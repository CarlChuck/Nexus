using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetDocProjectiles : MonoBehaviour
{
    #region Singleton
    public static StreetDocProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
