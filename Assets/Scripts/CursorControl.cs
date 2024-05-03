using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{

    public Interactible[] all_ints;
    public Interactible closest_interactible;

    public PhotoOp[] nearby_photo_ops;
    public PhotoOp closest_photo;

    public Transform cursor_trans;
    public Camera main_cam;

    public SpriteRenderer cursor_sprite;
    public Player my_player;

    public Sprite sprite_point;
    public Sprite sprite_cross;
    public Sprite sprite_dot;
    public Sprite sprite_idle;

    public Sprite sprite_nocam;
    public Sprite sprite_yescam;
    public Sprite sprite_camdeny;

    public float distance;
    public float distance_threshold;
    public float hide_cursor;

    public bool taking_photo;

    public Animator cam_flash;

    // Start is called before the first frame update
    void Start()
    {
        all_ints = Object.FindObjectsOfType<Interactible>();
        nearby_photo_ops = Object.FindObjectsOfType<PhotoOp>();
    }

    public void LocatePhotos()
    {
        nearby_photo_ops = Object.FindObjectsOfType<PhotoOp>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        if (!taking_photo)
        {

            distance = 99999f;
            cursor_trans.position = main_cam.ScreenToWorldPoint(Input.mousePosition);
            cursor_trans.position = cursor_trans.position - new Vector3(0f, 0f, cursor_trans.position.z);

            all_ints = Object.FindObjectsOfType<Interactible>();

            for (int i = 0; i < all_ints.Length; i++)
            {
                if (Vector3.Distance(all_ints[i].transform.position, cursor_trans.position) < distance)
                {
                    if (all_ints[i].isActiveAndEnabled)
                    {
                        closest_interactible = all_ints[i];
                        distance = Vector3.Distance(all_ints[i].transform.position, cursor_trans.position);
                    }
                }
            }

            Vector3 look_location = closest_interactible.transform.position;
            look_location.z = cursor_trans.position.z;

            cursor_trans.LookAt(look_location);

            Vector3 distance_point = closest_interactible.transform.position;
            distance_point.z = cursor_trans.position.z;
            distance = Vector3.Distance(distance_point, cursor_trans.position);

            if (distance < hide_cursor)
            {
                if (distance < distance_threshold)
                {
                    cursor_trans.localEulerAngles = new Vector3(225f, -90f, 0f);
                    if (closest_interactible.can_interact_with)
                    {
                        cursor_sprite.sprite = sprite_dot;
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            closest_interactible.my_event.Invoke();
                        }

                    }
                    else
                    {
                        cursor_trans.localEulerAngles = new Vector3(270f, -90f, 0f);
                        cursor_sprite.sprite = sprite_cross;
                    }
                }
                else
                {
                    cursor_sprite.sprite = sprite_point;
                }
            }
            else
            {
                cursor_trans.localEulerAngles = new Vector3(225f, -90f, 0f);
                cursor_sprite.sprite = sprite_idle;
            }

        } else
        {
            distance = 99999f;
            cursor_trans.position = main_cam.ScreenToWorldPoint(Input.mousePosition);
            cursor_trans.position = cursor_trans.position - new Vector3(0f, 0f, cursor_trans.position.z);

            cursor_sprite.sprite = sprite_nocam;

            closest_photo = null;

            for (int i = 0; i < nearby_photo_ops.Length; i++)
            {
                Vector3 measure = nearby_photo_ops[i].transform.position;
                measure.z = cursor_trans.position.z;
                if (Vector3.Distance(measure, cursor_trans.position) < distance && nearby_photo_ops[i].avaliable)
                {
                    closest_photo = nearby_photo_ops[i];
                    distance = Vector3.Distance(measure, cursor_trans.position);
                }
            }

            cursor_trans.localEulerAngles = new Vector3(260f, -90f, 0f);

            if (closest_photo != null)
            {
                Vector3 look_location = closest_photo.transform.position;
                look_location.z = cursor_trans.position.z;
                distance = Vector3.Distance(look_location, cursor_trans.position);

                if (distance < distance_threshold)
                {
                    if (closest_photo.blocked)
                    {
                        cursor_sprite.sprite = sprite_camdeny;
                    }
                    else
                    {
                        cursor_sprite.sprite = sprite_yescam;
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            closest_photo.Capture();
                            nearby_photo_ops = Object.FindObjectsOfType<PhotoOp>();
                            cam_flash.SetTrigger("FlashCamera");
                            my_player.Button_Camera();
                        }
                    }
                }
            }
        }
    }
}
