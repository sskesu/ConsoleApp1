using Coloring;
using MainGame;
using Inven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Shop;
using Info;

namespace Item
{
    public struct Armors
    {
        public string name;
        public string descript;
        public int Def;
        public int price;

        public Armors(string _name, string _descript, int _Def, int _price)
        {
            name = _name;
            descript = _descript;
            Def = _Def;
            price = _price;
        }
    }
    public struct Weapons
    {
        public string name;
        public string descript;
        public int Atk;
        public int price;

        public Weapons(string _name, string _descript, int _Atk, int _price)
        {
            name = _name;
            descript = _descript;
            Atk = _Atk;
            price = _price;
        }
    }


    // 아이템
    public class Items
    {
        public static Items _instance;

        public static Items Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Items();
                }
                return _instance;
            }
        }

        List<Armors> armorList = new List<Armors>();
        List<Weapons> weaponList = new List<Weapons>();
        int x, y;
        public int manageCount = 0;
        int ArmorCount = 0;
        public void ItemInit()
        {
            armorList.Add(new Armors("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, 1000));
            armorList.Add(new Armors("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, 1800));
            armorList.Add(new Armors("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, 3500));
            armorList.Add(new Armors("미스릴 갑옷", "미스릴로 만든 갑옷입니다.", 20, 5000));

            weaponList.Add(new Weapons("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 600));
            weaponList.Add(new Weapons("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 1500));
            weaponList.Add(new Weapons("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 2700));
            weaponList.Add(new Weapons("레바테인", "로키가 만든 불의 마검입니다.", 10, 3600));
        }

        public int GetAtk(int index) { return weaponList[index].Atk; }
        public int GetDef(int index) { return armorList[index].Def; }

        public void ShowItems()
        {
            for (int i = 0; i < armorList.Count; i++)
            {
                Console.Write("- " + armorList[i].name);
                (x, y) = Console.GetCursorPosition();
                Console.SetCursorPosition(18, y);
                Console.Write("| 방어력 +");
                ChangeColor.ColorMagenta(Convert.ToString(armorList[i].Def));
                Console.SetCursorPosition(30, y);
                Console.Write("  | " + armorList[i].descript);
                Console.SetCursorPosition(85, y);
                Console.Write("| ");
                if (InfoPage.Instance.haveArmor[i]) { Console.WriteLine("구매완료"); }
                else
                {
                    ChangeColor.ColorMagenta(Convert.ToString(armorList[i].price));
                    Console.WriteLine(" G");
                }
            }
            for (int i = 0; i < weaponList.Count; i++)
            {
                Console.Write("- " + weaponList[i].name);
                (x, y) = Console.GetCursorPosition();
                Console.SetCursorPosition(18, y);
                Console.Write("| 공격력 +");
                ChangeColor.ColorMagenta(Convert.ToString(weaponList[i].Atk));
                Console.SetCursorPosition(30, y);
                Console.Write("  | " + weaponList[i].descript);
                Console.SetCursorPosition(85, y);
                Console.Write("| ");
                if (InfoPage.Instance.haveWeapon[i]) { Console.WriteLine("구매완료"); }
                else
                {
                    ChangeColor.ColorMagenta(Convert.ToString(weaponList[i].price));
                    Console.WriteLine(" G");
                }
            }
            Console.WriteLine("\n");
        }

        public void InvenItems()
        {
            for (int i = 0; i < armorList.Count; i++)
            {
                if (InfoPage.Instance.haveArmor[i])
                {
                    Console.Write("- ");
                    if (InfoPage.Instance.equipArmor[i])
                    {
                        Console.Write("[");
                        ChangeColor.ColorMagenta("E");
                        Console.Write("]");
                    }
                    Console.Write(armorList[i].name);
                    (x, y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(20, y);
                    Console.Write("| 방어력 +");
                    ChangeColor.ColorMagenta(Convert.ToString(armorList[i].Def));
                    Console.SetCursorPosition(32, y);
                    Console.WriteLine("  | " + armorList[i].descript);
                }
            }
            for (int i = 0; i < weaponList.Count; i++)
            {
                if (InfoPage.Instance.haveWeapon[i])
                {
                    Console.Write("- ");
                    if (InfoPage.Instance.equipWeapon[i])
                    {
                        Console.Write("[");
                        ChangeColor.ColorMagenta("E");
                        Console.Write("]");
                    }
                    Console.Write(weaponList[i].name);
                    (x, y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(20, y);
                    Console.Write("| 공격력 +");
                    ChangeColor.ColorMagenta(Convert.ToString(weaponList[i].Atk));
                    Console.SetCursorPosition(32, y);
                    Console.WriteLine("  | " + weaponList[i].descript);
                }
            }
        }

        public void InvenManagement()
        {
            // 아이템 번호와 인벤번호 맞추기
            manageCount = 0;
            ArmorCount = 0;
            for (int i = 0; i < InfoPage.Instance.haveArmor.Length; i++)
            {
                if (InfoPage.Instance.haveArmor[i])
                {
                    InfoPage.Instance.invens[manageCount++] = i;
                    ArmorCount++;
                }
            }// 0 3
            for (int i = InfoPage.Instance.haveArmor.Length; i < InfoPage.Instance.haveArmor.Length + InfoPage.Instance.haveWeapon.Length; i++)
            {
                if (InfoPage.Instance.haveWeapon[i - InfoPage.Instance.haveArmor.Length])
                {
                    InfoPage.Instance.invens[manageCount++] = i;
                }
            }// 4 7
            
        }

        public void EquipItems(int index)
        {
            if (index <= manageCount) // 가진 장비 수 맞는지 확인
            {
                if (index <= ArmorCount) //  무긴지 방어군지 확인
                {
                    if (InfoPage.Instance.equipArmor[InfoPage.Instance.invens[index - 1]]) // 이미 장착중인지 확인
                    {
                        for (int j = 0; j < InfoPage.Instance.equipArmor.Length; j++)
                        {
                            InfoPage.Instance.equipArmor[j] = false;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < InfoPage.Instance.equipArmor.Length; j++)
                        {
                            InfoPage.Instance.equipArmor[j] = false;
                        }
                        InfoPage.Instance.equipArmor[InfoPage.Instance.invens[index - 1]] = true;
                    }
                    
                }
                else
                {
                    if (InfoPage.Instance.equipWeapon[InfoPage.Instance.invens[index - 1] - InfoPage.Instance.haveArmor.Length])
                    {
                        for (int j = 0; j < InfoPage.Instance.equipWeapon.Length; j++)
                        {
                            InfoPage.Instance.equipWeapon[j] = false;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < InfoPage.Instance.equipWeapon.Length; j++)
                        {
                            InfoPage.Instance.equipWeapon[j] = false;
                        }
                        InfoPage.Instance.equipWeapon[InfoPage.Instance.invens[index - 1] - InfoPage.Instance.haveArmor.Length] = true;
                    }
                }
            }
            else
            {
                ChangeColor.ColorRed("잘못된 입력입니다.\n");
            }
        }

        public void SellShop()
        {
            for (int i = 0; i < armorList.Count; i++)
            {
                if (InfoPage.Instance.haveArmor[i])
                {
                    Console.Write("- ");
                    if (InfoPage.Instance.equipArmor[i])
                    {
                        Console.Write("[");
                        ChangeColor.ColorMagenta("E");
                        Console.Write("]");
                    }
                    Console.Write(armorList[i].name);
                    (x, y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(20, y);
                    Console.Write("| 방어력 +");
                    ChangeColor.ColorMagenta(Convert.ToString(armorList[i].Def));
                    Console.SetCursorPosition(32, y);
                    Console.WriteLine("  | " + armorList[i].descript);
                    Console.SetCursorPosition(88, y);
                    Console.Write("| ");
                    ChangeColor.ColorMagenta(Convert.ToString(armorList[i].price));
                    Console.WriteLine(" G");
                }
            }
            for (int i = 0; i < weaponList.Count; i++)
            {
                if (InfoPage.Instance.haveWeapon[i])
                {
                    Console.Write("- ");
                    if (InfoPage.Instance.equipWeapon[i])
                    {
                        Console.Write("[");
                        ChangeColor.ColorMagenta("E");
                        Console.Write("]");
                    }
                    Console.Write(weaponList[i].name);
                    (x, y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(20, y);
                    Console.Write("| 공격력 +");
                    ChangeColor.ColorMagenta(Convert.ToString(weaponList[i].Atk));
                    Console.SetCursorPosition(32, y);
                    Console.WriteLine("  | " + weaponList[i].descript);
                    Console.SetCursorPosition(88, y);
                    Console.Write("| ");
                    ChangeColor.ColorMagenta(Convert.ToString(weaponList[i].price));
                    Console.WriteLine(" G");
                }
            }
        }

        public void SellItems(int index)
        {
            if (index > manageCount)
            {
                ChangeColor.ColorRed("잘못된 입력입니다.\n");
            }
            else
            {
                // 방어구/무기 확인
                if (index <= ArmorCount)
                {
                    Player.gold += armorList[InfoPage.Instance.invens[index - 1]].price * 85 / 100;
                    InfoPage.Instance.haveArmor[InfoPage.Instance.invens[index - 1]] = false;
                    InfoPage.Instance.equipArmor[InfoPage.Instance.invens[index - 1]] = false;
                }
                else
                {
                    Player.gold += weaponList[InfoPage.Instance.invens[index - 1] - InfoPage.Instance.haveArmor.Length].price * 85 / 100;
                    InfoPage.Instance.haveWeapon[InfoPage.Instance.invens[index - 1] - InfoPage.Instance.haveArmor.Length] = false;
                    InfoPage.Instance.equipWeapon[InfoPage.Instance.invens[index - 1] - InfoPage.Instance.haveArmor.Length] = false;
                }
            }
        }

        public void BuyArm(int index)
        {
            if (InfoPage.Instance.haveArmor[index - 1] == true)
            {
                ChangeColor.ColorBlue("이미 구매한 아이템입니다.");
            }
            else if (Player.gold >= armorList[index - 1].price)
            {
                Player.gold -= armorList[index - 1].price;
                InfoPage.Instance.haveArmor[index - 1] = true;
                ChangeColor.ColorBlue("구매를 완료했습니다.");
            }
            else
            {
                ChangeColor.ColorRed("Gold 가 부족합니다.");
            }
        }
        public void BuyWea(int index)
        {
            if (InfoPage.Instance.haveWeapon[index - 1 - InfoPage.Instance.haveArmor.Length] == true)
            {
                ChangeColor.ColorBlue("이미 구매한 아이템입니다.");
            }
            else if (Player.gold >= weaponList[index - 1 - InfoPage.Instance.haveArmor.Length].price)
            {
                Player.gold -= weaponList[index - 1 - InfoPage.Instance.haveArmor.Length].price;
                InfoPage.Instance.haveWeapon[index - 1 - InfoPage.Instance.haveArmor.Length] = true;
                ChangeColor.ColorBlue("구매를 완료했습니다.");
            }
            else
            {
                ChangeColor.ColorRed("Gold 가 부족합니다.");
            }
        }


    }
}
