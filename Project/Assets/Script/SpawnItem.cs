
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] itemspawn;

    public PinkUp pick;
    public Text timetext;
    public Text gameovertext;

    bool onstart;

    private float timeSpawn = 10;
    private float timeout = 5;

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

            if(timeSpawn >= 10)
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

                GameObject[] games = GameObject.FindGameObjectsWithTag("Item");
                foreach (GameObject i in games)
                {
                    Destroy(i);
                }
                
            }
        }
    }


    public void OnStartItemSpawn()
    {
        onstart = true;
    }

    public void Addtime(int time)
    {
        timeout += time;
    }
}
