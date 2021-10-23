using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{
    // holds all spawners
    public List<GameObject> spawners;

    public List<GameObject> enemies;

    public GameObject playerRef;

    public int enemyCount;
    public int wave;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    bool alive = true;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G) && !started)
        {
            startWaves();
        }
     
    }

    public void startWaves()
    {
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while(alive)
        {
            Debug.Log("spawn wait: " + spawnWait + " wave: " + waveWait + " enemy: " + enemyCount);
            for (int i = 0; i < enemyCount; i ++)
            {
                int spawnerLoc = Random.Range(0, spawners.Count);
                GameObject new_enemy = spawners[spawnerLoc].GetComponent<enemySpawner>().spawnEnemy();
                new_enemy.GetComponent<enemyController>().playerRef = playerRef;

                enemies.Add(new_enemy);
                
                yield return new WaitForSeconds(spawnWait);
                
            }

            enemyCount ++;
            wave++;

            if (wave%3 == 0 && spawnWait >= 0.3f)
            {
                spawnWait -= 0.1f;
                if (waveWait >= 1)
                {
                    waveWait -= 1;
                }
            }

            yield return new WaitForSeconds(waveWait);
        }
        //yield return null;
    }
}
