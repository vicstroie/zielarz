using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ButcherBehavior : MonoBehaviour
{

    [SerializeField] GameObject craftingCam;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject butcherRabbit;
    [SerializeField] GameObject hand;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingCamera)
        {
            /*
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, craftingCamPos.position, 0.5f);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, craftingCamPos.rotation, 0.5f);
            if (playerCamera.transform.position == craftingCamPos.position) {
                isMovingCamera = false;
                backButton.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                butcherRabbit.SetActive(true);
            }  */

            craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
            isMovingCamera = false;
            backButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            butcherRabbit.SetActive(true);
        }
       

        if (isMovingCameraBack)
        {
            /*
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, originalPlayerCameraPosition, 0.5f);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, originalPlayerCameraRotation, 0.5f);
            if (playerCamera.transform.position == originalPlayerCameraPosition)
            {
                isMovingCameraBack = false;
                Cursor.lockState = CursorLockMode.Locked;
                backButton.SetActive(false);
                 playerObject.GetComponent<FirstPersonController>().enabled = true;
                hand.SetActive(true);
            }
            */

            craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            isMovingCameraBack = false;
            Cursor.lockState = CursorLockMode.Locked;
            backButton.SetActive(false);
            playerObject.GetComponent<FirstPersonController>().enabled = true;
            hand.SetActive(true);
        }
    }

    public void StartChop(GameObject passedCamera, GameObject player)
    {
        /*
        isMovingCamera = true;
        playerCamera = passedCamera;
        originalPlayerCameraPosition = passedCamera.transform.position;
        originalPlayerCameraRotation = passedCamera.transform.rotation;
        */
        player.GetComponent<FirstPersonController>().enabled = false;
        playerObject = player;
        hand.SetActive(false);

        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
        isMovingCamera = false;
        backButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        butcherRabbit.SetActive(true);

    }

    public void EndChop()
    {
        //isMovingCameraBack = true;

        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        Cursor.lockState = CursorLockMode.Locked;
        backButton.SetActive(false);
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        hand.SetActive(true);
    }



}
