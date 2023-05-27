using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PieceOfGearPuzzle : MonoBehaviour
{
    private Puzzle puzzle;
    [SerializeField]
    private GameObject gearPreview;
    public List<Transform> PartsOfGear;
    public List<Transform> SolvedParts;
    private bool isWin = false;
    [SerializeField]
    private Gear gear;
    private bool canUpdate = true;
    private void Awake()
    {
        foreach (Transform partOfGear in PartsOfGear)
            partOfGear.gameObject.SetActive(false);
        puzzle = transform.parent.GetComponent<Puzzle>();
    }

    private void Update()
    {
        if (canUpdate)
            Interactive();

        if (isWin)
            Win();
    }

    private void Win()
    {
        isWin = false;
        canUpdate = false;
        var newGear = Instantiate(gear.gameObject, gearPreview.transform);
        newGear.GetComponent<Rigidbody>().isKinematic = true;
        newGear.transform.localPosition = Vector3.zero;
        newGear.transform.localRotation = Quaternion.identity;
        newGear.transform.localScale = Vector3.one;
        newGear.transform.SetParent(transform.parent);
        Destroy(gearPreview);
        foreach (var part in SolvedParts)
            Destroy(part.gameObject);
        Message.Instance.LoadMessage("Деталь собрана!", 2);

        transform.parent.GetComponent<Puzzle>().ExitPuzzle();
    }

    public void CheckWin()
    {
        if (PartsOfGear.Select(part => part.GetComponent<PartOfPuzzle>()).All(part => part.IsCorrect))
            isWin = true;
    }

    private void Interactive()
    {
        if (puzzle.CanSolve)
        {
            gearPreview.SetActive(true);
            for (int i = 0; i < Inventory.inventory.FindAll(obj => obj is PieceOfGear).Count; i++)
                PartsOfGear[i].gameObject.SetActive(true);
        }
        else
        {
            gearPreview.SetActive(false);
            foreach (Transform partOfGear in PartsOfGear)
                if (!partOfGear.GetComponent<PartOfPuzzle>().IsCorrect)
                    partOfGear.gameObject.SetActive(false);
        }
    }
}
