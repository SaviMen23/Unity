using UnityEngine;

public class VolumeChanger : MixerGroupBase
{
    public void ChangeVolume(float volume)
    {
        MixerGroup.audioMixer.SetFloat(ExposedParameterName, Mathf.Lerp(MinDecibel, MaxDecibel, volume));
    }
}
