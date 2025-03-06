using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryingRackBehavior : MonoBehaviour
{
    //Contents of the Inventory
    public GameObject[] contents;

    [Header("Changeable Variables")]
    [SerializeField] int maxCapacity;

    // Start is called before the first frame update
    void Start()
    {
        contents = new GameObject[maxCapacity];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InventoryIsFull()
    {
        int filledCount = 0;

        for (int i = 0; i < maxCapacity; i++)
        {
            if (contents[i] != null) filledCount++;
        }

        return filledCount == maxCapacity;
    }

    public void AddToInventory(GameObject item)
    {
        int emptyPosition = 0;

        for (int i = 0; i < maxCapacity; i++)
        {
            if (contents[i] == null) {
                emptyPosition = i;
                break;
            } 
        }

        contents[emptyPosition] = item;
        item.GetComponent<BillboardEffect>().enabled = false;
        item.GetComponent<PlantBehavior>().isPickable = false;
        item.transform.position = new Vector3(this.transform.position.x + 0.67f, this.transform.position.y - 0.91f, (this.transform.position.z + 2f) - emptyPosition);
        item.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        item.transform.eulerAngles = new Vector3(0, 90, 180);
        item.GetComponent<SpriteRenderer>().enabled = true;
        item.GetComponent<BoxCollider>().enabled = true;
    }
}
