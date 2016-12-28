using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 13;
		countText.text = "Cubes remaining: " + count;
		winText.text = "";

		// Add our sounds to a dictionary for easy lookup later.
		//audioMap = new Dictionary<string, Audio> ();
		audioMap = new Dictionary<string, AudioSource>();
		foreach (AudioSource audio in GetComponents<AudioSource>()) {
			audioMap.Add (audio.clip.name, audio);
		}

		HideMenu ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Called before each physics update.
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
		
	}

	// Setup trigger.
	void OnTriggerEnter(Collider other) {

		// Inactivate objects tagged as "Pick Up".
		if (other.CompareTag ("Pick Up")) {

			audioMap ["pickup"].Play ();
			
			// Set cube as inactive.
			other.gameObject.SetActive (false);

			// Increase counter.
			count--;
			UpdateCountText ();
		}

		Destroy (other.gameObject);
	}

	void UpdateCountText() {
		countText.text = "Cubes remaining: " + count.ToString ();
		if (count == 0) {
			audioMap ["level_complete"].Play ();
			winText.text = "You Win!";
			ShowMenu ();
		}
	}

	void HideMenu() {
		// Hide text and disable button.
		playAgainButton.interactable = false;
		playAgainButton.GetComponentInChildren<Text> ().text = "";

		// Button's disabled color has alpha=0.
		playAgainButton.image.enabled = false;
	}

	void ShowMenu() {
		// Show text and enable button.
		playAgainButton.interactable = true;
		playAgainButton.GetComponentInChildren<Text>().text = "Play Again?";

		playAgainButton.image.enabled = true;
	}

	// Public member is available via editor.
	public float speed;

	// UI text count.
	public Text countText;

	// UI text "win" message.
	public Text winText;

	// UI text asking to restart round.
	public Button playAgainButton;

	private Rigidbody rb;
	private int count;
	private Dictionary<string, AudioSource> audioMap;
}
