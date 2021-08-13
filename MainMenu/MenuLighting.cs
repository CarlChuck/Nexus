using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLighting : MonoBehaviour
{
    [SerializeField] GameObject frontMenuSpotlight;
    [SerializeField] GameObject selectSpotlights;
    [SerializeField] GameObject creationSpotlights;

    private void Start()
    {
        ResetAllLights();
        frontMenuSpotlight.SetActive(true);
    }

    private void ResetAllLights()
    {
        frontMenuSpotlight.SetActive(false);
        selectSpotlights.SetActive(false);
        creationSpotlights.SetActive(false);
    }

    public void ActivateFrontMenuLighting()
    {
        ResetAllLights();
        frontMenuSpotlight.SetActive(true);
    }

    public void ActivateSelectLighting()
    {
        ResetAllLights();
        StartCoroutine(ActivateObject(selectSpotlights));
    }
    public void ActivateCreationLighting()
    {
        ResetAllLights();
        StartCoroutine(ActivateObject(creationSpotlights));
    }

    IEnumerator ActivateObject(GameObject objectToActivate)
    {
        yield return new WaitForSeconds(1f);
        objectToActivate.SetActive(true);
    }
}
