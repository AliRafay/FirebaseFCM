
# FCM Message POST Request

## Structure

`FCMMessagePOSTRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `To` | `string` | Required | - |
| `Data` | [`Models.Data`](../../doc/models/data.md) | Required | - |

## Example (as JSON)

```json
{
  "to": "",
  "data": {
    "body": "First Notification",
    "title": "ALT App Testing"
  }
}
```

