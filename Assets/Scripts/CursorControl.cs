using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{

    public Interactible[] all_ints;
    public Interactible closest_interactible;

    public Transform cursor_trans;
    public Camera main_cam;

    public SpriteRenderer cursor_sprite;

    public Sprite sprite_point;
    public Sprite sprite_cross;
    public Sprite sprite_dot;
    public Sprite sprite_idle;

    public float distance;
    public float distance_threshold;
    public float hide_cursor;

    // Start is called before the first frame update
    void Start()
    {
        all_ints = Object.FindObjectsOfType<Interactible>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        distance = 99999f;
        cursor_trans.position = main_cam.ScreenToWorldPoint(Input.mousePosition);
        cursor_trans.position = cursor_trans.position - new Vector3(0f, 0f, cursor_trans.position.z);

        for (int i = 0; i < all_ints.Length; i++)
        {
            if (Vector3.Distance(all_ints[i].transform.position, cursor_trans.position) < distance)
            {
                closest_interactible = all_ints[i];
                distance = Vector3.Distance(all_ints[i].transform.position, cursor_trans.position);
            }
        }

        cursor_trans.LookAt(closest_interactible.transform.position);
        
        if (distance < hide_cursor)
        {
            if (distance < distance_threshold)
            {
                cursor_trans.localEulerAngles = new Vector3(0f, -90f, 0f);
                if (closest_interactible.can_interact_with)
                {
                    cursor_sprite.sprite = sprite_dot;
                }
                else
                {
                    cursor_sprite.sprite = sprite_cross;
                }
            }
            else
            {
                cursor_sprite.sprite = sprite_point;
            }
        } else
        {
            cursor_trans.localEulerAngles = new Vector3(0f, -90f, 0f);
            cursor_sprite.sprite = sprite_idle;
        }
    }
}
