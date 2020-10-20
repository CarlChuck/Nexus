using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticProjectiles : MonoBehaviour
{
    #region Singleton
    public static MysticProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
