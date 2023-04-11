using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefab;
    [SerializeField] private float xMinTransform;
    [SerializeField] private float xMaxTransform;
    [SerializeField] private float yMinTransform;
    [SerializeField] private float yMaxTransform;
    [SerializeField] private float nextObjectSpawn;
    [SerializeField] private float delay = 1.5f;
    

    private void Update()
    {
        if (Time.time >= nextObjectSpawn)
        {
            SpawnerObjects();
            nextObjectSpawn = Time.time + delay;
        }
    }

    private void SpawnerObjects()
    {
        int randomObject = Random.Range(0, objectPrefab.Length);

        float xRandomPosition = Random.Range(xMinTransform,xMaxTransform);
        float yRandomPosition = Random.Range(yMinTransform,yMaxTransform);

        var position = new Vector3(xRandomPosition, yRandomPosition);

        GameObject newObject = Instantiate(objectPrefab[randomObject],position, Quaternion.identity);

    }
}
