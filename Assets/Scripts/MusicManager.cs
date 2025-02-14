using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    float volume;

    // Start is called before the first frame update
    void Start()
    {
        SoundSystem.instance.PlayMusic("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("River"))
        {
            SoundSystem.instance.PlaySound("River");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("River"))
        {
            SoundSystem.instance.StopSound("River");
        }
    }
    
}
