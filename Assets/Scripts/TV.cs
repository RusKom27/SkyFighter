using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public bool onPause = false;
    public bool onMenu = false;
    public bool onGame = true;

    private GameObject player, enemySpawner, enemies, bullets, scores, lives, pauseText;
    private float bulletSpeed = 4, enemySpeed = 1, playerSpeed = 10;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.Find("Enemies");
        enemySpawner = GameObject.Find("EnemySpawner");
        bullets = GameObject.Find("Bullets");
        scores = GameObject.Find("Scores");
        lives = GameObject.Find("Lives");
        pauseText = GameObject.Find("PauseText");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
        }
        if (onPause)
        {
            enemySpawner.GetComponent<EnemySpawner>().freezed = true;
            player.GetComponent<Player>().freezed = true;
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).gameObject.GetComponent<Enemy>().freezed = true;
            }
            for (int i = 0; i < bullets.transform.childCount; i++)
            {
                bullets.transform.GetChild(i).gameObject.GetComponent<Bullet>().freezed = true;
            }
            pauseText.SetActive(true);
        }
        else if (onMenu)
        {

        }
        else if (onGame || !onPause)
        {
            enemySpawner.GetComponent<EnemySpawner>().freezed = false;
            player.GetComponent<Player>().freezed = false;
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).gameObject.GetComponent<Enemy>().freezed = false;
            }
            for (int i = 0; i < bullets.transform.childCount; i++)
            {
                bullets.transform.GetChild(i).gameObject.GetComponent<Bullet>().freezed = false;
            }
            pauseText.SetActive(false);
        }
    }

}
