using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public bool fromPlayer = true;

    private Rigidbody2D rigidBody;
    private GameObject scoreBoard;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, speed);
        scoreBoard = GameObject.Find("Score");
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
                scoreBoard.GetComponent<Score>().score += 1;
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.tag.Equals("Player"))
            {
                collision.GetComponent<Player>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
