using UnityEngine;


[CreateAssetMenu(fileName = "Soldier", menuName = "Soldier/Soldier Settings")]
public  class SoldierSettings : ScriptableObject
{
    //public string name;
    public  int life;
    public  int speed;
    public  int damage;
    public  Vector3 initialPos;
    public  GameObject prefabSoldier;
}
