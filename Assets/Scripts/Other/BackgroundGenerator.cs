using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _flowSpeed;
    [SerializeField] private SpriteRenderer _background;
    [Range(-1, 1)]
    [SerializeField] private int _offsetSignX, _offsetSignY;
    private Transform _bgStartPosition;
    private Vector3 _bgEndPosition;
    private Vector3 _bgSpriteSize;

    private void Start()
    {
        _bgStartPosition = _camera.transform;
        GenerateBackground(_background);
    }

    public void Init(SpriteRenderer background, int offsetSignX, int offsetSignY)
    {
        _background = background;
        _offsetSignX = offsetSignX;
        _offsetSignY = offsetSignY;
    }

    private void GenerateBackground(SpriteRenderer background)
    {
        _bgSpriteSize = background.bounds.size;
        var cameraPositionInWorld = _camera.ScreenToWorldPoint(new Vector2(0, 0));
        var startPosition = new Vector3(cameraPositionInWorld.x - _bgSpriteSize.x, cameraPositionInWorld.y - _bgSpriteSize.y, transform.position.z);

        cameraPositionInWorld = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, _camera.pixelHeight));
        var endPosition = new Vector3(cameraPositionInWorld.x + 2f * _bgSpriteSize.x, cameraPositionInWorld.y + 2f * _bgSpriteSize.y, transform.position.z);
        var currentPosition = startPosition;

        while (currentPosition.y <= endPosition.y)
        { 
            while(currentPosition.x <= endPosition.x)
            {
                Instantiate(background, currentPosition, Quaternion.identity, transform);
                currentPosition.x += _bgSpriteSize.x;
            }

            currentPosition.y += _bgSpriteSize.y;
            currentPosition.x = startPosition.x;
        }
    }

    private void Update()
    {
        _bgEndPosition = SetEndPosition();
        transform.position = Vector3.MoveTowards(transform.position, _bgEndPosition, _flowSpeed * Time.deltaTime);
        if (transform.position == _bgEndPosition)
        {
            transform.position = SetStartPosition();
        }
    }

    private Vector3 SetStartPosition()
    {
        var startPosition = _bgStartPosition.position;
        startPosition.z = transform.position.z;
        return startPosition;
    }

    private Vector3 SetEndPosition()
    {
        return new Vector3(_bgStartPosition.position.x + _offsetSignX * _bgSpriteSize.x, 
                            _bgStartPosition.position.y + _offsetSignY * _bgSpriteSize.y, 
                            transform.position.z);
    }
}
