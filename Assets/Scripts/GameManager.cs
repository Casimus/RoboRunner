using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float worldScrollingSpeed = 1.0f;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogError("Instancja ju¿ istnieje");
            Destroy(gameObject);
        }
    }

    public float GetWorldSpeed() => worldScrollingSpeed;

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        UpdateScreenScore();
    }

    private void UpdateScreenScore()
    {
        scoreText.text = score.ToString("0");
    }


}
