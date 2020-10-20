using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject rhIK = default;
    [SerializeField] private GameObject lhIK = default;


    private void Start()
    {
        UnEquipRight();
        UnEquipLeft();
    }

    public void UnEquipRight()
    {

    }
    public void UnEquipLeft()
    {

    }

    public void OnEquipPistolRight()
    {

    }
    public void OnEquipPistolLeft()
    {

    }
    public void OnEquipMeleeRight()
    {

    }
    public void OnEquipMeleeLeft()
    {

    }
    public void OnEquipWandRight()
    {

    }
    public void OnEquipWandLeft()
    {

    }
    public void OnEquipGloveRight()
    {

    }
    public void OnEquipGloveLeft()
    {

    }
    public void OnEquipRifle()
    {

    }
    public void OnEquipStaff()
    {

    }
    public void OnEquipShield()
    {

    }
    public void OnEquipFoci()
    {

    }

    public void OnShootPistolRight()
    {
        //StartCoroutine(MoveBetweenPoints(rhIK, 0.2f, 0.8f, pistolRHAttack.position, pistolRHBase.position));
    }
    public void OnShootPistolLeft()
    {
        //StartCoroutine(MoveBetweenPoints(lhIK, 0.2f, 0.8f, pistolLHAttack.position, pistolLHBase.position));
    }
    public void OnShootMeleeRight()
    {

    }
    public void OnShootMeleeLeft()
    {

    }
    public void OnShootWandRight()
    {

    }
    public void OnShootWandLeft()
    {

    }
    public void OnShootGloveRight()
    {

    }
    public void OnShootGloveLeft()
    {

    }
    public void OnShootRifle()
    {

    }
    public void OnShootStaff()
    {

    }
    public void OnShootShield()
    {

    }
    public void OnShootFoci()
    {

    }
    /*
    private IEnumerator MoveBetweenPoints(GameObject ikToMove, float secondsUp, float secondsDown, Vector3 target, Vector3 origin)
    {
        float timeToTarget = 0;
        AnimationState animState = AnimationState.AnimateUp; // 0 is up, 1 is down, 2 is done
        float elapsedTime = 0;
        while (elapsedTime < secondsUp + secondsDown)
        {
            if (animState == AnimationState.AnimateUp)
            {
                if (Vector3.Distance(ikToMove.transform.position, target) > 0.1f)
                {
                    timeToTarget += Time.deltaTime / secondsUp;
                    Debug.Log("Animation Up");
                    ikToMove.transform.position = Vector3.Lerp(ikToMove.transform.position, target, timeToTarget);
                }
                else
                {
                    timeToTarget = 0;
                    animState = AnimationState.AnimateDown;
                }
            }
            if (animState == AnimationState.AnimateDown)
            {
                if (Vector3.Distance(ikToMove.transform.position, origin) > 0.1f)
                {
                    timeToTarget += Time.deltaTime / secondsDown;
                    Debug.Log("Animation Up");
                    ikToMove.transform.position = Vector3.Lerp(ikToMove.transform.position, target, timeToTarget); ;
                }
                else
                {
                    animState = AnimationState.AnimateEnd;
                }
            }
            if (animState == AnimationState.AnimateEnd)
            {
                ikToMove.transform.position = origin;
                yield break;
            }
            elapsedTime += Time.deltaTime;
        }
        yield return new WaitForEndOfFrame();             
    }*/

    private enum AnimationState {AnimateUp, AnimateDown, AnimateEnd }
}
