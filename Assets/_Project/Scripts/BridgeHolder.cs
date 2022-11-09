using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHolder : MonoBehaviour
{
    [SerializeField] GameObject _bridge;
    [SerializeField] BridgeHolder _other;
    public bool isEnabled;
    public bool bridgeEnabled;

    SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        TurnOn();
        bridgeEnabled = true;
    }

    public void TurnOff()
    {
        isEnabled = false;
        _renderer.enabled = false;

        if (bridgeEnabled && _other.isEnabled == false)
        {
            DropBridge();
            _other.bridgeEnabled = false;
        }
    }

    public void TurnOn()
    {
        isEnabled = true;
        _renderer.enabled = true;
    }

    void DropBridge()
    {
        _bridge.SetActive(false);
        bridgeEnabled = false;
    }
}
