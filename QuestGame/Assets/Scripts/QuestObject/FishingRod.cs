using UnityEngine;

public class FishingRod : QuestObject
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;

    private void Start()
    {
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, pos1.position);
        lineRenderer.SetPosition(1, pos2.position);
    }

    public override double Weight => 1;

    public override string Name => "Удочка";

    public override Vector3 EquipPosition => new Vector3(-0.351999998f, 0.175999999f, 0.218999997f);

    public override Quaternion EquipRotation => new Quaternion(-0.340396971f, -0.0453358777f, -0.769616187f, -0.538298845f);

}
