using UnityEngine;
using UnityEngine.Audio;

public abstract class MixerGroupBase : MonoBehaviour
{
    [SerializeField] protected AudioMixer _audioMixer;
    [SerializeField] protected string _groupName;

    protected float _min = -80f;
    protected float _max = 0f;
}
