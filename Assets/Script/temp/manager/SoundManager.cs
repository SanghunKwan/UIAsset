using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource[] audioSources;
    
    [SerializeField] SliderValue bgmValue;
    private void Awake()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
        GetAudioVolume();
        bgmValue.AddListener(GetAudioVolume);
    }

    public void GetAudioVolume()
    {


        //audioSources[0].volume = bgmValue.Value;
    }
}
