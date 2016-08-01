using System;
using UnityEditor;
using UnityEngine;

namespace TwitchIntegration
{
	[CustomEditor(typeof(TwitchWrapper))]
	public class TwitchWrapperEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			if (GUILayout.Button ("Get Oauth Token")) {
				Application.OpenURL("http://www.twitchapps.com/tmi/");
			}
			base.OnInspectorGUI ();
		}
	}
}

