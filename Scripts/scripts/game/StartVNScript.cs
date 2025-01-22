using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartVNScript : AStartScript
{
    public Flowchart Chart;
    public string Name;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Chart.SendFungusMessage(Name);
    }
}
