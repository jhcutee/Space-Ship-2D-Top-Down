
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootableObject", menuName = "ScriptableObject/ShootableObject")]
public class ShootableObject : ScriptableObject
{
    public string shootableObjectName = "Shootable Object";
    public ObjectType objectType;
    public int hpMax = 2;
    public List<DropList> dropList;
}
