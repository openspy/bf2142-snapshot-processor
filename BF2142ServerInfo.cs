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
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
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
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
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
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "assist")]

        public int capture_assists {get; set; }     //+ => Capture Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("cpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "captures")]

        public int captured_control_points {get; set; }      //+ => Captured CPs

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("crpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "experiencepoints")]

        public int career_points {get; set; }      //+ => Captured CPs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("cs")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "points")]

        public double commander_score {get; set; }      //+ => Commander Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dass")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int driver_assists {get; set; }     //+ => Driver Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("dcpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "defend")]

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
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "globalscore")]
        [PlayerProgressOutputPageAttribute(PageName = "score", VariableName = "score")]

        public int global_score {get; set; }     //+ => Global Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("hls")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "hls")]

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
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "resp")]

        public int resupplies {get; set; }     //+ => Re-supplies
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("rps")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "rps")]

        public int repairs {get; set; }      //+ => Repairs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("rvs")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "rvs")]

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
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "cotime")]

        public int time_as_commander {get; set; }      //+ => Time As Commander
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("talw")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "lwtime")]

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
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "sltime")]

        public int time_as_squad_leader {get; set; }     //+ => Time As Squad Leader
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tasm")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "smtime")]

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
        [PlayerProgressOutputPageAttribute(PageName = "waccu", VariableName = "toth")]

        public int total_hits {get; set; }     //+ => Total Hits
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("tots")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerProgressOutputPageAttribute(PageName = "waccu", VariableName = "tots")]

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
        [PlayerProgressOutputPageAttribute(PageName = "twsc", VariableName = "twsc")]

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
        [PlayerProgressOutputPageAttribute(PageName = "wl", VariableName = "wins")]
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
        [PlayerProgressOutputPageAttribute(PageName = "wl", VariableName = "losses")]
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
        [PlayerProgressOutputPageAttribute(PageName = "waccu", VariableName = "waccu")]
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
        [PlayerProgressOutputPageAttribute(PageName = "ttp", VariableName = "ttp")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "ttp")]
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
    
        #region Vehicle Variables
            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-0")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_0 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-1")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_1 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-2")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_2 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-3")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_3 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-4")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_4 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-5")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_5 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-6")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_6 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-7")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_7 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-8")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_8 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-9")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_9 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-10")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_10 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-11")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_11 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-12")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_12 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdstry-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicles_destroyed_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vdths-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_deaths_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vkls-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_kills_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vrkls-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_r_kills_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vtp-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_total_points_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbf-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bf_13 { get; set; }

            [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
            [JsonProperty("vbh-13")]
            [PlayerInfoOutputPageAttribute(PageName = "veh")]
            public int vehicle_bh_13 { get; set; }
        #endregion
    
        #region Weapon Variables
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-0")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_0 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-0")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_0 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-0")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_0 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-0")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_0 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-0")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_0 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-1")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_1 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-1")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_1 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-1")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_1 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-1")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_1 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-1")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_1 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-2")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_2 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-2")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_2 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-2")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_2 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-2")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_2 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-2")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_2 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-3")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_3 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-3")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_3 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-3")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_3 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-3")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_3 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-3")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_3 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-4")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_4 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-4")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_4 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-4")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_4 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-4")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_4 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-4")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_4 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-5")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_5 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-5")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_5 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-5")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_5 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-5")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_5 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-5")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_5 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-6")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_6 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-6")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_6 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-6")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_6 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-6")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_6 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-6")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_6 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-7")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_7 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-7")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_7 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-7")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_7 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-7")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_7 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-7")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_7 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-8")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_8 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-8")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_8 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-8")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_8 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-8")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_8 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-8")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_8 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-9")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_9 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-9")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_9 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-9")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_9 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-9")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_9 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-9")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_9 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-10")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_10 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-10")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_10 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-10")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_10 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-10")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_10 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-10")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_10 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-11")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_11 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-11")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_11 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-11")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_11 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-11")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_11 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-11")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_11 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-12")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_12 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-12")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_12 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-12")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_12 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-12")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_12 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-12")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_12 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-13")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_13 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-13")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_13 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-13")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_13 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-13")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_13 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-13")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_13 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-14")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_14 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-14")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_14 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-14")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_14 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-14")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_14 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-14")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_14 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-15")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_15 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-15")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_15 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-15")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_15 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-15")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_15 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-15")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_15 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-16")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_16 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-16")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_16 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-16")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_16 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-16")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_16 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-16")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_16 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-17")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_17 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-17")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_17 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-17")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_17 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-17")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_17 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-17")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_17 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-18")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_18 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-18")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_18 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-18")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_18 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-18")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_18 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-18")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_18 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-19")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_19 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-19")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_19 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-19")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_19 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-19")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_19 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-19")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_19 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-20")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_20 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-20")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_20 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-20")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_20 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-20")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_20 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-20")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_20 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-21")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_21 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-21")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_21 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-21")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_21 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-21")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_21 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-21")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_21 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-22")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_22 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-22")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_22 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-22")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_22 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-22")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_22 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-22")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_22 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-23")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_23 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-23")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_23 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-23")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_23 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-23")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_23 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-23")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_23 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-24")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_24 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-24")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_24 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-24")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_24 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-24")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_24 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-24")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_24 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-25")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_25 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-25")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_25 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-25")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_25 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-25")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_25 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-25")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_25 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-26")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_26 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-26")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_26 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-26")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_26 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-26")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_26 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-26")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_26 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-27")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_27 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-27")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_27 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-27")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_27 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-27")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_27 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-27")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_27 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-28")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_28 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-28")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_28 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-28")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_28 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-28")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_28 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-28")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_28 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-29")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_29 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-29")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_29 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-29")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_29 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-29")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_29 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-29")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_29 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-30")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_30 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-30")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_30 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-30")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_30 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-30")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_30 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-30")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_30 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-31")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_31 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-31")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_31 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-31")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_31 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-31")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_31 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-31")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_31 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-32")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_32 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-32")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_32 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-32")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_32 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-32")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_32 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-32")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_32 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-33")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_33 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-33")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_33 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-33")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_33 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-33")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_33 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-33")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_33 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-34")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_34 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-34")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_34 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-34")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_34 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-34")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_34 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-34")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_34 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-35")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_35 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-35")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_35 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-35")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_35 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-35")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_35 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-35")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_35 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-36")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_36 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-36")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_36 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-36")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_36 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-36")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_36 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-36")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_36 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-37")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_37 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-37")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_37 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-37")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_37 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-37")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_37 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-37")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_37 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-38")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_38 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-38")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_38 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-38")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_38 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-38")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_38 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-38")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_38 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-39")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_39 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-39")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_39 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-39")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_39 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-39")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_39 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-39")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_39 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-40")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_40 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-40")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_40 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-40")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_40 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-40")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_40 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-40")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_40 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-41")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_41 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-41")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_41 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-41")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_41 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-41")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_41 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-41")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_41 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wdths-42")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_deaths_42 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wkls-42")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_kills_42 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wtp-42")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_total_points_42 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbf-42")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bf_42 { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonProperty("wbh-42")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int weapon_bh_42 { get; set; }
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
