using UnityEngine;
using System.Collections;

public class PlaceTower : MonoBehaviour {

	//public GameObject monsterPrefab;
	public GameObject tower;
	public GameObject[] towerPrefabs;
	private GameObject towerPrefab;
	public GameObject[] buttons;

	void Start()
	{
		buttons = GameObject.FindGameObjectsWithTag ("Button");
	}

	void Update()
	{
		if(buttons[0].GetComponent<BuildTowerScript>().activeTower00 == true)
		{
			towerPrefab = towerPrefabs[0];
		}
		else if(buttons[1].GetComponent<BuildTowerScript>().activeTower01 == true)
		{
			towerPrefab = towerPrefabs[1];
		}
		else if(buttons[2].GetComponent<BuildTowerScript>().activeTower02 == true)
		{
			towerPrefab = towerPrefabs[2];
		}
	}

	private bool canPlaceTower()
	{
		return tower == null;
	}

	private bool IsPath()
	{
		if(gameObject.GetComponent<TileScript>().type == TileScript.Type.PATH)
		{
			return true;
		}
		return false;
	}

	private bool canUpgradeTower()
	{
		if (tower != null) {
			TowerData towerData = tower.GetComponent<TowerData> ();
			TowerLevel nextLevel = towerData.GetNextLevel();
			if (nextLevel != null) {
				return true;
			}
		}
		return false;
	}

	void OnMouseUp(){
		if(canUpgradeTower())
		{
			GetComponent<PlaceTower>().enabled = true;
		}
		if (!enabled)
			return;
		if (canPlaceTower ()) 
		{
			if(!IsPath())
			{
				tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
			}
		}
		else if (canUpgradeTower ()) 
		{
			tower.GetComponent<TowerData> ().IncreaseLevel ();
		}
	}

	void OnMouseOver(){
		if(!enabled)
			return;
		if (canPlaceTower ()) 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
			if(IsPath())
			{
				gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			}
		}
		else if(canUpgradeTower() || !canUpgradeTower())
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
