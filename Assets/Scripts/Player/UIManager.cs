using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] List<GameObject> inventory;
    [SerializeField] List<GameObject> inventoryBackground;
    [SerializeField] List<GameObject> leftHandItems;
    [SerializeField] List<GameObject> leftHandMagicSpots;
    [SerializeField] List<Sprite> leftHandSprites;
    [SerializeField] List<GameObject> redLines;

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
                    }
                    else {
                        inventory[i].GetComponent<RawImage>().texture = null;
                        inventory[i].GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
                        inventoryBackground[i].GetComponent<Image>().sprite = menuSpotEmpty;

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
