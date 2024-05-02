using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeScript : MonoBehaviour
{
    /*
    [Header("<#BBBBBB> /com dialouge end            - Ends the dialouge")]
    [Header("<#BBBBBB> /com player disable          - Disables the player's ability to move")]
    [Header("<#BBBBBB> /com player enable           - Enables the player's ability to move")]
    [Header("<#BBBBBB> /com speech disable          - Disables the player's ability to progress speech")]
    [Header("<#BBBBBB> /com speech enable           - Enables the player's ability to progress speech")]
    [Header("<#BBBBBB> /com icon set #              - Sets the icon to the indicated ID")]
    [Header("<#BBBBBB> /com icon light #            - Sets the icon's brightness to the indicated point")]
    [Header("<#BBBBBB> /com run #                   - Runs the command in the indicated slot")]
    [Header("<#BBBBBB> /com auto enable            - Sets the icon to the indicated ID")]
    [Header("<#BBBBBB> /com auto disable           - Sets the icon's brightness to the indicated point")]
    */

    [Header("<#FFFFFF>    <b>- - - - - <u>Script Content</u> - - - - -")]

    public string[] script_lines;
    public UnityEvent event_1;
    public UnityEvent event_2;
    public UnityEvent event_3;

    [Header("<#FFFFFF>    <b>- - - - - <u>Script Commands</u> - - - - -")]

    [Header("<#BBBBBB> /start          - Starts the dialouge")]
    [Header("<#BBBBBB> /end          - Starts the dialouge")]
    [Header("<#BBBBBB> /enable          - Allows the player to progress dialouge")]
    [Header("<#BBBBBB> /disable          - Stops the player from progressing dialouge")]
    [Header("<#BBBBBB> /auto on          - Activates automation")]
    [Header("<#BBBBBB> /auto off          - Deactivates automation")]
    [Header("<#BBBBBB> /name          - Sets the name")]
    [Header("<#BBBBBB> /event 1          - Runs event 1")]
    [Header("<#BBBBBB> /event 2          - Runs event 2")]
    [Header("<#BBBBBB> /event 3          - Runs event 3")]
    [Header("<#BBBBBB> /choice          - Presents two choices")]
    [Header("<#BBBBBB> /newob          - Presents an objective")]
    [Header("<#BBBBBB> /pass         - Runs event 3")]
    [Header("")]

    public bool random_checkbox;

}
