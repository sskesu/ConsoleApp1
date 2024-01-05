using MainGame;
using Coloring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item;

namespace Info
{
    // 플레이어 정보
    public struct Player
    {
        public static Scene curScene = Scene.Start;
        public static int Lv = 1;
        public static string name = "name";
        public static string job = "전사";
        public static float attack = 10f;
        public static float defense = 5f;
        public static float Hp = 100;
        public static float gold = 1500f;
        public static int exp = 0;

        public static void SetScene(Scene scene)
        {
            curScene = scene;
        }
        public Player()
        {

        }

        public static void SetExp(int _exp)
        {
            exp += _exp;
            while (exp >= Lv)
            {
                exp -= Lv++;
                attack += 0.5f;
                defense += 1;
            }
        }
    }
    public class InfoPage
    {
        public static InfoPage _instance = null;
        public static InfoPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InfoPage();
                }
                return _instance;
            }
        }
        
        public bool[] equipArmor = new bool[4];
        public bool[] equipWeapon = new bool[4];
        public bool[] haveArmor = new bool[4];
        public bool[] haveWeapon = new bool[4];
        public int[] invens = new int[8];

        public void InfoAnnounce()
        {
            float pAtk = Player.attack, pDef = Player.defense;

            ChangeColor.ColorYellow("상태 보기\n");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.Write("Lv. ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Lv) + "\n");
            Console.WriteLine(Player.name + " ( " + Player.job + " )");

            Console.Write("공격력 : ");
            for (int i = 0; i < equipWeapon.Length; i++)
            {
                if (equipWeapon[i])
                {
                    pAtk += Items.Instance.GetAtk(i);
                }
            }
            ChangeColor.ColorMagenta(Convert.ToString(pAtk));
            if (Player.attack != pAtk)
            {
                Console.Write(" (+");
                ChangeColor.ColorMagenta(Convert.ToString(pAtk - Player.attack));
                Console.Write(")");
            }
            Console.WriteLine();

            Console.Write("방어력 : ");
            for (int i = 0; i < equipArmor.Length; i++)
            {
                if (equipArmor[i])
                {
                    pDef += Items.Instance.GetDef(i);
                }
            }
            ChangeColor.ColorMagenta(Convert.ToString(pDef));
            if (Player.defense != pDef)
            {
                Console.Write(" (+");
                ChangeColor.ColorMagenta(Convert.ToString(pDef - Player.defense));
                Console.Write(")");
            }
            Console.WriteLine();

            Console.Write("체 력 : ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Hp) + "\n");

            Console.Write("Gold : ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.gold));
            Console.WriteLine("G");

            Console.WriteLine();
            ChangeColor.ColorMagenta("0");
            Console.WriteLine(". 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string answer = Console.ReadLine();
            Console.Clear();

            switch (answer)
            {
                case "0":
                    Player.SetScene(Scene.Start);
                    break;

                default:
                    ChangeColor.ColorRed("잘못된 입력입니다.\n");
                    break;
            }
        }
    }
}
