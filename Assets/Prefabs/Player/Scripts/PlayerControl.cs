using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Left()
    {
        _player.Movement.Direction(Vector3.left);
    }
    public void Right()
    {
        _player.Movement.Direction(Vector3.right);
    }

    public void Move()
    {
        _player.Movement.TryMove();
    }

    public void Stop()
    {
        _player.Movement.Direction(Vector3.zero);
    }

    public void Jump()
    {
        _player.Jump.Jump();
    }
}
