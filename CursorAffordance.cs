using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] Texture2D defaultCursor = null;
    [SerializeField] Texture2D interactCursor = null;
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    private void Start()
    {
        if (Player.instance)
        {
            playerController = Player.instance.gameObject.GetComponent<PlayerController>();
            playerController.onLayerChange += onLayerChanged;
        }
    }

    //Adds to the layer change delegate
    private void onLayerChanged(int layer)
    {
        switch (layer)
        {
            case 15: //Layer 15
                Cursor.SetCursor(interactCursor, cursorHotspot, CursorMode.Auto);
                break;
            case 11: //Layer 11
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
                return;
        }

    }
}
