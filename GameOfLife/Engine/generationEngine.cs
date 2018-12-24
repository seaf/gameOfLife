using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    public class GenerationEngine : IGenerationEngine
    {
        public HashSet<Tuple<ulong, ulong>> Advance(HashSet<Tuple<ulong, ulong>> liveCells)
        {
            return liveCells;
        }

        private IEnumerable<Tuple<ulong, ulong>> GetValidNeighbors(Tuple<ulong, ulong> cell)
        {
            var notDone = true;
            var validNeighbors = new List<Tuple<ulong, ulong>>();
            var enumerator = this.GetNeighbors(cell).GetEnumerator();
            while (notDone)
            {
                try
                {
                    notDone = enumerator.MoveNext();
                    validNeighbors.Add(enumerator.Current);
                }
                catch (OverflowException) { }
            }

            return validNeighbors;
        }

        // TODO: Consider as an extension method
        // TODO: Alternative to avoid throwing in under/overflow cases: check Item1/2 values against 0 and ulong.MaxValue
        // TODO: Consider a "Cell" class to replace tuple that would hold logic for handling neighbors and checking under/overflow. This
        private IEnumerable<Tuple<ulong, ulong>> GetNeighbors(Tuple<ulong, ulong> cell)
        {
            yield return Tuple.Create(checked(cell.Item1 - 1), checked(cell.Item2 - 1));
            yield return Tuple.Create(checked(cell.Item1 - 1), checked(cell.Item2));
            yield return Tuple.Create(checked(cell.Item1 - 1), checked(cell.Item2 + 1));
            yield return Tuple.Create(checked(cell.Item1), checked(cell.Item2 - 1));
            yield return Tuple.Create(checked(cell.Item1), checked(cell.Item2));
            yield return Tuple.Create(checked(cell.Item1), checked(cell.Item2 + 1));
            yield return Tuple.Create(checked(cell.Item1 + 1), checked(cell.Item2 - 1));
            yield return Tuple.Create(checked(cell.Item1 + 1), checked(cell.Item2));
            yield return Tuple.Create(checked(cell.Item1 + 1), checked(cell.Item2 + 1));
        }
    }
}
