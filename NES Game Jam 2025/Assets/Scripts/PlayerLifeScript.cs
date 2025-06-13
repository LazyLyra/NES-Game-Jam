using System.Collections;
using System.Collections.Generic;
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

    public AudioSource AS;
    [SerializeField] AudioClip[] soundClips;

    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController();
        playerController.Enable();
        Alive = true;
        AS = GetComponent<AudioSource>();
        BC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        CurrentHp = MaxHp;
        playerController.Player.RestartGame.performed += RestartGame_performed;
    }

    private void RestartGame_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
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
        StartCoroutine(RestartTimer());
        Time.timeScale = 0;
        AS.PlayOneShot(soundClips[0]);
        //reload scene
        anim.SetBool("Dead", true);
    }



    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(10f);
    }
    private void TakeDamage(int Dmg)
    {
        CurrentHp -= Dmg;
        if (CurrentHp <= 0) {
            Die();
        }
    }
}
