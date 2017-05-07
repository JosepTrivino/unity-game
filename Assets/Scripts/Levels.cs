using UnityEngine;
using System;

public class Levels : MonoBehaviour {

	// Use this for initialization
	public int lvl;
	private int levels = 5;
	public GameObject music;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseUpAsButton(){
		ResumeText.resum = true;
		Time.timeScale = 1;
		music = GameObject.Find ("Music");
		music.audio.Pause ();
		audio.Play ();
		Invoke ("Sound", audio.clip.length);
	}
	void Sound(){
		music.audio.Play ();
		if (Application.loadedLevel == 7)
			Destroy (music);
		if (Application.loadedLevel == 0)
			music.transform.audio.playOnAwake = false;
		if (lvl <= levels && lvl > 1 && !LoadLevel.lockLevel [lvl]) {
			LoadLevel.lockLevel [lvl] = true;
			PlayerPrefs.SetInt ("Level" + Convert.ToChar (lvl), 1);
		}
		Application.LoadLevel (lvl);
	}
}