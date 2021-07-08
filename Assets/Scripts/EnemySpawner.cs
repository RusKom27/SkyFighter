using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int timeBetweenSpawn; 
    public int enemyAmount; 

    private float[] placesX;

    private void Start()
    {
        placesX = new float[transform.childCount];
        for (int i = 0; i < placesX.Length; i++)
        {
            placesX[i] = transform.GetChild(i).position.x;
        }
        StartCoroutine(spawnEnemy());
    }
    private IEnumerator spawnEnemy()
    {
        int countSpawn = 0; 
        while (countSpawn < enemyAmount)
        {
            countSpawn++;
            Instantiate(enemyPrefab, new Vector3(placesX[Random.Range(0,placesX.Length - 1)], transform.position.y, transform.position.z), Quaternion.identity);

            if (countSpawn % 10 == 0 && countSpawn <= 10)
            {
                timeBetweenSpawn -= 1;
            }

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
