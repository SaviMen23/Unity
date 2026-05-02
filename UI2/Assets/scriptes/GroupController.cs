using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GroupController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _groupName;

    private float _min = -80f;
    private float _max = 0f;
    public void ChnageVolume(float volume)
    {
        _audioMixer.SetFloat(_groupName, Mathf.Lerp(_min, _max, volume));
    }

    public void Mute(bool isWork)
    {
        _audioMixer.SetFloat(_groupName, isWork ? _min : _max);
    }
}
