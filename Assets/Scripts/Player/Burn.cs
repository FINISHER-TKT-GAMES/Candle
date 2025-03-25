using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Burn : MonoBehaviour
{

    [SerializeField]
    private PlayerManager player;

    public GameObject[] List_Vines;

    private Animator animator;

    public int burnTime;
    private int burningTime = 0;

    private int animation = 0;

    private bool isTimerRunning;

    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Time(1));
    }


    public void OnTriggerStay(Collider @object)
    {
        print(animator);
        if (@object.CompareTag("Player") && player.data.movementState == PlayerData.MovementState.bending) {

        }
    }

    public IEnumerator Time(float time) {
        while (time >= 0) {
            yield return new WaitForSeconds(1);
            time--;
        }
        List_Vines[animation].GetComponent<Animator>().SetBool("Start", true);
        animation++;
        StartCoroutine(Time(1));
    }



    /*public void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("New Animation6"))
        {
            Destroy(this);
        }
    }*/



}

