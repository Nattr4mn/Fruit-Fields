using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomize : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _backgrounds;
    [SerializeField] private BackgroundGenerator _generator;

    private void Awake()
    {
        SpriteRenderer background = _backgrounds[Random.Range(0, _backgrounds.Count)];
        int offsetSignX = Random.Range(-1, 1);
        int offsetSignY = Random.Range(-1, 1);

        _generator.Init(background, offsetSignX, offsetSignY);
    }

}
