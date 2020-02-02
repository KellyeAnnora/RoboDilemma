using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Statkeeper : MonoBehaviour
{
    public int maxHP = 25;

    public int HP = 20;
    public int power = 10;
    public int speed = 20;
    public int parts = 0;

    ResetSystem reset;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        reset = GetComponent<ResetSystem>();
    }

    public void Update()
    {
        if (HP <= 0)
        {
            reset.DeathScreen();
        }
    }

    public void UpdateHP(int newHP)
    {
        if (newHP != 0)
        {
            newHP = maxHP - HP;
        }
        HP += newHP;
        Debug.Log("Player HP is now " + HP + " out of " + maxHP);
    }

    public void UpdateMaxHP(int newMaxHP)
    {
        maxHP += newMaxHP;
        Debug.Log("Player max HP is now " + maxHP + " and HP is " + HP);
    }

    public void UpdatePower(int newPower)
    {
        power += newPower;
        Debug.Log("Player power is now " + power);
    }

    public void UpdateSpeed(int newSpeed)
    {
        speed += newSpeed;
        agent.speed = speed;
        Debug.Log("Player speed is now " + speed);
    }

    public void UpdatePartsCount(int newParts)
    {
        parts += newParts;
        Debug.Log("Player part count is now " + parts);
    }

    public void TakeDamage(int enemyPower)
    {
        HP = HP - enemyPower;
        Debug.Log("Player HP decreased by " + enemyPower);
    }

}
