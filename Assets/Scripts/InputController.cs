using UnityEngine;

public static class InputController 
{

    public static float GetHorizontalMovement(int controller)
    {
        return Input.GetAxis("C" + controller + "_LeftJoystickX");
    }

    public static bool IsJumpButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_AButton");
    }

    public static bool IsAttackButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_XButton");
    }

    public static bool IsSpecialAttackButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_YButton");
    }

    public static bool IsStartButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_StartButton");
    }

    public static bool IsStartButtonPressed()
    {
        return Input.GetButtonDown("StartButton");
    }



    public static Vector3 GetRightJoystickFromPlayer(int controller)
    {
        float h = Input.GetAxis("C" + controller + "_RightJoystickX");
        float v = Input.GetAxis("C" + controller + "_RightJoystickY");
        
        return new Vector3(h,0,v);
    }

    public static Vector3 GetLeftJoystickFromPlayer(int controller)
    {
        float h = GetHorizontalMovement(controller);
        float v = Input.GetAxis("C" + controller + "_LeftJoystickY");

        return new Vector3(h, 0, v);
    }

    public static bool IsAButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_AButton");
    }

    public static bool IsBButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_BButton");
    }

    public static bool IsXButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_XButton");
    }

    public static bool IsYButtonPressed(int controller)
    {
        return Input.GetButtonDown("C" + controller + "_YButton");
    }

    public static bool IsYButtonHeldDown(int controller)
    {
        return Input.GetButton("C" + controller + "_YButton");
    }

    public static float GetLeftTriggerFromPlayer(int controller)
    {
        return Input.GetAxis("C" + controller + "_LeftTrigger");
    }

    public static float GetRightTriggerFromPlayer(int controller)
    {
        return Input.GetAxis("C" + controller + "_RightTrigger");
    }

}


