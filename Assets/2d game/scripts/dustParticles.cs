using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustParticles : MonoBehaviour
{
    public ParticleSystem dust;
    public static bool onMove=false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onMove == true)
        {
            if (collision.gameObject.tag == "ground")
            {
                dust.Play();
                onMove = false;
            }
        }
    }
}
