using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class EditorCanvas : MonoBehaviour
{
    public MapManager mapManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Mode Text").GetComponent<Text>().text = "Mode: Move";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWidth(string w)
	{
        mapManager.width = Convert.ToInt32(w);
        mapManager.RecreateMap();
	}

    public void UpdateHeight(string h)
	{
        mapManager.height = Convert.ToInt32(h);
        mapManager.RecreateMap();
	}

    public void ToggleMode()
	{
        mapManager.moving = !mapManager.moving;
        GameObject.Find("Mode Text").GetComponent<Text>().text = mapManager.moving ? "Mode: Move" : "Mode: Edit";

    }
}
