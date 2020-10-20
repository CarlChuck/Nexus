using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowProjectiles : MonoBehaviour
{
    #region Singleton
    public static ShadowProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
