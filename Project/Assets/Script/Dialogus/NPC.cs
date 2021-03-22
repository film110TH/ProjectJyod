using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public Dialogue dialogue;


    //private void Update()
    //{
    //    float dist = Vector3.Distance(transform.position, player.transform.position);

    //    if (dist < 2)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            TriggerDialogue();
               
    //        }
    //    }

    //}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("chack");
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }  
}
