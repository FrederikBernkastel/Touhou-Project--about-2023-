using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpriteUIScript : AStartScript
{
    public Image _Image;
    public Sprite _Sprite;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        _Image.sprite = _Sprite;
    }
}
