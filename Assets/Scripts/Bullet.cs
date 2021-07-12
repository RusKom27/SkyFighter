using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public bool fromPlayer = true;
    public bool freezed = false;

    private Rigidbody2D rigidBody;
    private GameObject scoreBoard, bullets;
    private Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scoreBoard = GameObject.Find("Score");
    }

    private void Update()
    {
        if (!freezed)
            rigidBody.velocity = new Vector2(0, speed);
        else
            rigidBody.velocity = new Vector2(0, 0);
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Wall"))
        {
            rigidBody.velocity = new Vector2(0, 0);
            animator.SetBool("death", true);
        }
        else if (fromPlayer)
        {
            if (collision.tag.Equals("Enemy"))
            {
                collision.GetComponent<Enemy>().freezed = true;
                freezed = !freezed;
                collision.GetComponent<Animator>().SetBool("death", true);
                scoreBoard.GetComponent<Score>().score += 1;
                animator.SetBool("death", true);
            }
        }
        else
        {
            if (collision.tag.Equals("Player"))
            {
                collision.GetComponent<Player>().TakeDamage(1);
                freezed = !freezed;
                animator.SetBool("death", true);
            }
        }
    }
}
