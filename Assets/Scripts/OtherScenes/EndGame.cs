using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] GameObject easyText;
    [SerializeField] GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        easyText.SetActive(false);
        restartButton.SetActive(false);

        Invoke("ActivateEasyText", 4);

        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateEasyText()
    {
        easyText.SetActive(true);
        Invoke("ActivateButton", 2f);
    }

    void ActivateButton()
    {
        restartButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
