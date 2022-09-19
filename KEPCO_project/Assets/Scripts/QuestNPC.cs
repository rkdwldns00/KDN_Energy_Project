using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour, Interaction
{
    GameObject QuestCanvas;
    public Sprite open;
    bool isOpen = false;
    private void OnEnable()
    {
        QuestCanvas = FindObjectOfType<GameManager>().questManager;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interaction()
    {
        if (!isOpen)
        {
            isOpen = true;
            GetComponent<SpriteRenderer>().sprite = open;
            QuestCanvas.SetActive(true);
        }
    }
}
