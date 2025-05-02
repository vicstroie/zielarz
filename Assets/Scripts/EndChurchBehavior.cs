using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChurchBehavior : MonoBehaviour
{

    [SerializeField] GameObject gameManager;

    bool playerInside;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && gameManager.GetComponent<GameManager>().completedGame && gameManager.GetComponent<GameManager>().leftHandIsActive) {
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<UIManager>().enabled = false;

            SoundSystem.instance.PlaySound("popUp");
            Invoke("EndGame", 2);
            playerInside = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            playerInside = true;
            player = other.gameObject;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) playerInside = false;
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
