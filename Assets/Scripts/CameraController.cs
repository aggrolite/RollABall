using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	public GameObject player;

	private Vector3 offset;
}
