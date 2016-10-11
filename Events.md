# Events

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

##Server Notice Event (NoticeMessageArgs)

Notices are sent by the server and can be based of off commands sent by client or general changes in the state of the chat. The NoticeMessage Args has both a notice field along with the channel that the notice was sent from.

###Notices
```
SubsOn,
AlreadySubsOn,
SubsOff,
AlreadySubsOff,
SlowOn,
SlowOff,
r9kOn,
AlreadyR9kOn,
r9kOff,
AlreadyR9kOff,
HostOn,
badHostHosting,
hostOff,
hostsRemaining,
emoteOnlyOn,
alreadyEmoteOnlyOn,
emoteOnlyOff,
alreadyEmoteOnlyOff,
msgChannelSuspended,
timeoutSuccess,
banSuccess,
unbanSuccess,
badUnbanNoBan,
alreadyBanned,
unrecognizedCmd
```


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


##On Join Channel Event (UserChannelArgs)

This is a event sent when a user joins the channel.

```
public TwitchUser user{ get; private set; }
public IrcChannel channel{ get; private set; }
```

##Operator Change Event (OperatorArgs)

This event is sent when a user either gains or loses operator status.

```
public bool isOperator{ get; private set;}
public IrcChannel channel { get; private set;}
public TwitchUser user{ get; private set;}
```

##On Connected ()

This event notifies the client that the IRC library was able to connect to the server

##On Roomestate Event (RoomStateArgs)

Roomestate events occur when the state of a twitch chat room is changed. This can included
changing to subscriber only mode or when chat is placed in a slow delay mode.

```
public string broadcasterLang { get; private set; }
public bool r9kMode { get; private set; }
public bool subscribersOnly{ get; private set; }
public int slowDelay{ get; private set; }

public IrcChannel channel{ get; private set; }
public string raw{ get; private set; }
```

##On Userstate Event (UserstateArgs)

Userstate is sent after connection to the channel and after a PRIVMSG is sent to a channel

```
public string raw{ get; private set;}

public Color color{ get; private set; }
public string displayName{get;private set;}
public int[] emoteSet{ get; private set; }
public bool subscriber {get;private set;}
public bool mod { get; private set; }
public bool turbo{ get; private set; }
public TwitchMessage.UserType userType{ get; private set; }
```