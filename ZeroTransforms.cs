using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroTransforms : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    void FixedUpdate ()
    {
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
	}
}
