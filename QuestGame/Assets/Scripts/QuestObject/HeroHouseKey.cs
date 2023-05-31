using UnityEngine;

public class HeroHouseKey : QuestObject
{
    public override double Weight => 1;

    public override string Name => "Ключ";

    public override Vector3 EquipPosition => new Vector3(-0.393000007f, 0.476999998f, -0.0839999989f);

    public override Quaternion EquipRotation => new Quaternion(0.349363238f, 0.612758517f, 0.650814354f, 0.280914873f);
}
