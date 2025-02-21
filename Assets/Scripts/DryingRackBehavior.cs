using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryingRackBehavior : MonoBehaviour
{
    //Contents of the Inventory
    public List<GameObject> contents;

    [Header("Changeable Variables")]
    [SerializeField] int maxCapacity;

    // Start is called before the first frame update
    void Start()
    {
        contents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InventoryIsFull()
    {
        return contents.Count >= maxCapacity;
    }

    public void AddToInventory(GameObject item)
    {
        contents.Add(item);
        item.GetComponent<BillboardEffect>().enabled = false;
        item.GetComponent<PlantBehavior>().isPickable = false;
        item.transform.position = new Vector3(this.transform.position.x + 0.67f, this.transform.position.y - 0.91f, (this.transform.position.z + 2f) - contents.IndexOf(item));
        item.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        item.transform.eulerAngles = new Vector3(0, 90, 180);
        item.GetComponent<SpriteRenderer>().enabled = true;
        item.GetComponent<BoxCollider>().enabled = true;
    }
}
