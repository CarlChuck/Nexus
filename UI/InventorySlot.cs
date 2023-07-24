using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public ItemType iType;
    public ItemSlot slot;
    //public int slotNumber; //Used for skills and weapons
    public InventoryUI invUI;
    [SerializeField] GameObject hoverLight;
    [SerializeField] GameObject selectLight;

    [SerializeField] private Renderer rendererForEmission = default;

    private void Start()
    {
        invUI = InventoryUI.instance;
    }

    public void SelectSlot()
    {
        invUI = InventoryUI.instance;
        foreach (InventorySlot invSlot in invUI.invSlots)
        {
            invSlot.DeSelectSlot();
        }
        invUI.UpdateFromSelectedSlot(this);
        rendererForEmission.material.SetColor("_EmissiveColor", invUI.selectedEmissiveColour);
        selectLight.SetActive(true);
        hoverLight.SetActive(false);
    }
    public void DeSelectSlot()
    {
        rendererForEmission.material.SetColor("_EmissiveColor", invUI.baseEmissiveColour);
        selectLight.SetActive(false);
        hoverLight.SetActive(false);
    }

    public void OnPointerDown(PointerEventData pointerData)
    {

    }
    public void OnPointerUp(PointerEventData pointerData)
    {

        SelectSlot();
    }
    public void OnPointerEnter(PointerEventData pointerData)
    {
        if (invUI.selectedSlot != this)
        {
            rendererForEmission.material.SetColor("_EmissiveColor", invUI.hoverEmissiveColour);
            selectLight.SetActive(false);
            hoverLight.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        if (invUI.selectedSlot != this)
        {
            rendererForEmission.material.SetColor("_EmissiveColor", invUI.baseEmissiveColour);
            selectLight.SetActive(false);
            hoverLight.SetActive(false);
        }   
    }
}
public enum ItemSlot {RWeap, LWeap}
