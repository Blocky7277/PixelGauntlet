using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float str = 10;

    private float spd = 10;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private float movementSpeed = 20;

    [SerializeField]
    GameManager gameManager;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = direction.normalized * movementSpeed;
    }

    public void DealDamage(int dmg) {
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
