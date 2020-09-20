using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
public enum TileType
{
    floor,
    wall,
}

public class MapManager : MonoBehaviour
{
    public int width;
    public int height;
    public Tile[,] tiles;
    public Tile tile, tileClone;
    public float tileSize;
    public bool moving; 
    // Start is called before the first frame update
    void Start()
    {
        width = height = 10;
        moving = true;
        RecreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecreateMap()
	{
        ClearMap();
        Debug.Log(width + ", " + height);
        tiles = new Tile[width, height];
        for (int y = 0; y < height; y++)
		{
            for(int x = 0; x < width; x++)
			{
                tileClone = Instantiate(tile, transform);
                tileClone.transform.localPosition = new Vector2(x, y) * tileSize;
                tiles[x, y] = tileClone;
            }
		}
        UpdateMap();
	}

    public void UpdateMap()
	{
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tileClone = tiles[x, y];
                if (tileClone.tileType == TileType.floor)
                    tileClone.GetComponent<SpriteRenderer>().color = Color.green;
                else if (tileClone.tileType == TileType.wall)
                    tileClone.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    public void ClearMap()
	{
        foreach (Transform t in transform)
            Destroy(t.gameObject);
	}
}
