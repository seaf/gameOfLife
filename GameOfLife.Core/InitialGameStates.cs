using System.Collections.Generic;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core
{
    /// <summary>
    /// See:
    /// https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
    /// http://www.conwaylife.com/wiki/Main_Page
    /// 
    /// Our format is basically Life 1.06 with origin in a different spot.
    /// </summary>
    public static class InitialGameStates
    {
        public static HashSet<Cell> MinimalSingleBlockLayingSwitchEngine =
            new HashSet<Cell> {
                new Cell(211,217),
                new Cell(212,215),
                new Cell(212,217),
                new Cell(212,218),
                new Cell(213,215),
                new Cell(213,217),
                new Cell(214,215),
                new Cell(215,213),
                new Cell(216,211),
                new Cell(216,213)};

        public static HashSet<Cell> FiveByFiveSingleBlockLayingSwitchEngine =
            new HashSet<Cell> {
                new Cell(211,211),
                new Cell(211,212),
                new Cell(211,213),
                new Cell(211,215),
                new Cell(212,211),
                new Cell(213,214),
                new Cell(213,215),
                new Cell(214,212),
                new Cell(214,213),
                new Cell(214,215),
                new Cell(215,211),
                new Cell(215,213),
                new Cell(215,215)};

        public static HashSet<Cell> OneCellHighDoubleBlockLayingSwitchEngine =
            new HashSet<Cell>
            {
                new Cell(101,101),
                new Cell(101,102),
                new Cell(101,103),
                new Cell(101,104),
                new Cell(101,105),
                new Cell(101,106),
                new Cell(101,107),
                new Cell(101,108),
                new Cell(101,110),
                new Cell(101,111),
                new Cell(101,112),
                new Cell(101,113),
                new Cell(101,114),
                new Cell(101,118),
                new Cell(101,119),
                new Cell(101,120),
                new Cell(101,127),
                new Cell(101,128),
                new Cell(101,129),
                new Cell(101,130),
                new Cell(101,131),
                new Cell(101,132),
                new Cell(101,133),
                new Cell(101,135),
                new Cell(101,136),
                new Cell(101,137),
                new Cell(101,138),
                new Cell(101,139),
            };

        public static HashSet<Cell> GosperGliderGun =
            new HashSet<Cell>
            {
                new Cell(0, 24),
                new Cell(1, 22),
                new Cell(1, 24),
                new Cell(2, 12),
                new Cell(2, 13),
                new Cell(2, 20),
                new Cell(2, 21),
                new Cell(2, 34),
                new Cell(2, 35),
                new Cell(3, 11),
                new Cell(3, 15),
                new Cell(3, 20),
                new Cell(3, 21),
                new Cell(3, 34),
                new Cell(3, 35),
                new Cell(4, 0),
                new Cell(4, 1),
                new Cell(4, 10),
                new Cell(4, 16),
                new Cell(4, 20),
                new Cell(4, 21),
                new Cell(5, 0),
                new Cell(5, 1),
                new Cell(5, 10),
                new Cell(5, 14),
                new Cell(5, 16),
                new Cell(5, 17),
                new Cell(5, 22),
                new Cell(5, 24),
                new Cell(6, 10),
                new Cell(6, 16),
                new Cell(6, 24),
                new Cell(7, 11),
                new Cell(7, 15),
                new Cell(8, 12),
                new Cell(8, 13),
            };

        public static HashSet<Cell> PentadecathonOscillator =
            new HashSet<Cell>
            {
                new Cell(100, 100),
                new Cell(100, 101),
                new Cell(100, 102),
                new Cell(100, 103),
                new Cell(100, 104),
                new Cell(100, 105),
                new Cell(100, 106),
                new Cell(100, 107),
                new Cell(101, 100),
                new Cell(101, 102),
                new Cell(101, 103),
                new Cell(101, 104),
                new Cell(101, 105),
                new Cell(101, 107),
                new Cell(102, 100),
                new Cell(102, 101),
                new Cell(102, 102),
                new Cell(102, 103),
                new Cell(102, 104),
                new Cell(102, 105),
                new Cell(102, 106),
                new Cell(102, 107)};
    }
}
