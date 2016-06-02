using UnityEngine;
using System.Collections;

public class GoldClickPlutos : MonoBehaviour {

	private GameManagerBehaviour gameManagerPlutos;

	// Use this for initialization
	void Start () {
		gameManagerPlutos = GameObject.Find ("GameManager").GetComponent<GameManagerBehaviour>();
	}

	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonUp(0)) {
			gameManagerPlutos.Gold += 10;
		}
	}*/

	void OnMouseDown () {
		gameManagerPlutos.Gold += 10;
	}
}
