using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMove = false;
    public float speed = 3.1f;
    Rigidbody2D rb;
    // Update is called once per frame
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
       
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
               // rb.AddForce(new Vector2(0, speed*Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                //rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
               // rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
               // rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
            }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            FindObjectOfType<GameManager>().nextScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().resetScene();
        }
    }
}
