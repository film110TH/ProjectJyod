using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public Inventory inv;
    public PinkUp pink;
    public int itemID;

    private void Awake()
    {
        inv = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        pink = FindObjectOfType<PinkUp>().GetComponent<PinkUp>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pick")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inv.AddItem(itemID);
                Destroy(this.gameObject);
                pink.canpink = false;
            }
        }
    }

}
