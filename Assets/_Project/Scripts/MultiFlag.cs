using UnityEngine;

public class MultiFlag : MonoBehaviour
{
    [Range(1,2)]
    [SerializeField] int _playerRequiredNumber;
    [SerializeField] LevelManager _levelManager;
    static readonly int Raise = Animator.StringToHash("Raise");

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;

        if (player.PlayerNumber != _playerRequiredNumber)
            return;

        // Play flag wave
        Animator animator = GetComponent<Animator>();
        animator.SetBool(Raise, true);

        _levelManager.SetComplete(_playerRequiredNumber, true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;

        if (player.PlayerNumber != _playerRequiredNumber)
            return;
        
        // Play flag wave
        Animator animator = GetComponent<Animator>();
        animator.SetBool(Raise, false);
        
        _levelManager.SetComplete(_playerRequiredNumber, false);
    }
}
