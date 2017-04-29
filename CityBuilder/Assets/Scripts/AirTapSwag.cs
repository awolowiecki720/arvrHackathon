using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class AirTapSwag : MonoBehaviour
{
    public static bool AirTap = false;
    public static GameObject GazeTarget;
    public static Vector3 GazeTargetPos;

    bool mWasPressed;

    void LateUpdate()
    {
        // Update AirTap
        bool isPressed = Input.GetMouseButton(0);
        foreach (InteractionSourceState iss in InteractionManager.GetCurrentReading())
        {
            isPressed = iss.pressed;
        }

        AirTap = mWasPressed && !isPressed;
        mWasPressed = isPressed;

        // Update GazeTarget
        GazeTarget = GazeManager.Instance.HitObject;
        GazeTargetPos = GazeManager.Instance.HitPosition;

    }
}
