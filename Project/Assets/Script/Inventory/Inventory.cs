using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    GameObject invertorypanel;
    GameObject slotpanel;
    ItemDataBase dataBase;
    public GameObject inventoryslot;
    public GameObject inventoryItem;

    PinkUp pick; 

    int slotAmount; 
    public List<Item> itmes = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    [Obsolete]
    private void Awake()
    {
        pick = GameObject.Find("Player").transform.GetComponent<PinkUp>();

        dataBase =transform.GetComponent<ItemDataBase>();               
        slotAmount = 20;
        invertorypanel = GameObject.Find("Inventory Panel").transform.gameObject;
        slotpanel = invertorypanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            itmes.Add(new Item());
            slots.Add(Instantiate(inventoryslot));
            slots[i].transform.GetComponent<slot>().id = i;
            slots[i].transform.SetParent(slotpanel.transform);
            slots[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        pick.PickListener(OnPickUpitem);

    }
    
    public void OnPickUpitem(int itemid)
    {
        Debug.Log("ItemID" + itemid);
        AddItem(itemid);
    }
    public void AddItem(int id) 
    {
        Item itemtoAdd = dataBase.fetchItemByID(id);
        if (itemtoAdd.Stackable && Checkitemisinventory(itemtoAdd))
        {
            for (int i = 0; i < itmes.Count; i++)
            {
                if (itmes[i].ID == id)
                {
                    itemdata data = slots[i].transform.GetChild(0).GetComponent<itemdata>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            
            for (int i = 0; i < itmes.Count; i++)
            {
                if (itmes[i].ID == -1)
                {
                    itmes[i] = itemtoAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    
                    itemObj.transform.GetComponent<itemdata>().item = itemtoAdd;
                    itemObj.transform.GetComponent<itemdata>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);                   
                    itemObj.transform.position = slots[i].transform.position;

                    //itemObj.transform.position =  Vector2.zero;
                    itemObj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    itemObj.transform.GetComponent<Image>().sprite = itemtoAdd.Sprite;
                    itemObj.name = itemtoAdd.Title;

                      break;
                }
            }
        }
    }

    bool Checkitemisinventory(Item item)
    {
        for (int i = 0; i < itmes.Count;i++)
            if (itmes[i].ID == item.ID)
                return true;
        return false;
    }
}
