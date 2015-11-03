using UnityEngine;
using System.Collections;

public class Wall : MovingObject{

	//Start overrides the virtual Start function of the base class.
	protected override void Start ()
	{
		//Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
		//This allows the GameManager to issue movement commands.
		GameManager.instance.AddWallToList(this);
		
		//Call the start function of our base class MovingObject.
		base.Start ();
	}
	
	
	//Override the AttemptMove function of MovingObject to include functionality needed for Enemy to skip turns.
	//See comments in MovingObject for more on how base AttemptMove function works.
	protected override void AttemptMove <T> (int xDir, int yDir)
	{	
		//Call the AttemptMove function from MovingObject.
		base.AttemptMove <T> (xDir, yDir);
	} //Vielleicht löschbar
	
	
	//MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
	public void MoveWall ()
	{
		//Declare variables for X and Y axis move directions, these range from -1 to 1.
		//These values allow us to choose between the cardinal directions: up, down, left and right.
		int xDir = 0;
		int yDir = 0;

		xDir = Random.Range (-1, 1);

		if (xDir != 0)
			yDir = Random.Range(-1,1);
		
		//Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
		AttemptMove <Player> (xDir, yDir);
	}
	
	
	//OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
	//and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
	protected override void OnCantMove <T> (T component)
	{
		//Declare hitPlayer and set it to equal the encountered component.
		//Player hitPlayer = component as Player;
		
		//Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
		//hitPlayer.LoseFood (playerDamage);
		
		//Set the attack trigger of animator to trigger Enemy attack animation.
		//animator.SetTrigger ("enemyAttack");
		
	}
}
