using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float life;
    protected float damage;
    protected float velocity;

    public void Start()
    {
        damage = Enemies.Instance.damage;
        life = Enemies.Instance.life;
        velocity = Enemies.Instance.velocity;
    }
}
