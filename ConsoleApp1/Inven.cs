using MainGame;
using Coloring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item;
using Info;

namespace Inven
{
    enum Situation
    {
        Normal,
        Manage
    }
    public class InvenPage
    {
        int x, y;

        Situation situation = Situation.Normal;
        public void InvenAnnounce()
        {
            if (situation == Situation.Normal)
            {
                ChangeColor.ColorYellow("인벤토리\n");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("[아이템 목록]\n");
                Items.Instance.InvenItems();

                ChangeColor.ColorMagenta("\n1");
                Console.WriteLine(". 장착 관리");
                ChangeColor.ColorMagenta("0");
                Console.WriteLine(". 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string answer = Console.ReadLine();
                Console.Clear();

                switch (answer)
                {
                    case "1":
                        situation = Situation.Manage;
                        break;

                    case "0":
                        Player.SetScene(Scene.Start);
                        break;

                    default:
                        ChangeColor.ColorRed("잘못된 입력입니다.\n");
                        break;
                }
            }
            else if (situation == Situation.Manage)
            {
                ChangeColor.ColorYellow("인벤토리 - 장착 관리\n");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("[아이템 목록]\n");
                Items.Instance.InvenManagement();
                Items.Instance.InvenItems();

                Console.ForegroundColor = ConsoleColor.Magenta;
                (x, y) = Console.GetCursorPosition();
                for (int i = 0; i < Items.Instance.manageCount; i++)
                {
                    Console.SetCursorPosition(0, y - Items.Instance.manageCount + i);
                    Console.Write(Convert.ToString(i + 1));
                }
                Console.ResetColor();

                Console.SetCursorPosition(0, y + 1);
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
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Items.Instance.EquipItems(Convert.ToInt32(index));
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
