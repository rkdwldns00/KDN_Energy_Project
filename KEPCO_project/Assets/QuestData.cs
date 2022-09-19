using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest/Create Quest", order = 0)]
public class QuestData : ScriptableObject
{
    public Question[] questionList;
}
