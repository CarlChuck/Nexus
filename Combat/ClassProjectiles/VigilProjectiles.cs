using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilProjectiles : MonoBehaviour
{
    #region Singleton
    public static VigilProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
