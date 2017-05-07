using UnityEngine;
using System.Collections;

public class MovingPlataform : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public float way = 0.0f;
	public float MaxWay = 100.0f;
	public bool h = true;
	public bool v = false;
	
	private float walkingDirectionx = 1.0f;
	private float walkingDirectiony = 1.0f;
	
	Vector3 walkAmount;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (h) { //move beetween the x
			walkAmount.x = walkingDirectionx * walkSpeed * Time.deltaTime;
			way = way + Mathf.Abs(walkAmount.x);
			if (way >= MaxWay) {
				walkAmount.x = walkAmount.x - (way - MaxWay)*walkingDirectionx;
				walkingDirectionx = (-1) * walkingDirectionx;
				way = 0;
			}
		}
		if (v) { //move beetween the y
			walkAmount.y = walkingDirectiony * walkSpeed * Time.deltaTime;
			way = way + Mathf.Abs(walkAmount.y);
			if (way >= MaxWay) {
				walkAmount.y = walkAmount.y - (way - MaxWay)*walkingDirectiony;
				walkingDirectiony = (-1) * walkingDirectiony;
				way = 0;
			}
		}
		transform.Translate (walkAmount);
		
	}
	
}
