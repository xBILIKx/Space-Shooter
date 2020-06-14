using System.Collections;
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
    public Background background;
    int count = 0;
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
        yield return new WaitForSeconds(50);
        redEC.maxHP += 3f * count;
        redEC.reload -= 0.1f;
        greenEC.maxHP += 4f * count;
        greenEC.reload -= 0.12f;
        mc.maxHP += 2f * count;
        enemyRedMC.speed += 1f;
        enemyGreenMC.speed += 1.5f;
        meteorMC.speed += 1;
        meteorMC2.speed += 1;
        meteorMC3.speed += 1;
        meteorMC4.speed += 1;
        enemyLazersMC.speed += 1.6f;
        coins.speed += 1;
        Spawner.instance.spawnReload -= 0.12f;
        background.speed += 0.03f;
        count += 1;
        if (count != 5)
            StartCoroutine(BoostEnemyCharacteristics());
        else
            Destroy(gameObject);
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
        Spawner.instance.spawnReload = 1;
        background.speed = 0.05f;
    }
}
