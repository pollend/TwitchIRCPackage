##On Subscribe Event (SubscribeArgs)

This is a message sent to the client when a user subscribes to a channel.

```
public string displayName{get;private set;}
public Color color { get; private set; }
public List<KeyValuePair<string,string>> badges { get; private set; }
public string emoteSet { get; private set; }
public string msgId { get; private set; }
public TwitchUser twitchUser{ get; private set; }
public TwitchMessage.UserType userType { get; private set; }
public int userId{get;private set;}
public bool turbo{ get; private set; }
public int numberOfMonths{ get; private set; }
public int roomId{get;private set;}
public string systemMessage{ get; private set; }
public IrcChannel channel { get; private set; }
public string message{ get; private set; }
public bool isMod{ get; private set; }
public bool subscriber{ get; private set; }
```

