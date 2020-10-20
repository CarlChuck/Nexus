using UnityEngine;
using UnityEngine.EventSystems;

public class EquippedItem : MonoBehaviour//, IDropHandler
{
    public Transform parentToSet;
    public Transform startParent;
    public InventoryUI invUI;
    public int dockType; //0 Weapon || 1 Cybernetic || 2 Genetic || 3 Skill || 4 Outfit || 5 Headgear
    public int slotNumber; //starts at 1, 1=right hand, 2=left hand, rest are 1 -> 5 etc
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;
    public Transform slot5;
    public Transform slot6;
    ItemType itemType;

    //OnDrop for InventorySlot being dropped into a equiped dock
    /*
    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.itemBeingDragged != null)
        {
            Item itemToEquip = DragHandler.itemBeingDragged.gameObject.GetComponent<InventorySlot>().item;
            itemType = DragHandler.itemBeingDragged.gameObject.GetComponent<InventorySlot>().item.itemType;
            startParent = DragHandler.itemBeingDragged.gameObject.GetComponent<DragHandler>().startParent;
            Inventory inv = Inventory.instance;
            if (parentToSet != startParent && dockType == (int)itemType)
            {
                if (itemToEquip.itemType == ItemType.Weapon)
                {
                    Weapon weapon = itemToEquip as Weapon;
                    Handed weaponHandedness = weapon.handedness;

                    if (weaponHandedness == Handed.TwoHanded)
                    {
                        inv.removeWeapon(1);
                        inv.removeWeapon(2);
                        inv.addWeapon(weapon, 1);                        
                    }
                    else if (inv.rHand!= null && inv.rHand.handedness == Handed.TwoHanded)
                    {                        
                        if (weaponHandedness == Handed.LeftOnly && slotNumber == 1)
                        {
                            DragHandler.itemBeingDragged.transform.SetParent(parentToSet);
                        }
                        else if (weaponHandedness == Handed.RightOnly && slotNumber == 2)
                        {
                            DragHandler.itemBeingDragged.transform.SetParent(parentToSet);
                        }
                        else
                        {
                            inv.removeWeapon(1);
                            inv.addWeapon(weapon, slotNumber);
                        }
                    }
                    else if (weaponHandedness == Handed.LeftOnly && slotNumber == 2)
                    {
                        inv.removeWeapon(slotNumber);
                        inv.addWeapon(weapon, slotNumber);
                    }
                    else if (weaponHandedness == Handed.RightOnly && slotNumber == 1)
                    {
                        inv.removeWeapon(slotNumber);
                        inv.addWeapon(weapon, slotNumber);
                    }
                    else if (weaponHandedness == Handed.OneHanded)
                    {
                        if (slot1 == startParent)
                        {
                            inv.removeWeapon(1);
                            inv.removeWeapon(2);
                            inv.addWeapon(weapon, slotNumber);
                        }
                        else if (slot2 == startParent)
                        {
                            inv.removeWeapon(1);
                            inv.removeWeapon(2);
                            inv.addWeapon(weapon, slotNumber);
                        }
                        else
                        {
                            inv.removeWeapon(slotNumber);
                            inv.addWeapon(weapon, slotNumber);
                        }
                    }
                    else
                    {
                        DragHandler.itemBeingDragged.transform.SetParent(parentToSet);
                    }
                }
                else if (itemToEquip.itemType == ItemType.Cybernetic)
                {
                    if (slot1 == startParent)
                    {
                        inv.removeCybernetic(1);
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                    else if (slot2 == startParent)
                    {
                        inv.removeCybernetic(2);
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                    else if (slot3 == startParent)
                    {
                        inv.removeCybernetic(3);
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                    else if (slot4 == startParent)
                    {
                        inv.removeCybernetic(4);
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                    else if (slot5 == startParent)
                    {
                        inv.removeCybernetic(5);
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                    else
                    {
                        inv.removeCybernetic(slotNumber);
                        inv.addCybernetic(itemToEquip as Cybernetic, slotNumber);
                    }
                }
                else if (itemToEquip.itemType == ItemType.Genetic)
                {
                    if (slot1 == startParent)
                    {
                        inv.removeGenetic(1);
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                    else if (slot2 == startParent)
                    {
                        inv.removeGenetic(2);
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                    else if (slot3 == startParent)
                    {
                        inv.removeGenetic(3);
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                    else if (slot4 == startParent)
                    {
                        inv.removeGenetic(4);
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                    else if (slot5 == startParent)
                    {
                        inv.removeGenetic(5);
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                    else
                    {
                        inv.removeGenetic(slotNumber);
                        inv.addGenetic(itemToEquip as Genetic, slotNumber);
                    }
                }
                else if (itemToEquip.itemType == ItemType.Skill)
                {
                    Skill skill = itemToEquip as Skill;
                    if (skill.classRequired == Player.instance.cClass)
                    {
                        if (slot1 == startParent)
                        {
                            inv.removeSkill(1);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else if (slot2 == startParent)
                        {
                            inv.removeSkill(2);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else if (slot3 == startParent)
                        {
                            inv.removeSkill(3);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else if (slot4 == startParent)
                        {
                            inv.removeSkill(4);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else if (slot5 == startParent)
                        {
                            inv.removeSkill(5);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else if (slot6 == startParent)
                        {
                            inv.removeSkill(6);
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                        else
                        {
                            inv.removeSkill(slotNumber);
                            inv.addSkill(skill, slotNumber);
                        }
                    }                    
                }
                else if (itemToEquip.itemType == ItemType.Outfit || itemToEquip.itemType == ItemType.Headgear)
                {
                    inv.removeOutfit(slotNumber);
                    inv.addOutfit(itemToEquip as Outfit, slotNumber);
                }
                Destroy(DragHandler.itemBeingDragged);
            }
            else
            {
                DragHandler.itemBeingDragged.transform.SetParent(parentToSet);
            }
        }
        invUI.updateUI();
    }*/
}
