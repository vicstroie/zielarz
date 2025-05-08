using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Fungus;
using StarterAssets;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject flowchart;
    [SerializeField] GameObject player;
    [SerializeField] GameObject grandma;
    [SerializeField] Transform grandmaEndTransform;
    [SerializeField] GameObject blink;

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
        /*
        if (!movedGrandma && flowchart.GetComponent<Flowchart>().GetBooleanVariable("doneTutorial")) {
            grandma.GetComponent<MoveGrandma>().isWalking = true;
            movedGrandma = true;
            grandma.GetComponent<VillagerInfo>().enabled = false;
        }
        */

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
            player.GetComponent<FirstPersonController>().enabled = false;
            blink.GetComponent<Image>().color = Color.Lerp(blink.GetComponent<Image>().color, new Color(0, 0, 0, 1), 5 * Time.deltaTime);
            if (blink.GetComponent<Image>().color == new Color(0, 0, 0, 1))
            {
                movedGrandma = true;
                grandma.transform.position = grandmaEndTransform.position;
                grandma.transform.rotation = grandmaEndTransform.rotation;
                player.GetComponent<FirstPersonController>().enabled = true;
            }
        }

        if(movedGrandma && blink.GetComponent<Image>().color != new Color(0, 0, 0, 0))
        {
            blink.GetComponent<Image>().color = Color.Lerp(blink.GetComponent<Image>().color, new Color(0, 0, 0, 0), 5 * Time.deltaTime);
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
