using System.Text;

namespace ConsoleApp1
{
    public class VisionerDecryption
    {
        //Частотный индекс
        double IndexCount = 0.0553;
        //Алфавит
        string alphabit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //Строка введенная пользователем
        string s;
        //Длина ключа
        int KeyLenght;
        //Итоговая длина ключа
        int KeyLenghtResult;
        //Частотный индекс текста с ключем Key
        double KeyLenghtVer;
        //Группы строк исходя из длины ключа, согласно алгоритму
        string[] sGroaps;
        //Ключ
        string Key = "";

        //Конструктор
        public VisionerDecryption(string s)
        {
            this.s = TextToStandart(s);
            

        }
        //Метод осуществляющий дешифровку
        public void Decryption()
        {
            //то же самое
            KeyLenght = 2;
            int counter = 1;
            while (IndexCountCheck(StringReturn(KeyLenght)) != true)
            {
                KeyLenght++;
                counter++;
                if (counter == 8) { break; }
            }
            Console.WriteLine($"Длина ключа {KeyLenghtResult} частотная вероятность {KeyLenghtVer}");
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
                    try
                    {
                        Key += alphabit[alphabit.IndexOf(a) + 33 - alphabit.IndexOf("О")];
                    }
                    catch { Key += "А"; }
                }


                counter++;
            }

            Console.WriteLine(Key);




        }
        //Проверяет частотный индекс переданной строки с константным
        //если получившийся индекс выше константного, возвращает true, иначе false
        //Промежуточно записывает длину ключа в поле класса, если полученный результат ближе к константному
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
        //Принимает в себя предпологаемый размер ключа и исходя из этого возвращает строку
        //с каждым n-ым символом согласно алгоритму
        string StringReturn(int n)
        {
            StringBuilder stroka = new StringBuilder();
            for (int i = 0; i < s.Length; i += n)
            {
                stroka.Append(s[i]);
            }
            return stroka.ToString();
        }
        //Распределяет строку на группы строк, согласно алгоритму, возвращает массив строк
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
        //Находит самый встречающийся символ в строке
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
        //Приводит текст к стандартному виду
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
