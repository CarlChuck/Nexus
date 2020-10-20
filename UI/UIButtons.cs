using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public GameObject returnToHubButton;

    private void Start()
    {
        returnToHubButton.SetActive(false);
    }

    public void activateHubButton()
    {
        returnToHubButton.SetActive(true);
    }

    public void deactivateHubButton()
    {
        returnToHubButton.SetActive(false);
    }

    public void returnToHub()
    {
        SceneManager.LoadScene("SingularityBar");
        deactivateHubButton();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
