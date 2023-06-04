using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjective : MonoBehaviour
{
    [SerializeField] List<string> questItemsNeeded = new List<string>();

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding with: " + collision.gameObject.name);

        for (int i = 0; i < questItemsNeeded.Count; i++)
        {
            for (int j = 0; j < questItemsNeeded.Count; j++)
            {
                string questString = questItemsNeeded[i] + " + " + questItemsNeeded[j];
                Debug.Log("Quest string: " + questString);
                List<GameObject> heldObjectList = collision.gameObject.GetComponent<PlayerCharacter>().GetHeldItems();

                foreach (GameObject heldObject in heldObjectList)
                {
                    if (heldObject.transform.parent)
                    {
                        Debug.Log("Checking: " + questString + " for: " + heldObject.transform.parent.name);
                        if (questString == heldObject.transform.parent.name)
                        {
                            ProgressQuest(questString);
                            return;
                        }

                    }
                    else
                    {
                        if (questString == heldObject.gameObject.name)
                        {
                            ProgressQuest(questString);
                            return;
                        }

                    }

                }
            }
        }
    }

    public virtual void ProgressQuest(string questString)
    {
        Destroy(GameObject.Find(questString));
    }
}
