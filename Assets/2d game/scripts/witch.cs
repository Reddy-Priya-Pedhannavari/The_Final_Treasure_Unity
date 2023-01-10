using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witch : MonoBehaviour
{
    public GameObject player,Witch,bone,player_hand;
    public ParticleSystem witch_glow,witch_rise_effect;
    bool near_witch = false,w_fire = false;

    public GameObject witch_bullet;
    public Vector2 m_Offset;
    public Transform witch_fire_bullPos;
    private float m_FireTime = 0.0f, dist;
    int count = 0, bullet_attacked=0;

    private void Start()
    {
        Witch.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        count++;
        dist = player.transform.position.x - Witch.transform.position.x;
        if (near_witch == false)
        {
            if (Mathf.Abs(dist) <= 15f)
            {
                witch_rise_effect.Play();
                Invoke("witch_rise", 0.3f); 
                near_witch = true;
                witch_glow.Play();
                w_fire = true;
            }
        }

        if (w_fire==true)
        {
            if (count == 100)
            {
                if (Time.time > m_FireTime)
                {
                    m_FireTime = Time.time + (float)Random.Range(m_Offset.x, m_Offset.y);
                    GameObject bulletClone = (GameObject)Instantiate(witch_bullet, witch_fire_bullPos.transform.position, witch_fire_bullPos.transform.rotation);
                    bulletClone.GetComponent<Rigidbody2D>().AddForce(-bulletClone.transform.right * 1000f);
                    count = 0;
                }
            }
        }

        if (count == 100)
        {
            count=0;
        }
        if (Mathf.Abs(dist) <= 20f)
        {
            w_fire = true;
        }
        else
        {
            w_fire = false;
        }

        Vector3 player_pos= player.transform.position;
        Vector3 hand_rotate = bone.transform.position;
        float angle= Mathf.Atan2(player_pos.y - hand_rotate.y, player_pos.x - hand_rotate.x) * Mathf.Rad2Deg;
        bone.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }
     
    void witch_rise()
    {
        Witch.transform.LeanScale(Vector3.one, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire_bullet")
        {
            bullet_attacked++;
            if (bullet_attacked == 15)
            {
                witch_rise_effect.Play();
                Invoke("witch_death", 1f);
                bullet_attacked = 0;
            }
        }
    }
    void witch_death()
    {
        Witch.transform.localScale = Vector3.zero;
        Witch.SetActive(false);
        catchHearts.heartsCount = catchHearts.heartsCount + 20;
    }
    

    public void witch_Reset()
    {
        Witch.SetActive(true);
        Witch.transform.localScale = Vector3.zero;
        near_witch = false;
    }
    
}
