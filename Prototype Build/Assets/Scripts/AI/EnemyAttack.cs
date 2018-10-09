using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Trigger;
    private GameObject Enemy;
    public bool Attacked;
    private int choice = 0;
    private PlayerHealth playerHealthStats;
    private HealthCounter enemyHealthStats;

    void Start()
    {
        playerHealthStats = GameObject.Find("PlayerModel").GetComponent<PlayerHealth>();
        Enemy = GameObject.Find("Enemy");
        enemyHealthStats = Enemy.GetComponent<HealthCounter>();
        Trigger = GameObject.Find("Switch");
        Attacked = false;
    }

    public void Attack()
    {
        choice = Random.Range(0, 20);

        if (Attacked == false && Trigger.GetComponent<SwitchtoDeck>().endTurn == true && choice <= 1)
        {
            playerHealthStats.playerHealth -= 4;
            Attacked = true;
        }
        else if (Attacked == false && Trigger.GetComponent<SwitchtoDeck>().endTurn == true && choice >= 2)
        {
            enemyHealthStats.HealthIncrease();
            playerHealthStats.playerHealth -= 2;
            Attacked = true;
        }
    }
}
