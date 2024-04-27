using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsInGame { get; private set; }

    [SerializeField] Button resetButon;
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

    private void Start()
    {
        IsInGame = true;
        resetButon.gameObject.SetActive(false);

        
    }

   

    public float GetWorldSpeed() => worldScrollingSpeed;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsInGame) return;
        score += worldScrollingSpeed;
        UpdateScreenScore();
    }

    private void UpdateScreenScore()
    {
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        IsInGame = false;
        resetButon.gameObject.SetActive(true);
        
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(0);
    }


}
