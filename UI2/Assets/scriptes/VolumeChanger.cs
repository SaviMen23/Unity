using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MixerGroupBase
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        MixerGroup.audioMixer.SetFloat(ExposedParameterName, Mathf.Lerp(MinDecibel, MaxDecibel, volume));
    }
}
