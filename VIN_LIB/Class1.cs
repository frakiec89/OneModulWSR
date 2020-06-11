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


        // J H M   C M 5 6 5 5    7  C  4  0  4  4  5   3
        // 0 1 2   3 4 5 6 7 8    9 10  11 12 13 14  15 16

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

            if (!ControllSum(vin)) return false;

            return true;
        }

        private bool ControllSum(string vin)
        {
            // ToDo: Дописать  контрольную  сумму 
            return true;
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
    }
}
