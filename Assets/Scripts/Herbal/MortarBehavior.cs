using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBehavior : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] GameObject mouseTracker;
    [SerializeField] GameObject herbalBehavior;
    [SerializeField] GameObject pestle;

    List<GameObject> flowers = new List<GameObject>();

    float rotateCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = mouseTracker.transform.position;


        if (mousePos.x < this.transform.position.x + 0.5f && mousePos.x > this.transform.position.x - 0.5f
            && mousePos.z < this.transform.position.z + 0.5f && mousePos.z > this.transform.position.z - 0.5f)
        {
            if (herbalBehavior.GetComponent<HerbalBehavior>().isHoldingFlower && Input.GetMouseButtonDown(0))
            {
                flowers.Add(herbalBehavior.GetComponent<HerbalBehavior>().ReleaseFlower());

                float randX = Random.Range(-0.05f, 0.05f);
                float randZ = Random.Range(-0.05f, 0.05f);

                flowers[flowers.Count - 1].transform.position = new Vector3(this.transform.position.x - 0.1f + randX, (this.transform.position.y) + flowers.Count * 0.001f, this.transform.position.z + 0.1f + randZ);
            }

            if (flowers.Count == 5 && Input.GetMouseButton(0))
            {
                pestle.transform.Rotate(0, 1, 0);
                rotateCount += Time.deltaTime;

                if(rotateCount > 5)
                {
                    herbalBehavior.GetComponent<HerbalBehavior>().CompletedTea();
                    
                    for (int i = 0; i < 5; i++) {
                        Destroy(flowers[i].gameObject);
                    }
                    flowers.Clear();

                    rotateCount = 0;
                }
            }


        }

        
    }

    public bool canAddFlower()
    {
        return flowers.Count < 5;
    }
}
