using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private StartSceneSelector sceneSelector;
    private SaveSystemManager saveSystem;
    private CharacterData thisCharacter;

    private void Start()
    {
        saveSystem = SaveSystemManager.instance;
        thisCharacter = saveSystem.GetSelectedCharacter();
        StartPlayerFromSave();
    }

    public void StartPlayerFromSave()
    {
        player.ActivateCharacter(thisCharacter.GetName(), thisCharacter.GetCharClass(), thisCharacter.GetScene(), thisCharacter.GetXP(), thisCharacter.GetLevel());
        sceneSelector.LoadScene(player.savePoint);
    }
}
