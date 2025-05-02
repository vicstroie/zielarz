using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class HerbalBehavior : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] GameObject craftingCam;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject mortarPestle;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject grabHand;
    [SerializeField] GameObject mouseTracker;
    [SerializeField] GameObject basket;

    [Header("Sprites")]
    [SerializeField] Sprite openHand;
    [SerializeField] Sprite closedHand;

    public bool isHoldingFlower;

    //private
    GameObject playerObject;
    GameObject heldFlower;


    // Start is called before the first frame update
    void Start()
    {
        //mortarPestle.SetActive(false);
        mouseTracker.SetActive(false);
        backButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartCraft(GameObject player) {

        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<SelectionBehavior>().enabled = false;
        player.GetComponent<UIManager>().DeactivateSelection();

        playerObject = player;
        
        Cursor.lockState = CursorLockMode.None;

        if(player.GetComponent<InventoryManager>().DoesHaveFlowers())
        {
            basket.GetComponent<HerbalBasketBehavior>().AddToBasket(player.GetComponent<InventoryManager>().GetFlowers().Count);
        }


        hand.SetActive(false);
        mouseTracker.SetActive(true);
        backButton.SetActive(true);
    }

    public void StopCraft()
    {
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        playerObject.GetComponent<SelectionBehavior>().enabled = true;
        playerObject.GetComponent<UIManager>().ActivateSelection();

        Cursor.lockState = CursorLockMode.Locked;


        backButton.SetActive(false);
        hand.SetActive(true);
        mouseTracker.SetActive(false);
    }

    public void HoldFlower(GameObject flower)
    {
        isHoldingFlower = true;
        heldFlower = flower;

        grabHand.GetComponent<SpriteRenderer>().sprite = closedHand;
    }

    public GameObject ReleaseFlower()
    {
        isHoldingFlower = false;
        grabHand.GetComponent<SpriteRenderer>().sprite = openHand;

        heldFlower.GetComponent<FlowerBehavior>().StopHold();
        GameObject currentFlower = heldFlower;
        heldFlower = null;

        return currentFlower;
    }

    public bool CanHoldFlower()
    {
        return mortarPestle.GetComponent<MortarBehavior>().canAddFlower();
    }

    public void CompletedTea()
    {
        mouseTracker.SetActive(false);
        backButton.SetActive(false);
        craftingCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;

        playerObject.GetComponent<UIManager>().ActivateHandElements(1);
        playerObject.GetComponent<UIManager>().ActivatePopUp(1);
    }
}
