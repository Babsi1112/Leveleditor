﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 7.0f;

	//items
	private int coins = 0;
	private int bombs = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D))
			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.A))
			transform.position -= new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.W))
			transform.position += new Vector3 (0.0f, speed * Time.deltaTime, 0.0f);
		if (Input.GetKey (KeyCode.S))
			transform.position -= new Vector3 (0.0f,speed * Time.deltaTime, 0.0f);

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("coin"))
		{
			Destroy(other.gameObject);
			coins ++;
			Debug.Log ("coins: " +coins);
		}
		if(other.gameObject.CompareTag("bomb"))
		{
			Destroy(other.gameObject);
			bombs++;
			Debug.Log ("bombs: "+bombs);
		}
	}
}
