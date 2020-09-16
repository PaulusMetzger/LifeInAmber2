using UnityEngine;

public class RotationSc : MonoBehaviour
{
    public float rotation = 3f;
    public ButtonPress leftButton;
    public ButtonPress rightButton;
   
    void Start()
    {
        leftButton = GameObject.Find("LeftButton").GetComponent<ButtonPress>();
        rightButton = GameObject.Find("RightButton").GetComponent<ButtonPress>();
    }

    void Update()
    {
        if (leftButton.isPressed)
        {
            transform.Rotate(Vector3.up * rotation);
        }
        if (rightButton.isPressed)
        {
            transform.Rotate(Vector3.down * rotation);
        }
    }
}
