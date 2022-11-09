using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecker : MonoBehaviour
{
    [SerializeField] Animator _green;
    [SerializeField] Animator _blue;

    [SerializeField] bool _logData;

    // Update is called once per frame
    void Update()
    {
        if (!_logData) return;

        float greenOffset = _green.GetFloat("Offset");
        float blueOffset = _blue.GetFloat("Offset");

        float greenCurCyclePosition = _green.GetCurrentAnimatorStateInfo(0).normalizedTime;
        float blueCurCyclePosition = _blue.GetCurrentAnimatorStateInfo(0).normalizedTime;

        float greenAnimationPoint = (greenOffset + greenCurCyclePosition) % 1f;
        float blueAnimationPoint = (blueOffset + blueCurCyclePosition) % 1f;
        
        Debug.Log($"{Time.time} : {greenAnimationPoint}, {blueAnimationPoint}");
    }
}
