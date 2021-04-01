using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button button;
    public Sprite Mark_X;
    public Sprite Mark_0;
    public Sprite NONE;
    public Text WinText;
    public Button RegameButton;
    bt = GameObject.Find("RegameButton").GetComponent<Button>();
    public string[] board = {"n","n","n",
                             "n","n","n",
                             "n","n","n"};
    public string turn = "X";

    public void UpdateGame(int number)
    {
        if (turn == "X")
        {
            board[number] = "X";
            turn = "O";
        }
        else
        {
            board[number] = "O";
            turn = "X";
        }

        if (CheckWin() == "Win")
        {
            if (turn == "X")
            {
                WinText.text = "O Won";
            }
            else
            {
                WinText.text = "X Won";
            }
            //turn == "X" ? WinText.text = "O Won" : WinText.text = "X Won";
        }
        if (CheckWin() == "Draw")
        {

            WinText.text = "Draw";
        }
    }
  
    public void oc(string number)
    {
        button = GameObject.Find("Button"+number).GetComponent<Button>();
        if (turn == "X")
        {
            button.image.overrideSprite = Mark_X;
        }
        else
        {
            button.image.overrideSprite = Mark_0;
        }
        button.GetComponent<Image>().color = new Color(255, 255, 255);
        //button.interactable = false;
 
        
    }
    public string CheckWin()
    {
        
            if (board[0] == board[1] && board[1] == board[2] && board[0] != "n" ||
                board[0] == board[3] && board[3] == board[6] && board[0] != "n" ||
                board[6] == board[7] && board[7] == board[8] && board[8] != "n" ||
                board[2] == board[5] && board[5] == board[8] && board[8] != "n" ||
                board[1] == board[4] && board[4] == board[7] && board[7] != "n" ||
                board[3] == board[4] && board[4] == board[5] && board[5] != "n" ||
                board[2] == board[4] && board[4] == board[6] && board[6] != "n" ||
                board[0] == board[4] && board[4] == board[8] && board[8] != "n")
            {
                Debug.Log(turn + " Wins");
                return "Win";
            }

        if (board.Contains("n"))
        {
            Debug.Log("ingame");
            return "InGame";
        }
        else
        {
            Debug.Log("draw");
            return "Draw";
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = "n";
            button = GameObject.Find("Button" + i).GetComponent<Button>();
            button.image.overrideSprite = NONE;
        }
    }
    
}
