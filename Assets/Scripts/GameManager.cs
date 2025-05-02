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
    public bool completedGame;
    public bool leftHandIsActive;
    bool movedGrandma;
    bool gotRed;


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
        
        if(!gotRed && flowchart.GetComponent<Flowchart>().GetBooleanVariable("isSad"))
        {
            player.GetComponent<UIManager>().ActivateHandElements(2);
            player.GetComponent<UIManager>().ActivatePopUp(2);
            player.GetComponent<InventoryManager>().CheckForRabbit();

            Cursor.lockState = CursorLockMode.None;

            gotRed = true;
        }
    }

    public void HasRabbit()
    {
        flowchart.GetComponent<Flowchart>().SetBooleanVariable("hasRabbit", true);
        Debug.Log("hasRabbit");
    }

    public void HasBloodyRabbit()
    {
        flowchart.GetComponent<Flowchart>().SetBooleanVariable("killedRabbit", true);
    }
}
