# 🤖 Telegram Dicebear Avatar Bot

Bu bot Telegram orqali Dicebear API yordamida avatar yaratadi va foydalanuvchiga yuboradi.

## 🚀 Ishga tushirish

### 1. Bot yaratish
1. Telegram'da [@BotFather](https://t.me/botfather) ga murojaat qiling
2. `/newbot` buyrug'ini yuboring
3. Bot nomi va username'ini kiriting
4. Bot tokenini oling

### 2. Loyihani sozlash
\`\`\`bash
# Loyihani klonlash yoki yaratish
dotnet new console -n TelegramDicebearBot
cd TelegramDicebearBot

# Paketlarni o'rnatish
dotnet add package Telegram.Bot
\`\`\`

### 3. Bot tokenini sozlash
Environment variable orqali:
\`\`\`bash
# Windows
set TELEGRAM_BOT_TOKEN=your_bot_token_here

# Linux/Mac
export TELEGRAM_BOT_TOKEN=your_bot_token_here
\`\`\`

Yoki `Program.cs` faylidagi `YOUR_BOT_TOKEN_HERE` o'rniga to'g'ridan-to'g'ri token kiriting.

### 4. Ishga tushirish
\`\`\`bash
dotnet run
\`\`\`

## 📱 Foydalanish

### Qo'llab-quvvatlanadigan buyruqlar:
- `/fun-emoji [matn]` - Kulgili emoji avatar
- `/avataaars [matn]` - Avataaars uslubida avatar  
- `/bottts [matn]` - Robot uslubida avatar
- `/pixel-art [matn]` - Pixel art uslubida avatar
- `/help` - Yordam ma'lumotlari

### Misollar:
- `/fun-emoji Alisher` - "Alisher" so'zidan fun-emoji uslubida avatar
- `/bottts robot123` - "robot123" so'zidan robot uslubida avatar
- `/avataaars John Doe` - "John Doe" so'zidan avataaars uslubida avatar

## 🔧 Xususiyatlar

✅ 4 xil Dicebear uslubi  
✅ Bir nechta so'zli seed qo'llab-quvvatlash  
✅ Xatoliklarni qayta ishlash  
✅ Konsolga log yozish  
✅ Yordam buyrug'i  
✅ Foydalanuvchi do'stona xabarlar  

## 🛠️ Texnik ma'lumotlar

- **.NET 8** - Asosiy framework
- **Telegram.Bot** - Telegram API kutubxonasi
- **HttpClient** - Dicebear API bilan aloqa
- **Dicebear API v8.x** - Avatar yaratish xizmati

## 📊 Log misollar

\`\`\`
📨 Xabar olindi: 123456789 (@username) - /fun-emoji Alisher
🎨 Avatar yaratilmoqda: Style=fun-emoji, Seed=Alisher
🌐 API so'rovi: https://api.dicebear.com/8.x/fun-emoji/png?seed=Alisher
✅ Rasm olindi: 15234 bytes
✅ Avatar muvaffaqiyatli yuborildi: fun-emoji - Alisher
