using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave
{
    public GameObject gameObject;
    public GameObject[] gameObjects;
    public int spawnCount;

    public Wave(GameObject gameObject, int spawnCount)
    {
        this.gameObject = gameObject;
        this.spawnCount = spawnCount;

        gameObjects = null;
    }
    
    public Wave(GameObject[] gameObjects, int spawnCount)
    {
        this.gameObjects = gameObjects;
        this.spawnCount = spawnCount;

        gameObject = null;
    }
}
