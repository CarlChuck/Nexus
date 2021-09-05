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



    private MainMenu mMenu = default;

    public void Start()
    {
        mMenu = MainMenu.instance;
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
        audioClick.Play();
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

    public void OnPointerEnter(PointerEventData pointerData)
    {
        transform.SetAsLastSibling();
        animator.SetBool("hover", true);
        audioOver.Play();
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        animator.SetBool("hover", false);
    }

    public void SetAnimationDeSelected()
    {
        animator.SetBool("selected", false);
    }

}
