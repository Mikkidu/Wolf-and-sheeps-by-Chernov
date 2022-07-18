using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject wolf;
    bool startGame = false;
    GameObject wordHungry;
    float counter = 0;
    public GameObject spawnManager;
    GameObject[] destroyObjects;
    public GameObject spawnWordHungry;
    public AudioSource wolfAttack;
    public GameObject menu;
    public GameObject gameInter;
    
    void Start()
    {
        SpawnAll();
    }
    void Update()
    {
        //Start game and destroy Start Menu
        if (Input.GetKeyDown("space") && !startGame)
        {
            GameObject.Find("Hungry(Clone)").GetComponent<DestroyWord>().enabled = true;
            startGame = true;
            wolf.GetComponent<PlayerControl>().enabled = true;
            wolfAttack.Play();
            menu.SetActive()
        }
        else if (startGame)
        {
           
        }   
        //Restart if push "r"
        if (Input.GetKeyDown("r"))
        {
            DestroyAll();
            SpawnAll();
            wolf.GetComponent<PlayerControl>().enabled = false;
            wolf.transform.position = Vector3.up * 0.5f;
            wolf.transform.rotation = new Quaternion(0, 0, 0, 1);
            counter = 0;        
            startGame = false;
        }    
    }

    void DestroyAll()
    {
        destroyObjects = GameObject.FindGameObjectsWithTag("DestroyRestart");
        foreach (GameObject objects in destroyObjects)
        {
            Destroy(objects);
        }
    }
    void SpawnAll()
    {
        Instantiate(spawnManager, Vector3.zero, spawnManager.transform.rotation);
        Instantiate(spawnWordHungry, spawnWordHungry.transform.position, spawnWordHungry.transform.rotation);
    }
}
