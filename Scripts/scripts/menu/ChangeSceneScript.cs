using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : AStartScript
{
    public string NameScene;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        SceneManager.LoadScene(NameScene);
    }
}
