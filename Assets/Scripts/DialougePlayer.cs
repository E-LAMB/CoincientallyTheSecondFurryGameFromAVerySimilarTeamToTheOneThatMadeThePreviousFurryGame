using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialougePlayer : MonoBehaviour
{

    public string[] stolen_lines;
    public Event[] stolen_events;

    public int current_option;
    public KeyCode progression_key;
    public bool can_progress;
    public bool automated_progression;

    public TextMeshProUGUI my_text;
    public GameObject all_dialouge;

    public Sprite[] all_sprites;
    public Image sprite_image;

    public TextMeshProUGUI text_name;

    public bool force_progress;

    public UnityEvent stolen1;
    public UnityEvent stolen2;
    public UnityEvent stolen3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StealFrom(DialougeScript input)
    {
        int place = 0;
        while (place < input.script_lines.Length)
        {
            stolen_lines[place] = input.script_lines[place];
            place += 1;
        }

        stolen1 = input.event_1;
        stolen2 = input.event_2;
        stolen3 = input.event_3;

        current_option = 0;
        ProcessLine();
    }

    public void ProcessLine()
    {
        force_progress = false;

        if (stolen_lines[current_option].Contains("/"))
        {
            /*
            int dummy_int = 0;
            string dummy_string = "";
            */
            force_progress = true;

            /*
            if (stolen_lines[current_option] == "/com dialouge start")
            {
                all_dialouge.SetActive(true);
            }
            else if (stolen_lines[current_option] == "/com dialouge end")
            {
                all_dialouge.SetActive(false);
            }
            else if (stolen_lines[current_option] == "/com player disable")
            {
                Mind.player_has_control = false;
            }
            else if (stolen_lines[current_option] == "/com player enable")
            {
                Mind.player_has_control = true;
            }
             else if (stolen_lines[current_option].Contains("/com icon set"))
            {
                // (stolen_lines[current_option][14]) != ""
                // Debug.Log((stolen_lines[current_option].Length));
                if ((stolen_lines[current_option].Length > 14))
                {
                    if ((stolen_lines[current_option][16] + "/") != "/")
                    {
                        dummy_string = stolen_lines[current_option][14] + stolen_lines[current_option][15] + stolen_lines[current_option][16] + "";
                    }
                    else if ((stolen_lines[current_option][15] + "/") != "/")
                    {
                        dummy_string = stolen_lines[current_option][14] + stolen_lines[current_option][15] + "";
                    }
                    else if ((stolen_lines[current_option][14] + "/") != "/")
                    {
                        dummy_string = stolen_lines[current_option][14] + "";
                    }
                    dummy_int = int.Parse(dummy_string);
                    sprite_image.sprite = all_sprites[dummy_int];
                }
            }
            */

            if (stolen_lines[current_option] == "/start")
            {
                all_dialouge.SetActive(true);
                Mind.player_has_control = false;
            }
            else if (stolen_lines[current_option] == "/end")
            {
                all_dialouge.SetActive(false);
                Mind.player_has_control = true;
            }
            else if (stolen_lines[current_option] == "/disable")
            {
                can_progress = false;
            }
            else if (stolen_lines[current_option] == "/enable")
            {
                can_progress = true;
            }
            else if (stolen_lines[current_option] == "/auto on")
            {
                automated_progression = true;
            }
            else if (stolen_lines[current_option] == "/auto off")
            {
                automated_progression = false;
            }
            else if (stolen_lines[current_option] == "/name")
            {
                current_option++;
                text_name.text = stolen_lines[current_option];
            }
            else if (stolen_lines[current_option] == "/event 1")
            {
                stolen1.Invoke();
            }
            else if (stolen_lines[current_option] == "/event 2")
            {
                stolen2.Invoke();
            }
            else if (stolen_lines[current_option] == "/event 3")
            {
                stolen3.Invoke();
            }
            else if (stolen_lines[current_option] == "temp")
            {
                // temp
            }


        } else
        {
            my_text.text = stolen_lines[current_option];
        }

        current_option += 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(progression_key) && can_progress) 
        {
            ProcessLine();
        }
        if (automated_progression)
        {
            ProcessLine();
        }
        if (force_progress)
        {
            ProcessLine();
        }
    }
}
