using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerPanel : MonoBehaviour
{
    public void Use()
	{
        //Debug.Log("button");
        Debug.Log(GetComponentInChildren<InputField>().text);
        Debug.Log(transform.GetSiblingIndex());
        FindObjectOfType<MapManager>().selectedType = transform.GetSiblingIndex() - 2;
	}

    public void ChangeName(string name)
	{
        FindObjectOfType<MapManager>().types[transform.GetSiblingIndex() - 2] = name;
	}
}
