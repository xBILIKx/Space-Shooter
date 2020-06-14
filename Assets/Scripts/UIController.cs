using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject panel;
    public GameObject settingsPanel;
    public Text tScore;
    public Text tHightScore;
    public Text tcoins;
    int coins;
    int _score = 0;
    int hightScore;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        hightScore = PlayerPrefs.GetInt("HightScore");
        tScore.text = "SCORE: " + _score;
        tHightScore.text = "HIGHT SCORE: " + hightScore;
        tcoins.text = "Coins: " + coins;
        Time.timeScale = 1;
    }

    public void ChangeScore(int score)
    {
        _score += score;
        if (_score > hightScore)
            hightScore = _score;
        tScore.text = "SCORE: " + _score;
        tHightScore.text = "HIGHT SCORE: " + hightScore;
    }
    public void ChangeCoins()
    {
        coins += 1;
        tcoins.text = "Coins: " + coins;
    }
    public void Pause()
    {
        if (!panel.activeSelf && PlayerController.instance != null)
        {
            FindObjectOfType<PlayerController>().enabled = false;
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        else if(PlayerController.instance != null)
        {
            panel.SetActive(false);
            FindObjectOfType<PlayerController>().enabled = true;
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("HightScore", hightScore);
        PlayerPrefs.SetInt("Coins", coins);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("HightScore", hightScore);
        PlayerPrefs.SetInt("Coins", coins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Shop()
    {
        PlayerPrefs.SetInt("HightScore", hightScore);
        PlayerPrefs.SetInt("Coins", coins);
        SceneManager.LoadScene(2);
    }
    
    public void Settings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
