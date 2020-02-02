using UnityEngine;

[CreateAssetMenu(fileName = "New Bot", menuName = "Bots")]
public class Bot : ScriptableObject
{
    //identifiers to keep track of bots
    new public string name = "Bot Name";
    new public string description = "Description";
    new public int botIdentifier = 0;
    new public string botClass = "Bot Class";

    //keep track of bot power
    public int botPowerLevel;
    public int botPower;
}
