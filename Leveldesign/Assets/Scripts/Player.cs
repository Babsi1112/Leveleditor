using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player : MovingObject
{
	public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.
	//public int pointsPerFood = 10;              //Number of points to add to player food points when picking up a food object.
	//public int pointsPerSoda = 20;              //Number of points to add to player food points when picking up a soda object.
	//public int wallDamage = 1;                  //How much damage a player does to a wall when chopping it.
	private int coins = 0;
	private int bombs = 0;
	private Text itemText;
	
	//private Animator animator;                  //Used to store a reference to the Player's animator component.
	//private int food;                           //Used to store player food points total during level.
	
	
	//Start overrides the Start function of MovingObject
	protected override void Start ()
	{
		//Get a component reference to the Player's animator component
		//animator = GetComponent<Animator>();
		
		//Get the current food point total stored in GameManager.instance between levels.
		bombs = GameManager.instance.playerBombs;
		coins = GameManager.instance.playerCoins;
		itemText = GameObject.Find ("itemText").GetComponent<Text> ();
		itemText.text = "Bombs: " + bombs + ", Coins: " + coins;
		
		//Call the Start function of the MovingObject base class.
		base.Start ();
	}
	
	
	//This function is called when the behaviour becomes disabled or inactive.
	private void OnDisable ()
	{
		//When Player object is disabled, store the current local food total in the GameManager so it can be re-loaded in next level.
		GameManager.instance.playerBombs = bombs;
		GameManager.instance.playerCoins = coins;
	}
	
	
	private void Update ()
	{
		//If it's not the player's turn, exit the function.
		if(!GameManager.instance.playersTurn) return;
		
		int horizontal = 0;     //Used to store the horizontal move direction.
		int vertical = 0;       //Used to store the vertical move direction.
		
		
		//Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		
		//Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
		vertical = (int) (Input.GetAxisRaw ("Vertical"));
		
		//Check if moving horizontally, if so set vertical to zero.
		if(horizontal != 0)
		{
			vertical = 0;
		}
		
		//Check if we have a non-zero value for horizontal or vertical
		if(horizontal != 0 || vertical != 0)
		{
			//Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
			//Pass in horizontal and vertical as parameters to specify the direction to move Player in.
			AttemptMove<WallDestroy> (horizontal, vertical);

		}
	}

	//AttemptMove overrides the AttemptMove function in the base class MovingObject
	//AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		//Every time player moves, subtract from food points total.
		//food--;
		
		//Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
		base.AttemptMove <T> (xDir, yDir);
		
		//Hit allows us to reference the result of the Linecast done in Move.
		RaycastHit2D hit;
		
		//If Move returns true, meaning Player was able to move into an empty space.
		if (Move (xDir, yDir, out hit)) 
		{
			//Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
		}
		
		//Since the player has moved and lost food points, check if the game has ended.
		//CheckIfGameOver ();
		
		//Set the playersTurn boolean of GameManager to false now that players turn is over.
		GameManager.instance.playersTurn = false;
	}
	
	
	//OnCantMove overrides the abstract function OnCantMove in MovingObject.
	//It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
	protected override void OnCantMove <T> (T component)
	{
		//Set hitWall to equal the component passed in as a parameter.
		WallDestroy hitWall = component as WallDestroy;
		
		//Call the DamageWall function of the Wall we are hitting.
		if (bombs > 0) 
		{
			StartCoroutine (hitWall.DamageWall (1));
			bombs--;
			itemText.text = "Bombs: " + bombs + ", Coins: " + coins;
		}
		
		//Set the attack trigger of the player's animation controller in order to play the player's attack animation.
		//animator.SetTrigger ("playerChop");
	}
	
	
	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other)
	{
		//Check if the tag of the trigger collided with is Exit.
		if(other.tag == "Exit")
		{
			//Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
			Invoke ("Restart", restartLevelDelay);
			
			//Disable the player object since level is over.
			enabled = false;
		}
		else if(other.gameObject.CompareTag("coin"))
		{
			Destroy(other.gameObject);
			coins ++;
			itemText.text = "Bombs: " + bombs + ", Coins: " + coins;
			Debug.Log ("coins: " +coins);
		}
		else if(other.gameObject.CompareTag("bomb"))
		{
			Destroy(other.gameObject);
			bombs++;
			itemText.text = "Bombs: " + bombs + ", Coins: " + coins;
			Debug.Log ("bombs: "+bombs);
		}
	}
	
	
	//Restart reloads the scene when called.
	private void Restart ()
	{
		//Load the last scene loaded, in this case Main, the only scene in the game.
		Application.LoadLevel (Application.loadedLevel);
	}
	
	
	//LoseFood is called when an enemy attacks the player.
	//It takes a parameter loss which specifies how many points to lose.
	public void LoseFood (int loss)
	{
		//Set the trigger for the player animator to transition to the playerHit animation.
		//animator.SetTrigger ("playerHit");
		
		//Subtract lost food points from the players total.
		//food -= loss;
		
		//Check to see if game has ended.
		//CheckIfGameOver ();
	}
	
	
	//CheckIfGameOver checks if the player is out of food points and if so, ends the game.
	/*private void CheckIfGameOver ()
	{
		//Check if food point total is less than or equal to zero.
		if (food <= 0) 
		{
			
			//Call the GameOver function of GameManager.
			GameManager.instance.GameOver ();
		}
	}*/

}


/*public class Player : MonoBehaviour {

	//public float speed = 7.0f;

	//items
	private int coins = 0;
	private int bombs = 0;

	// Use this for initialization
	void Start () {
	
	}

	public bool TileIsPassable(int x, int y){
		CreateGrid createGrid = GameObject.FindGameObjectWithTag("GameController").GetComponent<CreateGrid> ();
		x = ~x + 1;
		string test = createGrid.levelMap[x][y]; 
		
		if (test == "W" || test == "1" || test == "w")
			return false;
		else
			return true;		
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D))
			if (TileIsPassable ((int)transform.position.y, (int)transform.position.x + 1)) 
				transform.position += Vector3.right;	
		if (Input.GetKeyDown (KeyCode.A))
			if(TileIsPassable((int)transform.position.y, (int)transform.position.x-1))
				transform.position += Vector3.left;
		if (Input.GetKeyDown (KeyCode.W))
			if(TileIsPassable((int)transform.position.y+1, (int)transform.position.x))
				transform.position += Vector3.up;
		if (Input.GetKeyDown (KeyCode.S))
			if(TileIsPassable((int)transform.position.y-1, (int)transform.position.x))
				transform.position += Vector3.down;

		correctPosition ();


	}

	void correctPosition(){
		var currentPos = transform.position;
		transform.position = new Vector3(Mathf.Round(currentPos.x),
		                            Mathf.Round(currentPos.y),
		                            Mathf.Round(currentPos.z));

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
}*/

