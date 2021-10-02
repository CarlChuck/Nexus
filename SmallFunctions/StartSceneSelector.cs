using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneSelector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AScene scene = Player.instance.savePoint;
        StartScene(scene);
    }

    void StartScene(AScene scene)
    {
        switch (scene)
        {
            case AScene.Tutorial:
                SceneManager.LoadScene("EarthD31");
                break;
            case AScene.Singularity:
                SceneManager.LoadScene("SingularityBar");
                break;
        }
    }
}

public enum AScene {Tutorial, Singularity } //TODO To be added to as game increases