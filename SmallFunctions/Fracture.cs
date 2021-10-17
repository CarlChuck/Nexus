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
            destroyedItem.SetActive(true);
            originalItem.SetActive(false);

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
                            rb.AddExplosionForce(200f, transform.position, 30f);
                            StartCoroutine(RemoveThisWithDelay(rb, 5f));
                            StartCoroutine(RemoveThisWithDelay(rb.gameObject.GetComponent<MeshCollider>(), 5f));
                        }
                        else
                        {
                            rb.AddExplosionForce(200f, origin.position, 50f);
                            StartCoroutine(RemoveThisWithDelay(rb, 5f));
                            StartCoroutine(RemoveThisWithDelay(rb.gameObject.GetComponent<MeshCollider>(), 5f));
                        }
                    }
                }
            }
            StartCoroutine(RemoveThisWithDelay(gameObject, 10f));            
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
    IEnumerator RemoveThisWithDelay(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (rb != null)
        {
            Destroy(rb);
        }
    }
    IEnumerator RemoveThisWithDelay(MeshCollider col, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (col != null)
        {
            Destroy(col);
        }
    }
}
