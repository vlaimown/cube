using UnityEngine;

public class InputControllerKeyboard : InputController
{
    public override float VerticalAxisRaw()
    {
        return Input.GetAxisRaw(GlobalStringVars.VERTICAL);
    }

    public override float HorizontalAxisRaw()
    {
        return Input.GetAxisRaw(GlobalStringVars.HORIZONTAL);
    }

    public override bool VerticalAxisDown()
    {
        return Input.GetButtonDown(GlobalStringVars.VERTICAL);
    }

    public override bool HorizontalAxisDown()
    {
        return Input.GetButtonDown(GlobalStringVars.HORIZONTAL);
    }

    public override bool ActionInputDown()
    {
        return Input.GetButtonDown(GlobalStringVars.ACTION);
    }

    public override bool VerticalInputUp()
    {
        return Input.GetButtonUp(GlobalStringVars.VERTICAL);
    }

    public override bool HorizontalInputUp()
    {
        return Input.GetButtonUp(GlobalStringVars.HORIZONTAL);
    }

    public override bool ActionInputUp()
    {
        return Input.GetButtonUp(GlobalStringVars.ACTION);
    }
}
