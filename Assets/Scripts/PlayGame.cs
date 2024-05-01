using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject panel;
    public int botCount;

    public void play()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}

