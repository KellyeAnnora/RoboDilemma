using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runemark.DialogueSystem;

[RequireComponent(typeof(DialogueInterface))]
public class EncounterSystem : MonoBehaviour
{
    public Bot assignedBot;

    Statkeeper playerStats;
    DialogueInterface dialogue;

    public bool playerWins;

    public int playerEdgeAdjustment;

    int botPower;
    int playerPower;

    private void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<Statkeeper>();
        dialogue = GetComponent<DialogueInterface>();
    }

    public void WhatBotAmI()
    {
        int botNumber = assignedBot.botIdentifier;
        dialogue.IdentifyBot(botNumber);
    }

    //run this function from the dialogue when encounter starts
    public void Encounter ()
    {
        botPower = assignedBot.botPower;
        playerPower = playerStats.power;

        int playerEdge = playerPower - playerEdgeAdjustment;

        int playerRoll = Random.Range(playerEdge, playerPower);

        if (botPower <= playerRoll)
        {
            playerWins = true;
            dialogue.DeclareTheWinner(playerWins);
            Debug.Log("Player wins.");
        } else
        {
            playerWins = false;
            dialogue.DeclareTheWinner(playerWins);
            DoDamage();
            Debug.Log("Player loses.");
        }

        void DoDamage()
        {
            playerStats.TakeDamage(botPower);
        }
    }
}
