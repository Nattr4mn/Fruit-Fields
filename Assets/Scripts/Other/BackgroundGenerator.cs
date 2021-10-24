using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private float _width, _height;
    [SerializeField] private float _flowSpeed;
    [SerializeField] private GameObject _backgroundSprite;
    [Range(-1, 1)]
    [SerializeField] private int _offsetSignX, _offsetSignY;
    private Vector3 _flowOffset;
    private Vector3 _bgStartPosition, _bgEndPosition;

    private void Start()
    {
        _bgStartPosition = transform.position;
        GenerateBackground(_backgroundSprite);
        _flowOffset.x *= _offsetSignX;
        _flowOffset.y *= _offsetSignY;
        _bgEndPosition = new Vector3(_bgStartPosition.x + _flowOffset.x, _bgStartPosition.y + _flowOffset.y, _bgStartPosition.z);
    }


    private void GenerateBackground(GameObject backgroundSprite)
    {
        var startPosition = new Vector3(transform.position.x - (_width / 2), transform.position.y - (_height / 2), transform.position.z);
        var currentPosition = startPosition;
        var endPosition = new Vector3(transform.position.x + (_width / 2), transform.position.y + (_height / 2), transform.position.z);
        _flowOffset = backgroundSprite.GetComponent<SpriteRenderer>().bounds.size;

        while (currentPosition.y <= endPosition.y)
        { 
            while(currentPosition.x <= endPosition.x)
            {
                Instantiate(backgroundSprite, currentPosition, Quaternion.identity, transform);
                currentPosition.x += _flowOffset.x;
            }
            currentPosition.y += _flowOffset.y;
            currentPosition.x = startPosition.x;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _bgEndPosition, _flowSpeed * Time.deltaTime);
        if(transform.position == _bgEndPosition)
        {
            transform.position = _bgStartPosition;
        }
    }
}
