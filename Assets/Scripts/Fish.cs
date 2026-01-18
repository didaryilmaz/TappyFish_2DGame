using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = - 60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource swim, hit, point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }
    private void FixedUpdate(){
        FishRotation();
    }    
    void FishSwim() {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false ){
            swim.Play();
            if(GameManager.gameStarted == false){
                _rb.gravityScale = 4f;
                _rb.linearVelocity = Vector2.zero;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x,_speed);
                obstacleSpawner.InstanteObstacle();
                gameManager.GameHasStarted();
            }
            else{
                _rb.linearVelocity = Vector2.zero;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x,_speed);
            }
            
        }
    }
    void FishRotation() {
        if (_rb.linearVelocity.y > 0){
            if (angle <= maxAngle){
                angle = angle + 4;
            }
        }
        else if (_rb.linearVelocity.y < -1.2){
            if(angle > minAngle){
                angle = angle - 2;
            }
        }
        if(touchedGround == false){
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){
            //Debug.Log("Scored!..");
            score.Scored();
            point.Play();
        }else if(collision.CompareTag("Column") && GameManager.gameOver == false){
            //game over
            gameManager.GameOver();
            FishDieEffect();
        }
    }
    void FishDieEffect(){
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Ground"))
    {
        if(GameManager.gameOver == false){
            //game over
            FishDieEffect();
            gameManager.GameOver();
            GameOver();
        }
        else{
            //game over (fish)
            GameOver();
        }
    }
    }
    void GameOver(){
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}


