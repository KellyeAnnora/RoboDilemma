using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehavior : MonoBehaviour
{
    public float detectionRadius = 100f;

    Transform player;
    float distToPlayer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(player);
    }

    private void Update()
    {
        distToPlayer = Vector2.Distance(player.position, transform.position);

        if (distToPlayer < detectionRadius)
        {
            transform.LookAt(player);
        }
    }
}
