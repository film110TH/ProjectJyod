using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class Start : MonoBehaviour
{

    public void onstart()
    {
        SceneManager.LoadScene("SceneHome");
    }
    
}
