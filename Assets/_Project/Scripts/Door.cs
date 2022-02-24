using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite _openMid;
    [SerializeField] Sprite _openTop;
    [SerializeField] SpriteRenderer _rendererMid;
    [SerializeField] SpriteRenderer _rendererTop;

    void Open()
    {
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
