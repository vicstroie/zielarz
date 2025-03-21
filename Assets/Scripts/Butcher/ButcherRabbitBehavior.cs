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

    //private
    Camera cam;
    GameObject player;
    Vector3 screenPosition;
    Vector3 worldPosition;
    Vector3 legPosition;
    int cutCount;

    //public
    public bool knifeIsOver;
    public GameObject butcherBehavior;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cutCount = 0;
        legPosition = legTransform.position;
        player = GameObject.FindGameObjectWithTag("Player");
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

        

        if(worldPosition.x < legPosition.x + 0.2f && worldPosition.x > legPosition.x - 0.2f
            && worldPosition.z < legPosition.z + 0.2f && worldPosition.z > legPosition.z - 0.2f)
        {
            knifeIsOver = true;

            if(Input.GetMouseButtonDown(0) && cutCount < 3)
            {
                //butcherBehavior.GetComponent<ButcherBehavior>().ChopAnimation();

                switch (cutCount)
                {
                    case 0:
                        bloodParticles1.SetActive(true);
                        SoundSystem.instance.PlaySound("stab1");
                        break;
                    case 1:
                        bloodParticles2.SetActive(true);
                        SoundSystem.instance.PlaySound("stab2");
                        break;
                    case 2:
                        bloodParticles3.SetActive(true);
                        this.GetComponent<SpriteRenderer>().sprite = cutLeg;
                        player.gameObject.GetComponent<UIManager>().ActivateHandElements(0);
                        SoundSystem.instance.PlaySound("stab3");
                        break;
                    default:
                        break;
                }

                cutCount++;
            }
            
        } else knifeIsOver = false;

        //Vector3 mousePos = worldPosition;
        //Debug.Log("X:" + mousePos.x + "Y:" + mousePos.y + "Z:" + mousePos.z);

    }
}
