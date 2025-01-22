using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeScreenScript : AStartScript
{
    private ColorGrading ColorGrad;
    public Vector2 PostExposure;
    public float TimeSeconds;
    [Range(0, 1)] public float Delta;
    public bool IsAutomat;
    public PostProcessVolume Post;

    private void Awake()
    {
        Post.profile.TryGetSettings(out ColorGrad);
    }
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Delta = 0;
        StartCoroutine(_OnChangeScreen(script, _transform));
    }
    private IEnumerator _OnChangeScreen(ScriptingFullScript script, Transform _transform)
    {
        while(Delta < 1)
        {
            if (IsAutomat)
                Delta += Time.deltaTime / TimeSeconds;

            Delta = Delta > 1 ? 1 : Delta;

            ColorGrad.postExposure.Interp(PostExposure.x, PostExposure.y, Delta);

            yield return null;
        }
    }
}
