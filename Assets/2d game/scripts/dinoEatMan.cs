using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class dinoEatMan : MonoBehaviour
{
    //public GameObject DinoBone_9;
    public GameObject player,player_hand,player_palm, dinoBone, dino, sword, gun, fire_gun, mount, cloud;
    public king k;
    public dragonscript dragScript;
    public enterHouse house;
    public Text lifeText;
    public Image gameOver;
    //public Rigidbody2D rd;
    public GameObject blood,dinoBlood;

    private static int count = 0, bull_count=0,fire_bull=0;
    public static int lifeCount=0;
    private Animator dinoanim,anim;
    private Vector3 dinoPos, playerpos, camerapos;
    private bool DinoAttackMan = false;
    private int collideCount = 0;

    Renderer rd,hd,palm;
    private void Start()
    {
        //rd = player.GetComponent<Rigidbody2D>();
        blood.transform.localScale = Vector3.zero;
        dinoBlood.transform.localScale = Vector3.zero;
        dinoanim = dino.GetComponent<Animator>();
        anim = player.GetComponent<Animator>();
        lifeCount = 3;

        dinoPos = dino.transform.position;
        camerapos = k.mainCamera.transform.position;
        playerpos = player.transform.position;

        rd = player.GetComponent<SpriteRenderer>();
        hd = player_hand.GetComponent<SpriteRenderer>();
        palm = player_palm.GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            bull_count++;
            if (bull_count == 10)
            {
                dinoDeath();
                bull_count = 0;
            }
        }
        if (collision.gameObject.tag == "Fire_bullet")
        {
            fire_bull++;
            if (fire_bull == 5)
            {
                dinoDeath();
                fire_bull = 0;
            }
        }
        if (collision.gameObject.tag == "sword")
        {
            count++;
            if (count == 10)
            {
                dinoDeath();
                count = 0;
            }
        }
        if (collision.gameObject.tag == "Player" )
        {
            collideCount++;
            if (collideCount == 10)
            {
                Invoke("player_reset", 0f);
            }
        }
        
    }
    public void player_reset()
    {
        if (DinoAttackMan == false )
        {
            if(house.witch_attacked == false)
            {
                if(house.drag_attack == false)
                {
                    player.transform.position = dinoBone.transform.position;
                    player.transform.Rotate(0f, 0f, 40f);
                    blood.transform.LeanScale(Vector3.one, 1f);
                    Vector3 bloodpos = blood.transform.position;
                    blood.transform.position = new Vector3(player.transform.position.x, -2.8f, bloodpos.z);
                }
            }
            
            Invoke("playerDisabled", 0.5f);
            if (lifeCount <= 3 && lifeCount > 0)
            {
                Invoke(nameof(reset), 1.5f);
                lifeCount--;
                lifeText.text = lifeCount.ToString();
                DinoAttackMan = true;

            }
            if (lifeText.text == "0")
            {
                //Time.timeScale = 0;
                gameOver.transform.localScale = Vector3.zero;
                gameOver.transform.LeanScale(Vector3.one, 0.5f);
                Invoke("timeFreez", 0.6f);
            }
        }
    }
    void playerDisabled()
    {
        //player.SetActive(false);
        rd.enabled = false;
        hd.enabled = false;
        palm.enabled = false;
    }
    
    void dinoDeath()
    {
        king.dinoClose = true;
        dinoanim.SetBool("EatMan", false);
        dinoanim.SetBool("dinoDeath", true);
        dinoanim.SetBool("dinoRun", false);
        dinoanim.SetBool("dinoIdle", false);
        dinoBlood.transform.LeanScale(Vector3.one, 1.5f);
        Invoke("dino_collider", 2f);
        catchHearts.heartsCount= catchHearts.heartsCount + 10;
    }

    void dino_collider()
    {
        dinoBone.GetComponent<Collider2D>().isTrigger = false;
    }
    public void reset()
    {
        player.SetActive(true);
        rd.enabled = true;
        hd.enabled = true;
        palm.enabled = true;
        //k.player.transform.Rotate(0, 0, 0);
        blood.transform.localScale= new Vector3(0f,0f,0f);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        anim.SetBool("idleAnime", true);
        anim.SetBool("RunAnime", false); ;
        anim.SetBool("jump", false);
        player.transform.position = playerpos;
        k.mainCamera.transform.position = camerapos;
        DinoAttackMan = false;
        Invoke("dino_reset", 0f);
    }
    
    void dino_reset()
    {
        dino.transform.position = dinoPos;
        dinoBlood.transform.localScale = Vector3.zero;
        dinoBone.GetComponent<Collider2D>().isTrigger = true;
        king.dinoClose = false;
        collideCount = 0;
        dragScript.collideCount = 0;
    }
    void timeFreez()
    {
        Time.timeScale = 0;
    }
}
