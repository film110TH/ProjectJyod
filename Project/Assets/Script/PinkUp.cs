using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkUp : MonoBehaviour
{
    public GameObject pinkUpPoin;
    public GameObject dropPoin;
    GameObject item = null;
    bool canpink = false;
    void Update()
    {
        if (canpink)
        {
            item.transform.position = pinkUpPoin.transform.position;
            if (Input.GetKey(KeyCode.Q))
            {
                item.transform.position = dropPoin.transform.position;
                canpink = false;
            }
        }
        else if (canpink == false)
        {
            item = null;

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Item")
        {
            if (canpink== false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    item = other.gameObject;
                    canpink = true;
                }
            }
        }
    }
}
