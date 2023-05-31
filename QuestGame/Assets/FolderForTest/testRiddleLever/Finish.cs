using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private Lever lever;
    private Animator animator;
    private bool isWin = false;
    private Puzzle puzzle;
    private void Awake()
    {
        puzzle = transform.parent.GetComponent<Puzzle>();
        animator = puzzle.GetComponent<Animator>();
    }
    private void Update()
    {
        if (isWin)
            MoveLever();

    }

    private void OnTriggerEnter(Collider other)
    {
        isWin = true;
    }

    private void Win()
    {
        isWin = false;
        Debug.Log("Win!");
        LevelChecker.IsSolveQuestLever = true;
        puzzle.PlayCutscene();
        animator.Play("OpenGates");
    }

    private void MoveLever()
    {
        Destroy(lever.GetComponent<Collider>());
        lever.transform.SetParent(transform);
        var winPos = new Vector3(4, 0, 0);
        lever.transform.localPosition = Vector3.MoveTowards(lever.transform.localPosition, winPos, 5 * Time.deltaTime);
        if (lever.transform.localPosition == winPos)
            Win();
    }
}
