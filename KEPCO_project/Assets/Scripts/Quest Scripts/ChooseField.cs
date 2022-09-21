using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseField : MonoBehaviour
{
    public QuestionType type;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public GameObject button3;
    public GameObject button4;
    public InputField inputText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setText(Question quest)
    {
        text1.text = quest.show[0];
        text2.text = quest.show[1];
        if (quest.show.Length < 3)
        {
            button3.SetActive(false);
        }
        else
        {
            button3.SetActive(true);
            text3.text = quest.show[2];
        }
        if (quest.show.Length < 4)
        {
            button4.SetActive(false);
        }
        else
        {
            button4.SetActive(true);
            text4.text = quest.show[3];
        }
    }

    public void choose(int answer)
    {
        if (type == QuestionType.choose || type == QuestionType.ox)
        {
            FindObjectOfType<QuestManager>().choose(answer,"null", gameObject);
        }
    }

    public void choose()
    {
        FindObjectOfType<QuestManager>().choose(-1,inputText.text, gameObject);
    }
}
