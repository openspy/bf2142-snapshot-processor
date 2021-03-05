using Newtonsoft.Json;
namespace BF2142.SnapshotProcessor {
    public class BF2142PlayerSnapshot {

        [JsonProperty("pid")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int profileid {get; set; }
        [JsonProperty("nick")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public string nick {get; set; }

        
        [JsonProperty("t")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Ignore)]
        public int team {get; set; }
        public int index {get; set; }

        #region Round Variables
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_GreaterEqual)]
        [JsonProperty("dstrk")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int death_streak {get; set; } //#> => Worst Death Streak

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_GreaterEqual)]
        [JsonProperty("klstrk")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kill_streak {get; set; } //#> => Kills Streak

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("capa")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int capture_assists {get; set; }     //+ => Capture Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("cpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int captured_control_points {get; set; }      //+ => Captured CPs

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("crpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int career_points {get; set; }      //+ => Captured CPs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("cs")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public double commander_score {get; set; }      //+ => Commander Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dass")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int driver_assists {get; set; }     //+ => Driver Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dcpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int defended_control_points {get; set; }     //+ => Defended Control Points			

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dmst")]
        public int defended_missle_silos {get; set; }     //+ => Defended Missle Silos

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dths")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int deaths {get; set; }     //+ => Deaths

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("gsco")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int global_score {get; set; }     //+ => Global Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("hls")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int heals {get; set; }      //+ => Heals
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kick")]
        public int kicks {get; set; }     //+ => total kicks from servers
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("klla")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kill_assists {get; set; }     //+ => Kill Assists
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("klls")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills {get; set; }     //+ => Kills			
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("klse")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        
        public int kills_with_explosion {get; set; }     //+ => Kills With Explosion?

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kluav")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int kills_with_gun_drone {get; set; }    //+ => Kills With Gun Drone
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("ncpt")]
        public int neutralized_control_points {get; set; }     //+ => Neutralized CPs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("nmst")]
        public int neutralized_missle_silos {get; set; }     //+ => Neutralized Missle Silos
        
        /*[StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]*/
        [JsonProperty("pdt")]
        public string player_dog_tags {get; set; }      //+ => Unique Dog Tags Collected //array
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("pdtc")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int total_dogtags_collected {get; set; }     //+ => Dog Tags Collected
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("resp")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int resupplies {get; set; }     //+ => Re-supplies
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("rps")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int repairs {get; set; }      //+ => Repairs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("rvs")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int revives {get; set; }      //+ => Revives
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("slbspn")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int spawns_on_squad_beacons {get; set; }   //+ => Spawns On Squad Beacons
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("sluav")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int spawn_drones_deploys {get; set; }    //+ => Spawn Dron Deployed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("slpts")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int points_from_sls_beacon {get; set; }    //+ => Points from SLS Beacon ??
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("suic")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int suicides {get; set; }     //+ => Suicides
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tac")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int time_as_commander {get; set; }      //+ => Time As Commander
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("talw")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int time_as_lone_wolf {get; set; }     //+ => Time As Lone Wolf
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tas")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_attack_score {get; set; }      //+ => Titan Attack Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tasl")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int time_as_squad_leader {get; set; }     //+ => Time As Squad Leader
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tasm")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int time_as_squad_member {get; set; }     //+ => Time As Squad Member
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tcd")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_components_destroyed {get; set; }      //+ => Titan Components Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tcrd")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_cores_destroyed {get; set; }     //+ => Titan Cores Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tdmg")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_damage {get; set; }     //+ => Team Damage
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tdrps")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_drops {get; set; }    //+ => Titan Drops
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tds")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_defend_score {get; set; }      //+ => Titan Defend Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tgd")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_guns_destroyed {get; set; }      //+ => Titan Guns Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tgr")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_guns_repaired {get; set; }      //+ => Titan Guns Repaired
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tkls")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_kills {get; set; }     //+ => Team Kills
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("toth")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int total_hits {get; set; }     //+ => Total Hits
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tots")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int total_shots {get; set; }     //+ => Total Fired
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int time_played {get; set; }       //+ => Time Played
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tvdmg")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_vehicle_damage {get; set; }    //+ => Team Vehicle Damage
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("twsc")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int teamwork_score {get; set; }     //+ => Teamwork Score

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kdths-0")]
        public int deaths_as_recon;  //+ => deads as Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kdths-1")]
        public int deaths_as_assault;  //+ => deads as Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kdths-2")]
        public int deaths_as_engineer;  //+ => deads as Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kdths-3")]
        public int deaths_as_support;  //+ => deads as Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kkls-0")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_recon;  //+ => Kills As Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kkls-1")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_assault;  //+ => Kills As Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kkls-2")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_engineer;  //+ => Kills As Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("kkls-3")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_support;  //+ => Kills As Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("ktt-0")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_recon;   //+ => Time As Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("ktt-1")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_assault;   //+ => Time As Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("ktt-2")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_engineer;   //+ => Time As Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("ktt-3")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_support;   //+ => Time As Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("etp-3")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int time_cloaked; //+ => Time cloaked

        #endregion
    
        #region Calculated Variables
        //these variables can also be sent in a snapshot
        [JsonProperty("rnk")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int rank {get; set; }

        [JsonProperty("rnkcg")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int rank_changed {get; set; }


        [JsonProperty("kdr")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double kill_death_ratio {get; set;}

        [JsonProperty("csgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double csgpm_one {get; set;}
        [JsonProperty("csgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double csgpm_zero {get; set;}

        [JsonProperty("ctgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double ctgpm_zero {get; set;}

        [JsonProperty("ctgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double ctgpm_one {get; set;}

        [JsonProperty("trp")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double trp {get; set;}

        [JsonProperty("attp-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double attp_zero {get; set;}

        [JsonProperty("attp-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double attp_one {get; set;}

        [JsonProperty("win")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)] //this property is "insecure" because the server could send win: 2000 and increment by 2x, should be capped at 1
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int wins {get; set; }

        [JsonProperty("los")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)] //this property is "insecure" because the server could send win: 2000 and increment by 2x, should be capped at 1
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int losses {get; set; }

        [JsonProperty("wlr")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double win_loss_ratio {get; set; }

        [JsonProperty("ovaccu")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double overall_accuracy {get; set; }

        [JsonProperty("ttp")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int total_time_played {get; set; }

        [JsonProperty("brs")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double best_round_score {get; set; }
        #endregion
    
    }
    public class BF2142Snapshot {

        //inheritied properties
        public System.DateTime created {get; set; }
        public int profileId {get; set; }
        //
        public class GameProperties {
            public string hostname {get; set;}
            public string mapname {get; set;}
            public int maxplayers {get; set;}
            public int gamemode {get; set;}

            [JsonProperty("win")]
            public int winning_team {get; set;}
            [JsonProperty("mapstart")]
            public float map_start_time {get; set;}

            [JsonProperty("mapend")]
            public float map_end_time {get; set;}
        }
        [JsonProperty("data")]
        public GameProperties game_properties {get; set;}
        public System.Collections.Generic.List<BF2142PlayerSnapshot> player_snapshots { get; set; }
    }
}
