using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float _wiggleStrength;
    bool _playerInside;
    HashSet<Player> _playersInTrigger = new HashSet<Player>();
    Coroutine _coroutine;
    Transform _transform;
    Vector3 _startPostion;

    void Start()
    {
        _transform = transform;
        _startPostion = _transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Add(player);

        _playerInside = true;

        if (_playersInTrigger.Count == 1)
            _coroutine = StartCoroutine(WiggleAndFall());
    }

    IEnumerator WiggleAndFall()
    {
        // Wait to wiggle
        yield return new WaitForSeconds(0.25f);
        // Wiggle
        float wiggleTimer = 0f;
        while (wiggleTimer < 1f)
        {
            float min = _wiggleStrength / 100f * -1f;
            float max = _wiggleStrength / 100f;
            float randX = UnityEngine.Random.Range(min, max);
            float randY = UnityEngine.Random.Range(min, max);
            _transform.position = _startPostion + new Vector3(randX, randY);
            float randDelay = UnityEngine.Random.Range(0.005f, 0.01f);
            yield return new WaitForSeconds(randDelay);
            wiggleTimer += randDelay;
        }
        // yield return new WaitForSeconds(1f);
        // Fall
        Debug.Log($"Falling");
        yield return new WaitForSeconds(3f);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;
            
        _playersInTrigger.Remove(player);

        if (_playersInTrigger.Count == 0)
        {
            _playerInside = false;
            StopCoroutine(_coroutine);
        }
    }
}
