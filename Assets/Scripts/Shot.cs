using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed = 5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(speed * Time.deltaTime, 0,0);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Shot2" || other.gameObject.tag == "Shot") {
			Destroy (other.gameObject);
				}
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Envoirment" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "Foot") {
						Destroy (gameObject);
				}
	}
}
