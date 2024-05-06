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

    public SpeakerProfile[] all_profiles;

    public RawImage sprite_image;
    public RawImage sprite_border;
    public RawImage dialouge_border;

    public Text text_name;

    public Text choiceA;
    public Text choiceB;

    public bool force_progress;

    public UnityEvent stolen1;
    public UnityEvent stolen2;
    public UnityEvent stolen3;

    public GameObject choice_buttons;

    public GameObject special_textbox;
    public InputField special_input;

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

    public void DecidedSpecial()
    {
        can_progress = true;
        special_textbox.SetActive(false);
        ChangeSpeaker("/speaker Twig");
        
        if (special_input.text == "Mr Robot")
        {
            stolen_lines[current_option] = "(Actually that's a really good idea for a name... Very creative of you!)";
            stolen_lines[current_option + 1] = "(You give a big smile as confetti flies in your mind, Well done Twig!)";
            my_text.text = "(Actually that's a really good idea for a name... Very creative of you!)";
        } else
        {
            stolen_lines[current_option] = "(You realise the name you chose was really uncreative)";
            stolen_lines[current_option + 1] = "(You decide to pick something much more imaginative)";
            my_text.text = "(You realise the name you chose was really uncreative)";
        }

        ProcessLine();

    }

    public void ChangeSpeaker(string insert)
    {
        for (int x = 0; x < all_profiles.Length; x++)
        {
            if (("/speaker " + all_profiles[x].name.ToLower()) == insert.ToLower())
            {
                // border portrait colors
                // text color
                // sprite change

                dialouge_border.color = all_profiles[x].speaker_color;
                sprite_border.color = all_profiles[x].speaker_color;
                my_text.color = all_profiles[x].speaker_color;
                my_text.font = all_profiles[x].speaker_font;
                sprite_image.texture = all_profiles[x].speaker_portrait;
            }
        }
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
            else if (stolen_lines[current_option] == "/pass")
            {
                current_option++;
                my_text.text = stolen_lines[current_option];
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

            else if (stolen_lines[current_option].Contains("/speaker"))
            {
                // current_option++;
                ChangeSpeaker(stolen_lines[current_option]);
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
            else if (stolen_lines[current_option] == "/special choice")
            {
                special_textbox.SetActive(true);
                can_progress = false;
                force_progress = false;
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
