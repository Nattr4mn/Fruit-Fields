using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private float _visionDistance;
    [SerializeField] private LayerMask _triggerMask;

    public bool DetectEnemy(Vector2 direction)
    {
        var hit = Physics2D.Raycast(transform.position, direction, _visionDistance, _triggerMask);
        if (hit)
        {
            if (hit.collider.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            return true;
        }    

        return false;
    }

    private void OnDrawGizmos()
    {
        var right = transform.right * _visionDistance;
        var left = -right;

        Gizmos.DrawRay(transform.position, left);
        Gizmos.DrawRay(transform.position, right);
    }
}
