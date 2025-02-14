using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionBehavior : MonoBehaviour
{

    private Transform _selection;
    private bool isLooking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            _selection = null;
        }
        else
        {
            //While not selected
            isLooking = false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Selectable"))
            {
                isLooking = true;
                _selection = selection;
                Debug.Log("looking!");
            }

        }


        if (isLooking)
        {
            if (Input.GetMouseButtonDown(0) && _selection != null)
            {
                SoundSystem.instance.PlaySound("pickUp");
                Destroy(_selection.gameObject);
            }

        }

    }
}
