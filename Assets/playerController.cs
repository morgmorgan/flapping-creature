using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playerController : MonoBehaviour
{
    public gameManager game_manager;
    public float force_modifier = 300;

    public AudioClip flap_sound;
    public AudioClip death_sound;

    bool is_dead = false;

    Animator anim;
    Rigidbody2D rb;
    //settingsScript gameSettings;
    AudioSource audio_player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //gameSettings = GameObject.Find("GameSettings").GetComponent<settingsScript>();
        audio_player = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Player Input
        if(Input.GetMouseButtonDown(0) && !is_dead)
        {
            rb.AddForce(Vector2.up * force_modifier);
            audio_player.PlayOneShot(flap_sound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for obstacle collision
        if (collision.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Dead!");
            //if(gameSettings.sound_on)
            if (!is_dead)
                audio_player.PlayOneShot(death_sound);
            anim.SetTrigger("hit_obstacle");
            is_dead = true;
            game_manager.gameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point_zone")
        {
            game_manager.addPoint();
        }
    }
}
