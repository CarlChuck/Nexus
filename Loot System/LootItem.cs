using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    [SerializeField] private InventoryItem item = default;
    [SerializeField] private Rigidbody rb = default;
    [SerializeField] private BoxCollider bCol = default;
    [SerializeField] private SphereCollider sCol = default;
    [SerializeField] private Color rarityColor;


    public void ActivateLootItem(InventoryItem inItem, Vector3 spawnPos)
    {
        //Set Item
        item = inItem;

        //Set colliders
        if (gameObject.GetComponent<BoxCollider>())
        {
            bCol = gameObject.GetComponent<BoxCollider>();
        }
        if (gameObject.GetComponent<SphereCollider>())
        {
            sCol = gameObject.GetComponent<SphereCollider>();
        }

        //Set graphic
        GameObject model = Instantiate(item.lootDropGraphic, gameObject.transform);

        //Set spawn in location
        Vector3 newPos = new Vector3(spawnPos.x + Random.Range(-0.1f, 0.1f), spawnPos.y, spawnPos.z + Random.Range(-0.1f, 0.1f));

        gameObject.transform.position = newPos;

        //Apply a random force
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
        float speed = 2;
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 1, force.z);
        rb.AddForce(force * speed);

        //Stop Collisions
        StartCoroutine(MakeLootable(1f));
        StartCoroutine(ClearRb(gameObject, 3f));
    }
    private void OnTriggerEnter(Collider collision)
    {
        //AutoLoot system
        if (collision.transform.GetComponent<AutoLoot>())
        {
            AutoLoot aLoot = collision.transform.GetComponent<AutoLoot>();
            aLoot.LootItem(this, item);
        }
    }

    public void DisableCollider()
    {
        sCol.enabled = false;
    }

    IEnumerator ClearRb(GameObject obj, float delay) //Makes walking easier
    {
        yield return new WaitForSeconds(delay);
        if (obj != null && rb != null)
        {
            rb.isKinematic = true;
        }
        if (bCol != null)
        {
            bCol.enabled = false;
        }
    }

    IEnumerator MakeLootable(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (sCol != null)
        {
            sCol.enabled = true;
        }
    }
}
