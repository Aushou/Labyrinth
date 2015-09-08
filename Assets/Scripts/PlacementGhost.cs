using UnityEngine;
using System.Collections;

public class PlacementGhost : MonoBehaviour {

	public SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlacementMode ();
		Destroy (gameObject);
	}

	void PlacementMode() {
	//INPUT: -
	//OUTPUT: ~
	//DESCRIPTION: Checks if it's current location is a valid spot for a tile. Places tile when clicked. Probably should take the
	//current tile as input actually but we'll get there...

		bool adjacent = false;
		bool overlap = false;
		bool valid = false;
		Vector2 myPos = GetComponent<Transform> ().position;

		adjacent = Physics2D.CircleCast (myPos , 0.51f, Vector2.right, 0f);
		overlap = Physics2D.CircleCast (myPos, 0.25f, Vector2.right, 0f);

		if (adjacent && !overlap) {
			valid = true;
			mySprite.color = Color.blue;
		} else {
			valid = false;
			mySprite.color = Color.red;
		}
		
		if (valid && Input.GetMouseButtonDown (0)) {
			Debug.Log ("Place tile at: " + myPos);
			//Instantiate (curTile, mousePos, Quaternion.identity);
			//turnStage++;
		}

		//Debug.Log ("Adjacent: " + adjacent + ", Overlap: " + overlap);

	}
}
