using UnityEngine;
using System.Collections;

public class FinalMonster : MonoBehaviour {
	
	public float alpha = 2.0f;
	public float normalSpeed = 1.0f;
	public float walkSpeed = 1.0f;
	public float MaxWay = 100.0f;
	public int life = 8;
	public int midlife = 4;
	public GameObject sensor;
	public GameObject launcher;
	public GameObject wall;
	public float fireRate = 0.5F;
	public GameObject shot;
	public float speed;
	public GameObject deathmonster;
	public GameObject Deadmusic;
	public Sprite monster2;
	public float positionMaxX;
	public float positionMinX;	
	public bool search = true;

	private float nextFire = 0.0F;
	private float angle = 0f;
	private float posPlayer;
	private float walkingDirection = 1.0f;
	private float positionX;
	private bool right = true; //boolean to know in which way we are going (left or right)
	private Sensor script;
	private Vector3 walkAmount;
	private bool first = true;

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
			
		} else {
			walkSpeed = normalSpeed;
			first = true;
		}
			
		transform.eulerAngles = new Vector3 (0f, angle, 0f);
		if (life > midlife && search) {
			if (first){
				nextFire = Time.time + 0.6f * fireRate;
				first = false;
			}
			else if(!first && (Time.time > nextFire)){ //if the player press Z, and gun is avaiable and the rate fire it's ok.
				audio.Play ();
				nextFire = Time.time + fireRate;
				GameObject clone;
				clone = (GameObject) Instantiate(shot,launcher.transform.position, transform.rotation);
				if(angle.Equals(180)){ //choose the direction of the shot, depends on the direction of the character.
					clone.rigidbody2D.velocity = new Vector2(-speed,0f);
					clone.rigidbody2D.rotation = 180;
				}
				else
					clone.rigidbody2D.velocity = new Vector2(speed,0f);
			}	
		} 
		else if(life <= midlife){
						(transform.GetComponent<SpriteRenderer>().sprite) = monster2;
						walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
						if ((positionMaxX <= walkAmount.x + transform.position.x) && right) {
								right = false;
								angle = 180;
								walkAmount.x = positionMaxX - transform.position.x; //remaining space to de limit
						} else if ((positionMinX >= transform.position.x - walkAmount.x) && !right) {
								right = true;
								angle = 0;
								walkAmount.x = transform.position.x - positionMinX; //remaining space to de limit
						}
						transform.Translate (walkAmount);
				}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.tag == "Shot") { //if it's shoot -1 life
			Destroy (other.gameObject);
			--life;
			if(life == 0){
				Deadmusic.audio.Play();
				Destroy (gameObject);
				Destroy (wall);
			}
		}
		
	}
}
