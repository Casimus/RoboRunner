using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.LogWarning("Auæ");
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        GameManager.Instance.GameOver();
    }
}
