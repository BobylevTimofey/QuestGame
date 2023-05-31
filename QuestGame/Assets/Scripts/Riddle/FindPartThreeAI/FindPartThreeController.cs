using System.Collections;
using UnityEngine;

public class FindPartThreeController : MonoBehaviour
{
    [SerializeField] private GameObject partTwoAI;
    [SerializeField] private GameObject partThreeAI;
    [SerializeField] private int secondsThroughPlaySound = 5;
    [SerializeField] int minDistance = 5;
    [SerializeField] int maxDistance = 30;
    private bool isStart;
    private bool isComplete;
    private AudioSource audioSource;

    public void StartRiddle()
    {
        if (Inventory.inventory.Contains(partTwoAI.GetComponent<PartTwoAI>()))
        {
            audioSource = GetComponent<AudioSource>();
            partTwoAI.GetComponent<PartTwoAI>().Equip();
            isStart = true;
            StartCoroutine(PlaySoundFindPart());
        }
    }

    private void Win()
    {
        isComplete = true;
        LevelChecker.IsHeroFindThirdPartAI = true;
    }

    IEnumerator PlaySoundFindPart()
    {
        while (!isComplete)
        {
            if (Inventory.EquipedItem == partTwoAI.GetComponent<PartTwoAI>()
                && !Inventory.inventory.Contains(partThreeAI.GetComponent<PartThreeAI>()))
            {
                var volume = Mathf.InverseLerp(maxDistance, minDistance, GetDistantion());
                audioSource.volume = volume;
                Debug.Log(volume + "---" + GetDistantion());
                audioSource.Play();
            }
            else if(Inventory.inventory.Contains(partThreeAI.GetComponent<PartThreeAI>()))
                Win();
            yield return new WaitForSeconds(secondsThroughPlaySound);
        }
    }

    private float GetDistantion()
    {
        return Vector3.Distance(partTwoAI.transform.position, partThreeAI.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isStart && other.gameObject.tag == "StartRiddleFindThree")
            StartRiddle();
    }
}
