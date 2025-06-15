using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class RoomMusicPlayer : MonoBehaviour
{
    public AudioSource AS;
    [SerializeField] float rate;
    [SerializeField] float max;
    [SerializeField] bool playing; 
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.volume = 0.05f;
        if (playing)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        if (!playing)
        {
            AS.Play();
            playing = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (AS.volume < max)
        {
            AS.volume += rate * Time.deltaTime;
        }
    }
}
