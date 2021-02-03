using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_SF : MonoBehaviour
{
    float movementSpeed = 2;
    float jumpHight = 7;
    bool grounded;
    Vector2 originalColliderSize;
    BoxCollider2D collider;
    SpriteManager spriteManager;

    private void Start()
    {
        spriteManager = GetComponent<SpriteManager>();
        collider = GetComponent<BoxCollider2D>();
        originalColliderSize = collider.size;
    }
    private void Update()
    {
        movementSpeed = 2;
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            spriteManager.isCrouching = true;
            collider.size = new Vector2(originalColliderSize.x, originalColliderSize.y / 2);
        }
        else
        {
            spriteManager.isCrouching = false;
            collider.size = originalColliderSize;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHight, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
