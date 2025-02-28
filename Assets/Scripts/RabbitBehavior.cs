using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour
{
    //public
    [SerializeField] float walkForce;

    //private variables
    GameObject player;
    Vector3 playerToRabbit;
    Rigidbody rb;
    bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerToRabbit = this.transform.position - player.transform.position;
        if (playerToRabbit.magnitude < 20) isRunning = true; else isRunning = false;
        playerToRabbit = new Vector3(playerToRabbit.x, 0, playerToRabbit.z);
        playerToRabbit = Vector3.Normalize(playerToRabbit);
    }

    private void FixedUpdate()
    {
        if(isRunning) rb.AddForce(playerToRabbit * walkForce);
    }
}
