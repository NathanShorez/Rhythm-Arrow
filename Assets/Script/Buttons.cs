using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private SpriteRenderer button;
    public Sprite defaultbutton;
    public Sprite pressedbutton;

    public KeyCode Press;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Press))
        {
            button.sprite = pressedbutton;
        }
        if (Input.GetKeyUp(Press))
        {
            button.sprite = defaultbutton;
        }
    }
}
