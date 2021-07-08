using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public int health = 5;
    public GameObject missile;

    private Rigidbody2D rigidBody;
    private GameObject gun1, gun2;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gun1 = transform.GetChild(0).gameObject;
        gun2 = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {        
        Instantiate(missile, gun1.transform.position, Quaternion.Euler(0f, 0f, 0f));
        Instantiate(missile, gun2.transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
