using UnityEngine;

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

    
}

