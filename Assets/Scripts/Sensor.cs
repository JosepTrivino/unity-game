using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	public bool search = false;
	public float posPlayer = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") { //player has entered the detection zone
			posPlayer = other.gameObject.transform.position.x;
			search = true;
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other) { //player has left the detection zone
		if (other.gameObject.tag == "Player")
			search = false;
	}
	void OnTriggerStay2D(Collider2D other) { //player is in the detection zone
		if (other.gameObject.tag == "Player")
			posPlayer = other.gameObject.transform.position.x;
	}
}
