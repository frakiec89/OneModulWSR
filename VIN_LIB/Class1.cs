using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB
{
    public class Class1
    {
        string[] godSimbolMas = new string[] 
        { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
          "A", "B", "C", "D", "E", "F", "G", "H",  "J", "K",
          "L", "M", "N", "P", "R", "S", "T", "U", "V", "W",
          "X", "Y", "Z", };

        /// <summary>
        /// Метод проверяет  vin 
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public bool  CheckVIN( string vin  )
        {
            if (!IsCountSimbol(vin)) return false; // Проверка  на  длинну  17 символов 

            if (!IsBedCount(vin)) return false;
          
            if (!IsBebWMI(vin.Substring(0,3) , out string name) ) return false; // проверка  индекса производителей 

            if ( ! IsWDS(vin.Substring(3, 6))) return false ;

            if (!IsBedVis(vin.Substring(9))) return false ;

          // if (!ControllSum(vin)) return false;

            return true;
        }

        /// <summary>
        /// Поиск  страны 
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public  string GetVINCountry(string vin)
        {
            string name;
            if (IsBebWMI(vin.Substring(0, 3), out name))
            {
                name = name.TrimStart();
                name = name.TrimEnd();
                return name;
            }
            else
                return "Нет  такой  страны ";

        }

        public int GetTransportYear(String vin)
        {
            string gs = vin.Substring(9, 1);

            #region god
            string god =   @"A   1980 *
            B   1981 *
            C   1982 *
            D   1983 *
            E   1984 *
            F   1985 *
            G   1986 *
            H   1987 *
            J   1988 *
            K   1989 *
            L   1990 *
            M   1991 *
            N   1992 *
            P   1993 *
            R   1994 *
            S   1995 *
            T   1996 *
            V   1997 *
            W   1998 *
            X   1999 *
            Y   2000 *
            1   2001 *
            2   2002 *
            3   2003 *
            4   2004 *
            5   2005 *
            6   2006 *
            7   2007 *
            8   2008 *
            9   2009 *
            A   2010 *
            B   2011 *
            C   2012 *
            D   2013 *
            E   2014 *
            F   2015 *
            G   2016 *
            H   2017 *
            J   2018 *
            K   2019 *
            L   2020 *
            M   2021 *
            N   2022 *
            P   2023 *
            R   2024 *
            S   2025 *
            T   2026 *
            V   2027 *
            W   2028 *
            X   2029 *
            Y   2030 *
            1   2031 *
            2   2032 *
            3   2033 *
            4   2034 *
            5   2035 *
            6   2036 *
            7   2037 *
            8   2038 *
            9   2039 *";
            #endregion 

            string[] gods = god.Split('*');
            List<string> godsList = new List<string>();

            foreach (  var  s   in  gods)
            {
                var ss = s.TrimStart();
                ss = ss.TrimEnd();
                godsList.Add(ss);
            }

            foreach (var g   in  godsList )
            {
                if (g.Substring(0, 1) == gs)
                    return  Convert.ToInt32(g.Substring(2));
            }

            return 0; 
        }

        public bool ControllSum(string vin)
        {
            int[] ves = new int[] {  8, 7, 6, 5, 4, 3, 2, 10,  9, 8, 7, 6, 5, 4, 3, 2 };

            List<Maska> maskas = new List<Maska>
             {
                 new Maska {  Name = "A" , Value =1},
                 new Maska {  Name = "B" , Value =2},
                 new Maska {  Name = "C" , Value =3},
                 new Maska {  Name = "D" , Value =4},
                 new Maska {  Name = "E" , Value =5},
                 new Maska {  Name = "F" , Value =6},
                 new Maska {  Name = "G" , Value =7},
                 new Maska {  Name = "H" , Value =8},
                 new Maska {  Name = "J" , Value =1},
                 new Maska {  Name = "K" , Value =2},
                 new Maska {  Name = "L" , Value =3},
                 new Maska {  Name = "M" , Value =4},
                 new Maska {  Name = "N" , Value =5},
                 new Maska {  Name = "P" , Value =6},
                 new Maska {  Name = "R" , Value =9},
                 new Maska {  Name = "S" , Value =2},
                 new Maska {  Name = "T" , Value =3},
                 new Maska {  Name = "U" , Value =4},
                 new Maska {  Name = "V" , Value =5},
                 new Maska {  Name = "W" , Value =6},
                 new Maska {  Name = "X" , Value =7},
                 new Maska {  Name = "Y" , Value =8},
                 new Maska {  Name = "Z" , Value =9},
            };

            int[] vinInt  = GetVinInt(maskas, vin);

            List<int> sum = new List<int>();

            for ( int i = 0;  i < ves.Length; i++) //  умножаем ;
            {
                sum.Add(ves[i] * vinInt[i]);
            }

            int totalSum = 0;

            foreach ( var s in sum)
            {
                totalSum += s;
            }

            int  sumDel =  (int) totalSum / 11;
            string  Snk = (totalSum - ( sumDel * 11)).ToString();

            if (Snk == "10")
                Snk = "X";

            if (vin.Substring(8, 1) == Snk)
                return true;

            // ToDo: Дописать  контрольную  сумму 
            return false; ;
        }

        private int[] GetVinInt(List<Maska> maskas, string vin)
        {
           vin = vin.Substring(0, 8) + vin.Substring(9);

           List<int> vs = new List<int>();

           foreach ( var v  in  vin)
            {

                string vst = v.ToString();
                var vr =   maskas.Where(x => x.Name == vst).ToList();
                if (vr.Count > 0)
                {
                    vs.Add(vr[0].Value);
                }
                else
                {
                    vs.Add(Convert.ToInt32(vst));
                }
                

            }
            return vs.ToArray();
        }

        public bool IsBedVis(string v)
        {
            if (v[0].ToString() == "Z" || v[0].ToString() == "0") return false; // проверка на  год

            var forV = v.Substring(3);
            var mas = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach ( var   item in  forV)
             {
                if (!isSimol(item, mas)) return false;
             }
            return true;

        }

        /// <summary>
        /// Проверяет контрольныу цифру
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool IsWDS(string v)
        {
            var vs = v.Substring(5,1);

            string[] mas = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "X" };

            foreach ( var s in  mas)
            {
                if (s == vs) return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет  наличие страны
        /// </summary>
        /// <param name="v"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsBebWMI (string v , out string name)
        {
            List <CountriList>    CountriList = Countru.CountruMas();
                    
            foreach ( var  c in CountriList )
            {
                if (c.GetName(v) != null) { name = c.GetName(v); return true; }
            }
            name = null;
            return false;
        }

        /// <summary>
        /// Поиск  плохих символов 
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public bool IsBedCount(string vin)
        {
            foreach (var value in vin) // перебор  символов 
            {
                if (!isSimol(value, godSimbolMas)) return false;
            }
            return true;
        }

        /// <summary>
        /// поиск  наличие разрешонного символа 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="godSimbolMas"></param>
        /// <returns></returns>
        public bool isSimol(char value, string[] godSimbolMas)
        {
           foreach (  var g   in  godSimbolMas)
           {
                if (g == value.ToString()) return true;
           }
            return false;
        }

        /// <summary>
        /// проверка на  длинну 
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public bool IsCountSimbol(string vin)
        {
            if (vin.Length == 17) return true;

            return false;
        }

        public  class Maska
        {
            public int  Value { get; set; }
            public  string Name { get; set; }
        }
    }
}
