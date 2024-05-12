using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Men : MonoBehaviour
{

    public int current_fade;
    public Image[] my_images;
    public bool is_main_menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void LoadSceneExit()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_main_menu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (current_fade < 3)
                {
                    current_fade += 1;
                }
            }

            if (current_fade < 3)
            {
                Vector4 temp_vec4 = my_images[0].color;
                if (current_fade == 0) {temp_vec4.w += Time.deltaTime; if (temp_vec4.w > 1f) {temp_vec4.w = 1f;}} 
                else {temp_vec4.w -= Time.deltaTime; if (temp_vec4.w < 0f) {temp_vec4.w = 0f;}}
                my_images[0].color = temp_vec4;

                temp_vec4 = my_images[1].color;
                if (current_fade == 1) {temp_vec4.w += Time.deltaTime; if (temp_vec4.w > 1f) {temp_vec4.w = 1f;}} 
                else {temp_vec4.w -= Time.deltaTime; if (temp_vec4.w < 0f) {temp_vec4.w = 0f;}}
                my_images[1].color = temp_vec4;

                temp_vec4 = my_images[2].color;
                if (current_fade == 2) {temp_vec4.w += Time.deltaTime; if (temp_vec4.w > 1f) {temp_vec4.w = 1f;}} 
                else {temp_vec4.w -= Time.deltaTime; if (temp_vec4.w < 0f) {temp_vec4.w = 0f;}}
                my_images[2].color = temp_vec4;

            } else
            {
                Vector4 temp_vec4 = my_images[0].color; temp_vec4.w -= Time.deltaTime; 
                if (temp_vec4.w < 0f) {temp_vec4.w = 0f;} my_images[0].color = temp_vec4;

                temp_vec4 = my_images[1].color; temp_vec4.w -= Time.deltaTime; 
                if (temp_vec4.w < 0f) {temp_vec4.w = 0f;} my_images[1].color = temp_vec4;

                temp_vec4 = my_images[2].color; temp_vec4.w -= Time.deltaTime; 
                if (temp_vec4.w < 0f) {temp_vec4.w = 0f;} my_images[2].color = temp_vec4;

                if (my_images[2].color.a == 0f) {LoadScene(2);}
            }
        }
    }
}
