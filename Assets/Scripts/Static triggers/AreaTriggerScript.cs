using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class AreaTriggerScript : MonoBehaviour
{
    public LayerMask interactLayers;
    public UnityEvent OnEnter;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (interactLayers == (interactLayers | (1 << coll.gameObject.layer)))
        {
            OnEnter.Invoke();
        }
    }
}