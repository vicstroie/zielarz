using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    private Camera mainCamera;
    public bool staticBillboard;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (staticBillboard)
        {
            transform.LookAt(mainCamera.transform);
        }
        else
        {
            transform.rotation = mainCamera.transform.rotation;
        }
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //transform.rotation.eulerAngles.x
    }
}
