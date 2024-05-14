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

    public GameObject my_stage;

    public void Open()
    {

        my_stage.SetActive(true);
        TurnPage(0);

    }

    public void Close()
    {

        my_stage.SetActive(false);

    }

    public void TurnPage(int direction)
    {
        current_page += direction;

        if (current_page > page.Length - 1)
        {
            current_page = page.Length - 1;
        } else if (current_page < 0)
        {
            current_page = 0;
        }

        LoadPage(current_page);
    }

    public void LoadPage(int to_load)
    {
        for (int a = 0; a < page.Length; a++)
        {
            for (int b = 0; b < page[a].page_sprites.Length; b++)
            {
                page[a].page_sprites[b].SetActive(false);
            }
        }

        int progress = 0;

        for (int i = 0; i < page[to_load].designations.Length; i++)
        {
            if (Mind.all_photos.Contains(page[to_load].designations[i]))
            {
                progress++;
            }
        }

        if (progress > 0) {page[to_load].page_sprites[0].SetActive(true);}
        if (progress == page[to_load].needed_total_progress) {page[to_load].page_sprites[1].SetActive(true);}
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
