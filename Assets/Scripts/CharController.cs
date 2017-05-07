using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {


	public float JumpPower = 7f;
	public float MovePower = 4f;
	public LayerMask FloorMask;
	public Transform FloorCheck;
	public Transform SpawnPoint;
	public bool doubleJump = false;
	public bool sprint = false;
	public float runSprint = 2f;
	public float run = 1f;
	public float sumY = 0f;
	public GameObject shot;
	public bool gun = false;
	public bool doubleJumpDone = false;
	public float fireRate = 0.5F;
	public bool finishGame;
	public bool pause;
	public float speed = 5;

	private AudioSource[] sounds;
	private int level;
	private bool keydown;
	private bool onFloor = true;
	private float nextFire = 0.0F;
	private Animator animation2;			
	private float rotation = 0f;	
	private float h;
	private float rad = 0.1f;
	private bool dead = false;


	// Use this for initialization
	void Start () {
		dead = false;
		finishGame = false;
		pause = false;
		animation2 = GetComponent<Animator>();
		level = Application.loadedLevel;
		rigidbody2D.velocity = new Vector2(0, 0);
		rotation = 180;
		transform.position = SpawnPoint.position;
		Time.timeScale = 1;
		sounds = gameObject.GetComponents <AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		onFloor = Physics2D.OverlapCircle (FloorCheck.position, rad, FloorMask); //detection of the floor
		if (onFloor)
			doubleJumpDone = false; //if is on the floor, doubleJump it's not done.
		Anim ();
		Sprint ();
		Movement ();
		Shoot ();
		transform.eulerAngles = new Vector3(0f, rotation,0f);
	}

	void Anim(){
		h = Input.GetAxis("Horizontal");
		animation2.SetBool("grounded", onFloor);
		animation2.SetFloat("speed", Mathf.Abs(h));
	}

	void Movement(){
		//UP BUTTON
		if(Input.GetAxis("Vertical")>0 && keydown){ 
			keydown = false;
			if((onFloor) || (!onFloor && doubleJump && !doubleJumpDone)){ //Jump with double jump
				sounds[0].Play ();
				if(!onFloor && doubleJump && !doubleJumpDone) doubleJumpDone = true; //if he can still make the doubleJump, done it
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpPower);
			}
		}
		if(Input.GetAxis("Vertical") == 0) keydown = true;
		
		//LEFT
		if (Input.GetAxis("Horizontal") < 0) {
			rigidbody2D.velocity = new Vector2(-MovePower * run, rigidbody2D.velocity.y);
			rotation = 0;
		}
		
		//RIGHT	
		if (Input.GetAxis("Horizontal") > 0) {
			rigidbody2D.velocity = new Vector2(MovePower * run, rigidbody2D.velocity.y);
			rotation = 180;
		}

		else if(Input.GetAxis("Horizontal") == 0 && onFloor) //We don't want the character to slip when he stops running
			rigidbody2D.velocity = new Vector2(0f,rigidbody2D.velocity.y);	  //when the player stops pressing key, the character stops completly.	


		if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) { //Pause game
			Time.timeScale = 0;  //Necessary put a button, otherwise there's a bug on the level 4 that I couldn't solutionate
			pause = true;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Enemy" && !dead){ //if the char impacts into an enemy, dies
			dead = true;
			die ();
		}
		else if(other.gameObject.tag == "Spine" && !dead){ //if the char impacts into spines, dies
			dead = true;
			die ();
		}
		else if(other.gameObject.tag == "Shot2" && !dead){ //if the char impacts into enemy shoot, dies
			dead = true;
			die ();
		}
		else if(other.gameObject.tag == "Finish" && !finishGame){ //if the char reaches goal, stop the game and put boolean true (followcamara observes)
			Time.timeScale = 0;
			finishGame = true;
		}
	}
	void Shoot () {
		if(Input.GetAxis("Fire") > 0 && gun && Time.time > nextFire){ //if the player press Z, and gun is avaiable and the rate fire it's ok.
			sounds[1].Play();
			nextFire = Time.time + fireRate;
			GameObject clone;
			clone = (GameObject) Instantiate(shot,transform.position, transform.rotation);
			if(rotation.Equals(180)) //choose the direction of the shot, depends on the direction of the character.
				clone.rigidbody2D.velocity = new Vector2(speed,0f);
			else{
				clone.rigidbody2D.velocity = new Vector2(-speed,0f);
				clone.rigidbody2D.rotation = 180;
			}
		}	
	}

	void Sprint(){
		if (Input.GetAxis("Sprint") > 0 && sprint && onFloor) { //if the player press X, and sprint is avaiable and the char is in the floor
			run = runSprint;
		}
		else {
			run = 1f;
		}
	}
	void die(){
		sounds [2].Play ();
		Application.LoadLevel (level); //On die, don't detroy, only restart the level
	}
	
}
