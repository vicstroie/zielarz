using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CraftingBehavior : MonoBehaviour
{

    [SerializeField] Transform craftingCamPos;

    bool isMovingCamera;
    GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingCamera)
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, craftingCamPos.position, 0.5f);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, craftingCamPos.rotation, 0.5f);
            if(playerCamera.transform.position == craftingCamPos.position) isMovingCamera = false;
        }
    }

    public void StartCraft(GameObject passedCamera, GameObject player)
    {
        isMovingCamera = true;
        playerCamera = passedCamera;
        player.GetComponent<FirstPersonController>().enabled = false;
    }
}
