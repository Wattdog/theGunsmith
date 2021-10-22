using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] public float moveSpeed;
    [SerializeField] public int health;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 

        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            move.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
        }

        GetComponent<Transform>().position = GetComponent<Transform>().position += move;

    }
}
