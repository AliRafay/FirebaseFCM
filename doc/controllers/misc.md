# Misc

```csharp
MiscController miscController = client.MiscController;
```

## Class Name

`MiscController`


# FCM Message POST

Send Direct Message to Device with given id. HTTP Request.

```csharp
FCMMessagePOSTAsync(
    string authorization,
    Models.FCMMessagePOSTRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `authorization` | `string` | Header, Required | - |
| `body` | [`Models.FCMMessagePOSTRequest`](../../doc/models/fcm-message-post-request.md) | Body, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
string authorization = "key=AAAANEY1wb8:APA91bFef9HCm0CJKp8v77rbQQwRtHGzn0RGJ8YJNkLEPvCAHuz-yxQqG5-77hKnO9d2lIJNKpE7R56CaAHrabhWMkoGW68-KleWggje4404hwAO63XyLsRfto2LRAq3YOVXHmM2bj1W";
var body = new FCMMessagePOSTRequest();
body.To = "";
body.Data = new Data();
body.Data.Body = "First Notification";
body.Data.Title = "ALT App Testing";

try
{
    await miscController.FCMMessagePOSTAsync(authorization, body);
}
catch (ApiException e){};
```

