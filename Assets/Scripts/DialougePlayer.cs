using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public bool force_progress;

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
        current_option = 0;
        ProcessLine();
    }

    public void ProcessLine()
    {
        if (stolen_lines[current_option].Contains("/com"))
        {
            int dummy_int = 0;
            string dummy_string = "";

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
            else if (stolen_lines[current_option] == "/com speech disable")
            {
                can_progress = false;
            }
            else if (stolen_lines[current_option] == "/com speech enable")
            {
                can_progress = true;
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
            else if (stolen_lines[current_option] == "auto on")
            {
                automated_progression = true;
            }
            else if (stolen_lines[current_option] == "auto off")
            {
                automated_progression = false;
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
        force_progress = false;

        if (automated_progression) { ProcessLine(); }
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
