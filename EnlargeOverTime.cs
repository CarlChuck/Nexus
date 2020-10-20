using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeOverTime : MonoBehaviour
{

    private void Update()
    {
        Vector3 vGrow = new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 4f);
        transform.localScale = Vector3.Lerp(transform.localScale, vGrow, Time.deltaTime);
    }
}
