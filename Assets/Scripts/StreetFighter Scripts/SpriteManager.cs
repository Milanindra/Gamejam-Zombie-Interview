using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform enemy;

    public bool isCrouching;
    public bool isAttacking;
    public bool isBlocking;

    [Header("Sprites")]
    public Sprite idle;
    public Sprite crouching;
    public Sprite blocking;
    public Sprite attacking;
    public Sprite crouchAttacking;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = FindObjectOfType<EnemyTag>().transform;
    }

    private void Update()
    {
        if (enemy.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        spriteRenderer.sprite = idle;

        if (isCrouching)
        {
            if (isAttacking)
                spriteRenderer.sprite = crouchAttacking;
            else
                spriteRenderer.sprite = crouching;
        }
        else
        {
            if (isAttacking)
                spriteRenderer.sprite = attacking;
            else if (isBlocking)
                spriteRenderer.sprite = blocking;
        }
    }
}
