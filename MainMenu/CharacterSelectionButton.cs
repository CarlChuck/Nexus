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
        animator.SetBool("mouseClickDown", true);
        if (audioClick != null)
        {
            audioClick.Play();
        }
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        animator.SetBool("select", true);
        animator.SetBool("mouseClickDown", false);
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
}
