using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public bool onPause = false;
    public bool onMenu = true;
    public bool onGame = false;

    private GameObject player, enemySpawner, enemies, bullets, scores, lives, pauseText, menuAnim;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.Find("Enemies");
        enemySpawner = GameObject.Find("EnemySpawner");
        bullets = GameObject.Find("Bullets");
        scores = GameObject.Find("Scores");
        lives = GameObject.Find("Lives");
        menuAnim = GameObject.Find("MenuAnimation");
        pauseText = GameObject.Find("PauseText");
        animator = GetComponent<Animator>();
        pauseText.SetActive(false);
        ChangeState(onGame, onMenu, onPause);
    }

    private void Update()
    {
        Debug.Log("G: " + onGame + " M: " + onMenu + " P: " + onPause);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
            onGame = !onGame;
            ChangeState(onGame, onMenu, onPause);
        }
    }

    public void ChangeStateMenu()
    {
        onMenu = !onMenu;
    }

    public void Exit()
    {

    }

    public void ChangeState(bool onGame, bool onMenu, bool onPause)
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
            pauseText.SetActive(true);
        }
        else if (onMenu)
        {
            menuAnim.SetActive(true);

        }
        else if (onGame)
        {
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
