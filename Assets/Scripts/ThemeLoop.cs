using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The purpose of this class is to guarantee that our theme
 * music continues playing even when a new scene is loaded.
 * To do this, we must tell Unity that this Audio Source object
 * must never be destroyed. Then, in Start() we simply delete
 * newly created objects. This gives us a singleton-type Audio Source
 * object which loops continues to loop its clip.
 * There might be a better way to do this, but having the audio as a
 * seperate component was by far the cleanest solution I could come up
 * with at the time.
 */
public class ThemeLoop : MonoBehaviour {

	void Start () {
		// Delete newly created object.
		GameObject[] music = GameObject.FindGameObjectsWithTag ("Music");
		if (music.Length > 1) {
			Destroy(music[1]);
		}
	}
	
	void Awake() {
		// We don't want anything garbage collected.
		DontDestroyOnLoad (this.gameObject);
	}
}