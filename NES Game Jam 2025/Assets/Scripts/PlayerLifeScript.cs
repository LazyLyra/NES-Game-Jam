using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeScript : MonoBehaviour
{
    [Header("Variables")]
    public bool Alive;
    public BoxCollider2D BC;
    public Animator anim;
    [SerializeField] private int MaxHp = 100;
    [SerializeField] private int CurrentHp;
    [SerializeField] public int Damage = 10;
    private PlayerController playerController;
    private PlayerMovementScript playerMovementScript;
    private SpriteRenderer SR;
    private GameObject deathMsg;
    public event EventHandler Ondeath; 

    public AudioSource AS;
    [SerializeField] AudioClip[] soundClips;

    // Start is called before the first frame update
    void Start()
    {

        Alive = true;
        AS = GetComponent<AudioSource>();
        BC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        playerMovementScript = GetComponent<PlayerMovementScript>();
        CurrentHp = MaxHp;
    }



    void OnCollisionEnter2D(Collision2D collider) 
    {
        if (collider.collider.CompareTag("Saw"))
        {
            TakeDamage(Damage);
        }
    }

        // Update is called once per frame
        void Update()
    {

    }

    public void Die()
    {
        Alive = false;
        anim.SetBool("Dead", true);
        AS.PlayOneShot(soundClips[0]);
        playerMovementScript.enabled = false;
        AS.enabled = false;
        StartCoroutine(RestartTimer());    
        //reload scene
    }



    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(1f);
        Ondeath?.Invoke(this, EventArgs.Empty);
        SR.enabled = false;
        yield return new WaitForSeconds(3f);
        SR.enabled = true;
        playerMovementScript.enabled = true;
        AS.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void TakeDamage(int Dmg)
    {
        CurrentHp -= Dmg;
        if (CurrentHp <= 0) {
            Die();
        }
    }
}
