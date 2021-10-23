using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public List<GameObject> enemyTypes;

    public GameObject spawnEnemy()
    {
        if (enemyTypes.Count == 0) { throw new System.Exception(); }
        return Instantiate(enemyTypes[0], transform.position, transform.rotation, transform.parent);
    }

    public GameObject spawnEnemy(int _type)
    {
        if (enemyTypes.Count == 0) { throw new System.Exception(); }
        return Instantiate(enemyTypes[0], transform.position, transform.rotation, transform.parent);
    }
}
