using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class GlassDoorHandle : MonoBehaviour
{
    public Animator door;
    
    private void OnHandHoverBegin(Hand hand)
    {
        var statInfo = door.GetCurrentAnimatorStateInfo(0);
        if (statInfo.IsName("glass_door_closed"))
        {
            ControllerButtonHints.ShowTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger, "开门");
        }
        else if (statInfo.IsName("glass_door_opened"))
        {
            ControllerButtonHints.ShowTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger, "关门");

        }
    }

    private void OnHandHoverEnd(Hand hand)
    {
        ControllerButtonHints.HideTextHint(hand, EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger)))
        {
            var statInfo = door.GetCurrentAnimatorStateInfo(0);
            if (statInfo.IsName("glass_door_closed"))
            {
                door.SetBool("isOpening", true);
            } else if (statInfo.IsName("glass_door_opened"))
            {
                door.SetBool("isOpening", false);

            }
        }
    }
}