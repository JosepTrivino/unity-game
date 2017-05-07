using UnityEngine;
using System.Collections;

public class FolllowCamara : MonoBehaviour {

	public Transform character;
	public Transform finish;
	public Transform begin;
	public GameObject textlevel;
	public GameObject textnext;
	public GameObject textquit;
	public GameObject textresume;
	public GameObject quad;
	public float edgeY = 5f;

	private float halfWidth;
	private float sumX;
	private float sumY;
	private bool endgame;
	private bool pause;
	private bool resum;

	// Use this for initialization
	void Start () {
		textlevel.SetActive (false);
		textnext.SetActive (false);
		textquit.SetActive (false);
		textresume.SetActive (false);
		quad.SetActive (false);
		halfWidth =  Camera.main.orthographicSize * Screen.width / Screen.height; //Width of the sceen, from the center to the extrems
	}
	
	// Update is called once per frame
	void Update () {

		endgame = character.GetComponent <CharController>().finishGame;
		pause = character.GetComponent <CharController> ().pause;
		resum = ResumeText.resum;

		if (pause)
			pausetext ();

		if (resum) {
			ResumeText.resum = false;
			textquit.SetActive (false);
			textresume.SetActive (false);
			quad.SetActive (false);
			Time.timeScale = 1;
			character.GetComponent <CharController> ().pause = false;
		}

		if (endgame)
			finishtext ();

		if (character.position.x < (begin.position.x + halfWidth))
			sumX = begin.position.x + halfWidth;
		else 
			sumX = character.position.x;

		if(character.position.y < edgeY)
			sumY = edgeY;
		else 
			sumY = character.position.y;

		if(character.position.x > (finish.position.x - halfWidth)) sumX = finish.position.x - halfWidth;
	    	transform.position = new Vector3 (sumX,  sumY, transform.position.z); 

	}

	void finishtext(){
		textlevel.SetActive (true);
		textnext.SetActive (true);
		quad.SetActive (true);
	}
	void pausetext(){
		Time.timeScale = 0;
		textquit.SetActive (true);
		textresume.SetActive (true);
		quad.SetActive (true);
			
	}
}