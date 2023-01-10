using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public ParticleSystem fog, fire_fog;
    public GameObject bullet, gun, player, fire_bullet, fire_gun ;
    public Transform Bullet_shootPoint, fire_shooting_point;

    private ParticleSystem f;
    private Animator anim;
    
    float bulletSpeed = 1000f;
    bool is_shooting = false , is_shoot_anim = false;
    bool flip_bull = false;
    
    
    GameObject bulletInst;
    GameObject bullet_ref;
    Vector2 direction;
    Transform shoot_point;
    private void Start()
    {
        anim = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (is_shooting == false && gun.active == true || fire_gun.active == true)
            {
                animation();
                if (is_shoot_anim == true)
                {
                    Invoke("shoot", 0f);
                }
                else
                {
                    Invoke("shoot", 0.5f);
                }
                is_shooting = true;
                is_shoot_anim = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.S)) 
        {
            is_shooting = false;
            is_shoot_anim = false;
        }
        
    }
    private void animation()
    {
        anim.SetBool("shoot", true);
        anim.SetBool("idleAnime", false);
        anim.SetBool("RunAnime", false); ;
        anim.SetBool("jump", false);
    }

    public void StopShootAnimation()
    {
        anim.SetBool("shoot", false);
        anim.SetBool("idleAnime", true);
        anim.SetBool("RunAnime", false); ;
        anim.SetBool("jump", false);
    }
    private void shoot()
    {
        
        if (gun.active == true)
        {
            bullet_ref = bullet;
            shoot_point = Bullet_shootPoint;
            f = fog;
        }
        else if (fire_gun.active == true)
        {
            bullet_ref = fire_bullet;
            shoot_point = fire_shooting_point;
            f = fire_fog;
        }
        float val = 1;
        if(player.transform.localScale.x <0f)
        {
            val = -1;
            if (flip_bull == false)
            {
                bullet_ref.transform.localScale = -bullet_ref.transform.localScale;
                flip_bull = true;
            }
        }
        else
        {
            flip_bull = false;
        }
        bulletInst = Instantiate(bullet_ref, shoot_point.position, Quaternion.identity);
        bulletInst.GetComponent<Rigidbody2D>().AddForce(bulletInst.transform.right * bulletSpeed * val);
        f.Play();
    }
}
