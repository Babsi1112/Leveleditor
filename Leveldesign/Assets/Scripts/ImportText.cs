using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ImportText : MonoBehaviour {
	public TextAsset textFile;     // drop your file here in inspector

	public Transform player;
	public Transform floor_valid;
	public Transform floor_obstacle;
	public Transform bomb;
	public Transform wall;
	public Transform wallDestroyable;
	public Transform coin;
	public Transform finish;

	public const string sfloor_valid = "0";
	public const string sfloor_obstacle = "1";
	public const string sfloor_checkpoint = "2";
	public const string sstart = "S";
	public const string sbomb = "b";
	public const string scoin = "c";
	public const string swall = "W";
	public const string swalldestroy = "w";
	public const string sfinish = "Z";

	// Use this for initialization
	void Start () {
		string[][] jagged = readFile ();
		// create planes based on matrix
		for (int y = 0; y < jagged.Length; y++) {
			for (int x = 0; x < jagged[0].Length; x++) {
				switch (jagged [y] [x]) {
				case sstart:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					Instantiate (player, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sbomb:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					Instantiate (bomb, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case scoin:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					Instantiate (coin, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfloor_valid:
					Instantiate (floor_valid, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfinish:
					Instantiate (finish, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sfloor_obstacle:
					Instantiate (floor_obstacle, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case swall:
					Instantiate (wall, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case swalldestroy:
					Instantiate (wallDestroyable, new Vector3 (x, -y, 0), Quaternion.identity);
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
