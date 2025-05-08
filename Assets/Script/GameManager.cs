using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   void awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void GoToMainMenu()
     {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
     }

     public void StartGame()
     {
        SceneManager.LoadScene("GameScene");
     }

     public void QuitGame()
     {
        Application.Quit();
        Debug.Log("Game Quit!");
     }

     void destroy()
     {
      FindFirstObjectByType<GameManager>().GameOver();
     }
}
