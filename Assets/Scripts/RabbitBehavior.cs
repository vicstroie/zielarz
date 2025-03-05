using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour
{
    //public
    [SerializeField] float walkForce;
    [SerializeField] Transform homeTransform;

    //private variables
    GameObject player;
    Vector3 playerToRabbit;
    Vector3 rabbitToHome;
    Rigidbody rb;
    bool isRunning;
    bool isHome;
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
        rabbitToHome = homeTransform.position - this.transform.position;

        if (rabbitToHome.magnitude < 20)
        {
            isHome = true;
        } else
        {
            isHome = false;
        }

        if (playerToRabbit.magnitude < 20) {
            isRunning = true;
            isHome = false;
        }  else isRunning = false;

        playerToRabbit = new Vector3(playerToRabbit.x, 0, playerToRabbit.z);
        playerToRabbit = Vector3.Normalize(playerToRabbit);

        rabbitToHome = new Vector3(rabbitToHome.x, 0, rabbitToHome.z);
        rabbitToHome = Vector3.Normalize(rabbitToHome);
    }

    private void FixedUpdate()
    {
        if(isRunning) rb.AddForce(playerToRabbit * walkForce); else if(!isHome && !isRunning) rb.AddForce(rabbitToHome * walkForce);
    }
}
