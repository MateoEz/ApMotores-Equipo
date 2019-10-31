using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float life;
    public float damage;
    public float velocity;
    public Vector3 initialPosition;
    public GameObject prefabEnemy;
    public GameObject prefabLeader;
    public static Enemies Instance;
    public List<GameObject> enemies = new List<GameObject>();
    private bool deleted;
    private void Start()
    {
        Instance = this;
    }

    public void DeleteArmy()
    {
        deleted = true;
    }

    public void SpawnEnemies()
    {
        var enemy = Instantiate(prefabEnemy);
        var enemy2 = Instantiate(prefabEnemy);
        var enemy3 = Instantiate(prefabEnemy);
        var enemy4 = Instantiate(prefabEnemy);
        var enemy5 = Instantiate(prefabEnemy);
        var enemy6 = Instantiate(prefabEnemy);
        var enemy7 = Instantiate(prefabEnemy);
        var enemy8 = Instantiate(prefabEnemy);
        var enemy9 = Instantiate(prefabEnemy);
        var enemy10= Instantiate(prefabLeader);
        var enemy11= Instantiate(prefabEnemy);
        var enemy12 = Instantiate(prefabEnemy);
        var enemy13 = Instantiate(prefabEnemy);
        var enemy14 = Instantiate(prefabEnemy);
        var enemy15 = Instantiate(prefabEnemy);
        var enemy16 = Instantiate(prefabEnemy);
        var enemy17 = Instantiate(prefabEnemy);
        var enemy18 = Instantiate(prefabEnemy);
        var enemy19 = Instantiate(prefabEnemy);
        var enemy20 = Instantiate(prefabEnemy);
        initialPosition.y = 0.5f;
        enemy.transform.position = initialPosition +transform.right * 0.5f;
        enemy2.transform.position = initialPosition + transform.right * 2;
        enemy3.transform.position = initialPosition + -transform.right * 2;
        enemy4.transform.position = initialPosition + transform.forward * 2;
        enemy5.transform.position = initialPosition + -transform.forward * 2;
        enemy6.transform.position = initialPosition + transform.right  -transform.forward* 2;
        enemy7.transform.position = initialPosition + -transform.right -transform.forward * 2;
        enemy8.transform.position = initialPosition - transform.right * 0.5f;
        enemy9.transform.position = initialPosition + -transform.forward + -transform.right * 2;
        enemy10.transform.position = initialPosition + -transform.forward * 4;
        enemy11.transform.position = initialPosition + -transform.right * 0.5f;
        enemy12.transform.position = initialPosition + -transform.right * 4;
        enemy13.transform.position = initialPosition + -transform.right * 1;
        enemy14.transform.position = initialPosition + transform.forward * 6;
        enemy15.transform.position = initialPosition + -transform.forward * 5;
        enemy16.transform.position = initialPosition + transform.right - transform.forward * 4;
        enemy17.transform.position = initialPosition + -transform.right - transform.forward * 3;
        enemy18.transform.position = initialPosition - transform.right * 4;
        enemy19.transform.position = initialPosition + -transform.forward + -transform.right * 4;
        enemy20.transform.position = initialPosition + transform.forward * 6;
    }

}
