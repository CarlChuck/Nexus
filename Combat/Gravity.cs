using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;
    public float gravityForce;
    public float radius;
    public float duration;
    public bool knockback;

    private void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) < radius)
            {
                if (knockback == false)
                {
                    GravityPull(enemy);
                }
                else
                {
                    GravityPush(enemy);
                }
            }
        }
    }

    void GravityPull(Enemy objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        objToAttract.OnPush(duration);//To switch on rigidbody
        rbToAttract.AddForce(direction.normalized * gravityForce);
    }

    void GravityPush(Enemy objToPush)
    {
        Rigidbody rbToPush = objToPush.rb;
        Vector3 direction = rbToPush.position - rb.position;
        float distance = direction.magnitude;

        objToPush.OnPush(duration);//To switch on rigidbody
        rbToPush.AddForce(direction.normalized * gravityForce);
    }
}
