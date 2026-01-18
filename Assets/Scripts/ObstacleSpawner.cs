using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InstanteObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false && GameManager.gameStarted == true){
            timer += Time.deltaTime;
            if(timer >= maxTime)
            {
                randomY = Random.Range(minY,maxY);
                InstanteObstacle();
                timer = 0;
            }
        }
    }
    public void InstanteObstacle(){
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2 (transform.position.x, randomY);
    }
}
