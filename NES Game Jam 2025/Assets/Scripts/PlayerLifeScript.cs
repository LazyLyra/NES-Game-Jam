using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour
{
    [Header("Variables")]
    public bool Alive;
    public BoxCollider2D BC;
    [SerializeField] private int MaxHp = 100;
    [SerializeField] private int CurrentHp;
    [SerializeField] public int Damage = 10;
    [SerializeField] SawScript sawScript;


    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        BC = GetComponent<BoxCollider2D>();

        CurrentHp = MaxHp;
        sawScript = GameObject.FindGameObjectWithTag("Saw").GetComponent<SawScript>();
        sawScript.OnHitPlayer += SawScript_OnHitPlayer;
    }

    private void SawScript_OnHitPlayer(object sender, System.EventArgs e)
    {
        TakeDamage(Damage);
    }

        // Update is called once per frame
        void Update()
    {

    }

    public void Die()
    {
        Alive = false;
        Wait();
        //reload scene
    }

    

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private void TakeDamage(int Dmg)
    {
        CurrentHp -= Dmg;
        if (CurrentHp <= 0) {
            Die();
        }
    }
}
