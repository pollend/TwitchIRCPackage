
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