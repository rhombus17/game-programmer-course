using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public bool multiInput;
    [SerializeField] Player _p1;
    [SerializeField] Player _p2;

    Player _curPlayer;
    Player _otherPlayer;

    [ContextMenu("Switch Player")]
    void SwitchPlayer()
    {
        _curPlayer.DisablePlayer();
        _otherPlayer.EnablePlayer();
        (_curPlayer, _otherPlayer) = (_otherPlayer, _curPlayer);
    }

    void Start()
    {
        if (multiInput)
            return;
        
        _p1.EnablePlayer();
        _curPlayer = _p1;
        _otherPlayer = _p2;

        TutInput.InputActions input = new();
        input.Enable();
        input.P1.Switch.started += SwitchInput;
    }

    void SwitchInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;
        
        SwitchPlayer();
    }

    public void PlayWinCelebration()
    {
        _p1.PlayWinAnimation();
        _p2.PlayWinAnimation();
    }
    
    
}
