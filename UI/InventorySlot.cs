using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject selectedGlow;
    public ItemType iType;
    public ItemSlot slot;
    //public int slotNumber; //Used for skills and weapons
    private InventoryUI invUI;

    private void Awake()
    {
        invUI = InventoryUI.instance;
    }

    public void SelectSlot()
    {
        selectedGlow.SetActive(true);
    }
    public void DeSelectSlot()
    {
        selectedGlow.SetActive(false); ;
    }

    public void OnPointerDown(PointerEventData pointerData)
    {

    }
    public void OnPointerUp(PointerEventData pointerData)
    {
        invUI = InventoryUI.instance;
        foreach (InventorySlot invSlot in invUI.invSlots)
        {
            invSlot.DeSelectSlot();
        }
        SelectSlot();
        invUI.UpdateFromSelectedSlot(this);
    }
    public void OnPointerEnter(PointerEventData pointerData)
    {
        //TODO add a bounce
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        //TODO above bounce exit
    }
}
public enum ItemSlot {RWeap, LWeap}
