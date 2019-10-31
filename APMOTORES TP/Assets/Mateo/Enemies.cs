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
        initialPosition.y = 0.5f;
        enemy.transform.position = initialPosition;
        var leader = Instantiate(prefabLeader);
        leader.transform.position = initialPosition + transform.forward * 5 + transform.right *1;
    }

}
