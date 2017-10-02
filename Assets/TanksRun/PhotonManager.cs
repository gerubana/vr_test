using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.PunBehaviour {

	public static PhotonManager instance;
	public static GameObject localPlayer;

	void Awake()
	{
		if (instance != null) 
		{
			DestroyImmediate (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
		instance = this;
	}

	void Start()
	{
		//PhotonNetwork.ConnectUsingSettings("0.1");  //連至大廳
		PhotonNetwork.ConnectUsingSettings ("Tanks_v1.0");
	}

	public void JoinGameRoom()
	{
		RoomOptions option = new RoomOptions ();
		option.MaxPlayers = 4;
		PhotonNetwork.JoinOrCreateRoom ("Fighting Room",option,null);
	}


	public override void OnJoinedRoom()
	{
		Debug.Log ("您已經進入遊戲");

		// 如果是Master Client, 即可建立/初始化,與載入遊戲場景
		if (PhotonNetwork.isMasterClient) 
		{
			PhotonNetwork.LoadLevel ("GameRoomScene");
		}
	}

	void OnLevelWasLoaded(int levelNumber)
	{
		// 若不在Photon的遊戲室內, 則網路有問題..
		if(!PhotonNetwork.inRoom)
			return;
		Debug.Log ("進入遊戲場景");

		localPlayer = PhotonNetwork.Instantiate (
			"Player",
			new Vector3 (0, 0.5f, 0),
			Quaternion.identity,
			0
		);
	}
}
