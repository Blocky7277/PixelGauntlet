using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public int str {get; set;} = 10;

    public int spd {get; set;} = 10;

    public bool shield {get; set;} = false;

    public Assist[] activeAssists = new Assist[3];

    [SerializeField]
    private int health = 100;

    [SerializeField]
    GameManager gameManager;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * spd;
    }

    public void DealDamage(int dmg) {
        for (int i = 0; i < activeAssists.Length; i++)
        {
            if(activeAssists[i] != null && activeAssists[i].assistType == AssistTypes.SHIELD) {
                gameManager.deactivateAssist(activeAssists[i]);
                return;
            }
        }
        health -= dmg;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        gameManager.TransitionScene(SceneManager.GetActiveScene(), 1f);
        gameObject.SetActive(false);
    }

}
