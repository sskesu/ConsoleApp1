using MainGame;
using Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coloring;
using Info;


namespace Shop
{
    enum Situation
    {
        Normal,
        Buy,
        Sell
    }

    public  class ShopPage
    {
        public static ShopPage _instance = null;
        public static ShopPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShopPage();
                }
                return _instance;
            }
        }

        Situation situation = Situation.Normal;
        int x, y;

        public void ShopTop()
        {
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine("[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Player.gold); Console.WriteLine(" G\n");
            Console.ResetColor();

            Console.WriteLine("[아이템 목록]\n");
        }
        public void ShopAnnounce()
        {
            
            Console.SetCursorPosition(0, 1);

            if (situation == Situation.Normal)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("상점");
                ShopTop();
                
                Items.Instance.ShowItems();

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string answer = Console.ReadLine();
                Console.Clear();

                switch (answer)
                {
                    case "1":
                        situation = Situation.Buy;
                        break;

                    case "2":
                        situation = Situation.Sell;
                        break;

                    case "0":
                        Player.SetScene(Scene.Start);
                        Console.Clear();
                        break;

                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }
            else if (situation == Situation.Buy)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("상점 - 아이템 구매");
                ShopTop();

                Items.Instance.ShowItems();
                (x, y) = Console.GetCursorPosition();

                Console.ForegroundColor = ConsoleColor.Magenta;
                for (int i = 0; i < InfoPage.Instance.haveArmor.Length + InfoPage.Instance.haveWeapon.Length; i++)
                {
                    Console.SetCursorPosition(0, y - (2 + InfoPage.Instance.haveArmor.Length + InfoPage.Instance.haveWeapon.Length) + i);
                    Console.Write(Convert.ToString(i + 1));
                }
                Console.ResetColor();
                Console.SetCursorPosition(0, y + 1);

                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string index = Console.ReadLine();
                Console.Clear();
                switch (index)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        Items.Instance.BuyArm(Convert.ToInt32(index));
                        break;
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Items.Instance.BuyWea(Convert.ToInt32(index));
                        break;
                    case "0":
                        situation = Situation.Normal;
                        break;
                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }
            else if (situation == Situation.Sell)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("상점 - 아이템 판매");
                ShopTop();
                Items.Instance.SellShop();
                Items.Instance.InvenManagement();

                Console.ForegroundColor = ConsoleColor.Magenta;
                (x, y) = Console.GetCursorPosition();
                for (int i = 0; i < Items.Instance.manageCount; i++)
                {
                    Console.SetCursorPosition(0, y - Items.Instance.manageCount + i);
                    Console.Write(Convert.ToString(i + 1));
                }
                Console.ResetColor();

                Console.WriteLine("\n");
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string index = Console.ReadLine();
                Console.Clear();
                switch (index)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Items.Instance.SellItems(Convert.ToInt16(index));
                        break;
                    case "0":
                        situation = Situation.Normal;
                        break;
                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }
            

            
        }
    }
}
