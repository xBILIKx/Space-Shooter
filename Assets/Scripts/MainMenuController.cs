using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject deleteAllPanel;
    public Text tHightScore;
    public Text tcoins;
    int coins;
    int hightScore;
    void Start()
    {
        //PlayerPrefs.SetInt("Coins", 99999);
        coins = PlayerPrefs.GetInt("Coins");
        hightScore = PlayerPrefs.GetInt("HightScore");
        tHightScore.text = "HIGHT SCORE: " + hightScore;
        tcoins.text = "Coins: " + coins;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void DeletetAllPanel()
    {
        deleteAllPanel.SetActive(!deleteAllPanel.activeSelf);
    }

    public void Shop()
    {
        SceneManager.LoadScene(2);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        hightScore = 0;
        coins = 0;
        tHightScore.text = "HIGHT SCORE: " + hightScore;
        tcoins.text = "Coins: " + coins;
        deleteAllPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
