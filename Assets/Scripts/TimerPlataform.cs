using UnityEngine;
using System.Collections;

public class TimerPlataform : MonoBehaviour {

	public float timeRemaining = 60f;
	public float timeRespawn = 60f;

	private float tR;
	private float tS;
	private bool destroy = false;
	private bool destroied = false;

	// Use this for initialization
	void Start () {
		tR = timeRemaining;
		tS = timeRespawn;
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy) { 
			InvokeRepeating ("decreaseTimeRemaining", 0.05f, 1f);	//repeatedly invokes the function 
			destroy = false;										//decrements the time 
		}
		else if (tR < 0) {
			destroied = true;
			CancelInvoke();
			tR = timeRemaining;
			gameObject.transform.collider2D.enabled = false;		//Hide the collider of block
			gameObject.transform.renderer.enabled = false;			//Hide the render of block			
		}
		else if (destroied) {
			InvokeRepeating ("decreaseTimeRespawn", 0.05f, 1f);
			destroied = false;
		}
		else if (tS < 0) {
			CancelInvoke();	
			tS = timeRespawn;
			gameObject.transform.collider2D.enabled = true;
			gameObject.transform.renderer.enabled = true;
		}
	}
	void decreaseTimeRemaining()
	{
		tR --;
	}
	void decreaseTimeRespawn()
	{
		tS --;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Foot")
		destroy = true;
	}
}

