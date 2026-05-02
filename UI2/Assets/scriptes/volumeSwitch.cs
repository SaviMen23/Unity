public class volumeSwitch: MixerGroupBase
{
    public void Mute(bool isWork)
    {
        _audioMixer.SetFloat(_groupName, isWork ? _min : _max);
    }
}
