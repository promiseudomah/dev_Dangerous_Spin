using UnityEngine;

public class SquareBlockController : MonoBehaviour
{
    public float movementSpeed = 5f; // Speed of the square block movement
    public float spawnDelay = 1f; // Delay between spawning each square block
    public GameObject squareBlockPrefab; // Prefab of the square block

    private float spawnTimer; // Timer to track the spawning delay
    [SerializeField] protected float minYSpawn = 0.3f; // Minimum Y position for spawning
    [SerializeField] protected float maxYSpawn = 2.6f; // Maximum Y position for spawning

    // [HideInInspector] public ObjectPooler objectPooler; // Object pooler for square blocks

    private void Start()
    {
        // objectPooler = ObjectPooler.Instance; // Get reference to the Object Pooler instance
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            SpawnSquareBlock();
            spawnTimer = 0f;
        }

        MoveSquareBlocks();
    }

    protected virtual void SpawnSquareBlock()
    {
        float randomY = Random.Range(minYSpawn, maxYSpawn); // Randomize Y position

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        GameObject squareBlock = ObjectPooler.Instance.SpawnFromPool(squareBlockPrefab.tag, spawnPosition, Quaternion.identity);
        squareBlock.transform.SetParent(transform);
    }

    private void MoveSquareBlocks()
    {
        float moveDistance = movementSpeed * Time.deltaTime;
        foreach (Transform child in transform)
        {
            child.Translate(Vector3.right * moveDistance);
            if (child.position.x > Screen.width)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
