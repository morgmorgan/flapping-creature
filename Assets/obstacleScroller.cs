using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScroller : MonoBehaviour
{
    public float scroll_speed = 2.0f;
    public float kill_position_x = -12.5f;

    gameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
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
        

        if (transform.position.x < kill_position_x)
            Destroy(this.gameObject);
    }
}
