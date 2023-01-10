using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rd;
    public GameObject player;
    public static bool isground;
    private void Start()
    {
        anim = player.GetComponent<Animator>();
        rd = player.GetComponent<Rigidbody2D>();
        isground = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "dragon")
        {
            isground = false;
            anim.SetBool("idleAnime", true);
            anim.SetBool("jump", false);
            anim.SetBool("RunAnime", false);
        }
    }
    void Update()
    {
        if (playerMoves.startGamebool == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isground == false)
                {
                    rd.velocity = Vector2.up * 10f;
                    anim.SetBool("jump", true);
                    anim.SetBool("RunAnime", false);
                    anim.SetBool("idleAnime", false);
                    isground = true;
                    dustParticles.onMove = true;
                }
            }
        }
    }
}
