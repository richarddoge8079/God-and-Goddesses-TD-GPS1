	using UnityEngine;
using System.Collections;

public class BuildTowerScript : MonoBehaviour {

	public GameObject[] tempObject;
	public bool activeTower00 = false;
	public bool activeTower01 = false;
	public bool activeTower02 = false;
	public GameObject[] buttonList;

	// Use this for initialization
	void Start () {
		buttonList = GameObject.FindGameObjectsWithTag("Button");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			{
				for(int i=0; i<tempObject.Length; i++)
				{
					tempObject[i].GetComponent<PlaceTower>().enabled = false;
				}
				activeTower00 = false;
				activeTower01 = false;
				activeTower02 = false;
			}
	}

	void OnMouseDown()
	{
		tempObject = GameObject.FindGameObjectsWithTag("Tile");

		for(int i = 0; i<tempObject.Length; i++)
		{
			tempObject[i].GetComponent<PlaceTower>().enabled = true;
		}

		for(int i =0; i<buttonList.Length; i++)
		{
			if(gameObject.name == "Button00")
			{
				buttonList[i].GetComponent<BuildTowerScript>().activeTower00 = true;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower01 = false;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower02 = false;
			}
			if(gameObject.name == "Button01")
			{
				buttonList[i].GetComponent<BuildTowerScript>().activeTower01 = true;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower00 = false;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower02 = false;
			}
			if(gameObject.name == "Button02")
			{
				buttonList[i].GetComponent<BuildTowerScript>().activeTower02 = true;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower01 = false;
				buttonList[i].GetComponent<BuildTowerScript>().activeTower00 = false;
			}
		}
	}
}
