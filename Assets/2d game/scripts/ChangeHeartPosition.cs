using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag=="hearts")
        {
            getPos();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "hearts")
        {
            getPos();
        }
    }
    public void getPos()
    {
        Debug.Log("change");
        float xpos = Random.Range(-10f, 470f);
        float ypos = Random.Range(0f, 5f);
        this.gameObject.transform.position = new Vector3(xpos, ypos, 0f);
    }
}
