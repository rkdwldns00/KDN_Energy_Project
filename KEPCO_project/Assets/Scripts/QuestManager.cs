using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum QuestionType
{
   choose,
   ox,
   text,
}

[System.Serializable]
public struct Question
{
    public QuestionType type;
    public string quest;
    public int answerI;
    public string answerT;
    //public int damage;
    public string[] show;
}

public class QuestManager : MonoBehaviour
{
    public QuestData QuestData;
    Question[] questionList;
    public UiManager ui;
    public GameObject chooseField;
    public GameObject oxField;
    public GameObject textField;
    //public int maxHp;
    public int maxScore;
    //int hp;
    GameObject player;
    int level = 0;
    int score = 0;
    bool isSet = false;
    Question nowQuestion;
    int questIndex = 0;
    
    void Start()
    {
        
    }

    private void OnEnable()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void init()
    {
        questionList = QuestData.questionList;
        player = FindObjectOfType<PlayerControll>().gameObject;
        player.SetActive(false);
        //Time.timeScale = 0f;
        //hp = maxHp;
        level++;
        //nowQuestion = questionList[]
        /*int randomIndex = UnityEngine.Random.Range(0, questionList.Length);
        nowQuestion = questionList[randomIndex];*/
        if (!isSet)
        {
            isSet = true;
            for (int i = 0; i < questionList.Length; i++)
            {
                int r1 = UnityEngine.Random.Range(0, questionList.Length - 1);
                int r2 = UnityEngine.Random.Range(0, questionList.Length - 1);

                Question temp = questionList[r1];
                questionList[r1] = questionList[r2];
                questionList[r2] = temp;
            }
        }
        nowQuestion = questionList[questIndex];
        questIndex++;
        ui.questShow(level, nowQuestion);
        //ui.hpShow(hp, maxHp);
        ui.scoreShow(score, maxScore);
        spawnField(nowQuestion.type);
    }

    public void choose(int answerI,string answerT,GameObject field)
    {
        //Question gen;
        DisableButton(field);
        if (nowQuestion.answerI == (int)answerI || nowQuestion.answerT == (string)answerT)
        {
            score += 10;
            ui.scoreShow(score, maxScore);
            ui.answerShow(true, nowQuestion);
        }
        else
        {
            ui.answerShow(false,nowQuestion);
        }
        /*else
        {
            if (hp - nowQuestion.damage > 0)
            {
                hp -= nowQuestion.damage;
            }
            else
            {
                hp = 0;
            }
            ui.hpShow(hp, maxHp);
        }
        if(hp == 0)
        {
            Die();
        }*/
        /*do
        {
            gen = questionList[Random.Range(0, questionList.Length)];
        } while (gen.quest == nowQuestion.quest);
        nowQuestion = gen;
        ui.questShow(level, nowQuestion);
        spawnField(nowQuestion.type);*/
        StartCoroutine(EndGame(field));
    }

    void spawnField(QuestionType type)
    {
        if (type == QuestionType.choose)
        {
            GameObject field = Instantiate(chooseField);
            field.GetComponent<ChooseField>().setText(nowQuestion);
        }else if (type == QuestionType.ox)
        {
            Instantiate(oxField);
        }else if(type == QuestionType.text)
        {
            Instantiate(textField);
        }
    }

    IEnumerator EndGame(GameObject field)
    {
        yield return new WaitForSeconds(1);
        Destroy(field);
        //Time.timeScale = 1f;
        player.SetActive(true);
        gameObject.SetActive(false);
    }

    void DisableButton(GameObject field)
    {
        Button[] buttons = field.GetComponentsInChildren<Button>();
        InputField[] texts = field.GetComponentsInChildren<InputField>();
        foreach(Button b in buttons)
        {
            b.interactable = false;
        }
        foreach(InputField f in texts)
        {
            f.interactable = false;
        }
    }
}
