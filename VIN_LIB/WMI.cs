using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB
{
   
    public  static  class Countru
    {
        #region 
       static string mas =  @"  AA-AH ЮАР*
                                AJ-AN Котд’Ивуар*
                                BA-BE Ангола	*
                                BF-BK Кения	*
                                BL-BR Танзания	*
                                CA-CE Бенин	*
                                CF-CK Мадагаскар	*
                                CL-CR Тунис	*
                                DA-DE Египет	*
                                DF-DK Марокко	*
                                DL-DR Замбия	*
                                EA-EE Эфиопия	*
                                EF-EK Мозамбик	*
                                FA-FE Гана	*
                                FF-FK Нигерия	*
                                JA-JT Япония	*
                                KA-KE Шри Ланка*
                                KF-KK Израиль	*
                                KL-KR Южная Корея*
                                KS-K0 Казахстан	*
                                LA-L0 Китай	*
                                MA-ME Индия	*
                                MF-MK Индонезия	*
                                ML-MR Таиланд	*
                                NF-NK Пакистан	*
                                NL-NR Турция	*
                                PA-PE Филиппины	*
                                PF-PK Сингапур	*
                                PL-PR Малайзия	*
                                RA-RE ОАЭ	*
                                RF-RK Тайвань	*
                                RL-RR Вьетнам	*
                                RS-R0 Саудовская Аравия*
                                SA-SM Великобритания	*
                                SN-ST Германия	*
                                SU-SZ Польша	*
                                S1-S4 Латвия	*
                                TA-TH Швейцария	*
                                TJ-TP Чехия	*
                                TR-TV Венгрия	*
                                TW-T1 Португалия	*
                                UH-UM Дания	*
                                UN-UT Ирландия	*
                                UU-UZ Румыния	*
                                U5-U7 Словакия	*
                                VA-VE Австрия	*
                                VF-VR Франция	*
                                VS-VW Испания	*
                                VX-V2 Сербия	*
                                V3-V5 Хорватия	*
                                V6-V0 Эстония	*
                                WA-W0 Германия	*
                                XA-XE Болгария	*
                                XF-XK Греция	*
                                XL-XR Нидерланды	*
                                XS-XW СССР/СНГ*
                                XX-X2 Люксембург	*
                                X3-X0 Россия	*
                                YA-YE Бельгия	*
                                YF-YK Финляндия	*
                                YL-YR Мальта	*
                                YS-YW Швеция	*
                                YX-Y2 Норвегия	*
                                Y3-Y5 Беларусь	*
                                Y6-Y0 Украина	*
                                ZA-ZR Италия	*
                                1A-10 США*
                                2A-20 Канада*
                                3A-3W Мексика	*
                                3X-37 Коста Рика	*
                                38-30 Каймановы острова	*
                                4A-40 США*
                                5A-50 США*
                                6A-6W Австралия	*
                                7A-7E Новая Зеландия	*
                                8A-8E Аргентина*
                                8F-8K Чили	*
                                8L-8R Эквадор	*
                                8S-8W Перу	*
                                8X-82 Венесуэла*
                                9A-9E Бразилия*
                                9F-9K Колумбия	*
                                9L-9R Парагвай	*
                                9S-9W Уругвай	*
                                9X-92 Тринидад и Тобаго*
                                93-99 Бразилия*
                                90 не используется	*
                                ZX-Z2 Словения	*
                                Z3-Z5 Литва	*
                                Z6-Z0 Россия	*";

        #endregion

        public static List<CountriList> CountruMas ()
        {

            var masiv  = mas.Split('*');

            List<CountriList> countriLists = new List<CountriList>();
 
            foreach ( var m  in  masiv)
            {
                countriLists.Add(new CountriList(m.TrimStart()));
            }

            return countriLists;
        }
    }

    public class CountriList
    {

        List<string>  godSimbolMas = new List<string>()
        { 
          "A", "B", "C", "D", "E", "F", "G", "H",  "J", "K",
          "L", "M", "N", "P", "R", "S", "T", "U", "V", "W",
          "X", "Y", "Z",  "1", "2", "3", "4", "5", "6", "7", "8", "9" , "0" };


        string To { get; set; }
        string From { get; set; }
        public List<string>  Wie  { get { return GetWie(); } }

        private List<string> GetWie()
        {
            var list = new List<string>();
            if (To != null || From != null)
            {
                int inIndex = godSimbolMas.IndexOf(To[1].ToString());
                int outIndex = godSimbolMas.IndexOf(From[1].ToString());
                for (int i = inIndex; i <= outIndex; i++)
                {
                    list.Add((To[0] + godSimbolMas[i]).ToString());
                }
            }
            return list;
        }

        String Name { get; set; }

       public CountriList (  string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                To = s.Substring(0, 2);
                From = s.Substring(3, 2);
                Name = s.Substring(6, s.Length - 6);
            }
        }

        public override string ToString()
        {

            string s = null; 

            foreach ( var  W in  Wie)
            {
                s +=  W +"\n";
            }

            return s + To + " " + From + " " + Name + "\n";
        }


        public  string  GetName ( string  vin)
        {
            vin = vin.Substring(0, 2);
            foreach  (  var  w in  Wie)
            {
                if (w == vin) return Name;
            }

            return null;
        }
    }


}
