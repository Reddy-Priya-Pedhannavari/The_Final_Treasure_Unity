using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoves : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    private float speed;
    bool facingright = true;
    private Vector3 flip;
    private Animator anim;
    public static bool startGamebool = false;

    void Start()
    {
        speed = 8f;
        anim = player.GetComponent<Animator>();
        flip = player.transform.localScale;
    }

    private void Update()
    {
        if (startGamebool == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (player.transform.position.x == mainCamera.transform.position.x)
                {
                    player.transform.position += Vector3.left * speed * Time.deltaTime;
                    mainCamera.transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else
                {
                    mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
                anim.SetBool("RunAnime", true);
                anim.SetBool("idleAnime", false);

                if (facingright == true)
                {
                    flip.x = -flip.x;
                }
                player.transform.localScale = flip;

                facingright = false;

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (player.transform.position.x == mainCamera.transform.position.x)
                {
                    mainCamera.transform.position += Vector3.right * speed * Time.deltaTime;
                    player.transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else
                {
                    mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
                flip.x = Mathf.Abs(flip.x);
                player.transform.localScale = flip;
                facingright = true;
                anim.SetBool("RunAnime", true);
                anim.SetBool("idleAnime", false);

            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("RunAnime", false);
                anim.SetBool("shoot", false);

            }
        }
    }
}
