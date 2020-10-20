using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoMageProjectiles : MonoBehaviour
{
    #region Singleton
    public static NanoMageProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
