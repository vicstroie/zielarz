using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject player;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.SetActive(true);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        player.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
