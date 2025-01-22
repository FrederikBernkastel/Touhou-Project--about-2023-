using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUpdateScript : MonoBehaviour
{
    public abstract void UpdateScript(Transform _transform, ref float delta);
}
