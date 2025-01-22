using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Linq;

public class PauseManagementScript : MonoBehaviour
{
    public bool IsPause {get; set;}
    public DepthOfField _DepthOfField {get; private set;}
    public PostProcessVolume Post;
    public AStartScript OnPauseEvent;
    public AStartScript OffPauseEvent; 
    
    private void Awake()
    {
        Post.profile.TryGetSettings<DepthOfField>(out var depth);
        _DepthOfField = depth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;
            
            if (IsPause)
            {
                if (OnPauseEvent != null)
                    OnPauseEvent.OnStartScript(null, transform);
            }
            else
            {
                if (OffPauseEvent != null)
                    OffPauseEvent.OnStartScript(null, transform);
            }
        }
    }
}
