using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcManager : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public List<GameObject> CarOptions;
    public List<GameObject> Active;

    public int SpawnCount = 4;

    void Start()
    {

    }

    IEnumerator SpawnCar()
    {
        var randomOffset = Random.insideUnitCircle;

        Instantiate(CarOptions[Random.Range(0, CarOptions.Count)],
                    SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position + (Vector3)randomOffset,
                    Quaternion.identity
                    );

        yield return new WaitForSeconds(1f);
    }

    void Update()
    {
        StartCoroutine(SpawnCar());
    }
}
