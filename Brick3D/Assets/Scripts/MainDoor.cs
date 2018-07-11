using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class MainDoor : MonoBehaviour {

    private Coroutine doorOpenHint;
    [HideInInspector()]
    private bool isStopped = true;

    private void OnHandHoverBegin(Hand hand) {
        if (!isStopped)
        {
            return;
        }
        if (doorOpenHint != null)
        {
            StopCoroutine(doorOpenHint);
            doorOpenHint = null;
        }
        doorOpenHint = StartCoroutine(OpenDoorTip(hand));
    }

    private IEnumerator OpenDoorTip(Hand hand)
    {
        isStopped = false;


        Animator ani = GetComponent<Animator>();
        var statInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (statInfo.IsName("door_3_closed"))
        {
            ani.SetTrigger("isTouching");
            ControllerButtonHints.ShowTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger, "开门中...");
        }
        else if (statInfo.IsName("door_3_opened"))
        {
            ani.ResetTrigger("isTouching");
            ControllerButtonHints.ShowTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger, "关门中...");
        }

        yield return new WaitForSeconds(1.0f);

        ControllerButtonHints.HideTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger);
        isStopped = true;
    }
}
