using UnityEngine;

public class Quicksand : MonoBehaviour
{
    [SerializeField] private float _gravityScaleMultiply = 20f;
    [SerializeField] private Rigidbody2D _playerRB;
    private bool _use = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(!_use)
            {
                _playerRB.gravityScale *= _gravityScaleMultiply;
                _use = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_use)
            {
                _playerRB.gravityScale /= _gravityScaleMultiply;
                _use = false;
            }
        }
    }
}
