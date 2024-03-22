using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefabs;
    [SerializeField] private GameObject[] pointSpawn;

    private float timeCount;
    private float timeSpwan; 
    private void Awake()
    {
        timeCount = 0;
    }
    private void Update()
    {
        if ((GameManager.Instance.IsGamePlaying()))
        {
            timeCount += Time.deltaTime;
            if (timeCount > 5)
            {
                SpwanEnemy();
                timeSpwan -= 0.1f;
                if (timeSpwan < 1) { timeSpwan = 1; }
                timeCount = 0;
            }
        }
        
    }
    private void SpwanEnemy()
    {
        int pointSpwan = Random.Range(0, pointSpawn.Length);
        Instantiate(enemyPrefabs, pointSpawn[pointSpwan].transform.position, Quaternion.identity);
    }
}
