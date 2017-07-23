using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float timeToDeath;

    private void Start()
    {
        Destroy(gameObject, timeToDeath);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }
}