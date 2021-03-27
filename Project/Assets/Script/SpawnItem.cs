
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] itemspawn;

    public PinkUp pick;
    public Text timetext;
    public Text gameovertext;
    public Text restarttext;
    public Text scoretext;
    public Text scorerealtext;

    static int score = 0;

    bool onstart;
    bool restart = false;

    private float timeSpawn = 10;
    private float timeout = 60;

    private void Start()
    {
        pick = GameObject.Find("Player").transform.GetComponent<PinkUp>();

        pick.PickTimeListener(Addtime);
    }

    void Update()
    {
        if(onstart == true)
        {
            timeSpawn += Time.deltaTime;
            timeout -= Time.deltaTime;

            timetext.text = "Time : " + (int)timeout;
            scorerealtext.text = "Score :" + score; 

            if (timeSpawn >= 10)
            {
                Debug.Log("New Item");
                for(int i = 0; i < 3; i++)
                {
                    float xpo;
                    float zpo;


                    xpo = Random.Range(-34, 16);
                    zpo = Random.Range(-50, -4);


                    Instantiate(itemspawn[Random.Range(0, 10)], new Vector3(xpo, 1.2f, zpo),Quaternion.identity);

                }
                timeSpawn = 0;
            }
            if(timeout <= 0)
            {
                onstart = false;
                gameovertext.text = "GameOver";
                restarttext.text = "press R to restart";
                scoretext.text = "score : " + score;


                GameObject[] games = GameObject.FindGameObjectsWithTag("Item");
                foreach (GameObject i in games)
                {
                    Destroy(i);
                }


                restart = true;
            }
        }
        if(restart == true)
        {
            if (Input.GetKey(KeyCode.R))
            {
                ReStart();
            }
        }
    }


    public void OnStartItemSpawn()
    {
        onstart = true;
    }

    public void Addtime(int id)
    {
        //timeout += id;
        Debug.Log(id);

        if (id == 2)
            score += 3;
        else if (id == 3)
            score += 5;
        else if (id == 99)
            timeout += 5; 
    
    }

    void ReStart()
    {
        Debug.Log("GG");
        SceneManager.LoadScene("SceneHome");
    }
}
