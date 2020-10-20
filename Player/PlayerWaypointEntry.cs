using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypointEntry : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player = Player.instance;
    }

    void Start()
    {
        player.ForceMovement(gameObject.transform.position);
    }
}
