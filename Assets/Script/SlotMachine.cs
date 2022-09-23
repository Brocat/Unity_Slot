using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];

    [Range(0, 9)][SerializeField] int minRandomNum = 0;
    [Range(0, 10)][SerializeField] int maxRandomNum = 10;

    [SerializeField] Button rotateBtn;

    CalculateMoney calculateMoney = new CalculateMoney();

    public void Spin()
    {
        StartCoroutine(SpinAndStopAndCal());
    }

    void BoardRandomNumber()
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(minRandomNum, maxRandomNum);
        }
        ShowBoardNum();
    }

    void ShowBoardNum()
    {
        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponentInChildren<TextMeshProUGUI>().text = boardNum[i].ToString();
        }
    }

    IEnumerator SpinAndStopAndCal()
    {
        BoardRandomNumber();
        rotateBtn.interactable = false;
        yield return new WaitForSeconds(0.5f);
        rotateBtn.interactable = true;
        int oddsTotal = calculateMoney.GetOddsTotal(boardNum);
        Debug.Log(oddsTotal);
    }
}
