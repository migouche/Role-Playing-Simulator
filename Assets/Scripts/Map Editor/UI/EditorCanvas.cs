using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EditorCanvas : MonoBehaviour
{
    public MapManager mapManager;
    public GameObject LayersPanel;
    public GameObject LayerPref;
    // Start is called before the first frame update
    void Start()
    {
        LayersPanel = GameObject.Find("Layers");
        GameObject.Find("Mode Text").GetComponent<Text>().text = "Mode: Move";
        UpdateLayers();
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

    public void UpdateLayers()
	{
        int i = 0;
        foreach (Transform t in LayersPanel.transform)
        {
            if(t.GetComponent<LayerPanel>())
                Destroy(t.gameObject);
        }
        Debug.Log("delete");
        foreach(string layer in mapManager.types)
		{
            GameObject LayerCLone = Instantiate(LayerPref, Vector2.zero, Quaternion.identity, LayersPanel.transform);
            LayerCLone.transform.localPosition = new Vector2(0, (-i - 1) * 30);
            Debug.Log(LayerCLone.transform.GetSiblingIndex());
            LayerCLone.GetComponentInChildren<InputField>().text = mapManager.types[LayerCLone.transform.GetSiblingIndex() - 2];
            LayerCLone.GetComponentInChildren<Image>().color = mapManager.colors[LayerCLone.transform.GetSiblingIndex() - 2];
            i++;
		}
        GameObject.Find("Add Layer").transform.localPosition = new Vector2(9, (-i - 1) * 30);
	}

    public void ChangeLayerName(string s, Transform lay)
	{
        int i = lay.GetSiblingIndex();
        mapManager.types[i] = s;
	}

    public void AddLayer()
	{
        UpdateLayers();
        //mapManager.types.Add("New Layer");
	}
    public void SaveMap()
	{
        MapSaveAndLoad.SaveMap(new MapData(mapManager.width, mapManager.height, mapManager.tiles));
	}

    public void LoadMap()
	{
        MapData md = MapSaveAndLoad.LoadMap();
        mapManager.RecreateMap(md);
	}
}
