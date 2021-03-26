using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : NPC
{
    bool check = false;
    public SpawnItem SI;
    void Start()
    {
        SI = GameObject.Find("Inventorycontrollor").GetComponent<SpawnItem>();
    }

    void Update()
    {
        if(check == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SI.OnStartItemSpawn();
                check = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                check = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                check = true;
                TriggerDialogue();
            }
        }
    }
}
