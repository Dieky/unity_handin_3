using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{

    public GameObject towerPrefab;
    public Material highlightColor;

    public Camera fpsCam;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlaceTower();
        }

    }

    void PlaceTower()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            bool isEmpty = hit.transform.GetComponent<NodeScript>().buildTower();
            if (isEmpty)
            {
                Instantiate(towerPrefab, hit.transform.position, Quaternion.identity);
                hit.transform.GetComponent<Renderer>().material = highlightColor;
            }
            return;
        }
    }
}



