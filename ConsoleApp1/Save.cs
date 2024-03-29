﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save
{
    public class SaveJson
    {
        string path = Environment.CurrentDirectory + @"\..\..\..\\Config.json";

        public void Save()
        {
            JObject configData = new JObject
            ( // 데이터 저장
            new JProperty("Lv", Player.Instance.Lv),
            new JProperty("AtkPt", Player.Instance.attack),
            new JProperty("DefPt", Player.Instance.defense),
            new JProperty("Hp", Player.Instance.Hp),
            new JProperty("Gold", Player.Instance.gold),
            new JProperty("Exp", Player.Instance.exp)
            ); // 배열 저장
            configData.Add("EquipA", JArray.FromObject(InfoPage.Instance.equipArmor));
            configData.Add("EquipW", JArray.FromObject(InfoPage.Instance.equipWeapon));
            configData.Add("HaveA", JArray.FromObject(InfoPage.Instance.haveArmor));
            configData.Add("HaveW", JArray.FromObject(InfoPage.Instance.haveWeapon));
            configData.Add("inventory", JArray.FromObject(InfoPage.Instance.invens));
            // 파일 생성 하고 값 저장
            File.WriteAllText(path, configData.ToString());
        }

        public void Load()
        {
            using (StreamReader file = File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject json = (JObject)JToken.ReadFrom(reader);

                    Player.Instance.Lv = (int)json["Lv"];
                    Player.Instance.attack = (float)json["AtkPt"];
                    Player.Instance.defense = (float)json["DefPt"];
                    Player.Instance.Hp = (float)json["Hp"];
                    Player.Instance.gold = (float)json["Gold"];
                    Player.Instance.exp = (int)json["Exp"];

                    for (int i = 0; i < InfoPage.Instance.equipArmor.Length; i++)
                    {
                        InfoPage.Instance.equipArmor[i] = (bool)json["EquipA"][i];
                    }
                    for(int i = 0; i < InfoPage.Instance.equipWeapon.Length; i++)
                    {
                        InfoPage.Instance.equipWeapon[i] = (bool)json["EquipW"][i];
                    }
                    for (int i = 0; i < InfoPage.Instance.haveArmor.Length; i++)
                    {
                        InfoPage.Instance.haveArmor[i] = (bool)json["HaveA"][i];
                    }
                    for (int i = 0; i < InfoPage.Instance.haveWeapon.Length; i++)
                    {
                        InfoPage.Instance.haveWeapon[i] = (bool)json["HaveW"][i];
                    }
                    for (int i = 0; i < InfoPage.Instance.invens.Length; i++)
                    {
                        InfoPage.Instance.invens[i] = (int)json["inventory"][i];
                    }

                }
            }
        }
    }
}
