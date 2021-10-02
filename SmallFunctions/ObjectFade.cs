
using UnityEngine;
using System.Collections;

public class ObjectFade : MonoBehaviour
{
    //This script must be attached to the collider that the player walks through, this will swap the visible gameObjects.

    [SerializeField] private GameObject upperSection = default;
    [SerializeField] private GameObject innerSection = default;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            DeactivateWall();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            ActivateWall();
        }
    }

    public void ActivateWall()
    {
        upperSection.SetActive(true);
        innerSection.SetActive(false);
    }

    public void DeactivateWall()
    {
        upperSection.SetActive(false);
        innerSection.SetActive(true);
    }
}
