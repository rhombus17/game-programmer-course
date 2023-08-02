using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinsCollected;

    [SerializeField] List<AudioClip> _soundEffects;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        CoinsCollected++;

        ScoreSystem.Add(100);
        
        if (_soundEffects.Count == 0)
            GetComponent<AudioSource>().Play();
        else
        {
            int randomIndex = UnityEngine.Random.Range(0, _soundEffects.Count);
            AudioClip clipToPlay = _soundEffects[randomIndex];
            GetComponent<AudioSource>().PlayOneShot(clipToPlay);
        }
    }
}
