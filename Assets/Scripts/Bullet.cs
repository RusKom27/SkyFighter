using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed_ = 4f;
    public bool fromPlayer_ = true;

    private Rigidbody2D rigidBody_;
    void Start()
    {
        rigidBody_ = GetComponent<Rigidbody2D>();
        rigidBody_.velocity = new Vector2(0, speed_);
    }

    void Update()
    {
    }
}
