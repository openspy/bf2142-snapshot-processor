using System;
using System.Threading;
using System.Collections.Generic; 
using QueueProcessor;
using QueueProcessor.Utils;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using Microsoft.Extensions.Logging;
using System.Linq;
using Newtonsoft.Json;
namespace BF2142.SnapshotProcessor {
    public static class PlayerInfo_ComputedHandler {
        public static void PerformComputations(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot currentPlayerInfo, ProcessorConfiguration processorConfig) {
            if(currentPlayerInfo.deaths > 0) {
                currentPlayerInfo.kill_death_ratio = (double)currentPlayerInfo.kills / (double)currentPlayerInfo.deaths;
            }

            if(currentPlayerInfo.total_shots > 0) {
                currentPlayerInfo.overall_accuracy = (double)currentPlayerInfo.total_hits / (double)currentPlayerInfo.total_shots;
            }

            switch(currentPlayerInfo.team) {
                case 1: //PAC
                    currentPlayerInfo.attp_one++; //increment total PAC plays
                break;
                case 2: //EU
                    currentPlayerInfo.attp_zero++; //incrmenet total EU plays
                break;
            }
            if(server_snapshot.game_properties.winning_team == gameserverSnapshot.team) {
                currentPlayerInfo.wins++;
            } else {
                currentPlayerInfo.losses++;
            }
            if(currentPlayerInfo.losses > 0)
                currentPlayerInfo.win_loss_ratio = (double)currentPlayerInfo.wins / (double)currentPlayerInfo.losses;

            switch(server_snapshot.game_properties.gamemode) {
                case 0: //conquest
                    currentPlayerInfo.csgpm_zero += currentPlayerInfo.time_as_commander;
                    currentPlayerInfo.ctgpm_zero += currentPlayerInfo.commander_score;
                break;
                case 1: //titan
                    currentPlayerInfo.csgpm_one += currentPlayerInfo.time_as_commander;
                    currentPlayerInfo.ctgpm_one += currentPlayerInfo.commander_score;
                break;
            }
            if(gameserverSnapshot.global_score > currentPlayerInfo.best_round_score) {
                currentPlayerInfo.best_round_score = gameserverSnapshot.global_score;
            }

            currentPlayerInfo.total_time_played += gameserverSnapshot.time_played;

            int newRank = processorConfig.GetRankByScore(currentPlayerInfo.global_score);
            if(newRank > currentPlayerInfo.rank) {
                currentPlayerInfo.rank = newRank;
                currentPlayerInfo.rank_changed = 1;
            }
        }
    }
}