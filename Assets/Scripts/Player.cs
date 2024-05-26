using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && !GameManager.Instance.IsImmortal())
        {
            Debug.LogWarning("Auæ");
            PlayerDeath();
        }
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Magnet"))
        {
            GameManager.Instance.MagnetCollected();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Immortal"))
        {
            GameManager.Instance.ImmortalityCollected();
            Destroy(collision.gameObject);
        }

    }

    private void PlayerDeath()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        GameManager.Instance.GameOver();
    }
}
