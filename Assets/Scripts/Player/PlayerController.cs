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
    private float health = 100f;

    [SerializeField]
    private float movementSpeed = 20;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = direction.normalized * movementSpeed;
    }

    public void DealDamage(float dmg) {
        health -= dmg;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        StartCoroutine(DelayLoad());
    }

    IEnumerator DelayLoad() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
