//Tutorial
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; //Singleton Muster
	public CreateGrid boardScript;

	// Use this for initialization
	void Awake () {
		if (instance == null) //Singleton
			instance = this; //Singleton
		else if (instance != this) //Singleton
			Destroy (gameObject);	//Singleton

		DontDestroyOnLoad (gameObject); //Not Destroyed when new scenes are loaded
		boardScript = GetComponent<CreateGrid> ();
		InitGame ();
	}

	void InitGame(){
		//boardScript.Start ();
	}

	public void GameOver(){
		enabled = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
