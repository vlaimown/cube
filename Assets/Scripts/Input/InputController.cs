using UnityEngine;

public class InputController : MonoBehaviour
{
    public virtual float VerticalAxisRaw()
    {
        return 0;
    }

    public virtual float HorizontalAxisRaw()
    {
        return 0;
    }

    public virtual bool VerticalAxisDown()
    {
        return false;
    }

    public virtual bool HorizontalAxisDown()
    {
        return false;
    }

    public virtual bool VerticalInputUp()
    {
        return false;
    }

    public virtual bool HorizontalInputUp()
    {
        return false;
    }

    public virtual bool ActionInputDown()
    {
        return false;
    }

    public virtual bool ActionInputUp()
    {
        return false;
    }
}
