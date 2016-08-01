using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TwitchIntegration;
using System.Collections.Generic;

public class TwitchChatUI : MonoBehaviour {
	private TwitchWrapper wrapper;
	[SerializeField]
	private GameObject content;
	[SerializeField]
	private GameObject messageGo;

	void Start()
	{
		wrapper = GetComponent<TwitchWrapper> ();
	}

	public void SendTwitchMessage(GameObject inputField)
	{
		if (wrapper.GetConnectedChannels.Count == 0) {
			UnityEngine.Debug.Log ("You haven't subscribed to any channels");
		} else {
			InputField field = inputField.GetComponent<InputField> ();
			this.AddMessage (wrapper.account + " : " + field.text);
			wrapper.SendTwitchMessage (field.text,10,-1, wrapper.GetConnectedChannels [0]);
			field.text = "";
		}
	}

	public void OnConnected()
	{
		this.AddMessage ("Connected!");
	}

	public void AddTwitchMessage(TwitchMessage message)
	{
		AddMessage (message.twitchUser.name + " : " + message.message);
	}

	public void AddMessage(string message)
	{
		float contentHeight = 15;
		int childCount = content.transform.childCount;

		GameObject messageGameObject = UnityEngine.GameObject.Instantiate (messageGo);
		messageGameObject.GetComponent<Text> ().text = message;
		messageGameObject.transform.SetParent (content.transform);

		List<Transform> removed = new List<Transform>();

		foreach (Transform t in content.transform) {
			if (childCount > 100) {
				childCount--;
				removed.Add (t);
				return;
			}
			RectTransform rectTransform = t.gameObject.GetComponent<RectTransform> ();
			rectTransform.localPosition = new Vector3 (0, -contentHeight, 0);
			rectTransform.offsetMin = new Vector2 (0, rectTransform.offsetMin.y);
			rectTransform.offsetMax = new Vector2 (0, rectTransform.offsetMax.y);


			contentHeight += rectTransform.rect.height + 10;
		}
		content.GetComponent<RectTransform> ().sizeDelta = new Vector2 (content.GetComponent<RectTransform> ().sizeDelta.x, contentHeight);

		for (int x = 0; x < removed.Count; x++) {
			Destroy (removed[x]);
		}
	}



}
