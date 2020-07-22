using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoalPole : MonoBehaviour
{
    private const float Y_DECREMENT = 0.05f;
    [SerializeField] private Collider2D collider;
    [SerializeField] private PlayableDirector playableDirector;
    private PlayerController player;
    private void OnCollisionEnter2D(Collision2D col)
    {
        collider.enabled = false;
        player = col.collider.GetComponent<PlayerController>();
        player.playerRigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
        player.SetSlidingDownAnimation(true);
        playableDirector.Play();
        Invoke(nameof(UnsetSlidingState), (float)playableDirector.duration);
    }

    void UnsetSlidingState()
    {
        player.SetSlidingDownAnimation(false);
        player.playerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }
}
