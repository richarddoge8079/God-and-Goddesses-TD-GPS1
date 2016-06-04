using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour
{
	public enum Type
	{
		NONE = 0,
		PATH,
		TOTAL
	}

	public Type type = Type.NONE;

	public Sprite[] spriteList;
	public SpriteRenderer spriteRenderer;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
