using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> CarOptions;

    [SerializeField]
    public List<GameObject> SpawnPoints;
    [SerializeField]
    int MaxNpcCount = 10;
    [SerializeField]
    float SpawnRate = 3f;
    [SerializeField]
    float SpawnpointCooldown = 0.5f;
    Dictionary<GameObject, float> spawnCooldowns = new Dictionary<GameObject, float>();

    void Start()
    {
        InvokeRepeating("SpawnCar", 0.5f, SpawnRate);
    }

    void SpawnCar()
    {
        if (GameObject.FindGameObjectsWithTag("Npc").Length < MaxNpcCount)
        {
            var randomOffset = Random.insideUnitCircle / 1.5f;

            Transform spawnPoint = PickRandomSpawnPoint();

            if (spawnPoint != null)
            {
                Instantiate(CarOptions[Random.Range(0, CarOptions.Count)],
                       spawnPoint.position + (Vector3)randomOffset,
                       Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No spawn point available for NPC.");
            }
        }
    }

    Transform PickRandomSpawnPoint()
    {
        List<GameObject> availableSpawnPoints = new List<GameObject>();

        foreach (GameObject spawnPoint in SpawnPoints)
        {
            if (!spawnCooldowns.ContainsKey(spawnPoint) || Time.time - spawnCooldowns[spawnPoint] >= SpawnpointCooldown)
            {
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        if (availableSpawnPoints.Count == 0) return null;

        GameObject selectedSpawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        spawnCooldowns[selectedSpawnPoint] = Time.time;

        return selectedSpawnPoint.transform;
    }

    void Update()
    {
    }
}
