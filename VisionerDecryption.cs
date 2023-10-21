using System.Text;

namespace ConsoleApp1
{
    public class VisionerDecryption
    {
        double IndexCount = 0.0553;
        string alphabit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        string s;
        int KeyLenght;
        int KeyLenghtResult;
        double KeyLenghtVer;
        string[] sGroaps;
        string Key;
        public VisionerDecryption(string s)
        {
            this.s = TextToStandart(s);
            Decryption();

        }
        void Decryption()
        {
            //то же самое
            KeyLenght = 2;
            int counter = 1;
            while (IndexCountCheck(StringReturn(KeyLenght)) != true)
            {
                KeyLenght++;
                counter++;
                if (counter == 12) { break; }
            }
            Console.WriteLine($"Длина ключа {KeyLenghtResult} вероятность {KeyLenghtVer}");
            sGroaps = StringToGroap(KeyLenghtResult);

            counter = 1;
            foreach(var el in sGroaps)
            {
                Console.WriteLine($"{counter}-я группа символов\n");
                Console.WriteLine(el);


                var a = MaxVer(el);
                Console.WriteLine(a);
                if (alphabit.IndexOf(a)>15)
                {
                    Key += alphabit[alphabit.IndexOf(a) - alphabit.IndexOf("О")];
                }
                else
                {
                    Key += alphabit[alphabit.IndexOf(a) + 33 - alphabit.IndexOf("О")];
                }


                counter++;
            }

            Console.WriteLine(Key);




        }
        bool IndexCountCheck(string str)
        {
            if (KeyLenght == 0) { return false; }
            double result = 0;
            for (int i = 0; i < alphabit.Length; i++)
            {
                int n = str.Count(x => x == alphabit[i]);
                result += ((double)n * ((double)n - 1)) / ((double)str.Length * ((double)str.Length - 1));
            }
            KeyLenghtResult = result > KeyLenghtVer ? KeyLenght : KeyLenghtResult;
            KeyLenghtVer = result > KeyLenghtVer ? result : KeyLenghtVer;
            return result >= IndexCount ? true : false;

        }
        string StringReturn(int n)
        {
            StringBuilder stroka = new StringBuilder();
            for (int i = 0; i < s.Length; i += n)
            {
                stroka.Append(s[i]);
            }
            return stroka.ToString();
        }
        string[] StringToGroap(int n)
        {
            string[] str = new string[n];
            StringBuilder strBuff = new StringBuilder();
            for(int i = 0; i < n;i++)
            {
                strBuff.Clear();
                for(int j = i; j < s.Length; j+= n)
                {
                    strBuff.Append(s[j]);
                }
                str[i] = strBuff.ToString();
            }
            return str;
        }
        string MaxVer(string str)
        {
            int result = 0;
            string resultA = "";
            foreach (var el in str.Distinct())
            {
                if (result < str.Count(x => x == el)) 
                { 
                    result = str.Count(x => x == el);
                    resultA = el.ToString();
                }
            }
            return resultA.ToString();
        }
        string TextToStandart(string str)
        {
            string strBuff = str.ToUpper();
            string a = "1234567890/.,?><';:[]{}=+-_)(*&^%$#@!ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            foreach(var el in a)
            {
                strBuff = strBuff.Replace(el.ToString(), String.Empty);
            }
            return strBuff;
        }
    }

}
