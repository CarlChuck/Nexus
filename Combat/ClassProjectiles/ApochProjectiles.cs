using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApochProjectiles : MonoBehaviour
{
    #region Singleton
    public static ApochProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
