using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> AudioList;

    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

	void Start()
    {
	}

    private AudioSource Play(AudioClip clip, float volume, float pitch)
    {

        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.parent = this.transform;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }

    public float Play(string Name, float Volume)
    {
        int index = -1;
        for (int i = 0; i < AudioList.Count; i++)
        {
            if (AudioList[i].name == Name)
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            Debug.Log("Sound " + Name + " not found");
            return -1;
        }

        Play(AudioList[index], Volume, 1f);
		return AudioList[index].length;
    }
 



}
