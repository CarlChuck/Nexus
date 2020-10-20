using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    [SerializeField] private Image rarityColourArea = default;
    public GameObject selectedImage;
    public Sprite baseImageBorder;
    public Sprite selectedImageBorder;
    public ItemType iType;
    public int slotNumber; //Used for skills and weapons

    //Just sets the item rarity colour in border
    private void UpdateQuality()
    {
        if (item != null)
        {
            switch (item.quality)
            {
                case Quality.Common:
                    rarityColourArea.color = new Color32(255, 255, 255, 255);
                    break;
                case Quality.Uncommon:
                    rarityColourArea.color = new Color32(100, 100, 175, 255);
                    break;
                case Quality.Masterwork:
                    rarityColourArea.color = new Color32(100, 175, 100, 255);
                    break;
                case Quality.Rare:
                    rarityColourArea.color = new Color32(200, 200, 100, 255);
                    break;
                case Quality.Legendary:
                    rarityColourArea.color = new Color32(150, 75, 175, 255);
                    break;
                case Quality.Unique:
                    rarityColourArea.color = new Color32(200, 125, 100, 255);
                    break;
                default:
                    rarityColourArea.color = new Color32(255, 255, 255, 255);
                    break;
            }
        }
        else
        {
            rarityColourArea.color = new Color32(255, 255, 255, 255);
        }
    }

    public void UpdateInfoPanel(InfoPane infoPane)
    {
        if (item != null)
        {
            infoPane.infoText.text = item.description;
            infoPane.infoTitle.text = item.name;
        }
        else
        {
            infoPane.infoText.text = "";
            infoPane.infoTitle.text = "";
        }
    }    
    public void UpdateItem(Item itemToAdd)
    {
        item = itemToAdd;
        //UpdateInfoPanel();
        UpdateQuality();
    }
    public void RemoveItem()
    {
        item = null;
        //UpdateInfoPanel();
        UpdateQuality();
    }

    public void SelectSlot()
    {
        selectedImage.GetComponent<Image>().sprite = selectedImageBorder;
    }
    public void DeSelectSlot()
    {
        selectedImage.GetComponent<Image>().sprite = baseImageBorder;
    }

    public void OnPointerDown(PointerEventData pointerData)
    {

    }
    public void OnPointerUp(PointerEventData pointerData)
    {
        InventoryUI invUI = InventoryUI.instance;
        invUI.selected = this;
        invUI.OpenPaneFromItem(iType);
        if (item != null)
        {
            invUI.EquippedItemStats(item);
        }
        else
        {
            invUI.equippedItemInfo.EmptyInfo();
        }
    }
    public void OnPointerEnter(PointerEventData pointerData)
    {
        SelectSlot();
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        DeSelectSlot();
    }
}
