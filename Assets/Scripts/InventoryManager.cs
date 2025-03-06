using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Contents of the Inventory
    public GameObject[] inventory;

    [Header("Changeable Variables")]
    [SerializeField] int maxCapacity;

    int lastAddedIndex;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new GameObject[maxCapacity];
        maxCapacity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InventoryIsFull()
    {
        int filledCount = 0;

        for(int i = 0; i < maxCapacity; i++)
        {
            if (inventory[i] != null) filledCount++;
        }

        return filledCount == maxCapacity;
    }

    public bool InventoryIsEmpty()
    {
        int nullCount = 0;

        for (int i = 0; i < maxCapacity; i++)
        {
            if (inventory[i] != null) nullCount++;
        }

        return nullCount == 0;
    }

    public void AddToInventory(GameObject item)
    {
        int emptyPosition = 0;

        for (int j = 0; j < maxCapacity; j++)
        {;
            if (inventory[j] == null)
            {
                emptyPosition = j;
                break;
            }
            
        }

        inventory[emptyPosition] = item;
        //lastAddedIndex++;
        item.transform.position = this.transform.position;
        item.GetComponent<SpriteRenderer>().enabled = false;
        item.GetComponent<BoxCollider>().enabled = false;

        Debug.Log("Added");
    }

    public bool DoesHaveFlowers()
    {
        bool hasFlowers = false;

        for (int i = 0; i < maxCapacity; i++)
        {
            if (inventory[i] != null && inventory[i].CompareTag("Plant")) {
                hasFlowers = true;
                break;
            }  
        }

        return hasFlowers;
    }

    public GameObject GetLastFlower()
    {
        List<GameObject> flowers = new List<GameObject>();
        List<int> flowerIndexes = new List<int>();

        for (int i = 0; i < maxCapacity; i++)
        {
            if (inventory[i] != null && inventory[i].CompareTag("Plant")) {
                flowers.Add(inventory[i]);
                flowerIndexes.Add(i);
            } 

        }

        GameObject flowerReturn = flowers[flowers.Count - 1];
        inventory[flowerIndexes[flowerIndexes.Count - 1]] = null;

        return flowerReturn;

    }


    
    public void RemoveFromInventory()
    {
        if(!InventoryIsEmpty())
        {
            inventory[lastAddedIndex - 1] = null;
        }
    }

    public GameObject[] GetInventoryValues()
    {
        return inventory;
    }
}
