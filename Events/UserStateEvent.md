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