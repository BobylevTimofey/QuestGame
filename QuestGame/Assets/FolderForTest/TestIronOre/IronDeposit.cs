using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IronDeposit : MonoBehaviour
{
    public QuestObject correctObject;
    public GameObject IronOre;
    public GameObject Stone;
    private int counter = 0;
    public Slider MiningProgress;
    private readonly float WaitSeconds = 0.2f;
    //private int maxCount = 10;
    //private int currentCount = 0;
    private Animator animator;
    private GameObject spawnedObject;
    private void Awake()
    {
        MiningProgress.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (/*currentCount < maxCount && */Inventory.EquipedItem == correctObject)
        {
            if (animator == null)
                animator = Inventory.EquipedItem.transform.parent.GetComponent<Animator>();
            animator.Play("Hit");

            counter++;
            MiningProgress.gameObject.SetActive(true);
            MiningProgress.value = counter;
            if (counter == 5)
            {
                SpawnIronOre();
                counter = 0;
                //currentCount++;
            }
        }
    }
    private void OnMouseUp()
    {
        StartCoroutine(WaitAndCloseProgress(WaitSeconds));
    }

    IEnumerator WaitAndCloseProgress(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MiningProgress.gameObject.SetActive(false);
    }

    private void SpawnIronOre()
    {
        var rnd = new System.Random();
        var chance = rnd.Next(3);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        spawnedObject = Instantiate(chance == 0 ? IronOre : Stone, (transform.position + objPosition) / 2, Quaternion.identity);
        if (spawnedObject.name.Contains(IronOre.name))
        {
            MiningProgress.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
