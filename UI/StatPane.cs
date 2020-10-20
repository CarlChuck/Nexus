using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPane : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charClass;

    public TextMeshProUGUI vitalityText;
    public TextMeshProUGUI armourText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI marksmanshipText;
    public TextMeshProUGUI arcanaText;
    public TextMeshProUGUI movementText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI ferocityText;
    public TextMeshProUGUI devastationText;
    public TextMeshProUGUI afflictionText;
    public TextMeshProUGUI persistenceText;
    public TextMeshProUGUI physResistText;
    public TextMeshProUGUI radResistText;
    public TextMeshProUGUI shockResistText;
    public TextMeshProUGUI fireResistText;

    public Color baseColour;
    public Color upColour;
    public Color downColour;

    public EnumsToString eToString;

    private void Start()
    {
        Player player = Player.instance;
        UpdateAllStats(player);
    }

    public void UpdateStat(Stat stat, TextMeshProUGUI text)
    {
        text.text = stat.GetValue().ToString();
        if (stat.PositiveModified() == true)
        {
            text.color = upColour;
        }
        else if (stat.NegativeModified() == true)
        {
            text.color = downColour;
        }
        else
        {
            text.color = baseColour;
        }
    }

    public void UpdateAllStats(Player player)
    {
        charName.text = player.charName;
        charClass.text = eToString.CharClassToString(player.cClass);
        UpdateStat(player.vitality, vitalityText);
        UpdateStat(player.armour, armourText);
        UpdateStat(player.strength, strengthText);
        UpdateStat(player.marksmanship, marksmanshipText);
        UpdateStat(player.arcana, arcanaText);
        UpdateStat(player.movement, movementText);
        UpdateStat(player.speed, speedText);
        UpdateStat(player.ferocity, ferocityText);
        UpdateStat(player.devastation, devastationText);
        UpdateStat(player.affliction, afflictionText);
        UpdateStat(player.persistence, persistenceText);
        UpdateStat(player.physicalResistance, physResistText);
        UpdateStat(player.radResistance, radResistText);
        UpdateStat(player.shockResistance, shockResistText);
        UpdateStat(player.fireResistance, fireResistText);
    }
}
