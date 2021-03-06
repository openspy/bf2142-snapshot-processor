using System.Collections.Generic;  
namespace BF2142.SnapshotProcessor {
    public class RankScoreMap {
        public int rank {get; set;}
        public int score {get; set;}
    }
    public class ProcessorConfiguration : QueueProcessor.ProcessorConfiguration {
        public ProcessorConfiguration() {
            rank_scores = new List<RankScoreMap>();
            rank_scores.Add(new RankScoreMap {rank = 0, score = 0});
            rank_scores.Add(new RankScoreMap { rank = 1, score = 40});
            rank_scores.Add(new RankScoreMap { rank = 2, score = 80});
            rank_scores.Add(new RankScoreMap { rank = 3, score = 120});
            rank_scores.Add(new RankScoreMap { rank = 4, score = 200});
            rank_scores.Add(new RankScoreMap { rank = 5, score = 330});
            rank_scores.Add(new RankScoreMap { rank = 6, score = 520});
            rank_scores.Add(new RankScoreMap { rank = 7, score = 750});
            rank_scores.Add(new RankScoreMap { rank = 8, score = 1050});
            rank_scores.Add(new RankScoreMap { rank = 9, score = 1400});
            rank_scores.Add(new RankScoreMap { rank = 10, score = 1800});
            rank_scores.Add(new RankScoreMap { rank = 11, score = 2250});
            rank_scores.Add(new RankScoreMap { rank = 12, score = 2850});
            rank_scores.Add(new RankScoreMap { rank = 13, score = 3550});
            rank_scores.Add(new RankScoreMap { rank = 14, score = 4400});
            rank_scores.Add(new RankScoreMap { rank = 15, score = 5300});
            rank_scores.Add(new RankScoreMap { rank = 16, score = 6250});
            rank_scores.Add(new RankScoreMap { rank = 17, score = 7250});
            rank_scores.Add(new RankScoreMap { rank = 18, score = 8250});
            rank_scores.Add(new RankScoreMap { rank = 19, score = 9300});
            rank_scores.Add(new RankScoreMap { rank = 20, score = 10400});
            rank_scores.Add(new RankScoreMap { rank = 21, score = 11550});
            rank_scores.Add(new RankScoreMap { rank = 22, score = 12700});
            rank_scores.Add(new RankScoreMap { rank = 23, score = 14000});
            rank_scores.Add(new RankScoreMap { rank = 24, score = 15300});
            rank_scores.Add(new RankScoreMap { rank = 25, score = 16700});
            rank_scores.Add(new RankScoreMap { rank = 26, score = 18300});
            rank_scores.Add(new RankScoreMap { rank = 27, score = 20100});
            rank_scores.Add(new RankScoreMap { rank = 28, score = 22100});
            rank_scores.Add(new RankScoreMap { rank = 29, score = 24200});
            rank_scores.Add(new RankScoreMap { rank = 30, score = 26400});
            rank_scores.Add(new RankScoreMap { rank = 31, score = 28800});
            rank_scores.Add(new RankScoreMap { rank = 32, score = 31500});
            rank_scores.Add(new RankScoreMap { rank = 33, score = 34200});
            rank_scores.Add(new RankScoreMap { rank = 34, score = 37100});
            rank_scores.Add(new RankScoreMap { rank = 35, score = 40200});
            rank_scores.Add(new RankScoreMap { rank = 36, score = 43300});
            rank_scores.Add(new RankScoreMap { rank = 37, score = 46900});
            rank_scores.Add(new RankScoreMap { rank = 38, score = 50500});
            rank_scores.Add(new RankScoreMap { rank = 39, score = 54100});
            rank_scores.Add(new RankScoreMap { rank = 40, score = 57700});
            rank_scores.Add(new RankScoreMap { rank = 41, score = 1000000});
            //rank_scores.Add(new RankScoreMap { rank = 42, score = 0});
            //rank_scores.Add(new RankScoreMap { rank = 43, score = 0});
        }
        public List<RankScoreMap> rank_scores {get; set;}
        public int num_ranks {get => rank_scores.Count; set { throw new System.InvalidOperationException(); } }

        public int GetRankByScore(int score) {
            int last_rank = 0;
            foreach(var item in rank_scores) {
                if(score >= item.score && last_rank < item.rank)
                    last_rank = item.rank;
            }

            return last_rank;
        }
    }
}