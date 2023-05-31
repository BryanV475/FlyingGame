using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check collision with player
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }

    }
}
