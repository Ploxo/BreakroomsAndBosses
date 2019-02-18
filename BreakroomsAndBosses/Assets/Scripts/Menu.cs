using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Direction
{
    up,
    right,
    down,
    left
}

public class Menu : MonoBehaviour
{
    [SerializeField]
    public Transform buttonsParent;
    private Button[] options;
    private Vector2Int SelectedIndex = Vector2Int.zero;
    [SerializeField]
    private Vector2Int size;
    public EventSystem ourEventSystem;

    public event System.Action<Button> onSelect;
    public event System.Action<Button> onDeselect;

    private Button CurrentButton
    {
        get {
            return options[SelectedIndex.x + (SelectedIndex.y * size.x)];
        }
    }


    public void Start()
    {
        options = buttonsParent.GetComponentsInChildren<Button>();
        if (options.Length != (size.x * size.y)) {
            Debug.LogError("missmatch in Menu size and buttonCount (" + transform.name + ")");
        }
        if (onSelect != null) {
            onSelect(CurrentButton);
        }
    }


    private int getNegativeMoveFrom(int i,int size)
    {
        i--;
        if (i < 0) {
            i += size;
        }
        return i;
    }

    private int getPositiveMoveFrom(int i, int size)
    {
        return (i + 1) % size;
    }

    public void Move(Direction dir)
    {
        if (onDeselect != null) {
            onDeselect(CurrentButton);
        }
        switch (dir) {
            case Direction.up:
                SelectedIndex.y = getNegativeMoveFrom(SelectedIndex.y,size.y);
                break;

            case Direction.left:
                SelectedIndex.x = getNegativeMoveFrom(SelectedIndex.x, size.x);

                break;

            case Direction.right:
                SelectedIndex.x = getPositiveMoveFrom(SelectedIndex.x, size.x);

                break;

            case Direction.down:
                SelectedIndex.y = getPositiveMoveFrom(SelectedIndex.y, size.y);
                break;
        }
        if (onSelect != null) {
            onSelect(CurrentButton);
        }

    }
    public void PressSelectedButton()
    {
        Button button = options[SelectedIndex.x + (SelectedIndex.y * size.x)];

        ExecuteEvents.Execute(button.gameObject, new BaseEventData(ourEventSystem), ExecuteEvents.submitHandler);
    }



}
