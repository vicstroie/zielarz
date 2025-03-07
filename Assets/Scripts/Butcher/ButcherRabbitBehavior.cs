using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ButcherRabbitBehavior : MonoBehaviour
{
    [SerializeField] Transform legTransform;
    [SerializeField] Sprite cutLeg;
    [SerializeField] GameObject bloodParticles1;
    [SerializeField] GameObject bloodParticles2;
    [SerializeField] GameObject bloodParticles3;

    Camera cam;
    Vector3 screenPosition;
    Vector3 worldPosition;
    Vector3 legPosition;

    int cutCount;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cutCount = 0;
        legPosition = legTransform.position;
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
            && Input.GetMouseButtonDown(0) && cutCount < 3)
        {
            switch(cutCount)
            {
                case 0:
                    bloodParticles1.SetActive(true);
                    break;
                case 1:
                    bloodParticles2.SetActive(true);
                    break;
                case 2:
                    bloodParticles3.SetActive(true);
                    this.GetComponent<SpriteRenderer>().sprite = cutLeg;
                    break;
                default:
                    break;
            }

            cutCount++;
            
        }

        //Vector3 mousePos = worldPosition;
        //Debug.Log("X:" + mousePos.x + "Y:" + mousePos.y + "Z:" + mousePos.z);

    }
}
