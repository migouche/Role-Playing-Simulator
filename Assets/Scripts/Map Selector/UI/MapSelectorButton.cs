using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectorButton : MonoBehaviour
{
	private MapSelectorUI MapSelector;

	private void Start()
	{
		MapSelector = FindObjectOfType<MapSelectorUI>();
	}
	public void Select()
	{
		MapSelector.SelectMap(GetComponentInChildren<Text>().text);
	}
}
