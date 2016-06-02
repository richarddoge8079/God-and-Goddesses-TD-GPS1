using UnityEngine;
using System.Collections;

public class PlaceTower : MonoBehaviour {

	public GameObject monsterPrefab;
	public GameObject monster;

	private bool canPlaceTower(){
		return monster == null;
	}

	private bool canUpgradeMonster(){
		if (monster != null) {
			MonsterData monsterData = monster.GetComponent<MonsterData> ();
			MonsterLevel nextLevel = monsterData.GetNextLevel ();
			if (nextLevel != null) {
				return true;
			}
		}
		return false;
		}

	void Update(){
		
	}

	void OnMouseUp(){
		if (!enabled)
			return;
		if (canPlaceTower ()) {
			monster = (GameObject)Instantiate (monsterPrefab, transform.position, Quaternion.identity);
		}
		else if (canUpgradeMonster ()) {
			monster.GetComponent<MonsterData> ().IncreaseLevel ();
		}
	}

	void OnMouseOver(){
		if (canPlaceTower ()) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		}
		else{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
