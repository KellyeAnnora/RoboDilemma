using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI energy;
    public TextMeshProUGUI maxEnergy;
    public TextMeshProUGUI partsCount;

    Statkeeper stats;

    private void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Statkeeper>();
    }

    private void Update()
    {
        string levelText = stats.power.ToString();
        string energyText = stats.HP.ToString();
        string maxEnergyText = stats.maxHP.ToString();
        string partsCountText = stats.parts.ToString();

        level.text = levelText;
        energy.text = energyText;
        maxEnergy.text = maxEnergyText;
        partsCount.text = partsCountText;
    }

}
