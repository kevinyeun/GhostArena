using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;

using AssemblyCSharp;

public class PlayerController : MonoBehaviour
{
	public static Dictionary<string,GameObject> usernameToPlayer = new Dictionary<string,GameObject> ();
	float updateInterval;
	float timeSinceUpdate;
	Listener listen = new Listener(); 
	Vector3 prevPos;

	// Use this for initialization
	void Start ()
	{
		updateInterval = 0.1f;
		timeSinceUpdate = 0f;
		
		prevPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}


	public static GameObject addPlayer(string username, float x, float y, float z) {
		GameObject obj = (GameObject) Instantiate(Resources.Load("MainPlayer"));
		obj.transform.position = new Vector3 (x, y, z);
		Debug.Log (usernameToPlayer == null);
		usernameToPlayer[username] = obj;
		return obj;
	}

	void movePlayer(GameObject obj, float x, float y, float z) {
		obj.transform.position = new Vector3 (x, y, z);
	}

	void movePlayer(string username, float x, float y, float z) {
		usernameToPlayer[username].transform.position = new Vector3 (x, y, z);
	}

	// Update is called once per frame
	void Update ()
	{

		timeSinceUpdate += Time.deltaTime;

		if (timeSinceUpdate > updateInterval) {
			timeSinceUpdate = 0;
			if (!new Vector3(transform.position.x, transform.position.y, transform.position.z).Equals(prevPos)) {
				string json = "{\"x\":\""+transform.position.x+"\",\"y\":\""+transform.position.y+"\",\"z\":\""+transform.position.z+"\"}";
				listen.sendMsg(json);
				prevPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			}

		}

		WarpClient.GetInstance().Update();
	}
}
