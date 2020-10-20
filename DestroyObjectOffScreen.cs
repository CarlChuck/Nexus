using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOffScreen : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
