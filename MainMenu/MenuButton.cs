using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator animator = default;
    [SerializeField] private AudioSource audioOver = default;
    [SerializeField] private AudioSource audioClick = default;

    //Is this a class button checkbox
    [SerializeField] private bool classButton = false;

    [Tooltip("If Class Button is false")]
    [SerializeField] private MenuFunc mFunc = default;

    [Tooltip("If Class Button is true")]
    [SerializeField] private CharClass mAvatar = default;

    [SerializeField] private GameObject baseBackLight = default;
    [SerializeField] private GameObject selectedBackLight = default;
    [SerializeField] private GameObject outerBaseBackLight = default;
    [SerializeField] private GameObject outerSelectedBackLight = default;
    [SerializeField] private GameObject vfx = default;
    [SerializeField] private Material emissiveMaterial = default;
    [ColorUsage(true, true)]
    [SerializeField] private Color baseColour = default;
    [ColorUsage(true, true)]
    [SerializeField] private Color selectedColour = default;



    private MainMenu mMenu = default;

    public void Start()
    {
        mMenu = MainMenu.instance; 
        baseBackLight.SetActive(false);
        selectedBackLight.SetActive(false);
        outerBaseBackLight.SetActive(true);
        outerSelectedBackLight.SetActive(false);
        emissiveMaterial.EnableKeyword("_EMISSION");
        vfx.SetActive(false);

    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        transform.SetAsLastSibling();
        animator.SetBool("hover", true);
        if (audioOver != null)
        {
            audioOver.Play();
        }
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        animator.SetBool("hover", false);
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        animator.SetBool("pressed", true);

        if (classButton == true)
        {
            mMenu.cCreationPane.SetClass(mAvatar);
            mMenu.mAvatarButtons.LoadThisAvatar(mAvatar);
            mMenu.cCreationPane.OnUpdateClassInfoWindow();
        }
        else
        {
            mMenu.MenuFunction(mFunc);
        }
        if (audioClick != null)
        {
            audioClick.Play();
        }
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        if (classButton == false)
        {
            animator.SetBool("pressed", false);
        }
        else
        {
            mMenu.mAvatarButtons.ResetAllButtons();
            mMenu.mAvatarButtons.UpdateClassDescription();
            animator.SetBool("selected", true); 
            animator.SetBool("pressed", false);
        }
    }


    public void SetAnimationDeSelected()
    {
        animator.SetBool("selected", false);
    }

    public void ButtonMouseOver()
    {
        baseBackLight.SetActive(true);
    }
    public void ButtonSelect()
    {

        baseBackLight.SetActive(false);
        selectedBackLight.SetActive(true);
        outerBaseBackLight.SetActive(false);
        outerSelectedBackLight.SetActive(true);
        emissiveMaterial.SetColor("_EmissiveColor", selectedColour);
        vfx.SetActive(true);
    }
    public void ButtonDeselect()
    {
        baseBackLight.SetActive(false);
        selectedBackLight.SetActive(false);
        outerBaseBackLight.SetActive(true);
        outerSelectedBackLight.SetActive(false);
        emissiveMaterial.SetColor("_EmissiveColor", baseColour);
        vfx.SetActive(false);

    }
}
