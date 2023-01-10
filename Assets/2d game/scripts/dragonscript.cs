using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonscript : MonoBehaviour
{
    public GameObject player, dragon;
    public ParticleSystem dragon_rise_effect;
    bool near_dragon = false, d_fire = false;
    public dinoEatMan player_Reset;
    public GameObject dragon_bullet;
    public Vector2 m_Offset;
    public Transform dragon_fire_bullPos;
    private float m_FireTime = 0.0f, dist;
    int count = 0, bullet_attacked = 0;
    public int collideCount = 0;
    private int bullet_count = 0;
    public bool dragAttack = false;
    public GameObject treasure;
    // Start is called before the first frame update
    void Start()
    {
        dragon.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        dist = player.transform.position.x - dragon.transform.position.x;
        if (near_dragon == false)
        {
            if (Mathf.Abs(dist) <= 15f)
            {
                dragon_rise_effect.Play();
                Invoke(nameof(dragon_rise), 0.3f);
                near_dragon = true;
                d_fire = true;
            }
        }
        if (d_fire == true)
        {
            if (count == 100)
            {
                if (Time.time > m_FireTime)
                {
                    m_FireTime = Time.time + (float)Random.Range(m_Offset.x, m_Offset.y);
                    GameObject bulletClone = (GameObject)Instantiate(dragon_bullet, dragon_fire_bullPos.transform.position, Quaternion.identity);
                    bulletClone.GetComponent<Rigidbody2D>().AddForce(-bulletClone.transform.right * 1000f);
                    count = 0;
                }
            }
        }
        if (count == 100)
        {
            count = 0;
        }
        if (Mathf.Abs(dist) <= 20f)
        {
            d_fire = true;
        }
        else
        {
            d_fire = false;
        }
    }

    void dragon_rise()
    {
        dragon.transform.LeanScale(new Vector3(4f, 4f, 4f), 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire_bullet")
        {
            bullet_attacked++;
            if (bullet_attacked == 15)
            {
                dragon_rise_effect.Play();
                Invoke(nameof(dragon_death), 1f);
                bullet_attacked = 0;
            }
        }
        
        if (collision.gameObject.tag == "Player")
        {
            collideCount++;
            if (collideCount == 10)
            {
                dragAttack = true;
                player_Reset.player_reset();
            }
            else
            {
                dragAttack = false;
            }

            /*bullet_count++;
            if (bullet_count == 10)
            {
                dragAttack = true;
                player_Reset.player_reset();
                bullet_count = 0;
            }
            else
            {
                dragAttack = false;
            }*/
        }
    }

    void dragon_death()
    {
        catchHearts.heartsCount = catchHearts.heartsCount + 30;
        dragon.SetActive(false);
        treasure.SetActive(true);
    }

    public void Dragon_Reset()
    {
        dragon.transform.localScale = Vector3.zero;
        dragon.SetActive(true);
        treasure.SetActive(false);
        near_dragon = false;
    }
}
