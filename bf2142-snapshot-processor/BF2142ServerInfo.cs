using System.Text.Json;
using System.Collections;
using System.Text.Json.Serialization;
namespace BF2142.SnapshotProcessor {

    public class BF2142Weapon {
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dths")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int deaths { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kls")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int kills { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tp")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int total_points { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("bf")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int bullets_fired { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("bh")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public int bullets_hit { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [JsonPropertyName("accu")]
        [PlayerInfoOutputPageAttribute(PageName = "wep")]
        public float accuracy { get; set; }
    }
    public class BF2142Vehicle {
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dstry")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int destroyed { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dths")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int deaths { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kls")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int kills { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("rkls")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int r_kills { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tp")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int total_points { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("bf")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int bullets_fired { get; set; }

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("bh")]
        [PlayerInfoOutputPageAttribute(PageName = "veh")]
        public int bullets_hit { get; set; }
    }
    public class BF2142PlayerSnapshot {

        [JsonPropertyName("pid")]
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

        [JsonPropertyName("nick")]
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

        [JsonPropertyName("bp-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        public int has_nothern_strike {get => 1; set { } }

        [JsonPropertyName("ent-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        public int has_bestbuy_gun {get => 1; set { } }

        [JsonPropertyName("ent-2")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        public int has_ent_2 {get => 1; set { } }

        [JsonPropertyName("ent-3")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        public int has_bf2_vet_tag {get => 1; set { } }

        
        [JsonPropertyName("t")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Ignore)]
        public int team {get; set; }
        public int index {get; set; }

        #region Round Variables
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_GreaterEqual)]
        [JsonPropertyName("dstrk")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int death_streak {get; set; } //#> => Worst Death Streak

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_GreaterEqual)]
        [JsonPropertyName("klstrk")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kill_streak {get; set; } //#> => Kills Streak

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("capa")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "assist")]

        public int capture_assists {get; set; }     //+ => Capture Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("cpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "captures")]

        public int captured_control_points {get; set; }      //+ => Captured CPs

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("crpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "experiencepoints")]

        public int career_points {get; set; }      //+ => Captured CPs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("cs")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "points")]

        public double commander_score {get; set; }      //+ => Commander Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dass")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int driver_assists {get; set; }     //+ => Driver Assists

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dcpt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "flag", VariableName = "defend")]

        public int defended_control_points {get; set; }     //+ => Defended Control Points			

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dmst")]
        public int defended_missle_silos {get; set; }     //+ => Defended Missle Silos

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("dths")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int deaths {get; set; }     //+ => Deaths

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("gsco")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        [PlayerProgressOutputPageAttribute(PageName = "point", VariableName = "globalscore")]
        [PlayerProgressOutputPageAttribute(PageName = "score", VariableName = "score")]

        public int global_score {get; set; }     //+ => Global Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("hls")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "hls")]

        public int heals {get; set; }      //+ => Heals
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kick")]
        public int kicks {get; set; }     //+ => total kicks from servers
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("klla")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kill_assists {get; set; }     //+ => Kill Assists
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("klls")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills {get; set; }     //+ => Kills			
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("klse")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        
        public int kills_with_explosion {get; set; }     //+ => Kills With Explosion?

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kluav")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int kills_with_gun_drone {get; set; }    //+ => Kills With Gun Drone
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ncpt")]
        public int neutralized_control_points {get; set; }     //+ => Neutralized CPs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("nmst")]
        public int neutralized_missle_silos {get; set; }     //+ => Neutralized Missle Silos
        
        /*[StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]*/
        [JsonPropertyName("pdt")]
        public string player_dog_tags {get; set; }      //+ => Unique Dog Tags Collected //array
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("pdtc")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int total_dogtags_collected {get; set; }     //+ => Dog Tags Collected
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("resp")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "resp")]

        public int resupplies {get; set; }     //+ => Re-supplies
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("rps")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "rps")]

        public int repairs {get; set; }      //+ => Repairs
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("rvs")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "sup", VariableName = "rvs")]

        public int revives {get; set; }      //+ => Revives
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("slbspn")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int spawns_on_squad_beacons {get; set; }   //+ => Spawns On Squad Beacons
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("sluav")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int spawn_drones_deploys {get; set; }    //+ => Spawn Dron Deployed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("slpts")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]

        public int points_from_sls_beacon {get; set; }    //+ => Points from SLS Beacon ??
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("suic")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int suicides {get; set; }     //+ => Suicides
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tac")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "cotime")]

        public int time_as_commander {get; set; }      //+ => Time As Commander
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("talw")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "lwtime")]

        public int time_as_lone_wolf {get; set; }     //+ => Time As Lone Wolf
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tas")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_attack_score {get; set; }      //+ => Titan Attack Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tasl")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "sltime")]

        public int time_as_squad_leader {get; set; }     //+ => Time As Squad Leader
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tasm")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "role", VariableName = "smtime")]

        public int time_as_squad_member {get; set; }     //+ => Time As Squad Member
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tcd")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_components_destroyed {get; set; }      //+ => Titan Components Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tcrd")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_cores_destroyed {get; set; }     //+ => Titan Cores Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tdmg")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_damage {get; set; }     //+ => Team Damage
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tdrps")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_drops {get; set; }    //+ => Titan Drops
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tds")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_defend_score {get; set; }      //+ => Titan Defend Score
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tgd")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_guns_destroyed {get; set; }      //+ => Titan Guns Destroyed
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tgr")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]

        public int titan_guns_repaired {get; set; }      //+ => Titan Guns Repaired
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tkls")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_kills {get; set; }     //+ => Team Kills
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("toth")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerProgressOutputPageAttribute(PageName = "waccu", VariableName = "toth")]

        public int total_hits {get; set; }     //+ => Total Hits
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tots")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerProgressOutputPageAttribute(PageName = "waccu", VariableName = "tots")]

        public int? total_shots {get; set; }     //+ => Total Fired
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tt")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int? time_played {get; set; }       //+ => Time Played
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("tvdmg")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]

        public int team_vehicle_damage {get; set; }    //+ => Team Vehicle Damage
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("twsc")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerProgressOutputPageAttribute(PageName = "twsc", VariableName = "twsc")]

        public int teamwork_score {get; set; }     //+ => Teamwork Score

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kdths-0")]
        public int deaths_as_recon {get; set; }  //+ => deads as Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kdths-1")]
        public int deaths_as_assault {get; set; }  //+ => deads as Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kdths-2")]
        public int deaths_as_engineer {get; set; }  //+ => deads as Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kdths-3")]
        public int deaths_as_support {get; set; }  //+ => deads as Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kkls-0")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_recon {get; set; }  //+ => Kills As Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kkls-1")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_assault {get; set; }  //+ => Kills As Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kkls-2")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_engineer {get; set; }  //+ => Kills As Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("kkls-3")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int kills_as_support {get; set; }  //+ => Kills As Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ktt-0")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_recon {get; set; }   //+ => Time As Recon
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ktt-1")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_assault {get; set; }   //+ => Time As Assault
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ktt-2")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_engineer {get; set; }   //+ => Time As Engineer
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ktt-3")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]

        public int time_as_support {get; set; }   //+ => Time As Support
        
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("etp-3")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int time_cloaked {get; set; } //+ => Time cloaked

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalCep")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int MedalCep {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalavsb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalavsb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalslsb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalslsb {get; set; } //+ => ???


        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("mvks")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int mvks {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalErp")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalErp {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalerb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalerb {get; set; } //+ => ???


        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalssb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalssb {get; set; } //+ => ???


        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalHr")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalHr {get; set; } //+ => ???


        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medaltdeb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medaltdeb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalrsb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalrsb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalasb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalasb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalers")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalers {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalresb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalresb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalerg")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalerg {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medaltsb")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medaltsb {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalDcep")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalDcep {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalIp")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalIp {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medaltdab")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medaltdab {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("medalCcp")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]

        public int medalCcp {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("mvns")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int mvns {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("c")]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]

        public int c {get; set; } //+ => ???

        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
        [JsonPropertyName("ban")]

        public int bans {get; set; } //+ => times banned (or maybe just if was banned)

        #endregion

        #region Calculated Variables
        //these variables can also be sent in a snapshot
        [JsonPropertyName("rnk")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int rank {get; set; }

        [JsonPropertyName("rnkcg")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public int rank_changed {get; set; }


        [JsonPropertyName("kdr")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double kill_death_ratio {get; set;}

        [JsonPropertyName("csgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double csgpm_one {get; set;}
        [JsonPropertyName("csgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double csgpm_zero {get; set;}

        [JsonPropertyName("ctgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double ctgpm_zero {get; set;}

        [JsonPropertyName("ctgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double ctgpm_one {get; set;}

        [JsonPropertyName("trp")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double trp {get; set;}

        [JsonPropertyName("attp-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double attp_zero {get; set;}

        [JsonPropertyName("attp-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Set)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double attp_one {get; set;}

        [JsonPropertyName("bksgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        public double best_kill_streak_pac {get; set;}

        [JsonPropertyName("bksgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        public double best_kill_streak_eu {get; set;}

        [JsonPropertyName("kgpm-0")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        public double total_kills_pac {get; set;}

        [JsonPropertyName("kgpm-1")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        public double total_kills_eu {get; set;}

        [JsonPropertyName("win")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)] //this property is "insecure" because the server could send win: 2000 and increment by 2x, should be capped at 1
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        [PlayerProgressOutputPageAttribute(PageName = "wl", VariableName = "wins")]
        public int? wins {get; set; }

        [JsonPropertyName("los")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)] //this property is "insecure" because the server could send win: 2000 and increment by 2x, should be capped at 1
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        [PlayerProgressOutputPageAttribute(PageName = "wl", VariableName = "losses")]
        public int? losses {get; set; }

        [JsonPropertyName("wlr")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Computed)]
        [PlayerInfoOutputPageAttribute(PageName = "base")]
        [PlayerInfoOutputPageAttribute(PageName = "ply")]
        [PlayerInfoOutputPageAttribute(PageName = "titan")]
        [PlayerInfoOutputPageAttribute(PageName = "wrk")]
        [PlayerInfoOutputPageAttribute(PageName = "com")]
        [PlayerInfoOutputPageAttribute(PageName = "ovr")]
        [PlayerInfoOutputPageAttribute(PageName = "comp")]
        public double win_loss_ratio {get; set; }

        [JsonPropertyName("ovaccu")]
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

        [JsonPropertyName("ttp")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_Increment)]
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

        [JsonPropertyName("brs")]
        [StatsHandlerAttribute(HandlerType = StatsHandlerAttribute.EStatsHandlerType.HandlerType_GreaterEqual)]
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
        [Vehicle(VehicleId = 0)]
        public BF2142Vehicle vehicle_0 {get; set;}
        [Vehicle(VehicleId = 1)]
        public BF2142Vehicle vehicle_1 {get; set;}
        [Vehicle(VehicleId = 2)]
        public BF2142Vehicle vehicle_2 {get; set;}
        [Vehicle(VehicleId = 3)]
        public BF2142Vehicle vehicle_3 {get; set;}
        [Vehicle(VehicleId = 4)]
        public BF2142Vehicle vehicle_4 {get; set;}
        [Vehicle(VehicleId = 5)]
        public BF2142Vehicle vehicle_5 {get; set;}
        [Vehicle(VehicleId = 6)]
        public BF2142Vehicle vehicle_6 {get; set;}
        [Vehicle(VehicleId = 7)]
        public BF2142Vehicle vehicle_7 {get; set;}
        [Vehicle(VehicleId = 8)]
        public BF2142Vehicle vehicle_8 {get; set;}
        [Vehicle(VehicleId = 8)]
        public BF2142Vehicle vehicle_9 {get; set;}
        [Vehicle(VehicleId = 9)]
        public BF2142Vehicle vehicle_10 {get; set;}
        [Vehicle(VehicleId = 10)]
        public BF2142Vehicle vehicle_11 {get; set;}
        [Vehicle(VehicleId = 11)]
        public BF2142Vehicle vehicle_12 {get; set;}
        [Vehicle(VehicleId = 12)]
        public BF2142Vehicle vehicle_13 {get; set;}
        [Vehicle(VehicleId = 14)]
        public BF2142Vehicle vehicle_14 {get; set;}
        [Vehicle(VehicleId = 15)]
        public BF2142Vehicle vehicle_15 {get; set;}
        #endregion

        #region Weapon Variables
        [Weapon(WeaponId = 0)]
        public BF2142Weapon weapon_0 {get; set;}

        [Weapon(WeaponId = 1)]
        public BF2142Weapon weapon_1 {get; set;}

        [Weapon(WeaponId = 2)]
        public BF2142Weapon weapon_2 {get; set;}

        [Weapon(WeaponId = 3)]
        public BF2142Weapon weapon_3 {get; set;}

        [Weapon(WeaponId = 4)]
        public BF2142Weapon weapon_4 {get; set;}

        [Weapon(WeaponId = 5)]
        public BF2142Weapon weapon_5 {get; set;}

        [Weapon(WeaponId = 6)]
        public BF2142Weapon weapon_6 {get; set;}

        [Weapon(WeaponId = 7)]
        public BF2142Weapon weapon_7 {get; set;}

        [Weapon(WeaponId = 8)]
        public BF2142Weapon weapon_8 {get; set;}

        [Weapon(WeaponId = 9)]
        public BF2142Weapon weapon_9 {get; set;}

        [Weapon(WeaponId = 10)]
        public BF2142Weapon weapon_10 {get; set;}

        [Weapon(WeaponId = 11)]
        public BF2142Weapon weapon_11 {get; set;}

        [Weapon(WeaponId = 12)]
        public BF2142Weapon weapon_12 {get; set;}

        [Weapon(WeaponId = 13)]
        public BF2142Weapon weapon_13 {get; set;}

        [Weapon(WeaponId = 14)]
        public BF2142Weapon weapon_14 {get; set;}

        [Weapon(WeaponId = 15)]
        public BF2142Weapon weapon_15 {get; set;}

        [Weapon(WeaponId = 16)]
        public BF2142Weapon weapon_16 {get; set;}

        [Weapon(WeaponId = 17)]
        public BF2142Weapon weapon_17 {get; set;}

        [Weapon(WeaponId = 18)]
        public BF2142Weapon weapon_18 {get; set;}

        [Weapon(WeaponId = 19)]
        public BF2142Weapon weapon_19 {get; set;}

        [Weapon(WeaponId = 20)]
        public BF2142Weapon weapon_20 {get; set;}

        [Weapon(WeaponId = 21)]
        public BF2142Weapon weapon_21 {get; set;}

        [Weapon(WeaponId = 22)]
        public BF2142Weapon weapon_22 {get; set;}

        [Weapon(WeaponId = 23)]
        public BF2142Weapon weapon_23 {get; set;}

        [Weapon(WeaponId = 24)]
        public BF2142Weapon weapon_24 {get; set;}

        [Weapon(WeaponId = 25)]
        public BF2142Weapon weapon_25 {get; set;}

        [Weapon(WeaponId = 26)]
        public BF2142Weapon weapon_26 {get; set;}

        [Weapon(WeaponId = 27)]
        public BF2142Weapon weapon_27 {get; set;}

        [Weapon(WeaponId = 28)]
        public BF2142Weapon weapon_28 {get; set;}

        [Weapon(WeaponId = 29)]
        public BF2142Weapon weapon_29 {get; set;}

        [Weapon(WeaponId = 30)]
        public BF2142Weapon weapon_30 {get; set;}

        [Weapon(WeaponId = 31)]
        public BF2142Weapon weapon_31 {get; set;}

        [Weapon(WeaponId = 32)]
        public BF2142Weapon weapon_32 {get; set;}

        [Weapon(WeaponId = 33)]
        public BF2142Weapon weapon_33 {get; set;}

        [Weapon(WeaponId = 34)]
        public BF2142Weapon weapon_34 {get; set;}
        
        [Weapon(WeaponId = 35)]
        public BF2142Weapon weapon_35 {get; set;}

        [Weapon(WeaponId = 36)]
        public BF2142Weapon weapon_36 {get; set;}

        [Weapon(WeaponId = 37)]
        public BF2142Weapon weapon_37 {get; set;}

        [Weapon(WeaponId = 38)]
        public BF2142Weapon weapon_38 {get; set;}

        [Weapon(WeaponId = 39)]
        public BF2142Weapon weapon_39 {get; set;}

        [Weapon(WeaponId = 40)]
        public BF2142Weapon weapon_40 {get; set;}

        [Weapon(WeaponId = 41)]
        public BF2142Weapon weapon_41 {get; set;}

        [Weapon(WeaponId = 42)]
        public BF2142Weapon weapon_42 {get; set;}

        #endregion
    }

    [JsonConverter(typeof(BF2142SnapshotProcessor.JsonConverters.BF2142SnapshotConverter))]
    public class BF2142Snapshot {

        public BF2142Snapshot() {
            player_snapshots = new Hashtable();
            game_properties = new GameProperties();
        }
        public class GameProperties {
            public string hostname {get; set;}
            public string mapname {get; set;}

            [JsonPropertyName("m")]
            public int map_index {get; set;}
            public int maxplayers {get; set;}
            [JsonPropertyName("gm")]
            public int gamemode {get; set;}

            [JsonPropertyName("win")]
            public int winning_team {get; set;}

            [JsonConverter(typeof(BF2142SnapshotProcessor.JsonConverters.DecimalTimeConverter))]
            [JsonPropertyName("mapstart")]
            public System.DateTime map_start_time {get; set;}


            [JsonConverter(typeof(BF2142SnapshotProcessor.JsonConverters.DecimalTimeConverter))]
            [JsonPropertyName("mapend")]
            public System.DateTime map_end_time {get; set;}

            [JsonPropertyName("v")]
            public string version {get; set;}

            [JsonPropertyName("pc")]
            public int numplayers {get; set;}

            [JsonPropertyName("rwa")]
            public int rwa {get; set;} //???

            [JsonPropertyName("EOF")]
            public int got_EOF {get; set;} //should always be 1
        }
        [JsonPropertyName("data")]
        public GameProperties game_properties {get; set;}
        public Hashtable player_snapshots { get; set; }
    }
}