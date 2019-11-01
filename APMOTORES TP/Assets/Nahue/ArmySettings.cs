using UnityEngine;

[CreateAssetMenu(fileName = "Army", menuName = "Amry/Army Configuration")]
public class ArmySettings : ScriptableObject
{
    public string armyName;
    public int soldiers;
    public int boss;
    public bool squareFormation;
    public bool triangleFormation;
    public bool circleFormation;
}