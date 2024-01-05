using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coloring;
using MainGame;
using Info;
using Item;

namespace Rest 
{ 
    public class RestPage
    {
        public static RestPage _instance;

        public static RestPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RestPage();
                }
                return _instance;
            }
        }

        int restPay = 500;

        public void RestAnnounce()
        {
            ChangeColor.ColorYellow("휴식하기\n");
            ChangeColor.ColorMagenta(Convert.ToString(restPay));
            Console.Write(" G 골드를 내면 체력을 회복할 수 있습니다. (보유 골드 : ");
            ChangeColor.ColorMagenta(Convert.ToString(Player.Instance.gold));
            Console.WriteLine(" G)\n");

            ChangeColor.ColorMagenta("1");
            Console.WriteLine(". 휴식하기");
            ChangeColor.ColorMagenta("0");
            Console.WriteLine(". 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string answer = Console.ReadLine();
            Console.Clear();

            switch (answer)
            {
                case "1":
                    RestInPeace();
                    break;
                case "0":
                    Player.Instance.SetScene(Scene.Start);
                    break;
                default:
                    ChangeColor.ColorRed("잘못된 입력입니다.\n");
                    break;
            }
        }

        public void RestInPeace()
        {
            if (Player.Instance.gold >= restPay)
            {
                Player.Instance.gold -= restPay;
                Player.Instance.Hp = 100;
                ChangeColor.ColorBlue("휴식을 완료했습니다.\n");
            }
            else
            {
                ChangeColor.ColorRed("Gold 가 부족합니다.\n");
            }
        }
    }
}
