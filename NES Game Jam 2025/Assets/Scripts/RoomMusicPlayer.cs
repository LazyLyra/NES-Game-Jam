using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomMusicPlayer : MonoBehaviour
{
    private static RoomMusicPlayer instance;
    public AudioSource AS;
    [SerializeField] float rate;
    [SerializeField] float max;
    [SerializeField] bool playing;
    
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.volume = 0.1f;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        if (playing && SceneManager.GetActiveScene().name != "EndCutScene")
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
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
