using UnityEngine;
using System.Collections;

public class NotDestroy : MonoBehaviour {

	void Awake () {
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
