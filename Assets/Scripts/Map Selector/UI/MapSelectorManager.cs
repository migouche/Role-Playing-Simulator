using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class MapSelectorManager
{
	public static Maps maps = new Maps();

	public struct Maps
	{
		public string path;
		public string[] list;
		public int count;
		public const string EXTENSION = ".rps-map";
		public void Update()
		{
			path = Application.persistentDataPath + "/maps/";
			list = Directory.GetFiles(path);
			count = list.Length;
		}
	}
}