using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    void Start()
    {
        InvokeRepeating("CreateEnemy", 5f, 5f);
    }

    void CreateEnemy()
    {
        Vector3 enemyPosition = transform.position;
        Instantiate(enemy, enemyPosition, Quaternion.identity);
    }

}
