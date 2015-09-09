using UnityEngine;
using System.Collections;

public class EffectCard : MonoBehaviour {

	// string card
	// nothing card
	// speed card
	// slow card
	// minotaur speed card
	
	public int stringCard = 0;
	public Player _pL;
	public GameObject cardButton;
	public bool DrawCardMode = false;
	private bool drew = false;

	void Start(){
		_pL = GetComponent<Player> ();	
	}

	public void DrawACard(){
		int num = Random.Range (0, 5);
		switch (num) {
		case 0:	// string card
			stringCard++;
			break;
		case 1: // nothing card
			break;
		case 2: // speed card
			_pL.playerMove++;
			break;
		case 3: // slow card
			_pL.playerMove--;
			break;
		case 4: // minotaur speed card
			_pL.minotaurAdd++;
			break;
		}
	}

	public void EndOfTurn(){
		_pL.playerMove = 2;
		_pL.minotaurAdd = 0;
	}


	void Update(){
		if (DrawCardMode) {
			if (!drew) {
				cardButton.SetActive (true);
			} else {
				cardButton.SetActive (false);
			}
		} else {
			cardButton.SetActive (false);
		}
	}
}
