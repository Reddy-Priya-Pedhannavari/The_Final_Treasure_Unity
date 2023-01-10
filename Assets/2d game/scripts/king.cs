using System.Collections;
using System.Collections.Generic;
using UnityEngine;           

public class king : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player,dino;
    public GameObject mountains,clouds;
    private float speed, cloudspeed;
    public Vector2 mountPos, cloudpos,mountstartPos,closdstartPos;
    public static bool dinoClose=false;
    private Animator anim,dinoAnim;
    bool facingright=true;
    private Vector3 flip;
    float dis;
    bool dinoFlip = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        cloudspeed = 2f;
        //mountPos = mountains.transform.position;
        //cloudpos = clouds.transform.position;
        anim = player.GetComponent<Animator>();
        dinoAnim = dino.GetComponent<Animator>();
        flip = player.transform.localScale;
        mountstartPos = mountPos;
        closdstartPos = cloudpos;
    }

    void Update()
     {
        if (playerMoves.startGamebool == true)
        {

            dis = Vector2.Distance(player.transform.position, dino.transform.position);


            if (dis < 30f)
            {

                if (dinoClose == false)
                {
                    Vector3 dino_flip = dino.transform.localScale;

                    if (dino.transform.position.x >= player.transform.position.x)
                    {

                        if (Mathf.Abs(dino.transform.position.x - player.transform.position.x) > 10f)
                        {
                            dino_flip.x = Mathf.Abs(dino_flip.x);
                            dino.transform.localScale = dino_flip;
                            dinoFlip = false;
                            dino.transform.position += Vector3.left * 5f * Time.deltaTime;
                        }
                    }
                    else if (dino.transform.position.x < player.transform.position.x)
                    {
                        if (Mathf.Abs(dino.transform.position.x - player.transform.position.x) > 10f)
                        {
                            if (dinoFlip == false)
                            {
                                dino_flip.x = -dino_flip.x;
                                dino.transform.localScale = dino_flip;
                                dinoFlip = true;
                            }
                            dino.transform.position += Vector3.right * 5f * Time.deltaTime;
                        }
                    }


                    dinoAnim.SetBool("EatMan", true);
                    dinoAnim.SetBool("dinoRun", false);
                    dinoAnim.SetBool("dinoIdle", false);
                    dinoAnim.SetBool("dinoDeath", false);
                    //Debug.Log("eat man");
                }

                //Vector2 dinoMove = new Vector2(dino.transform.position.x - 0.5f, dino.transform.position.y);
                //dino.transform.position = dinoMove*Time.deltaTime;
                //Debug.Log("dino eat anime");   
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {

                //float newpos = Mathf.Repeat(speed, 182)*Time.deltaTime;
                float newpos2 = Mathf.Repeat(cloudspeed, 100) * Time.deltaTime;
                //mountains.transform.position = mountPos + Vector2.right * newpos;
                //clouds.transform.position = cloudpos + Vector2.right * newpos2;
                if (player.transform.position.x == mainCamera.transform.position.x)
                {
                    player.transform.position += Vector3.left * speed * Time.deltaTime;
                    clouds.transform.position = cloudpos + Vector2.right * newpos2;
                    mainCamera.transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else
                {
                    mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
                if (jumpScript.isground == false)
                {
                    anim.SetBool("RunAnime", true);
                    anim.SetBool("idleAnime", false);
                }
                // anim.SetBool("jump", false);
                if (dinoClose == false)
                {
                    dinoAnim.SetBool("dinoRun", true);
                    dinoAnim.SetBool("dinoIdle", false);
                    dinoAnim.SetBool("EatMan", false);
                    dinoAnim.SetBool("dinoDeath", false);

                }
                if (facingright == true)
                {
                    flip.x = -flip.x;
                }
                player.transform.localScale = flip;

                facingright = false;
                //player.transform.position = new Vector3(8f, pos.y, 0);

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {

                //float newpos = Mathf.Repeat( speed, 182) * Time.deltaTime;
                float newpos2 = Mathf.Repeat(cloudspeed, 100) * Time.deltaTime;
                //mountains.transform.position = mountPos + Vector2.left * newpos;
                //clouds.transform.position = cloudpos + Vector2.left * newpos2;
                if (player.transform.position.x == mainCamera.transform.position.x)
                {
                    mainCamera.transform.position += Vector3.right * speed * Time.deltaTime;
                    clouds.transform.position = cloudpos + Vector2.left * newpos2;
                    player.transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else
                {
                    mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
                flip.x = Mathf.Abs(flip.x);
                player.transform.localScale = flip;
                facingright = true;
                if (jumpScript.isground == false)
                {
                    anim.SetBool("RunAnime", true);
                    anim.SetBool("idleAnime", false);
                }
                //anim.SetBool("jump", false);
                if (dinoClose == false)
                {
                    dinoAnim.SetBool("dinoRun", true);
                    dinoAnim.SetBool("dinoIdle", false);
                    dinoAnim.SetBool("EatMan", false);
                    dinoAnim.SetBool("dinoDeath", false);
                    //Debug.Log("run");
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                //player.GetComponent<Animator>().enabled = false;
                anim.SetBool("RunAnime", false);
                anim.SetBool("shoot", false);
                //anim.SetBool("idleAnime", true);
                // anim.SetBool("jump", false);
                if (dinoClose == false)
                {
                    dinoAnim.SetBool("dinoRun", false);
                    dinoAnim.SetBool("dinoIdle", true);
                    dinoAnim.SetBool("EatMan", false);
                    dinoAnim.SetBool("dinoDeath", false);
                }
            }
            //mountPos = mountains.transform.position;
            cloudpos = clouds.transform.position;

        }
    }
}