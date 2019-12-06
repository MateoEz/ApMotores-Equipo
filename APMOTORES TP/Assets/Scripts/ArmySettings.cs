using UnityEngine;

[CreateAssetMenu(fileName = "Army", menuName = "Army/Army Configuration")]
public class ArmySettings : ScriptableObject
{
    public SoldierSettings soldierPreset;
    public int numberOfSoldiers;
    public bool queueFormation;
    public bool randomFormation;
    public  Vector3 initialPos;
}