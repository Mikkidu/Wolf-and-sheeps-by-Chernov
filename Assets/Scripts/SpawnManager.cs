using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject sheep;
   
    Vector3 spawnPos, sizeCol = Vector3.one * 2;
    float centerHeight = 0.25f;
    Collider[] colliders;
    bool check = true;
    int numSheep = 21, endWhile;
    

    // Start is called before the first frame update
    void Start()
    {
        
        for ( int i = 0; i < numSheep; i += 1)
        {
            endWhile = 0;
            while (check && endWhile < 4)
            {
                spawnPos = new Vector3(Random.Range(-25f, 25f), centerHeight, Random.Range(-25f, 25f));
                check = CheckSpawnPos(spawnPos);
                endWhile += 1;
           }
            check = true;
            Instantiate(sheep, spawnPos, sheep.transform.rotation);
        }
    }
    void Update()
    {
        
    }
    bool CheckSpawnPos(Vector3 pos)
    {
        colliders = Physics.OverlapBox(spawnPos, sizeCol);
        if (colliders.Length > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
