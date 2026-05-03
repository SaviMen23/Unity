using UnityEngine;
using UnityEngine.UI;

public class volumeSwitch : MixerGroupBase
{
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(Mute);
    }

    public void Mute(bool isWork)
    {
        MixerGroup.audioMixer.SetFloat(ExposedParameterName, isWork ? MinDecibel : MaxDecibel);
    }
}
