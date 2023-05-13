using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : QuestObject
{

    public override double Weight => 1;

    public override string Name => "Шестерёнка";

    public override Vector3 EquipPosition => new Vector3(-0.294999987f, 0.388999999f, 0.114f);

    public override Quaternion EquipRotation => new Quaternion(-0.474757195f, -0.394119412f, -0.763177514f, -0.191926301f);
}
