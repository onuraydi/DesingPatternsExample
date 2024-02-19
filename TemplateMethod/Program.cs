using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            ScroringAlgortihm scroringAlgortihm;
            Console.WriteLine("Men");
            scroringAlgortihm = new MensScoringAlgorithm();
            Console.WriteLine(scroringAlgortihm.GenerateScore(10, new TimeSpan(0, 2, 15)));

            Console.WriteLine();
            Console.WriteLine("Women");
            scroringAlgortihm = new WomanScoringAlgorithm();
            Console.WriteLine(scroringAlgortihm.GenerateScore(10, new TimeSpan(0, 2, 15)));

            Console.WriteLine();
            Console.WriteLine("Children");
            scroringAlgortihm = new ChildrenScoringAlgorithm();
            Console.WriteLine(scroringAlgortihm.GenerateScore(10, new TimeSpan(0, 2, 15)));

            Console.ReadLine();
        }
    }

    abstract class ScroringAlgortihm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);    
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateBaseScore(int hits);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateOverallScore(int score, int reduction);
    }

    class MensScoringAlgorithm: ScroringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 90;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class WomanScoringAlgorithm : ScroringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class ChildrenScoringAlgorithm : ScroringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 110;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
}
