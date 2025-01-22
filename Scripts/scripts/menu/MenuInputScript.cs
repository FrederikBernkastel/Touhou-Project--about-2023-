using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputScript : MonoBehaviour
{
    public KeyCode NextButtonKey;
    public KeyCode BackButtonKey;
    public KeyCode NextKey;
    public MenuScript Menu;
    
    private void Update()
    {
        if (NextKey != KeyCode.None && Input.GetKeyDown(NextKey))
            Menu.OnNext();
        else if (NextButtonKey != KeyCode.None && Input.GetKeyDown(NextButtonKey))
            Menu.OnNextDown();
        else if (BackButtonKey != KeyCode.None && Input.GetKeyDown(BackButtonKey))
            Menu.OnNextUp();
    }
}
