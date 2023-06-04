using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableQuestItem : QuestObjective
{
    public override void ProgressQuest(string questString)
    {
        base.ProgressQuest(questString);

        Destroy(gameObject);
    }
}
