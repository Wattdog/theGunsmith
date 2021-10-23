using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public List<GameObject> enemyTypes;

    public void spawnEnemy()
    {
        if (enemyTypes.Count == 0) { throw new System.Exception(); }
        Instantiate(enemyTypes[0], transform.parent);
    }

    public void spawnEnemy(int _type)
    {
        if (enemyTypes.Count == 0) { throw new System.Exception(); }
        Instantiate(enemyTypes[0], transform.parent);
    }
}
