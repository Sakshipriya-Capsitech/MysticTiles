using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public int initialPlatforms = 5;
    public float platformLength = 6f;
    private float spawnZ = 0f;
    private Queue<GameObject> platforms = new Queue<GameObject>();
    void Start()
    {
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }
    void Update()
    {
        if (player.position.z - 10f > spawnZ - ((initialPlatforms * platformLength) + platformLength))
        {
            SpawnPlatform();
            SpawnPlatform();
            SpawnPlatform();
            RemoveOldPlatform();
        }
    }
    void SpawnPlatform()
    {

        float randomGap = 0.25f;
        Vector3 spawnPos = new Vector3(0, 0, spawnZ + randomGap);
        GameObject newPlatform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        platforms.Enqueue(newPlatform);
        spawnZ += platformLength + randomGap;
    }
    public IEnumerable<GameObject> GetAllPlatforms()
    {
        return platforms;
    }
    void RemoveOldPlatform()
    {
        GameObject oldPlatform = platforms.Dequeue();
        if (oldPlatform != null)
            Destroy(oldPlatform);
    }

    public PlatformTile GetNextTile()
    {
        foreach (GameObject platformGO in platforms)
        {
            if (platformGO == null) continue;
            if (platformGO.transform.position.z > player.position.z + 0.5f)
            {
                PlatformTile tile = platformGO.GetComponent<PlatformTile>();
                if (tile != null)
                    return tile;
            }
        }
        return null;
    }
}

