using UnityEngine;
using System.Collections;

public class CoreHealth : MonoBehaviour {

	public int health = 1;
	public float delay = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (gameObject, delay);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Detected");
		Destroy (other.gameObject);
		health--;
	}
}
