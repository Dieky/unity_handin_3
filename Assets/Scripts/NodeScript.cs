using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{

    bool isEmpty = true;

    public bool buildTower()
    {
        if (isEmpty == true)
        {
            isEmpty = false;
            return true;
        }
        else return false;
    }
}
