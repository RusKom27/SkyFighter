using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool freezed = false;
    public GameObject enemyPrefab; 
    public int timeBetweenSpawn; 
    public int enemyAmount; 

    private float[] placesX;
    private GameObject enemies, bullets;

    private void Start()
    {
        placesX = new float[transform.childCount];
        enemies = GameObject.Find("Enemies");
        bullets = GameObject.Find("Bullets");
        for (int i = 0; i < placesX.Length; i++)
        {
            placesX[i] = transform.GetChild(i).position.x;
        }
        StartCoroutine(spawnEnemy());
    }

    public void DeleteEnemies()
    {
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            Destroy(enemies.transform.GetChild(i).gameObject);
        }
    }

    public void DeleteBullets()
    {
        for (int i = 0; i < bullets.transform.childCount; i++)
        {
            Destroy(bullets.transform.GetChild(i).gameObject);
        }
    }

    private IEnumerator spawnEnemy()
    {
        int countSpawn = 0; 
        while (true)
        {
            if(!freezed)
            {
                countSpawn++;
                Instantiate(enemyPrefab, new Vector3(placesX[Random.Range(0, placesX.Length - 1)], transform.position.y, transform.position.z), Quaternion.identity, enemies.transform);
            }

            if (countSpawn % 10 == 0 && countSpawn <= 10)
            {
                timeBetweenSpawn -= 1;
            }

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
