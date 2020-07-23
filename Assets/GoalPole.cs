using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoalPole : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D collider;
    [SerializeField] private PlayableDirector playableDirector;
    private PlayerController player;
    private bool walk;
    private bool triggered = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        player = col.collider.GetComponent<PlayerController>();
        if (player && !triggered) 
        {
            triggered = true;
            collider.enabled = false;
            player.enabled = false;
            player.playerRigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
            player.playerRigidbody2D.velocity =  new Vector2(0f, -3f);
            player.SetSlidingDownAnimation(true);
            float duration = (float)playableDirector.duration;
            playableDirector.Play();
            Invoke(nameof(RotatePlayer), 0.5f);
            Invoke(nameof(UnsetSlidingState), 1f);
        }
    }

    void UnsetSlidingState()
    {
        player.transform.right = Vector2.right;
        player.SetSlidingDownAnimation(false);
        player.playerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        player.playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        walk = true;
    }

    void RotatePlayer()
    {
        player.transform.RotateAround(transform.TransformPoint(collider.points[0]), Vector3.up, 180f); //By default it is Space.Self and you do not need to include that value
    }

    private void FixedUpdate()
    {
        if (walk)
        {
            player.Move(1f);
        }
    }
}
