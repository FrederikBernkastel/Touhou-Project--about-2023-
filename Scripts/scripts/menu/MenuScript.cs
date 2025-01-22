using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public ButtonStateScript[] Buttons;
    public int CurrentButtonIndex {get; private set;}
    public AStartScript DefaultButtonEvent;
    public int DefaultButton {get; set;}
    public bool IsSelectedDefault = true;

    private void OnEnable()
    {
        foreach (var s in Buttons)
            foreach (var h in s.PeaceState)
                h.OnStartScript(null, transform);

        DefaultButtonEvent?.OnStartScript(null, transform);

        if (IsSelectedDefault)
            foreach (var s in Buttons[DefaultButton].SelectedState)
                s.OnStartScript(null, transform);

        CurrentButtonIndex = DefaultButton;
    }
    public void OnNext()
    {
        foreach (var s in Buttons[CurrentButtonIndex].ClickEvents)
            s.OnStartScript(null, Buttons[CurrentButtonIndex].transform);
    }
    public void OnNextDown()
    {
        foreach (var s in Buttons[CurrentButtonIndex].PeaceState)
            s.OnStartScript(null, Buttons[CurrentButtonIndex].transform);

        CurrentButtonIndex = CurrentButtonIndex + 1 > Buttons.Length - 1 ? 0 : CurrentButtonIndex + 1;

        foreach (var s in Buttons[CurrentButtonIndex].SelectedState)
            s.OnStartScript(null, Buttons[CurrentButtonIndex].transform);
    }
    public void OnNextUp()
    {
        foreach (var s in Buttons[CurrentButtonIndex].PeaceState)
            s.OnStartScript(null, Buttons[CurrentButtonIndex].transform);

        CurrentButtonIndex = CurrentButtonIndex - 1 < 0 ? Buttons.Length - 1 : CurrentButtonIndex - 1;

        foreach (var s in Buttons[CurrentButtonIndex].SelectedState)
            s.OnStartScript(null, Buttons[CurrentButtonIndex].transform);
    }
}
