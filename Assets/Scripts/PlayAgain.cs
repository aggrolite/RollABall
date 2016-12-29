using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(RestartGame);
	}

	// Restart scene, and overwrite objects.
	void RestartGame() {
		Debug.Log ("clicked");
		SceneManager.LoadScene ("MiniGame", LoadSceneMode.Single);
	}
}
