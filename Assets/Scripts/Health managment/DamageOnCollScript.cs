using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageOnCollScript : MonoBehaviour
{
    public int damageAmount;
    public LayerMask damageLayers;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (damageLayers == (damageLayers | (1 << coll.gameObject.layer)))
        {
            HealthScript health = coll.GetComponent<HealthScript>();
            if (health != null)
                health.TakeDamage(damageAmount);
        }
    }
}