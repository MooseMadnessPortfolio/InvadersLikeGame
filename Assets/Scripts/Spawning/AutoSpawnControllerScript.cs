using UnityEngine;
using URand = UnityEngine.Random;

[RequireComponent(typeof(SpawnScript))]
public class AutoSpawnControllerScript : MonoBehaviour
{
    public float minSpawnTime;
    public float maxSpawnTime;

    private float timer = 0;
    private float currSpawnTime;
    private SpawnScript spawnScript;

    private void Start()
    {
        currSpawnTime = URand.Range(minSpawnTime, maxSpawnTime);
        spawnScript = GetComponent<SpawnScript>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= currSpawnTime)
        {
            currSpawnTime = URand.Range(minSpawnTime, maxSpawnTime);
            timer = 0;
            spawnScript.Spawn();
        }
    }
}