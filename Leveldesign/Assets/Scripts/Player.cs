using UnityEngine;
using System.Collections;

/*public class Player : MovingObject{
	//items
	private int coins = 0;
	private int bombs = 0;


	protected override void Start(){

		base.Start ();
	}

	void Update(){
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		vertical = (int)(Input.GetAxisRaw ("Vertical"));

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0)
			AttemptMove<Wall> (horizontal, vertical);
	}

	protected override void AttemptMove <T> (int xDir, int yDir){

		base.AttemptMove <T> (xDir, yDir);

		RaycastHit2D hit;

		CheckIfGameOver();
	}

	private void OnTriggerEnter2D(Collider2D other){
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

	/*protected override void OnCantMove <T> (T component)
	{
		//Set hitWall to equal the component passed in as a parameter.
		Wall hitWall = component as Wall;
		
		//Call the DamageWall function of the Wall we are hitting.
		//hitWall.DamageWall (wallDamage);
		
		//Set the attack trigger of the player's animation controller in order to play the player's attack animation.
		//animator.SetTrigger ("playerChop");
	}*/
/*

	private void CheckIfGameOver(){

	}
	                           
}*/

public class Player : MonoBehaviour {

	//public float speed = 7.0f;

	//items
	private int coins = 0;
	private int bombs = 0;

	// Use this for initialization
	void Start () {
	
	}

	public bool TileIsPassable(int x, int y){
		ImportText importText = GameObject.FindGameObjectWithTag("GameController").GetComponent<ImportText> ();
		x = ~x + 1;
		string test = importText.levelMap[x][y]; 
		
		if (test == "W" || test == "1" || test == "w")
			return false;
		else
			return true;
		
	}



	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.D))
			if(TileIsPassable((int)transform.position.y,(int)transform.position.x+1))
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


