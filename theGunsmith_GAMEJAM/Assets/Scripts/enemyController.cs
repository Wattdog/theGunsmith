using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float accuracy;
    public float bulletSpeed;
    public float moveSpeed;
    public float rateOfFire;
    public float reloadSpeed;
    public float clipSize;
    public float range;

    public GameObject playerRef;
    public GameObject bulletPrefab;

    private bool canFire = true;
    private float currentClip;
    // Start is called before the first frame update
    void Start()
    {
        currentClip = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        // need to add interfacing with the pathfinding script
        /*
         * TODO:
         *      - Pathfind to random location within range of player
         *      - Remain in that spot till player is out of range or timer expires
         *      - Pick a new location and pathfind again
         * 
         * */

        if (Vector2.Distance(playerRef.transform.position, transform.position) <= range)
        {
            // disable pathfinding
            if (canFire)
            {

                canFire = false;

                float aimOffest = Random.Range(-accuracy, accuracy);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation, transform.parent);
                newBullet.GetComponent<bulletController>().setupBullet(transform.position, new Vector3((
                        playerRef.transform.position.x * Mathf.Cos(Mathf.Deg2Rad * aimOffest)) - (playerRef.transform.position.y * Mathf.Sin(Mathf.Deg2Rad * aimOffest)), (
                        playerRef.transform.position.x * Mathf.Sin(Mathf.Deg2Rad * aimOffest)) + (playerRef.transform.position.y * Mathf.Cos(Mathf.Deg2Rad * aimOffest))));
                newBullet.GetComponent<bulletController>().bulletSpeed = bulletSpeed;
                newBullet.GetComponent<bulletController>().owner = true;
                newBullet.GetComponent<bulletController>().startBullet();

                if (currentClip <= 0) { StartCoroutine(reloadSpeedDelayFunction()); }
                else { StartCoroutine(rateOfFireDelayFunction()); currentClip--; }

            }
            
        }
    }

    IEnumerator rateOfFireDelayFunction()
    {
        yield return new WaitForSeconds(rateOfFire);
        canFire = true;
    }

    IEnumerator reloadSpeedDelayFunction()
    {
        yield return new WaitForSeconds(reloadSpeed);
        canFire = true;
        currentClip = clipSize;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        Debug.Log(collider.tag);
        if (collider.tag == "Bullet")
        {
            if (!collider.GetComponent<bulletController>().owner)
            {
                if (collider.GetComponent<bulletController>().isRifle)
                {
                    if (collider.GetComponent<bulletController>().rifleHealth <= 0)
                    {
                        // kill enemey and bullet
                        GameObject.Destroy(collider);
                        GameObject.Destroy(gameObject);
                    }
                    else
                    {
                        collider.GetComponent<bulletController>().rifleHealth--;
                        GameObject.Destroy(gameObject);
                    }
                }
                else
                {
                    // kill enemey and bullet
                    GameObject.Destroy(collider);
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }
}
