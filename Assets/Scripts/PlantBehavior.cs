using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    public bool isPickable;

    //private
    int selfIndex;
    GameObject dryingRackObject;

    // Start is called before the first frame update
    void Start()
    {
        isPickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutOnRack(GameObject dryingRack, int index)
    {
        isPickable = false;
        dryingRackObject = dryingRack;
        selfIndex = index;
        StartCoroutine(DrySelf());
    }

    IEnumerator DrySelf()
    {
        yield return new WaitForSeconds(10);

        dryingRackObject.GetComponent<DryingRackBehavior>().SendFlowerToTable(selfIndex);
    }
}
