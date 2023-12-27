using UnityEngine;

public class AppleTreeController : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    private Transform[] spawns;
    private float randArea = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        spawns = GetComponentsInChildren<Transform>();
        InvokeRepeating(nameof(SpawnApple), 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnApple()
    {
        Vector2 randPoint = new Vector2(Random.Range(gameObject.transform.position.x-randArea, gameObject.transform.position.x + randArea), Random.Range(gameObject.transform.position.y-randArea, gameObject.transform.position.y + randArea));
        Instantiate(applePrefab, randPoint, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }

}