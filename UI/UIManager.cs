using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private ClassMechanicUI golemancerUI = default;
    [SerializeField] private ClassMechanicUI elementalistUI = default;
    [SerializeField] private ClassMechanicUI psycUI = default;
    [SerializeField] private ClassMechanicUI mysticUI = default;
    [SerializeField] private ClassMechanicUI artificerUI = default;
    [SerializeField] private ClassMechanicUI apochUI = default;
    [SerializeField] private ClassMechanicUI crypterUI = default;
    [SerializeField] private ClassMechanicUI nanoMageUI = default;
    [SerializeField] private ClassMechanicUI guardianUI = default;
    [SerializeField] private ClassMechanicUI vigilUI = default;
    [SerializeField] private ClassMechanicUI shadowUI = default;
    [SerializeField] private ClassMechanicUI streetDocUI = default;


    [SerializeField] private Image healthImage = default;
    [SerializeField] private Image weap1Fill = default;
    [SerializeField] private Image weap2Fill = default;
    [SerializeField] private Image weap3Fill = default;
    [SerializeField] private Image weap4Fill = default;

    public void OnStartMechanic()
    {
        DeActivateMechanics();
        switch (Player.instance.cClass)
        {
            case CharClass.Golemancer:
                golemancerUI.gameObject.SetActive(true);
                break;
            case CharClass.Elementalist:
                elementalistUI.gameObject.SetActive(true);
                break;
            case CharClass.Psyc:
                psycUI.gameObject.SetActive(true);
                break;
            case CharClass.Mystic:
                mysticUI.gameObject.SetActive(true);
                break;
            case CharClass.Artificer:
                artificerUI.gameObject.SetActive(true);
                break;
            case CharClass.Apoch:
                apochUI.gameObject.SetActive(true);
                break;
            case CharClass.Crypter:
                crypterUI.gameObject.SetActive(true);
                break;
            case CharClass.NanoMage:
                nanoMageUI.gameObject.SetActive(true);
                break;
            case CharClass.Guardian:
                guardianUI.gameObject.SetActive(true);
                break;
            case CharClass.Vigil:
                vigilUI.gameObject.SetActive(true);
                break;
            case CharClass.Shadow:
                shadowUI.gameObject.SetActive(true);
                break;
            case CharClass.StreetDoctor:
                streetDocUI.gameObject.SetActive(true);
                break;
        }
    }

    private void DeActivateMechanics()
    {
        golemancerUI.gameObject.SetActive(false);
        elementalistUI.gameObject.SetActive(false);
        psycUI.gameObject.SetActive(false);
        mysticUI.gameObject.SetActive(false);
        artificerUI.gameObject.SetActive(false);
        apochUI.gameObject.SetActive(false);
        crypterUI.gameObject.SetActive(false);
        nanoMageUI.gameObject.SetActive(false);
        guardianUI.gameObject.SetActive(false);
        vigilUI.gameObject.SetActive(false);
        shadowUI.gameObject.SetActive(false);
        streetDocUI.gameObject.SetActive(false);
    }

    public void SetHealthBar(float setHealth)
    {
        healthImage.fillAmount = setHealth;
    }

    public void SetWeapOneFill(float setFill)
    {
        weap1Fill.fillAmount = setFill;
    }
    public void SetWeapTwoFill(float setFill)
    {
        weap2Fill.fillAmount = setFill;
    }
    public void SetWeapThreeFill(float setFill)
    {
        weap3Fill.fillAmount = setFill;
    }
    public void SetWeapFourFill(float setFill)
    {
        weap4Fill.fillAmount = setFill;
    }

    public ClassMechanicUI GetGolemancerUI()
    {
        return golemancerUI;
    }
    public ClassMechanicUI GetElementalistUI()
    {
        return elementalistUI;
    }
    public ClassMechanicUI GetPsycUI()
    {
        return psycUI;
    }
    public ClassMechanicUI GetMysticUI()
    {
        return mysticUI;
    }
    public ClassMechanicUI GetArtificerUI()
    {
        return artificerUI;
    }
    public ClassMechanicUI GetApochUI()
    {
        return apochUI;
    }
    public ClassMechanicUI GetCrypterUI()
    {
        return crypterUI;
    }
    public ClassMechanicUI GetNanoMageUI()
    {
        return nanoMageUI;
    }
    public ClassMechanicUI GetGuardianUI()
    {
        return guardianUI;
    }
    public ClassMechanicUI GetVigilUI()
    {
        return vigilUI;
    }
    public ClassMechanicUI GetShadowUI()
    {
        return shadowUI;
    }
    public ClassMechanicUI GetStreetDocUI()
    {
        return streetDocUI;
    }
}
