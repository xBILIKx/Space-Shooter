using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject panel;
    public Text tScore;
    public Text tHightScore;
    public int score;
    int hightScore;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        hightScore = PlayerPrefs.GetInt("HightScore");
        Time.timeScale = 1;
    }

    void Update()
    {
        if (score > hightScore)
            HightScore();
        tScore.text = "SCORE: " + score;
        tHightScore.text = "HIGHT SCORE: " + hightScore;
    }
    void HightScore()
    {
        hightScore = score;
        PlayerPrefs.SetInt("HightScore", hightScore);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        if (!panel.activeSelf)
        {
            FindObjectOfType<PlayerController>().enabled = false;
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
            FindObjectOfType<PlayerController>().enabled = true;
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Shop()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
