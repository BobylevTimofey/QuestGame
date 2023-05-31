using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class InsertPuzzle : MonoBehaviour
{
    public List<PartPuzzle> PartsPuzzle;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    [SerializeField]
    private Transform cutsceneCameraPoint;
    private Transform previousCameraPoint;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        previousCameraPoint = cinemachine.Follow;
    }
    public void CheckPuzzle()
    {
        var allPartsIsSolve = true;
        foreach (var partPuzzle in PartsPuzzle)
            if (!partPuzzle.IsSolve)
                allPartsIsSolve = false;
        if (allPartsIsSolve)
            performVictoriousActions();

    }

    private void performVictoriousActions()
    {
        if (LevelChecker.IsHeroTakeTaskMinerWithGears)
            LevelChecker.IsHeroDidTaskMinerWithGears = true;
        LevelChecker.IsSolveQuestInCastleWithSearchItems = true;
        PlayCutscene();
    }

    public void PlayCutscene()
    {
        animator.Play("OpenGatesDown");
        cinemachine.Follow = cutsceneCameraPoint;
    }

    public void EndCutscene()
    {
        cinemachine.Follow = previousCameraPoint;
    }
}
