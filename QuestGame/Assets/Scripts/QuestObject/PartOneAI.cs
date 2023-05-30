using UnityEngine;

public class PartOneAI : QuestObject
{
    public override double Weight => 1;

    public override string Name => "Первая часть ИИ";

    public override Vector3 EquipPosition => new Vector3(-0.351999998f, 0.175999999f, 0.218999997f);

    public override Quaternion EquipRotation => new Quaternion(-0.340396971f, -0.0453358777f, -0.769616187f, -0.538298845f);
}
