using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : QuestObject
{
    public override double Weight => 2;

    public override string Name => "Камень";

    public override Vector3 EquipPosition => new Vector3(-0.351999998f, 0.175999999f, 0.218999997f);

    public override Quaternion EquipRotation => new Quaternion(-0.340396971f, -0.0453358777f, -0.769616187f, -0.538298845f);
}
