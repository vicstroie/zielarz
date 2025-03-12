using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ButcherBehavior : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject craftingCam;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject butcherRabbit;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject knifeHand;
    [SerializeField] GameObject mouseTracker;

    [Header("Sprites")]
    [SerializeField] Sprite knifeReady;
    [SerializeField] Sprite knifeIdle;

    bool isMovingCamera;
    bool isMovingCameraBack;
    GameObject playerCamera;
    GameObject playerObject;

    Vector3 originalPlayerCameraPosition;
    Quaternion originalPlayerCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        backButton.SetActive(false);
        butcherRabbit.SetActive(false);
        mouseTracker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (butcherRabbit.GetComponent<ButcherRabbitBehavior>().knifeIsOver) knifeHand.GetComponent<SpriteRenderer>().sprite = knifeReady; 
        else knifeHand.GetComponent<SpriteRenderer>().sprite = knifeIdle;

    }

    public void StartChop(GameObject passedCamera, GameObject player, bool canStart)
    {
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
        player.GetComponent<FirstPersonController>().enabled = false;
        playerObject = player;
        Cursor.lockState = CursorLockMode.None; 

        hand.SetActive(false);
        backButton.SetActive(true);
        mouseTracker.SetActive(true);
        

        if(canStart) butcherRabbit.SetActive(true);

    }

    public void EndChop()
    {
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        

        backButton.SetActive(false);
        hand.SetActive(true);
        mouseTracker.SetActive(false);
    }



}
