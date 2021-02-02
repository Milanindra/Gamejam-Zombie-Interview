using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_SF : MonoBehaviour
{
    float movementSpeed = 2;
    float jumpHight = 7;
    bool grounded;
    private void Update()
    {
        movementSpeed = 2;
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, .5f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -.25f);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
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
