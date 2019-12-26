using UnityEngine;

/// <summary>
/// This Class provides Functions to write and read from JSON.
/// </summary>
public static class HandleMoveData
{
    /// <summary>
    /// Returns MoveData with the given Index.
    /// See also JSON_MoveData.LoadData().
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>MoveData</returns>
    public static MoveData LoadData(int Index)
    {
        if (Index == 0)
            Debug.Log("You are probably requesting the wrong Move.\nIndex = 0 is only a Placeholder");

        return MoveData.Database[Index];
    }
}

/// <summary>
/// Provides Functions to write and read from JSON for Handling of the MoveData Class.
/// </summary>
public static class JSON_MoveData
{
    /// <summary>
    /// Writes all MoveData(s) to a JSON.
    /// </summary>
    static public void WriteDataBase()
    {
        MoveDataBase Database = new MoveDataBase
        {
            MoveData = MoveData.GetDatabase()
        };

        //cache
        string Ref = MoveData.Database[0].Reference;

        for (int i = 0; i < MoveData.Count; i++)
        {
            if (Database.MoveData[i].Reference == Ref)
                Database.MoveData[i].Reference = Database.MoveData[i].Name.ToLower(true);
            if (Database.MoveData[i].ID == -1)
                Database.MoveData[i].ID = i;
        }

        DataManagment.WriteToJSON(Database, "PokemonData/Data");
    }

    /// <summary>
    /// Return the whole DataBase (Class).
    /// Use with DataBase.MoveData[Index].
    /// </summary>
    /// <returns></returns>
    static public MoveDataBase LoadDataBase()
    {
        string JSON = DataManagment.ReadFromJSON("PokemonData/Data");

        return JsonUtility.FromJson<MoveDataBase>(JSON);
    }

    /// <summary>
    /// Returns MoveData with a given Index.
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>MoveData</returns>
    static public MoveData LoadData(int Index)
    {
        return LoadDataBase().MoveData[Index];
    }
}

/// <summary>
/// This Class functions purely as a JSON-Helper.
/// </summary>
public class MoveDataBase
{
    public MoveData[] MoveData;
}

/// <summary>
/// An Array of registered Moves.
/// Only override variable different to default.
/// </summary>
[System.Serializable]
public class MoveData
{
    #region Variables

    public string Name = "Placeholder Name";
    public string Description = "Placeholder Description";

    /// <summary>
    /// This string is for reference through a string.
    /// Don't override for standard formatting:
    /// "placeholder_name"
    /// </summary>
    public string Reference = "placeholder_reference";
    public Move Move = Move.none;

    /// <summary>
    /// If ID stays at -1, check will throw error!
    /// </summary>
    public int ID = -1;
    public int Power = 0;
    public int Accuracy = 100;

    /// <summary>
    /// Index of the effect(s).
    /// </summary>
    public int[] Index;
    public Target Target = Target.ADJACENT;

    /// <summary>
    /// Prioritylist:
    /// [-2] Always last
    /// [-1] last
    /// [0] neutral
    /// [1] first
    /// [2] more first
    /// [3] Always first
    /// </summary>
    public int Priority = 0;
    public int PP = 0;

    public bool Contact = false;
    public bool Protectable = false;
    public bool MagicCoatable = false;
    public bool Snatchable = false;
    public bool SoundBased = false;

    public P_Type Type = P_Type.none;
    public AttackCategory Category = AttackCategory.None;

    #endregion

    public MoveData()
    {
        Reference = Name.ToLower(true);
    }

    public static int Count { get { return Database.Length; } }
    public static MoveData[] Database;

    #region DataBase

    static MoveData()
    {
        Database = new MoveData[]
        {
            new MoveData()
            {
                ID = 0
            },

            new MoveData()
            {
                Name = "Tackle",
                Description = "A physical attack in which the user charges and slams into the target with its whole body.",
                Move = Move.Tackle,
                ID = 33,
                Power = 40,
                PP = 35,
                Type = P_Type.Normal,
                Category = AttackCategory.Physical,
                Protectable = true,
                Contact = true
            },  //Tackle
            new MoveData()
            {
                Name = "Growl",
                Description = "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.",
                Move = Move.Growl,
                ID = 45,
                PP = 40,
                Type = P_Type.Normal,
                Category = AttackCategory.Status,
                Protectable = true,
                MagicCoatable = true,
                SoundBased = true,
                Target = Target.ADJACENTOPPONENT
            },  //Growl
            new MoveData()
            {
                Name = "Vine Whip",
                Description = "The target is struck with slender, whiplike vines to inflict damage.",
                Move = Move.VineWhip,
                Power = 45,
                ID = 22,
                PP = 25,
                Type = P_Type.Grass,
                Category = AttackCategory.Physical,
                Protectable = true,
                Contact = true
            },  //Vine Whip
            new MoveData()
            {
                Name = "Growth",
                Description = "The user's body grows all at once, raising the Attack and Sp. Atk stats.",
                Move = Move.Growth,
                ID = 74,
                PP = 20,
                Type = P_Type.Normal,
                Category = AttackCategory.Status,
                Snatchable = true,
                Target = Target.SELF
            },  //Growth
            new MoveData()
            {
                Name = "Leech Seed",
                Description = "A seed is planted on the target. It steals some HP from the target every turn.",
                Move = Move.LeechSeed,
                ID = 73,
                PP = 10,
                Accuracy = 90,
                Type = P_Type.Grass,
                Category = AttackCategory.Status,
                Protectable = true,
                MagicCoatable = true
            },  //Leech Seed
            new MoveData()
            {
                Name = "Razor Leaf",
                Description = "Sharp-edged leaves are launched to slash at opposing Pokémon. Critical hits land more easily.",
                Move = Move.RazorLeaf,
                ID = 75,
                PP = 25,
                Power = 55,
                Accuracy = 95,
                Type = P_Type.Grass,
                Category = AttackCategory.Physical,
                Protectable = true,
                Target = Target.ADJACENTOPPONENT
            },  //Razor Leaf
            new MoveData()
            {
                Name = "Poison Powder",
                Description = "The user scatters a cloud of poisonous dust that poisons the target.",
                Move = Move.PoisonPowder,
                ID = 77,
                PP = 35,
                Accuracy = 75,
                Type = P_Type.Poison,
                Category = AttackCategory.Status,
                Protectable = true,
                MagicCoatable = true
            },  //Poison Powder
            new MoveData()
            {
                Name = "Sleep Powder",
                Description = "The user scatters a big cloud of sleep-inducing dust around the target.",
                Move = Move.SleepPowder,
                ID = 79,
                PP = 15,
                Accuracy = 75,
                Type = P_Type.Grass,
                Category = AttackCategory.Status,
                Protectable = true,
                MagicCoatable = true
            },  //Sleep Powder
            new MoveData()
            {
                Name = "Seed Bomb",
                Description = "The user slams a barrage of hard-shelled seeds down on the target from above.",
                Move = Move.SeedBomb,
                ID = 402,
                PP = 15,
                Power = 80,
                Type = P_Type.Grass,
                Category = AttackCategory.Physical,
                Protectable = true
            },  //Seed Bomb
            new MoveData()
            {
                Name = "Take Down",
                Description = "A reckless, full-body charge attack for slamming into the target. This also damages the user a little.",
                Move = Move.TakeDown,
                ID = 36,
                PP = 20,
                Power = 90,
                Accuracy = 85,
                Type = P_Type.Normal,
                Category = AttackCategory.Physical,
                Protectable = true,
                Contact = true
            }   //Take Down
        };
    }

    #endregion

    #region Methods

    public static MoveData GetData(int Index)
    {
        return Database[Index];
    }

    public static MoveData GetData(Move Move)
    {
        for (int i = 0; i < MoveData.Count; i++)
        {
            if (Database[i].Move == Move)
            {
                return Database[i];
            }
        }

        return Database[0];
    }

    public static MoveData[] GetDatabase()
    {
        return Database;
    }

    #endregion
}

#region Enums

public enum AttackCategory
{
    None,

    Physical,
    Special,
    Status
}

public enum Target
{
    SELF,
    ADJACENT,
    ANY,
    ADJACENTALLY,
    ADJACENTOPPONENT,
    ADJACENTALLYSELF,
    ALL,
    ALLADJACENT,
    ALLADJACENTOPPONENT,
    ALLOPPONENT,
    ALLALLY
}

public enum Move
{
    none,
    Pound,
    Doubleslap,
    CometPunch,
    MegaPunch,
    FirePunch,
    IcePunch,
    ThunderPunch,
    Scratch,
    ViceGrip,
    Guillotine,
    RazorWind,
    SwordsDance,
    Cut,
    Gust,
    WingAttack,
    Whirlwind,
    Fly,
    Bind,
    Slam,
    VineWhip,
    Stomp,
    DoubleKick,
    MegaKick,
    JumpKick,
    RollingKick,
    SandAttack,
    Headbutt,
    HornAttack,
    FuryAttack,
    HornDrill,
    Tackle,
    BodySlam,
    Wrap,
    TakeDown,
    Thrash,
    DoubleEdge,
    TailWhip,
    PoisonSting,
    Twineedle,
    PinMissile,
    Leer,
    Bite,
    Growl,
    Roar,
    Sing,
    Supersonic,
    Sonicboom,
    Disable,
    Acid,
    Ember,
    Flamethrower,
    Mist,
    WaterGun,
    HydroPump,
    Surf,
    IceBeam,
    Blizzard,
    Psybeam,
    Bubblebeam,
    AuroraBeam,
    HyperBeam,
    Peck,
    DrillPeck,
    Submission,
    LowKick,
    Counter,
    SeismicToss,
    Strength,
    Absorb,
    MegaDrain,
    LeechSeed,
    Growth,
    RazorLeaf,
    Solarbeam,
    PoisonPowder,
    StunSpore,
    SleepPowder,
    PetalDance,
    StringShot,
    DragonRage,
    FireSpin,
    Thundershock,
    Thunderbolt,
    ThunderWave,
    Thunder,
    RockThrow,
    Earthquake,
    Fissure,
    Dig,
    Toxic,
    Confusion,
    Psychic,
    Hypnosis,
    Meditate,
    Agility,
    QuickAttack,
    Rage,
    Teleport,
    NightShade,
    Mimic,
    Screech,
    DoubleTeam,
    Recover,
    Harden,
    Minimize,
    Smokescreen,
    ConfuseRay,
    Withdraw,
    DefenseCurl,
    Barrier,
    LightScreen,
    Haze,
    Reflect,
    FocusEnergy,
    Bide,
    Metronome,
    MirrorMove,
    Selfdestruct,
    EggBomb,
    Lick,
    Smog,
    Sludge,
    BoneClub,
    FireBlast,
    Waterfall,
    Clamp,
    Swift,
    SkullBash,
    SpikeCannon,
    Constrict,
    Amnesia,
    Kinesis,
    Softboiled,
    HiJumpKick,
    Glare,
    DreamEater,
    PoisonGas,
    Barrage,
    LeechLife,
    LovelyKiss,
    SkyAttack,
    Transform,
    Bubble,
    DizzyPunch,
    Spore,
    Flash,
    Psywave,
    Splash,
    AcidArmor,
    Crabhammer,
    Explosion,
    FurySwipes,
    Bonemerang,
    Rest,
    RockSlide,
    HyperFang,
    Sharpen,
    Conversion,
    TriAttack,
    SuperFang,
    Slash,
    Substitute,
    Struggle,
    Sketch,
    TripleKick,
    Thief,
    SpiderWeb,
    MindReader,
    Nightmare,
    FlameWheel,
    Snore,
    Curse,
    Flail,
    Conversion2,
    Aeroblast,
    CottonSpore,
    Reversal,
    Spite,
    PowderSnow,
    Protect,
    MachPunch,
    ScaryFace,
    FaintAttack,
    SweetKiss,
    BellyDrum,
    SludgeBomb,
    MudSlap,
    Octazooka,
    Spikes,
    ZapCannon,
    Foresight,
    DestinyBond,
    PerishSong,
    IcyWind,
    Detect,
    BoneRush,
    LockOn,
    Outrage,
    Sandstorm,
    GigaDrain,
    Endure,
    Charm,
    Rollout,
    FalseSwipe,
    Swagger,
    MilkDrink,
    Spark,
    FuryCutter,
    SteelWing,
    MeanLook,
    Attract,
    SleepTalk,
    HealBell,
    Return,
    Present,
    Frustration,
    Safeguard,
    PainSplit,
    SacredFire,
    Magnitude,
    Dynamicpunch,
    Megahorn,
    Dragonbreath,
    BatonPass,
    Encore,
    Pursuit,
    RapidSpin,
    SweetScent,
    IronTail,
    MetalClaw,
    VitalThrow,
    MorningSun,
    Synthesis,
    Moonlight,
    HiddenPower,
    CrossChop,
    Twister,
    RainDance,
    SunnyDay,
    Crunch,
    MirrorCoat,
    PsychUp,
    Extremespeed,
    Ancientpower,
    ShadowBall,
    FutureSight,
    RockSmash,
    Whirlpool,
    BeatUp,
    FakeOut,
    Uproar,
    Stockpile,
    SpitUp,
    Swallow,
    HeatWave,
    Hail,
    Tornment,
    Flatters,
    WillOWisp,
    Memento,
    Facade,
    FocusPunch,
    Smellingsalt,
    FollowMe,
    NaturePower,
    Charge,
    Taunt,
    HelpingHand,
    Trick,
    RolePlay,
    Wish,
    Assist,
    Ingrain,
    Superpower,
    MagicCoat,
    Recycle,
    Revenge,
    BrickBreak,
    Yawn,
    KnowkOff,
    Endeavor,
    Eruption,
    SkillSwap,
    Imprison,
    Refresh,
    Grudge,
    Snatch,
    SecretPower,
    Dive,
    ArmThrust,
    Camouflage,
    TailGlow,
    LusterPurge,
    MistBall,
    Featherdance,
    TeeterDance,
    BlazeKick,
    MudSport,
    IceBall,
    NeedleArm,
    SlackOff,
    HyperVoice,
    PoisonFang,
    CrushClaw,
    BlastBurn,
    HydroCannon,
    MeteorMash,
    Astonish,
    WeatherBall,
    Aromatherapy,
    FakeTears,
    AirCutter,
    Overheat,
    OdorSleuth,
    RockTomb,
    SilverWind,
    MetalSound,
    Grasswhistle,
    Tickle,
    CosmicPower,
    WaterSpout,
    SignalBeam,
    ShadowPunch,
    Extrasensory,
    SkyUppercut,
    SandTomb,
    SheerCold,
    MuddyWater,
    BulletSeed,
    AerialAce,
    IcicleSpear,
    IronDefense,
    Block,
    Howl,
    DragonClaw,
    FrenzyPlant,
    BulkUp,
    Bounce,
    MudShot,
    PoisonTail,
    Covet,
    VoltTackle,
    MagicalLeaf,
    WaterSport,
    CalmMind,
    LeafBlade,
    DragonDance,
    RockBlast,
    ShockWave,
    WaterPulse,
    DoomDesire,
    PyschoBoost,
    Roost,
    Gravity,
    MiracleEye,
    WakeUpSlap,
    HammerArm,
    GyroBall,
    HealingWish,
    Brine,
    NaturalGift,
    Feint,
    Pluck,
    Tailwind,
    Acupressure,
    MeatlBurst,
    Uturn,
    CloseCombat,
    Payback,
    Assurance,
    Embargo,
    Fling,
    PsychoShift,
    TrumpCard,
    HealBlock,
    WringOut,
    PowerTrick,
    GastroAcid,
    LuckyChant,
    MeFirst,
    Copycat,
    PowerSwap,
    GuardSwap,
    Punishment,
    LastResort,
    WorrySeed,
    SuckerPunch,
    ToxicSpikes,
    HeartSwap,
    AquaRing,
    MagnetRise,
    FlareBlitz,
    ForcePalm,
    AuraSphere,
    RockPolish,
    PoisonJab,
    DarkPulse,
    NightSlash,
    AquaTail,
    SeedBomb,
    AirSlash,
    XScissor,
    BugBuzz,
    DragonPulse,
    DragonRush,
    PowerGem,
    DrainPunch,
    VacuumWave,
    FocusBlast,
    EnergyBall,
    BraveBird,
    EarthPower,
    Switcheroo,
    GigaImpact,
    NastyPlot,
    BulletPunch,
    Avalanche,
    IceShard,
    ShadowClaw,
    ThunderFang,
    IceFang,
    FireFang,
    ShadowSneak,
    MudBomb,
    PsychoCut,
    ZenHeadbutt,
    MirrorShot,
    FlashCannon,
    RockClimb,
    Defog,
    TrickRoom,
    DracoMeteor,
    Discharge,
    LavaPlume,
    LeafStorm,
    PowerWhip,
    RockWrecker,
    CrossPoison,
    GunkShot,
    IronHead,
    MagnetBomb,
    StoneEdge,
    Captivate,
    StealthRock,
    GrassKnot,
    Chatter,
    Judgment,
    BugBite,
    ChargeBeam,
    WoodHammer,
    AquaJet,
    AttackOrder,
    DefendOrder,
    HealOrder,
    HeadSmash,
    DoubleHit,
    RoarofTime,
    SpacialRend,
    LunarDance,
    CrushGrip,
    MagmaStorm,
    DarkVoid,
    SeedFlare,
    ShadowForce
}
/*
 * https://pikamon.fandom.com/wiki/List_of_Moves
 */

#endregion