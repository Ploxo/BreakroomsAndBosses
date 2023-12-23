using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Enemy enemy;
    public PlayerInfo player;
    public string successBlockName = "success";
    public string failedBlockName = "failed";
    public string nothingBlockName = "nothing";
    public string questionStandardName = "question";
    public GameObject battleUI;
    //public InfluenceBar influence;
    private Button[] buttons;
    public int SelectIndex;
    private EventSystem ourEventSystem;

    Button CurrentButton
    {
        get {
            return buttons[SelectIndex];
        }
    }

    // Use this for initialization
    void Start()
    {
        buttons = battleUI.GetComponentsInChildren<Button>();
        ourEventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSelectable()) {
            return;
        }
        getImageByCurrentIndex().enabled = false;

        SelectIndex += getInput();
        SelectIndex = clampSelectedIndex();

        if (Input.GetButtonDown("Submit") && CurrentButton.onClick != null) {
            clickButton(CurrentButton.gameObject);
        }
        getImageByCurrentIndex().enabled = true;
    }

    void clickButton(GameObject button)
    {
        ExecuteEvents.Execute(button, new BaseEventData(ourEventSystem), ExecuteEvents.submitHandler);
    }

    bool isSelectable()
    {
        return true;
    }

    int clampSelectedIndex()
    {
        int currentIndex = SelectIndex;
        if (currentIndex < 0) {
            currentIndex = buttons.Length - 1;
        }
        else if (currentIndex >= buttons.Length) {
            currentIndex = 0;
        }
        return currentIndex;
    }

    int getInput()
    {
        int input = 0;
        if (Input.GetButtonDown("Right")) {
            input = 1;
        }
        else if (Input.GetButtonDown("Left")) {
            input = -1;
        }
        return input;

    }

    Image getImageByCurrentIndex()
    {
        return buttons[SelectIndex]
            .GetComponentInChildren<SelectComponent>()
            .GetComponent<Image>();
    }


    public void attack(ButtonStats buttonStats)
    {
        bool oneChoiceMatched = false;
        /*foreach (Stats btnStat in buttonStats.statsOfButton) {
            foreach (Stats bad in enemy.badAgainst) {
                if (bad == btnStat) {
                    enemy.enemyFlowChart.ExecuteBlock(successBlockName);
                    oneChoiceMatched = true;
                    //influence.Increase(10);
                }
            }
            foreach (Stats good in enemy.goodAgainst) {
                if (good == btnStat) {
                    enemy.enemyFlowChart.ExecuteBlock(failedBlockName);
                    oneChoiceMatched = true;
                    //influence.Decrease(10);
                }
            }
        }
        if (!oneChoiceMatched) {
            enemy.enemyFlowChart.ExecuteBlock(nothingBlockName);
        }*/
        battleUI.SetActive(false);


    }

    public void gotoQuestion(int number)
    {
        enemy.enemyFlowChart.ExecuteBlock(questionStandardName + number);
    }
}
