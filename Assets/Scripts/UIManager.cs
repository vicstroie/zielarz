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
    [SerializeField] List<GameObject> inventory;

    [Header("Sprites")]
    [SerializeField] Sprite idle;
    [SerializeField] Sprite grabbing;

    //private variables
    GameObject eraseableElement;
    bool menuIsActive;
    private GameObject[] inventoryValues;


    // Start is called before the first frame update
    void Start()
    {
        fullBasketWarning.SetActive(false);
        menuIsActive = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            menuIsActive = !menuIsActive;
            if (menuIsActive) menu.SetActive(false); else {
                menu.SetActive(true);

                inventoryValues = this.GetComponent<InventoryManager>().GetInventoryValues();


                for (int i = 0; i < inventoryValues.Length; i++)
                {
                    if (inventoryValues[i] != null)
                    {
                        inventory[i].GetComponent<RawImage>().texture = inventoryValues[i].GetComponent<SpriteRenderer>().sprite.texture;
                        inventory[i].GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                    }
                    else {
                        inventory[i].GetComponent<RawImage>().texture = null;
                        inventory[i].GetComponent<RawImage>().color = new Color(0.22f, 0.22f, 0.22f, 0.55f);
                    } 
                }
            }
            
        }
    }

    public void WarnFullBasket()
    {
        fullBasketWarning.SetActive(true);
        eraseableElement = fullBasketWarning;
        Invoke("EraseElement", 0.75f);
        
    }

    public void EraseElement()
    {
        eraseableElement.SetActive(false);
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
}
