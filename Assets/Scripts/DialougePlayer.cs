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

    public Text my_text;
    public GameObject all_dialouge;

    public Texture[] all_sprites;
    public Font[] all_fonts;
    public Texture[] all_boxes;

    public RawImage sprite_image;

    public Text text_name;

    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;

    public bool force_progress;

    public UnityEvent stolen1;
    public UnityEvent stolen2;
    public UnityEvent stolen3;

    public GameObject choice_buttons;

    public float auto_cooldown;

    public TalosCalled talos;

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

    public void ChoiceMade()
    {
        can_progress = true;
        choice_buttons.SetActive(false);
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
            else if (stolen_lines[current_option] == "/newob")
            {
                current_option++;
                talos.NewTask(stolen_lines[current_option]);
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

            else if (stolen_lines[current_option] == "/sprite")
            {
                current_option++;
                int temp_int = int.Parse(stolen_lines[current_option]);
                sprite_image.texture = all_sprites[temp_int];
            }
            else if (stolen_lines[current_option] == "/font")
            {
                current_option++;
                int temp_int = int.Parse(stolen_lines[current_option]);
                my_text.font = all_fonts[temp_int];
            }
            else if (stolen_lines[current_option] == "/color")
            {
                current_option++;
                int temp_int = int.Parse(stolen_lines[current_option]);
                sprite_image.texture = all_sprites[temp_int];
            }

            else if (stolen_lines[current_option] == "/choice")
            {
                choice_buttons.SetActive(true);
                can_progress = false;
                force_progress = false;
                current_option++;
                choiceA.text = stolen_lines[current_option];
                current_option++;
                choiceB.text = stolen_lines[current_option];
            }
            else if (stolen_lines[current_option] == "temp")
            {
                // temp
                Debug.Log("Temp");
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
        if ((Input.GetKeyDown(progression_key) || Input.GetMouseButtonDown(0)) && can_progress && !automated_progression) 
        {
            ProcessLine();
        }
        if (automated_progression)
        {
            auto_cooldown -= Time.deltaTime;
            if (0f > auto_cooldown)
            {
                auto_cooldown = 0.1f;
                ProcessLine();
            }
        }
        if (force_progress)
        {
            ProcessLine();
        }
    }
}
