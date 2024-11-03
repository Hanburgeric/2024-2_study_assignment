using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------

            var mth_scores = Enumerable.Range(1, stdCount).Select(i => double.Parse(data[i, 2U]));
            var sci_scores = Enumerable.Range(1, stdCount).Select(i => double.Parse(data[i, 3U]));
            var eng_scores = Enumerable.Range(1, stdCount).Select(i => double.Parse(data[i, 4U]));

            Console.WriteLine("Average Scores:");
            Console.WriteLine("Math: " + mth_scores.Average());
            Console.WriteLine("Science: " + sci_scores.Average());
            Console.WriteLine("English: " + eng_scores.Average());

            Console.WriteLine();

            Console.WriteLine("Max and min Scores:");
            Console.WriteLine("Math: (" + mth_scores.Max() + ", " + mth_scores.Min() + ")");
            Console.WriteLine("Science: (" + sci_scores.Max() + ", " + sci_scores.Min() + ")");
            Console.WriteLine("English: (" + eng_scores.Max() + ", " + eng_scores.Min() + ")");

            Console.WriteLine();

            // Rank students by score
            var std_ranks = Enumerable.Range(1, stdCount).Select(i => new
            {
                name_ = data[i, 1U],
                score_ = double.Parse(data[i, 2U]) + double.Parse(data[i, 3U]) + double.Parse(data[i, 4U])
            }).OrderByDescending(std => std.score_).Select((std, rank) => new
            {
                name_ = std.name_,
                rank_ = rank + 1
            }).OrderBy(student => student.name_);

            // Convert rank to ordinal number
            Func<int, string> RankToOrdinal = rank =>
            {
                int tens_ones = rank % 100;
                if (tens_ones == 11 || tens_ones == 12 || tens_ones == 13) return "th";
                else
                {
                    int ones = tens_ones % 10;
                    switch (ones)
                    {
                        case 1: return "st";
                        case 2: return "nd";
                        case 3: return "rd";
                        default: return "th";
                    }
                }
            };

            Console.WriteLine("Student rank by total scores:");
            foreach (var std in std_ranks)
            {
                Console.WriteLine(std.name_ + ": " + std.rank_ + RankToOrdinal(std.rank_));
            }

            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/
