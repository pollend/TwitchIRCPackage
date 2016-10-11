##Message Event (TwitchMessage)

Twitch Message is the general message payload for a message sent in twitch chat.

```
public string emoteSet { get; private set; }
public IrcChannel channel { get; private set; }
public string rawMessage { get; private set; }
public string displayName{ get; private set; }
public int userId{ get; private set; }
public bool turbo{ get; private set; }
public bool isMod{ get; private set; }
public string message{ get; private set; }
public bool subscriber{ get; private set; }
public Color color { get; private set; }
public UserType userType { get; private set; }
public List<KeyValuePair<string,string>> badges { get; private set; }
public TwitchUser twitchUser { get; private set; }
```