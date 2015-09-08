using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerPos_x; // current x position
	public int playerPos_y; // current y position
	
	// Update is called once per frame
	void Update () {
		// draw the player sprite

	}

	// move the player
	public void MovePlayer(int x, int y){
		if (checkValid (x, y)) {
			// move the player
		}
	}

	// check if movement is valid
	bool checkValid(int x, int y){

		// check if out of bound
		if (x > 30 || x < 0) {
			return false;
		} else if (y > 30 || y < 0) {
			return false;
		}

		return true;
	}
}
