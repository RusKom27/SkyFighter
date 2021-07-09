using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3f;
    public int health = 5;
    public float attackSpeed = 1f;
    public GameObject missile;

    private Rigidbody2D rigidBody;
    private GameObject gun1, gun2;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gun1 = transform.GetChild(0).gameObject;
        gun2 = transform.GetChild(1).gameObject;

        

        StartCoroutine(Shoot());
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(0, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Shoot()
    {
        while (gameObject != null)
        {
            Instantiate(missile, gun1.transform.position, Quaternion.Euler(0f, 0f, 0f));

            Instantiate(missile, gun2.transform.position, Quaternion.Euler(0f, 0f, 0f));

            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
