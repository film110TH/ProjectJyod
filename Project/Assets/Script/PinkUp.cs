using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;
using System;


public class PinkUp : MonoBehaviour
{
    PickUpEven pickupeven = new PickUpEven();
    PickUpEven picktimeeven = new PickUpEven();

    private int x = 0;
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

    public void PickTimeListener(UnityAction<int> listener)
    {
        picktimeeven.AddListener(listener);
    }
    //void Update()
    //{
    //    if(x == 2)
    //    {
    //        pickupeven.Invoke(itemid);

    //        x = 0;
    //    }
    //}

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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    OnDropItems();
                    
                }
                else if (Input.GetKeyDown(KeyCode.F)&&(Input.GetKey(KeyCode.F)))
                {
                    ID = item.GetComponent<ItemId>();
                    itemid = ID.itemID;
                    if(itemid != 99)
                        pickupeven.Invoke(itemid);
                    //x += 1;

                    else if(itemid == 99)
                    {
                        picktimeeven.Invoke(5);
                    }

                    Destroy(item.gameObject);
                    StartCoroutine(DelayBotton(true));
                }
            }           
        }
    }
    void clearItem()
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
