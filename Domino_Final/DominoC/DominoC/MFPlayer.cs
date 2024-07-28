using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoC
{
    class MFPlayer
    {
        static public string PlayerName = "Балбес";
        static private List<MTable.SBone> lHand;


        //=== Готовые функции =================
        // инициализация игрока
        static public void Initialize()
        {
            lHand = new List<MTable.SBone>();
        }

        // Вывод на экран
        static public void PrintAll()
        { MTable.PrintAll(lHand); }

        // дать количество доминушек
        static public int GetCount()
        { return lHand.Count; }

        //=== Функции для разработки =================
        // добавить доминушку в свою руку
        static public void AddItem(MTable.SBone sb)
        { lHand.Add(sb); }

        // дать сумму очков на руке
        static public int GetScore()
        {
            int score = 0;
            int count = 0;
            foreach (MTable.SBone element in lHand)
            {
                ++count;
                score = score + element.First + element.Second;
            }
            if (count == 1 && score == 0)
            {
                score += 25;
            }
            return score;
        }
        static private bool DuplicateSearch(ushort m, out MTable.SBone result)
        {
            foreach (MTable.SBone element in lHand)
            {
                if (element.First == m && element.Second == m)
                {
                    result = element;
                    return true;
                }
            }
            result.First = 999;
            result.Second = 999;
            return false;
        }
        // сделать ход
        static public bool MakeStep(out MTable.SBone sb, out bool End)
        {
            //инициализация
            List<MTable.SBone> NowGameCollection = MTable.GetGameCollection(); //текущая игра
            MTable.SBone result;
            ushort mleft = NowGameCollection[0].First, mright = NowGameCollection[NowGameCollection.Count - 1].Second; //крайние масти
            int countleft = 0, countright = 0; //счетчики
            //считаем сколько есть доминошек с мастями m1 m2
            foreach (MTable.SBone element in lHand)
            {
                if (element.First == mleft || element.Second == mleft)
                {
                    ++countleft;
                }
                if (element.First == mright || element.Second == mright)
                {
                    ++countright;
                }
            }
            //инициализируем переменную mmaxcount и присваиваем ей значение
            ushort mmaxcount;
            if (countleft >= countright)
            {
                mmaxcount = mleft;
                End = false;
            }
            else
            {
                mmaxcount = mright;
                End = true;
            }
            if (MTable.GetShopCount() > 0 && countleft == 0 && countleft == countright)
            {
                bool flag = false;
                while (flag == false && MTable.GetShopCount() > 0)
                {
                    MTable.GetFromShop(out result);
                    AddItem(result);
                    if (result.First == mleft || result.Second == mleft)
                    {
                        flag = true;
                        End = false;
                        sb = result;
                        lHand.Remove(result);
                        return true;
                    }
                    if (result.First == mright || result.Second == mright)
                    {
                        flag = true;
                        End = true;
                        sb = result;
                        lHand.Remove(result);
                        return true;
                    }
                }
            }
            else if (DuplicateSearch(mmaxcount, out result))
            {
                sb = result;
                lHand.Remove(result);
                return true;
            }
            else
            {
                foreach (MTable.SBone element in lHand)
                {
                    if (element.First == mmaxcount || element.Second == mmaxcount)
                    {
                        sb = element;
                        lHand.Remove(element);
                        return true;
                    }
                }
            }
            sb.First = 9999;
            sb.Second = 9999;
            return false;
        }

    }
}
