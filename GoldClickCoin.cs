using UnityEngine;
using System.Collections;

public class GoldClickCoin : MonoBehaviour {

	private GameManagerBehaviour gameManagerCoin;

	// Use this for initialization
	void Start () {
		gameManagerCoin = GameObject.Find ("GameManager").GetComponent<GameManagerBehaviour>();
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonUp(0)) {
			
		}
	}*/

	void OnMouseDown () {
		gameManagerCoin.Gold += 1;
	}
}
