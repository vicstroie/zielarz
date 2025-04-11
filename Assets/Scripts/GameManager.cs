using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject flowchart;

    public bool isTalking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTalking = flowchart.GetComponent<Flowchart>().GetBooleanVariable("isTalking");
    }
}
