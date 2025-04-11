using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveVillager : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform villagerDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = villagerDestination.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
