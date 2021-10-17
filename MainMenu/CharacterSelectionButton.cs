using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelectionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator animator = default;
    [SerializeField] private AudioSource audioOver = default;
    [SerializeField] private AudioSource audioClick = default;
    [SerializeField] private TextMeshProUGUI nameTextField = default;
    [SerializeField] private TextMeshProUGUI levelTextField = default;
    [SerializeField] private TextMeshProUGUI classTextField = default;
    [SerializeField] private GameObject mesh = default;
    [SerializeField] private GameObject classIcon = default;

    [SerializeField] private CharacterData characterDataRef;

    [SerializeField] private GameObject baseBackLight = default;
    [SerializeField] private GameObject selectedBackLight = default;
    [SerializeField] private GameObject vfx = default;
    [SerializeField] private Renderer emissiveMaterial = default;
    [ColorUsage(true, true)]
    [SerializeField] private Color baseColour = default;
    [ColorUsage(true, true)]
    [SerializeField] private Color selectedColour = default;
    [SerializeField] private Color baseTextColour = default;
    [SerializeField] private Color hoverTextColour = default;
    [SerializeField] private Color selectedTextColour = default;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MenuColliders"))
        {
            mesh.SetActive(false);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MenuColliders"))
        {
            mesh.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        animator.SetBool("mouseOver", true);
        if (audioOver != null)
        {
            audioOver.Play();
        }
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        animator.SetBool("mouseOver", false);
    }

    public void OnPointerDown(PointerEventData pointerData)
    {        
        //If this one not already selected
        if (!MainMenu.instance.cSelectionPane.IsCharacterSelected(this))
        {
            animator.SetBool("mouseClickDown", true);
            if (audioClick != null)
            {
                audioClick.Play();
            }
            MainMenu.instance.cSelectionPane.OnAButtonSelected();
        }
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        if (!MainMenu.instance.cSelectionPane.IsCharacterSelected(this))
        {
            animator.SetBool("select", true);
            animator.SetBool("mouseClickDown", false);
            OnSelect();
            MainMenu.instance.cSelectionPane.OnSelectACharacter(this);
        }
    }

    public void OnDeSelect()
    {
        animator.SetBool("select", false);
    }

    public void SetNameField(string name)
    {
        nameTextField.text = name;
    }

    public void SetLevelField(int level)
    {
        levelTextField.text = level.ToString();
    }

    public void SetClassField(CharClass cClass)
    {
        classTextField.text = cClass.ToString();
    }

    public void SetDataObject(CharacterData cData)
    {
        characterDataRef = cData;
    }

    private void OnSelect()
    {
        SaveSystemManager.instance.SelectCharacter(characterDataRef);
    }
    public void ButtonMouseOver()
    {
        baseBackLight.SetActive(true);
        nameTextField.color = hoverTextColour;
        levelTextField.color = hoverTextColour;
        classTextField.color = hoverTextColour;
    }
    public void ButtonMouseExit()
    {
        baseBackLight.SetActive(false);
        nameTextField.color = baseTextColour;
        levelTextField.color = baseTextColour;
        classTextField.color = baseTextColour;
    }
    public void ButtonSelect()
    {
        baseBackLight.SetActive(false);
        selectedBackLight.SetActive(true);
        nameTextField.color = selectedTextColour;
        levelTextField.color = selectedTextColour;
        classTextField.color = selectedTextColour;
        emissiveMaterial.material.SetColor("_EmissiveColor", selectedColour);
        vfx.SetActive(true);
    }
    public void ButtonDeselect()
    {
        baseBackLight.SetActive(false);
        selectedBackLight.SetActive(false);
        nameTextField.color = baseTextColour;
        levelTextField.color = baseTextColour;
        classTextField.color = baseTextColour;
        emissiveMaterial.material.SetColor("_EmissiveColor", baseColour);
        vfx.SetActive(false);
    }
}
