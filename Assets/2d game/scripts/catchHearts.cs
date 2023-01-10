using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class catchHearts : MonoBehaviour
{
    public static int heartsCount = 0;
    public Text displayScore;
    // Start is called before the first frame update
    void Start()
    {
        InstantiatePoints();
    }

    // Update is called once per frame
    void Update()
    {
        displayScore.text = heartsCount.ToString();
    }

    public void InstantiatePoints()
    {
        
        for(int i = 0; i < 50; i++)
        {
            float xpos = Random.Range(-10f, 470f);
            float ypos = Random.Range(0f, 5f);
            //int num = Random.Range(14, 19);
            GameObject obj = Resources.Load($"14") as GameObject;
            Instantiate(obj, new Vector3(xpos, ypos, 0f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hearts")
        {
            collision.gameObject.SetActive(false);
            heartsCount++;
        }
    }
}

//-10 to 450
// 0 to 5