using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting_SF : MonoBehaviour
{
    bool blocking;
    public GameObject attack;
    SpriteManager spriteManager;
    BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spriteManager = GetComponent<SpriteManager>();
    }
    void Update()
    {
        blocking = false;

        if (Input.GetKeyDown(KeyCode.E))
        {
            spriteManager.isAttacking = true;
            spriteManager.isBlocking = false;
            collider.offset = new Vector2(-.3f, 0);
            Instantiate(attack, transform.position, Quaternion.identity, transform);
        }
        else if (Input.GetKey(KeyCode.Q) && !spriteManager.isCrouching && !spriteManager.isAttacking)
        {
            collider.offset = new Vector2(0, 0);
            spriteManager.isBlocking = true;
            blocking = true;
        }
        else
        {
            spriteManager.isBlocking = false;
        }

        
    }
}
