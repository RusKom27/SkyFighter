using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public int health = 5000;
    public bool freezed = false;
    public GameObject missile;

    private Rigidbody2D rigidBody;
    private GameObject gun1, gun2;
    private GameObject livesBoard, bullets;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gun1 = transform.GetChild(0).gameObject;
        gun2 = transform.GetChild(1).gameObject;
        livesBoard = GameObject.Find("Lives");
        bullets = GameObject.Find("Bullets");
        livesBoard.GetComponent<Text>().text = "Lives: " + health;
    }

    private void Update()
    {
        if (!freezed)
        {
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (health > 1)
            health -= damage;
        else if (health <= 1)
        {
            livesBoard.GetComponent<Text>().text = "Lives: 0";
            Die();
        }
        livesBoard.GetComponent<Text>().text = "Lives: " + health;
    }

    private void Shoot()
    {        
        Instantiate(missile, gun1.transform.position, Quaternion.Euler(0f, 0f, 0f), bullets.transform);
        Instantiate(missile, gun2.transform.position, Quaternion.Euler(0f, 0f, 0f), bullets.transform);
    }
}
