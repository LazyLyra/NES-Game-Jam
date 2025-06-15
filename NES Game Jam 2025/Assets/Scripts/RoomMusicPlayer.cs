using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        AS.volume = 0.1f;
       
        if (playing && SceneManager.GetActiveScene().buildIndex != 6)
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
        

    }
}
