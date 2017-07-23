using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public int maxHealth;
    public UnityEvent onDeath;
    public UnityEvent onDamage;
    public HealthDrawScript healthDraw;
    
    private int currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }

   

    public void TakeDamage(int amount)
    {
        if (currHealth > 0)
        {
            onDamage.Invoke();
            currHealth -= amount;
            if (currHealth <= 0)
            {
                onDeath.Invoke();
                Destroy(gameObject);
            }
            else if(healthDraw != null)
            {
                healthDraw.ChangeHealthState((float)currHealth / maxHealth);
            }
        }
    }
}
