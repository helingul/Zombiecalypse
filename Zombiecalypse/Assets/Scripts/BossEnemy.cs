using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) > stoppingDistance)
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    _player.position,
                    speed * Time.deltaTime);
            
        } else if (
            Vector2.Distance(transform.position, _player.position) < stoppingDistance &&
            Vector2.Distance(transform.position, _player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            
        } else if (Vector2.Distance(transform.position, _player.position) < retreatDistance)
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    _player.position,
                    -speed * Time.deltaTime);
        }
    }
    
    
}
