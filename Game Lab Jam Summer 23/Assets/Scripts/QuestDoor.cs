using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDoor : QuestObjective
{
    public override void ProgressQuest(string questString)
    {
        base.ProgressQuest(questString);

        GetComponent<Animator>().Play("Open");
    }
}
