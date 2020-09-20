using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float x, y;
    public TileType tileType;
    public MapManager mapManager;
    // Start is called before the first frame update
    void Start()
    {
        mapManager = GetComponentInParent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnMouseDown()
	{
        if (!mapManager.moving)
		{
            if (tileType == TileType.floor)
            {
                tileType = TileType.wall;
                mapManager.UpdateMap();

            }
        }
	}
}
