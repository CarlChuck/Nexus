using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    //Master Physics Objects
    [SerializeField] private Collider oldCollider = default;
    [SerializeField] private Rigidbody oldRB = default;

    //RagDoll Physics Objects
    [SerializeField] private Collider headCollider = default;
    [SerializeField] private Collider torsoCollider = default;
    [SerializeField] private Collider pelvisCollider = default;
    [SerializeField] private Collider rArmCollider = default;
    [SerializeField] private Collider rElbowCollider = default;
    [SerializeField] private Collider lArmCollider = default;
    [SerializeField] private Collider lElbowCollider = default;
    [SerializeField] private Collider rLegCollider = default;
    [SerializeField] private Collider rShinCollider = default;
    [SerializeField] private Collider lLegCollider = default;
    [SerializeField] private Collider lShinCollider = default;

    [SerializeField] private Rigidbody headRB = default;
    [SerializeField] private Rigidbody torsoRB = default;
    [SerializeField] private Rigidbody pelvisRB = default;
    [SerializeField] private Rigidbody rArmRB = default;
    [SerializeField] private Rigidbody rElbowRB = default;
    [SerializeField] private Rigidbody lArmRB = default;
    [SerializeField] private Rigidbody lElbowRB = default;
    [SerializeField] private Rigidbody rLegRB = default;
    [SerializeField] private Rigidbody rShinRB = default;
    [SerializeField] private Rigidbody lLegRB = default;
    [SerializeField] private Rigidbody lShinRB = default;


    [SerializeField] private Transform forceLocation = default;

    private void Start()
    {
        DeactivateRB();
    }

    public void StartRigidBody()
    {
        ActivateRB();
        RemoveOldPhysics();
    }
    public void StartExplosiveRigidBody()
    {
        ActivateRB();
        RemoveOldPhysics();

        //Applies Force
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);
        foreach (Collider peice in colliders)
        {
            Rigidbody rb = peice.GetComponent<Rigidbody>();
            if (rb != null)
            {
                    rb.AddExplosionForce(500f, forceLocation.position, 10f);
            }
        }
    }

    private void ActivateRB()
    {
        headCollider.enabled = true;
        torsoCollider.enabled = true;
        pelvisCollider.enabled = true;
        rArmCollider.enabled = true;
        rElbowCollider.enabled = true;
        lArmCollider.enabled = true;
        lElbowCollider.enabled = true;
        rLegCollider.enabled = true;
        rShinCollider.enabled = true;
        lLegCollider.enabled = true;
        lShinCollider.enabled = true;

        headRB.isKinematic = false;
        torsoRB.isKinematic = false;
        pelvisRB.isKinematic = false;
        rArmRB.isKinematic = false;
        rElbowRB.isKinematic = false;
        lArmRB.isKinematic = false;
        lElbowRB.isKinematic = false;
        rLegRB.isKinematic = false;
        rShinRB.isKinematic = false;
        lLegRB.isKinematic = false;
        lShinRB.isKinematic = false;
        StartCoroutine(EndRB(2f));
    }

    private void DeactivateRB()
    {
        headCollider.enabled = false;
        torsoCollider.enabled = false;
        pelvisCollider.enabled = false;
        rArmCollider.enabled = false;
        rElbowCollider.enabled = false;
        lArmCollider.enabled = false;
        lElbowCollider.enabled = false;
        rLegCollider.enabled = false;
        rShinCollider.enabled = false;
        lLegCollider.enabled = false;
        lShinCollider.enabled = false;

        headRB.isKinematic = true;
        torsoRB.isKinematic = true;
        pelvisRB.isKinematic = true;
        rArmRB.isKinematic = true;
        rElbowRB.isKinematic = true;
        lArmRB.isKinematic = true;
        lElbowRB.isKinematic = true;
        rLegRB.isKinematic = true;
        rShinRB.isKinematic = true;
        lLegRB.isKinematic = true;
        lShinRB.isKinematic = true;
    }

    private void RemoveOldPhysics()
    {
        oldCollider.enabled = false;
        oldRB.isKinematic = true;
    }

    private void ReturnOldPhysics()
    {
        oldCollider.enabled = true;
    }

    public void RagdollThroughFloor()
    {
        headRB.detectCollisions = false;
        torsoRB.detectCollisions = false;
        pelvisRB.detectCollisions = false;
        rArmRB.detectCollisions = false;
        rElbowRB.detectCollisions = false;
        lArmRB.detectCollisions = false;
        lElbowRB.detectCollisions = false;
        rLegRB.detectCollisions = false;
        rShinRB.detectCollisions = false;
        lLegRB.detectCollisions = false;
        lShinRB.detectCollisions = false;
    }

    IEnumerator EndRB(float wTime)
    {
        yield return new WaitForSeconds(wTime);
        DeactivateRB();
    }
}
