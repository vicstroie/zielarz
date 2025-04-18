using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation : MonoBehaviour
{

    RectTransform rectTransform;
    [SerializeField] float rotationAmount;

    // Start is called before the first frame update
    void Start()
    {
       rectTransform = this.GetComponent<RectTransform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Rotate(0, 0, rotationAmount);
    }
}
