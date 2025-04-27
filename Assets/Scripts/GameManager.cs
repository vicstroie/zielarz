using System.Collections;
using System.Collections.Generic;
using Fungus;
using StarterAssets;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject flowchart;
    [SerializeField] GameObject player;
    [SerializeField] GameObject grandma;
    [SerializeField] Transform grandmaEndTransform;

    public bool isTalking;
    bool movedGrandma;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTalking = flowchart.GetComponent<Flowchart>().GetBooleanVariable("isTalking");

        if (isTalking)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
        }
        else
        {
            if (!player.GetComponent<FirstPersonController>().isActiveAndEnabled) player.GetComponent<FirstPersonController>().enabled = true;
        }

        if (!movedGrandma && flowchart.GetComponent<Flowchart>().GetBooleanVariable("doneTutorial"))
        {
            grandma.transform.position = grandmaEndTransform.position;
            grandma.transform.rotation = grandmaEndTransform.rotation;
        }
    }
}
