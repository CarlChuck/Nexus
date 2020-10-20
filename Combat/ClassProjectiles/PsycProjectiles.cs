using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsycProjectiles : MonoBehaviour
{
    #region Singleton
    public static PsycProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
