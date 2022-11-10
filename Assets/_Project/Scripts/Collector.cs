using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] _collectibles;

    TMP_Text _remainingCollectiblesText;
    int _curCount;

    void Awake()
    {
        _remainingCollectiblesText = GetComponentInChildren<TMP_Text>();
        UpdateCount(_collectibles.Length);
    }

    void Update()
    {
        var newCount = 0;
        foreach (var collectible in _collectibles)
        {
            if (collectible.isActiveAndEnabled)
                newCount++;
        }

        if (newCount != _curCount)
            UpdateCount(newCount);

        if (newCount > 0)
            return;
        
        // All Gems Collected
    }

    void UpdateCount(int newCount)
    {
        _curCount = newCount;
        _remainingCollectiblesText?.SetText(newCount.ToString());
    }

    void OnValidate()
    {
        _collectibles = _collectibles.Distinct().ToArray();
    }
}
