namespace ConsoleApp1
{
    internal class Program
    {
        //КЛЮЧ
        static void Main(string[] args)
        {
            Console.WriteLine("Введите зашифрованный текст");
            string s = Console.ReadLine().Replace("\r", String.Empty).Replace("\n", String.Empty);
            //string s = "";
            //string s = "";
            //string s = "";
            //  \r\n
            var a = new VisionerDecryption(s);
            a.Decryption();
            Console.ReadKey();
        }
    }
}