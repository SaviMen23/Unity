using UnityEngine;

public class VolumeChanger : MixerGroupBase
{
    public void ChangeVolume(float volume)
    {
        Debug.Log($"group name {_groupName}\tmin {_min}\tmax {_max}\tvolume {volume}");
        _audioMixer.SetFloat(_groupName, Mathf.Lerp(_min, _max, volume));
    }
}
