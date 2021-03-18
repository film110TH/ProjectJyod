using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDragHandler
{
    public int id;
    public Inventory inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemdata droopeditem = eventData.pointerDrag.GetComponent<itemdata>();
        if (inv.itmes[id].ID == -1)
        {
            inv.itmes[droopeditem.slot] = new Item();
            inv.itmes[id] = droopeditem.item;
            droopeditem.slot = id;
        }
        else
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<itemdata>().slot = droopeditem.slot;
        }
    }
}
