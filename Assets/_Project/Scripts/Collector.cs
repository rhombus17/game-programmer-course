using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] _collectibles;
    [SerializeField] UnityEvent _onCollectionComplete;

    TMP_Text _remainingCollectiblesText;
    int _curCollected;

    void Awake()
    {
        _remainingCollectiblesText = GetComponentInChildren<TMP_Text>();
        _curCollected = 0;
        UpdateCount();
    }

    void Start()
    {
        foreach (var collectible in _collectibles)
        {
            collectible.OnPickedUp += MarkCollected;
        }
    }

    void MarkCollected()
    {
        _curCollected++;
        UpdateCount();
    }

    void UpdateCount()
    {
        int remainingCollectibles = _collectibles.Length - _curCollected;
        _remainingCollectiblesText?.SetText(remainingCollectibles.ToString());
        
        if (remainingCollectibles > 0)
            return;
        
        // All Gems Collected
        _onCollectionComplete?.Invoke();
    }

    void OnValidate()
    {
        _collectibles = _collectibles.Distinct().ToArray();
    }
}
