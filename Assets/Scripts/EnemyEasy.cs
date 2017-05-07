using UnityEngine;
using System.Collections;

public class EnemyEasy : MonoBehaviour {
		
	public float angle = 0f;
	public bool kill = false;
	public bool move = false;
	public bool boxmove = false;
	public float MaxWay = 100.0f;
	public float walkSpeed = 1.0f;
	public bool collision = false;
	public float way = 0.0f;

	public GameObject deathmonster;
	public GameObject Deadmusic;
	private float walkingDirection = 1.0f;
	private Vector3 walkAmount;
	// Use this for initialization
	void Start () {
		Deadmusic = GameObject.Find ("deathmonster(Clone)");
		if(Deadmusic == null)
			Deadmusic = (GameObject) Instantiate(deathmonster,transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (boxmove) { //move beetween boxes
						transform.eulerAngles = new Vector3 (0f, angle, 0f);
						walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
						way = way + walkSpeed;
						transform.Translate (walkAmount);
				} 
		else if (move) { //moves the exactly amount of MaxWay
						transform.eulerAngles = new Vector3 (0f, angle, 0f);
						walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
						way = way + walkAmount.x;
						if (way >= MaxWay) {
							angle = angle + 180;
							walkAmount.x = walkAmount.x - (way - MaxWay);
							way = 0;
						}
						transform.Translate (walkAmount);		
				}
	}

	void OnTriggerEnter2D(Collider2D other) {
				if (other.gameObject.tag == "Box" && boxmove) {
						if (angle.Equals (0f))
								angle = 180f;
						else
								angle = 0;
				}
				if (other.gameObject.tag == "Shot") {
					Deadmusic.audio.Play();
					Destroy (other.gameObject);
					Destroy (gameObject);
				}
				if (other.gameObject.tag == "Foot") {
					Deadmusic.audio.Play ();
					Destroy (gameObject);
				}
		}
}
