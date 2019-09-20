﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Represents the hero's GameObject
    public GameObject player;
    //Alien spawnpoints
    public GameObject[] spawnPoints;
    //Alien Prefab
    public GameObject alien;
    //Controls the max amount of aliens on screen
    public int maxAliensOnScreen;
    // Total amount of alien kills needed to win
    public int totalAliens;
    //Controls the rate in which aliens spawn
    public float minSpawnTime;
    public float maxSpawnTime;
    //Determines the amount that spawn during a spawn event
    public int aliensPerSpawn;
    //Tracks the amount of Aliens on screen
    private int aliensOnScreen = 0;
    // Tracks time between spawn events
    private float generatedSpawnTime = 0;
    //Will track milliseconds between spawns
    private float currentSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //accumulates the time between each frame
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens)
            {
                List<int> previousSpawnLocations = new List<int>();
                if (aliensPerSpawn > spawnPoints.Length)
                {
                    aliensPerSpawn = spawnPoints.Length - 1;
                }
                aliensPerSpawn = (aliensPerSpawn > totalAliens) ? 
                    aliensPerSpawn - totalAliens : aliensPerSpawn;
                for (int i = 0; i < aliensPerSpawn; i++)
                {
                    if (aliensOnScreen < maxAliensOnScreen)
                    {
                        aliensOnScreen += 1;
                        int spawnPoint = -1;
                        while (spawnPoint == -1)
                        {
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }
                        GameObject spawnLocation = spawnPoints[spawnPoint];
                        GameObject newAlien = Instantiate(alien) as GameObject;
                        newAlien.transform.position = spawnLocation.transform.position;
                        Alien alienScript = newAlien.GetComponent<Alien>();
                        alienScript.target = player.transform;
                        Vector3 targetRotation = new Vector3(player.transform.position.x, 
                            newAlien.transform.position.y, player.transform.position.z);
                            newAlien.transform.LookAt(targetRotation);
                    }
                }
            }
        }
    }
}
