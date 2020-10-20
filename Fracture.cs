using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    public GameObject originalItem;
    public GameObject destroyedItem;

    public GameObject explosionEffect;


    //OnDestruction will use argument point of origin for adding exposive force, will use origin as models point of origin otherwise.
    public void OnDestruction(Transform origin = null)
    {

        //Gives an explosion VFX if one is present in inspector.
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        //Replaces the object with the fractured model and then adds force.
        if (destroyedItem != null && originalItem != null)
        {        
            //Replaces Objects
            GameObject fracturedObj = Instantiate(destroyedItem, transform.position, transform.rotation);
            Destroy(originalItem);
            originalItem = null;

            //Applies Force
            Collider[] colliders = Physics.OverlapSphere(transform.position, 30f);
            foreach (Collider peice in colliders)
            {
                if (peice.CompareTag("destructible"))
                {
                    Rigidbody rb = peice.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        if (origin == null)
                        {
                            rb.AddExplosionForce(1000f, transform.position, 30f);
                        }
                        else
                        {
                            rb.AddExplosionForce(1000f, origin.position, 50f);
                        }
                    }
                }
            }
            StartCoroutine(RemoveThisWithDelay(fracturedObj, 10f));
            StartCoroutine(RemoveThisWithDelay(gameObject, 11f));            
            //Just to destroy both script holder and the item, in case they are located in different areas for cleanup. Though both should be on same object.
        }
    }
    IEnumerator RemoveThisWithDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
