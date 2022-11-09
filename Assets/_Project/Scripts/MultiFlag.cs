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
        
        // How do I synchronize the flags? If they're playing at speed x,
        /* If they're playing at speed x, then I want to take time % x.
         * Then that m remainder can be used as m / x?
         */
        
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        float clipLength = info.length;
        float remainder = Time.time % clipLength;
        float offset = remainder / clipLength;
        animator.SetFloat("Offset", offset);
        // animator.SetFloat("Offset", 0.5f);
        float off = animator.GetFloat("Offset");
        // Debug.Log($"{Time.time}, {offset}");

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
