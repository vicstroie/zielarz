using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionBehavior : MonoBehaviour
{

    private Transform _selection;
    private bool isLooking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            _selection = null;
        }
        else
        {
            //While not selected
            isLooking = false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 5);
        if (Physics.Raycast(ray, out hit, 5))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Selectable") || selection.CompareTag("Plant") || selection.CompareTag("DryingRack"))
            {
                isLooking = true;
                _selection = selection;
                Debug.Log("looking!");
            }

        }


        if (isLooking)
        {
            if (Input.GetMouseButtonDown(0) && _selection != null)
            {
                //ADD OTHER SELECTABLES HERE
                if (_selection.CompareTag("Selectable")) {

                } else if(_selection.CompareTag("Plant")) //IF SELECTED IS PLANT
                {
                    //CHECKS IF INVENTORY IS FULL
                    if(!this.GetComponent<InventoryManager>().InventoryIsFull())
                    {
                        if(_selection.GetComponent<PlantBehavior>().isPickable)
                        {
                            this.GetComponent<InventoryManager>().AddToInventory(_selection.gameObject);
                            SoundSystem.instance.PlaySound("pickUp");
                            _selection = null;
                        }
                    } else 
                    {
                        //Warn Player that Basket is Full
                        this.GetComponent<UIManager>().WarnFullBasket();
                    }
                } else if(_selection.CompareTag("DryingRack"))
                {

                    if (!_selection.GetComponent<DryingRackBehavior>().InventoryIsFull()) Debug.Log("notfull!");
                    if (!this.GetComponent<InventoryManager>().InventoryIsEmpty()) Debug.Log("notempty!");



                    //Checks if DryingRack is full, and if inventory is empty
                    if(!_selection.GetComponent<DryingRackBehavior>().InventoryIsFull() && !this.GetComponent<InventoryManager>().InventoryIsEmpty())
                    {
                        Debug.Log("dryingRack!");
                        //Adds last addition to inventory to dryingrack
                        if(this.GetComponent<InventoryManager>().DoesLastObjectExist()) _selection.GetComponent<DryingRackBehavior>().AddToInventory(this.GetComponent<InventoryManager>().RetrieveLastObject());
                    }
                }
                
                //Destroy(_selection.gameObject);
            }

        }

    }
}
