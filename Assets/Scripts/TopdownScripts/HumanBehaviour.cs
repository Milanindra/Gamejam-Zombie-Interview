using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private GameObject plr;

    [SerializeField] private float run_distance;

    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, plr.transform.position);

        Vector3 dir_to_plr = transform.position - plr.transform.position;

        if (distance < run_distance)
        {
            transform.Translate(dir_to_plr * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
