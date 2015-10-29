using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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
			if (TileIsPassable ((int)transform.position.y, (int)transform.position.x + 1)) {
				transform.position += Vector3.right;	
			}
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
}


