using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float _shakeX;
    [SerializeField] float _shakeY;
    [Tooltip("Resets the shake timer when no players are on the platform")]
    [SerializeField] bool _resetShakeTimerOnEmpty;
    [Range(0.1f, 5f)] [SerializeField] float _fallAfterSeconds;
    [SerializeField] float _fallSpeed;
    bool _playerInside;
    bool _isFalling = false;
    HashSet<Player> _playersInTrigger = new HashSet<Player>();
    Coroutine _coroutine;
    Transform _transform;
    Vector3 _startPostion;
    float _wiggleTimer;

    void Start()
    {
        _transform = transform;
        _startPostion = _transform.position;
        _isFalling = false;
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
        // float wiggleTimer = 0f;
        while (_wiggleTimer < _fallAfterSeconds)
        {
            // float min = _wiggleStrength / 100f * -1f;
            // float max = _wiggleStrength / 100f;
            float randX = UnityEngine.Random.Range(-_shakeX / 100f, _shakeX / 100f);
            float randY = UnityEngine.Random.Range(-_shakeY / 100f, _shakeY / 100f);
            _transform.position = _startPostion + new Vector3(randX, randY);
            float randDelay = UnityEngine.Random.Range(0.005f, 0.01f);
            yield return new WaitForSeconds(randDelay);
            _wiggleTimer += randDelay;
        }

        // Fall
        _isFalling = true;
        var colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }

        float fallTimer = 0f;
        while (fallTimer < 3f)
        {
            _transform.position += Vector3.down * Time.deltaTime * _fallSpeed;
            fallTimer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (_isFalling)
            return;

        var player = other.GetComponent<Player>();
        if (player == null)
            return;
            
        _playersInTrigger.Remove(player);

        if (_playersInTrigger.Count == 0)
        {
            _playerInside = false;
            StopCoroutine(_coroutine);

            _transform.position = _startPostion;

            if (_resetShakeTimerOnEmpty)
            {
                _wiggleTimer = 0f;
            }
        }
    }
}
