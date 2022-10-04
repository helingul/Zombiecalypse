using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Transform _player;
    
    // Start is called before the first frame update
    protected void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rigidbody2D.rotation = angle;
        direction.Normalize();
        _movement = direction;
    }

    void FixedUpdate()
    {
        MoveCharacter(_movement);
    }

    protected void MoveCharacter(Vector2 direction)
    {
        _rigidbody2D.MovePosition((Vector2) transform.position + (direction * 3f * Time.deltaTime));
    }
}
