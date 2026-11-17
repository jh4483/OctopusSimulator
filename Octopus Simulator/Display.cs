namespace OctopusSimulator
{
    public static class Display
    {
        private const char OctopusSymbol = 'O';
        private const char DrawerSymbol = 'D';
        private const char BrokenDrawerSymbol = 'x';
        private const char EmptySymbol = '.';
        private const char WallSymbol = '#';

        public static void Render(Sandbox sandbox)
        {
            string border = new string(WallSymbol, Sandbox.NumberOfColumns + 2);
            Console.WriteLine(border);

            for (int row = 0; row < Sandbox.NumberOfRows; row++)
            {
                Console.Write(WallSymbol);

                for (int column = 0; column < Sandbox.NumberOfColumns; column++)
                {
                    Console.Write(SymbolAt(sandbox, row, column));
                }

                Console.WriteLine(WallSymbol);
            }

            Console.WriteLine(border);

            string drawerState = sandbox.IsDrawerBroken ? "broken" : "intact";
            Console.WriteLine($"Speed: {sandbox.OctopusSpeed}  Turn: {sandbox.TurnCount}  Drawer: {drawerState}");
        }

        private static char SymbolAt(Sandbox sandbox, int row, int column)
        {
            if (row == sandbox.OctopusRow && column == sandbox.OctopusColumn)
            {
                return OctopusSymbol;
            }

            if (row == sandbox.DrawerRow && column == sandbox.DrawerColumn)
            {
                return sandbox.IsDrawerBroken ? BrokenDrawerSymbol : DrawerSymbol;
            }

            return EmptySymbol;
        }
    }
}