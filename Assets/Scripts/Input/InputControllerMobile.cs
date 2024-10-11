using UnityEngine;

public class InputControllerMobile : InputController
{
    public override float VerticalAxisRaw()
    {
        if (Input.touchCount != 0)
        {
            float deltaPositionY = Input.GetTouch(0).deltaPosition.y;
            return deltaPositionY / Mathf.Abs(deltaPositionY);
        }
        else
        {
            return 0;
        }
    }

    public override float HorizontalAxisRaw()
    {
        if (Input.touchCount != 0)
        {
            float deltaPositionX = Input.GetTouch(0).deltaPosition.x;
            return deltaPositionX / Mathf.Abs(deltaPositionX);
        }
        else
        {
            return 0;
        }
    }

    public override bool VerticalAxisDown()
    {
        if (Input.touchCount != 0)
        {
            float deltaPositionY = Input.GetTouch(0).deltaPosition.y;
            return deltaPositionY != 0;
        }
        else
        {
            return false;
        }
    }

    public override bool HorizontalAxisDown()
    {
        if (Input.touchCount != 0)
        {
            float deltaPositionX = Input.GetTouch(0).deltaPosition.x;
            return deltaPositionX != 0;
        }
        else
        {
            return false;
        }
    }

    public override bool ActionInputDown()
    {
        if (Input.touchCount != 0 
            && Input.GetTouch(0).phase == TouchPhase.Began 
            && Input.GetTouch(0).deltaPosition == Vector2.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        //print(Input.GetTouch(0).deltaPosition.x);
    }
}