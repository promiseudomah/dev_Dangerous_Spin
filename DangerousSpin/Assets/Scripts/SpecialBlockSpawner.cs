using UnityEngine;

public class SpecialBlockSpawner : SquareBlockController
{
    public GameObject specialBlockPrefab; // Prefab of the special block
    public int specialBlockSpawnInterval = 3; // Interval to spawn the special block

    private int blockCount; // Counter for the normal block spawn

    protected override void SpawnSquareBlock()
    {
        blockCount++;

        // Spawn a special block every specialBlockSpawnInterval times
        if (blockCount % specialBlockSpawnInterval == 0)
        {
            SpawnSpecialBlock();
        }
        else
        {
            base.SpawnSquareBlock();
        }
    }

    private void SpawnSpecialBlock()
    {
        float randomY = Random.Range(minYSpawn, maxYSpawn); // Randomize Y position
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        GameObject specialBlock = objectPooler.SpawnFromPool(specialBlockPrefab.tag, spawnPosition, Quaternion.identity);
        specialBlock.transform.SetParent(transform);
    }
}
