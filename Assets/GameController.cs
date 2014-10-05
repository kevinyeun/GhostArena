using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;

//using UnityEditor;

using AssemblyCSharp;

public class GameController : MonoBehaviour {

	public static string apiKey = "3c983338d9d5f2917ccd0de3eb8b109a1bb40ba0b16f8d59ed40fc066d17ce17";
	public static string secretKey = "b465f2a3e3dd5753351ac46c35db7a3a22c0ef11449b3db6c8821d69c247f16b";
	public static string roomid = "1015565096";
	public static string username;
	public static GameObject player;
	Transform mainCamera;

	
	Listener listen = new Listener();

	public static float speed = 0.1f;

	// Use this for initialization
	void Start () {
		WarpClient.initialize(apiKey,secretKey);
		WarpClient.GetInstance().AddConnectionRequestListener(listen);
		WarpClient.GetInstance().AddChatRequestListener(listen);
		WarpClient.GetInstance().AddLobbyRequestListener(listen);
		WarpClient.GetInstance().AddNotificationListener(listen);
		WarpClient.GetInstance().AddRoomRequestListener(listen);
		WarpClient.GetInstance().AddUpdateRequestListener(listen);
		WarpClient.GetInstance().AddZoneRequestListener(listen);

		//Debug.Log (WarpClient.GetInstance().GetOnlineUsers().);
		
		// join with a unique name (current time stamp)
		username = System.DateTime.UtcNow.Ticks.ToString();
		WarpClient.GetInstance().Connect(username);
		//Debug.Log (WarpClient.GetInstance ().GetConnectionState() == WarpConnectionState.CONNECTING);
		//EditorApplication.playmodeStateChanged += OnEditorStateChanged;
		//addPlayer();
		player = PlayerController.addPlayer(username, 0f, 0f, 0f);
		mainCamera = player.GetComponentInChildren< Camera >().transform;
		initializePlayers();
	}

	public static void initializePlayers() {
		WarpClient.GetInstance().GetLiveRoomInfo(roomid);
	}

	public static void addPlayer(float x, float y, float z)
	{

		//obj.transform.position = new Vector3(x,y,z);
	}

	// Update is called once per frame
	void Update () {
		Vector3 oldPos = player.transform.position;
		Vector3 oldScale = player.transform.localScale;
		if (Input.GetKey ("right")) {
			player.transform.position = new Vector3 (oldPos.x + speed, oldPos.y, oldPos.z);
			player.transform.localEulerAngles = new Vector3 (0, 0, 90f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -90f);
		} else if (Input.GetKey ("left")) {
			player.transform.position = new Vector3 (oldPos.x - speed, oldPos.y, oldPos.z);
			player.transform.localEulerAngles = new Vector3 (0, 0, 270f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -270f);
		} else if (Input.GetKey ("up")) {
			player.transform.position = new Vector3 (oldPos.x, oldPos.y + speed, oldPos.z);
			player.transform.localEulerAngles = new Vector3 (0, 0, 180f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -180f);
		} else if (Input.GetKey ("down")) {
			player.transform.position = new Vector3 (oldPos.x, oldPos.y - speed, oldPos.z);
			player.transform.localEulerAngles = new Vector3 (0, 0, 0f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -0f);
		}
	}
}
