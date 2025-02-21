namespace Strumplådan3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory amandasInventarie = new Inventory();
            amandasInventarie.GetSavedSocks();
            amandasInventarie.MainMenu();
        }
    }
}
