﻿using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ImportText : MonoBehaviour {
	public TextAsset textFile;     // drop your file here in inspector

	public Transform player;
	public Transform floor_valid;
	public Transform floor_obstacle;
	//public Transform floor_checkpoint;
	
	public const string sfloor_valid = "0";
	public const string sfloor_obstacle = "1";
	public const string sfloor_checkpoint = "2";
	public const string sstart = "S";

	// Use this for initialization
	void Start () {
		string[][] jagged = readFile ();
		Debug.Log (jagged [0] [0]);

		// create planes based on matrix
		for (int y = 0; y < jagged.Length; y++) {
			for (int x = 0; x < jagged[0].Length; x++) {
				switch (jagged [y] [x]) {
				case sstart:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					Instantiate (player, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfloor_valid:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfloor_obstacle:
					Instantiate (floor_obstacle, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfloor_checkpoint:
					//Instantiate (floor_checkpoint, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				}
			}
		}
	}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		string[][] readFile(){
		string text = textFile.text;
		string[] lines = Regex.Split(text, "\n");
		int rows = lines.Length;
		
		string[][] levelBase = new string[rows][];
		for (int i = 0; i < lines.Length; i++)  {
			string[] stringsOfLine = Regex.Split(lines[i], " ");
			levelBase[i] = stringsOfLine;
		}
		return levelBase;
	}
	
	
}