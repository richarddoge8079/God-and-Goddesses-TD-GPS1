using UnityEngine;
using System.Collections;

public class TileManagerScript : MonoBehaviour {

	private static TileManagerScript mInstance;

	public static TileManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("TileManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_TileManager");
					mInstance = obj.AddComponent<TileManagerScript>();
					obj.tag = "TileManager";
					//DontDestroyOnLoad(obj);
				}
				else
				{
					mInstance = tempObject.GetComponent<TileManagerScript>();
				}
			}
			return mInstance;
		}
	}

	int[,] map;
	public const int ROW_COUNT = 9;
	public const int COL_COUNT = 20;

	public int rowCount;
	public int colCount;

	public GameObject tilePrefab;

	// Use this for initialization
	void Start ()
	{
		//RandomizeMap();
		InitializeMap();

		for (int i = 0; i < rowCount; i++) 
		{
			for ( int j = 0; j < colCount; j++)
			{
				TileScript tempTileScript = ((GameObject)Instantiate(tilePrefab, new Vector3(j*0.64f+3.92f - colCount/2, rowCount/2 - i*0.64f - 0.72f, 0.0f), Quaternion.identity)).GetComponent<TileScript>();

				if(map[i,j] == 0)
				{
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[0];
				}
				else if(map[i,j] == 1)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[1];
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void RandomizeMap()
	{
		map = new int[rowCount, colCount];

		for (int i = 0; i < rowCount; i++) 
		{
			for ( int j = 0; j < colCount; j++)
			{
				map[i,j] = Random.Range(0,2);
			}
		}
	}
	void InitializeMap()
	{
		map = new int[ROW_COUNT,COL_COUNT] 
						{
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
							{1,1,1,1,1,	1,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0}
							
						};

		rowCount = map.GetLength(0);
		colCount = map.GetLength(1);
	}
}
