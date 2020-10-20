using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrypterProjectiles : MonoBehaviour
{
    #region Singleton
    public static CrypterProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
