using TMPro;
using UnityEngine;

public class UICoinsCollected : MonoBehaviour
{
    TMP_Text _text;
    int _coinsCollectedDisplay;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
        SetCoinsCollected();
    }

    void Update()
    {
        if (_coinsCollectedDisplay == Coin.CoinsCollected)
            return;
        
        SetCoinsCollected();
    }

    void SetCoinsCollected()
    {
        _coinsCollectedDisplay = Coin.CoinsCollected;
        _text.SetText(_coinsCollectedDisplay.ToString());
    }
}
