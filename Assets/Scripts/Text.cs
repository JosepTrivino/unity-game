using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {
	
	public GameObject quad;
	// Use this for initialization
	void Start () {
		quad.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			quad.SetActive (true);
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		quad.SetActive (false);
	}
		
}
