using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class MapSaveAndLoad
{
	public static string CurrentMap;
	public static void SaveMap(MapData mp)
	{
		if (!Directory.Exists(MapSelectorManager.maps.path))
			Directory.CreateDirectory(MapSelectorManager.maps.path);
		BinaryFormatter bn = new BinaryFormatter();
		string path = MapSelectorManager.maps.path + CurrentMap + MapSelectorManager.Maps.EXTENSION;
		FileStream stream = new FileStream(path, FileMode.Create);
		bn.Serialize(stream, mp);
		stream.Close();
	}

	public static MapData LoadMap()
	{
		string path = MapSelectorManager.maps.path + CurrentMap + MapSelectorManager.Maps.EXTENSION;
		if (File.Exists(path))
		{
			BinaryFormatter bn = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			return bn.Deserialize(stream) as MapData;
		}else
		{
			Debug.LogError(path + " does not exist!");
			return null;
		}
	}

	public static void RenameMap(string newname)
	{
		if (File.Exists(MapSelectorManager.maps.path + CurrentMap + MapSelectorManager.Maps.EXTENSION))
		{
			File.Move(MapSelectorManager.maps.path + CurrentMap + MapSelectorManager.Maps.EXTENSION,
				MapSelectorManager.maps.path + newname + MapSelectorManager.Maps.EXTENSION);
		}
		CurrentMap = newname;
	}
	public static void OpenEditor(string map)
	{
		CurrentMap = map;
		SceneManager.LoadScene("Editor");
	}
}
