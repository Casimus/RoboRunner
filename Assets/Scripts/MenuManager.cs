
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public const string HIGH_SCORE_KEY = "HighScore";
    public const string COINS = "Coins";

    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI soundText;

    private int highScore = 0;
    private int coins = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        }
        if (PlayerPrefs.HasKey(COINS))
        {
            coins = PlayerPrefs.GetInt(COINS);
        } 
         
        UpdateUI();
    }

    public void UpdateUI()
    {
        highScoreText.text = highScore.ToString();
        coinsText.text = coins.ToString();

        if (SoundManager.Instance.GetIsMuted()) 
        {
            soundText.text = "Sound off";
        }
        else
        {
            soundText.text = "Sound on";
        }
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void MusicPressed()
    {
        SoundManager.Instance.ToggleMuted();
        UpdateUI();
    }


}
