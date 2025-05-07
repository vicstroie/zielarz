using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveGrandma : MonoBehaviour
{
    [SerializeField] Transform midDestination;
    [SerializeField] Transform finalDestination;

    Animator anim;
    NavMeshAgent agent;
    public bool isWalking;
    bool reachedMid;
    bool atEnd;
    Transform currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentDestination = midDestination;
    }

    // Update is called once per frame
    void Update()
    {

        if (!reachedMid && this.transform.position == midDestination.position) {
            currentDestination = finalDestination;
            reachedMid = true;
        } 

        if (isWalking) {
            agent.destination = currentDestination.position;
            anim.SetBool("isWalking", true);

            if (this.transform.position == finalDestination.position) {
                isWalking = false;
                atEnd = true;
                this.GetComponent<VillagerInfo>().enabled = true;
                anim.SetBool("isWalking", false);
            }
        }

        if (!isWalking && atEnd) { 

        }



    }
}
