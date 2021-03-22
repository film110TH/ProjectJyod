using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    GameObject player;
    GameObject invertorypanel;
    GameObject slotpanel;
    ItemDataBase dataBase;
    public GameObject inventoryslot;
    public GameObject inventoryItem;

    int slotAmount; 
    public List<Item> itmes = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    //void addpickuplistener()
    //{

    //}
    //public void OnPickItem(int itemID)
    //{
    //    AddItem(itemID);
    //}

    [Obsolete]
    private void Start()
    {
        dataBase = GetComponent<ItemDataBase>();               
        slotAmount = 20;
        invertorypanel = GameObject.Find("Inventory Panel");
        slotpanel = invertorypanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            itmes.Add(new Item());
            slots.Add(Instantiate(inventoryslot));
            slots[i].GetComponent<slot>().id = i;
            slots[i].transform.SetParent(slotpanel.transform);
            slots[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        AddItem(3);
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
                    itemObj.GetComponent<itemdata>().item = itemtoAdd;
                    itemObj.GetComponent<itemdata>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    itemObj.GetComponent<Image>().sprite = itemtoAdd.Sprite;
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
