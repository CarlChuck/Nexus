using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boon : MonoBehaviour
{
    public StatBlock owner;
    public StatBlock appliedBy;
    public BoonName boonName;
    public float duration;
    public int energyShield;

    private void Start()
    {
        //TODO add UI element
        name = boonName.ToString();
        duration = duration * (appliedBy.persistence.GetValue() / 100);
        if (boonName == BoonName.Regeneration)
        {
            owner.HasRegenerationBoon();
        }
    }

    private void FixedUpdate()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            EndBoon();
        }
        Debug.Log("Boon: " + boonName + "On: " + owner + "Timer:" + duration);
    }

    public void EndBoon()
    {
        Debug.Log("Boon: " + boonName + "Ended");
        //TODO remove UI element
        owner.boons.Remove(owner.GetBoon(boonName));
        Destroy(gameObject);
    }
    

}