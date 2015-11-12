//Tutorial
using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float levelStartDelay = 2f;
	public float turnDelay = 0.1f;                          //Delay between each Player turn.
	public float wallsDelay = 5.0f;
	public static GameManager instance = null; //Singleton Muster
	[HideInInspector] public bool playersTurn = true;       //Boolean to check if it's players turn, hidden in inspector but public
	public CreateGrid boardScript;

	public int playerBombs = 0;
	public int playerCoins = 0;
	public int playerLife = 0;

	private Text levelText;
	private Text itemText;
	private GameObject levelImage;
	public int level = 1;                                  //Current level number, expressed in game as "Day 1".
	//private List<Enemy> enemies;                          //List of all Enemy units, used to issue them move commands.
	private List<Wall> walls;
	private bool enemiesMoving; 							//Boolean to check if enemies are moving.
	private bool doingSetup;
	private bool wallsMoving;


	// Use this for initialization
	void Awake () {
		if (instance == null) //Singleton
			instance = this; //Singleton
		else if (instance != this) //Singleton
			Destroy (gameObject);	//Singleton
		walls = new List<Wall> ();
		DontDestroyOnLoad (gameObject); //Not Destroyed when new scenes are loaded
		boardScript = GetComponent<CreateGrid> ();
		InitGame ();
	}

	private void OnLevelWasLoaded(int index){
		//level++;
		InitGame ();
	}


	void InitGame(){
		doingSetup = true;
		//itemText = GameObject.Find ("itemText").GetComponent<Text> ();
		//itemText.text = "";
		levelImage = GameObject.Find ("Levelimage");
		levelText = GameObject.Find ("Leveltext").GetComponent<Text> ();
		levelText.text = "Level " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		boardScript.CreateLevel(level);
	}

	private void HideLevelImage(){
		levelImage.SetActive (false);
		doingSetup = false;
	}

	public void GameOver(){
		Debug.Log ("gameOver");
		//enabled = false;
		Application.LoadLevel (Application.loadedLevel);
	}
	// Update is called once per frame
	void Update () {

			if (!wallsMoving)
				StartCoroutine (MoveWalls());
			//Check that playersTurn or enemiesMoving or doingSetup are not currently true.
			if(playersTurn || enemiesMoving || doingSetup)
				
				//If any of these are true, return and do not start MoveEnemies.
				return;
			
			//Start moving enemies.
			StartCoroutine (MoveEnemies ());

			
		}
		
		//Call this to add the passed in Enemy to the List of Enemy objects.
		/*public void AddEnemyToList(Enemy script)
		{
			//Add Enemy to List enemies.
			enemies.Add(script);
		}*/
		
		public void AddWallToList(Wall script)
		{
			//Add Enemy to List enemies.
			walls.Add(script);
		}

		
		//Coroutine to move enemies in sequence.
		IEnumerator MoveEnemies()
		{
			//While enemiesMoving is true player is unable to move.
			enemiesMoving = true;
			
			//Wait for turnDelay seconds, defaults to .1 (100 ms).
			yield return new WaitForSeconds(turnDelay);
			
			//If there are no enemies spawned (IE in first level):
			//if (enemies.Count == 0) 
			//{
				//Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
				yield return new WaitForSeconds(turnDelay);
			//}

			/*//Loop through List of Enemy objects.
			for (int i = 0; i < enemies.Count; i++)
			{
				//Call the MoveEnemy function of Enemy at index i in the enemies List.
				//enemies[i].MoveEnemy ();
				
				//Wait for Enemy's moveTime before moving next Enemy, 
				//yield return new WaitForSeconds(enemies[i].moveTime);
			}*/
			//Once Enemies are done moving, set playersTurn to true so player can move.
			playersTurn = true;
			
			//Enemies are done moving, set enemiesMoving to false.
			enemiesMoving = false;
		}

	//Coroutine to move enemies in sequence.
	IEnumerator MoveWalls()
	{
		//While enemiesMoving is true player is unable to move.
		wallsMoving = true;
		
		//Wait for turnDelay seconds, defaults to .1 (100 ms).
		yield return new WaitForSeconds(5.0f);
		
		//If there are no enemies spawned (IE in first level):
		//if (enemies.Count == 0) 
		//{
		//Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
		//yield return new WaitForSeconds(turnDelay);
		//}

		int xDir = 0;
		int yDir = 0;
		
		xDir = Random.Range (-1, 2);
		
		if (xDir == 0)
			yDir = Random.Range(-1,2);
		
		//Loop through List of Enemy objects.
		for (int i = 0; i < walls.Count; i++)
		{
			//Call the MoveEnemy function of Enemy at index i in the enemies List.
			walls[i].MoveWall (xDir,yDir);
			
			//Wait for Enemy's moveTime before moving next Enemy, 
			//yield return new WaitForSeconds(enemies[i].moveTime);
		}		
		//Enemies are done moving, set enemiesMoving to false.
		wallsMoving = false;
	}

}
