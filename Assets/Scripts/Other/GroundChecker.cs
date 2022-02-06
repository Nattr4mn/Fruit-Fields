using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayer;
    [SerializeField] private Vector3 _boxCheckerSize;
    [SerializeField] private Color _color;

    public bool CheckGround()
    {
        var ground = Physics2D.OverlapBox(transform.position, _boxCheckerSize, 0f,~_ignoreLayer);
        if (ground != null)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawCube(transform.position, _boxCheckerSize);
    }
}
