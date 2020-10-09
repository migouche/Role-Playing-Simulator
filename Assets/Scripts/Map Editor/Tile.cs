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

    private void OnMouseEnter()
    {
        bool clicked = false;
        if (!clicked && Input.GetMouseButton(0))    
        {
            clicked = true;
            type = mapManager.selectedType;
            mapManager.UpdateMap();

        }
    }
	private void OnMouseDown()
	{
        bool clicked = false;
        if (!clicked)
        {
            clicked = true;
            type = mapManager.selectedType;
            mapManager.UpdateMap();

        }
    }
}
