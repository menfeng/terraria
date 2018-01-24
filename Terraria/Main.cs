using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Terraria
{
	public class Main : Game
	{
		private const int MF_BYPOSITION = 1024;

		public const int sectionWidth = 200;

		public const int sectionHeight = 150;

		public const int maxTileSets = 150;

		public const int maxWallTypes = 32;

		public const int maxBackgrounds = 32;

		public const int maxDust = 2000;

		public const int maxCombatText = 100;

		public const int maxItemText = 20;

		public const int maxPlayers = 255;

		public const int maxChests = 1000;

		public const int maxItemTypes = 603;

		public const int maxItems = 200;

		public const int maxBuffs = 40;

		public const int maxProjectileTypes = 111;

		public const int maxProjectiles = 1000;

		public const int maxNPCTypes = 147;

		public const int maxNPCs = 200;

		public const int maxGoreTypes = 160;

		public const int maxGore = 200;

		public const int maxInventory = 48;

		public const int maxItemSounds = 37;

		public const int maxNPCHitSounds = 11;

		public const int maxNPCKilledSounds = 15;

		public const int maxLiquidTypes = 2;

		public const int maxMusic = 14;

		public const int numArmorHead = 45;

		public const int numArmorBody = 26;

		public const int numArmorLegs = 25;

		public const double dayLength = 54000.0;

		public const double nightLength = 32400.0;

		public const int maxStars = 130;

		public const int maxStarTypes = 5;

		public const int maxClouds = 100;

		public const int maxCloudTypes = 4;

		public const int maxHair = 36;

		public static bool isChatFormOpen = false;

		public static bool isPNGMODOpen = false;

		public static int SetWindowPos_X = -1;

		public static int SetWindowPos_Y = -1;

		public static int curRelease = 37;

		public static string versionNumber = "v1.1.1 (程序:LS 翻译:Yuzuke 升级:Magian)";

		public static string versionNumber2 = "v1.1.1";

		public static bool skipMenu = false;

		public static bool verboseNetplay = false;

		public static bool stopTimeOuts = false;

		public static bool showSpam = false;

		public static bool showItemOwner = false;

		public static int oldTempLightCount = 0;

		public static int musicBox = -1;

		public static int musicBox2 = -1;

		public static float upTimer;

		public static float upTimerMax;

		public static float upTimerMaxDelay;

		public static float[] drawTimer = new float[10];

		public static float[] drawTimerMax = new float[10];

		public static float[] drawTimerMaxDelay = new float[10];

		public static float[] renderTimer = new float[10];

		public static float[] lightTimer = new float[10];

		public static bool drawDiag = false;

		public static bool drawRelease = false;

		public static bool renderNow = false;

		public static bool drawToScreen = false;

		public static bool targetSet = false;

		public static int mouseX;

		public static int mouseY;

		public static bool mouseLeft;

		public static bool mouseRight;

		public static float essScale = 1f;

		public static int essDir = -1;

		public static string debugWords = "";

		public static bool gamePad = false;

		public static bool xMas = false;

		public static int snowDust = 0;

		public static bool netDiag = false;

		public static int txData = 0;

		public static int rxData = 0;

		public static int txMsg = 0;

		public static int rxMsg = 0;

		public static int maxMsg = 61;

		public static int[] rxMsgType = new int[Main.maxMsg];

		public static int[] rxDataType = new int[Main.maxMsg];

		public static int[] txMsgType = new int[Main.maxMsg];

		public static int[] txDataType = new int[Main.maxMsg];

		public static float uCarry = 0f;

		public static bool drawSkip = false;

		public static int fpsCount = 0;

		public static Stopwatch fpsTimer = new Stopwatch();

		public static Stopwatch updateTimer = new Stopwatch();

		public bool gammaTest;

		public static bool showSplash = true;

		public static bool ignoreErrors = true;

		public static string defaultIP = "";

		public static int dayRate = 1;

		public static int maxScreenW = 1920;

		public static int minScreenW = 800;

		public static int maxScreenH = 1200;

		public static int minScreenH = 600;

		public static float iS = 1f;

		public static bool render = false;

		public static int qaStyle = 0;

		public static int zoneX = 99;

		public static int zoneY = 87;

		public static float harpNote = 0f;

		public static bool[] debuff = new bool[40];

		public static string[] buffName = new string[40];

		public static string[] buffTip = new string[40];

		public static int maxMP = 10;

		public static string[] recentWorld = new string[Main.maxMP];

		public static string[] recentIP = new string[Main.maxMP];

		public static int[] recentPort = new int[Main.maxMP];

		public static bool shortRender = true;

		public static bool owBack = true;

		public static int quickBG = 2;

		public static int bgDelay = 0;

		public static int bgStyle = 0;

		public static float[] bgAlpha = new float[10];

		public static float[] bgAlpha2 = new float[10];

		public bool showNPCs;

		public int mouseNPC = -1;

		public static int wof = -1;

		public static int wofT;

		public static int wofB;

		public static int wofF = 0;

		private static int offScreenRange = 200;

		private RenderTarget2D backWaterTarget;

		private RenderTarget2D waterTarget;

		private RenderTarget2D tileTarget;

		private RenderTarget2D blackTarget;

		private RenderTarget2D tile2Target;

		private RenderTarget2D wallTarget;

		private RenderTarget2D backgroundTarget;

		private int firstTileX;

		private int lastTileX;

		private int firstTileY;

		private int lastTileY;

		private double bgParrallax;

		private int bgStart;

		private int bgLoops;

		private int bgStartY;

		private int bgLoopsY;

		private int bgTop;

		public static int renderCount = 99;

		private GraphicsDeviceManager graphics;

		private SpriteBatch spriteBatch;

		private Process tServer = new Process();

		private static Stopwatch saveTime = new Stopwatch();

		public static MouseState mouseState = Mouse.GetState();

		public static MouseState oldMouseState = Mouse.GetState();

		public static KeyboardState keyState = Keyboard.GetState();

		public static Microsoft.Xna.Framework.Color mcColor = new Microsoft.Xna.Framework.Color(125, 125, 255);

		public static Microsoft.Xna.Framework.Color hcColor = new Microsoft.Xna.Framework.Color(200, 125, 255);

		public static Microsoft.Xna.Framework.Color bgColor;

		public static bool mouseHC = false;

		public static string chestText = "Chest";

		public static bool craftingHide = false;

		public static bool armorHide = false;

		public static float craftingAlpha = 1f;

		public static float armorAlpha = 1f;

		public static float[] buffAlpha = new float[40];

		public static Item trashItem = new Item();

		public static bool hardMode = false;

		public float chestLootScale = 1f;

		public bool chestLootHover;

		public float chestStackScale = 1f;

		public bool chestStackHover;

		public float chestDepositScale = 1f;

		public bool chestDepositHover;

		public static bool drawScene = false;

		public static Vector2 sceneWaterPos = default(Vector2);

		public static Vector2 sceneTilePos = default(Vector2);

		public static Vector2 sceneTile2Pos = default(Vector2);

		public static Vector2 sceneWallPos = default(Vector2);

		public static Vector2 sceneBackgroundPos = default(Vector2);

		public static bool maxQ = true;

		public static float gfxQuality = 1f;

		public static float gfxRate = 0.01f;

		public int DiscoStyle;

		public static int DiscoR = 255;

		public static int DiscoB = 0;

		public static int DiscoG = 0;

		public static int teamCooldown = 0;

		public static int teamCooldownLen = 300;

		public static bool gamePaused = false;

		public static int updateTime = 0;

		public static int drawTime = 0;

		public static int uCount = 0;

		public static int updateRate = 0;

		public static int frameRate = 0;

		public static bool RGBRelease = false;

		public static bool qRelease = false;

		public static bool netRelease = false;

		public static bool frameRelease = false;

		public static bool showFrameRate = false;

		public static int magmaBGFrame = 0;

		public static int magmaBGFrameCounter = 0;

		public static int saveTimer = 0;

		public static bool autoJoin = false;

		public static bool serverStarting = false;

		public static float leftWorld = 0f;

		public static float rightWorld = 134400f;

		public static float topWorld = 0f;

		public static float bottomWorld = 38400f;

		public static int maxTilesX = (int)Main.rightWorld / 16 + 1;

		public static int maxTilesY = (int)Main.bottomWorld / 16 + 1;

		public static int maxSectionsX = Main.maxTilesX / 200;

		public static int maxSectionsY = Main.maxTilesY / 150;

		public static int numDust = 2000;

		public static int maxNetPlayers = 255;

		public static string[] chrName = new string[147];

		public static int worldRate = 1;

		public static float caveParrallax = 1f;

		public static string[] tileName = new string[150];

		public static int dungeonX;

		public static int dungeonY;

		public static Liquid[] liquid = new Liquid[Liquid.resLiquid];

		public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];

		public static bool dedServ = false;

		public static int spamCount = 0;

		public static int curMusic = 0;

		public int newMusic;

		public static bool showItemText = true;

		public static bool autoSave = true;

		public static string buffString = "";

		public static string libPath = "";

		public static int lo = 0;

		public static int LogoA = 255;

		public static int LogoB = 0;

		public static bool LogoT = false;

		public static string statusText = "";

		public static string worldName = "";

		public static int worldID;

		public static int background = 0;

		public static Microsoft.Xna.Framework.Color tileColor;

		public static double worldSurface;

		public static double rockLayer;

		public static Microsoft.Xna.Framework.Color[] teamColor = new Microsoft.Xna.Framework.Color[5];

		public static bool dayTime = true;

		public static double time = 13500.0;

		public static int moonPhase = 0;

		public static short sunModY = 0;

		public static short moonModY = 0;

		public static bool grabSky = false;

		public static bool bloodMoon = false;

		public static int checkForSpawns = 0;

		public static int helpText = 0;

		public static bool autoGen = false;

		public static bool autoPause = false;

		public static int[] projFrames = new int[111];

		public static float demonTorch = 1f;

		public static int demonTorchDir = 1;

		public static int numStars;

		public static int cloudLimit = 100;

		public static int numClouds = Main.cloudLimit;

		public static float windSpeed = 0f;

		public static float windSpeedSpeed = 0f;

		public static Cloud[] cloud = new Cloud[100];

		public static bool resetClouds = true;

		public static int sandTiles;

		public static int evilTiles;

		public static int snowTiles;

		public static int holyTiles;

		public static int meteorTiles;

		public static int jungleTiles;

		public static int dungeonTiles;

		public static int fadeCounter = 0;

		public static float invAlpha = 1f;

		public static float invDir = 1f;

		[ThreadStatic]
		public static Random rand;

		public static Texture2D[] bannerTexture = new Texture2D[3];

		public static Texture2D[] npcHeadTexture = new Texture2D[12];

		public static Texture2D[] destTexture = new Texture2D[3];

		public static Texture2D[] wingsTexture = new Texture2D[3];

		public static Texture2D[] armorHeadTexture = new Texture2D[45];

		public static Texture2D[] armorBodyTexture = new Texture2D[26];

		public static Texture2D[] femaleBodyTexture = new Texture2D[26];

		public static Texture2D[] armorArmTexture = new Texture2D[26];

		public static Texture2D[] armorLegTexture = new Texture2D[25];

		public static Texture2D timerTexture;

		public static Texture2D reforgeTexture;

		public static Texture2D wallOutlineTexture;

		public static Texture2D wireTexture;

		public static Texture2D gridTexture;

		public static Texture2D lightDiscTexture;

		public static Texture2D MusicBoxTexture;

		public static Texture2D EyeLaserTexture;

		public static Texture2D BoneEyesTexture;

		public static Texture2D BoneLaserTexture;

		public static Texture2D trashTexture;

		public static Texture2D chainTexture;

		public static Texture2D probeTexture;

		public static Texture2D confuseTexture;

		public static Texture2D chain2Texture;

		public static Texture2D chain3Texture;

		public static Texture2D chain4Texture;

		public static Texture2D chain5Texture;

		public static Texture2D chain6Texture;

		public static Texture2D chain7Texture;

		public static Texture2D chain8Texture;

		public static Texture2D chain9Texture;

		public static Texture2D chain10Texture;

		public static Texture2D chain11Texture;

		public static Texture2D chain12Texture;

		public static Texture2D chaosTexture;

		public static Texture2D cdTexture;

		public static Texture2D wofTexture;

		public static Texture2D boneArmTexture;

		public static Texture2D boneArm2Texture;

		public static Texture2D[] npcToggleTexture = new Texture2D[2];

		public static Texture2D[] HBLockTexture = new Texture2D[2];

		public static Texture2D[] buffTexture = new Texture2D[40];

		public static Texture2D[] itemTexture = new Texture2D[603];

		public static Texture2D[] npcTexture = new Texture2D[147];

		public static Texture2D[] projectileTexture = new Texture2D[111];

		public static Texture2D[] goreTexture = new Texture2D[160];

		public static Texture2D cursorTexture;

		public static Texture2D dustTexture;

		public static Texture2D sunTexture;

		public static Texture2D sun2Texture;

		public static Texture2D moonTexture;

		public static Texture2D[] tileTexture = new Texture2D[150];

		public static Texture2D blackTileTexture;

		public static Texture2D[] wallTexture = new Texture2D[32];

		public static Texture2D[] backgroundTexture = new Texture2D[32];

		public static Texture2D[] cloudTexture = new Texture2D[4];

		public static Texture2D[] starTexture = new Texture2D[5];

		public static Texture2D[] liquidTexture = new Texture2D[2];

		public static Texture2D heartTexture;

		public static Texture2D manaTexture;

		public static Texture2D bubbleTexture;

		public static Texture2D[] treeTopTexture = new Texture2D[5];

		public static Texture2D shroomCapTexture;

		public static Texture2D[] treeBranchTexture = new Texture2D[5];

		public static Texture2D inventoryBackTexture;

		public static Texture2D inventoryBack2Texture;

		public static Texture2D inventoryBack3Texture;

		public static Texture2D inventoryBack4Texture;

		public static Texture2D inventoryBack5Texture;

		public static Texture2D inventoryBack6Texture;

		public static Texture2D inventoryBack7Texture;

		public static Texture2D inventoryBack8Texture;

		public static Texture2D inventoryBack9Texture;

		public static Texture2D inventoryBack10Texture;

		public static Texture2D inventoryBack11Texture;

		public static Texture2D[] loTexture = new Texture2D[6];

		public static Texture2D logoTexture;

		public static Texture2D logo2Texture;

		public static Texture2D logo3Texture;

		public static Texture2D textBackTexture;

		public static Texture2D chatTexture;

		public static Texture2D chat2Texture;

		public static Texture2D chatBackTexture;

		public static Texture2D teamTexture;

		public static Texture2D reTexture;

		public static Texture2D raTexture;

		public static Texture2D splashTexture;

		public static Texture2D fadeTexture;

		public static Texture2D ninjaTexture;

		public static Texture2D antLionTexture;

		public static Texture2D spikeBaseTexture;

		public static Texture2D ghostTexture;

		public static Texture2D evilCactusTexture;

		public static Texture2D goodCactusTexture;

		public static Texture2D wraithEyeTexture;

		public static Texture2D skinBodyTexture;

		public static Texture2D skinLegsTexture;

		public static Texture2D playerEyeWhitesTexture;

		public static Texture2D playerEyesTexture;

		public static Texture2D playerHandsTexture;

		public static Texture2D playerHands2Texture;

		public static Texture2D playerHeadTexture;

		public static Texture2D playerPantsTexture;

		public static Texture2D playerShirtTexture;

		public static Texture2D playerShoesTexture;

		public static Texture2D playerUnderShirtTexture;

		public static Texture2D playerUnderShirt2Texture;

		public static Texture2D femaleShirt2Texture;

		public static Texture2D femalePantsTexture;

		public static Texture2D femaleShirtTexture;

		public static Texture2D femaleShoesTexture;

		public static Texture2D femaleUnderShirtTexture;

		public static Texture2D femaleUnderShirt2Texture;

		public static Texture2D[] playerHairTexture = new Texture2D[36];

		public static Texture2D[] playerHairAltTexture = new Texture2D[36];

		public static SoundEffect[] soundMech = new SoundEffect[1];

		public static SoundEffectInstance[] soundInstanceMech = new SoundEffectInstance[1];

		public static SoundEffect[] soundDig = new SoundEffect[3];

		public static SoundEffectInstance[] soundInstanceDig = new SoundEffectInstance[3];

		public static SoundEffect[] soundTink = new SoundEffect[3];

		public static SoundEffectInstance[] soundInstanceTink = new SoundEffectInstance[3];

		public static SoundEffect[] soundPlayerHit = new SoundEffect[3];

		public static SoundEffectInstance[] soundInstancePlayerHit = new SoundEffectInstance[3];

		public static SoundEffect[] soundFemaleHit = new SoundEffect[3];

		public static SoundEffectInstance[] soundInstanceFemaleHit = new SoundEffectInstance[3];

		public static SoundEffect soundPlayerKilled;

		public static SoundEffectInstance soundInstancePlayerKilled;

		public static SoundEffect soundGrass;

		public static SoundEffectInstance soundInstanceGrass;

		public static SoundEffect soundGrab;

		public static SoundEffectInstance soundInstanceGrab;

		public static SoundEffect soundPixie;

		public static SoundEffectInstance soundInstancePixie;

		public static SoundEffect[] soundItem = new SoundEffect[38];

		public static SoundEffectInstance[] soundInstanceItem = new SoundEffectInstance[38];

		public static SoundEffect[] soundNPCHit = new SoundEffect[12];

		public static SoundEffectInstance[] soundInstanceNPCHit = new SoundEffectInstance[12];

		public static SoundEffect[] soundNPCKilled = new SoundEffect[16];

		public static SoundEffectInstance[] soundInstanceNPCKilled = new SoundEffectInstance[16];

		public static SoundEffect soundDoorOpen;

		public static SoundEffectInstance soundInstanceDoorOpen;

		public static SoundEffect soundDoorClosed;

		public static SoundEffectInstance soundInstanceDoorClosed;

		public static SoundEffect soundMenuOpen;

		public static SoundEffectInstance soundInstanceMenuOpen;

		public static SoundEffect soundMenuClose;

		public static SoundEffectInstance soundInstanceMenuClose;

		public static SoundEffect soundMenuTick;

		public static SoundEffectInstance soundInstanceMenuTick;

		public static SoundEffect soundShatter;

		public static SoundEffectInstance soundInstanceShatter;

		public static SoundEffect[] soundZombie = new SoundEffect[5];

		public static SoundEffectInstance[] soundInstanceZombie = new SoundEffectInstance[5];

		public static SoundEffect[] soundRoar = new SoundEffect[2];

		public static SoundEffectInstance[] soundInstanceRoar = new SoundEffectInstance[2];

		public static SoundEffect[] soundSplash = new SoundEffect[2];

		public static SoundEffectInstance[] soundInstanceSplash = new SoundEffectInstance[2];

		public static SoundEffect soundDoubleJump;

		public static SoundEffectInstance soundInstanceDoubleJump;

		public static SoundEffect soundRun;

		public static SoundEffectInstance soundInstanceRun;

		public static SoundEffect soundCoins;

		public static SoundEffectInstance soundInstanceCoins;

		public static SoundEffect soundUnlock;

		public static SoundEffectInstance soundInstanceUnlock;

		public static SoundEffect soundChat;

		public static SoundEffectInstance soundInstanceChat;

		public static SoundEffect soundMaxMana;

		public static SoundEffectInstance soundInstanceMaxMana;

		public static SoundEffect soundDrown;

		public static SoundEffectInstance soundInstanceDrown;

		public static AudioEngine engine;

		public static SoundBank soundBank;

		public static WaveBank waveBank;

		public static Cue[] music = new Cue[14];

		public static float[] musicFade = new float[14];

		public static float musicVolume = 0.75f;

		public static float soundVolume = 1f;

		public static SpriteFontX fontItemStack;

		public static SpriteFontX fontMouseText;

		public static SpriteFontX fontDeathText;

		public static SpriteFontX[] fontCombatText = new SpriteFontX[2];

		public static string fontMouseTextName = "黑体";

		public static string fontItemStackName = "仿宋体";

		public static string fontDeathTextName = "楷体";

		public static string fontCombatTextName = "黑体";

		public static bool[] tileLighted = new bool[150];

		public static bool[] tileMergeDirt = new bool[150];

		public static bool[] tileCut = new bool[150];

		public static bool[] tileAlch = new bool[150];

		public static int[] tileShine = new int[150];

		public static bool[] tileShine2 = new bool[150];

		public static bool[] wallHouse = new bool[32];

		public static int[] wallBlend = new int[32];

		public static bool[] tileStone = new bool[150];

		public static bool[] tilePick = new bool[150];

		public static bool[] tileAxe = new bool[150];

		public static bool[] tileHammer = new bool[150];

		public static bool[] tileWaterDeath = new bool[150];

		public static bool[] tileLavaDeath = new bool[150];

		public static bool[] tileTable = new bool[150];

		public static bool[] tileBlockLight = new bool[150];

		public static bool[] tileNoSunLight = new bool[150];

		public static bool[] tileDungeon = new bool[150];

		public static bool[] tileSolidTop = new bool[150];

		public static bool[] tileSolid = new bool[150];

		public static bool[] tileNoAttach = new bool[150];

		public static bool[] tileNoFail = new bool[150];

		public static bool[] tileFrameImportant = new bool[150];

		public static int[] backgroundWidth = new int[32];

		public static int[] backgroundHeight = new int[32];

		public static bool tilesLoaded = false;

		public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];

		public static Dust[] dust = new Dust[2001];

		public static Star[] star = new Star[130];

		public static Item[] item = new Item[201];

		public static NPC[] npc = new NPC[201];

		public static Gore[] gore = new Gore[201];

		public static Projectile[] projectile = new Projectile[1001];

		public static CombatText[] combatText = new CombatText[100];

		public static ItemText[] itemText = new ItemText[20];

		public static Chest[] chest = new Chest[1000];

		public static Sign[] sign = new Sign[1000];

		public static Vector2 screenPosition;

		public static Vector2 screenLastPosition;

		public static int screenWidth = 800;

		public static int screenHeight = 600;

		public static int chatLength = 600;

		public static bool chatMode = false;

		public static bool chatRelease = false;

		public static int numChatLines = 7;

		public static string chatText = "";

		public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];

		public static bool inputTextEnter = false;

		public static float[] hotbarScale = new float[]
		{
			1f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f
		};

		public static byte mouseTextColor = 0;

		public static int mouseTextColorChange = 1;

		public static bool mouseLeftRelease = false;

		public static bool mouseRightRelease = false;

		public static bool playerInventory = false;

		public static int stackSplit;

		public static int stackCounter = 0;

		public static int stackDelay = 7;

		public static Item mouseItem = new Item();

		public static Item guideItem = new Item();

		public static Item reforgeItem = new Item();

		private static float inventoryScale = 0.75f;

		public static bool hasFocus = true;

		public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];

		public static int[] availableRecipe = new int[Recipe.maxRecipes];

		public static float[] availableRecipeY = new float[Recipe.maxRecipes];

		public static int numAvailableRecipes;

		public static int focusRecipe;

		public static int myPlayer = 0;

		public static Player[] player = new Player[256];

		public static int spawnTileX;

		public static int spawnTileY;

		public static bool npcChatRelease = false;

		public static bool editSign = false;

		public static string signText = "";

		public static string npcChatText = "";

		public static bool npcChatFocus1 = false;

		public static bool npcChatFocus2 = false;

		public static bool npcChatFocus3 = false;

		public static int npcShop = 0;

		public Chest[] shop = new Chest[10];

		public static bool craftGuide = false;

		public static bool reforge = false;

		private static Item toolTip = new Item();

		private static int backSpaceCount = 0;

		public static string motd = "";

		public bool toggleFullscreen;

		private int numDisplayModes;

		private int[] displayWidth = new int[99];

		private int[] displayHeight = new int[99];

		public static bool gameMenu = true;

		public static Player[] loadPlayer = new Player[5];

		public static string[] loadPlayerPath = new string[5];

		private static int numLoadPlayers = 0;

		public static string playerPathName;

		public static string[] loadWorld = new string[999];

		public static string[] loadWorldPath = new string[999];

		private static int numLoadWorlds = 0;

		public static string worldPathName;

		public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\My Games\\Terraria";

		public static string WorldPath = Main.SavePath + "\\Worlds";

		public static string PlayerPath = Main.SavePath + "\\Players";

		public static string[] itemName = new string[603];

		public static string[] npcName = new string[147];

		private static KeyboardState inputText;

		private static KeyboardState oldInputText;

		public static int invasionType = 0;

		public static double invasionX = 0.0;

		public static int invasionSize = 0;

		public static int invasionDelay = 0;

		public static int invasionWarn = 0;

		public static int[] npcFrameCount = new int[]
		{
			1,
			2,
			2,
			3,
			6,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			16,
			14,
			16,
			14,
			15,
			16,
			2,
			10,
			1,
			16,
			16,
			16,
			3,
			1,
			15,
			3,
			1,
			3,
			1,
			1,
			16,
			16,
			1,
			1,
			1,
			3,
			3,
			15,
			3,
			7,
			7,
			4,
			5,
			5,
			5,
			3,
			3,
			16,
			6,
			3,
			6,
			6,
			2,
			5,
			3,
			2,
			7,
			7,
			4,
			2,
			8,
			1,
			5,
			1,
			2,
			4,
			16,
			5,
			4,
			4,
			15,
			15,
			15,
			15,
			2,
			4,
			6,
			6,
			18,
			16,
			1,
			1,
			1,
			1,
			1,
			1,
			4,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			5,
			6,
			7,
			16,
			1,
			1,
			16,
			16,
			12,
			20,
			21,
			1,
			2,
			2,
			3,
			6,
			1,
			1,
			1,
			15,
			4,
			11,
			1,
			14,
			6,
			6,
			3,
			1,
			2,
			2,
			1,
			3,
			4,
			1,
			2,
			1,
			4,
			2,
			1,
			15,
			3,
			16,
			4,
			5,
			7,
			3
		};

		private static bool mouseExit = false;

		private static float exitScale = 0.8f;

		private static bool mouseReforge = false;

		private static float reforgeScale = 0.8f;

		public static Player clientPlayer = new Player();

		public static string getIP = Main.defaultIP;

		public static string getPort = Convert.ToString(Netplay.serverPort);

		public static bool menuMultiplayer = false;

		public static bool menuServer = false;

		public static int netMode = 0;

		public static int timeOut = 120;

		public static int netPlayCounter;

		public static int lastNPCUpdate;

		public static int lastItemUpdate;

		public static int maxNPCUpdates = 5;

		public static int maxItemUpdates = 5;

		public static string cUp = "W";

		public static string cLeft = "A";

		public static string cDown = "S";

		public static string cRight = "D";

		public static string cJump = "Space";

		public static string cThrowItem = "T";

		public static string cInv = "Escape";

		public static string cHeal = "H";

		public static string cMana = "M";

		public static string cBuff = "B";

		public static string cHook = "E";

		public static string cTorch = "LeftShift";

		public static Microsoft.Xna.Framework.Color mouseColor = new Microsoft.Xna.Framework.Color(255, 50, 95);

		public static Microsoft.Xna.Framework.Color cursorColor = Microsoft.Xna.Framework.Color.White;

		public static int cursorColorDirection = 1;

		public static float cursorAlpha = 0f;

		public static float cursorScale = 0f;

		public static bool signBubble = false;

		public static int signX = 0;

		public static int signY = 0;

		public static bool hideUI = false;

		public static bool releaseUI = false;

		public static bool fixedTiming = false;

		private int splashCounter;

		public static string oldStatusText = "";

		public static bool autoShutdown = false;

		private float logoRotation;

		private float logoRotationDirection = 1f;

		private float logoRotationSpeed = 1f;

		private float logoScale = 1f;

		private float logoScaleDirection = 1f;

		private float logoScaleSpeed = 1f;

		private static int maxMenuItems = 14;

		private float[] menuItemScale = new float[Main.maxMenuItems];

		private int focusMenu = -1;

		private int selectedMenu = -1;

		private int selectedMenu2 = -1;

		private int selectedPlayer;

		private int selectedWorld;

		public static int menuMode = 0;

		private static Item cpItem = new Item();

		private int textBlinkerCount;

		private int textBlinkerState;

		public static string newWorldName = "";

		private static int accSlotCount = 0;

		private Microsoft.Xna.Framework.Color selColor = Microsoft.Xna.Framework.Color.White;

		private int focusColor;

		private int colorDelay;

		private int setKey = -1;

		private int bgScroll;

		public static bool autoPass = false;

		public static int menuFocus = 0;

		[DllImport("User32")]
		private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

		[DllImport("User32")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("User32")]
		private static extern int GetMenuItemCount(IntPtr hWnd);

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		public void EnablePNGMOD()
		{
			Main.isPNGMODOpen = true;
		}

		public static void LoadWorlds()
		{
			Directory.CreateDirectory(Main.WorldPath);
			string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
			int num = files.Length;
			if (!Main.dedServ && num > 5)
			{
				num = 5;
			}
			for (int i = 0; i < num; i++)
			{
				Main.loadWorldPath[i] = files[i];
				try
				{
					using (FileStream fileStream = new FileStream(Main.loadWorldPath[i], FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							Main.loadWorld[i] = binaryReader.ReadString();
							binaryReader.Close();
						}
					}
				}
				catch
				{
					Main.loadWorld[i] = Main.loadWorldPath[i];
				}
			}
			Main.numLoadWorlds = num;
		}

		public void LoadNewFonts(int num, string ChangeFont)
		{
			switch (num)
			{
			case 0:
				Main.fontItemStackName = ChangeFont;
				Main.fontMouseTextName = ChangeFont;
				Main.fontDeathTextName = ChangeFont;
				Main.fontCombatTextName = ChangeFont;
				break;
			case 1:
				Main.fontItemStackName = ChangeFont;
				break;
			case 2:
				Main.fontMouseTextName = ChangeFont;
				break;
			case 3:
				Main.fontDeathTextName = ChangeFont;
				break;
			case 4:
				Main.fontCombatTextName = ChangeFont;
				break;
			}
		}

		public void DisableChatForm()
		{
			Main.isChatFormOpen = true;
		}

		public void SetWindowPos(int num, int pos)
		{
			switch (num)
			{
			case 1:
				Main.SetWindowPos_X = pos;
				break;
			case 2:
				Main.SetWindowPos_Y = pos;
				break;
			}
		}

		public void DStoDSX(SpriteFontX spriteFont, string text, Vector2 position, Microsoft.Xna.Framework.Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		{
			try
			{
				Vector2 position2 = position;
				Vector2 vector = origin;
				position2.X -= vector.X;
				position2.Y -= vector.Y;
				this.spriteBatch.DrawStringX(spriteFont, text, position2, new Vector2(0f, 0f), new Vector2(scale, scale), color);
			}
			catch (Exception)
			{
			}
		}

		private static void LoadPlayers()
		{
			Directory.CreateDirectory(Main.PlayerPath);
			string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
			int num = files.Length;
			if (num > 5)
			{
				num = 5;
			}
			for (int i = 0; i < 5; i++)
			{
				Main.loadPlayer[i] = new Player();
				if (i < num)
				{
					Main.loadPlayerPath[i] = files[i];
					Main.loadPlayer[i] = Player.LoadPlayer(Main.loadPlayerPath[i]);
				}
			}
			Main.numLoadPlayers = num;
		}

		protected void OpenRecent()
		{
			try
			{
				if (File.Exists(Main.SavePath + "\\servers.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							for (int i = 0; i < 10; i++)
							{
								Main.recentWorld[i] = binaryReader.ReadString();
								Main.recentIP[i] = binaryReader.ReadString();
								Main.recentPort[i] = binaryReader.ReadInt32();
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		public static void SaveRecent()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + "\\servers.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						for (int i = 0; i < 10; i++)
						{
							binaryWriter.Write(Main.recentWorld[i]);
							binaryWriter.Write(Main.recentIP[i]);
							binaryWriter.Write(Main.recentPort[i]);
						}
					}
				}
			}
			catch
			{
			}
		}

		protected void SaveSettings()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + "\\config.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						binaryWriter.Write(this.graphics.IsFullScreen);
						binaryWriter.Write(Main.mouseColor.R);
						binaryWriter.Write(Main.mouseColor.G);
						binaryWriter.Write(Main.mouseColor.B);
						binaryWriter.Write(Main.soundVolume);
						binaryWriter.Write(Main.musicVolume);
						binaryWriter.Write(Main.cUp);
						binaryWriter.Write(Main.cDown);
						binaryWriter.Write(Main.cLeft);
						binaryWriter.Write(Main.cRight);
						binaryWriter.Write(Main.cJump);
						binaryWriter.Write(Main.cThrowItem);
						binaryWriter.Write(Main.cInv);
						binaryWriter.Write(Main.cHeal);
						binaryWriter.Write(Main.cMana);
						binaryWriter.Write(Main.cBuff);
						binaryWriter.Write(Main.cHook);
						binaryWriter.Write(Main.caveParrallax);
						binaryWriter.Write(Main.fixedTiming);
						binaryWriter.Write(this.graphics.PreferredBackBufferWidth);
						binaryWriter.Write(this.graphics.PreferredBackBufferHeight);
						binaryWriter.Write(Main.autoSave);
						binaryWriter.Write(Main.autoPause);
						binaryWriter.Write(Main.showItemText);
						binaryWriter.Write(Main.cTorch);
						binaryWriter.Write((byte)Lighting.lightMode);
						binaryWriter.Write((byte)Main.qaStyle);
						binaryWriter.Write(Main.owBack);
						binaryWriter.Close();
					}
				}
			}
			catch
			{
			}
		}

		protected void OpenSettings()
		{
			try
			{
				if (File.Exists(Main.SavePath + "\\config.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							bool flag = binaryReader.ReadBoolean();
							Main.mouseColor.R = binaryReader.ReadByte();
							Main.mouseColor.G = binaryReader.ReadByte();
							Main.mouseColor.B = binaryReader.ReadByte();
							Main.soundVolume = binaryReader.ReadSingle();
							Main.musicVolume = binaryReader.ReadSingle();
							Main.cUp = binaryReader.ReadString();
							Main.cDown = binaryReader.ReadString();
							Main.cLeft = binaryReader.ReadString();
							Main.cRight = binaryReader.ReadString();
							Main.cJump = binaryReader.ReadString();
							Main.cThrowItem = binaryReader.ReadString();
							if (num >= 1)
							{
								Main.cInv = binaryReader.ReadString();
							}
							if (num >= 12)
							{
								Main.cHeal = binaryReader.ReadString();
								Main.cMana = binaryReader.ReadString();
								Main.cBuff = binaryReader.ReadString();
							}
							if (num >= 13)
							{
								Main.cHook = binaryReader.ReadString();
							}
							Main.caveParrallax = binaryReader.ReadSingle();
							if (num >= 2)
							{
								Main.fixedTiming = binaryReader.ReadBoolean();
							}
							if (num >= 4)
							{
								this.graphics.PreferredBackBufferWidth = binaryReader.ReadInt32();
								this.graphics.PreferredBackBufferHeight = binaryReader.ReadInt32();
							}
							if (num >= 8)
							{
								Main.autoSave = binaryReader.ReadBoolean();
							}
							if (num >= 9)
							{
								Main.autoPause = binaryReader.ReadBoolean();
							}
							if (num >= 19)
							{
								Main.showItemText = binaryReader.ReadBoolean();
							}
							if (num >= 30)
							{
								Main.cTorch = binaryReader.ReadString();
								Lighting.lightMode = (int)binaryReader.ReadByte();
								Main.qaStyle = (int)binaryReader.ReadByte();
							}
							if (num >= 37)
							{
								Main.owBack = binaryReader.ReadBoolean();
							}
							binaryReader.Close();
							if (flag && !this.graphics.IsFullScreen)
							{
								this.graphics.ToggleFullScreen();
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		private static void ErasePlayer(int i)
		{
			try
			{
				File.Delete(Main.loadPlayerPath[i]);
				File.Delete(Main.loadPlayerPath[i] + ".bak");
				Main.LoadPlayers();
			}
			catch
			{
			}
		}

		private static void EraseWorld(int i)
		{
			try
			{
				File.Delete(Main.loadWorldPath[i]);
				File.Delete(Main.loadWorldPath[i] + ".bak");
				Main.LoadWorlds();
			}
			catch
			{
			}
		}

		private static string nextLoadPlayer()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.PlayerPath,
				"\\player",
				num,
				".plr"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.PlayerPath,
				"\\player",
				num,
				".plr"
			});
		}

		private static string nextLoadWorld()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.WorldPath,
				"\\world",
				num,
				".wld"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.WorldPath,
				"\\world",
				num,
				".wld"
			});
		}

		public void autoCreate(string newOpt)
		{
			if (newOpt == "0")
			{
				Main.autoGen = false;
			}
			else if (newOpt == "1")
			{
				Main.maxTilesX = 4200;
				Main.maxTilesY = 1200;
				Main.autoGen = true;
			}
			else if (newOpt == "2")
			{
				Main.maxTilesX = 6300;
				Main.maxTilesY = 1800;
				Main.autoGen = true;
			}
			else if (newOpt == "3")
			{
				Main.maxTilesX = 8400;
				Main.maxTilesY = 2400;
				Main.autoGen = true;
			}
		}

		public void NewMOTD(string newMOTD)
		{
			Main.motd = newMOTD;
		}

		public void LoadDedConfig(string configPath)
		{
			if (File.Exists(configPath))
			{
				using (StreamReader streamReader = new StreamReader(configPath))
				{
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						try
						{
							if (text.Length > 6 && text.Substring(0, 6).ToLower() == "world=")
							{
								string text2 = text.Substring(6);
								Main.worldPathName = text2;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "port=")
							{
								string value = text.Substring(5);
								try
								{
									int serverPort = Convert.ToInt32(value);
									Netplay.serverPort = serverPort;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "maxplayers=")
							{
								string value2 = text.Substring(11);
								try
								{
									int num = Convert.ToInt32(value2);
									Main.maxNetPlayers = num;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 9).ToLower() == "priority=")
							{
								string value3 = text.Substring(9);
								try
								{
									int num2 = Convert.ToInt32(value3);
									if (num2 >= 0 && num2 <= 5)
									{
										Process currentProcess = Process.GetCurrentProcess();
										if (num2 == 0)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
										}
										else if (num2 == 1)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.High;
										}
										else if (num2 == 2)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
										}
										else if (num2 == 3)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Normal;
										}
										else if (num2 == 4)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
										}
										else if (num2 == 5)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Idle;
										}
									}
								}
								catch
								{
								}
							}
							if (text.Length > 9 && text.Substring(0, 9).ToLower() == "password=")
							{
								string password = text.Substring(9);
								Netplay.password = password;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "motd=")
							{
								string text3 = text.Substring(5);
								Main.motd = text3;
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldpath=")
							{
								string worldPath = text.Substring(10);
								Main.WorldPath = worldPath;
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldname=")
							{
								string text4 = text.Substring(10);
								Main.worldName = text4;
							}
							if (text.Length > 8 && text.Substring(0, 8).ToLower() == "banlist=")
							{
								string banFile = text.Substring(8);
								Netplay.banFile = banFile;
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "autocreate=")
							{
								string a = text.Substring(11);
								if (a == "0")
								{
									Main.autoGen = false;
								}
								else if (a == "1")
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									Main.autoGen = true;
								}
								else if (a == "2")
								{
									Main.maxTilesX = 6300;
									Main.maxTilesY = 1800;
									Main.autoGen = true;
								}
								else if (a == "3")
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									Main.autoGen = true;
								}
							}
							if (text.Length > 7 && text.Substring(0, 7).ToLower() == "secure=")
							{
								string a2 = text.Substring(7);
								if (a2 == "1")
								{
									Netplay.spamCheck = true;
								}
							}
						}
						catch
						{
						}
					}
				}
			}
		}

		public void SetNetPlayers(int mPlayers)
		{
			Main.maxNetPlayers = mPlayers;
		}

		public void SetWorld(string wrold)
		{
			Main.worldPathName = wrold;
		}

		public void SetWorldName(string wrold)
		{
			Main.worldName = wrold;
		}

		public void autoShut()
		{
			Main.autoShutdown = true;
		}

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public void AutoPass()
		{
			Main.autoPass = true;
		}

		public void AutoJoin(string IP)
		{
			Main.defaultIP = IP;
			Main.getIP = IP;
			Netplay.SetIP(Main.defaultIP);
			Main.autoJoin = true;
		}

		public void AutoHost()
		{
			Main.menuMultiplayer = true;
			Main.menuServer = true;
			Main.menuMode = 1;
		}

		public void loadLib(string path)
		{
			Main.libPath = path;
			Main.LoadLibrary(Main.libPath);
		}

		public void DedServ()
		{
			Main.rand = new Random();
			if (Main.autoShutdown)
			{
				string text = "terraria" + Main.rand.Next(2147483647);
				Console.Title = text;
				IntPtr intPtr = Main.FindWindow(null, text);
				if (intPtr != IntPtr.Zero)
				{
					Main.ShowWindow(intPtr, 0);
				}
			}
			else
			{
				Console.Title = "Terraria 服务器 " + Main.versionNumber2;
			}
			Main.dedServ = true;
			Main.showSplash = false;
			this.Initialize();
			for (int i = 0; i < 147; i++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(i, -1f);
				Main.npcName[i] = nPC.name;
			}
			while (Main.worldPathName == null || Main.worldPathName == "")
			{
				Main.LoadWorlds();
				bool flag = true;
				while (flag)
				{
					Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
					Console.WriteLine("");
					for (int j = 0; j < Main.numLoadWorlds; j++)
					{
						Console.WriteLine(string.Concat(new object[]
						{
							j + 1,
							"  ....",
							'\t',
							"  ",
							Main.loadWorld[j]
						}));
					}
					Console.WriteLine(string.Concat(new object[]
					{
						"n",
						"  ....",
						'\t',
						"  ",
						"(建立新世界)"
					}));
					Console.WriteLine("d <编号>  (删除旧世界)");
					Console.WriteLine("");
					Console.Write("选择世界对应的编号: ");
					string text2 = Console.ReadLine();
					try
					{
						Console.Clear();
					}
					catch
					{
					}
					if (text2.Length >= 2 && text2.Substring(0, 2).ToLower() == "d ")
					{
						try
						{
							int num = Convert.ToInt32(text2.Substring(2)) - 1;
							if (num < Main.numLoadWorlds)
							{
								Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
								Console.WriteLine("");
								Console.WriteLine("真的要删除 < " + Main.loadWorld[num] + " > 吗?");
								Console.Write("(y/n): ");
								string text3 = Console.ReadLine();
								if (text3.ToLower() == "y")
								{
									Main.EraseWorld(num);
								}
							}
						}
						catch
						{
						}
						try
						{
							Console.Clear();
							continue;
						}
						catch
						{
							continue;
						}
					}
					if (text2 == "n" || text2 == "N")
					{
						bool flag2 = true;
						while (flag2)
						{
							Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
							Console.WriteLine("");
							Console.WriteLine("1" + '\t' + "小型");
							Console.WriteLine("2" + '\t' + "中型");
							Console.WriteLine("3" + '\t' + "大型");
							Console.WriteLine("");
							Console.Write("选择世界尺寸: ");
							string value = Console.ReadLine();
							try
							{
								int num2 = Convert.ToInt32(value);
								if (num2 == 1)
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									flag2 = false;
								}
								else if (num2 == 2)
								{
									Main.maxTilesX = 6300;
									Main.maxTilesY = 1800;
									flag2 = false;
								}
								else if (num2 == 3)
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									flag2 = false;
								}
							}
							catch
							{
							}
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
						flag2 = true;
						while (flag2)
						{
							Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
							Console.WriteLine("");
							Console.Write("输入新世界的名字: ");
							Main.newWorldName = Console.ReadLine();
							if (Main.newWorldName != "" && Main.newWorldName != " " && Main.newWorldName != null)
							{
								flag2 = false;
							}
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
						Main.worldName = Main.newWorldName;
						Main.worldPathName = Main.nextLoadWorld();
						Main.menuMode = 10;
						WorldGen.CreateNewWorld();
						flag2 = false;
						while (Main.menuMode == 10)
						{
							if (Main.oldStatusText != Main.statusText)
							{
								Main.oldStatusText = Main.statusText;
								Console.WriteLine(Main.statusText);
							}
						}
						try
						{
							Console.Clear();
							continue;
						}
						catch
						{
							continue;
						}
					}
					try
					{
						int num3 = Convert.ToInt32(text2);
						num3--;
						if (num3 >= 0 && num3 < Main.numLoadWorlds)
						{
							bool flag3 = true;
							while (flag3)
							{
								Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
								Console.WriteLine("");
								Console.Write("最大玩家数 (直接敲回车为默认8人): ");
								string text4 = Console.ReadLine();
								try
								{
									if (text4 == "")
									{
										text4 = "8";
									}
									int num4 = Convert.ToInt32(text4);
									if (num4 <= 255 && num4 >= 1)
									{
										Main.maxNetPlayers = num4;
										flag3 = false;
									}
									flag3 = false;
								}
								catch
								{
								}
								try
								{
									Console.Clear();
								}
								catch
								{
								}
							}
							flag3 = true;
							while (flag3)
							{
								Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
								Console.WriteLine("");
								Console.Write("服务器端口 (直接敲回车为默认7777): ");
								string text5 = Console.ReadLine();
								try
								{
									if (text5 == "")
									{
										text5 = "7777";
									}
									int num5 = Convert.ToInt32(text5);
									if (num5 <= 65535)
									{
										Netplay.serverPort = num5;
										flag3 = false;
									}
								}
								catch
								{
								}
								try
								{
									Console.Clear();
								}
								catch
								{
								}
							}
							Console.WriteLine("Terraria 服务器 " + Main.versionNumber2);
							Console.WriteLine("");
							Console.Write("服务器密码 (直接敲回车为空): ");
							Netplay.password = Console.ReadLine();
							Main.worldPathName = Main.loadWorldPath[num3];
							flag = false;
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
					}
					catch
					{
					}
				}
			}
			try
			{
				Console.Clear();
			}
			catch
			{
			}
			WorldGen.serverLoadWorld();
			Console.WriteLine("Terraria 服务器 " + Main.versionNumber);
			Console.WriteLine("");
			while (!Netplay.ServerUp)
			{
				if (Main.oldStatusText != Main.statusText)
				{
					Main.oldStatusText = Main.statusText;
					Console.WriteLine(Main.statusText);
				}
			}
			try
			{
				Console.Clear();
			}
			catch
			{
			}
			Console.WriteLine("Terraria 服务器 " + Main.versionNumber);
			Console.WriteLine("");
			Console.WriteLine("当前端口: " + Netplay.serverPort);
			Console.WriteLine("输入 help 查看可用的服务器端命令");
			Console.WriteLine("注意：不输入exit命令直接关闭服务器将可能导致回档!");
			Console.WriteLine("");
			Console.Title = "Terraria 服务器: " + Main.worldName;
			Stopwatch stopwatch = new Stopwatch();
			if (!Main.autoShutdown)
			{
				Main.startDedInput();
			}
			stopwatch.Start();
			double num6 = 16.666666666666668;
			double num7 = 0.0;
			int num8 = 0;
			Stopwatch stopwatch2 = new Stopwatch();
			stopwatch2.Start();
			while (!Netplay.disconnect)
			{
				double num9 = (double)stopwatch.ElapsedMilliseconds;
				if (num9 + num7 >= num6)
				{
					num8++;
					num7 += num9 - num6;
					stopwatch.Reset();
					stopwatch.Start();
					if (Main.oldStatusText != Main.statusText)
					{
						Main.oldStatusText = Main.statusText;
						Console.WriteLine(Main.statusText);
					}
					if (num7 > 1000.0)
					{
						num7 = 1000.0;
					}
					if (Netplay.anyClients)
					{
						this.Update(new GameTime());
					}
					double num10 = (double)stopwatch.ElapsedMilliseconds + num7;
					if (num10 < num6)
					{
						int num11 = (int)(num6 - num10) - 1;
						if (num11 > 1)
						{
							Thread.Sleep(num11);
							if (!Netplay.anyClients)
							{
								num7 = 0.0;
								Thread.Sleep(10);
							}
						}
					}
				}
				Thread.Sleep(0);
			}
		}

		public static void startDedInput()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
		}

		public static void startDedInputCallBack(object threadContext)
		{
			while (!Netplay.disconnect)
			{
				Console.Write(": ");
				string text = Console.ReadLine();
				string text2 = text;
				text = text.ToLower();
				try
				{
					if (text == "help")
					{
						Console.WriteLine("可用命令:");
						Console.WriteLine("");
						Console.WriteLine(string.Concat(new object[]
						{
							"help ",
							'\t',
							'\t',
							" 可用命令清单"
						}));
						Console.WriteLine("playing " + '\t' + " 显示当前在线人数");
						Console.WriteLine(string.Concat(new object[]
						{
							"clear ",
							'\t',
							'\t',
							" 控制台窗口清屏"
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"exit ",
							'\t',
							'\t',
							" 存档并退出"
						}));
						Console.WriteLine("exit-nosave " + '\t' + " 直接退出(等同于点右上角的叉)");
						Console.WriteLine(string.Concat(new object[]
						{
							"save ",
							'\t',
							'\t',
							" 保存世界数据(不退出)"
						}));
						Console.WriteLine("kick <玩家名> " + '\t' + " 踢掉指定玩家");
						Console.WriteLine("ban <玩家名> " + '\t' + " Ban掉指定玩家");
						Console.WriteLine("password" + '\t' + " 显示服务器密码");
						Console.WriteLine("password<新密码>" + '\t' + " 修改密码");
						Console.WriteLine(string.Concat(new object[]
						{
							"version",
							'\t',
							'\t',
							" 显示当前版本"
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"time",
							'\t',
							'\t',
							" 显示当前游戏内的时间"
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"port",
							'\t',
							'\t',
							" 显示服务端口"
						}));
						Console.WriteLine("maxplayers" + '\t' + " 显示允许的最大玩家数");
						Console.WriteLine("say <要说的话>" + '\t' + " 广播");
						Console.WriteLine(string.Concat(new object[]
						{
							"motd",
							'\t',
							'\t',
							" 显示欢迎信息"
						}));
						Console.WriteLine("motd <新欢迎词>" + '\t' + " 修改欢迎信息");
						Console.WriteLine(string.Concat(new object[]
						{
							"dawn",
							'\t',
							'\t',
							" 修改游戏内的时间为清晨"
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"noon",
							'\t',
							'\t',
							" 修改游戏内的时间为正午"
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"dusk",
							'\t',
							'\t',
							" 修改游戏内的时间为黄昏"
						}));
						Console.WriteLine("midnight" + '\t' + " 修改游戏内的时间为午夜");
						Console.WriteLine(string.Concat(new object[]
						{
							"settle",
							'\t',
							'\t',
							" 稳定游戏内的水平面"
						}));
					}
					else if (text == "settle")
					{
						if (!Liquid.panicMode)
						{
							Liquid.StartPanic();
						}
						else
						{
							Console.WriteLine("水平面已稳定");
						}
					}
					else if (text == "dawn")
					{
						Main.dayTime = true;
						Main.time = 0.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "dusk")
					{
						Main.dayTime = false;
						Main.time = 0.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "noon")
					{
						Main.dayTime = true;
						Main.time = 27000.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "midnight")
					{
						Main.dayTime = false;
						Main.time = 16200.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "exit-nosave")
					{
						Netplay.disconnect = true;
					}
					else if (text == "exit")
					{
						WorldGen.saveWorld(false);
						Netplay.disconnect = true;
					}
					else if (text == "save")
					{
						WorldGen.saveWorld(false);
					}
					else if (text == "time")
					{
						string text3 = "AM";
						double num = Main.time;
						if (!Main.dayTime)
						{
							num += 54000.0;
						}
						num = num / 86400.0 * 24.0;
						double num2 = 7.5;
						num = num - num2 - 12.0;
						if (num < 0.0)
						{
							num += 24.0;
						}
						if (num >= 12.0)
						{
							text3 = "PM";
						}
						int num3 = (int)num;
						double num4 = num - (double)num3;
						num4 = (double)((int)(num4 * 60.0));
						string text4 = string.Concat(num4);
						if (num4 < 10.0)
						{
							text4 = "0" + text4;
						}
						if (num3 > 12)
						{
							num3 -= 12;
						}
						if (num3 == 0)
						{
							num3 = 12;
						}
						Console.WriteLine(string.Concat(new object[]
						{
							"时间: ",
							num3,
							":",
							text4,
							" ",
							text3
						}));
					}
					else if (text == "maxplayers")
					{
						Console.WriteLine("允许的最大玩家数: " + Main.maxNetPlayers);
					}
					else if (text == "port")
					{
						Console.WriteLine("当前端口: " + Netplay.serverPort);
					}
					else if (text == "version")
					{
						Console.WriteLine("Terraria 服务器 " + Main.versionNumber);
					}
					else
					{
						if (text == "clear")
						{
							try
							{
								Console.Clear();
								continue;
							}
							catch
							{
								continue;
							}
						}
						if (text == "playing")
						{
							int num5 = 0;
							for (int i = 0; i < 255; i++)
							{
								if (Main.player[i].active)
								{
									num5++;
									Console.WriteLine(string.Concat(new object[]
									{
										Main.player[i].name,
										" (",
										Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint,
										")"
									}));
								}
							}
							if (num5 == 0)
							{
								Console.WriteLine("当前没有玩家连接。");
							}
							else if (num5 == 1)
							{
								Console.WriteLine("1 位玩家已连接。");
							}
							else
							{
								Console.WriteLine(num5 + " 位玩家已连接。");
							}
						}
						else if (!(text == ""))
						{
							if (text == "motd")
							{
								if (Main.motd == "")
								{
									Console.WriteLine("欢迎来到 " + Main.worldName + "!");
								}
								else
								{
									Console.WriteLine("MOTD: " + Main.motd);
								}
							}
							else if (text.Length >= 5 && text.Substring(0, 5) == "motd ")
							{
								string text5 = text2.Substring(5);
								Main.motd = text5;
							}
							else if (text.Length == 8 && text.Substring(0, 8) == "password")
							{
								if (Netplay.password == "")
								{
									Console.WriteLine("没有密码。");
								}
								else
								{
									Console.WriteLine("密码为: " + Netplay.password);
								}
							}
							else if (text.Length >= 9 && text.Substring(0, 9) == "password ")
							{
								string text6 = text2.Substring(9);
								if (text6 == "")
								{
									Netplay.password = "";
									Console.WriteLine("密码已取消。");
								}
								else
								{
									Netplay.password = text6;
									Console.WriteLine("密码修改为: " + Netplay.password);
								}
							}
							else if (text == "say")
							{
								Console.WriteLine("命令格式: say(空格)要说的话");
							}
							else if (text.Length >= 4 && text.Substring(0, 4) == "say ")
							{
								string text7 = text2.Substring(4);
								if (text7 == "")
								{
									Console.WriteLine("命令格式: say(空格)要说的话");
								}
								else
								{
									Console.WriteLine("<服务器> " + text7);
									NetMessage.SendData(25, -1, -1, "<服务器> " + text7, 255, 255f, 240f, 20f, 0);
								}
							}
							else if (text.Length == 4 && text.Substring(0, 4) == "kick")
							{
								Console.WriteLine("命令格式: kick(空格)玩家名");
							}
							else if (text.Length >= 5 && text.Substring(0, 5) == "kick ")
							{
								string text8 = text.Substring(5);
								text8 = text8.ToLower();
								if (text8 == "")
								{
									Console.WriteLine("命令格式: kick(空格)玩家名");
								}
								else
								{
									for (int j = 0; j < 255; j++)
									{
										if (Main.player[j].active && Main.player[j].name.ToLower() == text8)
										{
											NetMessage.SendData(2, j, -1, "已被踢除。", 0, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else if (text.Length == 3 && text.Substring(0, 3) == "ban")
							{
								Console.WriteLine("命令格式: ban(空格)玩家名");
							}
							else if (text.Length >= 4 && text.Substring(0, 4) == "ban ")
							{
								string text9 = text.Substring(4);
								text9 = text9.ToLower();
								if (text9 == "")
								{
									Console.WriteLine("命令格式: ban(空格)玩家名");
								}
								else
								{
									for (int k = 0; k < 255; k++)
									{
										if (Main.player[k].active && Main.player[k].name.ToLower() == text9)
										{
											Netplay.AddBan(k);
											NetMessage.SendData(2, k, -1, "已放入黑名单。", 0, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else
							{
								Console.WriteLine("无效命令");
							}
						}
					}
				}
				catch
				{
					Console.WriteLine("无效命令。");
				}
			}
		}

		public Main()
		{
			this.graphics = new GraphicsDeviceManager(this);
			base.Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			NPC.clrNames();
			NPC.setNames();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			for (int i = 0; i < 111; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[72] = 4;
			Main.projFrames[86] = 4;
			Main.projFrames[87] = 4;
			Main.projFrames[102] = 2;
			Main.debuff[20] = true;
			Main.debuff[21] = true;
			Main.debuff[22] = true;
			Main.debuff[23] = true;
			Main.debuff[24] = true;
			Main.debuff[25] = true;
			Main.debuff[28] = true;
			Main.debuff[30] = true;
			Main.debuff[31] = true;
			Main.debuff[32] = true;
			Main.debuff[33] = true;
			Main.debuff[34] = true;
			Main.debuff[35] = true;
			Main.debuff[36] = true;
			Main.debuff[37] = true;
			Main.debuff[38] = true;
			Main.debuff[39] = true;
			Main.buffName[1] = "黑曜石皮肤";
			Main.buffTip[1] = "免疫岩浆伤害";
			Main.buffName[2] = "再生";
			Main.buffTip[2] = "生命缓慢回复";
			Main.buffName[3] = "迅捷";
			Main.buffTip[3] = "增加25%移动速度";
			Main.buffName[4] = "鱼鳃";
			Main.buffTip[4] = "使你可以像鱼一样呼吸";
			Main.buffName[5] = "硬化皮肤";
			Main.buffTip[5] = "增加8点防御力";
			Main.buffName[6] = "灵感";
			Main.buffTip[6] = "魔力缓慢回复";
			Main.buffName[7] = "魔能";
			Main.buffTip[7] = "增加20%魔法伤害";
			Main.buffName[8] = "羽落";
			Main.buffTip[8] = "使用上、下方向键来改变降落速度";
			Main.buffName[9] = "探查";
			Main.buffTip[9] = "标示出矿物与宝物位置";
			Main.buffName[10] = "隐身";
			Main.buffTip[10] = "隐匿身形";
			Main.buffName[11] = "光芒四射";
			Main.buffTip[11] = "散发光亮";
			Main.buffName[12] = "夜视";
			Main.buffTip[12] = "弱效夜视能力，增强光源效果";
			Main.buffName[13] = "争战";
			Main.buffTip[13] = "增加怪物刷新速率";
			Main.buffName[14] = "荆棘";
			Main.buffTip[14] = "反弹伤害";
			Main.buffName[15] = "水上行走";
			Main.buffTip[15] = "方向键下可进入水体";
			Main.buffName[16] = "箭术";
			Main.buffTip[16] = "增加20%箭矢伤害和飞行速度";
			Main.buffName[17] = "猎手";
			Main.buffTip[17] = "标示怪物位置";
			Main.buffName[18] = "重力控制";
			Main.buffTip[18] = "上下键控制重力方向";
			Main.buffName[19] = "光球";
			Main.buffTip[19] = "提供光源的魔法光球";
			Main.buffName[20] = "中毒";
			Main.buffTip[20] = "缓慢损失生命";
			Main.buffName[21] = "耐药性";
			Main.buffTip[21] = "无法吸收治疗药剂";
			Main.buffName[22] = "黑暗";
			Main.buffTip[22] = "降低光源效果";
			Main.buffName[23] = "诅咒";
			Main.buffTip[23] = "无法使用道具";
			Main.buffName[24] = "燃烧";
			Main.buffTip[24] = "缓慢损失生命";
			Main.buffName[25] = "嗝～～～";
			Main.buffTip[25] = "增加近战能力，降低防御能力";
			Main.buffName[26] = "饱腹";
			Main.buffTip[26] = "所有属性略微提升";
			Main.buffName[27] = "妖精契约";
			Main.buffTip[27] = "一只小妖精跟随着你";
			Main.buffName[28] = "狼人";
			Main.buffTip[28] = "物理伤害提升";
			Main.buffName[29] = "洞察";
			Main.buffTip[29] = "魔法伤害提升";
			Main.buffName[30] = "流血";
			Main.buffTip[30] = "生命停止回复";
			Main.buffName[31] = "混乱";
			Main.buffTip[31] = "移动方向颠倒";
			Main.buffName[32] = "迟缓";
			Main.buffTip[32] = "移动速度降低";
			Main.buffName[33] = "虚弱";
			Main.buffTip[33] = "物理伤害降低";
			Main.buffName[34] = "鱼人";
			Main.buffTip[34] = "水下自由呼吸和移动";
			Main.buffName[35] = "沉默";
			Main.buffTip[35] = "无法使用魔法道具";
			Main.buffName[36] = "护甲碎裂";
			Main.buffTip[36] = "防御减半";
			Main.buffName[37] = "惊恐";
			Main.buffTip[37] = "你亲眼目睹了令人作呕的怪物，已经没有回头路了！";
			Main.buffName[38] = "恶心的舌头";
			Main.buffTip[38] = "你正被舌头扯进怪物嘴里！";
			Main.buffName[39] = "诅咒魔焰";
			Main.buffTip[39] = "不断损失生命";
			for (int j = 0; j < 10; j++)
			{
				Main.recentWorld[j] = "";
				Main.recentIP[j] = "";
				Main.recentPort[j] = 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			int num = Main.rand.Next(15);
			if (num == 0)
			{
				base.Window.Title = "Terraria: 苦工们，快挖！";
			}
			else if (num == 1)
			{
				base.Window.Title = "Terraria: 史诗般的泥土";
			}
			else if (num == 2)
			{
				base.Window.Title = "Terraria: 哟～大家好！";
			}
			else if (num == 3)
			{
				base.Window.Title = "Terraria: 过于强大的沙子";
			}
			else if (num == 4)
			{
				base.Window.Title = "Terraria Part 3: 向导的回归";
			}
			else if (num == 5)
			{
				base.Window.Title = "Terraria: 小白兔和100个小馒头";
			}
			else if (num == 6)
			{
				base.Window.Title = "Terraria: 骸骨博士和血月神庙";
			}
			else if (num == 7)
			{
				base.Window.Title = "Terraria: 史莱姆公园";
			}
			else if (num == 8)
			{
				base.Window.Title = "Terraria: 风景这边独好";
			}
			else if (num == 9)
			{
				base.Window.Title = "Terraria: 游戏包含小砖块，5岁以下儿童请勿吞食";
			}
			else if (num == 10)
			{
				base.Window.Title = "Terraria: 打砖块的加强版";
			}
			else if (num == 11)
			{
				base.Window.Title = "Terraria: 这里没有奶牛关";
			}
			else if (num == 12)
			{
				base.Window.Title = "Terraria: 可疑的眼球";
			}
			else if (num == 13)
			{
				base.Window.Title = "Terraria: 紫色草地！";
			}
			else if (num == 14)
			{
				base.Window.Title = "Terraria: 一个矿工也不能少！";
			}
			else
			{
				base.Window.Title = "Terraria: 我的世界--外传";
			}
			Main.lo = Main.rand.Next(6);
			Main.tileShine2[6] = true;
			Main.tileShine2[7] = true;
			Main.tileShine2[8] = true;
			Main.tileShine2[9] = true;
			Main.tileShine2[12] = true;
			Main.tileShine2[21] = true;
			Main.tileShine2[22] = true;
			Main.tileShine2[25] = true;
			Main.tileShine2[45] = true;
			Main.tileShine2[46] = true;
			Main.tileShine2[47] = true;
			Main.tileShine2[63] = true;
			Main.tileShine2[64] = true;
			Main.tileShine2[65] = true;
			Main.tileShine2[66] = true;
			Main.tileShine2[67] = true;
			Main.tileShine2[68] = true;
			Main.tileShine2[107] = true;
			Main.tileShine2[108] = true;
			Main.tileShine2[111] = true;
			Main.tileShine2[121] = true;
			Main.tileShine2[122] = true;
			Main.tileShine2[117] = true;
			Main.tileShine[129] = 300;
			Main.tileHammer[141] = true;
			Main.tileHammer[4] = true;
			Main.tileHammer[10] = true;
			Main.tileHammer[11] = true;
			Main.tileHammer[12] = true;
			Main.tileHammer[13] = true;
			Main.tileHammer[14] = true;
			Main.tileHammer[15] = true;
			Main.tileHammer[16] = true;
			Main.tileHammer[17] = true;
			Main.tileHammer[18] = true;
			Main.tileHammer[19] = true;
			Main.tileHammer[21] = true;
			Main.tileHammer[26] = true;
			Main.tileHammer[28] = true;
			Main.tileHammer[29] = true;
			Main.tileHammer[31] = true;
			Main.tileHammer[33] = true;
			Main.tileHammer[34] = true;
			Main.tileHammer[35] = true;
			Main.tileHammer[36] = true;
			Main.tileHammer[42] = true;
			Main.tileHammer[48] = true;
			Main.tileHammer[49] = true;
			Main.tileHammer[50] = true;
			Main.tileHammer[54] = true;
			Main.tileHammer[55] = true;
			Main.tileHammer[77] = true;
			Main.tileHammer[78] = true;
			Main.tileHammer[79] = true;
			Main.tileHammer[81] = true;
			Main.tileHammer[85] = true;
			Main.tileHammer[86] = true;
			Main.tileHammer[87] = true;
			Main.tileHammer[88] = true;
			Main.tileHammer[89] = true;
			Main.tileHammer[90] = true;
			Main.tileHammer[91] = true;
			Main.tileHammer[92] = true;
			Main.tileHammer[93] = true;
			Main.tileHammer[94] = true;
			Main.tileHammer[95] = true;
			Main.tileHammer[96] = true;
			Main.tileHammer[97] = true;
			Main.tileHammer[98] = true;
			Main.tileHammer[99] = true;
			Main.tileHammer[100] = true;
			Main.tileHammer[101] = true;
			Main.tileHammer[102] = true;
			Main.tileHammer[103] = true;
			Main.tileHammer[104] = true;
			Main.tileHammer[105] = true;
			Main.tileHammer[106] = true;
			Main.tileHammer[114] = true;
			Main.tileHammer[125] = true;
			Main.tileHammer[126] = true;
			Main.tileHammer[128] = true;
			Main.tileHammer[129] = true;
			Main.tileHammer[132] = true;
			Main.tileHammer[133] = true;
			Main.tileHammer[134] = true;
			Main.tileHammer[135] = true;
			Main.tileHammer[136] = true;
			Main.tileFrameImportant[139] = true;
			Main.tileHammer[139] = true;
			Main.tileLighted[149] = true;
			Main.tileFrameImportant[149] = true;
			Main.tileHammer[149] = true;
			Main.tileFrameImportant[142] = true;
			Main.tileHammer[142] = true;
			Main.tileFrameImportant[143] = true;
			Main.tileHammer[143] = true;
			Main.tileFrameImportant[144] = true;
			Main.tileHammer[144] = true;
			Main.tileStone[131] = true;
			Main.tileFrameImportant[136] = true;
			Main.tileFrameImportant[137] = true;
			Main.tileFrameImportant[138] = true;
			Main.tileBlockLight[137] = true;
			Main.tileSolid[137] = true;
			Main.tileBlockLight[145] = true;
			Main.tileSolid[145] = true;
			Main.tileMergeDirt[145] = true;
			Main.tileBlockLight[146] = true;
			Main.tileSolid[146] = true;
			Main.tileMergeDirt[146] = true;
			Main.tileBlockLight[147] = true;
			Main.tileSolid[147] = true;
			Main.tileMergeDirt[147] = true;
			Main.tileBlockLight[148] = true;
			Main.tileSolid[148] = true;
			Main.tileMergeDirt[148] = true;
			Main.tileBlockLight[138] = true;
			Main.tileSolid[138] = true;
			Main.tileBlockLight[140] = true;
			Main.tileSolid[140] = true;
			Main.tileAxe[5] = true;
			Main.tileAxe[30] = true;
			Main.tileAxe[72] = true;
			Main.tileAxe[80] = true;
			Main.tileAxe[124] = true;
			Main.tileShine[22] = 1150;
			Main.tileShine[6] = 1150;
			Main.tileShine[7] = 1100;
			Main.tileShine[8] = 1000;
			Main.tileShine[9] = 1050;
			Main.tileShine[12] = 1000;
			Main.tileShine[21] = 1200;
			Main.tileShine[63] = 900;
			Main.tileShine[64] = 900;
			Main.tileShine[65] = 900;
			Main.tileShine[66] = 900;
			Main.tileShine[67] = 900;
			Main.tileShine[68] = 900;
			Main.tileShine[45] = 1900;
			Main.tileShine[46] = 2000;
			Main.tileShine[47] = 2100;
			Main.tileShine[122] = 1800;
			Main.tileShine[121] = 1850;
			Main.tileShine[125] = 600;
			Main.tileShine[109] = 9000;
			Main.tileShine[110] = 9000;
			Main.tileShine[116] = 9000;
			Main.tileShine[117] = 9000;
			Main.tileShine[118] = 8000;
			Main.tileShine[107] = 950;
			Main.tileShine[108] = 900;
			Main.tileShine[111] = 850;
			Main.tileLighted[4] = true;
			Main.tileLighted[17] = true;
			Main.tileLighted[133] = true;
			Main.tileLighted[31] = true;
			Main.tileLighted[33] = true;
			Main.tileLighted[34] = true;
			Main.tileLighted[35] = true;
			Main.tileLighted[36] = true;
			Main.tileLighted[37] = true;
			Main.tileLighted[42] = true;
			Main.tileLighted[49] = true;
			Main.tileLighted[58] = true;
			Main.tileLighted[61] = true;
			Main.tileLighted[70] = true;
			Main.tileLighted[71] = true;
			Main.tileLighted[72] = true;
			Main.tileLighted[76] = true;
			Main.tileLighted[77] = true;
			Main.tileLighted[19] = true;
			Main.tileLighted[22] = true;
			Main.tileLighted[26] = true;
			Main.tileLighted[83] = true;
			Main.tileLighted[84] = true;
			Main.tileLighted[92] = true;
			Main.tileLighted[93] = true;
			Main.tileLighted[95] = true;
			Main.tileLighted[98] = true;
			Main.tileLighted[100] = true;
			Main.tileLighted[109] = true;
			Main.tileLighted[125] = true;
			Main.tileLighted[126] = true;
			Main.tileLighted[129] = true;
			Main.tileLighted[140] = true;
			Main.tileMergeDirt[1] = true;
			Main.tileMergeDirt[6] = true;
			Main.tileMergeDirt[7] = true;
			Main.tileMergeDirt[8] = true;
			Main.tileMergeDirt[9] = true;
			Main.tileMergeDirt[22] = true;
			Main.tileMergeDirt[25] = true;
			Main.tileMergeDirt[30] = true;
			Main.tileMergeDirt[37] = true;
			Main.tileMergeDirt[38] = true;
			Main.tileMergeDirt[40] = true;
			Main.tileMergeDirt[53] = true;
			Main.tileMergeDirt[56] = true;
			Main.tileMergeDirt[107] = true;
			Main.tileMergeDirt[108] = true;
			Main.tileMergeDirt[111] = true;
			Main.tileMergeDirt[112] = true;
			Main.tileMergeDirt[116] = true;
			Main.tileMergeDirt[117] = true;
			Main.tileMergeDirt[123] = true;
			Main.tileMergeDirt[140] = true;
			Main.tileMergeDirt[39] = true;
			Main.tileMergeDirt[122] = true;
			Main.tileMergeDirt[121] = true;
			Main.tileMergeDirt[120] = true;
			Main.tileMergeDirt[119] = true;
			Main.tileMergeDirt[118] = true;
			Main.tileMergeDirt[47] = true;
			Main.tileMergeDirt[46] = true;
			Main.tileMergeDirt[45] = true;
			Main.tileMergeDirt[44] = true;
			Main.tileMergeDirt[43] = true;
			Main.tileMergeDirt[41] = true;
			Main.tileFrameImportant[3] = true;
			Main.tileFrameImportant[4] = true;
			Main.tileFrameImportant[5] = true;
			Main.tileFrameImportant[10] = true;
			Main.tileFrameImportant[11] = true;
			Main.tileFrameImportant[12] = true;
			Main.tileFrameImportant[13] = true;
			Main.tileFrameImportant[14] = true;
			Main.tileFrameImportant[15] = true;
			Main.tileFrameImportant[16] = true;
			Main.tileFrameImportant[17] = true;
			Main.tileFrameImportant[18] = true;
			Main.tileFrameImportant[20] = true;
			Main.tileFrameImportant[21] = true;
			Main.tileFrameImportant[24] = true;
			Main.tileFrameImportant[26] = true;
			Main.tileFrameImportant[27] = true;
			Main.tileFrameImportant[28] = true;
			Main.tileFrameImportant[29] = true;
			Main.tileFrameImportant[31] = true;
			Main.tileFrameImportant[33] = true;
			Main.tileFrameImportant[34] = true;
			Main.tileFrameImportant[35] = true;
			Main.tileFrameImportant[36] = true;
			Main.tileFrameImportant[42] = true;
			Main.tileFrameImportant[50] = true;
			Main.tileFrameImportant[55] = true;
			Main.tileFrameImportant[61] = true;
			Main.tileFrameImportant[71] = true;
			Main.tileFrameImportant[72] = true;
			Main.tileFrameImportant[73] = true;
			Main.tileFrameImportant[74] = true;
			Main.tileFrameImportant[77] = true;
			Main.tileFrameImportant[78] = true;
			Main.tileFrameImportant[79] = true;
			Main.tileFrameImportant[81] = true;
			Main.tileFrameImportant[82] = true;
			Main.tileFrameImportant[83] = true;
			Main.tileFrameImportant[84] = true;
			Main.tileFrameImportant[85] = true;
			Main.tileFrameImportant[86] = true;
			Main.tileFrameImportant[87] = true;
			Main.tileFrameImportant[88] = true;
			Main.tileFrameImportant[89] = true;
			Main.tileFrameImportant[90] = true;
			Main.tileFrameImportant[91] = true;
			Main.tileFrameImportant[92] = true;
			Main.tileFrameImportant[93] = true;
			Main.tileFrameImportant[94] = true;
			Main.tileFrameImportant[95] = true;
			Main.tileFrameImportant[96] = true;
			Main.tileFrameImportant[97] = true;
			Main.tileFrameImportant[98] = true;
			Main.tileFrameImportant[99] = true;
			Main.tileFrameImportant[101] = true;
			Main.tileFrameImportant[102] = true;
			Main.tileFrameImportant[103] = true;
			Main.tileFrameImportant[104] = true;
			Main.tileFrameImportant[105] = true;
			Main.tileFrameImportant[100] = true;
			Main.tileFrameImportant[106] = true;
			Main.tileFrameImportant[110] = true;
			Main.tileFrameImportant[113] = true;
			Main.tileFrameImportant[114] = true;
			Main.tileFrameImportant[125] = true;
			Main.tileFrameImportant[126] = true;
			Main.tileFrameImportant[128] = true;
			Main.tileFrameImportant[129] = true;
			Main.tileFrameImportant[132] = true;
			Main.tileFrameImportant[133] = true;
			Main.tileFrameImportant[134] = true;
			Main.tileFrameImportant[135] = true;
			Main.tileFrameImportant[141] = true;
			Main.tileCut[3] = true;
			Main.tileCut[24] = true;
			Main.tileCut[28] = true;
			Main.tileCut[32] = true;
			Main.tileCut[51] = true;
			Main.tileCut[52] = true;
			Main.tileCut[61] = true;
			Main.tileCut[62] = true;
			Main.tileCut[69] = true;
			Main.tileCut[71] = true;
			Main.tileCut[73] = true;
			Main.tileCut[74] = true;
			Main.tileCut[82] = true;
			Main.tileCut[83] = true;
			Main.tileCut[84] = true;
			Main.tileCut[110] = true;
			Main.tileCut[113] = true;
			Main.tileCut[115] = true;
			Main.tileAlch[82] = true;
			Main.tileAlch[83] = true;
			Main.tileAlch[84] = true;
			Main.tileLavaDeath[104] = true;
			Main.tileLavaDeath[110] = true;
			Main.tileLavaDeath[113] = true;
			Main.tileLavaDeath[115] = true;
			Main.tileSolid[127] = true;
			Main.tileSolid[130] = true;
			Main.tileBlockLight[130] = true;
			Main.tileBlockLight[131] = true;
			Main.tileSolid[107] = true;
			Main.tileBlockLight[107] = true;
			Main.tileSolid[108] = true;
			Main.tileBlockLight[108] = true;
			Main.tileSolid[111] = true;
			Main.tileBlockLight[111] = true;
			Main.tileSolid[109] = true;
			Main.tileBlockLight[109] = true;
			Main.tileSolid[110] = false;
			Main.tileNoAttach[110] = true;
			Main.tileNoFail[110] = true;
			Main.tileSolid[112] = true;
			Main.tileBlockLight[112] = true;
			Main.tileSolid[116] = true;
			Main.tileBlockLight[116] = true;
			Main.tileSolid[117] = true;
			Main.tileBlockLight[117] = true;
			Main.tileSolid[123] = true;
			Main.tileBlockLight[123] = true;
			Main.tileSolid[118] = true;
			Main.tileBlockLight[118] = true;
			Main.tileSolid[119] = true;
			Main.tileBlockLight[119] = true;
			Main.tileSolid[120] = true;
			Main.tileBlockLight[120] = true;
			Main.tileSolid[121] = true;
			Main.tileBlockLight[121] = true;
			Main.tileSolid[122] = true;
			Main.tileBlockLight[122] = true;
			Main.tileBlockLight[115] = true;
			Main.tileSolid[0] = true;
			Main.tileBlockLight[0] = true;
			Main.tileSolid[1] = true;
			Main.tileBlockLight[1] = true;
			Main.tileSolid[2] = true;
			Main.tileBlockLight[2] = true;
			Main.tileSolid[3] = false;
			Main.tileNoAttach[3] = true;
			Main.tileNoFail[3] = true;
			Main.tileSolid[4] = false;
			Main.tileNoAttach[4] = true;
			Main.tileNoFail[4] = true;
			Main.tileNoFail[24] = true;
			Main.tileSolid[5] = false;
			Main.tileSolid[6] = true;
			Main.tileBlockLight[6] = true;
			Main.tileSolid[7] = true;
			Main.tileBlockLight[7] = true;
			Main.tileSolid[8] = true;
			Main.tileBlockLight[8] = true;
			Main.tileSolid[9] = true;
			Main.tileBlockLight[9] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[10] = true;
			Main.tileNoAttach[10] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[11] = false;
			Main.tileSolidTop[19] = true;
			Main.tileSolid[19] = true;
			Main.tileSolid[22] = true;
			Main.tileSolid[23] = true;
			Main.tileSolid[25] = true;
			Main.tileSolid[30] = true;
			Main.tileNoFail[32] = true;
			Main.tileBlockLight[32] = true;
			Main.tileSolid[37] = true;
			Main.tileBlockLight[37] = true;
			Main.tileSolid[38] = true;
			Main.tileBlockLight[38] = true;
			Main.tileSolid[39] = true;
			Main.tileBlockLight[39] = true;
			Main.tileSolid[40] = true;
			Main.tileBlockLight[40] = true;
			Main.tileSolid[41] = true;
			Main.tileBlockLight[41] = true;
			Main.tileSolid[43] = true;
			Main.tileBlockLight[43] = true;
			Main.tileSolid[44] = true;
			Main.tileBlockLight[44] = true;
			Main.tileSolid[45] = true;
			Main.tileBlockLight[45] = true;
			Main.tileSolid[46] = true;
			Main.tileBlockLight[46] = true;
			Main.tileSolid[47] = true;
			Main.tileBlockLight[47] = true;
			Main.tileSolid[48] = true;
			Main.tileBlockLight[48] = true;
			Main.tileSolid[53] = true;
			Main.tileBlockLight[53] = true;
			Main.tileSolid[54] = true;
			Main.tileBlockLight[52] = true;
			Main.tileSolid[56] = true;
			Main.tileBlockLight[56] = true;
			Main.tileSolid[57] = true;
			Main.tileBlockLight[57] = true;
			Main.tileSolid[58] = true;
			Main.tileBlockLight[58] = true;
			Main.tileSolid[59] = true;
			Main.tileBlockLight[59] = true;
			Main.tileSolid[60] = true;
			Main.tileBlockLight[60] = true;
			Main.tileSolid[63] = true;
			Main.tileBlockLight[63] = true;
			Main.tileStone[63] = true;
			Main.tileStone[130] = true;
			Main.tileSolid[64] = true;
			Main.tileBlockLight[64] = true;
			Main.tileStone[64] = true;
			Main.tileSolid[65] = true;
			Main.tileBlockLight[65] = true;
			Main.tileStone[65] = true;
			Main.tileSolid[66] = true;
			Main.tileBlockLight[66] = true;
			Main.tileStone[66] = true;
			Main.tileSolid[67] = true;
			Main.tileBlockLight[67] = true;
			Main.tileStone[67] = true;
			Main.tileSolid[68] = true;
			Main.tileBlockLight[68] = true;
			Main.tileStone[68] = true;
			Main.tileSolid[75] = true;
			Main.tileBlockLight[75] = true;
			Main.tileSolid[76] = true;
			Main.tileBlockLight[76] = true;
			Main.tileSolid[70] = true;
			Main.tileBlockLight[70] = true;
			Main.tileNoFail[50] = true;
			Main.tileNoAttach[50] = true;
			Main.tileDungeon[41] = true;
			Main.tileDungeon[43] = true;
			Main.tileDungeon[44] = true;
			Main.tileBlockLight[30] = true;
			Main.tileBlockLight[25] = true;
			Main.tileBlockLight[23] = true;
			Main.tileBlockLight[22] = true;
			Main.tileBlockLight[62] = true;
			Main.tileSolidTop[18] = true;
			Main.tileSolidTop[14] = true;
			Main.tileSolidTop[16] = true;
			Main.tileSolidTop[114] = true;
			Main.tileNoAttach[20] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[13] = true;
			Main.tileNoAttach[14] = true;
			Main.tileNoAttach[15] = true;
			Main.tileNoAttach[16] = true;
			Main.tileNoAttach[17] = true;
			Main.tileNoAttach[18] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[21] = true;
			Main.tileNoAttach[27] = true;
			Main.tileNoAttach[114] = true;
			Main.tileTable[14] = true;
			Main.tileTable[18] = true;
			Main.tileTable[19] = true;
			Main.tileTable[114] = true;
			Main.tileNoAttach[86] = true;
			Main.tileNoAttach[87] = true;
			Main.tileNoAttach[88] = true;
			Main.tileNoAttach[89] = true;
			Main.tileNoAttach[90] = true;
			Main.tileLavaDeath[86] = true;
			Main.tileLavaDeath[87] = true;
			Main.tileLavaDeath[88] = true;
			Main.tileLavaDeath[89] = true;
			Main.tileLavaDeath[125] = true;
			Main.tileLavaDeath[126] = true;
			Main.tileLavaDeath[101] = true;
			Main.tileTable[101] = true;
			Main.tileNoAttach[101] = true;
			Main.tileLavaDeath[102] = true;
			Main.tileNoAttach[102] = true;
			Main.tileNoAttach[94] = true;
			Main.tileNoAttach[95] = true;
			Main.tileNoAttach[96] = true;
			Main.tileNoAttach[97] = true;
			Main.tileNoAttach[98] = true;
			Main.tileNoAttach[99] = true;
			Main.tileLavaDeath[94] = true;
			Main.tileLavaDeath[95] = true;
			Main.tileLavaDeath[96] = true;
			Main.tileLavaDeath[97] = true;
			Main.tileLavaDeath[98] = true;
			Main.tileLavaDeath[99] = true;
			Main.tileLavaDeath[100] = true;
			Main.tileLavaDeath[103] = true;
			Main.tileTable[87] = true;
			Main.tileTable[88] = true;
			Main.tileSolidTop[87] = true;
			Main.tileSolidTop[88] = true;
			Main.tileSolidTop[101] = true;
			Main.tileNoAttach[91] = true;
			Main.tileLavaDeath[91] = true;
			Main.tileNoAttach[92] = true;
			Main.tileLavaDeath[92] = true;
			Main.tileNoAttach[93] = true;
			Main.tileLavaDeath[93] = true;
			Main.tileWaterDeath[4] = true;
			Main.tileWaterDeath[51] = true;
			Main.tileWaterDeath[93] = true;
			Main.tileWaterDeath[98] = true;
			Main.tileLavaDeath[3] = true;
			Main.tileLavaDeath[5] = true;
			Main.tileLavaDeath[10] = true;
			Main.tileLavaDeath[11] = true;
			Main.tileLavaDeath[12] = true;
			Main.tileLavaDeath[13] = true;
			Main.tileLavaDeath[14] = true;
			Main.tileLavaDeath[15] = true;
			Main.tileLavaDeath[16] = true;
			Main.tileLavaDeath[17] = true;
			Main.tileLavaDeath[18] = true;
			Main.tileLavaDeath[19] = true;
			Main.tileLavaDeath[20] = true;
			Main.tileLavaDeath[27] = true;
			Main.tileLavaDeath[28] = true;
			Main.tileLavaDeath[29] = true;
			Main.tileLavaDeath[32] = true;
			Main.tileLavaDeath[33] = true;
			Main.tileLavaDeath[34] = true;
			Main.tileLavaDeath[35] = true;
			Main.tileLavaDeath[36] = true;
			Main.tileLavaDeath[42] = true;
			Main.tileLavaDeath[49] = true;
			Main.tileLavaDeath[50] = true;
			Main.tileLavaDeath[52] = true;
			Main.tileLavaDeath[55] = true;
			Main.tileLavaDeath[61] = true;
			Main.tileLavaDeath[62] = true;
			Main.tileLavaDeath[69] = true;
			Main.tileLavaDeath[71] = true;
			Main.tileLavaDeath[72] = true;
			Main.tileLavaDeath[73] = true;
			Main.tileLavaDeath[74] = true;
			Main.tileLavaDeath[79] = true;
			Main.tileLavaDeath[80] = true;
			Main.tileLavaDeath[81] = true;
			Main.tileLavaDeath[106] = true;
			Main.wallHouse[1] = true;
			Main.wallHouse[4] = true;
			Main.wallHouse[5] = true;
			Main.wallHouse[6] = true;
			Main.wallHouse[10] = true;
			Main.wallHouse[11] = true;
			Main.wallHouse[12] = true;
			Main.wallHouse[16] = true;
			Main.wallHouse[17] = true;
			Main.wallHouse[18] = true;
			Main.wallHouse[19] = true;
			Main.wallHouse[20] = true;
			Main.wallHouse[21] = true;
			Main.wallHouse[22] = true;
			Main.wallHouse[23] = true;
			Main.wallHouse[24] = true;
			Main.wallHouse[25] = true;
			Main.wallHouse[26] = true;
			Main.wallHouse[27] = true;
			Main.wallHouse[29] = true;
			Main.wallHouse[30] = true;
			Main.wallHouse[31] = true;
			for (int k = 0; k < 32; k++)
			{
				if (k == 20)
				{
					Main.wallBlend[k] = 14;
				}
				else if (k == 19)
				{
					Main.wallBlend[k] = 9;
				}
				else if (k == 18)
				{
					Main.wallBlend[k] = 8;
				}
				else if (k == 17)
				{
					Main.wallBlend[k] = 7;
				}
				else if (k == 16)
				{
					Main.wallBlend[k] = 2;
				}
				else
				{
					Main.wallBlend[k] = k;
				}
			}
			Main.tileNoFail[32] = true;
			Main.tileNoFail[61] = true;
			Main.tileNoFail[69] = true;
			Main.tileNoFail[73] = true;
			Main.tileNoFail[74] = true;
			Main.tileNoFail[82] = true;
			Main.tileNoFail[83] = true;
			Main.tileNoFail[84] = true;
			Main.tileNoFail[110] = true;
			Main.tileNoFail[113] = true;
			for (int l = 0; l < 150; l++)
			{
				Main.tileName[l] = "";
				if (Main.tileSolid[l])
				{
					Main.tileNoSunLight[l] = true;
				}
			}
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileName[13] = "空瓶";
			Main.tileName[14] = "木桌";
			Main.tileName[15] = "木椅";
			Main.tileName[16] = "铁砧";
			Main.tileName[17] = "熔炉";
			Main.tileName[18] = "工作台";
			Main.tileName[26] = "恶魔祭坛";
			Main.tileName[77] = "地狱熔炉";
			Main.tileName[86] = "织布机";
			Main.tileName[94] = "酒桶";
			Main.tileName[96] = "烹饪锅";
			Main.tileName[101] = "书架";
			Main.tileName[106] = "锯木机";
			Main.tileName[114] = "工匠作坊";
			Main.tileName[133] = "精金熔炉";
			Main.tileName[134] = "秘银砧";
			for (int m = 0; m < Main.maxMenuItems; m++)
			{
				this.menuItemScale[m] = 0.8f;
			}
			for (int n = 0; n < 2001; n++)
			{
				Main.dust[n] = new Dust();
			}
			for (int num2 = 0; num2 < 201; num2++)
			{
				Main.item[num2] = new Item();
			}
			for (int num3 = 0; num3 < 201; num3++)
			{
				Main.npc[num3] = new NPC();
				Main.npc[num3].whoAmI = num3;
			}
			for (int num4 = 0; num4 < 256; num4++)
			{
				Main.player[num4] = new Player();
			}
			for (int num5 = 0; num5 < 1001; num5++)
			{
				Main.projectile[num5] = new Projectile();
			}
			for (int num6 = 0; num6 < 201; num6++)
			{
				Main.gore[num6] = new Gore();
			}
			for (int num7 = 0; num7 < 100; num7++)
			{
				Main.cloud[num7] = new Cloud();
			}
			for (int num8 = 0; num8 < 100; num8++)
			{
				Main.combatText[num8] = new CombatText();
			}
			for (int num9 = 0; num9 < 20; num9++)
			{
				Main.itemText[num9] = new ItemText();
			}
			for (int num10 = 0; num10 < 603; num10++)
			{
				Item item = new Item();
				item.SetDefaults(num10, false);
				Main.itemName[num10] = item.name;
				if (item.headSlot > 0)
				{
					Item.headType[item.headSlot] = item.type;
				}
				if (item.bodySlot > 0)
				{
					Item.bodyType[item.bodySlot] = item.type;
				}
				if (item.legSlot > 0)
				{
					Item.legType[item.legSlot] = item.type;
				}
			}
			for (int num11 = 0; num11 < Recipe.maxRecipes; num11++)
			{
				Main.recipe[num11] = new Recipe();
				Main.availableRecipeY[num11] = (float)(65 * num11);
			}
			Recipe.SetupRecipes();
			for (int num12 = 0; num12 < Main.numChatLines; num12++)
			{
				Main.chatLine[num12] = new ChatLine();
			}
			for (int num13 = 0; num13 < Liquid.resLiquid; num13++)
			{
				Main.liquid[num13] = new Liquid();
			}
			for (int num14 = 0; num14 < 10000; num14++)
			{
				Main.liquidBuffer[num14] = new LiquidBuffer();
			}
			this.shop[0] = new Chest();
			this.shop[1] = new Chest();
			this.shop[1].SetupShop(1);
			this.shop[2] = new Chest();
			this.shop[2].SetupShop(2);
			this.shop[3] = new Chest();
			this.shop[3].SetupShop(3);
			this.shop[4] = new Chest();
			this.shop[4].SetupShop(4);
			this.shop[5] = new Chest();
			this.shop[5].SetupShop(5);
			this.shop[6] = new Chest();
			this.shop[6].SetupShop(6);
			this.shop[7] = new Chest();
			this.shop[7].SetupShop(7);
			this.shop[8] = new Chest();
			this.shop[8].SetupShop(8);
			this.shop[9] = new Chest();
			this.shop[9].SetupShop(9);
			Main.teamColor[0] = Microsoft.Xna.Framework.Color.White;
			Main.teamColor[1] = new Microsoft.Xna.Framework.Color(230, 40, 20);
			Main.teamColor[2] = new Microsoft.Xna.Framework.Color(20, 200, 30);
			Main.teamColor[3] = new Microsoft.Xna.Framework.Color(75, 90, 255);
			Main.teamColor[4] = new Microsoft.Xna.Framework.Color(200, 180, 0);
			if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
			}
			Netplay.Init();
			if (Main.skipMenu)
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				Main.LoadPlayers();
				Main.player[Main.myPlayer] = (Player)Main.loadPlayer[0].Clone();
				Main.PlayerPath = Main.loadPlayerPath[0];
				Main.LoadWorlds();
				WorldGen.generateWorld(-1);
				WorldGen.EveryTileFrame();
				Main.player[Main.myPlayer].Spawn();
			}
			else
			{
				IntPtr systemMenu = Main.GetSystemMenu(base.Window.Handle, false);
				int menuItemCount = Main.GetMenuItemCount(systemMenu);
				Main.RemoveMenu(systemMenu, menuItemCount - 1, 1024);
			}
			if (!Main.dedServ)
			{
				this.graphics.PreferredBackBufferWidth = Main.screenWidth;
				this.graphics.PreferredBackBufferHeight = Main.screenHeight;
				this.graphics.ApplyChanges();
				base.Initialize();
				base.Window.AllowUserResizing = true;
				this.OpenSettings();
				this.OpenRecent();
				Star.SpawnStars();
				foreach (DisplayMode current in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
				{
					if (current.Width >= Main.minScreenW && current.Height >= Main.minScreenH && current.Width <= Main.maxScreenW && current.Height <= Main.maxScreenH)
					{
						bool flag = true;
						for (int num15 = 0; num15 < this.numDisplayModes; num15++)
						{
							if (current.Width == this.displayWidth[num15] && current.Height == this.displayHeight[num15])
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							this.displayHeight[this.numDisplayModes] = current.Height;
							this.displayWidth[this.numDisplayModes] = current.Width;
							this.numDisplayModes++;
						}
					}
				}
				if (Main.autoJoin)
				{
					Main.LoadPlayers();
					Main.menuMode = 1;
					Main.menuMultiplayer = true;
				}
				Main.fpsTimer.Start();
				Main.updateTimer.Start();
			}
		}

		protected override void LoadContent()
		{
			try
			{
				Main.engine = new AudioEngine("Content\\TerrariaMusic.xgs");
				Main.soundBank = new SoundBank(Main.engine, "Content\\Sound Bank.xsb");
				Main.waveBank = new WaveBank(Main.engine, "Content\\Wave Bank.xwb");
				for (int i = 1; i < 14; i++)
				{
					Main.music[i] = Main.soundBank.GetCue("Music_" + i);
				}
				Main.soundMech[0] = base.Content.Load<SoundEffect>("Sounds\\Mech_0");
				Main.soundInstanceMech[0] = Main.soundMech[0].CreateInstance();
				Main.soundGrab = base.Content.Load<SoundEffect>("Sounds\\Grab");
				Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
				Main.soundPixie = base.Content.Load<SoundEffect>("Sounds\\Pixie");
				Main.soundInstancePixie = Main.soundGrab.CreateInstance();
				Main.soundDig[0] = base.Content.Load<SoundEffect>("Sounds\\Dig_0");
				Main.soundInstanceDig[0] = Main.soundDig[0].CreateInstance();
				Main.soundDig[1] = base.Content.Load<SoundEffect>("Sounds\\Dig_1");
				Main.soundInstanceDig[1] = Main.soundDig[1].CreateInstance();
				Main.soundDig[2] = base.Content.Load<SoundEffect>("Sounds\\Dig_2");
				Main.soundInstanceDig[2] = Main.soundDig[2].CreateInstance();
				Main.soundTink[0] = base.Content.Load<SoundEffect>("Sounds\\Tink_0");
				Main.soundInstanceTink[0] = Main.soundTink[0].CreateInstance();
				Main.soundTink[1] = base.Content.Load<SoundEffect>("Sounds\\Tink_1");
				Main.soundInstanceTink[1] = Main.soundTink[1].CreateInstance();
				Main.soundTink[2] = base.Content.Load<SoundEffect>("Sounds\\Tink_2");
				Main.soundInstanceTink[2] = Main.soundTink[2].CreateInstance();
				Main.soundPlayerHit[0] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_0");
				Main.soundInstancePlayerHit[0] = Main.soundPlayerHit[0].CreateInstance();
				Main.soundPlayerHit[1] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_1");
				Main.soundInstancePlayerHit[1] = Main.soundPlayerHit[1].CreateInstance();
				Main.soundPlayerHit[2] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_2");
				Main.soundInstancePlayerHit[2] = Main.soundPlayerHit[2].CreateInstance();
				Main.soundFemaleHit[0] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_0");
				Main.soundInstanceFemaleHit[0] = Main.soundFemaleHit[0].CreateInstance();
				Main.soundFemaleHit[1] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_1");
				Main.soundInstanceFemaleHit[1] = Main.soundFemaleHit[1].CreateInstance();
				Main.soundFemaleHit[2] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_2");
				Main.soundInstanceFemaleHit[2] = Main.soundFemaleHit[2].CreateInstance();
				Main.soundPlayerKilled = base.Content.Load<SoundEffect>("Sounds\\Player_Killed");
				Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
				Main.soundChat = base.Content.Load<SoundEffect>("Sounds\\Chat");
				Main.soundInstanceChat = Main.soundChat.CreateInstance();
				Main.soundGrass = base.Content.Load<SoundEffect>("Sounds\\Grass");
				Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
				Main.soundDoorOpen = base.Content.Load<SoundEffect>("Sounds\\Door_Opened");
				Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
				Main.soundDoorClosed = base.Content.Load<SoundEffect>("Sounds\\Door_Closed");
				Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
				Main.soundMenuTick = base.Content.Load<SoundEffect>("Sounds\\Menu_Tick");
				Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
				Main.soundMenuOpen = base.Content.Load<SoundEffect>("Sounds\\Menu_Open");
				Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
				Main.soundMenuClose = base.Content.Load<SoundEffect>("Sounds\\Menu_Close");
				Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
				Main.soundShatter = base.Content.Load<SoundEffect>("Sounds\\Shatter");
				Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
				Main.soundZombie[0] = base.Content.Load<SoundEffect>("Sounds\\Zombie_0");
				Main.soundInstanceZombie[0] = Main.soundZombie[0].CreateInstance();
				Main.soundZombie[1] = base.Content.Load<SoundEffect>("Sounds\\Zombie_1");
				Main.soundInstanceZombie[1] = Main.soundZombie[1].CreateInstance();
				Main.soundZombie[2] = base.Content.Load<SoundEffect>("Sounds\\Zombie_2");
				Main.soundInstanceZombie[2] = Main.soundZombie[2].CreateInstance();
				Main.soundZombie[3] = base.Content.Load<SoundEffect>("Sounds\\Zombie_3");
				Main.soundInstanceZombie[3] = Main.soundZombie[3].CreateInstance();
				Main.soundZombie[4] = base.Content.Load<SoundEffect>("Sounds\\Zombie_4");
				Main.soundInstanceZombie[4] = Main.soundZombie[4].CreateInstance();
				Main.soundRoar[0] = base.Content.Load<SoundEffect>("Sounds\\Roar_0");
				Main.soundInstanceRoar[0] = Main.soundRoar[0].CreateInstance();
				Main.soundRoar[1] = base.Content.Load<SoundEffect>("Sounds\\Roar_1");
				Main.soundInstanceRoar[1] = Main.soundRoar[1].CreateInstance();
				Main.soundSplash[0] = base.Content.Load<SoundEffect>("Sounds\\Splash_0");
				Main.soundInstanceSplash[0] = Main.soundRoar[0].CreateInstance();
				Main.soundSplash[1] = base.Content.Load<SoundEffect>("Sounds\\Splash_1");
				Main.soundInstanceSplash[1] = Main.soundSplash[1].CreateInstance();
				Main.soundDoubleJump = base.Content.Load<SoundEffect>("Sounds\\Double_Jump");
				Main.soundInstanceDoubleJump = Main.soundRoar[0].CreateInstance();
				Main.soundRun = base.Content.Load<SoundEffect>("Sounds\\Run");
				Main.soundInstanceRun = Main.soundRun.CreateInstance();
				Main.soundCoins = base.Content.Load<SoundEffect>("Sounds\\Coins");
				Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
				Main.soundUnlock = base.Content.Load<SoundEffect>("Sounds\\Unlock");
				Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
				Main.soundMaxMana = base.Content.Load<SoundEffect>("Sounds\\MaxMana");
				Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
				Main.soundDrown = base.Content.Load<SoundEffect>("Sounds\\Drown");
				Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
				for (int j = 1; j < 38; j++)
				{
					Main.soundItem[j] = base.Content.Load<SoundEffect>("Sounds\\Item_" + j);
					Main.soundInstanceItem[j] = Main.soundItem[j].CreateInstance();
				}
				for (int k = 1; k < 12; k++)
				{
					Main.soundNPCHit[k] = base.Content.Load<SoundEffect>("Sounds\\NPC_Hit_" + k);
					Main.soundInstanceNPCHit[k] = Main.soundNPCHit[k].CreateInstance();
				}
				for (int l = 1; l < 16; l++)
				{
					Main.soundNPCKilled[l] = base.Content.Load<SoundEffect>("Sounds\\NPC_Killed_" + l);
					Main.soundInstanceNPCKilled[l] = Main.soundNPCKilled[l].CreateInstance();
				}
			}
			catch
			{
				Main.musicVolume = 0f;
				Main.soundVolume = 0f;
			}
			Main.reforgeTexture = base.Content.Load<Texture2D>("Images\\Reforge");
			Main.timerTexture = base.Content.Load<Texture2D>("Images\\Timer");
			Main.wofTexture = base.Content.Load<Texture2D>("Images\\WallOfFlesh");
			Main.wallOutlineTexture = base.Content.Load<Texture2D>("Images\\Wall_Outline");
			Main.raTexture = base.Content.Load<Texture2D>("Images\\ra-logo");
			Main.reTexture = base.Content.Load<Texture2D>("Images\\re-logo");
			Main.splashTexture = base.Content.Load<Texture2D>("Images\\splash");
			Main.fadeTexture = base.Content.Load<Texture2D>("Images\\fade-out");
			Main.ghostTexture = base.Content.Load<Texture2D>("Images\\Ghost");
			Main.evilCactusTexture = base.Content.Load<Texture2D>("Images\\Evil_Cactus");
			Main.goodCactusTexture = base.Content.Load<Texture2D>("Images\\Good_Cactus");
			Main.wraithEyeTexture = base.Content.Load<Texture2D>("Images\\Wraith_Eyes");
			Main.MusicBoxTexture = base.Content.Load<Texture2D>("Images\\Music_Box");
			Main.wingsTexture[1] = base.Content.Load<Texture2D>("Images\\Wings_1");
			Main.wingsTexture[2] = base.Content.Load<Texture2D>("Images\\Wings_2");
			Main.destTexture[0] = base.Content.Load<Texture2D>("Images\\Dest1");
			Main.destTexture[1] = base.Content.Load<Texture2D>("Images\\Dest2");
			Main.destTexture[2] = base.Content.Load<Texture2D>("Images\\Dest3");
			Main.wireTexture = base.Content.Load<Texture2D>("Images\\Wires");
			for (int m = 0; m < 6; m++)
			{
				Main.loTexture[m] = base.Content.Load<Texture2D>("Images\\logo_" + (m + 1));
			}
			this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
			for (int m = 1; m < 2; m++)
			{
				Main.bannerTexture[m] = base.Content.Load<Texture2D>("Images\\House_Banner_" + m);
			}
			for (int n = 0; n < 12; n++)
			{
				Main.npcHeadTexture[n] = base.Content.Load<Texture2D>("Images\\NPC_Head_" + n);
			}
			for (int num = 0; num < 150; num++)
			{
				Main.tileTexture[num] = base.Content.Load<Texture2D>("Images\\Tiles_" + num);
			}
			for (int num2 = 1; num2 < 32; num2++)
			{
				Main.wallTexture[num2] = base.Content.Load<Texture2D>("Images\\Wall_" + num2);
			}
			for (int num3 = 1; num3 < 40; num3++)
			{
				Main.buffTexture[num3] = base.Content.Load<Texture2D>("Images\\Buff_" + num3);
			}
			for (int num4 = 0; num4 < 32; num4++)
			{
				Main.backgroundTexture[num4] = base.Content.Load<Texture2D>("Images\\Background_" + num4);
				Main.backgroundWidth[num4] = Main.backgroundTexture[num4].Width;
				Main.backgroundHeight[num4] = Main.backgroundTexture[num4].Height;
			}
			for (int num5 = 0; num5 < 603; num5++)
			{
				Main.itemTexture[num5] = base.Content.Load<Texture2D>("Images\\Item_" + num5);
			}
			for (int num6 = 0; num6 < 147; num6++)
			{
				Main.npcTexture[num6] = base.Content.Load<Texture2D>("Images\\NPC_" + num6);
			}
			for (int num7 = 0; num7 < 147; num7++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(num7, -1f);
				Main.npcName[num7] = nPC.name;
			}
			for (int num8 = 0; num8 < 111; num8++)
			{
				Main.projectileTexture[num8] = base.Content.Load<Texture2D>("Images\\Projectile_" + num8);
			}
			for (int num9 = 1; num9 < 160; num9++)
			{
				Main.goreTexture[num9] = base.Content.Load<Texture2D>("Images\\Gore_" + num9);
			}
			for (int num10 = 0; num10 < 4; num10++)
			{
				Main.cloudTexture[num10] = base.Content.Load<Texture2D>("Images\\Cloud_" + num10);
			}
			for (int num11 = 0; num11 < 5; num11++)
			{
				Main.starTexture[num11] = base.Content.Load<Texture2D>("Images\\Star_" + num11);
			}
			for (int num12 = 0; num12 < 2; num12++)
			{
				Main.liquidTexture[num12] = base.Content.Load<Texture2D>("Images\\Liquid_" + num12);
			}
			Main.npcToggleTexture[0] = base.Content.Load<Texture2D>("Images\\House_1");
			Main.npcToggleTexture[1] = base.Content.Load<Texture2D>("Images\\House_2");
			Main.HBLockTexture[0] = base.Content.Load<Texture2D>("Images\\Lock_0");
			Main.HBLockTexture[1] = base.Content.Load<Texture2D>("Images\\Lock_1");
			Main.gridTexture = base.Content.Load<Texture2D>("Images\\Grid");
			Main.trashTexture = base.Content.Load<Texture2D>("Images\\Trash");
			Main.cdTexture = base.Content.Load<Texture2D>("Images\\CoolDown");
			Main.logoTexture = base.Content.Load<Texture2D>("Images\\Logo");
			Main.logo2Texture = base.Content.Load<Texture2D>("Images\\Logo2");
			Main.logo3Texture = base.Content.Load<Texture2D>("Images\\Logo3");
			Main.dustTexture = base.Content.Load<Texture2D>("Images\\Dust");
			Main.sunTexture = base.Content.Load<Texture2D>("Images\\Sun");
			Main.sun2Texture = base.Content.Load<Texture2D>("Images\\Sun2");
			Main.moonTexture = base.Content.Load<Texture2D>("Images\\Moon");
			Main.blackTileTexture = base.Content.Load<Texture2D>("Images\\Black_Tile");
			Main.heartTexture = base.Content.Load<Texture2D>("Images\\Heart");
			Main.bubbleTexture = base.Content.Load<Texture2D>("Images\\Bubble");
			Main.manaTexture = base.Content.Load<Texture2D>("Images\\Mana");
			Main.cursorTexture = base.Content.Load<Texture2D>("Images\\Cursor");
			Main.ninjaTexture = base.Content.Load<Texture2D>("Images\\Ninja");
			Main.antLionTexture = base.Content.Load<Texture2D>("Images\\AntlionBody");
			Main.spikeBaseTexture = base.Content.Load<Texture2D>("Images\\Spike_Base");
			Main.treeTopTexture[0] = base.Content.Load<Texture2D>("Images\\Tree_Tops_0");
			Main.treeBranchTexture[0] = base.Content.Load<Texture2D>("Images\\Tree_Branches_0");
			Main.treeTopTexture[1] = base.Content.Load<Texture2D>("Images\\Tree_Tops_1");
			Main.treeBranchTexture[1] = base.Content.Load<Texture2D>("Images\\Tree_Branches_1");
			Main.treeTopTexture[2] = base.Content.Load<Texture2D>("Images\\Tree_Tops_2");
			Main.treeBranchTexture[2] = base.Content.Load<Texture2D>("Images\\Tree_Branches_2");
			Main.treeTopTexture[3] = base.Content.Load<Texture2D>("Images\\Tree_Tops_3");
			Main.treeBranchTexture[3] = base.Content.Load<Texture2D>("Images\\Tree_Branches_3");
			Main.treeTopTexture[4] = base.Content.Load<Texture2D>("Images\\Tree_Tops_4");
			Main.treeBranchTexture[4] = base.Content.Load<Texture2D>("Images\\Tree_Branches_4");
			Main.shroomCapTexture = base.Content.Load<Texture2D>("Images\\Shroom_Tops");
			Main.inventoryBackTexture = base.Content.Load<Texture2D>("Images\\Inventory_Back");
			Main.inventoryBack2Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back2");
			Main.inventoryBack3Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back3");
			Main.inventoryBack4Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back4");
			Main.inventoryBack5Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back5");
			Main.inventoryBack6Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back6");
			Main.inventoryBack7Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back7");
			Main.inventoryBack8Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back8");
			Main.inventoryBack9Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back9");
			Main.inventoryBack10Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back10");
			Main.inventoryBack11Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back11");
			Main.textBackTexture = base.Content.Load<Texture2D>("Images\\Text_Back");
			Main.chatTexture = base.Content.Load<Texture2D>("Images\\Chat");
			Main.chat2Texture = base.Content.Load<Texture2D>("Images\\Chat2");
			Main.chatBackTexture = base.Content.Load<Texture2D>("Images\\Chat_Back");
			Main.teamTexture = base.Content.Load<Texture2D>("Images\\Team");
			for (int num13 = 1; num13 < 26; num13++)
			{
				Main.femaleBodyTexture[num13] = base.Content.Load<Texture2D>("Images\\Female_Body_" + num13);
				Main.armorBodyTexture[num13] = base.Content.Load<Texture2D>("Images\\Armor_Body_" + num13);
				Main.armorArmTexture[num13] = base.Content.Load<Texture2D>("Images\\Armor_Arm_" + num13);
			}
			for (int num14 = 1; num14 < 45; num14++)
			{
				Main.armorHeadTexture[num14] = base.Content.Load<Texture2D>("Images\\Armor_Head_" + num14);
			}
			for (int num15 = 1; num15 < 25; num15++)
			{
				Main.armorLegTexture[num15] = base.Content.Load<Texture2D>("Images\\Armor_Legs_" + num15);
			}
			for (int num16 = 0; num16 < 36; num16++)
			{
				Main.playerHairTexture[num16] = base.Content.Load<Texture2D>("Images\\Player_Hair_" + (num16 + 1));
				Main.playerHairAltTexture[num16] = base.Content.Load<Texture2D>("Images\\Player_HairAlt_" + (num16 + 1));
			}
			Main.skinBodyTexture = base.Content.Load<Texture2D>("Images\\Skin_Body");
			Main.skinLegsTexture = base.Content.Load<Texture2D>("Images\\Skin_Legs");
			Main.playerEyeWhitesTexture = base.Content.Load<Texture2D>("Images\\Player_Eye_Whites");
			Main.playerEyesTexture = base.Content.Load<Texture2D>("Images\\Player_Eyes");
			Main.playerHandsTexture = base.Content.Load<Texture2D>("Images\\Player_Hands");
			Main.playerHands2Texture = base.Content.Load<Texture2D>("Images\\Player_Hands2");
			Main.playerHeadTexture = base.Content.Load<Texture2D>("Images\\Player_Head");
			Main.playerPantsTexture = base.Content.Load<Texture2D>("Images\\Player_Pants");
			Main.playerShirtTexture = base.Content.Load<Texture2D>("Images\\Player_Shirt");
			Main.playerShoesTexture = base.Content.Load<Texture2D>("Images\\Player_Shoes");
			Main.playerUnderShirtTexture = base.Content.Load<Texture2D>("Images\\Player_Undershirt");
			Main.playerUnderShirt2Texture = base.Content.Load<Texture2D>("Images\\Player_Undershirt2");
			Main.femalePantsTexture = base.Content.Load<Texture2D>("Images\\Female_Pants");
			Main.femaleShirtTexture = base.Content.Load<Texture2D>("Images\\Female_Shirt");
			Main.femaleShoesTexture = base.Content.Load<Texture2D>("Images\\Female_Shoes");
			Main.femaleUnderShirtTexture = base.Content.Load<Texture2D>("Images\\Female_Undershirt");
			Main.femaleUnderShirt2Texture = base.Content.Load<Texture2D>("Images\\Female_Undershirt2");
			Main.femaleShirt2Texture = base.Content.Load<Texture2D>("Images\\Female_Shirt2");
			Main.chaosTexture = base.Content.Load<Texture2D>("Images\\Chaos");
			Main.EyeLaserTexture = base.Content.Load<Texture2D>("Images\\Eye_Laser");
			Main.BoneEyesTexture = base.Content.Load<Texture2D>("Images\\Bone_eyes");
			Main.BoneLaserTexture = base.Content.Load<Texture2D>("Images\\Bone_Laser");
			Main.lightDiscTexture = base.Content.Load<Texture2D>("Images\\Light_Disc");
			Main.confuseTexture = base.Content.Load<Texture2D>("Images\\Confuse");
			Main.probeTexture = base.Content.Load<Texture2D>("Images\\Probe");
			Main.chainTexture = base.Content.Load<Texture2D>("Images\\Chain");
			Main.chain2Texture = base.Content.Load<Texture2D>("Images\\Chain2");
			Main.chain3Texture = base.Content.Load<Texture2D>("Images\\Chain3");
			Main.chain4Texture = base.Content.Load<Texture2D>("Images\\Chain4");
			Main.chain5Texture = base.Content.Load<Texture2D>("Images\\Chain5");
			Main.chain6Texture = base.Content.Load<Texture2D>("Images\\Chain6");
			Main.chain7Texture = base.Content.Load<Texture2D>("Images\\Chain7");
			Main.chain8Texture = base.Content.Load<Texture2D>("Images\\Chain8");
			Main.chain9Texture = base.Content.Load<Texture2D>("Images\\Chain9");
			Main.chain10Texture = base.Content.Load<Texture2D>("Images\\Chain10");
			Main.chain11Texture = base.Content.Load<Texture2D>("Images\\Chain11");
			Main.chain12Texture = base.Content.Load<Texture2D>("Images\\Chain12");
			Main.boneArmTexture = base.Content.Load<Texture2D>("Images\\Arm_Bone");
			Main.boneArm2Texture = base.Content.Load<Texture2D>("Images\\Arm_Bone_2");
			Main.fontItemStack = new SpriteFontX(new Font(Main.fontItemStackName, 14f), this.graphics, TextRenderingHint.ClearTypeGridFit);
			Main.fontMouseText = new SpriteFontX(new Font(Main.fontMouseTextName, 14f), this.graphics, TextRenderingHint.ClearTypeGridFit);
			Main.fontDeathText = new SpriteFontX(new Font(Main.fontDeathTextName, 23f), this.graphics, TextRenderingHint.ClearTypeGridFit);
			Main.fontCombatText[0] = new SpriteFontX(new Font(Main.fontCombatTextName, 14f), this.graphics, TextRenderingHint.ClearTypeGridFit);
			Main.fontCombatText[1] = new SpriteFontX(new Font(Main.fontCombatTextName, 14f), this.graphics, TextRenderingHint.ClearTypeGridFit);
			if (Main.isPNGMODOpen)
			{
				IFileProvider provider = new DirProvider(new DirectoryInfo("Content\\PNG"));
				Dictionary<string, Texture2D> textures = ContentLoader.GetTextures(this.graphics.GraphicsDevice, provider);
				ContentLoader.Load(textures);
			}
		}

		protected override void UnloadContent()
		{
		}

		protected void UpdateMusic()
		{
			try
			{
				if (!Main.dedServ)
				{
					if (Main.curMusic > 0)
					{
						if (!base.IsActive)
						{
							if (!Main.music[Main.curMusic].IsPaused && Main.music[Main.curMusic].IsPlaying)
							{
								try
								{
									Main.music[Main.curMusic].Pause();
								}
								catch
								{
								}
							}
							return;
						}
						if (Main.music[Main.curMusic].IsPaused)
						{
							Main.music[Main.curMusic].Resume();
						}
					}
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
					int num = 5000;
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active)
						{
							if (Main.npc[i].type == 134 || Main.npc[i].type == 143 || Main.npc[i].type == 144 || Main.npc[i].type == 145)
							{
								Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
								if (rectangle.Intersects(value))
								{
									flag3 = true;
									break;
								}
							}
							else if (Main.npc[i].type == 113 || Main.npc[i].type == 114 || Main.npc[i].type == 125 || Main.npc[i].type == 126)
							{
								Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
								if (rectangle.Intersects(value2))
								{
									flag2 = true;
									break;
								}
							}
							else if (Main.npc[i].boss || Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15 || Main.npc[i].type == 134 || Main.npc[i].type == 26 || Main.npc[i].type == 27 || Main.npc[i].type == 28 || Main.npc[i].type == 29 || Main.npc[i].type == 111)
							{
								Microsoft.Xna.Framework.Rectangle value3 = new Microsoft.Xna.Framework.Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
								if (rectangle.Intersects(value3))
								{
									flag = true;
									break;
								}
							}
						}
					}
					if (Main.musicVolume == 0f)
					{
						this.newMusic = 0;
					}
					else if (Main.gameMenu)
					{
						if (Main.netMode != 2)
						{
							this.newMusic = 6;
						}
						else
						{
							this.newMusic = 0;
						}
					}
					else if (flag2)
					{
						this.newMusic = 12;
					}
					else if (flag)
					{
						this.newMusic = 5;
					}
					else if (flag3)
					{
						this.newMusic = 13;
					}
					else if (Main.player[Main.myPlayer].position.Y > (float)((Main.maxTilesY - 200) * 16))
					{
						this.newMusic = 2;
					}
					else if (Main.player[Main.myPlayer].zoneEvil)
					{
						if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)Main.screenHeight)
						{
							this.newMusic = 10;
						}
						else
						{
							this.newMusic = 8;
						}
					}
					else if (Main.player[Main.myPlayer].zoneMeteor || Main.player[Main.myPlayer].zoneDungeon)
					{
						this.newMusic = 2;
					}
					else if (Main.player[Main.myPlayer].zoneJungle)
					{
						this.newMusic = 7;
					}
					else if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)Main.screenHeight)
					{
						if (Main.player[Main.myPlayer].zoneHoly)
						{
							this.newMusic = 11;
						}
						else
						{
							this.newMusic = 4;
						}
					}
					else if (Main.dayTime)
					{
						if (Main.player[Main.myPlayer].zoneHoly)
						{
							this.newMusic = 9;
						}
						else
						{
							this.newMusic = 1;
						}
					}
					else if (!Main.dayTime)
					{
						if (Main.bloodMoon)
						{
							this.newMusic = 2;
						}
						else
						{
							this.newMusic = 3;
						}
					}
					if (Main.gameMenu)
					{
						Main.musicBox2 = -1;
						Main.musicBox = -1;
					}
					if (Main.musicBox2 >= 0)
					{
						Main.musicBox = Main.musicBox2;
					}
					if (Main.musicBox >= 0)
					{
						if (Main.musicBox == 0)
						{
							this.newMusic = 1;
						}
						if (Main.musicBox == 1)
						{
							this.newMusic = 2;
						}
						if (Main.musicBox == 2)
						{
							this.newMusic = 3;
						}
						if (Main.musicBox == 4)
						{
							this.newMusic = 4;
						}
						if (Main.musicBox == 5)
						{
							this.newMusic = 5;
						}
						if (Main.musicBox == 3)
						{
							this.newMusic = 6;
						}
						if (Main.musicBox == 6)
						{
							this.newMusic = 7;
						}
						if (Main.musicBox == 7)
						{
							this.newMusic = 8;
						}
						if (Main.musicBox == 9)
						{
							this.newMusic = 9;
						}
						if (Main.musicBox == 8)
						{
							this.newMusic = 10;
						}
						if (Main.musicBox == 11)
						{
							this.newMusic = 11;
						}
						if (Main.musicBox == 10)
						{
							this.newMusic = 12;
						}
						if (Main.musicBox == 12)
						{
							this.newMusic = 13;
						}
					}
					Main.curMusic = this.newMusic;
					for (int j = 1; j < 14; j++)
					{
						if (j == Main.curMusic)
						{
							if (!Main.music[j].IsPlaying)
							{
								Main.music[j] = Main.soundBank.GetCue("Music_" + j);
								Main.music[j].Play();
								Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
							}
							else
							{
								Main.musicFade[j] += 0.005f;
								if (Main.musicFade[j] > 1f)
								{
									Main.musicFade[j] = 1f;
								}
								Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
							}
						}
						else if (Main.music[j].IsPlaying)
						{
							if (Main.musicFade[Main.curMusic] > 0.25f)
							{
								Main.musicFade[j] -= 0.005f;
							}
							else if (Main.curMusic == 0)
							{
								Main.musicFade[j] = 0f;
							}
							if (Main.musicFade[j] <= 0f)
							{
								Main.musicFade[j] -= 0f;
								Main.music[j].Stop(AudioStopOptions.Immediate);
							}
							else
							{
								Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
							}
						}
						else
						{
							Main.musicFade[j] = 0f;
						}
					}
				}
			}
			catch
			{
				Main.musicVolume = 0f;
			}
		}

		public static void snowing()
		{
			if (!Main.gamePaused)
			{
				if (Main.snowTiles > 0 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0)
				{
					int maxValue = 800 / Main.snowTiles;
					float num = (float)Main.screenWidth / 1920f;
					int num2 = (int)(500f * num);
					if ((float)Main.snowDust < (float)num2 * (Main.gfxQuality / 2f + 0.5f) + (float)num2 * 0.1f && Main.rand.Next(maxValue) == 0)
					{
						int num3 = Main.rand.Next(Main.screenWidth + 1000) - 500;
						int num4 = (int)Main.screenPosition.Y;
						if (Main.rand.Next(5) == 0)
						{
							num3 = Main.rand.Next(500) - 500;
						}
						else if (Main.rand.Next(5) == 0)
						{
							num3 = Main.rand.Next(500) + Main.screenWidth;
						}
						if (num3 < 0 || num3 > Main.screenWidth)
						{
							num4 += Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
						}
						num3 += (int)Main.screenPosition.X;
						int num5 = Dust.NewDust(new Vector2((float)num3, (float)num4), 10, 10, 76, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
						Main.dust[num5].velocity.Y = 3f + (float)Main.rand.Next(30) * 0.1f;
						Dust dust = Main.dust[num5];
						dust.velocity.Y = dust.velocity.Y * Main.dust[num5].scale;
						Main.dust[num5].velocity.X = Main.windSpeed + (float)Main.rand.Next(-10, 10) * 0.1f;
					}
				}
			}
		}

		public static void checkXMas()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			if (day >= 15 && month == 12)
			{
				Main.xMas = true;
			}
			else
			{
				Main.xMas = false;
			}
		}

		protected override void Update(GameTime gameTime)
		{
			if (Main.netMode != 2)
			{
				Main.snowing();
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			WorldGen.destroyObject = false;
			if (!Main.dedServ)
			{
				if (Main.fixedTiming)
				{
					if (base.IsActive)
					{
						base.IsFixedTimeStep = false;
					}
					else
					{
						base.IsFixedTimeStep = true;
					}
				}
				else
				{
					base.IsFixedTimeStep = true;
				}
				this.graphics.SynchronizeWithVerticalRetrace = true;
				this.UpdateMusic();
				if (Main.showSplash)
				{
					return;
				}
				if (!Main.gameMenu && Main.netMode == 1)
				{
					if (!Main.saveTime.IsRunning)
					{
						Main.saveTime.Start();
					}
					if (Main.saveTime.ElapsedMilliseconds > 300000L)
					{
						Main.saveTime.Reset();
						WorldGen.saveToonWhilePlaying();
					}
				}
				else if (!Main.gameMenu && Main.autoSave)
				{
					if (!Main.saveTime.IsRunning)
					{
						Main.saveTime.Start();
					}
					if (Main.saveTime.ElapsedMilliseconds > 600000L)
					{
						Main.saveTime.Reset();
						WorldGen.saveToonWhilePlaying();
						WorldGen.saveAndPlay();
					}
				}
				else if (Main.saveTime.IsRunning)
				{
					Main.saveTime.Stop();
				}
				if (Main.teamCooldown > 0)
				{
					Main.teamCooldown--;
				}
				Main.updateTime++;
				if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
				{
					if ((float)Main.fpsCount >= 30f + 30f * Main.gfxQuality)
					{
						Main.gfxQuality += Main.gfxRate;
						Main.gfxRate += 0.005f;
					}
					else if ((float)Main.fpsCount < 29f + 30f * Main.gfxQuality)
					{
						Main.gfxRate = 0.01f;
						Main.gfxQuality -= 0.1f;
					}
					if (Main.gfxQuality < 0f)
					{
						Main.gfxQuality = 0f;
					}
					if (Main.gfxQuality > 1f)
					{
						Main.gfxQuality = 1f;
					}
					if (Main.maxQ && base.IsActive)
					{
						Main.gfxQuality = 1f;
						Main.maxQ = false;
					}
					Main.updateRate = Main.uCount;
					Main.frameRate = Main.fpsCount;
					Main.fpsCount = 0;
					Main.fpsTimer.Restart();
					Main.updateTime = 0;
					Main.drawTime = 0;
					Main.uCount = 0;
					if (Main.netMode == 2)
					{
						Main.cloudLimit = 0;
					}
				}
				if (Main.fixedTiming)
				{
					float num = 16f;
					float num2 = (float)Main.updateTimer.ElapsedMilliseconds;
					if (num2 + Main.uCarry < num)
					{
						Main.drawSkip = true;
						return;
					}
					Main.uCarry += num2 - num;
					if (Main.uCarry > 1000f)
					{
						Main.uCarry = 1000f;
					}
					Main.updateTimer.Restart();
				}
				Main.uCount++;
				Main.drawSkip = false;
				if (Main.qaStyle == 1)
				{
					Main.gfxQuality = 1f;
				}
				else if (Main.qaStyle == 2)
				{
					Main.gfxQuality = 0.5f;
				}
				else if (Main.qaStyle == 3)
				{
					Main.gfxQuality = 0f;
				}
				Main.numDust = (int)(2000f * (Main.gfxQuality * 0.75f + 0.25f));
				Gore.goreTime = (int)(600f * Main.gfxQuality);
				Main.cloudLimit = (int)(100f * Main.gfxQuality);
				Liquid.maxLiquid = (int)(2500f + 2500f * Main.gfxQuality);
				Liquid.cycles = (int)(17f - 10f * Main.gfxQuality);
				if ((double)Main.gfxQuality < 0.5)
				{
					this.graphics.SynchronizeWithVerticalRetrace = false;
				}
				else
				{
					this.graphics.SynchronizeWithVerticalRetrace = true;
				}
				if ((double)Main.gfxQuality < 0.2)
				{
					Lighting.maxRenderCount = 8;
				}
				else if ((double)Main.gfxQuality < 0.4)
				{
					Lighting.maxRenderCount = 7;
				}
				else if ((double)Main.gfxQuality < 0.6)
				{
					Lighting.maxRenderCount = 6;
				}
				else if ((double)Main.gfxQuality < 0.8)
				{
					Lighting.maxRenderCount = 5;
				}
				else
				{
					Lighting.maxRenderCount = 4;
				}
				if (Liquid.quickSettle)
				{
					Liquid.maxLiquid = Liquid.resLiquid;
					Liquid.cycles = 1;
				}
				if (!base.IsActive)
				{
					Main.hasFocus = false;
				}
				else
				{
					Main.hasFocus = true;
				}
				if (!base.IsActive && Main.netMode == 0)
				{
					base.IsMouseVisible = true;
					if (Main.netMode != 2 && Main.myPlayer >= 0)
					{
						Main.player[Main.myPlayer].delayUseItem = true;
					}
					Main.mouseLeftRelease = false;
					Main.mouseRightRelease = false;
					if (Main.gameMenu)
					{
						Main.UpdateMenu();
					}
					Main.gamePaused = true;
					return;
				}
				base.IsMouseVisible = false;
				Main.demonTorch += (float)Main.demonTorchDir * 0.01f;
				if (Main.demonTorch > 1f)
				{
					Main.demonTorch = 1f;
					Main.demonTorchDir = -1;
				}
				if (Main.demonTorch < 0f)
				{
					Main.demonTorch = 0f;
					Main.demonTorchDir = 1;
				}
				int num3 = 7;
				if (this.DiscoStyle == 0)
				{
					Main.DiscoG += num3;
					if (Main.DiscoG >= 255)
					{
						Main.DiscoG = 255;
						this.DiscoStyle++;
					}
					Main.DiscoR -= num3;
					if (Main.DiscoR <= 0)
					{
						Main.DiscoR = 0;
					}
				}
				else if (this.DiscoStyle == 1)
				{
					Main.DiscoB += num3;
					if (Main.DiscoB >= 255)
					{
						Main.DiscoB = 255;
						this.DiscoStyle++;
					}
					Main.DiscoG -= num3;
					if (Main.DiscoG <= 0)
					{
						Main.DiscoG = 0;
					}
				}
				else
				{
					Main.DiscoR += num3;
					if (Main.DiscoR >= 255)
					{
						Main.DiscoR = 255;
						this.DiscoStyle = 0;
					}
					Main.DiscoB -= num3;
					if (Main.DiscoB <= 0)
					{
						Main.DiscoB = 0;
					}
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F10) && !Main.chatMode && !Main.editSign)
				{
					if (Main.frameRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.showFrameRate)
						{
							Main.showFrameRate = false;
						}
						else
						{
							Main.showFrameRate = true;
						}
					}
					Main.frameRelease = false;
				}
				else
				{
					Main.frameRelease = true;
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F9) && !Main.chatMode && !Main.editSign)
				{
					if (Main.RGBRelease)
					{
						Lighting.lightCounter += 100;
						Main.PlaySound(12, -1, -1, 1);
						Lighting.lightMode++;
						if (Lighting.lightMode >= 4)
						{
							Lighting.lightMode = 0;
						}
						if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
						{
							Main.renderCount = 0;
							Main.renderNow = true;
							int num4 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
							int num5 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
							for (int i = 0; i < num4; i++)
							{
								for (int j = 0; j < num5; j++)
								{
									Lighting.color[i, j] = 0f;
									Lighting.colorG[i, j] = 0f;
									Lighting.colorB[i, j] = 0f;
								}
							}
						}
					}
					Main.RGBRelease = false;
				}
				else
				{
					Main.RGBRelease = true;
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F8) && !Main.chatMode && !Main.editSign)
				{
					if (Main.netRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.netDiag)
						{
							Main.netDiag = false;
						}
						else
						{
							Main.netDiag = true;
						}
					}
					Main.netRelease = false;
				}
				else
				{
					Main.netRelease = true;
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7) && !Main.chatMode && !Main.editSign)
				{
					if (Main.drawRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.drawDiag)
						{
							Main.drawDiag = false;
						}
						else
						{
							Main.drawDiag = true;
						}
					}
					Main.drawRelease = false;
				}
				else
				{
					Main.drawRelease = true;
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F11))
				{
					if (Main.releaseUI)
					{
						if (Main.hideUI)
						{
							Main.hideUI = false;
						}
						else
						{
							Main.hideUI = true;
						}
					}
					Main.releaseUI = false;
				}
				else
				{
					Main.releaseUI = true;
				}
				if ((Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt) || Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt)) && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
				{
					if (this.toggleFullscreen)
					{
						this.graphics.ToggleFullScreen();
						Main.chatRelease = false;
					}
					this.toggleFullscreen = false;
				}
				else
				{
					this.toggleFullscreen = true;
				}
				if (!Main.gamePad || Main.gameMenu)
				{
					Main.oldMouseState = Main.mouseState;
					Main.mouseState = Mouse.GetState();
					Main.mouseX = Main.mouseState.X;
					Main.mouseY = Main.mouseState.Y;
					Main.mouseLeft = false;
					Main.mouseRight = false;
					if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
					{
						Main.mouseLeft = true;
					}
					if (Main.mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
					{
						Main.mouseRight = true;
					}
				}
				Main.keyState = Keyboard.GetState();
				if (Main.editSign)
				{
					Main.chatMode = false;
				}
				if (Main.chatMode)
				{
					if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
					{
						Main.chatMode = false;
					}
					string a = Main.chatText;
					Main.chatText = Main.GetInputText(Main.chatText);
					while (Main.fontMouseText.MeasureString(Main.chatText).X > 470f)
					{
						Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
					}
					if (a != Main.chatText)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					if (Main.inputTextEnter && Main.chatRelease)
					{
						if (Main.chatText != "")
						{
							NetMessage.SendData(25, -1, -1, Main.chatText, Main.myPlayer, 0f, 0f, 0f, 0);
						}
						Main.chatText = "";
						Main.chatMode = false;
						Main.chatRelease = false;
						Main.player[Main.myPlayer].releaseHook = false;
						Main.player[Main.myPlayer].releaseThrow = false;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && Main.netMode == 1 && !Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt) && !Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt))
				{
					if (Main.chatRelease && !Main.chatMode && !Main.editSign && !Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.chatMode = true;
						Main.chatText = "";
						if (!Main.isChatFormOpen && !Main.gameMenu)
						{
							Steam.CallInputForm();
						}
					}
					Main.chatRelease = false;
				}
				else
				{
					Main.chatRelease = true;
				}
				if (Main.gameMenu)
				{
					Main.UpdateMenu();
					if (Main.netMode != 2)
					{
						return;
					}
					Main.gamePaused = false;
				}
			}
			if (Main.netMode == 1)
			{
				for (int k = 0; k < 49; k++)
				{
					if (Main.player[Main.myPlayer].inventory[k].IsNotTheSameAs(Main.clientPlayer.inventory[k]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
					}
				}
				if (Main.player[Main.myPlayer].armor[0].IsNotTheSameAs(Main.clientPlayer.armor[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[1].IsNotTheSameAs(Main.clientPlayer.armor[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[2].IsNotTheSameAs(Main.clientPlayer.armor[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[3].IsNotTheSameAs(Main.clientPlayer.armor[3]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[4].IsNotTheSameAs(Main.clientPlayer.armor[4]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[5].IsNotTheSameAs(Main.clientPlayer.armor[5]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[6].IsNotTheSameAs(Main.clientPlayer.armor[6]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[7].IsNotTheSameAs(Main.clientPlayer.armor[7]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[8].IsNotTheSameAs(Main.clientPlayer.armor[8]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[9].IsNotTheSameAs(Main.clientPlayer.armor[9]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[10].IsNotTheSameAs(Main.clientPlayer.armor[10]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest)
				{
					NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
				{
					NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneEvil != Main.clientPlayer.zoneEvil)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneMeteor != Main.clientPlayer.zoneMeteor)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneDungeon != Main.clientPlayer.zoneDungeon)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneJungle != Main.clientPlayer.zoneJungle)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneHoly != Main.clientPlayer.zoneHoly)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				bool flag = false;
				for (int l = 0; l < 10; l++)
				{
					if (Main.player[Main.myPlayer].buffType[l] != Main.clientPlayer.buffType[l])
					{
						flag = true;
					}
				}
				if (flag)
				{
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
			}
			if (Main.netMode == 1)
			{
				Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			}
			if (Main.netMode == 0 && (Main.playerInventory || Main.npcChatText != "" || Main.player[Main.myPlayer].sign >= 0) && Main.autoPause)
			{
				Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				Main.player[Main.myPlayer].controlInv = false;
				for (int m = 0; m < pressedKeys.Length; m++)
				{
					string a2 = string.Concat(pressedKeys[m]);
					if (a2 == Main.cInv)
					{
						Main.player[Main.myPlayer].controlInv = true;
					}
				}
				if (Main.player[Main.myPlayer].controlInv)
				{
					if (Main.player[Main.myPlayer].releaseInventory)
					{
						Main.player[Main.myPlayer].toggleInv();
					}
					Main.player[Main.myPlayer].releaseInventory = false;
				}
				else
				{
					Main.player[Main.myPlayer].releaseInventory = true;
				}
				if (Main.playerInventory)
				{
					int num6 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
					Main.focusRecipe += num6;
					if (Main.focusRecipe > Main.numAvailableRecipes - 1)
					{
						Main.focusRecipe = Main.numAvailableRecipes - 1;
					}
					if (Main.focusRecipe < 0)
					{
						Main.focusRecipe = 0;
					}
					Main.player[Main.myPlayer].dropItemCheck();
				}
				Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[0].headSlot;
				Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[1].bodySlot;
				Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[2].legSlot;
				if (!Main.player[Main.myPlayer].hostile)
				{
					if (Main.player[Main.myPlayer].armor[8].headSlot >= 0)
					{
						Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[8].headSlot;
					}
					if (Main.player[Main.myPlayer].armor[9].bodySlot >= 0)
					{
						Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[9].bodySlot;
					}
					if (Main.player[Main.myPlayer].armor[10].legSlot >= 0)
					{
						Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[10].legSlot;
					}
				}
				if (Main.editSign)
				{
					if (Main.player[Main.myPlayer].sign == -1)
					{
						Main.editSign = false;
					}
					else
					{
						Main.npcChatText = Main.GetInputText(Main.npcChatText);
						if (Main.inputTextEnter)
						{
							byte[] bytes = new byte[]
							{
								10
							};
							Main.npcChatText += Encoding.UTF8.GetString(bytes);
						}
					}
				}
				Main.gamePaused = true;
			}
			else
			{
				Main.gamePaused = false;
				if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
				{
					Star.UpdateStars();
					Cloud.UpdateClouds();
				}
				int n = 0;
				while (n < 255)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							Main.player[n].UpdatePlayer(n);
							goto IL_1AB6;
						}
						catch
						{
							goto IL_1AB6;
						}
						goto IL_1AB4;
					}
					goto IL_1AB4;
					IL_1AB6:
					n++;
					continue;
					IL_1AB4:
					Main.player[n].UpdatePlayer(n);
					goto IL_1AB6;
				}
				if (Main.netMode != 1)
				{
					NPC.SpawnNPC();
				}
				for (int num7 = 0; num7 < 255; num7++)
				{
					Main.player[num7].activeNPCs = 0f;
					Main.player[num7].townNPCs = 0f;
				}
				if (Main.wof >= 0 && !Main.npc[Main.wof].active)
				{
					Main.wof = -1;
				}
				int num8 = 0;
				while (num8 < 200)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							Main.npc[num8].UpdateNPC(num8);
							goto IL_1B9A;
						}
						catch (Exception)
						{
							Main.npc[num8] = new NPC();
							goto IL_1B9A;
						}
						goto IL_1B98;
					}
					goto IL_1B98;
					IL_1B9A:
					num8++;
					continue;
					IL_1B98:
					Main.npc[num8].UpdateNPC(num8);
					goto IL_1B9A;
				}
				int num9 = 0;
				while (num9 < 200)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							Main.gore[num9].Update();
							goto IL_1BFD;
						}
						catch
						{
							Main.gore[num9] = new Gore();
							goto IL_1BFD;
						}
						goto IL_1BFB;
					}
					goto IL_1BFB;
					IL_1BFD:
					num9++;
					continue;
					IL_1BFB:
					Main.gore[num9].Update();
					goto IL_1BFD;
				}
				int num10 = 0;
				while (num10 < 1000)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							Main.projectile[num10].Update(num10);
							goto IL_1C60;
						}
						catch
						{
							Main.projectile[num10] = new Projectile();
							goto IL_1C60;
						}
						goto IL_1C5E;
					}
					goto IL_1C5E;
					IL_1C60:
					num10++;
					continue;
					IL_1C5E:
					Main.projectile[num10].Update(num10);
					goto IL_1C60;
				}
				int num11 = 0;
				while (num11 < 200)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							Main.item[num11].UpdateItem(num11);
							goto IL_1CC5;
						}
						catch
						{
							Main.item[num11] = new Item();
							goto IL_1CC5;
						}
						goto IL_1CC3;
					}
					goto IL_1CC3;
					IL_1CC5:
					num11++;
					continue;
					IL_1CC3:
					Main.item[num11].UpdateItem(num11);
					goto IL_1CC5;
				}
				if (Main.ignoreErrors)
				{
					try
					{
						Dust.UpdateDust();
						goto IL_1D3A;
					}
					catch
					{
						for (int num12 = 0; num12 < 2000; num12++)
						{
							Main.dust[num12] = new Dust();
						}
						goto IL_1D3A;
					}
				}
				Dust.UpdateDust();
				IL_1D3A:
				if (Main.netMode != 2)
				{
					CombatText.UpdateCombatText();
					ItemText.UpdateItemText();
				}
				if (Main.ignoreErrors)
				{
					try
					{
						Main.UpdateTime();
						goto IL_1D7F;
					}
					catch
					{
						Main.checkForSpawns = 0;
						goto IL_1D7F;
					}
				}
				Main.UpdateTime();
				IL_1D7F:
				if (Main.netMode != 1)
				{
					if (Main.ignoreErrors)
					{
						try
						{
							WorldGen.UpdateWorld();
							Main.UpdateInvasion();
							goto IL_1DBE;
						}
						catch
						{
							goto IL_1DBE;
						}
					}
					WorldGen.UpdateWorld();
					Main.UpdateInvasion();
				}
				IL_1DBE:
				if (Main.ignoreErrors)
				{
					try
					{
						if (Main.netMode == 2)
						{
							Main.UpdateServer();
						}
						if (Main.netMode == 1)
						{
							Main.UpdateClient();
						}
						goto IL_1E30;
					}
					catch
					{
						int num13 = Main.netMode;
						goto IL_1E30;
					}
				}
				if (Main.netMode == 2)
				{
					Main.UpdateServer();
				}
				if (Main.netMode == 1)
				{
					Main.UpdateClient();
				}
				IL_1E30:
				if (Main.ignoreErrors)
				{
					try
					{
						for (int num14 = 0; num14 < Main.numChatLines; num14++)
						{
							if (Main.chatLine[num14].showTime > 0)
							{
								Main.chatLine[num14].showTime--;
							}
						}
						goto IL_1EBE;
					}
					catch
					{
						for (int num15 = 0; num15 < Main.numChatLines; num15++)
						{
							Main.chatLine[num15] = new ChatLine();
						}
						goto IL_1EBE;
					}
				}
				for (int num16 = 0; num16 < Main.numChatLines; num16++)
				{
					if (Main.chatLine[num16].showTime > 0)
					{
						Main.chatLine[num16].showTime--;
					}
				}
				IL_1EBE:
				Main.upTimer = (float)stopwatch.ElapsedMilliseconds;
				if (Main.upTimerMaxDelay > 0f)
				{
					Main.upTimerMaxDelay -= 1f;
				}
				else
				{
					Main.upTimerMax = 0f;
				}
				if (Main.upTimer > Main.upTimerMax)
				{
					Main.upTimerMax = Main.upTimer;
					Main.upTimerMaxDelay = 400f;
				}
				base.Update(gameTime);
			}
		}

		private static void UpdateMenu()
		{
			Main.playerInventory = false;
			Main.exitScale = 0.8f;
			if (Main.netMode == 0)
			{
				if (!Main.grabSky)
				{
					Main.time += 86.4;
					if (!Main.dayTime)
					{
						if (Main.time > 32400.0)
						{
							Main.bloodMoon = false;
							Main.time = 0.0;
							Main.dayTime = true;
							Main.moonPhase++;
							if (Main.moonPhase >= 8)
							{
								Main.moonPhase = 0;
							}
						}
					}
					else if (Main.time > 54000.0)
					{
						Main.time = 0.0;
						Main.dayTime = false;
					}
				}
			}
			else if (Main.netMode == 1)
			{
				Main.UpdateTime();
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern short GetKeyState(int keyCode);

		public static string GetInputText(string oldString)
		{
			string result;
			if (!Main.hasFocus)
			{
				result = oldString;
			}
			else
			{
				Main.inputTextEnter = false;
				string text = oldString;
				if (text == null)
				{
					text = "";
				}
				Main.oldInputText = Main.inputText;
				Main.inputText = Keyboard.GetState();
				bool flag = ((ushort)Main.GetKeyState(20) & 65535) != 0;
				bool flag2 = false;
				if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift))
				{
					flag2 = true;
				}
				Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.inputText.GetPressedKeys();
				Microsoft.Xna.Framework.Input.Keys[] pressedKeys2 = Main.oldInputText.GetPressedKeys();
				bool flag3 = false;
				if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back) && Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back))
				{
					if (Main.backSpaceCount == 0)
					{
						Main.backSpaceCount = 7;
						flag3 = true;
					}
					Main.backSpaceCount--;
				}
				else
				{
					Main.backSpaceCount = 15;
				}
				for (int i = 0; i < pressedKeys.Length; i++)
				{
					bool flag4 = true;
					for (int j = 0; j < pressedKeys2.Length; j++)
					{
						if (pressedKeys[i] == pressedKeys2[j])
						{
							flag4 = false;
						}
					}
					string text2 = string.Concat(pressedKeys[i]);
					if (text2 == "Back" && (flag4 || flag3))
					{
						if (text.Length > 0)
						{
							text = text.Substring(0, text.Length - 1);
						}
					}
					else if (flag4)
					{
						if (text2 == "Space")
						{
							text2 = " ";
						}
						else if (text2 == "Insert")
						{
							IDataObject dataObject = Clipboard.GetDataObject();
							if (dataObject.GetDataPresent(DataFormats.Text) | dataObject.GetDataPresent(DataFormats.OemText))
							{
								string text3 = (string)dataObject.GetData(DataFormats.Text);
								text3 = text3.Replace('\r', '\0').Replace('\n', '\0');
								text += text3;
							}
						}
						else if (text2.Length == 1)
						{
							char c = Convert.ToChar(text2);
							int num = Convert.ToInt32(c);
							if (num >= 65 && num <= 90 && ((!flag2 && !flag) || (flag2 && flag)))
							{
								num += 32;
								c = Convert.ToChar(num);
								text2 = string.Concat(c);
							}
						}
						else if (text2.Length == 2 && text2.Substring(0, 1) == "D")
						{
							text2 = text2.Substring(1, 1);
							if (flag2)
							{
								if (text2 == "1")
								{
									text2 = "!";
								}
								if (text2 == "2")
								{
									text2 = "@";
								}
								if (text2 == "3")
								{
									text2 = "#";
								}
								if (text2 == "4")
								{
									text2 = "$";
								}
								if (text2 == "5")
								{
									text2 = "%";
								}
								if (text2 == "6")
								{
									text2 = "^";
								}
								if (text2 == "7")
								{
									text2 = "&";
								}
								if (text2 == "8")
								{
									text2 = "*";
								}
								if (text2 == "9")
								{
									text2 = "(";
								}
								if (text2 == "0")
								{
									text2 = ")";
								}
							}
						}
						else if (text2.Length == 7 && text2.Substring(0, 6) == "NumPad")
						{
							text2 = text2.Substring(6, 1);
						}
						else if (text2 == "Divide")
						{
							text2 = "/";
						}
						else if (text2 == "Multiply")
						{
							text2 = "*";
						}
						else if (text2 == "Subtract")
						{
							text2 = "-";
						}
						else if (text2 == "Add")
						{
							text2 = "+";
						}
						else if (text2 == "Decimal")
						{
							text2 = ".";
						}
						else
						{
							if (text2 == "OemSemicolon")
							{
								text2 = ";";
							}
							else if (text2 == "OemPlus")
							{
								text2 = "=";
							}
							else if (text2 == "OemComma")
							{
								text2 = ",";
							}
							else if (text2 == "OemMinus")
							{
								text2 = "-";
							}
							else if (text2 == "OemPeriod")
							{
								text2 = ".";
							}
							else if (text2 == "OemQuestion")
							{
								text2 = "/";
							}
							else if (text2 == "OemTilde")
							{
								text2 = "`";
							}
							else if (text2 == "OemOpenBrackets")
							{
								text2 = "[";
							}
							else if (text2 == "OemPipe")
							{
								text2 = "\\";
							}
							else if (text2 == "OemCloseBrackets")
							{
								text2 = "]";
							}
							else if (text2 == "OemQuotes")
							{
								text2 = "'";
							}
							else if (text2 == "OemBackslash")
							{
								text2 = "\\";
							}
							if (flag2)
							{
								if (text2 == ";")
								{
									text2 = ":";
								}
								else if (text2 == "=")
								{
									text2 = "+";
								}
								else if (text2 == ",")
								{
									text2 = "<";
								}
								else if (text2 == "-")
								{
									text2 = "_";
								}
								else if (text2 == ".")
								{
									text2 = ">";
								}
								else if (text2 == "/")
								{
									text2 = "?";
								}
								else if (text2 == "`")
								{
									text2 = "~";
								}
								else if (text2 == "[")
								{
									text2 = "{";
								}
								else if (text2 == "\\")
								{
									text2 = "|";
								}
								else if (text2 == "]")
								{
									text2 = "}";
								}
								else if (text2 == "'")
								{
									text2 = "\"";
								}
							}
						}
						if (text2 == "Enter")
						{
							Main.inputTextEnter = true;
						}
						if (text2.Length == 1)
						{
							text += text2;
						}
					}
				}
				result = text;
			}
			return result;
		}

		protected void MouseText(string cursorText, int rare = 0, byte diff = 0)
		{
			if (this.mouseNPC <= -1)
			{
				if (cursorText != null)
				{
					int num = Main.mouseX + 10;
					int num2 = Main.mouseY + 10;
					Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					if (Main.toolTip.type > 0)
					{
						if (Main.player[Main.myPlayer].kbGlove)
						{
							Main.toolTip.knockBack *= 1.7f;
						}
						rare = Main.toolTip.rare;
						int num3 = 20;
						int num4 = 1;
						string[] array = new string[num3];
						bool[] array2 = new bool[num3];
						bool[] array3 = new bool[num3];
						for (int i = 0; i < num3; i++)
						{
							array2[i] = false;
							array3[i] = false;
						}
						array[0] = Main.toolTip.AffixName();
						if (Main.toolTip.stack > 1)
						{
							string[] array5;
							string[] array4 = array5 = array;
							int num5 = 0;
							object obj = array4[0];
							array5[num5] = string.Concat(new object[]
							{
								obj,
								" (",
								Main.toolTip.stack,
								")"
							});
						}
						if (Main.toolTip.social)
						{
							array[num4] = "装备于时装栏";
							num4++;
							array[num4] = "无法获取属性";
							num4++;
						}
						else
						{
							if (Main.toolTip.damage > 0)
							{
								int damage = Main.toolTip.damage;
								if (Main.toolTip.melee)
								{
									array[num4] = string.Concat((int)(Main.player[Main.myPlayer].meleeDamage * (float)damage));
									string[] array6;
									IntPtr value;
									(array6 = array)[(int)(value = (IntPtr)num4)] = array6[(int)value] + " 点近战";
								}
								else if (Main.toolTip.ranged)
								{
									array[num4] = string.Concat((int)(Main.player[Main.myPlayer].rangedDamage * (float)damage));
									string[] array7;
									IntPtr value2;
									(array7 = array)[(int)(value2 = (IntPtr)num4)] = array7[(int)value2] + " 点远程";
								}
								else if (Main.toolTip.magic)
								{
									array[num4] = string.Concat((int)(Main.player[Main.myPlayer].magicDamage * (float)damage));
									string[] array8;
									IntPtr value3;
									(array8 = array)[(int)(value3 = (IntPtr)num4)] = array8[(int)value3] + " 点魔法";
								}
								else
								{
									array[num4] = string.Concat(damage);
								}
								string[] array9;
								IntPtr value4;
								(array9 = array)[(int)(value4 = (IntPtr)num4)] = array9[(int)value4] + "伤害";
								num4++;
								if (Main.toolTip.melee)
								{
									int num6 = Main.player[Main.myPlayer].meleeCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
									array[num4] = num6 + "% 暴击率";
									num4++;
								}
								else if (Main.toolTip.ranged)
								{
									int num7 = Main.player[Main.myPlayer].rangedCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
									array[num4] = num7 + "% 暴击率";
									num4++;
								}
								else if (Main.toolTip.magic)
								{
									int num8 = Main.player[Main.myPlayer].magicCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
									array[num4] = num8 + "% 暴击率";
									num4++;
								}
								if (Main.toolTip.useStyle > 0)
								{
									if (Main.toolTip.useAnimation <= 8)
									{
										array[num4] = "疯狂";
									}
									else if (Main.toolTip.useAnimation <= 20)
									{
										array[num4] = "很快";
									}
									else if (Main.toolTip.useAnimation <= 25)
									{
										array[num4] = "快";
									}
									else if (Main.toolTip.useAnimation <= 30)
									{
										array[num4] = "常规";
									}
									else if (Main.toolTip.useAnimation <= 35)
									{
										array[num4] = "慢";
									}
									else if (Main.toolTip.useAnimation <= 45)
									{
										array[num4] = "很慢";
									}
									else if (Main.toolTip.useAnimation <= 55)
									{
										array[num4] = "极慢";
									}
									else
									{
										array[num4] = "蜗牛";
									}
									string[] array10;
									IntPtr value5;
									(array10 = array)[(int)(value5 = (IntPtr)num4)] = "攻速:" + array10[(int)value5];
									num4++;
								}
								if (Main.toolTip.knockBack == 0f)
								{
									array[num4] = "无";
								}
								else if ((double)Main.toolTip.knockBack <= 1.5)
								{
									array[num4] = "极弱";
								}
								else if (Main.toolTip.knockBack <= 3f)
								{
									array[num4] = "很弱";
								}
								else if (Main.toolTip.knockBack <= 4f)
								{
									array[num4] = "较弱";
								}
								else if (Main.toolTip.knockBack <= 6f)
								{
									array[num4] = "常规";
								}
								else if (Main.toolTip.knockBack <= 7f)
								{
									array[num4] = "较强";
								}
								else if (Main.toolTip.knockBack <= 9f)
								{
									array[num4] = "很强";
								}
								else if (Main.toolTip.knockBack <= 11f)
								{
									array[num4] = "极强";
								}
								else
								{
									array[num4] = "不可思议";
								}
								string[] array11;
								IntPtr value6;
								(array11 = array)[(int)(value6 = (IntPtr)num4)] = "击退威力:" + array11[(int)value6];
								num4++;
							}
							if (Main.toolTip.headSlot > 0 || Main.toolTip.bodySlot > 0 || Main.toolTip.legSlot > 0 || Main.toolTip.accessory)
							{
								array[num4] = "可装备";
								num4++;
							}
							if (Main.toolTip.vanity)
							{
								array[num4] = "时装";
								num4++;
							}
							if (Main.toolTip.defense > 0)
							{
								array[num4] = Main.toolTip.defense + "点防御";
								num4++;
							}
							if (Main.toolTip.pick > 0)
							{
								array[num4] = Main.toolTip.pick + "% 挖掘威力";
								num4++;
							}
							if (Main.toolTip.axe > 0)
							{
								array[num4] = Main.toolTip.axe * 5 + "% 砍伐威力";
								num4++;
							}
							if (Main.toolTip.hammer > 0)
							{
								array[num4] = Main.toolTip.hammer + "% 敲碎威力";
								num4++;
							}
							if (Main.toolTip.healLife > 0)
							{
								array[num4] = "补充" + Main.toolTip.healLife + "点生命";
								num4++;
							}
							if (Main.toolTip.healMana > 0)
							{
								array[num4] = "补充" + Main.toolTip.healMana + "点魔力";
								num4++;
							}
							if (Main.toolTip.mana > 0 && (Main.toolTip.type != 127 || !Main.player[Main.myPlayer].spaceGun))
							{
								array[num4] = "消耗 " + (int)((float)Main.toolTip.mana * Main.player[Main.myPlayer].manaCost) + " 点魔力";
								num4++;
							}
							if (Main.toolTip.createWall > 0 || Main.toolTip.createTile > -1)
							{
								if (Main.toolTip.type != 213)
								{
									array[num4] = "可放置";
									num4++;
								}
							}
							else if (Main.toolTip.ammo > 0)
							{
								array[num4] = "弹药";
								num4++;
							}
							else if (Main.toolTip.consumable)
							{
								array[num4] = "消耗品";
								num4++;
							}
							if (Main.toolTip.material)
							{
								array[num4] = "材料";
								num4++;
							}
							if (Main.toolTip.toolTip != null)
							{
								array[num4] = Main.toolTip.toolTip;
								num4++;
							}
							if (Main.toolTip.toolTip2 != null)
							{
								array[num4] = Main.toolTip.toolTip2;
								num4++;
							}
							if (Main.toolTip.buffTime > 0)
							{
								string text;
								if (Main.toolTip.buffTime / 60 >= 60)
								{
									text = Math.Round((double)(Main.toolTip.buffTime / 60) / 60.0) + " 分持续时间";
								}
								else
								{
									text = Math.Round((double)Main.toolTip.buffTime / 60.0) + " 秒持续时间";
								}
								array[num4] = text;
								num4++;
							}
							if (Main.toolTip.prefix > 0)
							{
								if (Main.cpItem == null || Main.cpItem.name != Main.toolTip.name)
								{
									Main.cpItem = new Item();
									Main.cpItem.SetDefaults(Main.toolTip.name);
								}
								if (Main.cpItem.damage != Main.toolTip.damage)
								{
									double num9 = (double)((float)Main.toolTip.damage - (float)Main.cpItem.damage);
									num9 = num9 / (double)((float)Main.cpItem.damage) * 100.0;
									num9 = Math.Round(num9);
									if (num9 > 0.0)
									{
										array[num4] = "+" + num9 + "% 伤害";
									}
									else
									{
										array[num4] = num9 + "% 伤害";
									}
									if (num9 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.useAnimation != Main.toolTip.useAnimation)
								{
									double num10 = (double)((float)Main.toolTip.useAnimation - (float)Main.cpItem.useAnimation);
									num10 = num10 / (double)((float)Main.cpItem.useAnimation) * 100.0;
									num10 = Math.Round(num10);
									num10 *= -1.0;
									if (num10 > 0.0)
									{
										array[num4] = "+" + num10 + "% 攻速";
									}
									else
									{
										array[num4] = num10 + "% 攻速";
									}
									if (num10 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.crit != Main.toolTip.crit)
								{
									double num11 = (double)((float)Main.toolTip.crit - (float)Main.cpItem.crit);
									if (num11 > 0.0)
									{
										array[num4] = "+" + num11 + "% 暴击率";
									}
									else
									{
										array[num4] = num11 + "% 暴击率";
									}
									if (num11 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.mana != Main.toolTip.mana)
								{
									double num12 = (double)((float)Main.toolTip.mana - (float)Main.cpItem.mana);
									num12 = num12 / (double)((float)Main.cpItem.mana) * 100.0;
									num12 = Math.Round(num12);
									if (num12 > 0.0)
									{
										array[num4] = "+" + num12 + "% 魔力消耗";
									}
									else
									{
										array[num4] = num12 + "% 魔力消耗";
									}
									if (num12 > 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.scale != Main.toolTip.scale)
								{
									double num13 = (double)(Main.toolTip.scale - Main.cpItem.scale);
									num13 = num13 / (double)Main.cpItem.scale * 100.0;
									num13 = Math.Round(num13);
									if (num13 > 0.0)
									{
										array[num4] = "+" + num13 + "% 体积";
									}
									else
									{
										array[num4] = num13 + "% 体积";
									}
									if (num13 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.shootSpeed != Main.toolTip.shootSpeed)
								{
									double num14 = (double)(Main.toolTip.shootSpeed - Main.cpItem.shootSpeed);
									num14 = num14 / (double)Main.cpItem.shootSpeed * 100.0;
									num14 = Math.Round(num14);
									if (num14 > 0.0)
									{
										array[num4] = "+" + num14 + "% 弹药初速";
									}
									else
									{
										array[num4] = num14 + "% 弹药初速";
									}
									if (num14 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.cpItem.knockBack != Main.toolTip.knockBack)
								{
									double num15 = (double)(Main.toolTip.knockBack - Main.cpItem.knockBack);
									num15 = num15 / (double)Main.cpItem.knockBack * 100.0;
									num15 = Math.Round(num15);
									if (num15 > 0.0)
									{
										array[num4] = "+" + num15 + "% 击退";
									}
									else
									{
										array[num4] = num15 + "% 击退";
									}
									if (num15 < 0.0)
									{
										array3[num4] = true;
									}
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 62)
								{
									array[num4] = "+1 防御";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 63)
								{
									array[num4] = "+2 防御";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 64)
								{
									array[num4] = "+3 防御";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 65)
								{
									array[num4] = "+4 防御";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 66)
								{
									array[num4] = "+20 魔力";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 67)
								{
									array[num4] = "+1% 暴击率";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 68)
								{
									array[num4] = "+2% 暴击率";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 69)
								{
									array[num4] = "+1% 伤害";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 70)
								{
									array[num4] = "+2% 伤害";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 71)
								{
									array[num4] = "+3% 伤害";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 72)
								{
									array[num4] = "+4% 伤害";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 73)
								{
									array[num4] = "+1% 移动速度";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 74)
								{
									array[num4] = "+2% 移动速度";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 75)
								{
									array[num4] = "+3% 移动速度";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 76)
								{
									array[num4] = "+4% 移动速度";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 77)
								{
									array[num4] = "+1% 近战攻速";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 78)
								{
									array[num4] = "+2% 近战攻速";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 79)
								{
									array[num4] = "+3% 近战攻速";
									array2[num4] = true;
									num4++;
								}
								if (Main.toolTip.prefix == 80)
								{
									array[num4] = "+4% 近战攻速";
									array2[num4] = true;
									num4++;
								}
							}
							if (Main.toolTip.wornArmor && Main.player[Main.myPlayer].setBonus != "")
							{
								array[num4] = "套装奖励: " + Main.player[Main.myPlayer].setBonus;
								num4++;
							}
						}
						float num21;
						if (Main.npcShop > 0)
						{
							if (Main.toolTip.value > 0)
							{
								string text2 = "";
								int num16 = 0;
								int num17 = 0;
								int num18 = 0;
								int num19 = 0;
								int num20 = Main.toolTip.value * Main.toolTip.stack;
								if (!Main.toolTip.buy)
								{
									num20 = Main.toolTip.value / 5 * Main.toolTip.stack;
								}
								if (num20 < 1)
								{
									num20 = 1;
								}
								if (num20 >= 1000000)
								{
									num16 = num20 / 1000000;
									num20 -= num16 * 1000000;
								}
								if (num20 >= 10000)
								{
									num17 = num20 / 10000;
									num20 -= num17 * 10000;
								}
								if (num20 >= 100)
								{
									num18 = num20 / 100;
									num20 -= num18 * 100;
								}
								if (num20 >= 1)
								{
									num19 = num20;
								}
								if (num16 > 0)
								{
									text2 = text2 + num16 + " 白金币 ";
								}
								if (num17 > 0)
								{
									text2 = text2 + num17 + " 金币 ";
								}
								if (num18 > 0)
								{
									text2 = text2 + num18 + " 银币 ";
								}
								if (num19 > 0)
								{
									text2 = text2 + num19 + " 铜币 ";
								}
								if (!Main.toolTip.buy)
								{
									array[num4] = "出售价: " + text2;
								}
								else
								{
									array[num4] = "购买价: " + text2;
								}
								num4++;
								num21 = (float)Main.mouseTextColor / 255f;
								if (num16 > 0)
								{
									color = new Microsoft.Xna.Framework.Color((int)((byte)(220f * num21)), (int)((byte)(220f * num21)), (int)((byte)(198f * num21)), (int)Main.mouseTextColor);
								}
								else if (num17 > 0)
								{
									color = new Microsoft.Xna.Framework.Color((int)((byte)(224f * num21)), (int)((byte)(201f * num21)), (int)((byte)(92f * num21)), (int)Main.mouseTextColor);
								}
								else if (num18 > 0)
								{
									color = new Microsoft.Xna.Framework.Color((int)((byte)(181f * num21)), (int)((byte)(192f * num21)), (int)((byte)(193f * num21)), (int)Main.mouseTextColor);
								}
								else if (num19 > 0)
								{
									color = new Microsoft.Xna.Framework.Color((int)((byte)(246f * num21)), (int)((byte)(138f * num21)), (int)((byte)(96f * num21)), (int)Main.mouseTextColor);
								}
							}
							else
							{
								num21 = (float)Main.mouseTextColor / 255f;
								array[num4] = "无价值";
								num4++;
								color = new Microsoft.Xna.Framework.Color((int)((byte)(120f * num21)), (int)((byte)(120f * num21)), (int)((byte)(120f * num21)), (int)Main.mouseTextColor);
							}
						}
						Vector2 vector = default(Vector2);
						int num22 = 0;
						for (int j = 0; j < num4; j++)
						{
							Vector2 vector2 = Main.fontMouseText.MeasureString(array[j]);
							if (vector2.X > vector.X)
							{
								vector.X = vector2.X;
							}
							vector.Y += vector2.Y + (float)num22;
						}
						if ((float)num + vector.X + 4f > (float)Main.screenWidth)
						{
							num = (int)((float)Main.screenWidth - vector.X - 4f);
						}
						if ((float)num2 + vector.Y + 4f > (float)Main.screenHeight)
						{
							num2 = (int)((float)Main.screenHeight - vector.Y - 4f);
						}
						int num23 = 0;
						num21 = (float)Main.mouseTextColor / 255f;
						for (int k = 0; k < num4; k++)
						{
							for (int l = 0; l < 5; l++)
							{
								int num24 = num;
								int num25 = num2 + num23;
								Microsoft.Xna.Framework.Color color2 = Microsoft.Xna.Framework.Color.Black;
								if (l == 0)
								{
									num24 -= 2;
								}
								else if (l == 1)
								{
									num24 += 2;
								}
								else if (l == 2)
								{
									num25 -= 2;
								}
								else if (l == 3)
								{
									num25 += 2;
								}
								else
								{
									color2 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
									if (k == 0)
									{
										if (rare == -1)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(130f * num21)), (int)((byte)(130f * num21)), (int)((byte)(130f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 1)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(150f * num21)), (int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 2)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 3)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(200f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 4)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 5)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
										}
										if (rare == 6)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(210f * num21)), (int)((byte)(160f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
										}
										if (diff == 1)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.mcColor.R * num21)), (int)((byte)((float)Main.mcColor.G * num21)), (int)((byte)((float)Main.mcColor.B * num21)), (int)Main.mouseTextColor);
										}
										if (diff == 2)
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.hcColor.R * num21)), (int)((byte)((float)Main.hcColor.G * num21)), (int)((byte)((float)Main.hcColor.B * num21)), (int)Main.mouseTextColor);
										}
									}
									else if (array2[k])
									{
										if (array3[k])
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(190f * num21)), (int)((byte)(120f * num21)), (int)((byte)(120f * num21)), (int)Main.mouseTextColor);
										}
										else
										{
											color2 = new Microsoft.Xna.Framework.Color((int)((byte)(120f * num21)), (int)((byte)(190f * num21)), (int)((byte)(120f * num21)), (int)Main.mouseTextColor);
										}
									}
									else if (k == num4 - 1)
									{
										color2 = color;
									}
								}
								SpriteBatch spriteBatch = this.spriteBatch;
								SpriteFontX spriteFont = Main.fontMouseText;
								string text3 = array[k];
								Vector2 position = new Vector2((float)num24, (float)num25);
								Microsoft.Xna.Framework.Color color3 = color2;
								float rotation = 0f;
								Vector2 origin = default(Vector2);
								this.DStoDSX(spriteFont, text3, position, color3, rotation, origin, 1f, SpriteEffects.None, 0f);
							}
							num23 += (int)(Main.fontMouseText.MeasureString(array[k]).Y + (float)num22);
						}
					}
					else
					{
						if (Main.buffString != "" && Main.buffString != null)
						{
							for (int m = 0; m < 5; m++)
							{
								int num26 = num;
								int num27 = num2 + (int)Main.fontMouseText.MeasureString(Main.buffString).Y;
								Microsoft.Xna.Framework.Color black = Microsoft.Xna.Framework.Color.Black;
								if (m == 0)
								{
									num26 -= 2;
								}
								else if (m == 1)
								{
									num26 += 2;
								}
								else if (m == 2)
								{
									num27 -= 2;
								}
								else if (m == 3)
								{
									num27 += 2;
								}
								else
								{
									black = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								}
								this.DStoDSX(Main.fontMouseText, Main.buffString, new Vector2((float)num26, (float)num27), black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						Vector2 vector3 = Main.fontMouseText.MeasureString(cursorText);
						if ((float)num + vector3.X + 4f > (float)Main.screenWidth)
						{
							num = (int)((float)Main.screenWidth - vector3.X - 4f);
						}
						if ((float)num2 + vector3.Y + 4f > (float)Main.screenHeight)
						{
							num2 = (int)((float)Main.screenHeight - vector3.Y - 4f);
						}
						SpriteBatch spriteBatch2 = this.spriteBatch;
						SpriteFontX spriteFont2 = Main.fontMouseText;
						Vector2 position2 = new Vector2((float)num, (float)(num2 - 2));
						Microsoft.Xna.Framework.Color black2 = Microsoft.Xna.Framework.Color.Black;
						float rotation2 = 0f;
						Vector2 origin = default(Vector2);
						this.DStoDSX(spriteFont2, cursorText, position2, black2, rotation2, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch3 = this.spriteBatch;
						SpriteFontX spriteFont3 = Main.fontMouseText;
						Vector2 position3 = new Vector2((float)num, (float)(num2 + 2));
						Microsoft.Xna.Framework.Color black3 = Microsoft.Xna.Framework.Color.Black;
						float rotation3 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont3, cursorText, position3, black3, rotation3, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch4 = this.spriteBatch;
						SpriteFontX spriteFont4 = Main.fontMouseText;
						Vector2 position4 = new Vector2((float)(num - 2), (float)num2);
						Microsoft.Xna.Framework.Color black4 = Microsoft.Xna.Framework.Color.Black;
						float rotation4 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont4, cursorText, position4, black4, rotation4, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch5 = this.spriteBatch;
						SpriteFontX spriteFont5 = Main.fontMouseText;
						Vector2 position5 = new Vector2((float)(num + 2), (float)num2);
						Microsoft.Xna.Framework.Color black5 = Microsoft.Xna.Framework.Color.Black;
						float rotation5 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont5, cursorText, position5, black5, rotation5, origin, 1f, SpriteEffects.None, 0f);
						float num21 = (float)Main.mouseTextColor / 255f;
						Microsoft.Xna.Framework.Color color4 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						if (rare == -1)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(130f * num21)), (int)((byte)(130f * num21)), (int)((byte)(130f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 6)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(210f * num21)), (int)((byte)(160f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 1)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(150f * num21)), (int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 2)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 3)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(200f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 4)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)((byte)(150f * num21)), (int)Main.mouseTextColor);
						}
						if (rare == 5)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)(255f * num21)), (int)((byte)(150f * num21)), (int)((byte)(255f * num21)), (int)Main.mouseTextColor);
						}
						if (diff == 1)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.mcColor.R * num21)), (int)((byte)((float)Main.mcColor.G * num21)), (int)((byte)((float)Main.mcColor.B * num21)), (int)Main.mouseTextColor);
						}
						if (diff == 2)
						{
							color4 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.hcColor.R * num21)), (int)((byte)((float)Main.hcColor.G * num21)), (int)((byte)((float)Main.hcColor.B * num21)), (int)Main.mouseTextColor);
						}
						SpriteBatch spriteBatch6 = this.spriteBatch;
						SpriteFontX spriteFont6 = Main.fontMouseText;
						Vector2 position6 = new Vector2((float)num, (float)num2);
						Microsoft.Xna.Framework.Color color5 = color4;
						float rotation6 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont6, cursorText, position6, color5, rotation6, origin, 1f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		protected void DrawFPS()
		{
			if (Main.showFrameRate)
			{
				string text = string.Concat(Main.frameRate);
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" (",
					(int)(Main.gfxQuality * 100f),
					"%)"
				});
				int num = 4;
				if (!Main.gameMenu)
				{
					num = Main.screenHeight - 24;
				}
				this.DStoDSX(Main.fontMouseText, text + " " + Main.debugWords, new Vector2(4f, (float)num), new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			}
		}

		public static Microsoft.Xna.Framework.Color shine(Microsoft.Xna.Framework.Color newColor, int type)
		{
			int num = (int)newColor.R;
			int num2 = (int)newColor.R;
			int num3 = (int)newColor.R;
			float num4 = 0.6f;
			if (type == 25)
			{
				num = (int)((float)newColor.R * 0.95f);
				num2 = (int)((float)newColor.G * 0.85f);
				num3 = (int)((double)((float)newColor.B) * 1.1);
			}
			else if (type == 117)
			{
				num = (int)((float)newColor.R * 1.1f);
				num2 = (int)((float)newColor.G * 1f);
				num3 = (int)((double)((float)newColor.B) * 1.2);
			}
			else
			{
				num = (int)((float)newColor.R * (1f + num4));
				num2 = (int)((float)newColor.G * (1f + num4));
				num3 = (int)((float)newColor.B * (1f + num4));
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			newColor.R = (byte)num;
			newColor.G = (byte)num2;
			newColor.B = (byte)num3;
			return new Microsoft.Xna.Framework.Color((int)((byte)num), (int)((byte)num2), (int)((byte)num3), (int)newColor.A);
		}

		protected void DrawTiles(bool solidOnly = true)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 30f * Main.gfxQuality);
			int num2 = (int)(50f * (1f - Main.gfxQuality) + 2f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num3 = 0;
			int[] array = new int[1000];
			int[] array2 = new int[1000];
			int num4 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num5 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num6 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num7 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesX)
			{
				num5 = Main.maxTilesX;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			if (num7 > Main.maxTilesY)
			{
				num7 = Main.maxTilesY;
			}
			for (int i = num6; i < num7 + 4; i++)
			{
				for (int j = num4 - 2; j < num5 + 2; j++)
				{
					if (Main.tile[j, i] == null)
					{
						Main.tile[j, i] = new Tile();
					}
					bool flag = Main.tileSolid[(int)Main.tile[j, i].type];
					if (Main.tile[j, i].type == 11)
					{
						flag = true;
					}
					if (Main.tile[j, i].active && flag == solidOnly)
					{
						Microsoft.Xna.Framework.Color color = Lighting.GetColor(j, i);
						int num8 = 0;
						if (Main.tile[j, i].type == 78 || Main.tile[j, i].type == 85)
						{
							num8 = 2;
						}
						if (Main.tile[j, i].type == 33 || Main.tile[j, i].type == 49)
						{
							num8 = -4;
						}
						int height;
						if (Main.tile[j, i].type == 3 || Main.tile[j, i].type == 4 || Main.tile[j, i].type == 5 || Main.tile[j, i].type == 24 || Main.tile[j, i].type == 33 || Main.tile[j, i].type == 49 || Main.tile[j, i].type == 61 || Main.tile[j, i].type == 71 || Main.tile[j, i].type == 110)
						{
							height = 20;
						}
						else if (Main.tile[j, i].type == 15 || Main.tile[j, i].type == 14 || Main.tile[j, i].type == 16 || Main.tile[j, i].type == 17 || Main.tile[j, i].type == 18 || Main.tile[j, i].type == 20 || Main.tile[j, i].type == 21 || Main.tile[j, i].type == 26 || Main.tile[j, i].type == 27 || Main.tile[j, i].type == 32 || Main.tile[j, i].type == 69 || Main.tile[j, i].type == 72 || Main.tile[j, i].type == 77 || Main.tile[j, i].type == 80)
						{
							height = 18;
						}
						else if (Main.tile[j, i].type == 137)
						{
							height = 18;
						}
						else if (Main.tile[j, i].type == 135)
						{
							num8 = 2;
							height = 18;
						}
						else if (Main.tile[j, i].type == 132)
						{
							num8 = 2;
							height = 18;
						}
						else
						{
							height = 16;
						}
						int num9;
						if (Main.tile[j, i].type == 4 || Main.tile[j, i].type == 5)
						{
							num9 = 20;
						}
						else
						{
							num9 = 16;
						}
						if (Main.tile[j, i].type == 73 || Main.tile[j, i].type == 74 || Main.tile[j, i].type == 113)
						{
							num8 -= 12;
							height = 32;
						}
						if (Main.tile[j, i].type == 81)
						{
							num8 -= 8;
							height = 26;
							num9 = 24;
						}
						if (Main.tile[j, i].type == 105)
						{
							num8 = 2;
						}
						if (Main.tile[j, i].type == 124)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 137)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 138)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 139 || Main.tile[j, i].type == 142 || Main.tile[j, i].type == 143)
						{
							num8 = 2;
						}
						if (Main.player[Main.myPlayer].findTreasure && (Main.tile[j, i].type == 6 || Main.tile[j, i].type == 7 || Main.tile[j, i].type == 8 || Main.tile[j, i].type == 9 || Main.tile[j, i].type == 12 || Main.tile[j, i].type == 21 || Main.tile[j, i].type == 22 || Main.tile[j, i].type == 28 || Main.tile[j, i].type == 107 || Main.tile[j, i].type == 108 || Main.tile[j, i].type == 111 || (Main.tile[j, i].type >= 63 && Main.tile[j, i].type <= 68) || Main.tileAlch[(int)Main.tile[j, i].type]))
						{
							if (color.R < Main.mouseTextColor / 2)
							{
								color.R = (byte)(Main.mouseTextColor / 2);
							}
							if (color.G < 70)
							{
								color.G = 70;
							}
							if (color.B < 210)
							{
								color.B = 210;
							}
							color.A = Main.mouseTextColor;
							if (!Main.gamePaused && base.IsActive && Main.rand.Next(150) == 0)
							{
								Vector2 position = new Vector2((float)(j * 16), (float)(i * 16));
								int width = 16;
								int height2 = 16;
								int type = 15;
								float speedX = 0f;
								float speedY = 0f;
								int alpha = 150;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num10 = Dust.NewDust(position, width, height2, type, speedX, speedY, alpha, newColor, 0.8f);
								Dust dust = Main.dust[num10];
								dust.velocity *= 0.1f;
								Main.dust[num10].noLight = true;
							}
						}
						if (!Main.gamePaused && base.IsActive)
						{
							if (Main.tile[j, i].type == 4 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 66)
							{
								int num11 = (int)(Main.tile[j, i].frameY / 22);
								if (num11 == 0)
								{
									num11 = 6;
								}
								else if (num11 == 8)
								{
									num11 = 75;
								}
								else
								{
									num11 = 58 + num11;
								}
								if (Main.tile[j, i].frameX == 22)
								{
									Vector2 position2 = new Vector2((float)(j * 16 + 6), (float)(i * 16));
									int width2 = 4;
									int height3 = 4;
									int type2 = num11;
									float speedX2 = 0f;
									float speedY2 = 0f;
									int alpha2 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position2, width2, height3, type2, speedX2, speedY2, alpha2, newColor, 1f);
								}
								if (Main.tile[j, i].frameX == 44)
								{
									Vector2 position3 = new Vector2((float)(j * 16 + 2), (float)(i * 16));
									int width3 = 4;
									int height4 = 4;
									int type3 = num11;
									float speedX3 = 0f;
									float speedY3 = 0f;
									int alpha3 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position3, width3, height4, type3, speedX3, speedY3, alpha3, newColor, 1f);
								}
								else
								{
									Vector2 position4 = new Vector2((float)(j * 16 + 4), (float)(i * 16));
									int width4 = 4;
									int height5 = 4;
									int type4 = num11;
									float speedX4 = 0f;
									float speedY4 = 0f;
									int alpha4 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position4, width4, height5, type4, speedX4, speedY4, alpha4, newColor, 1f);
								}
							}
							if (Main.tile[j, i].type == 33 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX == 0)
							{
								Vector2 position5 = new Vector2((float)(j * 16 + 4), (float)(i * 16 - 4));
								int width5 = 4;
								int height6 = 4;
								int type5 = 6;
								float speedX5 = 0f;
								float speedY5 = 0f;
								int alpha5 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position5, width5, height6, type5, speedX5, speedY5, alpha5, newColor, 1f);
							}
							if (Main.tile[j, i].type == 93 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX == 0 && Main.tile[j, i].frameY == 0)
							{
								Vector2 position6 = new Vector2((float)(j * 16 + 4), (float)(i * 16 + 2));
								int width6 = 4;
								int height7 = 4;
								int type6 = 6;
								float speedX6 = 0f;
								float speedY6 = 0f;
								int alpha6 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position6, width6, height7, type6, speedX6, speedY6, alpha6, newColor, 1f);
							}
							if (Main.tile[j, i].type == 100 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 36 && Main.tile[j, i].frameY == 0)
							{
								if (Main.tile[j, i].frameX == 0)
								{
									if (Main.rand.Next(3) == 0)
									{
										Vector2 position7 = new Vector2((float)(j * 16 + 4), (float)(i * 16 + 2));
										int width7 = 4;
										int height8 = 4;
										int type7 = 6;
										float speedX7 = 0f;
										float speedY7 = 0f;
										int alpha7 = 100;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										Dust.NewDust(position7, width7, height8, type7, speedX7, speedY7, alpha7, newColor, 1f);
									}
									else
									{
										Vector2 position8 = new Vector2((float)(j * 16 + 14), (float)(i * 16 + 2));
										int width8 = 4;
										int height9 = 4;
										int type8 = 6;
										float speedX8 = 0f;
										float speedY8 = 0f;
										int alpha8 = 100;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										Dust.NewDust(position8, width8, height9, type8, speedX8, speedY8, alpha8, newColor, 1f);
									}
								}
								else if (Main.rand.Next(3) == 0)
								{
									Vector2 position9 = new Vector2((float)(j * 16 + 6), (float)(i * 16 + 2));
									int width9 = 4;
									int height10 = 4;
									int type9 = 6;
									float speedX9 = 0f;
									float speedY9 = 0f;
									int alpha9 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position9, width9, height10, type9, speedX9, speedY9, alpha9, newColor, 1f);
								}
								else
								{
									Vector2 position10 = new Vector2((float)(j * 16), (float)(i * 16 + 2));
									int width10 = 4;
									int height11 = 4;
									int type10 = 6;
									float speedX10 = 0f;
									float speedY10 = 0f;
									int alpha10 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position10, width10, height11, type10, speedX10, speedY10, alpha10, newColor, 1f);
								}
							}
							if (Main.tile[j, i].type == 98 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameY == 0 && Main.tile[j, i].frameX == 0)
							{
								Vector2 position11 = new Vector2((float)(j * 16 + 12), (float)(i * 16 + 2));
								int width11 = 4;
								int height12 = 4;
								int type11 = 6;
								float speedX11 = 0f;
								float speedY11 = 0f;
								int alpha11 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position11, width11, height12, type11, speedX11, speedY11, alpha11, newColor, 1f);
							}
							if (Main.tile[j, i].type == 49 && Main.rand.Next(20) == 0)
							{
								Vector2 position12 = new Vector2((float)(j * 16 + 4), (float)(i * 16 - 4));
								int width12 = 4;
								int height13 = 4;
								int type12 = 29;
								float speedX12 = 0f;
								float speedY12 = 0f;
								int alpha12 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position12, width12, height13, type12, speedX12, speedY12, alpha12, newColor, 1f);
							}
							if ((Main.tile[j, i].type == 34 || Main.tile[j, i].type == 35 || Main.tile[j, i].type == 36) && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 54 && Main.tile[j, i].frameY == 18 && (Main.tile[j, i].frameX == 0 || Main.tile[j, i].frameX == 36))
							{
								Vector2 position13 = new Vector2((float)(j * 16), (float)(i * 16 + 2));
								int width13 = 14;
								int height14 = 6;
								int type13 = 6;
								float speedX13 = 0f;
								float speedY13 = 0f;
								int alpha13 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position13, width13, height14, type13, speedX13, speedY13, alpha13, newColor, 1f);
							}
							if (Main.tile[j, i].type == 22 && Main.rand.Next(400) == 0)
							{
								Vector2 position14 = new Vector2((float)(j * 16), (float)(i * 16));
								int width14 = 16;
								int height15 = 16;
								int type14 = 14;
								float speedX14 = 0f;
								float speedY14 = 0f;
								int alpha14 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position14, width14, height15, type14, speedX14, speedY14, alpha14, newColor, 1f);
							}
							else if ((Main.tile[j, i].type == 23 || Main.tile[j, i].type == 24 || Main.tile[j, i].type == 32) && Main.rand.Next(500) == 0)
							{
								Vector2 position15 = new Vector2((float)(j * 16), (float)(i * 16));
								int width15 = 16;
								int height16 = 16;
								int type15 = 14;
								float speedX15 = 0f;
								float speedY15 = 0f;
								int alpha15 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position15, width15, height16, type15, speedX15, speedY15, alpha15, newColor, 1f);
							}
							else if (Main.tile[j, i].type == 25 && Main.rand.Next(700) == 0)
							{
								Vector2 position16 = new Vector2((float)(j * 16), (float)(i * 16));
								int width16 = 16;
								int height17 = 16;
								int type16 = 14;
								float speedX16 = 0f;
								float speedY16 = 0f;
								int alpha16 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position16, width16, height17, type16, speedX16, speedY16, alpha16, newColor, 1f);
							}
							else if (Main.tile[j, i].type == 112 && Main.rand.Next(700) == 0)
							{
								Vector2 position17 = new Vector2((float)(j * 16), (float)(i * 16));
								int width17 = 16;
								int height18 = 16;
								int type17 = 14;
								float speedX17 = 0f;
								float speedY17 = 0f;
								int alpha17 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position17, width17, height18, type17, speedX17, speedY17, alpha17, newColor, 1f);
							}
							else if (Main.tile[j, i].type == 31 && Main.rand.Next(20) == 0)
							{
								Vector2 position18 = new Vector2((float)(j * 16), (float)(i * 16));
								int width18 = 16;
								int height19 = 16;
								int type18 = 14;
								float speedX18 = 0f;
								float speedY18 = 0f;
								int alpha18 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position18, width18, height19, type18, speedX18, speedY18, alpha18, newColor, 1f);
							}
							else if (Main.tile[j, i].type == 26 && Main.rand.Next(20) == 0)
							{
								Vector2 position19 = new Vector2((float)(j * 16), (float)(i * 16));
								int width19 = 16;
								int height20 = 16;
								int type19 = 14;
								float speedX19 = 0f;
								float speedY19 = 0f;
								int alpha19 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position19, width19, height20, type19, speedX19, speedY19, alpha19, newColor, 1f);
							}
							else if ((Main.tile[j, i].type == 71 || Main.tile[j, i].type == 72) && Main.rand.Next(500) == 0)
							{
								Vector2 position20 = new Vector2((float)(j * 16), (float)(i * 16));
								int width20 = 16;
								int height21 = 16;
								int type20 = 41;
								float speedX20 = 0f;
								float speedY20 = 0f;
								int alpha20 = 250;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(position20, width20, height21, type20, speedX20, speedY20, alpha20, newColor, 0.8f);
							}
							else if ((Main.tile[j, i].type == 17 || Main.tile[j, i].type == 77 || Main.tile[j, i].type == 133) && Main.rand.Next(40) == 0)
							{
								if (Main.tile[j, i].frameX == 18 & Main.tile[j, i].frameY == 18)
								{
									Vector2 position21 = new Vector2((float)(j * 16 + 2), (float)(i * 16));
									int width21 = 8;
									int height22 = 6;
									int type21 = 6;
									float speedX21 = 0f;
									float speedY21 = 0f;
									int alpha21 = 100;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(position21, width21, height22, type21, speedX21, speedY21, alpha21, newColor, 1f);
								}
							}
							else if (Main.tile[j, i].type == 37 && Main.rand.Next(250) == 0)
							{
								Vector2 position22 = new Vector2((float)(j * 16), (float)(i * 16));
								int width22 = 16;
								int height23 = 16;
								int type22 = 6;
								float speedX22 = 0f;
								float speedY22 = 0f;
								int alpha22 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num12 = Dust.NewDust(position22, width22, height23, type22, speedX22, speedY22, alpha22, newColor, (float)Main.rand.Next(3));
								if (Main.dust[num12].scale > 1f)
								{
									Main.dust[num12].noGravity = true;
								}
							}
							else if ((Main.tile[j, i].type == 58 || Main.tile[j, i].type == 76) && Main.rand.Next(250) == 0)
							{
								Vector2 position23 = new Vector2((float)(j * 16), (float)(i * 16));
								int width23 = 16;
								int height24 = 16;
								int type23 = 6;
								float speedX23 = 0f;
								float speedY23 = 0f;
								int alpha23 = 0;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num13 = Dust.NewDust(position23, width23, height24, type23, speedX23, speedY23, alpha23, newColor, (float)Main.rand.Next(3));
								if (Main.dust[num13].scale > 1f)
								{
									Main.dust[num13].noGravity = true;
								}
								Main.dust[num13].noLight = true;
							}
							else if (Main.tile[j, i].type == 61)
							{
								if (Main.tile[j, i].frameX == 144)
								{
									if (Main.rand.Next(60) == 0)
									{
										Vector2 position24 = new Vector2((float)(j * 16), (float)(i * 16));
										int width24 = 16;
										int height25 = 16;
										int type24 = 44;
										float speedX24 = 0f;
										float speedY24 = 0f;
										int alpha24 = 250;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										int num14 = Dust.NewDust(position24, width24, height25, type24, speedX24, speedY24, alpha24, newColor, 0.4f);
										Main.dust[num14].fadeIn = 0.7f;
									}
									color.A = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
									color.R = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
									color.B = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
									color.G = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
								}
							}
							else if (Main.tileShine[(int)Main.tile[j, i].type] > 0 && (color.R > 20 || color.B > 20 || color.G > 20))
							{
								int num15 = (int)color.R;
								if ((int)color.G > num15)
								{
									num15 = (int)color.G;
								}
								if ((int)color.B > num15)
								{
									num15 = (int)color.B;
								}
								num15 /= 30;
								if (Main.rand.Next(Main.tileShine[(int)Main.tile[j, i].type]) < num15 && (Main.tile[j, i].type != 21 || (Main.tile[j, i].frameX >= 36 && Main.tile[j, i].frameX < 180)))
								{
									Vector2 position25 = new Vector2((float)(j * 16), (float)(i * 16));
									int width25 = 16;
									int height26 = 16;
									int type25 = 43;
									float speedX25 = 0f;
									float speedY25 = 0f;
									int alpha25 = 254;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									int num16 = Dust.NewDust(position25, width25, height26, type25, speedX25, speedY25, alpha25, newColor, 0.5f);
									Dust dust2 = Main.dust[num16];
									dust2.velocity *= 0f;
								}
							}
						}
						if (Main.tile[j, i].type == 128 && Main.tile[j, i].frameX >= 100)
						{
							array[num3] = j;
							array2[num3] = i;
							num3++;
						}
						if (Main.tile[j, i].type == 5 && Main.tile[j, i].frameY >= 198 && Main.tile[j, i].frameX >= 22)
						{
							array[num3] = j;
							array2[num3] = i;
							num3++;
						}
						if (Main.tile[j, i].type == 72 && Main.tile[j, i].frameX >= 36)
						{
							int num17 = 0;
							if (Main.tile[j, i].frameY == 18)
							{
								num17 = 1;
							}
							else if (Main.tile[j, i].frameY == 36)
							{
								num17 = 2;
							}
							SpriteBatch spriteBatch = this.spriteBatch;
							Texture2D texture = Main.shroomCapTexture;
							Vector2 position26 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X - 22), (float)(i * 16 - (int)Main.screenPosition.Y - 26)) + value;
							Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(num17 * 62, 0, 60, 42));
							Microsoft.Xna.Framework.Color color2 = Lighting.GetColor(j, i);
							float rotation = 0f;
							Vector2 origin = default(Vector2);
							spriteBatch.Draw(texture, position26, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0f);
						}
						if (color.R > 1 || color.G > 1 || color.B > 1)
						{
							if (Main.tile[j - 1, i] == null)
							{
								Main.tile[j - 1, i] = new Tile();
							}
							if (Main.tile[j + 1, i] == null)
							{
								Main.tile[j + 1, i] = new Tile();
							}
							if (Main.tile[j, i - 1] == null)
							{
								Main.tile[j, i - 1] = new Tile();
							}
							if (Main.tile[j, i + 1] == null)
							{
								Main.tile[j, i + 1] = new Tile();
							}
							if (solidOnly && flag && !Main.tileSolidTop[(int)Main.tile[j, i].type] && (Main.tile[j - 1, i].liquid > 0 || Main.tile[j + 1, i].liquid > 0 || Main.tile[j, i - 1].liquid > 0 || Main.tile[j, i + 1].liquid > 0))
							{
								Microsoft.Xna.Framework.Color color3 = Lighting.GetColor(j, i);
								int num18 = 0;
								bool flag2 = false;
								bool flag3 = false;
								bool flag4 = false;
								bool flag5 = false;
								int num19 = 0;
								bool flag6 = false;
								if ((int)Main.tile[j - 1, i].liquid > num18)
								{
									num18 = (int)Main.tile[j - 1, i].liquid;
									flag2 = true;
								}
								else if (Main.tile[j - 1, i].liquid > 0)
								{
									flag2 = true;
								}
								if ((int)Main.tile[j + 1, i].liquid > num18)
								{
									num18 = (int)Main.tile[j + 1, i].liquid;
									flag3 = true;
								}
								else if (Main.tile[j + 1, i].liquid > 0)
								{
									num18 = (int)Main.tile[j + 1, i].liquid;
									flag3 = true;
								}
								if (Main.tile[j, i - 1].liquid > 0)
								{
									flag4 = true;
								}
								if (Main.tile[j, i + 1].liquid > 240)
								{
									flag5 = true;
								}
								if (Main.tile[j - 1, i].liquid > 0)
								{
									if (Main.tile[j - 1, i].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j + 1, i].liquid > 0)
								{
									if (Main.tile[j + 1, i].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j, i - 1].liquid > 0)
								{
									if (Main.tile[j, i - 1].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j, i + 1].liquid > 0)
								{
									if (Main.tile[j, i + 1].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (!flag6 || num19 != 1)
								{
									Vector2 value2 = new Vector2((float)(j * 16), (float)(i * 16));
									Microsoft.Xna.Framework.Rectangle value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16);
									if (flag5 && (flag2 || flag3))
									{
										flag2 = true;
										flag3 = true;
									}
									if ((!flag4 || (!flag2 && !flag3)) && (!flag5 || !flag4))
									{
										if (flag4)
										{
											value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 4);
										}
										else if (flag5 && !flag2 && !flag3)
										{
											value2 = new Vector2((float)(j * 16), (float)(i * 16 + 12));
											value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 4);
										}
										else
										{
											float num20 = (float)(256 - num18);
											num20 /= 32f;
											if (flag2 && flag3)
											{
												value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num20 * 2));
												value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16 - (int)num20 * 2);
											}
											else if (flag2)
											{
												value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num20 * 2));
												value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 4, 16 - (int)num20 * 2);
											}
											else
											{
												value2 = new Vector2((float)(j * 16 + 12), (float)(i * 16 + (int)num20 * 2));
												value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 4, 16 - (int)num20 * 2);
											}
										}
									}
									float num21 = 0.5f;
									if (num19 == 1)
									{
										num21 *= 1.6f;
									}
									if ((double)i < Main.worldSurface || num21 > 1f)
									{
										num21 = 1f;
									}
									float num22 = (float)color3.R * num21;
									float num23 = (float)color3.G * num21;
									float num24 = (float)color3.B * num21;
									float num25 = (float)color3.A * num21;
									color3 = new Microsoft.Xna.Framework.Color((int)((byte)num22), (int)((byte)num23), (int)((byte)num24), (int)((byte)num25));
									SpriteBatch spriteBatch2 = this.spriteBatch;
									Texture2D texture2 = Main.liquidTexture[num19];
									Vector2 position27 = value2 - Main.screenPosition + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = new Microsoft.Xna.Framework.Rectangle?(value3);
									Microsoft.Xna.Framework.Color color4 = color3;
									float rotation2 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch2.Draw(texture2, position27, sourceRectangle2, color4, rotation2, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							if (Main.tile[j, i].type == 51)
							{
								Microsoft.Xna.Framework.Color color5 = Lighting.GetColor(j, i);
								float num26 = 0.5f;
								float num27 = (float)color5.R * num26;
								float num28 = (float)color5.G * num26;
								float num29 = (float)color5.B * num26;
								float num30 = (float)color5.A * num26;
								color5 = new Microsoft.Xna.Framework.Color((int)((byte)num27), (int)((byte)num28), (int)((byte)num29), (int)((byte)num30));
								SpriteBatch spriteBatch3 = this.spriteBatch;
								Texture2D texture3 = Main.tileTexture[(int)Main.tile[j, i].type];
								Vector2 position28 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
								Microsoft.Xna.Framework.Rectangle? sourceRectangle3 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
								Microsoft.Xna.Framework.Color color6 = color5;
								float rotation3 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch3.Draw(texture3, position28, sourceRectangle3, color6, rotation3, origin, 1f, SpriteEffects.None, 0f);
							}
							else if (Main.tile[j, i].type == 129)
							{
								SpriteBatch spriteBatch4 = this.spriteBatch;
								Texture2D texture4 = Main.tileTexture[(int)Main.tile[j, i].type];
								Vector2 position29 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
								Microsoft.Xna.Framework.Rectangle? sourceRectangle4 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
								Microsoft.Xna.Framework.Color color7 = new Microsoft.Xna.Framework.Color(200, 200, 200, 0);
								float rotation4 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch4.Draw(texture4, position29, sourceRectangle4, color7, rotation4, origin, 1f, SpriteEffects.None, 0f);
							}
							else if (Main.tileAlch[(int)Main.tile[j, i].type])
							{
								height = 20;
								num8 = -1;
								int num31 = (int)Main.tile[j, i].type;
								int num32 = (int)(Main.tile[j, i].frameX / 18);
								if (num31 > 82)
								{
									if (num32 == 0 && Main.dayTime)
									{
										num31 = 84;
									}
									if (num32 == 1 && !Main.dayTime)
									{
										num31 = 84;
									}
									if (num32 == 3 && Main.bloodMoon)
									{
										num31 = 84;
									}
								}
								if (num31 == 84)
								{
									if (num32 == 0 && Main.rand.Next(100) == 0)
									{
										Vector2 position30 = new Vector2((float)(j * 16), (float)(i * 16 - 4));
										int width26 = 16;
										int height27 = 16;
										int type26 = 19;
										float speedX26 = 0f;
										float speedY26 = 0f;
										int alpha26 = 160;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										int num33 = Dust.NewDust(position30, width26, height27, type26, speedX26, speedY26, alpha26, newColor, 0.1f);
										Dust dust3 = Main.dust[num33];
										dust3.velocity.X = dust3.velocity.X / 2f;
										Dust dust4 = Main.dust[num33];
										dust4.velocity.Y = dust4.velocity.Y / 2f;
										Main.dust[num33].noGravity = true;
										Main.dust[num33].fadeIn = 1f;
									}
									if (num32 == 1 && Main.rand.Next(100) == 0)
									{
										Vector2 position31 = new Vector2((float)(j * 16), (float)(i * 16));
										int width27 = 16;
										int height28 = 16;
										int type27 = 41;
										float speedX27 = 0f;
										float speedY27 = 0f;
										int alpha27 = 250;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										Dust.NewDust(position31, width27, height28, type27, speedX27, speedY27, alpha27, newColor, 0.8f);
									}
									if (num32 == 3)
									{
										if (Main.rand.Next(200) == 0)
										{
											Vector2 position32 = new Vector2((float)(j * 16), (float)(i * 16));
											int width28 = 16;
											int height29 = 16;
											int type28 = 14;
											float speedX28 = 0f;
											float speedY28 = 0f;
											int alpha28 = 100;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											int num34 = Dust.NewDust(position32, width28, height29, type28, speedX28, speedY28, alpha28, newColor, 0.2f);
											Main.dust[num34].fadeIn = 1.2f;
										}
										if (Main.rand.Next(75) == 0)
										{
											Vector2 position33 = new Vector2((float)(j * 16), (float)(i * 16));
											int width29 = 16;
											int height30 = 16;
											int type29 = 27;
											float speedX29 = 0f;
											float speedY29 = 0f;
											int alpha29 = 100;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											int num35 = Dust.NewDust(position33, width29, height30, type29, speedX29, speedY29, alpha29, newColor, 1f);
											Dust dust5 = Main.dust[num35];
											dust5.velocity.X = dust5.velocity.X / 2f;
											Dust dust6 = Main.dust[num35];
											dust6.velocity.Y = dust6.velocity.Y / 2f;
										}
									}
									if (num32 == 4 && Main.rand.Next(150) == 0)
									{
										Vector2 position34 = new Vector2((float)(j * 16), (float)(i * 16));
										int width30 = 16;
										int height31 = 8;
										int type30 = 16;
										float speedX30 = 0f;
										float speedY30 = 0f;
										int alpha30 = 0;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										int num36 = Dust.NewDust(position34, width30, height31, type30, speedX30, speedY30, alpha30, newColor, 1f);
										Dust dust7 = Main.dust[num36];
										dust7.velocity.X = dust7.velocity.X / 3f;
										Dust dust8 = Main.dust[num36];
										dust8.velocity.Y = dust8.velocity.Y / 3f;
										Dust dust9 = Main.dust[num36];
										dust9.velocity.Y = dust9.velocity.Y - 0.7f;
										Main.dust[num36].alpha = 50;
										Main.dust[num36].scale *= 0.1f;
										Main.dust[num36].fadeIn = 0.9f;
										Main.dust[num36].noGravity = true;
									}
									if (num32 == 5)
									{
										if (Main.rand.Next(40) == 0)
										{
											Vector2 position35 = new Vector2((float)(j * 16), (float)(i * 16 - 6));
											int width31 = 16;
											int height32 = 16;
											int type31 = 6;
											float speedX31 = 0f;
											float speedY31 = 0f;
											int alpha31 = 0;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											int num37 = Dust.NewDust(position35, width31, height32, type31, speedX31, speedY31, alpha31, newColor, 1.5f);
											Dust dust10 = Main.dust[num37];
											dust10.velocity.Y = dust10.velocity.Y - 2f;
											Main.dust[num37].noGravity = true;
										}
										color.A = (byte)(Main.mouseTextColor / 2);
										color.G = Main.mouseTextColor;
										color.B = Main.mouseTextColor;
									}
								}
								SpriteBatch spriteBatch5 = this.spriteBatch;
								Texture2D texture5 = Main.tileTexture[num31];
								Vector2 position36 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
								Microsoft.Xna.Framework.Rectangle? sourceRectangle5 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
								Microsoft.Xna.Framework.Color color8 = color;
								float rotation5 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch5.Draw(texture5, position36, sourceRectangle5, color8, rotation5, origin, 1f, SpriteEffects.None, 0f);
							}
							else if (Main.tile[j, i].type == 80)
							{
								bool flag7 = false;
								bool flag8 = false;
								int num38 = j;
								if (Main.tile[j, i].frameX == 36)
								{
									num38--;
								}
								if (Main.tile[j, i].frameX == 54)
								{
									num38++;
								}
								if (Main.tile[j, i].frameX == 108)
								{
									if (Main.tile[j, i].frameY == 16)
									{
										num38--;
									}
									else
									{
										num38++;
									}
								}
								int num39 = i;
								bool flag9 = false;
								if (Main.tile[num38, num39].type == 80 && Main.tile[num38, num39].active)
								{
									flag9 = true;
								}
								while (!Main.tile[num38, num39].active || !Main.tileSolid[(int)Main.tile[num38, num39].type] || !flag9)
								{
									if (Main.tile[num38, num39].type == 80 && Main.tile[num38, num39].active)
									{
										flag9 = true;
									}
									num39++;
									if (num39 > i + 20)
									{
										break;
									}
								}
								if (Main.tile[num38, num39].type == 112)
								{
									flag7 = true;
								}
								if (Main.tile[num38, num39].type == 116)
								{
									flag8 = true;
								}
								if (flag7)
								{
									SpriteBatch spriteBatch6 = this.spriteBatch;
									Texture2D texture6 = Main.evilCactusTexture;
									Vector2 position37 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle6 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color9 = color;
									float rotation6 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch6.Draw(texture6, position37, sourceRectangle6, color9, rotation6, origin, 1f, SpriteEffects.None, 0f);
								}
								else if (flag8)
								{
									SpriteBatch spriteBatch7 = this.spriteBatch;
									Texture2D texture7 = Main.goodCactusTexture;
									Vector2 position38 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle7 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color10 = color;
									float rotation7 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch7.Draw(texture7, position38, sourceRectangle7, color10, rotation7, origin, 1f, SpriteEffects.None, 0f);
								}
								else
								{
									SpriteBatch spriteBatch8 = this.spriteBatch;
									Texture2D texture8 = Main.tileTexture[(int)Main.tile[j, i].type];
									Vector2 position39 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle8 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color11 = color;
									float rotation8 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch8.Draw(texture8, position39, sourceRectangle8, color11, rotation8, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							else if (Lighting.lightMode < 2 && Main.tileSolid[(int)Main.tile[j, i].type] && Main.tile[j, i].type != 137)
							{
								if ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2)
								{
									for (int k = 0; k < 9; k++)
									{
										int num40 = 0;
										int num41 = 0;
										int width32 = 4;
										int height33 = 4;
										Microsoft.Xna.Framework.Color color12 = color;
										Microsoft.Xna.Framework.Color color13 = color;
										if (k == 0)
										{
											color13 = Lighting.GetColor(j - 1, i - 1);
										}
										if (k == 1)
										{
											width32 = 8;
											num40 = 4;
											color13 = Lighting.GetColor(j, i - 1);
										}
										if (k == 2)
										{
											color13 = Lighting.GetColor(j + 1, i - 1);
											num40 = 12;
										}
										if (k == 3)
										{
											color13 = Lighting.GetColor(j - 1, i);
											height33 = 8;
											num41 = 4;
										}
										if (k == 4)
										{
											width32 = 8;
											height33 = 8;
											num40 = 4;
											num41 = 4;
										}
										if (k == 5)
										{
											num40 = 12;
											num41 = 4;
											height33 = 8;
											color13 = Lighting.GetColor(j + 1, i);
										}
										if (k == 6)
										{
											color13 = Lighting.GetColor(j - 1, i + 1);
											num41 = 12;
										}
										if (k == 7)
										{
											width32 = 8;
											height33 = 4;
											num40 = 4;
											num41 = 12;
											color13 = Lighting.GetColor(j, i + 1);
										}
										if (k == 8)
										{
											color13 = Lighting.GetColor(j + 1, i + 1);
											num40 = 12;
											num41 = 12;
										}
										color12.R = (byte)((color.R + color13.R) / 2);
										color12.G = (byte)((color.G + color13.G) / 2);
										color12.B = (byte)((color.B + color13.B) / 2);
										if (Main.tileShine2[(int)Main.tile[j, i].type])
										{
											color12 = Main.shine(color12, (int)Main.tile[j, i].type);
										}
										SpriteBatch spriteBatch9 = this.spriteBatch;
										Texture2D texture9 = Main.tileTexture[(int)Main.tile[j, i].type];
										Vector2 position40 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num40, (float)(i * 16 - (int)Main.screenPosition.Y + num8 + num41)) + value;
										Microsoft.Xna.Framework.Rectangle? sourceRectangle9 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX + num40, (int)Main.tile[j, i].frameY + num41, width32, height33));
										Microsoft.Xna.Framework.Color color14 = color12;
										float rotation9 = 0f;
										Vector2 origin = default(Vector2);
										spriteBatch9.Draw(texture9, position40, sourceRectangle9, color14, rotation9, origin, 1f, SpriteEffects.None, 0f);
									}
								}
								else if ((int)color.R > num2 || (double)color.G > (double)num2 * 1.1 || (double)color.B > (double)num2 * 1.2)
								{
									for (int l = 0; l < 4; l++)
									{
										int num42 = 0;
										int num43 = 0;
										Microsoft.Xna.Framework.Color color15 = color;
										Microsoft.Xna.Framework.Color color16 = color;
										if (l == 0)
										{
											if (Lighting.Brighter(j, i - 1, j - 1, i))
											{
												color16 = Lighting.GetColor(j - 1, i);
											}
											else
											{
												color16 = Lighting.GetColor(j, i - 1);
											}
										}
										if (l == 1)
										{
											if (Lighting.Brighter(j, i - 1, j + 1, i))
											{
												color16 = Lighting.GetColor(j + 1, i);
											}
											else
											{
												color16 = Lighting.GetColor(j, i - 1);
											}
											num42 = 8;
										}
										if (l == 2)
										{
											if (Lighting.Brighter(j, i + 1, j - 1, i))
											{
												color16 = Lighting.GetColor(j - 1, i);
											}
											else
											{
												color16 = Lighting.GetColor(j, i + 1);
											}
											num43 = 8;
										}
										if (l == 3)
										{
											if (Lighting.Brighter(j, i + 1, j + 1, i))
											{
												color16 = Lighting.GetColor(j + 1, i);
											}
											else
											{
												color16 = Lighting.GetColor(j, i + 1);
											}
											num42 = 8;
											num43 = 8;
										}
										color15.R = (byte)((color.R + color16.R) / 2);
										color15.G = (byte)((color.G + color16.G) / 2);
										color15.B = (byte)((color.B + color16.B) / 2);
										if (Main.tileShine2[(int)Main.tile[j, i].type])
										{
											color15 = Main.shine(color15, (int)Main.tile[j, i].type);
										}
										SpriteBatch spriteBatch10 = this.spriteBatch;
										Texture2D texture10 = Main.tileTexture[(int)Main.tile[j, i].type];
										Vector2 position41 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num42, (float)(i * 16 - (int)Main.screenPosition.Y + num8 + num43)) + value;
										Microsoft.Xna.Framework.Rectangle? sourceRectangle10 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX + num42, (int)Main.tile[j, i].frameY + num43, 8, 8));
										Microsoft.Xna.Framework.Color color17 = color15;
										float rotation10 = 0f;
										Vector2 origin = default(Vector2);
										spriteBatch10.Draw(texture10, position41, sourceRectangle10, color17, rotation10, origin, 1f, SpriteEffects.None, 0f);
									}
								}
								else
								{
									if (Main.tileShine2[(int)Main.tile[j, i].type])
									{
										color = Main.shine(color, (int)Main.tile[j, i].type);
									}
									SpriteBatch spriteBatch11 = this.spriteBatch;
									Texture2D texture11 = Main.tileTexture[(int)Main.tile[j, i].type];
									Vector2 position42 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle11 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color18 = color;
									float rotation11 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch11.Draw(texture11, position42, sourceRectangle11, color18, rotation11, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								if (Lighting.lightMode < 2 && Main.tileShine2[(int)Main.tile[j, i].type])
								{
									if (Main.tile[j, i].type == 21)
									{
										if (Main.tile[j, i].frameX >= 36 && Main.tile[j, i].frameX < 178)
										{
											color = Main.shine(color, (int)Main.tile[j, i].type);
										}
									}
									else
									{
										color = Main.shine(color, (int)Main.tile[j, i].type);
									}
								}
								if (Main.tile[j, i].type == 128)
								{
									int m;
									for (m = (int)Main.tile[j, i].frameX; m >= 100; m -= 100)
									{
									}
									SpriteBatch spriteBatch12 = this.spriteBatch;
									Texture2D texture12 = Main.tileTexture[(int)Main.tile[j, i].type];
									Vector2 position43 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle12 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(m, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color19 = color;
									float rotation12 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch12.Draw(texture12, position43, sourceRectangle12, color19, rotation12, origin, 1f, SpriteEffects.None, 0f);
								}
								else
								{
									SpriteBatch spriteBatch13 = this.spriteBatch;
									Texture2D texture13 = Main.tileTexture[(int)Main.tile[j, i].type];
									Vector2 position44 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
									Microsoft.Xna.Framework.Rectangle? sourceRectangle13 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
									Microsoft.Xna.Framework.Color color20 = color;
									float rotation13 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch13.Draw(texture13, position44, sourceRectangle13, color20, rotation13, origin, 1f, SpriteEffects.None, 0f);
									if (Main.tile[j, i].type == 139)
									{
										SpriteBatch spriteBatch14 = this.spriteBatch;
										Texture2D musicBoxTexture = Main.MusicBoxTexture;
										Vector2 position45 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
										Microsoft.Xna.Framework.Rectangle? sourceRectangle14 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
										Microsoft.Xna.Framework.Color color21 = new Microsoft.Xna.Framework.Color(200, 200, 200, 0);
										float rotation14 = 0f;
										origin = default(Vector2);
										spriteBatch14.Draw(musicBoxTexture, position45, sourceRectangle14, color21, rotation14, origin, 1f, SpriteEffects.None, 0f);
									}
									if (Main.tile[j, i].type == 144)
									{
										SpriteBatch spriteBatch15 = this.spriteBatch;
										Texture2D texture14 = Main.timerTexture;
										Vector2 position46 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num8)) + value;
										Microsoft.Xna.Framework.Rectangle? sourceRectangle15 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num9, height));
										Microsoft.Xna.Framework.Color color22 = new Microsoft.Xna.Framework.Color(200, 200, 200, 0);
										float rotation15 = 0f;
										origin = default(Vector2);
										spriteBatch15.Draw(texture14, position46, sourceRectangle15, color22, rotation15, origin, 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
				}
			}
			for (int n = 0; n < num3; n++)
			{
				int num44 = array[n];
				int num45 = array2[n];
				if (Main.tile[num44, num45].type == 128 && Main.tile[num44, num45].frameX >= 100)
				{
					int num46 = (int)(Main.tile[num44, num45].frameY / 18);
					int num47 = (int)Main.tile[num44, num45].frameX;
					int num48 = 0;
					while (num47 >= 100)
					{
						num48++;
						num47 -= 100;
					}
					int num49 = -4;
					SpriteEffects effects = SpriteEffects.FlipHorizontally;
					if (num47 >= 36)
					{
						effects = SpriteEffects.None;
						num49 = -4;
					}
					if (num46 == 0)
					{
						SpriteBatch spriteBatch16 = this.spriteBatch;
						Texture2D texture15 = Main.armorHeadTexture[num48];
						Vector2 position47 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle16 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 40, 36));
						Microsoft.Xna.Framework.Color color23 = Lighting.GetColor(num44, num45);
						float rotation16 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch16.Draw(texture15, position47, sourceRectangle16, color23, rotation16, origin, 1f, effects, 0f);
					}
					else if (num46 == 1)
					{
						SpriteBatch spriteBatch17 = this.spriteBatch;
						Texture2D texture16 = Main.armorBodyTexture[num48];
						Vector2 position48 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 28)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle17 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 40, 54));
						Microsoft.Xna.Framework.Color color24 = Lighting.GetColor(num44, num45);
						float rotation17 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch17.Draw(texture16, position48, sourceRectangle17, color24, rotation17, origin, 1f, effects, 0f);
					}
					else if (num46 == 2)
					{
						SpriteBatch spriteBatch18 = this.spriteBatch;
						Texture2D texture17 = Main.armorLegTexture[num48];
						Vector2 position49 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 44)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle18 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 40, 54));
						Microsoft.Xna.Framework.Color color25 = Lighting.GetColor(num44, num45);
						float rotation18 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch18.Draw(texture17, position49, sourceRectangle18, color25, rotation18, origin, 1f, effects, 0f);
					}
				}
				if (Main.tile[num44, num45].type == 5 && Main.tile[num44, num45].frameY >= 198 && Main.tile[num44, num45].frameX >= 22)
				{
					int num50 = 0;
					if (Main.tile[num44, num45].frameX == 22)
					{
						if (Main.tile[num44, num45].frameY == 220)
						{
							num50 = 1;
						}
						else if (Main.tile[num44, num45].frameY == 242)
						{
							num50 = 2;
						}
						int num51 = 0;
						int num52 = 80;
						int num53 = 80;
						int num54 = 32;
						int num55 = 0;
						int num56 = num45;
						while (num56 < num45 + 100)
						{
							if (Main.tile[num44, num56].type == 2)
							{
								num51 = 0;
								break;
							}
							if (Main.tile[num44, num56].type == 23)
							{
								num51 = 1;
								break;
							}
							if (Main.tile[num44, num56].type == 60)
							{
								num51 = 2;
								num52 = 114;
								num53 = 96;
								num54 = 48;
								break;
							}
							if (Main.tile[num44, num56].type == 147)
							{
								num51 = 4;
								break;
							}
							if (Main.tile[num44, num56].type == 109)
							{
								num51 = 3;
								num53 = 140;
								if (num44 % 3 == 1)
								{
									num50 += 3;
									break;
								}
								if (num44 % 3 == 2)
								{
									num50 += 6;
									break;
								}
								break;
							}
							else
							{
								num56++;
							}
						}
						SpriteBatch spriteBatch19 = this.spriteBatch;
						Texture2D texture18 = Main.treeTopTexture[num51];
						Vector2 position50 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X - num54), (float)(num45 * 16 - (int)Main.screenPosition.Y - num53 + 16 + num55)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle19 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(num50 * (num52 + 2), 0, num52, num53));
						Microsoft.Xna.Framework.Color color26 = Lighting.GetColor(num44, num45);
						float rotation19 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch19.Draw(texture18, position50, sourceRectangle19, color26, rotation19, origin, 1f, SpriteEffects.None, 0f);
					}
					else if (Main.tile[num44, num45].frameX == 44)
					{
						if (Main.tile[num44, num45].frameY == 220)
						{
							num50 = 1;
						}
						else if (Main.tile[num44, num45].frameY == 242)
						{
							num50 = 2;
						}
						int num57 = 0;
						int num58 = num45;
						while (num58 < num45 + 100)
						{
							if (Main.tile[num44 + 1, num58].type == 2)
							{
								num57 = 0;
								break;
							}
							if (Main.tile[num44 + 1, num58].type == 23)
							{
								num57 = 1;
								break;
							}
							if (Main.tile[num44 + 1, num58].type == 60)
							{
								num57 = 2;
								break;
							}
							if (Main.tile[num44 + 1, num58].type == 147)
							{
								num57 = 4;
								break;
							}
							if (Main.tile[num44 + 1, num58].type == 109)
							{
								num57 = 3;
								if (num44 % 3 == 1)
								{
									num50 += 3;
									break;
								}
								if (num44 % 3 == 2)
								{
									num50 += 6;
									break;
								}
								break;
							}
							else
							{
								num58++;
							}
						}
						SpriteBatch spriteBatch20 = this.spriteBatch;
						Texture2D texture19 = Main.treeBranchTexture[num57];
						Vector2 position51 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X - 24), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle20 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, num50 * 42, 40, 40));
						Microsoft.Xna.Framework.Color color27 = Lighting.GetColor(num44, num45);
						float rotation20 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch20.Draw(texture19, position51, sourceRectangle20, color27, rotation20, origin, 1f, SpriteEffects.None, 0f);
					}
					else if (Main.tile[num44, num45].frameX == 66)
					{
						if (Main.tile[num44, num45].frameY == 220)
						{
							num50 = 1;
						}
						else if (Main.tile[num44, num45].frameY == 242)
						{
							num50 = 2;
						}
						int num59 = 0;
						int num60 = num45;
						while (num60 < num45 + 100)
						{
							if (Main.tile[num44 - 1, num60].type == 2)
							{
								num59 = 0;
								break;
							}
							if (Main.tile[num44 - 1, num60].type == 23)
							{
								num59 = 1;
								break;
							}
							if (Main.tile[num44 - 1, num60].type == 60)
							{
								num59 = 2;
								break;
							}
							if (Main.tile[num44 - 1, num60].type == 147)
							{
								num59 = 4;
								break;
							}
							if (Main.tile[num44 - 1, num60].type == 109)
							{
								num59 = 3;
								if (num44 % 3 == 1)
								{
									num50 += 3;
									break;
								}
								if (num44 % 3 == 2)
								{
									num50 += 6;
									break;
								}
								break;
							}
							else
							{
								num60++;
							}
						}
						SpriteBatch spriteBatch21 = this.spriteBatch;
						Texture2D texture20 = Main.treeBranchTexture[num59];
						Vector2 position52 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
						Microsoft.Xna.Framework.Rectangle? sourceRectangle21 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(42, num50 * 42, 40, 40));
						Microsoft.Xna.Framework.Color color28 = Lighting.GetColor(num44, num45);
						float rotation21 = 0f;
						Vector2 origin = default(Vector2);
						spriteBatch21.Draw(texture20, position52, sourceRectangle21, color28, rotation21, origin, 1f, SpriteEffects.None, 0f);
					}
				}
			}
			if (solidOnly)
			{
				Main.renderTimer[0] = (float)stopwatch.ElapsedMilliseconds;
			}
			else
			{
				Main.renderTimer[1] = (float)stopwatch.ElapsedMilliseconds;
			}
		}

		protected void DrawWater(bool bg = false)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num = (int)(255f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			int num2 = (int)(255f * (1f - Main.gfxQuality) + 140f * Main.gfxQuality);
			float num3 = (float)Main.evilTiles / 350f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			float num4 = (255f - 100f * num3) / 255f;
			float num5 = (255f - 50f * num3) / 255f;
			int num6 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num7 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num8 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num9 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num6 < 5)
			{
				num6 = 5;
			}
			if (num7 > Main.maxTilesX - 5)
			{
				num7 = Main.maxTilesX - 5;
			}
			if (num8 < 5)
			{
				num8 = 5;
			}
			if (num9 > Main.maxTilesY - 5)
			{
				num9 = Main.maxTilesY - 5;
			}
			for (int i = num8; i < num9 + 4; i++)
			{
				for (int j = num6 - 2; j < num7 + 2; j++)
				{
					if (Main.tile[j, i] == null)
					{
						Main.tile[j, i] = new Tile();
					}
					if (Main.tile[j, i].liquid > 0 && (!Main.tile[j, i].active || !Main.tileSolid[(int)Main.tile[j, i].type] || Main.tileSolidTop[(int)Main.tile[j, i].type]) && (Lighting.Brightness(j, i) > 0f || bg))
					{
						Microsoft.Xna.Framework.Color color = Lighting.GetColor(j, i);
						float num10 = (float)(256 - (int)Main.tile[j, i].liquid);
						num10 /= 32f;
						int num11 = 0;
						if (Main.tile[j, i].lava)
						{
							num11 = 1;
						}
						float num12 = 0.5f;
						if (bg)
						{
							num12 = 1f;
						}
						Vector2 value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num10 * 2));
						Microsoft.Xna.Framework.Rectangle value3 = new Microsoft.Xna.Framework.Rectangle(0, 0, 16, 16 - (int)num10 * 2);
						if (Main.tile[j, i + 1].liquid < 245 && (!Main.tile[j, i + 1].active || !Main.tileSolid[(int)Main.tile[j, i + 1].type] || Main.tileSolidTop[(int)Main.tile[j, i + 1].type]))
						{
							float num13 = (float)(256 - (int)Main.tile[j, i + 1].liquid);
							num13 /= 32f;
							num12 = 0.5f * (8f - num10) / 4f;
							if ((double)num12 > 0.55)
							{
								num12 = 0.55f;
							}
							if ((double)num12 < 0.35)
							{
								num12 = 0.35f;
							}
							float num14 = num10 / 2f;
							if (Main.tile[j, i + 1].liquid < 200)
							{
								if (bg)
								{
									goto IL_F66;
								}
								if (Main.tile[j, i - 1].liquid > 0 && Main.tile[j, i - 1].liquid > 0)
								{
									value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16);
									num12 = 0.5f;
								}
								else if (Main.tile[j, i - 1].liquid > 0)
								{
									value2 = new Vector2((float)(j * 16), (float)(i * 16 + 4));
									value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 12);
									num12 = 0.5f;
								}
								else if (Main.tile[j, i + 1].liquid > 0)
								{
									value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num10 * 2 + (int)num13 * 2));
									value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16 - (int)num10 * 2);
								}
								else
								{
									value2 = new Vector2((float)(j * 16 + (int)num14), (float)(i * 16 + (int)num14 * 2 + (int)num13 * 2));
									value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16 - (int)num14 * 2, 16 - (int)num14 * 2);
								}
							}
							else
							{
								num12 = 0.5f;
								value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16 - (int)num10 * 2 + (int)num13 * 2);
							}
						}
						else if (Main.tile[j, i - 1].liquid > 32)
						{
							value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, value3.Width, value3.Height);
						}
						else if (num10 < 1f && Main.tile[j, i - 1].active && Main.tileSolid[(int)Main.tile[j, i - 1].type] && !Main.tileSolidTop[(int)Main.tile[j, i - 1].type])
						{
							value2 = new Vector2((float)(j * 16), (float)(i * 16));
							value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16);
						}
						else
						{
							bool flag = true;
							int num15 = i + 1;
							while (num15 < i + 6 && (!Main.tile[j, num15].active || !Main.tileSolid[(int)Main.tile[j, num15].type] || Main.tileSolidTop[(int)Main.tile[j, num15].type]))
							{
								if (Main.tile[j, num15].liquid < 200)
								{
									flag = false;
									break;
								}
								num15++;
							}
							if (!flag)
							{
								num12 = 0.5f;
								value3 = new Microsoft.Xna.Framework.Rectangle(0, 4, 16, 16);
							}
							else if (Main.tile[j, i - 1].liquid > 0)
							{
								value3 = new Microsoft.Xna.Framework.Rectangle(0, 2, value3.Width, value3.Height);
							}
						}
						if (Main.tile[j, i].lava)
						{
							num12 *= 1.8f;
							if (num12 > 1f)
							{
								num12 = 1f;
							}
							if (base.IsActive && !Main.gamePaused && Dust.lavaBubbles < 200)
							{
								if (Main.tile[j, i].liquid > 200 && Main.rand.Next(700) == 0)
								{
									Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16)), 16, 16, 35, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
								}
								if (value3.Y == 0 && Main.rand.Next(350) == 0)
								{
									int num16 = Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16) + num10 * 2f - 8f), 16, 8, 35, 0f, 0f, 50, default(Microsoft.Xna.Framework.Color), 1.5f);
									Dust dust = Main.dust[num16];
									dust.velocity *= 0.8f;
									Dust dust2 = Main.dust[num16];
									dust2.velocity.X = dust2.velocity.X * 2f;
									Dust dust3 = Main.dust[num16];
									dust3.velocity.Y = dust3.velocity.Y - (float)Main.rand.Next(1, 7) * 0.1f;
									if (Main.rand.Next(10) == 0)
									{
										Dust dust4 = Main.dust[num16];
										dust4.velocity.Y = dust4.velocity.Y * (float)Main.rand.Next(2, 5);
									}
									Main.dust[num16].noGravity = true;
								}
							}
						}
						float num17 = (float)color.R * num12;
						float num18 = (float)color.G * num12;
						float num19 = (float)color.B * num12;
						float num20 = (float)color.A * num12;
						if (num11 == 0)
						{
							num19 *= num4;
						}
						else
						{
							num17 *= num5;
						}
						color = new Microsoft.Xna.Framework.Color((int)((byte)num17), (int)((byte)num18), (int)((byte)num19), (int)((byte)num20));
						if (Lighting.lightMode < 2 && !bg)
						{
							Microsoft.Xna.Framework.Color color2 = color;
							if ((num11 == 0 && ((int)color2.R > num || (double)color2.G > (double)num * 1.1 || (double)color2.B > (double)num * 1.2)) || (int)color2.R > num2 || (double)color2.G > (double)num2 * 1.1 || (double)color2.B > (double)num2 * 1.2)
							{
								for (int k = 0; k < 4; k++)
								{
									int num21 = 0;
									int num22 = 0;
									int width = 8;
									int height = 8;
									Microsoft.Xna.Framework.Color color3 = color2;
									Microsoft.Xna.Framework.Color color4 = Lighting.GetColor(j, i);
									if (k == 0)
									{
										if (Lighting.Brighter(j, i - 1, j - 1, i))
										{
											if (!Main.tile[j - 1, i].active)
											{
												color4 = Lighting.GetColor(j - 1, i);
											}
											else if (!Main.tile[j, i - 1].active)
											{
												color4 = Lighting.GetColor(j, i - 1);
											}
										}
										if (value3.Height < 8)
										{
											height = value3.Height;
										}
									}
									if (k == 1)
									{
										if (Lighting.Brighter(j, i - 1, j + 1, i))
										{
											if (!Main.tile[j + 1, i].active)
											{
												color4 = Lighting.GetColor(j + 1, i);
											}
											else if (!Main.tile[j, i - 1].active)
											{
												color4 = Lighting.GetColor(j, i - 1);
											}
										}
										num21 = 8;
										if (value3.Height < 8)
										{
											height = value3.Height;
										}
									}
									if (k == 2)
									{
										if (Lighting.Brighter(j, i + 1, j - 1, i))
										{
											if (!Main.tile[j - 1, i].active)
											{
												color4 = Lighting.GetColor(j - 1, i);
											}
											else if (!Main.tile[j, i + 1].active)
											{
												color4 = Lighting.GetColor(j, i + 1);
											}
										}
										num22 = 8;
										height = 8 - (16 - value3.Height);
									}
									if (k == 3)
									{
										if (Lighting.Brighter(j, i + 1, j + 1, i))
										{
											if (!Main.tile[j + 1, i].active)
											{
												color4 = Lighting.GetColor(j + 1, i);
											}
											else if (!Main.tile[j, i + 1].active)
											{
												color4 = Lighting.GetColor(j, i + 1);
											}
										}
										num21 = 8;
										num22 = 8;
										height = 8 - (16 - value3.Height);
									}
									num17 = (float)color4.R * num12;
									num18 = (float)color4.G * num12;
									num19 = (float)color4.B * num12;
									num20 = (float)color4.A * num12;
									color4 = new Microsoft.Xna.Framework.Color((int)((byte)num17), (int)((byte)num18), (int)((byte)num19), (int)((byte)num20));
									color3.R = (byte)((color2.R + color4.R) / 2);
									color3.G = (byte)((color2.G + color4.G) / 2);
									color3.B = (byte)((color2.B + color4.B) / 2);
									color3.A = (byte)((color2.A + color4.A) / 2);
									this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + new Vector2((float)num21, (float)num22) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(value3.X + num21, value3.Y + num22, width, height)), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + value, new Microsoft.Xna.Framework.Rectangle?(value3), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						else
						{
							this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + value, new Microsoft.Xna.Framework.Rectangle?(value3), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
					IL_F66:;
				}
			}
			if (!bg)
			{
				Main.renderTimer[4] = (float)stopwatch.ElapsedMilliseconds;
			}
		}

		protected void DrawGore()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.gore[i].active && Main.gore[i].type > 0)
				{
					Microsoft.Xna.Framework.Color alpha = Main.gore[i].GetAlpha(Lighting.GetColor((int)((double)Main.gore[i].position.X + (double)Main.goreTexture[Main.gore[i].type].Width * 0.5) / 16, (int)(((double)Main.gore[i].position.Y + (double)Main.goreTexture[Main.gore[i].type].Height * 0.5) / 16.0)));
					this.spriteBatch.Draw(Main.goreTexture[Main.gore[i].type], new Vector2(Main.gore[i].position.X - Main.screenPosition.X + (float)(Main.goreTexture[Main.gore[i].type].Width / 2), Main.gore[i].position.Y - Main.screenPosition.Y + (float)(Main.goreTexture[Main.gore[i].type].Height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.goreTexture[Main.gore[i].type].Width, Main.goreTexture[Main.gore[i].type].Height)), alpha, Main.gore[i].rotation, new Vector2((float)(Main.goreTexture[Main.gore[i].type].Width / 2), (float)(Main.goreTexture[Main.gore[i].type].Height / 2)), Main.gore[i].scale, SpriteEffects.None, 0f);
				}
			}
		}

		protected void DrawNPCs(bool behindTiles = false)
		{
			bool flag = false;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 300, (int)Main.screenPosition.Y - 300, Main.screenWidth + 600, Main.screenHeight + 600);
			for (int i = 199; i >= 0; i--)
			{
				if (Main.npc[i].active && Main.npc[i].type > 0 && Main.npc[i].behindTiles == behindTiles)
				{
					if ((Main.npc[i].type == 125 || Main.npc[i].type == 126) && !flag)
					{
						flag = true;
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && i != j && (Main.npc[j].type == 125 || Main.npc[j].type == 126))
							{
								float num = Main.npc[j].position.X + (float)Main.npc[j].width * 0.5f;
								float num2 = Main.npc[j].position.Y + (float)Main.npc[j].height * 0.5f;
								Vector2 vector = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f, Main.npc[i].position.Y + (float)Main.npc[i].height * 0.5f);
								float num3 = num - vector.X;
								float num4 = num2 - vector.Y;
								float rotation = (float)Math.Atan2((double)num4, (double)num3) - 1.57f;
								bool flag2 = true;
								float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
								if (num5 > 2000f)
								{
									flag2 = false;
								}
								while (flag2)
								{
									num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
									if (num5 < 40f)
									{
										flag2 = false;
									}
									else
									{
										num5 = (float)Main.chain12Texture.Height / num5;
										num3 *= num5;
										num4 *= num5;
										vector.X += num3;
										vector.Y += num4;
										num3 = num - vector.X;
										num4 = num2 - vector.Y;
										Microsoft.Xna.Framework.Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
										this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float)Main.chain12Texture.Width * 0.5f, (float)Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (rectangle.Intersects(new Microsoft.Xna.Framework.Rectangle((int)Main.npc[i].position.X, (int)Main.npc[i].position.Y, Main.npc[i].width, Main.npc[i].height)))
					{
						if (Main.npc[i].type == 101)
						{
							bool flag3 = true;
							Vector2 vector2 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
							float num6 = Main.npc[i].ai[0] * 16f + 8f - vector2.X;
							float num7 = Main.npc[i].ai[1] * 16f + 8f - vector2.Y;
							float rotation2 = (float)Math.Atan2((double)num7, (double)num6) - 1.57f;
							bool flag4 = true;
							while (flag4)
							{
								float num8 = 0.75f;
								int height = 28;
								float num9 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
								if (num9 < 28f * num8)
								{
									height = (int)num9 - 40 + 28;
									flag4 = false;
								}
								num9 = 20f * num8 / num9;
								num6 *= num9;
								num7 *= num9;
								vector2.X += num6;
								vector2.Y += num7;
								num6 = Main.npc[i].ai[0] * 16f + 8f - vector2.X;
								num7 = Main.npc[i].ai[1] * 16f + 8f - vector2.Y;
								Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
								if (!flag3)
								{
									flag3 = true;
									this.spriteBatch.Draw(Main.chain10Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain10Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain10Texture.Width * 0.5f, (float)Main.chain10Texture.Height * 0.5f), num8, SpriteEffects.None, 0f);
								}
								else
								{
									flag3 = false;
									this.spriteBatch.Draw(Main.chain11Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain10Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain10Texture.Width * 0.5f, (float)Main.chain10Texture.Height * 0.5f), num8, SpriteEffects.None, 0f);
								}
							}
						}
						else if (Main.npc[i].aiStyle == 13)
						{
							Vector2 vector3 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
							float num10 = Main.npc[i].ai[0] * 16f + 8f - vector3.X;
							float num11 = Main.npc[i].ai[1] * 16f + 8f - vector3.Y;
							float rotation3 = (float)Math.Atan2((double)num11, (double)num10) - 1.57f;
							bool flag5 = true;
							while (flag5)
							{
								int height2 = 28;
								float num12 = (float)Math.Sqrt((double)(num10 * num10 + num11 * num11));
								if (num12 < 40f)
								{
									height2 = (int)num12 - 40 + 28;
									flag5 = false;
								}
								num12 = 28f / num12;
								num10 *= num12;
								num11 *= num12;
								vector3.X += num10;
								vector3.Y += num11;
								num10 = Main.npc[i].ai[0] * 16f + 8f - vector3.X;
								num11 = Main.npc[i].ai[1] * 16f + 8f - vector3.Y;
								Microsoft.Xna.Framework.Color color3 = Lighting.GetColor((int)vector3.X / 16, (int)(vector3.Y / 16f));
								if (Main.npc[i].type == 56)
								{
									this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain4Texture.Width, height2)), color3, rotation3, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								}
								else
								{
									this.spriteBatch.Draw(Main.chain4Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain4Texture.Width, height2)), color3, rotation3, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.npc[i].type == 36)
						{
							Vector2 vector4 = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f - 5f * Main.npc[i].ai[0], Main.npc[i].position.Y + 20f);
							for (int k = 0; k < 2; k++)
							{
								float num13 = Main.npc[(int)Main.npc[i].ai[1]].position.X + (float)(Main.npc[(int)Main.npc[i].ai[1]].width / 2) - vector4.X;
								float num14 = Main.npc[(int)Main.npc[i].ai[1]].position.Y + (float)(Main.npc[(int)Main.npc[i].ai[1]].height / 2) - vector4.Y;
								float num15;
								if (k == 0)
								{
									num13 -= 200f * Main.npc[i].ai[0];
									num14 += 130f;
									num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
									num15 = 92f / num15;
									vector4.X += num13 * num15;
									vector4.Y += num14 * num15;
								}
								else
								{
									num13 -= 50f * Main.npc[i].ai[0];
									num14 += 80f;
									num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
									num15 = 60f / num15;
									vector4.X += num13 * num15;
									vector4.Y += num14 * num15;
								}
								float rotation4 = (float)Math.Atan2((double)num14, (double)num13) - 1.57f;
								Microsoft.Xna.Framework.Color color4 = Lighting.GetColor((int)vector4.X / 16, (int)(vector4.Y / 16f));
								this.spriteBatch.Draw(Main.boneArmTexture, new Vector2(vector4.X - Main.screenPosition.X, vector4.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color4, rotation4, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								if (k == 0)
								{
									vector4.X += num13 * num15 / 2f;
									vector4.Y += num14 * num15 / 2f;
								}
								else if (base.IsActive)
								{
									vector4.X += num13 * num15 - 16f;
									vector4.Y += num14 * num15 - 6f;
									Vector2 position = new Vector2(vector4.X, vector4.Y);
									int width = 30;
									int height3 = 10;
									int type = 5;
									float speedX = num13 * 0.02f;
									float speedY = num14 * 0.02f;
									int alpha = 0;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									int num16 = Dust.NewDust(position, width, height3, type, speedX, speedY, alpha, newColor, 2f);
									Main.dust[num16].noGravity = true;
								}
							}
						}
						if (Main.npc[i].aiStyle >= 33 && Main.npc[i].aiStyle <= 36)
						{
							Vector2 vector5 = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f - 5f * Main.npc[i].ai[0], Main.npc[i].position.Y + 20f);
							for (int l = 0; l < 2; l++)
							{
								float num17 = Main.npc[(int)Main.npc[i].ai[1]].position.X + (float)(Main.npc[(int)Main.npc[i].ai[1]].width / 2) - vector5.X;
								float num18 = Main.npc[(int)Main.npc[i].ai[1]].position.Y + (float)(Main.npc[(int)Main.npc[i].ai[1]].height / 2) - vector5.Y;
								float num19;
								if (l == 0)
								{
									num17 -= 200f * Main.npc[i].ai[0];
									num18 += 130f;
									num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
									num19 = 92f / num19;
									vector5.X += num17 * num19;
									vector5.Y += num18 * num19;
								}
								else
								{
									num17 -= 50f * Main.npc[i].ai[0];
									num18 += 80f;
									num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
									num19 = 60f / num19;
									vector5.X += num17 * num19;
									vector5.Y += num18 * num19;
								}
								float rotation5 = (float)Math.Atan2((double)num18, (double)num17) - 1.57f;
								Microsoft.Xna.Framework.Color color5 = Lighting.GetColor((int)vector5.X / 16, (int)(vector5.Y / 16f));
								this.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector5.X - Main.screenPosition.X, vector5.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color5, rotation5, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								if (l == 0)
								{
									vector5.X += num17 * num19 / 2f;
									vector5.Y += num18 * num19 / 2f;
								}
								else if (base.IsActive)
								{
									vector5.X += num17 * num19 - 16f;
									vector5.Y += num18 * num19 - 6f;
									Vector2 position2 = new Vector2(vector5.X, vector5.Y);
									int width2 = 30;
									int height4 = 10;
									int type2 = 6;
									float speedX2 = num17 * 0.02f;
									float speedY2 = num18 * 0.02f;
									int alpha2 = 0;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									int num20 = Dust.NewDust(position2, width2, height4, type2, speedX2, speedY2, alpha2, newColor, 2.5f);
									Main.dust[num20].noGravity = true;
								}
							}
						}
						if (Main.npc[i].aiStyle == 20)
						{
							Vector2 vector6 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
							float num21 = Main.npc[i].ai[1] - vector6.X;
							float num22 = Main.npc[i].ai[2] - vector6.Y;
							float num23 = (float)Math.Atan2((double)num22, (double)num21) - 1.57f;
							Main.npc[i].rotation = num23;
							bool flag6 = true;
							while (flag6)
							{
								int height5 = 12;
								float num24 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
								if (num24 < 20f)
								{
									height5 = (int)num24 - 20 + 12;
									flag6 = false;
								}
								num24 = 12f / num24;
								num21 *= num24;
								num22 *= num24;
								vector6.X += num21;
								vector6.Y += num22;
								num21 = Main.npc[i].ai[1] - vector6.X;
								num22 = Main.npc[i].ai[2] - vector6.Y;
								Microsoft.Xna.Framework.Color color6 = Lighting.GetColor((int)vector6.X / 16, (int)(vector6.Y / 16f));
								this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chainTexture.Width, height5)), color6, num23, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
							}
							this.spriteBatch.Draw(Main.spikeBaseTexture, new Vector2(Main.npc[i].ai[1] - Main.screenPosition.X, Main.npc[i].ai[2] - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.spikeBaseTexture.Width, Main.spikeBaseTexture.Height)), Lighting.GetColor((int)Main.npc[i].ai[1] / 16, (int)(Main.npc[i].ai[2] / 16f)), num23 - 0.75f, new Vector2((float)Main.spikeBaseTexture.Width * 0.5f, (float)Main.spikeBaseTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
						Microsoft.Xna.Framework.Color color7 = Lighting.GetColor((int)((double)Main.npc[i].position.X + (double)Main.npc[i].width * 0.5) / 16, (int)(((double)Main.npc[i].position.Y + (double)Main.npc[i].height * 0.5) / 16.0));
						if (behindTiles && Main.npc[i].type != 113 && Main.npc[i].type != 114)
						{
							int num25 = (int)((Main.npc[i].position.X - 8f) / 16f);
							int num26 = (int)((Main.npc[i].position.X + (float)Main.npc[i].width + 8f) / 16f);
							int num27 = (int)((Main.npc[i].position.Y - 8f) / 16f);
							int num28 = (int)((Main.npc[i].position.Y + (float)Main.npc[i].height + 8f) / 16f);
							for (int m = num25; m <= num26; m++)
							{
								for (int n = num27; n <= num28; n++)
								{
									if (Lighting.Brightness(m, n) == 0f)
									{
										color7 = Microsoft.Xna.Framework.Color.Black;
									}
								}
							}
						}
						float num29 = 1f;
						float g = 1f;
						float num30 = 1f;
						float a = 1f;
						if (Main.npc[i].poisoned)
						{
							if (Main.rand.Next(30) == 0)
							{
								Vector2 position3 = Main.npc[i].position;
								int width3 = Main.npc[i].width;
								int height6 = Main.npc[i].height;
								int type3 = 46;
								float speedX3 = 0f;
								float speedY3 = 0f;
								int alpha3 = 120;
								int num31 = Dust.NewDust(position3, width3, height6, type3, speedX3, speedY3, alpha3, default(Microsoft.Xna.Framework.Color), 0.2f);
								Main.dust[num31].noGravity = true;
								Main.dust[num31].fadeIn = 1.9f;
							}
							num29 *= 0.65f;
							num30 *= 0.75f;
							color7 = Main.buffColor(color7, num29, g, num30, a);
						}
						if (Main.npc[i].onFire)
						{
							if (Main.rand.Next(4) < 3)
							{
								Vector2 position4 = new Vector2(Main.npc[i].position.X - 2f, Main.npc[i].position.Y - 2f);
								int width4 = Main.npc[i].width + 4;
								int height7 = Main.npc[i].height + 4;
								int type4 = 6;
								float speedX4 = Main.npc[i].velocity.X * 0.4f;
								float speedY4 = Main.npc[i].velocity.Y * 0.4f;
								int alpha4 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num32 = Dust.NewDust(position4, width4, height7, type4, speedX4, speedY4, alpha4, newColor, 3.5f);
								Main.dust[num32].noGravity = true;
								Dust dust = Main.dust[num32];
								dust.velocity *= 1.8f;
								Dust dust2 = Main.dust[num32];
								dust2.velocity.Y = dust2.velocity.Y - 0.5f;
								if (Main.rand.Next(4) == 0)
								{
									Main.dust[num32].noGravity = false;
									Main.dust[num32].scale *= 0.5f;
								}
							}
							Lighting.addLight((int)(Main.npc[i].position.X / 16f), (int)(Main.npc[i].position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
						}
						if (Main.npc[i].onFire2)
						{
							if (Main.rand.Next(4) < 3)
							{
								Vector2 position5 = new Vector2(Main.npc[i].position.X - 2f, Main.npc[i].position.Y - 2f);
								int width5 = Main.npc[i].width + 4;
								int height8 = Main.npc[i].height + 4;
								int type5 = 75;
								float speedX5 = Main.npc[i].velocity.X * 0.4f;
								float speedY5 = Main.npc[i].velocity.Y * 0.4f;
								int alpha5 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num33 = Dust.NewDust(position5, width5, height8, type5, speedX5, speedY5, alpha5, newColor, 3.5f);
								Main.dust[num33].noGravity = true;
								Dust dust3 = Main.dust[num33];
								dust3.velocity *= 1.8f;
								Dust dust4 = Main.dust[num33];
								dust4.velocity.Y = dust4.velocity.Y - 0.5f;
								if (Main.rand.Next(4) == 0)
								{
									Main.dust[num33].noGravity = false;
									Main.dust[num33].scale *= 0.5f;
								}
							}
							Lighting.addLight((int)(Main.npc[i].position.X / 16f), (int)(Main.npc[i].position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
						}
						if (Main.player[Main.myPlayer].detectCreature && Main.npc[i].lifeMax > 1)
						{
							if (color7.R < 150)
							{
								color7.A = Main.mouseTextColor;
							}
							if (color7.R < 50)
							{
								color7.R = 50;
							}
							if (color7.G < 200)
							{
								color7.G = 200;
							}
							if (color7.B < 100)
							{
								color7.B = 100;
							}
							if (!Main.gamePaused && base.IsActive && Main.rand.Next(50) == 0)
							{
								Vector2 position6 = new Vector2(Main.npc[i].position.X, Main.npc[i].position.Y);
								int width6 = Main.npc[i].width;
								int height9 = Main.npc[i].height;
								int type6 = 15;
								float speedX6 = 0f;
								float speedY6 = 0f;
								int alpha6 = 150;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num34 = Dust.NewDust(position6, width6, height9, type6, speedX6, speedY6, alpha6, newColor, 0.8f);
								Dust dust5 = Main.dust[num34];
								dust5.velocity *= 0.1f;
								Main.dust[num34].noLight = true;
							}
						}
						if (Main.npc[i].type == 50)
						{
							Vector2 vector7 = default(Vector2);
							float num35 = 0f;
							vector7.Y -= Main.npc[i].velocity.Y;
							vector7.X -= Main.npc[i].velocity.X * 2f;
							num35 += Main.npc[i].velocity.X * 0.05f;
							if (Main.npc[i].frame.Y == 120)
							{
								vector7.Y += 2f;
							}
							if (Main.npc[i].frame.Y == 360)
							{
								vector7.Y -= 2f;
							}
							if (Main.npc[i].frame.Y == 480)
							{
								vector7.Y -= 6f;
							}
							this.spriteBatch.Draw(Main.ninjaTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) + vector7.X, Main.npc[i].position.Y - Main.screenPosition.Y + (float)(Main.npc[i].height / 2) + vector7.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.ninjaTexture.Width, Main.ninjaTexture.Height)), color7, num35, new Vector2((float)(Main.ninjaTexture.Width / 2), (float)(Main.ninjaTexture.Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						if (Main.npc[i].type == 71)
						{
							Vector2 vector8 = default(Vector2);
							float num36 = 0f;
							vector8.Y -= Main.npc[i].velocity.Y * 0.3f;
							vector8.X -= Main.npc[i].velocity.X * 0.6f;
							num36 += Main.npc[i].velocity.X * 0.09f;
							if (Main.npc[i].frame.Y == 120)
							{
								vector8.Y += 2f;
							}
							if (Main.npc[i].frame.Y == 360)
							{
								vector8.Y -= 2f;
							}
							if (Main.npc[i].frame.Y == 480)
							{
								vector8.Y -= 6f;
							}
							this.spriteBatch.Draw(Main.itemTexture[327], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) + vector8.X, Main.npc[i].position.Y - Main.screenPosition.Y + (float)(Main.npc[i].height / 2) + vector8.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[327].Width, Main.itemTexture[327].Height)), color7, num36, new Vector2((float)(Main.itemTexture[327].Width / 2), (float)(Main.itemTexture[327].Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						if (Main.npc[i].type == 69)
						{
							this.spriteBatch.Draw(Main.antLionTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height + 14f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.antLionTexture.Width, Main.antLionTexture.Height)), color7, -Main.npc[i].rotation * 0.3f, new Vector2((float)(Main.antLionTexture.Width / 2), (float)(Main.antLionTexture.Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						float num37 = 0f;
						float num38 = 0f;
						Vector2 origin = new Vector2((float)(Main.npcTexture[Main.npc[i].type].Width / 2), (float)(Main.npcTexture[Main.npc[i].type].Height / Main.npcFrameCount[Main.npc[i].type] / 2));
						if (Main.npc[i].type == 108 || Main.npc[i].type == 124)
						{
							num37 = 2f;
						}
						if (Main.npc[i].type == 4)
						{
							origin = new Vector2(55f, 107f);
						}
						else if (Main.npc[i].type == 125)
						{
							origin = new Vector2(55f, 107f);
							num38 = 30f;
						}
						else if (Main.npc[i].type == 126)
						{
							origin = new Vector2(55f, 107f);
							num38 = 30f;
						}
						else if (Main.npc[i].type == 6)
						{
							num38 = 26f;
						}
						else if (Main.npc[i].type == 94)
						{
							num38 = 14f;
						}
						else if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
						{
							num38 = 13f;
						}
						else if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
						{
							num38 = 13f;
						}
						else if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
						{
							num38 = 13f;
						}
						else if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
						{
							num38 = 8f;
						}
						else if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
						{
							num38 = 26f;
						}
						else if (Main.npc[i].type == 48)
						{
							num38 = 32f;
						}
						else if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
						{
							num38 = 4f;
						}
						else if (Main.npc[i].type == 60)
						{
							num38 = 10f;
						}
						else if (Main.npc[i].type == 62 || Main.npc[i].type == 66)
						{
							num38 = 14f;
						}
						else if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
						{
							num38 = 4f;
							origin.Y += 4f;
						}
						else if (Main.npc[i].type == 65)
						{
							num38 = 14f;
						}
						else if (Main.npc[i].type == 69)
						{
							num38 = 4f;
							origin.Y += 8f;
						}
						else if (Main.npc[i].type == 70)
						{
							num38 = -4f;
						}
						else if (Main.npc[i].type == 72)
						{
							num38 = -2f;
						}
						else if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
						{
							num38 = 20f;
						}
						else if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
						{
							num38 = 26f;
						}
						else if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
						{
							num38 = 56f;
						}
						else if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
						{
							num38 = 30f;
						}
						num38 *= Main.npc[i].scale;
						if (Main.npc[i].aiStyle == 10 || Main.npc[i].type == 72)
						{
							color7 = Microsoft.Xna.Framework.Color.White;
						}
						SpriteEffects effects = SpriteEffects.None;
						if (Main.npc[i].spriteDirection == 1)
						{
							effects = SpriteEffects.FlipHorizontally;
						}
						if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
						{
							this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), Microsoft.Xna.Framework.Color.White, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
						}
						else if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
						{
							Microsoft.Xna.Framework.Color alpha7 = Main.npc[i].GetAlpha(color7);
							byte b = (byte)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
							if (alpha7.R < b)
							{
								alpha7.R = b;
							}
							if (alpha7.G < b)
							{
								alpha7.G = b;
							}
							if (alpha7.B < b)
							{
								alpha7.B = b;
							}
							this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), alpha7, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
						}
						else
						{
							if (Main.npc[i].type == 94)
							{
								for (int num39 = 1; num39 < 6; num39 += 2)
								{
									Vector2 vector9 = Main.npc[i].oldPos[num39];
									Microsoft.Xna.Framework.Color alpha8 = Main.npc[i].GetAlpha(color7);
									alpha8.R = (byte)((int)alpha8.R * (10 - num39) / 15);
									alpha8.G = (byte)((int)alpha8.G * (10 - num39) / 15);
									alpha8.B = (byte)((int)alpha8.B * (10 - num39) / 15);
									alpha8.A = (byte)((int)alpha8.A * (10 - num39) / 15);
									this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num39].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num39].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), alpha8, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
							}
							if (Main.npc[i].type == 125 || Main.npc[i].type == 126 || Main.npc[i].type == 127 || Main.npc[i].type == 128 || Main.npc[i].type == 129 || Main.npc[i].type == 130 || Main.npc[i].type == 131 || Main.npc[i].type == 139 || Main.npc[i].type == 140)
							{
								for (int num40 = 9; num40 >= 0; num40 -= 2)
								{
									Vector2 vector10 = Main.npc[i].oldPos[num40];
									Microsoft.Xna.Framework.Color alpha9 = Main.npc[i].GetAlpha(color7);
									alpha9.R = (byte)((int)alpha9.R * (10 - num40) / 20);
									alpha9.G = (byte)((int)alpha9.G * (10 - num40) / 20);
									alpha9.B = (byte)((int)alpha9.B * (10 - num40) / 20);
									alpha9.A = (byte)((int)alpha9.A * (10 - num40) / 20);
									this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num40].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num40].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), alpha9, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
							}
							this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), Main.npc[i].GetAlpha(color7), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							Microsoft.Xna.Framework.Color color8 = Main.npc[i].color;
							if (color8 != default(Microsoft.Xna.Framework.Color))
							{
								this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), Main.npc[i].GetColor(color7), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].confused)
							{
								this.spriteBatch.Draw(Main.confuseTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37 - (float)Main.confuseTexture.Height - 20f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.confuseTexture.Width, Main.confuseTexture.Height)), new Microsoft.Xna.Framework.Color(250, 250, 250, 70), Main.npc[i].velocity.X * -0.05f, new Vector2((float)(Main.confuseTexture.Width / 2), (float)(Main.confuseTexture.Height / 2)), Main.essScale + 0.2f, SpriteEffects.None, 0f);
							}
							if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136 && color7 != Microsoft.Xna.Framework.Color.Black)
							{
								this.spriteBatch.Draw(Main.destTexture[Main.npc[i].type - 134], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), new Microsoft.Xna.Framework.Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].type == 125)
							{
								this.spriteBatch.Draw(Main.EyeLaserTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), new Microsoft.Xna.Framework.Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].type == 139)
							{
								this.spriteBatch.Draw(Main.probeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), new Microsoft.Xna.Framework.Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].type == 127)
							{
								this.spriteBatch.Draw(Main.BoneEyesTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].type == 131)
							{
								this.spriteBatch.Draw(Main.BoneLaserTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							if (Main.npc[i].type == 120)
							{
								for (int num41 = 1; num41 < Main.npc[i].oldPos.Length; num41++)
								{
									Vector2 vector11 = Main.npc[i].oldPos[num41];
									Microsoft.Xna.Framework.Color color9 = default(Microsoft.Xna.Framework.Color);
									color9.R = (byte)(150 * (10 - num41) / 15);
									color9.G = (byte)(100 * (10 - num41) / 15);
									color9.B = (byte)(150 * (10 - num41) / 15);
									color9.A = (byte)(50 * (10 - num41) / 15);
									this.spriteBatch.Draw(Main.chaosTexture, new Vector2(Main.npc[i].oldPos[num41].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num41].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), color9, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
							}
							else if (Main.npc[i].type == 137 || Main.npc[i].type == 138)
							{
								for (int num42 = 1; num42 < Main.npc[i].oldPos.Length; num42++)
								{
									Vector2 vector12 = Main.npc[i].oldPos[num42];
									Microsoft.Xna.Framework.Color color10 = default(Microsoft.Xna.Framework.Color);
									color10.R = (byte)(150 * (10 - num42) / 15);
									color10.G = (byte)(100 * (10 - num42) / 15);
									color10.B = (byte)(150 * (10 - num42) / 15);
									color10.A = (byte)(50 * (10 - num42) / 15);
									this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num42].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num42].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), color10, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
							}
							else if (Main.npc[i].type == 82)
							{
								this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), Microsoft.Xna.Framework.Color.White, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								for (int num43 = 1; num43 < 10; num43++)
								{
									Microsoft.Xna.Framework.Color color11 = new Microsoft.Xna.Framework.Color(110 - num43 * 10, 110 - num43 * 10, 110 - num43 * 10, 110 - num43 * 10);
									this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38) - Main.npc[i].velocity * (float)num43 * 0.5f, new Microsoft.Xna.Framework.Rectangle?(Main.npc[i].frame), color11, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
							}
						}
					}
				}
			}
		}

		protected void DrawProj(int i)
		{
			if (Main.projectile[i].type == 32)
			{
				Vector2 vector = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
				float num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
				float rotation = (float)Math.Atan2((double)num2, (double)num) - 1.57f;
				bool flag = true;
				if (num == 0f && num2 == 0f)
				{
					flag = false;
				}
				else
				{
					float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
					num3 = 8f / num3;
					num *= num3;
					num2 *= num3;
					vector.X -= num;
					vector.Y -= num2;
					num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
					num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
				}
				while (flag)
				{
					float num4 = (float)Math.Sqrt((double)(num * num + num2 * num2));
					if (num4 < 28f)
					{
						flag = false;
					}
					else
					{
						num4 = 28f / num4;
						num *= num4;
						num2 *= num4;
						vector.X += num;
						vector.Y += num2;
						num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
						num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
						Microsoft.Xna.Framework.Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
						this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain5Texture.Width, Main.chain5Texture.Height)), color, rotation, new Vector2((float)Main.chain5Texture.Width * 0.5f, (float)Main.chain5Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else if (Main.projectile[i].type == 73)
			{
				Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num5 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
				float num6 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
				float rotation2 = (float)Math.Atan2((double)num6, (double)num5) - 1.57f;
				bool flag2 = true;
				while (flag2)
				{
					float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
					if (num7 < 25f)
					{
						flag2 = false;
					}
					else
					{
						num7 = 12f / num7;
						num5 *= num7;
						num6 *= num7;
						vector2.X += num5;
						vector2.Y += num6;
						num5 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
						num6 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
						Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
						this.spriteBatch.Draw(Main.chain8Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color2, rotation2, new Vector2((float)Main.chain8Texture.Width * 0.5f, (float)Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else if (Main.projectile[i].type == 74)
			{
				Vector2 vector3 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num8 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector3.X;
				float num9 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector3.Y;
				float rotation3 = (float)Math.Atan2((double)num9, (double)num8) - 1.57f;
				bool flag3 = true;
				while (flag3)
				{
					float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
					if (num10 < 25f)
					{
						flag3 = false;
					}
					else
					{
						num10 = 12f / num10;
						num8 *= num10;
						num9 *= num10;
						vector3.X += num8;
						vector3.Y += num9;
						num8 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector3.X;
						num9 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector3.Y;
						Microsoft.Xna.Framework.Color color3 = Lighting.GetColor((int)vector3.X / 16, (int)(vector3.Y / 16f));
						this.spriteBatch.Draw(Main.chain9Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color3, rotation3, new Vector2((float)Main.chain8Texture.Width * 0.5f, (float)Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else if (Main.projectile[i].aiStyle == 7)
			{
				Vector2 vector4 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num11 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector4.X;
				float num12 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector4.Y;
				float rotation4 = (float)Math.Atan2((double)num12, (double)num11) - 1.57f;
				bool flag4 = true;
				while (flag4)
				{
					float num13 = (float)Math.Sqrt((double)(num11 * num11 + num12 * num12));
					if (num13 < 25f)
					{
						flag4 = false;
					}
					else
					{
						num13 = 12f / num13;
						num11 *= num13;
						num12 *= num13;
						vector4.X += num11;
						vector4.Y += num12;
						num11 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector4.X;
						num12 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector4.Y;
						Microsoft.Xna.Framework.Color color4 = Lighting.GetColor((int)vector4.X / 16, (int)(vector4.Y / 16f));
						this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector4.X - Main.screenPosition.X, vector4.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color4, rotation4, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else if (Main.projectile[i].aiStyle == 13)
			{
				float num14 = Main.projectile[i].position.X + 8f;
				float num15 = Main.projectile[i].position.Y + 2f;
				float num16 = Main.projectile[i].velocity.X;
				float num17 = Main.projectile[i].velocity.Y;
				float num18 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
				num18 = 20f / num18;
				if (Main.projectile[i].ai[0] == 0f)
				{
					num14 -= Main.projectile[i].velocity.X * num18;
					num15 -= Main.projectile[i].velocity.Y * num18;
				}
				else
				{
					num14 += Main.projectile[i].velocity.X * num18;
					num15 += Main.projectile[i].velocity.Y * num18;
				}
				Vector2 vector5 = new Vector2(num14, num15);
				num16 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector5.X;
				num17 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector5.Y;
				float rotation5 = (float)Math.Atan2((double)num17, (double)num16) - 1.57f;
				if (Main.projectile[i].alpha == 0)
				{
					int num19 = -1;
					if (Main.projectile[i].position.X + (float)(Main.projectile[i].width / 2) < Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2))
					{
						num19 = 1;
					}
					if (Main.player[Main.projectile[i].owner].direction == 1)
					{
						Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num17 * (float)num19), (double)(num16 * (float)num19));
					}
					else
					{
						Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num17 * (float)num19), (double)(num16 * (float)num19));
					}
				}
				bool flag5 = true;
				while (flag5)
				{
					float num20 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
					if (num20 < 25f)
					{
						flag5 = false;
					}
					else
					{
						num20 = 12f / num20;
						num16 *= num20;
						num17 *= num20;
						vector5.X += num16;
						vector5.Y += num17;
						num16 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector5.X;
						num17 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector5.Y;
						Microsoft.Xna.Framework.Color color5 = Lighting.GetColor((int)vector5.X / 16, (int)(vector5.Y / 16f));
						this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector5.X - Main.screenPosition.X, vector5.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color5, rotation5, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else if (Main.projectile[i].aiStyle == 15)
			{
				Vector2 vector6 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num21 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector6.X;
				float num22 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector6.Y;
				float rotation6 = (float)Math.Atan2((double)num22, (double)num21) - 1.57f;
				if (Main.projectile[i].alpha == 0)
				{
					int num23 = -1;
					if (Main.projectile[i].position.X + (float)(Main.projectile[i].width / 2) < Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2))
					{
						num23 = 1;
					}
					if (Main.player[Main.projectile[i].owner].direction == 1)
					{
						Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num22 * (float)num23), (double)(num21 * (float)num23));
					}
					else
					{
						Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num22 * (float)num23), (double)(num21 * (float)num23));
					}
				}
				bool flag6 = true;
				while (flag6)
				{
					float num24 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
					if (num24 < 25f)
					{
						flag6 = false;
					}
					else
					{
						num24 = 12f / num24;
						num21 *= num24;
						num22 *= num24;
						vector6.X += num21;
						vector6.Y += num22;
						num21 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector6.X;
						num22 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector6.Y;
						Microsoft.Xna.Framework.Color color6 = Lighting.GetColor((int)vector6.X / 16, (int)(vector6.Y / 16f));
						if (Main.projectile[i].type == 25)
						{
							this.spriteBatch.Draw(Main.chain2Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain2Texture.Width, Main.chain2Texture.Height)), color6, rotation6, new Vector2((float)Main.chain2Texture.Width * 0.5f, (float)Main.chain2Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
						else if (Main.projectile[i].type == 35)
						{
							this.spriteBatch.Draw(Main.chain6Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain6Texture.Width, Main.chain6Texture.Height)), color6, rotation6, new Vector2((float)Main.chain6Texture.Width * 0.5f, (float)Main.chain6Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
						else if (Main.projectile[i].type == 63)
						{
							this.spriteBatch.Draw(Main.chain7Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain7Texture.Width, Main.chain7Texture.Height)), color6, rotation6, new Vector2((float)Main.chain7Texture.Width * 0.5f, (float)Main.chain7Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
						else
						{
							this.spriteBatch.Draw(Main.chain3Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain3Texture.Width, Main.chain3Texture.Height)), color6, rotation6, new Vector2((float)Main.chain3Texture.Width * 0.5f, (float)Main.chain3Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
			Microsoft.Xna.Framework.Color newColor = Lighting.GetColor((int)((double)Main.projectile[i].position.X + (double)Main.projectile[i].width * 0.5) / 16, (int)(((double)Main.projectile[i].position.Y + (double)Main.projectile[i].height * 0.5) / 16.0));
			if (Main.projectile[i].hide)
			{
				newColor = Lighting.GetColor((int)((double)Main.player[Main.projectile[i].owner].position.X + (double)Main.player[Main.projectile[i].owner].width * 0.5) / 16, (int)(((double)Main.player[Main.projectile[i].owner].position.Y + (double)Main.player[Main.projectile[i].owner].height * 0.5) / 16.0));
			}
			if (Main.projectile[i].type == 14)
			{
				newColor = Microsoft.Xna.Framework.Color.White;
			}
			int num25 = 0;
			int num26 = 0;
			if (Main.projectile[i].type == 16)
			{
				num25 = 6;
			}
			if (Main.projectile[i].type == 17 || Main.projectile[i].type == 31)
			{
				num25 = 2;
			}
			if (Main.projectile[i].type == 25 || Main.projectile[i].type == 26 || Main.projectile[i].type == 35 || Main.projectile[i].type == 63)
			{
				num25 = 6;
				num26 -= 6;
			}
			if (Main.projectile[i].type == 28 || Main.projectile[i].type == 37 || Main.projectile[i].type == 75)
			{
				num25 = 8;
			}
			if (Main.projectile[i].type == 29)
			{
				num25 = 11;
			}
			if (Main.projectile[i].type == 43)
			{
				num25 = 4;
			}
			if (Main.projectile[i].type == 69 || Main.projectile[i].type == 70)
			{
				num25 = 4;
				num26 = 4;
			}
			float num27 = (float)(Main.projectileTexture[Main.projectile[i].type].Width - Main.projectile[i].width) * 0.5f + (float)Main.projectile[i].width * 0.5f;
			if (Main.projectile[i].type == 50 || Main.projectile[i].type == 53)
			{
				num26 = -8;
			}
			if (Main.projectile[i].type == 72 || Main.projectile[i].type == 86 || Main.projectile[i].type == 87)
			{
				num26 = -16;
				num25 = 8;
			}
			if (Main.projectile[i].type == 74)
			{
				num26 = -6;
			}
			if (Main.projectile[i].type == 99)
			{
				num25 = 1;
			}
			SpriteEffects effects = SpriteEffects.None;
			if (Main.projectile[i].spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			if (Main.projFrames[Main.projectile[i].type] > 1)
			{
				int num28 = Main.projectileTexture[Main.projectile[i].type].Height / Main.projFrames[Main.projectile[i].type];
				int y = num28 * Main.projectile[i].frame;
				this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y, Main.projectileTexture[Main.projectile[i].type].Width, num28)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
			}
			else if (Main.projectile[i].aiStyle == 19)
			{
				Vector2 origin = new Vector2(0f, 0f);
				if (Main.projectile[i].spriteDirection == -1)
				{
					origin.X = (float)Main.projectileTexture[Main.projectile[i].type].Width;
				}
				this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + (float)(Main.projectile[i].width / 2), Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, origin, Main.projectile[i].scale, effects, 0f);
			}
			else
			{
				if (Main.projectile[i].type == 94 && Main.projectile[i].ai[1] > 6f)
				{
					for (int j = 0; j < 10; j++)
					{
						Microsoft.Xna.Framework.Color alpha = Main.projectile[i].GetAlpha(newColor);
						float num29 = (float)(9 - j) / 9f;
						alpha.R = (byte)((float)alpha.R * num29);
						alpha.G = (byte)((float)alpha.G * num29);
						alpha.B = (byte)((float)alpha.B * num29);
						alpha.A = (byte)((float)alpha.A * num29);
						float num30 = (float)(9 - j) / 9f;
						this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].oldPos[j].X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].oldPos[j].Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), alpha, Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), num30 * Main.projectile[i].scale, effects, 0f);
					}
				}
				this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
				if (Main.projectile[i].type == 106)
				{
					this.spriteBatch.Draw(Main.lightDiscTexture, new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
				}
			}
		}

		private static Microsoft.Xna.Framework.Color buffColor(Microsoft.Xna.Framework.Color newColor, float R, float G, float B, float A)
		{
			newColor.R = (byte)((float)newColor.R * R);
			newColor.G = (byte)((float)newColor.G * G);
			newColor.B = (byte)((float)newColor.B * B);
			newColor.A = (byte)((float)newColor.A * A);
			return newColor;
		}

		protected void DrawWoF()
		{
			if (Main.wof >= 0 && Main.player[Main.myPlayer].gross)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
					{
						float num = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
						float num2 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
						Vector2 vector = new Vector2(Main.player[i].position.X + (float)Main.player[i].width * 0.5f, Main.player[i].position.Y + (float)Main.player[i].height * 0.5f);
						float num3 = num - vector.X;
						float num4 = num2 - vector.Y;
						float rotation = (float)Math.Atan2((double)num4, (double)num3) - 1.57f;
						bool flag = true;
						while (flag)
						{
							float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
							if (num5 < 40f)
							{
								flag = false;
							}
							else
							{
								num5 = (float)Main.chain12Texture.Height / num5;
								num3 *= num5;
								num4 *= num5;
								vector.X += num3;
								vector.Y += num4;
								num3 = num - vector.X;
								num4 = num2 - vector.Y;
								Microsoft.Xna.Framework.Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
								this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float)Main.chain12Texture.Width * 0.5f, (float)Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].aiStyle == 29)
					{
						float num6 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
						float num7 = Main.npc[Main.wof].position.Y;
						float num8 = (float)(Main.wofB - Main.wofT);
						bool flag2 = false;
						if (Main.npc[j].frameCounter > 7.0)
						{
							flag2 = true;
						}
						num7 = (float)Main.wofT + num8 * Main.npc[j].ai[0];
						Vector2 vector2 = new Vector2(Main.npc[j].position.X + (float)(Main.npc[j].width / 2), Main.npc[j].position.Y + (float)(Main.npc[j].height / 2));
						float num9 = num6 - vector2.X;
						float num10 = num7 - vector2.Y;
						float rotation2 = (float)Math.Atan2((double)num10, (double)num9) - 1.57f;
						bool flag3 = true;
						while (flag3)
						{
							SpriteEffects effects = SpriteEffects.None;
							if (flag2)
							{
								effects = SpriteEffects.FlipHorizontally;
								flag2 = false;
							}
							else
							{
								flag2 = true;
							}
							int height = 28;
							float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
							if (num11 < 40f)
							{
								height = (int)num11 - 40 + 28;
								flag3 = false;
							}
							num11 = 28f / num11;
							num9 *= num11;
							num10 *= num11;
							vector2.X += num9;
							vector2.Y += num10;
							num9 = num6 - vector2.X;
							num10 = num7 - vector2.Y;
							Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
							this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain4Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, effects, 0f);
						}
					}
				}
				int num12 = 140;
				float num13 = (float)Main.wofT;
				float num14 = (float)Main.wofB;
				num14 = Main.screenPosition.Y + (float)Main.screenHeight;
				float num15 = (float)((int)((num13 - Main.screenPosition.Y) / (float)num12) + 1);
				num15 *= (float)num12;
				if (num15 > 0f)
				{
					num13 -= num15;
				}
				float num16 = num13;
				float num17 = Main.npc[Main.wof].position.X;
				float num18 = num14 - num13;
				bool flag4 = true;
				SpriteEffects effects2 = SpriteEffects.None;
				if (Main.npc[Main.wof].spriteDirection == 1)
				{
					effects2 = SpriteEffects.FlipHorizontally;
				}
				if (Main.npc[Main.wof].direction > 0)
				{
					num17 -= 80f;
				}
				int num19 = 0;
				if (!Main.gamePaused)
				{
					Main.wofF++;
				}
				if (Main.wofF > 12)
				{
					num19 = 280;
					if (Main.wofF > 17)
					{
						Main.wofF = 0;
					}
				}
				else if (Main.wofF > 6)
				{
					num19 = 140;
				}
				while (flag4)
				{
					num18 = num14 - num16;
					if (num18 > (float)num12)
					{
						num18 = (float)num12;
					}
					bool flag5 = true;
					int num20 = 0;
					while (flag5)
					{
						int x = (int)(num17 + (float)(Main.wofTexture.Width / 2)) / 16;
						int y = (int)(num16 + (float)num20) / 16;
						this.spriteBatch.Draw(Main.wofTexture, new Vector2(num17 - Main.screenPosition.X, num16 + (float)num20 - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, num19 + num20, Main.wofTexture.Width, 16)), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
						num20 += 16;
						if ((float)num20 >= num18)
						{
							flag5 = false;
						}
					}
					num16 += (float)num12;
					if (num16 >= num14)
					{
						flag4 = false;
					}
				}
			}
		}

		protected void DrawGhost(Player drawPlayer)
		{
			SpriteEffects effects;
			if (drawPlayer.direction == 1)
			{
				effects = SpriteEffects.None;
			}
			else
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Microsoft.Xna.Framework.Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16, new Microsoft.Xna.Framework.Color((int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100))));
			Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle(0, Main.ghostTexture.Height / 4 * drawPlayer.ghostFrame, Main.ghostTexture.Width, Main.ghostTexture.Height / 4);
			Vector2 origin = new Vector2((float)value.Width * 0.5f, (float)value.Height * 0.5f);
			this.spriteBatch.Draw(Main.ghostTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X + (float)(value.Width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)(value.Height / 2)))), new Microsoft.Xna.Framework.Rectangle?(value), immuneAlpha, 0f, origin, 1f, effects, 0f);
		}

		protected void DrawPlayer(Player drawPlayer)
		{
			Microsoft.Xna.Framework.Color color = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), Microsoft.Xna.Framework.Color.White));
			Microsoft.Xna.Framework.Color color2 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.eyeColor));
			Microsoft.Xna.Framework.Color color3 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.hairColor));
			Microsoft.Xna.Framework.Color color4 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.skinColor));
			Microsoft.Xna.Framework.Color color5 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.skinColor));
			Microsoft.Xna.Framework.Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.skinColor));
			Microsoft.Xna.Framework.Color color6 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.shirtColor));
			Microsoft.Xna.Framework.Color color7 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.underShirtColor));
			Microsoft.Xna.Framework.Color color8 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.pantsColor));
			Microsoft.Xna.Framework.Color color9 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.shoeColor));
			Microsoft.Xna.Framework.Color color10 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16, Microsoft.Xna.Framework.Color.White));
			Microsoft.Xna.Framework.Color color11 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16, Microsoft.Xna.Framework.Color.White));
			Microsoft.Xna.Framework.Color color12 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16, Microsoft.Xna.Framework.Color.White));
			if (drawPlayer.shadow > 0f)
			{
				immuneAlpha = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
				color5 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
				color4 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
				color3 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
				color2 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
				color = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
			}
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 1f;
			if (drawPlayer.poisoned)
			{
				if (Main.rand.Next(50) == 0)
				{
					int num5 = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 46, 0f, 0f, 150, default(Microsoft.Xna.Framework.Color), 0.2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].fadeIn = 1.9f;
				}
				num *= 0.65f;
				num3 *= 0.75f;
			}
			if (drawPlayer.onFire)
			{
				if (Main.rand.Next(4) == 0)
				{
					int num6 = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 6, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, default(Microsoft.Xna.Framework.Color), 3f);
					Main.dust[num6].noGravity = true;
					Dust dust = Main.dust[num6];
					dust.velocity *= 1.8f;
					Dust dust2 = Main.dust[num6];
					dust2.velocity.Y = dust2.velocity.Y - 0.5f;
				}
				num3 *= 0.6f;
				num2 *= 0.7f;
			}
			if (drawPlayer.onFire2)
			{
				if (Main.rand.Next(4) == 0)
				{
					int num7 = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 75, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, default(Microsoft.Xna.Framework.Color), 3f);
					Main.dust[num7].noGravity = true;
					Dust dust3 = Main.dust[num7];
					dust3.velocity *= 1.8f;
					Dust dust4 = Main.dust[num7];
					dust4.velocity.Y = dust4.velocity.Y - 0.5f;
				}
				num3 *= 0.6f;
				num2 *= 0.7f;
			}
			if (drawPlayer.noItems)
			{
				num2 *= 0.8f;
				num *= 0.65f;
			}
			if (drawPlayer.blind)
			{
				num2 *= 0.65f;
				num *= 0.7f;
			}
			if (drawPlayer.bleed)
			{
				num2 *= 0.9f;
				num3 *= 0.9f;
				if (!drawPlayer.dead && Main.rand.Next(30) == 0)
				{
					int num8 = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 5, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
					Dust dust5 = Main.dust[num8];
					dust5.velocity.Y = dust5.velocity.Y + 0.5f;
					Dust dust6 = Main.dust[num8];
					dust6.velocity *= 0.25f;
				}
			}
			if (num != 1f || num2 != 1f || num3 != 1f || num4 != 1f)
			{
				if (drawPlayer.onFire || drawPlayer.onFire2)
				{
					color = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
					color2 = drawPlayer.GetImmuneAlpha(drawPlayer.eyeColor);
					color3 = drawPlayer.GetImmuneAlpha(drawPlayer.hairColor);
					color4 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
					color5 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
					color6 = drawPlayer.GetImmuneAlpha(drawPlayer.shirtColor);
					color7 = drawPlayer.GetImmuneAlpha(drawPlayer.underShirtColor);
					color8 = drawPlayer.GetImmuneAlpha(drawPlayer.pantsColor);
					color9 = drawPlayer.GetImmuneAlpha(drawPlayer.shoeColor);
					color10 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
					color11 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
					color12 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
				}
				else
				{
					color = Main.buffColor(color, num, num2, num3, num4);
					color2 = Main.buffColor(color2, num, num2, num3, num4);
					color3 = Main.buffColor(color3, num, num2, num3, num4);
					color4 = Main.buffColor(color4, num, num2, num3, num4);
					color5 = Main.buffColor(color5, num, num2, num3, num4);
					color6 = Main.buffColor(color6, num, num2, num3, num4);
					color7 = Main.buffColor(color7, num, num2, num3, num4);
					color8 = Main.buffColor(color8, num, num2, num3, num4);
					color9 = Main.buffColor(color9, num, num2, num3, num4);
					color10 = Main.buffColor(color10, num, num2, num3, num4);
					color11 = Main.buffColor(color11, num, num2, num3, num4);
					color12 = Main.buffColor(color12, num, num2, num3, num4);
				}
			}
			SpriteEffects effects;
			SpriteEffects effects2;
			if (drawPlayer.gravDir == 1f)
			{
				if (drawPlayer.direction == 1)
				{
					effects = SpriteEffects.None;
					effects2 = SpriteEffects.None;
				}
				else
				{
					effects = SpriteEffects.FlipHorizontally;
					effects2 = SpriteEffects.FlipHorizontally;
				}
				if (!drawPlayer.dead)
				{
					drawPlayer.legPosition.Y = 0f;
					drawPlayer.headPosition.Y = 0f;
					drawPlayer.bodyPosition.Y = 0f;
				}
			}
			else
			{
				if (drawPlayer.direction == 1)
				{
					effects = SpriteEffects.FlipVertically;
					effects2 = SpriteEffects.FlipVertically;
				}
				else
				{
					effects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
					effects2 = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
				}
				if (!drawPlayer.dead)
				{
					drawPlayer.legPosition.Y = 6f;
					drawPlayer.headPosition.Y = 6f;
					drawPlayer.bodyPosition.Y = 6f;
				}
			}
			Vector2 vector = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.75f);
			Vector2 origin = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.5f);
			Vector2 vector2 = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.4f);
			if (drawPlayer.merman)
			{
				drawPlayer.headRotation = drawPlayer.velocity.Y * (float)drawPlayer.direction * 0.1f;
				if ((double)drawPlayer.headRotation < -0.3)
				{
					drawPlayer.headRotation = -0.3f;
				}
				if ((double)drawPlayer.headRotation > 0.3)
				{
					drawPlayer.headRotation = 0.3f;
				}
			}
			else if (!drawPlayer.dead)
			{
				drawPlayer.headRotation = 0f;
			}
			if (drawPlayer.wings > 0)
			{
				this.spriteBatch.Draw(Main.wingsTexture[drawPlayer.wings], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X + (float)(drawPlayer.width / 2) - (float)(9 * drawPlayer.direction))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)(drawPlayer.height / 2) + 2f * drawPlayer.gravDir))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, Main.wingsTexture[drawPlayer.wings].Height / 4 * drawPlayer.wingFrame, Main.wingsTexture[drawPlayer.wings].Width, Main.wingsTexture[drawPlayer.wings].Height / 4)), color11, drawPlayer.bodyRotation, new Vector2((float)(Main.wingsTexture[drawPlayer.wings].Width / 2), (float)(Main.wingsTexture[drawPlayer.wings].Height / 8)), 1f, effects, 0f);
			}
			if (!drawPlayer.invis)
			{
				this.spriteBatch.Draw(Main.skinBodyTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.skinLegsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), immuneAlpha, drawPlayer.legRotation, origin, 1f, effects, 0f);
			}
			if (drawPlayer.legs > 0 && drawPlayer.legs < 25)
			{
				this.spriteBatch.Draw(Main.armorLegTexture[drawPlayer.legs], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), color12, drawPlayer.legRotation, vector, 1f, effects, 0f);
			}
			else if (!drawPlayer.invis)
			{
				if (!drawPlayer.male)
				{
					this.spriteBatch.Draw(Main.femalePantsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), color8, drawPlayer.legRotation, vector, 1f, effects, 0f);
					this.spriteBatch.Draw(Main.femaleShoesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, vector, 1f, effects, 0f);
				}
				else
				{
					this.spriteBatch.Draw(Main.playerPantsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), color8, drawPlayer.legRotation, vector, 1f, effects, 0f);
					this.spriteBatch.Draw(Main.playerShoesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, vector, 1f, effects, 0f);
				}
			}
			if (drawPlayer.body > 0 && drawPlayer.body < 26)
			{
				if (!drawPlayer.male)
				{
					this.spriteBatch.Draw(Main.femaleBodyTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				else
				{
					this.spriteBatch.Draw(Main.armorBodyTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				if ((drawPlayer.body == 10 || drawPlayer.body == 11 || drawPlayer.body == 12 || drawPlayer.body == 13 || drawPlayer.body == 14 || drawPlayer.body == 15 || drawPlayer.body == 16 || drawPlayer.body == 20) && !drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
			}
			else if (!drawPlayer.invis)
			{
				if (!drawPlayer.male)
				{
					this.spriteBatch.Draw(Main.femaleUnderShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					this.spriteBatch.Draw(Main.femaleShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				else
				{
					this.spriteBatch.Draw(Main.playerUnderShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					this.spriteBatch.Draw(Main.playerShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
			}
			if (!drawPlayer.invis && drawPlayer.head != 38)
			{
				this.spriteBatch.Draw(Main.playerHeadTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color4, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.playerEyeWhitesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.playerEyesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color2, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			if (drawPlayer.head == 10 || drawPlayer.head == 12 || drawPlayer.head == 28)
			{
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				if (!drawPlayer.invis)
				{
					Microsoft.Xna.Framework.Rectangle bodyFrame = drawPlayer.bodyFrame;
					bodyFrame.Y -= 336;
					if (bodyFrame.Y < 0)
					{
						bodyFrame.Y = 0;
					}
					this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(bodyFrame), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
			}
			if (drawPlayer.head == 14 || drawPlayer.head == 15 || drawPlayer.head == 16 || drawPlayer.head == 18 || drawPlayer.head == 21 || drawPlayer.head == 24 || drawPlayer.head == 25 || drawPlayer.head == 26 || drawPlayer.head == 40 || drawPlayer.head == 44)
			{
				Microsoft.Xna.Framework.Rectangle bodyFrame2 = drawPlayer.bodyFrame;
				bodyFrame2.Y -= 336;
				if (bodyFrame2.Y < 0)
				{
					bodyFrame2.Y = 0;
				}
				if (!drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHairAltTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(bodyFrame2), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
			}
			if (drawPlayer.head == 23)
			{
				Microsoft.Xna.Framework.Rectangle bodyFrame3 = drawPlayer.bodyFrame;
				bodyFrame3.Y -= 336;
				if (bodyFrame3.Y < 0)
				{
					bodyFrame3.Y = 0;
				}
				if (!drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(bodyFrame3), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			else if (drawPlayer.head == 14)
			{
				Microsoft.Xna.Framework.Rectangle bodyFrame4 = drawPlayer.bodyFrame;
				int num9 = 0;
				if (bodyFrame4.Y == bodyFrame4.Height * 6)
				{
					bodyFrame4.Height -= 2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 7)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 8)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 9)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 10)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 13)
				{
					bodyFrame4.Height -= 2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 14)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 15)
				{
					num9 = -2;
				}
				else if (bodyFrame4.Y == bodyFrame4.Height * 16)
				{
					num9 = -2;
				}
				bodyFrame4.Y += num9;
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f + (float)num9))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(bodyFrame4), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			else if (drawPlayer.head > 0 && drawPlayer.head < 45 && drawPlayer.head != 28)
			{
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			else if (!drawPlayer.invis)
			{
				Microsoft.Xna.Framework.Rectangle bodyFrame5 = drawPlayer.bodyFrame;
				bodyFrame5.Y -= 336;
				if (bodyFrame5.Y < 0)
				{
					bodyFrame5.Y = 0;
				}
				this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Microsoft.Xna.Framework.Rectangle?(bodyFrame5), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			if (drawPlayer.heldProj >= 0)
			{
				this.DrawProj(drawPlayer.heldProj);
			}
			Microsoft.Xna.Framework.Color color13 = Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0));
			if ((drawPlayer.itemAnimation > 0 || drawPlayer.inventory[drawPlayer.selectedItem].holdStyle > 0) && drawPlayer.inventory[drawPlayer.selectedItem].type > 0 && !drawPlayer.dead && !drawPlayer.inventory[drawPlayer.selectedItem].noUseGraphic && (!drawPlayer.wet || !drawPlayer.inventory[drawPlayer.selectedItem].noWet))
			{
				if (drawPlayer.inventory[drawPlayer.selectedItem].useStyle == 5)
				{
					int num10 = 10;
					Vector2 vector3 = new Vector2((float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width / 2), (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					if (drawPlayer.inventory[drawPlayer.selectedItem].type == 95)
					{
						num10 = 10;
						vector3.Y += 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 96)
					{
						num10 = -5;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 98)
					{
						num10 = -5;
						vector3.Y -= 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 534)
					{
						num10 = -2;
						vector3.Y += 1f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 533)
					{
						num10 = -7;
						vector3.Y -= 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 506)
					{
						num10 = 0;
						vector3.Y -= 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 494 || drawPlayer.inventory[drawPlayer.selectedItem].type == 508)
					{
						num10 = -2;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 434)
					{
						num10 = 0;
						vector3.Y -= 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 514)
					{
						num10 = 0;
						vector3.Y += 3f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 435 || drawPlayer.inventory[drawPlayer.selectedItem].type == 436 || drawPlayer.inventory[drawPlayer.selectedItem].type == 481 || drawPlayer.inventory[drawPlayer.selectedItem].type == 578)
					{
						num10 = -2;
						vector3.Y -= 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 197)
					{
						num10 = -5;
						vector3.Y += 4f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 126)
					{
						num10 = 4;
						vector3.Y += 4f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 127)
					{
						num10 = 4;
						vector3.Y += 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 157)
					{
						num10 = 6;
						vector3.Y += 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 160)
					{
						num10 = -8;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 164 || drawPlayer.inventory[drawPlayer.selectedItem].type == 219)
					{
						num10 = 2;
						vector3.Y += 4f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 165 || drawPlayer.inventory[drawPlayer.selectedItem].type == 272)
					{
						num10 = 4;
						vector3.Y += 4f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 266)
					{
						num10 = 0;
						vector3.Y += 2f * drawPlayer.gravDir;
					}
					else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 281)
					{
						num10 = 6;
						vector3.Y -= 6f * drawPlayer.gravDir;
					}
					Vector2 origin2 = new Vector2(-(float)num10, (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					if (drawPlayer.direction == -1)
					{
						origin2 = new Vector2((float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width + num10), (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					}
					this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X + vector3.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y + vector3.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Microsoft.Xna.Framework.Color))
					{
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X + vector3.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y + vector3.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					}
				}
				else if (drawPlayer.gravDir == -1f)
				{
					this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Microsoft.Xna.Framework.Color))
					{
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					}
				}
				else
				{
					if (drawPlayer.inventory[drawPlayer.selectedItem].type == 425 || drawPlayer.inventory[drawPlayer.selectedItem].type == 507)
					{
						if (drawPlayer.gravDir == 1f)
						{
							if (drawPlayer.direction == 1)
							{
								effects2 = SpriteEffects.FlipVertically;
							}
							else
							{
								effects2 = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
							}
						}
						else if (drawPlayer.direction == 1)
						{
							effects2 = SpriteEffects.None;
						}
						else
						{
							effects2 = SpriteEffects.FlipHorizontally;
						}
					}
					this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Microsoft.Xna.Framework.Color))
					{
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					}
				}
			}
			if (drawPlayer.body > 0 && drawPlayer.body < 26)
			{
				this.spriteBatch.Draw(Main.armorArmTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				if ((drawPlayer.body == 10 || drawPlayer.body == 11 || drawPlayer.body == 12 || drawPlayer.body == 13 || drawPlayer.body == 14 || drawPlayer.body == 15 || drawPlayer.body == 16 || drawPlayer.body == 20) && !drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
			}
			else if (!drawPlayer.invis)
			{
				if (!drawPlayer.male)
				{
					this.spriteBatch.Draw(Main.femaleUnderShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					this.spriteBatch.Draw(Main.femaleShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				else
				{
					this.spriteBatch.Draw(Main.playerUnderShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
			}
		}

		private static void HelpText()
		{
			bool flag = false;
			if (Main.player[Main.myPlayer].statLifeMax > 100)
			{
				flag = true;
			}
			bool flag2 = false;
			if (Main.player[Main.myPlayer].statManaMax > 0)
			{
				flag2 = true;
			}
			bool flag3 = true;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 48; i++)
			{
				if (Main.player[Main.myPlayer].inventory[i].pick > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Pickaxe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].axe > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Axe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].hammer > 0)
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 11 || Main.player[Main.myPlayer].inventory[i].type == 12 || Main.player[Main.myPlayer].inventory[i].type == 13 || Main.player[Main.myPlayer].inventory[i].type == 14)
				{
					flag4 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 19 || Main.player[Main.myPlayer].inventory[i].type == 20 || Main.player[Main.myPlayer].inventory[i].type == 21 || Main.player[Main.myPlayer].inventory[i].type == 22)
				{
					flag5 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
				{
					flag6 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
				{
					flag7 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 68 || Main.player[Main.myPlayer].inventory[i].type == 70)
				{
					flag8 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 84)
				{
					flag9 = true;
				}
			}
			bool flag10 = false;
			bool flag11 = false;
			bool flag12 = false;
			bool flag13 = false;
			bool flag14 = false;
			bool flag15 = false;
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active)
				{
					if (Main.npc[j].type == 17)
					{
						flag10 = true;
					}
					if (Main.npc[j].type == 18)
					{
						flag11 = true;
					}
					if (Main.npc[j].type == 19)
					{
						flag13 = true;
					}
					if (Main.npc[j].type == 20)
					{
						flag12 = true;
					}
					if (Main.npc[j].type == 54)
					{
						flag18 = true;
					}
					if (Main.npc[j].type == 124)
					{
						flag15 = true;
					}
					if (Main.npc[j].type == 107)
					{
						flag14 = true;
					}
					if (Main.npc[j].type == 108)
					{
						flag16 = true;
					}
					if (Main.npc[j].type == 38)
					{
						flag17 = true;
					}
				}
			}
			while (true)
			{
				Main.helpText++;
				if (flag3)
				{
					if (Main.helpText == 1)
					{
						break;
					}
					if (Main.helpText == 2)
					{
						goto Block_35;
					}
					if (Main.helpText == 3)
					{
						goto Block_36;
					}
					if (Main.helpText == 4)
					{
						goto Block_37;
					}
					if (Main.helpText == 5)
					{
						goto Block_38;
					}
					if (Main.helpText == 6)
					{
						goto Block_39;
					}
				}
				if (flag3 && !flag4 && !flag5 && Main.helpText == 11)
				{
					goto Block_43;
				}
				if (flag3 && flag4 && !flag5)
				{
					if (Main.helpText == 21)
					{
						goto Block_47;
					}
					if (Main.helpText == 22)
					{
						goto Block_48;
					}
				}
				if (flag3 && flag5)
				{
					if (Main.helpText == 31)
					{
						goto Block_51;
					}
					if (Main.helpText == 32)
					{
						goto Block_52;
					}
				}
				if (!flag && Main.helpText == 41)
				{
					goto Block_54;
				}
				if (!flag2 && Main.helpText == 42)
				{
					goto Block_56;
				}
				if (!flag2 && !flag6 && Main.helpText == 43)
				{
					goto Block_59;
				}
				if (!flag10 && !flag11)
				{
					if (Main.helpText == 51)
					{
						goto Block_62;
					}
					if (Main.helpText == 52)
					{
						goto Block_63;
					}
					if (Main.helpText == 53)
					{
						goto Block_64;
					}
					if (Main.helpText == 54)
					{
						goto Block_65;
					}
				}
				if (!flag10 && Main.helpText == 61)
				{
					goto Block_67;
				}
				if (!flag11 && Main.helpText == 62)
				{
					goto Block_69;
				}
				if (!flag13 && Main.helpText == 63)
				{
					goto Block_71;
				}
				if (!flag12 && Main.helpText == 64)
				{
					goto Block_73;
				}
				if (!flag15 && Main.helpText == 65 && NPC.downedBoss3)
				{
					goto Block_76;
				}
				if (!flag18 && Main.helpText == 66 && NPC.downedBoss3)
				{
					goto Block_79;
				}
				if (!flag14 && Main.helpText == 67)
				{
					goto Block_81;
				}
				if (!flag17 && NPC.downedBoss2 && Main.helpText == 68)
				{
					goto Block_84;
				}
				if (!flag16 && Main.hardMode && Main.helpText == 69)
				{
					goto Block_87;
				}
				if (flag7 && Main.helpText == 71)
				{
					goto Block_89;
				}
				if (flag8 && Main.helpText == 72)
				{
					goto Block_91;
				}
				if ((flag7 || flag8) && Main.helpText == 80)
				{
					goto Block_93;
				}
				if (!flag9 && Main.helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
				{
					goto Block_98;
				}
				if (Main.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_101;
				}
				if (Main.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_104;
				}
				if (Main.helpText == 1002 && !NPC.downedBoss3)
				{
					goto Block_106;
				}
				if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
				{
					goto Block_109;
				}
				if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
				{
					goto Block_112;
				}
				if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
				{
					goto Block_116;
				}
				if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
				{
					goto Block_120;
				}
				if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_124;
				}
				if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_128;
				}
				if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
				{
					goto Block_132;
				}
				if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
				{
					goto Block_138;
				}
				if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_144;
				}
				if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_150;
				}
				if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_156;
				}
				if (Main.helpText == 1061 && Main.hardMode)
				{
					goto Block_158;
				}
				if (Main.helpText == 1062 && Main.hardMode)
				{
					goto Block_160;
				}
				if (Main.helpText > 1100)
				{
					Main.helpText = 0;
				}
			}
			Main.npcChatText = "你可以用锄头去挖掘泥土与矿石，也可以用斧去砍伐树木。要完成这些操作，你需将光标移动到目标上然后点击。";
			return;
			Block_35:
			Main.npcChatText = "如果你想在这个世界上生存下来，那么你需要去制造武器并建造住所。首先，你要去砍伐树木以收集木材。";
			return;
			Block_36:
			Main.npcChatText = "按住ESC键进入你的菜单栏,注意左下角制作栏，你可以利用木材来制造出一个工作台。然后站在它旁边，它能帮助你制造出比手工艺制品更为复杂的物品。";
			return;
			Block_37:
			Main.npcChatText = "你可以通过放置木材或砖块来建造一个房屋，不要忘记去布置背墙。";
			return;
			Block_38:
			Main.npcChatText = "一旦你拥有了木剑，你可以尝试着用它去杀死史莱姆，并收集掉落的史莱姆凝胶。木材和史莱姆凝胶可以合成火把！";
			return;
			Block_39:
			Main.npcChatText = "想去掉已经放置过的背墙和家具的话，就造一把锤子！";
			return;
			Block_43:
			Main.npcChatText = "你可以用采集到的矿石制造出非常有用的物品。";
			return;
			Block_47:
			Main.npcChatText = "做得不错！现在你有矿石了，先用熔炉去把它们熔制成锭，然后再用铁砧把锭制作成物品。";
			return;
			Block_48:
			Main.npcChatText = "熔炉可以用火把,木材和石块制作而成，当然你必须站在工作台旁边。";
			return;
			Block_51:
			Main.npcChatText = "你要通过铁砧来把锭制作成实用的工具，武器和防具。";
			return;
			Block_52:
			Main.npcChatText = "铁砧可以用铁锭来合成，也可以去商人那里购买。";
			return;
			Block_54:
			Main.npcChatText = "在地底深处存在着一些可以增加你最大血量的生命水晶，你可以用锤子去把它敲下来。";
			return;
			Block_56:
			Main.npcChatText = "如果你收集到10颗落星，就能用它们合成一颗增加法力容量的魔力水晶。";
			return;
			Block_59:
			Main.npcChatText = "夜晚会有星星掉落，它们在很多地方都有用途。如果你发现它，请尽快获取并保存好，因为在日出后，落到地面的星星就会消失。";
			return;
			Block_62:
			Main.npcChatText = "你可以通过各种各样的方法来让人们住进我们的房子，当然，房子里要有闲置的理想房间。";
			return;
			Block_63:
			Main.npcChatText = "一个房间能否居住，关键在于它是否具备以下条件：一个能使人休息的家具、一个能提供置物平面的家具、一个光源、以及用砖块堆砌出的完整空间和密不透风的背景墙。";
			return;
			Block_64:
			Main.npcChatText = "2个人永远不会住进一个房间，而且，如果他们的房间被破坏掉的话，他们会另外寻找可以居住的地方。";
			return;
			Block_65:
			Main.npcChatText = "你可以使用住宅界面来观察和管理居住状态。打开物品栏，点击右边的房屋图标。";
			return;
			Block_67:
			Main.npcChatText = "如果你想要吸引商人住进来，那你就得去收集大量钱币，达成这目标需要50银币。";
			return;
			Block_69:
			Main.npcChatText = "如果你要想护士居住进来，应该先增加你的最大生命，去收集生命水晶吧。";
			return;
			Block_71:
			Main.npcChatText = "如果你得到一把枪，我敢打赌一定会有个军火商想居住进来并向你出售弹药。";
			return;
			Block_73:
			Main.npcChatText = "你可以通过击败一只强大的怪物来证明自己，而这同时也会让你得到树妖的关注。";
			return;
			Block_76:
			Main.npcChatText = "如果你打算探索地牢，那就最好彻底一点，也许能找到被囚禁在地牢深处的人们。";
			return;
			Block_79:
			Main.npcChatText = "如果你解除了地牢旁边那个怪老头身上的诅咒，说不定他会愿意加入我们。";
			return;
			Block_81:
			Main.npcChatText = "收好任何你发现到的炸弹，因为爆破专家也许会对它们很感兴趣。";
			return;
			Block_84:
			Main.npcChatText = "地精难道就真的与我们差别太大而无法和平相处吗？";
			return;
			Block_87:
			Main.npcChatText = "我听说有一个强大的巫师住在附近，下次你去地底探索时记得留心寻找他的踪迹。";
			return;
			Block_89:
			Main.npcChatText = "如果你拿着晶状体在恶魔祭坛旁边合成的话，也许就能找到召唤某种强力怪物的方法，不过你可能要等待夜晚降临。";
			return;
			Block_91:
			Main.npcChatText = "你可以在恶魔祭坛用腐肉和邪恶粉末合成蠕虫诱食。别忘了只有在腐化之地才能使用诱饵。";
			return;
			Block_93:
			Main.npcChatText = "在腐化之地的地底深处，恶魔祭坛是很常见的，你可以在它附近合成某些特殊物品。";
			return;
			Block_98:
			Main.npcChatText = "你可以用钩子和铁链制作合成抓钩。在地底的骷髅怪物常常会携带着钩子。至于铁链，则是用铁锭制作而成。";
			return;
			Block_101:
			Main.npcChatText = "如果你看到罐子，不要犹豫打碎它吧，里面有很多有用的补给品。";
			return;
			Block_104:
			Main.npcChatText = "世界各处都隐藏着神秘宝藏，而在地下深处就有一些让人惊叹的宝物等着你去寻找！";
			return;
			Block_106:
			Main.npcChatText = "设法破坏暗影之球将会有一定机率引发陨石坠落，暗影之球位于腐化之地中的裂隙深处。";
			return;
			Block_109:
			Main.npcChatText = "你现在应该将重点放在寻找水晶之心上面，这样才能增加你的最大生命值。";
			return;
			Block_112:
			Main.npcChatText = "你目前的装备糟糕透顶，你最好想办法打造更好的护甲。";
			return;
			Block_116:
			Main.npcChatText = "看起来你已经为你的第一场恶战准备充分了。在夜间杀死一些眼球类怪物，收集它们掉落的晶状体，然后去恶魔祭坛旁边看看吧。";
			return;
			Block_120:
			Main.npcChatText = "想要进行下一想挑战？你最好再把你的血量提高些，等你有15颗红心的血量就差不多了。";
			return;
			Block_124:
			Main.npcChatText = "腐化之地的黑檀石可以被从树妖那里买来的净化粉末所净化，或者你也可以试试某些烈性炸药。";
			return;
			Block_128:
			Main.npcChatText = "接下来，你应该去探索腐化之地的裂隙了，打碎所有你能找到的暗影之球吧！";
			return;
			Block_132:
			Main.npcChatText = "离这里不远的地方有一座古老的地牢，你如果有空就找找看吧。";
			return;
			Block_138:
			Main.npcChatText = "你应该尝试加满你的最大生命值，那是20颗红心的血量。加油吧。";
			return;
			Block_144:
			Main.npcChatText = "地下丛林埋藏着非常多的宝藏，如果你愿意挖得更深一点，那就去转转吧！";
			return;
			Block_150:
			Main.npcChatText = "地底的最深处是由一种名为‘狱岩石’的矿物组成的，那是打造武器和防具的上好材料。";
			return;
			Block_156:
			Main.npcChatText = "如果你真的想挑战地底世界的领主，那么你需要一个活人来当做祭品……你可以在地下深处找到这种黑暗仪式所需的物品。";
			return;
			Block_158:
			Main.npcChatText = "别忘了尽量破坏你能找到的所有恶魔祭坛，我才不会告诉你将会有好事发生呢！";
			return;
			Block_160:
			Main.npcChatText = "杀死神圣领域或腐化领域的生物，有时能得到他们的灵魂。";
		}

		protected void DrawChat()
		{
			if (Main.player[Main.myPlayer].talkNPC < 0 && Main.player[Main.myPlayer].sign == -1)
			{
				Main.npcChatText = "";
			}
			else
			{
				if (Main.netMode == 0 && Main.autoPause && Main.player[Main.myPlayer].talkNPC >= 0)
				{
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 105)
					{
						Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(107);
					}
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 106)
					{
						Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(108);
					}
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 123)
					{
						Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(124);
					}
				}
				Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(200, 200, 200, 200);
				int num = (int)((Main.mouseTextColor * 2 + 255) / 3);
				Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color(num, num, num, num);
				int num2 = 10;
				int num3 = 0;
				string[] array = new string[num2];
				int num4 = 0;
				int num5 = 0;
				bool flag = true;
				if (Main.npcChatText == null)
				{
					Main.npcChatText = "";
				}
				for (int i = 0; i < Main.npcChatText.Length; i++)
				{
					flag = (Convert.ToChar(Main.npcChatText.Substring(i, 1)) < '¡' || !flag);
					if (Encoding.UTF8.GetBytes(Main.npcChatText.Substring(i, 1))[0] == 10)
					{
						array[num3] = Main.npcChatText.Substring(num4, i - num4);
						num3++;
						num4 = i + 1;
						num5 = i + 1;
					}
					else if (flag || i == Main.npcChatText.Length - 1)
					{
						if (Main.fontMouseText.MeasureString(Main.npcChatText.Substring(num4, i - num4)).X > 470f)
						{
							array[num3] = Main.npcChatText.Substring(num4, num5 - num4);
							num3++;
							num4 = num5 + 1;
						}
						num5 = i;
					}
					if (num3 == 10)
					{
						Main.npcChatText = Main.npcChatText.Substring(0, i - 1);
						num4 = i - 1;
						num3 = 9;
						break;
					}
				}
				if (num3 < 10)
				{
					array[num3] = Main.npcChatText.Substring(num4, Main.npcChatText.Length - num4);
				}
				if (Main.editSign)
				{
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					if (this.textBlinkerState == 1)
					{
						string[] array2;
						IntPtr value;
						(array2 = array)[(int)(value = (IntPtr)num3)] = array2[(int)value] + "|";
					}
				}
				num3++;
				this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), 100f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chatBackTexture.Width, (num3 + 1) * 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), (float)(100 + (num3 + 1) * 30)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, Main.chatBackTexture.Height - 30, Main.chatBackTexture.Width, 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				for (int j = 0; j < num3; j++)
				{
					for (int k = 0; k < 5; k++)
					{
						Microsoft.Xna.Framework.Color color3 = Microsoft.Xna.Framework.Color.Black;
						int num6 = 170 + (Main.screenWidth - 800) / 2;
						int num7 = 120 + j * 30;
						if (k == 0)
						{
							num6 -= 2;
						}
						if (k == 1)
						{
							num6 += 2;
						}
						if (k == 2)
						{
							num7 -= 2;
						}
						if (k == 3)
						{
							num7 += 2;
						}
						if (k == 4)
						{
							color3 = color2;
						}
						this.DStoDSX(Main.fontMouseText, array[j], new Vector2((float)num6, (float)num7), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					}
				}
				num = (int)Main.mouseTextColor;
				color2 = new Microsoft.Xna.Framework.Color(num, (int)((double)num / 1.1), num / 2, num);
				string text = "";
				string text2 = "";
				int num8 = Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife;
				for (int l = 0; l < 10; l++)
				{
					int num9 = Main.player[Main.myPlayer].buffType[l];
					if (Main.debuff[num9] && Main.player[Main.myPlayer].buffTime[l] > 0 && num9 != 28 && num9 != 34)
					{
						num8 += 1000;
					}
				}
				if (Main.player[Main.myPlayer].sign > -1)
				{
					if (Main.editSign)
					{
						text = "保存";
					}
					else
					{
						text = "编辑";
					}
				}
				else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
				{
					text = "商店";
					text2 = "状态";
				}
				else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
				{
					text = "商店";
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
					{
						text2 = "锻造";
					}
				}
				else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
				{
					if (!Main.dayTime)
					{
						text = "诅咒";
					}
				}
				else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
				{
					text = "帮助";
					text2 = "制作帮助";
				}
				else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
				{
					string text3 = "";
					int num10 = 0;
					int num11 = 0;
					int num12 = 0;
					int num13 = 0;
					int num14 = num8;
					if (num14 > 0)
					{
						num14 = (int)((double)num14 * 0.75);
						if (num14 < 1)
						{
							num14 = 1;
						}
					}
					if (num14 < 0)
					{
						num14 = 0;
					}
					num8 = num14;
					if (num14 >= 1000000)
					{
						num10 = num14 / 1000000;
						num14 -= num10 * 1000000;
					}
					if (num14 >= 10000)
					{
						num11 = num14 / 10000;
						num14 -= num11 * 10000;
					}
					if (num14 >= 100)
					{
						num12 = num14 / 100;
						num14 -= num12 * 100;
					}
					if (num14 >= 1)
					{
						num13 = num14;
					}
					if (num10 > 0)
					{
						text3 = text3 + num10 + " 白金币 ";
					}
					if (num11 > 0)
					{
						text3 = text3 + num11 + " 金币 ";
					}
					if (num12 > 0)
					{
						text3 = text3 + num12 + " 银币 ";
					}
					if (num13 > 0)
					{
						text3 = text3 + num13 + " 铜币 ";
					}
					float num15 = (float)Main.mouseTextColor / 255f;
					if (num10 > 0)
					{
						color2 = new Microsoft.Xna.Framework.Color((int)((byte)(220f * num15)), (int)((byte)(220f * num15)), (int)((byte)(198f * num15)), (int)Main.mouseTextColor);
					}
					else if (num11 > 0)
					{
						color2 = new Microsoft.Xna.Framework.Color((int)((byte)(224f * num15)), (int)((byte)(201f * num15)), (int)((byte)(92f * num15)), (int)Main.mouseTextColor);
					}
					else if (num12 > 0)
					{
						color2 = new Microsoft.Xna.Framework.Color((int)((byte)(181f * num15)), (int)((byte)(192f * num15)), (int)((byte)(193f * num15)), (int)Main.mouseTextColor);
					}
					else if (num13 > 0)
					{
						color2 = new Microsoft.Xna.Framework.Color((int)((byte)(246f * num15)), (int)((byte)(138f * num15)), (int)((byte)(96f * num15)), (int)Main.mouseTextColor);
					}
					text = "治疗 (" + text3 + ")";
					if (num14 == 0)
					{
						text = "治疗";
					}
				}
				int num16 = 180 + (Main.screenWidth - 800) / 2;
				int num17 = 130 + num3 * 30;
				float scale = 0.9f;
				if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text).Y)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					scale = 1.1f;
					if (!Main.npcChatFocus2)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus2 = true;
					Main.player[Main.myPlayer].releaseUseItem = false;
				}
				else
				{
					if (Main.npcChatFocus2)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus2 = false;
				}
				for (int m = 0; m < 5; m++)
				{
					int num18 = num16;
					int num19 = num17;
					Microsoft.Xna.Framework.Color color4 = Microsoft.Xna.Framework.Color.Black;
					if (m == 0)
					{
						num18 -= 2;
					}
					if (m == 1)
					{
						num18 += 2;
					}
					if (m == 2)
					{
						num19 -= 2;
					}
					if (m == 3)
					{
						num19 += 2;
					}
					if (m == 4)
					{
						color4 = color2;
					}
					Vector2 vector = Main.fontMouseText.MeasureString(text);
					vector *= 0.5f;
					this.DStoDSX(Main.fontMouseText, text, new Vector2((float)num18 + vector.X, (float)num19 + vector.Y), color4, 0f, vector, scale, SpriteEffects.None, 0f);
				}
				color2 = new Microsoft.Xna.Framework.Color(num, (int)((double)num / 1.1), num / 2, num);
				num16 = num16 + (int)Main.fontMouseText.MeasureString(text).X + 20;
				num17 = 130 + num3 * 30;
				scale = 0.9f;
				if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString("关闭").X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString("关闭").Y)
				{
					scale = 1.1f;
					if (!Main.npcChatFocus1)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus1 = true;
					Main.player[Main.myPlayer].releaseUseItem = false;
					Main.player[Main.myPlayer].controlUseItem = false;
				}
				else
				{
					if (Main.npcChatFocus1)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus1 = false;
				}
				for (int n = 0; n < 5; n++)
				{
					int num20 = num16;
					int num21 = num17;
					Microsoft.Xna.Framework.Color color5 = Microsoft.Xna.Framework.Color.Black;
					if (n == 0)
					{
						num20 -= 2;
					}
					if (n == 1)
					{
						num20 += 2;
					}
					if (n == 2)
					{
						num21 -= 2;
					}
					if (n == 3)
					{
						num21 += 2;
					}
					if (n == 4)
					{
						color5 = color2;
					}
					Vector2 vector2 = Main.fontMouseText.MeasureString("关闭");
					vector2 *= 0.5f;
					this.DStoDSX(Main.fontMouseText, "关闭", new Vector2((float)num20 + vector2.X, (float)num21 + vector2.Y), color5, 0f, vector2, scale, SpriteEffects.None, 0f);
				}
				if (text2 != "")
				{
					num16 = 296 + (Main.screenWidth - 800) / 2;
					num17 = 130 + num3 * 30;
					scale = 0.9f;
					if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text2).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text2).Y)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						scale = 1.1f;
						if (!Main.npcChatFocus3)
						{
							Main.PlaySound(12, -1, -1, 1);
						}
						Main.npcChatFocus3 = true;
						Main.player[Main.myPlayer].releaseUseItem = false;
					}
					else
					{
						if (Main.npcChatFocus3)
						{
							Main.PlaySound(12, -1, -1, 1);
						}
						Main.npcChatFocus3 = false;
					}
					for (int num22 = 0; num22 < 5; num22++)
					{
						int num23 = num16;
						int num24 = num17;
						Microsoft.Xna.Framework.Color color6 = Microsoft.Xna.Framework.Color.Black;
						if (num22 == 0)
						{
							num23 -= 2;
						}
						if (num22 == 1)
						{
							num23 += 2;
						}
						if (num22 == 2)
						{
							num24 -= 2;
						}
						if (num22 == 3)
						{
							num24 += 2;
						}
						if (num22 == 4)
						{
							color6 = color2;
						}
						Vector2 vector3 = Main.fontMouseText.MeasureString(text);
						vector3 *= 0.5f;
						this.DStoDSX(Main.fontMouseText, text2, new Vector2((float)num23 + vector3.X, (float)num24 + vector3.Y), color6, 0f, vector3, scale, SpriteEffects.None, 0f);
					}
				}
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					Main.mouseLeftRelease = false;
					Main.player[Main.myPlayer].releaseUseItem = false;
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.npcChatFocus1)
					{
						Main.player[Main.myPlayer].talkNPC = -1;
						Main.player[Main.myPlayer].sign = -1;
						Main.editSign = false;
						Main.npcChatText = "";
						Main.PlaySound(11, -1, -1, 1);
					}
					else if (Main.npcChatFocus2)
					{
						if (Main.player[Main.myPlayer].sign != -1)
						{
							if (!Main.editSign)
							{
								Main.PlaySound(12, -1, -1, 1);
								Main.editSign = true;
							}
							else
							{
								Main.PlaySound(12, -1, -1, 1);
								int num25 = Main.player[Main.myPlayer].sign;
								Sign.TextSign(num25, Main.npcChatText);
								Main.editSign = false;
								if (Main.netMode == 1)
								{
									NetMessage.SendData(47, -1, -1, "", num25, 0f, 0f, 0f, 0);
								}
							}
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 1;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 2;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 8;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 9;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
						{
							if (Main.netMode == 0)
							{
								NPC.SpawnSkeletron();
							}
							else
							{
								NetMessage.SendData(51, -1, -1, "", Main.myPlayer, 1f, 0f, 0f, 0);
							}
							Main.npcChatText = "";
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 3;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 4;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 5;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 6;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 7;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.HelpText();
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
						{
							Main.PlaySound(12, -1, -1, 1);
							if (num8 > 0)
							{
								if (Main.player[Main.myPlayer].BuyItem(num8))
								{
									Main.PlaySound(2, -1, -1, 4);
									Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife);
									if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.25)
									{
										Main.npcChatText = "你说我把你的脸缝歪了？没关系，反正也没谁在乎你长什么样子。";
									}
									else if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.5)
									{
										Main.npcChatText = "这样的伤口可是会留下疤痕喔。";
									}
									else if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.75)
									{
										Main.npcChatText = "好了。不过我可不想再看到你从悬崖上跳下来。";
									}
									else
									{
										Main.npcChatText = "刚才不是很疼吧，那么现在呢？";
									}
									Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
									for (int num26 = 0; num26 < 10; num26++)
									{
										int num27 = Main.player[Main.myPlayer].buffType[num26];
										if (Main.debuff[num27] && Main.player[Main.myPlayer].buffTime[num26] > 0 && num27 != 28 && num27 != 34)
										{
											Main.player[Main.myPlayer].DelBuff(num26);
										}
									}
								}
								else
								{
									int num28 = Main.rand.Next(3);
									if (num28 == 0)
									{
										Main.npcChatText = "先付款、后救命。";
									}
									if (num28 == 1)
									{
										Main.npcChatText = "像这种手术，得另外加钱……";
									}
									if (num28 == 2)
									{
										Main.npcChatText = "你以为会两下子就可以免费？";
									}
								}
							}
							else
							{
								int num29 = Main.rand.Next(3);
								if (num29 == 0)
								{
									Main.npcChatText = "别动手动脚的。";
								}
								if (num29 == 1)
								{
									Main.npcChatText = "除了给你整形之外我也帮不了你什么忙了。";
								}
								if (num29 == 2)
								{
									Main.npcChatText = "别浪费我的时间。";
								}
							}
						}
					}
					else if (Main.npcChatFocus3 && Main.player[Main.myPlayer].talkNPC >= 0)
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.PlaySound(12, -1, -1, 1);
							string str;
							if (WorldGen.tGood == 0)
							{
								str = string.Concat(new object[]
								{
									Main.worldName,
									" 已经 ",
									WorldGen.tEvil,
									"% 被腐化了。"
								});
							}
							else if (WorldGen.tEvil == 0)
							{
								str = string.Concat(new object[]
								{
									Main.worldName,
									" 已经 ",
									WorldGen.tGood,
									"% 被神圣化。"
								});
							}
							else
							{
								str = string.Concat(new object[]
								{
									Main.worldName,
									" 已经 ",
									WorldGen.tGood,
									"% 被神圣化、 ",
									WorldGen.tEvil,
									"% 被腐化了。"
								});
							}
							if (WorldGen.tGood > WorldGen.tEvil)
							{
								str += " 再接再厉吧！";
							}
							else if (WorldGen.tEvil > WorldGen.tGood && WorldGen.tEvil > 20)
							{
								str += " 情况确实很严酷。";
							}
							else
							{
								str += " 你应该更加努力。";
							}
							Main.npcChatText = str;
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.craftGuide = true;
						}
						else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.reforge = true;
						}
					}
				}
			}
		}

		private static bool AccCheck(Item newItem, int slot)
		{
			bool result;
			if (Main.player[Main.myPlayer].armor[slot].IsTheSameAs(newItem))
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
				{
					if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}

		public static Item armorSwap(Item newItem)
		{
			for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
			{
				if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
				{
					Main.accSlotCount = i;
				}
			}
			Item result;
			if (newItem.headSlot == -1 && newItem.bodySlot == -1 && newItem.legSlot == -1 && !newItem.accessory)
			{
				result = newItem;
			}
			else
			{
				Item item = newItem;
				if (newItem.headSlot != -1)
				{
					item = (Item)Main.player[Main.myPlayer].armor[0].Clone();
					Main.player[Main.myPlayer].armor[0] = (Item)newItem.Clone();
				}
				else if (newItem.bodySlot != -1)
				{
					item = (Item)Main.player[Main.myPlayer].armor[1].Clone();
					Main.player[Main.myPlayer].armor[1] = (Item)newItem.Clone();
				}
				else if (newItem.legSlot != -1)
				{
					item = (Item)Main.player[Main.myPlayer].armor[2].Clone();
					Main.player[Main.myPlayer].armor[2] = (Item)newItem.Clone();
				}
				else if (newItem.accessory)
				{
					for (int j = 3; j < 8; j++)
					{
						if (Main.player[Main.myPlayer].armor[j].type == 0)
						{
							Main.accSlotCount = j - 3;
							break;
						}
					}
					for (int k = 0; k < Main.player[Main.myPlayer].armor.Length; k++)
					{
						if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[k]))
						{
							Main.accSlotCount = k - 3;
						}
					}
					if (Main.accSlotCount >= 5)
					{
						Main.accSlotCount = 0;
					}
					if (Main.accSlotCount < 0)
					{
						Main.accSlotCount = 4;
					}
					item = (Item)Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
					Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = (Item)newItem.Clone();
					Main.accSlotCount++;
					if (Main.accSlotCount >= 5)
					{
						Main.accSlotCount = 0;
					}
				}
				Main.PlaySound(7, -1, -1, 1);
				Recipe.FindRecipes();
				result = item;
			}
			return result;
		}

		public static void BankCoins()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Main.player[Main.myPlayer].bank[i].type >= 71 && Main.player[Main.myPlayer].bank[i].type <= 73 && Main.player[Main.myPlayer].bank[i].stack == Main.player[Main.myPlayer].bank[i].maxStack)
				{
					Main.player[Main.myPlayer].bank[i].SetDefaults(Main.player[Main.myPlayer].bank[i].type + 1, false);
					for (int j = 0; j < 20; j++)
					{
						if (j != i && Main.player[Main.myPlayer].bank[j].type == Main.player[Main.myPlayer].bank[i].type && Main.player[Main.myPlayer].bank[j].stack < Main.player[Main.myPlayer].bank[j].maxStack)
						{
							Main.player[Main.myPlayer].bank[j].stack++;
							Main.player[Main.myPlayer].bank[i].SetDefaults(0, false);
							Main.BankCoins();
						}
					}
				}
			}
		}

		public static void ChestCoins()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Main.chest[Main.player[Main.myPlayer].chest].item[i].type >= 71 && Main.chest[Main.player[Main.myPlayer].chest].item[i].type <= 73 && Main.chest[Main.player[Main.myPlayer].chest].item[i].stack == Main.chest[Main.player[Main.myPlayer].chest].item[i].maxStack)
				{
					Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(Main.chest[Main.player[Main.myPlayer].chest].item[i].type + 1, false);
					for (int j = 0; j < 20; j++)
					{
						if (j != i && Main.chest[Main.player[Main.myPlayer].chest].item[j].type == Main.chest[Main.player[Main.myPlayer].chest].item[i].type && Main.chest[Main.player[Main.myPlayer].chest].item[j].stack < Main.chest[Main.player[Main.myPlayer].chest].item[j].maxStack)
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)j, 0f, 0f, 0);
							}
							Main.chest[Main.player[Main.myPlayer].chest].item[j].stack++;
							Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(0, false);
							Main.ChestCoins();
						}
					}
				}
			}
		}

		protected void DrawNPCHouse()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].townNPC && !Main.npc[i].homeless && Main.npc[i].homeTileX > 0 && Main.npc[i].homeTileY > 0 && Main.npc[i].type != 37)
				{
					int num = 1;
					int num2 = Main.npc[i].homeTileX;
					int num3 = Main.npc[i].homeTileY - 1;
					if (Main.tile[num2, num3] != null)
					{
						bool flag = false;
						while (!Main.tile[num2, num3].active || !Main.tileSolid[(int)Main.tile[num2, num3].type])
						{
							num3--;
							if (num3 < 10)
							{
								break;
							}
							if (Main.tile[num2, num3] == null)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							int num4 = 8;
							int num5 = 18;
							if (Main.tile[num2, num3].type == 19)
							{
								num5 -= 8;
							}
							num3++;
							this.spriteBatch.Draw(Main.bannerTexture[num], new Vector2((float)(num2 * 16 - (int)Main.screenPosition.X + num4), (float)(num3 * 16 - (int)Main.screenPosition.Y + num5)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.bannerTexture[num].Width, Main.bannerTexture[num].Height)), Lighting.GetColor(num2, num3), 0f, new Vector2((float)(Main.bannerTexture[num].Width / 2), (float)(Main.bannerTexture[num].Height / 2)), 1f, SpriteEffects.None, 0f);
							int num6 = NPC.TypeToNum(Main.npc[i].type);
							float scale = 1f;
							float num7;
							if (Main.npcHeadTexture[num6].Width > Main.npcHeadTexture[num6].Height)
							{
								num7 = (float)Main.npcHeadTexture[num6].Width;
							}
							else
							{
								num7 = (float)Main.npcHeadTexture[num6].Height;
							}
							if (num7 > 24f)
							{
								scale = 24f / num7;
							}
							this.spriteBatch.Draw(Main.npcHeadTexture[num6], new Vector2((float)(num2 * 16 - (int)Main.screenPosition.X + num4), (float)(num3 * 16 - (int)Main.screenPosition.Y + num5 + 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.npcHeadTexture[num6].Width, Main.npcHeadTexture[num6].Height)), Lighting.GetColor(num2, num3), 0f, new Vector2((float)(Main.npcHeadTexture[num6].Width / 2), (float)(Main.npcHeadTexture[num6].Height / 2)), scale, SpriteEffects.None, 0f);
							num2 = num2 * 16 - (int)Main.screenPosition.X + num4 - Main.bannerTexture[num].Width / 2;
							num3 = num3 * 16 - (int)Main.screenPosition.Y + num5 - Main.bannerTexture[num].Height / 2;
							if (Main.mouseX >= num2 && Main.mouseX <= num2 + Main.bannerTexture[num].Width && Main.mouseY >= num3 && Main.mouseY <= num3 + Main.bannerTexture[num].Height)
							{
								this.MouseText(Main.npc[i].displayCName + " the " + Main.npc[i].CName, 0, 0);
								if (Main.mouseRightRelease && Main.mouseRight)
								{
									Main.mouseRightRelease = false;
									WorldGen.kickOut(i);
									Main.PlaySound(12, -1, -1, 1);
								}
							}
						}
					}
				}
			}
		}

		protected void DrawInterface()
		{
			if (this.showNPCs)
			{
				this.DrawNPCHouse();
			}
			if (Main.player[Main.myPlayer].selectedItem == 48 && Main.player[Main.myPlayer].itemAnimation > 0)
			{
				Main.mouseLeftRelease = false;
			}
			Main.mouseHC = false;
			if (Main.hideUI)
			{
				Main.maxQ = true;
			}
			else
			{
				Vector2 origin;
				if (Main.player[Main.myPlayer].rulerAcc)
				{
					int num = (int)((float)((int)(Main.screenPosition.X / 16f) * 16) - Main.screenPosition.X);
					int num2 = (int)((float)((int)(Main.screenPosition.Y / 16f) * 16) - Main.screenPosition.Y);
					int num3 = Main.screenWidth / Main.gridTexture.Width;
					int num4 = Main.screenHeight / Main.gridTexture.Height;
					for (int i = 0; i <= num3 + 1; i++)
					{
						for (int j = 0; j <= num4 + 1; j++)
						{
							SpriteBatch spriteBatch = this.spriteBatch;
							Texture2D texture = Main.gridTexture;
							Vector2 position = new Vector2((float)(i * Main.gridTexture.Width + num), (float)(j * Main.gridTexture.Height + num2));
							Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.gridTexture.Width, Main.gridTexture.Height));
							Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(100, 100, 100, 15);
							float rotation = 0f;
							origin = default(Vector2);
							spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.netDiag)
				{
					for (int k = 0; k < 4; k++)
					{
						string text = "";
						int num5 = 20;
						int num6 = 220;
						if (k == 0)
						{
							text = "RX Msgs: " + string.Format("{0:0,0}", Main.rxMsg);
							num6 += k * 20;
						}
						else if (k == 1)
						{
							text = "RX Bytes: " + string.Format("{0:0,0}", Main.rxData);
							num6 += k * 20;
						}
						else if (k == 2)
						{
							text = "TX Msgs: " + string.Format("{0:0,0}", Main.txMsg);
							num6 += k * 20;
						}
						else if (k == 3)
						{
							text = "TX Bytes: " + string.Format("{0:0,0}", Main.txData);
							num6 += k * 20;
						}
						SpriteBatch spriteBatch2 = this.spriteBatch;
						SpriteFontX spriteFont = Main.fontMouseText;
						string text2 = text;
						Vector2 position2 = new Vector2((float)num5, (float)num6);
						Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
						float rotation2 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont, text2, position2, white, rotation2, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int l = 0; l < Main.maxMsg; l++)
					{
						int num7 = 200;
						int num8 = 120;
						num8 += l * 15;
						string text3 = l + ": ";
						SpriteBatch spriteBatch3 = this.spriteBatch;
						SpriteFontX spriteFont2 = Main.fontMouseText;
						string text4 = text3;
						Vector2 position3 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white2 = Microsoft.Xna.Framework.Color.White;
						float rotation3 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont2, text4, position3, white2, rotation3, origin, 0.8f, SpriteEffects.None, 0f);
						num7 += 30;
						text3 = "rx:" + string.Format("{0:0,0}", Main.rxMsgType[l]);
						SpriteBatch spriteBatch4 = this.spriteBatch;
						SpriteFontX spriteFont3 = Main.fontMouseText;
						string text5 = text3;
						Vector2 position4 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white3 = Microsoft.Xna.Framework.Color.White;
						float rotation4 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont3, text5, position4, white3, rotation4, origin, 0.8f, SpriteEffects.None, 0f);
						num7 += 70;
						text3 = string.Format("{0:0,0}", Main.rxDataType[l]);
						SpriteBatch spriteBatch5 = this.spriteBatch;
						SpriteFontX spriteFont4 = Main.fontMouseText;
						string text6 = text3;
						Vector2 position5 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white4 = Microsoft.Xna.Framework.Color.White;
						float rotation5 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont4, text6, position5, white4, rotation5, origin, 0.8f, SpriteEffects.None, 0f);
						num7 += 70;
						text3 = l + ": ";
						SpriteBatch spriteBatch6 = this.spriteBatch;
						SpriteFontX spriteFont5 = Main.fontMouseText;
						string text7 = text3;
						Vector2 position6 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white5 = Microsoft.Xna.Framework.Color.White;
						float rotation6 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont5, text7, position6, white5, rotation6, origin, 0.8f, SpriteEffects.None, 0f);
						num7 += 30;
						text3 = "tx:" + string.Format("{0:0,0}", Main.txMsgType[l]);
						SpriteBatch spriteBatch7 = this.spriteBatch;
						SpriteFontX spriteFont6 = Main.fontMouseText;
						string text8 = text3;
						Vector2 position7 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white6 = Microsoft.Xna.Framework.Color.White;
						float rotation7 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont6, text8, position7, white6, rotation7, origin, 0.8f, SpriteEffects.None, 0f);
						num7 += 70;
						text3 = string.Format("{0:0,0}", Main.txDataType[l]);
						SpriteBatch spriteBatch8 = this.spriteBatch;
						SpriteFontX spriteFont7 = Main.fontMouseText;
						string text9 = text3;
						Vector2 position8 = new Vector2((float)num7, (float)num8);
						Microsoft.Xna.Framework.Color white7 = Microsoft.Xna.Framework.Color.White;
						float rotation8 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont7, text9, position8, white7, rotation8, origin, 0.8f, SpriteEffects.None, 0f);
					}
				}
				if (Main.drawDiag)
				{
					for (int m = 0; m < 7; m++)
					{
						string text10 = "";
						int num9 = 20;
						int num10 = 220;
						num10 += m * 16;
						if (m == 0)
						{
							text10 = "实心砖块:";
						}
						if (m == 1)
						{
							text10 = "杂项砖块:";
						}
						if (m == 2)
						{
							text10 = "墙壁砖块:";
						}
						if (m == 3)
						{
							text10 = "背景砖块:";
						}
						if (m == 4)
						{
							text10 = "水体砖块:";
						}
						if (m == 5)
						{
							text10 = "黑色砖块:";
						}
						if (m == 6)
						{
							text10 = "渲染总计:";
						}
						SpriteBatch spriteBatch9 = this.spriteBatch;
						SpriteFontX spriteFont8 = Main.fontMouseText;
						string text11 = text10;
						Vector2 position9 = new Vector2((float)num9, (float)num10);
						Microsoft.Xna.Framework.Color white8 = Microsoft.Xna.Framework.Color.White;
						float rotation9 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont8, text11, position9, white8, rotation9, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int n = 0; n < 7; n++)
					{
						string text12 = "";
						int num11 = 180;
						int num12 = 220;
						num12 += n * 16;
						if (n == 0)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 1)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 2)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 3)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 4)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 5)
						{
							text12 = Main.renderTimer[n] + "毫秒";
						}
						if (n == 6)
						{
							text12 = Main.renderTimer[0] + Main.renderTimer[1] + Main.renderTimer[2] + Main.renderTimer[3] + Main.renderTimer[4] + Main.renderTimer[5] + "ms";
						}
						SpriteBatch spriteBatch10 = this.spriteBatch;
						SpriteFontX spriteFont9 = Main.fontMouseText;
						string text13 = text12;
						Vector2 position10 = new Vector2((float)num11, (float)num12);
						Microsoft.Xna.Framework.Color white9 = Microsoft.Xna.Framework.Color.White;
						float rotation10 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont9, text13, position10, white9, rotation10, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int num13 = 0; num13 < 6; num13++)
					{
						string text14 = "";
						int num14 = 20;
						int num15 = 346;
						num15 += num13 * 16;
						if (num13 == 0)
						{
							text14 = "光效初始化:";
						}
						if (num13 == 1)
						{
							text14 = "光效阶段 #1:";
						}
						if (num13 == 2)
						{
							text14 = "光效阶段 #2:";
						}
						if (num13 == 3)
						{
							text14 = "光效阶段 #3";
						}
						if (num13 == 4)
						{
							text14 = "光效阶段 #4";
						}
						if (num13 == 5)
						{
							text14 = "光效合计:";
						}
						SpriteBatch spriteBatch11 = this.spriteBatch;
						SpriteFontX spriteFont10 = Main.fontMouseText;
						string text15 = text14;
						Vector2 position11 = new Vector2((float)num14, (float)num15);
						Microsoft.Xna.Framework.Color white10 = Microsoft.Xna.Framework.Color.White;
						float rotation11 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont10, text15, position11, white10, rotation11, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int num16 = 0; num16 < 6; num16++)
					{
						string text16 = "";
						int num17 = 180;
						int num18 = 346;
						num18 += num16 * 16;
						if (num16 == 0)
						{
							text16 = Main.lightTimer[num16] + "毫秒";
						}
						if (num16 == 1)
						{
							text16 = Main.lightTimer[num16] + "毫秒";
						}
						if (num16 == 2)
						{
							text16 = Main.lightTimer[num16] + "毫秒";
						}
						if (num16 == 3)
						{
							text16 = Main.lightTimer[num16] + "毫秒";
						}
						if (num16 == 4)
						{
							text16 = Main.lightTimer[num16] + "毫秒";
						}
						if (num16 == 5)
						{
							text16 = Main.lightTimer[0] + Main.lightTimer[1] + Main.lightTimer[2] + Main.lightTimer[3] + Main.lightTimer[4] + "ms";
						}
						SpriteBatch spriteBatch12 = this.spriteBatch;
						SpriteFontX spriteFont11 = Main.fontMouseText;
						string text17 = text16;
						Vector2 position12 = new Vector2((float)num17, (float)num18);
						Microsoft.Xna.Framework.Color white11 = Microsoft.Xna.Framework.Color.White;
						float rotation12 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont11, text17, position12, white11, rotation12, origin, 1f, SpriteEffects.None, 0f);
					}
					int num19 = 5;
					for (int num20 = 0; num20 < num19; num20++)
					{
						int num21 = 20;
						int num22 = 456;
						num22 += num20 * 16;
						string text18 = "渲染 #" + num20 + ":";
						SpriteBatch spriteBatch13 = this.spriteBatch;
						SpriteFontX spriteFont12 = Main.fontMouseText;
						string text19 = text18;
						Vector2 position13 = new Vector2((float)num21, (float)num22);
						Microsoft.Xna.Framework.Color white12 = Microsoft.Xna.Framework.Color.White;
						float rotation13 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont12, text19, position13, white12, rotation13, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int num23 = 0; num23 < num19; num23++)
					{
						int num24 = 180;
						int num25 = 456;
						num25 += num23 * 16;
						string text20 = Main.drawTimer[num23] + "毫秒";
						SpriteBatch spriteBatch14 = this.spriteBatch;
						SpriteFontX spriteFont13 = Main.fontMouseText;
						string text21 = text20;
						Vector2 position14 = new Vector2((float)num24, (float)num25);
						Microsoft.Xna.Framework.Color white13 = Microsoft.Xna.Framework.Color.White;
						float rotation14 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont13, text21, position14, white13, rotation14, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int num26 = 0; num26 < num19; num26++)
					{
						int num27 = 230;
						int num28 = 456;
						num28 += num26 * 16;
						string text22 = Main.drawTimerMax[num26] + "毫秒";
						SpriteBatch spriteBatch15 = this.spriteBatch;
						SpriteFontX spriteFont14 = Main.fontMouseText;
						string text23 = text22;
						Vector2 position15 = new Vector2((float)num27, (float)num28);
						Microsoft.Xna.Framework.Color white14 = Microsoft.Xna.Framework.Color.White;
						float rotation15 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont14, text23, position15, white14, rotation15, origin, 1f, SpriteEffects.None, 0f);
					}
					int num29 = 20;
					int num30 = 456 + 16 * num19 + 16;
					string text24 = "更新:";
					SpriteBatch spriteBatch16 = this.spriteBatch;
					SpriteFontX spriteFont15 = Main.fontMouseText;
					string text25 = text24;
					Vector2 position16 = new Vector2((float)num29, (float)num30);
					Microsoft.Xna.Framework.Color white15 = Microsoft.Xna.Framework.Color.White;
					float rotation16 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont15, text25, position16, white15, rotation16, origin, 1f, SpriteEffects.None, 0f);
					num29 = 180;
					text24 = Main.upTimer + "毫秒";
					SpriteBatch spriteBatch17 = this.spriteBatch;
					SpriteFontX spriteFont16 = Main.fontMouseText;
					string text26 = text24;
					Vector2 position17 = new Vector2((float)num29, (float)num30);
					Microsoft.Xna.Framework.Color white16 = Microsoft.Xna.Framework.Color.White;
					float rotation17 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont16, text26, position17, white16, rotation17, origin, 1f, SpriteEffects.None, 0f);
					num29 = 230;
					text24 = Main.upTimerMax + "毫秒";
					SpriteBatch spriteBatch18 = this.spriteBatch;
					SpriteFontX spriteFont17 = Main.fontMouseText;
					string text27 = text24;
					Vector2 position18 = new Vector2((float)num29, (float)num30);
					Microsoft.Xna.Framework.Color white17 = Microsoft.Xna.Framework.Color.White;
					float rotation18 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont17, text27, position18, white17, rotation18, origin, 1f, SpriteEffects.None, 0f);
				}
				if (Main.signBubble)
				{
					int num31 = (int)((float)Main.signX - Main.screenPosition.X);
					int num32 = (int)((float)Main.signY - Main.screenPosition.Y);
					SpriteEffects effects = SpriteEffects.None;
					if ((float)Main.signX > Main.player[Main.myPlayer].position.X + (float)Main.player[Main.myPlayer].width)
					{
						effects = SpriteEffects.FlipHorizontally;
						num31 += -8 - Main.chat2Texture.Width;
					}
					else
					{
						num31 += 8;
					}
					num32 -= 22;
					SpriteBatch spriteBatch19 = this.spriteBatch;
					Texture2D texture2 = Main.chat2Texture;
					Vector2 position19 = new Vector2((float)num31, (float)num32);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chat2Texture.Width, Main.chat2Texture.Height));
					Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation19 = 0f;
					origin = default(Vector2);
					spriteBatch19.Draw(texture2, position19, sourceRectangle2, color2, rotation19, origin, 1f, effects, 0f);
					Main.signBubble = false;
				}
				for (int num33 = 0; num33 < 255; num33++)
				{
					if (Main.player[num33].active && Main.myPlayer != num33 && !Main.player[num33].dead)
					{
						new Microsoft.Xna.Framework.Rectangle((int)((double)Main.player[num33].position.X + (double)Main.player[num33].width * 0.5 - 16.0), (int)(Main.player[num33].position.Y + (float)Main.player[num33].height - 48f), 32, 48);
						if (Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[num33].team)
						{
							new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
							string text28 = Main.player[num33].name;
							if (Main.player[num33].statLife < Main.player[num33].statLifeMax)
							{
								object obj = text28;
								text28 = string.Concat(new object[]
								{
									obj,
									": ",
									Main.player[num33].statLife,
									"/",
									Main.player[num33].statLifeMax
								});
							}
							Vector2 vector = Main.fontMouseText.MeasureString(text28);
							float num34 = 0f;
							if (Main.player[num33].chatShowTime > 0)
							{
								num34 = -vector.Y;
							}
							float num35 = 0f;
							float num36 = (float)Main.mouseTextColor / 255f;
							Microsoft.Xna.Framework.Color color3 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.teamColor[Main.player[num33].team].R * num36)), (int)((byte)((float)Main.teamColor[Main.player[num33].team].G * num36)), (int)((byte)((float)Main.teamColor[Main.player[num33].team].B * num36)), (int)Main.mouseTextColor);
							Vector2 vector2 = new Vector2((float)(Main.screenWidth / 2) + Main.screenPosition.X, (float)(Main.screenHeight / 2) + Main.screenPosition.Y);
							float num37 = Main.player[num33].position.X + (float)(Main.player[num33].width / 2) - vector2.X;
							float num38 = Main.player[num33].position.Y - vector.Y - 2f + num34 - vector2.Y;
							float num39 = (float)Math.Sqrt((double)(num37 * num37 + num38 * num38));
							int num40 = Main.screenHeight;
							if (Main.screenHeight > Main.screenWidth)
							{
								num40 = Main.screenWidth;
							}
							num40 = num40 / 2 - 30;
							if (num40 < 100)
							{
								num40 = 100;
							}
							if (num39 < (float)num40)
							{
								vector.X = Main.player[num33].position.X + (float)(Main.player[num33].width / 2) - vector.X / 2f - Main.screenPosition.X;
								vector.Y = Main.player[num33].position.Y - vector.Y - 2f + num34 - Main.screenPosition.Y;
							}
							else
							{
								num35 = num39;
								num39 = (float)num40 / num39;
								vector.X = (float)(Main.screenWidth / 2) + num37 * num39 - vector.X / 2f;
								vector.Y = (float)(Main.screenHeight / 2) + num38 * num39;
							}
							if (num35 > 0f)
							{
								string text29 = "(" + (int)(num35 / 16f * 2f) + " 英尺)";
								Vector2 vector3 = Main.fontMouseText.MeasureString(text29);
								vector3.X = vector.X + Main.fontMouseText.MeasureString(text28).X / 2f - vector3.X / 2f;
								vector3.Y = vector.Y + Main.fontMouseText.MeasureString(text28).Y / 2f - vector3.Y / 2f - 20f;
								SpriteBatch spriteBatch20 = this.spriteBatch;
								SpriteFontX spriteFont18 = Main.fontMouseText;
								string text30 = text29;
								Vector2 position20 = new Vector2(vector3.X - 2f, vector3.Y);
								Microsoft.Xna.Framework.Color black = Microsoft.Xna.Framework.Color.Black;
								float rotation20 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont18, text30, position20, black, rotation20, origin, 1f, SpriteEffects.None, 0f);
								SpriteBatch spriteBatch21 = this.spriteBatch;
								SpriteFontX spriteFont19 = Main.fontMouseText;
								string text31 = text29;
								Vector2 position21 = new Vector2(vector3.X + 2f, vector3.Y);
								Microsoft.Xna.Framework.Color black2 = Microsoft.Xna.Framework.Color.Black;
								float rotation21 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont19, text31, position21, black2, rotation21, origin, 1f, SpriteEffects.None, 0f);
								SpriteBatch spriteBatch22 = this.spriteBatch;
								SpriteFontX spriteFont20 = Main.fontMouseText;
								string text32 = text29;
								Vector2 position22 = new Vector2(vector3.X, vector3.Y - 2f);
								Microsoft.Xna.Framework.Color black3 = Microsoft.Xna.Framework.Color.Black;
								float rotation22 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont20, text32, position22, black3, rotation22, origin, 1f, SpriteEffects.None, 0f);
								SpriteBatch spriteBatch23 = this.spriteBatch;
								SpriteFontX spriteFont21 = Main.fontMouseText;
								string text33 = text29;
								Vector2 position23 = new Vector2(vector3.X, vector3.Y + 2f);
								Microsoft.Xna.Framework.Color black4 = Microsoft.Xna.Framework.Color.Black;
								float rotation23 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont21, text33, position23, black4, rotation23, origin, 1f, SpriteEffects.None, 0f);
								SpriteBatch spriteBatch24 = this.spriteBatch;
								SpriteFontX spriteFont22 = Main.fontMouseText;
								string text34 = text29;
								Vector2 position24 = vector3;
								Microsoft.Xna.Framework.Color color4 = color3;
								float rotation24 = 0f;
								this.DStoDSX(spriteFont22, text34, position24, color4, rotation24, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							SpriteBatch spriteBatch25 = this.spriteBatch;
							SpriteFontX spriteFont23 = Main.fontMouseText;
							string text35 = text28;
							Vector2 position25 = new Vector2(vector.X - 2f, vector.Y);
							Microsoft.Xna.Framework.Color black5 = Microsoft.Xna.Framework.Color.Black;
							float rotation25 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont23, text35, position25, black5, rotation25, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch26 = this.spriteBatch;
							SpriteFontX spriteFont24 = Main.fontMouseText;
							string text36 = text28;
							Vector2 position26 = new Vector2(vector.X + 2f, vector.Y);
							Microsoft.Xna.Framework.Color black6 = Microsoft.Xna.Framework.Color.Black;
							float rotation26 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont24, text36, position26, black6, rotation26, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch27 = this.spriteBatch;
							SpriteFontX spriteFont25 = Main.fontMouseText;
							string text37 = text28;
							Vector2 position27 = new Vector2(vector.X, vector.Y - 2f);
							Microsoft.Xna.Framework.Color black7 = Microsoft.Xna.Framework.Color.Black;
							float rotation27 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont25, text37, position27, black7, rotation27, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch28 = this.spriteBatch;
							SpriteFontX spriteFont26 = Main.fontMouseText;
							string text38 = text28;
							Vector2 position28 = new Vector2(vector.X, vector.Y + 2f);
							Microsoft.Xna.Framework.Color black8 = Microsoft.Xna.Framework.Color.Black;
							float rotation28 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont26, text38, position28, black8, rotation28, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch29 = this.spriteBatch;
							SpriteFontX spriteFont27 = Main.fontMouseText;
							string text39 = text28;
							Vector2 position29 = vector;
							Microsoft.Xna.Framework.Color color5 = color3;
							float rotation29 = 0f;
							this.DStoDSX(spriteFont27, text39, position29, color5, rotation29, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.playerInventory)
				{
					Main.npcChatText = "";
					Main.player[Main.myPlayer].sign = -1;
				}
				if (Main.ignoreErrors)
				{
					try
					{
						if (Main.npcChatText != "" || Main.player[Main.myPlayer].sign != -1)
						{
							this.DrawChat();
						}
						goto IL_1AC8;
					}
					catch
					{
						goto IL_1AC8;
					}
				}
				if (Main.npcChatText != "" || Main.player[Main.myPlayer].sign != -1)
				{
					this.DrawChat();
				}
				IL_1AC8:
				Microsoft.Xna.Framework.Color color6 = new Microsoft.Xna.Framework.Color(220, 220, 220, 220);
				Main.invAlpha += Main.invDir * 0.2f;
				if (Main.invAlpha > 240f)
				{
					Main.invAlpha = 240f;
					Main.invDir = -1f;
				}
				if (Main.invAlpha < 180f)
				{
					Main.invAlpha = 180f;
					Main.invDir = 1f;
				}
				color6 = new Microsoft.Xna.Framework.Color((int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha));
				bool flag = false;
				int rare = 0;
				int num41 = Main.screenWidth - 800;
				int num42 = Main.player[Main.myPlayer].statLifeMax / 20;
				if (num42 >= 10)
				{
					num42 = 10;
				}
				string str = string.Concat(new object[]
				{
					"生命: ",
					Main.player[Main.myPlayer].statLifeMax,
					"/",
					Main.player[Main.myPlayer].statLifeMax
				});
				Vector2 vector4 = Main.fontMouseText.MeasureString(str);
				if (!Main.player[Main.myPlayer].ghost)
				{
					SpriteBatch spriteBatch30 = this.spriteBatch;
					SpriteFontX spriteFont28 = Main.fontMouseText;
					string text40 = "生命: ";
					Vector2 position30 = new Vector2((float)(500 + 13 * num42) - vector4.X * 0.5f + (float)num41, 6f);
					Microsoft.Xna.Framework.Color color7 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation30 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont28, text40, position30, color7, rotation30, origin, 1f, SpriteEffects.None, 0f);
					this.DStoDSX(Main.fontMouseText, Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax, new Vector2((float)(500 + 13 * num42) + vector4.X * 0.5f + (float)num41, 6f), new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, new Vector2(Main.fontMouseText.MeasureString(Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax).X, 0f), 1f, SpriteEffects.None, 0f);
				}
				int num43 = 20;
				for (int num44 = 1; num44 < Main.player[Main.myPlayer].statLifeMax / num43 + 1; num44++)
				{
					float num45 = 1f;
					bool flag2 = false;
					int num46;
					if (Main.player[Main.myPlayer].statLife >= num44 * num43)
					{
						num46 = 255;
						if (Main.player[Main.myPlayer].statLife == num44 * num43)
						{
							flag2 = true;
						}
					}
					else
					{
						float num47 = (float)(Main.player[Main.myPlayer].statLife - (num44 - 1) * num43) / (float)num43;
						num46 = (int)(30f + 225f * num47);
						if (num46 < 30)
						{
							num46 = 30;
						}
						num45 = num47 / 4f + 0.75f;
						if ((double)num45 < 0.75)
						{
							num45 = 0.75f;
						}
						if (num47 > 0f)
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						num45 += Main.cursorScale - 1f;
					}
					int num48 = 0;
					int num49 = 0;
					if (num44 > 10)
					{
						num48 -= 260;
						num49 += 26;
					}
					int a = (int)((double)((float)num46) * 0.9);
					if (!Main.player[Main.myPlayer].ghost)
					{
						this.spriteBatch.Draw(Main.heartTexture, new Vector2((float)(500 + 26 * (num44 - 1) + num48 + num41 + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num45) / 2f + (float)num49 + (float)(Main.heartTexture.Height / 2)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Microsoft.Xna.Framework.Color(num46, num46, num46, a), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num45, SpriteEffects.None, 0f);
					}
				}
				int num50 = 20;
				if (Main.player[Main.myPlayer].statManaMax2 > 0)
				{
					int num51 = Main.player[Main.myPlayer].statManaMax2 / 20;
					SpriteBatch spriteBatch31 = this.spriteBatch;
					SpriteFontX spriteFont29 = Main.fontMouseText;
					string text41 = "魔力";
					Vector2 position31 = new Vector2((float)(750 + num41), 6f);
					Microsoft.Xna.Framework.Color color8 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation31 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont29, text41, position31, color8, rotation31, origin, 1f, SpriteEffects.None, 0f);
					for (int num52 = 1; num52 < Main.player[Main.myPlayer].statManaMax2 / num50 + 1; num52++)
					{
						bool flag3 = false;
						float num53 = 1f;
						int num54;
						if (Main.player[Main.myPlayer].statMana >= num52 * num50)
						{
							num54 = 255;
							if (Main.player[Main.myPlayer].statMana == num52 * num50)
							{
								flag3 = true;
							}
						}
						else
						{
							float num55 = (float)(Main.player[Main.myPlayer].statMana - (num52 - 1) * num50) / (float)num50;
							num54 = (int)(30f + 225f * num55);
							if (num54 < 30)
							{
								num54 = 30;
							}
							num53 = num55 / 4f + 0.75f;
							if ((double)num53 < 0.75)
							{
								num53 = 0.75f;
							}
							if (num55 > 0f)
							{
								flag3 = true;
							}
						}
						if (flag3)
						{
							num53 += Main.cursorScale - 1f;
						}
						int a2 = (int)((double)((float)num54) * 0.9);
						this.spriteBatch.Draw(Main.manaTexture, new Vector2((float)(775 + num41), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num53) / 2f + (float)(28 * (num52 - 1))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Microsoft.Xna.Framework.Color(num54, num54, num54, a2), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num53, SpriteEffects.None, 0f);
					}
				}
				if (Main.player[Main.myPlayer].breath < Main.player[Main.myPlayer].breathMax && !Main.player[Main.myPlayer].ghost)
				{
					int num56 = 76;
					int num57 = Main.player[Main.myPlayer].breathMax / 20;
					SpriteBatch spriteBatch32 = this.spriteBatch;
					SpriteFontX spriteFont30 = Main.fontMouseText;
					string text42 = "氧气";
					Vector2 position32 = new Vector2((float)(500 + 13 * num42) - Main.fontMouseText.MeasureString("Breath").X * 0.5f + (float)num41, (float)(6 + num56));
					Microsoft.Xna.Framework.Color color9 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation32 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont30, text42, position32, color9, rotation32, origin, 1f, SpriteEffects.None, 0f);
					int num58 = 20;
					for (int num59 = 1; num59 < Main.player[Main.myPlayer].breathMax / num58 + 1; num59++)
					{
						float num60 = 1f;
						int num61;
						if (Main.player[Main.myPlayer].breath >= num59 * num58)
						{
							num61 = 255;
						}
						else
						{
							float num62 = (float)(Main.player[Main.myPlayer].breath - (num59 - 1) * num58) / (float)num58;
							num61 = (int)(30f + 225f * num62);
							if (num61 < 30)
							{
								num61 = 30;
							}
							num60 = num62 / 4f + 0.75f;
							if ((double)num60 < 0.75)
							{
								num60 = 0.75f;
							}
						}
						int num63 = 0;
						int num64 = 0;
						if (num59 > 10)
						{
							num63 -= 260;
							num64 += 26;
						}
						SpriteBatch spriteBatch33 = this.spriteBatch;
						Texture2D texture3 = Main.bubbleTexture;
						Vector2 position33 = new Vector2((float)(500 + 26 * (num59 - 1) + num63 + num41), 32f + ((float)Main.bubbleTexture.Height - (float)Main.bubbleTexture.Height * num60) / 2f + (float)num64 + (float)num56);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle3 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height));
						Microsoft.Xna.Framework.Color color10 = new Microsoft.Xna.Framework.Color(num61, num61, num61, num61);
						float rotation33 = 0f;
						origin = default(Vector2);
						spriteBatch33.Draw(texture3, position33, sourceRectangle3, color10, rotation33, origin, num60, SpriteEffects.None, 0f);
					}
				}
				Main.buffString = "";
				if (!Main.playerInventory)
				{
					int num65 = -1;
					for (int num66 = 0; num66 < 10; num66++)
					{
						if (Main.player[Main.myPlayer].buffType[num66] > 0)
						{
							int num67 = Main.player[Main.myPlayer].buffType[num66];
							int num68 = 32 + num66 * 38;
							int num69 = 76;
							Microsoft.Xna.Framework.Color color11 = new Microsoft.Xna.Framework.Color(Main.buffAlpha[num66], Main.buffAlpha[num66], Main.buffAlpha[num66], Main.buffAlpha[num66]);
							SpriteBatch spriteBatch34 = this.spriteBatch;
							Texture2D texture4 = Main.buffTexture[num67];
							Vector2 position34 = new Vector2((float)num68, (float)num69);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle4 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.buffTexture[num67].Width, Main.buffTexture[num67].Height));
							Microsoft.Xna.Framework.Color color12 = color11;
							float rotation34 = 0f;
							origin = default(Vector2);
							spriteBatch34.Draw(texture4, position34, sourceRectangle4, color12, rotation34, origin, 1f, SpriteEffects.None, 0f);
							if (num67 != 28 && num67 != 34 && num67 != 37 && num67 != 38)
							{
								string text43;
								if (Main.player[Main.myPlayer].buffTime[num66] / 60 >= 60)
								{
									text43 = Math.Round((double)(Main.player[Main.myPlayer].buffTime[num66] / 60) / 60.0) + " m";
								}
								else
								{
									text43 = Math.Round((double)Main.player[Main.myPlayer].buffTime[num66] / 60.0) + " s";
								}
								SpriteBatch spriteBatch35 = this.spriteBatch;
								SpriteFontX spriteFont31 = Main.fontItemStack;
								string text44 = text43;
								Vector2 position35 = new Vector2((float)num68, (float)(num69 + Main.buffTexture[num67].Height));
								Microsoft.Xna.Framework.Color color13 = color11;
								float rotation35 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont31, text44, position35, color13, rotation35, origin, 0.8f, SpriteEffects.None, 0f);
							}
							if (Main.mouseX < num68 + Main.buffTexture[num67].Width && Main.mouseY < num69 + Main.buffTexture[num67].Height && Main.mouseX > num68 && Main.mouseY > num69)
							{
								num65 = num66;
								Main.buffAlpha[num66] += 0.1f;
								if (Main.mouseRight && Main.mouseRightRelease && !Main.debuff[num67])
								{
									Main.PlaySound(12, -1, -1, 1);
									Main.player[Main.myPlayer].DelBuff(num66);
								}
							}
							else
							{
								Main.buffAlpha[num66] -= 0.05f;
							}
							if (Main.buffAlpha[num66] > 1f)
							{
								Main.buffAlpha[num66] = 1f;
							}
							else if ((double)Main.buffAlpha[num66] < 0.4)
							{
								Main.buffAlpha[num66] = 0.4f;
							}
						}
						else
						{
							Main.buffAlpha[num66] = 0.4f;
						}
					}
					if (num65 >= 0)
					{
						int num70 = Main.player[Main.myPlayer].buffType[num65];
						if (num70 > 0)
						{
							Main.buffString = Main.buffTip[num70];
							this.MouseText(Main.buffName[num70], 0, 0);
						}
					}
				}
				if (Main.player[Main.myPlayer].dead)
				{
					Main.playerInventory = false;
				}
				if (!Main.playerInventory)
				{
					Main.player[Main.myPlayer].chest = -1;
					Main.craftGuide = false;
					Main.reforge = false;
				}
				string text45 = "";
				if (Main.playerInventory)
				{
					if (Main.netMode == 1)
					{
						int num71 = 675 + Main.screenWidth - 800;
						int num72 = 114;
						if (Main.player[Main.myPlayer].hostile)
						{
							SpriteBatch spriteBatch36 = this.spriteBatch;
							Texture2D texture5 = Main.itemTexture[4];
							Vector2 position36 = new Vector2((float)(num71 - 2), (float)num72);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle5 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
							Microsoft.Xna.Framework.Color color14 = Main.teamColor[Main.player[Main.myPlayer].team];
							float rotation36 = 0f;
							origin = default(Vector2);
							spriteBatch36.Draw(texture5, position36, sourceRectangle5, color14, rotation36, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch37 = this.spriteBatch;
							Texture2D texture6 = Main.itemTexture[4];
							Vector2 position37 = new Vector2((float)(num71 + 2), (float)num72);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle6 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
							Microsoft.Xna.Framework.Color color15 = Main.teamColor[Main.player[Main.myPlayer].team];
							float rotation37 = 0f;
							origin = default(Vector2);
							spriteBatch37.Draw(texture6, position37, sourceRectangle6, color15, rotation37, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
						}
						else
						{
							SpriteBatch spriteBatch38 = this.spriteBatch;
							Texture2D texture7 = Main.itemTexture[4];
							Vector2 position38 = new Vector2((float)(num71 - 16), (float)(num72 + 14));
							Microsoft.Xna.Framework.Rectangle? sourceRectangle7 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
							Microsoft.Xna.Framework.Color color16 = Main.teamColor[Main.player[Main.myPlayer].team];
							float rotation38 = -0.785f;
							origin = default(Vector2);
							spriteBatch38.Draw(texture7, position38, sourceRectangle7, color16, rotation38, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch39 = this.spriteBatch;
							Texture2D texture8 = Main.itemTexture[4];
							Vector2 position39 = new Vector2((float)(num71 + 2), (float)(num72 + 14));
							Microsoft.Xna.Framework.Rectangle? sourceRectangle8 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
							Microsoft.Xna.Framework.Color color17 = Main.teamColor[Main.player[Main.myPlayer].team];
							float rotation39 = -0.785f;
							origin = default(Vector2);
							spriteBatch39.Draw(texture8, position39, sourceRectangle8, color17, rotation39, origin, 1f, SpriteEffects.None, 0f);
						}
						if (Main.mouseX > num71 && Main.mouseX < num71 + 34 && Main.mouseY > num72 - 2 && Main.mouseY < num72 + 34)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeft && Main.mouseLeftRelease)
							{
								if (Main.teamCooldown == 0)
								{
									Main.teamCooldown = Main.teamCooldownLen;
									Main.PlaySound(12, -1, -1, 1);
									if (Main.player[Main.myPlayer].hostile)
									{
										Main.player[Main.myPlayer].hostile = false;
									}
									else
									{
										Main.player[Main.myPlayer].hostile = true;
									}
									NetMessage.SendData(30, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								}
								else
								{
									Main.NewText("您必须等待 " + (Main.teamCooldown / 60 + 1) + " 秒。", 255, 0, 0);
								}
							}
						}
						num71 -= 3;
						Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle(Main.mouseX, Main.mouseY, 1, 1);
						int width = Main.teamTexture.Width;
						int height = Main.teamTexture.Height;
						for (int num73 = 0; num73 < 5; num73++)
						{
							Microsoft.Xna.Framework.Rectangle rectangle = default(Microsoft.Xna.Framework.Rectangle);
							if (num73 == 0)
							{
								rectangle = new Microsoft.Xna.Framework.Rectangle(num71 + 50, num72 - 20, width, height);
							}
							if (num73 == 1)
							{
								rectangle = new Microsoft.Xna.Framework.Rectangle(num71 + 40, num72, width, height);
							}
							if (num73 == 2)
							{
								rectangle = new Microsoft.Xna.Framework.Rectangle(num71 + 60, num72, width, height);
							}
							if (num73 == 3)
							{
								rectangle = new Microsoft.Xna.Framework.Rectangle(num71 + 40, num72 + 20, width, height);
							}
							if (num73 == 4)
							{
								rectangle = new Microsoft.Xna.Framework.Rectangle(num71 + 60, num72 + 20, width, height);
							}
							if (rectangle.Intersects(value))
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeft && Main.mouseLeftRelease && Main.player[Main.myPlayer].team != num73)
								{
									if (Main.teamCooldown == 0)
									{
										Main.teamCooldown = Main.teamCooldownLen;
										Main.PlaySound(12, -1, -1, 1);
										Main.player[Main.myPlayer].team = num73;
										NetMessage.SendData(45, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
									}
									else
									{
										Main.NewText("您必须等待 " + (Main.teamCooldown / 60 + 1) + " 秒。", 255, 0, 0);
									}
								}
							}
						}
						SpriteBatch spriteBatch40 = this.spriteBatch;
						Texture2D texture9 = Main.teamTexture;
						Vector2 position40 = new Vector2((float)(num71 + 50), (float)(num72 - 20));
						Microsoft.Xna.Framework.Rectangle? sourceRectangle9 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
						Microsoft.Xna.Framework.Color color18 = Main.teamColor[0];
						float rotation40 = 0f;
						origin = default(Vector2);
						spriteBatch40.Draw(texture9, position40, sourceRectangle9, color18, rotation40, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch41 = this.spriteBatch;
						Texture2D texture10 = Main.teamTexture;
						Vector2 position41 = new Vector2((float)(num71 + 40), (float)num72);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle10 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
						Microsoft.Xna.Framework.Color color19 = Main.teamColor[1];
						float rotation41 = 0f;
						origin = default(Vector2);
						spriteBatch41.Draw(texture10, position41, sourceRectangle10, color19, rotation41, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch42 = this.spriteBatch;
						Texture2D texture11 = Main.teamTexture;
						Vector2 position42 = new Vector2((float)(num71 + 60), (float)num72);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle11 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
						Microsoft.Xna.Framework.Color color20 = Main.teamColor[2];
						float rotation42 = 0f;
						origin = default(Vector2);
						spriteBatch42.Draw(texture11, position42, sourceRectangle11, color20, rotation42, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch43 = this.spriteBatch;
						Texture2D texture12 = Main.teamTexture;
						Vector2 position43 = new Vector2((float)(num71 + 40), (float)(num72 + 20));
						Microsoft.Xna.Framework.Rectangle? sourceRectangle12 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
						Microsoft.Xna.Framework.Color color21 = Main.teamColor[3];
						float rotation43 = 0f;
						origin = default(Vector2);
						spriteBatch43.Draw(texture12, position43, sourceRectangle12, color21, rotation43, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch spriteBatch44 = this.spriteBatch;
						Texture2D texture13 = Main.teamTexture;
						Vector2 position44 = new Vector2((float)(num71 + 60), (float)(num72 + 20));
						Microsoft.Xna.Framework.Rectangle? sourceRectangle13 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
						Microsoft.Xna.Framework.Color color22 = Main.teamColor[4];
						float rotation44 = 0f;
						origin = default(Vector2);
						spriteBatch44.Draw(texture13, position44, sourceRectangle13, color22, rotation44, origin, 1f, SpriteEffects.None, 0f);
					}
					bool flag4 = false;
					Main.inventoryScale = 0.85f;
					int num74 = 448;
					int num75 = 210;
					Microsoft.Xna.Framework.Color white18 = new Microsoft.Xna.Framework.Color(150, 150, 150, 150);
					if (Main.mouseX >= num74 && (float)Main.mouseX <= (float)num74 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num75 && (float)Main.mouseY <= (float)num75 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeftRelease && Main.mouseLeft)
						{
							if (Main.mouseItem.type != 0)
							{
								Main.trashItem.SetDefaults(0, false);
							}
							Item item = Main.mouseItem;
							Main.mouseItem = Main.trashItem;
							Main.trashItem = item;
							if (Main.trashItem.type == 0 || Main.trashItem.stack < 1)
							{
								Main.trashItem = new Item();
							}
							if (Main.mouseItem.IsTheSameAs(Main.trashItem) && Main.trashItem.stack != Main.trashItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
							{
								if (Main.mouseItem.stack + Main.trashItem.stack <= Main.mouseItem.maxStack)
								{
									Main.trashItem.stack += Main.mouseItem.stack;
									Main.mouseItem.stack = 0;
								}
								else
								{
									int num76 = Main.mouseItem.maxStack - Main.trashItem.stack;
									Main.trashItem.stack += num76;
									Main.mouseItem.stack -= num76;
								}
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || Main.trashItem.type > 0)
							{
								Main.PlaySound(7, -1, -1, 1);
							}
						}
						if (!flag4)
						{
							text45 = Main.trashItem.CName;
							if (Main.trashItem.stack > 1)
							{
								object obj = text45;
								text45 = string.Concat(new object[]
								{
									obj,
									" (",
									Main.trashItem.stack,
									")"
								});
							}
							Main.toolTip = (Item)Main.trashItem.Clone();
							if (text45 == null)
							{
								text45 = "垃圾桶";
							}
						}
						else
						{
							text45 = "垃圾桶";
						}
					}
					SpriteBatch spriteBatch45 = this.spriteBatch;
					Texture2D texture14 = Main.inventoryBack7Texture;
					Vector2 position45 = new Vector2((float)num74, (float)num75);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle14 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
					Microsoft.Xna.Framework.Color color23 = color6;
					float rotation45 = 0f;
					origin = default(Vector2);
					spriteBatch45.Draw(texture14, position45, sourceRectangle14, color23, rotation45, origin, Main.inventoryScale, SpriteEffects.None, 0f);
					white18 = Microsoft.Xna.Framework.Color.White;
					if (Main.trashItem.type == 0 || Main.trashItem.stack == 0 || flag4)
					{
						white18 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
						float num77 = Main.inventoryScale;
						SpriteBatch spriteBatch46 = this.spriteBatch;
						Texture2D texture15 = Main.trashTexture;
						Vector2 position46 = new Vector2((float)num74 + 26f * Main.inventoryScale - (float)Main.trashTexture.Width * 0.5f * num77, (float)num75 + 26f * Main.inventoryScale - (float)Main.trashTexture.Height * 0.5f * num77);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle15 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.trashTexture.Width, Main.trashTexture.Height));
						Microsoft.Xna.Framework.Color color24 = white18;
						float rotation46 = 0f;
						origin = default(Vector2);
						spriteBatch46.Draw(texture15, position46, sourceRectangle15, color24, rotation46, origin, num77, SpriteEffects.None, 0f);
					}
					else
					{
						float num78 = 1f;
						if (Main.itemTexture[Main.trashItem.type].Width > 32 || Main.itemTexture[Main.trashItem.type].Height > 32)
						{
							if (Main.itemTexture[Main.trashItem.type].Width > Main.itemTexture[Main.trashItem.type].Height)
							{
								num78 = 32f / (float)Main.itemTexture[Main.trashItem.type].Width;
							}
							else
							{
								num78 = 32f / (float)Main.itemTexture[Main.trashItem.type].Height;
							}
						}
						num78 *= Main.inventoryScale;
						SpriteBatch spriteBatch47 = this.spriteBatch;
						Texture2D texture16 = Main.itemTexture[Main.trashItem.type];
						Vector2 position47 = new Vector2((float)num74 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Width * 0.5f * num78, (float)num75 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Height * 0.5f * num78);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle16 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height));
						Microsoft.Xna.Framework.Color alpha = Main.trashItem.GetAlpha(white18);
						float rotation47 = 0f;
						origin = default(Vector2);
						spriteBatch47.Draw(texture16, position47, sourceRectangle16, alpha, rotation47, origin, num78, SpriteEffects.None, 0f);
						Microsoft.Xna.Framework.Color color25 = Main.trashItem.color;
						if (color25 != default(Microsoft.Xna.Framework.Color))
						{
							SpriteBatch spriteBatch48 = this.spriteBatch;
							Texture2D texture17 = Main.itemTexture[Main.trashItem.type];
							Vector2 position48 = new Vector2((float)num74 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Width * 0.5f * num78, (float)num75 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Height * 0.5f * num78);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle17 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height));
							Microsoft.Xna.Framework.Color color26 = Main.trashItem.GetColor(white18);
							float rotation48 = 0f;
							origin = default(Vector2);
							spriteBatch48.Draw(texture17, position48, sourceRectangle17, color26, rotation48, origin, num78, SpriteEffects.None, 0f);
						}
						if (Main.trashItem.stack > 1)
						{
							SpriteBatch spriteBatch49 = this.spriteBatch;
							SpriteFontX spriteFont32 = Main.fontItemStack;
							string text46 = string.Concat(Main.trashItem.stack);
							Vector2 position49 = new Vector2((float)num74 + 10f * Main.inventoryScale, (float)num75 + 26f * Main.inventoryScale);
							Microsoft.Xna.Framework.Color color27 = white18;
							float rotation49 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont32, text46, position49, color27, rotation49, origin, num78, SpriteEffects.None, 0f);
						}
					}
					SpriteBatch spriteBatch50 = this.spriteBatch;
					SpriteFontX spriteFont33 = Main.fontMouseText;
					string text47 = "背包";
					Vector2 position50 = new Vector2(40f, 0f);
					Microsoft.Xna.Framework.Color color28 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation50 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont33, text47, position50, color28, rotation50, origin, 1f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.85f;
					if (Main.mouseX > 20 && Main.mouseX < (int)(20f + 560f * Main.inventoryScale) && Main.mouseY > 20 && Main.mouseY < (int)(20f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num79 = 0; num79 < 10; num79++)
					{
						for (int num80 = 0; num80 < 4; num80++)
						{
							int num81 = (int)(20f + (float)(num79 * 56) * Main.inventoryScale);
							int num82 = (int)(20f + (float)(num80 * 56) * Main.inventoryScale);
							int num83 = num79 + num80 * 10;
							Microsoft.Xna.Framework.Color white19 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
							if (Main.mouseX >= num81 && (float)Main.mouseX <= (float)num81 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num82 && (float)Main.mouseY <= (float)num82 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
									{
										if (Main.player[Main.myPlayer].inventory[num83].type > 0)
										{
											if (Main.npcShop > 0)
											{
												if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num83].value, Main.player[Main.myPlayer].inventory[num83].stack))
												{
													this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num83]);
													Main.player[Main.myPlayer].inventory[num83].SetDefaults(0, false);
													Main.PlaySound(18, -1, -1, 1);
												}
												else if (Main.player[Main.myPlayer].inventory[num83].value == 0)
												{
													this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num83]);
													Main.player[Main.myPlayer].inventory[num83].SetDefaults(0, false);
													Main.PlaySound(7, -1, -1, 1);
												}
											}
											else
											{
												Recipe.FindRecipes();
												Main.PlaySound(7, -1, -1, 1);
												Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num83].Clone();
												Main.player[Main.myPlayer].inventory[num83].SetDefaults(0, false);
											}
										}
									}
									else if (Main.player[Main.myPlayer].selectedItem != num83 || Main.player[Main.myPlayer].itemAnimation <= 0)
									{
										Item item2 = Main.mouseItem;
										Main.mouseItem = Main.player[Main.myPlayer].inventory[num83];
										Main.player[Main.myPlayer].inventory[num83] = item2;
										if (Main.player[Main.myPlayer].inventory[num83].type == 0 || Main.player[Main.myPlayer].inventory[num83].stack < 1)
										{
											Main.player[Main.myPlayer].inventory[num83] = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num83]) && Main.player[Main.myPlayer].inventory[num83].stack != Main.player[Main.myPlayer].inventory[num83].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num83].stack <= Main.mouseItem.maxStack)
											{
												Main.player[Main.myPlayer].inventory[num83].stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num84 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num83].stack;
												Main.player[Main.myPlayer].inventory[num83].stack += num84;
												Main.mouseItem.stack -= num84;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num83].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
								}
								else if (Main.mouseRight && Main.mouseRightRelease && (Main.player[Main.myPlayer].inventory[num83].type == 599 || Main.player[Main.myPlayer].inventory[num83].type == 600 || Main.player[Main.myPlayer].inventory[num83].type == 601))
								{
									Main.PlaySound(7, -1, -1, 1);
									Main.stackSplit = 30;
									Main.mouseRightRelease = false;
									int num85 = Main.rand.Next(14);
									if (num85 == 0 && Main.hardMode)
									{
										Main.player[Main.myPlayer].inventory[num83].SetDefaults(602, false);
									}
									else if (num85 <= 7)
									{
										Main.player[Main.myPlayer].inventory[num83].SetDefaults(586, false);
										Main.player[Main.myPlayer].inventory[num83].stack = Main.rand.Next(20, 50);
									}
									else
									{
										Main.player[Main.myPlayer].inventory[num83].SetDefaults(591, false);
										Main.player[Main.myPlayer].inventory[num83].stack = Main.rand.Next(20, 50);
									}
								}
								else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].inventory[num83].maxStack == 1)
								{
									Main.player[Main.myPlayer].inventory[num83] = Main.armorSwap(Main.player[Main.myPlayer].inventory[num83]);
								}
								else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].inventory[num83].maxStack > 1 && Main.player[Main.myPlayer].inventory[num83].type > 0 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num83]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
								{
									if (Main.mouseItem.type == 0)
									{
										Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num83].Clone();
										Main.mouseItem.stack = 0;
									}
									Main.mouseItem.stack++;
									Main.player[Main.myPlayer].inventory[num83].stack--;
									if (Main.player[Main.myPlayer].inventory[num83].stack <= 0)
									{
										Main.player[Main.myPlayer].inventory[num83] = new Item();
									}
									Recipe.FindRecipes();
									Main.soundInstanceMenuTick.Stop();
									Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
									Main.PlaySound(12, -1, -1, 1);
									if (Main.stackSplit == 0)
									{
										Main.stackSplit = 15;
									}
									else
									{
										Main.stackSplit = Main.stackDelay;
									}
								}
								text45 = Main.player[Main.myPlayer].inventory[num83].CName;
								Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num83].Clone();
								if (Main.player[Main.myPlayer].inventory[num83].stack > 1)
								{
									object obj = text45;
									text45 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.player[Main.myPlayer].inventory[num83].stack,
										")"
									});
								}
							}
							if (num80 != 0)
							{
								SpriteBatch spriteBatch51 = this.spriteBatch;
								Texture2D texture18 = Main.inventoryBackTexture;
								Vector2 position51 = new Vector2((float)num81, (float)num82);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle18 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color29 = color6;
								float rotation51 = 0f;
								origin = default(Vector2);
								spriteBatch51.Draw(texture18, position51, sourceRectangle18, color29, rotation51, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							}
							else
							{
								SpriteBatch spriteBatch52 = this.spriteBatch;
								Texture2D texture19 = Main.inventoryBack9Texture;
								Vector2 position52 = new Vector2((float)num81, (float)num82);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle19 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color30 = color6;
								float rotation52 = 0f;
								origin = default(Vector2);
								spriteBatch52.Draw(texture19, position52, sourceRectangle19, color30, rotation52, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							}
							white19 = Microsoft.Xna.Framework.Color.White;
							if (Main.player[Main.myPlayer].inventory[num83].type > 0 && Main.player[Main.myPlayer].inventory[num83].stack > 0)
							{
								float num86 = 1f;
								if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height > 32)
								{
									if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height)
									{
										num86 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width;
									}
									else
									{
										num86 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height;
									}
								}
								num86 *= Main.inventoryScale;
								SpriteBatch spriteBatch53 = this.spriteBatch;
								Texture2D texture20 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type];
								Vector2 position53 = new Vector2((float)num81 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width * 0.5f * num86, (float)num82 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height * 0.5f * num86);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle20 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height));
								Microsoft.Xna.Framework.Color alpha2 = Main.player[Main.myPlayer].inventory[num83].GetAlpha(white19);
								float rotation53 = 0f;
								origin = default(Vector2);
								spriteBatch53.Draw(texture20, position53, sourceRectangle20, alpha2, rotation53, origin, num86, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color31 = Main.player[Main.myPlayer].inventory[num83].color;
								if (color31 != default(Microsoft.Xna.Framework.Color))
								{
									SpriteBatch spriteBatch54 = this.spriteBatch;
									Texture2D texture21 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type];
									Vector2 position54 = new Vector2((float)num81 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width * 0.5f * num86, (float)num82 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height * 0.5f * num86);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle21 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num83].type].Height));
									Microsoft.Xna.Framework.Color color32 = Main.player[Main.myPlayer].inventory[num83].GetColor(white19);
									float rotation54 = 0f;
									origin = default(Vector2);
									spriteBatch54.Draw(texture21, position54, sourceRectangle21, color32, rotation54, origin, num86, SpriteEffects.None, 0f);
								}
								if (Main.player[Main.myPlayer].inventory[num83].stack > 1)
								{
									SpriteBatch spriteBatch55 = this.spriteBatch;
									SpriteFontX spriteFont34 = Main.fontItemStack;
									string text48 = string.Concat(Main.player[Main.myPlayer].inventory[num83].stack);
									Vector2 position55 = new Vector2((float)num81 + 10f * Main.inventoryScale, (float)num82 + 26f * Main.inventoryScale);
									Microsoft.Xna.Framework.Color color33 = white19;
									float rotation55 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont34, text48, position55, color33, rotation55, origin, num86, SpriteEffects.None, 0f);
								}
							}
							if (num80 == 0)
							{
								string text49 = string.Concat(num83 + 1);
								if (text49 == "10")
								{
									text49 = "0";
								}
								Microsoft.Xna.Framework.Color color34 = color6;
								if (Main.player[Main.myPlayer].selectedItem == num83)
								{
									color34.R = 0;
									color34.B = 0;
									color34.G = 255;
									color34.A = 50;
								}
								SpriteBatch spriteBatch56 = this.spriteBatch;
								SpriteFontX spriteFont35 = Main.fontItemStack;
								string text50 = text49;
								Vector2 position56 = new Vector2((float)(num81 + 6), (float)(num82 + 4));
								Microsoft.Xna.Framework.Color color35 = color34;
								float rotation56 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont35, text50, position56, color35, rotation56, origin, Main.inventoryScale * 0.8f, SpriteEffects.None, 0f);
							}
						}
					}
					int num87 = 0;
					int num88 = 2;
					int num89 = 32;
					if (!Main.player[Main.myPlayer].hbLocked)
					{
						num87 = 1;
					}
					SpriteBatch spriteBatch57 = this.spriteBatch;
					Texture2D texture22 = Main.HBLockTexture[num87];
					Vector2 position57 = new Vector2((float)num88, (float)num89);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle22 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.HBLockTexture[num87].Width, Main.HBLockTexture[num87].Height));
					Microsoft.Xna.Framework.Color color36 = color6;
					float rotation57 = 0f;
					origin = default(Vector2);
					spriteBatch57.Draw(texture22, position57, sourceRectangle22, color36, rotation57, origin, 0.9f, SpriteEffects.None, 0f);
					if (Main.mouseX > num88 && (float)Main.mouseX < (float)num88 + (float)Main.HBLockTexture[num87].Width * 0.9f && Main.mouseY > num89 && (float)Main.mouseY < (float)num89 + (float)Main.HBLockTexture[num87].Height * 0.9f)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (!Main.player[Main.myPlayer].hbLocked)
						{
							this.MouseText("锁定工具栏", 0, 0);
							flag = true;
						}
						else
						{
							this.MouseText("解锁工具栏", 0, 0);
							flag = true;
						}
						if (Main.mouseLeft && Main.mouseLeftRelease)
						{
							Main.PlaySound(22, -1, -1, 1);
							if (!Main.player[Main.myPlayer].hbLocked)
							{
								Main.player[Main.myPlayer].hbLocked = true;
							}
							else
							{
								Main.player[Main.myPlayer].hbLocked = false;
							}
						}
					}
					if (Main.armorHide)
					{
						Main.armorAlpha -= 0.1f;
						if (Main.armorAlpha < 0f)
						{
							Main.armorAlpha = 0f;
						}
					}
					else
					{
						Main.armorAlpha += 0.025f;
						if (Main.armorAlpha > 1f)
						{
							Main.armorAlpha = 1f;
						}
					}
					Microsoft.Xna.Framework.Color color37 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)));
					Main.armorHide = false;
					int num90 = 1;
					int num91 = Main.screenWidth - 152;
					int num92 = 128;
					if (Main.netMode == 0)
					{
						num91 += 72;
					}
					if (this.showNPCs)
					{
						num90 = 0;
					}
					SpriteBatch spriteBatch58 = this.spriteBatch;
					Texture2D texture23 = Main.npcToggleTexture[num90];
					Vector2 position58 = new Vector2((float)num91, (float)num92);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle23 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.npcToggleTexture[num90].Width, Main.npcToggleTexture[num90].Height));
					Microsoft.Xna.Framework.Color white20 = Microsoft.Xna.Framework.Color.White;
					float rotation58 = 0f;
					origin = default(Vector2);
					spriteBatch58.Draw(texture23, position58, sourceRectangle23, white20, rotation58, origin, 0.9f, SpriteEffects.None, 0f);
					if (Main.mouseX > num91 && (float)Main.mouseX < (float)num91 + (float)Main.npcToggleTexture[num90].Width * 0.9f && Main.mouseY > num92 && (float)Main.mouseY < (float)num92 + (float)Main.npcToggleTexture[num90].Height * 0.9f)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeft && Main.mouseLeftRelease)
						{
							Main.PlaySound(12, -1, -1, 1);
							if (!this.showNPCs)
							{
								this.showNPCs = true;
							}
							else
							{
								this.showNPCs = false;
							}
						}
					}
					if (this.showNPCs)
					{
						SpriteBatch spriteBatch59 = this.spriteBatch;
						SpriteFontX spriteFont36 = Main.fontMouseText;
						string text51 = "住宅";
						Vector2 position59 = new Vector2((float)(Main.screenWidth - 64 - 28 - 3), 152f);
						Microsoft.Xna.Framework.Color color38 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation59 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont36, text51, position59, color38, rotation59, origin, 0.8f, SpriteEffects.None, 0f);
						if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 28) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 448f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						int num93 = 0;
						string text52 = "";
						for (int num94 = 0; num94 < 12; num94++)
						{
							bool flag5 = false;
							int num95 = 0;
							if (num94 == 0)
							{
								flag5 = true;
							}
							else
							{
								for (int num96 = 0; num96 < 200; num96++)
								{
									if (Main.npc[num96].active && NPC.TypeToNum(Main.npc[num96].type) == num94)
									{
										flag5 = true;
										num95 = num96;
										break;
									}
								}
							}
							if (flag5)
							{
								int num97 = Main.screenWidth - 64 - 28;
								int num98 = (int)(174f + (float)(num93 * 56) * Main.inventoryScale);
								Microsoft.Xna.Framework.Color white21 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
								if (Main.screenHeight < 768 && num93 > 5)
								{
									num98 -= (int)(280f * Main.inventoryScale);
									num97 -= 48;
								}
								if (Main.mouseX >= num97 && (float)Main.mouseX <= (float)num97 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num98 && (float)Main.mouseY <= (float)num98 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									flag = true;
									if (num94 == 0)
									{
										text52 = "住宅咨询";
									}
									else if (num94 == 11)
									{
										text52 = Main.npc[num95].displayCName;
									}
									else
									{
										text52 = Main.npc[num95].displayCName + "(" + Main.npc[num95].CName + ")";
									}
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseItem.type == 0)
									{
										Main.PlaySound(12, -1, -1, 1);
										this.mouseNPC = num94;
										Main.mouseLeftRelease = false;
									}
								}
								SpriteBatch spriteBatch60 = this.spriteBatch;
								Texture2D texture24 = Main.inventoryBack11Texture;
								Vector2 position60 = new Vector2((float)num97, (float)num98);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle24 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color39 = color6;
								float rotation60 = 0f;
								origin = default(Vector2);
								spriteBatch60.Draw(texture24, position60, sourceRectangle24, color39, rotation60, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								white21 = Microsoft.Xna.Framework.Color.White;
								int num99 = num94;
								float scale = 1f;
								float num100;
								if (Main.npcHeadTexture[num99].Width > Main.npcHeadTexture[num99].Height)
								{
									num100 = (float)Main.npcHeadTexture[num99].Width;
								}
								else
								{
									num100 = (float)Main.npcHeadTexture[num99].Height;
								}
								if (num100 > 36f)
								{
									scale = 36f / num100;
								}
								this.spriteBatch.Draw(Main.npcHeadTexture[num99], new Vector2((float)num97 + 26f * Main.inventoryScale, (float)num98 + 26f * Main.inventoryScale), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.npcHeadTexture[num99].Width, Main.npcHeadTexture[num99].Height)), white21, 0f, new Vector2((float)(Main.npcHeadTexture[num99].Width / 2), (float)(Main.npcHeadTexture[num99].Height / 2)), scale, SpriteEffects.None, 0f);
								num93++;
							}
						}
						if (text52 != "" && Main.mouseItem.type == 0)
						{
							this.MouseText(text52, 0, 0);
						}
					}
					else
					{
						SpriteBatch spriteBatch61 = this.spriteBatch;
						SpriteFontX spriteFont37 = Main.fontMouseText;
						string text53 = "装备";
						Vector2 position61 = new Vector2((float)(Main.screenWidth - 64 - 28 + 4), 152f);
						Microsoft.Xna.Framework.Color color40 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation61 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont37, text53, position61, color40, rotation61, origin, 0.8f, SpriteEffects.None, 0f);
						if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 28) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 448f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num101 = 0; num101 < 8; num101++)
						{
							int num102 = Main.screenWidth - 64 - 28;
							int num103 = (int)(174f + (float)(num101 * 56) * Main.inventoryScale);
							Microsoft.Xna.Framework.Color white22 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
							string text54 = "";
							if (num101 == 3)
							{
								text54 = "饰品";
							}
							if (num101 == 7)
							{
								text54 = "总防御:" + Main.player[Main.myPlayer].statDefense;
							}
							Vector2 vector5 = Main.fontMouseText.MeasureString(text54);
							SpriteBatch spriteBatch62 = this.spriteBatch;
							SpriteFontX spriteFont38 = Main.fontMouseText;
							string text55 = text54;
							Vector2 position62 = new Vector2((float)num102 - vector5.X - 10f, (float)num103 + (float)Main.inventoryBackTexture.Height * 0.5f - vector5.Y * 0.5f);
							Microsoft.Xna.Framework.Color color41 = color37;
							float rotation62 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont38, text55, position62, color41, rotation62, origin, 1f, SpriteEffects.None, 0f);
							if (Main.mouseX >= num102 && (float)Main.mouseX <= (float)num102 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num103 && (float)Main.mouseY <= (float)num103 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.armorHide = true;
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft && (Main.mouseItem.type == 0 || (Main.mouseItem.headSlot > -1 && num101 == 0) || (Main.mouseItem.bodySlot > -1 && num101 == 1) || (Main.mouseItem.legSlot > -1 && num101 == 2) || (Main.mouseItem.accessory && num101 > 2 && !Main.AccCheck(Main.mouseItem, num101))))
								{
									Item item3 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].armor[num101];
									Main.player[Main.myPlayer].armor[num101] = item3;
									if (Main.player[Main.myPlayer].armor[num101].type == 0 || Main.player[Main.myPlayer].armor[num101].stack < 1)
									{
										Main.player[Main.myPlayer].armor[num101] = new Item();
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[num101].type > 0)
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1);
									}
								}
								text45 = Main.player[Main.myPlayer].armor[num101].CName;
								Main.toolTip = (Item)Main.player[Main.myPlayer].armor[num101].Clone();
								if (num101 <= 2)
								{
									Main.toolTip.wornArmor = true;
								}
								if (Main.player[Main.myPlayer].armor[num101].stack > 1)
								{
									object obj = text45;
									text45 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.player[Main.myPlayer].armor[num101].stack,
										")"
									});
								}
							}
							SpriteBatch spriteBatch63 = this.spriteBatch;
							Texture2D texture25 = Main.inventoryBack3Texture;
							Vector2 position63 = new Vector2((float)num102, (float)num103);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle25 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Microsoft.Xna.Framework.Color color42 = color6;
							float rotation63 = 0f;
							origin = default(Vector2);
							spriteBatch63.Draw(texture25, position63, sourceRectangle25, color42, rotation63, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white22 = Microsoft.Xna.Framework.Color.White;
							if (Main.player[Main.myPlayer].armor[num101].type > 0 && Main.player[Main.myPlayer].armor[num101].stack > 0)
							{
								float num104 = 1f;
								if (Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height > 32)
								{
									if (Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width > Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height)
									{
										num104 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width;
									}
									else
									{
										num104 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height;
									}
								}
								num104 *= Main.inventoryScale;
								SpriteBatch spriteBatch64 = this.spriteBatch;
								Texture2D texture26 = Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type];
								Vector2 position64 = new Vector2((float)num102 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width * 0.5f * num104, (float)num103 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height * 0.5f * num104);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle26 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height));
								Microsoft.Xna.Framework.Color alpha3 = Main.player[Main.myPlayer].armor[num101].GetAlpha(white22);
								float rotation64 = 0f;
								origin = default(Vector2);
								spriteBatch64.Draw(texture26, position64, sourceRectangle26, alpha3, rotation64, origin, num104, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color43 = Main.player[Main.myPlayer].armor[num101].color;
								if (color43 != default(Microsoft.Xna.Framework.Color))
								{
									SpriteBatch spriteBatch65 = this.spriteBatch;
									Texture2D texture27 = Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type];
									Vector2 position65 = new Vector2((float)num102 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width * 0.5f * num104, (float)num103 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height * 0.5f * num104);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle27 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num101].type].Height));
									Microsoft.Xna.Framework.Color color44 = Main.player[Main.myPlayer].armor[num101].GetColor(white22);
									float rotation65 = 0f;
									origin = default(Vector2);
									spriteBatch65.Draw(texture27, position65, sourceRectangle27, color44, rotation65, origin, num104, SpriteEffects.None, 0f);
								}
								if (Main.player[Main.myPlayer].armor[num101].stack > 1)
								{
									SpriteBatch spriteBatch66 = this.spriteBatch;
									SpriteFontX spriteFont39 = Main.fontItemStack;
									string text56 = string.Concat(Main.player[Main.myPlayer].armor[num101].stack);
									Vector2 position66 = new Vector2((float)num102 + 10f * Main.inventoryScale, (float)num103 + 26f * Main.inventoryScale);
									Microsoft.Xna.Framework.Color color45 = white22;
									float rotation66 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont39, text56, position66, color45, rotation66, origin, num104, SpriteEffects.None, 0f);
								}
							}
						}
						SpriteBatch spriteBatch67 = this.spriteBatch;
						SpriteFontX spriteFont40 = Main.fontMouseText;
						string text57 = "时装";
						Vector2 position67 = new Vector2((float)(Main.screenWidth - 64 - 28 - 44), 152f);
						Microsoft.Xna.Framework.Color color46 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation67 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont40, text57, position67, color46, rotation67, origin, 0.8f, SpriteEffects.None, 0f);
						if (Main.mouseX > Main.screenWidth - 64 - 28 - 47 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 20 - 47) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 168f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num105 = 8; num105 < 11; num105++)
						{
							int num106 = Main.screenWidth - 64 - 28 - 47;
							int num107 = (int)(174f + (float)((num105 - 8) * 56) * Main.inventoryScale);
							Microsoft.Xna.Framework.Color white23 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
							string text58 = "";
							if (num105 == 8)
							{
								text58 = "头盔";
							}
							else if (num105 == 9)
							{
								text58 = "衣服";
							}
							else if (num105 == 10)
							{
								text58 = "裤子";
							}
							Vector2 vector6 = Main.fontMouseText.MeasureString(text58);
							SpriteBatch spriteBatch68 = this.spriteBatch;
							SpriteFontX spriteFont41 = Main.fontMouseText;
							string text59 = text58;
							Vector2 position68 = new Vector2((float)num106 - vector6.X - 10f, (float)num107 + (float)Main.inventoryBackTexture.Height * 0.5f - vector6.Y * 0.5f);
							Microsoft.Xna.Framework.Color color47 = color37;
							float rotation68 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont41, text59, position68, color47, rotation68, origin, 1f, SpriteEffects.None, 0f);
							if (Main.mouseX >= num106 && (float)Main.mouseX <= (float)num106 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num107 && (float)Main.mouseY <= (float)num107 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								Main.armorHide = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.mouseItem.type == 0 || (Main.mouseItem.headSlot > -1 && num105 == 8) || (Main.mouseItem.bodySlot > -1 && num105 == 9) || (Main.mouseItem.legSlot > -1 && num105 == 10))
									{
										Item item4 = Main.mouseItem;
										Main.mouseItem = Main.player[Main.myPlayer].armor[num105];
										Main.player[Main.myPlayer].armor[num105] = item4;
										if (Main.player[Main.myPlayer].armor[num105].type == 0 || Main.player[Main.myPlayer].armor[num105].stack < 1)
										{
											Main.player[Main.myPlayer].armor[num105] = new Item();
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[num105].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
								}
								else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].armor[num105].maxStack == 1)
								{
									Main.player[Main.myPlayer].armor[num105] = Main.armorSwap(Main.player[Main.myPlayer].armor[num105]);
								}
								text45 = Main.player[Main.myPlayer].armor[num105].CName;
								Main.toolTip = (Item)Main.player[Main.myPlayer].armor[num105].Clone();
								Main.toolTip.social = true;
								if (num105 <= 2)
								{
									Main.toolTip.wornArmor = true;
								}
								if (Main.player[Main.myPlayer].armor[num105].stack > 1)
								{
									object obj = text45;
									text45 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.player[Main.myPlayer].armor[num105].stack,
										")"
									});
								}
							}
							SpriteBatch spriteBatch69 = this.spriteBatch;
							Texture2D texture28 = Main.inventoryBack8Texture;
							Vector2 position69 = new Vector2((float)num106, (float)num107);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle28 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Microsoft.Xna.Framework.Color color48 = color6;
							float rotation69 = 0f;
							origin = default(Vector2);
							spriteBatch69.Draw(texture28, position69, sourceRectangle28, color48, rotation69, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white23 = Microsoft.Xna.Framework.Color.White;
							if (Main.player[Main.myPlayer].armor[num105].type > 0 && Main.player[Main.myPlayer].armor[num105].stack > 0)
							{
								float num108 = 1f;
								if (Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height > 32)
								{
									if (Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width > Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height)
									{
										num108 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width;
									}
									else
									{
										num108 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height;
									}
								}
								num108 *= Main.inventoryScale;
								SpriteBatch spriteBatch70 = this.spriteBatch;
								Texture2D texture29 = Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type];
								Vector2 position70 = new Vector2((float)num106 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width * 0.5f * num108, (float)num107 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height * 0.5f * num108);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle29 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height));
								Microsoft.Xna.Framework.Color alpha4 = Main.player[Main.myPlayer].armor[num105].GetAlpha(white23);
								float rotation70 = 0f;
								origin = default(Vector2);
								spriteBatch70.Draw(texture29, position70, sourceRectangle29, alpha4, rotation70, origin, num108, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color49 = Main.player[Main.myPlayer].armor[num105].color;
								if (color49 != default(Microsoft.Xna.Framework.Color))
								{
									SpriteBatch spriteBatch71 = this.spriteBatch;
									Texture2D texture30 = Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type];
									Vector2 position71 = new Vector2((float)num106 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width * 0.5f * num108, (float)num107 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height * 0.5f * num108);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle30 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num105].type].Height));
									Microsoft.Xna.Framework.Color color50 = Main.player[Main.myPlayer].armor[num105].GetColor(white23);
									float rotation71 = 0f;
									origin = default(Vector2);
									spriteBatch71.Draw(texture30, position71, sourceRectangle30, color50, rotation71, origin, num108, SpriteEffects.None, 0f);
								}
								if (Main.player[Main.myPlayer].armor[num105].stack > 1)
								{
									SpriteBatch spriteBatch72 = this.spriteBatch;
									SpriteFontX spriteFont42 = Main.fontItemStack;
									string text60 = string.Concat(Main.player[Main.myPlayer].armor[num105].stack);
									Vector2 position72 = new Vector2((float)num106 + 10f * Main.inventoryScale, (float)num107 + 26f * Main.inventoryScale);
									Microsoft.Xna.Framework.Color color51 = white23;
									float rotation72 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont42, text60, position72, color51, rotation72, origin, num108, SpriteEffects.None, 0f);
								}
							}
						}
					}
					int num109 = (Main.screenHeight - 600) / 2;
					int num110 = (int)((float)Main.screenHeight / 600f * 250f);
					if (Main.craftingHide)
					{
						Main.craftingAlpha -= 0.1f;
						if (Main.craftingAlpha < 0f)
						{
							Main.craftingAlpha = 0f;
						}
					}
					else
					{
						Main.craftingAlpha += 0.025f;
						if (Main.craftingAlpha > 1f)
						{
							Main.craftingAlpha = 1f;
						}
					}
					Microsoft.Xna.Framework.Color color52 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)));
					Main.craftingHide = false;
					if (Main.reforge)
					{
						if (Main.mouseReforge)
						{
							if ((double)Main.reforgeScale < 1.3)
							{
								Main.reforgeScale += 0.02f;
							}
						}
						else if (Main.reforgeScale > 1f)
						{
							Main.reforgeScale -= 0.02f;
						}
						if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.craftGuide)
						{
							Main.reforge = false;
							Main.player[Main.myPlayer].dropItemCheck();
							Recipe.FindRecipes();
						}
						else
						{
							int num111 = 101;
							int num112 = 241;
							string text61 = "费用: ";
							if (Main.reforgeItem.type > 0)
							{
								int value2 = Main.reforgeItem.value;
								string text62 = "";
								int num113 = 0;
								int num114 = 0;
								int num115 = 0;
								int num116 = 0;
								int num117 = value2;
								if (num117 < 1)
								{
									num117 = 1;
								}
								if (num117 >= 1000000)
								{
									num113 = num117 / 1000000;
									num117 -= num113 * 1000000;
								}
								if (num117 >= 10000)
								{
									num114 = num117 / 10000;
									num117 -= num114 * 10000;
								}
								if (num117 >= 100)
								{
									num115 = num117 / 100;
									num117 -= num115 * 100;
								}
								if (num117 >= 1)
								{
									num116 = num117;
								}
								if (num113 > 0)
								{
									text62 = text62 + num113 + " 白金币 ";
								}
								if (num114 > 0)
								{
									text62 = text62 + num114 + " 金币 ";
								}
								if (num115 > 0)
								{
									text62 = text62 + num115 + " 银币 ";
								}
								if (num116 > 0)
								{
									text62 = text62 + num116 + " 铜币 ";
								}
								float num118 = (float)Main.mouseTextColor / 255f;
								Microsoft.Xna.Framework.Color white24 = Microsoft.Xna.Framework.Color.White;
								if (num113 > 0)
								{
									white24 = new Microsoft.Xna.Framework.Color((int)((byte)(220f * num118)), (int)((byte)(220f * num118)), (int)((byte)(198f * num118)), (int)Main.mouseTextColor);
								}
								else if (num114 > 0)
								{
									white24 = new Microsoft.Xna.Framework.Color((int)((byte)(224f * num118)), (int)((byte)(201f * num118)), (int)((byte)(92f * num118)), (int)Main.mouseTextColor);
								}
								else if (num115 > 0)
								{
									white24 = new Microsoft.Xna.Framework.Color((int)((byte)(181f * num118)), (int)((byte)(192f * num118)), (int)((byte)(193f * num118)), (int)Main.mouseTextColor);
								}
								else if (num116 > 0)
								{
									white24 = new Microsoft.Xna.Framework.Color((int)((byte)(246f * num118)), (int)((byte)(138f * num118)), (int)((byte)(96f * num118)), (int)Main.mouseTextColor);
								}
								SpriteBatch spriteBatch73 = this.spriteBatch;
								SpriteFontX spriteFont43 = Main.fontMouseText;
								string text63 = text62;
								Vector2 position73 = new Vector2((float)(num111 + 50) + Main.fontMouseText.MeasureString(text61).X, (float)num112);
								Microsoft.Xna.Framework.Color color53 = white24;
								float rotation73 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont43, text63, position73, color53, rotation73, origin, 1f, SpriteEffects.None, 0f);
								int num119 = num111 + 70;
								int num120 = num112 + 40;
								this.spriteBatch.Draw(Main.reforgeTexture, new Vector2((float)num119, (float)num120), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.reforgeTexture.Width, Main.reforgeTexture.Height)), Microsoft.Xna.Framework.Color.White, 0f, new Vector2((float)(Main.reforgeTexture.Width / 2), (float)(Main.reforgeTexture.Height / 2)), Main.reforgeScale, SpriteEffects.None, 0f);
								if (Main.mouseX > num119 - Main.reforgeTexture.Width / 2 && Main.mouseX < num119 + Main.reforgeTexture.Width / 2 && Main.mouseY > num120 - Main.reforgeTexture.Height / 2 && Main.mouseY < num120 + Main.reforgeTexture.Height / 2)
								{
									text45 = "锻造";
									if (!Main.mouseReforge)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									Main.mouseReforge = true;
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft && Main.player[Main.myPlayer].BuyItem(value2))
									{
										Main.reforgeItem.SetDefaults(Main.reforgeItem.name);
										Main.reforgeItem.Prefix(-2);
										Main.reforgeItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.reforgeItem.width / 2);
										Main.reforgeItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.reforgeItem.height / 2);
										ItemText.NewText(Main.reforgeItem, Main.reforgeItem.stack);
										Main.PlaySound(2, -1, -1, 37);
									}
								}
								else
								{
									Main.mouseReforge = false;
								}
							}
							else
							{
								text61 = "将准备锻造的物品放在这里";
							}
							SpriteBatch spriteBatch74 = this.spriteBatch;
							SpriteFontX spriteFont44 = Main.fontMouseText;
							string text64 = text61;
							Vector2 position74 = new Vector2((float)(num111 + 50), (float)num112);
							Microsoft.Xna.Framework.Color color54 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
							float rotation74 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont44, text64, position74, color54, rotation74, origin, 1f, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color white25 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
							if (Main.mouseX >= num111 && (float)Main.mouseX <= (float)num111 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num112 && (float)Main.mouseY <= (float)num112 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								Main.craftingHide = true;
								if (Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0)
								{
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										Item item5 = Main.mouseItem;
										Main.mouseItem = Main.reforgeItem;
										Main.reforgeItem = item5;
										if (Main.reforgeItem.type == 0 || Main.reforgeItem.stack < 1)
										{
											Main.reforgeItem = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.reforgeItem) && Main.reforgeItem.stack != Main.reforgeItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.reforgeItem.stack <= Main.mouseItem.maxStack)
											{
												Main.reforgeItem.stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num121 = Main.mouseItem.maxStack - Main.reforgeItem.stack;
												Main.reforgeItem.stack += num121;
												Main.mouseItem.stack -= num121;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.reforgeItem.type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.reforgeItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.reforgeItem.Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.reforgeItem.stack--;
										if (Main.reforgeItem.stack <= 0)
										{
											Main.reforgeItem = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
								}
								text45 = Main.reforgeItem.name;
								Main.toolTip = (Item)Main.reforgeItem.Clone();
								if (Main.reforgeItem.stack > 1)
								{
									object obj = text45;
									text45 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.reforgeItem.stack,
										")"
									});
								}
							}
							SpriteBatch spriteBatch75 = this.spriteBatch;
							Texture2D texture31 = Main.inventoryBack4Texture;
							Vector2 position75 = new Vector2((float)num111, (float)num112);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle31 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Microsoft.Xna.Framework.Color color55 = color6;
							float rotation75 = 0f;
							origin = default(Vector2);
							spriteBatch75.Draw(texture31, position75, sourceRectangle31, color55, rotation75, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white25 = Microsoft.Xna.Framework.Color.White;
							if (Main.reforgeItem.type > 0 && Main.reforgeItem.stack > 0)
							{
								float num122 = 1f;
								if (Main.itemTexture[Main.reforgeItem.type].Width > 32 || Main.itemTexture[Main.reforgeItem.type].Height > 32)
								{
									if (Main.itemTexture[Main.reforgeItem.type].Width > Main.itemTexture[Main.reforgeItem.type].Height)
									{
										num122 = 32f / (float)Main.itemTexture[Main.reforgeItem.type].Width;
									}
									else
									{
										num122 = 32f / (float)Main.itemTexture[Main.reforgeItem.type].Height;
									}
								}
								num122 *= Main.inventoryScale;
								SpriteBatch spriteBatch76 = this.spriteBatch;
								Texture2D texture32 = Main.itemTexture[Main.reforgeItem.type];
								Vector2 position76 = new Vector2((float)num111 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Width * 0.5f * num122, (float)num112 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Height * 0.5f * num122);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle32 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height));
								Microsoft.Xna.Framework.Color alpha5 = Main.reforgeItem.GetAlpha(white25);
								float rotation76 = 0f;
								origin = default(Vector2);
								spriteBatch76.Draw(texture32, position76, sourceRectangle32, alpha5, rotation76, origin, num122, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color56 = Main.reforgeItem.color;
								if (color56 != default(Microsoft.Xna.Framework.Color))
								{
									SpriteBatch spriteBatch77 = this.spriteBatch;
									Texture2D texture33 = Main.itemTexture[Main.reforgeItem.type];
									Vector2 position77 = new Vector2((float)num111 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Width * 0.5f * num122, (float)num112 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Height * 0.5f * num122);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle33 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height));
									Microsoft.Xna.Framework.Color color57 = Main.reforgeItem.GetColor(white25);
									float rotation77 = 0f;
									origin = default(Vector2);
									spriteBatch77.Draw(texture33, position77, sourceRectangle33, color57, rotation77, origin, num122, SpriteEffects.None, 0f);
								}
								if (Main.reforgeItem.stack > 1)
								{
									SpriteBatch spriteBatch78 = this.spriteBatch;
									SpriteFontX spriteFont45 = Main.fontItemStack;
									string text65 = string.Concat(Main.reforgeItem.stack);
									Vector2 position78 = new Vector2((float)num111 + 10f * Main.inventoryScale, (float)num112 + 26f * Main.inventoryScale);
									Microsoft.Xna.Framework.Color color58 = white25;
									float rotation78 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont45, text65, position78, color58, rotation78, origin, num122, SpriteEffects.None, 0f);
								}
							}
						}
					}
					else if (Main.craftGuide)
					{
						if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.reforge)
						{
							Main.craftGuide = false;
							Main.player[Main.myPlayer].dropItemCheck();
							Recipe.FindRecipes();
						}
						else
						{
							int num123 = 73;
							int num124 = 331;
							num124 += num109;
							string text66;
							if (Main.guideItem.type > 0)
							{
								text66 = "显示<" + Main.guideItem.CName + ">能制作的物品";
								SpriteBatch spriteBatch79 = this.spriteBatch;
								SpriteFontX spriteFont46 = Main.fontMouseText;
								string text67 = "制造环境:";
								Vector2 position79 = new Vector2((float)num123, (float)(num124 + 118));
								Microsoft.Xna.Framework.Color color59 = color52;
								float rotation79 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont46, text67, position79, color59, rotation79, origin, 1f, SpriteEffects.None, 0f);
								int num125 = Main.focusRecipe;
								int num126 = 0;
								int num127 = 0;
								while (num127 < Recipe.maxRequirements)
								{
									int num128 = (num127 + 1) * 26;
									if (Main.recipe[Main.availableRecipe[num125]].requiredTile[num127] == -1)
									{
										if (num127 == 0 && !Main.recipe[Main.availableRecipe[num125]].needWater)
										{
											SpriteBatch spriteBatch80 = this.spriteBatch;
											SpriteFontX spriteFont47 = Main.fontMouseText;
											string text68 = "可直接制造";
											Vector2 position80 = new Vector2((float)num123, (float)(num124 + 118 + num128));
											Microsoft.Xna.Framework.Color color60 = color52;
											float rotation80 = 0f;
											origin = default(Vector2);
											this.DStoDSX(spriteFont47, text68, position80, color60, rotation80, origin, 1f, SpriteEffects.None, 0f);
											break;
										}
										break;
									}
									else
									{
										num126++;
										SpriteBatch spriteBatch81 = this.spriteBatch;
										SpriteFontX spriteFont48 = Main.fontMouseText;
										string text69 = Main.tileName[Main.recipe[Main.availableRecipe[num125]].requiredTile[num127]];
										Vector2 position81 = new Vector2((float)num123, (float)(num124 + 118 + num128));
										Microsoft.Xna.Framework.Color color61 = color52;
										float rotation81 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont48, text69, position81, color61, rotation81, origin, 1f, SpriteEffects.None, 0f);
										num127++;
									}
								}
								if (Main.recipe[Main.availableRecipe[num125]].needWater)
								{
									int num129 = (num126 + 1) * 26;
									SpriteBatch spriteBatch82 = this.spriteBatch;
									SpriteFontX spriteFont49 = Main.fontMouseText;
									string text70 = "可直接制造";
									Vector2 position82 = new Vector2((float)num123, (float)(num124 + 118 + num129));
									Microsoft.Xna.Framework.Color color62 = color52;
									float rotation82 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont49, text70, position82, color62, rotation82, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								text66 = "放置材料查询";
							}
							SpriteBatch spriteBatch83 = this.spriteBatch;
							SpriteFontX spriteFont50 = Main.fontMouseText;
							string text71 = text66;
							Vector2 position83 = new Vector2((float)(num123 + 50), (float)(num124 + 12));
							Microsoft.Xna.Framework.Color color63 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
							float rotation83 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont50, text71, position83, color63, rotation83, origin, 1f, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color white26 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
							if (Main.mouseX >= num123 && (float)Main.mouseX <= (float)num123 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num124 && (float)Main.mouseY <= (float)num124 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								Main.craftingHide = true;
								if (Main.mouseItem.material || Main.mouseItem.type == 0)
								{
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										Item item6 = Main.mouseItem;
										Main.mouseItem = Main.guideItem;
										Main.guideItem = item6;
										if (Main.guideItem.type == 0 || Main.guideItem.stack < 1)
										{
											Main.guideItem = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.guideItem) && Main.guideItem.stack != Main.guideItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.guideItem.stack <= Main.mouseItem.maxStack)
											{
												Main.guideItem.stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num130 = Main.mouseItem.maxStack - Main.guideItem.stack;
												Main.guideItem.stack += num130;
												Main.mouseItem.stack -= num130;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.guideItem.type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.guideItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.guideItem.Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.guideItem.stack--;
										if (Main.guideItem.stack <= 0)
										{
											Main.guideItem = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
								}
								text45 = Main.guideItem.CName;
								Main.toolTip = (Item)Main.guideItem.Clone();
								if (Main.guideItem.stack > 1)
								{
									object obj = text45;
									text45 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.guideItem.stack,
										")"
									});
								}
							}
							SpriteBatch spriteBatch84 = this.spriteBatch;
							Texture2D texture34 = Main.inventoryBack4Texture;
							Vector2 position84 = new Vector2((float)num123, (float)num124);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle34 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Microsoft.Xna.Framework.Color color64 = color6;
							float rotation84 = 0f;
							origin = default(Vector2);
							spriteBatch84.Draw(texture34, position84, sourceRectangle34, color64, rotation84, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white26 = Microsoft.Xna.Framework.Color.White;
							if (Main.guideItem.type > 0 && Main.guideItem.stack > 0)
							{
								float num131 = 1f;
								if (Main.itemTexture[Main.guideItem.type].Width > 32 || Main.itemTexture[Main.guideItem.type].Height > 32)
								{
									if (Main.itemTexture[Main.guideItem.type].Width > Main.itemTexture[Main.guideItem.type].Height)
									{
										num131 = 32f / (float)Main.itemTexture[Main.guideItem.type].Width;
									}
									else
									{
										num131 = 32f / (float)Main.itemTexture[Main.guideItem.type].Height;
									}
								}
								num131 *= Main.inventoryScale;
								SpriteBatch spriteBatch85 = this.spriteBatch;
								Texture2D texture35 = Main.itemTexture[Main.guideItem.type];
								Vector2 position85 = new Vector2((float)num123 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Width * 0.5f * num131, (float)num124 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Height * 0.5f * num131);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle35 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height));
								Microsoft.Xna.Framework.Color alpha6 = Main.guideItem.GetAlpha(white26);
								float rotation85 = 0f;
								origin = default(Vector2);
								spriteBatch85.Draw(texture35, position85, sourceRectangle35, alpha6, rotation85, origin, num131, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color65 = Main.guideItem.color;
								if (color65 != default(Microsoft.Xna.Framework.Color))
								{
									SpriteBatch spriteBatch86 = this.spriteBatch;
									Texture2D texture36 = Main.itemTexture[Main.guideItem.type];
									Vector2 position86 = new Vector2((float)num123 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Width * 0.5f * num131, (float)num124 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Height * 0.5f * num131);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle36 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height));
									Microsoft.Xna.Framework.Color color66 = Main.guideItem.GetColor(white26);
									float rotation86 = 0f;
									origin = default(Vector2);
									spriteBatch86.Draw(texture36, position86, sourceRectangle36, color66, rotation86, origin, num131, SpriteEffects.None, 0f);
								}
								if (Main.guideItem.stack > 1)
								{
									SpriteBatch spriteBatch87 = this.spriteBatch;
									SpriteFontX spriteFont51 = Main.fontItemStack;
									string text72 = string.Concat(Main.guideItem.stack);
									Vector2 position87 = new Vector2((float)num123 + 10f * Main.inventoryScale, (float)num124 + 26f * Main.inventoryScale);
									Microsoft.Xna.Framework.Color color67 = white26;
									float rotation87 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont51, text72, position87, color67, rotation87, origin, num131, SpriteEffects.None, 0f);
								}
							}
						}
					}
					if (!Main.reforge)
					{
						if (Main.numAvailableRecipes > 0)
						{
							SpriteBatch spriteBatch88 = this.spriteBatch;
							SpriteFontX spriteFont52 = Main.fontMouseText;
							string text73 = "制作";
							Vector2 position88 = new Vector2(76f, (float)(414 + num109));
							Microsoft.Xna.Framework.Color color68 = color52;
							float rotation88 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont52, text73, position88, color68, rotation88, origin, 1f, SpriteEffects.None, 0f);
						}
						for (int num132 = 0; num132 < Recipe.maxRecipes; num132++)
						{
							Main.inventoryScale = 100f / (Math.Abs(Main.availableRecipeY[num132]) + 100f);
							if ((double)Main.inventoryScale < 0.75)
							{
								Main.inventoryScale = 0.75f;
							}
							if (Main.availableRecipeY[num132] < (float)((num132 - Main.focusRecipe) * 65))
							{
								if (Main.availableRecipeY[num132] == 0f)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								Main.availableRecipeY[num132] += 6.5f;
							}
							else if (Main.availableRecipeY[num132] > (float)((num132 - Main.focusRecipe) * 65))
							{
								if (Main.availableRecipeY[num132] == 0f)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								Main.availableRecipeY[num132] -= 6.5f;
							}
							if (num132 < Main.numAvailableRecipes && Math.Abs(Main.availableRecipeY[num132]) <= (float)num110)
							{
								int num133 = (int)(46f - 26f * Main.inventoryScale);
								int num134 = (int)(410f + Main.availableRecipeY[num132] * Main.inventoryScale - 30f * Main.inventoryScale + (float)num109);
								double num135 = (double)(color6.A + 50);
								double num136 = 255.0;
								if (Math.Abs(Main.availableRecipeY[num132]) > (float)(num110 - 100))
								{
									num135 = (double)(150f * (100f - (Math.Abs(Main.availableRecipeY[num132]) - (float)(num110 - 100)))) * 0.01;
									num136 = (double)(255f * (100f - (Math.Abs(Main.availableRecipeY[num132]) - (float)(num110 - 100)))) * 0.01;
								}
								new Microsoft.Xna.Framework.Color((int)((byte)num135), (int)((byte)num135), (int)((byte)num135), (int)((byte)num135));
								Microsoft.Xna.Framework.Color color69 = new Microsoft.Xna.Framework.Color((int)((byte)num136), (int)((byte)num136), (int)((byte)num136), (int)((byte)num136));
								if (Main.mouseX >= num133 && (float)Main.mouseX <= (float)num133 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num134 && (float)Main.mouseY <= (float)num134 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.focusRecipe == num132 && Main.guideItem.type == 0)
									{
										if (Main.mouseItem.type == 0 || (Main.mouseItem.IsTheSameAs(Main.recipe[Main.availableRecipe[num132]].createItem) && Main.mouseItem.stack + Main.recipe[Main.availableRecipe[num132]].createItem.stack <= Main.mouseItem.maxStack))
										{
											if (Main.mouseLeftRelease && Main.mouseLeft)
											{
												int stack = Main.mouseItem.stack;
												Main.mouseItem = (Item)Main.recipe[Main.availableRecipe[num132]].createItem.Clone();
												Main.mouseItem.Prefix(-1);
												Main.mouseItem.stack += stack;
												Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
												Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
												ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[num132]].createItem.stack);
												Main.recipe[Main.availableRecipe[num132]].Create();
												if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[num132]].createItem.type > 0)
												{
													Main.PlaySound(7, -1, -1, 1);
												}
											}
											else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
											{
												if (Main.stackSplit == 0)
												{
													Main.stackSplit = 15;
												}
												else
												{
													Main.stackSplit = Main.stackDelay;
												}
												int stack2 = Main.mouseItem.stack;
												Main.mouseItem = (Item)Main.recipe[Main.availableRecipe[num132]].createItem.Clone();
												Main.mouseItem.stack += stack2;
												Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
												Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
												ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[num132]].createItem.stack);
												Main.recipe[Main.availableRecipe[num132]].Create();
												if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[num132]].createItem.type > 0)
												{
													Main.PlaySound(7, -1, -1, 1);
												}
											}
										}
									}
									else if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										Main.focusRecipe = num132;
									}
									Main.craftingHide = true;
									text45 = Main.recipe[Main.availableRecipe[num132]].createItem.CName;
									Main.toolTip = (Item)Main.recipe[Main.availableRecipe[num132]].createItem.Clone();
									if (Main.recipe[Main.availableRecipe[num132]].createItem.stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											Main.recipe[Main.availableRecipe[num132]].createItem.stack,
											")"
										});
									}
								}
								if (Main.numAvailableRecipes > 0)
								{
									num135 -= 50.0;
									if (num135 < 0.0)
									{
										num135 = 0.0;
									}
									SpriteBatch spriteBatch89 = this.spriteBatch;
									Texture2D texture37 = Main.inventoryBack4Texture;
									Vector2 position89 = new Vector2((float)num133, (float)num134);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle37 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
									Microsoft.Xna.Framework.Color color70 = new Microsoft.Xna.Framework.Color((int)((byte)num135), (int)((byte)num135), (int)((byte)num135), (int)((byte)num135));
									float rotation89 = 0f;
									origin = default(Vector2);
									spriteBatch89.Draw(texture37, position89, sourceRectangle37, color70, rotation89, origin, Main.inventoryScale, SpriteEffects.None, 0f);
									if (Main.recipe[Main.availableRecipe[num132]].createItem.type > 0 && Main.recipe[Main.availableRecipe[num132]].createItem.stack > 0)
									{
										float num137 = 1f;
										if (Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height > 32)
										{
											if (Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width > Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height)
											{
												num137 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width;
											}
											else
											{
												num137 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height;
											}
										}
										num137 *= Main.inventoryScale;
										SpriteBatch spriteBatch90 = this.spriteBatch;
										Texture2D texture38 = Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type];
										Vector2 position90 = new Vector2((float)num133 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width * 0.5f * num137, (float)num134 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height * 0.5f * num137);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle38 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height));
										Microsoft.Xna.Framework.Color alpha7 = Main.recipe[Main.availableRecipe[num132]].createItem.GetAlpha(color69);
										float rotation90 = 0f;
										origin = default(Vector2);
										spriteBatch90.Draw(texture38, position90, sourceRectangle38, alpha7, rotation90, origin, num137, SpriteEffects.None, 0f);
										Microsoft.Xna.Framework.Color color71 = Main.recipe[Main.availableRecipe[num132]].createItem.color;
										if (color71 != default(Microsoft.Xna.Framework.Color))
										{
											SpriteBatch spriteBatch91 = this.spriteBatch;
											Texture2D texture39 = Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type];
											Vector2 position91 = new Vector2((float)num133 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width * 0.5f * num137, (float)num134 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height * 0.5f * num137);
											Microsoft.Xna.Framework.Rectangle? sourceRectangle39 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[num132]].createItem.type].Height));
											Microsoft.Xna.Framework.Color color72 = Main.recipe[Main.availableRecipe[num132]].createItem.GetColor(color69);
											float rotation91 = 0f;
											origin = default(Vector2);
											spriteBatch91.Draw(texture39, position91, sourceRectangle39, color72, rotation91, origin, num137, SpriteEffects.None, 0f);
										}
										if (Main.recipe[Main.availableRecipe[num132]].createItem.stack > 1)
										{
											SpriteBatch spriteBatch92 = this.spriteBatch;
											SpriteFontX spriteFont53 = Main.fontItemStack;
											string text74 = string.Concat(Main.recipe[Main.availableRecipe[num132]].createItem.stack);
											Vector2 position92 = new Vector2((float)num133 + 10f * Main.inventoryScale, (float)num134 + 26f * Main.inventoryScale);
											Microsoft.Xna.Framework.Color color73 = color69;
											float rotation92 = 0f;
											origin = default(Vector2);
											this.DStoDSX(spriteFont53, text74, position92, color73, rotation92, origin, num137, SpriteEffects.None, 0f);
										}
									}
								}
							}
						}
						if (Main.numAvailableRecipes > 0)
						{
							int num138 = 0;
							while (num138 < Recipe.maxRequirements && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type != 0)
							{
								int num139 = 80 + num138 * 40;
								int num140 = 380 + num109;
								double num141 = (double)(color6.A + 50);
								Microsoft.Xna.Framework.Color white27 = Microsoft.Xna.Framework.Color.White;
								Microsoft.Xna.Framework.Color white28 = Microsoft.Xna.Framework.Color.White;
								num141 = (double)((float)(color6.A + 50) - Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2f);
								double num142 = (double)(255f - Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2f);
								if (num141 < 0.0)
								{
									num141 = 0.0;
								}
								if (num142 < 0.0)
								{
									num142 = 0.0;
								}
								white27.R = (byte)num141;
								white27.G = (byte)num141;
								white27.B = (byte)num141;
								white27.A = (byte)num141;
								white28.R = (byte)num142;
								white28.G = (byte)num142;
								white28.B = (byte)num142;
								white28.A = (byte)num142;
								Main.inventoryScale = 0.6f;
								if (num141 == 0.0)
								{
									break;
								}
								if (Main.mouseX >= num139 && (float)Main.mouseX <= (float)num139 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num140 && (float)Main.mouseY <= (float)num140 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.craftingHide = true;
									Main.player[Main.myPlayer].mouseInterface = true;
									text45 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].CName;
									Main.toolTip = (Item)Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].Clone();
									if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].stack,
											")"
										});
									}
								}
								num141 -= 50.0;
								if (num141 < 0.0)
								{
									num141 = 0.0;
								}
								SpriteBatch spriteBatch93 = this.spriteBatch;
								Texture2D texture40 = Main.inventoryBack4Texture;
								Vector2 position93 = new Vector2((float)num139, (float)num140);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle40 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color74 = new Microsoft.Xna.Framework.Color((int)((byte)num141), (int)((byte)num141), (int)((byte)num141), (int)((byte)num141));
								float rotation93 = 0f;
								origin = default(Vector2);
								spriteBatch93.Draw(texture40, position93, sourceRectangle40, color74, rotation93, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type > 0 && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].stack > 0)
								{
									float num143 = 1f;
									if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height > 32)
									{
										if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width > Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height)
										{
											num143 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width;
										}
										else
										{
											num143 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height;
										}
									}
									num143 *= Main.inventoryScale;
									SpriteBatch spriteBatch94 = this.spriteBatch;
									Texture2D texture41 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type];
									Vector2 position94 = new Vector2((float)num139 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width * 0.5f * num143, (float)num140 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height * 0.5f * num143);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle41 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height));
									Microsoft.Xna.Framework.Color alpha8 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].GetAlpha(white28);
									float rotation94 = 0f;
									origin = default(Vector2);
									spriteBatch94.Draw(texture41, position94, sourceRectangle41, alpha8, rotation94, origin, num143, SpriteEffects.None, 0f);
									Microsoft.Xna.Framework.Color color75 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].color;
									if (color75 != default(Microsoft.Xna.Framework.Color))
									{
										SpriteBatch spriteBatch95 = this.spriteBatch;
										Texture2D texture42 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type];
										Vector2 position95 = new Vector2((float)num139 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width * 0.5f * num143, (float)num140 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height * 0.5f * num143);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle42 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].type].Height));
										Microsoft.Xna.Framework.Color color76 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].GetColor(white28);
										float rotation95 = 0f;
										origin = default(Vector2);
										spriteBatch95.Draw(texture42, position95, sourceRectangle42, color76, rotation95, origin, num143, SpriteEffects.None, 0f);
									}
									if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].stack > 1)
									{
										SpriteBatch spriteBatch96 = this.spriteBatch;
										SpriteFontX spriteFont54 = Main.fontItemStack;
										string text75 = string.Concat(Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num138].stack);
										Vector2 position96 = new Vector2((float)num139 + 10f * Main.inventoryScale, (float)num140 + 26f * Main.inventoryScale);
										Microsoft.Xna.Framework.Color color77 = white28;
										float rotation96 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont54, text75, position96, color77, rotation96, origin, num143, SpriteEffects.None, 0f);
									}
								}
								num138++;
							}
						}
					}
					SpriteBatch spriteBatch97 = this.spriteBatch;
					SpriteFontX spriteFont55 = Main.fontMouseText;
					string text76 = "钱币";
					Vector2 position97 = new Vector2(496f, 84f);
					Microsoft.Xna.Framework.Color color78 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation97 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont55, text76, position97, color78, rotation97, origin, 0.75f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.6f;
					for (int num144 = 0; num144 < 4; num144++)
					{
						int num145 = 497;
						int num146 = (int)(85f + (float)(num144 * 56) * Main.inventoryScale + 20f);
						int num147 = num144 + 40;
						Microsoft.Xna.Framework.Color white29 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
						if (Main.mouseX >= num145 && (float)Main.mouseX <= (float)num145 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num146 && (float)Main.mouseY <= (float)num146 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeftRelease && Main.mouseLeft)
							{
								if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
								{
									if (Main.player[Main.myPlayer].inventory[num147].type > 0)
									{
										if (Main.npcShop > 0)
										{
											if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num147].value, Main.player[Main.myPlayer].inventory[num147].stack))
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num147]);
												Main.player[Main.myPlayer].inventory[num147].SetDefaults(0, false);
												Main.PlaySound(18, -1, -1, 1);
											}
											else if (Main.player[Main.myPlayer].inventory[num147].value == 0)
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num147]);
												Main.player[Main.myPlayer].inventory[num147].SetDefaults(0, false);
												Main.PlaySound(7, -1, -1, 1);
											}
										}
										else
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
											Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num147].Clone();
											Main.player[Main.myPlayer].inventory[num147].SetDefaults(0, false);
										}
									}
								}
								else if ((Main.player[Main.myPlayer].selectedItem != num147 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.type == 71 || Main.mouseItem.type == 72 || Main.mouseItem.type == 73 || Main.mouseItem.type == 74))
								{
									Item item7 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].inventory[num147];
									Main.player[Main.myPlayer].inventory[num147] = item7;
									if (Main.player[Main.myPlayer].inventory[num147].type == 0 || Main.player[Main.myPlayer].inventory[num147].stack < 1)
									{
										Main.player[Main.myPlayer].inventory[num147] = new Item();
									}
									if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num147]) && Main.player[Main.myPlayer].inventory[num147].stack != Main.player[Main.myPlayer].inventory[num147].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
									{
										if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num147].stack <= Main.mouseItem.maxStack)
										{
											Main.player[Main.myPlayer].inventory[num147].stack += Main.mouseItem.stack;
											Main.mouseItem.stack = 0;
										}
										else
										{
											int num148 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num147].stack;
											Main.player[Main.myPlayer].inventory[num147].stack += num148;
											Main.mouseItem.stack -= num148;
										}
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num147].type > 0)
									{
										Main.PlaySound(7, -1, -1, 1);
									}
									Recipe.FindRecipes();
								}
							}
							else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num147]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
							{
								if (Main.mouseItem.type == 0)
								{
									Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num147].Clone();
									Main.mouseItem.stack = 0;
								}
								Main.mouseItem.stack++;
								Main.player[Main.myPlayer].inventory[num147].stack--;
								if (Main.player[Main.myPlayer].inventory[num147].stack <= 0)
								{
									Main.player[Main.myPlayer].inventory[num147] = new Item();
								}
								Recipe.FindRecipes();
								Main.soundInstanceMenuTick.Stop();
								Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
								Main.PlaySound(12, -1, -1, 1);
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}
							}
							text45 = Main.player[Main.myPlayer].inventory[num147].CName;
							Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num147].Clone();
							if (Main.player[Main.myPlayer].inventory[num147].stack > 1)
							{
								object obj = text45;
								text45 = string.Concat(new object[]
								{
									obj,
									" (",
									Main.player[Main.myPlayer].inventory[num147].stack,
									")"
								});
							}
						}
						SpriteBatch spriteBatch98 = this.spriteBatch;
						Texture2D texture43 = Main.inventoryBackTexture;
						Vector2 position98 = new Vector2((float)num145, (float)num146);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle43 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Microsoft.Xna.Framework.Color color79 = color6;
						float rotation98 = 0f;
						origin = default(Vector2);
						spriteBatch98.Draw(texture43, position98, sourceRectangle43, color79, rotation98, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						white29 = Microsoft.Xna.Framework.Color.White;
						if (Main.player[Main.myPlayer].inventory[num147].type > 0 && Main.player[Main.myPlayer].inventory[num147].stack > 0)
						{
							float num149 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height)
								{
									num149 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width;
								}
								else
								{
									num149 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height;
								}
							}
							num149 *= Main.inventoryScale;
							SpriteBatch spriteBatch99 = this.spriteBatch;
							Texture2D texture44 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type];
							Vector2 position99 = new Vector2((float)num145 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width * 0.5f * num149, (float)num146 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height * 0.5f * num149);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle44 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height));
							Microsoft.Xna.Framework.Color alpha9 = Main.player[Main.myPlayer].inventory[num147].GetAlpha(white29);
							float rotation99 = 0f;
							origin = default(Vector2);
							spriteBatch99.Draw(texture44, position99, sourceRectangle44, alpha9, rotation99, origin, num149, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color color80 = Main.player[Main.myPlayer].inventory[num147].color;
							if (color80 != default(Microsoft.Xna.Framework.Color))
							{
								SpriteBatch spriteBatch100 = this.spriteBatch;
								Texture2D texture45 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type];
								Vector2 position100 = new Vector2((float)num145 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width * 0.5f * num149, (float)num146 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height * 0.5f * num149);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle45 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num147].type].Height));
								Microsoft.Xna.Framework.Color color81 = Main.player[Main.myPlayer].inventory[num147].GetColor(white29);
								float rotation100 = 0f;
								origin = default(Vector2);
								spriteBatch100.Draw(texture45, position100, sourceRectangle45, color81, rotation100, origin, num149, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].inventory[num147].stack > 1)
							{
								SpriteBatch spriteBatch101 = this.spriteBatch;
								SpriteFontX spriteFont56 = Main.fontItemStack;
								string text77 = string.Concat(Main.player[Main.myPlayer].inventory[num147].stack);
								Vector2 position101 = new Vector2((float)num145 + 10f * Main.inventoryScale, (float)num146 + 26f * Main.inventoryScale);
								Microsoft.Xna.Framework.Color color82 = white29;
								float rotation101 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont56, text77, position101, color82, rotation101, origin, num149, SpriteEffects.None, 0f);
							}
						}
					}
					SpriteBatch spriteBatch102 = this.spriteBatch;
					SpriteFontX spriteFont57 = Main.fontMouseText;
					string text78 = "弹药";
					Vector2 position102 = new Vector2(532f, 84f);
					Microsoft.Xna.Framework.Color color83 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation102 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont57, text78, position102, color83, rotation102, origin, 0.75f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.6f;
					for (int num150 = 0; num150 < 4; num150++)
					{
						int num151 = 534;
						int num152 = (int)(85f + (float)(num150 * 56) * Main.inventoryScale + 20f);
						int num153 = 44 + num150;
						Microsoft.Xna.Framework.Color white30 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
						if (Main.mouseX >= num151 && (float)Main.mouseX <= (float)num151 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num152 && (float)Main.mouseY <= (float)num152 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeftRelease && Main.mouseLeft)
							{
								if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
								{
									if (Main.player[Main.myPlayer].inventory[num153].type > 0)
									{
										if (Main.npcShop > 0)
										{
											if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num153].value, Main.player[Main.myPlayer].inventory[num153].stack))
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num153]);
												Main.player[Main.myPlayer].inventory[num153].SetDefaults(0, false);
												Main.PlaySound(18, -1, -1, 1);
											}
											else if (Main.player[Main.myPlayer].inventory[num153].value == 0)
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num153]);
												Main.player[Main.myPlayer].inventory[num153].SetDefaults(0, false);
												Main.PlaySound(7, -1, -1, 1);
											}
										}
										else
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
											Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num153].Clone();
											Main.player[Main.myPlayer].inventory[num153].SetDefaults(0, false);
										}
									}
								}
								else if ((Main.player[Main.myPlayer].selectedItem != num153 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.ammo > 0 || Main.mouseItem.type == 530))
								{
									Item item8 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].inventory[num153];
									Main.player[Main.myPlayer].inventory[num153] = item8;
									if (Main.player[Main.myPlayer].inventory[num153].type == 0 || Main.player[Main.myPlayer].inventory[num153].stack < 1)
									{
										Main.player[Main.myPlayer].inventory[num153] = new Item();
									}
									if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num153]) && Main.player[Main.myPlayer].inventory[num153].stack != Main.player[Main.myPlayer].inventory[num153].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
									{
										if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num153].stack <= Main.mouseItem.maxStack)
										{
											Main.player[Main.myPlayer].inventory[num153].stack += Main.mouseItem.stack;
											Main.mouseItem.stack = 0;
										}
										else
										{
											int num154 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num153].stack;
											Main.player[Main.myPlayer].inventory[num153].stack += num154;
											Main.mouseItem.stack -= num154;
										}
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num153].type > 0)
									{
										Main.PlaySound(7, -1, -1, 1);
									}
									Recipe.FindRecipes();
								}
							}
							else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num153]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
							{
								if (Main.mouseItem.type == 0)
								{
									Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num153].Clone();
									Main.mouseItem.stack = 0;
								}
								Main.mouseItem.stack++;
								Main.player[Main.myPlayer].inventory[num153].stack--;
								if (Main.player[Main.myPlayer].inventory[num153].stack <= 0)
								{
									Main.player[Main.myPlayer].inventory[num153] = new Item();
								}
								Recipe.FindRecipes();
								Main.soundInstanceMenuTick.Stop();
								Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
								Main.PlaySound(12, -1, -1, 1);
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}
							}
							text45 = Main.player[Main.myPlayer].inventory[num153].CName;
							Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num153].Clone();
							if (Main.player[Main.myPlayer].inventory[num153].stack > 1)
							{
								object obj = text45;
								text45 = string.Concat(new object[]
								{
									obj,
									" (",
									Main.player[Main.myPlayer].inventory[num153].stack,
									")"
								});
							}
						}
						SpriteBatch spriteBatch103 = this.spriteBatch;
						Texture2D texture46 = Main.inventoryBackTexture;
						Vector2 position103 = new Vector2((float)num151, (float)num152);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle46 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Microsoft.Xna.Framework.Color color84 = color6;
						float rotation103 = 0f;
						origin = default(Vector2);
						spriteBatch103.Draw(texture46, position103, sourceRectangle46, color84, rotation103, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						white30 = Microsoft.Xna.Framework.Color.White;
						if (Main.player[Main.myPlayer].inventory[num153].type > 0 && Main.player[Main.myPlayer].inventory[num153].stack > 0)
						{
							float num155 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height)
								{
									num155 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width;
								}
								else
								{
									num155 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height;
								}
							}
							num155 *= Main.inventoryScale;
							SpriteBatch spriteBatch104 = this.spriteBatch;
							Texture2D texture47 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type];
							Vector2 position104 = new Vector2((float)num151 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width * 0.5f * num155, (float)num152 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height * 0.5f * num155);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle47 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height));
							Microsoft.Xna.Framework.Color alpha10 = Main.player[Main.myPlayer].inventory[num153].GetAlpha(white30);
							float rotation104 = 0f;
							origin = default(Vector2);
							spriteBatch104.Draw(texture47, position104, sourceRectangle47, alpha10, rotation104, origin, num155, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color color85 = Main.player[Main.myPlayer].inventory[num153].color;
							if (color85 != default(Microsoft.Xna.Framework.Color))
							{
								SpriteBatch spriteBatch105 = this.spriteBatch;
								Texture2D texture48 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type];
								Vector2 position105 = new Vector2((float)num151 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width * 0.5f * num155, (float)num152 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height * 0.5f * num155);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle48 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num153].type].Height));
								Microsoft.Xna.Framework.Color color86 = Main.player[Main.myPlayer].inventory[num153].GetColor(white30);
								float rotation105 = 0f;
								origin = default(Vector2);
								spriteBatch105.Draw(texture48, position105, sourceRectangle48, color86, rotation105, origin, num155, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].inventory[num153].stack > 1)
							{
								SpriteBatch spriteBatch106 = this.spriteBatch;
								SpriteFontX spriteFont58 = Main.fontItemStack;
								string text79 = string.Concat(Main.player[Main.myPlayer].inventory[num153].stack);
								Vector2 position106 = new Vector2((float)num151 + 10f * Main.inventoryScale, (float)num152 + 26f * Main.inventoryScale);
								Microsoft.Xna.Framework.Color color87 = white30;
								float rotation106 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont58, text79, position106, color87, rotation106, origin, num155, SpriteEffects.None, 0f);
							}
						}
					}
					if (Main.npcShop > 0 && (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1))
					{
						Main.npcShop = 0;
					}
					if (Main.npcShop > 0)
					{
						SpriteBatch spriteBatch107 = this.spriteBatch;
						SpriteFontX spriteFont59 = Main.fontMouseText;
						string text80 = "商店";
						Vector2 position107 = new Vector2(284f, 210f);
						Microsoft.Xna.Framework.Color color88 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation107 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont59, text80, position107, color88, rotation107, origin, 1f, SpriteEffects.None, 0f);
						Main.inventoryScale = 0.75f;
						if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num156 = 0; num156 < 5; num156++)
						{
							for (int num157 = 0; num157 < 4; num157++)
							{
								int num158 = (int)(73f + (float)(num156 * 56) * Main.inventoryScale);
								int num159 = (int)(210f + (float)(num157 * 56) * Main.inventoryScale);
								int num160 = num156 + num157 * 5;
								Microsoft.Xna.Framework.Color white31 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
								if (Main.mouseX >= num158 && (float)Main.mouseX <= (float)num158 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num159 && (float)Main.mouseY <= (float)num159 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										if (Main.mouseItem.type == 0)
										{
											if ((Main.player[Main.myPlayer].selectedItem != num160 || Main.player[Main.myPlayer].itemAnimation <= 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[num160].value))
											{
												if (this.shop[Main.npcShop].item[num160].buyOnce)
												{
													int prefix = (int)this.shop[Main.npcShop].item[num160].prefix;
													Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num160].name);
													Main.mouseItem.Prefix(prefix);
												}
												else
												{
													Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num160].name);
													Main.mouseItem.Prefix(-1);
												}
												Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
												Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
												ItemText.NewText(Main.mouseItem, Main.mouseItem.stack);
												if (this.shop[Main.npcShop].item[num160].buyOnce)
												{
													this.shop[Main.npcShop].item[num160].stack--;
													if (this.shop[Main.npcShop].item[num160].stack <= 0)
													{
														this.shop[Main.npcShop].item[num160].SetDefaults(0, false);
													}
												}
												Main.PlaySound(18, -1, -1, 1);
											}
										}
										else if (this.shop[Main.npcShop].item[num160].type == 0)
										{
											if (Main.player[Main.myPlayer].SellItem(Main.mouseItem.value, Main.mouseItem.stack))
											{
												this.shop[Main.npcShop].AddShop(Main.mouseItem);
												Main.mouseItem.stack = 0;
												Main.mouseItem.type = 0;
												Main.PlaySound(18, -1, -1, 1);
											}
											else if (Main.mouseItem.value == 0)
											{
												this.shop[Main.npcShop].AddShop(Main.mouseItem);
												Main.mouseItem.stack = 0;
												Main.mouseItem.type = 0;
												Main.PlaySound(7, -1, -1, 1);
											}
										}
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(this.shop[Main.npcShop].item[num160]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[num160].value))
									{
										Main.PlaySound(18, -1, -1, 1);
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num160].name);
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
										if (this.shop[Main.npcShop].item[num160].buyOnce)
										{
											this.shop[Main.npcShop].item[num160].stack--;
											if (this.shop[Main.npcShop].item[num160].stack <= 0)
											{
												this.shop[Main.npcShop].item[num160].SetDefaults(0, false);
											}
										}
									}
									text45 = this.shop[Main.npcShop].item[num160].CName;
									Main.toolTip = (Item)this.shop[Main.npcShop].item[num160].Clone();
									Main.toolTip.buy = true;
									if (this.shop[Main.npcShop].item[num160].stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											this.shop[Main.npcShop].item[num160].stack,
											")"
										});
									}
								}
								SpriteBatch spriteBatch108 = this.spriteBatch;
								Texture2D texture49 = Main.inventoryBack6Texture;
								Vector2 position108 = new Vector2((float)num158, (float)num159);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle49 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color89 = color6;
								float rotation108 = 0f;
								origin = default(Vector2);
								spriteBatch108.Draw(texture49, position108, sourceRectangle49, color89, rotation108, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								white31 = Microsoft.Xna.Framework.Color.White;
								if (this.shop[Main.npcShop].item[num160].type > 0 && this.shop[Main.npcShop].item[num160].stack > 0)
								{
									float num161 = 1f;
									if (Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width > 32 || Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height > 32)
									{
										if (Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width > Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height)
										{
											num161 = 32f / (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width;
										}
										else
										{
											num161 = 32f / (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height;
										}
									}
									num161 *= Main.inventoryScale;
									SpriteBatch spriteBatch109 = this.spriteBatch;
									Texture2D texture50 = Main.itemTexture[this.shop[Main.npcShop].item[num160].type];
									Vector2 position109 = new Vector2((float)num158 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width * 0.5f * num161, (float)num159 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height * 0.5f * num161);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle50 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height));
									Microsoft.Xna.Framework.Color alpha11 = this.shop[Main.npcShop].item[num160].GetAlpha(white31);
									float rotation109 = 0f;
									origin = default(Vector2);
									spriteBatch109.Draw(texture50, position109, sourceRectangle50, alpha11, rotation109, origin, num161, SpriteEffects.None, 0f);
									Microsoft.Xna.Framework.Color color90 = this.shop[Main.npcShop].item[num160].color;
									if (color90 != default(Microsoft.Xna.Framework.Color))
									{
										SpriteBatch spriteBatch110 = this.spriteBatch;
										Texture2D texture51 = Main.itemTexture[this.shop[Main.npcShop].item[num160].type];
										Vector2 position110 = new Vector2((float)num158 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width * 0.5f * num161, (float)num159 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height * 0.5f * num161);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle51 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[num160].type].Height));
										Microsoft.Xna.Framework.Color color91 = this.shop[Main.npcShop].item[num160].GetColor(white31);
										float rotation110 = 0f;
										origin = default(Vector2);
										spriteBatch110.Draw(texture51, position110, sourceRectangle51, color91, rotation110, origin, num161, SpriteEffects.None, 0f);
									}
									if (this.shop[Main.npcShop].item[num160].stack > 1)
									{
										SpriteBatch spriteBatch111 = this.spriteBatch;
										SpriteFontX spriteFont60 = Main.fontItemStack;
										string text81 = string.Concat(this.shop[Main.npcShop].item[num160].stack);
										Vector2 position111 = new Vector2((float)num158 + 10f * Main.inventoryScale, (float)num159 + 26f * Main.inventoryScale);
										Microsoft.Xna.Framework.Color color92 = white31;
										float rotation111 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont60, text81, position111, color92, rotation111, origin, num161, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (Main.player[Main.myPlayer].chest > -1 && Main.tile[Main.player[Main.myPlayer].chestX, Main.player[Main.myPlayer].chestY].type != 21)
					{
						Main.player[Main.myPlayer].chest = -1;
					}
					if (Main.player[Main.myPlayer].chest != -1)
					{
						Main.inventoryScale = 0.75f;
						if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num162 = 0; num162 < 3; num162++)
						{
							int num163 = 286;
							int num164 = 250;
							float num165 = this.chestLootScale;
							string text82 = "全部取出";
							if (num162 == 1)
							{
								num164 += 26;
								num165 = this.chestDepositScale;
								text82 = "全部存入";
							}
							else if (num162 == 2)
							{
								num164 += 52;
								num165 = this.chestStackScale;
								text82 = "快速整理";
							}
							Vector2 vector7 = Main.fontMouseText.MeasureString(text82) / 2f;
							Microsoft.Xna.Framework.Color color93 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.mouseTextColor * num165)), (int)((byte)((float)Main.mouseTextColor * num165)), (int)((byte)((float)Main.mouseTextColor * num165)), (int)((byte)((float)Main.mouseTextColor * num165)));
							num163 += (int)(vector7.X * num165);
							this.DStoDSX(Main.fontMouseText, text82, new Vector2((float)num163, (float)num164), color93, 0f, vector7, num165, SpriteEffects.None, 0f);
							vector7 *= num165;
							if ((float)Main.mouseX > (float)num163 - vector7.X && (float)Main.mouseX < (float)num163 + vector7.X && (float)Main.mouseY > (float)num164 - vector7.Y && (float)Main.mouseY < (float)num164 + vector7.Y)
							{
								if (num162 == 0)
								{
									if (!this.chestLootHover)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.chestLootHover = true;
								}
								else if (num162 == 1)
								{
									if (!this.chestDepositHover)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.chestDepositHover = true;
								}
								else
								{
									if (!this.chestStackHover)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.chestStackHover = true;
								}
								Main.player[Main.myPlayer].mouseInterface = true;
								num165 += 0.05f;
								if (Main.mouseLeft && Main.mouseLeftRelease)
								{
									if (num162 == 0)
									{
										if (Main.player[Main.myPlayer].chest > -1)
										{
											for (int num166 = 0; num166 < 20; num166++)
											{
												if (Main.chest[Main.player[Main.myPlayer].chest].item[num166].type > 0)
												{
													Main.chest[Main.player[Main.myPlayer].chest].item[num166] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.chest[Main.player[Main.myPlayer].chest].item[num166]);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num166, 0f, 0f, 0);
													}
												}
											}
										}
										else if (Main.player[Main.myPlayer].chest == -3)
										{
											for (int num167 = 0; num167 < 20; num167++)
											{
												if (Main.player[Main.myPlayer].bank2[num167].type > 0)
												{
													Main.player[Main.myPlayer].bank2[num167] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank2[num167]);
												}
											}
										}
										else
										{
											for (int num168 = 0; num168 < 20; num168++)
											{
												if (Main.player[Main.myPlayer].bank[num168].type > 0)
												{
													Main.player[Main.myPlayer].bank[num168] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank[num168]);
												}
											}
										}
									}
									else if (num162 == 1)
									{
										for (int num169 = 40; num169 >= 10; num169--)
										{
											if (Main.player[Main.myPlayer].inventory[num169].stack > 0 && Main.player[Main.myPlayer].inventory[num169].type > 0)
											{
												if (Main.player[Main.myPlayer].inventory[num169].maxStack > 1)
												{
													for (int num170 = 0; num170 < 20; num170++)
													{
														if (Main.player[Main.myPlayer].chest > -1)
														{
															if (Main.chest[Main.player[Main.myPlayer].chest].item[num170].stack < Main.chest[Main.player[Main.myPlayer].chest].item[num170].maxStack && Main.player[Main.myPlayer].inventory[num169].IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num170]))
															{
																int num171 = Main.player[Main.myPlayer].inventory[num169].stack;
																if (Main.player[Main.myPlayer].inventory[num169].stack + Main.chest[Main.player[Main.myPlayer].chest].item[num170].stack > Main.chest[Main.player[Main.myPlayer].chest].item[num170].maxStack)
																{
																	num171 = Main.chest[Main.player[Main.myPlayer].chest].item[num170].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num170].stack;
																}
																Main.player[Main.myPlayer].inventory[num169].stack -= num171;
																Main.chest[Main.player[Main.myPlayer].chest].item[num170].stack += num171;
																Main.ChestCoins();
																Main.PlaySound(7, -1, -1, 1);
																if (Main.player[Main.myPlayer].inventory[num169].stack <= 0)
																{
																	Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num170, 0f, 0f, 0);
																		break;
																	}
																	break;
																}
																else
																{
																	if (Main.chest[Main.player[Main.myPlayer].chest].item[num170].type == 0)
																	{
																		Main.chest[Main.player[Main.myPlayer].chest].item[num170] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																		Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																	}
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num170, 0f, 0f, 0);
																	}
																}
															}
														}
														else if (Main.player[Main.myPlayer].chest == -3)
														{
															if (Main.player[Main.myPlayer].bank2[num170].stack < Main.player[Main.myPlayer].bank2[num170].maxStack && Main.player[Main.myPlayer].inventory[num169].IsTheSameAs(Main.player[Main.myPlayer].bank2[num170]))
															{
																int num172 = Main.player[Main.myPlayer].inventory[num169].stack;
																if (Main.player[Main.myPlayer].inventory[num169].stack + Main.player[Main.myPlayer].bank2[num170].stack > Main.player[Main.myPlayer].bank2[num170].maxStack)
																{
																	num172 = Main.player[Main.myPlayer].bank2[num170].maxStack - Main.player[Main.myPlayer].bank2[num170].stack;
																}
																Main.player[Main.myPlayer].inventory[num169].stack -= num172;
																Main.player[Main.myPlayer].bank2[num170].stack += num172;
																Main.PlaySound(7, -1, -1, 1);
																Main.BankCoins();
																if (Main.player[Main.myPlayer].inventory[num169].stack <= 0)
																{
																	Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																	break;
																}
																if (Main.player[Main.myPlayer].bank2[num170].type == 0)
																{
																	Main.player[Main.myPlayer].bank2[num170] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																	Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																}
															}
														}
														else if (Main.player[Main.myPlayer].bank[num170].stack < Main.player[Main.myPlayer].bank[num170].maxStack && Main.player[Main.myPlayer].inventory[num169].IsTheSameAs(Main.player[Main.myPlayer].bank[num170]))
														{
															int num173 = Main.player[Main.myPlayer].inventory[num169].stack;
															if (Main.player[Main.myPlayer].inventory[num169].stack + Main.player[Main.myPlayer].bank[num170].stack > Main.player[Main.myPlayer].bank[num170].maxStack)
															{
																num173 = Main.player[Main.myPlayer].bank[num170].maxStack - Main.player[Main.myPlayer].bank[num170].stack;
															}
															Main.player[Main.myPlayer].inventory[num169].stack -= num173;
															Main.player[Main.myPlayer].bank[num170].stack += num173;
															Main.PlaySound(7, -1, -1, 1);
															Main.BankCoins();
															if (Main.player[Main.myPlayer].inventory[num169].stack <= 0)
															{
																Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																break;
															}
															if (Main.player[Main.myPlayer].bank[num170].type == 0)
															{
																Main.player[Main.myPlayer].bank[num170] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
															}
														}
													}
												}
												if (Main.player[Main.myPlayer].inventory[num169].stack > 0)
												{
													if (Main.player[Main.myPlayer].chest > -1)
													{
														int num174 = 0;
														while (num174 < 20)
														{
															if (Main.chest[Main.player[Main.myPlayer].chest].item[num174].stack == 0)
															{
																Main.PlaySound(7, -1, -1, 1);
																Main.chest[Main.player[Main.myPlayer].chest].item[num174] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num174, 0f, 0f, 0);
																	break;
																}
																break;
															}
															else
															{
																num174++;
															}
														}
													}
													else if (Main.player[Main.myPlayer].chest == -3)
													{
														for (int num175 = 0; num175 < 20; num175++)
														{
															if (Main.player[Main.myPlayer].bank2[num175].stack == 0)
															{
																Main.PlaySound(7, -1, -1, 1);
																Main.player[Main.myPlayer].bank2[num175] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																break;
															}
														}
													}
													else
													{
														for (int num176 = 0; num176 < 20; num176++)
														{
															if (Main.player[Main.myPlayer].bank[num176].stack == 0)
															{
																Main.PlaySound(7, -1, -1, 1);
																Main.player[Main.myPlayer].bank[num176] = (Item)Main.player[Main.myPlayer].inventory[num169].Clone();
																Main.player[Main.myPlayer].inventory[num169].SetDefaults(0, false);
																break;
															}
														}
													}
												}
											}
										}
									}
									else if (Main.player[Main.myPlayer].chest > -1)
									{
										for (int num177 = 0; num177 < 20; num177++)
										{
											if (Main.chest[Main.player[Main.myPlayer].chest].item[num177].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[num177].stack < Main.chest[Main.player[Main.myPlayer].chest].item[num177].maxStack)
											{
												for (int num178 = 0; num178 < 48; num178++)
												{
													if (Main.chest[Main.player[Main.myPlayer].chest].item[num177].IsTheSameAs(Main.player[Main.myPlayer].inventory[num178]))
													{
														int num179 = Main.player[Main.myPlayer].inventory[num178].stack;
														if (Main.chest[Main.player[Main.myPlayer].chest].item[num177].stack + num179 > Main.chest[Main.player[Main.myPlayer].chest].item[num177].maxStack)
														{
															num179 = Main.chest[Main.player[Main.myPlayer].chest].item[num177].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num177].stack;
														}
														Main.PlaySound(7, -1, -1, 1);
														Main.chest[Main.player[Main.myPlayer].chest].item[num177].stack += num179;
														Main.player[Main.myPlayer].inventory[num178].stack -= num179;
														Main.ChestCoins();
														if (Main.player[Main.myPlayer].inventory[num178].stack == 0)
														{
															Main.player[Main.myPlayer].inventory[num178].SetDefaults(0, false);
														}
														else if (Main.chest[Main.player[Main.myPlayer].chest].item[num177].type == 0)
														{
															Main.chest[Main.player[Main.myPlayer].chest].item[num177] = (Item)Main.player[Main.myPlayer].inventory[num178].Clone();
															Main.player[Main.myPlayer].inventory[num178].SetDefaults(0, false);
														}
														if (Main.netMode == 1)
														{
															NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num177, 0f, 0f, 0);
														}
													}
												}
											}
										}
									}
									else if (Main.player[Main.myPlayer].chest == -3)
									{
										for (int num180 = 0; num180 < 20; num180++)
										{
											if (Main.player[Main.myPlayer].bank2[num180].type > 0 && Main.player[Main.myPlayer].bank2[num180].stack < Main.player[Main.myPlayer].bank2[num180].maxStack)
											{
												for (int num181 = 0; num181 < 48; num181++)
												{
													if (Main.player[Main.myPlayer].bank2[num180].IsTheSameAs(Main.player[Main.myPlayer].inventory[num181]))
													{
														int num182 = Main.player[Main.myPlayer].inventory[num181].stack;
														if (Main.player[Main.myPlayer].bank2[num180].stack + num182 > Main.player[Main.myPlayer].bank2[num180].maxStack)
														{
															num182 = Main.player[Main.myPlayer].bank2[num180].maxStack - Main.player[Main.myPlayer].bank2[num180].stack;
														}
														Main.PlaySound(7, -1, -1, 1);
														Main.player[Main.myPlayer].bank2[num180].stack += num182;
														Main.player[Main.myPlayer].inventory[num181].stack -= num182;
														Main.BankCoins();
														if (Main.player[Main.myPlayer].inventory[num181].stack == 0)
														{
															Main.player[Main.myPlayer].inventory[num181].SetDefaults(0, false);
														}
														else if (Main.player[Main.myPlayer].bank2[num180].type == 0)
														{
															Main.player[Main.myPlayer].bank2[num180] = (Item)Main.player[Main.myPlayer].inventory[num181].Clone();
															Main.player[Main.myPlayer].inventory[num181].SetDefaults(0, false);
														}
													}
												}
											}
										}
									}
									else
									{
										for (int num183 = 0; num183 < 20; num183++)
										{
											if (Main.player[Main.myPlayer].bank[num183].type > 0 && Main.player[Main.myPlayer].bank[num183].stack < Main.player[Main.myPlayer].bank[num183].maxStack)
											{
												for (int num184 = 0; num184 < 48; num184++)
												{
													if (Main.player[Main.myPlayer].bank[num183].IsTheSameAs(Main.player[Main.myPlayer].inventory[num184]))
													{
														int num185 = Main.player[Main.myPlayer].inventory[num184].stack;
														if (Main.player[Main.myPlayer].bank[num183].stack + num185 > Main.player[Main.myPlayer].bank[num183].maxStack)
														{
															num185 = Main.player[Main.myPlayer].bank[num183].maxStack - Main.player[Main.myPlayer].bank[num183].stack;
														}
														Main.PlaySound(7, -1, -1, 1);
														Main.player[Main.myPlayer].bank[num183].stack += num185;
														Main.player[Main.myPlayer].inventory[num184].stack -= num185;
														Main.BankCoins();
														if (Main.player[Main.myPlayer].inventory[num184].stack == 0)
														{
															Main.player[Main.myPlayer].inventory[num184].SetDefaults(0, false);
														}
														else if (Main.player[Main.myPlayer].bank[num183].type == 0)
														{
															Main.player[Main.myPlayer].bank[num183] = (Item)Main.player[Main.myPlayer].inventory[num184].Clone();
															Main.player[Main.myPlayer].inventory[num184].SetDefaults(0, false);
														}
													}
												}
											}
										}
									}
									Recipe.FindRecipes();
								}
							}
							else
							{
								num165 -= 0.05f;
								if (num162 == 0)
								{
									this.chestLootHover = false;
								}
								else if (num162 == 1)
								{
									this.chestDepositHover = false;
								}
								else
								{
									this.chestStackHover = false;
								}
							}
							if ((double)num165 < 0.75)
							{
								num165 = 0.75f;
							}
							if (num165 > 1f)
							{
								num165 = 1f;
							}
							if (num162 == 0)
							{
								this.chestLootScale = num165;
							}
							else if (num162 == 1)
							{
								this.chestDepositScale = num165;
							}
							else
							{
								this.chestStackScale = num165;
							}
						}
					}
					else
					{
						this.chestLootScale = 0.75f;
						this.chestDepositScale = 0.75f;
						this.chestStackScale = 0.75f;
						this.chestLootHover = false;
						this.chestDepositHover = false;
						this.chestStackHover = false;
					}
					if (Main.player[Main.myPlayer].chest > -1)
					{
						SpriteBatch spriteBatch112 = this.spriteBatch;
						SpriteFontX spriteFont61 = Main.fontMouseText;
						string text83 = Main.chestText;
						Vector2 position112 = new Vector2(284f, 210f);
						Microsoft.Xna.Framework.Color color94 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation112 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont61, text83, position112, color94, rotation112, origin, 1f, SpriteEffects.None, 0f);
						Main.inventoryScale = 0.75f;
						if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num186 = 0; num186 < 5; num186++)
						{
							for (int num187 = 0; num187 < 4; num187++)
							{
								int num188 = (int)(73f + (float)(num186 * 56) * Main.inventoryScale);
								int num189 = (int)(210f + (float)(num187 * 56) * Main.inventoryScale);
								int num190 = num186 + num187 * 5;
								Microsoft.Xna.Framework.Color white32 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
								if (Main.mouseX >= num188 && (float)Main.mouseX <= (float)num188 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num189 && (float)Main.mouseY <= (float)num189 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										if (Main.player[Main.myPlayer].selectedItem != num190 || Main.player[Main.myPlayer].itemAnimation <= 0)
										{
											Item item9 = Main.mouseItem;
											Main.mouseItem = Main.chest[Main.player[Main.myPlayer].chest].item[num190];
											Main.chest[Main.player[Main.myPlayer].chest].item[num190] = item9;
											if (Main.chest[Main.player[Main.myPlayer].chest].item[num190].type == 0 || Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack < 1)
											{
												Main.chest[Main.player[Main.myPlayer].chest].item[num190] = new Item();
											}
											if (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num190]) && Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack != Main.chest[Main.player[Main.myPlayer].chest].item[num190].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
											{
												if (Main.mouseItem.stack + Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack <= Main.mouseItem.maxStack)
												{
													Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack += Main.mouseItem.stack;
													Main.mouseItem.stack = 0;
												}
												else
												{
													int num191 = Main.mouseItem.maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack;
													Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack += num191;
													Main.mouseItem.stack -= num191;
												}
											}
											if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
											{
												Main.mouseItem = new Item();
											}
											if (Main.mouseItem.type > 0 || Main.chest[Main.player[Main.myPlayer].chest].item[num190].type > 0)
											{
												Recipe.FindRecipes();
												Main.PlaySound(7, -1, -1, 1);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num190, 0f, 0f, 0);
											}
										}
									}
									else if (Main.mouseRight && Main.mouseRightRelease && Main.chest[Main.player[Main.myPlayer].chest].item[num190].maxStack == 1)
									{
										Main.chest[Main.player[Main.myPlayer].chest].item[num190] = Main.armorSwap(Main.chest[Main.player[Main.myPlayer].chest].item[num190]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num190, 0f, 0f, 0);
										}
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && Main.chest[Main.player[Main.myPlayer].chest].item[num190].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num190]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.chest[Main.player[Main.myPlayer].chest].item[num190].Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack--;
										if (Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack <= 0)
										{
											Main.chest[Main.player[Main.myPlayer].chest].item[num190] = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num190, 0f, 0f, 0);
										}
									}
									text45 = Main.chest[Main.player[Main.myPlayer].chest].item[num190].CName;
									Main.toolTip = (Item)Main.chest[Main.player[Main.myPlayer].chest].item[num190].Clone();
									if (Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack,
											")"
										});
									}
								}
								SpriteBatch spriteBatch113 = this.spriteBatch;
								Texture2D texture52 = Main.inventoryBack5Texture;
								Vector2 position113 = new Vector2((float)num188, (float)num189);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle52 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color95 = color6;
								float rotation113 = 0f;
								origin = default(Vector2);
								spriteBatch113.Draw(texture52, position113, sourceRectangle52, color95, rotation113, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								white32 = Microsoft.Xna.Framework.Color.White;
								if (Main.chest[Main.player[Main.myPlayer].chest].item[num190].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack > 0)
								{
									float num192 = 1f;
									if (Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width > 32 || Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height > 32)
									{
										if (Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width > Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height)
										{
											num192 = 32f / (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width;
										}
										else
										{
											num192 = 32f / (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height;
										}
									}
									num192 *= Main.inventoryScale;
									SpriteBatch spriteBatch114 = this.spriteBatch;
									Texture2D texture53 = Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type];
									Vector2 position114 = new Vector2((float)num188 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width * 0.5f * num192, (float)num189 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height * 0.5f * num192);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle53 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height));
									Microsoft.Xna.Framework.Color alpha12 = Main.chest[Main.player[Main.myPlayer].chest].item[num190].GetAlpha(white32);
									float rotation114 = 0f;
									origin = default(Vector2);
									spriteBatch114.Draw(texture53, position114, sourceRectangle53, alpha12, rotation114, origin, num192, SpriteEffects.None, 0f);
									Microsoft.Xna.Framework.Color color96 = Main.chest[Main.player[Main.myPlayer].chest].item[num190].color;
									if (color96 != default(Microsoft.Xna.Framework.Color))
									{
										SpriteBatch spriteBatch115 = this.spriteBatch;
										Texture2D texture54 = Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type];
										Vector2 position115 = new Vector2((float)num188 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width * 0.5f * num192, (float)num189 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height * 0.5f * num192);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle54 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num190].type].Height));
										Microsoft.Xna.Framework.Color color97 = Main.chest[Main.player[Main.myPlayer].chest].item[num190].GetColor(white32);
										float rotation115 = 0f;
										origin = default(Vector2);
										spriteBatch115.Draw(texture54, position115, sourceRectangle54, color97, rotation115, origin, num192, SpriteEffects.None, 0f);
									}
									if (Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack > 1)
									{
										SpriteBatch spriteBatch116 = this.spriteBatch;
										SpriteFontX spriteFont62 = Main.fontItemStack;
										string text84 = string.Concat(Main.chest[Main.player[Main.myPlayer].chest].item[num190].stack);
										Vector2 position116 = new Vector2((float)num188 + 10f * Main.inventoryScale, (float)num189 + 26f * Main.inventoryScale);
										Microsoft.Xna.Framework.Color color98 = white32;
										float rotation116 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont62, text84, position116, color98, rotation116, origin, num192, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (Main.player[Main.myPlayer].chest == -2)
					{
						SpriteBatch spriteBatch117 = this.spriteBatch;
						SpriteFontX spriteFont63 = Main.fontMouseText;
						string text85 = "小猪储蓄罐";
						Vector2 position117 = new Vector2(284f, 210f);
						Microsoft.Xna.Framework.Color color99 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation117 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont63, text85, position117, color99, rotation117, origin, 1f, SpriteEffects.None, 0f);
						Main.inventoryScale = 0.75f;
						if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num193 = 0; num193 < 5; num193++)
						{
							for (int num194 = 0; num194 < 4; num194++)
							{
								int num195 = (int)(73f + (float)(num193 * 56) * Main.inventoryScale);
								int num196 = (int)(210f + (float)(num194 * 56) * Main.inventoryScale);
								int num197 = num193 + num194 * 5;
								Microsoft.Xna.Framework.Color white33 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
								if (Main.mouseX >= num195 && (float)Main.mouseX <= (float)num195 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num196 && (float)Main.mouseY <= (float)num196 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										if (Main.player[Main.myPlayer].selectedItem != num197 || Main.player[Main.myPlayer].itemAnimation <= 0)
										{
											Item item10 = Main.mouseItem;
											Main.mouseItem = Main.player[Main.myPlayer].bank[num197];
											Main.player[Main.myPlayer].bank[num197] = item10;
											if (Main.player[Main.myPlayer].bank[num197].type == 0 || Main.player[Main.myPlayer].bank[num197].stack < 1)
											{
												Main.player[Main.myPlayer].bank[num197] = new Item();
											}
											if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[num197]) && Main.player[Main.myPlayer].bank[num197].stack != Main.player[Main.myPlayer].bank[num197].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
											{
												if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank[num197].stack <= Main.mouseItem.maxStack)
												{
													Main.player[Main.myPlayer].bank[num197].stack += Main.mouseItem.stack;
													Main.mouseItem.stack = 0;
												}
												else
												{
													int num198 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank[num197].stack;
													Main.player[Main.myPlayer].bank[num197].stack += num198;
													Main.mouseItem.stack -= num198;
												}
											}
											if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
											{
												Main.mouseItem = new Item();
											}
											if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank[num197].type > 0)
											{
												Recipe.FindRecipes();
												Main.PlaySound(7, -1, -1, 1);
											}
										}
									}
									else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank[num197].maxStack == 1)
									{
										Main.player[Main.myPlayer].bank[num197] = Main.armorSwap(Main.player[Main.myPlayer].bank[num197]);
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank[num197].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[num197]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.player[Main.myPlayer].bank[num197].Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.player[Main.myPlayer].bank[num197].stack--;
										if (Main.player[Main.myPlayer].bank[num197].stack <= 0)
										{
											Main.player[Main.myPlayer].bank[num197] = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
									text45 = Main.player[Main.myPlayer].bank[num197].CName;
									Main.toolTip = (Item)Main.player[Main.myPlayer].bank[num197].Clone();
									if (Main.player[Main.myPlayer].bank[num197].stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											Main.player[Main.myPlayer].bank[num197].stack,
											")"
										});
									}
								}
								SpriteBatch spriteBatch118 = this.spriteBatch;
								Texture2D texture55 = Main.inventoryBack2Texture;
								Vector2 position118 = new Vector2((float)num195, (float)num196);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle55 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color100 = color6;
								float rotation118 = 0f;
								origin = default(Vector2);
								spriteBatch118.Draw(texture55, position118, sourceRectangle55, color100, rotation118, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								white33 = Microsoft.Xna.Framework.Color.White;
								if (Main.player[Main.myPlayer].bank[num197].type > 0 && Main.player[Main.myPlayer].bank[num197].stack > 0)
								{
									float num199 = 1f;
									if (Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height > 32)
									{
										if (Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width > Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height)
										{
											num199 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width;
										}
										else
										{
											num199 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height;
										}
									}
									num199 *= Main.inventoryScale;
									SpriteBatch spriteBatch119 = this.spriteBatch;
									Texture2D texture56 = Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type];
									Vector2 position119 = new Vector2((float)num195 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width * 0.5f * num199, (float)num196 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height * 0.5f * num199);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle56 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height));
									Microsoft.Xna.Framework.Color alpha13 = Main.player[Main.myPlayer].bank[num197].GetAlpha(white33);
									float rotation119 = 0f;
									origin = default(Vector2);
									spriteBatch119.Draw(texture56, position119, sourceRectangle56, alpha13, rotation119, origin, num199, SpriteEffects.None, 0f);
									Microsoft.Xna.Framework.Color color101 = Main.player[Main.myPlayer].bank[num197].color;
									if (color101 != default(Microsoft.Xna.Framework.Color))
									{
										SpriteBatch spriteBatch120 = this.spriteBatch;
										Texture2D texture57 = Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type];
										Vector2 position120 = new Vector2((float)num195 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width * 0.5f * num199, (float)num196 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height * 0.5f * num199);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle57 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[num197].type].Height));
										Microsoft.Xna.Framework.Color color102 = Main.player[Main.myPlayer].bank[num197].GetColor(white33);
										float rotation120 = 0f;
										origin = default(Vector2);
										spriteBatch120.Draw(texture57, position120, sourceRectangle57, color102, rotation120, origin, num199, SpriteEffects.None, 0f);
									}
									if (Main.player[Main.myPlayer].bank[num197].stack > 1)
									{
										SpriteBatch spriteBatch121 = this.spriteBatch;
										SpriteFontX spriteFont64 = Main.fontItemStack;
										string text86 = string.Concat(Main.player[Main.myPlayer].bank[num197].stack);
										Vector2 position121 = new Vector2((float)num195 + 10f * Main.inventoryScale, (float)num196 + 26f * Main.inventoryScale);
										Microsoft.Xna.Framework.Color color103 = white33;
										float rotation121 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont64, text86, position121, color103, rotation121, origin, num199, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (Main.player[Main.myPlayer].chest == -3)
					{
						SpriteBatch spriteBatch122 = this.spriteBatch;
						SpriteFontX spriteFont65 = Main.fontMouseText;
						string text87 = "保险箱";
						Vector2 position122 = new Vector2(284f, 210f);
						Microsoft.Xna.Framework.Color color104 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float rotation122 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont65, text87, position122, color104, rotation122, origin, 1f, SpriteEffects.None, 0f);
						Main.inventoryScale = 0.75f;
						if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
						}
						for (int num200 = 0; num200 < 5; num200++)
						{
							for (int num201 = 0; num201 < 4; num201++)
							{
								int num202 = (int)(73f + (float)(num200 * 56) * Main.inventoryScale);
								int num203 = (int)(210f + (float)(num201 * 56) * Main.inventoryScale);
								int num204 = num200 + num201 * 5;
								Microsoft.Xna.Framework.Color white34 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
								if (Main.mouseX >= num202 && (float)Main.mouseX <= (float)num202 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num203 && (float)Main.mouseY <= (float)num203 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
								{
									Main.player[Main.myPlayer].mouseInterface = true;
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										if (Main.player[Main.myPlayer].selectedItem != num204 || Main.player[Main.myPlayer].itemAnimation <= 0)
										{
											Item item11 = Main.mouseItem;
											Main.mouseItem = Main.player[Main.myPlayer].bank2[num204];
											Main.player[Main.myPlayer].bank2[num204] = item11;
											if (Main.player[Main.myPlayer].bank2[num204].type == 0 || Main.player[Main.myPlayer].bank2[num204].stack < 1)
											{
												Main.player[Main.myPlayer].bank2[num204] = new Item();
											}
											if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[num204]) && Main.player[Main.myPlayer].bank2[num204].stack != Main.player[Main.myPlayer].bank2[num204].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
											{
												if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank2[num204].stack <= Main.mouseItem.maxStack)
												{
													Main.player[Main.myPlayer].bank2[num204].stack += Main.mouseItem.stack;
													Main.mouseItem.stack = 0;
												}
												else
												{
													int num205 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank2[num204].stack;
													Main.player[Main.myPlayer].bank2[num204].stack += num205;
													Main.mouseItem.stack -= num205;
												}
											}
											if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
											{
												Main.mouseItem = new Item();
											}
											if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank2[num204].type > 0)
											{
												Recipe.FindRecipes();
												Main.PlaySound(7, -1, -1, 1);
											}
										}
									}
									else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank2[num204].maxStack == 1)
									{
										Main.player[Main.myPlayer].bank2[num204] = Main.armorSwap(Main.player[Main.myPlayer].bank2[num204]);
									}
									else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank2[num204].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[num204]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.player[Main.myPlayer].bank2[num204].Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.player[Main.myPlayer].bank2[num204].stack--;
										if (Main.player[Main.myPlayer].bank2[num204].stack <= 0)
										{
											Main.player[Main.myPlayer].bank2[num204] = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
									text45 = Main.player[Main.myPlayer].bank2[num204].CName;
									Main.toolTip = (Item)Main.player[Main.myPlayer].bank2[num204].Clone();
									if (Main.player[Main.myPlayer].bank2[num204].stack > 1)
									{
										object obj = text45;
										text45 = string.Concat(new object[]
										{
											obj,
											" (",
											Main.player[Main.myPlayer].bank2[num204].stack,
											")"
										});
									}
								}
								SpriteBatch spriteBatch123 = this.spriteBatch;
								Texture2D texture58 = Main.inventoryBack2Texture;
								Vector2 position123 = new Vector2((float)num202, (float)num203);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle58 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Microsoft.Xna.Framework.Color color105 = color6;
								float rotation123 = 0f;
								origin = default(Vector2);
								spriteBatch123.Draw(texture58, position123, sourceRectangle58, color105, rotation123, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								white34 = Microsoft.Xna.Framework.Color.White;
								if (Main.player[Main.myPlayer].bank2[num204].type > 0 && Main.player[Main.myPlayer].bank2[num204].stack > 0)
								{
									float num206 = 1f;
									if (Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height > 32)
									{
										if (Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width > Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height)
										{
											num206 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width;
										}
										else
										{
											num206 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height;
										}
									}
									num206 *= Main.inventoryScale;
									SpriteBatch spriteBatch124 = this.spriteBatch;
									Texture2D texture59 = Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type];
									Vector2 position124 = new Vector2((float)num202 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width * 0.5f * num206, (float)num203 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height * 0.5f * num206);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle59 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height));
									Microsoft.Xna.Framework.Color alpha14 = Main.player[Main.myPlayer].bank2[num204].GetAlpha(white34);
									float rotation124 = 0f;
									origin = default(Vector2);
									spriteBatch124.Draw(texture59, position124, sourceRectangle59, alpha14, rotation124, origin, num206, SpriteEffects.None, 0f);
									Microsoft.Xna.Framework.Color color106 = Main.player[Main.myPlayer].bank2[num204].color;
									if (color106 != default(Microsoft.Xna.Framework.Color))
									{
										SpriteBatch spriteBatch125 = this.spriteBatch;
										Texture2D texture60 = Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type];
										Vector2 position125 = new Vector2((float)num202 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width * 0.5f * num206, (float)num203 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height * 0.5f * num206);
										Microsoft.Xna.Framework.Rectangle? sourceRectangle60 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[num204].type].Height));
										Microsoft.Xna.Framework.Color color107 = Main.player[Main.myPlayer].bank2[num204].GetColor(white34);
										float rotation125 = 0f;
										origin = default(Vector2);
										spriteBatch125.Draw(texture60, position125, sourceRectangle60, color107, rotation125, origin, num206, SpriteEffects.None, 0f);
									}
									if (Main.player[Main.myPlayer].bank2[num204].stack > 1)
									{
										SpriteBatch spriteBatch126 = this.spriteBatch;
										SpriteFontX spriteFont66 = Main.fontItemStack;
										string text88 = string.Concat(Main.player[Main.myPlayer].bank2[num204].stack);
										Vector2 position126 = new Vector2((float)num202 + 10f * Main.inventoryScale, (float)num203 + 26f * Main.inventoryScale);
										Microsoft.Xna.Framework.Color color108 = white34;
										float rotation126 = 0f;
										origin = default(Vector2);
										this.DStoDSX(spriteFont66, text88, position126, color108, rotation126, origin, num206, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
				}
				else if (Main.npcChatText == null || Main.npcChatText == "")
				{
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					for (int num207 = 0; num207 < 3; num207++)
					{
						string text89 = "";
						if (Main.player[Main.myPlayer].accCompass > 0 && !flag8)
						{
							int num208 = (int)((Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2)) * 2f / 16f - (float)Main.maxTilesX);
							if (num208 > 0)
							{
								text89 = "位置: " + num208 + " 英尺以东";
								if (num208 == 1)
								{
									text89 = "位置: " + num208 + " 英尺以东";
								}
							}
							else if (num208 < 0)
							{
								num208 *= -1;
								text89 = "位置: " + num208 + " 英尺以西";
								if (num208 == 1)
								{
									text89 = "位置: " + num208 + " 英尺以西";
								}
							}
							else
							{
								text89 = "位置: 中心";
							}
							flag8 = true;
						}
						else if (Main.player[Main.myPlayer].accDepthMeter > 0 && !flag7)
						{
							int num209 = (int)((double)((Main.player[Main.myPlayer].position.Y + (float)Main.player[Main.myPlayer].height) * 2f / 16f) - Main.worldSurface * 2.0);
							if (num209 > 0)
							{
								text89 = "深度: " + num209 + " 英尺以下";
								if (num209 == 1)
								{
									text89 = "深度: " + num209 + " 英尺以下";
								}
							}
							else if (num209 < 0)
							{
								num209 *= -1;
								text89 = "深度: " + num209 + " 英尺以上";
								if (num209 == 1)
								{
									text89 = "深度: " + num209 + " 英尺以上";
								}
							}
							else
							{
								text89 = "深度: 水平面";
							}
							flag7 = true;
						}
						else if (Main.player[Main.myPlayer].accWatch > 0 && !flag6)
						{
							string text90 = "AM";
							double num210 = Main.time;
							if (!Main.dayTime)
							{
								num210 += 54000.0;
							}
							num210 = num210 / 86400.0 * 24.0;
							double num211 = 7.5;
							num210 = num210 - num211 - 12.0;
							if (num210 < 0.0)
							{
								num210 += 24.0;
							}
							if (num210 >= 12.0)
							{
								text90 = "PM";
							}
							int num212 = (int)num210;
							double num213 = num210 - (double)num212;
							num213 = (double)((int)(num213 * 60.0));
							string text91 = string.Concat(num213);
							if (num213 < 10.0)
							{
								text91 = "0" + text91;
							}
							if (num212 > 12)
							{
								num212 -= 12;
							}
							if (num212 == 0)
							{
								num212 = 12;
							}
							if (Main.player[Main.myPlayer].accWatch == 1)
							{
								text91 = "00";
							}
							else if (Main.player[Main.myPlayer].accWatch == 2)
							{
								if (num213 < 30.0)
								{
									text91 = "00";
								}
								else
								{
									text91 = "30";
								}
							}
							text89 = string.Concat(new object[]
							{
								"时间: ",
								num212,
								":",
								text91,
								" ",
								text90
							});
							flag6 = true;
						}
						if (text89 != "")
						{
							for (int num214 = 0; num214 < 5; num214++)
							{
								int num215 = 0;
								int num216 = 0;
								Microsoft.Xna.Framework.Color black9 = Microsoft.Xna.Framework.Color.Black;
								if (num214 == 0)
								{
									num215 = -2;
								}
								if (num214 == 1)
								{
									num215 = 2;
								}
								if (num214 == 2)
								{
									num216 = -2;
								}
								if (num214 == 3)
								{
									num216 = 2;
								}
								if (num214 == 4)
								{
									black9 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								}
								SpriteBatch spriteBatch127 = this.spriteBatch;
								SpriteFontX spriteFont67 = Main.fontMouseText;
								string text92 = text89;
								Vector2 position127 = new Vector2((float)(22 + num215), (float)(110 + 22 * num207 + num216 + 48));
								Microsoft.Xna.Framework.Color color109 = black9;
								float rotation127 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont67, text92, position127, color109, rotation127, origin, 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
				if (Main.playerInventory || Main.player[Main.myPlayer].ghost)
				{
					string text93 = "保存并退出";
					if (Main.netMode != 0)
					{
						text93 = "断开连接";
					}
					Vector2 vector8 = Main.fontDeathText.MeasureString(text93);
					int num217 = Main.screenWidth - 110;
					int num218 = Main.screenHeight - 20;
					if (Main.mouseExit)
					{
						if (Main.exitScale < 1f)
						{
							Main.exitScale += 0.02f;
						}
					}
					else if ((double)Main.exitScale > 0.8)
					{
						Main.exitScale -= 0.02f;
					}
					for (int num219 = 0; num219 < 5; num219++)
					{
						int num220 = 0;
						int num221 = 0;
						Microsoft.Xna.Framework.Color color110 = Microsoft.Xna.Framework.Color.Black;
						if (num219 == 0)
						{
							num220 = -2;
						}
						if (num219 == 1)
						{
							num220 = 2;
						}
						if (num219 == 2)
						{
							num221 = -2;
						}
						if (num219 == 3)
						{
							num221 = 2;
						}
						if (num219 == 4)
						{
							color110 = Microsoft.Xna.Framework.Color.White;
						}
						this.DStoDSX(Main.fontDeathText, text93, new Vector2((float)(num217 + num220), (float)(num218 + num221)), color110, 0f, new Vector2(vector8.X / 2f, vector8.Y / 2f), Main.exitScale - 0.2f, SpriteEffects.None, 0f);
					}
					if ((float)Main.mouseX > (float)num217 - vector8.X / 2f && (float)Main.mouseX < (float)num217 + vector8.X / 2f && (float)Main.mouseY > (float)num218 - vector8.Y / 2f && (float)Main.mouseY < (float)num218 + vector8.Y / 2f - 10f)
					{
						if (!Main.mouseExit)
						{
							Main.PlaySound(12, -1, -1, 1);
						}
						Main.mouseExit = true;
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeftRelease && Main.mouseLeft)
						{
							Main.menuMode = 10;
							WorldGen.SaveAndQuit();
						}
					}
					else
					{
						Main.mouseExit = false;
					}
				}
				if (!Main.playerInventory && !Main.player[Main.myPlayer].ghost)
				{
					string text94 = "物品";
					if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != "" && Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != null)
					{
						text94 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].AffixName();
					}
					Vector2 vector9 = Main.fontMouseText.MeasureString(text94) / 2f;
					SpriteBatch spriteBatch128 = this.spriteBatch;
					SpriteFontX spriteFont68 = Main.fontMouseText;
					string text95 = text94;
					Vector2 position128 = new Vector2(236f - vector9.X, 0f);
					Microsoft.Xna.Framework.Color color111 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float rotation128 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont68, text95, position128, color111, rotation128, origin, 1f, SpriteEffects.None, 0f);
					int num222 = 20;
					for (int num223 = 0; num223 < 10; num223++)
					{
						if (num223 == Main.player[Main.myPlayer].selectedItem)
						{
							if (Main.hotbarScale[num223] < 1f)
							{
								Main.hotbarScale[num223] += 0.05f;
							}
						}
						else if ((double)Main.hotbarScale[num223] > 0.75)
						{
							Main.hotbarScale[num223] -= 0.05f;
						}
						float num224 = Main.hotbarScale[num223];
						int num225 = (int)(20f + 22f * (1f - num224));
						int a3 = (int)(75f + 150f * num224);
						Microsoft.Xna.Framework.Color color112 = new Microsoft.Xna.Framework.Color(255, 255, 255, a3);
						SpriteBatch spriteBatch129 = this.spriteBatch;
						Texture2D texture61 = Main.inventoryBackTexture;
						Vector2 position129 = new Vector2((float)num222, (float)num225);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle61 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Microsoft.Xna.Framework.Color color113 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
						float rotation129 = 0f;
						origin = default(Vector2);
						spriteBatch129.Draw(texture61, position129, sourceRectangle61, color113, rotation129, origin, num224, SpriteEffects.None, 0f);
						if (!Main.player[Main.myPlayer].hbLocked && Main.mouseX >= num222 && (float)Main.mouseX <= (float)num222 + (float)Main.inventoryBackTexture.Width * Main.hotbarScale[num223] && Main.mouseY >= num225 && (float)Main.mouseY <= (float)num225 + (float)Main.inventoryBackTexture.Height * Main.hotbarScale[num223] && !Main.player[Main.myPlayer].channel)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeft && !Main.player[Main.myPlayer].hbLocked)
							{
								Main.player[Main.myPlayer].changeItem = num223;
							}
							Main.player[Main.myPlayer].showItemIcon = false;
							text45 = Main.player[Main.myPlayer].inventory[num223].AffixName();
							if (Main.player[Main.myPlayer].inventory[num223].stack > 1)
							{
								object obj = text45;
								text45 = string.Concat(new object[]
								{
									obj,
									" (",
									Main.player[Main.myPlayer].inventory[num223].stack,
									")"
								});
							}
							rare = Main.player[Main.myPlayer].inventory[num223].rare;
						}
						if (Main.player[Main.myPlayer].inventory[num223].type > 0 && Main.player[Main.myPlayer].inventory[num223].stack > 0)
						{
							float num226 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height)
								{
									num226 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width;
								}
								else
								{
									num226 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height;
								}
							}
							num226 *= num224;
							SpriteBatch spriteBatch130 = this.spriteBatch;
							Texture2D texture62 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type];
							Vector2 position130 = new Vector2((float)num222 + 26f * num224 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width * 0.5f * num226, (float)num225 + 26f * num224 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height * 0.5f * num226);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle62 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height));
							Microsoft.Xna.Framework.Color alpha15 = Main.player[Main.myPlayer].inventory[num223].GetAlpha(color112);
							float rotation130 = 0f;
							origin = default(Vector2);
							spriteBatch130.Draw(texture62, position130, sourceRectangle62, alpha15, rotation130, origin, num226, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color color114 = Main.player[Main.myPlayer].inventory[num223].color;
							if (color114 != default(Microsoft.Xna.Framework.Color))
							{
								SpriteBatch spriteBatch131 = this.spriteBatch;
								Texture2D texture63 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type];
								Vector2 position131 = new Vector2((float)num222 + 26f * num224 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width * 0.5f * num226, (float)num225 + 26f * num224 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height * 0.5f * num226);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle63 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num223].type].Height));
								Microsoft.Xna.Framework.Color color115 = Main.player[Main.myPlayer].inventory[num223].GetColor(color112);
								float rotation131 = 0f;
								origin = default(Vector2);
								spriteBatch131.Draw(texture63, position131, sourceRectangle63, color115, rotation131, origin, num226, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].inventory[num223].stack > 1)
							{
								SpriteBatch spriteBatch132 = this.spriteBatch;
								SpriteFontX spriteFont69 = Main.fontItemStack;
								string text96 = string.Concat(Main.player[Main.myPlayer].inventory[num223].stack);
								Vector2 position132 = new Vector2((float)num222 + 10f * num224, (float)num225 + 26f * num224);
								Microsoft.Xna.Framework.Color color116 = color112;
								float rotation132 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont69, text96, position132, color116, rotation132, origin, num226, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].inventory[num223].useAmmo > 0)
							{
								int useAmmo = Main.player[Main.myPlayer].inventory[num223].useAmmo;
								int num227 = 0;
								for (int num228 = 0; num228 < 48; num228++)
								{
									if (Main.player[Main.myPlayer].inventory[num228].ammo == useAmmo)
									{
										num227 += Main.player[Main.myPlayer].inventory[num228].stack;
									}
								}
								SpriteBatch spriteBatch133 = this.spriteBatch;
								SpriteFontX spriteFont70 = Main.fontItemStack;
								string text97 = string.Concat(num227);
								Vector2 position133 = new Vector2((float)num222 + 8f * num224, (float)num225 + 30f * num224);
								Microsoft.Xna.Framework.Color color117 = color112;
								float rotation133 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont70, text97, position133, color117, rotation133, origin, num224 * 0.8f, SpriteEffects.None, 0f);
							}
							else if (Main.player[Main.myPlayer].inventory[num223].type == 509)
							{
								int num229 = 0;
								for (int num230 = 0; num230 < 48; num230++)
								{
									if (Main.player[Main.myPlayer].inventory[num230].type == 530)
									{
										num229 += Main.player[Main.myPlayer].inventory[num230].stack;
									}
								}
								SpriteBatch spriteBatch134 = this.spriteBatch;
								SpriteFontX spriteFont71 = Main.fontItemStack;
								string text98 = string.Concat(num229);
								Vector2 position134 = new Vector2((float)num222 + 8f * num224, (float)num225 + 30f * num224);
								Microsoft.Xna.Framework.Color color118 = color112;
								float rotation134 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont71, text98, position134, color118, rotation134, origin, num224 * 0.8f, SpriteEffects.None, 0f);
							}
							string text99 = string.Concat(num223 + 1);
							if (text99 == "10")
							{
								text99 = "0";
							}
							SpriteBatch spriteBatch135 = this.spriteBatch;
							SpriteFontX spriteFont72 = Main.fontItemStack;
							string text100 = text99;
							Vector2 position135 = new Vector2((float)num222 + 8f * Main.hotbarScale[num223], (float)num225 + 4f * Main.hotbarScale[num223]);
							Microsoft.Xna.Framework.Color color119 = new Microsoft.Xna.Framework.Color((int)(color112.R / 2), (int)(color112.G / 2), (int)(color112.B / 2), (int)(color112.A / 2));
							float rotation135 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont72, text100, position135, color119, rotation135, origin, num226, SpriteEffects.None, 0f);
							if (Main.player[Main.myPlayer].inventory[num223].potion)
							{
								Microsoft.Xna.Framework.Color alpha16 = Main.player[Main.myPlayer].inventory[num223].GetAlpha(color112);
								float num231 = (float)Main.player[Main.myPlayer].potionDelay / (float)Main.player[Main.myPlayer].potionDelayTime;
								float num232 = (float)alpha16.R * num231;
								float num233 = (float)alpha16.G * num231;
								float num234 = (float)alpha16.B * num231;
								float num235 = (float)alpha16.A * num231;
								alpha16 = new Microsoft.Xna.Framework.Color((int)((byte)num232), (int)((byte)num233), (int)((byte)num234), (int)((byte)num235));
								SpriteBatch spriteBatch136 = this.spriteBatch;
								Texture2D texture64 = Main.cdTexture;
								Vector2 position136 = new Vector2((float)num222 + 26f * Main.hotbarScale[num223] - (float)Main.cdTexture.Width * 0.5f * num226, (float)num225 + 26f * Main.hotbarScale[num223] - (float)Main.cdTexture.Height * 0.5f * num226);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle64 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cdTexture.Width, Main.cdTexture.Height));
								Microsoft.Xna.Framework.Color color120 = alpha16;
								float rotation136 = 0f;
								origin = default(Vector2);
								spriteBatch136.Draw(texture64, position136, sourceRectangle64, color120, rotation136, origin, num226, SpriteEffects.None, 0f);
							}
						}
						num222 += (int)((float)Main.inventoryBackTexture.Width * Main.hotbarScale[num223]) + 4;
					}
				}
				if (Main.mouseItem.stack <= 0)
				{
					Main.mouseItem.type = 0;
				}
				if (text45 != null && text45 != "" && Main.mouseItem.type == 0)
				{
					Main.player[Main.myPlayer].showItemIcon = false;
					this.MouseText(text45, rare, 0);
					flag = true;
				}
				if (Main.chatMode)
				{
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					string text101 = Main.chatText;
					if (this.textBlinkerState == 1)
					{
						text101 += "|";
					}
					SpriteBatch spriteBatch137 = this.spriteBatch;
					Texture2D texture65 = Main.textBackTexture;
					Vector2 position137 = new Vector2(78f, (float)(Main.screenHeight - 36));
					Microsoft.Xna.Framework.Rectangle? sourceRectangle65 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.textBackTexture.Width, Main.textBackTexture.Height));
					Microsoft.Xna.Framework.Color color121 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
					float rotation137 = 0f;
					origin = default(Vector2);
					spriteBatch137.Draw(texture65, position137, sourceRectangle65, color121, rotation137, origin, 1f, SpriteEffects.None, 0f);
					for (int num236 = 0; num236 < 5; num236++)
					{
						int num237 = 0;
						int num238 = 0;
						Microsoft.Xna.Framework.Color black10 = Microsoft.Xna.Framework.Color.Black;
						if (num236 == 0)
						{
							num237 = -2;
						}
						if (num236 == 1)
						{
							num237 = 2;
						}
						if (num236 == 2)
						{
							num238 = -2;
						}
						if (num236 == 3)
						{
							num238 = 2;
						}
						if (num236 == 4)
						{
							black10 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						}
						SpriteBatch spriteBatch138 = this.spriteBatch;
						SpriteFontX spriteFont73 = Main.fontMouseText;
						string text102 = text101;
						Vector2 position138 = new Vector2((float)(88 + num237), (float)(Main.screenHeight - 30 + num238));
						Microsoft.Xna.Framework.Color color122 = black10;
						float rotation138 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont73, text102, position138, color122, rotation138, origin, 1f, SpriteEffects.None, 0f);
					}
				}
				for (int num239 = 0; num239 < Main.numChatLines; num239++)
				{
					if (Main.chatMode || Main.chatLine[num239].showTime > 0)
					{
						float num240 = (float)Main.mouseTextColor / 255f;
						for (int num241 = 0; num241 < 5; num241++)
						{
							int num242 = 0;
							int num243 = 0;
							Microsoft.Xna.Framework.Color black11 = Microsoft.Xna.Framework.Color.Black;
							if (num241 == 0)
							{
								num242 = -2;
							}
							if (num241 == 1)
							{
								num242 = 2;
							}
							if (num241 == 2)
							{
								num243 = -2;
							}
							if (num241 == 3)
							{
								num243 = 2;
							}
							if (num241 == 4)
							{
								black11 = new Microsoft.Xna.Framework.Color((int)((byte)((float)Main.chatLine[num239].color.R * num240)), (int)((byte)((float)Main.chatLine[num239].color.G * num240)), (int)((byte)((float)Main.chatLine[num239].color.B * num240)), (int)Main.mouseTextColor);
							}
							SpriteBatch spriteBatch139 = this.spriteBatch;
							SpriteFontX spriteFont74 = Main.fontMouseText;
							string text103 = Main.chatLine[num239].text;
							Vector2 position139 = new Vector2((float)(88 + num242), (float)(Main.screenHeight - 30 + num243 - 28 - num239 * 21));
							Microsoft.Xna.Framework.Color color123 = black11;
							float rotation139 = 0f;
							origin = default(Vector2);
							this.DStoDSX(spriteFont74, text103, position139, color123, rotation139, origin, 1f, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.player[Main.myPlayer].dead)
				{
					string text104 = "你挂了...";
					SpriteBatch spriteBatch140 = this.spriteBatch;
					SpriteFontX spriteFont75 = Main.fontDeathText;
					string text105 = text104;
					Vector2 position140 = new Vector2((float)(Main.screenWidth / 2 - text104.Length * 10), (float)(Main.screenHeight / 2 - 20));
					Microsoft.Xna.Framework.Color deathAlpha = Main.player[Main.myPlayer].GetDeathAlpha(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
					float rotation140 = 0f;
					origin = default(Vector2);
					this.DStoDSX(spriteFont75, text105, position140, deathAlpha, rotation140, origin, 1f, SpriteEffects.None, 0f);
				}
				SpriteBatch spriteBatch141 = this.spriteBatch;
				Texture2D texture66 = Main.cursorTexture;
				Vector2 position141 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
				Microsoft.Xna.Framework.Rectangle? sourceRectangle66 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
				Microsoft.Xna.Framework.Color color124 = new Microsoft.Xna.Framework.Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
				float rotation141 = 0f;
				origin = default(Vector2);
				spriteBatch141.Draw(texture66, position141, sourceRectangle66, color124, rotation141, origin, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
				SpriteBatch spriteBatch142 = this.spriteBatch;
				Texture2D texture67 = Main.cursorTexture;
				Vector2 position142 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
				Microsoft.Xna.Framework.Rectangle? sourceRectangle67 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
				Microsoft.Xna.Framework.Color color125 = Main.cursorColor;
				float rotation142 = 0f;
				origin = default(Vector2);
				spriteBatch142.Draw(texture67, position142, sourceRectangle67, color125, rotation142, origin, Main.cursorScale, SpriteEffects.None, 0f);
				if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					this.mouseNPC = -1;
					Main.player[Main.myPlayer].showItemIcon = false;
					Main.player[Main.myPlayer].showItemIcon2 = 0;
					flag = true;
					float num244 = 1f;
					if (Main.itemTexture[Main.mouseItem.type].Width > 32 || Main.itemTexture[Main.mouseItem.type].Height > 32)
					{
						if (Main.itemTexture[Main.mouseItem.type].Width > Main.itemTexture[Main.mouseItem.type].Height)
						{
							num244 = 32f / (float)Main.itemTexture[Main.mouseItem.type].Width;
						}
						else
						{
							num244 = 32f / (float)Main.itemTexture[Main.mouseItem.type].Height;
						}
					}
					float num245 = 1f;
					num245 *= Main.cursorScale;
					Microsoft.Xna.Framework.Color white35 = Microsoft.Xna.Framework.Color.White;
					num244 *= num245;
					SpriteBatch spriteBatch143 = this.spriteBatch;
					Texture2D texture68 = Main.itemTexture[Main.mouseItem.type];
					Vector2 position143 = new Vector2((float)Main.mouseX + 26f * num245 - (float)Main.itemTexture[Main.mouseItem.type].Width * 0.5f * num244, (float)Main.mouseY + 26f * num245 - (float)Main.itemTexture[Main.mouseItem.type].Height * 0.5f * num244);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle68 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height));
					Microsoft.Xna.Framework.Color alpha17 = Main.mouseItem.GetAlpha(white35);
					float rotation143 = 0f;
					origin = default(Vector2);
					spriteBatch143.Draw(texture68, position143, sourceRectangle68, alpha17, rotation143, origin, num244, SpriteEffects.None, 0f);
					Microsoft.Xna.Framework.Color color126 = Main.mouseItem.color;
					if (color126 != default(Microsoft.Xna.Framework.Color))
					{
						SpriteBatch spriteBatch144 = this.spriteBatch;
						Texture2D texture69 = Main.itemTexture[Main.mouseItem.type];
						Vector2 position144 = new Vector2((float)Main.mouseX + 26f * num245 - (float)Main.itemTexture[Main.mouseItem.type].Width * 0.5f * num244, (float)Main.mouseY + 26f * num245 - (float)Main.itemTexture[Main.mouseItem.type].Height * 0.5f * num244);
						Microsoft.Xna.Framework.Rectangle? sourceRectangle69 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height));
						Microsoft.Xna.Framework.Color color127 = Main.mouseItem.GetColor(white35);
						float rotation144 = 0f;
						origin = default(Vector2);
						spriteBatch144.Draw(texture69, position144, sourceRectangle69, color127, rotation144, origin, num244, SpriteEffects.None, 0f);
					}
					if (Main.mouseItem.stack > 1)
					{
						SpriteBatch spriteBatch145 = this.spriteBatch;
						SpriteFontX spriteFont76 = Main.fontItemStack;
						string text106 = string.Concat(Main.mouseItem.stack);
						Vector2 position145 = new Vector2((float)Main.mouseX + 10f * num245, (float)Main.mouseY + 26f * num245);
						Microsoft.Xna.Framework.Color color128 = white35;
						float rotation145 = 0f;
						origin = default(Vector2);
						this.DStoDSX(spriteFont76, text106, position145, color128, rotation145, origin, num244, SpriteEffects.None, 0f);
					}
				}
				else if (this.mouseNPC > -1)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					flag = false;
					float num246 = 1f;
					num246 *= Main.cursorScale;
					SpriteBatch spriteBatch146 = this.spriteBatch;
					Texture2D texture70 = Main.npcHeadTexture[this.mouseNPC];
					Vector2 position146 = new Vector2((float)Main.mouseX + 26f * num246 - (float)Main.npcHeadTexture[this.mouseNPC].Width * 0.5f * num246, (float)Main.mouseY + 26f * num246 - (float)Main.npcHeadTexture[this.mouseNPC].Height * 0.5f * num246);
					Microsoft.Xna.Framework.Rectangle? sourceRectangle70 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.npcHeadTexture[this.mouseNPC].Width, Main.npcHeadTexture[this.mouseNPC].Height));
					Microsoft.Xna.Framework.Color white36 = Microsoft.Xna.Framework.Color.White;
					float rotation146 = 0f;
					origin = default(Vector2);
					spriteBatch146.Draw(texture70, position146, sourceRectangle70, white36, rotation146, origin, num246, SpriteEffects.None, 0f);
					if (Main.mouseRight && Main.mouseRightRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						this.mouseNPC = -1;
					}
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						if (this.mouseNPC == 0)
						{
							int x = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
							int y = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
							int n2 = -1;
							if (WorldGen.MoveNPC(x, y, n2))
							{
								Main.NewText("这间房子可以使用。", 255, 240, 20);
							}
						}
						else
						{
							int num247 = 0;
							for (int num248 = 0; num248 < 200; num248++)
							{
								if (Main.npc[num248].active && Main.npc[num248].type == NPC.NumToType(this.mouseNPC))
								{
									num247 = num248;
									break;
								}
							}
							if (num247 >= 0)
							{
								int x2 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
								int y2 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
								if (WorldGen.MoveNPC(x2, y2, num247))
								{
									this.mouseNPC = -1;
									WorldGen.moveRoom(x2, y2, num247);
									Main.PlaySound(12, -1, -1, 1);
								}
							}
							else
							{
								this.mouseNPC = 0;
							}
						}
					}
				}
				Microsoft.Xna.Framework.Rectangle rectangle2 = new Microsoft.Xna.Framework.Rectangle((int)((float)Main.mouseX + Main.screenPosition.X), (int)((float)Main.mouseY + Main.screenPosition.Y), 1, 1);
				if (!flag)
				{
					int num249 = 26 * Main.player[Main.myPlayer].statLifeMax / num43;
					int num250 = 0;
					if (Main.player[Main.myPlayer].statLifeMax > 200)
					{
						num249 = 260;
						num250 += 26;
					}
					if (Main.mouseX > 500 + num41 && Main.mouseX < 500 + num249 + num41 && Main.mouseY > 32 && Main.mouseY < 32 + Main.heartTexture.Height + num250)
					{
						Main.player[Main.myPlayer].showItemIcon = false;
						string cursorText = Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax;
						this.MouseText(cursorText, 0, 0);
						flag = true;
					}
				}
				if (!flag)
				{
					int num251 = 24;
					int num252 = 28 * Main.player[Main.myPlayer].statManaMax2 / num50;
					if (Main.mouseX > 762 + num41 && Main.mouseX < 762 + num251 + num41 && Main.mouseY > 30 && Main.mouseY < 30 + num252)
					{
						Main.player[Main.myPlayer].showItemIcon = false;
						string cursorText2 = Main.player[Main.myPlayer].statMana + "/" + Main.player[Main.myPlayer].statManaMax2;
						this.MouseText(cursorText2, 0, 0);
						flag = true;
					}
				}
				if (!flag)
				{
					for (int num253 = 0; num253 < 200; num253++)
					{
						if (Main.item[num253].active)
						{
							Microsoft.Xna.Framework.Rectangle value3 = new Microsoft.Xna.Framework.Rectangle((int)((double)Main.item[num253].position.X + (double)Main.item[num253].width * 0.5 - (double)Main.itemTexture[Main.item[num253].type].Width * 0.5), (int)(Main.item[num253].position.Y + (float)Main.item[num253].height - (float)Main.itemTexture[Main.item[num253].type].Height), Main.itemTexture[Main.item[num253].type].Width, Main.itemTexture[Main.item[num253].type].Height);
							if (rectangle2.Intersects(value3))
							{
								Main.player[Main.myPlayer].showItemIcon = false;
								string text107 = Main.item[num253].AffixName();
								if (Main.item[num253].stack > 1)
								{
									object obj = text107;
									text107 = string.Concat(new object[]
									{
										obj,
										" (",
										Main.item[num253].stack,
										")"
									});
								}
								if (Main.item[num253].owner < 255 && Main.showItemOwner)
								{
									text107 = text107 + " <" + Main.player[Main.item[num253].owner].name + ">";
								}
								rare = Main.item[num253].rare;
								this.MouseText(text107, rare, 0);
								flag = true;
								break;
							}
						}
					}
				}
				for (int num254 = 0; num254 < 255; num254++)
				{
					if (Main.player[num254].active && Main.myPlayer != num254 && !Main.player[num254].dead)
					{
						Microsoft.Xna.Framework.Rectangle value4 = new Microsoft.Xna.Framework.Rectangle((int)((double)Main.player[num254].position.X + (double)Main.player[num254].width * 0.5 - 16.0), (int)(Main.player[num254].position.Y + (float)Main.player[num254].height - 48f), 32, 48);
						if (!flag && rectangle2.Intersects(value4))
						{
							Main.player[Main.myPlayer].showItemIcon = false;
							int num255 = Main.player[num254].statLife;
							if (num255 < 0)
							{
								num255 = 0;
							}
							string text108 = string.Concat(new object[]
							{
								Main.player[num254].name,
								": ",
								num255,
								"/",
								Main.player[num254].statLifeMax
							});
							if (Main.player[num254].hostile)
							{
								text108 += " (PvP)";
							}
							this.MouseText(text108, 0, Main.player[num254].difficulty);
						}
					}
				}
				if (!flag)
				{
					for (int num256 = 0; num256 < 200; num256++)
					{
						if (Main.npc[num256].active)
						{
							Microsoft.Xna.Framework.Rectangle value5 = new Microsoft.Xna.Framework.Rectangle((int)((double)Main.npc[num256].position.X + (double)Main.npc[num256].width * 0.5 - (double)Main.npcTexture[Main.npc[num256].type].Width * 0.5), (int)(Main.npc[num256].position.Y + (float)Main.npc[num256].height - (float)(Main.npcTexture[Main.npc[num256].type].Height / Main.npcFrameCount[Main.npc[num256].type])), Main.npcTexture[Main.npc[num256].type].Width, Main.npcTexture[Main.npc[num256].type].Height / Main.npcFrameCount[Main.npc[num256].type]);
							if (Main.npc[num256].type >= 87 && Main.npc[num256].type <= 92)
							{
								value5 = new Microsoft.Xna.Framework.Rectangle((int)((double)Main.npc[num256].position.X + (double)Main.npc[num256].width * 0.5 - 32.0), (int)((double)Main.npc[num256].position.Y + (double)Main.npc[num256].height * 0.5 - 32.0), 64, 64);
							}
							if (rectangle2.Intersects(value5) && (Main.npc[num256].type != 85 || Main.npc[num256].ai[0] != 0f))
							{
								bool flag9 = false;
								if (Main.npc[num256].townNPC || Main.npc[num256].type == 105 || Main.npc[num256].type == 106 || Main.npc[num256].type == 123)
								{
									Microsoft.Xna.Framework.Rectangle rectangle3 = new Microsoft.Xna.Framework.Rectangle((int)(Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Player.tileRangeX * 16)), (int)(Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
									Microsoft.Xna.Framework.Rectangle value6 = new Microsoft.Xna.Framework.Rectangle((int)Main.npc[num256].position.X, (int)Main.npc[num256].position.Y, Main.npc[num256].width, Main.npc[num256].height);
									if (rectangle3.Intersects(value6))
									{
										flag9 = true;
									}
								}
								if (flag9 && !Main.player[Main.myPlayer].dead)
								{
									int num257 = -(Main.npc[num256].width / 2 + 8);
									SpriteEffects effects2 = SpriteEffects.None;
									if (Main.npc[num256].spriteDirection == -1)
									{
										effects2 = SpriteEffects.FlipHorizontally;
										num257 = Main.npc[num256].width / 2 + 8;
									}
									SpriteBatch spriteBatch147 = this.spriteBatch;
									Texture2D texture71 = Main.chatTexture;
									Vector2 position147 = new Vector2(Main.npc[num256].position.X + (float)(Main.npc[num256].width / 2) - Main.screenPosition.X - (float)(Main.chatTexture.Width / 2) - (float)num257, Main.npc[num256].position.Y - (float)Main.chatTexture.Height - Main.screenPosition.Y);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle71 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chatTexture.Width, Main.chatTexture.Height));
									Microsoft.Xna.Framework.Color color129 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
									float rotation147 = 0f;
									origin = default(Vector2);
									spriteBatch147.Draw(texture71, position147, sourceRectangle71, color129, rotation147, origin, 1f, effects2, 0f);
									if (Main.mouseRight && Main.npcChatRelease)
									{
										Main.npcChatRelease = false;
										if (Main.player[Main.myPlayer].talkNPC != num256)
										{
											Main.player[Main.myPlayer].sign = -1;
											Main.editSign = false;
											Main.player[Main.myPlayer].talkNPC = num256;
											Main.playerInventory = false;
											Main.player[Main.myPlayer].chest = -1;
											Main.npcChatText = Main.npc[num256].GetChat();
											Main.PlaySound(24, -1, -1, 1);
										}
									}
								}
								Main.player[Main.myPlayer].showItemIcon = false;
								string text109 = Main.npc[num256].displayCName;
								int num258 = num256;
								if (Main.npc[num256].realLife >= 0)
								{
									num258 = Main.npc[num256].realLife;
								}
								if (Main.npc[num258].lifeMax > 1 && !Main.npc[num258].dontTakeDamage)
								{
									object obj = text109;
									text109 = string.Concat(new object[]
									{
										obj,
										": ",
										Main.npc[num258].life,
										"/",
										Main.npc[num258].lifeMax
									});
								}
								this.MouseText(text109, 0, 0);
								break;
							}
						}
					}
				}
				if (Main.mouseRight)
				{
					Main.npcChatRelease = false;
				}
				else
				{
					Main.npcChatRelease = true;
				}
				if (Main.player[Main.myPlayer].showItemIcon && (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type > 0 || Main.player[Main.myPlayer].showItemIcon2 > 0))
				{
					int num259 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
					Microsoft.Xna.Framework.Color color130 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetAlpha(Microsoft.Xna.Framework.Color.White);
					Microsoft.Xna.Framework.Color color131 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetColor(Microsoft.Xna.Framework.Color.White);
					if (Main.player[Main.myPlayer].showItemIcon2 > 0)
					{
						num259 = Main.player[Main.myPlayer].showItemIcon2;
						color130 = Microsoft.Xna.Framework.Color.White;
						color131 = default(Microsoft.Xna.Framework.Color);
					}
					float scale2 = Main.cursorScale;
					SpriteBatch spriteBatch148 = this.spriteBatch;
					Texture2D texture72 = Main.itemTexture[num259];
					Vector2 position148 = new Vector2((float)(Main.mouseX + 10), (float)(Main.mouseY + 10));
					Microsoft.Xna.Framework.Rectangle? sourceRectangle72 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[num259].Width, Main.itemTexture[num259].Height));
					Microsoft.Xna.Framework.Color color132 = color130;
					float rotation148 = 0f;
					origin = default(Vector2);
					spriteBatch148.Draw(texture72, position148, sourceRectangle72, color132, rotation148, origin, scale2, SpriteEffects.None, 0f);
					if (Main.player[Main.myPlayer].showItemIcon2 == 0)
					{
						Microsoft.Xna.Framework.Color color133 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].color;
						if (color133 != default(Microsoft.Xna.Framework.Color))
						{
							SpriteBatch spriteBatch149 = this.spriteBatch;
							Texture2D texture73 = Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type];
							Vector2 position149 = new Vector2((float)(Main.mouseX + 10), (float)(Main.mouseY + 10));
							Microsoft.Xna.Framework.Rectangle? sourceRectangle73 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Height));
							Microsoft.Xna.Framework.Color color134 = color131;
							float rotation149 = 0f;
							origin = default(Vector2);
							spriteBatch149.Draw(texture73, position149, sourceRectangle73, color134, rotation149, origin, scale2, SpriteEffects.None, 0f);
						}
					}
				}
				Main.player[Main.myPlayer].showItemIcon = false;
				Main.player[Main.myPlayer].showItemIcon2 = 0;
			}
		}

		protected void QuitGame()
		{
			Steam.Kill();
			base.Exit();
		}

		protected Microsoft.Xna.Framework.Color randColor()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num + num3 + num2 <= 150)
			{
				num = Main.rand.Next(256);
				num2 = Main.rand.Next(256);
				num3 = Main.rand.Next(256);
			}
			return new Microsoft.Xna.Framework.Color(num, num2, num3, 255);
		}

		protected void DrawMenu()
		{
			Main.render = false;
			Star.UpdateStars();
			Cloud.UpdateClouds();
			Main.holyTiles = 0;
			Main.evilTiles = 0;
			Main.jungleTiles = 0;
			Main.chatMode = false;
			for (int i = 0; i < Main.numChatLines; i++)
			{
				Main.chatLine[i] = new ChatLine();
			}
			this.DrawFPS();
			Main.screenLastPosition = Main.screenPosition;
			Main.screenPosition.Y = (float)(Main.worldSurface * 16.0 - (double)Main.screenHeight);
			if (Main.grabSky)
			{
				Main.screenPosition.X = Main.screenPosition.X + (float)(Main.mouseX - Main.screenWidth / 2) * 0.02f;
			}
			else
			{
				Main.screenPosition.X = Main.screenPosition.X + 2f;
			}
			if (Main.screenPosition.X > 2.14748352E+09f)
			{
				Main.screenPosition.X = 0f;
			}
			if (Main.screenPosition.X < -2.14748352E+09f)
			{
				Main.screenPosition.X = 0f;
			}
			Main.background = 0;
			byte b = (byte)((255 + Main.tileColor.R * 2) / 3);
			Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color((int)b, (int)b, (int)b, 255);
			this.logoRotation += this.logoRotationSpeed * 3E-05f;
			if ((double)this.logoRotation > 0.1)
			{
				this.logoRotationDirection = -1f;
			}
			else if ((double)this.logoRotation < -0.1)
			{
				this.logoRotationDirection = 1f;
			}
			if (this.logoRotationSpeed < 20f & this.logoRotationDirection == 1f)
			{
				this.logoRotationSpeed += 1f;
			}
			else if (this.logoRotationSpeed > -20f & this.logoRotationDirection == -1f)
			{
				this.logoRotationSpeed -= 1f;
			}
			this.logoScale += this.logoScaleSpeed * 1E-05f;
			if ((double)this.logoScale > 1.1)
			{
				this.logoScaleDirection = -1f;
			}
			else if ((double)this.logoScale < 0.9)
			{
				this.logoScaleDirection = 1f;
			}
			if (this.logoScaleSpeed < 50f & this.logoScaleDirection == 1f)
			{
				this.logoScaleSpeed += 1f;
			}
			else if (this.logoScaleSpeed > -50f & this.logoScaleDirection == -1f)
			{
				this.logoScaleSpeed -= 1f;
			}
			Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color((int)((byte)((float)color.R * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.G * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.B * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.A * ((float)Main.LogoA / 255f))));
			Microsoft.Xna.Framework.Color color3 = new Microsoft.Xna.Framework.Color((int)((byte)((float)color.R * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.G * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.B * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.A * ((float)Main.LogoB / 255f))));
			Main.LogoT = false;
			if (!Main.LogoT)
			{
				this.spriteBatch.Draw(Main.logoTexture, new Vector2((float)(Main.screenWidth / 2), 100f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			}
			else
			{
				this.spriteBatch.Draw(Main.logo3Texture, new Vector2((float)(Main.screenWidth / 2), 100f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			}
			this.spriteBatch.Draw(Main.logo2Texture, new Vector2((float)(Main.screenWidth / 2), 100f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color3, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			if (Main.dayTime)
			{
				Main.LogoA += 2;
				if (Main.LogoA > 255)
				{
					Main.LogoA = 255;
				}
				Main.LogoB--;
				if (Main.LogoB < 0)
				{
					Main.LogoB = 0;
				}
			}
			else
			{
				Main.LogoB += 2;
				if (Main.LogoB > 255)
				{
					Main.LogoB = 255;
				}
				Main.LogoA--;
				if (Main.LogoA < 0)
				{
					Main.LogoA = 0;
					Main.LogoT = true;
				}
			}
			int num = 250;
			int num2 = Main.screenWidth / 2;
			int num3 = 80;
			int num4 = 0;
			int num5 = Main.menuMode;
			int num6 = -1;
			int num7 = 0;
			int num8 = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num9 = 0;
			bool[] array = new bool[Main.maxMenuItems];
			bool[] array2 = new bool[Main.maxMenuItems];
			int[] array3 = new int[Main.maxMenuItems];
			int[] array4 = new int[Main.maxMenuItems];
			byte[] array5 = new byte[Main.maxMenuItems];
			float[] array6 = new float[Main.maxMenuItems];
			bool[] array7 = new bool[Main.maxMenuItems];
			for (int j = 0; j < Main.maxMenuItems; j++)
			{
				array[j] = false;
				array2[j] = false;
				array3[j] = 0;
				array4[j] = 0;
				array6[j] = 1f;
			}
			string[] array8 = new string[Main.maxMenuItems];
			if (Main.menuMode == -1)
			{
				Main.menuMode = 0;
			}
			if (Main.netMode == 2)
			{
				bool flag4 = true;
				for (int k = 0; k < 8; k++)
				{
					if (k < 255)
					{
						try
						{
							array8[k] = Netplay.serverSock[k].statusText;
							if (Netplay.serverSock[k].active && Main.showSpam)
							{
								string[] array10;
								string[] array9 = array10 = array8;
								IntPtr value;
								int num10 = (int)(value = (IntPtr)k);
								object obj = array9[(int)value];
								array10[num10] = string.Concat(new object[]
								{
									obj,
									" (",
									NetMessage.buffer[k].spamCount,
									")"
								});
							}
						}
						catch
						{
							array8[k] = "";
						}
						array[k] = true;
						if (array8[k] != "" && array8[k] != null)
						{
							flag4 = false;
						}
					}
				}
				if (flag4)
				{
					array8[0] = "打开新的客户端连接本服务器！";
					array8[1] = "服务器运行于端口 " + Netplay.serverPort + "。";
				}
				num4 = 11;
				array8[9] = Main.statusText;
				array[9] = true;
				num = 170;
				num3 = 30;
				array3[10] = 20;
				array3[10] = 40;
				array8[10] = "断开连接";
				if (this.selectedMenu == 10)
				{
					Netplay.disconnect = true;
					Main.PlaySound(11, -1, -1, 1);
				}
			}
			else if (Main.menuMode == 31)
			{
				string password = Netplay.password;
				Netplay.password = Main.GetInputText(Netplay.password);
				if (password != Netplay.password)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				array8[0] = "    服务器要求输入密码:";
				this.textBlinkerCount++;
				if (this.textBlinkerCount >= 20)
				{
					if (this.textBlinkerState == 0)
					{
						this.textBlinkerState = 1;
					}
					else
					{
						this.textBlinkerState = 0;
					}
					this.textBlinkerCount = 0;
				}
				array8[1] = Netplay.password;
				if (this.textBlinkerState == 1)
				{
					string[] array9;
					(array9 = array8)[1] = array9[1] + "|";
					array4[1] = 1;
				}
				else
				{
					string[] array9;
					(array9 = array8)[1] = array9[1] + " ";
				}
				array[0] = true;
				array[1] = true;
				array3[1] = -20;
				array3[2] = 20;
				array8[2] = "接受";
				array8[3] = "返回";
				num4 = 4;
				if (this.selectedMenu == 3)
				{
					Main.PlaySound(11, -1, -1, 1);
					Main.menuMode = 0;
					Netplay.disconnect = true;
					Netplay.password = "";
				}
				else if (this.selectedMenu == 2 || Main.inputTextEnter)
				{
					NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
					Main.menuMode = 14;
				}
			}
			else
			{
				if (Main.netMode == 1 || Main.menuMode == 14)
				{
					num4 = 2;
					array8[0] = Main.statusText;
					array[0] = true;
					num = 300;
					array8[1] = "取消";
					if (this.selectedMenu != 1)
					{
						goto IL_43DD;
					}
					Netplay.disconnect = true;
					Netplay.clientSock.tcpClient.Close();
					Main.PlaySound(11, -1, -1, 1);
					Main.menuMode = 0;
					Main.netMode = 0;
					try
					{
						this.tServer.Kill();
						goto IL_43DD;
					}
					catch
					{
						goto IL_43DD;
					}
				}
				if (Main.menuMode == 30)
				{
					string password2 = Netplay.password;
					Netplay.password = Main.GetInputText(Netplay.password);
					if (password2 != Netplay.password)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "   输入服务器密码:";
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Netplay.password;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[1] = -20;
					array3[2] = 20;
					array8[2] = "接受";
					array8[3] = "返回";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 6;
						Netplay.password = "";
					}
					else if (this.selectedMenu == 2 || Main.inputTextEnter || Main.autoPass)
					{
						this.tServer.StartInfo.FileName = "TerrariaServer.exe";
						this.tServer.StartInfo.Arguments = string.Concat(new string[]
						{
							"-autoshutdown -world \"",
							Main.worldPathName,
							"\" -password \"",
							Netplay.password,
							"\""
						});
						if (Main.libPath != "")
						{
							ProcessStartInfo startInfo = this.tServer.StartInfo;
							startInfo.Arguments = startInfo.Arguments + " -loadlib " + Main.libPath;
						}
						this.tServer.StartInfo.UseShellExecute = false;
						this.tServer.StartInfo.CreateNoWindow = true;
						this.tServer.Start();
						Netplay.SetIP("127.0.0.1");
						Main.autoPass = true;
						Main.statusText = "准备启动服务器...";
						Netplay.StartClient();
						Main.menuMode = 10;
					}
				}
				else if (Main.menuMode == 15)
				{
					num4 = 2;
					array8[0] = Main.statusText;
					array[0] = true;
					num = 80;
					num3 = 400;
					array8[1] = "返回";
					if (this.selectedMenu == 1)
					{
						Netplay.disconnect = true;
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
						Main.netMode = 0;
					}
				}
				else if (Main.menuMode == 200)
				{
					num4 = 3;
					array8[0] = "载入地图失败！";
					array[0] = true;
					num -= 30;
					array3[1] = 70;
					array3[2] = 50;
					array8[1] = "尝试载入备份地图";
					array8[2] = "取消";
					if (this.selectedMenu == 1)
					{
						if (File.Exists(Main.worldPathName + ".bak"))
						{
							File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
							File.Delete(Main.worldPathName + ".bak");
							Main.PlaySound(10, -1, -1, 1);
							WorldGen.playWorld();
							Main.menuMode = 10;
						}
						else
						{
							Main.PlaySound(11, -1, -1, 1);
							Main.menuMode = 0;
							Main.netMode = 0;
						}
					}
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
						Main.netMode = 0;
					}
				}
				else if (Main.menuMode == 201)
				{
					num4 = 3;
					array8[0] = "载入地图失败！";
					array[0] = true;
					array[1] = true;
					num -= 30;
					array3[1] = -30;
					array3[2] = 50;
					array8[1] = "备份地图没有找到";
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
						Main.netMode = 0;
					}
				}
				else if (Main.menuMode == 10)
				{
					num4 = 1;
					array8[0] = Main.statusText;
					array[0] = true;
					num = 300;
				}
				else if (Main.menuMode == 100)
				{
					num4 = 1;
					array8[0] = Main.statusText;
					array[0] = true;
					num = 300;
				}
				else if (Main.menuMode == 0)
				{
					Main.menuMultiplayer = false;
					Main.menuServer = false;
					Main.netMode = 0;
					array8[0] = " 单人游戏";
					array8[1] = " 多人游戏";
					array8[2] = "设置";
					array8[3] = "退出";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						this.QuitGame();
					}
					if (this.selectedMenu == 1)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 12;
					}
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 11;
					}
					if (this.selectedMenu == 0)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1;
						Main.LoadPlayers();
					}
				}
				else if (Main.menuMode == 1)
				{
					Main.myPlayer = 0;
					num = 190;
					num3 = 50;
					array8[5] = "  创建新人物";
					array8[6] = "删除";
					if (Main.numLoadPlayers == 5)
					{
						array2[5] = true;
						array8[5] = "";
					}
					else if (Main.numLoadPlayers == 0)
					{
						array2[6] = true;
						array8[6] = "";
					}
					array8[7] = "返回";
					for (int l = 0; l < 5; l++)
					{
						if (l < Main.numLoadPlayers)
						{
							array8[l] = Main.loadPlayer[l].name;
							array5[l] = Main.loadPlayer[l].difficulty;
						}
						else
						{
							array8[l] = null;
						}
					}
					num4 = 8;
					if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
					{
						num6 = this.focusMenu;
						Vector2 vector = Main.fontDeathText.MeasureString(array8[num6]);
						num7 = (int)((double)(Main.screenWidth / 2) + (double)vector.X * 0.5 + 10.0);
						num8 = num + num3 * this.focusMenu + 4;
					}
					if (this.selectedMenu == 7)
					{
						Main.autoJoin = false;
						Main.autoPass = false;
						Main.PlaySound(11, -1, -1, 1);
						if (Main.menuMultiplayer)
						{
							Main.menuMode = 12;
							Main.menuMultiplayer = false;
							Main.menuServer = false;
						}
						else
						{
							Main.menuMode = 0;
						}
					}
					else if (this.selectedMenu == 5)
					{
						Main.loadPlayer[Main.numLoadPlayers] = new Player();
						Main.loadPlayer[Main.numLoadPlayers].inventory[0].SetDefaults("Copper Shortsword");
						Main.loadPlayer[Main.numLoadPlayers].inventory[0].Prefix(-1);
						Main.loadPlayer[Main.numLoadPlayers].inventory[1].SetDefaults("Copper Pickaxe");
						Main.loadPlayer[Main.numLoadPlayers].inventory[1].Prefix(-1);
						Main.loadPlayer[Main.numLoadPlayers].inventory[2].SetDefaults("Copper Axe");
						Main.loadPlayer[Main.numLoadPlayers].inventory[2].Prefix(-1);
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 2;
					}
					else if (this.selectedMenu == 6)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 4;
					}
					else if (this.selectedMenu >= 0)
					{
						if (Main.menuMultiplayer)
						{
							this.selectedPlayer = this.selectedMenu;
							Main.player[Main.myPlayer] = (Player)Main.loadPlayer[this.selectedPlayer].Clone();
							Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
							Main.PlaySound(10, -1, -1, 1);
							if (Main.autoJoin)
							{
								if (Netplay.SetIP(Main.getIP))
								{
									Main.menuMode = 10;
									Netplay.StartClient();
								}
								else if (Netplay.SetIP2(Main.getIP))
								{
									Main.menuMode = 10;
									Netplay.StartClient();
								}
								Main.autoJoin = false;
							}
							else if (Main.menuServer)
							{
								Main.LoadWorlds();
								Main.menuMode = 6;
							}
							else
							{
								Main.menuMode = 13;
							}
						}
						else
						{
							Main.myPlayer = 0;
							this.selectedPlayer = this.selectedMenu;
							Main.player[Main.myPlayer] = (Player)Main.loadPlayer[this.selectedPlayer].Clone();
							Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
							Main.LoadWorlds();
							Main.PlaySound(10, -1, -1, 1);
							Main.menuMode = 6;
						}
					}
				}
				else if (Main.menuMode == 2)
				{
					if (this.selectedMenu == 0)
					{
						Main.menuMode = 17;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].hairColor;
					}
					if (this.selectedMenu == 1)
					{
						Main.menuMode = 18;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].eyeColor;
					}
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 19;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].skinColor;
					}
					if (this.selectedMenu == 3)
					{
						Main.menuMode = 20;
						Main.PlaySound(10, -1, -1, 1);
					}
					array8[0] = "头发";
					array8[1] = "眼睛";
					array8[2] = "皮肤";
					array8[3] = "衣服";
					num = 220;
					for (int m = 0; m < 9; m++)
					{
						if (m < 6)
						{
							array6[m] = 0.75f;
						}
						else
						{
							array6[m] = 0.9f;
						}
					}
					num3 = 38;
					array3[6] = 6;
					array3[7] = 12;
					array3[8] = 18;
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 176;
					if (Main.loadPlayer[num6].male)
					{
						array8[4] = "男性";
					}
					else
					{
						array8[4] = "女性";
					}
					if (this.selectedMenu == 4)
					{
						if (Main.loadPlayer[num6].male)
						{
							Main.PlaySound(20, -1, -1, 1);
							Main.loadPlayer[num6].male = false;
						}
						else
						{
							Main.PlaySound(1, -1, -1, 1);
							Main.loadPlayer[num6].male = true;
						}
					}
					if (Main.loadPlayer[num6].difficulty == 2)
					{
						array8[5] = "困难难度";
						array5[5] = Main.loadPlayer[num6].difficulty;
					}
					else if (Main.loadPlayer[num6].difficulty == 1)
					{
						array8[5] = "中等难度";
						array5[5] = Main.loadPlayer[num6].difficulty;
					}
					else
					{
						array8[5] = "一般难度";
					}
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 222;
					}
					if (this.selectedMenu == 7)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.loadPlayer[num6].hair = Main.rand.Next(36);
						Main.loadPlayer[num6].eyeColor = this.randColor();
						while ((int)(Main.loadPlayer[num6].eyeColor.R + Main.loadPlayer[num6].eyeColor.G + Main.loadPlayer[num6].eyeColor.B) > 300)
						{
							Main.loadPlayer[num6].eyeColor = this.randColor();
						}
						Main.loadPlayer[num6].hairColor = this.randColor();
						Main.loadPlayer[num6].pantsColor = this.randColor();
						Main.loadPlayer[num6].shirtColor = this.randColor();
						Main.loadPlayer[num6].shoeColor = this.randColor();
						Main.loadPlayer[num6].skinColor = this.randColor();
						float num11 = (float)Main.rand.Next(60, 120) * 0.01f;
						if (num11 > 1f)
						{
							num11 = 1f;
						}
						Main.loadPlayer[num6].skinColor.R = (byte)((float)Main.rand.Next(240, 255) * num11);
						Main.loadPlayer[num6].skinColor.G = (byte)((float)Main.rand.Next(110, 140) * num11);
						Main.loadPlayer[num6].skinColor.B = (byte)((float)Main.rand.Next(75, 110) * num11);
						Main.loadPlayer[num6].underShirtColor = this.randColor();
						int num12 = Main.loadPlayer[num6].hair + 1;
						if (num12 == 5 || num12 == 6 || num12 == 7 || num12 == 10 || num12 == 12 || num12 == 19 || num12 == 22 || num12 == 23 || num12 == 26 || num12 == 27 || num12 == 30 || num12 == 33)
						{
							Main.loadPlayer[num6].male = false;
						}
						else
						{
							Main.loadPlayer[num6].male = true;
						}
					}
					array8[7] = "随机";
					array8[6] = "创建";
					array8[8] = "返回";
					num4 = 9;
					if (this.selectedMenu == 8)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
					else if (this.selectedMenu == 6)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.loadPlayer[Main.numLoadPlayers].name = "";
						Main.menuMode = 3;
					}
				}
				else if (Main.menuMode == 222)
				{
					if (this.focusMenu == 3)
					{
						array8[0] = "困难难度死亡后角色被删除";
					}
					else if (this.focusMenu == 2)
					{
						array8[0] = "中等难度死亡掉落所有物品";
					}
					else if (this.focusMenu == 1)
					{
						array8[0] = "一般难度死亡后只掉落金钱";
					}
					else
					{
						array8[0] = "选择难度";
					}
					num3 = 50;
					array3[1] = 25;
					array3[2] = 25;
					array3[3] = 25;
					array[0] = true;
					array8[1] = "一般难度";
					array8[2] = "中等难度";
					array5[2] = 1;
					array8[3] = "困难难度";
					array5[3] = 2;
					num4 = 4;
					if (this.selectedMenu == 1)
					{
						Main.loadPlayer[Main.numLoadPlayers].difficulty = 0;
						Main.menuMode = 2;
					}
					else if (this.selectedMenu == 2)
					{
						Main.menuMode = 2;
						Main.loadPlayer[Main.numLoadPlayers].difficulty = 1;
					}
					else if (this.selectedMenu == 3)
					{
						Main.loadPlayer[Main.numLoadPlayers].difficulty = 2;
						Main.menuMode = 2;
					}
				}
				else if (Main.menuMode == 20)
				{
					if (this.selectedMenu == 0)
					{
						Main.menuMode = 21;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].shirtColor;
					}
					if (this.selectedMenu == 1)
					{
						Main.menuMode = 22;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].underShirtColor;
					}
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 23;
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].pantsColor;
					}
					if (this.selectedMenu == 3)
					{
						this.selColor = Main.loadPlayer[Main.numLoadPlayers].shoeColor;
						Main.menuMode = 24;
						Main.PlaySound(10, -1, -1, 1);
					}
					array8[0] = "上衣";
					array8[1] = "汗衫";
					array8[2] = "裤子";
					array8[3] = "鞋子";
					num = 260;
					num3 = 50;
					array3[5] = 20;
					array8[5] = "返回";
					num4 = 6;
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 2;
					}
				}
				else if (Main.menuMode == 17)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 390;
					num = 260;
					num3 = 60;
					Main.loadPlayer[num6].hairColor = this.selColor;
					num4 = 3;
					array8[0] = "发型 " + (Main.loadPlayer[num6].hair + 1);
					array8[1] = "头发颜色";
					array[1] = true;
					array3[2] = 150;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 0)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.loadPlayer[num6].hair++;
						if (Main.loadPlayer[num6].hair >= 36)
						{
							Main.loadPlayer[num6].hair = 0;
						}
					}
					else if (this.selectedMenu2 == 0)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.loadPlayer[num6].hair--;
						if (Main.loadPlayer[num6].hair < 0)
						{
							Main.loadPlayer[num6].hair = 35;
						}
					}
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 2;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 18)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].eyeColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "眼睛颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 2;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 19)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].skinColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "皮肤颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 2;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 21)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].shirtColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "上衣颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 20;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 22)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].underShirtColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "汗衫颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 20;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 23)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].pantsColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "裤子颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 20;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 24)
				{
					num6 = Main.numLoadPlayers;
					num7 = Main.screenWidth / 2 - 16;
					num8 = 210;
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.loadPlayer[num6].shoeColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "鞋子颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 20;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 3)
				{
					string name = Main.loadPlayer[Main.numLoadPlayers].name;
					Main.loadPlayer[Main.numLoadPlayers].name = Main.GetInputText(Main.loadPlayer[Main.numLoadPlayers].name);
					if (Main.loadPlayer[Main.numLoadPlayers].name.Length > Player.nameLen)
					{
						Main.loadPlayer[Main.numLoadPlayers].name = Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, Player.nameLen);
					}
					if (name != Main.loadPlayer[Main.numLoadPlayers].name)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "   输入角色名字:";
					array2[2] = true;
					if (Main.loadPlayer[Main.numLoadPlayers].name != "")
					{
						if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, 1) == " ")
						{
							Main.loadPlayer[Main.numLoadPlayers].name = "";
						}
						for (int n = 0; n < Main.loadPlayer[Main.numLoadPlayers].name.Length; n++)
						{
							if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(n, 1) != " ")
							{
								array2[2] = false;
							}
						}
					}
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Main.loadPlayer[Main.numLoadPlayers].name;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[1] = -20;
					array3[2] = 20;
					array8[2] = "接受";
					array8[3] = "返回";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 2;
					}
					if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
					{
						Main.loadPlayer[Main.numLoadPlayers].name.Trim();
						Main.loadPlayerPath[Main.numLoadPlayers] = Main.nextLoadPlayer();
						Player.SavePlayer(Main.loadPlayer[Main.numLoadPlayers], Main.loadPlayerPath[Main.numLoadPlayers]);
						Main.LoadPlayers();
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1;
					}
				}
				else if (Main.menuMode == 4)
				{
					num = 220;
					num3 = 60;
					array8[5] = "返回";
					for (int num13 = 0; num13 < 5; num13++)
					{
						if (num13 < Main.numLoadPlayers)
						{
							array8[num13] = Main.loadPlayer[num13].name;
							array5[num13] = Main.loadPlayer[num13].difficulty;
						}
						else
						{
							array8[num13] = null;
						}
					}
					num4 = 6;
					if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
					{
						num6 = this.focusMenu;
						Vector2 vector2 = Main.fontDeathText.MeasureString(array8[num6]);
						num7 = (int)((double)(Main.screenWidth / 2) + (double)vector2.X * 0.5 + 10.0);
						num8 = num + num3 * this.focusMenu + 4;
					}
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
					else if (this.selectedMenu >= 0)
					{
						this.selectedPlayer = this.selectedMenu;
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 5;
					}
				}
				else if (Main.menuMode == 5)
				{
					array8[0] = "删除 < " + Main.loadPlayer[this.selectedPlayer].name + " > 吗?";
					array[0] = true;
					array8[1] = "是";
					array8[2] = "否";
					num4 = 3;
					if (this.selectedMenu == 1)
					{
						Main.ErasePlayer(this.selectedPlayer);
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1;
					}
					else if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
				}
				else if (Main.menuMode == 6)
				{
					num = 190;
					num3 = 50;
					array8[5] = "  创建新世界";
					array8[6] = "删除";
					if (Main.numLoadWorlds == 5)
					{
						array2[5] = true;
						array8[5] = "";
					}
					else if (Main.numLoadWorlds == 0)
					{
						array2[6] = true;
						array8[6] = "";
					}
					array8[7] = "返回";
					for (int num14 = 0; num14 < 5; num14++)
					{
						if (num14 < Main.numLoadWorlds)
						{
							array8[num14] = Main.loadWorld[num14];
						}
						else
						{
							array8[num14] = null;
						}
					}
					num4 = 8;
					if (this.selectedMenu == 7)
					{
						if (Main.menuMultiplayer)
						{
							Main.menuMode = 12;
						}
						else
						{
							Main.menuMode = 1;
						}
						Main.PlaySound(11, -1, -1, 1);
					}
					else if (this.selectedMenu == 5)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 16;
						Main.newWorldName = "World " + (Main.numLoadWorlds + 1);
					}
					else if (this.selectedMenu == 6)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 8;
					}
					else if (this.selectedMenu >= 0)
					{
						if (Main.menuMultiplayer)
						{
							Main.PlaySound(10, -1, -1, 1);
							Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
							Main.menuMode = 30;
						}
						else
						{
							Main.PlaySound(10, -1, -1, 1);
							Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
							WorldGen.playWorld();
							Main.menuMode = 10;
						}
					}
				}
				else if (Main.menuMode == 7)
				{
					string a = Main.newWorldName;
					Main.newWorldName = Main.GetInputText(Main.newWorldName);
					if (Main.newWorldName.Length > 20)
					{
						Main.newWorldName = Main.newWorldName.Substring(0, 20);
					}
					if (a != Main.newWorldName)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "   输入世界名字:";
					array2[2] = true;
					if (Main.newWorldName != "")
					{
						if (Main.newWorldName.Substring(0, 1) == " ")
						{
							Main.newWorldName = "";
						}
						for (int num15 = 0; num15 < Main.newWorldName.Length; num15++)
						{
							if (Main.newWorldName != " ")
							{
								array2[2] = false;
							}
						}
					}
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Main.newWorldName;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[1] = -20;
					array3[2] = 20;
					array8[2] = "接受";
					array8[3] = "返回";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 16;
					}
					if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
					{
						Main.menuMode = 10;
						Main.worldName = Main.newWorldName;
						Main.worldPathName = Main.nextLoadWorld();
						WorldGen.CreateNewWorld();
					}
				}
				else if (Main.menuMode == 8)
				{
					num = 220;
					num3 = 60;
					array8[5] = "返回";
					for (int num16 = 0; num16 < 5; num16++)
					{
						if (num16 < Main.numLoadWorlds)
						{
							array8[num16] = Main.loadWorld[num16];
						}
						else
						{
							array8[num16] = null;
						}
					}
					num4 = 6;
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
					else if (this.selectedMenu >= 0)
					{
						this.selectedWorld = this.selectedMenu;
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 9;
					}
				}
				else if (Main.menuMode == 9)
				{
					array8[0] = "删除 < " + Main.loadWorld[this.selectedWorld] + " > 吗?";
					array[0] = true;
					array8[1] = "是";
					array8[2] = "否";
					num4 = 3;
					if (this.selectedMenu == 1)
					{
						Main.EraseWorld(this.selectedWorld);
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 6;
					}
					else if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 6;
					}
				}
				else if (Main.menuMode == 1111)
				{
					num = 210;
					num3 = 46;
					for (int num17 = 0; num17 < 7; num17++)
					{
						array6[num17] = 0.9f;
					}
					array3[7] = 10;
					num4 = 8;
					if (this.graphics.IsFullScreen)
					{
						array8[0] = "窗口模式";
					}
					else
					{
						array8[0] = "全屏模式";
					}
					this.bgScroll = (int)Math.Round((double)((1f - Main.caveParrallax) * 500f));
					array8[1] = "分辨率";
					array8[2] = "平行视差";
					if (Main.fixedTiming)
					{
						array8[3] = "   跳帧 关 (不建议)";
					}
					else
					{
						array8[3] = "  跳帧 开 (建议)";
					}
					if (Lighting.lightMode == 0)
					{
						array8[4] = "光效: 艳丽";
					}
					else if (Lighting.lightMode == 1)
					{
						array8[4] = "光效: 白色";
					}
					else if (Lighting.lightMode == 2)
					{
						array8[4] = "光效: 怀旧";
					}
					else if (Lighting.lightMode == 3)
					{
						array8[4] = "光效: 朦胧";
					}
					if (Main.qaStyle == 0)
					{
						array8[5] = "画质: 自动";
					}
					else if (Main.qaStyle == 1)
					{
						array8[5] = "画质: 高";
					}
					else if (Main.qaStyle == 2)
					{
						array8[5] = "画质: 中";
					}
					else
					{
						array8[5] = "画质: 低";
					}
					if (Main.owBack)
					{
						array8[6] = "背景 开";
					}
					else
					{
						array8[6] = "背景 关";
					}
					if (this.selectedMenu == 6)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.owBack)
						{
							Main.owBack = false;
						}
						else
						{
							Main.owBack = true;
						}
					}
					array8[7] = "返回";
					if (this.selectedMenu == 7)
					{
						Main.PlaySound(11, -1, -1, 1);
						this.SaveSettings();
						Main.menuMode = 11;
					}
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.qaStyle++;
						if (Main.qaStyle > 3)
						{
							Main.qaStyle = 0;
						}
					}
					if (this.selectedMenu == 4)
					{
						Main.PlaySound(12, -1, -1, 1);
						Lighting.lightMode++;
						if (Lighting.lightMode >= 4)
						{
							Lighting.lightMode = 0;
						}
					}
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.fixedTiming)
						{
							Main.fixedTiming = false;
						}
						else
						{
							Main.fixedTiming = true;
						}
					}
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 28;
					}
					if (this.selectedMenu == 1)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 111;
					}
					if (this.selectedMenu == 0)
					{
						this.graphics.ToggleFullScreen();
					}
				}
				else if (Main.menuMode == 11)
				{
					num = 180;
					num3 = 48;
					array3[7] = 10;
					num4 = 8;
					array8[0] = "显示";
					array8[1] = " 光标颜色";
					array8[2] = "音量";
					array8[3] = " 按键控制";
					if (Main.autoSave)
					{
						array8[4] = "   自动保存 开";
					}
					else
					{
						array8[4] = "   自动保存 关";
					}
					if (Main.autoPause)
					{
						array8[5] = "   自动暂停 开";
					}
					else
					{
						array8[5] = "   自动暂停 关";
					}
					if (Main.showItemText)
					{
						array8[6] = "   拾取提示 开";
					}
					else
					{
						array8[6] = "   拾取提示 关";
					}
					array8[7] = "返回";
					if (this.selectedMenu == 7)
					{
						Main.PlaySound(11, -1, -1, 1);
						this.SaveSettings();
						Main.menuMode = 0;
					}
					if (this.selectedMenu == 6)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.showItemText)
						{
							Main.showItemText = false;
						}
						else
						{
							Main.showItemText = true;
						}
					}
					if (this.selectedMenu == 5)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.autoPause)
						{
							Main.autoPause = false;
						}
						else
						{
							Main.autoPause = true;
						}
					}
					if (this.selectedMenu == 4)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.autoSave)
						{
							Main.autoSave = false;
						}
						else
						{
							Main.autoSave = true;
						}
					}
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 27;
					}
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 26;
					}
					if (this.selectedMenu == 1)
					{
						Main.PlaySound(10, -1, -1, 1);
						this.selColor = Main.mouseColor;
						Main.menuMode = 25;
					}
					if (this.selectedMenu == 0)
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1111;
					}
				}
				else if (Main.menuMode == 111)
				{
					num = 240;
					num3 = 60;
					num4 = 3;
					array8[0] = "全屏分辨率";
					array8[1] = this.graphics.PreferredBackBufferWidth + "x" + this.graphics.PreferredBackBufferHeight;
					array[0] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 1)
					{
						Main.PlaySound(12, -1, -1, 1);
						int num18 = 0;
						for (int num19 = 0; num19 < this.numDisplayModes; num19++)
						{
							if (this.displayWidth[num19] == this.graphics.PreferredBackBufferWidth && this.displayHeight[num19] == this.graphics.PreferredBackBufferHeight)
							{
								num18 = num19;
								break;
							}
						}
						num18++;
						if (num18 >= this.numDisplayModes)
						{
							num18 = 0;
						}
						this.graphics.PreferredBackBufferWidth = this.displayWidth[num18];
						this.graphics.PreferredBackBufferHeight = this.displayHeight[num18];
					}
					if (this.selectedMenu == 2)
					{
						if (this.graphics.IsFullScreen)
						{
							this.graphics.ApplyChanges();
						}
						Main.menuMode = 1111;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 25)
				{
					flag = true;
					num9 = 370;
					num = 240;
					num3 = 60;
					Main.mouseColor = this.selColor;
					num4 = 3;
					array8[0] = "";
					array8[1] = "光标颜色";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 11;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 26)
				{
					flag2 = true;
					num = 240;
					num3 = 60;
					num4 = 3;
					array8[0] = "";
					array8[1] = "音量";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 11;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 28)
				{
					Main.caveParrallax = 1f - (float)this.bgScroll / 500f;
					flag3 = true;
					num = 240;
					num3 = 60;
					num4 = 3;
					array8[0] = "";
					array8[1] = "平行视差";
					array[1] = true;
					array3[2] = 170;
					array3[1] = 10;
					array8[2] = "返回";
					if (this.selectedMenu == 2)
					{
						Main.menuMode = 1111;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				else if (Main.menuMode == 27)
				{
					num = 176;
					num3 = 28;
					num4 = 14;
					string[] array11 = new string[]
					{
						Main.cUp,
						Main.cDown,
						Main.cLeft,
						Main.cRight,
						Main.cJump,
						Main.cThrowItem,
						Main.cInv,
						Main.cHeal,
						Main.cMana,
						Main.cBuff,
						Main.cHook,
						Main.cTorch
					};
					if (this.setKey >= 0)
					{
						array11[this.setKey] = "_";
					}
					array8[0] = "上            " + array11[0];
					array8[1] = "下            " + array11[1];
					array8[2] = "左            " + array11[2];
					array8[3] = "右            " + array11[3];
					array8[4] = "跳跃          " + array11[4];
					array8[5] = "丢弃          " + array11[5];
					array8[6] = "背包          " + array11[6];
					array8[7] = "快捷治疗      " + array11[7];
					array8[8] = "快捷回魔      " + array11[8];
					array8[9] = "快捷BUFF      " + array11[9];
					array8[10] = "抓钩          " + array11[10];
					array8[11] = "自动选择      " + array11[11];
					for (int num20 = 0; num20 < 12; num20++)
					{
						array7[num20] = true;
						array6[num20] = 0.55f;
						array4[num20] = -80;
					}
					array6[12] = 0.8f;
					array6[13] = 0.8f;
					array3[12] = 6;
					array8[12] = "   恢复默认按键";
					array3[13] = 16;
					array8[13] = "返回";
					if (this.selectedMenu == 13)
					{
						Main.menuMode = 11;
						Main.PlaySound(11, -1, -1, 1);
					}
					else if (this.selectedMenu == 12)
					{
						Main.cUp = "W";
						Main.cDown = "S";
						Main.cLeft = "A";
						Main.cRight = "D";
						Main.cJump = "Space";
						Main.cThrowItem = "T";
						Main.cInv = "Escape";
						Main.cHeal = "H";
						Main.cMana = "M";
						Main.cBuff = "B";
						Main.cHook = "E";
						Main.cTorch = "LeftShift";
						this.setKey = -1;
						Main.PlaySound(11, -1, -1, 1);
					}
					else if (this.selectedMenu >= 0)
					{
						this.setKey = this.selectedMenu;
					}
					if (this.setKey >= 0)
					{
						Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.keyState.GetPressedKeys();
						if (pressedKeys.Length > 0)
						{
							string a2 = string.Concat(pressedKeys[0]);
							if (a2 != "None")
							{
								if (this.setKey == 0)
								{
									Main.cUp = a2;
								}
								if (this.setKey == 1)
								{
									Main.cDown = a2;
								}
								if (this.setKey == 2)
								{
									Main.cLeft = a2;
								}
								if (this.setKey == 3)
								{
									Main.cRight = a2;
								}
								if (this.setKey == 4)
								{
									Main.cJump = a2;
								}
								if (this.setKey == 5)
								{
									Main.cThrowItem = a2;
								}
								if (this.setKey == 6)
								{
									Main.cInv = a2;
								}
								if (this.setKey == 7)
								{
									Main.cHeal = a2;
								}
								if (this.setKey == 8)
								{
									Main.cMana = a2;
								}
								if (this.setKey == 9)
								{
									Main.cBuff = a2;
								}
								if (this.setKey == 10)
								{
									Main.cHook = a2;
								}
								if (this.setKey == 11)
								{
									Main.cTorch = a2;
								}
								this.setKey = -1;
							}
						}
					}
				}
				else if (Main.menuMode == 12)
				{
					Main.menuServer = false;
					array8[0] = "加入";
					array8[1] = "   建主机并加入";
					array8[2] = "返回";
					if (this.selectedMenu == 0)
					{
						Main.LoadPlayers();
						Main.menuMultiplayer = true;
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1;
					}
					else if (this.selectedMenu == 1)
					{
						Main.LoadPlayers();
						Main.PlaySound(10, -1, -1, 1);
						Main.menuMode = 1;
						Main.menuMultiplayer = true;
						Main.menuServer = true;
					}
					if (this.selectedMenu == 2)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
					}
					num4 = 3;
				}
				else if (Main.menuMode == 13)
				{
					string a3 = Main.getIP;
					Main.getIP = Main.GetInputText(Main.getIP);
					if (a3 != Main.getIP)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "    输入服务器IP地址:";
					array2[9] = true;
					if (Main.getIP != "")
					{
						if (Main.getIP.Substring(0, 1) == " ")
						{
							Main.getIP = "";
						}
						for (int num21 = 0; num21 < Main.getIP.Length; num21++)
						{
							if (Main.getIP != " ")
							{
								array2[9] = false;
							}
						}
					}
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Main.getIP;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[9] = 44;
					array3[10] = 64;
					array8[9] = "接受";
					array8[10] = "返回";
					num4 = 11;
					num = 180;
					num3 = 30;
					array3[1] = 19;
					for (int num22 = 2; num22 < 9; num22++)
					{
						int num23 = num22 - 2;
						if (Main.recentWorld[num23] != null && Main.recentWorld[num23] != "")
						{
							array8[num22] = string.Concat(new object[]
							{
								Main.recentWorld[num23],
								" (",
								Main.recentIP[num23],
								":",
								Main.recentPort[num23],
								")"
							});
						}
						else
						{
							array8[num22] = "";
							array[num22] = true;
						}
						array6[num22] = 0.6f;
						array3[num22] = 40;
					}
					if (this.selectedMenu >= 2 && this.selectedMenu < 9)
					{
						Main.autoPass = false;
						int num24 = this.selectedMenu - 2;
						Netplay.serverPort = Main.recentPort[num24];
						Main.getIP = Main.recentIP[num24];
						if (Netplay.SetIP(Main.getIP))
						{
							Main.menuMode = 10;
							Netplay.StartClient();
						}
						else if (Netplay.SetIP2(Main.getIP))
						{
							Main.menuMode = 10;
							Netplay.StartClient();
						}
					}
					if (this.selectedMenu == 10)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
					if (this.selectedMenu == 9 || (!array2[2] && Main.inputTextEnter))
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.menuMode = 131;
					}
				}
				else if (Main.menuMode == 131)
				{
					int num25 = 7777;
					string a4 = Main.getPort;
					Main.getPort = Main.GetInputText(Main.getPort);
					if (a4 != Main.getPort)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "   输入服务器端口:";
					array2[2] = true;
					if (Main.getPort != "")
					{
						bool flag5 = false;
						try
						{
							num25 = Convert.ToInt32(Main.getPort);
							if (num25 > 0 && num25 <= 65535)
							{
								flag5 = true;
							}
						}
						catch
						{
						}
						if (flag5)
						{
							array2[2] = false;
						}
					}
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Main.getPort;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[1] = -20;
					array3[2] = 20;
					array8[2] = "接受";
					array8[3] = "返回";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 1;
					}
					if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
					{
						Netplay.serverPort = num25;
						Main.autoPass = false;
						if (Netplay.SetIP(Main.getIP))
						{
							Main.menuMode = 10;
							Netplay.StartClient();
						}
						else if (Netplay.SetIP2(Main.getIP))
						{
							Main.menuMode = 10;
							Netplay.StartClient();
						}
					}
				}
				else if (Main.menuMode == 16)
				{
					num = 200;
					num3 = 60;
					array3[1] = 30;
					array3[2] = 30;
					array3[3] = 30;
					array3[4] = 70;
					array8[0] = "选择世界尺寸:";
					array[0] = true;
					array8[1] = "小型";
					array8[2] = "中等";
					array8[3] = "大型";
					array8[4] = "返回";
					num4 = 5;
					if (this.selectedMenu == 4)
					{
						Main.menuMode = 6;
						Main.PlaySound(11, -1, -1, 1);
					}
					else if (this.selectedMenu > 0)
					{
						if (this.selectedMenu == 1)
						{
							Main.maxTilesX = 4200;
							Main.maxTilesY = 1200;
						}
						else if (this.selectedMenu == 2)
						{
							Main.maxTilesX = 6400;
							Main.maxTilesY = 1800;
						}
						else
						{
							Main.maxTilesX = 8400;
							Main.maxTilesY = 2400;
						}
						Main.menuMode = 7;
						Main.PlaySound(10, -1, -1, 1);
						WorldGen.setWorldSize();
					}
				}
			}
			IL_43DD:
			if (Main.menuMode != num5)
			{
				num4 = 0;
				for (int num26 = 0; num26 < Main.maxMenuItems; num26++)
				{
					this.menuItemScale[num26] = 0.8f;
				}
			}
			int num27 = this.focusMenu;
			this.selectedMenu = -1;
			this.selectedMenu2 = -1;
			this.focusMenu = -1;
			Vector2 origin;
			for (int num28 = 0; num28 < num4; num28++)
			{
				if (array8[num28] != null)
				{
					if (flag)
					{
						string text = "";
						for (int num29 = 0; num29 < 6; num29++)
						{
							int num30 = num9;
							int num31 = 370 + Main.screenWidth / 2 - 400;
							if (num29 == 0)
							{
								text = "红色:";
							}
							if (num29 == 1)
							{
								text = "绿色:";
								num30 += 30;
							}
							if (num29 == 2)
							{
								text = "蓝色:";
								num30 += 60;
							}
							if (num29 == 3)
							{
								text = string.Concat(this.selColor.R);
								num31 += 90;
							}
							if (num29 == 4)
							{
								text = string.Concat(this.selColor.G);
								num31 += 90;
								num30 += 30;
							}
							if (num29 == 5)
							{
								text = string.Concat(this.selColor.B);
								num31 += 90;
								num30 += 60;
							}
							for (int num32 = 0; num32 < 5; num32++)
							{
								Microsoft.Xna.Framework.Color color4 = Microsoft.Xna.Framework.Color.Black;
								if (num32 == 4)
								{
									color4 = color;
									color4.R = (byte)((255 + color4.R) / 2);
									color4.G = (byte)((255 + color4.R) / 2);
									color4.B = (byte)((255 + color4.R) / 2);
								}
								int num33 = 255;
								int num34 = (int)color4.R - (255 - num33);
								if (num34 < 0)
								{
									num34 = 0;
								}
								color4 = new Microsoft.Xna.Framework.Color((int)((byte)num34), (int)((byte)num34), (int)((byte)num34), (int)((byte)num33));
								int num35 = 0;
								int num36 = 0;
								if (num32 == 0)
								{
									num35 = -2;
								}
								if (num32 == 1)
								{
									num35 = 2;
								}
								if (num32 == 2)
								{
									num36 = -2;
								}
								if (num32 == 3)
								{
									num36 = 2;
								}
								SpriteBatch spriteBatch = this.spriteBatch;
								SpriteFontX spriteFont = Main.fontDeathText;
								string text2 = text;
								Vector2 position = new Vector2((float)(num31 + num35), (float)(num30 + num36));
								Microsoft.Xna.Framework.Color color5 = color4;
								float rotation = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont, text2, position, color5, rotation, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag6 = false;
						for (int num37 = 0; num37 < 2; num37++)
						{
							for (int num38 = 0; num38 < 3; num38++)
							{
								int num39 = num9 + num38 * 30 - 12;
								int num40 = 360 + Main.screenWidth / 2 - 400;
								float scale = 0.9f;
								if (num37 == 0)
								{
									num40 -= 70;
									num39 += 2;
								}
								else
								{
									num40 -= 40;
								}
								text = "-";
								if (num37 == 1)
								{
									text = "+";
								}
								Vector2 vector3 = new Vector2(24f, 24f);
								int num41 = 142;
								if (Main.mouseX > num40 && (float)Main.mouseX < (float)num40 + vector3.X && Main.mouseY > num39 + 13 && (float)Main.mouseY < (float)(num39 + 13) + vector3.Y)
								{
									if (this.focusColor != (num37 + 1) * (num38 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num37 + 1) * (num38 + 10);
									flag6 = true;
									num41 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num42 = num37;
											if (num37 == 0)
											{
												num42 = -1;
												if (this.selColor.R + this.selColor.G + this.selColor.B <= 150)
												{
													num42 = 0;
												}
											}
											if (num38 == 0 && (int)this.selColor.R + num42 >= 0 && (int)this.selColor.R + num42 <= 255)
											{
												this.selColor.R = (byte)((int)this.selColor.R + num42);
											}
											if (num38 == 1 && (int)this.selColor.G + num42 >= 0 && (int)this.selColor.G + num42 <= 255)
											{
												this.selColor.G = (byte)((int)this.selColor.G + num42);
											}
											if (num38 == 2 && (int)this.selColor.B + num42 >= 0 && (int)this.selColor.B + num42 <= 255)
											{
												this.selColor.B = (byte)((int)this.selColor.B + num42);
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num43 = 0; num43 < 5; num43++)
								{
									Microsoft.Xna.Framework.Color color6 = Microsoft.Xna.Framework.Color.Black;
									if (num43 == 4)
									{
										color6 = color;
										color6.R = (byte)((255 + color6.R) / 2);
										color6.G = (byte)((255 + color6.R) / 2);
										color6.B = (byte)((255 + color6.R) / 2);
									}
									int num44 = (int)color6.R - (255 - num41);
									if (num44 < 0)
									{
										num44 = 0;
									}
									color6 = new Microsoft.Xna.Framework.Color((int)((byte)num44), (int)((byte)num44), (int)((byte)num44), (int)((byte)num41));
									int num45 = 0;
									int num46 = 0;
									if (num43 == 0)
									{
										num45 = -2;
									}
									if (num43 == 1)
									{
										num45 = 2;
									}
									if (num43 == 2)
									{
										num46 = -2;
									}
									if (num43 == 3)
									{
										num46 = 2;
									}
									SpriteBatch spriteBatch2 = this.spriteBatch;
									SpriteFontX spriteFont2 = Main.fontDeathText;
									string text3 = text;
									Vector2 position2 = new Vector2((float)(num40 + num45), (float)(num39 + num46));
									Microsoft.Xna.Framework.Color color7 = color6;
									float rotation2 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont2, text3, position2, color7, rotation2, origin, scale, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag6)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					if (flag3)
					{
						int num47 = 400;
						string text4 = "";
						for (int num48 = 0; num48 < 4; num48++)
						{
							int num49 = num47;
							int num50 = 370 + Main.screenWidth / 2 - 400;
							if (num48 == 0)
							{
								text4 = "平行视差: " + this.bgScroll;
							}
							for (int num51 = 0; num51 < 5; num51++)
							{
								Microsoft.Xna.Framework.Color color8 = Microsoft.Xna.Framework.Color.Black;
								if (num51 == 4)
								{
									color8 = color;
									color8.R = (byte)((255 + color8.R) / 2);
									color8.G = (byte)((255 + color8.R) / 2);
									color8.B = (byte)((255 + color8.R) / 2);
								}
								int num52 = 255;
								int num53 = (int)color8.R - (255 - num52);
								if (num53 < 0)
								{
									num53 = 0;
								}
								color8 = new Microsoft.Xna.Framework.Color((int)((byte)num53), (int)((byte)num53), (int)((byte)num53), (int)((byte)num52));
								int num54 = 0;
								int num55 = 0;
								if (num51 == 0)
								{
									num54 = -2;
								}
								if (num51 == 1)
								{
									num54 = 2;
								}
								if (num51 == 2)
								{
									num55 = -2;
								}
								if (num51 == 3)
								{
									num55 = 2;
								}
								SpriteBatch spriteBatch3 = this.spriteBatch;
								SpriteFontX spriteFont3 = Main.fontDeathText;
								string text5 = text4;
								Vector2 position3 = new Vector2((float)(num50 + num54), (float)(num49 + num55));
								Microsoft.Xna.Framework.Color color9 = color8;
								float rotation3 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont3, text5, position3, color9, rotation3, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag7 = false;
						for (int num56 = 0; num56 < 2; num56++)
						{
							for (int num57 = 0; num57 < 1; num57++)
							{
								int num58 = num47 + num57 * 30 - 12;
								int num59 = 360 + Main.screenWidth / 2 - 400;
								float scale2 = 0.9f;
								if (num56 == 0)
								{
									num59 -= 70;
									num58 += 2;
								}
								else
								{
									num59 -= 40;
								}
								text4 = "-";
								if (num56 == 1)
								{
									text4 = "+";
								}
								Vector2 vector4 = new Vector2(24f, 24f);
								int num60 = 142;
								if (Main.mouseX > num59 && (float)Main.mouseX < (float)num59 + vector4.X && Main.mouseY > num58 + 13 && (float)Main.mouseY < (float)(num58 + 13) + vector4.Y)
								{
									if (this.focusColor != (num56 + 1) * (num57 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num56 + 1) * (num57 + 10);
									flag7 = true;
									num60 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num61 = (num56 == 0) ? -1 : num56;
											if (num57 == 0)
											{
												this.bgScroll += num61;
												if (this.bgScroll > 100)
												{
													this.bgScroll = 100;
												}
												if (this.bgScroll < 0)
												{
													this.bgScroll = 0;
												}
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num62 = 0; num62 < 5; num62++)
								{
									Microsoft.Xna.Framework.Color color10 = Microsoft.Xna.Framework.Color.Black;
									if (num62 == 4)
									{
										color10 = color;
										color10.R = (byte)((255 + color10.R) / 2);
										color10.G = (byte)((255 + color10.R) / 2);
										color10.B = (byte)((255 + color10.R) / 2);
									}
									int num63 = (int)color10.R - (255 - num60);
									if (num63 < 0)
									{
										num63 = 0;
									}
									color10 = new Microsoft.Xna.Framework.Color((int)((byte)num63), (int)((byte)num63), (int)((byte)num63), (int)((byte)num60));
									int num64 = 0;
									int num65 = 0;
									if (num62 == 0)
									{
										num64 = -2;
									}
									if (num62 == 1)
									{
										num64 = 2;
									}
									if (num62 == 2)
									{
										num65 = -2;
									}
									if (num62 == 3)
									{
										num65 = 2;
									}
									SpriteBatch spriteBatch4 = this.spriteBatch;
									SpriteFontX spriteFont4 = Main.fontDeathText;
									string text6 = text4;
									Vector2 position4 = new Vector2((float)(num59 + num64), (float)(num58 + num65));
									Microsoft.Xna.Framework.Color color11 = color10;
									float rotation4 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont4, text6, position4, color11, rotation4, origin, scale2, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag7)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					if (flag2)
					{
						int num66 = 400;
						string text7 = "";
						for (int num67 = 0; num67 < 4; num67++)
						{
							int num68 = num66;
							int num69 = 370 + Main.screenWidth / 2 - 400;
							if (num67 == 0)
							{
								text7 = "音效:";
							}
							if (num67 == 1)
							{
								text7 = "音乐:";
								num68 += 30;
							}
							if (num67 == 2)
							{
								text7 = Math.Round((double)(Main.soundVolume * 100f)) + "%";
								num69 += 90;
							}
							if (num67 == 3)
							{
								text7 = Math.Round((double)(Main.musicVolume * 100f)) + "%";
								num69 += 90;
								num68 += 30;
							}
							for (int num70 = 0; num70 < 5; num70++)
							{
								Microsoft.Xna.Framework.Color color12 = Microsoft.Xna.Framework.Color.Black;
								if (num70 == 4)
								{
									color12 = color;
									color12.R = (byte)((255 + color12.R) / 2);
									color12.G = (byte)((255 + color12.R) / 2);
									color12.B = (byte)((255 + color12.R) / 2);
								}
								int num71 = 255;
								int num72 = (int)color12.R - (255 - num71);
								if (num72 < 0)
								{
									num72 = 0;
								}
								color12 = new Microsoft.Xna.Framework.Color((int)((byte)num72), (int)((byte)num72), (int)((byte)num72), (int)((byte)num71));
								int num73 = 0;
								int num74 = 0;
								if (num70 == 0)
								{
									num73 = -2;
								}
								if (num70 == 1)
								{
									num73 = 2;
								}
								if (num70 == 2)
								{
									num74 = -2;
								}
								if (num70 == 3)
								{
									num74 = 2;
								}
								SpriteBatch spriteBatch5 = this.spriteBatch;
								SpriteFontX spriteFont5 = Main.fontDeathText;
								string text8 = text7;
								Vector2 position5 = new Vector2((float)(num69 + num73), (float)(num68 + num74));
								Microsoft.Xna.Framework.Color color13 = color12;
								float rotation5 = 0f;
								origin = default(Vector2);
								this.DStoDSX(spriteFont5, text8, position5, color13, rotation5, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag8 = false;
						for (int num75 = 0; num75 < 2; num75++)
						{
							for (int num76 = 0; num76 < 2; num76++)
							{
								int num77 = num66 + num76 * 30 - 12;
								int num78 = 360 + Main.screenWidth / 2 - 400;
								float scale3 = 0.9f;
								if (num75 == 0)
								{
									num78 -= 70;
									num77 += 2;
								}
								else
								{
									num78 -= 40;
								}
								text7 = "-";
								if (num75 == 1)
								{
									text7 = "+";
								}
								Vector2 vector5 = new Vector2(24f, 24f);
								int num79 = 142;
								if (Main.mouseX > num78 && (float)Main.mouseX < (float)num78 + vector5.X && Main.mouseY > num77 + 13 && (float)Main.mouseY < (float)(num77 + 13) + vector5.Y)
								{
									if (this.focusColor != (num75 + 1) * (num76 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num75 + 1) * (num76 + 10);
									flag8 = true;
									num79 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num80 = (num75 == 0) ? -1 : num75;
											if (num76 == 0)
											{
												Main.soundVolume += (float)num80 * 0.01f;
												if (Main.soundVolume > 1f)
												{
													Main.soundVolume = 1f;
												}
												if (Main.soundVolume < 0f)
												{
													Main.soundVolume = 0f;
												}
											}
											if (num76 == 1)
											{
												Main.musicVolume += (float)num80 * 0.01f;
												if (Main.musicVolume > 1f)
												{
													Main.musicVolume = 1f;
												}
												if (Main.musicVolume < 0f)
												{
													Main.musicVolume = 0f;
												}
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num81 = 0; num81 < 5; num81++)
								{
									Microsoft.Xna.Framework.Color color14 = Microsoft.Xna.Framework.Color.Black;
									if (num81 == 4)
									{
										color14 = color;
										color14.R = (byte)((255 + color14.R) / 2);
										color14.G = (byte)((255 + color14.R) / 2);
										color14.B = (byte)((255 + color14.R) / 2);
									}
									int num82 = (int)color14.R - (255 - num79);
									if (num82 < 0)
									{
										num82 = 0;
									}
									color14 = new Microsoft.Xna.Framework.Color((int)((byte)num82), (int)((byte)num82), (int)((byte)num82), (int)((byte)num79));
									int num83 = 0;
									int num84 = 0;
									if (num81 == 0)
									{
										num83 = -2;
									}
									if (num81 == 1)
									{
										num83 = 2;
									}
									if (num81 == 2)
									{
										num84 = -2;
									}
									if (num81 == 3)
									{
										num84 = 2;
									}
									SpriteBatch spriteBatch6 = this.spriteBatch;
									SpriteFontX spriteFont6 = Main.fontDeathText;
									string text9 = text7;
									Vector2 position6 = new Vector2((float)(num78 + num83), (float)(num77 + num84));
									Microsoft.Xna.Framework.Color color15 = color14;
									float rotation6 = 0f;
									origin = default(Vector2);
									this.DStoDSX(spriteFont6, text9, position6, color15, rotation6, origin, scale3, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag8)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					for (int num85 = 0; num85 < 5; num85++)
					{
						Microsoft.Xna.Framework.Color color16 = Microsoft.Xna.Framework.Color.Black;
						if (num85 == 4)
						{
							color16 = color;
							if (array5[num28] == 2)
							{
								color16 = Main.hcColor;
							}
							else if (array5[num28] == 1)
							{
								color16 = Main.mcColor;
							}
							color16.R = (byte)((255 + color16.R) / 2);
							color16.G = (byte)((255 + color16.G) / 2);
							color16.B = (byte)((255 + color16.B) / 2);
						}
						int num86 = (int)(255f * (this.menuItemScale[num28] * 2f - 1f));
						if (array[num28])
						{
							num86 = 255;
						}
						int num87 = (int)color16.R - (255 - num86);
						if (num87 < 0)
						{
							num87 = 0;
						}
						int num88 = (int)color16.G - (255 - num86);
						if (num88 < 0)
						{
							num88 = 0;
						}
						int num89 = (int)color16.B - (255 - num86);
						if (num89 < 0)
						{
							num89 = 0;
						}
						color16 = new Microsoft.Xna.Framework.Color((int)((byte)num87), (int)((byte)num88), (int)((byte)num89), (int)((byte)num86));
						int num90 = 0;
						int num91 = 0;
						if (num85 == 0)
						{
							num90 = -2;
						}
						if (num85 == 1)
						{
							num90 = 2;
						}
						if (num85 == 2)
						{
							num91 = -2;
						}
						if (num85 == 3)
						{
							num91 = 2;
						}
						Vector2 origin2 = Main.fontDeathText.MeasureString(array8[num28]);
						origin2.X *= 0.5f;
						origin2.Y *= 0.5f;
						float num92 = this.menuItemScale[num28];
						if (Main.menuMode == 15 && num28 == 0)
						{
							num92 *= 0.35f;
						}
						else if (Main.netMode == 2)
						{
							num92 *= 0.5f;
						}
						num92 *= array6[num28];
						if (!array7[num28])
						{
							this.DStoDSX(Main.fontDeathText, array8[num28], new Vector2((float)(num2 + num90 + array4[num28]), (float)(num + num3 * num28 + num91) + origin2.Y * array6[num28] + (float)array3[num28]), color16, 0f, origin2, num92, SpriteEffects.None, 0f);
						}
						else
						{
							this.DStoDSX(Main.fontDeathText, array8[num28], new Vector2((float)(num2 + num90 + array4[num28]), (float)(num + num3 * num28 + num91) + origin2.Y * array6[num28] + (float)array3[num28]), color16, 0f, new Vector2(0f, origin2.Y), num92, SpriteEffects.None, 0f);
						}
					}
					if (!array7[num28])
					{
						if ((float)Main.mouseX > (float)num2 - (float)(array8[num28].Length * 10) * array6[num28] + (float)array4[num28] && (float)Main.mouseX < (float)num2 + (float)(array8[num28].Length * 10) * array6[num28] + (float)array4[num28] && Main.mouseY > num + num3 * num28 + array3[num28] && (float)Main.mouseY < (float)(num + num3 * num28 + array3[num28]) + 50f * array6[num28] && Main.hasFocus)
						{
							this.focusMenu = num28;
							if (array[num28] || array2[num28])
							{
								this.focusMenu = -1;
							}
							else
							{
								if (num27 != this.focusMenu)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									this.selectedMenu = num28;
								}
								if (Main.mouseRightRelease && Main.mouseRight)
								{
									this.selectedMenu2 = num28;
								}
							}
						}
					}
					else if (Main.mouseX > num2 + array4[num28] && (float)Main.mouseX < (float)num2 + (float)(array8[num28].Length * 20) * array6[num28] + (float)array4[num28] && Main.mouseY > num + num3 * num28 + array3[num28] && (float)Main.mouseY < (float)(num + num3 * num28 + array3[num28]) + 50f * array6[num28] && Main.hasFocus)
					{
						this.focusMenu = num28;
						if (array[num28] || array2[num28])
						{
							this.focusMenu = -1;
						}
						else
						{
							if (num27 != this.focusMenu)
							{
								Main.PlaySound(12, -1, -1, 1);
							}
							if (Main.mouseLeftRelease && Main.mouseLeft)
							{
								this.selectedMenu = num28;
							}
							if (Main.mouseRightRelease && Main.mouseRight)
							{
								this.selectedMenu2 = num28;
							}
						}
					}
				}
			}
			for (int num93 = 0; num93 < Main.maxMenuItems; num93++)
			{
				if (num93 == this.focusMenu)
				{
					if (this.menuItemScale[num93] < 1f)
					{
						this.menuItemScale[num93] += 0.02f;
					}
					if (this.menuItemScale[num93] > 1f)
					{
						this.menuItemScale[num93] = 1f;
					}
				}
				else if ((double)this.menuItemScale[num93] > 0.8)
				{
					this.menuItemScale[num93] -= 0.02f;
				}
			}
			if (num6 >= 0)
			{
				Main.loadPlayer[num6].PlayerFrame();
				Main.loadPlayer[num6].position.X = (float)num7 + Main.screenPosition.X;
				Main.loadPlayer[num6].position.Y = (float)num8 + Main.screenPosition.Y;
				this.DrawPlayer(Main.loadPlayer[num6]);
			}
			for (int num94 = 0; num94 < 5; num94++)
			{
				Microsoft.Xna.Framework.Color color17 = Microsoft.Xna.Framework.Color.Black;
				if (num94 == 4)
				{
					color17 = color;
					color17.R = (byte)((255 + color17.R) / 2);
					color17.G = (byte)((255 + color17.R) / 2);
					color17.B = (byte)((255 + color17.R) / 2);
				}
				color17.A = (byte)((float)color17.A * 0.3f);
				int num95 = 0;
				int num96 = 0;
				if (num94 == 0)
				{
					num95 = -2;
				}
				if (num94 == 1)
				{
					num95 = 2;
				}
				if (num94 == 2)
				{
					num96 = -2;
				}
				if (num94 == 3)
				{
					num96 = 2;
				}
				string text10 = "Copyright © 2011 Re-Logic";
				Vector2 origin3 = Main.fontMouseText.MeasureString(text10);
				origin3.X *= 0.5f;
				origin3.Y *= 0.5f;
				this.DStoDSX(Main.fontMouseText, text10, new Vector2((float)Main.screenWidth - origin3.X + (float)num95 - 10f, (float)Main.screenHeight - origin3.Y + (float)num96 - 2f), color17, 0f, origin3, 1f, SpriteEffects.None, 0f);
			}
			for (int num97 = 0; num97 < 5; num97++)
			{
				Microsoft.Xna.Framework.Color color18 = Microsoft.Xna.Framework.Color.Black;
				if (num97 == 4)
				{
					color18 = color;
					color18.R = (byte)((255 + color18.R) / 2);
					color18.G = (byte)((255 + color18.R) / 2);
					color18.B = (byte)((255 + color18.R) / 2);
				}
				color18.A = (byte)((float)color18.A * 0.3f);
				int num98 = 0;
				int num99 = 0;
				if (num97 == 0)
				{
					num98 = -2;
				}
				if (num97 == 1)
				{
					num98 = 2;
				}
				if (num97 == 2)
				{
					num99 = -2;
				}
				if (num97 == 3)
				{
					num99 = 2;
				}
				Vector2 origin4 = Main.fontMouseText.MeasureString(Main.versionNumber);
				origin4.X *= 0.5f;
				origin4.Y *= 0.5f;
				this.DStoDSX(Main.fontMouseText, Main.versionNumber, new Vector2(origin4.X + (float)num98 + 10f, (float)Main.screenHeight - origin4.Y + (float)num99 - 2f), color18, 0f, origin4, 1f, SpriteEffects.None, 0f);
			}
			SpriteBatch spriteBatch7 = this.spriteBatch;
			Texture2D texture = Main.cursorTexture;
			Vector2 position7 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
			Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Microsoft.Xna.Framework.Color color19 = new Microsoft.Xna.Framework.Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
			float rotation7 = 0f;
			origin = default(Vector2);
			spriteBatch7.Draw(texture, position7, sourceRectangle, color19, rotation7, origin, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
			SpriteBatch spriteBatch8 = this.spriteBatch;
			Texture2D texture2 = Main.cursorTexture;
			Vector2 position8 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Microsoft.Xna.Framework.Color color20 = Main.cursorColor;
			float rotation8 = 0f;
			origin = default(Vector2);
			spriteBatch8.Draw(texture2, position8, sourceRectangle2, color20, rotation8, origin, Main.cursorScale, SpriteEffects.None, 0f);
			if (Main.fadeCounter > 0)
			{
				Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
				Main.fadeCounter--;
				float num100 = (float)Main.fadeCounter / 75f * 255f;
				byte b2 = (byte)num100;
				white = new Microsoft.Xna.Framework.Color((int)b2, (int)b2, (int)b2, (int)b2);
				this.spriteBatch.Draw(Main.fadeTexture, new Microsoft.Xna.Framework.Rectangle(0, 0, Main.screenWidth, Main.screenHeight), white);
			}
			this.spriteBatch.End();
			if (Main.mouseLeft)
			{
				Main.mouseLeftRelease = false;
			}
			else
			{
				Main.mouseLeftRelease = true;
			}
			if (Main.mouseRight)
			{
				Main.mouseRightRelease = false;
			}
			else
			{
				Main.mouseRightRelease = true;
			}
		}

		public static void CursorColor()
		{
			Main.cursorAlpha += (float)Main.cursorColorDirection * 0.015f;
			if (Main.cursorAlpha >= 1f)
			{
				Main.cursorAlpha = 1f;
				Main.cursorColorDirection = -1;
			}
			if ((double)Main.cursorAlpha <= 0.6)
			{
				Main.cursorAlpha = 0.6f;
				Main.cursorColorDirection = 1;
			}
			float num = Main.cursorAlpha * 0.3f + 0.7f;
			byte r = (byte)((float)Main.mouseColor.R * Main.cursorAlpha);
			byte g = (byte)((float)Main.mouseColor.G * Main.cursorAlpha);
			byte b = (byte)((float)Main.mouseColor.B * Main.cursorAlpha);
			byte a = (byte)(255f * num);
			Main.cursorColor = new Microsoft.Xna.Framework.Color((int)r, (int)g, (int)b, (int)a);
			Main.cursorScale = Main.cursorAlpha * 0.3f + 0.7f + 0.1f;
		}

		protected void DrawSplash(GameTime gameTime)
		{
			base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
			base.Draw(gameTime);
			this.spriteBatch.Begin();
			this.splashCounter++;
			Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
			byte b = 0;
			if (this.splashCounter <= 75)
			{
				float num = (float)this.splashCounter / 75f * 255f;
				b = (byte)num;
			}
			else if (this.splashCounter <= 125)
			{
				b = 255;
			}
			else if (this.splashCounter <= 200)
			{
				int num2 = 125 - this.splashCounter;
				float num3 = (float)num2 / 75f * 255f;
				b = (byte)num3;
			}
			else
			{
				Main.showSplash = false;
				Main.fadeCounter = 75;
			}
			white = new Microsoft.Xna.Framework.Color((int)b, (int)b, (int)b, (int)b);
			this.spriteBatch.Draw(Main.loTexture[Main.lo], new Microsoft.Xna.Framework.Rectangle(0, 0, Main.screenWidth, Main.screenHeight), white);
			this.spriteBatch.End();
		}

		protected void DrawBackground()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 140f * Main.gfxQuality);
			int num2 = (int)(200f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			int num3 = 96;
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			float num4 = 0.9f;
			float num5 = num4;
			float num6 = num4;
			float num7 = num4;
			float num8 = 0f;
			if (Main.holyTiles > Main.evilTiles)
			{
				num8 = (float)Main.holyTiles / 800f;
			}
			else if (Main.evilTiles > Main.holyTiles)
			{
				num8 = (float)Main.evilTiles / 800f;
			}
			if (num8 > 1f)
			{
				num8 = 1f;
			}
			if (num8 < 0f)
			{
				num8 = 0f;
			}
			float num9 = (float)((double)Main.screenPosition.Y - Main.worldSurface * 16.0) / 300f;
			if (num9 < 0f)
			{
				num9 = 0f;
			}
			else if (num9 > 1f)
			{
				num9 = 1f;
			}
			float num10 = 1f * (1f - num9) + num5 * num9;
			Lighting.brightness = Lighting.defBrightness * (1f - num9) + 1f * num9;
			float num11 = (float)((double)(Main.screenPosition.Y - (float)(Main.screenHeight / 2) + 200f) - Main.rockLayer * 16.0) / 300f;
			if (num11 < 0f)
			{
				num11 = 0f;
			}
			else if (num11 > 1f)
			{
				num11 = 1f;
			}
			if (Main.evilTiles > 0)
			{
				num5 = 0.8f * num8 + num5 * (1f - num8);
				num6 = 0.75f * num8 + num6 * (1f - num8);
				num7 = 1.1f * num8 + num7 * (1f - num8);
			}
			else if (Main.holyTiles > 0)
			{
				num5 = 1f * num8 + num5 * (1f - num8);
				num6 = 0.7f * num8 + num6 * (1f - num8);
				num7 = 0.9f * num8 + num7 * (1f - num8);
			}
			num5 = 1f * (num10 - num11) + num5 * num11;
			num6 = 1f * (num10 - num11) + num6 * num11;
			num7 = 1f * (num10 - num11) + num7 * num11;
			Lighting.defBrightness = 1.2f * (1f - num11) + 1f * num11;
			this.bgParrallax = (double)Main.caveParrallax;
			this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
			this.bgLoops = Main.screenWidth / num3 + 2;
			this.bgTop = (int)((float)((int)Main.worldSurface * 16 - Main.backgroundHeight[1]) - Main.screenPosition.Y + 16f);
			for (int i = 0; i < this.bgLoops; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					float num12 = (float)this.bgStart + Main.screenPosition.X;
					num12 = -(float)Math.IEEERemainder((double)num12, 16.0);
					num12 = (float)Math.Round((double)num12);
					int num13 = (int)num12;
					if (num13 == -8)
					{
						num13 = 8;
					}
					float num14 = (float)(this.bgStart + num3 * i + j * 16 + 8);
					float num15 = (float)this.bgTop;
					Microsoft.Xna.Framework.Color color = Lighting.GetColor((int)((num14 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num15) / 16f));
					color.R = (byte)((float)color.R * num5);
					color.G = (byte)((float)color.G * num6);
					color.B = (byte)((float)color.B * num7);
					this.spriteBatch.Draw(Main.backgroundTexture[1], new Vector2((float)(this.bgStart + num3 * i + 16 * j + num13), (float)this.bgTop) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * j + num13 + 16, 0, 16, 16)), color);
				}
			}
			double num16 = (double)(Main.maxTilesY - 230);
			double num17 = (double)((int)((num16 - Main.worldSurface) / 6.0) * 6);
			num16 = Main.worldSurface + num17 - 5.0;
			bool flag = false;
			bool flag2 = false;
			this.bgTop = (int)((float)((int)Main.worldSurface * 16) - Main.screenPosition.Y + 16f);
			if (Main.worldSurface * 16.0 <= (double)(Main.screenPosition.Y + (float)Main.screenHeight + (float)Main.offScreenRange))
			{
				this.bgParrallax = (double)Main.caveParrallax;
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (Main.worldSurface * 16.0 < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[2]) - (double)Main.backgroundHeight[2]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				if (Main.rockLayer * 16.0 < (double)(Main.screenPosition.Y + 600f))
				{
					this.bgLoopsY = (int)(Main.rockLayer * 16.0 - (double)Main.screenPosition.Y + 600.0 - (double)this.bgStartY) / Main.backgroundHeight[2];
					flag2 = true;
				}
				float num18 = (float)this.bgStart + Main.screenPosition.X;
				num18 = -(float)Math.IEEERemainder((double)num18, 16.0);
				num18 = (float)Math.Round((double)num18);
				int num19 = (int)num18;
				if (num19 == -8)
				{
					num19 = 8;
				}
				for (int k = 0; k < this.bgLoops; k++)
				{
					for (int l = 0; l < this.bgLoopsY; l++)
					{
						for (int m = 0; m < 6; m++)
						{
							for (int n = 0; n < 6; n++)
							{
								float num20 = (float)(this.bgStartY + l * 96 + n * 16 + 8);
								float num21 = (float)(this.bgStart + num3 * k + m * 16 + 8);
								int num22 = (int)((num21 + Main.screenPosition.X) / 16f);
								int num23 = (int)((num20 + Main.screenPosition.Y) / 16f);
								Microsoft.Xna.Framework.Color color2 = Lighting.GetColor(num22, num23);
								if (Main.tile[num22, num23] == null)
								{
									Main.tile[num22, num23] = new Tile();
								}
								if (color2.R > 0 || color2.G > 0 || color2.B > 0)
								{
									if (((int)color2.R > num || (double)color2.G > (double)num * 1.1 || (double)color2.B > (double)num * 1.2) && !Main.tile[num22, num23].active)
									{
										if (Main.tile[num22, num23].wall != 0)
										{
											if (Main.tile[num22, num23].wall != 21)
											{
												goto IL_D13;
											}
										}
										try
										{
											for (int num24 = 0; num24 < 9; num24++)
											{
												int num25 = 0;
												int num26 = 0;
												int width = 4;
												int height = 4;
												Microsoft.Xna.Framework.Color color3 = color2;
												Microsoft.Xna.Framework.Color color4 = color2;
												if (num24 == 0 && !Main.tile[num22 - 1, num23 - 1].active)
												{
													color4 = Lighting.GetColor(num22 - 1, num23 - 1);
												}
												if (num24 == 1)
												{
													width = 8;
													num25 = 4;
													if (!Main.tile[num22, num23 - 1].active)
													{
														color4 = Lighting.GetColor(num22, num23 - 1);
													}
												}
												if (num24 == 2)
												{
													if (!Main.tile[num22 + 1, num23 - 1].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23 - 1);
													}
													if (Main.tile[num22 + 1, num23 - 1] == null)
													{
														Main.tile[num22 + 1, num23 - 1] = new Tile();
													}
													num25 = 12;
												}
												if (num24 == 3)
												{
													if (!Main.tile[num22 - 1, num23].active)
													{
														color4 = Lighting.GetColor(num22 - 1, num23);
													}
													height = 8;
													num26 = 4;
												}
												if (num24 == 4)
												{
													width = 8;
													height = 8;
													num25 = 4;
													num26 = 4;
												}
												if (num24 == 5)
												{
													num25 = 12;
													num26 = 4;
													height = 8;
													if (!Main.tile[num22 + 1, num23].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23);
													}
												}
												if (num24 == 6)
												{
													if (!Main.tile[num22 - 1, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22 - 1, num23 + 1);
													}
													num26 = 12;
												}
												if (num24 == 7)
												{
													width = 8;
													height = 4;
													num25 = 4;
													num26 = 12;
													if (!Main.tile[num22, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22, num23 + 1);
													}
												}
												if (num24 == 8)
												{
													if (!Main.tile[num22 + 1, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23 + 1);
													}
													num25 = 12;
													num26 = 12;
												}
												color3.R = (byte)((color2.R + color4.R) / 2);
												color3.G = (byte)((color2.G + color4.G) / 2);
												color3.B = (byte)((color2.B + color4.B) / 2);
												color3.R = (byte)((float)color3.R * num5);
												color3.G = (byte)((float)color3.G * num6);
												color3.B = (byte)((float)color3.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num25 + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n + num26)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * m + num25 + num19 + 16, 16 * n + num26, width, height)), color3);
											}
											goto IL_1119;
										}
										catch
										{
											color2.R = (byte)((float)color2.R * num5);
											color2.G = (byte)((float)color2.G * num6);
											color2.B = (byte)((float)color2.B * num7);
											this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
											goto IL_1119;
										}
									}
									IL_D13:
									if ((int)color2.R > num2 || (double)color2.G > (double)num2 * 1.1 || (double)color2.B > (double)num2 * 1.2)
									{
										for (int num27 = 0; num27 < 4; num27++)
										{
											int num28 = 0;
											int num29 = 0;
											Microsoft.Xna.Framework.Color color5 = color2;
											Microsoft.Xna.Framework.Color color6 = color2;
											if (num27 == 0)
											{
												if (Lighting.Brighter(num22, num23 - 1, num22 - 1, num23))
												{
													color6 = Lighting.GetColor(num22 - 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 - 1);
												}
											}
											if (num27 == 1)
											{
												if (Lighting.Brighter(num22, num23 - 1, num22 + 1, num23))
												{
													color6 = Lighting.GetColor(num22 + 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 - 1);
												}
												num28 = 8;
											}
											if (num27 == 2)
											{
												if (Lighting.Brighter(num22, num23 + 1, num22 - 1, num23))
												{
													color6 = Lighting.GetColor(num22 - 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 + 1);
												}
												num29 = 8;
											}
											if (num27 == 3)
											{
												if (Lighting.Brighter(num22, num23 + 1, num22 + 1, num23))
												{
													color6 = Lighting.GetColor(num22 + 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 + 1);
												}
												num28 = 8;
												num29 = 8;
											}
											color5.R = (byte)((color2.R + color6.R) / 2);
											color5.G = (byte)((color2.G + color6.G) / 2);
											color5.B = (byte)((color2.B + color6.B) / 2);
											color5.R = (byte)((float)color5.R * num5);
											color5.G = (byte)((float)color5.G * num6);
											color5.B = (byte)((float)color5.B * num7);
											this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num28 + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n + num29)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * m + num28 + num19 + 16, 16 * n + num29, 8, 8)), color5);
										}
									}
									else
									{
										color2.R = (byte)((float)color2.R * num5);
										color2.G = (byte)((float)color2.G * num6);
										color2.B = (byte)((float)color2.B * num7);
										this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
									}
								}
								else
								{
									color2.R = (byte)((float)color2.R * num5);
									color2.G = (byte)((float)color2.G * num6);
									color2.B = (byte)((float)color2.B * num7);
									this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
								}
								IL_1119:;
							}
						}
					}
				}
				if (flag2)
				{
					this.bgParrallax = (double)Main.caveParrallax;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
					this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
					this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
					if (this.bgTop > -32)
					{
						for (int num30 = 0; num30 < this.bgLoops; num30++)
						{
							for (int num31 = 0; num31 < 6; num31++)
							{
								float num32 = (float)(this.bgStart + num3 * num30 + num31 * 16 + 8);
								float num33 = (float)this.bgTop;
								Microsoft.Xna.Framework.Color color7 = Lighting.GetColor((int)((num32 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num33) / 16f));
								color7.R = (byte)((float)color7.R * num5);
								color7.G = (byte)((float)color7.G * num6);
								color7.B = (byte)((float)color7.B * num7);
								this.spriteBatch.Draw(Main.backgroundTexture[4], new Vector2((float)(this.bgStart + num3 * num30 + 16 * num31 + num19), (float)this.bgTop) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num31 + num19 + 16, 0, 16, 16)), color7);
							}
						}
					}
				}
			}
			this.bgTop = (int)((float)((int)Main.rockLayer * 16) - Main.screenPosition.Y + 16f + 600f - 8f);
			if (Main.rockLayer * 16.0 <= (double)(Main.screenPosition.Y + 600f))
			{
				this.bgParrallax = (double)Main.caveParrallax;
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (Main.rockLayer * 16.0 + (double)Main.screenHeight < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[3]) - (double)Main.backgroundHeight[3]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				if (num16 * 16.0 < (double)(Main.screenPosition.Y + 600f))
				{
					this.bgLoopsY = (int)(num16 * 16.0 - (double)Main.screenPosition.Y + 600.0 - (double)this.bgStartY) / Main.backgroundHeight[2];
					flag = true;
				}
				float num34 = (float)this.bgStart + Main.screenPosition.X;
				num34 = -(float)Math.IEEERemainder((double)num34, 16.0);
				num34 = (float)Math.Round((double)num34);
				int num35 = (int)num34;
				if (num35 == -8)
				{
					num35 = 8;
				}
				for (int num36 = 0; num36 < this.bgLoops; num36++)
				{
					for (int num37 = 0; num37 < this.bgLoopsY; num37++)
					{
						for (int num38 = 0; num38 < 6; num38++)
						{
							for (int num39 = 0; num39 < 6; num39++)
							{
								float num40 = (float)(this.bgStartY + num37 * 96 + num39 * 16 + 8);
								float num41 = (float)(this.bgStart + num3 * num36 + num38 * 16 + 8);
								int num42 = (int)((num41 + Main.screenPosition.X) / 16f);
								int num43 = (int)((num40 + Main.screenPosition.Y) / 16f);
								Microsoft.Xna.Framework.Color color8 = Lighting.GetColor(num42, num43);
								if (Main.tile[num42, num43] == null)
								{
									Main.tile[num42, num43] = new Tile();
								}
								bool flag3 = false;
								if (Main.caveParrallax != 0f)
								{
									if (Main.tile[num42 - 1, num43] == null)
									{
										Main.tile[num42 - 1, num43] = new Tile();
									}
									if (Main.tile[num42 + 1, num43] == null)
									{
										Main.tile[num42 + 1, num43] = new Tile();
									}
									if (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21 || Main.tile[num42 - 1, num43].wall == 0 || Main.tile[num42 - 1, num43].wall == 21 || Main.tile[num42 + 1, num43].wall == 0 || Main.tile[num42 + 1, num43].wall == 21)
									{
										flag3 = true;
									}
								}
								else if (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21)
								{
									flag3 = true;
								}
								if ((flag3 || color8.R == 0 || color8.G == 0 || color8.B == 0) && (color8.R > 0 || color8.G > 0 || color8.B > 0) && (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21 || Main.caveParrallax != 0f))
								{
									if (Lighting.lightMode < 2 && color8.R < 230 && color8.G < 230 && color8.B < 230)
									{
										if (((int)color8.R > num || (double)color8.G > (double)num * 1.1 || (double)color8.B > (double)num * 1.2) && !Main.tile[num42, num43].active)
										{
											for (int num44 = 0; num44 < 9; num44++)
											{
												int num45 = 0;
												int num46 = 0;
												int width2 = 4;
												int height2 = 4;
												Microsoft.Xna.Framework.Color color9 = color8;
												Microsoft.Xna.Framework.Color color10 = color8;
												if (num44 == 0 && !Main.tile[num42 - 1, num43 - 1].active)
												{
													color10 = Lighting.GetColor(num42 - 1, num43 - 1);
												}
												if (num44 == 1)
												{
													width2 = 8;
													num45 = 4;
													if (!Main.tile[num42, num43 - 1].active)
													{
														color10 = Lighting.GetColor(num42, num43 - 1);
													}
												}
												if (num44 == 2)
												{
													if (!Main.tile[num42 + 1, num43 - 1].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43 - 1);
													}
													num45 = 12;
												}
												if (num44 == 3)
												{
													if (!Main.tile[num42 - 1, num43].active)
													{
														color10 = Lighting.GetColor(num42 - 1, num43);
													}
													height2 = 8;
													num46 = 4;
												}
												if (num44 == 4)
												{
													width2 = 8;
													height2 = 8;
													num45 = 4;
													num46 = 4;
												}
												if (num44 == 5)
												{
													num45 = 12;
													num46 = 4;
													height2 = 8;
													if (!Main.tile[num42 + 1, num43].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43);
													}
												}
												if (num44 == 6)
												{
													if (!Main.tile[num42 - 1, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42 - 1, num43 + 1);
													}
													num46 = 12;
												}
												if (num44 == 7)
												{
													width2 = 8;
													height2 = 4;
													num45 = 4;
													num46 = 12;
													if (!Main.tile[num42, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42, num43 + 1);
													}
												}
												if (num44 == 8)
												{
													if (!Main.tile[num42 + 1, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43 + 1);
													}
													num45 = 12;
													num46 = 12;
												}
												color9.R = (byte)((color8.R + color10.R) / 2);
												color9.G = (byte)((color8.G + color10.G) / 2);
												color9.B = (byte)((color8.B + color10.B) / 2);
												color9.R = (byte)((float)color9.R * num5);
												color9.G = (byte)((float)color9.G * num6);
												color9.B = (byte)((float)color9.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num45 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39 + num46)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num38 + num45 + num35 + 16, 16 * num39 + num46, width2, height2)), color9);
											}
										}
										else if ((int)color8.R > num2 || (double)color8.G > (double)num2 * 1.1 || (double)color8.B > (double)num2 * 1.2)
										{
											for (int num47 = 0; num47 < 4; num47++)
											{
												int num48 = 0;
												int num49 = 0;
												Microsoft.Xna.Framework.Color color11 = color8;
												Microsoft.Xna.Framework.Color color12 = color8;
												if (num47 == 0)
												{
													if (Lighting.Brighter(num42, num43 - 1, num42 - 1, num43))
													{
														color12 = Lighting.GetColor(num42 - 1, num43);
													}
													else
													{
														color12 = Lighting.GetColor(num42, num43 - 1);
													}
												}
												if (num47 == 1)
												{
													if (Lighting.Brighter(num42, num43 - 1, num42 + 1, num43))
													{
														color12 = Lighting.GetColor(num42 + 1, num43);
													}
													else
													{
														color12 = Lighting.GetColor(num42, num43 - 1);
													}
													num48 = 8;
												}
												if (num47 == 2)
												{
													if (Lighting.Brighter(num42, num43 + 1, num42 - 1, num43))
													{
														color12 = Lighting.GetColor(num42 - 1, num43);
													}
													else
													{
														color12 = Lighting.GetColor(num42, num43 + 1);
													}
													num49 = 8;
												}
												if (num47 == 3)
												{
													if (Lighting.Brighter(num42, num43 + 1, num42 + 1, num43))
													{
														color12 = Lighting.GetColor(num42 + 1, num43);
													}
													else
													{
														color12 = Lighting.GetColor(num42, num43 + 1);
													}
													num48 = 8;
													num49 = 8;
												}
												color11.R = (byte)((color8.R + color12.R) / 2);
												color11.G = (byte)((color8.G + color12.G) / 2);
												color11.B = (byte)((color8.B + color12.B) / 2);
												color11.R = (byte)((float)color11.R * num5);
												color11.G = (byte)((float)color11.G * num6);
												color11.B = (byte)((float)color11.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num48 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39 + num49)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num38 + num48 + num35 + 16, 16 * num39 + num49, 8, 8)), color11);
											}
										}
										else
										{
											color8.R = (byte)((float)color8.R * num5);
											color8.G = (byte)((float)color8.G * num6);
											color8.B = (byte)((float)color8.B * num7);
											this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num38 + num35 + 16, 16 * num39, 16, 16)), color8);
										}
									}
									else
									{
										color8.R = (byte)((float)color8.R * num5);
										color8.G = (byte)((float)color8.G * num6);
										color8.B = (byte)((float)color8.B * num7);
										this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num38 + num35 + 16, 16 * num39, 16, 16)), color8);
									}
								}
							}
						}
					}
				}
				if (flag)
				{
					this.bgParrallax = (double)Main.caveParrallax;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
					this.bgLoops = Main.screenWidth / num3 + 2;
					this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
					for (int num50 = 0; num50 < this.bgLoops; num50++)
					{
						for (int num51 = 0; num51 < 6; num51++)
						{
							float num52 = (float)(this.bgStart + num3 * num50 + num51 * 16 + 8);
							float num53 = (float)this.bgTop;
							Microsoft.Xna.Framework.Color color13 = Lighting.GetColor((int)((num52 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num53) / 16f));
							color13.R = (byte)((float)color13.R * num5);
							color13.G = (byte)((float)color13.G * num6);
							color13.B = (byte)((float)color13.B * num7);
							this.spriteBatch.Draw(Main.backgroundTexture[6], new Vector2((float)(this.bgStart + num3 * num50 + 16 * num51 + num35), (float)this.bgTop) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num51 + num35 + 16, Main.magmaBGFrame * 16, 16, 16)), color13);
						}
					}
				}
			}
			this.bgTop = (int)((float)((int)num16 * 16) - Main.screenPosition.Y + 16f + 600f) - 8;
			if (num16 * 16.0 <= (double)(Main.screenPosition.Y + 600f))
			{
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (num16 * 16.0 + (double)Main.screenHeight < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[2]) - (double)Main.backgroundHeight[2]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				num = (int)((double)num * 1.5);
				num2 = (int)((double)num2 * 1.5);
				float num54 = (float)this.bgStart + Main.screenPosition.X;
				num54 = -(float)Math.IEEERemainder((double)num54, 16.0);
				num54 = (float)Math.Round((double)num54);
				int num55 = (int)num54;
				if (num55 == -8)
				{
					num55 = 8;
				}
				for (int num56 = 0; num56 < this.bgLoops; num56++)
				{
					for (int num57 = 0; num57 < this.bgLoopsY; num57++)
					{
						for (int num58 = 0; num58 < 6; num58++)
						{
							for (int num59 = 0; num59 < 6; num59++)
							{
								float num60 = (float)(this.bgStartY + num57 * 96 + num59 * 16 + 8);
								float num61 = (float)(this.bgStart + num3 * num56 + num58 * 16 + 8);
								int num62 = (int)((num61 + Main.screenPosition.X) / 16f);
								int num63 = (int)((num60 + Main.screenPosition.Y) / 16f);
								Microsoft.Xna.Framework.Color color14 = Lighting.GetColor(num62, num63);
								if (Main.tile[num62, num63] == null)
								{
									Main.tile[num62, num63] = new Tile();
								}
								bool flag4 = false;
								if (Main.caveParrallax != 0f)
								{
									if (Main.tile[num62 - 1, num63] == null)
									{
										Main.tile[num62 - 1, num63] = new Tile();
									}
									if (Main.tile[num62 + 1, num63] == null)
									{
										Main.tile[num62 + 1, num63] = new Tile();
									}
									if (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21 || Main.tile[num62 - 1, num63].wall == 0 || Main.tile[num62 - 1, num63].wall == 21 || Main.tile[num62 + 1, num63].wall == 0 || Main.tile[num62 + 1, num63].wall == 21)
									{
										flag4 = true;
									}
								}
								else if (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21)
								{
									flag4 = true;
								}
								if ((flag4 || color14.R == 0 || color14.G == 0 || color14.B == 0) && (color14.R > 0 || color14.G > 0 || color14.B > 0) && (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21 || Main.caveParrallax != 0f))
								{
									if (Lighting.lightMode < 2 && color14.R < 230 && color14.G < 230 && color14.B < 230)
									{
										if (((int)color14.R > num || (double)color14.G > (double)num * 1.1 || (double)color14.B > (double)num * 1.2) && !Main.tile[num62, num63].active)
										{
											for (int num64 = 0; num64 < 9; num64++)
											{
												int num65 = 0;
												int num66 = 0;
												int width3 = 4;
												int height3 = 4;
												Microsoft.Xna.Framework.Color color15 = color14;
												Microsoft.Xna.Framework.Color color16 = color14;
												if (num64 == 0 && !Main.tile[num62 - 1, num63 - 1].active)
												{
													color16 = Lighting.GetColor(num62 - 1, num63 - 1);
												}
												if (num64 == 1)
												{
													width3 = 8;
													num65 = 4;
													if (!Main.tile[num62, num63 - 1].active)
													{
														color16 = Lighting.GetColor(num62, num63 - 1);
													}
												}
												if (num64 == 2)
												{
													if (!Main.tile[num62 + 1, num63 - 1].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63 - 1);
													}
													num65 = 12;
												}
												if (num64 == 3)
												{
													if (!Main.tile[num62 - 1, num63].active)
													{
														color16 = Lighting.GetColor(num62 - 1, num63);
													}
													height3 = 8;
													num66 = 4;
												}
												if (num64 == 4)
												{
													width3 = 8;
													height3 = 8;
													num65 = 4;
													num66 = 4;
												}
												if (num64 == 5)
												{
													num65 = 12;
													num66 = 4;
													height3 = 8;
													if (!Main.tile[num62 + 1, num63].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63);
													}
												}
												if (num64 == 6)
												{
													if (!Main.tile[num62 - 1, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62 - 1, num63 + 1);
													}
													num66 = 12;
												}
												if (num64 == 7)
												{
													width3 = 8;
													height3 = 4;
													num65 = 4;
													num66 = 12;
													if (!Main.tile[num62, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62, num63 + 1);
													}
												}
												if (num64 == 8)
												{
													if (!Main.tile[num62 + 1, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63 + 1);
													}
													num65 = 12;
													num66 = 12;
												}
												color15.R = (byte)((color14.R + color16.R) / 2);
												color15.G = (byte)((color14.G + color16.G) / 2);
												color15.B = (byte)((color14.B + color16.B) / 2);
												color15.R = (byte)((float)color15.R * num5);
												color15.G = (byte)((float)color15.G * num6);
												color15.B = (byte)((float)color15.B * num7);
												SpriteBatch spriteBatch = this.spriteBatch;
												Texture2D texture = Main.backgroundTexture[5];
												Vector2 position = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num65 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59 + num66)) + value;
												Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num58 + num65 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame + num66, width3, height3));
												Microsoft.Xna.Framework.Color color17 = color15;
												float rotation = 0f;
												Vector2 origin = default(Vector2);
												spriteBatch.Draw(texture, position, sourceRectangle, color17, rotation, origin, 1f, SpriteEffects.None, 0f);
											}
										}
										else if ((int)color14.R > num2 || (double)color14.G > (double)num2 * 1.1 || (double)color14.B > (double)num2 * 1.2)
										{
											for (int num67 = 0; num67 < 4; num67++)
											{
												int num68 = 0;
												int num69 = 0;
												Microsoft.Xna.Framework.Color color18 = color14;
												Microsoft.Xna.Framework.Color color19 = color14;
												if (num67 == 0)
												{
													if (Lighting.Brighter(num62, num63 - 1, num62 - 1, num63))
													{
														color19 = Lighting.GetColor(num62 - 1, num63);
													}
													else
													{
														color19 = Lighting.GetColor(num62, num63 - 1);
													}
												}
												if (num67 == 1)
												{
													if (Lighting.Brighter(num62, num63 - 1, num62 + 1, num63))
													{
														color19 = Lighting.GetColor(num62 + 1, num63);
													}
													else
													{
														color19 = Lighting.GetColor(num62, num63 - 1);
													}
													num68 = 8;
												}
												if (num67 == 2)
												{
													if (Lighting.Brighter(num62, num63 + 1, num62 - 1, num63))
													{
														color19 = Lighting.GetColor(num62 - 1, num63);
													}
													else
													{
														color19 = Lighting.GetColor(num62, num63 + 1);
													}
													num69 = 8;
												}
												if (num67 == 3)
												{
													if (Lighting.Brighter(num62, num63 + 1, num62 + 1, num63))
													{
														color19 = Lighting.GetColor(num62 + 1, num63);
													}
													else
													{
														color19 = Lighting.GetColor(num62, num63 + 1);
													}
													num68 = 8;
													num69 = 8;
												}
												color18.R = (byte)((color14.R + color19.R) / 2);
												color18.G = (byte)((color14.G + color19.G) / 2);
												color18.B = (byte)((color14.B + color19.B) / 2);
												color18.R = (byte)((float)color18.R * num5);
												color18.G = (byte)((float)color18.G * num6);
												color18.B = (byte)((float)color18.B * num7);
												SpriteBatch spriteBatch2 = this.spriteBatch;
												Texture2D texture2 = Main.backgroundTexture[5];
												Vector2 position2 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num68 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59 + num69)) + value;
												Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num58 + num68 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame + num69, 8, 8));
												Microsoft.Xna.Framework.Color color20 = color18;
												float rotation2 = 0f;
												Vector2 origin = default(Vector2);
												spriteBatch2.Draw(texture2, position2, sourceRectangle2, color20, rotation2, origin, 1f, SpriteEffects.None, 0f);
											}
										}
										else
										{
											color14.R = (byte)((float)color14.R * num5);
											color14.G = (byte)((float)color14.G * num6);
											color14.B = (byte)((float)color14.B * num7);
											SpriteBatch spriteBatch3 = this.spriteBatch;
											Texture2D texture3 = Main.backgroundTexture[5];
											Vector2 position3 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59)) + value;
											Microsoft.Xna.Framework.Rectangle? sourceRectangle3 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num58 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16));
											Microsoft.Xna.Framework.Color color21 = color14;
											float rotation3 = 0f;
											Vector2 origin = default(Vector2);
											spriteBatch3.Draw(texture3, position3, sourceRectangle3, color21, rotation3, origin, 1f, SpriteEffects.None, 0f);
										}
									}
									else
									{
										color14.R = (byte)((float)color14.R * num5);
										color14.G = (byte)((float)color14.G * num6);
										color14.B = (byte)((float)color14.B * num7);
										SpriteBatch spriteBatch4 = this.spriteBatch;
										Texture2D texture4 = Main.backgroundTexture[5];
										Vector2 position4 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59)) + value;
										Microsoft.Xna.Framework.Rectangle? sourceRectangle4 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(16 * num58 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16));
										Microsoft.Xna.Framework.Color color22 = color14;
										float rotation4 = 0f;
										Vector2 origin = default(Vector2);
										spriteBatch4.Draw(texture4, position4, sourceRectangle4, color22, rotation4, origin, 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
				}
			}
			Lighting.brightness = Lighting.defBrightness;
			Main.renderTimer[3] = (float)stopwatch.ElapsedMilliseconds;
		}

		protected void RenderBackground()
		{
			if (!Main.drawToScreen)
			{
				base.GraphicsDevice.SetRenderTarget(this.backWaterTarget);
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				try
				{
					this.DrawWater(true);
				}
				catch
				{
				}
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
				base.GraphicsDevice.SetRenderTarget(this.backgroundTarget);
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				this.DrawBackground();
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected void RenderTiles()
		{
			if (!Main.drawToScreen)
			{
				this.RenderBlack();
				base.GraphicsDevice.SetRenderTarget(this.tileTarget);
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				this.DrawTiles(true);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected void RenderTiles2()
		{
			if (!Main.drawToScreen)
			{
				base.GraphicsDevice.SetRenderTarget(this.tile2Target);
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				this.DrawTiles(false);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected void RenderWater()
		{
			if (!Main.drawToScreen)
			{
				base.GraphicsDevice.SetRenderTarget(this.waterTarget);
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				try
				{
					this.DrawWater(false);
					if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
					{
						this.DrawWires();
					}
				}
				catch
				{
				}
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected bool FullTile(int x, int y)
		{
			bool result;
			if (Main.tile[x, y].active && Main.tileSolid[(int)Main.tile[x, y].type] && !Main.tileSolidTop[(int)Main.tile[x, y].type] && Main.tile[x, y].type != 10 && Main.tile[x, y].type != 54 && Main.tile[x, y].type != 138)
			{
				int frameX = (int)Main.tile[x, y].frameX;
				int frameY = (int)Main.tile[x, y].frameY;
				if (frameY == 18)
				{
					if (frameX >= 18 && frameX <= 54)
					{
						result = true;
						return result;
					}
					if (frameX >= 108 && frameX <= 144)
					{
						result = true;
						return result;
					}
				}
				else if (frameY >= 90 && frameY <= 196)
				{
					if (frameX <= 70)
					{
						result = true;
						return result;
					}
					if (frameX >= 144 && frameX <= 232)
					{
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}

		protected void DrawBlack()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num = (int)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
			float num2 = (float)((double)num * 0.4) / 255f;
			if (Lighting.lightMode == 2)
			{
				num2 = (float)(Main.tileColor.R - 55) / 255f;
			}
			else if (Lighting.lightMode == 3)
			{
				num2 = (float)(num - 55) / 255f;
			}
			int num3 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num4 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num5 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num6 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			int num7 = Main.offScreenRange / 16;
			int num8 = Main.offScreenRange / 16;
			if (num3 - num7 < 0)
			{
				num3 = num7;
			}
			if (num4 + num7 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX - num7;
			}
			if (num5 - num8 < 0)
			{
				num5 = num8;
			}
			if (num6 + num8 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY - num8;
			}
			for (int i = num5 - num8; i < num6 + num8; i++)
			{
				if ((double)i <= Main.worldSurface)
				{
					for (int j = num3 - num7; j < num4 + num7; j++)
					{
						if (Main.tile[j, i] == null)
						{
							Main.tile[j, i] = new Tile();
						}
						if (Lighting.Brightness(j, i) < num2 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
						{
							int num9 = j;
							j++;
							while (Main.tile[j, i] != null && Lighting.Brightness(j, i) < num2 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
							{
								j++;
								if (j >= num4 + num7)
								{
									break;
								}
							}
							j--;
							int width = (j - num9 + 1) * 16;
							this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float)(num9 * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, width, 16)), Microsoft.Xna.Framework.Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
			Main.renderTimer[5] = (float)stopwatch.ElapsedMilliseconds;
		}

		protected void RenderBlack()
		{
			if (!Main.drawToScreen)
			{
				base.GraphicsDevice.SetRenderTarget(this.blackTarget);
				base.GraphicsDevice.DepthStencilState = new DepthStencilState
				{
					DepthBufferEnable = true
				};
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				this.DrawBlack();
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected void DrawWalls()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 100f * Main.gfxQuality);
			int num2 = (int)(120f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num3 = (int)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
			float num4 = (float)((double)num3 * 0.53) / 255f;
			if (Lighting.lightMode == 2)
			{
				num4 = (float)(Main.tileColor.R - 12) / 255f;
			}
			if (Lighting.lightMode == 3)
			{
				num4 = (float)(num3 - 12) / 255f;
			}
			int num5 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num6 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num7 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num8 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			int num9 = Main.offScreenRange / 16;
			int num10 = Main.offScreenRange / 16;
			if (num5 - num9 < 0)
			{
				num5 = num9;
			}
			if (num6 + num9 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX - num9;
			}
			if (num7 - num10 < 0)
			{
				num7 = num10;
			}
			if (num8 + num10 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY - num10;
			}
			for (int i = num7 - num10; i < num8 + num10; i++)
			{
				if ((double)i <= Main.worldSurface)
				{
					for (int j = num5 - num9; j < num6 + num9; j++)
					{
						if (Main.tile[j, i] == null)
						{
							Main.tile[j, i] = new Tile();
						}
						if (Lighting.Brightness(j, i) < num4 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
						{
							this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, Lighting.GetBlackness(j, i));
						}
					}
				}
			}
			for (int k = num7 - num10; k < num8 + num10; k++)
			{
				for (int l = num5 - num9; l < num6 + num9; l++)
				{
					if (Main.tile[l, k] == null)
					{
						Main.tile[l, k] = new Tile();
					}
					if (Main.tile[l, k].wall > 0 && Lighting.Brightness(l, k) > 0f && !this.FullTile(l, k))
					{
						Microsoft.Xna.Framework.Color color = Lighting.GetColor(l, k);
						if (Lighting.lightMode < 2 && Main.tile[l, k].wall != 21 && !WorldGen.SolidTile(l, k))
						{
							if ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2)
							{
								for (int m = 0; m < 9; m++)
								{
									int num11 = 0;
									int num12 = 0;
									int width = 12;
									int height = 12;
									Microsoft.Xna.Framework.Color color2 = color;
									Microsoft.Xna.Framework.Color color3 = color;
									if (m == 0)
									{
										color3 = Lighting.GetColor(l - 1, k - 1);
									}
									if (m == 1)
									{
										width = 8;
										num11 = 12;
										color3 = Lighting.GetColor(l, k - 1);
									}
									if (m == 2)
									{
										color3 = Lighting.GetColor(l + 1, k - 1);
										num11 = 20;
									}
									if (m == 3)
									{
										color3 = Lighting.GetColor(l - 1, k);
										height = 8;
										num12 = 12;
									}
									if (m == 4)
									{
										width = 8;
										height = 8;
										num11 = 12;
										num12 = 12;
									}
									if (m == 5)
									{
										num11 = 20;
										num12 = 12;
										height = 8;
										color3 = Lighting.GetColor(l + 1, k);
									}
									if (m == 6)
									{
										color3 = Lighting.GetColor(l - 1, k + 1);
										num12 = 20;
									}
									if (m == 7)
									{
										width = 12;
										num11 = 12;
										num12 = 20;
										color3 = Lighting.GetColor(l, k + 1);
									}
									if (m == 8)
									{
										color3 = Lighting.GetColor(l + 1, k + 1);
										num11 = 20;
										num12 = 20;
									}
									color2.R = (byte)((color.R + color3.R) / 2);
									color2.G = (byte)((color.G + color3.G) / 2);
									color2.B = (byte)((color.B + color3.B) / 2);
									this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8 + num11), (float)(k * 16 - (int)Main.screenPosition.Y - 8 + num12)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)(Main.tile[l, k].wallFrameX * 2) + num11, (int)(Main.tile[l, k].wallFrameY * 2) + num12, width, height)), color2, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else if ((int)color.R > num2 || (double)color.G > (double)num2 * 1.1 || (double)color.B > (double)num2 * 1.2)
							{
								for (int n = 0; n < 4; n++)
								{
									int num13 = 0;
									int num14 = 0;
									Microsoft.Xna.Framework.Color color4 = color;
									Microsoft.Xna.Framework.Color color5 = color;
									if (n == 0)
									{
										if (Lighting.Brighter(l, k - 1, l - 1, k))
										{
											color5 = Lighting.GetColor(l - 1, k);
										}
										else
										{
											color5 = Lighting.GetColor(l, k - 1);
										}
									}
									if (n == 1)
									{
										if (Lighting.Brighter(l, k - 1, l + 1, k))
										{
											color5 = Lighting.GetColor(l + 1, k);
										}
										else
										{
											color5 = Lighting.GetColor(l, k - 1);
										}
										num13 = 16;
									}
									if (n == 2)
									{
										if (Lighting.Brighter(l, k + 1, l - 1, k))
										{
											color5 = Lighting.GetColor(l - 1, k);
										}
										else
										{
											color5 = Lighting.GetColor(l, k + 1);
										}
										num14 = 16;
									}
									if (n == 3)
									{
										if (Lighting.Brighter(l, k + 1, l + 1, k))
										{
											color5 = Lighting.GetColor(l + 1, k);
										}
										else
										{
											color5 = Lighting.GetColor(l, k + 1);
										}
										num13 = 16;
										num14 = 16;
									}
									color4.R = (byte)((color.R + color5.R) / 2);
									color4.G = (byte)((color.G + color5.G) / 2);
									color4.B = (byte)((color.B + color5.B) / 2);
									this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8 + num13), (float)(k * 16 - (int)Main.screenPosition.Y - 8 + num14)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int)(Main.tile[l, k].wallFrameX * 2) + num13, (int)(Main.tile[l, k].wallFrameY * 2) + num14, 16, 16)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle((int)(Main.tile[l, k].wallFrameX * 2), (int)(Main.tile[l, k].wallFrameY * 2), 32, 32);
								this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8), (float)(k * 16 - (int)Main.screenPosition.Y - 8)) + value, new Microsoft.Xna.Framework.Rectangle?(value2), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						else
						{
							Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle((int)(Main.tile[l, k].wallFrameX * 2), (int)(Main.tile[l, k].wallFrameY * 2), 32, 32);
							this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8), (float)(k * 16 - (int)Main.screenPosition.Y - 8)) + value, new Microsoft.Xna.Framework.Rectangle?(value2), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
						if ((double)color.R > (double)num2 * 0.4 || (double)color.G > (double)num2 * 0.35 || (double)color.B > (double)num2 * 0.3)
						{
							bool flag = false;
							if (Main.tile[l - 1, k].wall > 0 && Main.wallBlend[(int)Main.tile[l - 1, k].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag = true;
							}
							bool flag2 = false;
							if (Main.tile[l + 1, k].wall > 0 && Main.wallBlend[(int)Main.tile[l + 1, k].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag2 = true;
							}
							bool flag3 = false;
							if (Main.tile[l, k - 1].wall > 0 && Main.wallBlend[(int)Main.tile[l, k - 1].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag3 = true;
							}
							bool flag4 = false;
							if (Main.tile[l, k + 1].wall > 0 && Main.wallBlend[(int)Main.tile[l, k + 1].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag4 = true;
							}
							if (flag)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 2, 16)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag2)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X + 14), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(14, 0, 2, 16)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag3)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 16, 2)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag4)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y + 14)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 14, 16, 2)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
			}
			Main.renderTimer[2] = (float)stopwatch.ElapsedMilliseconds;
		}

		protected void RenderWalls()
		{
			if (!Main.drawToScreen)
			{
				base.GraphicsDevice.SetRenderTarget(this.wallTarget);
				base.GraphicsDevice.DepthStencilState = new DepthStencilState
				{
					DepthBufferEnable = true
				};
				base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
				this.spriteBatch.Begin();
				this.DrawWalls();
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
			}
		}

		protected void ReleaseTargets()
		{
			try
			{
				if (!Main.dedServ)
				{
					Main.offScreenRange = 0;
					Main.targetSet = false;
					this.waterTarget.Dispose();
					this.backWaterTarget.Dispose();
					this.blackTarget.Dispose();
					this.tileTarget.Dispose();
					this.tile2Target.Dispose();
					this.wallTarget.Dispose();
					this.backgroundTarget.Dispose();
				}
			}
			catch
			{
			}
		}

		protected void InitTargets()
		{
			try
			{
				if (!Main.dedServ)
				{
					Main.offScreenRange = 192;
					Main.targetSet = true;
					if (base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2 > 2048)
					{
						Main.offScreenRange = (2048 - base.GraphicsDevice.PresentationParameters.BackBufferWidth) / 2;
					}
					this.waterTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.backWaterTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.blackTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.tileTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.tile2Target = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.wallTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
					this.backgroundTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
				}
			}
			catch
			{
				Lighting.lightMode = 2;
				try
				{
					this.ReleaseTargets();
				}
				catch
				{
				}
			}
		}

		protected void DrawWires()
		{
			int num = (int)(50f * (1f - Main.gfxQuality) + 2f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num2 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num3 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num4 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num5 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 > Main.maxTilesX)
			{
				num3 = Main.maxTilesX;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesY)
			{
				num5 = Main.maxTilesY;
			}
			for (int i = num4; i < num5; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[j, i].wire && Lighting.Brightness(j, i) > 0f)
					{
						Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle(0, 0, 16, 16);
						bool wire = Main.tile[j, i - 1].wire;
						bool wire2 = Main.tile[j, i + 1].wire;
						bool wire3 = Main.tile[j - 1, i].wire;
						bool wire4 = Main.tile[j + 1, i].wire;
						if (wire)
						{
							if (wire2)
							{
								if (wire3)
								{
									if (wire4)
									{
										value2 = new Microsoft.Xna.Framework.Rectangle(18, 18, 16, 16);
									}
									else
									{
										value2 = new Microsoft.Xna.Framework.Rectangle(54, 0, 16, 16);
									}
								}
								else if (wire4)
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(36, 0, 16, 16);
								}
								else
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(0, 0, 16, 16);
								}
							}
							else if (wire3)
							{
								if (wire4)
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(0, 18, 16, 16);
								}
								else
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(54, 18, 16, 16);
								}
							}
							else if (wire4)
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(36, 18, 16, 16);
							}
							else
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(36, 36, 16, 16);
							}
						}
						else if (wire2)
						{
							if (wire3)
							{
								if (wire4)
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(72, 0, 16, 16);
								}
								else
								{
									value2 = new Microsoft.Xna.Framework.Rectangle(72, 18, 16, 16);
								}
							}
							else if (wire4)
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(0, 36, 16, 16);
							}
							else
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(18, 36, 16, 16);
							}
						}
						else if (wire3)
						{
							if (wire4)
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(18, 0, 16, 16);
							}
							else
							{
								value2 = new Microsoft.Xna.Framework.Rectangle(54, 36, 16, 16);
							}
						}
						else if (wire4)
						{
							value2 = new Microsoft.Xna.Framework.Rectangle(72, 36, 16, 16);
						}
						else
						{
							value2 = new Microsoft.Xna.Framework.Rectangle(0, 54, 16, 16);
						}
						Microsoft.Xna.Framework.Color color = Lighting.GetColor(j, i);
						if (Lighting.lightMode < 2 && ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2))
						{
							for (int k = 0; k < 4; k++)
							{
								int num6 = 0;
								int num7 = 0;
								Microsoft.Xna.Framework.Color color2 = color;
								Microsoft.Xna.Framework.Color color3 = color;
								if (k == 0)
								{
									if (Lighting.Brighter(j, i - 1, j - 1, i))
									{
										color3 = Lighting.GetColor(j - 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i - 1);
									}
								}
								if (k == 1)
								{
									if (Lighting.Brighter(j, i - 1, j + 1, i))
									{
										color3 = Lighting.GetColor(j + 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i - 1);
									}
									num6 = 8;
								}
								if (k == 2)
								{
									if (Lighting.Brighter(j, i + 1, j - 1, i))
									{
										color3 = Lighting.GetColor(j - 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i + 1);
									}
									num7 = 8;
								}
								if (k == 3)
								{
									if (Lighting.Brighter(j, i + 1, j + 1, i))
									{
										color3 = Lighting.GetColor(j + 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i + 1);
									}
									num6 = 8;
									num7 = 8;
								}
								color2.R = (byte)((color.R + color3.R) / 2);
								color2.G = (byte)((color.G + color3.G) / 2);
								color2.B = (byte)((color.B + color3.B) / 2);
								this.spriteBatch.Draw(Main.wireTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X + num6), (float)(i * 16 - (int)Main.screenPosition.Y + num7)) + value, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(value2.X + num6, value2.Y + num7, 8, 8)), color2, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						else
						{
							this.spriteBatch.Draw(Main.wireTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, new Microsoft.Xna.Framework.Rectangle?(value2), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			if (Lighting.lightMode >= 2)
			{
				Main.drawToScreen = true;
			}
			else
			{
				Main.drawToScreen = false;
			}
			if (Main.drawToScreen && Main.targetSet)
			{
				this.ReleaseTargets();
			}
			if (!Main.drawToScreen && !Main.targetSet)
			{
				this.InitTargets();
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Main.fpsCount++;
			if (!base.IsActive)
			{
				Main.maxQ = true;
			}
			if (!Main.dedServ)
			{
				bool flag = false;
				int num = Main.screenWidth;
				if (num == base.GraphicsDevice.Viewport.Width)
				{
					int num2 = Main.screenHeight;
					if (num2 == base.GraphicsDevice.Viewport.Height)
					{
						goto IL_127;
					}
				}
				flag = true;
				if (Main.gamePaused)
				{
					Main.renderNow = true;
				}
				IL_127:
				Main.screenWidth = base.GraphicsDevice.Viewport.Width;
				Main.screenHeight = base.GraphicsDevice.Viewport.Height;
				if (Main.screenWidth > Main.maxScreenW)
				{
					Main.screenWidth = Main.maxScreenW;
					flag = true;
				}
				if (Main.screenHeight > Main.maxScreenH)
				{
					Main.screenHeight = Main.maxScreenH;
					flag = true;
				}
				if (Main.screenWidth < Main.minScreenW)
				{
					Main.screenWidth = Main.minScreenW;
					flag = true;
				}
				if (Main.screenHeight < Main.minScreenH)
				{
					Main.screenHeight = Main.minScreenH;
					flag = true;
				}
				if (flag)
				{
					this.graphics.PreferredBackBufferWidth = Main.screenWidth;
					this.graphics.PreferredBackBufferHeight = Main.screenHeight;
					this.graphics.ApplyChanges();
					if (!Main.drawToScreen)
					{
						this.InitTargets();
					}
				}
			}
			Main.CursorColor();
			Main.drawTime++;
			Main.screenLastPosition = Main.screenPosition;
			if (Main.stackSplit == 0)
			{
				Main.stackCounter = 0;
				Main.stackDelay = 7;
			}
			else
			{
				Main.stackCounter++;
				if (Main.stackCounter >= 30)
				{
					Main.stackDelay--;
					if (Main.stackDelay < 2)
					{
						Main.stackDelay = 2;
					}
					Main.stackCounter = 0;
				}
			}
			Main.mouseTextColor += (byte)Main.mouseTextColorChange;
			if (Main.mouseTextColor >= 250)
			{
				Main.mouseTextColorChange = -4;
			}
			if (Main.mouseTextColor <= 175)
			{
				Main.mouseTextColorChange = 4;
			}
			if (Main.myPlayer >= 0)
			{
				Main.player[Main.myPlayer].mouseInterface = false;
			}
			Main.toolTip = new Item();
			if (!Main.gameMenu && Main.netMode != 2)
			{
				Main.screenPosition.X = Main.player[Main.myPlayer].position.X + (float)Main.player[Main.myPlayer].width * 0.5f - (float)Main.screenWidth * 0.5f;
				Main.screenPosition.Y = Main.player[Main.myPlayer].position.Y + (float)Main.player[Main.myPlayer].height * 0.5f - (float)Main.screenHeight * 0.5f;
				Main.screenPosition.X = (float)((int)Main.screenPosition.X);
				Main.screenPosition.Y = (float)((int)Main.screenPosition.Y);
			}
			if (!Main.gameMenu && Main.netMode != 2)
			{
				if (Main.screenPosition.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
				{
					Main.screenPosition.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				}
				else if (Main.screenPosition.X + (float)Main.screenWidth > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
				{
					Main.screenPosition.X = Main.rightWorld - (float)Main.screenWidth - (float)(Lighting.offScreenTiles * 16) - 32f;
				}
				if (Main.screenPosition.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
				{
					Main.screenPosition.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				}
				else if (Main.screenPosition.Y + (float)Main.screenHeight > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
				{
					Main.screenPosition.Y = Main.bottomWorld - (float)Main.screenHeight - (float)(Lighting.offScreenTiles * 16) - 32f;
				}
			}
			if (Main.showSplash)
			{
				this.DrawSplash(gameTime);
			}
			else
			{
				if (!Main.gameMenu)
				{
					if (Main.renderNow)
					{
						Main.screenLastPosition = Main.screenPosition;
						Main.renderNow = false;
						Main.renderCount = 99;
						int tempLightCount = Lighting.tempLightCount;
						this.Draw(gameTime);
						Lighting.tempLightCount = tempLightCount;
						Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
						Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
						this.RenderTiles();
						Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						this.RenderBackground();
						Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						this.RenderWalls();
						Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						this.RenderTiles2();
						Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						this.RenderWater();
						Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						Main.renderCount = 99;
					}
					else
					{
						if (Main.renderCount == 3)
						{
							this.RenderTiles();
							Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Main.renderCount == 2)
						{
							this.RenderBackground();
							Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Main.renderCount == 2)
						{
							this.RenderWalls();
							Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Main.renderCount == 3)
						{
							this.RenderTiles2();
							Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Main.renderCount == 1)
						{
							this.RenderWater();
							Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
					}
					if (Main.render && !Main.gameMenu)
					{
						if (Math.Abs(Main.sceneTilePos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTilePos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
						{
							this.RenderTiles();
							Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Math.Abs(Main.sceneTile2Pos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTile2Pos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
						{
							this.RenderTiles2();
							Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Math.Abs(Main.sceneBackgroundPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneBackgroundPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
						{
							this.RenderBackground();
							Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Math.Abs(Main.sceneWallPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWallPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
						{
							this.RenderWalls();
							Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
						if (Math.Abs(Main.sceneWaterPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWaterPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
						{
							this.RenderWater();
							Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
							Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
						}
					}
				}
				this.bgParrallax = 0.1;
				this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
				this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
				this.bgStartY = 0;
				this.bgLoopsY = 0;
				this.bgTop = (int)(-(double)Main.screenPosition.Y / (Main.worldSurface * 16.0 - 600.0) * 200.0);
				Main.bgColor = Microsoft.Xna.Framework.Color.White;
				if (Main.gameMenu || Main.netMode == 2)
				{
					this.bgTop = -200;
				}
				int num3 = (int)(Main.time / 54000.0 * (double)(Main.screenWidth + Main.sunTexture.Width * 2)) - Main.sunTexture.Width;
				int num4 = 0;
				Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
				float num5 = 1f;
				float rotation = (float)(Main.time / 54000.0) * 2f - 7.3f;
				int num6 = (int)(Main.time / 32400.0 * (double)(Main.screenWidth + Main.moonTexture.Width * 2)) - Main.moonTexture.Width;
				int num7 = 0;
				Microsoft.Xna.Framework.Color white2 = Microsoft.Xna.Framework.Color.White;
				float num8 = 1f;
				float rotation2 = (float)(Main.time / 32400.0) * 2f - 7.3f;
				if (Main.dayTime)
				{
					double num9;
					if (Main.time < 27000.0)
					{
						num9 = Math.Pow(1.0 - Main.time / 54000.0 * 2.0, 2.0);
						num4 = (int)((double)this.bgTop + num9 * 250.0 + 180.0);
					}
					else
					{
						num9 = Math.Pow((Main.time / 54000.0 - 0.5) * 2.0, 2.0);
						num4 = (int)((double)this.bgTop + num9 * 250.0 + 180.0);
					}
					num5 = (float)(1.2 - num9 * 0.4);
				}
				else
				{
					double num10;
					if (Main.time < 16200.0)
					{
						num10 = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
						num7 = (int)((double)this.bgTop + num10 * 250.0 + 180.0);
					}
					else
					{
						num10 = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
						num7 = (int)((double)this.bgTop + num10 * 250.0 + 180.0);
					}
					num8 = (float)(1.2 - num10 * 0.4);
				}
				if (Main.dayTime)
				{
					if (Main.time < 13500.0)
					{
						float num11 = (float)(Main.time / 13500.0);
						white.R = (byte)(num11 * 200f + 55f);
						white.G = (byte)(num11 * 180f + 75f);
						white.B = (byte)(num11 * 250f + 5f);
						Main.bgColor.R = (byte)(num11 * 230f + 25f);
						Main.bgColor.G = (byte)(num11 * 220f + 35f);
						Main.bgColor.B = (byte)(num11 * 220f + 35f);
					}
					if (Main.time > 45900.0)
					{
						float num11 = (float)(1.0 - (Main.time / 54000.0 - 0.85) * 6.666666666666667);
						white.R = (byte)(num11 * 120f + 55f);
						white.G = (byte)(num11 * 100f + 25f);
						white.B = (byte)(num11 * 120f + 55f);
						Main.bgColor.R = (byte)(num11 * 200f + 35f);
						Main.bgColor.G = (byte)(num11 * 85f + 35f);
						Main.bgColor.B = (byte)(num11 * 135f + 35f);
					}
					else if (Main.time > 37800.0)
					{
						float num11 = (float)(1.0 - (Main.time / 54000.0 - 0.7) * 6.666666666666667);
						white.R = (byte)(num11 * 80f + 175f);
						white.G = (byte)(num11 * 130f + 125f);
						white.B = (byte)(num11 * 100f + 155f);
						Main.bgColor.R = (byte)(num11 * 20f + 235f);
						Main.bgColor.G = (byte)(num11 * 135f + 120f);
						Main.bgColor.B = (byte)(num11 * 85f + 170f);
					}
				}
				if (!Main.dayTime)
				{
					if (Main.bloodMoon)
					{
						if (Main.time < 16200.0)
						{
							float num11 = (float)(1.0 - Main.time / 16200.0);
							white2.R = (byte)(num11 * 10f + 205f);
							white2.G = (byte)(num11 * 170f + 55f);
							white2.B = (byte)(num11 * 200f + 55f);
							Main.bgColor.R = (byte)(40f - num11 * 40f + 35f);
							Main.bgColor.G = (byte)(num11 * 20f + 15f);
							Main.bgColor.B = (byte)(num11 * 20f + 15f);
						}
						else if (Main.time >= 16200.0)
						{
							float num11 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
							white2.R = (byte)(num11 * 50f + 205f);
							white2.G = (byte)(num11 * 100f + 155f);
							white2.B = (byte)(num11 * 100f + 155f);
							white2.R = (byte)(num11 * 10f + 205f);
							white2.G = (byte)(num11 * 170f + 55f);
							white2.B = (byte)(num11 * 200f + 55f);
							Main.bgColor.R = (byte)(40f - num11 * 40f + 35f);
							Main.bgColor.G = (byte)(num11 * 20f + 15f);
							Main.bgColor.B = (byte)(num11 * 20f + 15f);
						}
					}
					else if (Main.time < 16200.0)
					{
						float num11 = (float)(1.0 - Main.time / 16200.0);
						white2.R = (byte)(num11 * 10f + 205f);
						white2.G = (byte)(num11 * 70f + 155f);
						white2.B = (byte)(num11 * 100f + 155f);
						Main.bgColor.R = (byte)(num11 * 20f + 15f);
						Main.bgColor.G = (byte)(num11 * 20f + 15f);
						Main.bgColor.B = (byte)(num11 * 20f + 15f);
					}
					else if (Main.time >= 16200.0)
					{
						float num11 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
						white2.R = (byte)(num11 * 50f + 205f);
						white2.G = (byte)(num11 * 100f + 155f);
						white2.B = (byte)(num11 * 100f + 155f);
						Main.bgColor.R = (byte)(num11 * 10f + 15f);
						Main.bgColor.G = (byte)(num11 * 20f + 15f);
						Main.bgColor.B = (byte)(num11 * 20f + 15f);
					}
				}
				if (Main.gameMenu || Main.netMode == 2)
				{
					this.bgTop = 0;
					if (!Main.dayTime)
					{
						Main.bgColor.R = 35;
						Main.bgColor.G = 35;
						Main.bgColor.B = 35;
					}
				}
				if (Main.gameMenu)
				{
					Main.bgDelay = 1000;
					Main.evilTiles = (int)(Main.bgAlpha[1] * 500f);
				}
				if (Main.evilTiles > 0)
				{
					float num12 = (float)Main.evilTiles / 500f;
					if (num12 > 1f)
					{
						num12 = 1f;
					}
					int num13 = (int)Main.bgColor.R;
					int num14 = (int)Main.bgColor.G;
					int num15 = (int)Main.bgColor.B;
					num13 -= (int)(100f * num12 * ((float)Main.bgColor.R / 255f));
					num14 -= (int)(140f * num12 * ((float)Main.bgColor.G / 255f));
					num15 -= (int)(80f * num12 * ((float)Main.bgColor.B / 255f));
					if (num13 < 15)
					{
						num13 = 15;
					}
					if (num14 < 15)
					{
						num14 = 15;
					}
					if (num15 < 15)
					{
						num15 = 15;
					}
					Main.bgColor.R = (byte)num13;
					Main.bgColor.G = (byte)num14;
					Main.bgColor.B = (byte)num15;
					num13 = (int)white.R;
					num14 = (int)white.G;
					num15 = (int)white.B;
					num13 -= (int)(100f * num12 * ((float)white.R / 255f));
					num14 -= (int)(100f * num12 * ((float)white.G / 255f));
					num15 -= (int)(0f * num12 * ((float)white.B / 255f));
					if (num13 < 15)
					{
						num13 = 15;
					}
					if (num14 < 15)
					{
						num14 = 15;
					}
					if (num15 < 15)
					{
						num15 = 15;
					}
					white.R = (byte)num13;
					white.G = (byte)num14;
					white.B = (byte)num15;
					num13 = (int)white2.R;
					num14 = (int)white2.G;
					num15 = (int)white2.B;
					num13 -= (int)(140f * num12 * ((float)white2.R / 255f));
					num14 -= (int)(190f * num12 * ((float)white2.G / 255f));
					num15 -= (int)(170f * num12 * ((float)white2.B / 255f));
					if (num13 < 15)
					{
						num13 = 15;
					}
					if (num14 < 15)
					{
						num14 = 15;
					}
					if (num15 < 15)
					{
						num15 = 15;
					}
					white2.R = (byte)num13;
					white2.G = (byte)num14;
					white2.B = (byte)num15;
				}
				if (Main.jungleTiles > 0)
				{
					float num16 = (float)Main.jungleTiles / 200f;
					if (num16 > 1f)
					{
						num16 = 1f;
					}
					int num17 = (int)Main.bgColor.R;
					int num18 = (int)Main.bgColor.G;
					int num19 = (int)Main.bgColor.B;
					num17 -= (int)(20f * num16 * ((float)Main.bgColor.R / 255f));
					num19 -= (int)(90f * num16 * ((float)Main.bgColor.B / 255f));
					if (num18 > 255)
					{
						num18 = 255;
					}
					if (num18 < 15)
					{
						num18 = 15;
					}
					if (num17 > 255)
					{
						num17 = 255;
					}
					if (num17 < 15)
					{
						num17 = 15;
					}
					if (num19 < 15)
					{
						num19 = 15;
					}
					Main.bgColor.R = (byte)num17;
					Main.bgColor.G = (byte)num18;
					Main.bgColor.B = (byte)num19;
					num17 = (int)white.R;
					num18 = (int)white.G;
					num19 = (int)white.B;
					num17 -= (int)(30f * num16 * ((float)white.R / 255f));
					num19 -= (int)(10f * num16 * ((float)white.B / 255f));
					if (num17 < 15)
					{
						num17 = 15;
					}
					if (num18 < 15)
					{
						num18 = 15;
					}
					if (num19 < 15)
					{
						num19 = 15;
					}
					white.R = (byte)num17;
					white.G = (byte)num18;
					white.B = (byte)num19;
					num17 = (int)white2.R;
					num18 = (int)white2.G;
					num19 = (int)white2.B;
					num18 -= (int)(140f * num16 * ((float)white2.R / 255f));
					num17 -= (int)(170f * num16 * ((float)white2.G / 255f));
					num19 -= (int)(190f * num16 * ((float)white2.B / 255f));
					if (num17 < 15)
					{
						num17 = 15;
					}
					if (num18 < 15)
					{
						num18 = 15;
					}
					if (num19 < 15)
					{
						num19 = 15;
					}
					white2.R = (byte)num17;
					white2.G = (byte)num18;
					white2.B = (byte)num19;
				}
				if (Main.bgColor.R < 15)
				{
					Main.bgColor.R = 15;
				}
				if (Main.bgColor.G < 15)
				{
					Main.bgColor.G = 15;
				}
				if (Main.bgColor.B < 15)
				{
					Main.bgColor.B = 15;
				}
				if (Main.bloodMoon)
				{
					if (Main.bgColor.R < 25)
					{
						Main.bgColor.R = 25;
					}
					if (Main.bgColor.G < 25)
					{
						Main.bgColor.G = 25;
					}
					if (Main.bgColor.B < 25)
					{
						Main.bgColor.B = 25;
					}
				}
				Main.tileColor.A = 255;
				Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
				Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
				Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
				Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.R * 7) / 10);
				Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.G * 7) / 10);
				Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.B * 7) / 10);
				if (Main.tileColor.R >= 255 && Main.tileColor.G >= 255)
				{
					byte b = Main.tileColor.B;
				}
				float num20 = (float)(Main.maxTilesX / 4200);
				num20 *= num20;
				float num21 = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f - (65f + 10f * num20)) / (Main.worldSurface / 5.0));
				if (num21 < 0f)
				{
					num21 = 0f;
				}
				if (num21 > 1f)
				{
					num21 = 1f;
				}
				if (Main.gameMenu)
				{
					num21 = 1f;
				}
				Main.bgColor.R = (byte)((float)Main.bgColor.R * num21);
				Main.bgColor.G = (byte)((float)Main.bgColor.G * num21);
				Main.bgColor.B = (byte)((float)Main.bgColor.B * num21);
				base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
				base.Draw(gameTime);
				this.spriteBatch.Begin();
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int i = 0; i < this.bgLoops; i++)
					{
						this.spriteBatch.Draw(Main.backgroundTexture[Main.background], new Microsoft.Xna.Framework.Rectangle(this.bgStart + Main.backgroundWidth[Main.background] * i, this.bgTop, Main.backgroundWidth[Main.background], Main.backgroundHeight[Main.background]), Main.bgColor);
					}
				}
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && 255 - Main.bgColor.R - 100 > 0 && Main.netMode != 2)
				{
					for (int j = 0; j < Main.numStars; j++)
					{
						Microsoft.Xna.Framework.Color color = default(Microsoft.Xna.Framework.Color);
						float num22 = (float)Main.evilTiles / 500f;
						if (num22 > 1f)
						{
							num22 = 1f;
						}
						num22 = 1f - num22 * 0.5f;
						if (Main.evilTiles <= 0)
						{
							num22 = 1f;
						}
						int num23 = (int)((float)(255 - Main.bgColor.R - 100) * Main.star[j].twinkle * num22);
						int num24 = (int)((float)(255 - Main.bgColor.G - 100) * Main.star[j].twinkle * num22);
						int num25 = (int)((float)(255 - Main.bgColor.B - 100) * Main.star[j].twinkle * num22);
						if (num23 < 0)
						{
							num23 = 0;
						}
						if (num24 < 0)
						{
							num24 = 0;
						}
						if (num25 < 0)
						{
							num25 = 0;
						}
						color.R = (byte)num23;
						color.G = (byte)((float)num24 * num22);
						color.B = (byte)((float)num25 * num22);
						float num26 = Main.star[j].position.X * ((float)Main.screenWidth / 800f);
						float num27 = Main.star[j].position.Y * ((float)Main.screenHeight / 600f);
						this.spriteBatch.Draw(Main.starTexture[Main.star[j].type], new Vector2(num26 + (float)Main.starTexture[Main.star[j].type].Width * 0.5f, num27 + (float)Main.starTexture[Main.star[j].type].Height * 0.5f + (float)this.bgTop), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.starTexture[Main.star[j].type].Width, Main.starTexture[Main.star[j].type].Height)), color, Main.star[j].rotation, new Vector2((float)Main.starTexture[Main.star[j].type].Width * 0.5f, (float)Main.starTexture[Main.star[j].type].Height * 0.5f), Main.star[j].scale * Main.star[j].twinkle, SpriteEffects.None, 0f);
					}
				}
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 2.0)
				{
					if (Main.dayTime)
					{
						num5 *= 1.1f;
						if (!Main.gameMenu && Main.player[Main.myPlayer].head == 12)
						{
							this.spriteBatch.Draw(Main.sun2Texture, new Vector2((float)num3, (float)(num4 + (int)Main.sunModY)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num5, SpriteEffects.None, 0f);
						}
						else
						{
							this.spriteBatch.Draw(Main.sunTexture, new Vector2((float)num3, (float)(num4 + (int)Main.sunModY)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num5, SpriteEffects.None, 0f);
						}
					}
					if (!Main.dayTime)
					{
						this.spriteBatch.Draw(Main.moonTexture, new Vector2((float)num6, (float)(num7 + (int)Main.moonModY)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, Main.moonTexture.Width * Main.moonPhase, Main.moonTexture.Width, Main.moonTexture.Width)), white2, rotation2, new Vector2((float)(Main.moonTexture.Width / 2), (float)(Main.moonTexture.Width / 2)), num8, SpriteEffects.None, 0f);
					}
				}
				Microsoft.Xna.Framework.Rectangle value;
				if (Main.dayTime)
				{
					value = new Microsoft.Xna.Framework.Rectangle((int)((double)num3 - (double)Main.sunTexture.Width * 0.5 * (double)num5), (int)((double)num4 - (double)Main.sunTexture.Height * 0.5 * (double)num5 + (double)Main.sunModY), (int)((float)Main.sunTexture.Width * num5), (int)((float)Main.sunTexture.Width * num5));
				}
				else
				{
					value = new Microsoft.Xna.Framework.Rectangle((int)((double)num6 - (double)Main.moonTexture.Width * 0.5 * (double)num8), (int)((double)num7 - (double)Main.moonTexture.Width * 0.5 * (double)num8 + (double)Main.moonModY), (int)((float)Main.moonTexture.Width * num8), (int)((float)Main.moonTexture.Width * num8));
				}
				Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(Main.mouseX, Main.mouseY, 1, 1);
				Main.sunModY = (short)((double)Main.sunModY * 0.999);
				Main.moonModY = (short)((double)Main.moonModY * 0.999);
				if (Main.gameMenu && Main.netMode != 1)
				{
					if (Main.mouseLeft && Main.hasFocus)
					{
						if (rectangle.Intersects(value) || Main.grabSky)
						{
							if (Main.dayTime)
							{
								Main.time = 54000.0 * (double)((float)(Main.mouseX + Main.sunTexture.Width) / ((float)Main.screenWidth + (float)(Main.sunTexture.Width * 2)));
								Main.sunModY = (short)(Main.mouseY - num4);
								if (Main.time > 53990.0)
								{
									Main.time = 53990.0;
								}
							}
							else
							{
								Main.time = 32400.0 * (double)((float)(Main.mouseX + Main.moonTexture.Width) / ((float)Main.screenWidth + (float)(Main.moonTexture.Width * 2)));
								Main.moonModY = (short)(Main.mouseY - num7);
								if (Main.time > 32390.0)
								{
									Main.time = 32390.0;
								}
							}
							if (Main.time < 10.0)
							{
								Main.time = 10.0;
							}
							if (Main.netMode != 0)
							{
								NetMessage.SendData(18, -1, -1, "", 0, 0f, 0f, 0f, 0);
							}
							Main.grabSky = true;
						}
					}
					else
					{
						Main.grabSky = false;
					}
				}
				float num28 = (float)(Main.screenHeight - 600);
				this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1200.0 + 1190.0);
				float num29 = (float)(this.bgTop - 50);
				if (Main.resetClouds)
				{
					Cloud.resetClouds();
					Main.resetClouds = false;
				}
				if (base.IsActive || Main.netMode != 0)
				{
					Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0001f;
					if (!Main.dayTime)
					{
						Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0002f;
					}
					if ((double)Main.windSpeedSpeed < -0.002)
					{
						Main.windSpeedSpeed = -0.002f;
					}
					if ((double)Main.windSpeedSpeed > 0.002)
					{
						Main.windSpeedSpeed = 0.002f;
					}
					Main.windSpeed += Main.windSpeedSpeed;
					if ((double)Main.windSpeed < -0.3)
					{
						Main.windSpeed = -0.3f;
					}
					if ((double)Main.windSpeed > 0.3)
					{
						Main.windSpeed = 0.3f;
					}
					Main.numClouds += Main.rand.Next(-1, 2);
					if (Main.numClouds < 0)
					{
						Main.numClouds = 0;
					}
					if (Main.numClouds > Main.cloudLimit)
					{
						Main.numClouds = Main.cloudLimit;
					}
				}
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int k = 0; k < 100; k++)
					{
						if (Main.cloud[k].active && Main.cloud[k].scale < 1f)
						{
							Microsoft.Xna.Framework.Color color2 = Main.cloud[k].cloudColor(Main.bgColor);
							if (num21 < 1f)
							{
								color2.R = (byte)((float)color2.R * num21);
								color2.G = (byte)((float)color2.G * num21);
								color2.B = (byte)((float)color2.B * num21);
								color2.A = (byte)((float)color2.A * num21);
							}
							float num30 = Main.cloud[k].position.Y * ((float)Main.screenHeight / 600f);
							float num31 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
							if (num31 < 0f)
							{
								num31 = 0f;
							}
							if (num31 > 1f)
							{
							}
							if (Main.gameMenu)
							{
							}
							this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[k].type], new Vector2(Main.cloud[k].position.X + (float)Main.cloudTexture[Main.cloud[k].type].Width * 0.5f, num30 + (float)Main.cloudTexture[Main.cloud[k].type].Height * 0.5f + num29), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cloudTexture[Main.cloud[k].type].Width, Main.cloudTexture[Main.cloud[k].type].Height)), color2, Main.cloud[k].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[k].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[k].type].Height * 0.5f), Main.cloud[k].scale, SpriteEffects.None, 0f);
						}
					}
				}
				num21 = 1f;
				float num32 = 1f;
				num32 *= 2f;
				this.bgParrallax = 0.15;
				int num33 = (int)((float)Main.backgroundWidth[7] * num32);
				Microsoft.Xna.Framework.Color color3 = Main.bgColor;
				Microsoft.Xna.Framework.Color color4 = color3;
				if (num21 < 1f)
				{
					color3.R = (byte)((float)color3.R * num21);
					color3.G = (byte)((float)color3.G * num21);
					color3.B = (byte)((float)color3.B * num21);
					color3.A = (byte)((float)color3.A * num21);
				}
				this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1300.0 + 1090.0);
				if (Main.owBack)
				{
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
					this.bgLoops = Main.screenWidth / num33 + 2;
					if (Main.gameMenu)
					{
						this.bgTop = 100;
					}
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[0]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[0]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[0]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[0]);
						if (Main.bgAlpha2[0] > 0f)
						{
							for (int l = 0; l < this.bgLoops; l++)
							{
								SpriteBatch spriteBatch = this.spriteBatch;
								Texture2D texture = Main.backgroundTexture[7];
								Vector2 position = new Vector2((float)(this.bgStart + num33 * l), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color5 = color3;
								float rotation3 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch.Draw(texture, position, sourceRectangle, color5, rotation3, origin, num32, SpriteEffects.None, 0f);
							}
						}
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[1]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[1]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[1]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[1]);
						if (Main.bgAlpha2[1] > 0f)
						{
							for (int m = 0; m < this.bgLoops; m++)
							{
								SpriteBatch spriteBatch2 = this.spriteBatch;
								Texture2D texture2 = Main.backgroundTexture[23];
								Vector2 position2 = new Vector2((float)(this.bgStart + num33 * m), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color6 = color3;
								float rotation4 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch2.Draw(texture2, position2, sourceRectangle2, color6, rotation4, origin, num32, SpriteEffects.None, 0f);
							}
						}
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[2]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[2]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[2]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[2]);
						if (Main.bgAlpha2[2] > 0f)
						{
							for (int n = 0; n < this.bgLoops; n++)
							{
								SpriteBatch spriteBatch3 = this.spriteBatch;
								Texture2D texture3 = Main.backgroundTexture[24];
								Vector2 position3 = new Vector2((float)(this.bgStart + num33 * n), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle3 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color7 = color3;
								float rotation5 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch3.Draw(texture3, position3, sourceRectangle3, color7, rotation5, origin, num32, SpriteEffects.None, 0f);
							}
						}
					}
				}
				num29 = (float)(this.bgTop - 50);
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int num34 = 0; num34 < 100; num34++)
					{
						if (Main.cloud[num34].active && (double)Main.cloud[num34].scale < 1.15 && Main.cloud[num34].scale >= 1f)
						{
							Microsoft.Xna.Framework.Color color8 = Main.cloud[num34].cloudColor(Main.bgColor);
							if (num21 < 1f)
							{
								color8.R = (byte)((float)color8.R * num21);
								color8.G = (byte)((float)color8.G * num21);
								color8.B = (byte)((float)color8.B * num21);
								color8.A = (byte)((float)color8.A * num21);
							}
							float num35 = Main.cloud[num34].position.Y * ((float)Main.screenHeight / 600f);
							float num36 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
							if (num36 < 0f)
							{
								num36 = 0f;
							}
							if (num36 > 1f)
							{
							}
							if (Main.gameMenu)
							{
							}
							this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num34].type], new Vector2(Main.cloud[num34].position.X + (float)Main.cloudTexture[Main.cloud[num34].type].Width * 0.5f, num35 + (float)Main.cloudTexture[Main.cloud[num34].type].Height * 0.5f + num29), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cloudTexture[Main.cloud[num34].type].Width, Main.cloudTexture[Main.cloud[num34].type].Height)), color8, Main.cloud[num34].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num34].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num34].type].Height * 0.5f), Main.cloud[num34].scale, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.holyTiles > 0 && Main.owBack)
				{
					this.bgParrallax = 0.17;
					num32 = 1.1f;
					num32 *= 2f;
					num33 = (int)((double)(3500f * num32) * 1.05);
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
					this.bgLoops = Main.screenWidth / num33 + 2;
					this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1400.0 + 900.0);
					if (Main.gameMenu)
					{
						this.bgTop = 230;
						this.bgStart -= 500;
					}
					Microsoft.Xna.Framework.Color color9 = color4;
					float num37 = (float)Main.holyTiles / 400f;
					if (num37 > 0.5f)
					{
						num37 = 0.5f;
					}
					color9.R = (byte)((float)color9.R * num37);
					color9.G = (byte)((float)color9.G * num37);
					color9.B = (byte)((float)color9.B * num37);
					color9.A = (byte)((float)color9.A * num37 * 0.8f);
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num38 = 0; num38 < this.bgLoops; num38++)
						{
							SpriteBatch spriteBatch4 = this.spriteBatch;
							Texture2D texture4 = Main.backgroundTexture[18];
							Vector2 position4 = new Vector2((float)(this.bgStart + num33 * num38), (float)this.bgTop);
							Microsoft.Xna.Framework.Rectangle? sourceRectangle4 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[18], Main.backgroundHeight[18]));
							Microsoft.Xna.Framework.Color color10 = color9;
							float rotation6 = 0f;
							Vector2 origin = default(Vector2);
							spriteBatch4.Draw(texture4, position4, sourceRectangle4, color10, rotation6, origin, num32, SpriteEffects.None, 0f);
							SpriteBatch spriteBatch5 = this.spriteBatch;
							Texture2D texture5 = Main.backgroundTexture[19];
							Vector2 position5 = new Vector2((float)(this.bgStart + num33 * num38 + 1700), (float)(this.bgTop + 100));
							Microsoft.Xna.Framework.Rectangle? sourceRectangle5 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[19], Main.backgroundHeight[19]));
							Microsoft.Xna.Framework.Color color11 = color9;
							float rotation7 = 0f;
							origin = default(Vector2);
							spriteBatch5.Draw(texture5, position5, sourceRectangle5, color11, rotation7, origin, num32 * 0.9f, SpriteEffects.None, 0f);
						}
					}
				}
				this.bgParrallax = 0.2;
				num32 = 1.15f;
				num32 *= 2f;
				num33 = (int)((float)Main.backgroundWidth[7] * num32);
				this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
				this.bgLoops = Main.screenWidth / num33 + 2;
				this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1400.0 + 1260.0);
				if (Main.owBack)
				{
					if (Main.gameMenu)
					{
						this.bgTop = 230;
						this.bgStart -= 500;
					}
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[0]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[0]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[0]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[0]);
						if (Main.bgAlpha2[0] > 0f)
						{
							for (int num39 = 0; num39 < this.bgLoops; num39++)
							{
								SpriteBatch spriteBatch6 = this.spriteBatch;
								Texture2D texture6 = Main.backgroundTexture[8];
								Vector2 position6 = new Vector2((float)(this.bgStart + num33 * num39), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle6 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color12 = color3;
								float rotation8 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch6.Draw(texture6, position6, sourceRectangle6, color12, rotation8, origin, num32, SpriteEffects.None, 0f);
							}
						}
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[1]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[1]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[1]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[1]);
						if (Main.bgAlpha2[1] > 0f)
						{
							for (int num40 = 0; num40 < this.bgLoops; num40++)
							{
								SpriteBatch spriteBatch7 = this.spriteBatch;
								Texture2D texture7 = Main.backgroundTexture[22];
								Vector2 position7 = new Vector2((float)(this.bgStart + num33 * num40), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle7 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color13 = color3;
								float rotation9 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch7.Draw(texture7, position7, sourceRectangle7, color13, rotation9, origin, num32, SpriteEffects.None, 0f);
							}
						}
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[2]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[2]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[2]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[2]);
						if (Main.bgAlpha2[2] > 0f)
						{
							for (int num41 = 0; num41 < this.bgLoops; num41++)
							{
								SpriteBatch spriteBatch8 = this.spriteBatch;
								Texture2D texture8 = Main.backgroundTexture[25];
								Vector2 position8 = new Vector2((float)(this.bgStart + num33 * num41), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle8 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color14 = color3;
								float rotation10 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch8.Draw(texture8, position8, sourceRectangle8, color14, rotation10, origin, num32, SpriteEffects.None, 0f);
							}
						}
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha2[3]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha2[3]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha2[3]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha2[3]);
						if (Main.bgAlpha2[3] > 0f)
						{
							for (int num42 = 0; num42 < this.bgLoops; num42++)
							{
								SpriteBatch spriteBatch9 = this.spriteBatch;
								Texture2D texture9 = Main.backgroundTexture[28];
								Vector2 position9 = new Vector2((float)(this.bgStart + num33 * num42), (float)this.bgTop);
								Microsoft.Xna.Framework.Rectangle? sourceRectangle9 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
								Microsoft.Xna.Framework.Color color15 = color3;
								float rotation11 = 0f;
								Vector2 origin = default(Vector2);
								spriteBatch9.Draw(texture9, position9, sourceRectangle9, color15, rotation11, origin, num32, SpriteEffects.None, 0f);
							}
						}
					}
				}
				num29 = (float)this.bgTop * 1.01f - 150f;
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int num43 = 0; num43 < 100; num43++)
					{
						if (Main.cloud[num43].active && Main.cloud[num43].scale > num32)
						{
							Microsoft.Xna.Framework.Color color16 = Main.cloud[num43].cloudColor(Main.bgColor);
							if (num21 < 1f)
							{
								color16.R = (byte)((float)color16.R * num21);
								color16.G = (byte)((float)color16.G * num21);
								color16.B = (byte)((float)color16.B * num21);
								color16.A = (byte)((float)color16.A * num21);
							}
							float num44 = Main.cloud[num43].position.Y * ((float)Main.screenHeight / 600f);
							float num45 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
							if (num45 < 0f)
							{
								num45 = 0f;
							}
							if (num45 > 1f)
							{
							}
							if (Main.gameMenu)
							{
							}
							this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num43].type], new Vector2(Main.cloud[num43].position.X + (float)Main.cloudTexture[Main.cloud[num43].type].Width * 0.5f, num44 + (float)Main.cloudTexture[Main.cloud[num43].type].Height * 0.5f + num29), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.cloudTexture[Main.cloud[num43].type].Width, Main.cloudTexture[Main.cloud[num43].type].Height)), color16, Main.cloud[num43].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num43].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num43].type].Height * 0.5f), Main.cloud[num43].scale, SpriteEffects.None, 0f);
						}
					}
				}
				int num46 = Main.bgStyle;
				int num47 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if (num47 < 380 || num47 > Main.maxTilesX - 380)
				{
					num46 = 4;
				}
				else if (Main.sandTiles > 1000)
				{
					if (Main.player[Main.myPlayer].zoneEvil)
					{
						num46 = 5;
					}
					else if (Main.player[Main.myPlayer].zoneHoly)
					{
						num46 = 5;
					}
					else
					{
						num46 = 2;
					}
				}
				else if (Main.player[Main.myPlayer].zoneHoly)
				{
					num46 = 6;
				}
				else if (Main.player[Main.myPlayer].zoneEvil)
				{
					num46 = 1;
				}
				else if (Main.player[Main.myPlayer].zoneJungle)
				{
					num46 = 3;
				}
				else
				{
					num46 = 0;
				}
				float num48 = 0.05f;
				int num49 = 30;
				if (num46 == 0)
				{
					num49 = 120;
				}
				if (Main.bgDelay < 0)
				{
					Main.bgDelay++;
				}
				else if (num46 != Main.bgStyle)
				{
					Main.bgDelay++;
					if (Main.bgDelay > num49)
					{
						Main.bgDelay = -60;
						Main.bgStyle = num46;
						if (num46 == 0)
						{
							Main.bgDelay = 0;
						}
					}
				}
				else if (Main.bgDelay > 0)
				{
					Main.bgDelay--;
				}
				if (Main.gameMenu)
				{
					num48 = 0.02f;
					if (!Main.dayTime)
					{
						Main.bgStyle = 1;
					}
					else
					{
						Main.bgStyle = 0;
					}
					num46 = Main.bgStyle;
				}
				if (Main.quickBG > 0)
				{
					Main.quickBG--;
					Main.bgStyle = num46;
					num48 = 1f;
				}
				if (Main.bgStyle == 2)
				{
					Main.bgAlpha2[0] -= num48;
					if (Main.bgAlpha2[0] < 0f)
					{
						Main.bgAlpha2[0] = 0f;
					}
					Main.bgAlpha2[1] += num48;
					if (Main.bgAlpha2[1] > 1f)
					{
						Main.bgAlpha2[1] = 1f;
					}
					Main.bgAlpha2[2] -= num48;
					if (Main.bgAlpha2[2] < 0f)
					{
						Main.bgAlpha2[2] = 0f;
					}
					Main.bgAlpha2[3] -= num48;
					if (Main.bgAlpha2[3] < 0f)
					{
						Main.bgAlpha2[3] = 0f;
					}
				}
				else if (Main.bgStyle == 5 || Main.bgStyle == 1 || Main.bgStyle == 6)
				{
					Main.bgAlpha2[0] -= num48;
					if (Main.bgAlpha2[0] < 0f)
					{
						Main.bgAlpha2[0] = 0f;
					}
					Main.bgAlpha2[1] -= num48;
					if (Main.bgAlpha2[1] < 0f)
					{
						Main.bgAlpha2[1] = 0f;
					}
					Main.bgAlpha2[2] += num48;
					if (Main.bgAlpha2[2] > 1f)
					{
						Main.bgAlpha2[2] = 1f;
					}
					Main.bgAlpha2[3] -= num48;
					if (Main.bgAlpha2[3] < 0f)
					{
						Main.bgAlpha2[3] = 0f;
					}
				}
				else if (Main.bgStyle == 4)
				{
					Main.bgAlpha2[0] -= num48;
					if (Main.bgAlpha2[0] < 0f)
					{
						Main.bgAlpha2[0] = 0f;
					}
					Main.bgAlpha2[1] -= num48;
					if (Main.bgAlpha2[1] < 0f)
					{
						Main.bgAlpha2[1] = 0f;
					}
					Main.bgAlpha2[2] -= num48;
					if (Main.bgAlpha2[2] < 0f)
					{
						Main.bgAlpha2[2] = 0f;
					}
					Main.bgAlpha2[3] += num48;
					if (Main.bgAlpha2[3] > 1f)
					{
						Main.bgAlpha2[3] = 1f;
					}
				}
				else
				{
					Main.bgAlpha2[0] += num48;
					if (Main.bgAlpha2[0] > 1f)
					{
						Main.bgAlpha2[0] = 1f;
					}
					Main.bgAlpha2[1] -= num48;
					if (Main.bgAlpha2[1] < 0f)
					{
						Main.bgAlpha2[1] = 0f;
					}
					Main.bgAlpha2[2] -= num48;
					if (Main.bgAlpha2[2] < 0f)
					{
						Main.bgAlpha2[2] = 0f;
					}
					Main.bgAlpha2[3] -= num48;
					if (Main.bgAlpha2[3] < 0f)
					{
						Main.bgAlpha2[3] = 0f;
					}
				}
				for (int num50 = 0; num50 < 7; num50++)
				{
					if (Main.bgStyle == num50)
					{
						Main.bgAlpha[num50] += num48;
						if (Main.bgAlpha[num50] > 1f)
						{
							Main.bgAlpha[num50] = 1f;
						}
					}
					else
					{
						Main.bgAlpha[num50] -= num48;
						if (Main.bgAlpha[num50] < 0f)
						{
							Main.bgAlpha[num50] = 0f;
						}
					}
					if (Main.owBack)
					{
						color3 = color4;
						color3.R = (byte)((float)color3.R * Main.bgAlpha[num50]);
						color3.G = (byte)((float)color3.G * Main.bgAlpha[num50]);
						color3.B = (byte)((float)color3.B * Main.bgAlpha[num50]);
						color3.A = (byte)((float)color3.A * Main.bgAlpha[num50]);
						if (Main.bgAlpha[num50] > 0f && num50 == 3)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1660.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num51 = 0; num51 < this.bgLoops; num51++)
								{
									SpriteBatch spriteBatch10 = this.spriteBatch;
									Texture2D texture10 = Main.backgroundTexture[15];
									Vector2 position10 = new Vector2((float)(this.bgStart + num33 * num51), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle10 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color17 = color3;
									float rotation12 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch10.Draw(texture10, position10, sourceRectangle10, color17, rotation12, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.31f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1950.0 + 1840.0);
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num52 = 0; num52 < this.bgLoops; num52++)
								{
									SpriteBatch spriteBatch11 = this.spriteBatch;
									Texture2D texture11 = Main.backgroundTexture[16];
									Vector2 position11 = new Vector2((float)(this.bgStart + num33 * num52), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle11 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color18 = color3;
									float rotation13 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch11.Draw(texture11, position11, sourceRectangle11, color18, rotation13, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2060.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num53 = 0; num53 < this.bgLoops; num53++)
								{
									SpriteBatch spriteBatch12 = this.spriteBatch;
									Texture2D texture12 = Main.backgroundTexture[17];
									Vector2 position12 = new Vector2((float)(this.bgStart + num33 * num53), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle12 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color19 = color3;
									float rotation14 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch12.Draw(texture12, position12, sourceRectangle12, color19, rotation14, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num50] > 0f && num50 == 2)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.37;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num54 = 0; num54 < this.bgLoops; num54++)
								{
									SpriteBatch spriteBatch13 = this.spriteBatch;
									Texture2D texture13 = Main.backgroundTexture[21];
									Vector2 position13 = new Vector2((float)(this.bgStart + num33 * num54), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle13 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
									Microsoft.Xna.Framework.Color color20 = color3;
									float rotation15 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch13.Draw(texture13, position13, sourceRectangle13, color20, rotation15, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num55 = 0; num55 < this.bgLoops; num55++)
								{
									SpriteBatch spriteBatch14 = this.spriteBatch;
									Texture2D texture14 = Main.backgroundTexture[20];
									Vector2 position14 = new Vector2((float)(this.bgStart + num33 * num55), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle14 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
									Microsoft.Xna.Framework.Color color21 = color3;
									float rotation16 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch14.Draw(texture14, position14, sourceRectangle14, color21, rotation16, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num50] > 0f && num50 == 5)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.37;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num56 = 0; num56 < this.bgLoops; num56++)
								{
									SpriteBatch spriteBatch15 = this.spriteBatch;
									Texture2D texture15 = Main.backgroundTexture[26];
									Vector2 position15 = new Vector2((float)(this.bgStart + num33 * num56), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle15 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
									Microsoft.Xna.Framework.Color color22 = color3;
									float rotation17 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch15.Draw(texture15, position15, sourceRectangle15, color22, rotation17, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num57 = 0; num57 < this.bgLoops; num57++)
								{
									SpriteBatch spriteBatch16 = this.spriteBatch;
									Texture2D texture16 = Main.backgroundTexture[27];
									Vector2 position16 = new Vector2((float)(this.bgStart + num33 * num57), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle16 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
									Microsoft.Xna.Framework.Color color23 = color3;
									float rotation18 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch16.Draw(texture16, position16, sourceRectangle16, color23, rotation18, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num50] > 0f && num50 == 1)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num58 = 0; num58 < this.bgLoops; num58++)
								{
									SpriteBatch spriteBatch17 = this.spriteBatch;
									Texture2D texture17 = Main.backgroundTexture[12];
									Vector2 position17 = new Vector2((float)(this.bgStart + num33 * num58), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle17 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color24 = color3;
									float rotation19 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch17.Draw(texture17, position17, sourceRectangle17, color24, rotation19, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.31f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num59 = 0; num59 < this.bgLoops; num59++)
								{
									SpriteBatch spriteBatch18 = this.spriteBatch;
									Texture2D texture18 = Main.backgroundTexture[13];
									Vector2 position18 = new Vector2((float)(this.bgStart + num33 * num59), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle18 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color25 = color3;
									float rotation20 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch18.Draw(texture18, position18, sourceRectangle18, color25, rotation20, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num60 = 0; num60 < this.bgLoops; num60++)
								{
									SpriteBatch spriteBatch19 = this.spriteBatch;
									Texture2D texture19 = Main.backgroundTexture[14];
									Vector2 position19 = new Vector2((float)(this.bgStart + num33 * num60), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle19 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color26 = color3;
									float rotation21 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch19.Draw(texture19, position19, sourceRectangle19, color26, rotation21, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num50] > 0f && num50 == 6)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num61 = 0; num61 < this.bgLoops; num61++)
								{
									SpriteBatch spriteBatch20 = this.spriteBatch;
									Texture2D texture20 = Main.backgroundTexture[29];
									Vector2 position20 = new Vector2((float)(this.bgStart + num33 * num61), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle20 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color27 = color3;
									float rotation22 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch20.Draw(texture20, position20, sourceRectangle20, color27, rotation22, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.31f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num62 = 0; num62 < this.bgLoops; num62++)
								{
									SpriteBatch spriteBatch21 = this.spriteBatch;
									Texture2D texture21 = Main.backgroundTexture[30];
									Vector2 position21 = new Vector2((float)(this.bgStart + num33 * num62), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle21 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color28 = color3;
									float rotation23 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch21.Draw(texture21, position21, sourceRectangle21, color28, rotation23, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num63 = 0; num63 < this.bgLoops; num63++)
								{
									SpriteBatch spriteBatch22 = this.spriteBatch;
									Texture2D texture22 = Main.backgroundTexture[31];
									Vector2 position22 = new Vector2((float)(this.bgStart + num33 * num63), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle22 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color29 = color3;
									float rotation24 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch22.Draw(texture22, position22, sourceRectangle22, color29, rotation24, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num50] > 0f && num50 == 0)
						{
							num32 = 1.25f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num64 = 0; num64 < this.bgLoops; num64++)
								{
									SpriteBatch spriteBatch23 = this.spriteBatch;
									Texture2D texture23 = Main.backgroundTexture[9];
									Vector2 position23 = new Vector2((float)(this.bgStart + num33 * num64), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle23 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color30 = color3;
									float rotation25 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch23.Draw(texture23, position23, sourceRectangle23, color30, rotation25, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.31f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num65 = 0; num65 < this.bgLoops; num65++)
								{
									SpriteBatch spriteBatch24 = this.spriteBatch;
									Texture2D texture24 = Main.backgroundTexture[10];
									Vector2 position24 = new Vector2((float)(this.bgStart + num33 * num65), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle24 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color31 = color3;
									float rotation26 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch24.Draw(texture24, position24, sourceRectangle24, color31, rotation26, origin, num32, SpriteEffects.None, 0f);
								}
							}
							num32 = 1.34f;
							num32 *= 2f;
							num33 = (int)((float)Main.backgroundWidth[8] * num32);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num33) - (double)(num33 / 2));
							this.bgTop = (int)((-(double)Main.screenPosition.Y + (double)(num28 / 2f)) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / num33 + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num66 = 0; num66 < this.bgLoops; num66++)
								{
									SpriteBatch spriteBatch25 = this.spriteBatch;
									Texture2D texture25 = Main.backgroundTexture[11];
									Vector2 position25 = new Vector2((float)(this.bgStart + num33 * num66), (float)this.bgTop);
									Microsoft.Xna.Framework.Rectangle? sourceRectangle25 = new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
									Microsoft.Xna.Framework.Color color32 = color3;
									float rotation27 = 0f;
									Vector2 origin = default(Vector2);
									spriteBatch25.Draw(texture25, position25, sourceRectangle25, color32, rotation27, origin, num32, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
				if (Main.gameMenu || Main.netMode == 2)
				{
					this.DrawMenu();
				}
				else
				{
					this.firstTileX = (int)(Main.screenPosition.X / 16f - 1f);
					this.lastTileX = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 2;
					this.firstTileY = (int)(Main.screenPosition.Y / 16f - 1f);
					this.lastTileY = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 2;
					if (this.firstTileX < 0)
					{
						this.firstTileX = 0;
					}
					if (this.lastTileX > Main.maxTilesX)
					{
						this.lastTileX = Main.maxTilesX;
					}
					if (this.firstTileY < 0)
					{
						this.firstTileY = 0;
					}
					if (this.lastTileY > Main.maxTilesY)
					{
						this.lastTileY = Main.maxTilesY;
					}
					if (!Main.drawSkip)
					{
						Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
					}
					Microsoft.Xna.Framework.Color white3 = Microsoft.Xna.Framework.Color.White;
					if (Main.drawToScreen)
					{
						this.DrawWater(true);
					}
					else
					{
						this.spriteBatch.Draw(this.backWaterTarget, Main.sceneBackgroundPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
					}
					float x = (Main.sceneBackgroundPos.X - Main.screenPosition.X + (float)Main.offScreenRange) * Main.caveParrallax - (float)Main.offScreenRange;
					if (Main.drawToScreen)
					{
						this.DrawBackground();
					}
					else
					{
						this.spriteBatch.Draw(this.backgroundTarget, new Vector2(x, Main.sceneBackgroundPos.Y - Main.screenPosition.Y), Microsoft.Xna.Framework.Color.White);
					}
					Main.magmaBGFrameCounter++;
					if (Main.magmaBGFrameCounter >= 8)
					{
						Main.magmaBGFrameCounter = 0;
						Main.magmaBGFrame++;
						if (Main.magmaBGFrame >= 3)
						{
							Main.magmaBGFrame = 0;
						}
					}
					try
					{
						if (Main.drawToScreen)
						{
							this.DrawBlack();
							this.DrawWalls();
						}
						else
						{
							this.spriteBatch.Draw(this.blackTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
							this.spriteBatch.Draw(this.wallTarget, Main.sceneWallPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
						}
						this.DrawWoF();
						if (Main.player[Main.myPlayer].detectCreature)
						{
							if (Main.drawToScreen)
							{
								this.DrawTiles(false);
								this.DrawTiles(true);
							}
							else
							{
								this.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
								this.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
							}
							this.DrawGore();
							this.DrawNPCs(true);
							this.DrawNPCs(false);
						}
						else
						{
							if (Main.drawToScreen)
							{
								this.DrawTiles(false);
								this.DrawNPCs(true);
								this.DrawTiles(true);
							}
							else
							{
								this.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
								this.DrawNPCs(true);
								this.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
							}
							this.DrawGore();
							this.DrawNPCs(false);
						}
					}
					catch
					{
					}
					for (int num67 = 0; num67 < 1000; num67++)
					{
						if (Main.projectile[num67].active && Main.projectile[num67].type > 0 && !Main.projectile[num67].hide)
						{
							this.DrawProj(num67);
						}
					}
					for (int num68 = 0; num68 < 255; num68++)
					{
						if (Main.player[num68].active)
						{
							if (Main.player[num68].ghost)
							{
								Vector2 position26 = Main.player[num68].position;
								Main.player[num68].position = Main.player[num68].shadowPos[0];
								Main.player[num68].shadow = 0.5f;
								this.DrawGhost(Main.player[num68]);
								Main.player[num68].position = Main.player[num68].shadowPos[1];
								Main.player[num68].shadow = 0.7f;
								this.DrawGhost(Main.player[num68]);
								Main.player[num68].position = Main.player[num68].shadowPos[2];
								Main.player[num68].shadow = 0.9f;
								this.DrawGhost(Main.player[num68]);
								Main.player[num68].position = position26;
								Main.player[num68].shadow = 0f;
								this.DrawGhost(Main.player[num68]);
							}
							else
							{
								bool flag2 = false;
								bool flag3 = false;
								if (Main.player[num68].head == 5 && Main.player[num68].body == 5 && Main.player[num68].legs == 5)
								{
									flag2 = true;
								}
								if (Main.player[num68].head == 7 && Main.player[num68].body == 7 && Main.player[num68].legs == 7)
								{
									flag2 = true;
								}
								if (Main.player[num68].head == 22 && Main.player[num68].body == 14 && Main.player[num68].legs == 14)
								{
									flag2 = true;
								}
								if (Main.player[num68].body == 17 && Main.player[num68].legs == 16 && (Main.player[num68].head == 29 || Main.player[num68].head == 30 || Main.player[num68].head == 31))
								{
									flag2 = true;
								}
								if (Main.player[num68].body == 19 && Main.player[num68].legs == 18 && (Main.player[num68].head == 35 || Main.player[num68].head == 36 || Main.player[num68].head == 37))
								{
									flag3 = true;
								}
								if (Main.player[num68].body == 24 && Main.player[num68].legs == 23 && (Main.player[num68].head == 41 || Main.player[num68].head == 42 || Main.player[num68].head == 43))
								{
									flag3 = true;
									flag2 = true;
								}
								if (flag3)
								{
									Vector2 position27 = Main.player[num68].position;
									if (!Main.gamePaused)
									{
										Main.player[num68].ghostFade += Main.player[num68].ghostDir * 0.075f;
									}
									if ((double)Main.player[num68].ghostFade < 0.1)
									{
										Main.player[num68].ghostDir = 1f;
										Main.player[num68].ghostFade = 0.1f;
									}
									if ((double)Main.player[num68].ghostFade > 0.9)
									{
										Main.player[num68].ghostDir = -1f;
										Main.player[num68].ghostFade = 0.9f;
									}
									Main.player[num68].position.X = position27.X - Main.player[num68].ghostFade * 5f;
									Main.player[num68].shadow = Main.player[num68].ghostFade;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position.X = position27.X + Main.player[num68].ghostFade * 5f;
									Main.player[num68].shadow = Main.player[num68].ghostFade;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position = position27;
									Main.player[num68].position.Y = position27.Y - Main.player[num68].ghostFade * 5f;
									Main.player[num68].shadow = Main.player[num68].ghostFade;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position.Y = position27.Y + Main.player[num68].ghostFade * 5f;
									Main.player[num68].shadow = Main.player[num68].ghostFade;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position = position27;
									Main.player[num68].shadow = 0f;
								}
								if (flag2)
								{
									Vector2 position28 = Main.player[num68].position;
									Main.player[num68].position = Main.player[num68].shadowPos[0];
									Main.player[num68].shadow = 0.5f;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position = Main.player[num68].shadowPos[1];
									Main.player[num68].shadow = 0.7f;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position = Main.player[num68].shadowPos[2];
									Main.player[num68].shadow = 0.9f;
									this.DrawPlayer(Main.player[num68]);
									Main.player[num68].position = position28;
									Main.player[num68].shadow = 0f;
								}
								this.DrawPlayer(Main.player[num68]);
							}
						}
					}
					if (!Main.gamePaused)
					{
						Main.essScale += (float)Main.essDir * 0.01f;
						if (Main.essScale > 1f)
						{
							Main.essDir = -1;
							Main.essScale = 1f;
						}
						if ((double)Main.essScale < 0.7)
						{
							Main.essDir = 1;
							Main.essScale = 0.7f;
						}
					}
					for (int num69 = 0; num69 < 200; num69++)
					{
						if (Main.item[num69].active && Main.item[num69].type > 0)
						{
							int num70 = (int)((double)Main.item[num69].position.X + (double)Main.item[num69].width * 0.5) / 16;
							int offScreenTiles = Lighting.offScreenTiles;
							int num71 = (int)((double)Main.item[num69].position.Y + (double)Main.item[num69].height * 0.5) / 16;
							int offScreenTiles2 = Lighting.offScreenTiles;
							Microsoft.Xna.Framework.Color color33 = Lighting.GetColor((int)((double)Main.item[num69].position.X + (double)Main.item[num69].width * 0.5) / 16, (int)((double)Main.item[num69].position.Y + (double)Main.item[num69].height * 0.5) / 16);
							if (!Main.gamePaused && base.IsActive && ((Main.item[num69].type >= 71 && Main.item[num69].type <= 74) || Main.item[num69].type == 58 || Main.item[num69].type == 109) && color33.R > 60)
							{
								float num72 = (float)Main.rand.Next(500) - (Math.Abs(Main.item[num69].velocity.X) + Math.Abs(Main.item[num69].velocity.Y)) * 10f;
								if (num72 < (float)(color33.R / 50))
								{
									Vector2 position29 = Main.item[num69].position;
									int width = Main.item[num69].width;
									int height = Main.item[num69].height;
									int type = 43;
									float speedX = 0f;
									float speedY = 0f;
									int alpha = 254;
									int num73 = Dust.NewDust(position29, width, height, type, speedX, speedY, alpha, default(Microsoft.Xna.Framework.Color), 0.5f);
									Dust dust = Main.dust[num73];
									dust.velocity *= 0f;
								}
							}
							float rotation28 = Main.item[num69].velocity.X * 0.2f;
							float num74 = 1f;
							Microsoft.Xna.Framework.Color alpha2 = Main.item[num69].GetAlpha(color33);
							if (Main.item[num69].type == 520 || Main.item[num69].type == 521 || Main.item[num69].type == 547 || Main.item[num69].type == 548 || Main.item[num69].type == 549)
							{
								num74 = Main.essScale;
								alpha2.R = (byte)((float)alpha2.R * num74);
								alpha2.G = (byte)((float)alpha2.G * num74);
								alpha2.B = (byte)((float)alpha2.B * num74);
								alpha2.A = (byte)((float)alpha2.A * num74);
							}
							else if (Main.item[num69].type == 58 || Main.item[num69].type == 184)
							{
								num74 = Main.essScale * 0.25f + 0.75f;
								alpha2.R = (byte)((float)alpha2.R * num74);
								alpha2.G = (byte)((float)alpha2.G * num74);
								alpha2.B = (byte)((float)alpha2.B * num74);
								alpha2.A = (byte)((float)alpha2.A * num74);
							}
							float num75 = (float)(Main.item[num69].height - Main.itemTexture[Main.item[num69].type].Height);
							float num76 = (float)(Main.item[num69].width / 2 - Main.itemTexture[Main.item[num69].type].Width / 2);
							this.spriteBatch.Draw(Main.itemTexture[Main.item[num69].type], new Vector2(Main.item[num69].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num69].type].Width / 2) + num76, Main.item[num69].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num69].type].Height / 2) + num75 + 2f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.item[num69].type].Width, Main.itemTexture[Main.item[num69].type].Height)), alpha2, rotation28, new Vector2((float)(Main.itemTexture[Main.item[num69].type].Width / 2), (float)(Main.itemTexture[Main.item[num69].type].Height / 2)), num74, SpriteEffects.None, 0f);
							Microsoft.Xna.Framework.Color color34 = Main.item[num69].color;
							if (color34 != default(Microsoft.Xna.Framework.Color))
							{
								this.spriteBatch.Draw(Main.itemTexture[Main.item[num69].type], new Vector2(Main.item[num69].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num69].type].Width / 2) + num76, Main.item[num69].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num69].type].Height / 2) + num75 + 2f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[Main.item[num69].type].Width, Main.itemTexture[Main.item[num69].type].Height)), Main.item[num69].GetColor(color33), rotation28, new Vector2((float)(Main.itemTexture[Main.item[num69].type].Width / 2), (float)(Main.itemTexture[Main.item[num69].type].Height / 2)), num74, SpriteEffects.None, 0f);
							}
						}
					}
					Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 50, Main.screenWidth + 1000, Main.screenHeight + 100);
					for (int num77 = 0; num77 < Main.numDust; num77++)
					{
						if (Main.dust[num77].active)
						{
							if (new Microsoft.Xna.Framework.Rectangle((int)Main.dust[num77].position.X, (int)Main.dust[num77].position.Y, 4, 4).Intersects(value2))
							{
								Microsoft.Xna.Framework.Color color35 = Lighting.GetColor((int)((double)Main.dust[num77].position.X + 4.0) / 16, (int)((double)Main.dust[num77].position.Y + 4.0) / 16);
								if (Main.dust[num77].type == 6 || Main.dust[num77].type == 15 || Main.dust[num77].noLight || (Main.dust[num77].type >= 59 && Main.dust[num77].type <= 64))
								{
									color35 = Microsoft.Xna.Framework.Color.White;
								}
								color35 = Main.dust[num77].GetAlpha(color35);
								this.spriteBatch.Draw(Main.dustTexture, Main.dust[num77].position - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(Main.dust[num77].frame), color35, Main.dust[num77].rotation, new Vector2(4f, 4f), Main.dust[num77].scale, SpriteEffects.None, 0f);
								Microsoft.Xna.Framework.Color color36 = Main.dust[num77].color;
								if (color36 != default(Microsoft.Xna.Framework.Color))
								{
									this.spriteBatch.Draw(Main.dustTexture, Main.dust[num77].position - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(Main.dust[num77].frame), Main.dust[num77].GetColor(color35), Main.dust[num77].rotation, new Vector2(4f, 4f), Main.dust[num77].scale, SpriteEffects.None, 0f);
								}
								if (color35 == Microsoft.Xna.Framework.Color.Black)
								{
									Main.dust[num77].active = false;
								}
							}
							else
							{
								Main.dust[num77].active = false;
							}
						}
					}
					if (Main.drawToScreen)
					{
						this.DrawWater(false);
						if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
						{
							this.DrawWires();
						}
					}
					else
					{
						this.spriteBatch.Draw(this.waterTarget, Main.sceneWaterPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
					}
					if (!Main.hideUI)
					{
						for (int num78 = 0; num78 < 255; num78++)
						{
							if (Main.player[num78].active && Main.player[num78].chatShowTime > 0 && num78 != Main.myPlayer && !Main.player[num78].dead)
							{
								Vector2 vector = Main.fontMouseText.MeasureString(Main.player[num78].chatText);
								Vector2 vector2;
								vector2.X = Main.player[num78].position.X + (float)(Main.player[num78].width / 2) - vector.X / 2f;
								vector2.Y = Main.player[num78].position.Y - vector.Y - 2f;
								for (int num79 = 0; num79 < 5; num79++)
								{
									int num80 = 0;
									int num81 = 0;
									Microsoft.Xna.Framework.Color black = Microsoft.Xna.Framework.Color.Black;
									if (num79 == 0)
									{
										num80 = -2;
									}
									if (num79 == 1)
									{
										num80 = 2;
									}
									if (num79 == 2)
									{
										num81 = -2;
									}
									if (num79 == 3)
									{
										num81 = 2;
									}
									if (num79 == 4)
									{
										black = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
									}
									SpriteBatch spriteBatch26 = this.spriteBatch;
									SpriteFontX spriteFont = Main.fontMouseText;
									string text = Main.player[num78].chatText;
									Vector2 position30 = new Vector2(vector2.X + (float)num80 - Main.screenPosition.X, vector2.Y + (float)num81 - Main.screenPosition.Y);
									Microsoft.Xna.Framework.Color color37 = black;
									float rotation29 = 0f;
									Vector2 origin = default(Vector2);
									this.DStoDSX(spriteFont, text, position30, color37, rotation29, origin, 1f, SpriteEffects.None, 0f);
								}
							}
						}
						for (int num82 = 0; num82 < 100; num82++)
						{
							if (Main.combatText[num82].active)
							{
								int num83 = 0;
								if (Main.combatText[num82].crit)
								{
									num83 = 1;
								}
								Vector2 vector3 = Main.fontCombatText[num83].MeasureString(Main.combatText[num82].text);
								Vector2 origin2 = new Vector2(vector3.X * 0.5f, vector3.Y * 0.5f);
								float scale = Main.combatText[num82].scale;
								float num84 = (float)Main.combatText[num82].color.R;
								float num85 = (float)Main.combatText[num82].color.G;
								float num86 = (float)Main.combatText[num82].color.B;
								float num87 = (float)Main.combatText[num82].color.A;
								num84 *= Main.combatText[num82].scale * Main.combatText[num82].alpha * 0.3f;
								num86 *= Main.combatText[num82].scale * Main.combatText[num82].alpha * 0.3f;
								num85 *= Main.combatText[num82].scale * Main.combatText[num82].alpha * 0.3f;
								num87 *= Main.combatText[num82].scale * Main.combatText[num82].alpha;
								Microsoft.Xna.Framework.Color color38 = new Microsoft.Xna.Framework.Color((int)num84, (int)num85, (int)num86, (int)num87);
								for (int num88 = 0; num88 < 5; num88++)
								{
									int num89 = 0;
									int num90 = 0;
									if (num88 == 0)
									{
										num89--;
									}
									else if (num88 == 1)
									{
										num89++;
									}
									else if (num88 == 2)
									{
										num90--;
									}
									else if (num88 == 3)
									{
										num90++;
									}
									else
									{
										num84 = (float)Main.combatText[num82].color.R * Main.combatText[num82].scale * Main.combatText[num82].alpha;
										num86 = (float)Main.combatText[num82].color.B * Main.combatText[num82].scale * Main.combatText[num82].alpha;
										num85 = (float)Main.combatText[num82].color.G * Main.combatText[num82].scale * Main.combatText[num82].alpha;
										num87 = (float)Main.combatText[num82].color.A * Main.combatText[num82].scale * Main.combatText[num82].alpha;
										color38 = new Microsoft.Xna.Framework.Color((int)num84, (int)num85, (int)num86, (int)num87);
									}
									this.DStoDSX(Main.fontCombatText[num83], Main.combatText[num82].text, new Vector2(Main.combatText[num82].position.X - Main.screenPosition.X + (float)num89 + origin2.X, Main.combatText[num82].position.Y - Main.screenPosition.Y + (float)num90 + origin2.Y), color38, Main.combatText[num82].rotation, origin2, Main.combatText[num82].scale, SpriteEffects.None, 0f);
								}
							}
						}
						for (int num91 = 0; num91 < 20; num91++)
						{
							if (Main.itemText[num91].active)
							{
								string text2 = Main.itemText[num91].name;
								if (Main.itemText[num91].stack > 1)
								{
									text2 = string.Concat(new object[]
									{
										text2,
										" (",
										Main.itemText[num91].stack,
										")"
									});
								}
								Vector2 vector4 = Main.fontMouseText.MeasureString(text2);
								Vector2 origin3 = new Vector2(vector4.X * 0.5f, vector4.Y * 0.5f);
								float scale2 = Main.itemText[num91].scale;
								float num92 = (float)Main.itemText[num91].color.R;
								float num93 = (float)Main.itemText[num91].color.G;
								float num94 = (float)Main.itemText[num91].color.B;
								float num95 = (float)Main.itemText[num91].color.A;
								num92 *= Main.itemText[num91].scale * Main.itemText[num91].alpha * 0.3f;
								num94 *= Main.itemText[num91].scale * Main.itemText[num91].alpha * 0.3f;
								num93 *= Main.itemText[num91].scale * Main.itemText[num91].alpha * 0.3f;
								num95 *= Main.itemText[num91].scale * Main.itemText[num91].alpha;
								Microsoft.Xna.Framework.Color color39 = new Microsoft.Xna.Framework.Color((int)num92, (int)num93, (int)num94, (int)num95);
								for (int num96 = 0; num96 < 5; num96++)
								{
									int num97 = 0;
									int num98 = 0;
									if (num96 == 0)
									{
										num97 -= 2;
									}
									else if (num96 == 1)
									{
										num97 += 2;
									}
									else if (num96 == 2)
									{
										num98 -= 2;
									}
									else if (num96 == 3)
									{
										num98 += 2;
									}
									else
									{
										num92 = (float)Main.itemText[num91].color.R * Main.itemText[num91].scale * Main.itemText[num91].alpha;
										num94 = (float)Main.itemText[num91].color.B * Main.itemText[num91].scale * Main.itemText[num91].alpha;
										num93 = (float)Main.itemText[num91].color.G * Main.itemText[num91].scale * Main.itemText[num91].alpha;
										num95 = (float)Main.itemText[num91].color.A * Main.itemText[num91].scale * Main.itemText[num91].alpha;
										color39 = new Microsoft.Xna.Framework.Color((int)num92, (int)num93, (int)num94, (int)num95);
									}
									if (num96 < 4)
									{
										num95 = (float)Main.itemText[num91].color.A * Main.itemText[num91].scale * Main.itemText[num91].alpha;
										color39 = new Microsoft.Xna.Framework.Color(0, 0, 0, (int)num95);
									}
									this.DStoDSX(Main.fontMouseText, text2, new Vector2(Main.itemText[num91].position.X - Main.screenPosition.X + (float)num97 + origin3.X, Main.itemText[num91].position.Y - Main.screenPosition.Y + (float)num98 + origin3.Y), color39, Main.itemText[num91].rotation, origin3, Main.itemText[num91].scale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.netMode == 1 && Netplay.clientSock.statusText != "" && Netplay.clientSock.statusText != null)
						{
							string text3 = string.Concat(new object[]
							{
								Netplay.clientSock.statusText,
								": ",
								(int)((float)Netplay.clientSock.statusCount / (float)Netplay.clientSock.statusMax * 100f),
								"%"
							});
							SpriteBatch spriteBatch27 = this.spriteBatch;
							SpriteFontX spriteFont2 = Main.fontMouseText;
							string text4 = text3;
							Vector2 position31 = new Vector2(628f - Main.fontMouseText.MeasureString(text3).X * 0.5f + (float)(Main.screenWidth - 800), 84f);
							Microsoft.Xna.Framework.Color color40 = new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
							float rotation30 = 0f;
							Vector2 origin = default(Vector2);
							this.DStoDSX(spriteFont2, text4, position31, color40, rotation30, origin, 1f, SpriteEffects.None, 0f);
						}
						this.DrawFPS();
						this.DrawInterface();
					}
					else
					{
						Main.maxQ = true;
					}
					this.spriteBatch.End();
					if (Main.mouseLeft)
					{
						Main.mouseLeftRelease = false;
					}
					else
					{
						Main.mouseLeftRelease = true;
					}
					if (Main.mouseRight)
					{
						Main.mouseRightRelease = false;
					}
					else
					{
						Main.mouseRightRelease = true;
					}
					if (Main.mouseState.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
					{
						Main.stackSplit = 0;
					}
					if (Main.stackSplit > 0)
					{
						Main.stackSplit--;
					}
					if (Main.renderCount < 10)
					{
						Main.drawTimer[Main.renderCount] = (float)stopwatch.ElapsedMilliseconds;
						if (Main.drawTimerMaxDelay[Main.renderCount] > 0f)
						{
							Main.drawTimerMaxDelay[Main.renderCount] -= 1f;
						}
						else
						{
							Main.drawTimerMax[Main.renderCount] = 0f;
						}
						if (Main.drawTimer[Main.renderCount] > Main.drawTimerMax[Main.renderCount])
						{
							Main.drawTimerMax[Main.renderCount] = Main.drawTimer[Main.renderCount];
							Main.drawTimerMaxDelay[Main.renderCount] = 100f;
						}
					}
				}
			}
		}

		private static void UpdateInvasion()
		{
			if (Main.invasionType > 0)
			{
				if (Main.invasionSize <= 0)
				{
					if (Main.invasionType == 1)
					{
						NPC.downedGoblins = true;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						}
					}
					else if (Main.invasionType == 2)
					{
						NPC.downedFrost = true;
					}
					Main.InvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 7;
				}
				if (Main.invasionX != (double)Main.spawnTileX)
				{
					float num = 1f;
					if (Main.invasionX > (double)Main.spawnTileX)
					{
						Main.invasionX -= (double)num;
						if (Main.invasionX <= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							Main.InvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
					else if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							Main.InvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
					if (Main.invasionWarn <= 0)
					{
						Main.invasionWarn = 3600;
						Main.InvasionWarning();
					}
				}
			}
		}

		private static void InvasionWarning()
		{
			string str = "地精军团";
			if (Main.invasionType == 2)
			{
				str = "冰霜军团";
			}
			string text;
			if (Main.invasionSize <= 0)
			{
				text = str + "已被击退！";
			}
			else if (Main.invasionX < (double)Main.spawnTileX)
			{
				text = str + "即将从西面入侵！";
			}
			else if (Main.invasionX > (double)Main.spawnTileX)
			{
				text = str + "即将从东面入侵！";
			}
			else
			{
				text = str + "已抵达！";
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 175, 75, 255);
			}
			else if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
			}
		}

		public static void StartInvasion(int type = 1)
		{
			if (Main.invasionType == 0 && Main.invasionDelay == 0)
			{
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					Main.invasionType = type;
					Main.invasionSize = 80 + 40 * num;
					Main.invasionWarn = 0;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
					}
					else
					{
						Main.invasionX = (double)Main.maxTilesX;
					}
				}
			}
		}

		private static void UpdateClient()
		{
			if (Main.myPlayer == 255)
			{
				Netplay.disconnect = true;
			}
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				Main.netPlayCounter = 0;
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 300.0) == 0.0)
			{
				NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 600.0) == 0.0)
			{
				NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Netplay.clientSock.active)
			{
				Netplay.clientSock.timeOut++;
				if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
				{
					Main.statusText = "连接超时";
					Netplay.disconnect = true;
				}
			}
			for (int i = 0; i < 200; i++)
			{
				if (Main.item[i].active && Main.item[i].owner == Main.myPlayer)
				{
					Main.item[i].FindOwner(i);
				}
			}
		}

		private static void UpdateServer()
		{
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				NetMessage.syncPlayers();
				Main.netPlayCounter = 0;
			}
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (Main.player[i].active && Netplay.serverSock[i].active)
				{
					Netplay.serverSock[i].SpamUpdate();
				}
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
			{
				bool flag = true;
				int num = Main.lastItemUpdate;
				int num2 = 0;
				while (flag)
				{
					num++;
					if (num >= 200)
					{
						num = 0;
					}
					num2++;
					if (!Main.item[num].active || Main.item[num].owner == 255)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (num2 >= Main.maxItemUpdates || num == Main.lastItemUpdate)
					{
						flag = false;
					}
				}
				Main.lastItemUpdate = num;
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.item[j].active && (Main.item[j].owner == 255 || !Main.player[Main.item[j].owner].active))
				{
					Main.item[j].FindOwner(j);
				}
			}
			for (int k = 0; k < 255; k++)
			{
				if (Netplay.serverSock[k].active)
				{
					Netplay.serverSock[k].timeOut++;
					if (!Main.stopTimeOuts && Netplay.serverSock[k].timeOut > 60 * Main.timeOut)
					{
						Netplay.serverSock[k].kill = true;
					}
				}
				if (Main.player[k].active)
				{
					int sectionX = Netplay.GetSectionX((int)(Main.player[k].position.X / 16f));
					int sectionY = Netplay.GetSectionY((int)(Main.player[k].position.Y / 16f));
					int num3 = 0;
					for (int l = sectionX - 1; l < sectionX + 2; l++)
					{
						for (int m = sectionY - 1; m < sectionY + 2; m++)
						{
							if (l >= 0 && l < Main.maxSectionsX && m >= 0 && m < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[l, m])
							{
								num3++;
							}
						}
					}
					if (num3 > 0)
					{
						int num4 = num3 * 150;
						NetMessage.SendData(9, k, -1, "接收物块数据", num4, 0f, 0f, 0f, 0);
						Netplay.serverSock[k].statusText2 = "正在接收物块数据";
						Netplay.serverSock[k].statusMax += num4;
						for (int n = sectionX - 1; n < sectionX + 2; n++)
						{
							for (int num5 = sectionY - 1; num5 < sectionY + 2; num5++)
							{
								if (n >= 0 && n < Main.maxSectionsX && num5 >= 0 && num5 < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[n, num5])
								{
									NetMessage.SendSection(k, n, num5);
									NetMessage.SendData(11, k, -1, "", n, (float)num5, (float)n, (float)num5, 0);
								}
							}
						}
					}
				}
			}
		}

		public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255)
		{
			for (int i = Main.numChatLines - 1; i > 0; i--)
			{
				Main.chatLine[i].text = Main.chatLine[i - 1].text;
				Main.chatLine[i].showTime = Main.chatLine[i - 1].showTime;
				Main.chatLine[i].color = Main.chatLine[i - 1].color;
			}
			if (R == 0 && G == 0 && B == 0)
			{
				Main.chatLine[0].color = Microsoft.Xna.Framework.Color.White;
			}
			else
			{
				Main.chatLine[0].color = new Microsoft.Xna.Framework.Color((int)R, (int)G, (int)B);
			}
			Main.chatLine[0].text = newText;
			Main.chatLine[0].showTime = Main.chatLength;
			Main.PlaySound(12, -1, -1, 1);
		}

		private static void UpdateTime()
		{
			Main.time += (double)Main.dayRate;
			if (!Main.dayTime)
			{
				if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
				{
					for (int i = 0; i < 255; i++)
					{
						if (Main.player[i].active && !Main.player[i].dead && (double)Main.player[i].position.Y < Main.worldSurface * 16.0)
						{
							NPC.SpawnOnPlayer(i, 4);
							WorldGen.spawnEye = false;
							break;
						}
					}
				}
				if (Main.time > 32400.0)
				{
					Main.checkXMas();
					if (Main.invasionDelay > 0)
					{
						Main.invasionDelay--;
					}
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					Main.time = 0.0;
					Main.bloodMoon = false;
					Main.dayTime = true;
					Main.moonPhase++;
					if (Main.moonPhase >= 8)
					{
						Main.moonPhase = 0;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						WorldGen.saveAndPlay();
					}
					if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						if (!NPC.downedGoblins)
						{
							if (Main.rand.Next(3) == 0)
							{
								Main.StartInvasion(1);
							}
						}
						else if (Main.rand.Next(15) == 0)
						{
							Main.StartInvasion(1);
						}
					}
				}
				if (Main.time > 16200.0 && WorldGen.spawnMeteor)
				{
					WorldGen.spawnMeteor = false;
					WorldGen.dropMeteor();
				}
			}
			else
			{
				Main.bloodMoon = false;
				if (Main.time > 54000.0)
				{
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						WorldGen.spawnMeteor = true;
					}
					if (!NPC.downedBoss1 && Main.netMode != 1)
					{
						bool flag = false;
						for (int j = 0; j < 255; j++)
						{
							if (Main.player[j].active && Main.player[j].statLifeMax >= 200 && Main.player[j].statDefense > 10)
							{
								flag = true;
								break;
							}
						}
						if (flag && Main.rand.Next(3) == 0)
						{
							int num = 0;
							for (int k = 0; k < 200; k++)
							{
								if (Main.npc[k].active && Main.npc[k].townNPC)
								{
									num++;
								}
							}
							if (num >= 4)
							{
								WorldGen.spawnEye = true;
								if (Main.netMode == 0)
								{
									Main.NewText("你感到一个邪恶的生物正凝视着你...", 50, 255, 130);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, "你感到一个邪恶的生物正凝视着你...", 255, 50f, 255f, 130f, 0);
								}
							}
						}
					}
					if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
					{
						for (int l = 0; l < 255; l++)
						{
							if (Main.player[l].active && Main.player[l].statLifeMax > 120)
							{
								Main.bloodMoon = true;
								break;
							}
						}
						if (Main.bloodMoon)
						{
							if (Main.netMode == 0)
							{
								Main.NewText("血色之月正在升起...", 50, 255, 130);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, "血色之月正在升起...", 255, 50f, 255f, 130f, 0);
							}
						}
					}
					Main.time = 0.0;
					Main.dayTime = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
				if (Main.netMode != 1)
				{
					Main.checkForSpawns++;
					if (Main.checkForSpawns >= 7200)
					{
						int num2 = 0;
						for (int m = 0; m < 255; m++)
						{
							if (Main.player[m].active)
							{
								num2++;
							}
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						int num10 = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						int num14 = 0;
						int num15 = 0;
						for (int n = 0; n < 200; n++)
						{
							if (Main.npc[n].active && Main.npc[n].townNPC)
							{
								if (Main.npc[n].type != 37 && !Main.npc[n].homeless)
								{
									WorldGen.QuickFindHome(n);
								}
								if (Main.npc[n].type == 37)
								{
									num8++;
								}
								if (Main.npc[n].type == 17)
								{
									num3++;
								}
								if (Main.npc[n].type == 18)
								{
									num4++;
								}
								if (Main.npc[n].type == 19)
								{
									num6++;
								}
								if (Main.npc[n].type == 20)
								{
									num5++;
								}
								if (Main.npc[n].type == 22)
								{
									num7++;
								}
								if (Main.npc[n].type == 38)
								{
									num9++;
								}
								if (Main.npc[n].type == 54)
								{
									num10++;
								}
								if (Main.npc[n].type == 107)
								{
									num12++;
								}
								if (Main.npc[n].type == 108)
								{
									num11++;
								}
								if (Main.npc[n].type == 124)
								{
									num13++;
								}
								if (Main.npc[n].type == 142)
								{
									num14++;
								}
								num15++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num16 = 0;
							bool flag2 = false;
							int num17 = 0;
							bool flag3 = false;
							bool flag4 = false;
							for (int num18 = 0; num18 < 255; num18++)
							{
								if (Main.player[num18].active)
								{
									for (int num19 = 0; num19 < 48; num19++)
									{
										if (Main.player[num18].inventory[num19] != null & Main.player[num18].inventory[num19].stack > 0)
										{
											if (Main.player[num18].inventory[num19].type == 71)
											{
												num16 += Main.player[num18].inventory[num19].stack;
											}
											if (Main.player[num18].inventory[num19].type == 72)
											{
												num16 += Main.player[num18].inventory[num19].stack * 100;
											}
											if (Main.player[num18].inventory[num19].type == 73)
											{
												num16 += Main.player[num18].inventory[num19].stack * 10000;
											}
											if (Main.player[num18].inventory[num19].type == 74)
											{
												num16 += Main.player[num18].inventory[num19].stack * 1000000;
											}
											if (Main.player[num18].inventory[num19].ammo == 14 || Main.player[num18].inventory[num19].useAmmo == 14)
											{
												flag3 = true;
											}
											if (Main.player[num18].inventory[num19].type == 166 || Main.player[num18].inventory[num19].type == 167 || Main.player[num18].inventory[num19].type == 168 || Main.player[num18].inventory[num19].type == 235)
											{
												flag4 = true;
											}
										}
									}
									int num20 = Main.player[num18].statLifeMax / 20;
									if (num20 > 5)
									{
										flag2 = true;
									}
									num17 += num20;
								}
							}
							if (!NPC.downedBoss3 && num8 == 0)
							{
								int num21 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num21].homeless = false;
								Main.npc[num21].homeTileX = Main.dungeonX;
								Main.npc[num21].homeTileY = Main.dungeonY;
							}
							if (WorldGen.spawnNPC == 0 && num7 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num16 > 5000.0 && num3 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag2 && num4 < 1)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag3 && num6 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num5 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num3 > 0 && num9 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num10 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num12 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num11 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num13 < 1)
							{
								WorldGen.spawnNPC = 124;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedFrost && num14 < 1)
							{
								WorldGen.spawnNPC = 142;
							}
						}
					}
				}
			}
		}

		public static int DamageVar(float dmg)
		{
			float num = dmg * (1f + (float)Main.rand.Next(-15, 16) * 0.01f);
			return (int)Math.Round((double)num);
		}

		public static double CalculateDamage(int Damage, int Defense)
		{
			double num = (double)Damage - (double)Defense * 0.5;
			if (num < 1.0)
			{
				num = 1.0;
			}
			return num;
		}

		public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
		{
			int num = Style;
			try
			{
				if (!Main.dedServ)
				{
					if (Main.soundVolume != 0f)
					{
						bool flag = false;
						float num2 = 1f;
						float num3 = 0f;
						if (x == -1 || y == -1)
						{
							flag = true;
						}
						else
						{
							if (WorldGen.gen)
							{
								return;
							}
							if (Main.netMode == 2)
							{
								return;
							}
							Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle((int)(Main.screenPosition.X - (float)(Main.screenWidth * 2)), (int)(Main.screenPosition.Y - (float)(Main.screenHeight * 2)), Main.screenWidth * 5, Main.screenHeight * 5);
							Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(x, y, 1, 1);
							Vector2 vector = new Vector2(Main.screenPosition.X + (float)Main.screenWidth * 0.5f, Main.screenPosition.Y + (float)Main.screenHeight * 0.5f);
							if (rectangle.Intersects(value))
							{
								flag = true;
							}
							if (flag)
							{
								num3 = ((float)x - vector.X) / ((float)Main.screenWidth * 0.5f);
								float num4 = Math.Abs((float)x - vector.X);
								float num5 = Math.Abs((float)y - vector.Y);
								float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
								num2 = 1f - num6 / ((float)Main.screenWidth * 1.5f);
							}
						}
						if (num3 < -1f)
						{
							num3 = -1f;
						}
						if (num3 > 1f)
						{
							num3 = 1f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						if (num2 > 0f)
						{
							if (flag)
							{
								num2 *= Main.soundVolume;
								if (type == 0)
								{
									int num7 = Main.rand.Next(3);
									Main.soundInstanceDig[num7].Stop();
									Main.soundInstanceDig[num7] = Main.soundDig[num7].CreateInstance();
									Main.soundInstanceDig[num7].Volume = num2;
									Main.soundInstanceDig[num7].Pan = num3;
									Main.soundInstanceDig[num7].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceDig[num7].Play();
								}
								else if (type == 1)
								{
									int num8 = Main.rand.Next(3);
									Main.soundInstancePlayerHit[num8].Stop();
									Main.soundInstancePlayerHit[num8] = Main.soundPlayerHit[num8].CreateInstance();
									Main.soundInstancePlayerHit[num8].Volume = num2;
									Main.soundInstancePlayerHit[num8].Pan = num3;
									Main.soundInstancePlayerHit[num8].Play();
								}
								else if (type == 2)
								{
									if (num == 1)
									{
										int num9 = Main.rand.Next(3);
										if (num9 == 1)
										{
											num = 18;
										}
										if (num9 == 2)
										{
											num = 19;
										}
									}
									if (num != 9 && num != 10 && num != 24 && num != 26 && num != 34)
									{
										Main.soundInstanceItem[num].Stop();
									}
									Main.soundInstanceItem[num] = Main.soundItem[num].CreateInstance();
									Main.soundInstanceItem[num].Volume = num2;
									Main.soundInstanceItem[num].Pan = num3;
									Main.soundInstanceItem[num].Pitch = (float)Main.rand.Next(-6, 7) * 0.01f;
									if (num == 26 || num == 35)
									{
										Main.soundInstanceItem[num].Volume = num2 * 0.75f;
										Main.soundInstanceItem[num].Pitch = Main.harpNote;
									}
									Main.soundInstanceItem[num].Play();
								}
								else if (type == 3)
								{
									Main.soundInstanceNPCHit[num].Stop();
									Main.soundInstanceNPCHit[num] = Main.soundNPCHit[num].CreateInstance();
									Main.soundInstanceNPCHit[num].Volume = num2;
									Main.soundInstanceNPCHit[num].Pan = num3;
									Main.soundInstanceNPCHit[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceNPCHit[num].Play();
								}
								else if (type == 4)
								{
									if (num != 10 || Main.soundInstanceNPCKilled[num].State != SoundState.Playing)
									{
										Main.soundInstanceNPCKilled[num] = Main.soundNPCKilled[num].CreateInstance();
										Main.soundInstanceNPCKilled[num].Volume = num2;
										Main.soundInstanceNPCKilled[num].Pan = num3;
										Main.soundInstanceNPCKilled[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
										Main.soundInstanceNPCKilled[num].Play();
									}
								}
								else if (type == 5)
								{
									Main.soundInstancePlayerKilled.Stop();
									Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
									Main.soundInstancePlayerKilled.Volume = num2;
									Main.soundInstancePlayerKilled.Pan = num3;
									Main.soundInstancePlayerKilled.Play();
								}
								else if (type == 6)
								{
									Main.soundInstanceGrass.Stop();
									Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
									Main.soundInstanceGrass.Volume = num2;
									Main.soundInstanceGrass.Pan = num3;
									Main.soundInstanceGrass.Pitch = (float)Main.rand.Next(-30, 31) * 0.01f;
									Main.soundInstanceGrass.Play();
								}
								else if (type == 7)
								{
									Main.soundInstanceGrab.Stop();
									Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
									Main.soundInstanceGrab.Volume = num2;
									Main.soundInstanceGrab.Pan = num3;
									Main.soundInstanceGrab.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceGrab.Play();
								}
								else if (type == 8)
								{
									Main.soundInstanceDoorOpen.Stop();
									Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
									Main.soundInstanceDoorOpen.Volume = num2;
									Main.soundInstanceDoorOpen.Pan = num3;
									Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
									Main.soundInstanceDoorOpen.Play();
								}
								else if (type == 9)
								{
									Main.soundInstanceDoorClosed.Stop();
									Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
									Main.soundInstanceDoorClosed.Volume = num2;
									Main.soundInstanceDoorClosed.Pan = num3;
									Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
									Main.soundInstanceDoorClosed.Play();
								}
								else if (type == 10)
								{
									Main.soundInstanceMenuOpen.Stop();
									Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
									Main.soundInstanceMenuOpen.Volume = num2;
									Main.soundInstanceMenuOpen.Pan = num3;
									Main.soundInstanceMenuOpen.Play();
								}
								else if (type == 11)
								{
									Main.soundInstanceMenuClose.Stop();
									Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
									Main.soundInstanceMenuClose.Volume = num2;
									Main.soundInstanceMenuClose.Pan = num3;
									Main.soundInstanceMenuClose.Play();
								}
								else if (type == 12)
								{
									Main.soundInstanceMenuTick.Stop();
									Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
									Main.soundInstanceMenuTick.Volume = num2;
									Main.soundInstanceMenuTick.Pan = num3;
									Main.soundInstanceMenuTick.Play();
								}
								else if (type == 13)
								{
									Main.soundInstanceShatter.Stop();
									Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
									Main.soundInstanceShatter.Volume = num2;
									Main.soundInstanceShatter.Pan = num3;
									Main.soundInstanceShatter.Play();
								}
								else if (type == 14)
								{
									int num10 = Main.rand.Next(3);
									Main.soundInstanceZombie[num10] = Main.soundZombie[num10].CreateInstance();
									Main.soundInstanceZombie[num10].Volume = num2 * 0.4f;
									Main.soundInstanceZombie[num10].Pan = num3;
									Main.soundInstanceZombie[num10].Play();
								}
								else if (type == 15)
								{
									if (Main.soundInstanceRoar[num].State == SoundState.Stopped)
									{
										Main.soundInstanceRoar[num] = Main.soundRoar[num].CreateInstance();
										Main.soundInstanceRoar[num].Volume = num2;
										Main.soundInstanceRoar[num].Pan = num3;
										Main.soundInstanceRoar[num].Play();
									}
								}
								else if (type == 16)
								{
									Main.soundInstanceDoubleJump.Stop();
									Main.soundInstanceDoubleJump = Main.soundDoubleJump.CreateInstance();
									Main.soundInstanceDoubleJump.Volume = num2;
									Main.soundInstanceDoubleJump.Pan = num3;
									Main.soundInstanceDoubleJump.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceDoubleJump.Play();
								}
								else if (type == 17)
								{
									Main.soundInstanceRun.Stop();
									Main.soundInstanceRun = Main.soundRun.CreateInstance();
									Main.soundInstanceRun.Volume = num2;
									Main.soundInstanceRun.Pan = num3;
									Main.soundInstanceRun.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceRun.Play();
								}
								else if (type == 18)
								{
									Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
									Main.soundInstanceCoins.Volume = num2;
									Main.soundInstanceCoins.Pan = num3;
									Main.soundInstanceCoins.Play();
								}
								else if (type == 19)
								{
									if (Main.soundInstanceSplash[num].State == SoundState.Stopped)
									{
										Main.soundInstanceSplash[num] = Main.soundSplash[num].CreateInstance();
										Main.soundInstanceSplash[num].Volume = num2;
										Main.soundInstanceSplash[num].Pan = num3;
										Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
										Main.soundInstanceSplash[num].Play();
									}
								}
								else if (type == 20)
								{
									int num11 = Main.rand.Next(3);
									Main.soundInstanceFemaleHit[num11].Stop();
									Main.soundInstanceFemaleHit[num11] = Main.soundFemaleHit[num11].CreateInstance();
									Main.soundInstanceFemaleHit[num11].Volume = num2;
									Main.soundInstanceFemaleHit[num11].Pan = num3;
									Main.soundInstanceFemaleHit[num11].Play();
								}
								else if (type == 21)
								{
									int num12 = Main.rand.Next(3);
									Main.soundInstanceTink[num12].Stop();
									Main.soundInstanceTink[num12] = Main.soundTink[num12].CreateInstance();
									Main.soundInstanceTink[num12].Volume = num2;
									Main.soundInstanceTink[num12].Pan = num3;
									Main.soundInstanceTink[num12].Play();
								}
								else if (type == 22)
								{
									Main.soundInstanceUnlock.Stop();
									Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
									Main.soundInstanceUnlock.Volume = num2;
									Main.soundInstanceUnlock.Pan = num3;
									Main.soundInstanceUnlock.Play();
								}
								else if (type == 23)
								{
									Main.soundInstanceDrown.Stop();
									Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
									Main.soundInstanceDrown.Volume = num2;
									Main.soundInstanceDrown.Pan = num3;
									Main.soundInstanceDrown.Play();
								}
								else if (type == 24)
								{
									Main.soundInstanceChat = Main.soundChat.CreateInstance();
									Main.soundInstanceChat.Volume = num2;
									Main.soundInstanceChat.Pan = num3;
									Main.soundInstanceChat.Play();
								}
								else if (type == 25)
								{
									Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
									Main.soundInstanceMaxMana.Volume = num2;
									Main.soundInstanceMaxMana.Pan = num3;
									Main.soundInstanceMaxMana.Play();
								}
								else if (type == 26)
								{
									int num13 = Main.rand.Next(3, 5);
									Main.soundInstanceZombie[num13] = Main.soundZombie[num13].CreateInstance();
									Main.soundInstanceZombie[num13].Volume = num2 * 0.9f;
									Main.soundInstanceZombie[num13].Pan = num3;
									Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceZombie[num13].Play();
								}
								else if (type == 27)
								{
									if (Main.soundInstancePixie.State == SoundState.Playing)
									{
										Main.soundInstancePixie.Volume = num2;
										Main.soundInstancePixie.Pan = num3;
										Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									}
									else
									{
										Main.soundInstancePixie.Stop();
										Main.soundInstancePixie = Main.soundPixie.CreateInstance();
										Main.soundInstancePixie.Volume = num2;
										Main.soundInstancePixie.Pan = num3;
										Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
										Main.soundInstancePixie.Play();
									}
								}
								else if (type == 28)
								{
									if (Main.soundInstanceMech[num].State != SoundState.Playing)
									{
										Main.soundInstanceMech[num] = Main.soundMech[num].CreateInstance();
										Main.soundInstanceMech[num].Volume = num2;
										Main.soundInstanceMech[num].Pan = num3;
										Main.soundInstanceMech[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
										Main.soundInstanceMech[num].Play();
									}
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
