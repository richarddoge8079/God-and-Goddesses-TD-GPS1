using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[HideInInspector]
	public GameObject[] wayPoints;
	private int currentWayPoint = 0;
	private float lastWayPointSwitchTime;
	public float speed = 1.0f;	

	// Use this for initialization
	void Start () {
		lastWayPointSwitchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 startPosition = wayPoints [currentWayPoint].transform.position;
		Vector3 endPosition = wayPoints [currentWayPoint + 1].transform.position;
		// 2 
		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWayPointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
		// 3 
		if (gameObject.transform.position.Equals(endPosition)) {
			if (currentWayPoint < wayPoints.Length - 2) {
				// 4 Switch to next waypoint
				currentWayPoint++;
				lastWayPointSwitchTime = Time.time;
			} else {
				// 5 Destroy enemy
				Destroy(gameObject);
			}
		}
	}
}
