using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public Transform pWaypoint;

	// Use this for initialization
	void Start ()
    {
        Player.instance.player.transform.position = pWaypoint.position;
	}
}
