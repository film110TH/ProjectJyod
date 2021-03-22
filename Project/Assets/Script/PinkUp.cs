using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinkUp : MonoBehaviour
{
    public GameObject pinkUpPoin;
    public GameObject dropPoin;
    GameObject item = null;
    public bool canpink = false;

    Even pickitem = new Even();


    public void pickuplistener(UnityAction<int> listener)
    {
        pickitem.AddListener(listener);
    }
    
    void Update()
    {
        if (canpink)
        {    
            if(item != null)
            {
                
                item.transform.position = pinkUpPoin.transform.position;
            }
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
