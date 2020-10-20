using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvoyProjectiles : MonoBehaviour
{
    #region Singleton
    public static EnvoyProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
