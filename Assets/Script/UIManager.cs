using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image companionHPBar;

    public TextMeshProUGUI killCountText;
    private int killCount = 0;

    public TextMeshProUGUI coinCountText;
    private int totalCoins = 0;

    void start()
    {
        GameOverScreen.SetActive(false);

        UpdateCoinUI();
        UpdateKillCount();
    }
    
    public GameObject GameOverScreen;

    void awake()
    {
        Instance = this;
    }


    public void UpdateCompanionHP(float currentHealth, float maxHealth)
    {
        if (companionHPBar != null)
        {
            companionHPBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void KillCount()
    {
        killCount++;
        UpdateKillCount();
    }

    private void UpdateKillCount()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + totalCoins;
        }
    }

    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
