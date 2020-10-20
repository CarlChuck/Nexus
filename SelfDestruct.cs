using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float time;
    public bool killTimerFromAwake = true;

    private void Awake()
    {
        if (killTimerFromAwake == true)
        {
            StartKillTimer(time);
        }
    }
    public void StartKillTimer(float timer)
    {
        StartCoroutine(SelfDestructTimer(timer));
    }
    IEnumerator SelfDestructTimer(float aTime)
    {
        yield return new WaitForSeconds(aTime);
        Destroy(gameObject);
    }

}
