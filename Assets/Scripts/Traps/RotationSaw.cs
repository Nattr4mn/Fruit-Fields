using UnityEngine;

public class RotationSaw : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _chain;
    [SerializeField] private float _chainLegth;
    [SerializeField] private GameObject _saw;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        var chainSize = _chain.size.y;
        var chainPosition = _chain.transform.position;
        for(int i = 0; i < _chainLegth; i++)
        {
            chainPosition.y -= chainSize;
            Instantiate(_chain, chainPosition, Quaternion.identity,transform);
        }
        _saw.transform.position = chainPosition;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        var chainSize = _chain.size.y;
        var to = Vector3.down;
        to.y *= chainSize * _chainLegth;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, to);
    }
}
