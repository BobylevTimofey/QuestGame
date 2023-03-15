using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronOre : QuestObject
{
    public override double Weight => 2;

    public override string Name => "Железная руда";

    public override Vector3 EquipPosition => new Vector3(-0.595066726f, 0.019610703f, 0.488674909f);

    public override Quaternion EquipRotation => new Quaternion(0.80719775f, 0.534711361f, 0.0168774929f, 0.249460638f);
}
