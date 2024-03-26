using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{

    public bool open;
    public JournalPage[] page;
    public int current_page;

    public Image page_sprite;

    public GameObject my_stage;

    public void Open()
    {

        my_stage.SetActive(true);
        TurnPage(0);

    }

    public void TurnPage(int direction)
    {
        current_page += direction;

        if (current_page > page.Length - 1)
        {
            current_page -= page.Length - 1;
        } else if (current_page < 0)
        {
            current_page += page.Length - 1;
        }

        LoadPage(current_page);
    }

    public void LoadPage(int to_load)
    {
        int progress = 0;

        for (int i = 0; i < page[to_load].designations.Length; i++)
        {
            if (Mind.all_photos.Contains(page[to_load].designations[i]))
            {
                progress++;
            }
        }

        page_sprite.sprite = page[to_load].page_sprites[progress];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
