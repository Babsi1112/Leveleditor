//Tutorial
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; //Singleton Muster
	public ImportText boardScript;

	// Use this for initialization
	void Awake () {
		if (instance == null) //Singleton
			instance = this; //Singleton
		else if (instance != this) //Singleton
			Destroy (gameObject);	//Singleton

		DontDestroyOnLoad (gameObject); //Not Destroyed when new scenes are loaded
		boardScript = GetComponent<ImportText> ();
		InitGame ();
	}

	void InitGame(){
		//boardScript.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
