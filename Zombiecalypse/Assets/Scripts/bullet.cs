using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 4f;
    private Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        dir= GameObject.Find("Dir").transform.position;
        transform.position= GameObject.Find("FirePoint").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);

        
    }
}
