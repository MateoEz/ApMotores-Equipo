using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float life;
    public float damage;
    public float velocity;
    public GameObject prefabEnemySquare;
    public GameObject prefabEnemyTriangle;
    public GameObject prefabEnemyCircle;
    public GameObject prefabLeader;
    public static Enemies Instance;
    public Vector3 Position;
    private List<GameObject> enemies = new List<GameObject>();
    private bool deleted;
    private GameObject _armySquare;
    private GameObject _armyCircle;
    private GameObject _armyTriangle;
    private GameObject _leader;
    private void Start()
    {
        Instance = this;
    }
    public void DeleteArmySquare()
    {
        DestroyImmediate(_armySquare);
        DestroyImmediate(_leader);
    }
    public void DeleteArmyCircle()
    {
        DestroyImmediate(_armyCircle);
    }
    public void DeleteArmyTriangle()
    {
        DestroyImmediate(_armyTriangle);
    }
    public void SpawnEnemiesSquare()
    {
        var enemy = Instantiate(prefabEnemySquare);
        Position.y = 0.5f;
        enemy.transform.position = Position;
        var leader = Instantiate(prefabLeader);
        leader.transform.position = Position + transform.forward * 5 + transform.right *1;
        _armySquare = enemy;
        _leader = leader;
    }
    public void SpawnEnemiesCircle()
    {
        var enemy = Instantiate(prefabEnemyCircle);
        Position.y = 0.5f;
        enemy.transform.position = Position;
        _armyCircle = enemy;
    }
    public void SpawnEnemiesTriangle()
    {
        var enemy = Instantiate(prefabEnemyTriangle);
        Position.y = 0.5f;
        enemy.transform.position = Position;
        _armyTriangle = enemy;
    }
}
