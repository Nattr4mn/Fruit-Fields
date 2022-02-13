using UnityEngine;

public class Vision : MonoBehaviour
{
    private float _visionDistance;
    private LayerMask _triggerMask;

    public float VisionDistance => _visionDistance;

    public void Init(float vosionDistance, LayerMask triggerMask)
    {
        _visionDistance = vosionDistance;
        _triggerMask = triggerMask;
    }

    public bool DetectEnemy(Vector2 direction)
    {
        direction = transform.TransformDirection(direction);
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
}
