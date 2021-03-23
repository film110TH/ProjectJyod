using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;
using System;


public class PinkUp : MonoBehaviour
{
    PickUpEven pickupeven = new PickUpEven();
    

    public float Delay = 3f;
    public GameObject pinkUpPoin;
    public GameObject dropPoin;
    public GameObject item = null;
    public bool canpink = true;
    public ItemId ID;

    public int itemid;

    public void PickListener(UnityAction<int> listener)
    {
        pickupeven.AddListener(listener);
    }
    void Update()
    {
     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            if (canpink == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    item = other.gameObject;
                   
                    OnpickUpItems();
                    StartCoroutine(DelayBotton(false));
                }
            }
            if (canpink == false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    
                    OnDropItems();
                   
                }
                else if (Input.GetKey(KeyCode.F))
                {
                    ID = item.GetComponent<ItemId>();
                    itemid = ID.itemID;
                    
                }
            }           
        }
    }
    void AddtoInventory()
    {
        
    }
    void OnpickUpItems()
    {
        item.transform.position = pinkUpPoin.transform.position;
        item.transform.SetParent(pinkUpPoin.transform);
    }

    void OnDropItems()
    {
        try
        {
            item.transform.SetParent(item.transform.parent.parent);
            //item.transform.SetParent(item.transform.parent.parent);
            item.transform.position = dropPoin.transform.position;

            StartCoroutine(DelayBotton(true));
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    void Enditem()
    {
        item = null;
    }
    IEnumerator DelayBotton(bool Trick)
    {
        yield return new WaitForSeconds(Delay);
        canpink = Trick;
    }
}
