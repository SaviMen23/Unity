using UnityEngine;
using UnityEngine.Audio;

public abstract class MixerGroupBase : MonoBehaviour
{
    [SerializeField] protected AudioMixerGroup MixerGroup;
    [SerializeField] protected string ExposedParameterName;

    protected float MinDecibel = -80f;
    protected float MaxDecibel = 0f;
}
