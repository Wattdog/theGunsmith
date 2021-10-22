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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletGo)
        {
            transform.position += direction * Time.deltaTime; 
        }
    }

    public void startBullet()
    {
        bulletGo = true;
    }
    public void setupBullet(Vector2 currentLoc, Vector2 mouseLoc)
    {
        Vector3 unitVec = (mouseLoc - currentLoc).normalized;
        direction = unitVec;

        direction *= bulletSpeed;
    }


}
