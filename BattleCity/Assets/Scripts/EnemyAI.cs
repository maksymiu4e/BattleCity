using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Movement
{
    WeaponController wc;
    Rigidbody2D rb2d;

    [SerializeField]
    LayerMask blockingLayer;

    float h, v;
    enum Direction { Up, Down, Left, Right};

    public void RandomDirection()
    {
        CancelInvoke("RandomDirection");

        List<Direction> direction = new List<Direction>();
        if(!Physics2D.Linecast(transform.position, (Vector2)transform.position + new Vector2(1, 0), blockingLayer))
        {
            direction.Add(Direction.Right);
        }
        if (!Physics2D.Linecast(transform.position, (Vector2)transform.position + new Vector2(-1, 0), blockingLayer))
        {
            direction.Add(Direction.Left);
        }
        if (!Physics2D.Linecast(transform.position, (Vector2)transform.position + new Vector2(0, 1), blockingLayer))
        {
            direction.Add(Direction.Up);
        }
        if (!Physics2D.Linecast(transform.position, (Vector2)transform.position + new Vector2(0, -1), blockingLayer))
        {
            direction.Add(Direction.Down);
        }

        Direction selection = direction[Random.Range(0, direction.Count)];
        if (selection == Direction.Up)
        {
            v = 1;
            h = 0;
        }
        if (selection == Direction.Down)
        {
            v = -1;
            h = 0;
        }
        if (selection == Direction.Right)
        {
            v = 0;
            h = 1;
        }
        if (selection == Direction.Left)
        {
            v = 0;
            h = -1;
        }
        Invoke("RandomDirection", Random.Range(3, 6));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RandomDirection();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        RandomDirection();
        wc = GetComponentInChildren<WeaponController>();
        Invoke("FireWhenWanted", Random.Range(1f, 5f));
    }

    void FireWhenWanted()
    {
        wc.Fire();
        Invoke("FireWhenWanted", Random.Range(1f, 5f));
    }

    private void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }

}
