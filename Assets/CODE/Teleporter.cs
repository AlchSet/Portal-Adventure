using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public Vector2 offset;


    public UnityEvent OnTeleport;

    // Start is called before the first frame update
   public Vector2 GetDestination()
    {
        OnTeleport.Invoke();
        return (Vector2)destination.position + offset;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, (Vector2)destination.position+offset);
    }
}
