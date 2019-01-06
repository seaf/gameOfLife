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
                new Cell(511,517),
                new Cell(512,515),
                new Cell(512,517),
                new Cell(512,518),
                new Cell(513,515),
                new Cell(513,517),
                new Cell(514,515),
                new Cell(515,513),
                new Cell(516,511),
                new Cell(516,513)};

        public static HashSet<Cell> FiveByFiveSingleBlockLayingSwitchEngine =
            new HashSet<Cell> {
                new Cell(511,511),
                new Cell(511,512),
                new Cell(511,513),
                new Cell(511,515),
                new Cell(512,511),
                new Cell(513,514),
                new Cell(513,515),
                new Cell(514,512),
                new Cell(514,513),
                new Cell(514,515),
                new Cell(515,511),
                new Cell(515,513),
                new Cell(515,515)};

        public static HashSet<Cell> OneCellHighDoubleBlockLayingSwitchEngine =
            new HashSet<Cell>
            {
                new Cell(501,501),
                new Cell(501,502),
                new Cell(501,503),
                new Cell(501,504),
                new Cell(501,505),
                new Cell(501,506),
                new Cell(501,507),
                new Cell(501,508),
                new Cell(501,510),
                new Cell(501,511),
                new Cell(501,512),
                new Cell(501,513),
                new Cell(501,514),
                new Cell(501,518),
                new Cell(501,519),
                new Cell(501,520),
                new Cell(501,527),
                new Cell(501,528),
                new Cell(501,529),
                new Cell(501,530),
                new Cell(501,531),
                new Cell(501,532),
                new Cell(501,533),
                new Cell(501,535),
                new Cell(501,536),
                new Cell(501,537),
                new Cell(501,538),
                new Cell(501,539),
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
                new Cell(400, 400),
                new Cell(400, 401),
                new Cell(400, 402),
                new Cell(400, 403),
                new Cell(400, 404),
                new Cell(400, 405),
                new Cell(400, 406),
                new Cell(400, 407),
                new Cell(401, 400),
                new Cell(401, 402),
                new Cell(401, 403),
                new Cell(401, 404),
                new Cell(401, 405),
                new Cell(401, 407),
                new Cell(402, 400),
                new Cell(402, 401),
                new Cell(402, 402),
                new Cell(402, 403),
                new Cell(402, 404),
                new Cell(402, 405),
                new Cell(402, 406),
                new Cell(402, 407)};
    }
}
