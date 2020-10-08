using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class MapSaveAndLoad
{
	public static void SaveMap(MapData mp)
	{
		BinaryFormatter bn = new BinaryFormatter();
		string path = Application.persistentDataPath + "/maptest.rps-map";
		FileStream stream = new FileStream(path, FileMode.Create);
		bn.Serialize(stream, mp);
		stream.Close();
	}

	public static MapData LoadMap()
	{
		string path = Application.persistentDataPath + "/maptest.rps-map";
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
}
