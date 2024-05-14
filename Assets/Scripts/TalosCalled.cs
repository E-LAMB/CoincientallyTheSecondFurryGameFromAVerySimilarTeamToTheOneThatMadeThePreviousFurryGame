using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalosCalled : MonoBehaviour
{

    public TextMeshProUGUI objective;
    public Animator anim;

    public int target_slot;
    public string[] my_objectives;
    public bool talos_animating;
    public int tasks_here;

    public GameObject visibility;

    public void SwapObjectives()
    {
        if (target_slot != -25)
        {
            bool not_found = true;
            int heat = 20;

            while (heat > 0 && not_found)
            {
                target_slot += 1;
                if (target_slot >= my_objectives.Length)
                {
                    target_slot = 0;
                }

                if (objective.text != my_objectives[target_slot] && my_objectives[target_slot] != "")
                {
                    not_found = false;
                    heat = -20;
                    objective.text = my_objectives[target_slot];
                    anim.SetTrigger("PlayObjective");
                }

                heat -= 1;
            }

        }
        CountTasks();
    }

    public void TalosStartAnim() { talos_animating = true; } public void TalosFinishAnim() { talos_animating = false; }

    public void NewTask(string new_objective)
    {
        objective.text = new_objective;
        my_objectives[0] = new_objective;
        anim.SetTrigger("PlayObjective");
        LocateTask(new_objective);
        CountTasks();
    }

    public void StackObjective(string new_objective)
    {
        bool has_stacked = false;
        for (int a = 0; a < my_objectives.Length; a++)
        {
            if (my_objectives[a] == "" && !has_stacked)
            {
                has_stacked = true;
                my_objectives[a] = new_objective;
                objective.text = new_objective;
                anim.SetTrigger("PlayObjective");
                LocateTask(new_objective);
            }
        }
        CountTasks();
    }

    public void LocateTask()
    {
        for (int a = 0; a < my_objectives.Length; a++)
        {
            if (my_objectives[a] != "")
            {
                target_slot = -25;
                objective.text = my_objectives[a];
                anim.SetTrigger("PlayObjective");
            }
        }
        visibility.SetActive(target_slot != -25);
        CountTasks();
    }

    public void LocateTask(string new_objective)
    {
        for (int a = 0; a < my_objectives.Length; a++)
        {
            if (my_objectives[a] == new_objective)
            {
                target_slot = a;
                objective.text = my_objectives[a];
                anim.SetTrigger("PlayObjective");
            }
        }
        visibility.SetActive(target_slot != -25);
        CountTasks();
    }

    public void ClearTask(string new_objective)
    {
        for (int a = 0; a < my_objectives.Length; a++)
        {
            if (my_objectives[a] == new_objective)
            {
                my_objectives[a] = "";
            }
            LocateTask();
        }
        CountTasks();
    }

    public void ClearAllTasks()
    {
        for (int a = 0; a < my_objectives.Length; a++)
        {
            my_objectives[a] = "";
        }
        CountTasks();
    }

    public int CountTasks()
    {
        tasks_here = 0;

        for (int a = 0; a < my_objectives.Length; a++)
        {
            if (my_objectives[a] != "")
            {
                tasks_here += 1;
            }
        }

        return tasks_here;
    }

    // Start is called before the first frame update
    void Start()
    {
        CountTasks();
    }

    // Update is called once per frame
    void Update()
    {
        visibility.SetActive(tasks_here > 1);
    }
}
