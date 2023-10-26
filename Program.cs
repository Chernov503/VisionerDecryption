namespace ConsoleApp1
{
    internal class Program
    {
        //КЛЮЧ
        static void Main(string[] args)
        {
            Console.WriteLine("Введите зашифрованный текст");
            string s = Console.ReadLine().Replace("\r", String.Empty).Replace("\n", String.Empty);
            var a = new VisionerDecryption(s);
            a.Decryption();
            Console.ReadKey();
        }
    }
}