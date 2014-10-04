using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	int NUM_TILES = 9;
	public Transform background;
	public Transform mainCamera;
	float speed;

	// Use this for initialization
	void Start ()
	{
		transform.localScale = new Vector3 (1f / NUM_TILES, 1f / NUM_TILES, 1);
		speed = 0.03f*5f / NUM_TILES;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 oldPos = transform.position;
		Vector3 oldScale = transform.localScale;

		if (Input.GetKey ("right")) {
			transform.position = new Vector3 (oldPos.x + speed, oldPos.y, oldPos.z);
			transform.localEulerAngles = new Vector3 (0, 0, 90f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -90f);
		} else if (Input.GetKey ("left")) {
			transform.position = new Vector3 (oldPos.x - speed, oldPos.y, oldPos.z);
			transform.localEulerAngles = new Vector3 (0, 0, 270f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -270f);
		} else if (Input.GetKey ("up")) {
			transform.position = new Vector3 (oldPos.x, oldPos.y + speed, oldPos.z);
			transform.localEulerAngles = new Vector3 (0, 0, 180f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -180f);
		} else if (Input.GetKey ("down")) {
			transform.position = new Vector3 (oldPos.x, oldPos.y - speed, oldPos.z);
			transform.localEulerAngles = new Vector3 (0, 0, 0f);
			mainCamera.localEulerAngles = new Vector3 (0, 0, -0f);
		}
	}
}
