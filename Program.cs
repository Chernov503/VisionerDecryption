namespace ConsoleApp1
{
    internal class Program
    {
        //КЛЮЧ
        static void Main(string[] args)
        {
            Console.WriteLine("Введите зашифрованный текст");
            string s = Console.ReadLine();
            var a = new VisionerDecryption(s);
        }
    }
}