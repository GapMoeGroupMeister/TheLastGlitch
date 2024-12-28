using System.Linq;
using UnityEngine;

public class AcceptedQuest : MonoBehaviour
{
    public AcceptedQuestListSO list;
    [SerializeField] protected EventBox eb;
    [SerializeField] protected GameObject _empty;



    public void CreatQuest()
    {
        if (GetComponentsInChildren<QuestControl>().Count() == 0)
        {
            foreach (TestQuestSO item in list.AcceptedList)
            {

                QuestControl a = Instantiate(_empty, transform).GetComponent<QuestControl>();
                a._quest = item;
                a._eb = eb;
                a.OnCreat?.Invoke();
            }
        }

    }



}
