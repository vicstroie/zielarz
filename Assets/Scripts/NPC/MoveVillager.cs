using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveVillager : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform startDestination;
    [SerializeField] Transform midDestinationOne;
    [SerializeField] Transform midDestinationTwo;
    [SerializeField] Transform endDestination;

    Vector3 lastPostion;
    bool isMovingToEnd;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = midDestinationOne.position;
        lastPostion = startDestination.position;
        isMovingToEnd = true;
       // agent.speed *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 0.5f) {

            if (isMovingToEnd) {
                if (lastPostion == startDestination.position)
                {
                    agent.destination = midDestinationTwo.position;
                    lastPostion = midDestinationOne.position;
                }
                else if (lastPostion == midDestinationOne.position)
                {
                    agent.destination = endDestination.position;
                    lastPostion = midDestinationTwo.position;
                }
                else if (lastPostion == midDestinationTwo.position)
                {
                    agent.destination = midDestinationTwo.position;
                    lastPostion = endDestination.position;
                    isMovingToEnd = false;
                }
            } else
            {
                if (lastPostion == endDestination.position) {
                    agent.destination = midDestinationOne.position;
                    lastPostion = midDestinationTwo.position;
                } else if(lastPostion == midDestinationTwo.position)
                {
                    agent.destination = startDestination.position;
                    lastPostion = midDestinationOne.position;
                } else if(lastPostion == midDestinationOne.position)
                {
                    agent.destination = midDestinationOne.position;
                    lastPostion = startDestination.position;
                    isMovingToEnd = true;
                }
            }
            

            
        }

        //

        //if (this.transform.position == endDestination.position) agent.destination = startDestination.position;
    }
}
