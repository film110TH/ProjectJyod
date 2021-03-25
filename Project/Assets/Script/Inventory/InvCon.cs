using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvCon : MonoBehaviour
{
    public GameObject inventory;
    public GameObject inv;

    void Awake()
    {

        inventory = GameObject.Find("Inventory Panel");
        inv = GameObject.Find("Inventory");
   
    }

    private void Start()
    {
        inventory.SetActive(false);
        inv.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            inventory.SetActive(true);
            inv.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.SetActive(false);
            inv.SetActive(false);
        }
    }
}
