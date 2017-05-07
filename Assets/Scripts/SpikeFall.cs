using UnityEngine;
using System.Collections;

public class SpikeFall : MonoBehaviour {

	public bool fall = false;
	public float alpha = 1f;
	private float posX;
	private float posY;
	public GameObject temp;
	// Use this for initialization
	void Start () {
		posY = transform.position.y;
		transform.rigidbody2D.gravityScale =0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (!fall && other.gameObject.tag == "Player") {//detection of the player with the sensor
			fall = true;
			temp.SetActive (false); //disable the sensor
			transform.rigidbody2D.gravityScale = -Physics2D.gravity.y * alpha; //activate gravity and spike fall
		} else if(other.gameObject.tag != "Player") { //when the spike reaches the floor, returns to his position
			transform.rigidbody2D.gravityScale = 0f;
			transform.Translate (0f,transform.position.y - posY, 0f);
			fall = false;
			temp.SetActive (true);
		}
	}
}
