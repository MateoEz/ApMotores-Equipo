using UnityEngine;

[CreateAssetMenu(fileName = "Soldier", menuName = "Soldier/Soldier Settings")]
public class SoldierSettings : ScriptableObject
{
    public int life;
    public int speed;
    public int damage;
    public GameObject prefabSoldier;
}
