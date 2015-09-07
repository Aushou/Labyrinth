using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int row; // current row position
	public int col; // current col position
	
	// Update is called once per frame
	void Update () {
	
	}

	// move the player: 0-right, 1-left, 2-up, 3-down
	public void MovePlayer(int direction){
		if (checkValid (direction)) {
			// move the player
		}
	}

	// check if movement is valid
	bool checkValid(int direction){
		if (true) {
			return true;
		} else {
			return false;
		}
	}
}
