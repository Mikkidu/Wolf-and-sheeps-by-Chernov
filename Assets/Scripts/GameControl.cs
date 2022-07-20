using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject wolf, spawnManager, spawnWordHungry;
    bool startGame = false;
    float counter, timer = 150;
    GameObject[] destroyObjects;
    public AudioSource wolfAttack;
    public GameObject menu;
    public Text timeLeft, sheepsLeft, bestScore, finalLeft;
    int numberSheeps, bestSheepLeft;
    
    void Start()
    {
        SpawnAll();
        counter = timer;
        sheepsLeft.enabled = false;
        timeLeft.enabled = false;
        finalLeft.enabled = false;
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
            menu.SetActive(false);
            sheepsLeft.enabled = true;
            timeLeft.enabled = true;
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
            counter = 120f;        
            startGame = false;
            menu.SetActive(true);
            sheepsLeft.enabled = false;
            timeLeft.enabled = false;
            finalLeft.enabled = false;
        }
        //Time and score
        if (startGame && counter > 0)
        {
            counter -= Time.deltaTime;
            timeLeft.text = Mathf.Round(counter).ToString();
            numberSheeps = GameObject.FindGameObjectsWithTag("Sheeps").Length;
            sheepsLeft.text = string.Format("Sheeps left - {0}", numberSheeps);
        }
        else if (counter <= 0) //Time is over
        {
            bestScore.text = string.Format("Best score - {0}", numberSheeps);
            finalLeft.text = string.Format("Final left - {0}!", numberSheeps);
            wolf.GetComponent<PlayerControl>().enabled = false;
            startGame = false;
            finalLeft.enabled = true;
        }    
    }
    //Destroy all spawned objectы
    void DestroyAll()
    {
        destroyObjects = GameObject.FindGameObjectsWithTag("DestroyRestart");
        foreach (GameObject objects in destroyObjects)
        {
            Destroy(objects);
        }
        destroyObjects = GameObject.FindGameObjectsWithTag("Sheeps");
        foreach (GameObject objects in destroyObjects)
        {
            Destroy(objects);
        }
    }
    //Spawn "Hungry?" and Sheeps
    void SpawnAll()
    {
        Instantiate(spawnManager, Vector3.zero, spawnManager.transform.rotation);
        Instantiate(spawnWordHungry, spawnWordHungry.transform.position, spawnWordHungry.transform.rotation);
    }
}
