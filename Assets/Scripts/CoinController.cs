using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        if (GameManager.Instance == null && !GameManager.Instance.GetMagnet().isActive)
            return;

        // sprawdzamy odlegloœæ pomiêdzy graczem a monet¹

        if ( Vector3.Distance(transform.position, player.position)
            < GameManager.Instance.GetMagnet().GetRange())
        {
            var direction = (player.position - transform.position).normalized;
            transform.position += direction * GameManager.Instance.GetMagnet().GetSpeed();
        }

    }
}
