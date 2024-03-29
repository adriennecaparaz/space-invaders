﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D m_rigidbody;
    public static bool off_screen = true;
    public GameObject bullet;
    public static int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        off_screen = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // timescale to make sure clicking play/resume
        if (Time.timeScale == 1f && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))){
            if (off_screen == true){
                Shoot();
            }
        }
    }

    void Shoot()
    {
        off_screen = false;
        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, Vector2.up);
        Debug.DrawRay(this.transform.position, Vector2.up*9001, Color.green, 0.1f);
    
        GameObject b = (GameObject)(Instantiate (bullet, transform.position, Quaternion.identity));
        Physics2D.IgnoreCollision(b.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        b.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
    }

    void Move()
    {
        float movementModifier = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = m_rigidbody.velocity;
        m_rigidbody.velocity = new Vector2(movementModifier * speed, currentVelocity.y);
    }

    public int getLives()
    {
        return lives;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {

    }
}
