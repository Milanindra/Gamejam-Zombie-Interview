using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{

    BoxCollider2D collider2D;
    float hitSpeed = 25;
    private void Start()
    {
        collider2D = GetComponentInChildren<BoxCollider2D>();

        StartCoroutine(Resize());
    }

    IEnumerator Resize()
    {
        while (collider2D.size.x < 5)
        {
            collider2D.size += new Vector2(hitSpeed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        while (collider2D.size.x > 1)
        {
            collider2D.size -= new Vector2(hitSpeed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        GetComponentInParent<SpriteManager>().isAttacking = false;
        GetComponentInParent<BoxCollider2D>().offset = new Vector2(0, 0);
        Destroy(gameObject);
    }
}
