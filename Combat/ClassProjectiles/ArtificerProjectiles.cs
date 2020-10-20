using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificerProjectiles : MonoBehaviour
{
    #region Singleton
    public static ArtificerProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
