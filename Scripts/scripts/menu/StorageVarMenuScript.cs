using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageVarMenuScript : AStartScript
{
    public static ButtonStateScript NameButton;
    public ButtonStateScript CurrentButton;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        NameButton = CurrentButton;
    }
}
