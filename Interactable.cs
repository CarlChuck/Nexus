using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 10f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void interact()
    {
        //for Override
    }

    public virtual void OnMouseOver()
    {
        //for Override
    }

    public virtual void OnMouseExit()
    {
        //for Override
    }
}
