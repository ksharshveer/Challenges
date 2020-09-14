using System.Text;

namespace Arrays
{
    public class ABoardGame
    {
        public string WhoWins(string[] board)
        {
            var BoardCellValues = (Alice: 'A', Bob: 'B', Empty: '.');
            var BoardGameResults = (AliceWins: "Alice", BobWins: "Bob", Draw: "Draw");

            // Track points for both players in each region
            int AlicePoints = 0;
            int BobPoints = 0;
            foreach (var region in GetBoardRegions(board))
            {
                foreach (var ch in region.ToCharArray())
                {
                    if (ch == BoardCellValues.Empty) continue;
                    else if (ch == BoardCellValues.Alice) AlicePoints++;
                    else if (ch == BoardCellValues.Bob) BobPoints++;
                }
                if (AlicePoints > BobPoints) return BoardGameResults.AliceWins;
                else if (BobPoints > AlicePoints) return BoardGameResults.BobWins;
                AlicePoints = 0;
                BobPoints = 0;
            }
            return BoardGameResults.Draw;
        }

        // Get board regions starting with most important innermost regions,
        // each region being represented as a string
        public string[] GetBoardRegions(string[] board)
        {
            int numOfRegions = board.Length / 2;
            string[] regions = new string[numOfRegions];

            int curRegion = 1;
            int curRegionIndex = numOfRegions - 1;
            int curRegionHorizontalCount = 2 * curRegion;
            int curRegionVerticalCount = curRegionHorizontalCount - 2;

            while (curRegion <= numOfRegions)
            {
                StringBuilder region = new StringBuilder();

                // Read horizontal parts of the region
                for (int i = curRegionIndex; i < curRegionIndex + curRegionHorizontalCount; i++)
                {
                    region.Append(board[curRegionIndex][i]);
                    region.Append(board[curRegionIndex + curRegionHorizontalCount - 1][i]);
                }

                // Read vertical parts of the region remaining,
                // except the ones which already got covered earlier
                int changedRegionIndex = curRegionIndex + 1;
                for (int i = changedRegionIndex; i < changedRegionIndex + curRegionVerticalCount; i++)
                {
                    region.Append(board[i][curRegionIndex]);
                    region.Append(board[i][curRegionIndex + curRegionHorizontalCount - 1]);
                }

                regions[curRegion - 1] = region.ToString();
                curRegion++;
                curRegionHorizontalCount = 2 * curRegion;
                curRegionVerticalCount = curRegionHorizontalCount - 2;
                curRegionIndex--;
            }

            return regions;
        }
    }
}
