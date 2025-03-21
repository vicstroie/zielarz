using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehavior : MonoBehaviour
{


    //private
    bool isHeld;
    GameObject mouseTracker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld && mouseTracker.transform.position.x > -102 && mouseTracker.transform.position.x < -98
            && mouseTracker.transform.position.z > -55 && mouseTracker.transform.position.z < -51)
        {
            this.transform.position = new Vector3(mouseTracker.transform.position.x, this.transform.position.y, mouseTracker.transform.position.z);
        }
    }

    public void StartHold(GameObject mouseObject)
    {
        isHeld = true;
        mouseTracker = mouseObject;
    }

    public void StopHold()
    {
        isHeld = false;
    }
}
