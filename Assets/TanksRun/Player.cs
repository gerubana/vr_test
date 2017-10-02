using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.PunBehaviour {
	Camera playerCam;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		playerCam = GetComponentInChildren<Camera> ();

		//判斷是否為本人
		if (!photonView.isMine)
		{
			playerCam.gameObject.SetActive (false);
		}
	}
}
