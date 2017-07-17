using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseClass : MonoBehaviour {
	public GameObject PlayerSlot;
	public Text Name;
	public Text Status;
	public Transform ScrollViewParent;
	public Image ProfilePic;
   
	Facepunch.Steamworks.Client steamClient;
	Facepunch.Steamworks.Friends steamFriend;
	
	// Use this for initialization
	void Start () {
		steamClient = new Facepunch.Steamworks.Client(220);

		if (steamClient.IsValid)
			foreach (var friend in steamClient.Friends.AllFriends)
			{
				GameObject _playerSlot = Instantiate(PlayerSlot);
				_playerSlot.transform.parent = ScrollViewParent;
				if(friend.IsOnline == true)
				{
				    
					Status.text = "Online";
				}
			   if (friend.IsAway)
				{
					Status.text = "Away";
				}
			 if (friend.IsSnoozing)
				{
					Status.text = "Snoozing";
					
					
				}
				Name.text = friend.Name;
				//ProfilePic = steamFriend.GetAvatar(Facepunch.Steamworks.Friends.AvatarSize.Medium ,friend.Id);
				
				 
				//Debug.Log($"{friend.Id}, {friend.Name}");

			}
		else
		{
			steamClient.Dispose();
			Debug.LogError("Cannot access steam, check all dependencies.");
		}
	}

	// Update is called once per frame
	void Update() {
  
	}
}
