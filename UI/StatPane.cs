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
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI armourText;
    public TextMeshProUGUI mitigationText;
    public TextMeshProUGUI blockText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI marksmanshipText;
    public TextMeshProUGUI arcanaText;

    public TextMeshProUGUI movementText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI ferocityText;
    public TextMeshProUGUI devastationText;
    public TextMeshProUGUI afflictionText;
    public TextMeshProUGUI persistenceText;
    public TextMeshProUGUI luckText;
    public TextMeshProUGUI xpGainText;
    public TextMeshProUGUI leechText;
    public TextMeshProUGUI regenText;
    public TextMeshProUGUI feedbackText;

    public TextMeshProUGUI thermalResistText;
    public TextMeshProUGUI cryoResistText;
    public TextMeshProUGUI shockResistText;
    public TextMeshProUGUI radResistText;
    public TextMeshProUGUI psiResistText;
    public TextMeshProUGUI dimensionResistText;
    public TextMeshProUGUI kineticResistText;
    public TextMeshProUGUI poisonResistText;
    public TextMeshProUGUI bioResistText;
    public TextMeshProUGUI corruptResistText;

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
        healthText.text = player.currentHealth.ToString();
        UpdateStat(player.armour, armourText);
        mitigationText.text = player.armourIncreasePercentage.ToString();
        UpdateStat(player.vitality, blockText);
        UpdateStat(player.strength, strengthText);
        UpdateStat(player.marksmanship, marksmanshipText);
        UpdateStat(player.arcana, arcanaText);

        UpdateStat(player.movement, movementText);
        UpdateStat(player.speed, speedText);
        UpdateStat(player.ferocity, ferocityText);
        UpdateStat(player.devastation, devastationText);
        UpdateStat(player.affliction, afflictionText);
        UpdateStat(player.persistence, persistenceText);
        UpdateStat(player.luck, luckText);
        UpdateStat(player.xpGain, xpGainText);
        UpdateStat(player.leech, leechText);
        UpdateStat(player.regen, regenText);
        UpdateStat(player.feedback, feedbackText);

        UpdateStat(player.thermalResistance, thermalResistText);
        UpdateStat(player.cryoResistance, cryoResistText);
        UpdateStat(player.shockResistance, shockResistText);
        UpdateStat(player.radiationResistance, radResistText);
        UpdateStat(player.psiResistance, psiResistText);
        UpdateStat(player.dimensionResistance, dimensionResistText);
        UpdateStat(player.kineticResistance, kineticResistText);
        UpdateStat(player.poisonResistance, poisonResistText);
        UpdateStat(player.bioResistance, bioResistText);
        UpdateStat(player.corruptionResistance, corruptResistText);
    }
}
