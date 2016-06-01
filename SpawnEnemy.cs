
using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject[] wayPoints;
	public GameObject enemy1;
	public GameObject enemy2;
	public float interval = 2;
	public float interval2 = 1;
	public int maxEnemy = 5;
	public int maxEnemy2 = 5;
	public int totalWave = 5;
	private int currentWave = 0;
	private int enemySpawned = 0;
	private int enemySpawned2 = 0;

	// Use this for initialization
	void Start () {
		//Instantiate (testEnemyPrefab).GetComponent<EnemyMovement> ().wayPoints = wayPoints;
		//InvokeRepeating("startSpawn",0,10.0f);
	}

	void startSpawn(){
		InvokeRepeating("Spawn", 0, interval);
		InvokeRepeating ("Spawn2", 1, interval2);
	}

	void Spawn(){
		Instantiate (enemy1).GetComponent<EnemyMovement> ().wayPoints = wayPoints;
		enemySpawned++;
	}

	void Spawn2(){
		Instantiate (enemy2).GetComponent<EnemyMovement> ().wayPoints = wayPoints;
		enemySpawned2++;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			if(enemySpawned==0 && enemySpawned2==0 && currentWave <= totalWave){
				startSpawn ();
				currentWave++;
			}
		}
		if (enemySpawned >= maxEnemy) {
			CancelInvoke ("Spawn");
			enemySpawned = 0;
		}
		if (enemySpawned2 >= maxEnemy2) {
			CancelInvoke ("Spawn2");
			enemySpawned2 = 0;
		}	
	}
		
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), currentWave + "/" + totalWave);
	}
}
