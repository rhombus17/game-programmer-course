using TMPro;
using UnityEngine;

public class UICoinsCollected : MonoBehaviour
{
    TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _text.text = Coin.CoinsCollected.ToString();
    }
}
