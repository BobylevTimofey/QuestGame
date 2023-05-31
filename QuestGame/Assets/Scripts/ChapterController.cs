using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDeactivate;
    [SerializeField]
    private List<GameObject> objectsToActivate;
    [SerializeField]
    private Transform AI;
    [SerializeField]
    private PlayerNPC player;
    [SerializeField]
    private Transform AIPoint;
    [SerializeField]
    private Transform playerPoint;

    public void TransitObjects()
    {
        player.transform.position = playerPoint.position;
        player.transform.rotation = playerPoint.rotation;
        AI.position = AIPoint.position;
        AI.rotation = AIPoint.rotation;

        LevelChecker.IsHeroTalkAIFirstTime = true;
    }

    public void StartPlayerDialogue()
    {
        player.PlayDialogue();
        Destroy(gameObject);
    }
}
