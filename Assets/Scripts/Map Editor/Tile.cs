using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    //public float x, y;
    //public TileType tileType;
    public int type;
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
        bool clicked = false;
        /*if (!mapManager.moving)
		{
            if (tileType == TileType.floor && !clicked)
            {
                clicked = true;
                Debug.Log("convert to wall");
                tileType = TileType.wall;
                mapManager.UpdateMap();

            }

            if(tileType == TileType.wall && !clicked)
			{
                clicked = true;
                Debug.Log("convert to floor");
                tileType = TileType.floor;
                mapManager.UpdateMap();
			}
        }*/

        if(!mapManager.moving && !clicked)
		{
            clicked = true;
            type = mapManager.selectedType;
            mapManager.UpdateMap();
		}
	}
}
