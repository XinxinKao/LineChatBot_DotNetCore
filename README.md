# LineChatBot_DotNetCore

## Overview
以 .net core 3.1 搭配 LineBotSDK ，建立簡易的LINE Bot，可以回應用戶訊息(Reply)和主動推播訊息(Push)。

### Package
- [Line.Bot.SDK](https://www.nuget.org/packages/Line.Bot.SDK)

### How to use
- 建立好LINE Bot帳號，並取得Channel Secret與Channel Access Token
- 修改 appsettings.json 檔案中的設定
```
"LineSetting": 
{
    "ChannelSecret": "Your_Line_Channel_Secret",
    "AccessToken": "Your_Line_Access_Token"
}
```
