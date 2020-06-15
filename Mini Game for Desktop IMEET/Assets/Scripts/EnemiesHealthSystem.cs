using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealthSystem : MonoBehaviour
{
    // Enemies health
    public int maxHealth;
    public int currentHealth;

    // healthbar script
    public HealthBar healthBar;

    private GameObject _player;
    private PlayerCombat _playerCombat;

    private bool isTakingDamage;

    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerCombat = _player.GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if (isTakingDamage)
        {
            TakeDamage(_playerCombat.AttackPower);
            isTakingDamage = false;
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _player.tag)
        {
            isTakingDamage = true;
        }
        else
        {
            isTakingDamage = false;
        }
    }
}
