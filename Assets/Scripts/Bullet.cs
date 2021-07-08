using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public bool fromPlayer = true;

    private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
        else if (fromPlayer)
        {
            if (collision.tag.Equals("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.tag.Equals("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
