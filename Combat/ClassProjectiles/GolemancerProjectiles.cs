using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemancerProjectiles : MonoBehaviour
{
    #region Singleton
    public static GolemancerProjectiles instance;

    private void Start()
    {
        instance = this;
    }
    #endregion
}
