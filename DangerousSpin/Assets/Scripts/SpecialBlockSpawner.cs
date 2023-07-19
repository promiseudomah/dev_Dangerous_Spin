using UnityEngine;

public class SpecialBlockSpawner : SquareBlockController
{
    public GameObject specialBlockPrefab; // Prefab of the special block

    private int normalBlockCount; // Counter for normal blocks spawned
    private int currentNormalBlockCount; // Current count of normal blocks spawned

    private void Start()
    {
        ResetBlockCounts();
    }

    protected override void SpawnSquareBlock()
    {
        currentNormalBlockCount++;
        if (currentNormalBlockCount >= normalBlockCount)
        {
            SpawnSpecialBlock();
            ResetBlockCounts();
        }
    }

    private void SpawnSpecialBlock()
    {
        float randomY = Random.Range(minYSpawn, maxYSpawn); // Randomize Y position
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        GameObject specialBlock = Instantiate(specialBlockPrefab, spawnPosition, Quaternion.identity);
        specialBlock.transform.SetParent(transform);
    }

    private void ResetBlockCounts()
    {
        normalBlockCount = Random.Range(2, 6); // Randomly set the count for normal blocks
        currentNormalBlockCount = 0;
    }
}
