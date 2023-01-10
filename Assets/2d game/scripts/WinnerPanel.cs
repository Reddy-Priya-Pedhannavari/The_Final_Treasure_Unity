using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    public GameObject WinPanel;
    public Text score;
    public dinoEatMan dinoEatManScript;
    public witch witchScript;
    public dragonscript dragonScript;
    public catchHearts catchHearts;
    public GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            WinPanel.SetActive(true);
            score.text = "Score : " +catchHearts.heartsCount.ToString();
            playerMoves.startGamebool = false;
            //Time.timeScale = 0;
            //collision.gameObject.GetComponent<playerMoves>().enabled = false;
        }
    }

    public void playAgain()
    {
        dinoEatMan.lifeCount = 0;
        //dinoEatManScript.player_reset();
        witchScript.witch_Reset();
        dragonScript.Dragon_Reset();
        dinoEatManScript.reset();
        dinoEatMan.lifeCount = 3;
        catchHearts.heartsCount = 0;
        //catchHearts.displayScore.text = "0";
        WinPanel.SetActive(false);
        GameObject []heartsObj;
        heartsObj = GameObject.FindGameObjectsWithTag("hearts");
        for(int i = 0; i < heartsObj.Length; i++)
        {
            Destroy(heartsObj[i].gameObject);
        }
        catchHearts.InstantiatePoints();
        startPanel.SetActive(true);
        playerMoves.startGamebool = false;
    }

    public void Exit()
    {
        Application.Quit(0);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        playerMoves.startGamebool = true;
    }
}
