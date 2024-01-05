using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coloring;
using MainGame;
using Info;
using Item;
using System.Reflection;
using Rest;

namespace Dungeon
{
    enum Situation
    {
        Normal,
        Clear
    }

    public struct DungeonDifficult
    {
        public string name;
        public float defReq;
        public float gold;

        public DungeonDifficult(string _name, float _defReq, float _gold)
        {
            name = _name;
            defReq = _defReq;
            gold = _gold;
        }
    }

    public class DungeonPage
    {
        public static DungeonPage _instance;

        public static DungeonPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DungeonPage();
                }
                return _instance;
            }
        }

        Situation situation = Situation.Normal;

        int x, y;

        Random random = new Random();

        List<DungeonDifficult> Dundiffs = new List<DungeonDifficult>();

        float beforeHp;
        float beforeGold;
        string selectDungeon;


        public void DunInit()
        {
            DungeonPage.Instance.Dundiffs.Add(new DungeonDifficult("쉬운 던전", 5, 1000));
            DungeonPage.Instance.Dundiffs.Add(new DungeonDifficult("일반 던전", 11, 1700));
            DungeonPage.Instance.Dundiffs.Add(new DungeonDifficult("어려운 던전", 17, 2500));
        }



        public void DungeonAnnounce()
        {
            if (situation == Situation.Normal)
            {
                ChangeColor.ColorYellow("던전입장\n");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

                for (int i = 0; i < Dundiffs.Count; i++)
                {
                    DungeonDiff(i + 1, Dundiffs[i].name, Dundiffs[i].defReq);
                }

                Console.WriteLine();
                ChangeColor.ColorMagenta("0");
                Console.WriteLine(". 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string index = Console.ReadLine();
                Console.Clear();

                switch (index)
                {
                    case "1":
                    case "2":
                    case "3":
                        DungeonEnter(index);
                        break;
                    case "0":
                        Player.SetScene(Scene.Start);
                        break;

                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }
            else if (situation == Situation.Clear)
            {
                ChangeColor.ColorYellow("던전 클리어\n");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine(selectDungeon + "을 클리어 하였습니다.\n");

                Console.WriteLine("[탐험 결과]");
                Console.Write("체력 ");
                ChangeColor.ColorMagenta(Convert.ToString(beforeHp));
                Console.Write(" -> ");
                ChangeColor.ColorMagenta(Convert.ToString(Player.Hp));
                Console.WriteLine();
                Console.Write("Gold ");
                ChangeColor.ColorMagenta(Convert.ToString(beforeGold));
                Console.Write(" G -> ");
                ChangeColor.ColorMagenta(Convert.ToString(Player.gold));
                Console.WriteLine(" G\n");

                ChangeColor.ColorMagenta("0");
                Console.WriteLine(". 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string answer = Console.ReadLine();
                Console.Clear();

                switch (answer)
                {
                    case "0":
                        situation = Situation.Normal;
                        break;
                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }

        }

        void DungeonDiff(int index, string diff, float def)
        {
            ChangeColor.ColorMagenta(Convert.ToString(index));
            Console.Write(". " + diff);
            (x, y) = Console.GetCursorPosition();
            Console.SetCursorPosition(18, y);
            Console.Write("| 방어력 ");
            ChangeColor.ColorMagenta(Convert.ToString(def));
            Console.WriteLine(" 이상 권장");
        }

        void DungeonEnter(string index)
        {
            float pAtk = Player.attack, pDef = Player.defense;
            // 방어력 결정
            for (int i = 0; i < InfoPage.Instance.equipArmor.Length; i++)
            {
                if (InfoPage.Instance.equipArmor[i])
                {
                    pDef = Player.defense + Items.Instance.GetDef(i);
                    break;
                }
            }
            // 던전 성공 여부
            if (pDef < Dundiffs[Convert.ToInt16(index) - 1].defReq)
            {
                // 권장 방어력보다 낮으면 확률로 실패
                if (random.Next(1, 101) <= 40)
                {
                    Player.Hp -= (random.Next(20, 36) - (pDef - Dundiffs[Convert.ToInt16(index) - 1].defReq)) / 2;
                    ChangeColor.ColorRed("탐험 실패\n");
                    return;
                }
            }
            // 던전 성공
            beforeHp = Player.Hp;
            beforeGold = Player.gold;
            selectDungeon = Dundiffs[Convert.ToInt16(index) - 1].name;
            
            // 체력 -= 기본 체력 감소 - (내 방어력 - 권장 방어력)
            if (random.Next(20, 36) - (pDef - Dundiffs[Convert.ToInt16(index) - 1].defReq) >= 0)
            {
                Player.Hp -= random.Next(20, 36) - (pDef - Dundiffs[Convert.ToInt16(index) - 1].defReq);
            }

            // 클리어 보상
            // 공격력 계산
            for (int i = 0; i < InfoPage.Instance.equipWeapon.Length; i++)
            {
                if (InfoPage.Instance.equipWeapon[i])
                {
                    pAtk = Player.attack + Items.Instance.GetAtk(i);
                    break;
                }
            }
            // (공격력 ~ 공격력 2배)% 만큼 기본 보상에서 추가해서 정산
            Player.gold += (100 + random.Next(Convert.ToInt16(pAtk), Convert.ToInt16(pAtk * 2))) / 100.0f * Dundiffs[Convert.ToInt16(index) - 1].gold;

            Player.SetExp(1);
            situation = Situation.Clear;
        }
    }
}
