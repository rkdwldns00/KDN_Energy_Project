using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameResultText;
    public GameObject ScoreText;
    public GameObject GradeText;
    public Image StartButton;
    //public Image blackCanvas;
    //float blackCanvasAlpha = 1.3f;
    void Start()
    {
        StartCoroutine(GameOverAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        /*blackCanvas.color = new Color(blackCanvas.color.r, blackCanvas.color.g, blackCanvas.color.b, blackCanvas.color.a + ((blackCanvas.color.a + blackCanvasAlpha) / 2f - blackCanvas.color.a) * Time.deltaTime * 8);
        if (blackCanvas.color.a <= 1f)
        {
            blackCanvas.gameObject.SetActive(false);
        }
        else
        {
            blackCanvas.gameObject.SetActive(true);
        }*/
    }

        IEnumerator GameOverAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        GameResultText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //blackCanvasAlpha = 0f;
        StartCoroutine(ScoreAnimation());
        
    }

    IEnumerator ScoreAnimation()
    {
        ScoreText.SetActive(true);
        for(int i = 0; i <= QuestManager.score; i++)
        {
            yield return new WaitForSeconds(0.01f);
            ScoreText.GetComponent<Text>().text = i.ToString()+"점";
        }
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(GradeAnimation());
    }

    IEnumerator GradeAnimation()
    {
        if (QuestManager.score >= 75)
        {
            GradeText.GetComponent<Text>().text = "완벽해요!";
        }
        else if (QuestManager.score >= 75)
        {
            GradeText.GetComponent<Text>().text = "잘했어요!";
        }
        else if(QuestManager.score >= 25)
        {
            GradeText.GetComponent<Text>().text = "나쁘지 않아요";
        }
        else
        {
            GradeText.GetComponent<Text>().text = "더 노력하세요";
        }
        GradeText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartButton.enabled = true;
    }
}
