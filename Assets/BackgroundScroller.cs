using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
public class BackgroundScroller : MonoBehaviour
{
    public float scroll_speed = 2.0f;

    gameManager gm;
    BoxCollider2D collider;
    float width;
    Vector2 reset_position;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();

        collider = GetComponent<BoxCollider2D>();

        width = collider.size.x * transform.localScale.x;
        collider.enabled = false;
        reset_position = new Vector2(width * 2f, 0);
    }

    void Update()
    {
        if(gm != null)
        {
            if(!gm.game_over)
            {
                transform.Translate(Vector2.left * scroll_speed * Time.deltaTime);
            }
        }

        if(transform.position.x < -width)
            transform.position = (Vector2)transform.position + reset_position;
    }
}
