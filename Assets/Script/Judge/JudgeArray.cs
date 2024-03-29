using UnityEngine;
using System.Linq;

public class JudgeArray
{
    public int CheckAllTheSame(params int[] a)
    {
        int characterCount = a.Count(x => x == a[0]);

        if (characterCount == 9)
        {
            return OddsDict.dictOverall[(Odds)a[0]];
        }

        return CheckBoard(a);
    }

    public int CheckBoard(params int[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }

        if (anySeven == 9)
        {
            return OddsDict.dictOverall[Odds.anySeven];
        }
        else if (anyBar == 9)
        {
            return OddsDict.dictOverall[Odds.anyBar];
        }
        else if (anyFruit == 9)
        {
            return OddsDict.dictOverall[Odds.anyFruit];
        }
        else
        {
            return 0;
        }
    }

    public int CheckSeven(params int[] a)
    {
        int redSeven = a.Count(x => x == (int)Odds.gura);
        int blueSeven = a.Count(x => x == (int)Odds.ame);

        if (redSeven > 0 && blueSeven > 0)
        {
            return OddsDict.dictSpecial[Odds.anySeven][redSeven + blueSeven];
        }
        else if (redSeven == 0 && blueSeven > 1)
        {
            return OddsDict.dictSpecial[Odds.ame][blueSeven];
        }
        else if (redSeven > 1 && blueSeven == 0)
        {
            return OddsDict.dictSpecial[Odds.gura][redSeven];
        }
        return 0;
    }

    public int JudgeThree(params int[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }
        if (a[0] == a[1] && a[0] == a[2])
        {
            return OddsDict.dicNormal[(Odds)a[0]];
        }
        else if (anySeven == 3)
        {
            Debug.Log($"anySeven={anySeven}");
            return OddsDict.dicNormal[Odds.anySeven];
        }
        else if (anyBar == 3)
        {
            return OddsDict.dicNormal[Odds.anyBar];
        }
        else if (a[0] == (int)Odds.hololive)
        {
            if (a[0] == a[1]) return 5;
            else return 2;
        }
        return 0;
    }

    public void CheckEachCount(int a, ref int anySeven, ref int anyBar, ref int anyFruit)
    {
        switch (a)
        {
            case (int)Odds.gura:
            case (int)Odds.ame:
                anySeven++;
                break;
            case (int)Odds.ina:
            case (int)Odds.kronii:
            case (int)Odds.mumei:
                anyBar++;
                break;
            case (int)Odds.sana:
                break;
            default:
                anyFruit++;
                break;
        }
    }
}
