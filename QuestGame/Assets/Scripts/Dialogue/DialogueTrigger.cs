using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private string triggerName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (triggerName)
            {
                case "Mountain":
                    LevelChecker.IsComeToMountain = true;
                    break;
                case "Bridge":
                    LevelChecker.IsOnBridge = true;
                    break;
                case "Castle":
                    LevelChecker.IsInCastle = true;
                    break;
                default:
                    break;
            }
            PlayerNPC.Instance.PlayDialogue();
            Destroy(gameObject);
        }
    }
}
