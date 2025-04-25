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

    bool isChopping;
    GameObject playerCamera;
    GameObject playerObject;
    Animator chopAnim;

    Vector3 originalPlayerCameraPosition;
    Quaternion originalPlayerCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        butcherRabbit.SetActive(false);
        mouseTracker.SetActive(false);
        backButton.SetActive(false);
        /*
        chopAnim = knifeHand.GetComponent<Animator>();
        chopAnim.SetBool("isChopping", false);
        chopAnim.SetBool("knifeIsOver", false);
        */
        isChopping = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!isChopping)
        {
            if (butcherRabbit.GetComponent<ButcherRabbitBehavior>().knifeIsOver)
            {
                //chopAnim.SetBool("isKnifeOver", true);
                knifeHand.GetComponent<SpriteRenderer>().sprite = knifeReady;
            }
            else {
                //chopAnim.SetBool("isKnifeOver", false);
                knifeHand.GetComponent<SpriteRenderer>().sprite = knifeIdle;
            } 
        }

    }

    public void StartChop(GameObject passedCamera, GameObject player, bool canStart)
    {
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<SelectionBehavior>().enabled = false;
        playerObject = player;
        
        Cursor.lockState = CursorLockMode.None; 

        hand.SetActive(false);
        mouseTracker.SetActive(true);
        backButton.SetActive(true);


        if (canStart) {
            butcherRabbit.SetActive(true);
            butcherRabbit.GetComponent<ButcherRabbitBehavior>().butcherBehavior = this.gameObject;
        } 

    }

    public void EndChop()
    {
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        playerObject.GetComponent<SelectionBehavior>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        

        hand.SetActive(true);
        mouseTracker.SetActive(false);
        backButton.SetActive(false);
    }

    public void ChopAnimation()
    {
        isChopping = true;
        //chopAnim.SetBool("isChopping", true);
        Invoke("EndChopAnimation", 0.15f);
    }

    void EndChopAnimation()
    {
        isChopping = false;
        //chopAnim.SetBool("isChopping", false);
    }

    public void EndChopObtained()
    {
        mouseTracker.SetActive(false);
        backButton.SetActive(false);
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }

}
