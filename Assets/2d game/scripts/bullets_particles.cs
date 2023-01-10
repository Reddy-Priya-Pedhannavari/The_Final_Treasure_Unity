using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets_particles : MonoBehaviour
{
    public ParticleSystem blood, blast;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "witch" || collision.gameObject.tag == "dragon")
        {
            Renderer spr = this.gameObject.GetComponent<SpriteRenderer>();
            spr.enabled = false;
            Invoke("destroyOBJ", 0.1f);
            blast.Play();
        }
        if (collision.gameObject.tag == "enemy")
        {
            Renderer spr = gameObject.GetComponent<SpriteRenderer>();
            spr.enabled = false;
            Invoke("destroyOBJ", 0.1f);
            blood.Play();
        }
    }
    void destroyOBJ()
    {
        DestroyObject(gameObject);
    }
}
