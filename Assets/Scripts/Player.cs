using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_ = 10f;
    public int health_ = 5;
    public GameObject missile;

    private Rigidbody2D rigidBody;
    private GameObject gun1, gun2;
    private bool gunQueue = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gun1 = GameObject.Find("gun1");
        gun2 = GameObject.Find("gun2");
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed_, rigidBody.velocity.y);
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
