using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObstacleScript : MonoBehaviour
{
    public LayerMask projectileLayers;
    public LayerMask enemyLayers;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (projectileLayers == (projectileLayers | (1 << coll.gameObject.layer)))
        {
            Destroy(coll.gameObject);
        }
        else if (enemyLayers == (enemyLayers | (1 << coll.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
