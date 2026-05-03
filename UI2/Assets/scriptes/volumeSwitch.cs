public class volumeSwitch : MixerGroupBase
{
    public void Mute(bool isWork)
    {
        MixerGroup.audioMixer.SetFloat(ExposedParameterName, isWork ? MinDecibel : MaxDecibel);
    }
}
