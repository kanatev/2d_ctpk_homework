using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeController : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    private Transform[] spawns;

    private float timer = 3f;
    private float randArea = 0.3f;
    
    
    // private SpawnPoint[] spawnPoints;
    List<SpawnPoint> treeSpawnPoints = new List<SpawnPoint>();

    
    // this class spawn apples

    // Start is called before the first frame update
    void Start()
    {
        spawns = GetComponentsInChildren<Transform>();
        InvokeRepeating(nameof(SpawnApple), 0, 1);
        // spawns = 
        // foreach (var spawn in spawns)
        // {
        //     GameObject newApple = Instantiate(applePrefab, spawn.position, Quaternion.identity);
        //     SpawnPoint ourSpawn = new SpawnPoint(spawn, true, newApple);
        //     treeSpawnPoints.Add(ourSpawn);
        //     Debug.Log("we did it");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // Invoke("SpawnApple", 2);
        // SpawnApple();
        // Vector2 randPoint = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f)) * Time.deltaTime;
        // GameObject newApple = Instantiate(applePrefab, randPoint, Quaternion.identity);

        // if a spawn point is empty let's grow an apple
        // if (treeSpawnPoints.),

        // for simple implementation
        // span new apple each time counter

        // if ()


    }

    void SpawnApple()
    {
        // if (timer > 0)
        // {
        //     timer -= 1;// * Time.deltaTime;
        // }
        // else
        // {
            Vector2 randPoint = new Vector2(Random.Range(gameObject.transform.position.x-randArea, gameObject.transform.position.x + randArea), Random.Range(gameObject.transform.position.y-randArea, gameObject.transform.position.y + randArea));
            GameObject newApple = Instantiate(applePrefab, randPoint, Quaternion.identity);
            timer = 3f;
        // }        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            // let's shake the tree (animation)

            // let's drop all apples

        }
    }

    public void OnGettingInfo(Transform freeSpawnPlace)
    {

    }
}

public class SpawnPoint
{
    public Transform spawnPoint;
    public bool isEmpty;
    public GameObject apple;
    public SpawnPoint(Transform aSpawnPoint, bool aIsEmpty, GameObject anApple)
    {
        spawnPoint = aSpawnPoint;
        isEmpty = aIsEmpty;
        apple = anApple;
    }
}

public class AppleSpawner
{

}