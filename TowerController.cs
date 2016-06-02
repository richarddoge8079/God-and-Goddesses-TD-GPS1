using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	public GameObject Bullet;
	bool ShootOn= false ; 
	//private float cdTime = 0f;
	//bool isCD = true;
	public float FireRate =2.0f;
	public float NextFire = 0.0f;

	public GameObject target ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ShootOn == true && Time.time>NextFire) {
			NextFire = Time.time + FireRate;
			GameObject go = (GameObject)Instantiate (Bullet, this.transform.position, Bullet.transform.rotation);
			go.GetComponent<Bullet> ().targetPos = target.transform.position; 
			

		}
		/*cdTime += Time.deltaTime;

		if (cdTime >= 0.5f) {
			cdTime = 0f;
			isCD = true;
		}*/
	}

		/*cdTime += Time.deltaTime;

		if (cdTime >= 0.5f) {
			cdTime = 0f;
			isCD = true;
		}*/

	void OnTriggerEnter2D(Collider2D co) {
		// Was it a Monster? Add to list
		if(co.name == "Enemy(Clone)"  )
		{
			
			
				Debug.Log ("Enemy tag detected");
				ShootOn = true;
				target = co.gameObject;

			
				
	

		}

	}
	void OnTriggerExit2D(Collider2D co) {
		// Was it a Monster? Add to list
		if(co.name == "Enemy(Clone)")
		{

				Debug.Log ("Enemy tag detected");
				ShootOn = false;


		}

	}

	/*void OnTriggerEnter2D(Collider2D other){
		if ( isCD == true) {
			Instantiate (Bullet, this.transform.position, Quaternion.identity);
			isCD = false;
		}
	}*/
}
