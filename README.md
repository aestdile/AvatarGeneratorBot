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
📨 Xabar olindi: 123456789 (@username) - /fun-emoji Mukhtor
🎨 Avatar yaratilmoqda: Style=fun-emoji, Seed=Mukhtor
🌐 API so'rovi: https://api.dicebear.com/8.x/fun-emoji/png?seed=Mukhtor
✅ Rasm olindi: 15234 bytes
✅ Avatar muvaffaqiyatli yuborildi: fun-emoji - Mukhtor

## ✍️ Muallif
👤 Mukhtor Eshboyev\
🔗 GitHub: [@aestdile](https://github.com/aestdile)

## 📞 Aloqa

Savollar yoki takliflar uchun:
- Issue yarating
- Telegram: [@aestdile](https://t.me/aestdile)
- Email: aestdile@gmail.com

---

⭐ Agar loyiha foydali bo'lsa, star bosishni unutmang!

## 🌐 Social Networks

<div align="center">
  <a href="https://t.me/aestdile"><img src="https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white" /></a>
  <a href="https://github.com/aestdile"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white" /></a>
  <a href="https://leetcode.com/aestdile"><img src="https://img.shields.io/badge/LeetCode-FFA116?style=for-the-badge&logo=leetcode&logoColor=black" /></a>
  <a href="https://linkedin.com/in/aestdile"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" /></a>
  <a href="https://youtube.com/@aestdile"><img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" /></a>
  <a href="https://instagram.com/aestdile"><img src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white" /></a>
  <a href="https://facebook.com/aestdile"><img src="https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white" /></a>
  <a href="mailto:aestdile@gmail.com"><img src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" /></a>
  <a href="https://twitter.com/aestdile"><img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" /></a>
  <a href="tel:+998772672774"><img src="https://img.shields.io/badge/Phone:+998772672774-25D366?style=for-the-badge&logo=whatsapp&logoColor=white" /></a>
</div>
