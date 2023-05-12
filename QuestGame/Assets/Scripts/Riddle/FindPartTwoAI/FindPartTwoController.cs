using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPartTwoController : MonoBehaviour
{
    [SerializeField] private GameObject partOneAI;
    [SerializeField] private GameObject partTwoAI;
    [SerializeField] int minDistance = 10;
    [SerializeField] int maxDistance = 50;
    private bool isStart;
    private bool isComplete;
    private Light lightPart;

    public void StartRiddle()
    {
        if (Inventory.inventory.Contains(partOneAI.GetComponent<PartOneAI>()))
        {
            lightPart = partOneAI.GetComponent<Light>();
            partOneAI.GetComponent<PartOneAI>().Equip();
            isStart = true;
            lightPart.enabled = true;
        }
    }

    private void Win()
    {
        isComplete = true;
        LevelChecker.IsHeroFindSecondPartAI = true;
        lightPart.enabled = false;
    }

    private void Update()
    {
        if(isStart && !isComplete)
        {
            if (Inventory.EquipedItem == partOneAI.GetComponent<PartOneAI>()
               && !Inventory.inventory.Contains(partTwoAI.GetComponent<PartTwoAI>()))
            {
                var intencity = Mathf.InverseLerp(maxDistance, minDistance, GetDistantion());
                lightPart.intensity = intencity * 10;
                Debug.Log(intencity * 10 + "---" + GetDistantion());
            }
            else if (Inventory.inventory.Contains(partTwoAI.GetComponent<PartTwoAI>()))
                Win();
        }
    }

    private float GetDistantion()
    {
        return Vector3.Distance(partOneAI.transform.position, partTwoAI.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isStart && other.gameObject.tag == "StartRiddleFindTwo")
            StartRiddle();
    }
}
