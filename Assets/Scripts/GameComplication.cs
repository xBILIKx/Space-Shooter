using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplication : MonoBehaviour
{
    public EnemyController redEC;
    public EnemyController greenEC;
    public MeteorController mc;
    public MovementController enemyRedMC;
    public MovementController enemyGreenMC;
    public MovementController meteorMC;
    public MovementController meteorMC2;
    public MovementController meteorMC3;
    public MovementController meteorMC4;
    public MovementController enemyLazersMC;
    public MovementController coins;
    public Spawner spawner;
    public Background background;
    private void Awake()
    {
        SetPrimaryCharacteristics();
    }
    void Start()
    {
        StartCoroutine(BoostEnemyCharacteristics());
    }

    IEnumerator BoostEnemyCharacteristics()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if (!MaxValue())
            {
                redEC.maxHP += 0.7f;
                redEC.reload -= 0.03f;
                greenEC.maxHP += 1.2f;
                greenEC.reload -= 0.05f;
                mc.maxHP += 0.7f;
                enemyRedMC.speed += 0.5f;
                enemyGreenMC.speed += 0.6f;
                meteorMC.speed += 1;
                meteorMC2.speed += 1;
                meteorMC3.speed += 1;
                meteorMC4.speed += 0.5f;
                enemyLazersMC.speed += 0.65f;
                coins.speed += 1;
                spawner.spawnReload -= 0.03f;
                background.speed += 0.02f;
            }
            else
            {
                break;
            }
        }
    }

    bool MaxValue()
    {
        if (greenEC.reload == 0.05)
            return true;
        return false;
    }

    void SetPrimaryCharacteristics()
    {
        redEC.maxHP = 6;
        redEC.reload = 1.5f;
        greenEC.maxHP = 6;
        greenEC.reload = 1.3f;
        mc.maxHP = 5f;
        enemyRedMC.speed = 1;
        enemyGreenMC.speed = 1.2f;
        meteorMC.speed = 1;
        meteorMC2.speed = 1;
        meteorMC3.speed = 1;
        meteorMC4.speed = 1;
        enemyLazersMC.speed = 3f;
        coins.speed = 1;
        spawner.spawnReload = 1;
        background.speed = 0.05f;
    }
}
