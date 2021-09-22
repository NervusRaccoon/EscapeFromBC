using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float damping = 1.5f;
	private Transform player;

	void Update() 
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		if (player) 
		{
			Vector3 target;
			target = new Vector3 (player.position.x, player.position.y, transform.position.z);
			Vector3 currentPosition = Vector3.Lerp (transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}
