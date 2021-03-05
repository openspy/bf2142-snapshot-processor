using System.Collections.Generic;  
namespace BF2142.SnapshotProcessor {

    public class ProcessorConfiguration : QueueProcessor.ProcessorConfiguration {
        public ProcessorConfiguration() {
            rank_scores = new int[44];
            rank_scores[0] = 0;
            rank_scores[1] = 40;
            rank_scores[2] = 80;
            rank_scores[3] = 120;
            rank_scores[4] = 200;
            rank_scores[5] = 330;
            rank_scores[6] = 520;
            rank_scores[7] = 750;
            rank_scores[8] = 1050;
            rank_scores[9] = 1400;
            rank_scores[10] = 1800;
            rank_scores[11] = 2250;
            rank_scores[12] = 2850;
            rank_scores[13] = 3550;
            rank_scores[14] = 4400;
            rank_scores[15] = 5300;
            rank_scores[16] = 6250;
            rank_scores[17] = 7250;
            rank_scores[18] = 8250;
            rank_scores[19] = 9300;
            rank_scores[20] = 10400;
            rank_scores[21] = 11550;
            rank_scores[22] = 12700;
            rank_scores[23] = 14000;
            rank_scores[24] = 15300;
            rank_scores[25] = 16700;
            rank_scores[26] = 18300;
            rank_scores[27] = 20100;
            rank_scores[28] = 22100;
            rank_scores[29] = 24200;
            rank_scores[30] = 26400;
            rank_scores[31] = 28800;
            rank_scores[32] = 31500;
            rank_scores[33] = 34200;
            rank_scores[34] = 37100;
            rank_scores[35] = 40200;
            rank_scores[36] = 43300;
            rank_scores[37] = 46900;
            rank_scores[38] = 50500;
            rank_scores[39] = 54100;
            rank_scores[40] = 57700;
            rank_scores[41] = 1000000;
            rank_scores[42] = 0;
            rank_scores[43] = 0;
        }
        public int[] rank_scores {get; set;}
        public int num_ranks {get => rank_scores.Length; set { throw new System.InvalidOperationException(); } }

        public int GetRankByScore(int score) {
            int last_rank = 0;
            for(var i=0;i<num_ranks;i++) {
                if(score >= rank_scores[i] && rank_scores[i] != 0) {
                    last_rank = i;
                }
            }
            return last_rank;
        }
    }
}