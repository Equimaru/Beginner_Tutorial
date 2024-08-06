using UnityEngine;

public class PauseSystem
{
    public bool isPaused;
    
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
