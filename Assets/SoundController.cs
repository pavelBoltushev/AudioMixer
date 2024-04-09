using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public const string MasterVolume = nameof(MasterVolume);
    public const string BackgroundVolume = nameof(BackgroundVolume);
    public const string ButtonsVolume = nameof(ButtonsVolume);

    [SerializeField] private AudioMixerGroup _master;    
    [SerializeField] private AudioSource _button1Sound;
    [SerializeField] private AudioSource _button2Sound;
    [SerializeField] private AudioSource _button3Sound;

    private bool _muted;
    private float _currentMasterVolumeValue;

    public void MuteUnmute()
    {
        if (_muted)
        {
            ChangeVolume(MasterVolume, _currentMasterVolumeValue);
            _muted = false;
        }
        else
        {
            ChangeVolume(MasterVolume, 0);
            _muted = true;
        }
    }

    public void PlayButton1Sound()
    {
        _button1Sound.Play();
    }

    public void PlayButton2Sound()
    {
        _button2Sound.Play();
    }

    public void PlayButton3Sound()
    {
        _button3Sound.Play();
    }   

    public void ChangeMasterVolume(float value)
    {
        _currentMasterVolumeValue = value;

        if(_muted == false)
            ChangeVolume(MasterVolume, value);
    }

    public void ChangeBackgroundVolume(float value)
    {
        ChangeVolume(BackgroundVolume, value);
    }

    public void ChangeButtonsVolume(float value)
    {
        ChangeVolume(ButtonsVolume, value);
    }

    private void ChangeVolume(string exposedParameterTitle, float normalizedValue)
    {
        _master.audioMixer.SetFloat(exposedParameterTitle, Mathf.Lerp(-80, 0, normalizedValue));
    }
}
