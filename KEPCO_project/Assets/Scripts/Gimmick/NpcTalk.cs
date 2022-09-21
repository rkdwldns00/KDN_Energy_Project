using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NpcTalk : MonoBehaviour, Interaction
{
    [TextArea]
    public string[] talkText;
    GameManager gameManager;
    int talkIndex = 0;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interaction()
    {
        if(talkIndex == talkText.Length)
        {
            talkIndex = 0;
            gameManager.closeHelp();
        }
        else
        {
            show(talkText[talkIndex]);
            talkIndex++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerControll>() != null)
        {
            gameManager.closeHelp();
            talkIndex = 0;
        }
    }

    void show(string s)
    {
        gameManager.closeHelp();
        gameManager.showHelp(s);
    }
}
