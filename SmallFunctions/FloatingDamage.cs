using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingDamage : MonoBehaviour
{
    //[SerializeField] TextMesh tmp;
    [SerializeField] TMP_Text tmp;
    private Vector3 offset = new Vector3(0, 2.3f, 0);
    private Vector3 randomiseIntensity = new Vector3(0.3f, 0.3f, 0.3f);
    Camera cameraToLookAt;

    public void OnActivate(int num)
    {
        cameraToLookAt = Camera.main;
        tmp.text = num.ToString();
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomiseIntensity.x, randomiseIntensity.x), 
            Random.Range(-randomiseIntensity.y, randomiseIntensity.y), 
            Random.Range(-randomiseIntensity.z, randomiseIntensity.z));
    }
    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
