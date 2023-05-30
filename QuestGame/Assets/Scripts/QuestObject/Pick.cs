using UnityEngine;

public class Pick : QuestObject
{
    public override double Weight => 3;

    public override string Name => "Кирка";

    public override Vector3 EquipPosition => new Vector3(-0.693000019f, 0.0149999997f, 0.200000003f);

    public override Quaternion EquipRotation => new Quaternion(-0.0513801426f, 0.00903961062f, 0.635769367f, 0.770114124f);
}
