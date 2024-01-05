using MainGame;
using Home;
using Shop;
using Info;
using Inven;
using Rest;
using Dungeon;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Coloring;
using Save;
using Item;


namespace MainGame
{
    public enum Scene
    {
        Start,
        Information,
        Inventory,
        Shop,
        Dungeon,
        Rest
    }

    
    // 메인 실행
    public class ConsoleGameProject
    {
        
        public static void Main()
        {
            var startPage = new StartPage();
            var invenPage = new InvenPage();
            var saveJson = new SaveJson();

            Items.Instance.ItemInit();
            DungeonPage.Instance.DunInit();
            saveJson.Load();

            while (true)
            {
                saveJson.Save();
                switch (Player.Instance.curScene)
                {
                    case Scene.Start:
                        startPage.StartAnnounce();
                        break;

                    case Scene.Information:
                        InfoPage.Instance.InfoAnnounce();
                        break;

                    case Scene.Inventory:
                        invenPage.InvenAnnounce();
                        break;

                    case Scene.Shop:
                        ShopPage.Instance.ShopAnnounce();
                        break;

                    case Scene.Dungeon:
                        DungeonPage.Instance.DungeonAnnounce();
                        break;

                    case Scene.Rest:
                        RestPage.Instance.RestAnnounce();
                        break;

                    default:
                        break;
                }
            }
        }

    }
}

