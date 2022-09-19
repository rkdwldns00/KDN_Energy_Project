using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject helpKeyUi;
    public Text helpText;
    public GameObject questManager;
    public GameObject[] maps;
    public bool isDebuging;
    public Image blackCanvas;
    float blackCanvasAlpha;
    bool isEnter = false;
    GameObject player;
    Vector3 spawnPoint;
    int nowMap = 0;
    void Start()
    {
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(true);
        }
        questManager.GetComponent<QuestManager>().maxScore = FindObjectsOfType<QuestNPC>().Length * 10;
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        if (!isDebuging)
        {
            maps[0].SetActive(true);
        }
        else
        {
            maps[maps.Length-1].SetActive(true);
        }

        player = FindObjectOfType<PlayerControll>().gameObject;
        spawnPoint = GameObject.Find("Spawn Point").transform.position;
        player.transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            helpKeyUi.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            helpKeyUi.SetActive(false);
        }

        blackCanvas.color = new Color(blackCanvas.color.r, blackCanvas.color.g, blackCanvas.color.b, blackCanvas.color.a + ((blackCanvas.color.a + blackCanvasAlpha) / 2f - blackCanvas.color.a) * Time.deltaTime * 8);
    }

    public void showHelp(string s)
    {
        helpUi.SetActive(true);
        helpText.text = s;
    }

    public void closeHelp()
    {
        helpText.text = "";
        helpUi.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.position = spawnPoint;
        }
    }

    public void nextMap()
    {
        if(!(nowMap < maps.Length-1) || isEnter) {
            return;
        }
        isEnter = true;
        StartCoroutine(blackDown());
    }

    IEnumerator blackDown()
    {
        blackCanvasAlpha = 1.3f;
        yield return new WaitForSeconds(1f);

        maps[nowMap].SetActive(false);
        nowMap++;
        maps[nowMap].SetActive(true);
        spawnPoint = GameObject.FindWithTag("Respawn").transform.position;
        player.transform.position = spawnPoint;

        blackCanvasAlpha = 0f;
        isEnter = false;
    }
}