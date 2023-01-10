using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBulletDetect : MonoBehaviour
{
    public ParticleSystem blood, blast, explosion;
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "witch" || collision.gameObject.tag == "Player" )
        {
            Renderer spr= this.gameObject.GetComponent<SpriteRenderer>();
            spr.enabled=false;
            blast.Play();
            Invoke("destroyOBJ", 0.1f);
        }
        if(collision.gameObject.tag == "enemy" )
        {
            Renderer spr = gameObject.GetComponent<SpriteRenderer>();
            spr.enabled = false;
            blood.Play();
            Invoke("destroyOBJ", 0.1f);
        }
        if (collision.gameObject.tag == "Fire_bullet")
        {
            Renderer spr = gameObject.GetComponent<SpriteRenderer>();
            spr.enabled = false;
            explosion.Play();
            Invoke("destroyOBJ", 0.1f);
        }
    }
     void destroyOBJ()
    {
        DestroyObject(gameObject);
    }
}
