using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject cannonBall;
    Rigidbody2D rb;
    BoxCollider2D bx;

    void Start()
    {
        rb = cannonBall.GetComponent<Rigidbody2D>();
        bx = cannonBall.GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }

    }
}
