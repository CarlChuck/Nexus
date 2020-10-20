using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Animator animator = default;
    [SerializeField] GameObject toOpen = default;
    [SerializeField] GameObject toClose = default;
    [SerializeField] MCharStats mStats = default;
    [SerializeField] bool setClass = default;
    [SerializeField] int num = default;
    [SerializeField] MainMenu mMenu = default;
    [SerializeField] MenuFunc mFunc = default;
    [SerializeField] AudioSource audioOver = default;
    [SerializeField] AudioSource audioClick = default;


    public void OnPointerDown(PointerEventData pointerData)
    {
        animator.SetBool("pressed", true);
        if (toOpen != null)
        {
            toOpen.SetActive(true);
        }
        if (toClose != null)
        {
            toOpen.SetActive(false);
        }
        if (mStats != null)
        {
            if (setClass == true)
            {
                mStats.SetClass(num);
            }
        }
        if (mMenu != null)
        {
            mMenu.MenuFunction(mFunc);
        }
        audioClick.Play();
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        animator.SetBool("pressed", false);
    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        transform.SetAsLastSibling();
        animator.SetBool("selected", true);
        audioOver.Play();
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        animator.SetBool("selected", false);
    }

}
