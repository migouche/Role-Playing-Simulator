using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
	{
        //Debug.Log("button");
        Debug.Log(GetComponentInChildren<InputField>().text);
        FindObjectOfType<MapManager>().selectedType = transform.GetSiblingIndex() - 2;
	}
}
