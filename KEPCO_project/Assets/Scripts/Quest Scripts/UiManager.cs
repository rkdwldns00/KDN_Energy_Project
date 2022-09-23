using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text levelText;
    public Text questText;
    //public Text hpText;
    //public Slider hpSlider;
    public Text scoreText;
    public Slider scoreSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questShow(int level,Question quest)
    {
        levelText.text = level + "번 문제";
        questText.text = quest.quest;
    }

    public void answerShow(bool isRight,Question quest)
    {
        if (isRight)
        {
            questText.text = "정답!";
        }
        else
        {
            if (quest.type == QuestionType.text)
            {
                questText.text = "답 : " + quest.answerT;
            }
            else if(quest.type == QuestionType.choose)
            {
                questText.text = "답 : " + quest.show[quest.answerI-1];
            }else if(quest.type == QuestionType.ox)
            {
                if (quest.answerI == 1)
                {
                    questText.text = "답 : O";
                }
                else
                {
                    questText.text = "답 : X";
                }
            }
        }
    }

    /*public void hpShow(int hp,int maxhp)
    {
        hpText.text = "체력 : "+hp;
        hpSlider.value = (float)hp/maxhp;
    }*/

    public void scoreShow(float score,int maxScore)
    {
        scoreText.text = "점수 : " + (int)score;
        scoreSlider.value = (float)score/(maxScore * 10);
    }
}
