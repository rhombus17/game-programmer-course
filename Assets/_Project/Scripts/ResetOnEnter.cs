using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (player == null)
            return;
        player.ResetToStart();
    }
}
