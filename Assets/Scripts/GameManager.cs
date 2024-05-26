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
    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private Magnet magnet;
    [SerializeField] private Immortality immortality;

    private int coins = 0;
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
        coins = PlayerPrefs.GetInt(MenuManager.COINS);

        immortality.isActive = false;
        magnet.isActive = false;
    }

   public void AddCoin()
    {
        coins++;
        PlayerPrefs.SetInt(MenuManager.COINS, coins);
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
        coinsText.text = coins.ToString("0");
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

    public void MagnetCollected()
    {
        if (magnet.isActive)
        {
            CancelInvoke(nameof(CancelMagnet));
        }

        magnet.isActive = true;

        Invoke(nameof(CancelMagnet), magnet.GetDuration());
    }

    public void CancelMagnet()
    {
        magnet.isActive = false;
    }

    public void ImmortalityCollected()
    {
        if(immortality.isActive)
        {
            CancelInvoke(nameof(CancelImmortality));
        }

        immortality.isActive = true;
        worldScrollingSpeed += immortality.GetSpeedBoost();

        Invoke(nameof(CancelImmortality), immortality.GetDuration());
    }

    public void CancelImmortality()
    {
        immortality.isActive = false;
        worldScrollingSpeed -= immortality.GetSpeedBoost();
    }
    public bool IsImmortal() => immortality.isActive;

    public Magnet GetMagnet() => magnet;
}
