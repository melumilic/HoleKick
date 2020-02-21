using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRay : MonoBehaviour
{
    void Update()
    {
        interact();
    }
    void interact()
    {
        if (InputManager.instance.GetKeyDown(KeybindingActions.Interact))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 500))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log("hit: " + hit.collider.name);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}
