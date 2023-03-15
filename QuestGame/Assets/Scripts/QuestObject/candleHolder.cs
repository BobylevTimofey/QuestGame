using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleHolder : QuestObject
{
    public override double Weight => 0.2;

    public override string Name => "Подсвечник";

    public override Vector3 EquipPosition => throw new System.NotImplementedException();

    public override Quaternion EquipRotation => throw new System.NotImplementedException();
}

