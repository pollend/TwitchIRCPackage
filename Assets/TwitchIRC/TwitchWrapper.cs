using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using TwitchIntegration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;


namespace TwitchIntegration
{
	public class TwitchWrapper : MonoBehaviour {
		[System.Serializable]
		public class TwitchMessageEvent : UnityEvent<TwitchMessage> {}

		[System.Serializable]
		public class ServerNotice : UnityEvent<NoticeMessageArgs> {}

		[System.Serializable]
		public class RoomStateEvent : UnityEvent<RoomStateArgs> {}

		[System.Serializable]
		public class SubscribeEvent : UnityEvent<SubscribeArgs> {}

		[System.Serializable]
		public class OnOperatorEvent : UnityEvent<OperatorArgs> {}

		[System.Serializable]
		public class JoinChannel : UnityEvent<UserChannelArgs> {}

		[System.Serializable]
		public class UserStateEvent : UnityEvent<UserstateArgs> {}


		private event EventHandler syncHandle;


		public TwitchMessageEvent messageEvent;
		public ServerNotice serverNoticeEvent;
		public RoomStateEvent roomStateEvent;
		public SubscribeEvent onSubscribeEvent;
		public JoinChannel onJoinChannelEvent;
		public OnOperatorEvent OperatorChangeEvent;
		public UnityEvent onConnected;
		public RoomStateEvent onRoomstateEvent;
		public UserStateEvent onUserstateEvent;

		public TwitchIrcClient client{ get; private set; }
		private List<IrcChannel> ircChannels;

		[SerializeField]
		private string[] channels;
		public string account = "";
		public string oauth  = "";

		public bool enableTags = false;
		public bool enableMembership = false;
		public bool enableCommands = false;

		public bool enableSSL = true;

		public ReadOnlyCollection<IrcChannel> GetConnectedChannels{ get{ return ircChannels.AsReadOnly (); } }

		protected virtual void Awake()
		{

			ircChannels = new List<IrcChannel> ();
			client = new TwitchIrcClient ();

			client.OnMessage += (object sender, TwitchMessage e) => {
				syncHandle += (object sr, EventArgs ev) => 
				{
				if(messageEvent != null)
					messageEvent.Invoke(e);
				};
			};

			client.OnJoinChannel += (object sender, UserChannelArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(this.onJoinChannelEvent != null)
						onJoinChannelEvent.Invoke(e);
				};
			
			};

			client.OnOperatorChange += (object sender, OperatorArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(serverNoticeEvent != null)
						OperatorChangeEvent.Invoke(e);
				};
			};

			client.OnRoomState += (object sender, RoomStateArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(onRoomstateEvent != null)
						onRoomstateEvent.Invoke(e);
				};
			};
			client.OnSubscribe += (object sender, SubscribeArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(onSubscribeEvent != null)
						onSubscribeEvent.Invoke(e);
				};
			};
			client.OnUserState += (object sender, UserstateArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(onUserstateEvent != null)
						onUserstateEvent.Invoke(e);
				};
			};

			client.NoticeMessage += (object sender, NoticeMessageArgs e) => {
				syncHandle+= (object SpriteRenderer, EventArgs ev) => {
					if(serverNoticeEvent != null)
						serverNoticeEvent.Invoke(e);
				};
			};

			client.OnConnected += (object sender, System.EventArgs e) => {
				if(enableTags)
					client.EnableTags();
				if(enableMembership)
					client.EnableMembership();
				if(enableCommands)
					client.EnableCommands();
				
				if(channels != null)
				{
					for(int x = 0 ; x < channels.Length; x++)
					{
						TwitchJoinChannel(channels[x]);
					}
				}
				syncHandle += (object sr, EventArgs ev) => {
					if(onConnected != null)
					onConnected.Invoke();
				};
			};
		}

		public virtual void Update()
		{

			var handle = syncHandle;

			if (handle != null) {
				handle (this, new EventArgs ());
				syncHandle = null;
			}

		}

		public void TwitchJoinChannel(string channel)
		{
			ircChannels.Add (client.joinChannel (channel));
		}

		// Use this for initialization
		protected virtual void Start () {
			if (account != "" && oauth != "") {
				Connect ();
			}
		}

		protected virtual void OauthWebsite()
		{
			Application.OpenURL("http://www.twitchapps.com/tmi/");
		}

		public virtual  void Connect()
		{
			client.Connect (enableSSL, account, oauth);
		}

		public void SendTwitchMessage(string message,int time,int priority,IrcChannel channel)
		{
			client.SendMessage (channel, time, priority, message);
		}

		public void SendPrivateTwitchMessage(string message,int time,int priority,TwitchUser user,IrcChannel channel)
		{
			client.SendMessagePrivate (channel, time, priority,user, message);
		}

		protected virtual void OnDestroy()
		{
			client.Disconnect ();
		}

	}
}
