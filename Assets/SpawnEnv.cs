using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnv : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject p9;
    public GameObject p10;
    public float spawnRate = 1.8f;
    public int pNum = 11;
    private float currentTimeToSpawn;
    private int rndm;


    void Update()
    {
        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime * GameManager.gameSpeedIncrease;
        }
        else
        {
            Spawn();
            currentTimeToSpawn = spawnRate;
        }
    }

    private void Spawn()
    {
        //Random highest has tu be higher than max possible
        rndm = Random.Range(1,pNum);
        if(rndm == 1)
        {
            GameObject platforms = Instantiate(p1, transform.position, Quaternion.identity);
        }
        else if(rndm == 2)
        {
            GameObject platforms = Instantiate(p2, transform.position, Quaternion.identity);
        }
        else if(rndm == 3)
        {
            GameObject platforms = Instantiate(p3, transform.position, Quaternion.identity);
        }
        else if(rndm == 4)
        {
            GameObject platforms = Instantiate(p4, transform.position, Quaternion.identity);
        }
        else if(rndm == 5)
        {
            GameObject platforms = Instantiate(p5, transform.position, Quaternion.identity);
        }
        else if(rndm == 6)
        {
            GameObject platforms = Instantiate(p6, transform.position, Quaternion.identity);
        }
        else if(rndm == 7)
        {
            GameObject platforms = Instantiate(p7, transform.position, Quaternion.identity);
        }
        else if(rndm == 8)
        {
            GameObject platforms = Instantiate(p8, transform.position, Quaternion.identity);
        }
        else if(rndm == 9)
        {
            GameObject platforms = Instantiate(p9, transform.position, Quaternion.identity);
        }
        else if(rndm == 10)
        {
            GameObject platforms = Instantiate(p10, transform.position, Quaternion.identity);
        }
    }
}
