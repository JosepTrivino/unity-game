using UnityEngine;
using System.Collections;

public class ResumeText : MonoBehaviour {

	static public bool resum = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUpAsButton(){
		audio.Play ();
		resum = true;	
	}
}
