using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Contents of the Inventory
    public List<GameObject> inventory;

    [Header("Changeable Variables")]
    [SerializeField] int maxCapacity;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InventoryIsFull()
    {
        return inventory.Count >= maxCapacity;
    }

    public bool InventoryIsEmpty()
    {
        return inventory.Count == 0;
    }

    public void AddToInventory(GameObject item)
    {
        inventory.Add(item);
        item.transform.position = this.transform.position;
        item.GetComponent<SpriteRenderer>().enabled = false;
        item.GetComponent<BoxCollider>().enabled = false;

        Debug.Log("Added");
    }

    public GameObject RetrieveLastObject()
    {
        if (!InventoryIsEmpty()) {
            GameObject lastObject = inventory[inventory.Count - 1];
            inventory.Remove(inventory[inventory.Count - 1]);
            return lastObject;
        } else
        {
            return null;
        }
    }

    public bool DoesLastObjectExist()
    {

        GameObject lastObject;

        if(!InventoryIsEmpty())
        {
            lastObject = inventory[inventory.Count - 1];
        } else
        {
            lastObject = null;
        }

        return lastObject != null;
    }
    public void RemoveFromInventory()
    {
        if(!InventoryIsEmpty()) inventory.Remove(inventory[inventory.Count - 1]);
    }
}
