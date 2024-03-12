using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeScript : MonoBehaviour
{

    [Header("<#FFFFFF>    <b>- - - - - <u>Script Descriptions</u> - - - - -")]

    [Header("<#BBBBBB> /com dialouge start          - Starts the dialouge")]
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

    [Header("")]
    [Header("<#FFFFFF>    <b>- - - - - <u>Script Content</u> - - - - -")]
    [Header("")]

    public string[] script_lines;
    public Event[] script_events;

}
