using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float alpha = 2.0f;
	public float normalSpeed = 1.0f;
	public float walkSpeed = 1.0f;
	public float MaxWay = 100.0f;
	public int life = 8;
	public GameObject sensor;
	public GameObject deathmonster;
	public GameObject Deadmusic;

	private float angle = 0f;
	private float posPlayer;
	private bool search = false;
	private float walkingDirection = 1.0f;
	private float positionX;
	public float positionMaxX;
	public float positionMinX;	
	private bool right = true; //boolean to know in which way we are going (left or right)
	private Sensor script;
	private Vector3 walkAmount;

	// Use this for initialization
	void Start () {
		Deadmusic = GameObject.Find ("deathmonster(Clone)");
		if(Deadmusic == null)
			Deadmusic = (GameObject) Instantiate(deathmonster,transform.position, transform.rotation);
		positionMaxX = transform.position.x + MaxWay;
		positionMinX = transform.position.x - MaxWay;
	}
	
	// Update is called once per frame
	void Update () {

		script = sensor.GetComponent <Sensor>();
		search = script.search;
		posPlayer = script.posPlayer;
		if (search) { //if the sensor detects de player, we have to go to him
			walkSpeed = normalSpeed * alpha;
			if (posPlayer >= transform.position.x) {
				angle = 0;
				right = true;
			} else {
				angle = 180;
				right = false;
			}
	
		} else
			walkSpeed = normalSpeed;
		transform.eulerAngles = new Vector3 (0f, angle, 0f);
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if ((positionMaxX <= walkAmount.x + transform.position.x) && right) {
						right = false;
						angle = 180;
						walkAmount.x = positionMaxX - transform.position.x; //remaining space to de limit
				} 
		else if ((positionMinX >= transform.position.x - walkAmount.x) && !right) {
						right = true;
						angle = 0;
						walkAmount.x = transform.position.x - positionMinX; //remaining space to de limit
				}
		transform.Translate (walkAmount);
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.tag == "Shot") { //if it's shoot -1 life
			Deadmusic.audio.Play();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		
	}
	

}
