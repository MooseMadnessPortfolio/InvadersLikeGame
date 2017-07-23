using UnityEngine;

[RequireComponent(typeof(CannonScript))]
public class InputHandlerScript : MonoBehaviour
{
    private CannonScript cannon;

    private void Awake()
    {
        cannon = GetComponent<CannonScript>();
    }

    private void Update()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cannon.SetPosition(mouseWorldPos.x);

        if(Input.GetButton("Fire1"))
        {
            cannon.Fire();
        }
    }
}