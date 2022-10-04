using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform playerPos;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        // ground bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,
            -29f,-1.7f), Mathf.Clamp(transform.position.y,
            -19f, 0.6f), transform.position.z);
    }
}
