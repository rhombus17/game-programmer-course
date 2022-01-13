using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        // Play flag wave
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Raise");
        // Load new level
    }
}
