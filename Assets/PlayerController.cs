using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public Transform background;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 oldPos = transform.position;

		if (Input.GetKeyDown ("right")) {
			transform.position = new Vector3 (oldPos.x + 0.5f, oldPos.y, oldPos.z);
		} else if (Input.GetKeyDown ("left")) {
			transform.position = new Vector3 (oldPos.x - 0.5f, oldPos.y, oldPos.z);
		}
	}
}
