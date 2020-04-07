using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.1f;
    public bool locks = false;
    
    private void FixedUpdate()
    {
        
                this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            

     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            this.speed = -this.speed;
        }
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().resetScene();
        }
    }

}
