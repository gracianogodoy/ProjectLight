using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public struct Sound
{
    public string Name;
    public AudioClip Clip;
    public float Volume;
    public bool Loop;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    private List<AudioSource> _audioSources;

    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    // Use this for initialization
    void Awake()
    {
        _audioSources = new List<AudioSource>();
        _instance = this;
    }

    #region Play methods
    public AudioSource Play(AudioClip sound, float volume, bool loop)
    {
        var source = getFreeAudioSource();

        source.clip = sound;
        source.volume = volume;
        source.loop = loop;
        source.playOnAwake = true;

        source.Play();
        return source;
    }

    //public AudioSource Play(string soundName, float volume, bool loop, bool playOnAwake)
    //{
    //    return Play(getSound(soundName), volume, loop, playOnAwake, false);
    //}

    //public AudioSource Play(string soundName, float volume, bool loop)
    //{
    //    return Play(getSound(soundName), volume, loop, false, false);
    //}

    //public AudioSource Play(string soundName, float volume)
    //{
    //    return Play(getSound(soundName), volume, false, false, false);
    //}

    public AudioSource Play(string soundName)
    {
        var sound = getSound(soundName);
        return Play(sound.Clip, sound.Volume, sound.Loop);
    }
    #endregion

    #region Helper methods
    private Sound getSound(string name)
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            var sound = Sounds[i];

            if (sound.Name == name)
                return sound;
        }

        throw new Exception(string.Format("The sound {0} was not found.", name));
    }

    public AudioSource getFreeAudioSource()
    {
        for (int i = 0; i < _audioSources.Count; i++)
        {
            var audioSource = _audioSources[i];

            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }

        var newAudioSource = createAudioSourceObject();
        _audioSources.Add(newAudioSource);

        return newAudioSource;
    }

    private AudioSource createAudioSourceObject()
    {
        GameObject obj = null;
        obj = new GameObject("audio_source");
        obj.transform.position = Instance.transform.position;
        obj.transform.parent = Instance.transform;

        AudioSource source = null;
        source = obj.AddComponent<AudioSource>();

        return source;
    }
    #endregion
}
