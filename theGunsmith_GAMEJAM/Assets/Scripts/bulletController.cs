using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    
    /*
        -Create bullet
        -Calculate unit vector from orgin to mouse location
        -multiply result by bullet speed * delta time
        -push bullet every frame by this vector
        -delete afeter out of scene
         
         */

    public float bulletSpeed = 5.0f;
    public Vector3 direction = new Vector3();

    private bool bulletGo = false;
    public bool isRifle;
    public int rifleHealth = 3;
    // if owner is set to false, it is the gunsmith's bullet
    // if owner is set to true, it is an enemey bullet
    public bool owner = false;

    // Start is called before the first frame update
    void Start()
    {
        isRifle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletGo)
        {
            transform.position += direction* bulletSpeed * Time.deltaTime; 
        }

        // when doing collisions implement rifle bullet health for x many impacts
    }

    public void startBullet()
    {
        bulletGo = true;
    }
    public void setupBullet(Vector2 currentLoc, Vector2 mouseLoc)
    {
        Vector3 unitVec = (mouseLoc - currentLoc).normalized;
        direction = unitVec;
    }


}
