using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runemark.DialogueSystem
{
    public class DialogueInterface : MonoBehaviour
    {
        DialogueBehaviour dialogue;
        Transform player;
        DialogueFlow flow;

        Shopkeeper shopkeeper;
        public int upgradeIndex;

        private void Start()
        {
            dialogue = GetComponent<DialogueBehaviour>();
            flow = dialogue.Conversation;

            player = GameObject.FindWithTag("Player").transform;
            shopkeeper = GetComponent<Shopkeeper>();
        }

        public void DialogueOnInteraction()
        {
            Debug.Log("Starting dialogue with " + gameObject.name);
            dialogue.StartDialogue(player);
        }

        public void DialogueClose()
        {
            Debug.Log("Ending dialogue with " + gameObject.name);
            dialogue.StopDialogue(flow);
        }

        //functions to called from Dialogue System to set an integer
        public void Index0()
        {
            upgradeIndex = 0;
            Debug.Log("Shopping index returned " + upgradeIndex);
            ReceiveUpgradeIndex(upgradeIndex);
        }

        public void Index1()
        {
            upgradeIndex = 1;
            Debug.Log("Shopping index returned " + upgradeIndex);
            ReceiveUpgradeIndex(upgradeIndex);
        }

        public void Index2()
        {
            upgradeIndex = 2;
            Debug.Log("Shopping index returned " + upgradeIndex);
            ReceiveUpgradeIndex(upgradeIndex);
        }

        public void Index3()
        {
            upgradeIndex = 3;
            Debug.Log("Shopping index returned " + upgradeIndex);
            ReceiveUpgradeIndex(upgradeIndex);
        }

        public void Index4()
        {
            upgradeIndex = 4;
            Debug.Log("Shopping index returned " + upgradeIndex);
            ReceiveUpgradeIndex(upgradeIndex);
        }

        //function called once integer is set
        public void ReceiveUpgradeIndex(int index)
        {
            shopkeeper.AttemptPurchase(index);
            upgradeIndex = 0;
        }

        public void IdentifyBot(int botNumber)
        {
            DialogueSystem.SetGlobalVariable<int>("botIdentity", botNumber);
        }

        //function called by EncounterSystem once encounter is calculated
        public void DeclareTheWinner(bool wins)
        {
            DialogueSystem.SetGlobalVariable<bool>("playerWins", wins);
        }
    }
}


