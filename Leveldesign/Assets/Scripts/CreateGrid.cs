using UnityEngine;
using System.Collections;

public class CreateGrid : MonoBehaviour {

	public Transform player;
	public GameObject[] floorTiles;
	public Transform floor_obstacle;
	public Transform bomb;
	public Transform wall;
	public Transform wallDestroyable;
	public Transform coin;
	public Transform movableWall;
	public Transform finish;
	public Transform key;
	public Transform door;
	
	public const string sfloor_valid = "0";
	public const string sfloor_obstacle = "1";
	public const string sfloor_checkpoint = "2";
	public const string sstart = "S";
	public const string sbomb = "b";
	public const string scoin = "c";
	public const string swall = "W";
	public const string swalldestroy = "w";
	public const string sfinish = "Z";
	public const string smovableWall = "m";
	public const string skey = "k";
	public const string sdoor = "d";


	public int GridWidth;
	public int GridHeight;
	public string[,] Grid; //Tutorial videogamedesign24
	
	public string[][] levelMap;

	public ImportText importedLevel;

	public Vector3 playerStartPos;

	/*void Awake(){
		CreateLevel ();
	}*/

	// Use this for initialization
	public void CreateLevel (int level) {
		importedLevel = GetComponent<ImportText> ();

		levelMap = importedLevel.readFile (level);
		GridWidth = levelMap [0].Length;
		GridHeight = levelMap.Length;

		Grid = new string[GridWidth, GridHeight];

		// create planes based on matrix
		for (int y = 0; y < GridHeight; y++) {
			for (int x = 0; x < GridWidth-1; x++) {

				//Spawn floor everywhere
				GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
				Instantiate (toInstantiate, new Vector3 (x, -y, 0f), Quaternion.identity);

				switch (levelMap [y] [x]) {
				case sstart:
				{
					Instantiate (player, new Vector3 (x, -y, 0f), Quaternion.identity);
					playerStartPos = new Vector3 (x,-y,0f);
					break;
				}
				case sbomb:
					Instantiate (bomb, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case scoin:
					Instantiate (coin, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case sfinish:
					Instantiate (finish, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case sfloor_obstacle:
					Instantiate (floor_obstacle, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case swall:
					Instantiate (wall, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case swalldestroy:
					Instantiate (wallDestroyable, new Vector3 (x, -y, 0f), Quaternion.identity);
					break;
				case smovableWall:
					Instantiate (movableWall, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case skey:
					Instantiate (key, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				case sdoor:
					Instantiate (door, new Vector3 (x, -y, 0), Quaternion.identity);
					break;
				}
			}
		}
	
	}

}
