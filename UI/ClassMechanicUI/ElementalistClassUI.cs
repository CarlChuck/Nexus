using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalistClassUI : ClassMechanicUI
{
    public Image currenElementBar;


    [SerializeField] private Image utility1Fill = default;
    [SerializeField] private Image utility2Fill = default;
    [SerializeField] private Image eliteFill = default;
    [SerializeField] private Image elementIconFill = default;
    [SerializeField] private Image currentIcon = default;
    [SerializeField] private Image airIcon = default;
    [SerializeField] private Image earthIcon = default;
    [SerializeField] private Image fireIcon = default;
    [SerializeField] private Image waterIcon = default;


    public void SetElementAir()
    {
        currentIcon.sprite = airIcon.sprite;
    }

    public void SetElementEarth()
    {
        currentIcon.sprite = earthIcon.sprite;
    }

    public void SetElementFire()
    {
        currentIcon.sprite = fireIcon.sprite;
    }

    public void SetElementWater()
    {
        currentIcon.sprite = waterIcon.sprite;
    }

    public void SetUtilityOneFill(float setFill)
    {
        utility1Fill.fillAmount = setFill;
    }
    public void SetUtilityTwoFill(float setFill)
    {
        utility2Fill.fillAmount = setFill;
    }
    public void SetEliteFill(float setFill)
    {
        eliteFill.fillAmount = setFill;
    }

    public void SetAttunementFill(float setFill)
    {
        //elementIconFill.fillAmount = setFill;
    }
}
