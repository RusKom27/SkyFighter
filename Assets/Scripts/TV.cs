using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public bool onPause = false;
    public bool onMenu = true;
    public bool onGame = false;

    private GameObject player, enemySpawner, enemies, bullets, scores, lives, pauseText, deathText, menuAnim;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.Find("Enemies");
        enemySpawner = GameObject.Find("EnemySpawner");
        bullets = GameObject.Find("Bullets");
        scores = GameObject.Find("Score");
        lives = GameObject.Find("Lives");
        menuAnim = GameObject.Find("MenuAnimation");
        pauseText = GameObject.Find("PauseText");
        deathText = GameObject.Find("DeathText");
        animator = GetComponent<Animator>();
        deathText.SetActive(false);
        pauseText.SetActive(false);
        ChangeState();
    }

    private void Update()
    {
        Debug.Log("G: " + onGame + " M: " + onMenu + " P: " + onPause);
        if (Input.GetKeyDown(KeyCode.Escape) && !onMenu)
        {
            onPause = !onPause;
            onGame = !onGame;
            ChangeState();
        }
    }

    public void ChangeStateMenu()
    {
        if (onPause)
        {
            onMenu = !onMenu;
            onPause = !onPause;
        }
        else if (!onPause)
        {
            onMenu = !onMenu;
            onGame = !onGame;
        }
        
        ChangeState();
    }

    public void Exit()
    {

    }

    public void GameOver()
    {
        deathText.SetActive(true);
    }

    public void ChangeState()
    {
        if (onPause)
        {
            enemySpawner.GetComponent<EnemySpawner>().freezed = true;
            player.GetComponent<Player>().freezed = true;
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).GetComponent<Enemy>().freezed = true;
            }

            for (int i = 0; i < bullets.transform.childCount; i++)
            {
                bullets.transform.GetChild(i).GetComponent<Bullet>().freezed = true;
            }
            deathText.SetActive(false);
            pauseText.SetActive(true);
        }
        if (onMenu)
        {
            menuAnim.SetActive(true);
            enemySpawner.GetComponent<EnemySpawner>().DeleteEnemies();
            enemySpawner.GetComponent<EnemySpawner>().DeleteBullets();
            enemySpawner.GetComponent<EnemySpawner>().freezed = true;
            deathText.SetActive(false);
            player.SetActive(false);
        }
        if (onGame)
        {
            deathText.SetActive(false);
            player.GetComponent<Player>().health = 10;
            scores.GetComponent<Score>().score = 0;
            player.SetActive(true);
            enemySpawner.GetComponent<EnemySpawner>().freezed = false;
            menuAnim.SetActive(false);
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
