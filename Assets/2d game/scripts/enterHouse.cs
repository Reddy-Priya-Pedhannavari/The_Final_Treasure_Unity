using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enterHouse : MonoBehaviour
{
    public GameObject houseBG, Background, clouds, sky;
    public dinoEatMan player_Reset;
    int bullet_count=0,drag_bullet_count=0;
    public bool witch_attacked = false,drag_attack=false;
    public void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "enter")
        {
            Invoke("EnterHouse", 0f);
        }
        if (player.gameObject.tag == "exit")
        {
            Invoke("ExitHouse", 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire_bullet" )
        {
            bullet_count++;
            if (bullet_count == 20)
            {
                witch_attacked = true;
                player_Reset.player_reset();
                ExitHouse(); //reset background
                bullet_count = 0;
            }
            else
            {
                witch_attacked = false;
            }
        }
        if (collision.gameObject.tag == "dragon_bullet" )
        {
            drag_bullet_count++;
            if (drag_bullet_count == 20)
            {
                drag_attack = true;
                player_Reset.player_reset();
                drag_bullet_count = 0;
            }
            else
            {
                drag_attack = false;
            }
        }
    }

    public void EnterHouse()
    {
        houseBG.SetActive(true);
        Background.SetActive(false);
        clouds.SetActive(false);
        sky.SetActive(false);
    }
    

    public void ExitHouse()
    {
        houseBG.SetActive(false);
        Background.SetActive(true);
        clouds.SetActive(true);
        sky.SetActive(true);
    }
}
