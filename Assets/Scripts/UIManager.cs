using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject fullBasketWarning;


    //private variables
    GameObject eraseableElement;


    // Start is called before the first frame update
    void Start()
    {
        fullBasketWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
