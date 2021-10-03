using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneSelector : MonoBehaviour
{

    public void LoadScene(AScene scene)
    {
        switch (scene)
        {
            case AScene.Tutorial:
                SceneManager.LoadScene("AlbionD31");
                break;
            case AScene.Singularity:
                SceneManager.LoadScene("SingularityBar");
                break;
        }
    }

    private void RemoveOldScene()
    {
        //TODO
    }
}

public enum AScene {Tutorial, Singularity } //TODO To be added to as game increases