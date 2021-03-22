using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler
{
    public int id;
    public Inventory inv;
    public itemdata droppeditem;
  
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();   
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("canrun");

        droppeditem = eventData.pointerDrag.GetComponent<itemdata>();
       
        if (inv.itmes[id].ID == -1)
        {
            inv.itmes[droppeditem.slot] = new Item();
            Debug.Log(inv.itmes[id].ID);
            inv.itmes[id] = droppeditem.item;
            droppeditem.slot = id;
        }
        else if (droppeditem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<itemdata>().slot = droppeditem.slot;
            item.transform.SetParent(inv.slots[droppeditem.slot].transform);
            item.transform.position = inv.slots[droppeditem.slot].transform.position;

            droppeditem.slot = id;
            droppeditem.transform.SetParent(this.transform);
            droppeditem.transform.position = this.transform.position;

            inv.itmes[droppeditem.slot] = item.GetComponent<itemdata>().item;
            inv.itmes[id] = droppeditem.item;
        }
    }
}
