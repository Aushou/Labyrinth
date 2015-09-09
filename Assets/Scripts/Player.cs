using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private int player_num = 4;

	public List<GameObject> players;
	public GameObject player_1;
	public GameObject player_2;
	public GameObject player_3;
	public GameObject player_4;
	public GameObject player_ghost;

	private int curPlayer = 1;
	private GameLogic _gL;
	private Camera mainCam;
	
	public bool MovementMode = true;

	// initiation
	void Start(){
		_gL = GetComponent<GameLogic> ();
		mainCam = GetComponentInChildren<Camera> ();

		// randomly assign player start
		// initiate list
		players = new List<GameObject> ();
		players.Add (player_1);
		players.Add (player_2);
		players.Add (player_3);
		players.Add (player_4);
		player_ghost.SetActive (false);

		// randomly assign positions
		int[] givenPos = new int[player_num];
		for (int i = 0; i < player_num; i++) {
			givenPos[i] = -1;
		}
		for (int i = 0; i < player_num; i++) {
			int num = -1;
			bool invalid;

			do{
				invalid = false;
				num = Random.Range (0, 8);
				for(int j = 0; j < player_num; j++){
					if(givenPos[j] == num){
						invalid = true;
						break;
					}
				}
			}while(invalid);

			givenPos[i] = num;
		}
		int k = 0;
		foreach(GameObject player in players){

			switch(givenPos[k]){
			
			case 0: 
				player.transform.position = new Vector3(15, 17, 0);
				break;
			case 1:
				player.transform.position = new Vector3(13, 17, 0);
				break;
			case 2:
				player.transform.position = new Vector3(11, 17, 0);
				break;
			case 3:
				player.transform.position = new Vector3(11, 16, 0);
				break;
			case 4:
				player.transform.position = new Vector3(11, 14, 0);
				break;
			case 5:
				player.transform.position = new Vector3(11, 13, 0);
				break;
			case 6:
				player.transform.position = new Vector3(13, 13, 0);
				break;
			case 7:
				player.transform.position = new Vector3(15, 13, 0);
				break;
			}
			k++;
		}
	}

	// place a ghost at where the mouse is
	void PlayerGhost() {
		TrackMouse ();

		bool overlap = false;
		bool adjacent = false;
		Vector2 ghost_pos = player_ghost.transform.position;

		if (checkValid()) {
			player_ghost.GetComponent<SpriteRenderer> ().color = Color.green;
		}else{
			player_ghost.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}

	// track player's mouse
	void TrackMouse(){
		Vector3 mousePos = mainCam.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D;
		
		mousePos.z = 0;
		mousePos.x = Mathf.RoundToInt (mousePos.x);
		mousePos.y = Mathf.RoundToInt (mousePos.y);
		mousePos2D.x = mousePos.x;
		mousePos2D.y = mousePos.y;
		
		player_ghost.transform.position = mousePos2D;
	}

	// check if movement is valid
	bool checkValid(){

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		// check if hit tile
		if(hit.collider != null)
		{

			Tile _t = hit.collider.gameObject.GetComponent<Tile>();

			if(_t !=null){
			
				// north
				Vector3 north = players[curPlayer-1].transform.position;
				north.y++;
				if (player_ghost.transform.position == north && _t.GetSouth()) {
					return true;
				}
				// south
				Vector3 south = players[curPlayer-1].transform.position;
				south.y--;
				if (player_ghost.transform.position == south && _t.GetNorth()) {
					return true;
				}
				// east
				Vector3 east = players[curPlayer-1].transform.position;
				east.x--;
				if (player_ghost.transform.position == east && _t.GetWest()) {
					return true;
				}
				// west
				Vector3 west = players[curPlayer-1].transform.position;
				west.x++;
				if (player_ghost.transform.position == west && _t.GetEast()) {
					return true;
				}
			}
		}

		return false;
	}

	// actually move the player
	public void MovePlayer(){
		players [curPlayer - 1].transform.position = player_ghost.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (MovementMode) {
			//curPlayer = _gL.curPlayer;
			player_ghost.SetActive(true);
			PlayerGhost();
			if (checkValid() && Input.GetMouseButtonDown (0)) {
				MovePlayer();
			}
		}
	}
}
