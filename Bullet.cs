using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		transform.position = Vector3.MoveTowards (transform.position , targetPos , Time.deltaTime * 30f);

		if(this.transform.position.y >4f)
		{
			Destroy (this.gameObject);
		}
	
	}



}
