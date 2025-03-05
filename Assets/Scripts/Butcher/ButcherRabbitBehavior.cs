using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ButcherRabbitBehavior : MonoBehaviour
{


    [SerializeField] Sprite cutLeg;
    [SerializeField] GameObject bloodParticles;

    Camera cam;
    Vector3 screenPosition;
    Vector3 worldPosition;

    Vector3 legPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        legPosition = new Vector3(-82.7f, 20.4f, -25.3f);
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitData))
        {
            worldPosition = hitData.point;
        }

        if(worldPosition.x < legPosition.x + 0.5f && worldPosition.x > legPosition.x - 0.5f
            && worldPosition.y < legPosition.y + 0.5f && worldPosition.y > legPosition.y - 0.5f
            && Input.GetMouseButtonDown(0))
        {
            this.GetComponent<SpriteRenderer>().sprite = cutLeg;
            bloodParticles.SetActive(true);
        }

        //Vector3 mousePos = worldPosition;
        //Debug.Log("X:" + mousePos.x + "Y:" + mousePos.y + "Z:" + mousePos.z);

    }
}
