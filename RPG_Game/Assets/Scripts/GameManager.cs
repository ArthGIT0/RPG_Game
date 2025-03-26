using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject[] enemyPrefabs;
    private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private TMP_Text playerName, playerHealth;
    [SerializeField] private TMP_Text enemyName, enemyHealth;

    void Start()
    {
        playerName.text = player.CharName;
        SpawnEnemy();
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerHealth.text = player.health.ToString();
        if (enemies.Count > 0)
        {
            enemyName.text = enemies[0].name;
            enemyHealth.text = enemies[0].health.ToString();
        }
        else
        {
            enemyName.text = "No Enemies";
            enemyHealth.text = "-";
        }
    }

    public void DoRound()
    {
        if (enemies.Count == 0) return;

        Enemy currentEnemy = enemies[0];
        int damage = player.Attack();
        currentEnemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(currentEnemy);

        if (currentEnemy.health <= 0)
        {
            enemies.RemoveAt(0);
            Destroy(currentEnemy.gameObject);
            SpawnEnemy();
        }
        else
        {
            int enemyDamage = currentEnemy.Attack();
            player.GetHit(enemyDamage);
        }

        UpdateUI();
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab);
        Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemies.Add(enemyComponent);
            newEnemy.name = enemyPrefab.name;
        }
    }
}