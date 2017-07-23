using UnityEngine;

public class MoveLikeInvadersScript : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;

    public float xMin;
    public float xMax;

    private Vector3 target;

    private void Start()
    {
        target = new Vector3(xMax, transform.position.y, 0);
    }

    private void Update()
    {
        Vector3 dir = target - transform.position;
        float deltaSpeed = xSpeed * Time.deltaTime;
        if(dir.sqrMagnitude > deltaSpeed * deltaSpeed)
        {
            transform.Translate(dir.normalized * deltaSpeed);
        }
        else
        {
            target.y -= ySpeed;
            transform.position = target;
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        target.x = target.x == xMin ? xMax : xMin;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(xMax, transform.position.y, 0), 0.5f);
        Gizmos.DrawWireSphere(new Vector3(xMin, transform.position.y, 0), 0.5f);
    }
}
