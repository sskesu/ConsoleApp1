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
    public class Player
    {
        public static Player _instance;

        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }

        public Scene curScene = Scene.Start;
        public int Lv = 1;
        public string name = "name";
        public string job = "전사";
        public float attack = 10f;
        public float defense = 5f;
        public float Hp = 100;
        public float gold = 1500f;
        public int exp = 0;

        public void SetScene(Scene scene)
        {
            curScene = scene;
        }
        public Player()
        {

        }

        public void SetExp(int _exp)
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
            float pAtk = Player.Instance.attack, pDef = Player.Instance.defense;

            ChangeColor.ColorYellow("상태 보기\n");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.Write("Lv. ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Instance.Lv) + "\n");
            Console.WriteLine(Player.Instance.name + " ( " + Player.Instance.job + " )");

            Console.Write("공격력 : ");
            for (int i = 0; i < equipWeapon.Length; i++)
            {
                if (equipWeapon[i])
                {
                    pAtk += Items.Instance.GetAtk(i);
                }
            }
            ChangeColor.ColorMagenta(Convert.ToString(pAtk));
            if (Player.Instance.attack != pAtk)
            {
                Console.Write(" (+");
                ChangeColor.ColorMagenta(Convert.ToString(pAtk - Player.Instance.attack));
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
            if (Player.Instance.defense != pDef)
            {
                Console.Write(" (+");
                ChangeColor.ColorMagenta(Convert.ToString(pDef - Player.Instance.defense));
                Console.Write(")");
            }
            Console.WriteLine();

            Console.Write("체 력 : ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Instance.Hp) + "\n");

            Console.Write("Gold : ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Instance.gold));
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
                    Player.Instance.SetScene(Scene.Start);
                    break;

                default:
                    ChangeColor.ColorRed("잘못된 입력입니다.\n");
                    break;
            }
        }
    }
}
