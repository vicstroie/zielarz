using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbalBasketBehavior : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] GameObject mouseTracker;
    [SerializeField] GameObject flowerPrefab;
    [SerializeField] GameObject HerbalManager;

    //private
    List<GameObject> basketContents;

    // Start is called before the first frame update
    void Start()
    {
        basketContents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mouseTracker.transform.position;

        //Check if hand is over basket
        if (mousePos.x < this.transform.position.x + 0.2f && mousePos.x > this.transform.position.x - 0.2f
            && mousePos.z < this.transform.position.z + 0.3f && mousePos.z > this.transform.position.z - 0.3f)
        {

            //Check that 1) basket isn't empty 2) mouse is clicked 3) not holding a flower
            if(basketContents.Count > 0 && Input.GetMouseButtonDown(0) && !HerbalManager.GetComponent<HerbalBehavior>().isHoldingFlower)
            {
                GameObject currentFlower = basketContents[basketContents.Count - 1];

                currentFlower.GetComponent<FlowerBehavior>().StartHold(mouseTracker); //Makes flower follow hand
                HerbalManager.GetComponent<HerbalBehavior>().HoldFlower(currentFlower);
                basketContents.Remove(currentFlower);
            }



        }
    }

    //Called by plants, adds flowers to basket
    public void AddToBasket()
    {
        for(int i = 0; i < 5; i++)
        {
            float randX = Random.Range(-0.1f, 0.1f);
            float randZ = Random.Range(-0.2f, 0.2f);

            //new flower position, increases height with basket size
            Vector3 newFlowerPosition = new Vector3(this.transform.position.x +  randX, this.transform.position.y + basketContents.Count * 0.001f, this.transform.position.z + randZ);

            GameObject newFlower = Instantiate(flowerPrefab, newFlowerPosition, this.transform.rotation);
            basketContents.Add(newFlower);
        }
    }
}
