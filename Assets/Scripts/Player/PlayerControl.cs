using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Left()
    {
        _player.PlayerMovement.Direction(Vector3.left);
    }
    public void Right()
    {
        _player.PlayerMovement.Direction(Vector3.right);
    }

    public void Stop()
    {
        _player.PlayerMovement.Direction(Vector3.zero);
    }

    public void Jump()
    {
        _player.Jumping.Jump();
    }
}
