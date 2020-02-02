using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runemark.DialogueSystem;

[RequireComponent(typeof(Statkeeper))]
public class Shopkeeper : Interactable
{
    Statkeeper keeper;

    public int indexFromDialogue;

    Upgrade currentUpgrade;
    public Upgrade[] upgrades;

    private void Start()
    {
        keeper = GameObject.FindWithTag("Player").GetComponent<Statkeeper>();
    }

    public void AttemptPurchase(int upgradeIndex)
    {
        currentUpgrade = upgrades[upgradeIndex];
        Debug.Log("Attempting to purchase " + currentUpgrade.name);

        int currentCount = keeper.parts;
        if (CheckPartCount(currentCount, currentUpgrade.cost) == true)
        {
            CompletePurchase(currentUpgrade);
            DialogueSystem.SetGlobalVariable<bool>("hasEnoughParts", true);
            Debug.Log("Player has purchased " + currentUpgrade.name);
        } else
        {
            DialogueSystem.SetGlobalVariable<bool>("hasEnoughParts", false);
        }
    }

    bool CheckPartCount(int parts, int cost)
    {
        if (parts >= cost)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void CompletePurchase (Upgrade upgrade)
    {
        keeper.UpdatePartsCount(-currentUpgrade.cost);
        keeper.UpdateHP(currentUpgrade.HPModifier);
        keeper.UpdateMaxHP(currentUpgrade.HPMaxModifier);
        keeper.UpdatePower(currentUpgrade.powerModifier);
        keeper.UpdateSpeed(currentUpgrade.speedModifier);
    }
}
