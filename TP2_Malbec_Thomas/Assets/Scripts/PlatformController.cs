using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Update()
    {
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        if (rb.transform.position.x < -12)
        {
            Destroy(this.gameObject);
        }
    }
}
