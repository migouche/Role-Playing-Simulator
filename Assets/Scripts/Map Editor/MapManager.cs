using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEngine.UI;
public enum TileType
{
    floor,
    wall
}

public class MapManager : MonoBehaviour
{
    public int width;
    public int height;
    public Tile[,] tiles;
    public Tile tile, tileClone;
    public List<string> types;
    public int selectedType;
    public float tileSize;
    public bool moving;
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        /*
        types = new List<string>();
        types.Add("floor");
        types.Add("walls");
        types.Add("lava");
        width = height = 10;
        moving = true;
        */
        RecreateMap(MapSaveAndLoad.LoadMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLayer(int layer)
	{
        foreach(Tile t in tiles)
		{
            if (t.type == layer)
                t.type = 0;
            else if (t.type > layer)
                t.type--;
		}
        types.RemoveAt(layer);
        UpdateMap();
	}
        
    public void RecreateMap()
	{
        ClearMap();
        //Debug.Log(width + ", " + height);
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
                tileClone.GetComponent<SpriteRenderer>().color = colors[tileClone.type];
            }
        }
    }

    public void RecreateMap(MapData md)
	{
        width = md.Width;
        height = md.Width;
        tiles = new Tile[width, height];
        types = md.Types;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tileClone = Instantiate(tile, transform);
                tileClone.transform.localPosition = new Vector2(x, y) * tileSize;
                tileClone.type = md.Tiles[x, y];
                tiles[x, y] = tileClone;
            }
        }
        UpdateMap();
    }

    public void ClearMap()
	{
        foreach (Transform t in transform)
            Destroy(t.gameObject);
	}
}

[System.Serializable]
public class MapData
{
    public int Height, Width;
    public int[,] Tiles;
    public List<string> Types;
    public MapData(int width, int height, Tile[,] tiles, List<string> types)
	{
        Width = width;
        Height = height;
        Tiles = new int[Width, Height];
        Types = types;
        for (int y = 0; y < Height; y++)
		{
            for(int x = 0; x < Width; x++)
			{
                Tiles[x, y] = tiles[x, y].type;
			}
		}
	}

    public MapData(int width, int height, int[,] tiles, List<string> types)
    {
        Width = width;
        Height = height;
        Tiles = new int[Width, Height];
        Types = types;
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Tiles[x, y] = tiles[x, y];
            }
        }
    }
}
