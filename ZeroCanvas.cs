using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroCanvas : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector3.zero;
	}	
}
