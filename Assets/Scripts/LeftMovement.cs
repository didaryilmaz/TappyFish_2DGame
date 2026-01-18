using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWith;
    float obstacleWith;

    void Start()
    {
        if(gameObject.CompareTag("Ground")){
            box = GetComponent<BoxCollider2D>();
            groundWith = box.size.x;
        }
        else if(gameObject.CompareTag("Obstacle")){
            obstacleWith = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    void Update()
    {
        if (GameManager.gameOver == false )
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if(gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWith)
        {
            transform.position = new Vector2(transform.position.x + groundWith * 2, transform.position.y);
        }
        }
        else if(gameObject.CompareTag("Obstacle"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - obstacleWith)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
