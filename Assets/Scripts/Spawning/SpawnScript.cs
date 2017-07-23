using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnOffset;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + spawnOffset, 0.5f);
    }

    public void Spawn()
    {
        GameObject projectile = Instantiate(prefab);
        projectile.transform.position = transform.position + spawnOffset;
    }
}