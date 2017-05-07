using UnityEngine;
using System.Collections;
using System;

public class LoadLevel : MonoBehaviour {
	static public bool[] lockLevel = new bool[6]; 
	public GameObject lvl2;
	public GameObject lvl3;
	public GameObject lvl4;
	public GameObject lvl5;
	public GameObject lock2;
	public GameObject lock3;
	public GameObject lock4;
	public GameObject lock5;

	private string namelevel;
	private int levels = 5;

	// Use this for initialization
	void Start () {
		for(int i = 2; i <= levels; ++i){
			namelevel = "Level" + Convert.ToChar(i);
			int state = PlayerPrefs.GetInt(namelevel, 0);   //0 is default value, when "Level1State" has never been saved before 
			
			if (state == 1)
				LoadLevel.lockLevel[i] = true;
			else
				LoadLevel.lockLevel[i] = false;
		}
	}
	
	// Update is called once per frame

	void Update () {
		lvl2.SetActive (lockLevel [2]);
		lvl3.SetActive (lockLevel [3]);
		lvl4.SetActive (lockLevel [4]);
		lvl5.SetActive (lockLevel [5]);
		lock2.SetActive (!lockLevel [2]);
		lock3.SetActive (!lockLevel [3]);
		lock4.SetActive (!lockLevel [4]);
		lock5.SetActive (!lockLevel [5]);
	}

	public bool CheckLock(int levelCheck){
		return lockLevel[levelCheck];
	}
}
