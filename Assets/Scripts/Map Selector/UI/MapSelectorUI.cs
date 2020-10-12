using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapSelectorUI : MonoBehaviour
{
    public GameObject MapContent;
    public GameObject ButtonPrefab;
    public GameObject[] buttons;
    public Text MapTxt;
    public string selectedMap;
    public int NumberOfMaps;

    void Start()
    {
        MapTxt = GameObject.Find("Map Name").GetComponent<Text>();

#if UNITY_ANDROID
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
#endif
        ReloadMapList();
        SelectMap(Path.GetFileNameWithoutExtension(MapSelectorManager.maps.list[0]));
    }

    public void ReloadMapList()
	{
        MapSelectorManager.maps.Update();
        NumberOfMaps = MapSelectorManager.maps.count;

        MapContent.GetComponent<RectTransform>().offsetMin = new Vector2(MapContent.GetComponent<RectTransform>().offsetMin.x, 500 - (NumberOfMaps + 1) * 100);
        GameObject AddLayer = GameObject.Find("Add Layer");
        foreach (Transform t in MapContent.transform)
		{
            if (t != AddLayer.transform && t != this.transform)
			{
                Destroy(t);
			}
		}

        for (int i = 0; i < NumberOfMaps; i++)
        {
            GameObject b = Instantiate(ButtonPrefab, MapContent.transform);
            b.GetComponentInChildren<Text>().text = Path.GetFileNameWithoutExtension(MapSelectorManager.maps.list[i]);
        }

        AddLayer.transform.SetAsLastSibling();
    }

    public void LoadMap()
	{
        MapSaveAndLoad.OpenEditor(selectedMap);
	}

    public void SelectMap(string map)
	{
        selectedMap = map;
        MapTxt.text = selectedMap;
    }

    public void NewMap()
	{
        MapSaveAndLoad.CurrentMap = "new map";
        MapSaveAndLoad.SaveMap(new MapData(10, 10, new int[10, 10], new List<string>() { "floor", "wall", "lava" }));
        SceneManager.LoadScene("Editor");
	}
}