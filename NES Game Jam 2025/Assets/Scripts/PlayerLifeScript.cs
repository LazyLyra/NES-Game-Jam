using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeScript : MonoBehaviour
{
    [Header("Variables")]
    public bool Alive;
    public BoxCollider2D BC;
    [SerializeField] private int MaxHp = 100;
    [SerializeField] private int CurrentHp;
    [SerializeField] public int Damage = 10;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController();
        playerController.Enable();
        Alive = true;
        BC = GetComponent<BoxCollider2D>();

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
        //reload scene
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
