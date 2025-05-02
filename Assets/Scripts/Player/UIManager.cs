using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject fullBasketWarning;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject selectionMarker;

    [SerializeField] GameObject popUpObject;
    [SerializeField] GameObject popUpImage;
    [SerializeField] GameObject popUpName;
    [SerializeField] List<string> popUpNames;

    [SerializeField] List<GameObject> inventory;
    [SerializeField] List<GameObject> inventoryBackground;
    [SerializeField] List<GameObject> inventoryNames;
    [SerializeField] List<GameObject> inventoryText;
    [SerializeField] List<GameObject> leftHandItems;
    [SerializeField] List<GameObject> leftHandMagicSpots;
    [SerializeField] List<Sprite> leftHandSprites;
    [SerializeField] List<GameObject> redLines;

    [SerializeField] GameObject gameManager;

    [Header("Sprites")]
    [SerializeField] Sprite idle;
    [SerializeField] Sprite grabbing;
    [SerializeField] Sprite magicSpotDone;
    [SerializeField] Sprite magicSpotWaiting;
    [SerializeField] Sprite menuSpotEmpty;
    [SerializeField] Sprite menuSpotFilled;

    //private variables
    GameObject eraseableElement;
    bool menuIsActive;
    bool leftHandIsActive;
    bool isLookingAtSomething;
    private GameObject[] inventoryValues;
    int popUpTracker;


    // Start is called before the first frame update
    void Start()
    {
        fullBasketWarning.SetActive(false);
        menuIsActive = false;
        menu.SetActive(false);
        leftHandIsActive = false;
        leftHand.SetActive(false);


        for (int i = 0; i < redLines.Count; i++) {
            redLines[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !leftHandIsActive) {
            menuIsActive = !menuIsActive;
            if (!menuIsActive) {
                menu.SetActive(false);
                ActivateSelection();
            }  else {
                menu.SetActive(true);
                DeactivateSelection();

                inventoryValues = this.GetComponent<InventoryManager>().GetInventoryValues();


                for (int i = 0; i < inventoryValues.Length; i++)
                {
                    if (inventoryValues[i] != null)
                    {
                        inventory[i].GetComponent<RawImage>().texture = inventoryValues[i].GetComponent<ObjectInformation>().menuSprite.texture;
                        inventory[i].GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                        inventoryBackground[i].GetComponent<Image>().sprite = menuSpotFilled;
                        inventoryNames[i].GetComponent<TextMeshProUGUI>().text = inventoryValues[i].GetComponent<ObjectInformation>().menuName;
                        inventoryText[i].GetComponent<TextMeshProUGUI>().text = inventoryValues[i].GetComponent<ObjectInformation>().menuText;
                    }
                    else {
                        inventory[i].GetComponent<RawImage>().texture = null;
                        inventory[i].GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
                        inventoryBackground[i].GetComponent<Image>().sprite = menuSpotEmpty;
                        inventoryNames[i].GetComponent<TextMeshProUGUI>().text = "";
                        inventoryText[i].GetComponent<TextMeshProUGUI>().text = "";
                    } 
                }
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Q) && !menuIsActive)
        {
            leftHandIsActive = !leftHandIsActive;
            if (leftHandIsActive) {
                leftHand.SetActive(true);
                DeactivateSelection();
            } 
            else {
                    leftHand.SetActive(false);
                    ActivateSelection();
            }

            gameManager.GetComponent<GameManager>().leftHandIsActive = leftHandIsActive;

        }

        if(isLookingAtSomething )
        {
            selectionMarker.GetComponent<Image>().sprite = magicSpotDone;
        } else 
        {
            selectionMarker.GetComponent<Image>().sprite = magicSpotWaiting;
        }
    }

    public void WarnFullBasket()
    {
        fullBasketWarning.SetActive(true);
        eraseableElement = fullBasketWarning;
        Invoke("EraseElement", 0.75f);
        DeactivateSelection();
        
    }

    public void EraseElement()
    {
        eraseableElement.SetActive(false);
        ActivateSelection();
    }

    public void Grab()
    {
        hand.GetComponent<Image>().sprite = grabbing;
        Invoke("ReturnToIdleSprite", 0.5f);

    }

    public void ReturnToIdleSprite()
    {
        hand.GetComponent<Image>().sprite = idle;
    }

    public void ActivateHandElements(int handInt)
    {
        leftHandItems[handInt].GetComponent<Image>().sprite = leftHandSprites[handInt];
        leftHandItems[handInt].GetComponent<Image>().color = Color.white;
        leftHandMagicSpots[handInt].GetComponent<Image>().sprite = magicSpotDone;
        redLines[handInt].SetActive(true);
    } 

    public void ActivatePopUp(int handInt)
    {
        popUpImage.GetComponent<Image>().sprite = leftHandSprites[handInt];
        popUpName.GetComponent<TextMeshProUGUI>().text = popUpNames[handInt];
        popUpObject.SetActive(true);
        menuIsActive = true;

        popUpTracker++;
        if (popUpTracker == 3) gameManager.GetComponent<GameManager>().completedGame = true;

        SoundSystem.instance.PlaySound("popUp");

        DeactivateSelection();
    }

    public void DeactivatePopUp()
    {
        popUpObject.SetActive(false);
        menuIsActive = false;
        hand.SetActive(true);
        this.GetComponent<FirstPersonController>().enabled = true;
        this.GetComponent<SelectionBehavior>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        ActivateSelection();
    }

    public void ActivateSelection()
    {
        selectionMarker.SetActive(true);
    }

    public void DeactivateSelection()
    {
        selectionMarker.SetActive(false);
    }

    public void SetSelector(bool value)
    {
        isLookingAtSomething = value;
    }

}
