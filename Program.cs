using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramDicebearBot;

class Program
{
    private static readonly HttpClient httpClient = new();
    private static ITelegramBotClient? botClient;
    
    private static readonly Dictionary<string, string> SupportedStyles = new()
    {
        { "/fun-emoji", "fun-emoji" },
        { "/avataaars", "avataaars" },
        { "/bottts", "bottts" },
        { "/pixel-art", "pixel-art" }
    };

    static async Task Main(string[] args)
    {
        Console.WriteLine("Telegram Dicebear Bot ishga tushmoqda...");

        var botToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
                    ?? "BOT_TOKEN_MUST_BE_HERE"; 

        if (string.IsNullOrWhiteSpace(botToken) || botToken.StartsWith("YOUR_"))
        {
            Console.WriteLine("Bot token yo'q yoki noto'g'ri. Iltimos, to'g'ri token kiriting.");
            return;
        }
        

        botClient = new TelegramBotClient(botToken);

        using CancellationTokenSource cts = new();

        try
        {
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Bot muvaffaqiyatli ulandi: @{me.Username}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bot ulanishida xatolik: {ex.Message}");
            return;
        }

        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        Console.WriteLine("Bot ishlayapti. To'xtatish uchun Enter tugmasini bosing...");
        Console.ReadLine();

        cts.Cancel();
    }


    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;
        var userId = message.From?.Id ?? 0;
        var username = message.From?.Username ?? "Unknown";

        Console.WriteLine($"Xabar olindi: {userId} (@{username}) - {messageText}");

        try
        {
            await ProcessMessageAsync(botClient, chatId, messageText, cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xabarni qayta ishlashda xatolik: {ex.Message}");
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Xatolik yuz berdi. Keyinroq urinib ko'ring.",
                cancellationToken: cancellationToken);
        }
    }

    static async Task ProcessMessageAsync(ITelegramBotClient botClient, long chatId, string messageText, CancellationToken cancellationToken)
    {
        if (messageText.ToLower() == "/help" || messageText.ToLower() == "/start")
        {
            var helpText =
            """
                🎨 **Dicebear Avatar Bot**
                
                **Qo'llab-quvvatlanadigan buyruqlar:**
                `/fun-emoji [matn]` - Kulgili emoji avatar
                `/avataaars [matn]` - Avataaars uslubida avatar
                `/bottts [matn]` - Robot uslubida avatar
                `/pixel-art [matn]` - Pixel art uslubida avatar

                **Misol:** `/fun-emoji Alisher`
                
                **Eslatma:** Buyruqdan keyin o'z ismingiz yoki istalgan matnni yozing.
            """;

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: helpText,
                parseMode: ParseMode.Markdown,
                cancellationToken: cancellationToken);
            return;
        }

        var parts = messageText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Iltimos, avatar olish uchun buyruqdan foydalaning.\nYordam uchun /help yuboring.",
                cancellationToken: cancellationToken);
            return;
        }

        var command = parts[0].ToLower();

        if (!SupportedStyles.ContainsKey(command))
        {
            if (command.StartsWith('/'))
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Noma'lum buyruq. Quyidagilardan birini ishlating:\n/fun-emoji, /bottts, /avataaars, /pixel-art\n\nYordam uchun /help yuboring.",
                    cancellationToken: cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Iltimos, avatar olish uchun buyruqdan foydalaning.\nYordam uchun /help yuboring.",
                    cancellationToken: cancellationToken);
            }
            return;
        }

        if (parts.Length < 2)
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Iltimos, buyruqdan keyin matn (seed) kiriting.\nMisol: {command} Ali",
                cancellationToken: cancellationToken);
            return;
        }

        var seed = string.Join(" ", parts.Skip(1));
        var style = SupportedStyles[command];

        Console.WriteLine($"Avatar yaratilmoqda: Style={style}, Seed={seed}");

        var processingMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Avatar yaratilmoqda...",
            cancellationToken: cancellationToken);

        try
        {
            var imageStream = await GetDicebearImageAsync(style, seed);
            
            if (imageStream != null)
            {
                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromStream(imageStream, $"{style}_{seed}.png"),
                    caption: $"🎨 **{style}** uslubida avatar\n🌱 Seed: `{seed}`",
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken);

                Console.WriteLine($"Avatar muvaffaqiyatli yuborildi: {style} - {seed}");
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Avatar yaratishda xatolik yuz berdi. Keyinroq urinib ko'ring.",
                    cancellationToken: cancellationToken);
                
                Console.WriteLine($"Avatar yaratishda xatolik: {style} - {seed}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rasm yuborishda xatolik: {ex.Message}");
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Rasmni yuborishda xatolik yuz berdi.",
                cancellationToken: cancellationToken);
        }
        finally
        {
            try
            {
                await botClient.DeleteMessageAsync(
                    chatId: chatId,
                    messageId: processingMessage.MessageId,
                    cancellationToken: cancellationToken);
            }
            catch
            {

            }
        }
    }

    static async Task<Stream?> GetDicebearImageAsync(string style, string seed)
    {
        try
        {
            var encodedSeed = Uri.EscapeDataString(seed);
            var url = $"https://api.dicebear.com/8.x/{style}/png?seed={encodedSeed}";
            
            Console.WriteLine($"API so'rovi: {url}");

            var response = await httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine($"Rasm olindi: {imageBytes.Length} bytes");
                return new MemoryStream(imageBytes);
            }
            else
            {
                Console.WriteLine($"API xatoligi: {response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dicebear API xatoligi: {ex.Message}");
            return null;
        }
    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API xatoligi:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine($"Polling xatoligi: {errorMessage}");
        return Task.CompletedTask;
    }
}
