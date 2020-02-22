﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    [SerializeField]
    private float _spawnOffset = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");

        if (collision.tag == "Hole" || collision.tag == "Enemy")
        {
            Debug.Log("Tele");
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.position = new Vector3(transform.position.x, transform.position.y + _spawnOffset, 0);
        }
    }
}
