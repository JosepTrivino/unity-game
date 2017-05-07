using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	public GameObject music;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseUpAsButton(){
		music = GameObject.Find("Music");
		music.audio.Pause ();
		audio.Play ();
		Invoke ("Sound", audio.clip.length);
	}
	void Sound(){
		Application.Quit();
	}
}
