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
        levelText.text = level + "�� ����";
        questText.text = quest.quest;
    }

    public void answerShow(bool isRight,Question quest)
    {
        if (isRight)
        {
            questText.text = "����!";
        }
        else
        {
            if (quest.type == QuestionType.text)
            {
                questText.text = "�� : " + quest.answerT;
            }
            else if(quest.type == QuestionType.choose)
            {
                questText.text = "�� : " + quest.show[quest.answerI-1];
            }else if(quest.type == QuestionType.ox)
            {
                if (quest.answerI == 1)
                {
                    questText.text = "�� : O";
                }
                else
                {
                    questText.text = "�� : X";
                }
            }
        }
    }

    /*public void hpShow(int hp,int maxhp)
    {
        hpText.text = "ü�� : "+hp;
        hpSlider.value = (float)hp/maxhp;
    }*/

    public void scoreShow(float score,int maxScore)
    {
        scoreText.text = "���� : " + (int)score;
        scoreSlider.value = (float)score/(maxScore * 10);
    }
}
