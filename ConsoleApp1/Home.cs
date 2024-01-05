using MainGame;
using Coloring;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    public class StartPage
    {
        public void StartAnnounce()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            ChangeColor.ColorMagenta("1");
            Console.WriteLine(". 상태 보기");
            ChangeColor.ColorMagenta("2");
            Console.WriteLine(". 인벤토리");
            ChangeColor.ColorMagenta("3");
            Console.WriteLine(". 상점");
            ChangeColor.ColorMagenta("4");
            Console.WriteLine(". 던전 입장");
            ChangeColor.ColorMagenta("5");
            Console.WriteLine(". 휴식하기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string answer = Console.ReadLine();
            Console.Clear();

            switch (answer)
            {
                case "1":
                    Player.Instance.SetScene(Scene.Information);
                    break;

                case "2":
                    Player.Instance.SetScene(Scene.Inventory);
                    break;

                case "3":
                    Player.Instance.SetScene(Scene.Shop);
                    break;

                case "4":
                    Player.Instance.SetScene(Scene.Dungeon);
                    break;

                case "5":
                    Player.Instance.SetScene(Scene.Rest);
                    break;

                default:
                    ChangeColor.ColorRed("잘못된 입력입니다.\n");
                    break;

            }
        }
    }
}
