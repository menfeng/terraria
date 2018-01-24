using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public class NPC
	{
		public const int maxBuffs = 5;

		public static int immuneTime = 20;

		public static int maxAI = 4;

		public int netSpam;

		private static int spawnSpaceX = 3;

		private static int spawnSpaceY = 3;

		private static int maxAttack = 20;

		private static int[] attackNPC = new int[NPC.maxAttack];

		public Vector2[] oldPos = new Vector2[10];

		public int netSkip;

		public bool netAlways;

		public int realLife = -1;

		public static int sWidth = 1920;

		public static int sHeight = 1080;

		private static int spawnRangeX = (int)((double)(NPC.sWidth / 16) * 0.7);

		private static int spawnRangeY = (int)((double)(NPC.sHeight / 16) * 0.7);

		public static int safeRangeX = (int)((double)(NPC.sWidth / 16) * 0.52);

		public static int safeRangeY = (int)((double)(NPC.sHeight / 16) * 0.52);

		private static int activeRangeX = (int)((double)NPC.sWidth * 1.7);

		private static int activeRangeY = (int)((double)NPC.sHeight * 1.7);

		private static int townRangeX = NPC.sWidth;

		private static int townRangeY = NPC.sHeight;

		public float npcSlots = 1f;

		private static bool noSpawnCycle = false;

		private static int activeTime = 750;

		private static int defaultSpawnRate = 600;

		private static int defaultMaxSpawns = 5;

		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public int[] buffType = new int[5];

		public int[] buffTime = new int[5];

		public bool[] buffImmune = new bool[40];

		public bool onFire;

		public bool onFire2;

		public bool poisoned;

		public int lifeRegen;

		public int lifeRegenCount;

		public bool confused;

		public static bool downedBoss1 = false;

		public static bool downedBoss2 = false;

		public static bool downedBoss3 = false;

		public static bool savedGoblin = false;

		public static bool savedWizard = false;

		public static bool savedMech = false;

		public static bool downedGoblins = false;

		public static bool downedFrost = false;

		public static bool downedClown = false;

		private static int spawnRate = NPC.defaultSpawnRate;

		private static int maxSpawns = NPC.defaultMaxSpawns;

		public int soundDelay;

		public Vector2 position;

		public Vector2 velocity;

		public Vector2 oldPosition;

		public Vector2 oldVelocity;

		public int width;

		public int height;

		public bool active;

		public int[] immune = new int[256];

		public int direction = 1;

		public int directionY = 1;

		public int type;

		public float[] ai = new float[NPC.maxAI];

		public float[] localAI = new float[NPC.maxAI];

		public int aiAction;

		public int aiStyle;

		public bool justHit;

		public int timeLeft;

		public int target = -1;

		public int damage;

		public int defense;

		public int defDamage;

		public int defDefense;

		public int soundHit;

		public int soundKilled;

		public int life;

		public int lifeMax;

		public Rectangle targetRect;

		public double frameCounter;

		public Rectangle frame;

		public string name;

		public string CName;

		public string displayName;

		public string displayCName;

		public Color color;

		public int alpha;

		public float scale = 1f;

		public float knockBackResist = 1f;

		public int oldDirection;

		public int oldDirectionY;

		public int oldTarget;

		public int whoAmI;

		public float rotation;

		public bool noGravity;

		public bool noTileCollide;

		public bool netUpdate;

		public bool netUpdate2;

		public bool collideX;

		public bool collideY;

		public bool boss;

		public int spriteDirection = -1;

		public bool behindTiles;

		public bool lavaImmune;

		public float value;

		public bool dontTakeDamage;

		public int netID;

		public bool townNPC;

		public bool homeless;

		public int homeTileX = -1;

		public int homeTileY = -1;

		public bool oldHomeless;

		public int oldHomeTileX = -1;

		public int oldHomeTileY = -1;

		public bool friendly;

		public bool closeDoor;

		public int doorX;

		public int doorY;

		public int friendlyRegen;

		public static void clrNames()
		{
			for (int i = 0; i < 147; i++)
			{
				Main.chrName[i] = "";
			}
		}

		public static void setNames()
		{
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random();
			}
			int num = WorldGen.genRand.Next(23);
			string text;
			if (num == 0)
			{
				text = "Molly";
			}
			else if (num == 1)
			{
				text = "Amy";
			}
			else if (num == 2)
			{
				text = "Claire";
			}
			else if (num == 3)
			{
				text = "Emily";
			}
			else if (num == 4)
			{
				text = "Katie";
			}
			else if (num == 5)
			{
				text = "Madeline";
			}
			else if (num == 6)
			{
				text = "Katelyn";
			}
			else if (num == 7)
			{
				text = "Emma";
			}
			else if (num == 8)
			{
				text = "Abigail";
			}
			else if (num == 9)
			{
				text = "Carly";
			}
			else if (num == 10)
			{
				text = "Jenna";
			}
			else if (num == 11)
			{
				text = "Heather";
			}
			else if (num == 12)
			{
				text = "Katherine";
			}
			else if (num == 13)
			{
				text = "Caitlin";
			}
			else if (num == 14)
			{
				text = "Kaitlin";
			}
			else if (num == 15)
			{
				text = "Holly";
			}
			else if (num == 16)
			{
				text = "Kaitlyn";
			}
			else if (num == 17)
			{
				text = "Hannah";
			}
			else if (num == 18)
			{
				text = "Kathryn";
			}
			else if (num == 19)
			{
				text = "Lorraine";
			}
			else if (num == 20)
			{
				text = "Helen";
			}
			else if (num == 21)
			{
				text = "Kayla";
			}
			else
			{
				text = "Allison";
			}
			if (Main.chrName[18] == "")
			{
				Main.chrName[18] = text;
			}
			num = WorldGen.genRand.Next(24);
			if (num == 0)
			{
				text = "Shayna";
			}
			else if (num == 1)
			{
				text = "Korrie";
			}
			else if (num == 2)
			{
				text = "Ginger";
			}
			else if (num == 3)
			{
				text = "Brooke";
			}
			else if (num == 4)
			{
				text = "Jenny";
			}
			else if (num == 5)
			{
				text = "Autumn";
			}
			else if (num == 6)
			{
				text = "Nancy";
			}
			else if (num == 7)
			{
				text = "Ella";
			}
			else if (num == 8)
			{
				text = "Kayla";
			}
			else if (num == 9)
			{
				text = "Beth";
			}
			else if (num == 10)
			{
				text = "Sophia";
			}
			else if (num == 11)
			{
				text = "Marshanna";
			}
			else if (num == 12)
			{
				text = "Lauren";
			}
			else if (num == 13)
			{
				text = "Trisha";
			}
			else if (num == 14)
			{
				text = "Shirlena";
			}
			else if (num == 15)
			{
				text = "Sheena";
			}
			else if (num == 16)
			{
				text = "Ellen";
			}
			else if (num == 17)
			{
				text = "Amy";
			}
			else if (num == 18)
			{
				text = "Dawn";
			}
			else if (num == 19)
			{
				text = "Susana";
			}
			else if (num == 20)
			{
				text = "Meredith";
			}
			else if (num == 21)
			{
				text = "Selene";
			}
			else if (num == 22)
			{
				text = "Terra";
			}
			else
			{
				text = "Sally";
			}
			if (Main.chrName[124] == "")
			{
				Main.chrName[124] = text;
			}
			num = WorldGen.genRand.Next(23);
			if (num == 0)
			{
				text = "DeShawn";
			}
			else if (num == 1)
			{
				text = "DeAndre";
			}
			else if (num == 2)
			{
				text = "Marquis";
			}
			else if (num == 3)
			{
				text = "Darnell";
			}
			else if (num == 4)
			{
				text = "Terrell";
			}
			else if (num == 5)
			{
				text = "Malik";
			}
			else if (num == 6)
			{
				text = "Trevon";
			}
			else if (num == 7)
			{
				text = "Tyrone";
			}
			else if (num == 8)
			{
				text = "Willie";
			}
			else if (num == 9)
			{
				text = "Dominique";
			}
			else if (num == 10)
			{
				text = "Demetrius";
			}
			else if (num == 11)
			{
				text = "Reginald";
			}
			else if (num == 12)
			{
				text = "Jamal";
			}
			else if (num == 13)
			{
				text = "Maurice";
			}
			else if (num == 14)
			{
				text = "Jalen";
			}
			else if (num == 15)
			{
				text = "Darius";
			}
			else if (num == 16)
			{
				text = "Xavier";
			}
			else if (num == 17)
			{
				text = "Terrance";
			}
			else if (num == 18)
			{
				text = "Andre";
			}
			else if (num == 19)
			{
				text = "Dante";
			}
			else if (num == 20)
			{
				text = "Brimst";
			}
			else if (num == 21)
			{
				text = "Bronson";
			}
			else
			{
				text = "Darryl";
			}
			if (Main.chrName[19] == "")
			{
				Main.chrName[19] = text;
			}
			num = WorldGen.genRand.Next(35);
			if (num == 0)
			{
				text = "Jake";
			}
			else if (num == 1)
			{
				text = "Connor";
			}
			else if (num == 2)
			{
				text = "Tanner";
			}
			else if (num == 3)
			{
				text = "Wyatt";
			}
			else if (num == 4)
			{
				text = "Cody";
			}
			else if (num == 5)
			{
				text = "Dustin";
			}
			else if (num == 6)
			{
				text = "Luke";
			}
			else if (num == 7)
			{
				text = "Jack";
			}
			else if (num == 8)
			{
				text = "Scott";
			}
			else if (num == 9)
			{
				text = "Logan";
			}
			else if (num == 10)
			{
				text = "Cole";
			}
			else if (num == 11)
			{
				text = "Lucas";
			}
			else if (num == 12)
			{
				text = "Bradley";
			}
			else if (num == 13)
			{
				text = "Jacob";
			}
			else if (num == 14)
			{
				text = "Garrett";
			}
			else if (num == 15)
			{
				text = "Dylan";
			}
			else if (num == 16)
			{
				text = "Maxwell";
			}
			else if (num == 17)
			{
				text = "Steve";
			}
			else if (num == 18)
			{
				text = "Brett";
			}
			else if (num == 19)
			{
				text = "Andrew";
			}
			else if (num == 20)
			{
				text = "Harley";
			}
			else if (num == 21)
			{
				text = "Kyle";
			}
			else if (num == 22)
			{
				text = "Jake";
			}
			else if (num == 23)
			{
				text = "Ryan";
			}
			else if (num == 24)
			{
				text = "Jeffrey";
			}
			else if (num == 25)
			{
				text = "Seth";
			}
			else if (num == 26)
			{
				text = "Marty";
			}
			else if (num == 27)
			{
				text = "Brandon";
			}
			else if (num == 28)
			{
				text = "Zach";
			}
			else if (num == 29)
			{
				text = "Jeff";
			}
			else if (num == 30)
			{
				text = "Daniel";
			}
			else if (num == 31)
			{
				text = "Trent";
			}
			else if (num == 32)
			{
				text = "Kevin";
			}
			else if (num == 33)
			{
				text = "Brian";
			}
			else
			{
				text = "Colin";
			}
			if (Main.chrName[22] == "")
			{
				Main.chrName[22] = text;
			}
			num = WorldGen.genRand.Next(22);
			if (num == 0)
			{
				text = "Alalia";
			}
			else if (num == 1)
			{
				text = "Alalia";
			}
			else if (num == 2)
			{
				text = "Alura";
			}
			else if (num == 3)
			{
				text = "Ariella";
			}
			else if (num == 4)
			{
				text = "Caelia";
			}
			else if (num == 5)
			{
				text = "Calista";
			}
			else if (num == 6)
			{
				text = "Chryseis";
			}
			else if (num == 7)
			{
				text = "Emerenta";
			}
			else if (num == 8)
			{
				text = "Elysia";
			}
			else if (num == 9)
			{
				text = "Evvie";
			}
			else if (num == 10)
			{
				text = "Faye";
			}
			else if (num == 11)
			{
				text = "Felicitae";
			}
			else if (num == 12)
			{
				text = "Lunette";
			}
			else if (num == 13)
			{
				text = "Nata";
			}
			else if (num == 14)
			{
				text = "Nissa";
			}
			else if (num == 15)
			{
				text = "Tatiana";
			}
			else if (num == 16)
			{
				text = "Rosalva";
			}
			else if (num == 17)
			{
				text = "Shea";
			}
			else if (num == 18)
			{
				text = "Tania";
			}
			else if (num == 19)
			{
				text = "Isis";
			}
			else if (num == 20)
			{
				text = "Celestia";
			}
			else
			{
				text = "Xylia";
			}
			if (Main.chrName[20] == "")
			{
				Main.chrName[20] = text;
			}
			num = WorldGen.genRand.Next(22);
			if (num == 0)
			{
				text = "Dolbere";
			}
			else if (num == 1)
			{
				text = "Bazdin";
			}
			else if (num == 2)
			{
				text = "Durim";
			}
			else if (num == 3)
			{
				text = "Tordak";
			}
			else if (num == 4)
			{
				text = "Garval";
			}
			else if (num == 5)
			{
				text = "Morthal";
			}
			else if (num == 6)
			{
				text = "Oten";
			}
			else if (num == 7)
			{
				text = "Dolgen";
			}
			else if (num == 8)
			{
				text = "Gimli";
			}
			else if (num == 9)
			{
				text = "Gimut";
			}
			else if (num == 10)
			{
				text = "Duerthen";
			}
			else if (num == 11)
			{
				text = "Beldin";
			}
			else if (num == 12)
			{
				text = "Jarut";
			}
			else if (num == 13)
			{
				text = "Ovbere";
			}
			else if (num == 14)
			{
				text = "Norkas";
			}
			else if (num == 15)
			{
				text = "Dolgrim";
			}
			else if (num == 16)
			{
				text = "Boften";
			}
			else if (num == 17)
			{
				text = "Norsun";
			}
			else if (num == 18)
			{
				text = "Dias";
			}
			else if (num == 19)
			{
				text = "Fikod";
			}
			else if (num == 20)
			{
				text = "Urist";
			}
			else
			{
				text = "Darur";
			}
			if (Main.chrName[38] == "")
			{
				Main.chrName[38] = text;
			}
			num = WorldGen.genRand.Next(21);
			if (num == 0)
			{
				text = "Dalamar";
			}
			else if (num == 1)
			{
				text = "Dulais";
			}
			else if (num == 2)
			{
				text = "Elric";
			}
			else if (num == 3)
			{
				text = "Arddun";
			}
			else if (num == 4)
			{
				text = "Maelor";
			}
			else if (num == 5)
			{
				text = "Leomund";
			}
			else if (num == 6)
			{
				text = "Hirael";
			}
			else if (num == 7)
			{
				text = "Gwentor";
			}
			else if (num == 8)
			{
				text = "Greum";
			}
			else if (num == 9)
			{
				text = "Gearroid";
			}
			else if (num == 10)
			{
				text = "Fizban";
			}
			else if (num == 11)
			{
				text = "Ningauble";
			}
			else if (num == 12)
			{
				text = "Seonag";
			}
			else if (num == 13)
			{
				text = "Sargon";
			}
			else if (num == 14)
			{
				text = "Merlyn";
			}
			else if (num == 15)
			{
				text = "Magius";
			}
			else if (num == 16)
			{
				text = "Berwyn";
			}
			else if (num == 17)
			{
				text = "Arwyn";
			}
			else if (num == 18)
			{
				text = "Alasdair";
			}
			else if (num == 19)
			{
				text = "Tagar";
			}
			else
			{
				text = "Xanadu";
			}
			if (Main.chrName[108] == "")
			{
				Main.chrName[108] = text;
			}
			num = WorldGen.genRand.Next(23);
			if (num == 0)
			{
				text = "Alfred";
			}
			else if (num == 1)
			{
				text = "Barney";
			}
			else if (num == 2)
			{
				text = "Calvin";
			}
			else if (num == 3)
			{
				text = "Edmund";
			}
			else if (num == 4)
			{
				text = "Edwin";
			}
			else if (num == 5)
			{
				text = "Eugene";
			}
			else if (num == 6)
			{
				text = "Frank";
			}
			else if (num == 7)
			{
				text = "Frederick";
			}
			else if (num == 8)
			{
				text = "Gilbert";
			}
			else if (num == 9)
			{
				text = "Gus";
			}
			else if (num == 10)
			{
				text = "Wilbur";
			}
			else if (num == 11)
			{
				text = "Seymour";
			}
			else if (num == 12)
			{
				text = "Louis";
			}
			else if (num == 13)
			{
				text = "Humphrey";
			}
			else if (num == 14)
			{
				text = "Harold";
			}
			else if (num == 15)
			{
				text = "Milton";
			}
			else if (num == 16)
			{
				text = "Mortimer";
			}
			else if (num == 17)
			{
				text = "Howard";
			}
			else if (num == 18)
			{
				text = "Walter";
			}
			else if (num == 19)
			{
				text = "Finn";
			}
			else if (num == 20)
			{
				text = "Isacc";
			}
			else if (num == 21)
			{
				text = "Joseph";
			}
			else
			{
				text = "Ralph";
			}
			if (Main.chrName[17] == "")
			{
				Main.chrName[17] = text;
			}
			num = WorldGen.genRand.Next(24);
			if (num == 0)
			{
				text = "Sebastian";
			}
			else if (num == 1)
			{
				text = "Rupert";
			}
			else if (num == 2)
			{
				text = "Clive";
			}
			else if (num == 3)
			{
				text = "Nigel";
			}
			else if (num == 4)
			{
				text = "Mervyn";
			}
			else if (num == 5)
			{
				text = "Cedric";
			}
			else if (num == 6)
			{
				text = "Pip";
			}
			else if (num == 7)
			{
				text = "Cyril";
			}
			else if (num == 8)
			{
				text = "Fitz";
			}
			else if (num == 9)
			{
				text = "Lloyd";
			}
			else if (num == 10)
			{
				text = "Arthur";
			}
			else if (num == 11)
			{
				text = "Rodney";
			}
			else if (num == 12)
			{
				text = "Graham";
			}
			else if (num == 13)
			{
				text = "Edward";
			}
			else if (num == 14)
			{
				text = "Alfred";
			}
			else if (num == 15)
			{
				text = "Edmund";
			}
			else if (num == 16)
			{
				text = "Henry";
			}
			else if (num == 17)
			{
				text = "Herald";
			}
			else if (num == 18)
			{
				text = "Roland";
			}
			else if (num == 19)
			{
				text = "Lincoln";
			}
			else if (num == 20)
			{
				text = "Lloyd";
			}
			else if (num == 21)
			{
				text = "Edgar";
			}
			else if (num == 22)
			{
				text = "Eustace";
			}
			else
			{
				text = "Rodrick";
			}
			if (Main.chrName[54] == "")
			{
				Main.chrName[54] = text;
			}
			num = WorldGen.genRand.Next(25);
			if (num == 0)
			{
				text = "Grodax";
			}
			else if (num == 1)
			{
				text = "Sarx";
			}
			else if (num == 2)
			{
				text = "Xon";
			}
			else if (num == 3)
			{
				text = "Mrunok";
			}
			else if (num == 4)
			{
				text = "Nuxatk";
			}
			else if (num == 5)
			{
				text = "Tgerd";
			}
			else if (num == 6)
			{
				text = "Darz";
			}
			else if (num == 7)
			{
				text = "Smador";
			}
			else if (num == 8)
			{
				text = "Stazen";
			}
			else if (num == 9)
			{
				text = "Mobart";
			}
			else if (num == 10)
			{
				text = "Knogs";
			}
			else if (num == 11)
			{
				text = "Tkanus";
			}
			else if (num == 12)
			{
				text = "Negurk";
			}
			else if (num == 13)
			{
				text = "Nort";
			}
			else if (num == 14)
			{
				text = "Durnok";
			}
			else if (num == 15)
			{
				text = "Trogem";
			}
			else if (num == 16)
			{
				text = "Stezom";
			}
			else if (num == 17)
			{
				text = "Gnudar";
			}
			else if (num == 18)
			{
				text = "Ragz";
			}
			else if (num == 19)
			{
				text = "Fahd";
			}
			else if (num == 20)
			{
				text = "Xanos";
			}
			else if (num == 21)
			{
				text = "Arback";
			}
			else if (num == 22)
			{
				text = "Fjell";
			}
			else if (num == 23)
			{
				text = "Dalek";
			}
			else
			{
				text = "Knub";
			}
			if (Main.chrName[107] == "")
			{
				Main.chrName[107] = text;
			}
		}

		public void netDefaults(int type)
		{
			if (type < 0)
			{
				if (type == -1)
				{
					this.SetDefaults("Slimeling");
				}
				else if (type == -2)
				{
					this.SetDefaults("Slimer2");
				}
				else if (type == -3)
				{
					this.SetDefaults("Green Slime");
				}
				else if (type == -4)
				{
					this.SetDefaults("Pinky");
				}
				else if (type == -5)
				{
					this.SetDefaults("Baby Slime");
				}
				else if (type == -6)
				{
					this.SetDefaults("Black Slime");
				}
				else if (type == -7)
				{
					this.SetDefaults("Purple Slime");
				}
				else if (type == -8)
				{
					this.SetDefaults("Red Slime");
				}
				else if (type == -9)
				{
					this.SetDefaults("Yellow Slime");
				}
				else if (type == -10)
				{
					this.SetDefaults("Jungle Slime");
				}
				else if (type == -11)
				{
					this.SetDefaults("Little Eater");
				}
				else if (type == -12)
				{
					this.SetDefaults("Big Eater");
				}
				else if (type == -13)
				{
					this.SetDefaults("Short Bones");
				}
				else if (type == -14)
				{
					this.SetDefaults("Big Boned");
				}
				else if (type == -15)
				{
					this.SetDefaults("Heavy Skeleton");
				}
				else if (type == -16)
				{
					this.SetDefaults("Little Stinger");
				}
				else if (type == -17)
				{
					this.SetDefaults("Big Stinger");
				}
			}
			else
			{
				this.SetDefaults(type, -1f);
			}
		}

		public void SetDefaults(string Name)
		{
			this.SetDefaults(0, -1f);
			if (Name == "Slimeling")
			{
				this.SetDefaults(81, 0.6f);
				this.name = Name;
				this.CName = "腐蚀体液";
				this.damage = 45;
				this.defense = 10;
				this.life = 90;
				this.knockBackResist = 1.2f;
				this.value = 100f;
				this.netID = -1;
			}
			else if (Name == "Slimer2")
			{
				this.SetDefaults(81, 0.9f);
				this.displayName = "Slimer";
				this.displayCName = "飞翼史莱姆";
				this.name = Name;
				this.CName = "飞翼史莱姆";
				this.damage = 45;
				this.defense = 20;
				this.life = 90;
				this.knockBackResist = 1.2f;
				this.value = 100f;
				this.netID = -2;
			}
			else if (Name == "Green Slime")
			{
				this.SetDefaults(1, 0.9f);
				this.name = Name;
				this.CName = "绿色史莱姆";
				this.damage = 6;
				this.defense = 0;
				this.life = 14;
				this.knockBackResist = 1.2f;
				this.color = new Color(0, 220, 40, 100);
				this.value = 3f;
				this.netID = -3;
			}
			else if (Name == "Pinky")
			{
				this.SetDefaults(1, 0.6f);
				this.name = Name;
				this.CName = "粉红波利";
				this.damage = 5;
				this.defense = 5;
				this.life = 150;
				this.knockBackResist = 1.4f;
				this.color = new Color(250, 30, 90, 90);
				this.value = 10000f;
				this.netID = -4;
			}
			else if (Name == "Baby Slime")
			{
				this.SetDefaults(1, 0.9f);
				this.name = Name;
				this.CName = "史莱姆幼体";
				this.damage = 13;
				this.defense = 4;
				this.life = 30;
				this.knockBackResist = 0.95f;
				this.alpha = 120;
				this.color = new Color(0, 0, 0, 50);
				this.value = 10f;
				this.netID = -5;
			}
			else if (Name == "Black Slime")
			{
				this.SetDefaults(1, -1f);
				this.name = Name;
				this.CName = "黑色史莱姆";
				this.damage = 15;
				this.defense = 4;
				this.life = 45;
				this.color = new Color(0, 0, 0, 50);
				this.value = 20f;
				this.netID = -6;
			}
			else if (Name == "Purple Slime")
			{
				this.SetDefaults(1, 1.2f);
				this.name = Name;
				this.CName = "紫色史莱姆";
				this.damage = 12;
				this.defense = 6;
				this.life = 40;
				this.knockBackResist = 0.9f;
				this.color = new Color(200, 0, 255, 150);
				this.value = 10f;
				this.netID = -7;
			}
			else if (Name == "Red Slime")
			{
				this.SetDefaults(1, -1f);
				this.name = Name;
				this.CName = "红色史莱姆";
				this.damage = 12;
				this.defense = 4;
				this.life = 35;
				this.color = new Color(255, 30, 0, 100);
				this.value = 8f;
				this.netID = -8;
			}
			else if (Name == "Yellow Slime")
			{
				this.SetDefaults(1, 1.2f);
				this.name = Name;
				this.CName = "黄色史莱姆";
				this.damage = 15;
				this.defense = 7;
				this.life = 45;
				this.color = new Color(255, 255, 0, 100);
				this.value = 10f;
				this.netID = -9;
			}
			else if (Name == "Jungle Slime")
			{
				this.SetDefaults(1, 1.1f);
				this.name = Name;
				this.CName = "丛林史莱姆";
				this.damage = 18;
				this.defense = 6;
				this.life = 60;
				this.color = new Color(143, 215, 93, 100);
				this.value = 500f;
				this.netID = -10;
			}
			else if (Name == "Little Eater")
			{
				this.SetDefaults(6, 0.85f);
				this.name = Name;
				this.CName = "噬灵虫";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((float)this.damage * this.scale);
				this.life = (int)((float)this.life * this.scale);
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots *= this.scale;
				this.knockBackResist *= 2f - this.scale;
				this.netID = -11;
			}
			else if (Name == "Big Eater")
			{
				this.SetDefaults(6, 1.15f);
				this.name = Name;
				this.CName = "吞灵虫";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((float)this.damage * this.scale);
				this.life = (int)((float)this.life * this.scale);
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots *= this.scale;
				this.knockBackResist *= 2f - this.scale;
				this.netID = -12;
			}
			else if (Name == "Short Bones")
			{
				this.SetDefaults(31, 0.9f);
				this.name = Name;
				this.CName = "愤怒骷髅";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((float)this.damage * this.scale);
				this.life = (int)((float)this.life * this.scale);
				this.value = (float)((int)(this.value * this.scale));
				this.netID = -13;
			}
			else if (Name == "Big Boned")
			{
				this.SetDefaults(31, 1.15f);
				this.name = Name;
				this.CName = "狂暴骷髅";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((double)((float)this.damage * this.scale) * 1.1);
				this.life = (int)((double)((float)this.life * this.scale) * 1.1);
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots = 2f;
				this.knockBackResist *= 2f - this.scale;
				this.netID = -14;
			}
			else if (Name == "Heavy Skeleton")
			{
				this.SetDefaults(77, 1.15f);
				this.name = Name;
				this.CName = "重甲骷髅";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((double)((float)this.damage * this.scale) * 1.1);
				this.life = 400;
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots = 2f;
				this.knockBackResist *= 2f - this.scale;
				this.height = 44;
				this.netID = -15;
			}
			else if (Name == "Little Stinger")
			{
				this.SetDefaults(42, 0.85f);
				this.name = Name;
				this.CName = "小黄蜂";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((float)this.damage * this.scale);
				this.life = (int)((float)this.life * this.scale);
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots *= this.scale;
				this.knockBackResist *= 2f - this.scale;
				this.netID = -16;
			}
			else if (Name == "Big Stinger")
			{
				this.SetDefaults(42, 1.2f);
				this.name = Name;
				this.CName = "巨黄蜂";
				this.defense = (int)((float)this.defense * this.scale);
				this.damage = (int)((float)this.damage * this.scale);
				this.life = (int)((float)this.life * this.scale);
				this.value = (float)((int)(this.value * this.scale));
				this.npcSlots *= this.scale;
				this.knockBackResist *= 2f - this.scale;
				this.netID = -17;
			}
			else if (Name != "")
			{
				for (int i = 1; i < 147; i++)
				{
					if (Main.npcName[i] == Name)
					{
						this.SetDefaults(i, -1f);
						return;
					}
				}
				this.SetDefaults(0, -1f);
				this.active = false;
			}
			else
			{
				this.active = false;
			}
			if (this.displayName == null || this.displayName == "")
			{
				this.displayName = Name;
				this.displayCName = this.CName;
			}
			this.lifeMax = this.life;
			this.defDamage = this.damage;
			this.defDefense = this.defense;
		}

		public static bool MechSpawn(float x, float y, int type)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == type)
				{
					num++;
					Vector2 vector = new Vector2(x, y);
					float num4 = Main.npc[i].position.X - vector.X;
					float num5 = Main.npc[i].position.Y - vector.Y;
					float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
					if (num6 < 200f)
					{
						num2++;
					}
					if (num6 < 600f)
					{
						num3++;
					}
				}
			}
			return num2 < 3 && num3 < 6 && num < 10;
		}

		public static int TypeToNum(int type)
		{
			int result;
			if (type == 17)
			{
				result = 2;
			}
			else if (type == 18)
			{
				result = 3;
			}
			else if (type == 19)
			{
				result = 6;
			}
			else if (type == 20)
			{
				result = 5;
			}
			else if (type == 22)
			{
				result = 1;
			}
			else if (type == 38)
			{
				result = 4;
			}
			else if (type == 54)
			{
				result = 7;
			}
			else if (type == 107)
			{
				result = 9;
			}
			else if (type == 108)
			{
				result = 10;
			}
			else if (type == 124)
			{
				result = 8;
			}
			else if (type == 142)
			{
				result = 11;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public static int NumToType(int type)
		{
			int result;
			if (type == 2)
			{
				result = 17;
			}
			else if (type == 3)
			{
				result = 18;
			}
			else if (type == 6)
			{
				result = 19;
			}
			else if (type == 5)
			{
				result = 20;
			}
			else if (type == 1)
			{
				result = 22;
			}
			else if (type == 4)
			{
				result = 38;
			}
			else if (type == 7)
			{
				result = 54;
			}
			else if (type == 9)
			{
				result = 107;
			}
			else if (type == 10)
			{
				result = 108;
			}
			else if (type == 8)
			{
				result = 124;
			}
			else if (type == 11)
			{
				result = 142;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public void SetDefaults(int Type, float scaleOverride = -1f)
		{
			this.netID = 0;
			this.netAlways = false;
			this.netSpam = 0;
			for (int i = 0; i < this.oldPos.Length; i++)
			{
				this.oldPos[i].X = 0f;
				this.oldPos[i].Y = 0f;
			}
			for (int j = 0; j < 5; j++)
			{
				this.buffTime[j] = 0;
				this.buffType[j] = 0;
			}
			for (int k = 0; k < 40; k++)
			{
				this.buffImmune[k] = false;
			}
			this.buffImmune[31] = true;
			this.netSkip = -2;
			this.realLife = -1;
			this.lifeRegen = 0;
			this.lifeRegenCount = 0;
			this.poisoned = false;
			this.onFire = false;
			this.confused = false;
			this.onFire2 = false;
			this.justHit = false;
			this.dontTakeDamage = false;
			this.npcSlots = 1f;
			this.lavaImmune = false;
			this.lavaWet = false;
			this.wetCount = 0;
			this.wet = false;
			this.townNPC = false;
			this.homeless = false;
			this.homeTileX = -1;
			this.homeTileY = -1;
			this.friendly = false;
			this.behindTiles = false;
			this.boss = false;
			this.noTileCollide = false;
			this.rotation = 0f;
			this.active = true;
			this.alpha = 0;
			this.color = default(Color);
			this.collideX = false;
			this.collideY = false;
			this.direction = 0;
			this.oldDirection = this.direction;
			this.frameCounter = 0.0;
			this.netUpdate = true;
			this.netUpdate2 = false;
			this.knockBackResist = 1f;
			this.name = "";
			this.CName = "";
			this.displayName = "";
			this.displayCName = "";
			this.noGravity = false;
			this.scale = 1f;
			this.soundHit = 0;
			this.soundKilled = 0;
			this.spriteDirection = -1;
			this.target = 255;
			this.oldTarget = this.target;
			this.targetRect = default(Rectangle);
			this.timeLeft = NPC.activeTime;
			this.type = Type;
			this.value = 0f;
			for (int l = 0; l < NPC.maxAI; l++)
			{
				this.ai[l] = 0f;
			}
			for (int m = 0; m < NPC.maxAI; m++)
			{
				this.localAI[m] = 0f;
			}
			if (this.type == 1)
			{
				this.name = "Blue Slime";
				this.CName = "蓝色史莱姆";
				this.width = 24;
				this.height = 18;
				this.aiStyle = 1;
				this.damage = 7;
				this.defense = 2;
				this.lifeMax = 25;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 175;
				this.color = new Color(0, 80, 255, 100);
				this.value = 25f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 2)
			{
				this.name = "Demon Eye";
				this.CName = "恶魔之眼";
				this.width = 30;
				this.height = 32;
				this.aiStyle = 2;
				this.damage = 18;
				this.defense = 2;
				this.lifeMax = 60;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 75f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 3)
			{
				this.name = "Zombie";
				this.CName = "僵尸";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 14;
				this.defense = 6;
				this.lifeMax = 45;
				this.soundHit = 1;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 60f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 4)
			{
				this.name = "Eye of Cthulhu";
				this.CName = "克苏鲁魔眼";
				this.width = 100;
				this.height = 110;
				this.aiStyle = 4;
				this.damage = 15;
				this.defense = 12;
				this.lifeMax = 2800;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0f;
				this.noGravity = true;
				this.noTileCollide = true;
				this.timeLeft = NPC.activeTime * 30;
				this.boss = true;
				this.value = 30000f;
				this.npcSlots = 5f;
			}
			else if (this.type == 5)
			{
				this.name = "Servant of Cthulhu";
				this.CName = "克苏鲁仆从";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 5;
				this.damage = 12;
				this.defense = 0;
				this.lifeMax = 8;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
			}
			else if (this.type == 6)
			{
				this.npcSlots = 1f;
				this.name = "Eater of Souls";
				this.CName = "食灵虫";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 5;
				this.damage = 22;
				this.defense = 8;
				this.lifeMax = 40;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.knockBackResist = 0.5f;
				this.value = 90f;
			}
			else if (this.type == 7)
			{
				this.displayName = "Devourer";
				this.displayCName = "贪食虫";
				this.npcSlots = 3.5f;
				this.name = "Devourer Head";
				this.CName = "贪食虫头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.damage = 31;
				this.defense = 2;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 140f;
				this.netAlways = true;
			}
			else if (this.type == 8)
			{
				this.displayName = "Devourer";
				this.displayCName = "贪食虫";
				this.name = "Devourer Body";
				this.CName = "贪食虫身";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 16;
				this.defense = 6;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 140f;
			}
			else if (this.type == 9)
			{
				this.displayName = "Devourer";
				this.displayCName = "贪食虫";
				this.name = "Devourer Tail";
				this.CName = "贪食虫尾";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 13;
				this.defense = 10;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 140f;
			}
			else if (this.type == 10)
			{
				this.displayName = "Giant Worm";
				this.displayCName = "巨蠕虫";
				this.name = "Giant Worm Head";
				this.CName = "巨蠕虫头";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 8;
				this.defense = 0;
				this.lifeMax = 30;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 40f;
			}
			else if (this.type == 11)
			{
				this.displayName = "Giant Worm";
				this.displayCName = "巨蠕虫";
				this.name = "Giant Worm Body";
				this.CName = "巨蠕虫身";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 4;
				this.defense = 4;
				this.lifeMax = 30;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 40f;
			}
			else if (this.type == 12)
			{
				this.displayName = "Giant Worm";
				this.displayCName = "巨蠕虫";
				this.name = "Giant Worm Tail";
				this.CName = "巨蠕虫尾";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 4;
				this.defense = 6;
				this.lifeMax = 30;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 40f;
			}
			else if (this.type == 13)
			{
				this.displayName = "Eater of Worlds";
				this.displayCName = "吞世者";
				this.npcSlots = 5f;
				this.name = "Eater of Worlds Head";
				this.CName = "吞世者头部";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 22;
				this.defense = 2;
				this.lifeMax = 65;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 300f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 14)
			{
				this.displayName = "Eater of Worlds";
				this.displayCName = "吞世者";
				this.name = "Eater of Worlds Body";
				this.CName = "吞世者躯干";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 13;
				this.defense = 4;
				this.lifeMax = 150;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 300f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 15)
			{
				this.displayName = "Eater of Worlds";
				this.displayCName = "吞世者";
				this.name = "Eater of Worlds Tail";
				this.CName = "吞世者尾部";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 11;
				this.defense = 8;
				this.lifeMax = 220;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 300f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 16)
			{
				this.npcSlots = 2f;
				this.name = "Mother Slime";
				this.CName = "史莱姆母体";
				this.width = 36;
				this.height = 24;
				this.aiStyle = 1;
				this.damage = 20;
				this.defense = 7;
				this.lifeMax = 90;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 120;
				this.color = new Color(0, 0, 0, 50);
				this.value = 75f;
				this.scale = 1.25f;
				this.knockBackResist = 0.6f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 17)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Merchant";
				this.CName = "商人";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 18)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Nurse";
				this.CName = "护士";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 19)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Arms Dealer";
				this.CName = "军火商";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 20)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Dryad";
				this.CName = "树妖";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 21)
			{
				this.name = "Skeleton";
				this.CName = "骷髅";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 8;
				this.lifeMax = 60;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 100f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 22)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Guide";
				this.CName = "向导";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 23)
			{
				this.name = "Meteor Head";
				this.CName = "陨石怪";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 5;
				this.damage = 40;
				this.defense = 6;
				this.lifeMax = 26;
				this.soundHit = 3;
				this.soundKilled = 3;
				this.noGravity = true;
				this.noTileCollide = true;
				this.value = 80f;
				this.knockBackResist = 0.4f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 24)
			{
				this.npcSlots = 3f;
				this.name = "Fire Imp";
				this.CName = "火魔精";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 8;
				this.damage = 30;
				this.defense = 16;
				this.lifeMax = 70;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
				this.lavaImmune = true;
				this.value = 350f;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 25)
			{
				this.name = "Burning Sphere";
				this.CName = "火魔球";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 9;
				this.damage = 30;
				this.defense = 0;
				this.lifeMax = 1;
				this.soundHit = 3;
				this.soundKilled = 3;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.alpha = 100;
			}
			else if (this.type == 26)
			{
				this.name = "Goblin Peon";
				this.CName = "地精苦工";
				this.scale = 0.9f;
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 12;
				this.defense = 4;
				this.lifeMax = 60;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.8f;
				this.value = 100f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 27)
			{
				this.name = "Goblin Thief";
				this.CName = "地精盗贼";
				this.scale = 0.95f;
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 6;
				this.lifeMax = 80;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.7f;
				this.value = 200f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 28)
			{
				this.name = "Goblin Warrior";
				this.CName = "地精勇士";
				this.scale = 1.1f;
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 25;
				this.defense = 8;
				this.lifeMax = 110;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
				this.value = 150f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 29)
			{
				this.name = "Goblin Sorcerer";
				this.CName = "地精术士";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 8;
				this.damage = 20;
				this.defense = 2;
				this.lifeMax = 40;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.6f;
				this.value = 200f;
			}
			else if (this.type == 30)
			{
				this.name = "Chaos Ball";
				this.CName = "混沌魔球";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 9;
				this.damage = 20;
				this.defense = 0;
				this.lifeMax = 1;
				this.soundHit = 3;
				this.soundKilled = 3;
				this.noGravity = true;
				this.noTileCollide = true;
				this.alpha = 100;
				this.knockBackResist = 0f;
			}
			else if (this.type == 31)
			{
				this.name = "Angry Bones";
				this.CName = "怒火骷髅";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 26;
				this.defense = 8;
				this.lifeMax = 80;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.8f;
				this.value = 130f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 32)
			{
				this.name = "Dark Caster";
				this.CName = "暗黑法师";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 8;
				this.damage = 20;
				this.defense = 2;
				this.lifeMax = 50;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.6f;
				this.value = 140f;
				this.npcSlots = 2f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 33)
			{
				this.name = "Water Sphere";
				this.CName = "水魔球";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 9;
				this.damage = 20;
				this.defense = 0;
				this.lifeMax = 1;
				this.soundHit = 3;
				this.soundKilled = 3;
				this.noGravity = true;
				this.noTileCollide = true;
				this.alpha = 100;
				this.knockBackResist = 0f;
			}
			else if (this.type == 34)
			{
				this.name = "Cursed Skull";
				this.CName = "诅咒颅骨";
				this.width = 26;
				this.height = 28;
				this.aiStyle = 10;
				this.damage = 35;
				this.defense = 6;
				this.lifeMax = 40;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.noGravity = true;
				this.noTileCollide = true;
				this.value = 150f;
				this.knockBackResist = 0.2f;
				this.npcSlots = 0.75f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 35)
			{
				this.displayName = "Skeletron";
				this.displayCName = "骷髅王";
				this.name = "Skeletron Head";
				this.CName = "骷髅王头部";
				this.width = 80;
				this.height = 102;
				this.aiStyle = 11;
				this.damage = 32;
				this.defense = 10;
				this.lifeMax = 4400;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.noGravity = true;
				this.noTileCollide = true;
				this.value = 50000f;
				this.knockBackResist = 0f;
				this.boss = true;
				this.npcSlots = 6f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 36)
			{
				this.displayName = "Skeletron";
				this.displayCName = "骷髅王";
				this.name = "Skeletron Hand";
				this.CName = "骷髅王手部";
				this.width = 52;
				this.height = 52;
				this.aiStyle = 12;
				this.damage = 20;
				this.defense = 14;
				this.lifeMax = 600;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 37)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Old Man";
				this.CName = "老人";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 38)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Demolitionist";
				this.CName = "爆破专家";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 39)
			{
				this.npcSlots = 6f;
				this.name = "Bone Serpent Head";
				this.CName = "骸骨巨蟒头部";
				this.displayName = "Bone Serpent";
				this.displayCName = "骸骨巨蟒";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 30;
				this.defense = 10;
				this.lifeMax = 250;
				this.soundHit = 2;
				this.soundKilled = 5;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 1200f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 40)
			{
				this.name = "Bone Serpent Body";
				this.CName = "骸骨巨蟒躯体";
				this.displayName = "Bone Serpent";
				this.displayCName = "骸骨巨蟒";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 15;
				this.defense = 12;
				this.lifeMax = 250;
				this.soundHit = 2;
				this.soundKilled = 5;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 1200f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 41)
			{
				this.name = "Bone Serpent Tail";
				this.CName = "骸骨巨蟒尾部";
				this.displayName = "Bone Serpent";
				this.displayCName = "骸骨巨蟒";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 10;
				this.defense = 18;
				this.lifeMax = 250;
				this.soundHit = 2;
				this.soundKilled = 5;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 1200f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 42)
			{
				this.name = "Hornet";
				this.CName = "大黄蜂";
				this.width = 34;
				this.height = 32;
				this.aiStyle = 5;
				this.damage = 34;
				this.defense = 12;
				this.lifeMax = 50;
				this.soundHit = 1;
				this.knockBackResist = 0.5f;
				this.soundKilled = 1;
				this.value = 200f;
				this.noGravity = true;
				this.buffImmune[20] = true;
			}
			else if (this.type == 43)
			{
				this.noGravity = true;
				this.noTileCollide = true;
				this.name = "Man Eater";
				this.CName = "食人花";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 13;
				this.damage = 42;
				this.defense = 14;
				this.lifeMax = 130;
				this.soundHit = 1;
				this.knockBackResist = 0f;
				this.soundKilled = 1;
				this.value = 350f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 44)
			{
				this.name = "Undead Miner";
				this.CName = "亡灵矿工";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 22;
				this.defense = 9;
				this.lifeMax = 70;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 250f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 45)
			{
				this.name = "Tim";
				this.CName = "魔法师提姆";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 8;
				this.damage = 20;
				this.defense = 4;
				this.lifeMax = 200;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.6f;
				this.value = 5000f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 46)
			{
				this.name = "Bunny";
				this.CName = "兔子";
				this.width = 18;
				this.height = 20;
				this.aiStyle = 7;
				this.damage = 0;
				this.defense = 0;
				this.lifeMax = 5;
				this.soundHit = 1;
				this.soundKilled = 1;
			}
			else if (this.type == 47)
			{
				this.name = "Corrupt Bunny";
				this.CName = "腐化兔";
				this.width = 18;
				this.height = 20;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 4;
				this.lifeMax = 70;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 500f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 48)
			{
				this.name = "Harpy";
				this.CName = "鸟身女妖";
				this.width = 24;
				this.height = 34;
				this.aiStyle = 14;
				this.damage = 25;
				this.defense = 8;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.knockBackResist = 0.6f;
				this.soundKilled = 1;
				this.value = 300f;
			}
			else if (this.type == 49)
			{
				this.npcSlots = 0.5f;
				this.name = "Cave Bat";
				this.CName = "洞穴蝙蝠";
				this.width = 22;
				this.height = 18;
				this.aiStyle = 14;
				this.damage = 13;
				this.defense = 2;
				this.lifeMax = 16;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 4;
				this.value = 90f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 50)
			{
				this.boss = true;
				this.name = "King Slime";
				this.CName = "史莱姆王";
				this.width = 98;
				this.height = 92;
				this.aiStyle = 15;
				this.damage = 40;
				this.defense = 10;
				this.lifeMax = 2000;
				this.knockBackResist = 0f;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 30;
				this.value = 10000f;
				this.scale = 1.25f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 51)
			{
				this.npcSlots = 0.5f;
				this.name = "Jungle Bat";
				this.CName = "丛林蝙蝠";
				this.width = 22;
				this.height = 18;
				this.aiStyle = 14;
				this.damage = 20;
				this.defense = 4;
				this.lifeMax = 34;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 4;
				this.value = 80f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 52)
			{
				this.name = "Doctor Bones";
				this.CName = "骸骨博士";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 10;
				this.lifeMax = 500;
				this.soundHit = 1;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 1000f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 53)
			{
				this.name = "The Groom";
				this.CName = "僵尸新郎";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 14;
				this.defense = 8;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 1000f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 54)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Clothier";
				this.CName = "裁缝";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 55)
			{
				this.noGravity = true;
				this.name = "Goldfish";
				this.CName = "金鱼";
				this.width = 20;
				this.height = 18;
				this.aiStyle = 16;
				this.damage = 0;
				this.defense = 0;
				this.lifeMax = 5;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 56)
			{
				this.noTileCollide = true;
				this.noGravity = true;
				this.name = "Snatcher";
				this.CName = "食人草";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 13;
				this.damage = 25;
				this.defense = 10;
				this.lifeMax = 60;
				this.soundHit = 1;
				this.knockBackResist = 0f;
				this.soundKilled = 1;
				this.value = 90f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 57)
			{
				this.noGravity = true;
				this.name = "Corrupt Goldfish";
				this.CName = "腐化金鱼";
				this.width = 18;
				this.height = 20;
				this.aiStyle = 16;
				this.damage = 30;
				this.defense = 6;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 500f;
			}
			else if (this.type == 58)
			{
				this.npcSlots = 0.5f;
				this.noGravity = true;
				this.name = "Piranha";
				this.CName = "食人鱼";
				this.width = 18;
				this.height = 20;
				this.aiStyle = 16;
				this.damage = 25;
				this.defense = 2;
				this.lifeMax = 30;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 50f;
			}
			else if (this.type == 59)
			{
				this.name = "Lava Slime";
				this.CName = "岩浆史莱姆";
				this.width = 24;
				this.height = 18;
				this.aiStyle = 1;
				this.damage = 15;
				this.defense = 10;
				this.lifeMax = 50;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.scale = 1.1f;
				this.alpha = 50;
				this.lavaImmune = true;
				this.value = 120f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 60)
			{
				this.npcSlots = 0.5f;
				this.name = "Hellbat";
				this.CName = "地狱蝙蝠";
				this.width = 22;
				this.height = 18;
				this.aiStyle = 14;
				this.damage = 35;
				this.defense = 8;
				this.lifeMax = 46;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 4;
				this.value = 120f;
				this.scale = 1.1f;
				this.lavaImmune = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 61)
			{
				this.name = "Vulture";
				this.CName = "秃鹫";
				this.width = 36;
				this.height = 36;
				this.aiStyle = 17;
				this.damage = 15;
				this.defense = 4;
				this.lifeMax = 40;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 60f;
			}
			else if (this.type == 62)
			{
				this.npcSlots = 2f;
				this.name = "Demon";
				this.CName = "小恶魔";
				this.width = 28;
				this.height = 48;
				this.aiStyle = 14;
				this.damage = 32;
				this.defense = 8;
				this.lifeMax = 120;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 300f;
				this.lavaImmune = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 63)
			{
				this.noGravity = true;
				this.name = "Blue Jellyfish";
				this.CName = "蓝水母";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 18;
				this.damage = 20;
				this.defense = 2;
				this.lifeMax = 30;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 100f;
				this.alpha = 20;
			}
			else if (this.type == 64)
			{
				this.noGravity = true;
				this.name = "Pink Jellyfish";
				this.CName = "粉水母";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 18;
				this.damage = 30;
				this.defense = 6;
				this.lifeMax = 70;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 100f;
				this.alpha = 20;
			}
			else if (this.type == 65)
			{
				this.noGravity = true;
				this.name = "Shark";
				this.CName = "鲨鱼";
				this.width = 100;
				this.height = 24;
				this.aiStyle = 16;
				this.damage = 40;
				this.defense = 2;
				this.lifeMax = 300;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 400f;
				this.knockBackResist = 0.7f;
			}
			else if (this.type == 66)
			{
				this.npcSlots = 2f;
				this.name = "Voodoo Demon";
				this.CName = "巫毒恶魔";
				this.width = 28;
				this.height = 48;
				this.aiStyle = 14;
				this.damage = 32;
				this.defense = 8;
				this.lifeMax = 140;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 1000f;
				this.lavaImmune = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 67)
			{
				this.name = "Crab";
				this.CName = "螃蟹";
				this.width = 28;
				this.height = 20;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 10;
				this.lifeMax = 40;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 60f;
			}
			else if (this.type == 68)
			{
				this.name = "Dungeon Guardian";
				this.CName = "地牢守卫";
				this.width = 80;
				this.height = 102;
				this.aiStyle = 11;
				this.damage = 9000;
				this.defense = 9000;
				this.lifeMax = 9999;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 69)
			{
				this.name = "Antlion";
				this.CName = "蚁狮";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 19;
				this.damage = 10;
				this.defense = 6;
				this.lifeMax = 45;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0f;
				this.value = 60f;
				this.behindTiles = true;
			}
			else if (this.type == 70)
			{
				this.npcSlots = 0.3f;
				this.name = "Spike Ball";
				this.CName = "刺球机关";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 20;
				this.damage = 32;
				this.defense = 100;
				this.lifeMax = 100;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0f;
				this.noGravity = true;
				this.noTileCollide = true;
				this.dontTakeDamage = true;
				this.scale = 1.5f;
			}
			else if (this.type == 71)
			{
				this.npcSlots = 2f;
				this.name = "Dungeon Slime";
				this.CName = "地牢史莱姆";
				this.width = 36;
				this.height = 24;
				this.aiStyle = 1;
				this.damage = 30;
				this.defense = 7;
				this.lifeMax = 150;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 60;
				this.value = 150f;
				this.scale = 1.25f;
				this.knockBackResist = 0.6f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 72)
			{
				this.npcSlots = 0.3f;
				this.name = "Blazing Wheel";
				this.CName = "烈焰火轮";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 21;
				this.damage = 24;
				this.defense = 100;
				this.lifeMax = 100;
				this.alpha = 100;
				this.behindTiles = true;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0f;
				this.noGravity = true;
				this.dontTakeDamage = true;
				this.scale = 1.2f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 73)
			{
				this.name = "Goblin Scout";
				this.CName = "地精斥候";
				this.scale = 0.95f;
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 6;
				this.lifeMax = 80;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.7f;
				this.value = 200f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 74)
			{
				this.name = "Bird";
				this.CName = "小鸟";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 24;
				this.damage = 0;
				this.defense = 0;
				this.lifeMax = 5;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
			}
			else if (this.type == 75)
			{
				this.noGravity = true;
				this.name = "Pixie";
				this.CName = "小妖精";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 22;
				this.damage = 55;
				this.defense = 20;
				this.lifeMax = 150;
				this.soundHit = 5;
				this.knockBackResist = 0.6f;
				this.soundKilled = 7;
				this.value = 350f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 77)
			{
				this.name = "Armored Skeleton";
				this.CName = "盔甲骷髅";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 60;
				this.defense = 36;
				this.lifeMax = 340;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.4f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 78)
			{
				this.name = "Mummy";
				this.CName = "木乃伊";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 50;
				this.defense = 16;
				this.lifeMax = 130;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.knockBackResist = 0.6f;
				this.value = 600f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 79)
			{
				this.name = "Dark Mummy";
				this.CName = "暗黑木乃伊";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 60;
				this.defense = 18;
				this.lifeMax = 180;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.knockBackResist = 0.5f;
				this.value = 700f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 80)
			{
				this.name = "Light Mummy";
				this.CName = "神圣木乃伊";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 55;
				this.defense = 18;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.knockBackResist = 0.55f;
				this.value = 700f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 81)
			{
				this.name = "Corrupt Slime";
				this.CName = "腐蚀史莱姆";
				this.width = 40;
				this.height = 30;
				this.aiStyle = 1;
				this.damage = 55;
				this.defense = 20;
				this.lifeMax = 170;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 55;
				this.value = 400f;
				this.scale = 1.1f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 82)
			{
				this.noGravity = true;
				this.noTileCollide = true;
				this.name = "Wraith";
				this.CName = "幽魂";
				this.width = 24;
				this.height = 44;
				this.aiStyle = 22;
				this.damage = 75;
				this.defense = 18;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.alpha = 100;
				this.value = 500f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.knockBackResist = 0.7f;
			}
			else if (this.type == 83)
			{
				this.name = "Cursed Hammer";
				this.CName = "诅咒战锤";
				this.width = 40;
				this.height = 40;
				this.aiStyle = 23;
				this.damage = 80;
				this.defense = 18;
				this.lifeMax = 200;
				this.soundHit = 4;
				this.soundKilled = 6;
				this.value = 1000f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.knockBackResist = 0.4f;
			}
			else if (this.type == 84)
			{
				this.name = "Enchanted Sword";
				this.CName = "魔化长剑";
				this.width = 40;
				this.height = 40;
				this.aiStyle = 23;
				this.damage = 80;
				this.defense = 18;
				this.lifeMax = 200;
				this.soundHit = 4;
				this.soundKilled = 6;
				this.value = 1000f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.knockBackResist = 0.4f;
			}
			else if (this.type == 85)
			{
				this.name = "Mimic";
				this.CName = "宝箱怪";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 25;
				this.damage = 80;
				this.defense = 30;
				this.lifeMax = 500;
				this.soundHit = 4;
				this.soundKilled = 6;
				this.value = 100000f;
				this.knockBackResist = 0.3f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 86)
			{
				this.name = "Unicorn";
				this.CName = "独角兽";
				this.width = 46;
				this.height = 42;
				this.aiStyle = 26;
				this.damage = 65;
				this.defense = 30;
				this.lifeMax = 400;
				this.soundHit = 10;
				this.soundKilled = 1;
				this.knockBackResist = 0.3f;
				this.value = 1000f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 87)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.npcSlots = 5f;
				this.name = "Wyvern Head";
				this.CName = "虚空白龙头部";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 80;
				this.defense = 10;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 10000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 88)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.name = "Wyvern Legs";
				this.CName = "虚空白龙腿部";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 10000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 89)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.name = "Wyvern Body";
				this.CName = "虚空白龙躯体";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 2000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 90)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.name = "Wyvern Body 2";
				this.CName = "虚空白龙躯体";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 10000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 91)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.name = "Wyvern Body 3";
				this.CName = "虚空白龙躯体";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 10000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 92)
			{
				this.displayName = "Wyvern";
				this.displayCName = "虚空白龙";
				this.noTileCollide = true;
				this.name = "Wyvern Tail";
				this.CName = "虚空白龙尾部";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 4000;
				this.soundHit = 7;
				this.soundKilled = 8;
				this.noGravity = true;
				this.knockBackResist = 0f;
				this.value = 10000f;
				this.scale = 1f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 93)
			{
				this.npcSlots = 0.5f;
				this.name = "Giant Bat";
				this.CName = "巨型蝙蝠";
				this.width = 26;
				this.height = 20;
				this.aiStyle = 14;
				this.damage = 70;
				this.defense = 20;
				this.lifeMax = 160;
				this.soundHit = 1;
				this.knockBackResist = 0.75f;
				this.soundKilled = 4;
				this.value = 400f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 94)
			{
				this.npcSlots = 1f;
				this.name = "Corruptor";
				this.CName = "污染者";
				this.width = 44;
				this.height = 44;
				this.aiStyle = 5;
				this.damage = 60;
				this.defense = 32;
				this.lifeMax = 230;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.knockBackResist = 0.55f;
				this.value = 500f;
			}
			else if (this.type == 95)
			{
				this.displayName = "Digger";
				this.displayCName = "掘地虫";
				this.name = "Digger Head";
				this.CName = "掘地虫头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 45;
				this.defense = 10;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.scale = 0.9f;
				this.value = 300f;
			}
			else if (this.type == 96)
			{
				this.displayName = "Digger";
				this.displayCName = "掘地虫";
				this.name = "Digger Body";
				this.CName = "掘地虫身";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 28;
				this.defense = 20;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.scale = 0.9f;
				this.value = 300f;
			}
			else if (this.type == 97)
			{
				this.displayName = "Digger";
				this.displayCName = "掘地虫";
				this.name = "Digger Tail";
				this.CName = "掘地虫尾";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 26;
				this.defense = 30;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.scale = 0.9f;
				this.value = 300f;
			}
			else if (this.type == 98)
			{
				this.displayName = "World Feeder";
				this.displayCName = "吞噬虫";
				this.npcSlots = 3.5f;
				this.name = "Seeker Head";
				this.CName = "吞噬虫头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 70;
				this.defense = 36;
				this.lifeMax = 500;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 700f;
			}
			else if (this.type == 99)
			{
				this.displayName = "World Feeder";
				this.displayCName = "吞噬虫";
				this.name = "Seeker Body";
				this.CName = "吞噬虫身";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 55;
				this.defense = 40;
				this.lifeMax = 500;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 700f;
			}
			else if (this.type == 100)
			{
				this.displayName = "World Feeder";
				this.displayCName = "吞噬虫";
				this.name = "Seeker Tail";
				this.CName = "吞噬虫尾";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 40;
				this.defense = 44;
				this.lifeMax = 500;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 700f;
			}
			else if (this.type == 101)
			{
				this.noGravity = true;
				this.noTileCollide = true;
				this.behindTiles = true;
				this.name = "Clinger";
				this.CName = "钳咬虫";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 13;
				this.damage = 70;
				this.defense = 30;
				this.lifeMax = 320;
				this.soundHit = 1;
				this.knockBackResist = 0.2f;
				this.soundKilled = 1;
				this.value = 600f;
			}
			else if (this.type == 102)
			{
				this.npcSlots = 0.5f;
				this.noGravity = true;
				this.name = "Angler Fish";
				this.CName = "鮟鱇鱼";
				this.width = 18;
				this.height = 20;
				this.aiStyle = 16;
				this.damage = 80;
				this.defense = 22;
				this.lifeMax = 90;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 500f;
			}
			else if (this.type == 103)
			{
				this.noGravity = true;
				this.name = "Green Jellyfish";
				this.CName = "绿水母";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 18;
				this.damage = 80;
				this.defense = 30;
				this.lifeMax = 120;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.value = 800f;
				this.alpha = 20;
			}
			else if (this.type == 104)
			{
				this.name = "Werewolf";
				this.CName = "狼人";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 70;
				this.defense = 40;
				this.lifeMax = 400;
				this.soundHit = 6;
				this.soundKilled = 1;
				this.knockBackResist = 0.4f;
				this.value = 1000f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 105)
			{
				this.friendly = true;
				this.name = "Bound Goblin";
				this.CName = "被捆绑的地精";
				this.width = 18;
				this.height = 34;
				this.aiStyle = 0;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
				this.scale = 0.9f;
			}
			else if (this.type == 106)
			{
				this.friendly = true;
				this.name = "Bound Wizard";
				this.CName = "被捆绑的巫师";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 0;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 107)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Goblin Tinkerer";
				this.CName = "地精工匠";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
				this.scale = 0.9f;
			}
			else if (this.type == 108)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Wizard";
				this.CName = "巫师";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 109)
			{
				this.name = "Clown";
				this.CName = "马戏团小丑";
				this.width = 34;
				this.height = 78;
				this.aiStyle = 3;
				this.damage = 50;
				this.defense = 20;
				this.lifeMax = 400;
				this.soundHit = 1;
				this.soundKilled = 2;
				this.knockBackResist = 0.4f;
				this.value = 8000f;
			}
			else if (this.type == 110)
			{
				this.name = "Skeleton Archer";
				this.CName = "骷髅神射手";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 55;
				this.defense = 28;
				this.lifeMax = 260;
				this.soundHit = 2;
				this.soundKilled = 2;
				this.knockBackResist = 0.55f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 111)
			{
				this.name = "Goblin Archer";
				this.CName = "地精弓手";
				this.scale = 0.95f;
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 20;
				this.defense = 6;
				this.lifeMax = 80;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.7f;
				this.value = 200f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 112)
			{
				this.name = "Vile Spit";
				this.CName = "腐蚀唾液";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 9;
				this.damage = 65;
				this.defense = 0;
				this.lifeMax = 1;
				this.soundHit = 0;
				this.soundKilled = 9;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.scale = 0.9f;
				this.alpha = 80;
			}
			else if (this.type == 113)
			{
				this.npcSlots = 10f;
				this.name = "Wall of Flesh";
				this.CName = "肉山大魔墙";
				this.width = 100;
				this.height = 100;
				this.aiStyle = 27;
				this.damage = 50;
				this.defense = 12;
				this.lifeMax = 8000;
				this.soundHit = 8;
				this.soundKilled = 10;
				this.noGravity = true;
				this.noTileCollide = true;
				this.behindTiles = true;
				this.knockBackResist = 0f;
				this.scale = 1.2f;
				this.boss = true;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.value = 80000f;
			}
			else if (this.type == 114)
			{
				this.name = "Wall of Flesh Eye";
				this.CName = "肉山大魔眼";
				this.displayName = "Wall of Flesh";
				this.displayCName = "肉山大魔墙";
				this.width = 100;
				this.height = 100;
				this.aiStyle = 28;
				this.damage = 50;
				this.defense = 0;
				this.lifeMax = 8000;
				this.soundHit = 8;
				this.soundKilled = 10;
				this.noGravity = true;
				this.noTileCollide = true;
				this.behindTiles = true;
				this.knockBackResist = 0f;
				this.scale = 1.2f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.value = 80000f;
			}
			else if (this.type == 115)
			{
				this.name = "The Hungry";
				this.CName = "暴食";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 29;
				this.damage = 30;
				this.defense = 10;
				this.lifeMax = 240;
				this.soundHit = 9;
				this.soundKilled = 11;
				this.noGravity = true;
				this.behindTiles = true;
				this.noTileCollide = true;
				this.knockBackResist = 1.1f;
			}
			else if (this.type == 116)
			{
				this.name = "The Hungry II";
				this.CName = "饕餮";
				this.displayName = "The Hungry";
				this.displayCName = "暴食";
				this.width = 30;
				this.height = 32;
				this.aiStyle = 2;
				this.damage = 30;
				this.defense = 6;
				this.lifeMax = 80;
				this.soundHit = 9;
				this.knockBackResist = 0.8f;
				this.soundKilled = 12;
			}
			else if (this.type == 117)
			{
				this.displayName = "Leech";
				this.displayCName = "血蛭";
				this.name = "Leech Head";
				this.CName = "血蛭头";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 26;
				this.defense = 2;
				this.lifeMax = 60;
				this.soundHit = 9;
				this.soundKilled = 12;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
			}
			else if (this.type == 118)
			{
				this.displayName = "Leech";
				this.displayCName = "血蛭";
				this.name = "Leech Body";
				this.CName = "血蛭身";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 22;
				this.defense = 6;
				this.lifeMax = 60;
				this.soundHit = 9;
				this.soundKilled = 12;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
			}
			else if (this.type == 119)
			{
				this.displayName = "Leech";
				this.displayCName = "血蛭";
				this.name = "Leech Tail";
				this.CName = "血蛭尾";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 6;
				this.netAlways = true;
				this.damage = 18;
				this.defense = 10;
				this.lifeMax = 60;
				this.soundHit = 9;
				this.soundKilled = 12;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
			}
			else if (this.type == 120)
			{
				this.name = "Chaos Elemental";
				this.CName = "混沌魔";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 40;
				this.defense = 30;
				this.lifeMax = 370;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.knockBackResist = 0.4f;
				this.value = 600f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 121)
			{
				this.name = "Slimer";
				this.CName = "飞翼史莱姆";
				this.width = 40;
				this.height = 30;
				this.aiStyle = 14;
				this.damage = 45;
				this.defense = 20;
				this.lifeMax = 60;
				this.soundHit = 1;
				this.alpha = 55;
				this.knockBackResist = 0.8f;
				this.scale = 1.1f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 122)
			{
				this.noGravity = true;
				this.name = "Gastropod";
				this.CName = "变异蜗牛";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 22;
				this.damage = 60;
				this.defense = 22;
				this.lifeMax = 220;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 600f;
				this.buffImmune[20] = true;
			}
			else if (this.type == 123)
			{
				this.friendly = true;
				this.name = "Bound Mechanic";
				this.CName = "被捆绑的机械师";
				this.width = 18;
				this.height = 34;
				this.aiStyle = 0;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
				this.scale = 0.9f;
			}
			else if (this.type == 124)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Mechanic";
				this.CName = "机械师";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 125)
			{
				this.name = "Retinazer";
				this.CName = "聚焦魔眼";
				this.width = 100;
				this.height = 110;
				this.aiStyle = 30;
				this.damage = 50;
				this.defense = 10;
				this.lifeMax = 24000;
				this.soundHit = 1;
				this.soundKilled = 14;
				this.knockBackResist = 0f;
				this.noGravity = true;
				this.noTileCollide = true;
				this.timeLeft = NPC.activeTime * 30;
				this.boss = true;
				this.value = 120000f;
				this.npcSlots = 5f;
				this.boss = true;
			}
			else if (this.type == 126)
			{
				this.name = "Spazmatism";
				this.CName = "混乱魔眼";
				this.width = 100;
				this.height = 110;
				this.aiStyle = 31;
				this.damage = 50;
				this.defense = 10;
				this.lifeMax = 24000;
				this.soundHit = 1;
				this.soundKilled = 14;
				this.knockBackResist = 0f;
				this.noGravity = true;
				this.noTileCollide = true;
				this.timeLeft = NPC.activeTime * 30;
				this.boss = true;
				this.value = 120000f;
				this.npcSlots = 5f;
				this.boss = true;
			}
			else if (this.type == 127)
			{
				this.name = "Skeletron Prime";
				this.CName = "机甲终结者";
				this.width = 80;
				this.height = 102;
				this.aiStyle = 32;
				this.damage = 50;
				this.defense = 25;
				this.lifeMax = 30000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.value = 120000f;
				this.knockBackResist = 0f;
				this.boss = true;
				this.npcSlots = 6f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.boss = true;
			}
			else if (this.type == 128)
			{
				this.name = "Prime Cannon";
				this.CName = "终结者机炮";
				this.width = 52;
				this.height = 52;
				this.aiStyle = 35;
				this.damage = 30;
				this.defense = 25;
				this.lifeMax = 7000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.netAlways = true;
			}
			else if (this.type == 129)
			{
				this.name = "Prime Saw";
				this.CName = "重金属链锯";
				this.width = 52;
				this.height = 52;
				this.aiStyle = 33;
				this.damage = 52;
				this.defense = 40;
				this.lifeMax = 10000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.netAlways = true;
			}
			else if (this.type == 130)
			{
				this.name = "Prime Vice";
				this.CName = "超合金虎钳";
				this.width = 52;
				this.height = 52;
				this.aiStyle = 34;
				this.damage = 45;
				this.defense = 35;
				this.lifeMax = 10000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.netAlways = true;
			}
			else if (this.type == 131)
			{
				this.name = "Prime Laser";
				this.CName = "超镭射死光";
				this.width = 52;
				this.height = 52;
				this.aiStyle = 36;
				this.damage = 29;
				this.defense = 20;
				this.lifeMax = 6000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.netAlways = true;
			}
			else if (this.type == 132)
			{
				this.displayName = "Zombie";
				this.displayCName = "僵尸";
				this.name = "Bald Zombie";
				this.CName = "腐尸";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 14;
				this.defense = 6;
				this.lifeMax = 45;
				this.soundHit = 1;
				this.soundKilled = 2;
				this.knockBackResist = 0.5f;
				this.value = 60f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 133)
			{
				this.name = "Wandering Eye";
				this.CName = "死亡之眼";
				this.width = 30;
				this.height = 32;
				this.aiStyle = 2;
				this.damage = 40;
				this.defense = 20;
				this.lifeMax = 300;
				this.soundHit = 1;
				this.knockBackResist = 0.8f;
				this.soundKilled = 1;
				this.value = 500f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 134)
			{
				this.displayName = "The Destroyer";
				this.displayCName = "机甲毁灭者";
				this.npcSlots = 5f;
				this.name = "The Destroyer";
				this.CName = "机甲毁灭者";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 37;
				this.damage = 60;
				this.defense = 0;
				this.lifeMax = 80000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.value = 120000f;
				this.scale = 1.25f;
				this.boss = true;
				this.netAlways = true;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 135)
			{
				this.displayName = "The Destroyer";
				this.displayCName = "机甲毁灭者";
				this.npcSlots = 5f;
				this.name = "The Destroyer Body";
				this.CName = "机甲毁灭者躯体";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 37;
				this.damage = 40;
				this.defense = 30;
				this.lifeMax = 80000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.netAlways = true;
				this.scale = 1.25f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 136)
			{
				this.displayName = "The Destroyer";
				this.displayCName = "机甲毁灭者";
				this.npcSlots = 5f;
				this.name = "The Destroyer Tail";
				this.CName = "机甲毁灭者尾部";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 37;
				this.damage = 20;
				this.defense = 35;
				this.lifeMax = 80000;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.noTileCollide = true;
				this.knockBackResist = 0f;
				this.behindTiles = true;
				this.scale = 1.25f;
				this.netAlways = true;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 137)
			{
				this.name = "Illuminant Bat";
				this.CName = "夜光蝙蝠";
				this.width = 26;
				this.height = 20;
				this.aiStyle = 14;
				this.damage = 75;
				this.defense = 30;
				this.lifeMax = 200;
				this.soundHit = 1;
				this.knockBackResist = 0.75f;
				this.soundKilled = 6;
				this.value = 500f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.buffImmune[31] = false;
			}
			else if (this.type == 138)
			{
				this.name = "Illuminant Slime";
				this.CName = "夜光史莱姆";
				this.width = 24;
				this.height = 18;
				this.aiStyle = 1;
				this.damage = 70;
				this.defense = 30;
				this.lifeMax = 180;
				this.soundHit = 1;
				this.soundKilled = 6;
				this.alpha = 100;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
				this.knockBackResist = 0.85f;
				this.scale = 1.05f;
				this.buffImmune[31] = false;
			}
			else if (this.type == 139)
			{
				this.npcSlots = 1f;
				this.name = "Probe";
				this.CName = "探测器";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 5;
				this.damage = 50;
				this.defense = 20;
				this.lifeMax = 200;
				this.soundHit = 4;
				this.soundKilled = 14;
				this.noGravity = true;
				this.knockBackResist = 0.8f;
				this.noTileCollide = true;
			}
			else if (this.type == 140)
			{
				this.name = "Possessed Armor";
				this.CName = "魔灵盔甲";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 3;
				this.damage = 55;
				this.defense = 28;
				this.lifeMax = 260;
				this.soundHit = 4;
				this.soundKilled = 6;
				this.knockBackResist = 0.4f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
				this.buffImmune[24] = true;
			}
			else if (this.type == 141)
			{
				this.name = "Toxic Sludge";
				this.CName = "毒性污泥怪";
				this.width = 34;
				this.height = 28;
				this.aiStyle = 1;
				this.damage = 50;
				this.defense = 18;
				this.lifeMax = 150;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.alpha = 55;
				this.value = 400f;
				this.scale = 1.1f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
				this.knockBackResist = 0.8f;
			}
			else if (this.type == 142)
			{
				this.townNPC = true;
				this.friendly = true;
				this.name = "Santa Claus";
				this.CName = "圣诞老人";
				this.width = 18;
				this.height = 40;
				this.aiStyle = 7;
				this.damage = 10;
				this.defense = 15;
				this.lifeMax = 250;
				this.soundHit = 1;
				this.soundKilled = 1;
				this.knockBackResist = 0.5f;
			}
			else if (this.type == 143)
			{
				this.name = "Snowman Gangsta";
				this.CName = "雪人怪";
				this.width = 26;
				this.height = 40;
				this.aiStyle = 38;
				this.damage = 50;
				this.defense = 20;
				this.lifeMax = 200;
				this.soundHit = 11;
				this.soundKilled = 15;
				this.knockBackResist = 0.6f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 144)
			{
				this.name = "Mister Stabby";
				this.CName = "戳刺先生";
				this.width = 26;
				this.height = 40;
				this.aiStyle = 38;
				this.damage = 65;
				this.defense = 26;
				this.lifeMax = 240;
				this.soundHit = 11;
				this.soundKilled = 15;
				this.knockBackResist = 0.6f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			else if (this.type == 145)
			{
				this.name = "Snow Balla";
				this.CName = "雪人巴拉";
				this.width = 26;
				this.height = 40;
				this.aiStyle = 38;
				this.damage = 55;
				this.defense = 22;
				this.lifeMax = 220;
				this.soundHit = 11;
				this.soundKilled = 15;
				this.knockBackResist = 0.6f;
				this.value = 400f;
				this.buffImmune[20] = true;
				this.buffImmune[31] = false;
				this.buffImmune[24] = true;
				this.buffImmune[39] = true;
			}
			if (Main.dedServ)
			{
				this.frame = default(Rectangle);
			}
			else
			{
				this.frame = new Rectangle(0, 0, Main.npcTexture[this.type].Width, Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type]);
			}
			if (scaleOverride > 0f)
			{
				int num = (int)((float)this.width * this.scale);
				int num2 = (int)((float)this.height * this.scale);
				this.position.X = this.position.X + (float)(num / 2);
				this.position.Y = this.position.Y + (float)num2;
				this.scale = scaleOverride;
				this.width = (int)((float)this.width * this.scale);
				this.height = (int)((float)this.height * this.scale);
				if (this.height == 16 || this.height == 32)
				{
					this.height++;
				}
				this.position.X = this.position.X - (float)(this.width / 2);
				this.position.Y = this.position.Y - (float)this.height;
			}
			else
			{
				this.width = (int)((float)this.width * this.scale);
				this.height = (int)((float)this.height * this.scale);
			}
			this.life = this.lifeMax;
			this.defDamage = this.damage;
			this.defDefense = this.defense;
			this.netID = this.type;
		}

		public void AI()
		{
			if (this.aiStyle == 0)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].talkNPC == this.whoAmI)
					{
						if (this.type == 105)
						{
							this.Transform(107);
							return;
						}
						if (this.type == 106)
						{
							this.Transform(108);
							return;
						}
						if (this.type == 123)
						{
							this.Transform(124);
							return;
						}
					}
				}
				this.velocity.X = this.velocity.X * 0.93f;
				if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
				{
					this.velocity.X = 0f;
				}
				this.TargetClosest(true);
				this.spriteDirection = this.direction;
			}
			else if (this.aiStyle == 1)
			{
				bool flag = false;
				if (!Main.dayTime || this.life != this.lifeMax || (double)this.position.Y > Main.worldSurface * 16.0)
				{
					flag = true;
				}
				if (this.type == 81)
				{
					flag = true;
					if (Main.rand.Next(30) == 0)
					{
						int num = Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, this.alpha, this.color, 1f);
						Dust dust = Main.dust[num];
						dust.velocity *= 0.3f;
					}
				}
				if (this.type == 59)
				{
					Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					Vector2 vector = new Vector2(this.position.X, this.position.Y);
					int num2 = this.width;
					int num3 = this.height;
					int num4 = 6;
					float speedX = this.velocity.X * 0.2f;
					float speedY = this.velocity.Y * 0.2f;
					int num5 = 100;
					Color newColor = default(Color);
					int num6 = Dust.NewDust(vector, num2, num3, num4, speedX, speedY, num5, newColor, 1.7f);
					Main.dust[num6].noGravity = true;
				}
				if (this.ai[2] > 1f)
				{
					this.ai[2] -= 1f;
				}
				if (this.wet)
				{
					if (this.collideY)
					{
						this.velocity.Y = -2f;
					}
					if (this.velocity.Y < 0f && this.ai[3] == this.position.X)
					{
						this.direction *= -1;
						this.ai[2] = 200f;
					}
					if (this.velocity.Y > 0f)
					{
						this.ai[3] = this.position.X;
					}
					if (this.type == 59)
					{
						if (this.velocity.Y > 2f)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
						}
						else if (this.directionY < 0)
						{
							this.velocity.Y = this.velocity.Y - 0.8f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -10f)
						{
							this.velocity.Y = -10f;
						}
					}
					else
					{
						if (this.velocity.Y > 2f)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
					}
					if (this.ai[2] == 1f && flag)
					{
						this.TargetClosest(true);
					}
				}
				this.aiAction = 0;
				if (this.ai[2] == 0f)
				{
					this.ai[0] = -100f;
					this.ai[2] = 1f;
					this.TargetClosest(true);
				}
				if (this.velocity.Y == 0f)
				{
					if (this.ai[3] == this.position.X)
					{
						this.direction *= -1;
						this.ai[2] = 200f;
					}
					this.ai[3] = 0f;
					this.velocity.X = this.velocity.X * 0.8f;
					if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
					{
						this.velocity.X = 0f;
					}
					if (flag)
					{
						this.ai[0] += 1f;
					}
					this.ai[0] += 1f;
					if (this.type == 59)
					{
						this.ai[0] += 2f;
					}
					if (this.type == 71)
					{
						this.ai[0] += 3f;
					}
					if (this.type == 138)
					{
						this.ai[0] += 2f;
					}
					if (this.type == 81)
					{
						if (this.scale >= 0f)
						{
							this.ai[0] += 4f;
						}
						else
						{
							this.ai[0] += 1f;
						}
					}
					if (this.ai[0] >= 0f)
					{
						this.netUpdate = true;
						if (flag && this.ai[2] == 1f)
						{
							this.TargetClosest(true);
						}
						if (this.ai[1] == 2f)
						{
							this.velocity.Y = -8f;
							if (this.type == 59)
							{
								this.velocity.Y = this.velocity.Y - 2f;
							}
							this.velocity.X = this.velocity.X + (float)(3 * this.direction);
							if (this.type == 59)
							{
								this.velocity.X = this.velocity.X + 0.5f * (float)this.direction;
							}
							this.ai[0] = -200f;
							this.ai[1] = 0f;
							this.ai[3] = this.position.X;
						}
						else
						{
							this.velocity.Y = -6f;
							this.velocity.X = this.velocity.X + (float)(2 * this.direction);
							if (this.type == 59)
							{
								this.velocity.X = this.velocity.X + (float)(2 * this.direction);
							}
							this.ai[0] = -120f;
							this.ai[1] += 1f;
						}
						if (this.type == 141)
						{
							this.velocity.Y = this.velocity.Y * 1.3f;
							this.velocity.X = this.velocity.X * 1.2f;
						}
					}
					else if (this.ai[0] >= -30f)
					{
						this.aiAction = 1;
					}
				}
				else if (this.target < 255 && ((this.direction == 1 && this.velocity.X < 3f) || (this.direction == -1 && this.velocity.X > -3f)))
				{
					if ((this.direction == -1 && (double)this.velocity.X < 0.1) || (this.direction == 1 && (double)this.velocity.X > -0.1))
					{
						this.velocity.X = this.velocity.X + 0.2f * (float)this.direction;
					}
					else
					{
						this.velocity.X = this.velocity.X * 0.93f;
					}
				}
			}
			else if (this.aiStyle == 2)
			{
				this.noGravity = true;
				if (this.collideX)
				{
					this.velocity.X = this.oldVelocity.X * -0.5f;
					if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 2f)
					{
						this.velocity.X = 2f;
					}
					if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -2f)
					{
						this.velocity.X = -2f;
					}
				}
				if (this.collideY)
				{
					this.velocity.Y = this.oldVelocity.Y * -0.5f;
					if (this.velocity.Y > 0f && this.velocity.Y < 1f)
					{
						this.velocity.Y = 1f;
					}
					if (this.velocity.Y < 0f && this.velocity.Y > -1f)
					{
						this.velocity.Y = -1f;
					}
				}
				if (Main.dayTime && (double)this.position.Y <= Main.worldSurface * 16.0 && (this.type == 2 || this.type == 133))
				{
					if (this.timeLeft > 10)
					{
						this.timeLeft = 10;
					}
					this.directionY = -1;
					if (this.velocity.Y > 0f)
					{
						this.direction = 1;
					}
					this.direction = -1;
					if (this.velocity.X > 0f)
					{
						this.direction = 1;
					}
				}
				else
				{
					this.TargetClosest(true);
				}
				if (this.type == 116)
				{
					this.TargetClosest(true);
					Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
					if (this.direction == -1 && this.velocity.X > -6f)
					{
						this.velocity.X = this.velocity.X - 0.1f;
						if (this.velocity.X > 6f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
						}
						else if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X - 0.2f;
						}
						if (this.velocity.X < -6f)
						{
							this.velocity.X = -6f;
						}
					}
					else if (this.direction == 1 && this.velocity.X < 6f)
					{
						this.velocity.X = this.velocity.X + 0.1f;
						if (this.velocity.X < -6f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
						}
						else if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X + 0.2f;
						}
						if (this.velocity.X > 6f)
						{
							this.velocity.X = 6f;
						}
					}
					if (this.directionY == -1 && (double)this.velocity.Y > -2.5)
					{
						this.velocity.Y = this.velocity.Y - 0.04f;
						if ((double)this.velocity.Y > 2.5)
						{
							this.velocity.Y = this.velocity.Y - 0.05f;
						}
						else if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - 0.15f;
						}
						if ((double)this.velocity.Y < -2.5)
						{
							this.velocity.Y = -2.5f;
						}
					}
					else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
					{
						this.velocity.Y = this.velocity.Y + 0.04f;
						if ((double)this.velocity.Y < -2.5)
						{
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
						else if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.15f;
						}
						if ((double)this.velocity.Y > 2.5)
						{
							this.velocity.Y = 2.5f;
						}
					}
					if (Main.rand.Next(40) == 0)
					{
						Vector2 vector2 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
						int num7 = this.width;
						int num8 = (int)((float)this.height * 0.5f);
						int num9 = 5;
						float x = this.velocity.X;
						float speedY2 = 2f;
						int num10 = 0;
						Color newColor = default(Color);
						int num11 = Dust.NewDust(vector2, num7, num8, num9, x, speedY2, num10, newColor, 1f);
						Dust dust2 = Main.dust[num11];
						dust2.velocity.X = dust2.velocity.X * 0.5f;
						Dust dust3 = Main.dust[num11];
						dust3.velocity.Y = dust3.velocity.Y * 0.1f;
					}
				}
				else if (this.type == 133)
				{
					if ((double)this.life < (double)this.lifeMax * 0.5)
					{
						if (this.direction == -1 && this.velocity.X > -6f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 6f)
							{
								this.velocity.X = this.velocity.X - 0.1f;
							}
							else if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X + 0.05f;
							}
							if (this.velocity.X < -6f)
							{
								this.velocity.X = -6f;
							}
						}
						else if (this.direction == 1 && this.velocity.X < 6f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -6f)
							{
								this.velocity.X = this.velocity.X + 0.1f;
							}
							else if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X - 0.05f;
							}
							if (this.velocity.X > 6f)
							{
								this.velocity.X = 6f;
							}
						}
						if (this.directionY == -1 && this.velocity.Y > -4f)
						{
							this.velocity.Y = this.velocity.Y - 0.1f;
							if (this.velocity.Y > 4f)
							{
								this.velocity.Y = this.velocity.Y - 0.1f;
							}
							else if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y + 0.05f;
							}
							if (this.velocity.Y < -4f)
							{
								this.velocity.Y = -4f;
							}
						}
						else if (this.directionY == 1 && this.velocity.Y < 4f)
						{
							this.velocity.Y = this.velocity.Y + 0.1f;
							if (this.velocity.Y < -4f)
							{
								this.velocity.Y = this.velocity.Y + 0.1f;
							}
							else if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y - 0.05f;
							}
							if (this.velocity.Y > 4f)
							{
								this.velocity.Y = 4f;
							}
						}
					}
					else
					{
						if (this.direction == -1 && this.velocity.X > -4f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 4f)
							{
								this.velocity.X = this.velocity.X - 0.1f;
							}
							else if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X + 0.05f;
							}
							if (this.velocity.X < -4f)
							{
								this.velocity.X = -4f;
							}
						}
						else if (this.direction == 1 && this.velocity.X < 4f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -4f)
							{
								this.velocity.X = this.velocity.X + 0.1f;
							}
							else if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X - 0.05f;
							}
							if (this.velocity.X > 4f)
							{
								this.velocity.X = 4f;
							}
						}
						if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
						{
							this.velocity.Y = this.velocity.Y - 0.04f;
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = this.velocity.Y - 0.05f;
							}
							else if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y + 0.03f;
							}
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = -1.5f;
							}
						}
						else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
						{
							this.velocity.Y = this.velocity.Y + 0.04f;
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = this.velocity.Y + 0.05f;
							}
							else if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y - 0.03f;
							}
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = 1.5f;
							}
						}
					}
				}
				else
				{
					if (this.direction == -1 && this.velocity.X > -4f)
					{
						this.velocity.X = this.velocity.X - 0.1f;
						if (this.velocity.X > 4f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
						}
						else if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X + 0.05f;
						}
						if (this.velocity.X < -4f)
						{
							this.velocity.X = -4f;
						}
					}
					else if (this.direction == 1 && this.velocity.X < 4f)
					{
						this.velocity.X = this.velocity.X + 0.1f;
						if (this.velocity.X < -4f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
						}
						else if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X - 0.05f;
						}
						if (this.velocity.X > 4f)
						{
							this.velocity.X = 4f;
						}
					}
					if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
					{
						this.velocity.Y = this.velocity.Y - 0.04f;
						if ((double)this.velocity.Y > 1.5)
						{
							this.velocity.Y = this.velocity.Y - 0.05f;
						}
						else if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.03f;
						}
						if ((double)this.velocity.Y < -1.5)
						{
							this.velocity.Y = -1.5f;
						}
					}
					else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
					{
						this.velocity.Y = this.velocity.Y + 0.04f;
						if ((double)this.velocity.Y < -1.5)
						{
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
						else if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y - 0.03f;
						}
						if ((double)this.velocity.Y > 1.5)
						{
							this.velocity.Y = 1.5f;
						}
					}
				}
				if ((this.type == 2 || this.type == 133) && Main.rand.Next(40) == 0)
				{
					Vector2 vector3 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
					int num12 = this.width;
					int num13 = (int)((float)this.height * 0.5f);
					int num14 = 5;
					float x2 = this.velocity.X;
					float speedY3 = 2f;
					int num15 = 0;
					Color newColor = default(Color);
					int num16 = Dust.NewDust(vector3, num12, num13, num14, x2, speedY3, num15, newColor, 1f);
					Dust dust4 = Main.dust[num16];
					dust4.velocity.X = dust4.velocity.X * 0.5f;
					Dust dust5 = Main.dust[num16];
					dust5.velocity.Y = dust5.velocity.Y * 0.1f;
				}
				if (this.wet)
				{
					if (this.velocity.Y > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.95f;
					}
					this.velocity.Y = this.velocity.Y - 0.5f;
					if (this.velocity.Y < -4f)
					{
						this.velocity.Y = -4f;
					}
					this.TargetClosest(true);
				}
			}
			else if (this.aiStyle == 3)
			{
				int num17 = 60;
				if (this.type == 120)
				{
					num17 = 20;
					if (this.ai[3] == -120f)
					{
						this.velocity *= 0f;
						this.ai[3] = 0f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
						Vector2 vector4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num18 = this.oldPos[2].X + (float)this.width * 0.5f - vector4.X;
						float num19 = this.oldPos[2].Y + (float)this.height * 0.5f - vector4.Y;
						float num20 = (float)Math.Sqrt((double)(num18 * num18 + num19 * num19));
						num20 = 2f / num20;
						num18 *= num20;
						num19 *= num20;
						for (int j = 0; j < 20; j++)
						{
							Vector2 vector5 = this.position;
							int num21 = this.width;
							int num22 = this.height;
							int num23 = 71;
							float speedX2 = num18;
							float speedY4 = num19;
							int num24 = 200;
							int num25 = Dust.NewDust(vector5, num21, num22, num23, speedX2, speedY4, num24, default(Color), 2f);
							Main.dust[num25].noGravity = true;
							Dust dust6 = Main.dust[num25];
							dust6.velocity.X = dust6.velocity.X * 2f;
						}
						for (int k = 0; k < 20; k++)
						{
							Vector2 vector6 = this.oldPos[2];
							int num26 = this.width;
							int num27 = this.height;
							int num28 = 71;
							float speedX3 = -num18;
							float speedY5 = -num19;
							int num29 = 200;
							int num30 = Dust.NewDust(vector6, num26, num27, num28, speedX3, speedY5, num29, default(Color), 2f);
							Main.dust[num30].noGravity = true;
							Dust dust7 = Main.dust[num30];
							dust7.velocity.X = dust7.velocity.X * 2f;
						}
					}
				}
				bool flag2 = false;
				bool flag3 = true;
				if (this.type == 47 || this.type == 67 || this.type == 109 || this.type == 110 || this.type == 111 || this.type == 120)
				{
					flag3 = false;
				}
				if ((this.type != 110 && this.type != 111) || this.ai[2] <= 0f)
				{
					if (this.velocity.Y == 0f && ((this.velocity.X > 0f && this.direction < 0) || (this.velocity.X < 0f && this.direction > 0)))
					{
						flag2 = true;
					}
					if (this.position.X == this.oldPosition.X || this.ai[3] >= (float)num17 || flag2)
					{
						this.ai[3] += 1f;
					}
					else if ((double)Math.Abs(this.velocity.X) > 0.9 && this.ai[3] > 0f)
					{
						this.ai[3] -= 1f;
					}
					if (this.ai[3] > (float)(num17 * 10))
					{
						this.ai[3] = 0f;
					}
					if (this.justHit)
					{
						this.ai[3] = 0f;
					}
					if (this.ai[3] == (float)num17)
					{
						this.netUpdate = true;
					}
				}
				if ((!Main.dayTime || (double)this.position.Y > Main.worldSurface * 16.0 || this.type == 26 || this.type == 27 || this.type == 28 || this.type == 31 || this.type == 47 || this.type == 67 || this.type == 73 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 110 || this.type == 111 || this.type == 120) && this.ai[3] < (float)num17)
				{
					if ((this.type == 3 || this.type == 21 || this.type == 31 || this.type == 77 || this.type == 110 || this.type == 132) && Main.rand.Next(1000) == 0)
					{
						Main.PlaySound(14, (int)this.position.X, (int)this.position.Y, 1);
					}
					if ((this.type == 78 || this.type == 79 || this.type == 80) && Main.rand.Next(500) == 0)
					{
						Main.PlaySound(26, (int)this.position.X, (int)this.position.Y, 1);
					}
					this.TargetClosest(true);
				}
				else if ((this.type != 110 && this.type != 111) || this.ai[2] <= 0f)
				{
					if (Main.dayTime && (double)(this.position.Y / 16f) < Main.worldSurface && this.timeLeft > 10)
					{
						this.timeLeft = 10;
					}
					if (this.velocity.X == 0f)
					{
						if (this.velocity.Y == 0f)
						{
							this.ai[0] += 1f;
							if (this.ai[0] >= 2f)
							{
								this.direction *= -1;
								this.spriteDirection = this.direction;
								this.ai[0] = 0f;
							}
						}
					}
					else
					{
						this.ai[0] = 0f;
					}
					if (this.direction == 0)
					{
						this.direction = 1;
					}
				}
				if (this.type == 120)
				{
					if (this.velocity.X < -3f || this.velocity.X > 3f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.8f;
						}
					}
					else if (this.velocity.X < 3f && this.direction == 1)
					{
						if (this.velocity.Y == 0f && this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X * 0.99f;
						}
						this.velocity.X = this.velocity.X + 0.07f;
						if (this.velocity.X > 3f)
						{
							this.velocity.X = 3f;
						}
					}
					else if (this.velocity.X > -3f && this.direction == -1)
					{
						if (this.velocity.Y == 0f && this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X * 0.99f;
						}
						this.velocity.X = this.velocity.X - 0.07f;
						if (this.velocity.X < -3f)
						{
							this.velocity.X = -3f;
						}
					}
				}
				else if (this.type == 27 || this.type == 77 || this.type == 104)
				{
					if (this.velocity.X < -2f || this.velocity.X > 2f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.8f;
						}
					}
					else if (this.velocity.X < 2f && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + 0.07f;
						if (this.velocity.X > 2f)
						{
							this.velocity.X = 2f;
						}
					}
					else if (this.velocity.X > -2f && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - 0.07f;
						if (this.velocity.X < -2f)
						{
							this.velocity.X = -2f;
						}
					}
				}
				else if (this.type == 109)
				{
					if (this.velocity.X < -2f || this.velocity.X > 2f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.8f;
						}
					}
					else if (this.velocity.X < 2f && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + 0.04f;
						if (this.velocity.X > 2f)
						{
							this.velocity.X = 2f;
						}
					}
					else if (this.velocity.X > -2f && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - 0.04f;
						if (this.velocity.X < -2f)
						{
							this.velocity.X = -2f;
						}
					}
				}
				else if (this.type == 21 || this.type == 26 || this.type == 31 || this.type == 47 || this.type == 73 || this.type == 140)
				{
					if (this.velocity.X < -1.5f || this.velocity.X > 1.5f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.8f;
						}
					}
					else if (this.velocity.X < 1.5f && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + 0.07f;
						if (this.velocity.X > 1.5f)
						{
							this.velocity.X = 1.5f;
						}
					}
					else if (this.velocity.X > -1.5f && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - 0.07f;
						if (this.velocity.X < -1.5f)
						{
							this.velocity.X = -1.5f;
						}
					}
				}
				else if (this.type == 67)
				{
					if (this.velocity.X < -0.5f || this.velocity.X > 0.5f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.7f;
						}
					}
					else if (this.velocity.X < 0.5f && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + 0.03f;
						if (this.velocity.X > 0.5f)
						{
							this.velocity.X = 0.5f;
						}
					}
					else if (this.velocity.X > -0.5f && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - 0.03f;
						if (this.velocity.X < -0.5f)
						{
							this.velocity.X = -0.5f;
						}
					}
				}
				else if (this.type == 78 || this.type == 79 || this.type == 80)
				{
					float num31 = 1f;
					float num32 = 0.05f;
					if (this.life < this.lifeMax / 2)
					{
						num31 = 2f;
						num32 = 0.1f;
					}
					if (this.type == 79)
					{
						num31 *= 1.5f;
					}
					if (this.velocity.X < -num31 || this.velocity.X > num31)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.7f;
						}
					}
					else if (this.velocity.X < num31 && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + num32;
						if (this.velocity.X > num31)
						{
							this.velocity.X = num31;
						}
					}
					else if (this.velocity.X > -num31 && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - num32;
						if (this.velocity.X < -num31)
						{
							this.velocity.X = -num31;
						}
					}
				}
				else if (this.type != 110 && this.type != 111)
				{
					if (this.velocity.X < -1f || this.velocity.X > 1f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity *= 0.8f;
						}
					}
					else if (this.velocity.X < 1f && this.direction == 1)
					{
						this.velocity.X = this.velocity.X + 0.07f;
						if (this.velocity.X > 1f)
						{
							this.velocity.X = 1f;
						}
					}
					else if (this.velocity.X > -1f && this.direction == -1)
					{
						this.velocity.X = this.velocity.X - 0.07f;
						if (this.velocity.X < -1f)
						{
							this.velocity.X = -1f;
						}
					}
				}
				if (this.type == 110 || this.type == 111)
				{
					if (this.confused)
					{
						this.ai[2] = 0f;
					}
					else
					{
						if (this.ai[1] > 0f)
						{
							this.ai[1] -= 1f;
						}
						if (this.justHit)
						{
							this.ai[1] = 30f;
							this.ai[2] = 0f;
						}
						int num33 = 70;
						if (this.type == 111)
						{
							num33 = 180;
						}
						if (this.ai[2] > 0f)
						{
							this.TargetClosest(true);
							if (this.ai[1] == (float)(num33 / 2))
							{
								float num34 = 11f;
								if (this.type == 111)
								{
									num34 = 9f;
								}
								Vector2 vector7 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num35 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector7.X;
								float num36 = Math.Abs(num35) * 0.1f;
								float num37 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector7.Y - num36;
								num35 += (float)Main.rand.Next(-40, 41);
								num37 += (float)Main.rand.Next(-40, 41);
								float num38 = (float)Math.Sqrt((double)(num35 * num35 + num37 * num37));
								this.netUpdate = true;
								num38 = num34 / num38;
								num35 *= num38;
								num37 *= num38;
								int num39 = 35;
								if (this.type == 111)
								{
									num39 = 11;
								}
								int num40 = 82;
								if (this.type == 111)
								{
									num40 = 81;
								}
								vector7.X += num35;
								vector7.Y += num37;
								if (Main.netMode != 1)
								{
									Projectile.NewProjectile(vector7.X, vector7.Y, num35, num37, num40, num39, 0f, Main.myPlayer);
								}
								if (Math.Abs(num37) > Math.Abs(num35) * 2f)
								{
									if (num37 > 0f)
									{
										this.ai[2] = 1f;
									}
									else
									{
										this.ai[2] = 5f;
									}
								}
								else if (Math.Abs(num35) > Math.Abs(num37) * 2f)
								{
									this.ai[2] = 3f;
								}
								else if (num37 > 0f)
								{
									this.ai[2] = 2f;
								}
								else
								{
									this.ai[2] = 4f;
								}
							}
							if (this.velocity.Y != 0f || this.ai[1] <= 0f)
							{
								this.ai[2] = 0f;
								this.ai[1] = 0f;
							}
							else
							{
								this.velocity.X = this.velocity.X * 0.9f;
								this.spriteDirection = this.direction;
							}
						}
						if (this.ai[2] <= 0f && this.velocity.Y == 0f && this.ai[1] <= 0f && !Main.player[this.target].dead && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
						{
							float num41 = 10f;
							Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num42 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector8.X;
							float num43 = Math.Abs(num42) * 0.1f;
							float num44 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector8.Y - num43;
							num42 += (float)Main.rand.Next(-40, 41);
							num44 += (float)Main.rand.Next(-40, 41);
							float num45 = (float)Math.Sqrt((double)(num42 * num42 + num44 * num44));
							if (num45 < 700f)
							{
								this.netUpdate = true;
								this.velocity.X = this.velocity.X * 0.5f;
								num45 = num41 / num45;
								num42 *= num45;
								num44 *= num45;
								this.ai[2] = 3f;
								this.ai[1] = (float)num33;
								if (Math.Abs(num44) > Math.Abs(num42) * 2f)
								{
									if (num44 > 0f)
									{
										this.ai[2] = 1f;
									}
									else
									{
										this.ai[2] = 5f;
									}
								}
								else if (Math.Abs(num42) > Math.Abs(num44) * 2f)
								{
									this.ai[2] = 3f;
								}
								else if (num44 > 0f)
								{
									this.ai[2] = 2f;
								}
								else
								{
									this.ai[2] = 4f;
								}
							}
						}
						if (this.ai[2] <= 0f)
						{
							if (this.velocity.X < -1f || this.velocity.X > 1f)
							{
								if (this.velocity.Y == 0f)
								{
									this.velocity *= 0.8f;
								}
							}
							else if (this.velocity.X < 1f && this.direction == 1)
							{
								this.velocity.X = this.velocity.X + 0.07f;
								if (this.velocity.X > 1f)
								{
									this.velocity.X = 1f;
								}
							}
							else if (this.velocity.X > -1f && this.direction == -1)
							{
								this.velocity.X = this.velocity.X - 0.07f;
								if (this.velocity.X < -1f)
								{
									this.velocity.X = -1f;
								}
							}
						}
					}
				}
				if (this.type == 109 && Main.netMode != 1 && !Main.player[this.target].dead)
				{
					if (this.justHit)
					{
						this.ai[2] = 0f;
					}
					this.ai[2] += 1f;
					if (this.ai[2] > 450f)
					{
						Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f - (float)(this.direction * 24), this.position.Y + 4f);
						int num46 = 3 * this.direction;
						int num47 = -5;
						int num48 = Projectile.NewProjectile(vector9.X, vector9.Y, (float)num46, (float)num47, 75, 0, 0f, Main.myPlayer);
						Main.projectile[num48].timeLeft = 300;
						this.ai[2] = 0f;
					}
				}
				bool flag4 = false;
				if (this.velocity.Y == 0f)
				{
					int num49 = (int)(this.position.Y + (float)this.height + 8f) / 16;
					int num50 = (int)this.position.X / 16;
					int num51 = (int)(this.position.X + (float)this.width) / 16;
					for (int l = num50; l <= num51; l++)
					{
						if (Main.tile[l, num49] == null)
						{
							return;
						}
						if (Main.tile[l, num49].active && Main.tileSolid[(int)Main.tile[l, num49].type])
						{
							flag4 = true;
							break;
						}
					}
				}
				if (flag4)
				{
					int num52 = (int)((this.position.X + (float)(this.width / 2) + (float)(15 * this.direction)) / 16f);
					int num53 = (int)((this.position.Y + (float)this.height - 15f) / 16f);
					if (this.type == 109)
					{
						num52 = (int)((this.position.X + (float)(this.width / 2) + (float)((this.width / 2 + 16) * this.direction)) / 16f);
					}
					if (Main.tile[num52, num53] == null)
					{
						Main.tile[num52, num53] = new Tile();
					}
					if (Main.tile[num52, num53 - 1] == null)
					{
						Main.tile[num52, num53 - 1] = new Tile();
					}
					if (Main.tile[num52, num53 - 2] == null)
					{
						Main.tile[num52, num53 - 2] = new Tile();
					}
					if (Main.tile[num52, num53 - 3] == null)
					{
						Main.tile[num52, num53 - 3] = new Tile();
					}
					if (Main.tile[num52, num53 + 1] == null)
					{
						Main.tile[num52, num53 + 1] = new Tile();
					}
					if (Main.tile[num52 + this.direction, num53 - 1] == null)
					{
						Main.tile[num52 + this.direction, num53 - 1] = new Tile();
					}
					if (Main.tile[num52 + this.direction, num53 + 1] == null)
					{
						Main.tile[num52 + this.direction, num53 + 1] = new Tile();
					}
					if (Main.tile[num52, num53 - 1].active && Main.tile[num52, num53 - 1].type == 10 && flag3)
					{
						this.ai[2] += 1f;
						this.ai[3] = 0f;
						if (this.ai[2] >= 60f)
						{
							if (!Main.bloodMoon && (this.type == 3 || this.type == 132))
							{
								this.ai[1] = 0f;
							}
							this.velocity.X = 0.5f * -(float)this.direction;
							this.ai[1] += 1f;
							if (this.type == 27)
							{
								this.ai[1] += 1f;
							}
							if (this.type == 31)
							{
								this.ai[1] += 6f;
							}
							this.ai[2] = 0f;
							bool flag5 = false;
							if (this.ai[1] >= 10f)
							{
								flag5 = true;
								this.ai[1] = 10f;
							}
							WorldGen.KillTile(num52, num53 - 1, true, false, false);
							if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
							{
								if (this.type == 26)
								{
									WorldGen.KillTile(num52, num53 - 1, false, false, false);
									if (Main.netMode == 2)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num52, (float)(num53 - 1), 0f, 0);
									}
								}
								else
								{
									bool flag6 = WorldGen.OpenDoor(num52, num53, this.direction);
									if (!flag6)
									{
										this.ai[3] = (float)num17;
										this.netUpdate = true;
									}
									if (Main.netMode == 2 && flag6)
									{
										NetMessage.SendData(19, -1, -1, "", 0, (float)num52, (float)num53, (float)this.direction, 0);
									}
								}
							}
						}
					}
					else
					{
						if ((this.velocity.X < 0f && this.spriteDirection == -1) || (this.velocity.X > 0f && this.spriteDirection == 1))
						{
							if (Main.tile[num52, num53 - 2].active && Main.tileSolid[(int)Main.tile[num52, num53 - 2].type])
							{
								if (Main.tile[num52, num53 - 3].active && Main.tileSolid[(int)Main.tile[num52, num53 - 3].type])
								{
									this.velocity.Y = -8f;
									this.netUpdate = true;
								}
								else
								{
									this.velocity.Y = -7f;
									this.netUpdate = true;
								}
							}
							else if (Main.tile[num52, num53 - 1].active && Main.tileSolid[(int)Main.tile[num52, num53 - 1].type])
							{
								this.velocity.Y = -6f;
								this.netUpdate = true;
							}
							else if (Main.tile[num52, num53].active && Main.tileSolid[(int)Main.tile[num52, num53].type])
							{
								this.velocity.Y = -5f;
								this.netUpdate = true;
							}
							else if (this.directionY < 0 && this.type != 67 && (!Main.tile[num52, num53 + 1].active || !Main.tileSolid[(int)Main.tile[num52, num53 + 1].type]) && (!Main.tile[num52 + this.direction, num53 + 1].active || !Main.tileSolid[(int)Main.tile[num52 + this.direction, num53 + 1].type]))
							{
								this.velocity.Y = -8f;
								this.velocity.X = this.velocity.X * 1.5f;
								this.netUpdate = true;
							}
							else if (flag3)
							{
								this.ai[1] = 0f;
								this.ai[2] = 0f;
							}
						}
						if ((this.type == 31 || this.type == 47 || this.type == 77 || this.type == 104) && this.velocity.Y == 0f && Math.Abs(this.position.X + (float)(this.width / 2) - (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2))) < 100f && Math.Abs(this.position.Y + (float)(this.height / 2) - (Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2))) < 50f && ((this.direction > 0 && this.velocity.X >= 1f) || (this.direction < 0 && this.velocity.X <= -1f)))
						{
							this.velocity.X = this.velocity.X * 2f;
							if (this.velocity.X > 3f)
							{
								this.velocity.X = 3f;
							}
							if (this.velocity.X < -3f)
							{
								this.velocity.X = -3f;
							}
							this.velocity.Y = -4f;
							this.netUpdate = true;
						}
						if (this.type == 120 && this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 1.1f;
						}
					}
				}
				else if (flag3)
				{
					this.ai[1] = 0f;
					this.ai[2] = 0f;
				}
				if (Main.netMode != 1 && this.type == 120 && this.ai[3] >= (float)num17)
				{
					int num54 = (int)Main.player[this.target].position.X / 16;
					int num55 = (int)Main.player[this.target].position.Y / 16;
					int num56 = (int)this.position.X / 16;
					int num57 = (int)this.position.Y / 16;
					int num58 = 20;
					int num59 = 0;
					bool flag7 = false;
					if (Math.Abs(this.position.X - Main.player[this.target].position.X) + Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000f)
					{
						num59 = 100;
						flag7 = true;
					}
					while (!flag7)
					{
						if (num59 >= 100)
						{
							break;
						}
						num59++;
						int num60 = Main.rand.Next(num54 - num58, num54 + num58);
						int num61 = Main.rand.Next(num55 - num58, num55 + num58);
						for (int m = num61; m < num55 + num58; m++)
						{
							if ((m < num55 - 4 || m > num55 + 4 || num60 < num54 - 4 || num60 > num54 + 4) && (m < num57 - 1 || m > num57 + 1 || num60 < num56 - 1 || num60 > num56 + 1) && Main.tile[num60, m].active)
							{
								bool flag8 = true;
								if (this.type == 32 && Main.tile[num60, m - 1].wall == 0)
								{
									flag8 = false;
								}
								else if (Main.tile[num60, m - 1].lava)
								{
									flag8 = false;
								}
								if (flag8 && Main.tileSolid[(int)Main.tile[num60, m].type] && !Collision.SolidTiles(num60 - 1, num60 + 1, m - 4, m - 1))
								{
									this.position.X = (float)(num60 * 16 - this.width / 2);
									this.position.Y = (float)(m * 16 - this.height);
									this.netUpdate = true;
									this.ai[3] = -120f;
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 4)
			{
				if (this.target < 0 || this.target == 255 || Main.player[this.target].dead || !Main.player[this.target].active)
				{
					this.TargetClosest(true);
				}
				bool dead = Main.player[this.target].dead;
				float num62 = this.position.X + (float)(this.width / 2) - Main.player[this.target].position.X - (float)(Main.player[this.target].width / 2);
				float num63 = this.position.Y + (float)this.height - 59f - Main.player[this.target].position.Y - (float)(Main.player[this.target].height / 2);
				float num64 = (float)Math.Atan2((double)num63, (double)num62) + 1.57f;
				if (num64 < 0f)
				{
					num64 += 6.283f;
				}
				else if ((double)num64 > 6.283)
				{
					num64 -= 6.283f;
				}
				float num65 = 0f;
				if (this.ai[0] == 0f && this.ai[1] == 0f)
				{
					num65 = 0.02f;
				}
				if (this.ai[0] == 0f && this.ai[1] == 2f && this.ai[2] > 40f)
				{
					num65 = 0.05f;
				}
				if (this.ai[0] == 3f && this.ai[1] == 0f)
				{
					num65 = 0.05f;
				}
				if (this.ai[0] == 3f && this.ai[1] == 2f && this.ai[2] > 40f)
				{
					num65 = 0.08f;
				}
				if (this.rotation < num64)
				{
					if ((double)(num64 - this.rotation) > 3.1415)
					{
						this.rotation -= num65;
					}
					else
					{
						this.rotation += num65;
					}
				}
				else if (this.rotation > num64)
				{
					if ((double)(this.rotation - num64) > 3.1415)
					{
						this.rotation += num65;
					}
					else
					{
						this.rotation -= num65;
					}
				}
				if (this.rotation > num64 - num65 && this.rotation < num64 + num65)
				{
					this.rotation = num64;
				}
				if (this.rotation < 0f)
				{
					this.rotation += 6.283f;
				}
				else if ((double)this.rotation > 6.283)
				{
					this.rotation -= 6.283f;
				}
				if (this.rotation > num64 - num65 && this.rotation < num64 + num65)
				{
					this.rotation = num64;
				}
				if (Main.rand.Next(5) == 0)
				{
					Vector2 vector10 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
					int num66 = this.width;
					int num67 = (int)((float)this.height * 0.5f);
					int num68 = 5;
					float x3 = this.velocity.X;
					float speedY6 = 2f;
					int num69 = 0;
					Color newColor = default(Color);
					int num70 = Dust.NewDust(vector10, num66, num67, num68, x3, speedY6, num69, newColor, 1f);
					Dust dust8 = Main.dust[num70];
					dust8.velocity.X = dust8.velocity.X * 0.5f;
					Dust dust9 = Main.dust[num70];
					dust9.velocity.Y = dust9.velocity.Y * 0.1f;
				}
				if (Main.dayTime || dead)
				{
					this.velocity.Y = this.velocity.Y - 0.04f;
					if (this.timeLeft > 10)
					{
						this.timeLeft = 10;
					}
				}
				else if (this.ai[0] == 0f)
				{
					if (this.ai[1] == 0f)
					{
						float num71 = 5f;
						float num72 = 0.04f;
						Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num73 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector11.X;
						float num74 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 200f - vector11.Y;
						float num75 = (float)Math.Sqrt((double)(num73 * num73 + num74 * num74));
						float num76 = num75;
						num75 = num71 / num75;
						num73 *= num75;
						num74 *= num75;
						if (this.velocity.X < num73)
						{
							this.velocity.X = this.velocity.X + num72;
							if (this.velocity.X < 0f && num73 > 0f)
							{
								this.velocity.X = this.velocity.X + num72;
							}
						}
						else if (this.velocity.X > num73)
						{
							this.velocity.X = this.velocity.X - num72;
							if (this.velocity.X > 0f && num73 < 0f)
							{
								this.velocity.X = this.velocity.X - num72;
							}
						}
						if (this.velocity.Y < num74)
						{
							this.velocity.Y = this.velocity.Y + num72;
							if (this.velocity.Y < 0f && num74 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num72;
							}
						}
						else if (this.velocity.Y > num74)
						{
							this.velocity.Y = this.velocity.Y - num72;
							if (this.velocity.Y > 0f && num74 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num72;
							}
						}
						this.ai[2] += 1f;
						if (this.ai[2] >= 600f)
						{
							this.ai[1] = 1f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.target = 255;
							this.netUpdate = true;
						}
						else if (this.position.Y + (float)this.height < Main.player[this.target].position.Y && num76 < 500f)
						{
							if (!Main.player[this.target].dead)
							{
								this.ai[3] += 1f;
							}
							if (this.ai[3] >= 110f)
							{
								this.ai[3] = 0f;
								this.rotation = num64;
								float num77 = 5f;
								float num78 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector11.X;
								float num79 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector11.Y;
								float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
								num80 = num77 / num80;
								Vector2 vector12 = vector11;
								Vector2 vector13;
								vector13.X = num78 * num80;
								vector13.Y = num79 * num80;
								vector12.X += vector13.X * 10f;
								vector12.Y += vector13.Y * 10f;
								if (Main.netMode != 1)
								{
									int num81 = NPC.NewNPC((int)vector12.X, (int)vector12.Y, 5, 0);
									Main.npc[num81].velocity.X = vector13.X;
									Main.npc[num81].velocity.Y = vector13.Y;
									if (Main.netMode == 2 && num81 < 200)
									{
										NetMessage.SendData(23, -1, -1, "", num81, 0f, 0f, 0f, 0);
									}
								}
								Main.PlaySound(3, (int)vector12.X, (int)vector12.Y, 1);
								for (int n = 0; n < 10; n++)
								{
									Vector2 vector14 = vector12;
									int num82 = 20;
									int num83 = 20;
									int num84 = 5;
									float speedX4 = vector13.X * 0.4f;
									float speedY7 = vector13.Y * 0.4f;
									int num85 = 0;
									Dust.NewDust(vector14, num82, num83, num84, speedX4, speedY7, num85, default(Color), 1f);
								}
							}
						}
					}
					else if (this.ai[1] == 1f)
					{
						this.rotation = num64;
						float num86 = 6f;
						Vector2 vector15 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num87 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector15.X;
						float num88 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector15.Y;
						float num89 = (float)Math.Sqrt((double)(num87 * num87 + num88 * num88));
						num89 = num86 / num89;
						this.velocity.X = num87 * num89;
						this.velocity.Y = num88 * num89;
						this.ai[1] = 2f;
					}
					else if (this.ai[1] == 2f)
					{
						this.ai[2] += 1f;
						if (this.ai[2] >= 40f)
						{
							this.velocity.X = this.velocity.X * 0.98f;
							this.velocity.Y = this.velocity.Y * 0.98f;
							if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
							{
								this.velocity.X = 0f;
							}
							if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
							{
								this.velocity.Y = 0f;
							}
						}
						else
						{
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
						}
						if (this.ai[2] >= 150f)
						{
							this.ai[3] += 1f;
							this.ai[2] = 0f;
							this.target = 255;
							this.rotation = num64;
							if (this.ai[3] >= 3f)
							{
								this.ai[1] = 0f;
								this.ai[3] = 0f;
							}
							else
							{
								this.ai[1] = 1f;
							}
						}
					}
					if ((double)this.life < (double)this.lifeMax * 0.5)
					{
						this.ai[0] = 1f;
						this.ai[1] = 0f;
						this.ai[2] = 0f;
						this.ai[3] = 0f;
						this.netUpdate = true;
					}
				}
				else if (this.ai[0] == 1f || this.ai[0] == 2f)
				{
					if (this.ai[0] == 1f)
					{
						this.ai[2] += 0.005f;
						if ((double)this.ai[2] > 0.5)
						{
							this.ai[2] = 0.5f;
						}
					}
					else
					{
						this.ai[2] -= 0.005f;
						if (this.ai[2] < 0f)
						{
							this.ai[2] = 0f;
						}
					}
					this.rotation += this.ai[2];
					this.ai[1] += 1f;
					if (this.ai[1] == 100f)
					{
						this.ai[0] += 1f;
						this.ai[1] = 0f;
						if (this.ai[0] == 3f)
						{
							this.ai[2] = 0f;
						}
						else
						{
							Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1);
							for (int num90 = 0; num90 < 2; num90++)
							{
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 8, 1f);
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
							}
							for (int num91 = 0; num91 < 20; num91++)
							{
								Vector2 vector16 = this.position;
								int num92 = this.width;
								int num93 = this.height;
								int num94 = 5;
								float speedX5 = (float)Main.rand.Next(-30, 31) * 0.2f;
								float speedY8 = (float)Main.rand.Next(-30, 31) * 0.2f;
								int num95 = 0;
								Dust.NewDust(vector16, num92, num93, num94, speedX5, speedY8, num95, default(Color), 1f);
							}
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						}
					}
					Vector2 vector17 = this.position;
					int num96 = this.width;
					int num97 = this.height;
					int num98 = 5;
					float speedX6 = (float)Main.rand.Next(-30, 31) * 0.2f;
					float speedY9 = (float)Main.rand.Next(-30, 31) * 0.2f;
					int num99 = 0;
					Dust.NewDust(vector17, num96, num97, num98, speedX6, speedY9, num99, default(Color), 1f);
					this.velocity.X = this.velocity.X * 0.98f;
					this.velocity.Y = this.velocity.Y * 0.98f;
					if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
					{
						this.velocity.X = 0f;
					}
					if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
					{
						this.velocity.Y = 0f;
					}
				}
				else
				{
					this.damage = 23;
					this.defense = 0;
					if (this.ai[1] == 0f)
					{
						float num100 = 6f;
						float num101 = 0.07f;
						Vector2 vector18 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num102 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector18.X;
						float num103 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 120f - vector18.Y;
						float num104 = (float)Math.Sqrt((double)(num102 * num102 + num103 * num103));
						num104 = num100 / num104;
						num102 *= num104;
						num103 *= num104;
						if (this.velocity.X < num102)
						{
							this.velocity.X = this.velocity.X + num101;
							if (this.velocity.X < 0f && num102 > 0f)
							{
								this.velocity.X = this.velocity.X + num101;
							}
						}
						else if (this.velocity.X > num102)
						{
							this.velocity.X = this.velocity.X - num101;
							if (this.velocity.X > 0f && num102 < 0f)
							{
								this.velocity.X = this.velocity.X - num101;
							}
						}
						if (this.velocity.Y < num103)
						{
							this.velocity.Y = this.velocity.Y + num101;
							if (this.velocity.Y < 0f && num103 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num101;
							}
						}
						else if (this.velocity.Y > num103)
						{
							this.velocity.Y = this.velocity.Y - num101;
							if (this.velocity.Y > 0f && num103 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num101;
							}
						}
						this.ai[2] += 1f;
						if (this.ai[2] >= 200f)
						{
							this.ai[1] = 1f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.target = 255;
							this.netUpdate = true;
						}
					}
					else if (this.ai[1] == 1f)
					{
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						this.rotation = num64;
						float num105 = 6.8f;
						Vector2 vector19 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num106 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector19.X;
						float num107 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector19.Y;
						float num108 = (float)Math.Sqrt((double)(num106 * num106 + num107 * num107));
						num108 = num105 / num108;
						this.velocity.X = num106 * num108;
						this.velocity.Y = num107 * num108;
						this.ai[1] = 2f;
					}
					else if (this.ai[1] == 2f)
					{
						this.ai[2] += 1f;
						if (this.ai[2] >= 40f)
						{
							this.velocity.X = this.velocity.X * 0.97f;
							this.velocity.Y = this.velocity.Y * 0.97f;
							if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
							{
								this.velocity.X = 0f;
							}
							if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
							{
								this.velocity.Y = 0f;
							}
						}
						else
						{
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
						}
						if (this.ai[2] >= 130f)
						{
							this.ai[3] += 1f;
							this.ai[2] = 0f;
							this.target = 255;
							this.rotation = num64;
							if (this.ai[3] >= 3f)
							{
								this.ai[1] = 0f;
								this.ai[3] = 0f;
							}
							else
							{
								this.ai[1] = 1f;
							}
						}
					}
				}
			}
			else if (this.aiStyle == 5)
			{
				if (this.target < 0 || this.target == 255 || Main.player[this.target].dead)
				{
					this.TargetClosest(true);
				}
				float num109 = 6f;
				float num110 = 0.05f;
				if (this.type == 6)
				{
					num109 = 4f;
					num110 = 0.02f;
				}
				else if (this.type == 94)
				{
					num109 = 4.2f;
					num110 = 0.022f;
				}
				else if (this.type == 42)
				{
					num109 = 3.5f;
					num110 = 0.021f;
				}
				else if (this.type == 23)
				{
					num109 = 1f;
					num110 = 0.03f;
				}
				else if (this.type == 5)
				{
					num109 = 5f;
					num110 = 0.03f;
				}
				Vector2 vector20 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num111 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2);
				float num112 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2);
				num111 = (float)((int)(num111 / 8f) * 8);
				num112 = (float)((int)(num112 / 8f) * 8);
				vector20.X = (float)((int)(vector20.X / 8f) * 8);
				vector20.Y = (float)((int)(vector20.Y / 8f) * 8);
				num111 -= vector20.X;
				num112 -= vector20.Y;
				float num113 = (float)Math.Sqrt((double)(num111 * num111 + num112 * num112));
				float num114 = num113;
				bool flag9 = false;
				if (num113 > 600f)
				{
					flag9 = true;
				}
				if (num113 == 0f)
				{
					num111 = this.velocity.X;
					num112 = this.velocity.Y;
				}
				else
				{
					num113 = num109 / num113;
					num111 *= num113;
					num112 *= num113;
				}
				if (this.type == 6 || this.type == 42 || this.type == 94 || this.type == 139)
				{
					if (num114 > 100f || this.type == 42 || this.type == 94)
					{
						this.ai[0] += 1f;
						if (this.ai[0] > 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.023f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y - 0.023f;
						}
						if (this.ai[0] < -100f || this.ai[0] > 100f)
						{
							this.velocity.X = this.velocity.X + 0.023f;
						}
						else
						{
							this.velocity.X = this.velocity.X - 0.023f;
						}
						if (this.ai[0] > 200f)
						{
							this.ai[0] = -200f;
						}
					}
					if (num114 < 150f && (this.type == 6 || this.type == 94))
					{
						this.velocity.X = this.velocity.X + num111 * 0.007f;
						this.velocity.Y = this.velocity.Y + num112 * 0.007f;
					}
				}
				if (Main.player[this.target].dead)
				{
					num111 = (float)this.direction * num109 / 2f;
					num112 = -num109 / 2f;
				}
				if (this.velocity.X < num111)
				{
					this.velocity.X = this.velocity.X + num110;
					if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && this.velocity.X < 0f && num111 > 0f)
					{
						this.velocity.X = this.velocity.X + num110;
					}
				}
				else if (this.velocity.X > num111)
				{
					this.velocity.X = this.velocity.X - num110;
					if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && this.velocity.X > 0f && num111 < 0f)
					{
						this.velocity.X = this.velocity.X - num110;
					}
				}
				if (this.velocity.Y < num112)
				{
					this.velocity.Y = this.velocity.Y + num110;
					if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && this.velocity.Y < 0f && num112 > 0f)
					{
						this.velocity.Y = this.velocity.Y + num110;
					}
				}
				else if (this.velocity.Y > num112)
				{
					this.velocity.Y = this.velocity.Y - num110;
					if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && this.velocity.Y > 0f && num112 < 0f)
					{
						this.velocity.Y = this.velocity.Y - num110;
					}
				}
				if (this.type == 23)
				{
					if (num111 > 0f)
					{
						this.spriteDirection = 1;
						this.rotation = (float)Math.Atan2((double)num112, (double)num111);
					}
					else if (num111 < 0f)
					{
						this.spriteDirection = -1;
						this.rotation = (float)Math.Atan2((double)num112, (double)num111) + 3.14f;
					}
				}
				else if (this.type == 139)
				{
					this.localAI[0] += 1f;
					if (this.justHit)
					{
						this.localAI[0] = 0f;
					}
					if (Main.netMode != 1 && this.localAI[0] >= 120f)
					{
						this.localAI[0] = 0f;
						if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
						{
							int num115 = 25;
							int num116 = 84;
							Projectile.NewProjectile(vector20.X, vector20.Y, num111, num112, num116, num115, 0f, Main.myPlayer);
						}
					}
					int num117 = (int)this.position.X + this.width / 2;
					int num118 = (int)this.position.Y + this.height / 2;
					num117 /= 16;
					num118 /= 16;
					if (!WorldGen.SolidTile(num117, num118))
					{
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
					}
					if (num111 > 0f)
					{
						this.spriteDirection = 1;
						this.rotation = (float)Math.Atan2((double)num112, (double)num111);
					}
					if (num111 < 0f)
					{
						this.spriteDirection = -1;
						this.rotation = (float)Math.Atan2((double)num112, (double)num111) + 3.14f;
					}
				}
				else if (this.type == 6 || this.type == 94)
				{
					this.rotation = (float)Math.Atan2((double)num112, (double)num111) - 1.57f;
				}
				else if (this.type == 42)
				{
					if (num111 > 0f)
					{
						this.spriteDirection = 1;
					}
					if (num111 < 0f)
					{
						this.spriteDirection = -1;
					}
					this.rotation = this.velocity.X * 0.1f;
				}
				else
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
				}
				if (this.type == 6 || this.type == 23 || this.type == 42 || this.type == 94 || this.type == 139)
				{
					float num119 = 0.7f;
					if (this.type == 6)
					{
						num119 = 0.4f;
					}
					if (this.collideX)
					{
						this.netUpdate = true;
						this.velocity.X = this.oldVelocity.X * -num119;
						if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 2f)
						{
							this.velocity.X = 2f;
						}
						if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -2f)
						{
							this.velocity.X = -2f;
						}
					}
					if (this.collideY)
					{
						this.netUpdate = true;
						this.velocity.Y = this.oldVelocity.Y * -num119;
						if (this.velocity.Y > 0f && (double)this.velocity.Y < 1.5)
						{
							this.velocity.Y = 2f;
						}
						if (this.velocity.Y < 0f && (double)this.velocity.Y > -1.5)
						{
							this.velocity.Y = -2f;
						}
					}
					if (this.type == 23)
					{
						Vector2 vector21 = new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
						int num120 = this.width;
						int num121 = this.height;
						int num122 = 6;
						float speedX7 = this.velocity.X * 0.2f;
						float speedY10 = this.velocity.Y * 0.2f;
						int num123 = 100;
						Color newColor = default(Color);
						int num124 = Dust.NewDust(vector21, num120, num121, num122, speedX7, speedY10, num123, newColor, 2f);
						Main.dust[num124].noGravity = true;
						Dust dust10 = Main.dust[num124];
						dust10.velocity.X = dust10.velocity.X * 0.3f;
						Dust dust11 = Main.dust[num124];
						dust11.velocity.Y = dust11.velocity.Y * 0.3f;
					}
					else if (this.type != 42 && this.type != 139 && Main.rand.Next(20) == 0)
					{
						int num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f), this.width, (int)((float)this.height * 0.5f), 18, this.velocity.X, 2f, 75, this.color, this.scale);
						Dust dust12 = Main.dust[num125];
						dust12.velocity.X = dust12.velocity.X * 0.5f;
						Dust dust13 = Main.dust[num125];
						dust13.velocity.Y = dust13.velocity.Y * 0.1f;
					}
				}
				else if (Main.rand.Next(40) == 0)
				{
					Vector2 vector22 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
					int num126 = this.width;
					int num127 = (int)((float)this.height * 0.5f);
					int num128 = 5;
					float x4 = this.velocity.X;
					float speedY11 = 2f;
					int num129 = 0;
					Color newColor = default(Color);
					int num130 = Dust.NewDust(vector22, num126, num127, num128, x4, speedY11, num129, newColor, 1f);
					Dust dust14 = Main.dust[num130];
					dust14.velocity.X = dust14.velocity.X * 0.5f;
					Dust dust15 = Main.dust[num130];
					dust15.velocity.Y = dust15.velocity.Y * 0.1f;
				}
				if ((this.type == 6 || this.type == 94) && this.wet)
				{
					if (this.velocity.Y > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.95f;
					}
					this.velocity.Y = this.velocity.Y - 0.3f;
					if (this.velocity.Y < -2f)
					{
						this.velocity.Y = -2f;
					}
				}
				if (this.type == 42)
				{
					if (this.wet)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.95f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
						this.TargetClosest(true);
					}
					if (this.ai[1] == 101f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
						this.ai[1] = 0f;
					}
					if (Main.netMode != 1)
					{
						this.ai[1] += (float)Main.rand.Next(5, 20) * 0.1f * this.scale;
						if (this.ai[1] >= 130f)
						{
							if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								float num131 = 8f;
								Vector2 vector23 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2));
								float num132 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector23.X + (float)Main.rand.Next(-20, 21);
								float num133 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector23.Y + (float)Main.rand.Next(-20, 21);
								if ((num132 < 0f && this.velocity.X < 0f) || (num132 > 0f && this.velocity.X > 0f))
								{
									float num134 = (float)Math.Sqrt((double)(num132 * num132 + num133 * num133));
									num134 = num131 / num134;
									num132 *= num134;
									num133 *= num134;
									int num135 = (int)(13f * this.scale);
									int num136 = 55;
									int num137 = Projectile.NewProjectile(vector23.X, vector23.Y, num132, num133, num136, num135, 0f, Main.myPlayer);
									Main.projectile[num137].timeLeft = 300;
									this.ai[1] = 101f;
									this.netUpdate = true;
								}
								else
								{
									this.ai[1] = 0f;
								}
							}
							else
							{
								this.ai[1] = 0f;
							}
						}
					}
				}
				if (this.type == 139 && flag9)
				{
					if ((this.velocity.X > 0f && num111 > 0f) || (this.velocity.X < 0f && num111 < 0f))
					{
						if (Math.Abs(this.velocity.X) < 12f)
						{
							this.velocity.X = this.velocity.X * 1.05f;
						}
					}
					else
					{
						this.velocity.X = this.velocity.X * 0.9f;
					}
				}
				if (Main.netMode != 1 && this.type == 94 && !Main.player[this.target].dead)
				{
					if (this.justHit)
					{
						this.localAI[0] = 0f;
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] == 180f)
					{
						if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
						{
							NPC.NewNPC((int)(this.position.X + (float)(this.width / 2) + this.velocity.X), (int)(this.position.Y + (float)(this.height / 2) + this.velocity.Y), 112, 0);
						}
						this.localAI[0] = 0f;
					}
				}
				if ((Main.dayTime && this.type != 6 && this.type != 23 && this.type != 42 && this.type != 94) || Main.player[this.target].dead)
				{
					this.velocity.Y = this.velocity.Y - num110 * 2f;
					if (this.timeLeft > 10)
					{
						this.timeLeft = 10;
					}
				}
				if (((this.velocity.X > 0f && this.oldVelocity.X < 0f) || (this.velocity.X < 0f && this.oldVelocity.X > 0f) || (this.velocity.Y > 0f && this.oldVelocity.Y < 0f) || (this.velocity.Y < 0f && this.oldVelocity.Y > 0f)) && !this.justHit)
				{
					this.netUpdate = true;
				}
			}
			else if (this.aiStyle == 6)
			{
				if (this.type == 117 && this.localAI[1] == 0f)
				{
					this.localAI[1] = 1f;
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 13);
					int num138 = 1;
					if (this.velocity.X < 0f)
					{
						num138 = -1;
					}
					for (int num139 = 0; num139 < 20; num139++)
					{
						Vector2 vector24 = new Vector2(this.position.X - 20f, this.position.Y - 20f);
						int num140 = this.width + 40;
						int num141 = this.height + 40;
						int num142 = 5;
						float speedX8 = (float)(num138 * 8);
						float speedY12 = -1f;
						int num143 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector24, num140, num141, num142, speedX8, speedY12, num143, newColor, 1f);
					}
				}
				if (this.type >= 13 && this.type <= 15)
				{
					this.realLife = -1;
				}
				else if (this.ai[3] > 0f)
				{
					this.realLife = (int)this.ai[3];
				}
				if (this.target < 0 || this.target == 255 || Main.player[this.target].dead)
				{
					this.TargetClosest(true);
				}
				if (Main.player[this.target].dead && this.timeLeft > 300)
				{
					this.timeLeft = 300;
				}
				if (Main.netMode != 1)
				{
					if (this.type == 87 && this.ai[0] == 0f)
					{
						this.ai[3] = (float)this.whoAmI;
						this.realLife = this.whoAmI;
						int num144 = this.whoAmI;
						for (int num145 = 0; num145 < 14; num145++)
						{
							int num146 = 89;
							if (num145 == 1 || num145 == 8)
							{
								num146 = 88;
							}
							else if (num145 == 11)
							{
								num146 = 90;
							}
							else if (num145 == 12)
							{
								num146 = 91;
							}
							else if (num145 == 13)
							{
								num146 = 92;
							}
							int num147 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), num146, this.whoAmI);
							Main.npc[num147].ai[3] = (float)this.whoAmI;
							Main.npc[num147].realLife = this.whoAmI;
							Main.npc[num147].ai[1] = (float)num144;
							Main.npc[num144].ai[0] = (float)num147;
							NetMessage.SendData(23, -1, -1, "", num147, 0f, 0f, 0f, 0);
							num144 = num147;
						}
					}
					if ((this.type == 7 || this.type == 8 || this.type == 10 || this.type == 11 || this.type == 13 || this.type == 14 || this.type == 39 || this.type == 40 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || this.type == 117 || this.type == 118) && this.ai[0] == 0f)
					{
						if (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 95 || this.type == 98 || this.type == 117)
						{
							if (this.type < 13 || this.type > 15)
							{
								this.ai[3] = (float)this.whoAmI;
								this.realLife = this.whoAmI;
							}
							this.ai[2] = (float)Main.rand.Next(8, 13);
							if (this.type == 10)
							{
								this.ai[2] = (float)Main.rand.Next(4, 7);
							}
							if (this.type == 13)
							{
								this.ai[2] = (float)Main.rand.Next(45, 56);
							}
							if (this.type == 39)
							{
								this.ai[2] = (float)Main.rand.Next(12, 19);
							}
							if (this.type == 95)
							{
								this.ai[2] = (float)Main.rand.Next(6, 12);
							}
							if (this.type == 98)
							{
								this.ai[2] = (float)Main.rand.Next(20, 26);
							}
							if (this.type == 117)
							{
								this.ai[2] = (float)Main.rand.Next(3, 6);
							}
							this.ai[0] = (float)NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), this.type + 1, this.whoAmI);
						}
						else if ((this.type == 8 || this.type == 11 || this.type == 14 || this.type == 40 || this.type == 96 || this.type == 99 || this.type == 118) && this.ai[2] > 0f)
						{
							this.ai[0] = (float)NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), this.type, this.whoAmI);
						}
						else
						{
							this.ai[0] = (float)NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), this.type + 1, this.whoAmI);
						}
						if (this.type < 13 || this.type > 15)
						{
							Main.npc[(int)this.ai[0]].ai[3] = this.ai[3];
							Main.npc[(int)this.ai[0]].realLife = this.realLife;
						}
						Main.npc[(int)this.ai[0]].ai[1] = (float)this.whoAmI;
						Main.npc[(int)this.ai[0]].ai[2] = this.ai[2] - 1f;
						this.netUpdate = true;
					}
					if ((this.type == 8 || this.type == 9 || this.type == 11 || this.type == 12 || this.type == 40 || this.type == 41 || this.type == 96 || this.type == 97 || this.type == 99 || this.type == 100 || (this.type > 87 && this.type <= 92) || this.type == 118 || this.type == 119) && (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != this.aiStyle))
					{
						this.life = 0;
						this.HitEffect(0, 10.0);
						this.active = false;
					}
					if ((this.type == 7 || this.type == 8 || this.type == 10 || this.type == 11 || this.type == 39 || this.type == 40 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || (this.type >= 87 && this.type < 92) || this.type == 117 || this.type == 118) && (!Main.npc[(int)this.ai[0]].active || Main.npc[(int)this.ai[0]].aiStyle != this.aiStyle))
					{
						this.life = 0;
						this.HitEffect(0, 10.0);
						this.active = false;
					}
					if (this.type == 13 || this.type == 14 || this.type == 15)
					{
						if (!Main.npc[(int)this.ai[1]].active && !Main.npc[(int)this.ai[0]].active)
						{
							this.life = 0;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
						if (this.type == 13 && !Main.npc[(int)this.ai[0]].active)
						{
							this.life = 0;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
						if (this.type == 15 && !Main.npc[(int)this.ai[1]].active)
						{
							this.life = 0;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
						if (this.type == 14 && (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != this.aiStyle))
						{
							this.type = 13;
							int num148 = this.whoAmI;
							float num149 = (float)this.life / (float)this.lifeMax;
							float num150 = this.ai[0];
							this.SetDefaults(this.type, -1f);
							this.life = (int)((float)this.lifeMax * num149);
							this.ai[0] = num150;
							this.TargetClosest(true);
							this.netUpdate = true;
							this.whoAmI = num148;
						}
						if (this.type == 14 && (!Main.npc[(int)this.ai[0]].active || Main.npc[(int)this.ai[0]].aiStyle != this.aiStyle))
						{
							int num151 = this.whoAmI;
							float num152 = (float)this.life / (float)this.lifeMax;
							float num153 = this.ai[1];
							this.SetDefaults(this.type, -1f);
							this.life = (int)((float)this.lifeMax * num152);
							this.ai[1] = num153;
							this.TargetClosest(true);
							this.netUpdate = true;
							this.whoAmI = num151;
						}
						if (this.life == 0)
						{
							bool flag10 = true;
							for (int num154 = 0; num154 < 200; num154++)
							{
								if (Main.npc[num154].active && (Main.npc[num154].type == 13 || Main.npc[num154].type == 14 || Main.npc[num154].type == 15))
								{
									flag10 = false;
									break;
								}
							}
							if (flag10)
							{
								this.boss = true;
								this.NPCLoot();
							}
						}
					}
					if (!this.active && Main.netMode == 2)
					{
						NetMessage.SendData(28, -1, -1, "", this.whoAmI, -1f, 0f, 0f, 0);
					}
				}
				int num155 = (int)(this.position.X / 16f) - 1;
				int num156 = (int)((this.position.X + (float)this.width) / 16f) + 2;
				int num157 = (int)(this.position.Y / 16f) - 1;
				int num158 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
				if (num155 < 0)
				{
					num155 = 0;
				}
				if (num156 > Main.maxTilesX)
				{
					num156 = Main.maxTilesX;
				}
				if (num157 < 0)
				{
					num157 = 0;
				}
				if (num158 > Main.maxTilesY)
				{
					num158 = Main.maxTilesY;
				}
				bool flag11 = false;
				if (this.type >= 87 && this.type <= 92)
				{
					flag11 = true;
				}
				if (!flag11)
				{
					for (int num159 = num155; num159 < num156; num159++)
					{
						for (int num160 = num157; num160 < num158; num160++)
						{
							if (Main.tile[num159, num160] != null && ((Main.tile[num159, num160].active && (Main.tileSolid[(int)Main.tile[num159, num160].type] || (Main.tileSolidTop[(int)Main.tile[num159, num160].type] && Main.tile[num159, num160].frameY == 0))) || Main.tile[num159, num160].liquid > 64))
							{
								Vector2 vector25;
								vector25.X = (float)(num159 * 16);
								vector25.Y = (float)(num160 * 16);
								if (this.position.X + (float)this.width > vector25.X && this.position.X < vector25.X + 16f && this.position.Y + (float)this.height > vector25.Y && this.position.Y < vector25.Y + 16f)
								{
									flag11 = true;
									if (Main.rand.Next(100) == 0 && this.type != 117 && Main.tile[num159, num160].active)
									{
										WorldGen.KillTile(num159, num160, true, true, false);
									}
									if (Main.netMode != 1 && Main.tile[num159, num160].type == 2)
									{
										byte b = Main.tile[num159, num160 - 1].type;
									}
								}
							}
						}
					}
				}
				if (!flag11 && (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 95 || this.type == 98 || this.type == 117))
				{
					Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
					int num161 = 1000;
					bool flag12 = true;
					for (int num162 = 0; num162 < 255; num162++)
					{
						if (Main.player[num162].active)
						{
							Rectangle rectangle2 = new Rectangle((int)Main.player[num162].position.X - num161, (int)Main.player[num162].position.Y - num161, num161 * 2, num161 * 2);
							if (rectangle.Intersects(rectangle2))
							{
								flag12 = false;
								break;
							}
						}
					}
					if (flag12)
					{
						flag11 = true;
					}
				}
				if (this.type >= 87 && this.type <= 92)
				{
					if (this.velocity.X < 0f)
					{
						this.spriteDirection = 1;
					}
					else if (this.velocity.X > 0f)
					{
						this.spriteDirection = -1;
					}
				}
				float num163 = 8f;
				float num164 = 0.07f;
				if (this.type == 95)
				{
					num163 = 5.5f;
					num164 = 0.045f;
				}
				if (this.type == 10)
				{
					num163 = 6f;
					num164 = 0.05f;
				}
				if (this.type == 13)
				{
					num163 = 10f;
					num164 = 0.07f;
				}
				if (this.type == 87)
				{
					num163 = 11f;
					num164 = 0.25f;
				}
				if (this.type == 117 && Main.wof >= 0)
				{
					float num165 = (float)Main.npc[Main.wof].life / (float)Main.npc[Main.wof].lifeMax;
					if ((double)num165 < 0.5)
					{
						num163 += 1f;
						num164 += 0.1f;
					}
					if ((double)num165 < 0.25)
					{
						num163 += 1f;
						num164 += 0.1f;
					}
					if ((double)num165 < 0.1)
					{
						num163 += 2f;
						num164 += 0.1f;
					}
				}
				Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num166 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2);
				float num167 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2);
				num166 = (float)((int)(num166 / 16f) * 16);
				num167 = (float)((int)(num167 / 16f) * 16);
				vector26.X = (float)((int)(vector26.X / 16f) * 16);
				vector26.Y = (float)((int)(vector26.Y / 16f) * 16);
				num166 -= vector26.X;
				num167 -= vector26.Y;
				float num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
				if (this.ai[1] > 0f && this.ai[1] < (float)Main.npc.Length)
				{
					try
					{
						vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num166 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - vector26.X;
						num167 = Main.npc[(int)this.ai[1]].position.Y + (float)(Main.npc[(int)this.ai[1]].height / 2) - vector26.Y;
					}
					catch
					{
					}
					this.rotation = (float)Math.Atan2((double)num167, (double)num166) + 1.57f;
					num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
					int num169 = this.width;
					if (this.type >= 87 && this.type <= 92)
					{
						num169 = 42;
					}
					num168 = (num168 - (float)num169) / num168;
					num166 *= num168;
					num167 *= num168;
					this.velocity = default(Vector2);
					this.position.X = this.position.X + num166;
					this.position.Y = this.position.Y + num167;
					if (this.type >= 87 && this.type <= 92)
					{
						if (num166 < 0f)
						{
							this.spriteDirection = 1;
						}
						else if (num166 > 0f)
						{
							this.spriteDirection = -1;
						}
					}
				}
				else
				{
					if (!flag11)
					{
						this.TargetClosest(true);
						this.velocity.Y = this.velocity.Y + 0.11f;
						if (this.velocity.Y > num163)
						{
							this.velocity.Y = num163;
						}
						if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num163 * 0.4)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X - num164 * 1.1f;
							}
							else
							{
								this.velocity.X = this.velocity.X + num164 * 1.1f;
							}
						}
						else if (this.velocity.Y == num163)
						{
							if (this.velocity.X < num166)
							{
								this.velocity.X = this.velocity.X + num164;
							}
							else if (this.velocity.X > num166)
							{
								this.velocity.X = this.velocity.X - num164;
							}
						}
						else if (this.velocity.Y > 4f)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X + num164 * 0.9f;
							}
							else
							{
								this.velocity.X = this.velocity.X - num164 * 0.9f;
							}
						}
					}
					else
					{
						if (this.type != 87 && this.type != 117 && this.soundDelay == 0)
						{
							float num170 = num168 / 40f;
							if (num170 < 10f)
							{
								num170 = 10f;
							}
							if (num170 > 20f)
							{
								num170 = 20f;
							}
							this.soundDelay = (int)num170;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 1);
						}
						num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
						float num171 = Math.Abs(num166);
						float num172 = Math.Abs(num167);
						float num173 = num163 / num168;
						num166 *= num173;
						num167 *= num173;
						if ((this.type == 13 || this.type == 7) && !Main.player[this.target].zoneEvil)
						{
							bool flag13 = true;
							for (int num174 = 0; num174 < 255; num174++)
							{
								if (Main.player[num174].active && !Main.player[num174].dead && Main.player[num174].zoneEvil)
								{
									flag13 = false;
								}
							}
							if (flag13)
							{
								if (Main.netMode != 1 && (double)(this.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
								{
									this.active = false;
									int num175 = (int)this.ai[0];
									while (num175 > 0 && num175 < 200 && Main.npc[num175].active && Main.npc[num175].aiStyle == this.aiStyle)
									{
										int num176 = (int)Main.npc[num175].ai[0];
										Main.npc[num175].active = false;
										this.life = 0;
										if (Main.netMode == 2)
										{
											NetMessage.SendData(23, -1, -1, "", num175, 0f, 0f, 0f, 0);
										}
										num175 = num176;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(23, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
									}
								}
								num166 = 0f;
								num167 = num163;
							}
						}
						bool flag14 = false;
						if (this.type == 87)
						{
							if (((this.velocity.X > 0f && num166 < 0f) || (this.velocity.X < 0f && num166 > 0f) || (this.velocity.Y > 0f && num167 < 0f) || (this.velocity.Y < 0f && num167 > 0f)) && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > num164 / 2f && num168 < 300f)
							{
								flag14 = true;
								if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < num163)
								{
									this.velocity *= 1.1f;
								}
							}
							if (this.position.Y > Main.player[this.target].position.Y || (double)(Main.player[this.target].position.Y / 16f) > Main.worldSurface || Main.player[this.target].dead)
							{
								flag14 = true;
								if (Math.Abs(this.velocity.X) < num163 / 2f)
								{
									if (this.velocity.X == 0f)
									{
										this.velocity.X = this.velocity.X - (float)this.direction;
									}
									this.velocity.X = this.velocity.X * 1.1f;
								}
								else if (this.velocity.Y > -num163)
								{
									this.velocity.Y = this.velocity.Y - num164;
								}
							}
						}
						if (!flag14)
						{
							if ((this.velocity.X > 0f && num166 > 0f) || (this.velocity.X < 0f && num166 < 0f) || (this.velocity.Y > 0f && num167 > 0f) || (this.velocity.Y < 0f && num167 < 0f))
							{
								if (this.velocity.X < num166)
								{
									this.velocity.X = this.velocity.X + num164;
								}
								else if (this.velocity.X > num166)
								{
									this.velocity.X = this.velocity.X - num164;
								}
								if (this.velocity.Y < num167)
								{
									this.velocity.Y = this.velocity.Y + num164;
								}
								else if (this.velocity.Y > num167)
								{
									this.velocity.Y = this.velocity.Y - num164;
								}
								if ((double)Math.Abs(num167) < (double)num163 * 0.2 && ((this.velocity.X > 0f && num166 < 0f) || (this.velocity.X < 0f && num166 > 0f)))
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y + num164 * 2f;
									}
									else
									{
										this.velocity.Y = this.velocity.Y - num164 * 2f;
									}
								}
								if ((double)Math.Abs(num166) < (double)num163 * 0.2 && ((this.velocity.Y > 0f && num167 < 0f) || (this.velocity.Y < 0f && num167 > 0f)))
								{
									if (this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X + num164 * 2f;
									}
									else
									{
										this.velocity.X = this.velocity.X - num164 * 2f;
									}
								}
							}
							else if (num171 > num172)
							{
								if (this.velocity.X < num166)
								{
									this.velocity.X = this.velocity.X + num164 * 1.1f;
								}
								else if (this.velocity.X > num166)
								{
									this.velocity.X = this.velocity.X - num164 * 1.1f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num163 * 0.5)
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y + num164;
									}
									else
									{
										this.velocity.Y = this.velocity.Y - num164;
									}
								}
							}
							else
							{
								if (this.velocity.Y < num167)
								{
									this.velocity.Y = this.velocity.Y + num164 * 1.1f;
								}
								else if (this.velocity.Y > num167)
								{
									this.velocity.Y = this.velocity.Y - num164 * 1.1f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num163 * 0.5)
								{
									if (this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X + num164;
									}
									else
									{
										this.velocity.X = this.velocity.X - num164;
									}
								}
							}
						}
					}
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					if (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 95 || this.type == 98 || this.type == 117)
					{
						if (flag11)
						{
							if (this.localAI[0] != 1f)
							{
								this.netUpdate = true;
							}
							this.localAI[0] = 1f;
						}
						else
						{
							if (this.localAI[0] != 0f)
							{
								this.netUpdate = true;
							}
							this.localAI[0] = 0f;
						}
						if (((this.velocity.X > 0f && this.oldVelocity.X < 0f) || (this.velocity.X < 0f && this.oldVelocity.X > 0f) || (this.velocity.Y > 0f && this.oldVelocity.Y < 0f) || (this.velocity.Y < 0f && this.oldVelocity.Y > 0f)) && !this.justHit)
						{
							this.netUpdate = true;
						}
					}
				}
			}
			else if (this.aiStyle == 7)
			{
				if (this.type == 142 && Main.netMode != 1 && !Main.xMas)
				{
					this.StrikeNPC(9999, 0f, 0, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(28, -1, -1, "", this.whoAmI, 9999f, 0f, 0f, 0);
					}
				}
				int num177 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int num178 = (int)(this.position.Y + (float)this.height + 1f) / 16;
				if (this.type == 107)
				{
					NPC.savedGoblin = true;
				}
				if (this.type == 108)
				{
					NPC.savedWizard = true;
				}
				if (this.type == 124)
				{
					NPC.savedMech = true;
				}
				if (this.type == 46 && this.target == 255)
				{
					this.TargetClosest(true);
				}
				bool flag15 = false;
				this.directionY = -1;
				if (this.direction == 0)
				{
					this.direction = 1;
				}
				for (int num179 = 0; num179 < 255; num179++)
				{
					if (Main.player[num179].active && Main.player[num179].talkNPC == this.whoAmI)
					{
						flag15 = true;
						if (this.ai[0] != 0f)
						{
							this.netUpdate = true;
						}
						this.ai[0] = 0f;
						this.ai[1] = 300f;
						this.ai[2] = 100f;
						if (Main.player[num179].position.X + (float)(Main.player[num179].width / 2) < this.position.X + (float)(this.width / 2))
						{
							this.direction = -1;
						}
						else
						{
							this.direction = 1;
						}
					}
				}
				if (this.ai[3] > 0f)
				{
					this.life = -1;
					this.HitEffect(0, 10.0);
					this.active = false;
					if (this.type == 37)
					{
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					}
				}
				if (this.type == 37 && Main.netMode != 1)
				{
					this.homeless = false;
					this.homeTileX = Main.dungeonX;
					this.homeTileY = Main.dungeonY;
					if (NPC.downedBoss3)
					{
						this.ai[3] = 1f;
						this.netUpdate = true;
					}
				}
				int num180 = this.homeTileY;
				if (Main.netMode != 1 && this.homeTileY > 0)
				{
					while (!WorldGen.SolidTile(this.homeTileX, num180) && num180 < Main.maxTilesY - 20)
					{
						num180++;
					}
				}
				if (Main.netMode != 1 && this.townNPC && (!Main.dayTime || Main.tileDungeon[(int)Main.tile[num177, num178].type]) && (num177 != this.homeTileX || num178 != num180) && !this.homeless)
				{
					bool flag16 = true;
					for (int num181 = 0; num181 < 2; num181++)
					{
						Rectangle rectangle3 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(this.position.Y + (float)(this.height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
						if (num181 == 1)
						{
							rectangle3 = new Rectangle(this.homeTileX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, num180 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
						}
						for (int num182 = 0; num182 < 255; num182++)
						{
							if (Main.player[num182].active)
							{
								Rectangle rectangle4 = new Rectangle((int)Main.player[num182].position.X, (int)Main.player[num182].position.Y, Main.player[num182].width, Main.player[num182].height);
								if (rectangle4.Intersects(rectangle3))
								{
									flag16 = false;
									break;
								}
							}
							if (!flag16)
							{
								break;
							}
						}
					}
					if (flag16)
					{
						if (this.type == 37 || !Collision.SolidTiles(this.homeTileX - 1, this.homeTileX + 1, num180 - 3, num180 - 1))
						{
							this.velocity.X = 0f;
							this.velocity.Y = 0f;
							this.position.X = (float)(this.homeTileX * 16 + 8 - this.width / 2);
							this.position.Y = (float)(num180 * 16 - this.height) - 0.1f;
							this.netUpdate = true;
						}
						else
						{
							this.homeless = true;
							WorldGen.QuickFindHome(this.whoAmI);
						}
					}
				}
				if (this.ai[0] == 0f)
				{
					if (this.ai[2] > 0f)
					{
						this.ai[2] -= 1f;
					}
					if (!Main.dayTime && !flag15 && this.type != 46)
					{
						if (Main.netMode != 1)
						{
							if (num177 == this.homeTileX && num178 == num180)
							{
								if (this.velocity.X != 0f)
								{
									this.netUpdate = true;
								}
								if ((double)this.velocity.X > 0.1)
								{
									this.velocity.X = this.velocity.X - 0.1f;
								}
								else if ((double)this.velocity.X < -0.1)
								{
									this.velocity.X = this.velocity.X + 0.1f;
								}
								else
								{
									this.velocity.X = 0f;
								}
							}
							else if (!flag15)
							{
								if (num177 > this.homeTileX)
								{
									this.direction = -1;
								}
								else
								{
									this.direction = 1;
								}
								this.ai[0] = 1f;
								this.ai[1] = (float)(200 + Main.rand.Next(200));
								this.ai[2] = 0f;
								this.netUpdate = true;
							}
						}
					}
					else
					{
						if ((double)this.velocity.X > 0.1)
						{
							this.velocity.X = this.velocity.X - 0.1f;
						}
						else if ((double)this.velocity.X < -0.1)
						{
							this.velocity.X = this.velocity.X + 0.1f;
						}
						else
						{
							this.velocity.X = 0f;
						}
						if (Main.netMode != 1)
						{
							if (this.ai[1] > 0f)
							{
								this.ai[1] -= 1f;
							}
							if (this.ai[1] <= 0f)
							{
								this.ai[0] = 1f;
								this.ai[1] = (float)(200 + Main.rand.Next(200));
								if (this.type == 46)
								{
									this.ai[1] += (float)Main.rand.Next(200, 400);
								}
								this.ai[2] = 0f;
								this.netUpdate = true;
							}
						}
					}
					if (Main.netMode != 1 && (Main.dayTime || (num177 == this.homeTileX && num178 == num180)))
					{
						if (num177 < this.homeTileX - 25 || num177 > this.homeTileX + 25)
						{
							if (this.ai[2] == 0f)
							{
								if (num177 < this.homeTileX - 50 && this.direction == -1)
								{
									this.direction = 1;
									this.netUpdate = true;
								}
								else if (num177 > this.homeTileX + 50 && this.direction == 1)
								{
									this.direction = -1;
									this.netUpdate = true;
								}
							}
						}
						else if (Main.rand.Next(80) == 0 && this.ai[2] == 0f)
						{
							this.ai[2] = 200f;
							this.direction *= -1;
							this.netUpdate = true;
						}
					}
				}
				else if (this.ai[0] == 1f)
				{
					if (Main.netMode != 1 && !Main.dayTime && num177 == this.homeTileX && num178 == this.homeTileY && this.type != 46)
					{
						this.ai[0] = 0f;
						this.ai[1] = (float)(200 + Main.rand.Next(200));
						this.ai[2] = 60f;
						this.netUpdate = true;
					}
					else
					{
						if (Main.netMode != 1 && !this.homeless && !Main.tileDungeon[(int)Main.tile[num177, num178].type] && (num177 < this.homeTileX - 35 || num177 > this.homeTileX + 35))
						{
							if (this.position.X < (float)(this.homeTileX * 16) && this.direction == -1)
							{
								this.ai[1] -= 5f;
							}
							else if (this.position.X > (float)(this.homeTileX * 16) && this.direction == 1)
							{
								this.ai[1] -= 5f;
							}
						}
						this.ai[1] -= 1f;
						if (this.ai[1] <= 0f)
						{
							this.ai[0] = 0f;
							this.ai[1] = (float)(300 + Main.rand.Next(300));
							if (this.type == 46)
							{
								this.ai[1] -= (float)Main.rand.Next(100);
							}
							this.ai[2] = 60f;
							this.netUpdate = true;
						}
						if (this.closeDoor && ((this.position.X + (float)(this.width / 2)) / 16f > (float)(this.doorX + 2) || (this.position.X + (float)(this.width / 2)) / 16f < (float)(this.doorX - 2)))
						{
							bool flag17 = WorldGen.CloseDoor(this.doorX, this.doorY, false);
							if (flag17)
							{
								this.closeDoor = false;
								NetMessage.SendData(19, -1, -1, "", 1, (float)this.doorX, (float)this.doorY, (float)this.direction, 0);
							}
							if ((this.position.X + (float)(this.width / 2)) / 16f > (float)(this.doorX + 4) || (this.position.X + (float)(this.width / 2)) / 16f < (float)(this.doorX - 4) || (this.position.Y + (float)(this.height / 2)) / 16f > (float)(this.doorY + 4) || (this.position.Y + (float)(this.height / 2)) / 16f < (float)(this.doorY - 4))
							{
								this.closeDoor = false;
							}
						}
						if (this.velocity.X < -1f || this.velocity.X > 1f)
						{
							if (this.velocity.Y == 0f)
							{
								this.velocity *= 0.8f;
							}
						}
						else if ((double)this.velocity.X < 1.15 && this.direction == 1)
						{
							this.velocity.X = this.velocity.X + 0.07f;
							if (this.velocity.X > 1f)
							{
								this.velocity.X = 1f;
							}
						}
						else if (this.velocity.X > -1f && this.direction == -1)
						{
							this.velocity.X = this.velocity.X - 0.07f;
							if (this.velocity.X > 1f)
							{
								this.velocity.X = 1f;
							}
						}
						if (this.velocity.Y == 0f)
						{
							if (this.position.X == this.ai[2])
							{
								this.direction *= -1;
							}
							this.ai[2] = -1f;
							int num183 = (int)((this.position.X + (float)(this.width / 2) + (float)(15 * this.direction)) / 16f);
							int num184 = (int)((this.position.Y + (float)this.height - 16f) / 16f);
							if (Main.tile[num183, num184] == null)
							{
								Main.tile[num183, num184] = new Tile();
							}
							if (Main.tile[num183, num184 - 1] == null)
							{
								Main.tile[num183, num184 - 1] = new Tile();
							}
							if (Main.tile[num183, num184 - 2] == null)
							{
								Main.tile[num183, num184 - 2] = new Tile();
							}
							if (Main.tile[num183, num184 - 3] == null)
							{
								Main.tile[num183, num184 - 3] = new Tile();
							}
							if (Main.tile[num183, num184 + 1] == null)
							{
								Main.tile[num183, num184 + 1] = new Tile();
							}
							if (Main.tile[num183 + this.direction, num184 - 1] == null)
							{
								Main.tile[num183 + this.direction, num184 - 1] = new Tile();
							}
							if (Main.tile[num183 + this.direction, num184 + 1] == null)
							{
								Main.tile[num183 + this.direction, num184 + 1] = new Tile();
							}
							if (this.townNPC && Main.tile[num183, num184 - 2].active && Main.tile[num183, num184 - 2].type == 10 && (Main.rand.Next(10) == 0 || !Main.dayTime))
							{
								if (Main.netMode != 1)
								{
									bool flag18 = WorldGen.OpenDoor(num183, num184 - 2, this.direction);
									if (flag18)
									{
										this.closeDoor = true;
										this.doorX = num183;
										this.doorY = num184 - 2;
										NetMessage.SendData(19, -1, -1, "", 0, (float)num183, (float)(num184 - 2), (float)this.direction, 0);
										this.netUpdate = true;
										this.ai[1] += 80f;
									}
									else if (WorldGen.OpenDoor(num183, num184 - 2, -this.direction))
									{
										this.closeDoor = true;
										this.doorX = num183;
										this.doorY = num184 - 2;
										NetMessage.SendData(19, -1, -1, "", 0, (float)num183, (float)(num184 - 2), -(float)this.direction, 0);
										this.netUpdate = true;
										this.ai[1] += 80f;
									}
									else
									{
										this.direction *= -1;
										this.netUpdate = true;
									}
								}
							}
							else
							{
								if ((this.velocity.X < 0f && this.spriteDirection == -1) || (this.velocity.X > 0f && this.spriteDirection == 1))
								{
									if (Main.tile[num183, num184 - 2].active && Main.tileSolid[(int)Main.tile[num183, num184 - 2].type] && !Main.tileSolidTop[(int)Main.tile[num183, num184 - 2].type])
									{
										if ((this.direction == 1 && !Collision.SolidTiles(num183 - 2, num183 - 1, num184 - 5, num184 - 1)) || (this.direction == -1 && !Collision.SolidTiles(num183 + 1, num183 + 2, num184 - 5, num184 - 1)))
										{
											if (!Collision.SolidTiles(num183, num183, num184 - 5, num184 - 3))
											{
												this.velocity.Y = -6f;
												this.netUpdate = true;
											}
											else
											{
												this.direction *= -1;
												this.netUpdate = true;
											}
										}
										else
										{
											this.direction *= -1;
											this.netUpdate = true;
										}
									}
									else if (Main.tile[num183, num184 - 1].active && Main.tileSolid[(int)Main.tile[num183, num184 - 1].type] && !Main.tileSolidTop[(int)Main.tile[num183, num184 - 1].type])
									{
										if ((this.direction == 1 && !Collision.SolidTiles(num183 - 2, num183 - 1, num184 - 4, num184 - 1)) || (this.direction == -1 && !Collision.SolidTiles(num183 + 1, num183 + 2, num184 - 4, num184 - 1)))
										{
											if (!Collision.SolidTiles(num183, num183, num184 - 4, num184 - 2))
											{
												this.velocity.Y = -5f;
												this.netUpdate = true;
											}
											else
											{
												this.direction *= -1;
												this.netUpdate = true;
											}
										}
										else
										{
											this.direction *= -1;
											this.netUpdate = true;
										}
									}
									else if (Main.tile[num183, num184].active && Main.tileSolid[(int)Main.tile[num183, num184].type] && !Main.tileSolidTop[(int)Main.tile[num183, num184].type])
									{
										if ((this.direction == 1 && !Collision.SolidTiles(num183 - 2, num183, num184 - 3, num184 - 1)) || (this.direction == -1 && !Collision.SolidTiles(num183, num183 + 2, num184 - 3, num184 - 1)))
										{
											this.velocity.Y = -3.6f;
											this.netUpdate = true;
										}
										else
										{
											this.direction *= -1;
											this.netUpdate = true;
										}
									}
									try
									{
										if (Main.tile[num183, num184 + 1] == null)
										{
											Main.tile[num183, num184 + 1] = new Tile();
										}
										if (Main.tile[num183 - this.direction, num184 + 1] == null)
										{
											Main.tile[num183 - this.direction, num184 + 1] = new Tile();
										}
										if (Main.tile[num183, num184 + 2] == null)
										{
											Main.tile[num183, num184 + 2] = new Tile();
										}
										if (Main.tile[num183 - this.direction, num184 + 2] == null)
										{
											Main.tile[num183 - this.direction, num184 + 2] = new Tile();
										}
										if (Main.tile[num183, num184 + 3] == null)
										{
											Main.tile[num183, num184 + 3] = new Tile();
										}
										if (Main.tile[num183 - this.direction, num184 + 3] == null)
										{
											Main.tile[num183 - this.direction, num184 + 3] = new Tile();
										}
										if (Main.tile[num183, num184 + 4] == null)
										{
											Main.tile[num183, num184 + 4] = new Tile();
										}
										if (Main.tile[num183 - this.direction, num184 + 4] == null)
										{
											Main.tile[num183 - this.direction, num184 + 4] = new Tile();
										}
										else if (num177 >= this.homeTileX - 35 && num177 <= this.homeTileX + 35 && (!Main.tile[num183, num184 + 1].active || !Main.tileSolid[(int)Main.tile[num183, num184 + 1].type]) && (!Main.tile[num183 - this.direction, num184 + 1].active || !Main.tileSolid[(int)Main.tile[num183 - this.direction, num184 + 1].type]) && (!Main.tile[num183, num184 + 2].active || !Main.tileSolid[(int)Main.tile[num183, num184 + 2].type]) && (!Main.tile[num183 - this.direction, num184 + 2].active || !Main.tileSolid[(int)Main.tile[num183 - this.direction, num184 + 2].type]) && (!Main.tile[num183, num184 + 3].active || !Main.tileSolid[(int)Main.tile[num183, num184 + 3].type]) && (!Main.tile[num183 - this.direction, num184 + 3].active || !Main.tileSolid[(int)Main.tile[num183 - this.direction, num184 + 3].type]) && (!Main.tile[num183, num184 + 4].active || !Main.tileSolid[(int)Main.tile[num183, num184 + 4].type]) && (!Main.tile[num183 - this.direction, num184 + 4].active || !Main.tileSolid[(int)Main.tile[num183 - this.direction, num184 + 4].type]) && this.type != 46)
										{
											this.direction *= -1;
											this.velocity.X = this.velocity.X * -1f;
											this.netUpdate = true;
										}
									}
									catch
									{
									}
									if (this.velocity.Y < 0f)
									{
										this.ai[2] = this.position.X;
									}
								}
								if (this.velocity.Y < 0f && this.wet)
								{
									this.velocity.Y = this.velocity.Y * 1.2f;
								}
								if (this.velocity.Y < 0f && this.type == 46)
								{
									this.velocity.Y = this.velocity.Y * 1.2f;
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 8)
			{
				this.TargetClosest(true);
				this.velocity.X = this.velocity.X * 0.93f;
				if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
				{
					this.velocity.X = 0f;
				}
				if (this.ai[0] == 0f)
				{
					this.ai[0] = 500f;
				}
				if (this.ai[2] != 0f && this.ai[3] != 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
					for (int num185 = 0; num185 < 50; num185++)
					{
						if (this.type == 29 || this.type == 45)
						{
							Vector2 vector27 = new Vector2(this.position.X, this.position.Y);
							int num186 = this.width;
							int num187 = this.height;
							int num188 = 27;
							float speedX9 = 0f;
							float speedY13 = 0f;
							int num189 = 100;
							Color newColor = default(Color);
							int num190 = Dust.NewDust(vector27, num186, num187, num188, speedX9, speedY13, num189, newColor, (float)Main.rand.Next(1, 3));
							Dust dust16 = Main.dust[num190];
							dust16.velocity *= 3f;
							if (Main.dust[num190].scale > 1f)
							{
								Main.dust[num190].noGravity = true;
							}
						}
						else if (this.type == 32)
						{
							Vector2 vector28 = new Vector2(this.position.X, this.position.Y);
							int num191 = this.width;
							int num192 = this.height;
							int num193 = 29;
							float speedX10 = 0f;
							float speedY14 = 0f;
							int num194 = 100;
							Color newColor = default(Color);
							int num195 = Dust.NewDust(vector28, num191, num192, num193, speedX10, speedY14, num194, newColor, 2.5f);
							Dust dust17 = Main.dust[num195];
							dust17.velocity *= 3f;
							Main.dust[num195].noGravity = true;
						}
						else
						{
							Vector2 vector29 = new Vector2(this.position.X, this.position.Y);
							int num196 = this.width;
							int num197 = this.height;
							int num198 = 6;
							float speedX11 = 0f;
							float speedY15 = 0f;
							int num199 = 100;
							Color newColor = default(Color);
							int num200 = Dust.NewDust(vector29, num196, num197, num198, speedX11, speedY15, num199, newColor, 2.5f);
							Dust dust18 = Main.dust[num200];
							dust18.velocity *= 3f;
							Main.dust[num200].noGravity = true;
						}
					}
					this.position.X = this.ai[2] * 16f - (float)(this.width / 2) + 8f;
					this.position.Y = this.ai[3] * 16f - (float)this.height;
					this.velocity.X = 0f;
					this.velocity.Y = 0f;
					this.ai[2] = 0f;
					this.ai[3] = 0f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
					for (int num201 = 0; num201 < 50; num201++)
					{
						if (this.type == 29 || this.type == 45)
						{
							Vector2 vector30 = new Vector2(this.position.X, this.position.Y);
							int num202 = this.width;
							int num203 = this.height;
							int num204 = 27;
							float speedX12 = 0f;
							float speedY16 = 0f;
							int num205 = 100;
							Color newColor = default(Color);
							int num206 = Dust.NewDust(vector30, num202, num203, num204, speedX12, speedY16, num205, newColor, (float)Main.rand.Next(1, 3));
							Dust dust19 = Main.dust[num206];
							dust19.velocity *= 3f;
							if (Main.dust[num206].scale > 1f)
							{
								Main.dust[num206].noGravity = true;
							}
						}
						else if (this.type == 32)
						{
							Vector2 vector31 = new Vector2(this.position.X, this.position.Y);
							int num207 = this.width;
							int num208 = this.height;
							int num209 = 29;
							float speedX13 = 0f;
							float speedY17 = 0f;
							int num210 = 100;
							Color newColor = default(Color);
							int num211 = Dust.NewDust(vector31, num207, num208, num209, speedX13, speedY17, num210, newColor, 2.5f);
							Dust dust20 = Main.dust[num211];
							dust20.velocity *= 3f;
							Main.dust[num211].noGravity = true;
						}
						else
						{
							Vector2 vector32 = new Vector2(this.position.X, this.position.Y);
							int num212 = this.width;
							int num213 = this.height;
							int num214 = 6;
							float speedX14 = 0f;
							float speedY18 = 0f;
							int num215 = 100;
							Color newColor = default(Color);
							int num216 = Dust.NewDust(vector32, num212, num213, num214, speedX14, speedY18, num215, newColor, 2.5f);
							Dust dust21 = Main.dust[num216];
							dust21.velocity *= 3f;
							Main.dust[num216].noGravity = true;
						}
					}
				}
				this.ai[0] += 1f;
				if (this.ai[0] == 100f || this.ai[0] == 200f || this.ai[0] == 300f)
				{
					this.ai[1] = 30f;
					this.netUpdate = true;
				}
				else if (this.ai[0] >= 650f && Main.netMode != 1)
				{
					this.ai[0] = 1f;
					int num217 = (int)Main.player[this.target].position.X / 16;
					int num218 = (int)Main.player[this.target].position.Y / 16;
					int num219 = (int)this.position.X / 16;
					int num220 = (int)this.position.Y / 16;
					int num221 = 20;
					int num222 = 0;
					bool flag19 = false;
					if (Math.Abs(this.position.X - Main.player[this.target].position.X) + Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000f)
					{
						num222 = 100;
						flag19 = true;
					}
					while (!flag19 && num222 < 100)
					{
						num222++;
						int num223 = Main.rand.Next(num217 - num221, num217 + num221);
						int num224 = Main.rand.Next(num218 - num221, num218 + num221);
						for (int num225 = num224; num225 < num218 + num221; num225++)
						{
							if ((num225 < num218 - 4 || num225 > num218 + 4 || num223 < num217 - 4 || num223 > num217 + 4) && (num225 < num220 - 1 || num225 > num220 + 1 || num223 < num219 - 1 || num223 > num219 + 1) && Main.tile[num223, num225].active)
							{
								bool flag20 = true;
								if (this.type == 32 && Main.tile[num223, num225 - 1].wall == 0)
								{
									flag20 = false;
								}
								else if (Main.tile[num223, num225 - 1].lava)
								{
									flag20 = false;
								}
								if (flag20 && Main.tileSolid[(int)Main.tile[num223, num225].type] && !Collision.SolidTiles(num223 - 1, num223 + 1, num225 - 4, num225 - 1))
								{
									this.ai[1] = 20f;
									this.ai[2] = (float)num223;
									this.ai[3] = (float)num225;
									flag19 = true;
									break;
								}
							}
						}
					}
					this.netUpdate = true;
				}
				if (this.ai[1] > 0f)
				{
					this.ai[1] -= 1f;
					if (this.ai[1] == 25f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
						if (Main.netMode != 1)
						{
							if (this.type == 29 || this.type == 45)
							{
								NPC.NewNPC((int)this.position.X + this.width / 2, (int)this.position.Y - 8, 30, 0);
							}
							else if (this.type == 32)
							{
								NPC.NewNPC((int)this.position.X + this.width / 2, (int)this.position.Y - 8, 33, 0);
							}
							else
							{
								NPC.NewNPC((int)this.position.X + this.width / 2 + this.direction * 8, (int)this.position.Y + 20, 25, 0);
							}
						}
					}
				}
				if (this.type == 29 || this.type == 45)
				{
					if (Main.rand.Next(5) == 0)
					{
						Vector2 vector33 = new Vector2(this.position.X, this.position.Y + 2f);
						int num226 = this.width;
						int num227 = this.height;
						int num228 = 27;
						float speedX15 = this.velocity.X * 0.2f;
						float speedY19 = this.velocity.Y * 0.2f;
						int num229 = 100;
						Color newColor = default(Color);
						int num230 = Dust.NewDust(vector33, num226, num227, num228, speedX15, speedY19, num229, newColor, 1.5f);
						Main.dust[num230].noGravity = true;
						Dust dust22 = Main.dust[num230];
						dust22.velocity.X = dust22.velocity.X * 0.5f;
						Main.dust[num230].velocity.Y = -2f;
					}
				}
				else if (this.type == 32)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector34 = new Vector2(this.position.X, this.position.Y + 2f);
						int num231 = this.width;
						int num232 = this.height;
						int num233 = 29;
						float speedX16 = this.velocity.X * 0.2f;
						float speedY20 = this.velocity.Y * 0.2f;
						int num234 = 100;
						Color newColor = default(Color);
						int num235 = Dust.NewDust(vector34, num231, num232, num233, speedX16, speedY20, num234, newColor, 2f);
						Main.dust[num235].noGravity = true;
						Dust dust23 = Main.dust[num235];
						dust23.velocity.X = dust23.velocity.X * 1f;
						Dust dust24 = Main.dust[num235];
						dust24.velocity.Y = dust24.velocity.Y * 1f;
					}
				}
				else if (Main.rand.Next(2) == 0)
				{
					Vector2 vector35 = new Vector2(this.position.X, this.position.Y + 2f);
					int num236 = this.width;
					int num237 = this.height;
					int num238 = 6;
					float speedX17 = this.velocity.X * 0.2f;
					float speedY21 = this.velocity.Y * 0.2f;
					int num239 = 100;
					Color newColor = default(Color);
					int num240 = Dust.NewDust(vector35, num236, num237, num238, speedX17, speedY21, num239, newColor, 2f);
					Main.dust[num240].noGravity = true;
					Dust dust25 = Main.dust[num240];
					dust25.velocity.X = dust25.velocity.X * 1f;
					Dust dust26 = Main.dust[num240];
					dust26.velocity.Y = dust26.velocity.Y * 1f;
				}
			}
			else if (this.aiStyle == 9)
			{
				if (this.target == 255)
				{
					this.TargetClosest(true);
					float num241 = 6f;
					if (this.type == 25)
					{
						num241 = 5f;
					}
					if (this.type == 112)
					{
						num241 = 7f;
					}
					Vector2 vector36 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num242 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector36.X;
					float num243 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector36.Y;
					float num244 = (float)Math.Sqrt((double)(num242 * num242 + num243 * num243));
					num244 = num241 / num244;
					this.velocity.X = num242 * num244;
					this.velocity.Y = num243 * num244;
				}
				if (this.type == 112)
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 3f)
					{
						this.ai[0] = 3f;
					}
					if (this.ai[0] == 2f)
					{
						this.position += this.velocity;
						Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 9);
						for (int num245 = 0; num245 < 20; num245++)
						{
							Vector2 vector37 = new Vector2(this.position.X, this.position.Y + 2f);
							int num246 = this.width;
							int num247 = this.height;
							int num248 = 18;
							float speedX18 = 0f;
							float speedY22 = 0f;
							int num249 = 100;
							Color newColor = default(Color);
							int num250 = Dust.NewDust(vector37, num246, num247, num248, speedX18, speedY22, num249, newColor, 1.8f);
							Dust dust27 = Main.dust[num250];
							dust27.velocity *= 1.3f;
							Dust dust28 = Main.dust[num250];
							dust28.velocity += this.velocity;
							Main.dust[num250].noGravity = true;
						}
					}
				}
				if (this.type == 112 && Collision.SolidCollision(this.position, this.width, this.height))
				{
					if (Main.netMode != 1)
					{
						int num251 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num252 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
						int num253 = 8;
						for (int num254 = num251 - num253; num254 <= num251 + num253; num254++)
						{
							for (int num255 = num252 - num253; num255 < num252 + num253; num255++)
							{
								if ((double)(Math.Abs(num254 - num251) + Math.Abs(num255 - num252)) < (double)num253 * 0.5)
								{
									if (Main.tile[num254, num255].type == 2)
									{
										Main.tile[num254, num255].type = 23;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
									else if (Main.tile[num254, num255].type == 1)
									{
										Main.tile[num254, num255].type = 25;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
									else if (Main.tile[num254, num255].type == 53)
									{
										Main.tile[num254, num255].type = 112;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
									else if (Main.tile[num254, num255].type == 109)
									{
										Main.tile[num254, num255].type = 23;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
									else if (Main.tile[num254, num255].type == 117)
									{
										Main.tile[num254, num255].type = 25;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
									else if (Main.tile[num254, num255].type == 116)
									{
										Main.tile[num254, num255].type = 112;
										WorldGen.SquareTileFrame(num254, num255, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num254, num255, 1);
										}
									}
								}
							}
						}
					}
					this.StrikeNPC(999, 0f, 0, false, false);
				}
				if (this.timeLeft > 100)
				{
					this.timeLeft = 100;
				}
				for (int num256 = 0; num256 < 2; num256++)
				{
					if (this.type == 30)
					{
						Vector2 vector38 = new Vector2(this.position.X, this.position.Y + 2f);
						int num257 = this.width;
						int num258 = this.height;
						int num259 = 27;
						float speedX19 = this.velocity.X * 0.2f;
						float speedY23 = this.velocity.Y * 0.2f;
						int num260 = 100;
						Color newColor = default(Color);
						int num261 = Dust.NewDust(vector38, num257, num258, num259, speedX19, speedY23, num260, newColor, 2f);
						Main.dust[num261].noGravity = true;
						Dust dust29 = Main.dust[num261];
						dust29.velocity *= 0.3f;
						Dust dust30 = Main.dust[num261];
						dust30.velocity.X = dust30.velocity.X - this.velocity.X * 0.2f;
						Dust dust31 = Main.dust[num261];
						dust31.velocity.Y = dust31.velocity.Y - this.velocity.Y * 0.2f;
					}
					else if (this.type == 33)
					{
						Vector2 vector39 = new Vector2(this.position.X, this.position.Y + 2f);
						int num262 = this.width;
						int num263 = this.height;
						int num264 = 29;
						float speedX20 = this.velocity.X * 0.2f;
						float speedY24 = this.velocity.Y * 0.2f;
						int num265 = 100;
						Color newColor = default(Color);
						int num266 = Dust.NewDust(vector39, num262, num263, num264, speedX20, speedY24, num265, newColor, 2f);
						Main.dust[num266].noGravity = true;
						Dust dust32 = Main.dust[num266];
						dust32.velocity.X = dust32.velocity.X * 0.3f;
						Dust dust33 = Main.dust[num266];
						dust33.velocity.Y = dust33.velocity.Y * 0.3f;
					}
					else if (this.type == 112)
					{
						Vector2 vector40 = new Vector2(this.position.X, this.position.Y + 2f);
						int num267 = this.width;
						int num268 = this.height;
						int num269 = 18;
						float speedX21 = this.velocity.X * 0.1f;
						float speedY25 = this.velocity.Y * 0.1f;
						int num270 = 80;
						Color newColor = default(Color);
						int num271 = Dust.NewDust(vector40, num267, num268, num269, speedX21, speedY25, num270, newColor, 1.3f);
						Dust dust34 = Main.dust[num271];
						dust34.velocity *= 0.3f;
						Main.dust[num271].noGravity = true;
					}
					else
					{
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 1f, 0.3f, 0.1f);
						Vector2 vector41 = new Vector2(this.position.X, this.position.Y + 2f);
						int num272 = this.width;
						int num273 = this.height;
						int num274 = 6;
						float speedX22 = this.velocity.X * 0.2f;
						float speedY26 = this.velocity.Y * 0.2f;
						int num275 = 100;
						Color newColor = default(Color);
						int num276 = Dust.NewDust(vector41, num272, num273, num274, speedX22, speedY26, num275, newColor, 2f);
						Main.dust[num276].noGravity = true;
						Dust dust35 = Main.dust[num276];
						dust35.velocity.X = dust35.velocity.X * 0.3f;
						Dust dust36 = Main.dust[num276];
						dust36.velocity.Y = dust36.velocity.Y * 0.3f;
					}
				}
				this.rotation += 0.4f * (float)this.direction;
			}
			else if (this.aiStyle == 10)
			{
				float num277 = 1f;
				float num278 = 0.011f;
				this.TargetClosest(true);
				Vector2 vector42 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num279 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector42.X;
				float num280 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector42.Y;
				float num281 = (float)Math.Sqrt((double)(num279 * num279 + num280 * num280));
				float num282 = num281;
				this.ai[1] += 1f;
				if (this.ai[1] > 600f)
				{
					num278 *= 8f;
					num277 = 4f;
					if (this.ai[1] > 650f)
					{
						this.ai[1] = 0f;
					}
				}
				else if (num282 < 250f)
				{
					this.ai[0] += 0.9f;
					if (this.ai[0] > 0f)
					{
						this.velocity.Y = this.velocity.Y + 0.019f;
					}
					else
					{
						this.velocity.Y = this.velocity.Y - 0.019f;
					}
					if (this.ai[0] < -100f || this.ai[0] > 100f)
					{
						this.velocity.X = this.velocity.X + 0.019f;
					}
					else
					{
						this.velocity.X = this.velocity.X - 0.019f;
					}
					if (this.ai[0] > 200f)
					{
						this.ai[0] = -200f;
					}
				}
				if (num282 > 350f)
				{
					num277 = 5f;
					num278 = 0.3f;
				}
				else if (num282 > 300f)
				{
					num277 = 3f;
					num278 = 0.2f;
				}
				else if (num282 > 250f)
				{
					num277 = 1.5f;
					num278 = 0.1f;
				}
				num281 = num277 / num281;
				num279 *= num281;
				num280 *= num281;
				if (Main.player[this.target].dead)
				{
					num279 = (float)this.direction * num277 / 2f;
					num280 = -num277 / 2f;
				}
				if (this.velocity.X < num279)
				{
					this.velocity.X = this.velocity.X + num278;
				}
				else if (this.velocity.X > num279)
				{
					this.velocity.X = this.velocity.X - num278;
				}
				if (this.velocity.Y < num280)
				{
					this.velocity.Y = this.velocity.Y + num278;
				}
				else if (this.velocity.Y > num280)
				{
					this.velocity.Y = this.velocity.Y - num278;
				}
				if (num279 > 0f)
				{
					this.spriteDirection = -1;
					this.rotation = (float)Math.Atan2((double)num280, (double)num279);
				}
				if (num279 < 0f)
				{
					this.spriteDirection = 1;
					this.rotation = (float)Math.Atan2((double)num280, (double)num279) + 3.14f;
				}
			}
			else if (this.aiStyle == 11)
			{
				if (this.ai[0] == 0f && Main.netMode != 1)
				{
					this.TargetClosest(true);
					this.ai[0] = 1f;
					if (this.type != 68)
					{
						int num283 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 36, this.whoAmI);
						Main.npc[num283].ai[0] = -1f;
						Main.npc[num283].ai[1] = (float)this.whoAmI;
						Main.npc[num283].target = this.target;
						Main.npc[num283].netUpdate = true;
						num283 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 36, this.whoAmI);
						Main.npc[num283].ai[0] = 1f;
						Main.npc[num283].ai[1] = (float)this.whoAmI;
						Main.npc[num283].ai[3] = 150f;
						Main.npc[num283].target = this.target;
						Main.npc[num283].netUpdate = true;
					}
				}
				if (this.type == 68 && this.ai[1] != 3f && this.ai[1] != 2f)
				{
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					this.ai[1] = 2f;
				}
				if (Main.player[this.target].dead || Math.Abs(this.position.X - Main.player[this.target].position.X) > 2000f || Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000f)
				{
					this.TargetClosest(true);
					if (Main.player[this.target].dead || Math.Abs(this.position.X - Main.player[this.target].position.X) > 2000f || Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000f)
					{
						this.ai[1] = 3f;
					}
				}
				if (Main.dayTime && this.ai[1] != 3f && this.ai[1] != 2f)
				{
					this.ai[1] = 2f;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
				}
				if (this.ai[1] == 0f)
				{
					this.defense = 10;
					this.ai[2] += 1f;
					if (this.ai[2] >= 800f)
					{
						this.ai[2] = 0f;
						this.ai[1] = 1f;
						this.TargetClosest(true);
						this.netUpdate = true;
					}
					this.rotation = this.velocity.X / 15f;
					if (this.position.Y > Main.player[this.target].position.Y - 250f)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.98f;
						}
						this.velocity.Y = this.velocity.Y - 0.02f;
						if (this.velocity.Y > 2f)
						{
							this.velocity.Y = 2f;
						}
					}
					else if (this.position.Y < Main.player[this.target].position.Y - 250f)
					{
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.98f;
						}
						this.velocity.Y = this.velocity.Y + 0.02f;
						if (this.velocity.Y < -2f)
						{
							this.velocity.Y = -2f;
						}
					}
					if (this.position.X + (float)(this.width / 2) > Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2))
					{
						if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X * 0.98f;
						}
						this.velocity.X = this.velocity.X - 0.05f;
						if (this.velocity.X > 8f)
						{
							this.velocity.X = 8f;
						}
					}
					if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2))
					{
						if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X * 0.98f;
						}
						this.velocity.X = this.velocity.X + 0.05f;
						if (this.velocity.X < -8f)
						{
							this.velocity.X = -8f;
						}
					}
				}
				else if (this.ai[1] == 1f)
				{
					this.defense = 0;
					this.ai[2] += 1f;
					if (this.ai[2] == 2f)
					{
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					}
					if (this.ai[2] >= 400f)
					{
						this.ai[2] = 0f;
						this.ai[1] = 0f;
					}
					this.rotation += (float)this.direction * 0.3f;
					Vector2 vector43 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num284 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector43.X;
					float num285 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector43.Y;
					float num286 = (float)Math.Sqrt((double)(num284 * num284 + num285 * num285));
					num286 = 1.5f / num286;
					this.velocity.X = num284 * num286;
					this.velocity.Y = num285 * num286;
				}
				else if (this.ai[1] == 2f)
				{
					this.damage = 9999;
					this.defense = 9999;
					this.rotation += (float)this.direction * 0.3f;
					Vector2 vector44 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num287 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector44.X;
					float num288 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector44.Y;
					float num289 = (float)Math.Sqrt((double)(num287 * num287 + num288 * num288));
					num289 = 8f / num289;
					this.velocity.X = num287 * num289;
					this.velocity.Y = num288 * num289;
				}
				else if (this.ai[1] == 3f)
				{
					this.velocity.Y = this.velocity.Y + 0.1f;
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.95f;
					}
					this.velocity.X = this.velocity.X * 0.95f;
					if (this.timeLeft > 500)
					{
						this.timeLeft = 500;
					}
				}
				if (this.ai[1] != 2f && this.ai[1] != 3f && this.type != 68)
				{
					Vector2 vector45 = new Vector2(this.position.X + (float)(this.width / 2) - 15f - this.velocity.X * 5f, this.position.Y + (float)this.height - 2f);
					int num290 = 30;
					int num291 = 10;
					int num292 = 5;
					float speedX23 = -this.velocity.X * 0.2f;
					float speedY27 = 3f;
					int num293 = 0;
					Color newColor = default(Color);
					int num294 = Dust.NewDust(vector45, num290, num291, num292, speedX23, speedY27, num293, newColor, 2f);
					Main.dust[num294].noGravity = true;
					Dust dust37 = Main.dust[num294];
					dust37.velocity.X = dust37.velocity.X * 1.3f;
					Dust dust38 = Main.dust[num294];
					dust38.velocity.X = dust38.velocity.X + this.velocity.X * 0.4f;
					Dust dust39 = Main.dust[num294];
					dust39.velocity.Y = dust39.velocity.Y + (2f + this.velocity.Y);
					for (int num295 = 0; num295 < 2; num295++)
					{
						Vector2 vector46 = new Vector2(this.position.X, this.position.Y + 120f);
						int num296 = this.width;
						int num297 = 60;
						int num298 = 5;
						float x5 = this.velocity.X;
						float y = this.velocity.Y;
						int num299 = 0;
						newColor = default(Color);
						num294 = Dust.NewDust(vector46, num296, num297, num298, x5, y, num299, newColor, 2f);
						Main.dust[num294].noGravity = true;
						Dust dust40 = Main.dust[num294];
						dust40.velocity -= this.velocity;
						Dust dust41 = Main.dust[num294];
						dust41.velocity.Y = dust41.velocity.Y + 5f;
					}
				}
			}
			else if (this.aiStyle == 12)
			{
				this.spriteDirection = -(int)this.ai[0];
				if (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != 11)
				{
					this.ai[2] += 10f;
					if (this.ai[2] > 50f || Main.netMode != 2)
					{
						this.life = -1;
						this.HitEffect(0, 10.0);
						this.active = false;
					}
				}
				if (this.ai[2] == 0f || this.ai[2] == 3f)
				{
					if (Main.npc[(int)this.ai[1]].ai[1] == 3f && this.timeLeft > 10)
					{
						this.timeLeft = 10;
					}
					if (Main.npc[(int)this.ai[1]].ai[1] != 0f)
					{
						if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y - 100f)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y - 0.07f;
							if (this.velocity.Y > 6f)
							{
								this.velocity.Y = 6f;
							}
						}
						else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 100f)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y + 0.07f;
							if (this.velocity.Y < -6f)
							{
								this.velocity.Y = -6f;
							}
						}
						if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 8f)
							{
								this.velocity.X = 8f;
							}
						}
						if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -8f)
							{
								this.velocity.X = -8f;
							}
						}
					}
					else
					{
						this.ai[3] += 1f;
						if (this.ai[3] >= 300f)
						{
							this.ai[2] += 1f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
						if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y + 230f)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y - 0.04f;
							if (this.velocity.Y > 3f)
							{
								this.velocity.Y = 3f;
							}
						}
						else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y + 230f)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y + 0.04f;
							if (this.velocity.Y < -3f)
							{
								this.velocity.Y = -3f;
							}
						}
						if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0])
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X - 0.07f;
							if (this.velocity.X > 8f)
							{
								this.velocity.X = 8f;
							}
						}
						if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0])
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X + 0.07f;
							if (this.velocity.X < -8f)
							{
								this.velocity.X = -8f;
							}
						}
					}
					Vector2 vector47 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num300 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector47.X;
					float num301 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector47.Y;
					Math.Sqrt((double)(num300 * num300 + num301 * num301));
					this.rotation = (float)Math.Atan2((double)num301, (double)num300) + 1.57f;
				}
				else if (this.ai[2] == 1f)
				{
					Vector2 vector48 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num302 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector48.X;
					float num303 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector48.Y;
					float num304 = (float)Math.Sqrt((double)(num302 * num302 + num303 * num303));
					this.rotation = (float)Math.Atan2((double)num303, (double)num302) + 1.57f;
					this.velocity.X = this.velocity.X * 0.95f;
					this.velocity.Y = this.velocity.Y - 0.1f;
					if (this.velocity.Y < -8f)
					{
						this.velocity.Y = -8f;
					}
					if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 200f)
					{
						this.TargetClosest(true);
						this.ai[2] = 2f;
						vector48 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num302 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector48.X;
						num303 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector48.Y;
						num304 = (float)Math.Sqrt((double)(num302 * num302 + num303 * num303));
						num304 = 18f / num304;
						this.velocity.X = num302 * num304;
						this.velocity.Y = num303 * num304;
						this.netUpdate = true;
					}
				}
				else if (this.ai[2] == 2f)
				{
					if (this.position.Y > Main.player[this.target].position.Y || this.velocity.Y < 0f)
					{
						this.ai[2] = 3f;
					}
				}
				else if (this.ai[2] == 4f)
				{
					Vector2 vector49 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num305 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector49.X;
					float num306 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector49.Y;
					float num307 = (float)Math.Sqrt((double)(num305 * num305 + num306 * num306));
					this.rotation = (float)Math.Atan2((double)num306, (double)num305) + 1.57f;
					this.velocity.Y = this.velocity.Y * 0.95f;
					this.velocity.X = this.velocity.X + 0.1f * -this.ai[0];
					if (this.velocity.X < -8f)
					{
						this.velocity.X = -8f;
					}
					if (this.velocity.X > 8f)
					{
						this.velocity.X = 8f;
					}
					if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 500f || this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) + 500f)
					{
						this.TargetClosest(true);
						this.ai[2] = 5f;
						vector49 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num305 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector49.X;
						num306 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector49.Y;
						num307 = (float)Math.Sqrt((double)(num305 * num305 + num306 * num306));
						num307 = 17f / num307;
						this.velocity.X = num305 * num307;
						this.velocity.Y = num306 * num307;
						this.netUpdate = true;
					}
				}
				else if (this.ai[2] == 5f && ((this.velocity.X > 0f && this.position.X + (float)(this.width / 2) > Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2)) || (this.velocity.X < 0f && this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2))))
				{
					this.ai[2] = 0f;
				}
			}
			else if (this.aiStyle == 13)
			{
				if (Main.tile[(int)this.ai[0], (int)this.ai[1]] == null)
				{
					Main.tile[(int)this.ai[0], (int)this.ai[1]] = new Tile();
				}
				if (!Main.tile[(int)this.ai[0], (int)this.ai[1]].active)
				{
					this.life = -1;
					this.HitEffect(0, 10.0);
					this.active = false;
				}
				else
				{
					this.TargetClosest(true);
					float num308 = 0.035f;
					float num309 = 150f;
					if (this.type == 43)
					{
						num309 = 250f;
					}
					if (this.type == 101)
					{
						num309 = 175f;
					}
					this.ai[2] += 1f;
					if (this.ai[2] > 300f)
					{
						num309 = (float)((int)((double)num309 * 1.3));
						if (this.ai[2] > 450f)
						{
							this.ai[2] = 0f;
						}
					}
					Vector2 vector50 = new Vector2(this.ai[0] * 16f + 8f, this.ai[1] * 16f + 8f);
					float num310 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - (float)(this.width / 2) - vector50.X;
					float num311 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - (float)(this.height / 2) - vector50.Y;
					float num312 = (float)Math.Sqrt((double)(num310 * num310 + num311 * num311));
					if (num312 > num309)
					{
						num312 = num309 / num312;
						num310 *= num312;
						num311 *= num312;
					}
					if (this.position.X < this.ai[0] * 16f + 8f + num310)
					{
						this.velocity.X = this.velocity.X + num308;
						if (this.velocity.X < 0f && num310 > 0f)
						{
							this.velocity.X = this.velocity.X + num308 * 1.5f;
						}
					}
					else if (this.position.X > this.ai[0] * 16f + 8f + num310)
					{
						this.velocity.X = this.velocity.X - num308;
						if (this.velocity.X > 0f && num310 < 0f)
						{
							this.velocity.X = this.velocity.X - num308 * 1.5f;
						}
					}
					if (this.position.Y < this.ai[1] * 16f + 8f + num311)
					{
						this.velocity.Y = this.velocity.Y + num308;
						if (this.velocity.Y < 0f && num311 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num308 * 1.5f;
						}
					}
					else if (this.position.Y > this.ai[1] * 16f + 8f + num311)
					{
						this.velocity.Y = this.velocity.Y - num308;
						if (this.velocity.Y > 0f && num311 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num308 * 1.5f;
						}
					}
					if (this.type == 43)
					{
						if (this.velocity.X > 3f)
						{
							this.velocity.X = 3f;
						}
						if (this.velocity.X < -3f)
						{
							this.velocity.X = -3f;
						}
						if (this.velocity.Y > 3f)
						{
							this.velocity.Y = 3f;
						}
						if (this.velocity.Y < -3f)
						{
							this.velocity.Y = -3f;
						}
					}
					else
					{
						if (this.velocity.X > 2f)
						{
							this.velocity.X = 2f;
						}
						if (this.velocity.X < -2f)
						{
							this.velocity.X = -2f;
						}
						if (this.velocity.Y > 2f)
						{
							this.velocity.Y = 2f;
						}
						if (this.velocity.Y < -2f)
						{
							this.velocity.Y = -2f;
						}
					}
					if (num310 > 0f)
					{
						this.spriteDirection = 1;
						this.rotation = (float)Math.Atan2((double)num311, (double)num310);
					}
					if (num310 < 0f)
					{
						this.spriteDirection = -1;
						this.rotation = (float)Math.Atan2((double)num311, (double)num310) + 3.14f;
					}
					if (this.collideX)
					{
						this.netUpdate = true;
						this.velocity.X = this.oldVelocity.X * -0.7f;
						if (this.velocity.X > 0f && this.velocity.X < 2f)
						{
							this.velocity.X = 2f;
						}
						if (this.velocity.X < 0f && this.velocity.X > -2f)
						{
							this.velocity.X = -2f;
						}
					}
					if (this.collideY)
					{
						this.netUpdate = true;
						this.velocity.Y = this.oldVelocity.Y * -0.7f;
						if (this.velocity.Y > 0f && this.velocity.Y < 2f)
						{
							this.velocity.Y = 2f;
						}
						if (this.velocity.Y < 0f && this.velocity.Y > -2f)
						{
							this.velocity.Y = -2f;
						}
					}
					if (Main.netMode != 1 && this.type == 101 && !Main.player[this.target].dead)
					{
						if (this.justHit)
						{
							this.localAI[0] = 0f;
						}
						this.localAI[0] += 1f;
						if (this.localAI[0] >= 120f)
						{
							if (!Collision.SolidCollision(this.position, this.width, this.height) && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								float num313 = 10f;
								vector50 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								num310 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector50.X + (float)Main.rand.Next(-10, 11);
								num311 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector50.Y + (float)Main.rand.Next(-10, 11);
								num312 = (float)Math.Sqrt((double)(num310 * num310 + num311 * num311));
								num312 = num313 / num312;
								num310 *= num312;
								num311 *= num312;
								int num314 = 22;
								int num315 = 96;
								int num316 = Projectile.NewProjectile(vector50.X, vector50.Y, num310, num311, num315, num314, 0f, Main.myPlayer);
								Main.projectile[num316].timeLeft = 300;
								this.localAI[0] = 0f;
							}
							else
							{
								this.localAI[0] = 100f;
							}
						}
					}
				}
			}
			else if (this.aiStyle == 14)
			{
				if (this.type == 60)
				{
					Vector2 vector51 = new Vector2(this.position.X, this.position.Y);
					int num317 = this.width;
					int num318 = this.height;
					int num319 = 6;
					float speedX24 = this.velocity.X * 0.2f;
					float speedY28 = this.velocity.Y * 0.2f;
					int num320 = 100;
					Color newColor = default(Color);
					int num321 = Dust.NewDust(vector51, num317, num318, num319, speedX24, speedY28, num320, newColor, 2f);
					Main.dust[num321].noGravity = true;
				}
				this.noGravity = true;
				if (this.collideX)
				{
					this.velocity.X = this.oldVelocity.X * -0.5f;
					if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 2f)
					{
						this.velocity.X = 2f;
					}
					if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -2f)
					{
						this.velocity.X = -2f;
					}
				}
				if (this.collideY)
				{
					this.velocity.Y = this.oldVelocity.Y * -0.5f;
					if (this.velocity.Y > 0f && this.velocity.Y < 1f)
					{
						this.velocity.Y = 1f;
					}
					if (this.velocity.Y < 0f && this.velocity.Y > -1f)
					{
						this.velocity.Y = -1f;
					}
				}
				this.TargetClosest(true);
				if (this.direction == -1 && this.velocity.X > -4f)
				{
					this.velocity.X = this.velocity.X - 0.1f;
					if (this.velocity.X > 4f)
					{
						this.velocity.X = this.velocity.X - 0.1f;
					}
					else if (this.velocity.X > 0f)
					{
						this.velocity.X = this.velocity.X + 0.05f;
					}
					if (this.velocity.X < -4f)
					{
						this.velocity.X = -4f;
					}
				}
				else if (this.direction == 1 && this.velocity.X < 4f)
				{
					this.velocity.X = this.velocity.X + 0.1f;
					if (this.velocity.X < -4f)
					{
						this.velocity.X = this.velocity.X + 0.1f;
					}
					else if (this.velocity.X < 0f)
					{
						this.velocity.X = this.velocity.X - 0.05f;
					}
					if (this.velocity.X > 4f)
					{
						this.velocity.X = 4f;
					}
				}
				if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
				{
					this.velocity.Y = this.velocity.Y - 0.04f;
					if ((double)this.velocity.Y > 1.5)
					{
						this.velocity.Y = this.velocity.Y - 0.05f;
					}
					else if (this.velocity.Y > 0f)
					{
						this.velocity.Y = this.velocity.Y + 0.03f;
					}
					if ((double)this.velocity.Y < -1.5)
					{
						this.velocity.Y = -1.5f;
					}
				}
				else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
				{
					this.velocity.Y = this.velocity.Y + 0.04f;
					if ((double)this.velocity.Y < -1.5)
					{
						this.velocity.Y = this.velocity.Y + 0.05f;
					}
					else if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y - 0.03f;
					}
					if ((double)this.velocity.Y > 1.5)
					{
						this.velocity.Y = 1.5f;
					}
				}
				if (this.type == 49 || this.type == 51 || this.type == 60 || this.type == 62 || this.type == 66 || this.type == 93 || this.type == 137)
				{
					if (this.wet)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.95f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
						this.TargetClosest(true);
					}
					if (this.type == 60)
					{
						if (this.direction == -1 && this.velocity.X > -4f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 4f)
							{
								this.velocity.X = this.velocity.X - 0.07f;
							}
							else if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X + 0.03f;
							}
							if (this.velocity.X < -4f)
							{
								this.velocity.X = -4f;
							}
						}
						else if (this.direction == 1 && this.velocity.X < 4f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -4f)
							{
								this.velocity.X = this.velocity.X + 0.07f;
							}
							else if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X - 0.03f;
							}
							if (this.velocity.X > 4f)
							{
								this.velocity.X = 4f;
							}
						}
						if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
						{
							this.velocity.Y = this.velocity.Y - 0.04f;
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = this.velocity.Y - 0.03f;
							}
							else if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y + 0.02f;
							}
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = -1.5f;
							}
						}
						else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
						{
							this.velocity.Y = this.velocity.Y + 0.04f;
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = this.velocity.Y + 0.03f;
							}
							else if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y - 0.02f;
							}
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = 1.5f;
							}
						}
					}
					else
					{
						if (this.direction == -1 && this.velocity.X > -4f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 4f)
							{
								this.velocity.X = this.velocity.X - 0.1f;
							}
							else if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X + 0.05f;
							}
							if (this.velocity.X < -4f)
							{
								this.velocity.X = -4f;
							}
						}
						else if (this.direction == 1 && this.velocity.X < 4f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -4f)
							{
								this.velocity.X = this.velocity.X + 0.1f;
							}
							else if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X - 0.05f;
							}
							if (this.velocity.X > 4f)
							{
								this.velocity.X = 4f;
							}
						}
						if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
						{
							this.velocity.Y = this.velocity.Y - 0.04f;
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = this.velocity.Y - 0.05f;
							}
							else if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y + 0.03f;
							}
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = -1.5f;
							}
						}
						else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
						{
							this.velocity.Y = this.velocity.Y + 0.04f;
							if ((double)this.velocity.Y < -1.5)
							{
								this.velocity.Y = this.velocity.Y + 0.05f;
							}
							else if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y - 0.03f;
							}
							if ((double)this.velocity.Y > 1.5)
							{
								this.velocity.Y = 1.5f;
							}
						}
					}
				}
				this.ai[1] += 1f;
				if (this.ai[1] > 200f)
				{
					if (!Main.player[this.target].wet && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
					{
						this.ai[1] = 0f;
					}
					float num322 = 0.2f;
					float num323 = 0.1f;
					float num324 = 4f;
					float num325 = 1.5f;
					if (this.type == 48 || this.type == 62 || this.type == 66)
					{
						num322 = 0.12f;
						num323 = 0.07f;
						num324 = 3f;
						num325 = 1.25f;
					}
					if (this.ai[1] > 1000f)
					{
						this.ai[1] = 0f;
					}
					this.ai[2] += 1f;
					if (this.ai[2] > 0f)
					{
						if (this.velocity.Y < num325)
						{
							this.velocity.Y = this.velocity.Y + num323;
						}
					}
					else if (this.velocity.Y > -num325)
					{
						this.velocity.Y = this.velocity.Y - num323;
					}
					if (this.ai[2] < -150f || this.ai[2] > 150f)
					{
						if (this.velocity.X < num324)
						{
							this.velocity.X = this.velocity.X + num322;
						}
					}
					else if (this.velocity.X > -num324)
					{
						this.velocity.X = this.velocity.X - num322;
					}
					if (this.ai[2] > 300f)
					{
						this.ai[2] = -300f;
					}
				}
				if (Main.netMode != 1)
				{
					if (this.type == 48)
					{
						this.ai[0] += 1f;
						if (this.ai[0] == 30f || this.ai[0] == 60f || this.ai[0] == 90f)
						{
							if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								float num326 = 6f;
								Vector2 vector52 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num327 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector52.X + (float)Main.rand.Next(-100, 101);
								float num328 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector52.Y + (float)Main.rand.Next(-100, 101);
								float num329 = (float)Math.Sqrt((double)(num327 * num327 + num328 * num328));
								num329 = num326 / num329;
								num327 *= num329;
								num328 *= num329;
								int num330 = 15;
								int num331 = 38;
								int num332 = Projectile.NewProjectile(vector52.X, vector52.Y, num327, num328, num331, num330, 0f, Main.myPlayer);
								Main.projectile[num332].timeLeft = 300;
							}
						}
						else if (this.ai[0] >= (float)(400 + Main.rand.Next(400)))
						{
							this.ai[0] = 0f;
						}
					}
					if (this.type == 62 || this.type == 66)
					{
						this.ai[0] += 1f;
						if (this.ai[0] == 20f || this.ai[0] == 40f || this.ai[0] == 60f || this.ai[0] == 80f)
						{
							if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								float num333 = 0.2f;
								Vector2 vector53 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num334 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector53.X + (float)Main.rand.Next(-100, 101);
								float num335 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector53.Y + (float)Main.rand.Next(-100, 101);
								float num336 = (float)Math.Sqrt((double)(num334 * num334 + num335 * num335));
								num336 = num333 / num336;
								num334 *= num336;
								num335 *= num336;
								int num337 = 21;
								int num338 = 44;
								int num339 = Projectile.NewProjectile(vector53.X, vector53.Y, num334, num335, num338, num337, 0f, Main.myPlayer);
								Main.projectile[num339].timeLeft = 300;
							}
						}
						else if (this.ai[0] >= (float)(300 + Main.rand.Next(300)))
						{
							this.ai[0] = 0f;
						}
					}
				}
			}
			else if (this.aiStyle == 15)
			{
				this.aiAction = 0;
				if (this.ai[3] == 0f && this.life > 0)
				{
					this.ai[3] = (float)this.lifeMax;
				}
				if (this.ai[2] == 0f)
				{
					this.ai[0] = -100f;
					this.ai[2] = 1f;
					this.TargetClosest(true);
				}
				if (this.velocity.Y == 0f)
				{
					this.velocity.X = this.velocity.X * 0.8f;
					if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
					{
						this.velocity.X = 0f;
					}
					this.ai[0] += 2f;
					if ((double)this.life < (double)this.lifeMax * 0.8)
					{
						this.ai[0] += 1f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.6)
					{
						this.ai[0] += 1f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.4)
					{
						this.ai[0] += 2f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.2)
					{
						this.ai[0] += 3f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.1)
					{
						this.ai[0] += 4f;
					}
					if (this.ai[0] >= 0f)
					{
						this.netUpdate = true;
						this.TargetClosest(true);
						if (this.ai[1] == 3f)
						{
							this.velocity.Y = -13f;
							this.velocity.X = this.velocity.X + 3.5f * (float)this.direction;
							this.ai[0] = -200f;
							this.ai[1] = 0f;
						}
						else if (this.ai[1] == 2f)
						{
							this.velocity.Y = -6f;
							this.velocity.X = this.velocity.X + 4.5f * (float)this.direction;
							this.ai[0] = -120f;
							this.ai[1] += 1f;
						}
						else
						{
							this.velocity.Y = -8f;
							this.velocity.X = this.velocity.X + 4f * (float)this.direction;
							this.ai[0] = -120f;
							this.ai[1] += 1f;
						}
					}
					else if (this.ai[0] >= -30f)
					{
						this.aiAction = 1;
					}
				}
				else if (this.target < 255 && ((this.direction == 1 && this.velocity.X < 3f) || (this.direction == -1 && this.velocity.X > -3f)))
				{
					if ((this.direction == -1 && (double)this.velocity.X < 0.1) || (this.direction == 1 && (double)this.velocity.X > -0.1))
					{
						this.velocity.X = this.velocity.X + 0.2f * (float)this.direction;
					}
					else
					{
						this.velocity.X = this.velocity.X * 0.93f;
					}
				}
				int num340 = Dust.NewDust(this.position, this.width, this.height, 4, this.velocity.X, this.velocity.Y, 255, new Color(0, 80, 255, 80), this.scale * 1.2f);
				Main.dust[num340].noGravity = true;
				Dust dust42 = Main.dust[num340];
				dust42.velocity *= 0.5f;
				if (this.life > 0)
				{
					float num341 = (float)this.life / (float)this.lifeMax;
					num341 = num341 * 0.5f + 0.75f;
					if (num341 != this.scale)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)this.height;
						this.scale = num341;
						this.width = (int)(98f * this.scale);
						this.height = (int)(92f * this.scale);
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)this.height;
					}
					if (Main.netMode != 1)
					{
						int num342 = (int)((double)this.lifeMax * 0.05);
						if ((float)(this.life + num342) < this.ai[3])
						{
							this.ai[3] = (float)this.life;
							int num343 = Main.rand.Next(1, 4);
							for (int num344 = 0; num344 < num343; num344++)
							{
								int x6 = (int)(this.position.X + (float)Main.rand.Next(this.width - 32));
								int y2 = (int)(this.position.Y + (float)Main.rand.Next(this.height - 32));
								int num345 = NPC.NewNPC(x6, y2, 1, 0);
								Main.npc[num345].SetDefaults(1, -1f);
								Main.npc[num345].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
								Main.npc[num345].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
								Main.npc[num345].ai[1] = (float)Main.rand.Next(3);
								if (Main.netMode == 2 && num345 < 200)
								{
									NetMessage.SendData(23, -1, -1, "", num345, 0f, 0f, 0f, 0);
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 16)
			{
				if (this.direction == 0)
				{
					this.TargetClosest(true);
				}
				if (this.wet)
				{
					bool flag21 = false;
					if (this.type != 55)
					{
						this.TargetClosest(false);
						if (Main.player[this.target].wet && !Main.player[this.target].dead)
						{
							flag21 = true;
						}
					}
					if (!flag21)
					{
						if (this.collideX)
						{
							this.velocity.X = this.velocity.X * -1f;
							this.direction *= -1;
							this.netUpdate = true;
						}
						if (this.collideY)
						{
							this.netUpdate = true;
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = Math.Abs(this.velocity.Y) * -1f;
								this.directionY = -1;
								this.ai[0] = -1f;
							}
							else if (this.velocity.Y < 0f)
							{
								this.velocity.Y = Math.Abs(this.velocity.Y);
								this.directionY = 1;
								this.ai[0] = 1f;
							}
						}
					}
					if (this.type == 102)
					{
						Lighting.addLight((int)(this.position.X + (float)(this.width / 2) + (float)(this.direction * (this.width + 8))) / 16, (int)(this.position.Y + 2f) / 16, 0.07f, 0.04f, 0.025f);
					}
					if (flag21)
					{
						this.TargetClosest(true);
						if (this.type == 65 || this.type == 102)
						{
							this.velocity.X = this.velocity.X + (float)this.direction * 0.15f;
							this.velocity.Y = this.velocity.Y + (float)this.directionY * 0.15f;
							if (this.velocity.X > 5f)
							{
								this.velocity.X = 5f;
							}
							if (this.velocity.X < -5f)
							{
								this.velocity.X = -5f;
							}
							if (this.velocity.Y > 3f)
							{
								this.velocity.Y = 3f;
							}
							if (this.velocity.Y < -3f)
							{
								this.velocity.Y = -3f;
							}
						}
						else
						{
							this.velocity.X = this.velocity.X + (float)this.direction * 0.1f;
							this.velocity.Y = this.velocity.Y + (float)this.directionY * 0.1f;
							if (this.velocity.X > 3f)
							{
								this.velocity.X = 3f;
							}
							if (this.velocity.X < -3f)
							{
								this.velocity.X = -3f;
							}
							if (this.velocity.Y > 2f)
							{
								this.velocity.Y = 2f;
							}
							if (this.velocity.Y < -2f)
							{
								this.velocity.Y = -2f;
							}
						}
					}
					else
					{
						this.velocity.X = this.velocity.X + (float)this.direction * 0.1f;
						if (this.velocity.X < -1f || this.velocity.X > 1f)
						{
							this.velocity.X = this.velocity.X * 0.95f;
						}
						if (this.ai[0] == -1f)
						{
							this.velocity.Y = this.velocity.Y - 0.01f;
							if ((double)this.velocity.Y < -0.3)
							{
								this.ai[0] = 1f;
							}
						}
						else
						{
							this.velocity.Y = this.velocity.Y + 0.01f;
							if ((double)this.velocity.Y > 0.3)
							{
								this.ai[0] = -1f;
							}
						}
						int num346 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num347 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
						if (Main.tile[num346, num347 - 1] == null)
						{
							Main.tile[num346, num347 - 1] = new Tile();
						}
						if (Main.tile[num346, num347 + 1] == null)
						{
							Main.tile[num346, num347 + 1] = new Tile();
						}
						if (Main.tile[num346, num347 + 2] == null)
						{
							Main.tile[num346, num347 + 2] = new Tile();
						}
						if (Main.tile[num346, num347 - 1].liquid > 128)
						{
							if (Main.tile[num346, num347 + 1].active)
							{
								this.ai[0] = -1f;
							}
							else if (Main.tile[num346, num347 + 2].active)
							{
								this.ai[0] = -1f;
							}
						}
						if ((double)this.velocity.Y > 0.4 || (double)this.velocity.Y < -0.4)
						{
							this.velocity.Y = this.velocity.Y * 0.95f;
						}
					}
				}
				else
				{
					if (this.velocity.Y == 0f)
					{
						if (this.type == 65)
						{
							this.velocity.X = this.velocity.X * 0.94f;
							if ((double)this.velocity.X > -0.2 && (double)this.velocity.X < 0.2)
							{
								this.velocity.X = 0f;
							}
						}
						else if (Main.netMode != 1)
						{
							this.velocity.Y = (float)Main.rand.Next(-50, -20) * 0.1f;
							this.velocity.X = (float)Main.rand.Next(-20, 20) * 0.1f;
							this.netUpdate = true;
						}
					}
					this.velocity.Y = this.velocity.Y + 0.3f;
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
					this.ai[0] = 1f;
				}
				this.rotation = this.velocity.Y * (float)this.direction * 0.1f;
				if ((double)this.rotation < -0.2)
				{
					this.rotation = -0.2f;
				}
				if ((double)this.rotation > 0.2)
				{
					this.rotation = 0.2f;
				}
			}
			else if (this.aiStyle == 17)
			{
				this.noGravity = true;
				if (this.ai[0] == 0f)
				{
					this.noGravity = false;
					this.TargetClosest(true);
					if (Main.netMode != 1)
					{
						if (this.velocity.X != 0f || this.velocity.Y < 0f || (double)this.velocity.Y > 0.3)
						{
							this.ai[0] = 1f;
							this.netUpdate = true;
						}
						else
						{
							Rectangle rectangle5 = new Rectangle((int)Main.player[this.target].position.X, (int)Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
							Rectangle rectangle6 = new Rectangle((int)this.position.X - 100, (int)this.position.Y - 100, this.width + 200, this.height + 200);
							if (rectangle6.Intersects(rectangle5) || this.life < this.lifeMax)
							{
								this.ai[0] = 1f;
								this.velocity.Y = this.velocity.Y - 6f;
								this.netUpdate = true;
							}
						}
					}
				}
				else if (!Main.player[this.target].dead)
				{
					if (this.collideX)
					{
						this.velocity.X = this.oldVelocity.X * -0.5f;
						if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 2f)
						{
							this.velocity.X = 2f;
						}
						if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -2f)
						{
							this.velocity.X = -2f;
						}
					}
					if (this.collideY)
					{
						this.velocity.Y = this.oldVelocity.Y * -0.5f;
						if (this.velocity.Y > 0f && this.velocity.Y < 1f)
						{
							this.velocity.Y = 1f;
						}
						if (this.velocity.Y < 0f && this.velocity.Y > -1f)
						{
							this.velocity.Y = -1f;
						}
					}
					this.TargetClosest(true);
					if (this.direction == -1 && this.velocity.X > -3f)
					{
						this.velocity.X = this.velocity.X - 0.1f;
						if (this.velocity.X > 3f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
						}
						else if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X - 0.05f;
						}
						if (this.velocity.X < -3f)
						{
							this.velocity.X = -3f;
						}
					}
					else if (this.direction == 1 && this.velocity.X < 3f)
					{
						this.velocity.X = this.velocity.X + 0.1f;
						if (this.velocity.X < -3f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
						}
						else if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X + 0.05f;
						}
						if (this.velocity.X > 3f)
						{
							this.velocity.X = 3f;
						}
					}
					float num348 = Math.Abs(this.position.X + (float)(this.width / 2) - (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2)));
					float num349 = Main.player[this.target].position.Y - (float)(this.height / 2);
					if (num348 > 50f)
					{
						num349 -= 100f;
					}
					if (this.position.Y < num349)
					{
						this.velocity.Y = this.velocity.Y + 0.05f;
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.01f;
						}
					}
					else
					{
						this.velocity.Y = this.velocity.Y - 0.05f;
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - 0.01f;
						}
					}
					if (this.velocity.Y < -3f)
					{
						this.velocity.Y = -3f;
					}
					if (this.velocity.Y > 3f)
					{
						this.velocity.Y = 3f;
					}
				}
				if (this.wet)
				{
					if (this.velocity.Y > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.95f;
					}
					this.velocity.Y = this.velocity.Y - 0.5f;
					if (this.velocity.Y < -4f)
					{
						this.velocity.Y = -4f;
					}
					this.TargetClosest(true);
				}
			}
			else if (this.aiStyle == 18)
			{
				if (this.type == 63)
				{
					Lighting.addLight((int)(this.position.X + (float)(this.height / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.05f, 0.15f, 0.4f);
				}
				else if (this.type == 103)
				{
					Lighting.addLight((int)(this.position.X + (float)(this.height / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.05f, 0.45f, 0.1f);
				}
				else
				{
					Lighting.addLight((int)(this.position.X + (float)(this.height / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.35f, 0.05f, 0.2f);
				}
				if (this.direction == 0)
				{
					this.TargetClosest(true);
				}
				if (!this.wet)
				{
					this.rotation += this.velocity.X * 0.1f;
					if (this.velocity.Y == 0f)
					{
						this.velocity.X = this.velocity.X * 0.98f;
						if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
						{
							this.velocity.X = 0f;
						}
					}
					this.velocity.Y = this.velocity.Y + 0.2f;
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
					this.ai[0] = 1f;
				}
				else
				{
					if (this.collideX)
					{
						this.velocity.X = this.velocity.X * -1f;
						this.direction *= -1;
					}
					if (this.collideY)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = Math.Abs(this.velocity.Y) * -1f;
							this.directionY = -1;
							this.ai[0] = -1f;
						}
						else if (this.velocity.Y < 0f)
						{
							this.velocity.Y = Math.Abs(this.velocity.Y);
							this.directionY = 1;
							this.ai[0] = 1f;
						}
					}
					bool flag22 = false;
					if (!this.friendly)
					{
						this.TargetClosest(false);
						if (Main.player[this.target].wet && !Main.player[this.target].dead)
						{
							flag22 = true;
						}
					}
					if (flag22)
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
						this.velocity *= 0.98f;
						float num350 = 0.2f;
						if (this.type == 103)
						{
							this.velocity *= 0.98f;
							num350 = 0.6f;
						}
						if (this.velocity.X > -num350 && this.velocity.X < num350 && this.velocity.Y > -num350 && this.velocity.Y < num350)
						{
							this.TargetClosest(true);
							float num351 = 7f;
							if (this.type == 103)
							{
								num351 = 9f;
							}
							Vector2 vector54 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num352 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector54.X;
							float num353 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector54.Y;
							float num354 = (float)Math.Sqrt((double)(num352 * num352 + num353 * num353));
							num354 = num351 / num354;
							num352 *= num354;
							num353 *= num354;
							this.velocity.X = num352;
							this.velocity.Y = num353;
						}
					}
					else
					{
						this.velocity.X = this.velocity.X + (float)this.direction * 0.02f;
						this.rotation = this.velocity.X * 0.4f;
						if (this.velocity.X < -1f || this.velocity.X > 1f)
						{
							this.velocity.X = this.velocity.X * 0.95f;
						}
						if (this.ai[0] == -1f)
						{
							this.velocity.Y = this.velocity.Y - 0.01f;
							if (this.velocity.Y < -1f)
							{
								this.ai[0] = 1f;
							}
						}
						else
						{
							this.velocity.Y = this.velocity.Y + 0.01f;
							if (this.velocity.Y > 1f)
							{
								this.ai[0] = -1f;
							}
						}
						int num355 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num356 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
						if (Main.tile[num355, num356 - 1] == null)
						{
							Main.tile[num355, num356 - 1] = new Tile();
						}
						if (Main.tile[num355, num356 + 1] == null)
						{
							Main.tile[num355, num356 + 1] = new Tile();
						}
						if (Main.tile[num355, num356 + 2] == null)
						{
							Main.tile[num355, num356 + 2] = new Tile();
						}
						if (Main.tile[num355, num356 - 1].liquid > 128)
						{
							if (Main.tile[num355, num356 + 1].active)
							{
								this.ai[0] = -1f;
							}
							else if (Main.tile[num355, num356 + 2].active)
							{
								this.ai[0] = -1f;
							}
						}
						else
						{
							this.ai[0] = 1f;
						}
						if ((double)this.velocity.Y > 1.2 || (double)this.velocity.Y < -1.2)
						{
							this.velocity.Y = this.velocity.Y * 0.99f;
						}
					}
				}
			}
			else
			{
				if (this.aiStyle == 19)
				{
					this.TargetClosest(true);
					float num357 = 12f;
					Vector2 vector55 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num358 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector55.X;
					float num359 = Main.player[this.target].position.Y - vector55.Y;
					float num360 = (float)Math.Sqrt((double)(num358 * num358 + num359 * num359));
					num360 = num357 / num360;
					num358 *= num360;
					num359 *= num360;
					bool flag23 = false;
					if (this.directionY < 0)
					{
						this.rotation = (float)(Math.Atan2((double)num359, (double)num358) + 1.57);
						flag23 = ((double)this.rotation >= -1.2 && (double)this.rotation <= 1.2);
						if ((double)this.rotation < -0.8)
						{
							this.rotation = -0.8f;
						}
						else if ((double)this.rotation > 0.8)
						{
							this.rotation = 0.8f;
						}
						if (this.velocity.X != 0f)
						{
							this.velocity.X = this.velocity.X * 0.9f;
							if ((double)this.velocity.X > -0.1 || (double)this.velocity.X < 0.1)
							{
								this.netUpdate = true;
								this.velocity.X = 0f;
							}
						}
					}
					if (this.ai[0] > 0f)
					{
						if (this.ai[0] == 200f)
						{
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
						}
						this.ai[0] -= 1f;
					}
					if (Main.netMode != 1 && flag23 && this.ai[0] == 0f && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
					{
						this.ai[0] = 200f;
						int num361 = 10;
						int num362 = 31;
						int num363 = Projectile.NewProjectile(vector55.X, vector55.Y, num358, num359, num362, num361, 0f, Main.myPlayer);
						Main.projectile[num363].ai[0] = 2f;
						Main.projectile[num363].timeLeft = 300;
						Main.projectile[num363].friendly = false;
						NetMessage.SendData(27, -1, -1, "", num363, 0f, 0f, 0f, 0);
						this.netUpdate = true;
					}
					try
					{
						int num364 = (int)this.position.X / 16;
						int num365 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num366 = (int)(this.position.X + (float)this.width) / 16;
						int num367 = (int)(this.position.Y + (float)this.height) / 16;
						bool flag24 = false;
						if (Main.tile[num364, num367] == null)
						{
							Main.tile[num364, num367] = new Tile();
						}
						if (Main.tile[num365, num367] == null)
						{
							Main.tile[num364, num367] = new Tile();
						}
						if (Main.tile[num366, num367] == null)
						{
							Main.tile[num364, num367] = new Tile();
						}
						if ((Main.tile[num364, num367].active && Main.tileSolid[(int)Main.tile[num364, num367].type]) || (Main.tile[num365, num367].active && Main.tileSolid[(int)Main.tile[num365, num367].type]) || (Main.tile[num366, num367].active && Main.tileSolid[(int)Main.tile[num366, num367].type]))
						{
							flag24 = true;
						}
						if (flag24)
						{
							this.noGravity = true;
							this.noTileCollide = true;
							this.velocity.Y = -0.2f;
						}
						else
						{
							this.noGravity = false;
							this.noTileCollide = false;
							if (Main.rand.Next(2) == 0)
							{
								Vector2 vector56 = new Vector2(this.position.X - 4f, this.position.Y + (float)this.height - 8f);
								int num368 = this.width + 8;
								int num369 = 24;
								int num370 = 32;
								float speedX25 = 0f;
								float speedY29 = this.velocity.Y / 2f;
								int num371 = 0;
								Color newColor = default(Color);
								int num372 = Dust.NewDust(vector56, num368, num369, num370, speedX25, speedY29, num371, newColor, 1f);
								Dust dust43 = Main.dust[num372];
								dust43.velocity.X = dust43.velocity.X * 0.4f;
								Dust dust44 = Main.dust[num372];
								dust44.velocity.Y = dust44.velocity.Y * -1f;
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num372].noGravity = true;
									Main.dust[num372].scale += 0.2f;
								}
							}
						}
						return;
					}
					catch
					{
						return;
					}
				}
				if (this.aiStyle == 20)
				{
					if (this.ai[0] == 0f)
					{
						if (Main.netMode != 1)
						{
							this.TargetClosest(true);
							this.direction *= -1;
							this.directionY *= -1;
							this.position.Y = this.position.Y + (float)(this.height / 2 + 8);
							this.ai[1] = this.position.X + (float)(this.width / 2);
							this.ai[2] = this.position.Y + (float)(this.height / 2);
							if (this.direction == 0)
							{
								this.direction = 1;
							}
							if (this.directionY == 0)
							{
								this.directionY = 1;
							}
							this.ai[3] = 1f + (float)Main.rand.Next(15) * 0.1f;
							this.velocity.Y = (float)(this.directionY * 6) * this.ai[3];
							this.ai[0] += 1f;
							this.netUpdate = true;
						}
						else
						{
							this.ai[1] = this.position.X + (float)(this.width / 2);
							this.ai[2] = this.position.Y + (float)(this.height / 2);
						}
					}
					else
					{
						float num373 = 6f * this.ai[3];
						float num374 = 0.2f * this.ai[3];
						float num375 = num373 / num374 / 2f;
						if (this.ai[0] >= 1f && this.ai[0] < (float)((int)num375))
						{
							this.velocity.Y = (float)this.directionY * num373;
							this.ai[0] += 1f;
						}
						else if (this.ai[0] >= (float)((int)num375))
						{
							this.netUpdate = true;
							this.velocity.Y = 0f;
							this.directionY *= -1;
							this.velocity.X = num373 * (float)this.direction;
							this.ai[0] = -1f;
						}
						else
						{
							if (this.directionY > 0)
							{
								if (this.velocity.Y >= num373)
								{
									this.netUpdate = true;
									this.directionY *= -1;
									this.velocity.Y = num373;
								}
							}
							else if (this.directionY < 0 && this.velocity.Y <= -num373)
							{
								this.directionY *= -1;
								this.velocity.Y = -num373;
							}
							if (this.direction > 0)
							{
								if (this.velocity.X >= num373)
								{
									this.direction *= -1;
									this.velocity.X = num373;
								}
							}
							else if (this.direction < 0 && this.velocity.X <= -num373)
							{
								this.direction *= -1;
								this.velocity.X = -num373;
							}
							this.velocity.X = this.velocity.X + num374 * (float)this.direction;
							this.velocity.Y = this.velocity.Y + num374 * (float)this.directionY;
						}
					}
				}
				else if (this.aiStyle == 21)
				{
					if (this.ai[0] == 0f)
					{
						this.TargetClosest(true);
						this.directionY = 1;
						this.ai[0] = 1f;
					}
					int num376 = 6;
					if (this.ai[1] == 0f)
					{
						this.rotation += (float)(this.direction * this.directionY) * 0.13f;
						if (this.collideY)
						{
							this.ai[0] = 2f;
						}
						if (!this.collideY && this.ai[0] == 2f)
						{
							this.direction = -this.direction;
							this.ai[1] = 1f;
							this.ai[0] = 1f;
						}
						if (this.collideX)
						{
							this.directionY = -this.directionY;
							this.ai[1] = 1f;
						}
					}
					else
					{
						this.rotation -= (float)(this.direction * this.directionY) * 0.13f;
						if (this.collideX)
						{
							this.ai[0] = 2f;
						}
						if (!this.collideX && this.ai[0] == 2f)
						{
							this.directionY = -this.directionY;
							this.ai[1] = 0f;
							this.ai[0] = 1f;
						}
						if (this.collideY)
						{
							this.direction = -this.direction;
							this.ai[1] = 0f;
						}
					}
					this.velocity.X = (float)(num376 * this.direction);
					this.velocity.Y = (float)(num376 * this.directionY);
					float num377 = (float)(270 - (int)Main.mouseTextColor) / 400f;
					Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.9f, 0.3f + num377, 0.2f);
				}
				else if (this.aiStyle == 22)
				{
					bool flag25 = false;
					if (this.justHit)
					{
						this.ai[2] = 0f;
					}
					if (this.ai[2] >= 0f)
					{
						int num378 = 16;
						bool flag26 = false;
						bool flag27 = false;
						if (this.position.X > this.ai[0] - (float)num378 && this.position.X < this.ai[0] + (float)num378)
						{
							flag26 = true;
						}
						else if ((this.velocity.X < 0f && this.direction > 0) || (this.velocity.X > 0f && this.direction < 0))
						{
							flag26 = true;
						}
						num378 += 24;
						if (this.position.Y > this.ai[1] - (float)num378 && this.position.Y < this.ai[1] + (float)num378)
						{
							flag27 = true;
						}
						if (flag26 && flag27)
						{
							this.ai[2] += 1f;
							if (this.ai[2] >= 30f && num378 == 16)
							{
								flag25 = true;
							}
							if (this.ai[2] >= 60f)
							{
								this.ai[2] = -200f;
								this.direction *= -1;
								this.velocity.X = this.velocity.X * -1f;
								this.collideX = false;
							}
						}
						else
						{
							this.ai[0] = this.position.X;
							this.ai[1] = this.position.Y;
							this.ai[2] = 0f;
						}
						this.TargetClosest(true);
					}
					else
					{
						this.ai[2] += 1f;
						if (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) > this.position.X + (float)(this.width / 2))
						{
							this.direction = -1;
						}
						else
						{
							this.direction = 1;
						}
					}
					int num379 = (int)((this.position.X + (float)(this.width / 2)) / 16f) + this.direction * 2;
					int num380 = (int)((this.position.Y + (float)this.height) / 16f);
					bool flag28 = true;
					bool flag29 = false;
					int num381 = 3;
					if (this.type == 122)
					{
						if (this.justHit)
						{
							this.ai[3] = 0f;
							this.localAI[1] = 0f;
						}
						float num382 = 7f;
						Vector2 vector57 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num383 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector57.X;
						float num384 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector57.Y;
						float num385 = (float)Math.Sqrt((double)(num383 * num383 + num384 * num384));
						num385 = num382 / num385;
						num383 *= num385;
						num384 *= num385;
						if (Main.netMode != 1 && this.ai[3] == 32f)
						{
							int num386 = 25;
							int num387 = 84;
							Projectile.NewProjectile(vector57.X, vector57.Y, num383, num384, num387, num386, 0f, Main.myPlayer);
						}
						num381 = 8;
						if (this.ai[3] > 0f)
						{
							this.ai[3] += 1f;
							if (this.ai[3] >= 64f)
							{
								this.ai[3] = 0f;
							}
						}
						if (Main.netMode != 1 && this.ai[3] == 0f)
						{
							this.localAI[1] += 1f;
							if (this.localAI[1] > 120f && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								this.localAI[1] = 0f;
								this.ai[3] = 1f;
								this.netUpdate = true;
							}
						}
					}
					else if (this.type == 75)
					{
						num381 = 4;
						if (Main.rand.Next(6) == 0)
						{
							int num388 = Dust.NewDust(this.position, this.width, this.height, 55, 0f, 0f, 200, this.color, 1f);
							Dust dust45 = Main.dust[num388];
							dust45.velocity *= 0.3f;
						}
						if (Main.rand.Next(40) == 0)
						{
							Main.PlaySound(27, (int)this.position.X, (int)this.position.Y, 1);
						}
					}
					for (int num389 = num380; num389 < num380 + num381; num389++)
					{
						if (Main.tile[num379, num389] == null)
						{
							Main.tile[num379, num389] = new Tile();
						}
						if ((Main.tile[num379, num389].active && Main.tileSolid[(int)Main.tile[num379, num389].type]) || Main.tile[num379, num389].liquid > 0)
						{
							if (num389 <= num380 + 1)
							{
								flag29 = true;
							}
							flag28 = false;
							break;
						}
					}
					if (flag25)
					{
						flag29 = false;
						flag28 = true;
					}
					if (flag28)
					{
						if (this.type == 75)
						{
							this.velocity.Y = this.velocity.Y + 0.2f;
							if (this.velocity.Y > 2f)
							{
								this.velocity.Y = 2f;
							}
						}
						else
						{
							this.velocity.Y = this.velocity.Y + 0.1f;
							if (this.velocity.Y > 3f)
							{
								this.velocity.Y = 3f;
							}
						}
					}
					else
					{
						if (this.type == 75)
						{
							if ((this.directionY < 0 && this.velocity.Y > 0f) || flag29)
							{
								this.velocity.Y = this.velocity.Y - 0.2f;
							}
						}
						else if (this.directionY < 0 && this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - 0.1f;
						}
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
					}
					if (this.type == 75 && this.wet)
					{
						this.velocity.Y = this.velocity.Y - 0.2f;
						if (this.velocity.Y < -2f)
						{
							this.velocity.Y = -2f;
						}
					}
					if (this.collideX)
					{
						this.velocity.X = this.oldVelocity.X * -0.4f;
						if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 1f)
						{
							this.velocity.X = 1f;
						}
						if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -1f)
						{
							this.velocity.X = -1f;
						}
					}
					if (this.collideY)
					{
						this.velocity.Y = this.oldVelocity.Y * -0.25f;
						if (this.velocity.Y > 0f && this.velocity.Y < 1f)
						{
							this.velocity.Y = 1f;
						}
						if (this.velocity.Y < 0f && this.velocity.Y > -1f)
						{
							this.velocity.Y = -1f;
						}
					}
					float num390 = 2f;
					if (this.type == 75)
					{
						num390 = 3f;
					}
					if (this.direction == -1 && this.velocity.X > -num390)
					{
						this.velocity.X = this.velocity.X - 0.1f;
						if (this.velocity.X > num390)
						{
							this.velocity.X = this.velocity.X - 0.1f;
						}
						else if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X + 0.05f;
						}
						if (this.velocity.X < -num390)
						{
							this.velocity.X = -num390;
						}
					}
					else if (this.direction == 1 && this.velocity.X < num390)
					{
						this.velocity.X = this.velocity.X + 0.1f;
						if (this.velocity.X < -num390)
						{
							this.velocity.X = this.velocity.X + 0.1f;
						}
						else if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X - 0.05f;
						}
						if (this.velocity.X > num390)
						{
							this.velocity.X = num390;
						}
					}
					if (this.directionY == -1 && (double)this.velocity.Y > -1.5)
					{
						this.velocity.Y = this.velocity.Y - 0.04f;
						if ((double)this.velocity.Y > 1.5)
						{
							this.velocity.Y = this.velocity.Y - 0.05f;
						}
						else if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.03f;
						}
						if ((double)this.velocity.Y < -1.5)
						{
							this.velocity.Y = -1.5f;
						}
					}
					else if (this.directionY == 1 && (double)this.velocity.Y < 1.5)
					{
						this.velocity.Y = this.velocity.Y + 0.04f;
						if ((double)this.velocity.Y < -1.5)
						{
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
						else if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y - 0.03f;
						}
						if ((double)this.velocity.Y > 1.5)
						{
							this.velocity.Y = 1.5f;
						}
					}
					if (this.type == 122)
					{
						Lighting.addLight((int)this.position.X / 16, (int)this.position.Y / 16, 0.4f, 0f, 0.25f);
					}
				}
				else if (this.aiStyle == 23)
				{
					this.noGravity = true;
					this.noTileCollide = true;
					if (this.type == 83)
					{
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.2f, 0.05f, 0.3f);
					}
					else
					{
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.05f, 0.2f, 0.3f);
					}
					if (this.target < 0 || this.target == 255 || Main.player[this.target].dead)
					{
						this.TargetClosest(true);
					}
					if (this.ai[0] == 0f)
					{
						float num391 = 9f;
						Vector2 vector58 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num392 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector58.X;
						float num393 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector58.Y;
						float num394 = (float)Math.Sqrt((double)(num392 * num392 + num393 * num393));
						num394 = num391 / num394;
						num392 *= num394;
						num393 *= num394;
						this.velocity.X = num392;
						this.velocity.Y = num393;
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 0.785f;
						this.ai[0] = 1f;
						this.ai[1] = 0f;
					}
					else if (this.ai[0] == 1f)
					{
						if (this.justHit)
						{
							this.ai[0] = 2f;
							this.ai[1] = 0f;
						}
						this.velocity *= 0.99f;
						this.ai[1] += 1f;
						if (this.ai[1] >= 100f)
						{
							this.ai[0] = 2f;
							this.ai[1] = 0f;
							this.velocity.X = 0f;
							this.velocity.Y = 0f;
						}
					}
					else
					{
						if (this.justHit)
						{
							this.ai[0] = 2f;
							this.ai[1] = 0f;
						}
						this.velocity *= 0.96f;
						this.ai[1] += 1f;
						float num395 = this.ai[1] / 120f;
						num395 = 0.1f + num395 * 0.4f;
						this.rotation += num395 * (float)this.direction;
						if (this.ai[1] >= 120f)
						{
							this.netUpdate = true;
							this.ai[0] = 0f;
							this.ai[1] = 0f;
						}
					}
				}
				else if (this.aiStyle == 24)
				{
					this.noGravity = true;
					if (this.ai[0] == 0f)
					{
						this.noGravity = false;
						this.TargetClosest(true);
						if (Main.netMode != 1)
						{
							if (this.velocity.X != 0f || this.velocity.Y < 0f || (double)this.velocity.Y > 0.3)
							{
								this.ai[0] = 1f;
								this.netUpdate = true;
								this.direction = -this.direction;
							}
							else
							{
								Rectangle rectangle7 = new Rectangle((int)Main.player[this.target].position.X, (int)Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
								Rectangle rectangle8 = new Rectangle((int)this.position.X - 100, (int)this.position.Y - 100, this.width + 200, this.height + 200);
								if (rectangle8.Intersects(rectangle7) || this.life < this.lifeMax)
								{
									this.ai[0] = 1f;
									this.velocity.Y = this.velocity.Y - 6f;
									this.netUpdate = true;
									this.direction = -this.direction;
								}
							}
						}
					}
					else if (!Main.player[this.target].dead)
					{
						if (this.collideX)
						{
							this.direction *= -1;
							this.velocity.X = this.oldVelocity.X * -0.5f;
							if (this.direction == -1 && this.velocity.X > 0f && this.velocity.X < 2f)
							{
								this.velocity.X = 2f;
							}
							if (this.direction == 1 && this.velocity.X < 0f && this.velocity.X > -2f)
							{
								this.velocity.X = -2f;
							}
						}
						if (this.collideY)
						{
							this.velocity.Y = this.oldVelocity.Y * -0.5f;
							if (this.velocity.Y > 0f && this.velocity.Y < 1f)
							{
								this.velocity.Y = 1f;
							}
							if (this.velocity.Y < 0f && this.velocity.Y > -1f)
							{
								this.velocity.Y = -1f;
							}
						}
						if (this.direction == -1 && this.velocity.X > -3f)
						{
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 3f)
							{
								this.velocity.X = this.velocity.X - 0.1f;
							}
							else if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X - 0.05f;
							}
							if (this.velocity.X < -3f)
							{
								this.velocity.X = -3f;
							}
						}
						else if (this.direction == 1 && this.velocity.X < 3f)
						{
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -3f)
							{
								this.velocity.X = this.velocity.X + 0.1f;
							}
							else if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X + 0.05f;
							}
							if (this.velocity.X > 3f)
							{
								this.velocity.X = 3f;
							}
						}
						int num396 = (int)((this.position.X + (float)(this.width / 2)) / 16f) + this.direction;
						int num397 = (int)((this.position.Y + (float)this.height) / 16f);
						bool flag30 = true;
						int num398 = 15;
						bool flag31 = false;
						for (int num399 = num397; num399 < num397 + num398; num399++)
						{
							if (Main.tile[num396, num399] == null)
							{
								Main.tile[num396, num399] = new Tile();
							}
							if ((Main.tile[num396, num399].active && Main.tileSolid[(int)Main.tile[num396, num399].type]) || Main.tile[num396, num399].liquid > 0)
							{
								if (num399 < num397 + 5)
								{
									flag31 = true;
								}
								flag30 = false;
								break;
							}
						}
						if (flag30)
						{
							this.velocity.Y = this.velocity.Y + 0.1f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y - 0.1f;
						}
						if (flag31)
						{
							this.velocity.Y = this.velocity.Y - 0.2f;
						}
						if (this.velocity.Y > 3f)
						{
							this.velocity.Y = 3f;
						}
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
					}
					if (this.wet)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.95f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -4f)
						{
							this.velocity.Y = -4f;
						}
						this.TargetClosest(true);
					}
				}
				else if (this.aiStyle == 25)
				{
					if (this.ai[3] == 0f)
					{
						this.position.X = this.position.X + 8f;
						if (this.position.Y / 16f > (float)(Main.maxTilesY - 200))
						{
							this.ai[3] = 3f;
						}
						else if ((double)(this.position.Y / 16f) > Main.worldSurface)
						{
							this.ai[3] = 2f;
						}
						else
						{
							this.ai[3] = 1f;
						}
					}
					if (this.ai[0] == 0f)
					{
						this.TargetClosest(true);
						if (Main.netMode != 1)
						{
							if (this.velocity.X != 0f || this.velocity.Y < 0f || (double)this.velocity.Y > 0.3)
							{
								this.ai[0] = 1f;
								this.netUpdate = true;
							}
							else
							{
								Rectangle rectangle9 = new Rectangle((int)Main.player[this.target].position.X, (int)Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
								Rectangle rectangle10 = new Rectangle((int)this.position.X - 100, (int)this.position.Y - 100, this.width + 200, this.height + 200);
								if (rectangle10.Intersects(rectangle9) || this.life < this.lifeMax)
								{
									this.ai[0] = 1f;
									this.netUpdate = true;
								}
							}
						}
					}
					else if (this.velocity.Y == 0f)
					{
						this.ai[2] += 1f;
						int num400 = 20;
						if (this.ai[1] == 0f)
						{
							num400 = 12;
						}
						if (this.ai[2] < (float)num400)
						{
							this.velocity.X = this.velocity.X * 0.9f;
						}
						else
						{
							this.ai[2] = 0f;
							this.TargetClosest(true);
							this.spriteDirection = this.direction;
							this.ai[1] += 1f;
							if (this.ai[1] == 2f)
							{
								this.velocity.X = (float)this.direction * 2.5f;
								this.velocity.Y = -8f;
								this.ai[1] = 0f;
							}
							else
							{
								this.velocity.X = (float)this.direction * 3.5f;
								this.velocity.Y = -4f;
							}
							this.netUpdate = true;
						}
					}
					else if (this.direction == 1 && this.velocity.X < 1f)
					{
						this.velocity.X = this.velocity.X + 0.1f;
					}
					else if (this.direction == -1 && this.velocity.X > -1f)
					{
						this.velocity.X = this.velocity.X - 0.1f;
					}
				}
				else if (this.aiStyle == 26)
				{
					int num401 = 30;
					bool flag32 = false;
					if (this.velocity.Y == 0f && ((this.velocity.X > 0f && this.direction < 0) || (this.velocity.X < 0f && this.direction > 0)))
					{
						flag32 = true;
						this.ai[3] += 1f;
					}
					if (this.position.X == this.oldPosition.X || this.ai[3] >= (float)num401 || flag32)
					{
						this.ai[3] += 1f;
					}
					else if (this.ai[3] > 0f)
					{
						this.ai[3] -= 1f;
					}
					if (this.ai[3] > (float)(num401 * 10))
					{
						this.ai[3] = 0f;
					}
					if (this.justHit)
					{
						this.ai[3] = 0f;
					}
					if (this.ai[3] == (float)num401)
					{
						this.netUpdate = true;
					}
					if (this.ai[3] < (float)num401)
					{
						this.TargetClosest(true);
					}
					else
					{
						if (this.velocity.X == 0f)
						{
							if (this.velocity.Y == 0f)
							{
								this.ai[0] += 1f;
								if (this.ai[0] >= 2f)
								{
									this.direction *= -1;
									this.spriteDirection = this.direction;
									this.ai[0] = 0f;
								}
							}
						}
						else
						{
							this.ai[0] = 0f;
						}
						this.directionY = -1;
						if (this.direction == 0)
						{
							this.direction = 1;
						}
					}
					float num402 = 6f;
					if (this.velocity.Y == 0f || this.wet || (this.velocity.X <= 0f && this.direction < 0) || (this.velocity.X >= 0f && this.direction > 0))
					{
						if (this.velocity.X < -num402 || this.velocity.X > num402)
						{
							if (this.velocity.Y == 0f)
							{
								this.velocity *= 0.8f;
							}
						}
						else if (this.velocity.X < num402 && this.direction == 1)
						{
							this.velocity.X = this.velocity.X + 0.07f;
							if (this.velocity.X > num402)
							{
								this.velocity.X = num402;
							}
						}
						else if (this.velocity.X > -num402 && this.direction == -1)
						{
							this.velocity.X = this.velocity.X - 0.07f;
							if (this.velocity.X < -num402)
							{
								this.velocity.X = -num402;
							}
						}
					}
					if (this.velocity.Y == 0f)
					{
						int num403 = (int)((this.position.X + (float)(this.width / 2) + (float)((this.width / 2 + 2) * this.direction) + this.velocity.X * 5f) / 16f);
						int num404 = (int)((this.position.Y + (float)this.height - 15f) / 16f);
						if (Main.tile[num403, num404] == null)
						{
							Main.tile[num403, num404] = new Tile();
						}
						if (Main.tile[num403, num404 - 1] == null)
						{
							Main.tile[num403, num404 - 1] = new Tile();
						}
						if (Main.tile[num403, num404 - 2] == null)
						{
							Main.tile[num403, num404 - 2] = new Tile();
						}
						if (Main.tile[num403, num404 - 3] == null)
						{
							Main.tile[num403, num404 - 3] = new Tile();
						}
						if (Main.tile[num403, num404 + 1] == null)
						{
							Main.tile[num403, num404 + 1] = new Tile();
						}
						if (Main.tile[num403 + this.direction, num404 - 1] == null)
						{
							Main.tile[num403 + this.direction, num404 - 1] = new Tile();
						}
						if (Main.tile[num403 + this.direction, num404 + 1] == null)
						{
							Main.tile[num403 + this.direction, num404 + 1] = new Tile();
						}
						if ((this.velocity.X < 0f && this.spriteDirection == -1) || (this.velocity.X > 0f && this.spriteDirection == 1))
						{
							if (Main.tile[num403, num404 - 2].active && Main.tileSolid[(int)Main.tile[num403, num404 - 2].type])
							{
								if (Main.tile[num403, num404 - 3].active && Main.tileSolid[(int)Main.tile[num403, num404 - 3].type])
								{
									this.velocity.Y = -8.5f;
									this.netUpdate = true;
								}
								else
								{
									this.velocity.Y = -7.5f;
									this.netUpdate = true;
								}
							}
							else if (Main.tile[num403, num404 - 1].active && Main.tileSolid[(int)Main.tile[num403, num404 - 1].type])
							{
								this.velocity.Y = -7f;
								this.netUpdate = true;
							}
							else if (Main.tile[num403, num404].active && Main.tileSolid[(int)Main.tile[num403, num404].type])
							{
								this.velocity.Y = -6f;
								this.netUpdate = true;
							}
							else if ((this.directionY < 0 || Math.Abs(this.velocity.X) > 3f) && (!Main.tile[num403, num404 + 1].active || !Main.tileSolid[(int)Main.tile[num403, num404 + 1].type]) && (!Main.tile[num403 + this.direction, num404 + 1].active || !Main.tileSolid[(int)Main.tile[num403 + this.direction, num404 + 1].type]))
							{
								this.velocity.Y = -8f;
								this.netUpdate = true;
							}
						}
					}
				}
				else if (this.aiStyle == 27)
				{
					if (this.position.X < 160f || this.position.X > (float)((Main.maxTilesX - 10) * 16))
					{
						this.active = false;
					}
					if (this.localAI[0] == 0f)
					{
						this.localAI[0] = 1f;
						Main.wofB = -1;
						Main.wofT = -1;
					}
					this.ai[1] += 1f;
					if (this.ai[2] == 0f)
					{
						if ((double)this.life < (double)this.lifeMax * 0.5)
						{
							this.ai[1] += 1f;
						}
						if ((double)this.life < (double)this.lifeMax * 0.2)
						{
							this.ai[1] += 1f;
						}
						if (this.ai[1] > 2700f)
						{
							this.ai[2] = 1f;
						}
					}
					if (this.ai[2] > 0f && this.ai[1] > 60f)
					{
						int num405 = 3;
						if ((double)this.life < (double)this.lifeMax * 0.3)
						{
							num405++;
						}
						this.ai[2] += 1f;
						this.ai[1] = 0f;
						if (this.ai[2] > (float)num405)
						{
							this.ai[2] = 0f;
						}
						if (Main.netMode != 1)
						{
							int num406 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)(this.height / 2) + 20f), 117, 1);
							Main.npc[num406].velocity.X = (float)(this.direction * 8);
						}
					}
					this.localAI[3] += 1f;
					if (this.localAI[3] >= (float)(600 + Main.rand.Next(1000)))
					{
						this.localAI[3] = -(float)Main.rand.Next(200);
						Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 10);
					}
					Main.wof = this.whoAmI;
					int num407 = (int)(this.position.X / 16f);
					int num408 = (int)((this.position.X + (float)this.width) / 16f);
					int num409 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
					int num410 = 0;
					int num411 = num409 + 7;
					while (num410 < 15 && num411 > Main.maxTilesY - 200)
					{
						num411++;
						for (int num412 = num407; num412 <= num408; num412++)
						{
							try
							{
								if (WorldGen.SolidTile(num412, num411) || Main.tile[num412, num411].liquid > 0)
								{
									num410++;
								}
							}
							catch
							{
								num410 += 15;
							}
						}
					}
					num411 += 4;
					if (Main.wofB == -1)
					{
						Main.wofB = num411 * 16;
					}
					else if (Main.wofB > num411 * 16)
					{
						Main.wofB--;
						if (Main.wofB < num411 * 16)
						{
							Main.wofB = num411 * 16;
						}
					}
					else if (Main.wofB < num411 * 16)
					{
						Main.wofB++;
						if (Main.wofB > num411 * 16)
						{
							Main.wofB = num411 * 16;
						}
					}
					num410 = 0;
					num411 = num409 - 7;
					while (num410 < 15 && num411 < Main.maxTilesY - 10)
					{
						num411--;
						for (int num413 = num407; num413 <= num408; num413++)
						{
							try
							{
								if (WorldGen.SolidTile(num413, num411) || Main.tile[num413, num411].liquid > 0)
								{
									num410++;
								}
							}
							catch
							{
								num410 += 15;
							}
						}
					}
					num411 -= 4;
					if (Main.wofT == -1)
					{
						Main.wofT = num411 * 16;
					}
					else if (Main.wofT > num411 * 16)
					{
						Main.wofT--;
						if (Main.wofT < num411 * 16)
						{
							Main.wofT = num411 * 16;
						}
					}
					else if (Main.wofT < num411 * 16)
					{
						Main.wofT++;
						if (Main.wofT > num411 * 16)
						{
							Main.wofT = num411 * 16;
						}
					}
					float num414 = (float)((Main.wofB + Main.wofT) / 2 - this.height / 2);
					if (this.position.Y > num414 + 1f)
					{
						this.velocity.Y = -1f;
					}
					else if (this.position.Y < num414 - 1f)
					{
						this.velocity.Y = 1f;
					}
					this.velocity.Y = 0f;
					this.position.Y = num414;
					float num415 = 1.5f;
					if ((double)this.life < (double)this.lifeMax * 0.75)
					{
						num415 += 0.25f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.5)
					{
						num415 += 0.4f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.25)
					{
						num415 += 0.5f;
					}
					if ((double)this.life < (double)this.lifeMax * 0.1)
					{
						num415 += 0.6f;
					}
					if (this.velocity.X == 0f)
					{
						this.TargetClosest(true);
						this.velocity.X = (float)this.direction;
					}
					if (this.velocity.X < 0f)
					{
						this.velocity.X = -num415;
						this.direction = -1;
					}
					else
					{
						this.velocity.X = num415;
						this.direction = 1;
					}
					this.spriteDirection = this.direction;
					Vector2 vector59 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num416 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector59.X;
					float num417 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector59.Y;
					float num418 = (float)Math.Sqrt((double)(num416 * num416 + num417 * num417));
					num416 *= num418;
					num417 *= num418;
					if (this.direction > 0)
					{
						if (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) > this.position.X + (float)(this.width / 2))
						{
							this.rotation = (float)Math.Atan2(-(double)num417, -(double)num416) + 3.14f;
						}
						else
						{
							this.rotation = 0f;
						}
					}
					else if (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) < this.position.X + (float)(this.width / 2))
					{
						this.rotation = (float)Math.Atan2((double)num417, (double)num416) + 3.14f;
					}
					else
					{
						this.rotation = 0f;
					}
					if (this.localAI[0] == 1f && Main.netMode != 1)
					{
						this.localAI[0] = 2f;
						num414 = (float)((Main.wofB + Main.wofT) / 2);
						num414 = (num414 + (float)Main.wofT) / 2f;
						int num419 = NPC.NewNPC((int)this.position.X, (int)num414, 114, this.whoAmI);
						Main.npc[num419].ai[0] = 1f;
						num414 = (float)((Main.wofB + Main.wofT) / 2);
						num414 = (num414 + (float)Main.wofB) / 2f;
						num419 = NPC.NewNPC((int)this.position.X, (int)num414, 114, this.whoAmI);
						Main.npc[num419].ai[0] = -1f;
						num414 = (float)((Main.wofB + Main.wofT) / 2);
						num414 = (num414 + (float)Main.wofB) / 2f;
						for (int num420 = 0; num420 < 11; num420++)
						{
							num419 = NPC.NewNPC((int)this.position.X, (int)num414, 115, this.whoAmI);
							Main.npc[num419].ai[0] = (float)num420 * 0.1f - 0.05f;
						}
					}
				}
				else if (this.aiStyle == 28)
				{
					if (Main.wof < 0)
					{
						this.active = false;
					}
					else
					{
						this.realLife = Main.wof;
						this.TargetClosest(true);
						this.position.X = Main.npc[Main.wof].position.X;
						this.direction = Main.npc[Main.wof].direction;
						this.spriteDirection = this.direction;
						float num421 = (float)((Main.wofB + Main.wofT) / 2);
						if (this.ai[0] > 0f)
						{
							num421 = (num421 + (float)Main.wofT) / 2f;
						}
						else
						{
							num421 = (num421 + (float)Main.wofB) / 2f;
						}
						num421 -= (float)(this.height / 2);
						if (this.position.Y > num421 + 1f)
						{
							this.velocity.Y = -1f;
						}
						else if (this.position.Y < num421 - 1f)
						{
							this.velocity.Y = 1f;
						}
						else
						{
							this.velocity.Y = 0f;
							this.position.Y = num421;
						}
						if (this.velocity.Y > 5f)
						{
							this.velocity.Y = 5f;
						}
						if (this.velocity.Y < -5f)
						{
							this.velocity.Y = -5f;
						}
						Vector2 vector60 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num422 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector60.X;
						float num423 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector60.Y;
						float num424 = (float)Math.Sqrt((double)(num422 * num422 + num423 * num423));
						num422 *= num424;
						num423 *= num424;
						bool flag33 = true;
						if (this.direction > 0)
						{
							if (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) > this.position.X + (float)(this.width / 2))
							{
								this.rotation = (float)Math.Atan2(-(double)num423, -(double)num422) + 3.14f;
							}
							else
							{
								this.rotation = 0f;
								flag33 = false;
							}
						}
						else if (Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) < this.position.X + (float)(this.width / 2))
						{
							this.rotation = (float)Math.Atan2((double)num423, (double)num422) + 3.14f;
						}
						else
						{
							this.rotation = 0f;
							flag33 = false;
						}
						if (Main.netMode != 1)
						{
							int num425 = 4;
							this.localAI[1] += 1f;
							if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.75)
							{
								this.localAI[1] += 1f;
								num425++;
							}
							if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.5)
							{
								this.localAI[1] += 1f;
								num425++;
							}
							if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.25)
							{
								this.localAI[1] += 1f;
								num425 += 2;
							}
							if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.1)
							{
								this.localAI[1] += 2f;
								num425 += 3;
							}
							if (this.localAI[2] == 0f)
							{
								if (this.localAI[1] > 600f)
								{
									this.localAI[2] = 1f;
									this.localAI[1] = 0f;
								}
							}
							else if (this.localAI[1] > 45f && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								this.localAI[1] = 0f;
								this.localAI[2] += 1f;
								if (this.localAI[2] >= (float)num425)
								{
									this.localAI[2] = 0f;
								}
								if (flag33)
								{
									float num426 = 9f;
									int num427 = 11;
									int num428 = 83;
									if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.5)
									{
										num427++;
										num426 += 1f;
									}
									if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.25)
									{
										num427++;
										num426 += 1f;
									}
									if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.1)
									{
										num427 += 2;
										num426 += 2f;
									}
									vector60 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
									num422 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector60.X;
									num423 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector60.Y;
									num424 = (float)Math.Sqrt((double)(num422 * num422 + num423 * num423));
									num424 = num426 / num424;
									num422 *= num424;
									num423 *= num424;
									vector60.X += num422;
									vector60.Y += num423;
									Projectile.NewProjectile(vector60.X, vector60.Y, num422, num423, num428, num427, 0f, Main.myPlayer);
								}
							}
						}
					}
				}
				else if (this.aiStyle == 29)
				{
					if (this.justHit)
					{
						this.ai[1] = 10f;
					}
					if (Main.wof < 0)
					{
						this.active = false;
					}
					else
					{
						this.TargetClosest(true);
						float num429 = 0.1f;
						float num430 = 300f;
						if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.25)
						{
							this.damage = 75;
							this.defense = 40;
							num430 = 900f;
						}
						else if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.5)
						{
							this.damage = 60;
							this.defense = 30;
							num430 = 700f;
						}
						else if ((double)Main.npc[Main.wof].life < (double)Main.npc[Main.wof].lifeMax * 0.75)
						{
							this.damage = 45;
							this.defense = 20;
							num430 = 500f;
						}
						float num431 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
						float num432 = Main.npc[Main.wof].position.Y;
						float num433 = (float)(Main.wofB - Main.wofT);
						num432 = (float)Main.wofT + num433 * this.ai[0];
						this.ai[2] += 1f;
						if (this.ai[2] > 100f)
						{
							num430 = (float)((int)(num430 * 1.3f));
							if (this.ai[2] > 200f)
							{
								this.ai[2] = 0f;
							}
						}
						Vector2 vector61 = new Vector2(num431, num432);
						float num434 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - (float)(this.width / 2) - vector61.X;
						float num435 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - (float)(this.height / 2) - vector61.Y;
						float num436 = (float)Math.Sqrt((double)(num434 * num434 + num435 * num435));
						if (this.ai[1] == 0f)
						{
							if (num436 > num430)
							{
								num436 = num430 / num436;
								num434 *= num436;
								num435 *= num436;
							}
							if (this.position.X < num431 + num434)
							{
								this.velocity.X = this.velocity.X + num429;
								if (this.velocity.X < 0f && num434 > 0f)
								{
									this.velocity.X = this.velocity.X + num429 * 2.5f;
								}
							}
							else if (this.position.X > num431 + num434)
							{
								this.velocity.X = this.velocity.X - num429;
								if (this.velocity.X > 0f && num434 < 0f)
								{
									this.velocity.X = this.velocity.X - num429 * 2.5f;
								}
							}
							if (this.position.Y < num432 + num435)
							{
								this.velocity.Y = this.velocity.Y + num429;
								if (this.velocity.Y < 0f && num435 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num429 * 2.5f;
								}
							}
							else if (this.position.Y > num432 + num435)
							{
								this.velocity.Y = this.velocity.Y - num429;
								if (this.velocity.Y > 0f && num435 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num429 * 2.5f;
								}
							}
							if (this.velocity.X > 4f)
							{
								this.velocity.X = 4f;
							}
							if (this.velocity.X < -4f)
							{
								this.velocity.X = -4f;
							}
							if (this.velocity.Y > 4f)
							{
								this.velocity.Y = 4f;
							}
							if (this.velocity.Y < -4f)
							{
								this.velocity.Y = -4f;
							}
						}
						else if (this.ai[1] > 0f)
						{
							this.ai[1] -= 1f;
						}
						else
						{
							this.ai[1] = 0f;
						}
						if (num434 > 0f)
						{
							this.spriteDirection = 1;
							this.rotation = (float)Math.Atan2((double)num435, (double)num434);
						}
						if (num434 < 0f)
						{
							this.spriteDirection = -1;
							this.rotation = (float)Math.Atan2((double)num435, (double)num434) + 3.14f;
						}
						Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
					}
				}
				else if (this.aiStyle == 30)
				{
					if (this.target < 0 || this.target == 255 || Main.player[this.target].dead || !Main.player[this.target].active)
					{
						this.TargetClosest(true);
					}
					bool dead2 = Main.player[this.target].dead;
					float num437 = this.position.X + (float)(this.width / 2) - Main.player[this.target].position.X - (float)(Main.player[this.target].width / 2);
					float num438 = this.position.Y + (float)this.height - 59f - Main.player[this.target].position.Y - (float)(Main.player[this.target].height / 2);
					float num439 = (float)Math.Atan2((double)num438, (double)num437) + 1.57f;
					if (num439 < 0f)
					{
						num439 += 6.283f;
					}
					else if ((double)num439 > 6.283)
					{
						num439 -= 6.283f;
					}
					float num440 = 0.1f;
					if (this.rotation < num439)
					{
						if ((double)(num439 - this.rotation) > 3.1415)
						{
							this.rotation -= num440;
						}
						else
						{
							this.rotation += num440;
						}
					}
					else if (this.rotation > num439)
					{
						if ((double)(this.rotation - num439) > 3.1415)
						{
							this.rotation += num440;
						}
						else
						{
							this.rotation -= num440;
						}
					}
					if (this.rotation > num439 - num440 && this.rotation < num439 + num440)
					{
						this.rotation = num439;
					}
					if (this.rotation < 0f)
					{
						this.rotation += 6.283f;
					}
					else if ((double)this.rotation > 6.283)
					{
						this.rotation -= 6.283f;
					}
					if (this.rotation > num439 - num440 && this.rotation < num439 + num440)
					{
						this.rotation = num439;
					}
					if (Main.rand.Next(5) == 0)
					{
						Vector2 vector62 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
						int num441 = this.width;
						int num442 = (int)((float)this.height * 0.5f);
						int num443 = 5;
						float x7 = this.velocity.X;
						float speedY30 = 2f;
						int num444 = 0;
						Color newColor = default(Color);
						int num445 = Dust.NewDust(vector62, num441, num442, num443, x7, speedY30, num444, newColor, 1f);
						Dust dust46 = Main.dust[num445];
						dust46.velocity.X = dust46.velocity.X * 0.5f;
						Dust dust47 = Main.dust[num445];
						dust47.velocity.Y = dust47.velocity.Y * 0.1f;
					}
					if (Main.dayTime || dead2)
					{
						this.velocity.Y = this.velocity.Y - 0.04f;
						if (this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
					}
					else if (this.ai[0] == 0f)
					{
						if (this.ai[1] == 0f)
						{
							float num446 = 7f;
							float num447 = 0.1f;
							int num448 = 1;
							if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
							{
								num448 = -1;
							}
							Vector2 vector63 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num449 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num448 * 300) - vector63.X;
							float num450 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 300f - vector63.Y;
							float num451 = (float)Math.Sqrt((double)(num449 * num449 + num450 * num450));
							float num452 = num451;
							num451 = num446 / num451;
							num449 *= num451;
							num450 *= num451;
							if (this.velocity.X < num449)
							{
								this.velocity.X = this.velocity.X + num447;
								if (this.velocity.X < 0f && num449 > 0f)
								{
									this.velocity.X = this.velocity.X + num447;
								}
							}
							else if (this.velocity.X > num449)
							{
								this.velocity.X = this.velocity.X - num447;
								if (this.velocity.X > 0f && num449 < 0f)
								{
									this.velocity.X = this.velocity.X - num447;
								}
							}
							if (this.velocity.Y < num450)
							{
								this.velocity.Y = this.velocity.Y + num447;
								if (this.velocity.Y < 0f && num450 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num447;
								}
							}
							else if (this.velocity.Y > num450)
							{
								this.velocity.Y = this.velocity.Y - num447;
								if (this.velocity.Y > 0f && num450 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num447;
								}
							}
							this.ai[2] += 1f;
							if (this.ai[2] >= 600f)
							{
								this.ai[1] = 1f;
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.target = 255;
								this.netUpdate = true;
							}
							else if (this.position.Y + (float)this.height < Main.player[this.target].position.Y && num452 < 400f)
							{
								if (!Main.player[this.target].dead)
								{
									this.ai[3] += 1f;
								}
								if (this.ai[3] >= 60f)
								{
									this.ai[3] = 0f;
									vector63 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
									num449 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector63.X;
									num450 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector63.Y;
									if (Main.netMode != 1)
									{
										float num453 = 9f;
										int num454 = 20;
										int num455 = 83;
										num451 = (float)Math.Sqrt((double)(num449 * num449 + num450 * num450));
										num451 = num453 / num451;
										num449 *= num451;
										num450 *= num451;
										num449 += (float)Main.rand.Next(-40, 41) * 0.08f;
										num450 += (float)Main.rand.Next(-40, 41) * 0.08f;
										vector63.X += num449 * 15f;
										vector63.Y += num450 * 15f;
										Projectile.NewProjectile(vector63.X, vector63.Y, num449, num450, num455, num454, 0f, Main.myPlayer);
									}
								}
							}
						}
						else if (this.ai[1] == 1f)
						{
							this.rotation = num439;
							float num456 = 12f;
							Vector2 vector64 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num457 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector64.X;
							float num458 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector64.Y;
							float num459 = (float)Math.Sqrt((double)(num457 * num457 + num458 * num458));
							num459 = num456 / num459;
							this.velocity.X = num457 * num459;
							this.velocity.Y = num458 * num459;
							this.ai[1] = 2f;
						}
						else if (this.ai[1] == 2f)
						{
							this.ai[2] += 1f;
							if (this.ai[2] >= 25f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
								this.velocity.Y = this.velocity.Y * 0.96f;
								if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
								{
									this.velocity.X = 0f;
								}
								if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
								{
									this.velocity.Y = 0f;
								}
							}
							else
							{
								this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
							}
							if (this.ai[2] >= 70f)
							{
								this.ai[3] += 1f;
								this.ai[2] = 0f;
								this.target = 255;
								this.rotation = num439;
								if (this.ai[3] >= 4f)
								{
									this.ai[1] = 0f;
									this.ai[3] = 0f;
								}
								else
								{
									this.ai[1] = 1f;
								}
							}
						}
						if ((double)this.life < (double)this.lifeMax * 0.5)
						{
							this.ai[0] = 1f;
							this.ai[1] = 0f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
					}
					else if (this.ai[0] == 1f || this.ai[0] == 2f)
					{
						if (this.ai[0] == 1f)
						{
							this.ai[2] += 0.005f;
							if ((double)this.ai[2] > 0.5)
							{
								this.ai[2] = 0.5f;
							}
						}
						else
						{
							this.ai[2] -= 0.005f;
							if (this.ai[2] < 0f)
							{
								this.ai[2] = 0f;
							}
						}
						this.rotation += this.ai[2];
						this.ai[1] += 1f;
						if (this.ai[1] == 100f)
						{
							this.ai[0] += 1f;
							this.ai[1] = 0f;
							if (this.ai[0] == 3f)
							{
								this.ai[2] = 0f;
							}
							else
							{
								Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1);
								for (int num460 = 0; num460 < 2; num460++)
								{
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
								}
								for (int num461 = 0; num461 < 20; num461++)
								{
									Vector2 vector65 = this.position;
									int num462 = this.width;
									int num463 = this.height;
									int num464 = 5;
									float speedX26 = (float)Main.rand.Next(-30, 31) * 0.2f;
									float speedY31 = (float)Main.rand.Next(-30, 31) * 0.2f;
									int num465 = 0;
									Dust.NewDust(vector65, num462, num463, num464, speedX26, speedY31, num465, default(Color), 1f);
								}
								Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							}
						}
						Vector2 vector66 = this.position;
						int num466 = this.width;
						int num467 = this.height;
						int num468 = 5;
						float speedX27 = (float)Main.rand.Next(-30, 31) * 0.2f;
						float speedY32 = (float)Main.rand.Next(-30, 31) * 0.2f;
						int num469 = 0;
						Dust.NewDust(vector66, num466, num467, num468, speedX27, speedY32, num469, default(Color), 1f);
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
						{
							this.velocity.X = 0f;
						}
						if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
						{
							this.velocity.Y = 0f;
						}
					}
					else
					{
						this.damage = (int)((double)this.defDamage * 1.5);
						this.defense = this.defDefense + 15;
						this.soundHit = 4;
						if (this.ai[1] == 0f)
						{
							float num470 = 8f;
							float num471 = 0.15f;
							Vector2 vector67 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num472 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector67.X;
							float num473 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 300f - vector67.Y;
							float num474 = (float)Math.Sqrt((double)(num472 * num472 + num473 * num473));
							num474 = num470 / num474;
							num472 *= num474;
							num473 *= num474;
							if (this.velocity.X < num472)
							{
								this.velocity.X = this.velocity.X + num471;
								if (this.velocity.X < 0f && num472 > 0f)
								{
									this.velocity.X = this.velocity.X + num471;
								}
							}
							else if (this.velocity.X > num472)
							{
								this.velocity.X = this.velocity.X - num471;
								if (this.velocity.X > 0f && num472 < 0f)
								{
									this.velocity.X = this.velocity.X - num471;
								}
							}
							if (this.velocity.Y < num473)
							{
								this.velocity.Y = this.velocity.Y + num471;
								if (this.velocity.Y < 0f && num473 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num471;
								}
							}
							else if (this.velocity.Y > num473)
							{
								this.velocity.Y = this.velocity.Y - num471;
								if (this.velocity.Y > 0f && num473 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num471;
								}
							}
							this.ai[2] += 1f;
							if (this.ai[2] >= 300f)
							{
								this.ai[1] = 1f;
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.TargetClosest(true);
								this.netUpdate = true;
							}
							vector67 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num472 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector67.X;
							num473 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector67.Y;
							this.rotation = (float)Math.Atan2((double)num473, (double)num472) - 1.57f;
							if (Main.netMode != 1)
							{
								this.localAI[1] += 1f;
								if ((double)this.life < (double)this.lifeMax * 0.75)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.5)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.25)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.1)
								{
									this.localAI[1] += 2f;
								}
								if (this.localAI[1] > 140f && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
								{
									this.localAI[1] = 0f;
									float num475 = 9f;
									int num476 = 25;
									int num477 = 100;
									num474 = (float)Math.Sqrt((double)(num472 * num472 + num473 * num473));
									num474 = num475 / num474;
									num472 *= num474;
									num473 *= num474;
									vector67.X += num472 * 15f;
									vector67.Y += num473 * 15f;
									Projectile.NewProjectile(vector67.X, vector67.Y, num472, num473, num477, num476, 0f, Main.myPlayer);
								}
							}
						}
						else
						{
							int num478 = 1;
							if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
							{
								num478 = -1;
							}
							float num479 = 8f;
							float num480 = 0.2f;
							Vector2 vector68 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num481 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num478 * 340) - vector68.X;
							float num482 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector68.Y;
							float num483 = (float)Math.Sqrt((double)(num481 * num481 + num482 * num482));
							num483 = num479 / num483;
							num481 *= num483;
							num482 *= num483;
							if (this.velocity.X < num481)
							{
								this.velocity.X = this.velocity.X + num480;
								if (this.velocity.X < 0f && num481 > 0f)
								{
									this.velocity.X = this.velocity.X + num480;
								}
							}
							else if (this.velocity.X > num481)
							{
								this.velocity.X = this.velocity.X - num480;
								if (this.velocity.X > 0f && num481 < 0f)
								{
									this.velocity.X = this.velocity.X - num480;
								}
							}
							if (this.velocity.Y < num482)
							{
								this.velocity.Y = this.velocity.Y + num480;
								if (this.velocity.Y < 0f && num482 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num480;
								}
							}
							else if (this.velocity.Y > num482)
							{
								this.velocity.Y = this.velocity.Y - num480;
								if (this.velocity.Y > 0f && num482 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num480;
								}
							}
							vector68 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num481 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector68.X;
							num482 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector68.Y;
							this.rotation = (float)Math.Atan2((double)num482, (double)num481) - 1.57f;
							if (Main.netMode != 1)
							{
								this.localAI[1] += 1f;
								if ((double)this.life < (double)this.lifeMax * 0.75)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.5)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.25)
								{
									this.localAI[1] += 1f;
								}
								if ((double)this.life < (double)this.lifeMax * 0.1)
								{
									this.localAI[1] += 2f;
								}
								if (this.localAI[1] > 45f && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
								{
									this.localAI[1] = 0f;
									float num484 = 9f;
									int num485 = 20;
									int num486 = 100;
									num483 = (float)Math.Sqrt((double)(num481 * num481 + num482 * num482));
									num483 = num484 / num483;
									num481 *= num483;
									num482 *= num483;
									vector68.X += num481 * 15f;
									vector68.Y += num482 * 15f;
									Projectile.NewProjectile(vector68.X, vector68.Y, num481, num482, num486, num485, 0f, Main.myPlayer);
								}
							}
							this.ai[2] += 1f;
							if (this.ai[2] >= 200f)
							{
								this.ai[1] = 0f;
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.TargetClosest(true);
								this.netUpdate = true;
							}
						}
					}
				}
				else if (this.aiStyle == 31)
				{
					if (this.target < 0 || this.target == 255 || Main.player[this.target].dead || !Main.player[this.target].active)
					{
						this.TargetClosest(true);
					}
					bool dead3 = Main.player[this.target].dead;
					float num487 = this.position.X + (float)(this.width / 2) - Main.player[this.target].position.X - (float)(Main.player[this.target].width / 2);
					float num488 = this.position.Y + (float)this.height - 59f - Main.player[this.target].position.Y - (float)(Main.player[this.target].height / 2);
					float num489 = (float)Math.Atan2((double)num488, (double)num487) + 1.57f;
					if (num489 < 0f)
					{
						num489 += 6.283f;
					}
					else if ((double)num489 > 6.283)
					{
						num489 -= 6.283f;
					}
					float num490 = 0.15f;
					if (this.rotation < num489)
					{
						if ((double)(num489 - this.rotation) > 3.1415)
						{
							this.rotation -= num490;
						}
						else
						{
							this.rotation += num490;
						}
					}
					else if (this.rotation > num489)
					{
						if ((double)(this.rotation - num489) > 3.1415)
						{
							this.rotation += num490;
						}
						else
						{
							this.rotation -= num490;
						}
					}
					if (this.rotation > num489 - num490 && this.rotation < num489 + num490)
					{
						this.rotation = num489;
					}
					if (this.rotation < 0f)
					{
						this.rotation += 6.283f;
					}
					else if ((double)this.rotation > 6.283)
					{
						this.rotation -= 6.283f;
					}
					if (this.rotation > num489 - num490 && this.rotation < num489 + num490)
					{
						this.rotation = num489;
					}
					if (Main.rand.Next(5) == 0)
					{
						Vector2 vector69 = new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f);
						int num491 = this.width;
						int num492 = (int)((float)this.height * 0.5f);
						int num493 = 5;
						float x8 = this.velocity.X;
						float speedY33 = 2f;
						int num494 = 0;
						Color newColor = default(Color);
						int num495 = Dust.NewDust(vector69, num491, num492, num493, x8, speedY33, num494, newColor, 1f);
						Dust dust48 = Main.dust[num495];
						dust48.velocity.X = dust48.velocity.X * 0.5f;
						Dust dust49 = Main.dust[num495];
						dust49.velocity.Y = dust49.velocity.Y * 0.1f;
					}
					if (Main.dayTime || dead3)
					{
						this.velocity.Y = this.velocity.Y - 0.04f;
						if (this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
					}
					else if (this.ai[0] == 0f)
					{
						if (this.ai[1] == 0f)
						{
							this.TargetClosest(true);
							float num496 = 12f;
							float num497 = 0.4f;
							int num498 = 1;
							if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
							{
								num498 = -1;
							}
							Vector2 vector70 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num499 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num498 * 400) - vector70.X;
							float num500 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector70.Y;
							float num501 = (float)Math.Sqrt((double)(num499 * num499 + num500 * num500));
							num501 = num496 / num501;
							num499 *= num501;
							num500 *= num501;
							if (this.velocity.X < num499)
							{
								this.velocity.X = this.velocity.X + num497;
								if (this.velocity.X < 0f && num499 > 0f)
								{
									this.velocity.X = this.velocity.X + num497;
								}
							}
							else if (this.velocity.X > num499)
							{
								this.velocity.X = this.velocity.X - num497;
								if (this.velocity.X > 0f && num499 < 0f)
								{
									this.velocity.X = this.velocity.X - num497;
								}
							}
							if (this.velocity.Y < num500)
							{
								this.velocity.Y = this.velocity.Y + num497;
								if (this.velocity.Y < 0f && num500 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num497;
								}
							}
							else if (this.velocity.Y > num500)
							{
								this.velocity.Y = this.velocity.Y - num497;
								if (this.velocity.Y > 0f && num500 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num497;
								}
							}
							this.ai[2] += 1f;
							if (this.ai[2] >= 600f)
							{
								this.ai[1] = 1f;
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.target = 255;
								this.netUpdate = true;
							}
							else
							{
								if (!Main.player[this.target].dead)
								{
									this.ai[3] += 1f;
								}
								if (this.ai[3] >= 60f)
								{
									this.ai[3] = 0f;
									vector70 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
									num499 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector70.X;
									num500 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector70.Y;
									if (Main.netMode != 1)
									{
										float num502 = 12f;
										int num503 = 25;
										int num504 = 96;
										num501 = (float)Math.Sqrt((double)(num499 * num499 + num500 * num500));
										num501 = num502 / num501;
										num499 *= num501;
										num500 *= num501;
										num499 += (float)Main.rand.Next(-40, 41) * 0.05f;
										num500 += (float)Main.rand.Next(-40, 41) * 0.05f;
										vector70.X += num499 * 4f;
										vector70.Y += num500 * 4f;
										Projectile.NewProjectile(vector70.X, vector70.Y, num499, num500, num504, num503, 0f, Main.myPlayer);
									}
								}
							}
						}
						else if (this.ai[1] == 1f)
						{
							this.rotation = num489;
							float num505 = 13f;
							Vector2 vector71 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num506 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector71.X;
							float num507 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector71.Y;
							float num508 = (float)Math.Sqrt((double)(num506 * num506 + num507 * num507));
							num508 = num505 / num508;
							this.velocity.X = num506 * num508;
							this.velocity.Y = num507 * num508;
							this.ai[1] = 2f;
						}
						else if (this.ai[1] == 2f)
						{
							this.ai[2] += 1f;
							if (this.ai[2] >= 8f)
							{
								this.velocity.X = this.velocity.X * 0.9f;
								this.velocity.Y = this.velocity.Y * 0.9f;
								if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
								{
									this.velocity.X = 0f;
								}
								if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
								{
									this.velocity.Y = 0f;
								}
							}
							else
							{
								this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
							}
							if (this.ai[2] >= 42f)
							{
								this.ai[3] += 1f;
								this.ai[2] = 0f;
								this.target = 255;
								this.rotation = num489;
								if (this.ai[3] >= 10f)
								{
									this.ai[1] = 0f;
									this.ai[3] = 0f;
								}
								else
								{
									this.ai[1] = 1f;
								}
							}
						}
						if ((double)this.life < (double)this.lifeMax * 0.5)
						{
							this.ai[0] = 1f;
							this.ai[1] = 0f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
					}
					else if (this.ai[0] == 1f || this.ai[0] == 2f)
					{
						if (this.ai[0] == 1f)
						{
							this.ai[2] += 0.005f;
							if ((double)this.ai[2] > 0.5)
							{
								this.ai[2] = 0.5f;
							}
						}
						else
						{
							this.ai[2] -= 0.005f;
							if (this.ai[2] < 0f)
							{
								this.ai[2] = 0f;
							}
						}
						this.rotation += this.ai[2];
						this.ai[1] += 1f;
						if (this.ai[1] == 100f)
						{
							this.ai[0] += 1f;
							this.ai[1] = 0f;
							if (this.ai[0] == 3f)
							{
								this.ai[2] = 0f;
							}
							else
							{
								Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1);
								for (int num509 = 0; num509 < 2; num509++)
								{
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
								}
								for (int num510 = 0; num510 < 20; num510++)
								{
									Vector2 vector72 = this.position;
									int num511 = this.width;
									int num512 = this.height;
									int num513 = 5;
									float speedX28 = (float)Main.rand.Next(-30, 31) * 0.2f;
									float speedY34 = (float)Main.rand.Next(-30, 31) * 0.2f;
									int num514 = 0;
									Dust.NewDust(vector72, num511, num512, num513, speedX28, speedY34, num514, default(Color), 1f);
								}
								Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							}
						}
						Vector2 vector73 = this.position;
						int num515 = this.width;
						int num516 = this.height;
						int num517 = 5;
						float speedX29 = (float)Main.rand.Next(-30, 31) * 0.2f;
						float speedY35 = (float)Main.rand.Next(-30, 31) * 0.2f;
						int num518 = 0;
						Dust.NewDust(vector73, num515, num516, num517, speedX29, speedY35, num518, default(Color), 1f);
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
						{
							this.velocity.X = 0f;
						}
						if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
						{
							this.velocity.Y = 0f;
						}
					}
					else
					{
						this.soundHit = 4;
						this.damage = (int)((double)this.defDamage * 1.5);
						this.defense = this.defDefense + 25;
						if (this.ai[1] == 0f)
						{
							float num519 = 4f;
							float num520 = 0.1f;
							int num521 = 1;
							if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
							{
								num521 = -1;
							}
							Vector2 vector74 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num522 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num521 * 180) - vector74.X;
							float num523 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector74.Y;
							float num524 = (float)Math.Sqrt((double)(num522 * num522 + num523 * num523));
							num524 = num519 / num524;
							num522 *= num524;
							num523 *= num524;
							if (this.velocity.X < num522)
							{
								this.velocity.X = this.velocity.X + num520;
								if (this.velocity.X < 0f && num522 > 0f)
								{
									this.velocity.X = this.velocity.X + num520;
								}
							}
							else if (this.velocity.X > num522)
							{
								this.velocity.X = this.velocity.X - num520;
								if (this.velocity.X > 0f && num522 < 0f)
								{
									this.velocity.X = this.velocity.X - num520;
								}
							}
							if (this.velocity.Y < num523)
							{
								this.velocity.Y = this.velocity.Y + num520;
								if (this.velocity.Y < 0f && num523 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num520;
								}
							}
							else if (this.velocity.Y > num523)
							{
								this.velocity.Y = this.velocity.Y - num520;
								if (this.velocity.Y > 0f && num523 < 0f)
								{
									this.velocity.Y = this.velocity.Y - num520;
								}
							}
							this.ai[2] += 1f;
							if (this.ai[2] >= 400f)
							{
								this.ai[1] = 1f;
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.target = 255;
								this.netUpdate = true;
							}
							if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
							{
								this.localAI[2] += 1f;
								if (this.localAI[2] > 22f)
								{
									this.localAI[2] = 0f;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 34);
								}
								if (Main.netMode != 1)
								{
									this.localAI[1] += 1f;
									if ((double)this.life < (double)this.lifeMax * 0.75)
									{
										this.localAI[1] += 1f;
									}
									if ((double)this.life < (double)this.lifeMax * 0.5)
									{
										this.localAI[1] += 1f;
									}
									if ((double)this.life < (double)this.lifeMax * 0.25)
									{
										this.localAI[1] += 1f;
									}
									if ((double)this.life < (double)this.lifeMax * 0.1)
									{
										this.localAI[1] += 2f;
									}
									if (this.localAI[1] > 8f)
									{
										this.localAI[1] = 0f;
										float num525 = 6f;
										int num526 = 30;
										int num527 = 101;
										vector74 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										num522 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector74.X;
										num523 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector74.Y;
										num524 = (float)Math.Sqrt((double)(num522 * num522 + num523 * num523));
										num524 = num525 / num524;
										num522 *= num524;
										num523 *= num524;
										num523 += (float)Main.rand.Next(-40, 41) * 0.01f;
										num522 += (float)Main.rand.Next(-40, 41) * 0.01f;
										num523 += this.velocity.Y * 0.5f;
										num522 += this.velocity.X * 0.5f;
										vector74.X -= num522 * 1f;
										vector74.Y -= num523 * 1f;
										Projectile.NewProjectile(vector74.X, vector74.Y, num522, num523, num527, num526, 0f, Main.myPlayer);
									}
								}
							}
						}
						else if (this.ai[1] == 1f)
						{
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							this.rotation = num489;
							float num528 = 14f;
							Vector2 vector75 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num529 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector75.X;
							float num530 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector75.Y;
							float num531 = (float)Math.Sqrt((double)(num529 * num529 + num530 * num530));
							num531 = num528 / num531;
							this.velocity.X = num529 * num531;
							this.velocity.Y = num530 * num531;
							this.ai[1] = 2f;
						}
						else if (this.ai[1] == 2f)
						{
							this.ai[2] += 1f;
							if (this.ai[2] >= 50f)
							{
								this.velocity.X = this.velocity.X * 0.93f;
								this.velocity.Y = this.velocity.Y * 0.93f;
								if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
								{
									this.velocity.X = 0f;
								}
								if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
								{
									this.velocity.Y = 0f;
								}
							}
							else
							{
								this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
							}
							if (this.ai[2] >= 80f)
							{
								this.ai[3] += 1f;
								this.ai[2] = 0f;
								this.target = 255;
								this.rotation = num489;
								if (this.ai[3] >= 6f)
								{
									this.ai[1] = 0f;
									this.ai[3] = 0f;
								}
								else
								{
									this.ai[1] = 1f;
								}
							}
						}
					}
				}
				else if (this.aiStyle == 32)
				{
					this.damage = this.defDamage;
					this.defense = this.defDefense;
					if (this.ai[0] == 0f && Main.netMode != 1)
					{
						this.TargetClosest(true);
						this.ai[0] = 1f;
						if (this.type != 68)
						{
							int num532 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 128, this.whoAmI);
							Main.npc[num532].ai[0] = -1f;
							Main.npc[num532].ai[1] = (float)this.whoAmI;
							Main.npc[num532].target = this.target;
							Main.npc[num532].netUpdate = true;
							num532 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 129, this.whoAmI);
							Main.npc[num532].ai[0] = 1f;
							Main.npc[num532].ai[1] = (float)this.whoAmI;
							Main.npc[num532].target = this.target;
							Main.npc[num532].netUpdate = true;
							num532 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 130, this.whoAmI);
							Main.npc[num532].ai[0] = -1f;
							Main.npc[num532].ai[1] = (float)this.whoAmI;
							Main.npc[num532].target = this.target;
							Main.npc[num532].ai[3] = 150f;
							Main.npc[num532].netUpdate = true;
							num532 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)this.position.Y + this.height / 2, 131, this.whoAmI);
							Main.npc[num532].ai[0] = 1f;
							Main.npc[num532].ai[1] = (float)this.whoAmI;
							Main.npc[num532].target = this.target;
							Main.npc[num532].netUpdate = true;
							Main.npc[num532].ai[3] = 150f;
						}
					}
					if (this.type == 68 && this.ai[1] != 3f && this.ai[1] != 2f)
					{
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						this.ai[1] = 2f;
					}
					if (Main.player[this.target].dead || Math.Abs(this.position.X - Main.player[this.target].position.X) > 6000f || Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 6000f)
					{
						this.TargetClosest(true);
						if (Main.player[this.target].dead || Math.Abs(this.position.X - Main.player[this.target].position.X) > 6000f || Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 6000f)
						{
							this.ai[1] = 3f;
						}
					}
					if (Main.dayTime && this.ai[1] != 3f && this.ai[1] != 2f)
					{
						this.ai[1] = 2f;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					}
					if (this.ai[1] == 0f)
					{
						this.ai[2] += 1f;
						if (this.ai[2] >= 600f)
						{
							this.ai[2] = 0f;
							this.ai[1] = 1f;
							this.TargetClosest(true);
							this.netUpdate = true;
						}
						this.rotation = this.velocity.X / 15f;
						if (this.position.Y > Main.player[this.target].position.Y - 200f)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.98f;
							}
							this.velocity.Y = this.velocity.Y - 0.1f;
							if (this.velocity.Y > 2f)
							{
								this.velocity.Y = 2f;
							}
						}
						else if (this.position.Y < Main.player[this.target].position.Y - 500f)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.98f;
							}
							this.velocity.Y = this.velocity.Y + 0.1f;
							if (this.velocity.Y < -2f)
							{
								this.velocity.Y = -2f;
							}
						}
						if (this.position.X + (float)(this.width / 2) > Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + 100f)
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.98f;
							}
							this.velocity.X = this.velocity.X - 0.1f;
							if (this.velocity.X > 8f)
							{
								this.velocity.X = 8f;
							}
						}
						if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - 100f)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.98f;
							}
							this.velocity.X = this.velocity.X + 0.1f;
							if (this.velocity.X < -8f)
							{
								this.velocity.X = -8f;
							}
						}
					}
					else if (this.ai[1] == 1f)
					{
						this.defense *= 2;
						this.damage *= 2;
						this.ai[2] += 1f;
						if (this.ai[2] == 2f)
						{
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						}
						if (this.ai[2] >= 400f)
						{
							this.ai[2] = 0f;
							this.ai[1] = 0f;
						}
						this.rotation += (float)this.direction * 0.3f;
						Vector2 vector76 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num533 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector76.X;
						float num534 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector76.Y;
						float num535 = (float)Math.Sqrt((double)(num533 * num533 + num534 * num534));
						num535 = 2f / num535;
						this.velocity.X = num533 * num535;
						this.velocity.Y = num534 * num535;
					}
					else if (this.ai[1] == 2f)
					{
						this.damage = 9999;
						this.defense = 9999;
						this.rotation += (float)this.direction * 0.3f;
						Vector2 vector77 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num536 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector77.X;
						float num537 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector77.Y;
						float num538 = (float)Math.Sqrt((double)(num536 * num536 + num537 * num537));
						num538 = 8f / num538;
						this.velocity.X = num536 * num538;
						this.velocity.Y = num537 * num538;
					}
					else if (this.ai[1] == 3f)
					{
						this.velocity.Y = this.velocity.Y + 0.1f;
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.95f;
						}
						this.velocity.X = this.velocity.X * 0.95f;
						if (this.timeLeft > 500)
						{
							this.timeLeft = 500;
						}
					}
				}
				else if (this.aiStyle == 33)
				{
					Vector2 vector78 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num539 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector78.X;
					float num540 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector78.Y;
					float num541 = (float)Math.Sqrt((double)(num539 * num539 + num540 * num540));
					if (this.ai[2] != 99f)
					{
						if (num541 > 800f)
						{
							this.ai[2] = 99f;
						}
					}
					else if (num541 < 400f)
					{
						this.ai[2] = 0f;
					}
					this.spriteDirection = -(int)this.ai[0];
					if (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != 32)
					{
						this.ai[2] += 10f;
						if (this.ai[2] > 50f || Main.netMode != 2)
						{
							this.life = -1;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
					}
					if (this.ai[2] == 99f)
					{
						if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y - 0.1f;
							if (this.velocity.Y > 8f)
							{
								this.velocity.Y = 8f;
							}
						}
						else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y + 0.1f;
							if (this.velocity.Y < -8f)
							{
								this.velocity.Y = -8f;
							}
						}
						if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X - 0.5f;
							if (this.velocity.X > 12f)
							{
								this.velocity.X = 12f;
							}
						}
						if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X + 0.5f;
							if (this.velocity.X < -12f)
							{
								this.velocity.X = -12f;
							}
						}
					}
					else if (this.ai[2] == 0f || this.ai[2] == 3f)
					{
						if (Main.npc[(int)this.ai[1]].ai[1] == 3f && this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
						if (Main.npc[(int)this.ai[1]].ai[1] != 0f)
						{
							this.TargetClosest(true);
							if (Main.player[this.target].dead)
							{
								this.velocity.Y = this.velocity.Y + 0.1f;
								if (this.velocity.Y > 16f)
								{
									this.velocity.Y = 16f;
								}
							}
							else
							{
								Vector2 vector79 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num542 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector79.X;
								float num543 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector79.Y;
								float num544 = (float)Math.Sqrt((double)(num542 * num542 + num543 * num543));
								num544 = 7f / num544;
								num542 *= num544;
								num543 *= num544;
								this.rotation = (float)Math.Atan2((double)num543, (double)num542) - 1.57f;
								if (this.velocity.X > num542)
								{
									if (this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X * 0.97f;
									}
									this.velocity.X = this.velocity.X - 0.05f;
								}
								if (this.velocity.X < num542)
								{
									if (this.velocity.X < 0f)
									{
										this.velocity.X = this.velocity.X * 0.97f;
									}
									this.velocity.X = this.velocity.X + 0.05f;
								}
								if (this.velocity.Y > num543)
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y * 0.97f;
									}
									this.velocity.Y = this.velocity.Y - 0.05f;
								}
								if (this.velocity.Y < num543)
								{
									if (this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y * 0.97f;
									}
									this.velocity.Y = this.velocity.Y + 0.05f;
								}
							}
							this.ai[3] += 1f;
							if (this.ai[3] >= 600f)
							{
								this.ai[2] = 0f;
								this.ai[3] = 0f;
								this.netUpdate = true;
							}
						}
						else
						{
							this.ai[3] += 1f;
							if (this.ai[3] >= 300f)
							{
								this.ai[2] += 1f;
								this.ai[3] = 0f;
								this.netUpdate = true;
							}
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y + 320f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.04f;
								if (this.velocity.Y > 3f)
								{
									this.velocity.Y = 3f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y + 260f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.04f;
								if (this.velocity.Y < -3f)
								{
									this.velocity.Y = -3f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X - 0.3f;
								if (this.velocity.X > 12f)
								{
									this.velocity.X = 12f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 250f)
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X + 0.3f;
								if (this.velocity.X < -12f)
								{
									this.velocity.X = -12f;
								}
							}
						}
						Vector2 vector80 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num545 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector80.X;
						float num546 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector80.Y;
						Math.Sqrt((double)(num545 * num545 + num546 * num546));
						this.rotation = (float)Math.Atan2((double)num546, (double)num545) + 1.57f;
					}
					else if (this.ai[2] == 1f)
					{
						Vector2 vector81 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num547 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector81.X;
						float num548 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector81.Y;
						float num549 = (float)Math.Sqrt((double)(num547 * num547 + num548 * num548));
						this.rotation = (float)Math.Atan2((double)num548, (double)num547) + 1.57f;
						this.velocity.X = this.velocity.X * 0.95f;
						this.velocity.Y = this.velocity.Y - 0.1f;
						if (this.velocity.Y < -8f)
						{
							this.velocity.Y = -8f;
						}
						if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 200f)
						{
							this.TargetClosest(true);
							this.ai[2] = 2f;
							vector81 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num547 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector81.X;
							num548 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector81.Y;
							num549 = (float)Math.Sqrt((double)(num547 * num547 + num548 * num548));
							num549 = 22f / num549;
							this.velocity.X = num547 * num549;
							this.velocity.Y = num548 * num549;
							this.netUpdate = true;
						}
					}
					else if (this.ai[2] == 2f)
					{
						if (this.position.Y > Main.player[this.target].position.Y || this.velocity.Y < 0f)
						{
							this.ai[2] = 3f;
						}
					}
					else if (this.ai[2] == 4f)
					{
						this.TargetClosest(true);
						Vector2 vector82 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num550 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector82.X;
						float num551 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector82.Y;
						float num552 = (float)Math.Sqrt((double)(num550 * num550 + num551 * num551));
						num552 = 7f / num552;
						num550 *= num552;
						num551 *= num552;
						if (this.velocity.X > num550)
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.97f;
							}
							this.velocity.X = this.velocity.X - 0.05f;
						}
						if (this.velocity.X < num550)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.97f;
							}
							this.velocity.X = this.velocity.X + 0.05f;
						}
						if (this.velocity.Y > num551)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.97f;
							}
							this.velocity.Y = this.velocity.Y - 0.05f;
						}
						if (this.velocity.Y < num551)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.97f;
							}
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
						this.ai[3] += 1f;
						if (this.ai[3] >= 600f)
						{
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
						vector82 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num550 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector82.X;
						num551 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector82.Y;
						num552 = (float)Math.Sqrt((double)(num550 * num550 + num551 * num551));
						this.rotation = (float)Math.Atan2((double)num551, (double)num550) + 1.57f;
					}
					else if (this.ai[2] == 5f && ((this.velocity.X > 0f && this.position.X + (float)(this.width / 2) > Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2)) || (this.velocity.X < 0f && this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2))))
					{
						this.ai[2] = 0f;
					}
				}
				else if (this.aiStyle == 34)
				{
					this.spriteDirection = -(int)this.ai[0];
					Vector2 vector83 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num553 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector83.X;
					float num554 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector83.Y;
					float num555 = (float)Math.Sqrt((double)(num553 * num553 + num554 * num554));
					if (this.ai[2] != 99f)
					{
						if (num555 > 800f)
						{
							this.ai[2] = 99f;
						}
					}
					else if (num555 < 400f)
					{
						this.ai[2] = 0f;
					}
					if (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != 32)
					{
						this.ai[2] += 10f;
						if (this.ai[2] > 50f || Main.netMode != 2)
						{
							this.life = -1;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
					}
					if (this.ai[2] == 99f)
					{
						if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y - 0.1f;
							if (this.velocity.Y > 8f)
							{
								this.velocity.Y = 8f;
							}
						}
						else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.96f;
							}
							this.velocity.Y = this.velocity.Y + 0.1f;
							if (this.velocity.Y < -8f)
							{
								this.velocity.Y = -8f;
							}
						}
						if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X - 0.5f;
							if (this.velocity.X > 12f)
							{
								this.velocity.X = 12f;
							}
						}
						if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
							this.velocity.X = this.velocity.X + 0.5f;
							if (this.velocity.X < -12f)
							{
								this.velocity.X = -12f;
							}
						}
					}
					else if (this.ai[2] == 0f || this.ai[2] == 3f)
					{
						if (Main.npc[(int)this.ai[1]].ai[1] == 3f && this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
						if (Main.npc[(int)this.ai[1]].ai[1] != 0f)
						{
							this.TargetClosest(true);
							this.TargetClosest(true);
							if (Main.player[this.target].dead)
							{
								this.velocity.Y = this.velocity.Y + 0.1f;
								if (this.velocity.Y > 16f)
								{
									this.velocity.Y = 16f;
								}
							}
							else
							{
								Vector2 vector84 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num556 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector84.X;
								float num557 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector84.Y;
								float num558 = (float)Math.Sqrt((double)(num556 * num556 + num557 * num557));
								num558 = 12f / num558;
								num556 *= num558;
								num557 *= num558;
								this.rotation = (float)Math.Atan2((double)num557, (double)num556) - 1.57f;
								if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 2f)
								{
									this.rotation = (float)Math.Atan2((double)num557, (double)num556) - 1.57f;
									this.velocity.X = num556;
									this.velocity.Y = num557;
									this.netUpdate = true;
								}
								else
								{
									this.velocity *= 0.97f;
								}
								this.ai[3] += 1f;
								if (this.ai[3] >= 600f)
								{
									this.ai[2] = 0f;
									this.ai[3] = 0f;
									this.netUpdate = true;
								}
							}
						}
						else
						{
							this.ai[3] += 1f;
							if (this.ai[3] >= 600f)
							{
								this.ai[2] += 1f;
								this.ai[3] = 0f;
								this.netUpdate = true;
							}
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y + 300f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.1f;
								if (this.velocity.Y > 3f)
								{
									this.velocity.Y = 3f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y + 230f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.1f;
								if (this.velocity.Y < -3f)
								{
									this.velocity.Y = -3f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) + 250f)
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.94f;
								}
								this.velocity.X = this.velocity.X - 0.3f;
								if (this.velocity.X > 9f)
								{
									this.velocity.X = 9f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2))
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.94f;
								}
								this.velocity.X = this.velocity.X + 0.2f;
								if (this.velocity.X < -8f)
								{
									this.velocity.X = -8f;
								}
							}
						}
						Vector2 vector85 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num559 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector85.X;
						float num560 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector85.Y;
						Math.Sqrt((double)(num559 * num559 + num560 * num560));
						this.rotation = (float)Math.Atan2((double)num560, (double)num559) + 1.57f;
					}
					else if (this.ai[2] == 1f)
					{
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
						}
						Vector2 vector86 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num561 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 280f * this.ai[0] - vector86.X;
						float num562 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector86.Y;
						float num563 = (float)Math.Sqrt((double)(num561 * num561 + num562 * num562));
						this.rotation = (float)Math.Atan2((double)num562, (double)num561) + 1.57f;
						this.velocity.X = (this.velocity.X * 5f + Main.npc[(int)this.ai[1]].velocity.X) / 6f;
						this.velocity.X = this.velocity.X + 0.5f;
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y < -9f)
						{
							this.velocity.Y = -9f;
						}
						if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 280f)
						{
							this.TargetClosest(true);
							this.ai[2] = 2f;
							vector86 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num561 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector86.X;
							num562 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector86.Y;
							num563 = (float)Math.Sqrt((double)(num561 * num561 + num562 * num562));
							num563 = 20f / num563;
							this.velocity.X = num561 * num563;
							this.velocity.Y = num562 * num563;
							this.netUpdate = true;
						}
					}
					else if (this.ai[2] == 2f)
					{
						if (this.position.Y > Main.player[this.target].position.Y || this.velocity.Y < 0f)
						{
							if (this.ai[3] >= 4f)
							{
								this.ai[2] = 3f;
								this.ai[3] = 0f;
							}
							else
							{
								this.ai[2] = 1f;
								this.ai[3] += 1f;
							}
						}
					}
					else if (this.ai[2] == 4f)
					{
						Vector2 vector87 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num564 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector87.X;
						float num565 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector87.Y;
						float num566 = (float)Math.Sqrt((double)(num564 * num564 + num565 * num565));
						this.rotation = (float)Math.Atan2((double)num565, (double)num564) + 1.57f;
						this.velocity.Y = (this.velocity.Y * 5f + Main.npc[(int)this.ai[1]].velocity.Y) / 6f;
						this.velocity.X = this.velocity.X + 0.5f;
						if (this.velocity.X > 12f)
						{
							this.velocity.X = 12f;
						}
						if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 500f || this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) + 500f)
						{
							this.TargetClosest(true);
							this.ai[2] = 5f;
							vector87 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num564 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector87.X;
							num565 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector87.Y;
							num566 = (float)Math.Sqrt((double)(num564 * num564 + num565 * num565));
							num566 = 17f / num566;
							this.velocity.X = num564 * num566;
							this.velocity.Y = num565 * num566;
							this.netUpdate = true;
						}
					}
					else if (this.ai[2] == 5f && this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - 100f)
					{
						if (this.ai[3] >= 4f)
						{
							this.ai[2] = 0f;
							this.ai[3] = 0f;
						}
						else
						{
							this.ai[2] = 4f;
							this.ai[3] += 1f;
						}
					}
				}
				else if (this.aiStyle == 35)
				{
					this.spriteDirection = -(int)this.ai[0];
					if (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != 32)
					{
						this.ai[2] += 10f;
						if (this.ai[2] > 50f || Main.netMode != 2)
						{
							this.life = -1;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
					}
					if (this.ai[2] == 0f)
					{
						if (Main.npc[(int)this.ai[1]].ai[1] == 3f && this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
						if (Main.npc[(int)this.ai[1]].ai[1] != 0f)
						{
							this.localAI[0] += 2f;
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.07f;
								if (this.velocity.Y > 6f)
								{
									this.velocity.Y = 6f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.07f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X - 0.1f;
								if (this.velocity.X > 8f)
								{
									this.velocity.X = 8f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X + 0.1f;
								if (this.velocity.X < -8f)
								{
									this.velocity.X = -8f;
								}
							}
						}
						else
						{
							this.ai[3] += 1f;
							if (this.ai[3] >= 1100f)
							{
								this.localAI[0] = 0f;
								this.ai[2] = 1f;
								this.ai[3] = 0f;
								this.netUpdate = true;
							}
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y - 150f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.04f;
								if (this.velocity.Y > 3f)
								{
									this.velocity.Y = 3f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 150f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.04f;
								if (this.velocity.Y < -3f)
								{
									this.velocity.Y = -3f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) + 200f)
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X - 0.2f;
								if (this.velocity.X > 8f)
								{
									this.velocity.X = 8f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) + 160f)
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X + 0.2f;
								if (this.velocity.X < -8f)
								{
									this.velocity.X = -8f;
								}
							}
						}
						Vector2 vector88 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num567 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 200f * this.ai[0] - vector88.X;
						float num568 = Main.npc[(int)this.ai[1]].position.Y + 230f - vector88.Y;
						float num569 = (float)Math.Sqrt((double)(num567 * num567 + num568 * num568));
						this.rotation = (float)Math.Atan2((double)num568, (double)num567) + 1.57f;
						if (Main.netMode != 1)
						{
							this.localAI[0] += 1f;
							if (this.localAI[0] > 140f)
							{
								this.localAI[0] = 0f;
								float num570 = 12f;
								int num571 = 0;
								int num572 = 102;
								num569 = num570 / num569;
								num567 = -num567 * num569;
								num568 = -num568 * num569;
								num567 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num568 += (float)Main.rand.Next(-40, 41) * 0.01f;
								vector88.X += num567 * 4f;
								vector88.Y += num568 * 4f;
								Projectile.NewProjectile(vector88.X, vector88.Y, num567, num568, num572, num571, 0f, Main.myPlayer);
							}
						}
					}
					else if (this.ai[2] == 1f)
					{
						this.ai[3] += 1f;
						if (this.ai[3] >= 300f)
						{
							this.localAI[0] = 0f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
						Vector2 vector89 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num573 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - vector89.X;
						float num574 = Main.npc[(int)this.ai[1]].position.Y - vector89.Y;
						num574 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 80f - vector89.Y;
						float num575 = (float)Math.Sqrt((double)(num573 * num573 + num574 * num574));
						num575 = 6f / num575;
						num573 *= num575;
						num574 *= num575;
						if (this.velocity.X > num573)
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							this.velocity.X = this.velocity.X - 0.04f;
						}
						if (this.velocity.X < num573)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							this.velocity.X = this.velocity.X + 0.04f;
						}
						if (this.velocity.Y > num574)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
							}
							this.velocity.Y = this.velocity.Y - 0.08f;
						}
						if (this.velocity.Y < num574)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
							}
							this.velocity.Y = this.velocity.Y + 0.08f;
						}
						this.TargetClosest(true);
						vector89 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num573 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector89.X;
						num574 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector89.Y;
						num575 = (float)Math.Sqrt((double)(num573 * num573 + num574 * num574));
						this.rotation = (float)Math.Atan2((double)num574, (double)num573) - 1.57f;
						if (Main.netMode != 1)
						{
							this.localAI[0] += 1f;
							if (this.localAI[0] > 40f)
							{
								this.localAI[0] = 0f;
								float num576 = 10f;
								int num577 = 0;
								int num578 = 102;
								num575 = num576 / num575;
								num573 *= num575;
								num574 *= num575;
								num573 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num574 += (float)Main.rand.Next(-40, 41) * 0.01f;
								vector89.X += num573 * 4f;
								vector89.Y += num574 * 4f;
								Projectile.NewProjectile(vector89.X, vector89.Y, num573, num574, num578, num577, 0f, Main.myPlayer);
							}
						}
					}
				}
				else if (this.aiStyle == 36)
				{
					this.spriteDirection = -(int)this.ai[0];
					if (!Main.npc[(int)this.ai[1]].active || Main.npc[(int)this.ai[1]].aiStyle != 32)
					{
						this.ai[2] += 10f;
						if (this.ai[2] > 50f || Main.netMode != 2)
						{
							this.life = -1;
							this.HitEffect(0, 10.0);
							this.active = false;
						}
					}
					if (this.ai[2] == 0f || this.ai[2] == 3f)
					{
						if (Main.npc[(int)this.ai[1]].ai[1] == 3f && this.timeLeft > 10)
						{
							this.timeLeft = 10;
						}
						if (Main.npc[(int)this.ai[1]].ai[1] != 0f)
						{
							this.localAI[0] += 3f;
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.07f;
								if (this.velocity.Y > 6f)
								{
									this.velocity.Y = 6f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.07f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X - 0.1f;
								if (this.velocity.X > 8f)
								{
									this.velocity.X = 8f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 120f * this.ai[0])
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X + 0.1f;
								if (this.velocity.X < -8f)
								{
									this.velocity.X = -8f;
								}
							}
						}
						else
						{
							this.ai[3] += 1f;
							if (this.ai[3] >= 800f)
							{
								this.ai[2] += 1f;
								this.ai[3] = 0f;
								this.netUpdate = true;
							}
							if (this.position.Y > Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y - 0.1f;
								if (this.velocity.Y > 3f)
								{
									this.velocity.Y = 3f;
								}
							}
							else if (this.position.Y < Main.npc[(int)this.ai[1]].position.Y - 100f)
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.96f;
								}
								this.velocity.Y = this.velocity.Y + 0.1f;
								if (this.velocity.Y < -3f)
								{
									this.velocity.Y = -3f;
								}
							}
							if (this.position.X + (float)(this.width / 2) > Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 180f * this.ai[0])
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X - 0.14f;
								if (this.velocity.X > 8f)
								{
									this.velocity.X = 8f;
								}
							}
							if (this.position.X + (float)(this.width / 2) < Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - 180f * this.ai[0])
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.96f;
								}
								this.velocity.X = this.velocity.X + 0.14f;
								if (this.velocity.X < -8f)
								{
									this.velocity.X = -8f;
								}
							}
						}
						this.TargetClosest(true);
						Vector2 vector90 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num579 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector90.X;
						float num580 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector90.Y;
						float num581 = (float)Math.Sqrt((double)(num579 * num579 + num580 * num580));
						this.rotation = (float)Math.Atan2((double)num580, (double)num579) - 1.57f;
						if (Main.netMode != 1)
						{
							this.localAI[0] += 1f;
							if (this.localAI[0] > 200f)
							{
								this.localAI[0] = 0f;
								float num582 = 8f;
								int num583 = 25;
								int num584 = 100;
								num581 = num582 / num581;
								num579 *= num581;
								num580 *= num581;
								num579 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num580 += (float)Main.rand.Next(-40, 41) * 0.05f;
								vector90.X += num579 * 8f;
								vector90.Y += num580 * 8f;
								Projectile.NewProjectile(vector90.X, vector90.Y, num579, num580, num584, num583, 0f, Main.myPlayer);
							}
						}
					}
					else if (this.ai[2] == 1f)
					{
						this.ai[3] += 1f;
						if (this.ai[3] >= 200f)
						{
							this.localAI[0] = 0f;
							this.ai[2] = 0f;
							this.ai[3] = 0f;
							this.netUpdate = true;
						}
						Vector2 vector91 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num585 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - 350f - vector91.X;
						float num586 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - 20f - vector91.Y;
						float num587 = (float)Math.Sqrt((double)(num585 * num585 + num586 * num586));
						num587 = 7f / num587;
						num585 *= num587;
						num586 *= num587;
						if (this.velocity.X > num585)
						{
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							this.velocity.X = this.velocity.X - 0.1f;
						}
						if (this.velocity.X < num585)
						{
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							this.velocity.X = this.velocity.X + 0.1f;
						}
						if (this.velocity.Y > num586)
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
							}
							this.velocity.Y = this.velocity.Y - 0.03f;
						}
						if (this.velocity.Y < num586)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
							}
							this.velocity.Y = this.velocity.Y + 0.03f;
						}
						this.TargetClosest(true);
						vector91 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num585 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector91.X;
						num586 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector91.Y;
						num587 = (float)Math.Sqrt((double)(num585 * num585 + num586 * num586));
						this.rotation = (float)Math.Atan2((double)num586, (double)num585) - 1.57f;
						if (Main.netMode == 1)
						{
							this.localAI[0] += 1f;
							if (this.localAI[0] > 80f)
							{
								this.localAI[0] = 0f;
								float num588 = 10f;
								int num589 = 25;
								int num590 = 100;
								num587 = num588 / num587;
								num585 *= num587;
								num586 *= num587;
								num585 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num586 += (float)Main.rand.Next(-40, 41) * 0.05f;
								vector91.X += num585 * 8f;
								vector91.Y += num586 * 8f;
								Projectile.NewProjectile(vector91.X, vector91.Y, num585, num586, num590, num589, 0f, Main.myPlayer);
							}
						}
					}
				}
				else if (this.aiStyle == 37)
				{
					if (this.ai[3] > 0f)
					{
						this.realLife = (int)this.ai[3];
					}
					if (this.target < 0 || this.target == 255 || Main.player[this.target].dead)
					{
						this.TargetClosest(true);
					}
					if (this.type > 134)
					{
						bool flag34 = false;
						if (this.ai[1] <= 0f)
						{
							flag34 = true;
						}
						else if (Main.npc[(int)this.ai[1]].life <= 0)
						{
							flag34 = true;
						}
						if (flag34)
						{
							this.life = 0;
							this.HitEffect(0, 10.0);
							this.checkDead();
						}
					}
					if (Main.netMode != 1)
					{
						if (this.ai[0] == 0f && this.type == 134)
						{
							this.ai[3] = (float)this.whoAmI;
							this.realLife = this.whoAmI;
							int num591 = this.whoAmI;
							int num592 = 80;
							for (int num593 = 0; num593 <= num592; num593++)
							{
								int num594 = 135;
								if (num593 == num592)
								{
									num594 = 136;
								}
								int num595 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), num594, this.whoAmI);
								Main.npc[num595].ai[3] = (float)this.whoAmI;
								Main.npc[num595].realLife = this.whoAmI;
								Main.npc[num595].ai[1] = (float)num591;
								Main.npc[num591].ai[0] = (float)num595;
								NetMessage.SendData(23, -1, -1, "", num595, 0f, 0f, 0f, 0);
								num591 = num595;
							}
						}
						if (this.type == 135)
						{
							this.localAI[0] += (float)Main.rand.Next(4);
							if (this.localAI[0] >= (float)Main.rand.Next(1400, 26000))
							{
								this.localAI[0] = 0f;
								this.TargetClosest(true);
								if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
								{
									float num596 = 8f;
									Vector2 vector92 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2));
									float num597 = Main.player[this.target].position.X + (float)Main.player[this.target].width * 0.5f - vector92.X + (float)Main.rand.Next(-20, 21);
									float num598 = Main.player[this.target].position.Y + (float)Main.player[this.target].height * 0.5f - vector92.Y + (float)Main.rand.Next(-20, 21);
									float num599 = (float)Math.Sqrt((double)(num597 * num597 + num598 * num598));
									num599 = num596 / num599;
									num597 *= num599;
									num598 *= num599;
									num597 += (float)Main.rand.Next(-20, 21) * 0.05f;
									num598 += (float)Main.rand.Next(-20, 21) * 0.05f;
									int num600 = 22;
									int num601 = 100;
									vector92.X += num597 * 5f;
									vector92.Y += num598 * 5f;
									int num602 = Projectile.NewProjectile(vector92.X, vector92.Y, num597, num598, num601, num600, 0f, Main.myPlayer);
									Main.projectile[num602].timeLeft = 300;
									this.netUpdate = true;
								}
							}
						}
					}
					int num603 = (int)(this.position.X / 16f) - 1;
					int num604 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num605 = (int)(this.position.Y / 16f) - 1;
					int num606 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num603 < 0)
					{
						num603 = 0;
					}
					if (num604 > Main.maxTilesX)
					{
						num604 = Main.maxTilesX;
					}
					if (num605 < 0)
					{
						num605 = 0;
					}
					if (num606 > Main.maxTilesY)
					{
						num606 = Main.maxTilesY;
					}
					bool flag35 = false;
					if (!flag35)
					{
						for (int num607 = num603; num607 < num604; num607++)
						{
							for (int num608 = num605; num608 < num606; num608++)
							{
								if (Main.tile[num607, num608] != null && ((Main.tile[num607, num608].active && (Main.tileSolid[(int)Main.tile[num607, num608].type] || (Main.tileSolidTop[(int)Main.tile[num607, num608].type] && Main.tile[num607, num608].frameY == 0))) || Main.tile[num607, num608].liquid > 64))
								{
									Vector2 vector93;
									vector93.X = (float)(num607 * 16);
									vector93.Y = (float)(num608 * 16);
									if (this.position.X + (float)this.width > vector93.X && this.position.X < vector93.X + 16f && this.position.Y + (float)this.height > vector93.Y && this.position.Y < vector93.Y + 16f)
									{
										flag35 = true;
										break;
									}
								}
							}
						}
					}
					if (!flag35)
					{
						if (this.type != 135 || this.ai[2] != 1f)
						{
							Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
						}
						this.localAI[1] = 1f;
						if (this.type == 134)
						{
							Rectangle rectangle11 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							int num609 = 1000;
							bool flag36 = true;
							if (this.position.Y > Main.player[this.target].position.Y)
							{
								for (int num610 = 0; num610 < 255; num610++)
								{
									if (Main.player[num610].active)
									{
										Rectangle rectangle12 = new Rectangle((int)Main.player[num610].position.X - num609, (int)Main.player[num610].position.Y - num609, num609 * 2, num609 * 2);
										if (rectangle11.Intersects(rectangle12))
										{
											flag36 = false;
											break;
										}
									}
								}
								if (flag36)
								{
									flag35 = true;
								}
							}
						}
					}
					else
					{
						this.localAI[1] = 0f;
					}
					float num611 = 16f;
					if (Main.dayTime || Main.player[this.target].dead)
					{
						flag35 = false;
						this.velocity.Y = this.velocity.Y + 1f;
						if ((double)this.position.Y > Main.worldSurface * 16.0)
						{
							this.velocity.Y = this.velocity.Y + 1f;
							num611 = 32f;
						}
						if ((double)this.position.Y > Main.rockLayer * 16.0)
						{
							for (int num612 = 0; num612 < 200; num612++)
							{
								if (Main.npc[num612].aiStyle == this.aiStyle)
								{
									Main.npc[num612].active = false;
								}
							}
						}
					}
					float num613 = 0.1f;
					float num614 = 0.15f;
					Vector2 vector94 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num615 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2);
					float num616 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2);
					num615 = (float)((int)(num615 / 16f) * 16);
					num616 = (float)((int)(num616 / 16f) * 16);
					vector94.X = (float)((int)(vector94.X / 16f) * 16);
					vector94.Y = (float)((int)(vector94.Y / 16f) * 16);
					num615 -= vector94.X;
					num616 -= vector94.Y;
					float num617 = (float)Math.Sqrt((double)(num615 * num615 + num616 * num616));
					if (this.ai[1] > 0f && this.ai[1] < (float)Main.npc.Length)
					{
						try
						{
							vector94 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num615 = Main.npc[(int)this.ai[1]].position.X + (float)(Main.npc[(int)this.ai[1]].width / 2) - vector94.X;
							num616 = Main.npc[(int)this.ai[1]].position.Y + (float)(Main.npc[(int)this.ai[1]].height / 2) - vector94.Y;
						}
						catch
						{
						}
						this.rotation = (float)Math.Atan2((double)num616, (double)num615) + 1.57f;
						num617 = (float)Math.Sqrt((double)(num615 * num615 + num616 * num616));
						int num618 = (int)(44f * this.scale);
						num617 = (num617 - (float)num618) / num617;
						num615 *= num617;
						num616 *= num617;
						this.velocity = default(Vector2);
						this.position.X = this.position.X + num615;
						this.position.Y = this.position.Y + num616;
					}
					else
					{
						if (!flag35)
						{
							this.TargetClosest(true);
							this.velocity.Y = this.velocity.Y + 0.15f;
							if (this.velocity.Y > num611)
							{
								this.velocity.Y = num611;
							}
							if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num611 * 0.4)
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X - num613 * 1.1f;
								}
								else
								{
									this.velocity.X = this.velocity.X + num613 * 1.1f;
								}
							}
							else if (this.velocity.Y == num611)
							{
								if (this.velocity.X < num615)
								{
									this.velocity.X = this.velocity.X + num613;
								}
								else if (this.velocity.X > num615)
								{
									this.velocity.X = this.velocity.X - num613;
								}
							}
							else if (this.velocity.Y > 4f)
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num613 * 0.9f;
								}
								else
								{
									this.velocity.X = this.velocity.X - num613 * 0.9f;
								}
							}
						}
						else
						{
							if (this.soundDelay == 0)
							{
								float num619 = num617 / 40f;
								if (num619 < 10f)
								{
									num619 = 10f;
								}
								if (num619 > 20f)
								{
									num619 = 20f;
								}
								this.soundDelay = (int)num619;
								Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 1);
							}
							num617 = (float)Math.Sqrt((double)(num615 * num615 + num616 * num616));
							float num620 = Math.Abs(num615);
							float num621 = Math.Abs(num616);
							float num622 = num611 / num617;
							num615 *= num622;
							num616 *= num622;
							if (((this.velocity.X > 0f && num615 > 0f) || (this.velocity.X < 0f && num615 < 0f)) && ((this.velocity.Y > 0f && num616 > 0f) || (this.velocity.Y < 0f && num616 < 0f)))
							{
								if (this.velocity.X < num615)
								{
									this.velocity.X = this.velocity.X + num614;
								}
								else if (this.velocity.X > num615)
								{
									this.velocity.X = this.velocity.X - num614;
								}
								if (this.velocity.Y < num616)
								{
									this.velocity.Y = this.velocity.Y + num614;
								}
								else if (this.velocity.Y > num616)
								{
									this.velocity.Y = this.velocity.Y - num614;
								}
							}
							if ((this.velocity.X > 0f && num615 > 0f) || (this.velocity.X < 0f && num615 < 0f) || (this.velocity.Y > 0f && num616 > 0f) || (this.velocity.Y < 0f && num616 < 0f))
							{
								if (this.velocity.X < num615)
								{
									this.velocity.X = this.velocity.X + num613;
								}
								else if (this.velocity.X > num615)
								{
									this.velocity.X = this.velocity.X - num613;
								}
								if (this.velocity.Y < num616)
								{
									this.velocity.Y = this.velocity.Y + num613;
								}
								else if (this.velocity.Y > num616)
								{
									this.velocity.Y = this.velocity.Y - num613;
								}
								if ((double)Math.Abs(num616) < (double)num611 * 0.2 && ((this.velocity.X > 0f && num615 < 0f) || (this.velocity.X < 0f && num615 > 0f)))
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y + num613 * 2f;
									}
									else
									{
										this.velocity.Y = this.velocity.Y - num613 * 2f;
									}
								}
								if ((double)Math.Abs(num615) < (double)num611 * 0.2 && ((this.velocity.Y > 0f && num616 < 0f) || (this.velocity.Y < 0f && num616 > 0f)))
								{
									if (this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X + num613 * 2f;
									}
									else
									{
										this.velocity.X = this.velocity.X - num613 * 2f;
									}
								}
							}
							else if (num620 > num621)
							{
								if (this.velocity.X < num615)
								{
									this.velocity.X = this.velocity.X + num613 * 1.1f;
								}
								else if (this.velocity.X > num615)
								{
									this.velocity.X = this.velocity.X - num613 * 1.1f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num611 * 0.5)
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y + num613;
									}
									else
									{
										this.velocity.Y = this.velocity.Y - num613;
									}
								}
							}
							else
							{
								if (this.velocity.Y < num616)
								{
									this.velocity.Y = this.velocity.Y + num613 * 1.1f;
								}
								else if (this.velocity.Y > num616)
								{
									this.velocity.Y = this.velocity.Y - num613 * 1.1f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num611 * 0.5)
								{
									if (this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X + num613;
									}
									else
									{
										this.velocity.X = this.velocity.X - num613;
									}
								}
							}
						}
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
						if (this.type == 134)
						{
							if (flag35)
							{
								if (this.localAI[0] != 1f)
								{
									this.netUpdate = true;
								}
								this.localAI[0] = 1f;
							}
							else
							{
								if (this.localAI[0] != 0f)
								{
									this.netUpdate = true;
								}
								this.localAI[0] = 0f;
							}
							if (((this.velocity.X > 0f && this.oldVelocity.X < 0f) || (this.velocity.X < 0f && this.oldVelocity.X > 0f) || (this.velocity.Y > 0f && this.oldVelocity.Y < 0f) || (this.velocity.Y < 0f && this.oldVelocity.Y > 0f)) && !this.justHit)
							{
								this.netUpdate = true;
							}
						}
					}
				}
				else if (this.aiStyle == 38)
				{
					float num623 = 4f;
					float num624 = 1f;
					if (this.type == 143)
					{
						num623 = 3f;
						num624 = 0.7f;
					}
					if (this.type == 145)
					{
						num623 = 3.5f;
						num624 = 0.8f;
					}
					if (this.type == 143)
					{
						this.ai[2] += 1f;
						if (this.ai[2] >= 120f)
						{
							this.ai[2] = 0f;
							if (Main.netMode != 1)
							{
								Vector2 vector95 = new Vector2(this.position.X + (float)this.width * 0.5f - (float)(this.direction * 12), this.position.Y + (float)this.height * 0.5f);
								float speedX30 = (float)(12 * this.spriteDirection);
								float speedY36 = 0f;
								if (Main.netMode != 1)
								{
									int num625 = 25;
									int num626 = 110;
									int num627 = Projectile.NewProjectile(vector95.X, vector95.Y, speedX30, speedY36, num626, num625, 0f, Main.myPlayer);
									Main.projectile[num627].ai[0] = 2f;
									Main.projectile[num627].timeLeft = 300;
									Main.projectile[num627].friendly = false;
									NetMessage.SendData(27, -1, -1, "", num627, 0f, 0f, 0f, 0);
									this.netUpdate = true;
								}
							}
						}
					}
					if (this.type == 144 && this.ai[1] >= 3f)
					{
						this.TargetClosest(true);
						this.spriteDirection = this.direction;
						if (this.velocity.Y == 0f)
						{
							this.velocity.X = this.velocity.X * 0.9f;
							this.ai[2] += 1f;
							if ((double)this.velocity.X > -0.3 && (double)this.velocity.X < 0.3)
							{
								this.velocity.X = 0f;
							}
							if (this.ai[2] >= 200f)
							{
								this.ai[2] = 0f;
								this.ai[1] = 0f;
							}
						}
					}
					else if (this.type == 145 && this.ai[1] >= 3f)
					{
						this.TargetClosest(true);
						if (this.velocity.Y == 0f)
						{
							this.velocity.X = this.velocity.X * 0.9f;
							this.ai[2] += 1f;
							if ((double)this.velocity.X > -0.3 && (double)this.velocity.X < 0.3)
							{
								this.velocity.X = 0f;
							}
							if (this.ai[2] >= 16f)
							{
								this.ai[2] = 0f;
								this.ai[1] = 0f;
							}
						}
						if (this.velocity.X == 0f && this.velocity.Y == 0f && this.ai[2] == 8f)
						{
							float num628 = 10f;
							Vector2 vector96 = new Vector2(this.position.X + (float)this.width * 0.5f - (float)(this.direction * 12), this.position.Y + (float)this.height * 0.25f);
							float num629 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector96.X;
							float num630 = Main.player[this.target].position.Y - vector96.Y;
							float num631 = (float)Math.Sqrt((double)(num629 * num629 + num630 * num630));
							num631 = num628 / num631;
							num629 *= num631;
							num630 *= num631;
							if (Main.netMode != 1)
							{
								int num632 = 35;
								int num633 = 109;
								int num634 = Projectile.NewProjectile(vector96.X, vector96.Y, num629, num630, num633, num632, 0f, Main.myPlayer);
								Main.projectile[num634].ai[0] = 2f;
								Main.projectile[num634].timeLeft = 300;
								Main.projectile[num634].friendly = false;
								NetMessage.SendData(27, -1, -1, "", num634, 0f, 0f, 0f, 0);
								this.netUpdate = true;
							}
						}
					}
					else
					{
						if (this.velocity.Y == 0f)
						{
							if (this.localAI[2] == this.position.X)
							{
								this.direction *= -1;
								this.ai[3] = 60f;
							}
							this.localAI[2] = this.position.X;
							if (this.ai[3] == 0f)
							{
								this.TargetClosest(true);
							}
							this.ai[0] += 1f;
							if (this.ai[0] > 2f)
							{
								this.ai[0] = 0f;
								this.ai[1] += 1f;
								this.velocity.Y = -8.2f;
								this.velocity.X = this.velocity.X + (float)this.direction * num624 * 1.1f;
							}
							else
							{
								this.velocity.Y = -6f;
								this.velocity.X = this.velocity.X + (float)this.direction * num624 * 0.9f;
							}
							this.spriteDirection = this.direction;
						}
						this.velocity.X = this.velocity.X + (float)this.direction * num624 * 0.01f;
					}
					if (this.ai[3] > 0f)
					{
						this.ai[3] -= 1f;
					}
					if (this.velocity.X > num623 && this.direction > 0)
					{
						this.velocity.X = 4f;
					}
					if (this.velocity.X < -num623 && this.direction < 0)
					{
						this.velocity.X = -4f;
					}
				}
			}
		}

		public void FindFrame()
		{
			int num = 1;
			if (!Main.dedServ)
			{
				num = Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type];
			}
			int num2 = 0;
			if (this.aiAction == 0)
			{
				if (this.velocity.Y < 0f)
				{
					num2 = 2;
				}
				else if (this.velocity.Y > 0f)
				{
					num2 = 3;
				}
				else if (this.velocity.X != 0f)
				{
					num2 = 1;
				}
				else
				{
					num2 = 0;
				}
			}
			else if (this.aiAction == 1)
			{
				num2 = 4;
			}
			if (this.type == 1 || this.type == 16 || this.type == 59 || this.type == 71 || this.type == 81 || this.type == 138)
			{
				this.frameCounter += 1.0;
				if (num2 > 0)
				{
					this.frameCounter += 1.0;
				}
				if (num2 == 4)
				{
					this.frameCounter += 1.0;
				}
				if (this.frameCounter >= 8.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 141)
			{
				this.spriteDirection = this.direction;
				if (this.velocity.Y != 0f)
				{
					this.frame.Y = num * 2;
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 8.0)
					{
						this.frame.Y = this.frame.Y + num;
						this.frameCounter = 0.0;
					}
					if (this.frame.Y > num)
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 143)
			{
				if (this.velocity.Y > 0f)
				{
					this.frameCounter += 1.0;
				}
				else if (this.velocity.Y < 0f)
				{
					this.frameCounter -= 1.0;
				}
				if (this.frameCounter < 6.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num * 2;
				}
				else if (this.frameCounter < 18.0)
				{
					this.frame.Y = num * 3;
				}
				if (this.frameCounter < 0.0)
				{
					this.frameCounter = 0.0;
				}
				if (this.frameCounter > 17.0)
				{
					this.frameCounter = 17.0;
				}
			}
			if (this.type == 144)
			{
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					this.localAI[3] += 1f;
					if (this.localAI[3] < 6f)
					{
						this.frame.Y = 0;
					}
					else if (this.localAI[3] < 12f)
					{
						this.frame.Y = num;
					}
					if (this.localAI[3] >= 11f)
					{
						this.localAI[3] = 0f;
					}
				}
				else
				{
					if (this.velocity.Y > 0f)
					{
						this.frameCounter += 1.0;
					}
					else if (this.velocity.Y < 0f)
					{
						this.frameCounter -= 1.0;
					}
					if (this.frameCounter < 6.0)
					{
						this.frame.Y = num * 2;
					}
					else if (this.frameCounter < 12.0)
					{
						this.frame.Y = num * 3;
					}
					else if (this.frameCounter < 18.0)
					{
						this.frame.Y = num * 4;
					}
					if (this.frameCounter < 0.0)
					{
						this.frameCounter = 0.0;
					}
					if (this.frameCounter > 17.0)
					{
						this.frameCounter = 17.0;
					}
				}
			}
			if (this.type == 145)
			{
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					if (this.ai[2] < 4f)
					{
						this.frame.Y = 0;
					}
					else if (this.ai[2] < 8f)
					{
						this.frame.Y = num;
					}
					else if (this.ai[2] < 12f)
					{
						this.frame.Y = num * 2;
					}
					else if (this.ai[2] < 16f)
					{
						this.frame.Y = num * 3;
					}
				}
				else
				{
					if (this.velocity.Y > 0f)
					{
						this.frameCounter += 1.0;
					}
					else if (this.velocity.Y < 0f)
					{
						this.frameCounter -= 1.0;
					}
					if (this.frameCounter < 6.0)
					{
						this.frame.Y = num * 4;
					}
					else if (this.frameCounter < 12.0)
					{
						this.frame.Y = num * 5;
					}
					else if (this.frameCounter < 18.0)
					{
						this.frame.Y = num * 6;
					}
					if (this.frameCounter < 0.0)
					{
						this.frameCounter = 0.0;
					}
					if (this.frameCounter > 17.0)
					{
						this.frameCounter = 17.0;
					}
				}
			}
			if (this.type == 50)
			{
				if (this.velocity.Y != 0f)
				{
					this.frame.Y = num * 4;
				}
				else
				{
					this.frameCounter += 1.0;
					if (num2 > 0)
					{
						this.frameCounter += 1.0;
					}
					if (num2 == 4)
					{
						this.frameCounter += 1.0;
					}
					if (this.frameCounter >= 8.0)
					{
						this.frame.Y = this.frame.Y + num;
						this.frameCounter = 0.0;
					}
					if (this.frame.Y >= num * 4)
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 135)
			{
				if (this.ai[2] == 0f)
				{
					this.frame.Y = 0;
				}
				else
				{
					this.frame.Y = num;
				}
			}
			if (this.type == 85)
			{
				if (this.ai[0] == 0f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
				else
				{
					int num3 = 3;
					if (this.velocity.Y == 0f)
					{
						this.frameCounter -= 1.0;
					}
					else
					{
						this.frameCounter += 1.0;
					}
					if (this.frameCounter < 0.0)
					{
						this.frameCounter = 0.0;
					}
					if (this.frameCounter > (double)(num3 * 4))
					{
						this.frameCounter = (double)(num3 * 4);
					}
					if (this.frameCounter < (double)num3)
					{
						this.frame.Y = num;
					}
					else if (this.frameCounter < (double)(num3 * 2))
					{
						this.frame.Y = num * 2;
					}
					else if (this.frameCounter < (double)(num3 * 3))
					{
						this.frame.Y = num * 3;
					}
					else if (this.frameCounter < (double)(num3 * 4))
					{
						this.frame.Y = num * 4;
					}
					else if (this.frameCounter < (double)(num3 * 5))
					{
						this.frame.Y = num * 5;
					}
					else if (this.frameCounter < (double)(num3 * 6))
					{
						this.frame.Y = num * 4;
					}
					else if (this.frameCounter < (double)(num3 * 7))
					{
						this.frame.Y = num * 3;
					}
					else
					{
						this.frame.Y = num * 2;
						if (this.frameCounter >= (double)(num3 * 8))
						{
							this.frameCounter = (double)num3;
						}
					}
				}
				if (this.ai[3] == 2f)
				{
					this.frame.Y = this.frame.Y + num * 6;
				}
				else if (this.ai[3] == 3f)
				{
					this.frame.Y = this.frame.Y + num * 12;
				}
			}
			if (this.type == 113 || this.type == 114)
			{
				if (this.ai[2] == 0f)
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 12.0)
					{
						this.frame.Y = this.frame.Y + num;
						this.frameCounter = 0.0;
					}
					if (this.frame.Y >= num * Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
				else
				{
					this.frame.Y = 0;
					this.frameCounter = -60.0;
				}
			}
			if (this.type == 61)
			{
				this.spriteDirection = this.direction;
				this.rotation = this.velocity.X * 0.1f;
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					this.frame.Y = 0;
					this.frameCounter = 0.0;
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter < 4.0)
					{
						this.frame.Y = num;
					}
					else
					{
						this.frame.Y = num * 2;
						if (this.frameCounter >= 7.0)
						{
							this.frameCounter = 0.0;
						}
					}
				}
			}
			if (this.type == 122)
			{
				this.spriteDirection = this.direction;
				this.rotation = this.velocity.X * 0.05f;
				if (this.ai[3] > 0f)
				{
					int num4 = (int)(this.ai[3] / 8f);
					this.frameCounter = 0.0;
					this.frame.Y = (num4 + 3) * num;
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 8.0)
					{
						this.frame.Y = this.frame.Y + num;
						this.frameCounter = 0.0;
					}
					if (this.frame.Y >= num * 3)
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 74)
			{
				this.spriteDirection = this.direction;
				this.rotation = this.velocity.X * 0.1f;
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					this.frame.Y = num * 4;
					this.frameCounter = 0.0;
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 4.0)
					{
						this.frame.Y = this.frame.Y + num;
						this.frameCounter = 0.0;
					}
					if (this.frame.Y >= num * Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 62 || this.type == 66)
			{
				this.spriteDirection = this.direction;
				this.rotation = this.velocity.X * 0.1f;
				this.frameCounter += 1.0;
				if (this.frameCounter < 6.0)
				{
					this.frame.Y = 0;
				}
				else
				{
					this.frame.Y = num;
					if (this.frameCounter >= 11.0)
					{
						this.frameCounter = 0.0;
					}
				}
			}
			if (this.type == 63 || this.type == 64 || this.type == 103)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 6.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 18.0)
				{
					this.frame.Y = num * 2;
				}
				else
				{
					this.frame.Y = num * 3;
					if (this.frameCounter >= 23.0)
					{
						this.frameCounter = 0.0;
					}
				}
			}
			if (this.type == 2 || this.type == 23 || this.type == 121)
			{
				if (this.type == 2)
				{
					if (this.velocity.X > 0f)
					{
						this.spriteDirection = 1;
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
					}
					if (this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
					}
				}
				else if (this.type == 2 || this.type == 121)
				{
					if (this.velocity.X > 0f)
					{
						this.spriteDirection = 1;
					}
					if (this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
					}
					this.rotation = this.velocity.X * 0.1f;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 8.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 133)
			{
				if (this.velocity.X > 0f)
				{
					this.spriteDirection = 1;
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
				}
				if (this.velocity.X < 0f)
				{
					this.spriteDirection = -1;
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 8.0)
				{
					this.frame.Y = num;
				}
				else
				{
					this.frame.Y = 0;
				}
				if (this.frameCounter >= 16.0)
				{
					this.frame.Y = 0;
					this.frameCounter = 0.0;
				}
				if ((double)this.life < (double)this.lifeMax * 0.5)
				{
					this.frame.Y = this.frame.Y + num * 2;
				}
			}
			if (this.type == 116)
			{
				if (this.velocity.X > 0f)
				{
					this.spriteDirection = 1;
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
				}
				if (this.velocity.X < 0f)
				{
					this.spriteDirection = -1;
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 5.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 75)
			{
				if (this.velocity.X > 0f)
				{
					this.spriteDirection = 1;
				}
				else
				{
					this.spriteDirection = -1;
				}
				this.rotation = this.velocity.X * 0.1f;
				this.frameCounter += 1.0;
				if (this.frameCounter >= 4.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 55 || this.type == 57 || this.type == 58 || this.type == 102)
			{
				this.spriteDirection = this.direction;
				this.frameCounter += 1.0;
				if (this.wet)
				{
					if (this.frameCounter < 6.0)
					{
						this.frame.Y = 0;
					}
					else if (this.frameCounter < 12.0)
					{
						this.frame.Y = num;
					}
					else if (this.frameCounter < 18.0)
					{
						this.frame.Y = num * 2;
					}
					else if (this.frameCounter < 24.0)
					{
						this.frame.Y = num * 3;
					}
					else
					{
						this.frameCounter = 0.0;
					}
				}
				else if (this.frameCounter < 6.0)
				{
					this.frame.Y = num * 4;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num * 5;
				}
				else
				{
					this.frameCounter = 0.0;
				}
			}
			if (this.type == 69)
			{
				if (this.ai[0] < 190f)
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 6.0)
					{
						this.frameCounter = 0.0;
						this.frame.Y = this.frame.Y + num;
						if (this.frame.Y / num >= Main.npcFrameCount[this.type] - 1)
						{
							this.frame.Y = 0;
						}
					}
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * (Main.npcFrameCount[this.type] - 1);
				}
			}
			if (this.type == 86)
			{
				if (this.velocity.Y == 0f || this.wet)
				{
					if (this.velocity.X < -2f)
					{
						this.spriteDirection = -1;
					}
					else if (this.velocity.X > 2f)
					{
						this.spriteDirection = 1;
					}
					else
					{
						this.spriteDirection = this.direction;
					}
				}
				if (this.velocity.Y != 0f)
				{
					this.frame.Y = num * 15;
					this.frameCounter = 0.0;
				}
				else if (this.velocity.X == 0f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
				else if (Math.Abs(this.velocity.X) < 3f)
				{
					this.frameCounter += (double)Math.Abs(this.velocity.X);
					if (this.frameCounter >= 6.0)
					{
						this.frameCounter = 0.0;
						this.frame.Y = this.frame.Y + num;
						if (this.frame.Y / num >= 9)
						{
							this.frame.Y = num;
						}
						if (this.frame.Y / num <= 0)
						{
							this.frame.Y = num;
						}
					}
				}
				else
				{
					this.frameCounter += (double)Math.Abs(this.velocity.X);
					if (this.frameCounter >= 10.0)
					{
						this.frameCounter = 0.0;
						this.frame.Y = this.frame.Y + num;
						if (this.frame.Y / num >= 15)
						{
							this.frame.Y = num * 9;
						}
						if (this.frame.Y / num <= 8)
						{
							this.frame.Y = num * 9;
						}
					}
				}
			}
			if (this.type == 127)
			{
				if (this.ai[1] == 0f)
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 12.0)
					{
						this.frameCounter = 0.0;
						this.frame.Y = this.frame.Y + num;
						if (this.frame.Y / num >= 2)
						{
							this.frame.Y = 0;
						}
					}
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * 2;
				}
			}
			if (this.type == 129)
			{
				if (this.velocity.Y == 0f)
				{
					this.spriteDirection = this.direction;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 2.0)
				{
					this.frameCounter = 0.0;
					this.frame.Y = this.frame.Y + num;
					if (this.frame.Y / num >= Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 130)
			{
				if (this.velocity.Y == 0f)
				{
					this.spriteDirection = this.direction;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 8.0)
				{
					this.frameCounter = 0.0;
					this.frame.Y = this.frame.Y + num;
					if (this.frame.Y / num >= Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 67)
			{
				if (this.velocity.Y == 0f)
				{
					this.spriteDirection = this.direction;
				}
				this.frameCounter += 1.0;
				if (this.frameCounter >= 6.0)
				{
					this.frameCounter = 0.0;
					this.frame.Y = this.frame.Y + num;
					if (this.frame.Y / num >= Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 109)
			{
				if (this.velocity.Y == 0f && ((this.velocity.X <= 0f && this.direction < 0) || (this.velocity.X >= 0f && this.direction > 0)))
				{
					this.spriteDirection = this.direction;
				}
				this.frameCounter += (double)Math.Abs(this.velocity.X);
				if (this.frameCounter >= 7.0)
				{
					this.frameCounter -= 7.0;
					this.frame.Y = this.frame.Y + num;
					if (this.frame.Y / num >= Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 83 || this.type == 84)
			{
				if (this.ai[0] == 2f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter >= 4.0)
					{
						this.frameCounter = 0.0;
						this.frame.Y = this.frame.Y + num;
						if (this.frame.Y / num >= Main.npcFrameCount[this.type])
						{
							this.frame.Y = 0;
						}
					}
				}
			}
			if (this.type == 72)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter >= 3.0)
				{
					this.frameCounter = 0.0;
					this.frame.Y = this.frame.Y + num;
					if (this.frame.Y / num >= Main.npcFrameCount[this.type])
					{
						this.frame.Y = 0;
					}
				}
			}
			if (this.type == 65)
			{
				this.spriteDirection = this.direction;
				this.frameCounter += 1.0;
				if (this.wet)
				{
					if (this.frameCounter < 6.0)
					{
						this.frame.Y = 0;
					}
					else if (this.frameCounter < 12.0)
					{
						this.frame.Y = num;
					}
					else if (this.frameCounter < 18.0)
					{
						this.frame.Y = num * 2;
					}
					else if (this.frameCounter < 24.0)
					{
						this.frame.Y = num * 3;
					}
					else
					{
						this.frameCounter = 0.0;
					}
				}
			}
			if (this.type == 48 || this.type == 49 || this.type == 51 || this.type == 60 || this.type == 82 || this.type == 93 || this.type == 137)
			{
				if (this.velocity.X > 0f)
				{
					this.spriteDirection = 1;
				}
				if (this.velocity.X < 0f)
				{
					this.spriteDirection = -1;
				}
				this.rotation = this.velocity.X * 0.1f;
				this.frameCounter += 1.0;
				if (this.frameCounter >= 6.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * 4)
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 42)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 2.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 4.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 6.0)
				{
					this.frame.Y = num * 2;
				}
				else if (this.frameCounter < 8.0)
				{
					this.frame.Y = num;
				}
				else
				{
					this.frameCounter = 0.0;
				}
			}
			if (this.type == 43 || this.type == 56)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 6.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 18.0)
				{
					this.frame.Y = num * 2;
				}
				else if (this.frameCounter < 24.0)
				{
					this.frame.Y = num;
				}
				if (this.frameCounter == 23.0)
				{
					this.frameCounter = 0.0;
				}
			}
			if (this.type == 115)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 3.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 6.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num * 2;
				}
				else if (this.frameCounter < 15.0)
				{
					this.frame.Y = num;
				}
				if (this.frameCounter == 15.0)
				{
					this.frameCounter = 0.0;
				}
			}
			if (this.type == 101)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter > 6.0)
				{
					this.frame.Y = this.frame.Y + num * 2;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y > num * 2)
				{
					this.frame.Y = 0;
				}
			}
			if (this.type == 17 || this.type == 18 || this.type == 19 || this.type == 20 || this.type == 22 || this.type == 142 || this.type == 38 || this.type == 26 || this.type == 27 || this.type == 28 || this.type == 31 || this.type == 21 || this.type == 44 || this.type == 54 || this.type == 37 || this.type == 73 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 104 || this.type == 107 || this.type == 108 || this.type == 120 || this.type == 124 || this.type == 140)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
					if (this.velocity.X == 0f)
					{
						if (this.type == 140)
						{
							this.frame.Y = num;
							this.frameCounter = 0.0;
						}
						else
						{
							this.frame.Y = 0;
							this.frameCounter = 0.0;
						}
					}
					else
					{
						this.frameCounter += (double)(Math.Abs(this.velocity.X) * 2f);
						this.frameCounter += 1.0;
						if (this.frameCounter > 6.0)
						{
							this.frame.Y = this.frame.Y + num;
							this.frameCounter = 0.0;
						}
						if (this.frame.Y / num >= Main.npcFrameCount[this.type])
						{
							this.frame.Y = num * 2;
						}
					}
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = num;
					if (this.type == 21 || this.type == 31 || this.type == 44 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 120 || this.type == 140)
					{
						this.frame.Y = 0;
					}
				}
			}
			else if (this.type == 110)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
					if (this.ai[2] > 0f)
					{
						this.spriteDirection = this.direction;
						this.frame.Y = num * (int)this.ai[2];
						this.frameCounter = 0.0;
					}
					else
					{
						if (this.frame.Y < num * 6)
						{
							this.frame.Y = num * 6;
						}
						this.frameCounter += (double)(Math.Abs(this.velocity.X) * 2f);
						this.frameCounter += (double)this.velocity.X;
						if (this.frameCounter > 6.0)
						{
							this.frame.Y = this.frame.Y + num;
							this.frameCounter = 0.0;
						}
						if (this.frame.Y / num >= Main.npcFrameCount[this.type])
						{
							this.frame.Y = num * 6;
						}
					}
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
			}
			if (this.type == 111)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
					if (this.ai[2] > 0f)
					{
						this.spriteDirection = this.direction;
						this.frame.Y = num * ((int)this.ai[2] - 1);
						this.frameCounter = 0.0;
					}
					else
					{
						if (this.frame.Y < num * 7)
						{
							this.frame.Y = num * 7;
						}
						this.frameCounter += (double)(Math.Abs(this.velocity.X) * 2f);
						this.frameCounter += (double)(this.velocity.X * 1.3f);
						if (this.frameCounter > 6.0)
						{
							this.frame.Y = this.frame.Y + num;
							this.frameCounter = 0.0;
						}
						if (this.frame.Y / num >= Main.npcFrameCount[this.type])
						{
							this.frame.Y = num * 7;
						}
					}
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * 6;
				}
			}
			else if (this.type == 3 || this.type == 52 || this.type == 53 || this.type == 132)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
				}
				if (this.velocity.Y != 0f || (this.direction == -1 && this.velocity.X > 0f) || (this.direction == 1 && this.velocity.X < 0f))
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * 2;
				}
				else if (this.velocity.X == 0f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
				else
				{
					this.frameCounter += (double)Math.Abs(this.velocity.X);
					if (this.frameCounter < 8.0)
					{
						this.frame.Y = 0;
					}
					else if (this.frameCounter < 16.0)
					{
						this.frame.Y = num;
					}
					else if (this.frameCounter < 24.0)
					{
						this.frame.Y = num * 2;
					}
					else if (this.frameCounter < 32.0)
					{
						this.frame.Y = num;
					}
					else
					{
						this.frameCounter = 0.0;
					}
				}
			}
			else if (this.type == 46 || this.type == 47)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
					if (this.velocity.X == 0f)
					{
						this.frame.Y = 0;
						this.frameCounter = 0.0;
					}
					else
					{
						this.frameCounter += (double)(Math.Abs(this.velocity.X) * 1f);
						this.frameCounter += 1.0;
						if (this.frameCounter > 6.0)
						{
							this.frame.Y = this.frame.Y + num;
							this.frameCounter = 0.0;
						}
						if (this.frame.Y / num >= Main.npcFrameCount[this.type])
						{
							this.frame.Y = 0;
						}
					}
				}
				else if (this.velocity.Y < 0f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * 4;
				}
				else if (this.velocity.Y > 0f)
				{
					this.frameCounter = 0.0;
					this.frame.Y = num * 6;
				}
			}
			else if (this.type == 4 || this.type == 125 || this.type == 126)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 7.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 14.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 21.0)
				{
					this.frame.Y = num * 2;
				}
				else
				{
					this.frameCounter = 0.0;
					this.frame.Y = 0;
				}
				if (this.ai[0] > 1f)
				{
					this.frame.Y = this.frame.Y + num * 3;
				}
			}
			else if (this.type == 5)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter >= 8.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			else if (this.type == 94)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter < 6.0)
				{
					this.frame.Y = 0;
				}
				else if (this.frameCounter < 12.0)
				{
					this.frame.Y = num;
				}
				else if (this.frameCounter < 18.0)
				{
					this.frame.Y = num * 2;
				}
				else
				{
					this.frame.Y = num;
					if (this.frameCounter >= 23.0)
					{
						this.frameCounter = 0.0;
					}
				}
			}
			else if (this.type == 6)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter >= 8.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
			else if (this.type == 24)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
				}
				if (this.ai[1] > 0f)
				{
					if (this.frame.Y < 4)
					{
						this.frameCounter = 0.0;
					}
					this.frameCounter += 1.0;
					if (this.frameCounter <= 4.0)
					{
						this.frame.Y = num * 4;
					}
					else if (this.frameCounter <= 8.0)
					{
						this.frame.Y = num * 5;
					}
					else if (this.frameCounter <= 12.0)
					{
						this.frame.Y = num * 6;
					}
					else if (this.frameCounter <= 16.0)
					{
						this.frame.Y = num * 7;
					}
					else if (this.frameCounter <= 20.0)
					{
						this.frame.Y = num * 8;
					}
					else
					{
						this.frame.Y = num * 9;
						this.frameCounter = 100.0;
					}
				}
				else
				{
					this.frameCounter += 1.0;
					if (this.frameCounter <= 4.0)
					{
						this.frame.Y = 0;
					}
					else if (this.frameCounter <= 8.0)
					{
						this.frame.Y = num;
					}
					else if (this.frameCounter <= 12.0)
					{
						this.frame.Y = num * 2;
					}
					else
					{
						this.frame.Y = num * 3;
						if (this.frameCounter >= 16.0)
						{
							this.frameCounter = 0.0;
						}
					}
				}
			}
			else if (this.type == 29 || this.type == 32 || this.type == 45)
			{
				if (this.velocity.Y == 0f)
				{
					if (this.direction == 1)
					{
						this.spriteDirection = 1;
					}
					if (this.direction == -1)
					{
						this.spriteDirection = -1;
					}
				}
				this.frame.Y = 0;
				if (this.velocity.Y != 0f)
				{
					this.frame.Y = this.frame.Y + num;
				}
				else if (this.ai[1] > 0f)
				{
					this.frame.Y = this.frame.Y + num * 2;
				}
			}
			if (this.type == 34)
			{
				this.frameCounter += 1.0;
				if (this.frameCounter >= 4.0)
				{
					this.frame.Y = this.frame.Y + num;
					this.frameCounter = 0.0;
				}
				if (this.frame.Y >= num * Main.npcFrameCount[this.type])
				{
					this.frame.Y = 0;
				}
			}
		}

		public static string FindCNames(string Ename)
		{
			string[] array = new string[]
			{
				"Molly",
				"Amy",
				"Claire",
				"Emily",
				"Katie",
				"Madeline",
				"Katelyn",
				"Emma",
				"Abigail",
				"Carly",
				"Jenna",
				"Heather",
				"Katherine",
				"Caitlin",
				"Kaitlin",
				"Holly",
				"Kaitlyn",
				"Hannah",
				"Kathryn",
				"Lorraine",
				"Helen",
				"Kayla",
				"Allison",
				"Shayna",
				"Korrie",
				"Ginger",
				"Brooke",
				"Jenny",
				"Autumn",
				"Nancy",
				"Ella",
				"Kayla",
				"Beth",
				"Sophia",
				"Marshanna",
				"Lauren",
				"Trisha",
				"Shirlena",
				"Sheena",
				"Ellen",
				"Amy",
				"Dawn",
				"Susana",
				"Meredith",
				"Selene",
				"Terra",
				"Sally",
				"DeShawn",
				"DeAndre",
				"Marquis",
				"Darnell",
				"Terrell",
				"Malik",
				"Trevon",
				"Tyrone",
				"Willie",
				"Dominique",
				"Demetrius",
				"Reginald",
				"Jamal",
				"Maurice",
				"Jalen",
				"Darius",
				"Xavier",
				"Terrance",
				"Andre",
				"Dante",
				"Brimst",
				"Bronson",
				"Darryl",
				"Jake",
				"Connor",
				"Tanner",
				"Wyatt",
				"Cody",
				"Dustin",
				"Luke",
				"Jack",
				"Scott",
				"Logan",
				"Cole",
				"Lucas",
				"Bradley",
				"Jacob",
				"Garrett",
				"Dylan",
				"Maxwell",
				"Steve",
				"Brett",
				"Andrew",
				"Harley",
				"Kyle",
				"Jake",
				"Ryan",
				"Jeffrey",
				"Seth",
				"Marty",
				"Brandon",
				"Zach",
				"Jeff",
				"Daniel",
				"Trent",
				"Kevin",
				"Brian",
				"Colin",
				"Alalia",
				"Alalia",
				"Alura",
				"Ariella",
				"Caelia",
				"Calista",
				"Chryseis",
				"Emerenta",
				"Elysia",
				"Evvie",
				"Faye",
				"Felicitae",
				"Lunette",
				"Nata",
				"Nissa",
				"Tatiana",
				"Rosalva",
				"Shea",
				"Tania",
				"Isis",
				"Celestia",
				"Xylia",
				"Dolbere",
				"Bazdin",
				"Durim",
				"Tordak",
				"Garval",
				"Morthal",
				"Oten",
				"Dolgen",
				"Gimli",
				"Gimut",
				"Duerthen",
				"Beldin",
				"Jarut",
				"Ovbere",
				"Norkas",
				"Dolgrim",
				"Boften",
				"Norsun",
				"Dias",
				"Fikod",
				"Urist",
				"Darur",
				"Dalamar",
				"Dulais",
				"Elric",
				"Arddun",
				"Maelor",
				"Leomund",
				"Hirael",
				"Gwentor",
				"Greum",
				"Gearroid",
				"Fizban",
				"Ningauble",
				"Seonag",
				"Sargon",
				"Merlyn",
				"Magius",
				"Berwyn",
				"Arwyn",
				"Alasdair",
				"Tagar",
				"Xanadu",
				"Alfred",
				"Barney",
				"Calvin",
				"Edmund",
				"Edwin",
				"Eugene",
				"Frank",
				"Frederick",
				"Gilbert",
				"Gus",
				"Wilbur",
				"Seymour",
				"Louis",
				"Humphrey",
				"Harold",
				"Milton",
				"Mortimer",
				"Howard",
				"Walter",
				"Finn",
				"Isacc",
				"Joseph",
				"Ralph",
				"Sebastian",
				"Rupert",
				"Clive",
				"Nigel",
				"Mervyn",
				"Cedric",
				"Pip",
				"Cyril",
				"Fitz",
				"Lloyd",
				"Arthur",
				"Rodney",
				"Graham",
				"Edward",
				"Alfred",
				"Edmund",
				"Henry",
				"Herald",
				"Roland",
				"Lincoln",
				"Lloyd",
				"Edgar",
				"Eustace",
				"Rodrick",
				"Grodax",
				"Sarx",
				"Xon",
				"Mrunok",
				"Nuxatk",
				"Tgerd",
				"Darz",
				"Smador",
				"Stazen",
				"Mobart",
				"Knogs",
				"Tkanus",
				"Negurk",
				"Nort",
				"Durnok",
				"Trogem",
				"Stezom",
				"Gnudar",
				"Ragz",
				"Fahd",
				"Xanos",
				"Arback",
				"Fjell",
				"Dalek",
				"Knub"
			};
			string[] array2 = new string[]
			{
				"茉莉",
				"艾米",
				"克莱尔",
				"艾米丽",
				"凯蒂",
				"玛德琳",
				"凯特琳",
				"艾玛",
				"丫头",
				"卡莉",
				"珍娜",
				"海瑟",
				"凯瑟琳",
				"凯琳",
				"凯特琳",
				"藿莉",
				"卡特琳娜",
				"汉娜",
				"凯斯琳",
				"萝琳",
				"海伦",
				"凯拉",
				"艾莉森",
				"夏娜",
				"科琳",
				"金卓",
				"波姬",
				"珍妮",
				"秋菊",
				"兰茜",
				"艾拉",
				"凯勒",
				"贝丝",
				"索菲娅",
				"玛姗娜",
				"劳伦",
				"秋莎",
				"姗拉娜",
				"珊娜",
				"爱伦",
				"艾咪",
				"桐恩",
				"苏珊娜",
				"梅瑞狄斯",
				"塞勒涅",
				"泰拉",
				"莎莉",
				"德肖恩",
				"德安卓",
				"马奎斯",
				"达尼尔",
				"泰瑞尔",
				"马利克",
				"特雷文",
				"泰隆",
				"威利",
				"多米尼克",
				"德米狄斯",
				"雷金纳德",
				"贾马尔",
				"莫里斯",
				"杰伦",
				"戴瑞斯",
				"赛维尔",
				"特伦斯",
				"安卓",
				"但丁",
				"布雷斯塔",
				"布朗森",
				"达里尔",
				"爵克",
				"康纳",
				"特纳",
				"怀亚特",
				"科迪",
				"达斯汀",
				"鲁克",
				"杰克",
				"斯科特",
				"洛根",
				"科尔",
				"卢卡斯",
				"布拉德利",
				"雅各布",
				"加勒特",
				"迪伦",
				"麦克斯韦",
				"史蒂夫",
				"布雷特",
				"安德鲁",
				"哈利",
				"凯尔",
				"杰弗逊",
				"赖安",
				"杰弗里",
				"塞斯",
				"马蒂",
				"布兰顿",
				"扎克",
				"杰夫",
				"丹尼尔",
				"特伦特",
				"凯文",
				"布莱恩",
				"科林",
				"奥拉利亚",
				"奥拉利亚",
				"奥萝拉",
				"奥莱拉",
				"凯莉娅",
				"卡莉斯塔",
				"克律塞伊丝",
				"伊莫恩塔",
				"伊莱西娅",
				"艾薇",
				"菲伊",
				"菲勒西缇",
				"露奈特",
				"娜塔亚",
				"妮莎",
				"塔狄安娜",
				"罗莎瓦",
				"菲儿",
				"塔尼娅",
				"依希斯",
				"塞涅斯提亚",
				"赛莉娅",
				"多尔贝里",
				"贝斯汀",
				"多瑞姆",
				"托达克",
				"加瓦尔",
				"莫萨尔",
				"奥汀",
				"多尔金",
				"金雳",
				"吉姆特",
				"杜尔森",
				"贝汀",
				"加鲁特",
				"欧贝瑞",
				"诺卡斯",
				"多利姆",
				"贝弗特",
				"诺桑",
				"戴阿斯",
				"费克德",
				"瑞斯特",
				"达鲁尔",
				"达拉玛",
				"杜莱斯",
				"埃瑞克",
				"安度因",
				"梅勒",
				"李奥蒙多",
				"海拉尔",
				"葛文特",
				"格瑞姆",
				"格尔罗德",
				"费孜本",
				"凌霄",
				"西奥纳格",
				"萨尔贡",
				"梅林",
				"梅吉斯",
				"波尔温",
				"艾尔文",
				"阿拉斯戴尔",
				"塔加",
				"穆迪",
				"艾尔弗雷德",
				"巴尼",
				"卡尔文",
				"埃德蒙",
				"埃德温",
				"尤金",
				"弗兰克",
				"弗雷德里克",
				"吉尔伯特",
				"格斯",
				"韦伯",
				"西摩",
				"路易斯",
				"亨弗利",
				"哈洛德",
				"弥尔顿",
				"莫蒂默",
				"霍华德",
				"沃尔特",
				"费恩",
				"伊萨克",
				"约瑟夫",
				"拉尔夫",
				"塞巴斯蒂安",
				"鲁伯特",
				"克莱夫",
				"奈杰尔",
				"默文",
				"赛狄克",
				"匹普",
				"西里尔",
				"菲茨",
				"洛依德",
				"亚瑟",
				"罗德尼",
				"格雷姆",
				"爱德华",
				"阿尔弗雷德",
				"艾德姆",
				"亨利",
				"海洛德",
				"罗纳德",
				"林肯",
				"劳埃德",
				"埃德加",
				"尤斯塔斯",
				"罗德里克",
				"格罗达克",
				"萨科斯",
				"埃克松",
				"姆诺克",
				"诺科萨缇",
				"特德",
				"达兹",
				"司马铎",
				"斯塔泽",
				"莫巴特",
				"诺兹",
				"卡诺斯",
				"奈古克",
				"诺尔特",
				"杜诺特",
				"罗格姆",
				"斯泰龙",
				"努达",
				"拉兹",
				"法德",
				"艾克萨罗",
				"三三",
				"摩卡",
				"索亚",
				"凯尔本"
			};
			string result;
			for (int i = 0; i < 242; i++)
			{
				if (array[i] == Ename)
				{
					string text = array2[i];
					result = text;
					return result;
				}
			}
			result = Ename;
			return result;
		}

		public void TargetClosest(bool faceTarget = true)
		{
			float num = -1f;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && !Main.player[i].dead && (num == -1f || Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - this.position.Y + (float)(this.height / 2)) < num))
				{
					num = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - this.position.Y + (float)(this.height / 2));
					this.target = i;
				}
			}
			if (this.target < 0 || this.target >= 255)
			{
				this.target = 0;
			}
			this.targetRect = new Rectangle((int)Main.player[this.target].position.X, (int)Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
			if (Main.player[this.target].dead)
			{
				faceTarget = false;
			}
			if (faceTarget)
			{
				this.direction = 1;
				if ((float)(this.targetRect.X + this.targetRect.Width / 2) < this.position.X + (float)(this.width / 2))
				{
					this.direction = -1;
				}
				this.directionY = 1;
				if ((float)(this.targetRect.Y + this.targetRect.Height / 2) < this.position.Y + (float)(this.height / 2))
				{
					this.directionY = -1;
				}
			}
			if (this.confused)
			{
				this.direction *= -1;
			}
			if ((this.direction != this.oldDirection || this.directionY != this.oldDirectionY || this.target != this.oldTarget) && !this.collideX && !this.collideY)
			{
				this.netUpdate = true;
			}
		}

		public void CheckActive()
		{
			if (this.active)
			{
				if (this.type != 8 && this.type != 9 && this.type != 11 && this.type != 12 && this.type != 14 && this.type != 15 && this.type != 40 && this.type != 41 && this.type != 96 && this.type != 97 && this.type != 99 && this.type != 100 && (this.type <= 87 || this.type > 92) && this.type != 118 && this.type != 119 && this.type != 113 && this.type != 114 && this.type != 115)
				{
					if (this.type < 134 || this.type > 136)
					{
						if (this.townNPC)
						{
							Rectangle rectangle = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)NPC.townRangeX), (int)(this.position.Y + (float)(this.height / 2) - (float)NPC.townRangeY), NPC.townRangeX * 2, NPC.townRangeY * 2);
							for (int i = 0; i < 255; i++)
							{
								if (Main.player[i].active && rectangle.Intersects(new Rectangle((int)Main.player[i].position.X, (int)Main.player[i].position.Y, Main.player[i].width, Main.player[i].height)))
								{
									Main.player[i].townNPCs += this.npcSlots;
								}
							}
						}
						else
						{
							bool flag = false;
							Rectangle rectangle2 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)NPC.activeRangeX), (int)(this.position.Y + (float)(this.height / 2) - (float)NPC.activeRangeY), NPC.activeRangeX * 2, NPC.activeRangeY * 2);
							Rectangle rectangle3 = new Rectangle((int)((double)(this.position.X + (float)(this.width / 2)) - (double)NPC.sWidth * 0.5 - (double)this.width), (int)((double)(this.position.Y + (float)(this.height / 2)) - (double)NPC.sHeight * 0.5 - (double)this.height), NPC.sWidth + this.width * 2, NPC.sHeight + this.height * 2);
							for (int j = 0; j < 255; j++)
							{
								if (Main.player[j].active)
								{
									if (rectangle2.Intersects(new Rectangle((int)Main.player[j].position.X, (int)Main.player[j].position.Y, Main.player[j].width, Main.player[j].height)))
									{
										flag = true;
										if (this.type != 25 && this.type != 30 && this.type != 33 && this.lifeMax > 0)
										{
											Main.player[j].activeNPCs += this.npcSlots;
										}
									}
									if (rectangle3.Intersects(new Rectangle((int)Main.player[j].position.X, (int)Main.player[j].position.Y, Main.player[j].width, Main.player[j].height)))
									{
										this.timeLeft = NPC.activeTime;
									}
									if (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 87)
									{
										flag = true;
									}
									if (this.boss || this.type == 35 || this.type == 36 || this.type == 127 || this.type == 128 || this.type == 129 || this.type == 130 || this.type == 131)
									{
										flag = true;
									}
								}
							}
							this.timeLeft--;
							if (this.timeLeft <= 0)
							{
								flag = false;
							}
							if (!flag && Main.netMode != 1)
							{
								NPC.noSpawnCycle = true;
								this.active = false;
								if (Main.netMode == 2)
								{
									this.netSkip = -1;
									this.life = 0;
									NetMessage.SendData(23, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
								}
								if (this.aiStyle == 6)
								{
									for (int k = (int)this.ai[0]; k > 0; k = (int)Main.npc[k].ai[0])
									{
										if (Main.npc[k].active)
										{
											Main.npc[k].active = false;
											if (Main.netMode == 2)
											{
												Main.npc[k].life = 0;
												Main.npc[k].netSkip = -1;
												NetMessage.SendData(23, -1, -1, "", k, 0f, 0f, 0f, 0);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static void SpawnNPC()
		{
			if (NPC.noSpawnCycle)
			{
				NPC.noSpawnCycle = false;
			}
			else
			{
				bool flag = false;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						num3++;
					}
				}
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && !Main.player[j].dead)
					{
						bool flag2 = false;
						bool flag3 = false;
						bool flag4 = false;
						if (Main.player[j].active && Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && (double)Main.player[j].position.Y < Main.worldSurface * 16.0 + (double)NPC.sHeight)
						{
							int num4 = 3000;
							if ((double)Main.player[j].position.X > Main.invasionX * 16.0 - (double)num4 && (double)Main.player[j].position.X < Main.invasionX * 16.0 + (double)num4)
							{
								flag3 = true;
							}
						}
						bool flag5 = false;
						NPC.spawnRate = NPC.defaultSpawnRate;
						NPC.maxSpawns = NPC.defaultMaxSpawns;
						if (Main.hardMode)
						{
							NPC.spawnRate = (int)((double)NPC.defaultSpawnRate * 0.9);
							NPC.maxSpawns = NPC.defaultMaxSpawns + 1;
						}
						if (Main.player[j].position.Y > (float)((Main.maxTilesY - 200) * 16))
						{
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 2f);
						}
						else if ((double)Main.player[j].position.Y > Main.rockLayer * 16.0 + (double)NPC.sHeight)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.4);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.9f);
						}
						else if ((double)Main.player[j].position.Y > Main.worldSurface * 16.0 + (double)NPC.sHeight)
						{
							if (Main.hardMode)
							{
								NPC.spawnRate = (int)((double)NPC.spawnRate * 0.45);
								NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.8f);
							}
							else
							{
								NPC.spawnRate = (int)((double)NPC.spawnRate * 0.5);
								NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.7f);
							}
						}
						else if (!Main.dayTime)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.6);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.3f);
							if (Main.bloodMoon)
							{
								NPC.spawnRate = (int)((double)NPC.spawnRate * 0.3);
								NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.8f);
							}
						}
						if (Main.player[j].zoneDungeon)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.4);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.7f);
						}
						else if (Main.player[j].zoneJungle)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.4);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.5f);
						}
						else if (Main.player[j].zoneEvil)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.65);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.3f);
						}
						else if (Main.player[j].zoneMeteor)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.4);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.1f);
						}
						if (Main.player[j].zoneHoly && (double)Main.player[j].position.Y > Main.rockLayer * 16.0 + (double)NPC.sHeight)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.65);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.3f);
						}
						if (Main.wof >= 0 && Main.player[j].position.Y > (float)((Main.maxTilesY - 200) * 16))
						{
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 0.3f);
							NPC.spawnRate *= 3;
						}
						if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.2)
						{
							NPC.spawnRate = (int)((float)NPC.spawnRate * 0.6f);
						}
						else if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.4)
						{
							NPC.spawnRate = (int)((float)NPC.spawnRate * 0.7f);
						}
						else if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.6)
						{
							NPC.spawnRate = (int)((float)NPC.spawnRate * 0.8f);
						}
						else if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.8)
						{
							NPC.spawnRate = (int)((float)NPC.spawnRate * 0.9f);
						}
						if ((double)(Main.player[j].position.Y * 16f) > (Main.worldSurface + Main.rockLayer) / 2.0 || Main.player[j].zoneEvil)
						{
							if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.2)
							{
								NPC.spawnRate = (int)((float)NPC.spawnRate * 0.7f);
							}
							else if ((double)Main.player[j].activeNPCs < (double)NPC.maxSpawns * 0.4)
							{
								NPC.spawnRate = (int)((float)NPC.spawnRate * 0.9f);
							}
						}
						if (Main.player[j].inventory[Main.player[j].selectedItem].type == 148)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.75);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 1.5f);
						}
						if (Main.player[j].enemySpawns)
						{
							NPC.spawnRate = (int)((double)NPC.spawnRate * 0.5);
							NPC.maxSpawns = (int)((float)NPC.maxSpawns * 2f);
						}
						if ((double)NPC.spawnRate < (double)NPC.defaultSpawnRate * 0.1)
						{
							NPC.spawnRate = (int)((double)NPC.defaultSpawnRate * 0.1);
						}
						if (NPC.maxSpawns > NPC.defaultMaxSpawns * 3)
						{
							NPC.maxSpawns = NPC.defaultMaxSpawns * 3;
						}
						if (flag3)
						{
							NPC.maxSpawns = (int)((double)NPC.defaultMaxSpawns * (2.0 + 0.3 * (double)num3));
							NPC.spawnRate = 20;
						}
						if (Main.player[j].zoneDungeon && !NPC.downedBoss3)
						{
							NPC.spawnRate = 10;
						}
						bool flag6 = false;
						if (!flag3 && (!Main.bloodMoon || Main.dayTime) && !Main.player[j].zoneDungeon && !Main.player[j].zoneEvil && !Main.player[j].zoneMeteor)
						{
							if (Main.player[j].townNPCs == 1f)
							{
								flag2 = true;
								if (Main.rand.Next(3) <= 1)
								{
									flag6 = true;
									NPC.maxSpawns = (int)((double)((float)NPC.maxSpawns) * 0.6);
								}
								else
								{
									NPC.spawnRate = (int)((float)NPC.spawnRate * 2f);
								}
							}
							else if (Main.player[j].townNPCs == 2f)
							{
								flag2 = true;
								if (Main.rand.Next(3) == 0)
								{
									flag6 = true;
									NPC.maxSpawns = (int)((double)((float)NPC.maxSpawns) * 0.6);
								}
								else
								{
									NPC.spawnRate = (int)((float)NPC.spawnRate * 3f);
								}
							}
							else if (Main.player[j].townNPCs >= 3f)
							{
								flag2 = true;
								flag6 = true;
								NPC.maxSpawns = (int)((double)((float)NPC.maxSpawns) * 0.6);
							}
						}
						if (Main.player[j].active && !Main.player[j].dead && Main.player[j].activeNPCs < (float)NPC.maxSpawns && Main.rand.Next(NPC.spawnRate) == 0)
						{
							int num5 = (int)(Main.player[j].position.X / 16f) - NPC.spawnRangeX;
							int num6 = (int)(Main.player[j].position.X / 16f) + NPC.spawnRangeX;
							int num7 = (int)(Main.player[j].position.Y / 16f) - NPC.spawnRangeY;
							int num8 = (int)(Main.player[j].position.Y / 16f) + NPC.spawnRangeY;
							int num9 = (int)(Main.player[j].position.X / 16f) - NPC.safeRangeX;
							int num10 = (int)(Main.player[j].position.X / 16f) + NPC.safeRangeX;
							int num11 = (int)(Main.player[j].position.Y / 16f) - NPC.safeRangeY;
							int num12 = (int)(Main.player[j].position.Y / 16f) + NPC.safeRangeY;
							if (num5 < 0)
							{
								num5 = 0;
							}
							if (num6 > Main.maxTilesX)
							{
								num6 = Main.maxTilesX;
							}
							if (num7 < 0)
							{
								num7 = 0;
							}
							if (num8 > Main.maxTilesY)
							{
								num8 = Main.maxTilesY;
							}
							int k = 0;
							while (k < 50)
							{
								int num13 = Main.rand.Next(num5, num6);
								int num14 = Main.rand.Next(num7, num8);
								if (Main.tile[num13, num14].active && Main.tileSolid[(int)Main.tile[num13, num14].type])
								{
									goto IL_ECD;
								}
								if (!Main.wallHouse[(int)Main.tile[num13, num14].wall])
								{
									if (!flag3 && (double)num14 < Main.worldSurface * 0.34999999403953552 && !flag6 && ((double)num13 < (double)Main.maxTilesX * 0.45 || (double)num13 > (double)Main.maxTilesX * 0.55 || Main.hardMode))
									{
										byte b = Main.tile[num13, num14].type;
										num = num13;
										num2 = num14;
										flag5 = true;
										flag = true;
									}
									else if (!flag3 && (double)num14 < Main.worldSurface * 0.44999998807907104 && !flag6 && Main.hardMode && Main.rand.Next(10) == 0)
									{
										byte b2 = Main.tile[num13, num14].type;
										num = num13;
										num2 = num14;
										flag5 = true;
										flag = true;
									}
									else
									{
										int l = num14;
										while (l < Main.maxTilesY)
										{
											if (Main.tile[num13, l].active && Main.tileSolid[(int)Main.tile[num13, l].type])
											{
												if (num13 < num9 || num13 > num10 || l < num11 || l > num12)
												{
													byte b3 = Main.tile[num13, l].type;
													num = num13;
													num2 = l;
													flag5 = true;
													break;
												}
												break;
											}
											else
											{
												l++;
											}
										}
									}
									if (!flag5)
									{
										goto IL_ECD;
									}
									int num15 = num - NPC.spawnSpaceX / 2;
									int num16 = num + NPC.spawnSpaceX / 2;
									int num17 = num2 - NPC.spawnSpaceY;
									int num18 = num2;
									if (num15 < 0)
									{
										flag5 = false;
									}
									if (num16 > Main.maxTilesX)
									{
										flag5 = false;
									}
									if (num17 < 0)
									{
										flag5 = false;
									}
									if (num18 > Main.maxTilesY)
									{
										flag5 = false;
									}
									if (flag5)
									{
										for (int m = num15; m < num16; m++)
										{
											for (int n = num17; n < num18; n++)
											{
												if (Main.tile[m, n].active && Main.tileSolid[(int)Main.tile[m, n].type])
												{
													flag5 = false;
													break;
												}
												if (Main.tile[m, n].lava)
												{
													flag5 = false;
													break;
												}
											}
										}
										goto IL_ECD;
									}
									goto IL_ECD;
								}
								IL_EC5:
								k++;
								continue;
								IL_ECD:
								if (!flag5 && !flag5)
								{
									goto IL_EC5;
								}
								break;
							}
						}
						if (flag5)
						{
							Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
							for (int num19 = 0; num19 < 255; num19++)
							{
								if (Main.player[num19].active)
								{
									Rectangle rectangle2 = new Rectangle((int)(Main.player[num19].position.X + (float)(Main.player[num19].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[num19].position.Y + (float)(Main.player[num19].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
									if (rectangle.Intersects(rectangle2))
									{
										flag5 = false;
									}
								}
							}
						}
						if (flag5)
						{
							if (Main.player[j].zoneDungeon && (!Main.tileDungeon[(int)Main.tile[num, num2].type] || Main.tile[num, num2 - 1].wall == 0))
							{
								flag5 = false;
							}
							if (Main.tile[num, num2 - 1].liquid > 0 && Main.tile[num, num2 - 2].liquid > 0 && !Main.tile[num, num2 - 1].lava)
							{
								flag4 = true;
							}
						}
						if (flag5)
						{
							int num20 = (int)Main.tile[num, num2].type;
							int num21 = 200;
							if (flag)
							{
								if (Main.hardMode && Main.rand.Next(10) == 0 && !NPC.AnyNPCs(87))
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 87, 1);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 48, 0);
								}
							}
							else if (flag3)
							{
								if (Main.invasionType == 1)
								{
									if (Main.rand.Next(9) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 29, 0);
									}
									else if (Main.rand.Next(5) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 26, 0);
									}
									else if (Main.rand.Next(3) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 111, 0);
									}
									else if (Main.rand.Next(3) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 27, 0);
									}
									else
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 28, 0);
									}
								}
								else if (Main.invasionType == 2)
								{
									if (Main.rand.Next(7) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 145, 0);
									}
									else if (Main.rand.Next(3) == 0)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 143, 0);
									}
									else
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 144, 0);
									}
								}
							}
							else if (flag4 && (num < 250 || num > Main.maxTilesX - 250) && num20 == 53 && (double)num2 < Main.rockLayer)
							{
								if (Main.rand.Next(8) == 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 65, 0);
								}
								if (Main.rand.Next(3) == 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 67, 0);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 64, 0);
								}
							}
							else if (flag4 && (((double)num2 > Main.rockLayer && Main.rand.Next(2) == 0) || num20 == 60))
							{
								if (Main.hardMode && Main.rand.Next(3) > 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 102, 0);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 58, 0);
								}
							}
							else if (flag4 && (double)num2 > Main.worldSurface && Main.rand.Next(3) == 0)
							{
								if (Main.hardMode)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 103, 0);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 63, 0);
								}
							}
							else if (flag4 && Main.rand.Next(4) == 0)
							{
								if (Main.player[j].zoneEvil)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 57, 0);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0);
								}
							}
							else if (NPC.downedGoblins && Main.rand.Next(20) == 0 && !flag4 && (double)num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !NPC.savedGoblin && !NPC.AnyNPCs(105))
							{
								NPC.NewNPC(num * 16 + 8, num2 * 16, 105, 0);
							}
							else if (Main.hardMode && Main.rand.Next(20) == 0 && !flag4 && (double)num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !NPC.savedWizard && !NPC.AnyNPCs(106))
							{
								NPC.NewNPC(num * 16 + 8, num2 * 16, 106, 0);
							}
							else if (flag6)
							{
								if (flag4)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0);
								}
								else
								{
									if (num20 != 2 && num20 != 109 && num20 != 147 && (double)num2 <= Main.worldSurface)
									{
										break;
									}
									if (Main.rand.Next(2) == 0 && (double)num2 <= Main.worldSurface)
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0);
									}
									else
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 46, 0);
									}
								}
							}
							else if (Main.player[j].zoneDungeon)
							{
								if (!NPC.downedBoss3)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 68, 0);
								}
								else if (!NPC.savedMech && Main.rand.Next(5) == 0 && !flag4 && !NPC.AnyNPCs(123) && (double)num2 > Main.rockLayer)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 123, 0);
								}
								else if (Main.rand.Next(37) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 71, 0);
								}
								else if (Main.rand.Next(4) == 0 && !NPC.NearSpikeBall(num, num2))
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 70, 0);
								}
								else if (Main.rand.Next(15) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 72, 0);
								}
								else if (Main.rand.Next(9) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 34, 0);
								}
								else if (Main.rand.Next(7) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 32, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 31, 0);
									if (Main.rand.Next(4) == 0)
									{
										Main.npc[num21].SetDefaults("Big Boned");
									}
									else if (Main.rand.Next(5) == 0)
									{
										Main.npc[num21].SetDefaults("Short Bones");
									}
								}
							}
							else if (Main.player[j].zoneMeteor)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 23, 0);
							}
							else if (Main.player[j].zoneEvil && Main.rand.Next(65) == 0)
							{
								if (Main.hardMode && Main.rand.Next(4) != 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 98, 1);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 7, 1);
								}
							}
							else if (Main.hardMode && (double)num2 > Main.worldSurface && Main.rand.Next(75) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 85, 0);
							}
							else if (Main.hardMode && Main.tile[num, num2 - 1].wall == 2 && Main.rand.Next(20) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 85, 0);
							}
							else if (Main.hardMode && (double)num2 <= Main.worldSurface && !Main.dayTime && (Main.rand.Next(20) == 0 || (Main.rand.Next(5) == 0 && Main.moonPhase == 4)))
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 82, 0);
							}
							else if (num20 == 60 && Main.rand.Next(500) == 0 && !Main.dayTime)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 52, 0);
							}
							else if (num20 == 60 && (double)num2 > (Main.worldSurface + Main.rockLayer) / 2.0)
							{
								if (Main.rand.Next(3) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 43, 0);
									Main.npc[num21].ai[0] = (float)num;
									Main.npc[num21].ai[1] = (float)num2;
									Main.npc[num21].netUpdate = true;
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 42, 0);
									if (Main.rand.Next(4) == 0)
									{
										Main.npc[num21].SetDefaults("Little Stinger");
									}
									else if (Main.rand.Next(4) == 0)
									{
										Main.npc[num21].SetDefaults("Big Stinger");
									}
								}
							}
							else if (num20 == 60 && Main.rand.Next(4) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 51, 0);
							}
							else if (num20 == 60 && Main.rand.Next(8) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 56, 0);
								Main.npc[num21].ai[0] = (float)num;
								Main.npc[num21].ai[1] = (float)num2;
								Main.npc[num21].netUpdate = true;
							}
							else if (Main.hardMode && num20 == 53 && Main.rand.Next(3) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 78, 0);
							}
							else if (Main.hardMode && num20 == 112 && Main.rand.Next(2) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 79, 0);
							}
							else if (Main.hardMode && num20 == 116 && Main.rand.Next(2) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 80, 0);
							}
							else if (Main.hardMode && !flag4 && (double)num2 < Main.rockLayer && (num20 == 116 || num20 == 117 || num20 == 109))
							{
								if (!Main.dayTime && Main.rand.Next(2) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 122, 0);
								}
								else if (Main.rand.Next(10) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 86, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 75, 0);
								}
							}
							else if (!flag2 && Main.hardMode && Main.rand.Next(50) == 0 && !flag4 && (double)num2 >= Main.rockLayer && (num20 == 116 || num20 == 117 || num20 == 109))
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 84, 0);
							}
							else if ((num20 == 22 && Main.player[j].zoneEvil) || num20 == 23 || num20 == 25 || num20 == 112)
							{
								if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(3) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 101, 0);
									Main.npc[num21].ai[0] = (float)num;
									Main.npc[num21].ai[1] = (float)num2;
									Main.npc[num21].netUpdate = true;
								}
								else if (Main.hardMode && Main.rand.Next(3) == 0)
								{
									if (Main.rand.Next(3) == 0)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 121, 0);
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 81, 0);
									}
								}
								else if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(40) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 83, 0);
								}
								else if (Main.hardMode && (Main.rand.Next(2) == 0 || (double)num2 > Main.rockLayer))
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 94, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 6, 0);
									if (Main.rand.Next(3) == 0)
									{
										Main.npc[num21].SetDefaults("Little Eater");
									}
									else if (Main.rand.Next(3) == 0)
									{
										Main.npc[num21].SetDefaults("Big Eater");
									}
								}
							}
							else if ((double)num2 <= Main.worldSurface)
							{
								if (Main.dayTime)
								{
									int num22 = Math.Abs(num - Main.spawnTileX);
									if (num22 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num20 == 2 || num20 == 109 || num20 == 147))
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 46, 0);
									}
									else if (num22 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num20 == 2 || num20 == 109 || num20 == 147))
									{
										NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0);
									}
									else if (num22 > Main.maxTilesX / 3 && num20 == 2 && Main.rand.Next(300) == 0 && !NPC.AnyNPCs(50))
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 50, 0);
									}
									else if (num20 == 53 && Main.rand.Next(5) == 0 && !flag4)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 69, 0);
									}
									else if (num20 == 53 && !flag4)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 61, 0);
									}
									else if (num22 > Main.maxTilesX / 3 && Main.rand.Next(15) == 0)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 73, 0);
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0);
										if (num20 == 60)
										{
											Main.npc[num21].SetDefaults("Jungle Slime");
										}
										else if (Main.rand.Next(3) == 0 || num22 < 200)
										{
											Main.npc[num21].SetDefaults("Green Slime");
										}
										else if (Main.rand.Next(10) == 0 && num22 > 400)
										{
											Main.npc[num21].SetDefaults("Purple Slime");
										}
									}
								}
								else if (Main.rand.Next(6) == 0 || (Main.moonPhase == 4 && Main.rand.Next(2) == 0))
								{
									if (Main.hardMode && Main.rand.Next(3) == 0)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 133, 0);
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 2, 0);
									}
								}
								else if (Main.hardMode && Main.rand.Next(50) == 0 && Main.bloodMoon && !NPC.AnyNPCs(109))
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 109, 0);
								}
								else if (Main.rand.Next(250) == 0 && Main.bloodMoon)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 53, 0);
								}
								else if (Main.moonPhase == 0 && Main.hardMode && Main.rand.Next(3) != 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 104, 0);
								}
								else if (Main.hardMode && Main.rand.Next(3) == 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 140, 0);
								}
								else if (Main.rand.Next(3) == 0)
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 132, 0);
								}
								else
								{
									NPC.NewNPC(num * 16 + 8, num2 * 16, 3, 0);
								}
							}
							else if ((double)num2 <= Main.rockLayer)
							{
								if (!flag2 && Main.rand.Next(50) == 0)
								{
									if (Main.hardMode)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 95, 1);
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 10, 1);
									}
								}
								else if (Main.hardMode && Main.rand.Next(3) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 140, 0);
								}
								else if (Main.hardMode && Main.rand.Next(4) != 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 141, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0);
									if (Main.rand.Next(5) == 0)
									{
										Main.npc[num21].SetDefaults("Yellow Slime");
									}
									else if (Main.rand.Next(2) == 0)
									{
										Main.npc[num21].SetDefaults("Blue Slime");
									}
									else
									{
										Main.npc[num21].SetDefaults("Red Slime");
									}
								}
							}
							else if (num2 > Main.maxTilesY - 190)
							{
								if (Main.rand.Next(40) == 0 && !NPC.AnyNPCs(39))
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 39, 1);
								}
								else if (Main.rand.Next(14) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 24, 0);
								}
								else if (Main.rand.Next(8) == 0)
								{
									if (Main.rand.Next(7) == 0)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 66, 0);
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 62, 0);
									}
								}
								else if (Main.rand.Next(3) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 59, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 60, 0);
								}
							}
							else if ((num20 == 116 || num20 == 117) && !flag2 && Main.rand.Next(8) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 120, 0);
							}
							else if (!flag2 && Main.rand.Next(75) == 0 && !Main.player[j].zoneHoly)
							{
								if (Main.hardMode)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 95, 1);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 10, 1);
								}
							}
							else if (!Main.hardMode && Main.rand.Next(10) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 16, 0);
							}
							else if (!Main.hardMode && Main.rand.Next(4) == 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0);
								if (Main.player[j].zoneJungle)
								{
									Main.npc[num21].SetDefaults("Jungle Slime");
								}
								else
								{
									Main.npc[num21].SetDefaults("Black Slime");
								}
							}
							else if (Main.rand.Next(2) == 0)
							{
								if ((double)num2 > (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && Main.rand.Next(700) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 45, 0);
								}
								else if (Main.hardMode && Main.rand.Next(10) != 0)
								{
									if (Main.rand.Next(2) == 0)
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 77, 0);
										if ((double)num2 > (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && Main.rand.Next(5) == 0)
										{
											Main.npc[num21].SetDefaults("Heavy Skeleton");
										}
									}
									else
									{
										num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 110, 0);
									}
								}
								else if (Main.rand.Next(15) == 0)
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 44, 0);
								}
								else
								{
									num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 21, 0);
								}
							}
							else if (Main.hardMode && (Main.player[j].zoneHoly & Main.rand.Next(2) == 0))
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 138, 0);
							}
							else if (Main.player[j].zoneJungle)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 51, 0);
							}
							else if (Main.hardMode && Main.player[j].zoneHoly)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 137, 0);
							}
							else if (Main.hardMode && Main.rand.Next(6) > 0)
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 93, 0);
							}
							else
							{
								num21 = NPC.NewNPC(num * 16 + 8, num2 * 16, 49, 0);
							}
							if (Main.npc[num21].type == 1 && Main.rand.Next(250) == 0)
							{
								Main.npc[num21].SetDefaults("Pinky");
							}
							if (Main.netMode == 2 && num21 < 200)
							{
								NetMessage.SendData(23, -1, -1, "", num21, 0f, 0f, 0f, 0);
								break;
							}
							break;
						}
					}
				}
			}
		}

		public static void SpawnWOF(Vector2 pos)
		{
			if (pos.Y / 16f >= (float)(Main.maxTilesY - 205))
			{
				if (Main.wof < 0)
				{
					if (Main.netMode != 1)
					{
						Player.FindClosest(pos, 16, 16);
						int num = 1;
						if (pos.X / 16f > (float)(Main.maxTilesX / 2))
						{
							num = -1;
						}
						bool flag = false;
						int num2 = (int)pos.X;
						while (!flag)
						{
							flag = true;
							for (int i = 0; i < 255; i++)
							{
								if (Main.player[i].active && Main.player[i].position.X > (float)(num2 - 1200) && Main.player[i].position.X < (float)(num2 + 1200))
								{
									num2 -= num * 16;
									flag = false;
								}
							}
							if (num2 / 16 < 20 || num2 / 16 > Main.maxTilesX - 20)
							{
								flag = true;
							}
						}
						int num3 = (int)pos.Y;
						int num4 = num2 / 16;
						int num5 = num3 / 16;
						int num6 = 0;
						try
						{
							while (WorldGen.SolidTile(num4, num5 - num6) || Main.tile[num4, num5 - num6].liquid >= 100)
							{
								if (!WorldGen.SolidTile(num4, num5 + num6) && Main.tile[num4, num5 + num6].liquid < 100)
								{
									num5 += num6;
									goto IL_1E8;
								}
								num6++;
							}
							num5 -= num6;
						}
						catch
						{
						}
						IL_1E8:
						num3 = num5 * 16;
						int num7 = NPC.NewNPC(num2, num3, 113, 0);
						if (Main.npc[num7].displayName == "")
						{
							Main.npc[num7].displayName = Main.npc[num7].name;
							Main.npc[num7].displayCName = Main.npc[num7].CName;
						}
						if (Main.netMode == 0)
						{
							Main.NewText(Main.npc[num7].displayCName + " 苏醒了!!!", 175, 75, 255);
						}
						else if (Main.netMode == 2)
						{
							NetMessage.SendData(25, -1, -1, Main.npc[num7].displayCName + " 苏醒了!!!", 255, 175f, 75f, 255f, 0);
						}
					}
				}
			}
		}

		public static void SpawnOnPlayer(int plr, int Type)
		{
			if (Main.netMode != 1)
			{
				bool flag = false;
				int num = 0;
				int num2 = 0;
				int num3 = (int)(Main.player[plr].position.X / 16f) - NPC.spawnRangeX * 2;
				int num4 = (int)(Main.player[plr].position.X / 16f) + NPC.spawnRangeX * 2;
				int num5 = (int)(Main.player[plr].position.Y / 16f) - NPC.spawnRangeY * 2;
				int num6 = (int)(Main.player[plr].position.Y / 16f) + NPC.spawnRangeY * 2;
				int num7 = (int)(Main.player[plr].position.X / 16f) - NPC.safeRangeX;
				int num8 = (int)(Main.player[plr].position.X / 16f) + NPC.safeRangeX;
				int num9 = (int)(Main.player[plr].position.Y / 16f) - NPC.safeRangeY;
				int num10 = (int)(Main.player[plr].position.Y / 16f) + NPC.safeRangeY;
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesX)
				{
					num4 = Main.maxTilesX;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesY)
				{
					num6 = Main.maxTilesY;
				}
				for (int i = 0; i < 1000; i++)
				{
					int j = 0;
					while (j < 100)
					{
						int num11 = Main.rand.Next(num3, num4);
						int num12 = Main.rand.Next(num5, num6);
						if (Main.tile[num11, num12].active && Main.tileSolid[(int)Main.tile[num11, num12].type])
						{
							goto IL_3E7;
						}
						if (!Main.wallHouse[(int)Main.tile[num11, num12].wall] || i >= 999)
						{
							int k = num12;
							while (k < Main.maxTilesY)
							{
								if (Main.tile[num11, k].active && Main.tileSolid[(int)Main.tile[num11, k].type])
								{
									if (num11 < num7 || num11 > num8 || k < num9 || k > num10 || i == 999)
									{
										byte b = Main.tile[num11, k].type;
										num = num11;
										num2 = k;
										flag = true;
										break;
									}
									break;
								}
								else
								{
									k++;
								}
							}
							if (!flag || i >= 999)
							{
								goto IL_3E7;
							}
							int num13 = num - NPC.spawnSpaceX / 2;
							int num14 = num + NPC.spawnSpaceX / 2;
							int num15 = num2 - NPC.spawnSpaceY;
							int num16 = num2;
							if (num13 < 0)
							{
								flag = false;
							}
							if (num14 > Main.maxTilesX)
							{
								flag = false;
							}
							if (num15 < 0)
							{
								flag = false;
							}
							if (num16 > Main.maxTilesY)
							{
								flag = false;
							}
							if (flag)
							{
								for (int l = num13; l < num14; l++)
								{
									for (int m = num15; m < num16; m++)
									{
										if (Main.tile[l, m].active && Main.tileSolid[(int)Main.tile[l, m].type])
										{
											flag = false;
											break;
										}
									}
								}
								goto IL_3E7;
							}
							goto IL_3E7;
						}
						IL_3DF:
						j++;
						continue;
						IL_3E7:
						if (!flag && !flag)
						{
							goto IL_3DF;
						}
						break;
					}
					if (flag && i < 999)
					{
						Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
						for (int n = 0; n < 255; n++)
						{
							if (Main.player[n].active)
							{
								Rectangle rectangle2 = new Rectangle((int)(Main.player[n].position.X + (float)(Main.player[n].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[n].position.Y + (float)(Main.player[n].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
								if (rectangle.Intersects(rectangle2))
								{
									flag = false;
								}
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					int num17 = NPC.NewNPC(num * 16 + 8, num2 * 16, Type, 1);
					if (num17 != 200)
					{
						Main.npc[num17].target = plr;
						Main.npc[num17].timeLeft *= 20;
						string str = Main.npc[num17].CName;
						if (Main.npc[num17].type == 13)
						{
							str = "世界吞噬者";
						}
						if (Main.npc[num17].type == 35)
						{
							str = "骷髅君王";
						}
						if (Main.netMode == 2 && num17 < 200)
						{
							NetMessage.SendData(23, -1, -1, "", num17, 0f, 0f, 0f, 0);
						}
						if (Type == 125)
						{
							if (Main.netMode == 0)
							{
								Main.NewText("魔眼双子 苏醒了!!!", 175, 75, 255);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, "魔眼双子 苏醒了!!!", 255, 175f, 75f, 255f, 0);
							}
						}
						else if (Type != 82 && Type != 126 && Type != 50)
						{
							if (Main.netMode == 0)
							{
								Main.NewText(str + " 苏醒了!!!", 175, 75, 255);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, str + " 苏醒了!!!", 255, 175f, 75f, 255f, 0);
							}
						}
					}
				}
			}
		}

		public static int NewNPC(int X, int Y, int Type, int Start = 0)
		{
			int num = -1;
			for (int i = Start; i < 200; i++)
			{
				if (!Main.npc[i].active)
				{
					num = i;
					break;
				}
			}
			int result;
			if (num >= 0)
			{
				Main.npc[num] = new NPC();
				Main.npc[num].SetDefaults(Type, -1f);
				Main.npc[num].position.X = (float)(X - Main.npc[num].width / 2);
				Main.npc[num].position.Y = (float)(Y - Main.npc[num].height);
				Main.npc[num].active = true;
				Main.npc[num].timeLeft = (int)((double)NPC.activeTime * 1.25);
				Main.npc[num].wet = Collision.WetCollision(Main.npc[num].position, Main.npc[num].width, Main.npc[num].height);
				if (Type == 50)
				{
					if (Main.netMode == 0)
					{
						Main.NewText(Main.npc[num].CName + " 苏醒了!!!", 175, 75, 255);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(25, -1, -1, Main.npc[num].CName + " 苏醒了!!!", 255, 175f, 75f, 255f, 0);
					}
				}
				result = num;
			}
			else
			{
				result = 200;
			}
			return result;
		}

		public void Transform(int newType)
		{
			if (Main.netMode != 1)
			{
				Vector2 vector = this.velocity;
				this.position.Y = this.position.Y + (float)this.height;
				int num = this.spriteDirection;
				this.SetDefaults(newType, -1f);
				this.spriteDirection = num;
				this.TargetClosest(true);
				this.velocity = vector;
				this.position.Y = this.position.Y - (float)this.height;
				if (newType == 107 || newType == 108)
				{
					this.homeTileX = (int)(this.position.X + (float)(this.width / 2)) / 16;
					this.homeTileY = (int)(this.position.Y + (float)this.height) / 16;
					this.homeless = true;
				}
				if (Main.netMode == 2)
				{
					this.netUpdate = true;
					NetMessage.SendData(23, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
				}
			}
		}

		public double StrikeNPC(int Damage, float knockBack, int hitDirection, bool crit = false, bool noEffect = false)
		{
			double result;
			if (!this.active || this.life <= 0)
			{
				result = 0.0;
			}
			else
			{
				double num = (double)Damage;
				num = Main.CalculateDamage((int)num, this.defense);
				if (crit)
				{
					num *= 2.0;
				}
				if (Damage != 9999 && this.lifeMax > 1)
				{
					if (this.friendly)
					{
						CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 80, 90, 255), string.Concat((int)num), crit);
					}
					else
					{
						CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 160, 80, 255), string.Concat((int)num), crit);
					}
				}
				if (num >= 1.0)
				{
					this.justHit = true;
					if (this.townNPC)
					{
						this.ai[0] = 1f;
						this.ai[1] = (float)(300 + Main.rand.Next(300));
						this.ai[2] = 0f;
						this.direction = hitDirection;
						this.netUpdate = true;
					}
					if (this.aiStyle == 8 && Main.netMode != 1)
					{
						this.ai[0] = 400f;
						this.TargetClosest(true);
					}
					if (this.realLife >= 0)
					{
						Main.npc[this.realLife].life -= (int)num;
						this.life = Main.npc[this.realLife].life;
						this.lifeMax = Main.npc[this.realLife].lifeMax;
					}
					else
					{
						this.life -= (int)num;
					}
					if (knockBack > 0f && this.knockBackResist > 0f)
					{
						float num2 = knockBack * this.knockBackResist;
						if (num2 > 8f)
						{
							num2 = 8f;
						}
						if (crit)
						{
							num2 *= 1.4f;
						}
						if (num * 10.0 < (double)this.lifeMax)
						{
							if (hitDirection < 0 && this.velocity.X > -num2)
							{
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num2;
								}
								this.velocity.X = this.velocity.X - num2;
								if (this.velocity.X < -num2)
								{
									this.velocity.X = -num2;
								}
							}
							else if (hitDirection > 0 && this.velocity.X < num2)
							{
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num2;
								}
								this.velocity.X = this.velocity.X + num2;
								if (this.velocity.X > num2)
								{
									this.velocity.X = num2;
								}
							}
							if (!this.noGravity)
							{
								num2 *= -0.75f;
							}
							else
							{
								num2 *= -0.5f;
							}
							if (this.velocity.Y > num2)
							{
								this.velocity.Y = this.velocity.Y + num2;
								if (this.velocity.Y < num2)
								{
									this.velocity.Y = num2;
								}
							}
						}
						else
						{
							if (!this.noGravity)
							{
								this.velocity.Y = -num2 * 0.75f * this.knockBackResist;
							}
							else
							{
								this.velocity.Y = -num2 * 0.5f * this.knockBackResist;
							}
							this.velocity.X = num2 * (float)hitDirection * this.knockBackResist;
						}
					}
					if ((this.type == 113 || this.type == 114) && this.life <= 0)
					{
						for (int i = 0; i < 200; i++)
						{
							if (Main.npc[i].active && (Main.npc[i].type == 113 || Main.npc[i].type == 114))
							{
								Main.npc[i].HitEffect(hitDirection, num);
							}
						}
					}
					else
					{
						this.HitEffect(hitDirection, num);
					}
					if (this.soundHit > 0)
					{
						Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, this.soundHit);
					}
					if (this.realLife >= 0)
					{
						Main.npc[this.realLife].checkDead();
					}
					else
					{
						this.checkDead();
					}
					result = num;
				}
				else
				{
					result = 0.0;
				}
			}
			return result;
		}

		public void checkDead()
		{
			if (this.active)
			{
				if (this.realLife < 0 || this.realLife == this.whoAmI)
				{
					if (this.life <= 0)
					{
						NPC.noSpawnCycle = true;
						if (this.townNPC && this.type != 37)
						{
							string cName = this.CName;
							if (this.displayName != "")
							{
								cName = this.displayCName;
							}
							if (Main.netMode == 0)
							{
								Main.NewText(cName + "被杀死了...", 255, 25, 25);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, cName + "被杀死了...", 255, 255f, 25f, 25f, 0);
							}
							if (Main.netMode != 1)
							{
								Main.chrName[this.type] = "";
								NPC.setNames();
								NetMessage.SendData(56, -1, -1, "", this.type, 0f, 0f, 0f, 0);
							}
						}
						if (this.townNPC && Main.netMode != 1 && this.homeless && WorldGen.spawnNPC == this.type)
						{
							WorldGen.spawnNPC = 0;
						}
						if (this.soundKilled > 0)
						{
							Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, this.soundKilled);
						}
						this.NPCLoot();
						this.active = false;
						if (this.type == 26 || this.type == 27 || this.type == 28 || this.type == 29 || this.type == 111 || this.type == 143 || this.type == 144 || this.type == 145)
						{
							Main.invasionSize--;
						}
					}
				}
			}
		}

		public void NPCLoot()
		{
			if (Main.hardMode && this.lifeMax > 1 && this.damage > 0 && !this.friendly && (double)this.position.Y > Main.rockLayer * 16.0 && Main.rand.Next(7) == 0 && this.type != 121 && this.value > 0f)
			{
				if (Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].zoneEvil)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 521, 1, false, 0);
				}
				if (Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].zoneHoly)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 520, 1, false, 0);
				}
			}
			if (Main.xMas && this.lifeMax > 1 && this.damage > 0 && !this.friendly && this.type != 121 && this.value > 0f && Main.rand.Next(13) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(599, 602), 1, false, 0);
			}
			if (this.type == 109 && !NPC.downedClown)
			{
				NPC.downedClown = true;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				}
			}
			if (this.type == 85 && this.value > 0f)
			{
				int num = Main.rand.Next(7);
				if (num == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 437, 1, false, -1);
				}
				if (num == 1)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 517, 1, false, -1);
				}
				if (num == 2)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 535, 1, false, -1);
				}
				if (num == 3)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 536, 1, false, -1);
				}
				if (num == 4)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 532, 1, false, -1);
				}
				if (num == 5)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 393, 1, false, -1);
				}
				if (num == 6)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 554, 1, false, -1);
				}
			}
			if (this.type == 87)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 575, Main.rand.Next(5, 11), false, 0);
			}
			if (this.type == 143 || this.type == 144 || this.type == 145)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 593, Main.rand.Next(5, 11), false, 0);
			}
			if (this.type == 79)
			{
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 527, 1, false, 0);
				}
			}
			else if (this.type == 80 && Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 528, 1, false, 0);
			}
			if (this.type == 101 || this.type == 98)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 522, Main.rand.Next(2, 6), false, 0);
			}
			if (this.type == 86)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 526, 1, false, 0);
			}
			if (this.type == 113)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 367, 1, false, -1);
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(489, 492), 1, false, -1);
				}
				else
				{
					int num2 = Main.rand.Next(3);
					if (num2 == 0)
					{
						Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 514, 1, false, -1);
					}
					else if (num2 == 1)
					{
						Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 426, 1, false, -1);
					}
					else if (num2 == 2)
					{
						Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 434, 1, false, -1);
					}
				}
				if (Main.netMode != 1)
				{
					int num3 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num4 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					int num5 = this.width / 2 / 16 + 1;
					for (int i = num3 - num5; i <= num3 + num5; i++)
					{
						for (int j = num4 - num5; j <= num4 + num5; j++)
						{
							if ((i == num3 - num5 || i == num3 + num5 || j == num4 - num5 || j == num4 + num5) && !Main.tile[i, j].active)
							{
								Main.tile[i, j].type = 140;
								Main.tile[i, j].active = true;
							}
							Main.tile[i, j].lava = false;
							Main.tile[i, j].liquid = 0;
							if (Main.netMode == 2)
							{
								NetMessage.SendTileSquare(-1, i, j, 1);
							}
							else
							{
								WorldGen.SquareTileFrame(i, j, true);
							}
						}
					}
				}
			}
			if (this.type == 1 || this.type == 16 || this.type == 138 || this.type == 141)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 23, Main.rand.Next(1, 3), false, 0);
			}
			if (this.type == 75)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 501, Main.rand.Next(1, 4), false, 0);
			}
			if (this.type == 81)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 23, Main.rand.Next(2, 5), false, 0);
			}
			if (this.type == 122)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 23, Main.rand.Next(5, 11), false, 0);
			}
			if (this.type == 71)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 327, 1, false, 0);
			}
			if (this.type == 2)
			{
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 38, 1, false, 0);
				}
				else if (Main.rand.Next(100) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 236, 1, false, 0);
				}
			}
			if (this.type == 104 && Main.rand.Next(60) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 485, 1, false, -1);
			}
			if (this.type == 58)
			{
				if (Main.rand.Next(500) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 263, 1, false, 0);
				}
				else if (Main.rand.Next(40) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 118, 1, false, 0);
				}
			}
			if (this.type == 102 && Main.rand.Next(500) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 263, 1, false, 0);
			}
			if ((this.type == 3 || this.type == 132) && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 216, 1, false, -1);
			}
			if (this.type == 66)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 267, 1, false, 0);
			}
			if (this.type == 62 && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 272, 1, false, -1);
			}
			if (this.type == 52)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 251, 1, false, 0);
			}
			if (this.type == 53)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 239, 1, false, 0);
			}
			if (this.type == 54)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 260, 1, false, 0);
			}
			if (this.type == 55)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 261, 1, false, 0);
			}
			if (this.type == 69 && Main.rand.Next(7) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 323, 1, false, 0);
			}
			if (this.type == 73)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 362, Main.rand.Next(1, 3), false, 0);
			}
			if (this.type == 4)
			{
				int stack = Main.rand.Next(30) + 20;
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, stack, false, 0);
				stack = Main.rand.Next(20) + 10;
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack, false, 0);
				stack = Main.rand.Next(20) + 10;
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack, false, 0);
				stack = Main.rand.Next(20) + 10;
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack, false, 0);
				stack = Main.rand.Next(3) + 1;
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 59, stack, false, 0);
			}
			if ((this.type == 6 || this.type == 94) && Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 68, 1, false, 0);
			}
			if (this.type == 7 || this.type == 8 || this.type == 9)
			{
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 68, Main.rand.Next(1, 3), false, 0);
				}
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 69, Main.rand.Next(3, 9), false, 0);
			}
			if ((this.type == 10 || this.type == 11 || this.type == 12 || this.type == 95 || this.type == 96 || this.type == 97) && Main.rand.Next(500) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 215, 1, false, 0);
			}
			if (this.type == 47 && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 243, 1, false, 0);
			}
			if (this.type == 13 || this.type == 14 || this.type == 15)
			{
				int stack2 = Main.rand.Next(1, 3);
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 86, stack2, false, 0);
				}
				if (Main.rand.Next(2) == 0)
				{
					stack2 = Main.rand.Next(2, 6);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack2, false, 0);
				}
				if (this.boss)
				{
					stack2 = Main.rand.Next(10, 30);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack2, false, 0);
					stack2 = Main.rand.Next(10, 31);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 56, stack2, false, 0);
				}
				if (Main.rand.Next(3) == 0 && Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statLife < Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statLifeMax)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 58, 1, false, 0);
				}
			}
			if (this.type == 116 || this.type == 117 || this.type == 118 || this.type == 119 || this.type == 139)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 58, 1, false, 0);
			}
			if (this.type == 63 || this.type == 64 || this.type == 103)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, Main.rand.Next(1, 5), false, 0);
			}
			if (this.type == 21 || this.type == 44)
			{
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 118, 1, false, 0);
				}
				else if (this.type == 44)
				{
					if (Main.rand.Next(20) == 0)
					{
						Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(410, 412), 1, false, 0);
					}
					else
					{
						Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 166, Main.rand.Next(1, 4), false, 0);
					}
				}
			}
			if (this.type == 45)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 238, 1, false, 0);
			}
			if (this.type == 50)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(256, 259), 1, false, 0);
			}
			if (this.type == 23 && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 116, 1, false, 0);
			}
			if (this.type == 24 && Main.rand.Next(300) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 244, 1, false, 0);
			}
			if (this.type == 31 || this.type == 32 || this.type == 34)
			{
				if (Main.rand.Next(65) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 327, 1, false, 0);
				}
				else
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, Main.rand.Next(1, 4), false, 0);
				}
			}
			if (this.type == 26 || this.type == 27 || this.type == 28 || this.type == 29 || this.type == 111)
			{
				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 160, 1, false, 0);
				}
				else if (Main.rand.Next(2) == 0)
				{
					int stack3 = Main.rand.Next(1, 6);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 161, stack3, false, 0);
				}
			}
			if (this.type == 42 && Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 209, 1, false, 0);
			}
			if (this.type == 43 && Main.rand.Next(4) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 210, 1, false, 0);
			}
			if (this.type == 65)
			{
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 268, 1, false, 0);
				}
				else
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 319, 1, false, 0);
				}
			}
			if (this.type == 48 && Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 320, 1, false, 0);
			}
			if (this.type == 125 || this.type == 126)
			{
				int num6 = 125;
				if (this.type == 125)
				{
					num6 = 126;
				}
				if (!NPC.AnyNPCs(num6))
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 549, Main.rand.Next(20, 31), false, 0);
				}
				else
				{
					this.value = 0f;
					this.boss = false;
				}
			}
			else if (this.type == 127)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 547, Main.rand.Next(20, 31), false, 0);
			}
			else if (this.type == 134)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 548, Main.rand.Next(20, 31), false, 0);
			}
			if (this.boss)
			{
				if (this.type == 4)
				{
					NPC.downedBoss1 = true;
				}
				else if (this.type == 13 || this.type == 14 || this.type == 15)
				{
					NPC.downedBoss2 = true;
					this.name = "Eater of Worlds";
					this.CName = "世界吞噬者";
				}
				else if (this.type == 35)
				{
					NPC.downedBoss3 = true;
					this.name = "Skeletron";
					this.CName = "骷髅君王";
				}
				else
				{
					this.name = this.displayName;
					this.CName = this.displayCName;
				}
				int stack4 = Main.rand.Next(5, 16);
				int num7 = 28;
				if (this.type == 113)
				{
					num7 = 188;
				}
				if (this.type > 113)
				{
					num7 = 499;
				}
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num7, stack4, false, 0);
				int num8 = Main.rand.Next(5) + 5;
				for (int k = 0; k < num8; k++)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 58, 1, false, 0);
				}
				if (this.type == 125 || this.type == 126)
				{
					if (Main.netMode == 0)
					{
						Main.NewText("魔眼双子 被击败！！！", 175, 75, 255);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(25, -1, -1, "魔眼双子 被击败！！！", 255, 175f, 75f, 255f, 0);
					}
				}
				else if (Main.netMode == 0)
				{
					Main.NewText(this.CName + " 被击败！！！", 175, 75, 255);
				}
				else if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, this.CName + " 被击败！！！", 255, 175f, 75f, 255f, 0);
				}
				if (this.type == 113 && Main.netMode != 1)
				{
					WorldGen.StartHardmode();
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				}
			}
			if (Main.rand.Next(6) == 0 && this.lifeMax > 1 && this.damage > 0)
			{
				if (Main.rand.Next(2) == 0 && Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statMana < Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statManaMax)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 184, 1, false, 0);
				}
				else if (Main.rand.Next(2) == 0 && Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statLife < Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statLifeMax)
				{
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 58, 1, false, 0);
				}
			}
			if (Main.rand.Next(2) == 0 && this.lifeMax > 1 && this.damage > 0 && Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statMana < Main.player[(int)Player.FindClosest(this.position, this.width, this.height)].statManaMax)
			{
				Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 184, 1, false, 0);
			}
			float num9 = this.value;
			num9 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
			if (Main.rand.Next(5) == 0)
			{
				num9 *= 1f + (float)Main.rand.Next(5, 11) * 0.01f;
			}
			if (Main.rand.Next(10) == 0)
			{
				num9 *= 1f + (float)Main.rand.Next(10, 21) * 0.01f;
			}
			if (Main.rand.Next(15) == 0)
			{
				num9 *= 1f + (float)Main.rand.Next(15, 31) * 0.01f;
			}
			if (Main.rand.Next(20) == 0)
			{
				num9 *= 1f + (float)Main.rand.Next(20, 41) * 0.01f;
			}
			while ((int)num9 > 0)
			{
				if (num9 > 1000000f)
				{
					int num10 = (int)(num9 / 1000000f);
					if (num10 > 50 && Main.rand.Next(5) == 0)
					{
						num10 /= Main.rand.Next(3) + 1;
					}
					if (Main.rand.Next(5) == 0)
					{
						num10 /= Main.rand.Next(3) + 1;
					}
					num9 -= (float)(1000000 * num10);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 74, num10, false, 0);
				}
				else if (num9 > 10000f)
				{
					int num11 = (int)(num9 / 10000f);
					if (num11 > 50 && Main.rand.Next(5) == 0)
					{
						num11 /= Main.rand.Next(3) + 1;
					}
					if (Main.rand.Next(5) == 0)
					{
						num11 /= Main.rand.Next(3) + 1;
					}
					num9 -= (float)(10000 * num11);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 73, num11, false, 0);
				}
				else if (num9 > 100f)
				{
					int num12 = (int)(num9 / 100f);
					if (num12 > 50 && Main.rand.Next(5) == 0)
					{
						num12 /= Main.rand.Next(3) + 1;
					}
					if (Main.rand.Next(5) == 0)
					{
						num12 /= Main.rand.Next(3) + 1;
					}
					num9 -= (float)(100 * num12);
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 72, num12, false, 0);
				}
				else
				{
					int num13 = (int)num9;
					if (num13 > 50 && Main.rand.Next(5) == 0)
					{
						num13 /= Main.rand.Next(3) + 1;
					}
					if (Main.rand.Next(5) == 0)
					{
						num13 /= Main.rand.Next(4) + 1;
					}
					if (num13 < 1)
					{
						num13 = 1;
					}
					num9 -= (float)num13;
					Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 71, num13, false, 0);
				}
			}
		}

		public void HitEffect(int hitDirection = 0, double dmg = 10.0)
		{
			if (this.active)
			{
				if (this.type == 1 || this.type == 16 || this.type == 71)
				{
					if (this.life > 0)
					{
						int num = 0;
						while ((double)num < dmg / (double)this.lifeMax * 100.0)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)hitDirection, -1f, this.alpha, this.color, 1f);
							num++;
						}
					}
					else
					{
						for (int i = 0; i < 50; i++)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)(2 * hitDirection), -2f, this.alpha, this.color, 1f);
						}
						if (Main.netMode != 1 && this.type == 16)
						{
							int num2 = Main.rand.Next(2) + 2;
							for (int j = 0; j < num2; j++)
							{
								int num3 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), 1, 0);
								Main.npc[num3].SetDefaults("Baby Slime");
								Main.npc[num3].velocity.X = this.velocity.X * 2f;
								Main.npc[num3].velocity.Y = this.velocity.Y;
								NPC nPC = Main.npc[num3];
								nPC.velocity.X = nPC.velocity.X + ((float)Main.rand.Next(-20, 20) * 0.1f + (float)(j * this.direction) * 0.3f);
								NPC nPC2 = Main.npc[num3];
								nPC2.velocity.Y = nPC2.velocity.Y - ((float)Main.rand.Next(0, 10) * 0.1f + (float)j);
								Main.npc[num3].ai[1] = (float)j;
								if (Main.netMode == 2 && num3 < 200)
								{
									NetMessage.SendData(23, -1, -1, "", num3, 0f, 0f, 0f, 0);
								}
							}
						}
					}
				}
				if (this.type == 143 || this.type == 144 || this.type == 145)
				{
					if (this.life > 0)
					{
						int num4 = 0;
						while ((double)num4 < dmg / (double)this.lifeMax * 100.0)
						{
							Vector2 vector = this.position;
							int num5 = this.width;
							int num6 = this.height;
							int num7 = 76;
							float speedX = (float)hitDirection;
							float speedY = -1f;
							int num8 = 0;
							int num9 = Dust.NewDust(vector, num5, num6, num7, speedX, speedY, num8, default(Color), 1f);
							Main.dust[num9].noGravity = true;
							num4++;
						}
					}
					else
					{
						for (int k = 0; k < 50; k++)
						{
							Vector2 vector2 = this.position;
							int num10 = this.width;
							int num11 = this.height;
							int num12 = 76;
							float speedX2 = (float)hitDirection;
							float speedY2 = -1f;
							int num13 = 0;
							int num14 = Dust.NewDust(vector2, num10, num11, num12, speedX2, speedY2, num13, default(Color), 1f);
							Main.dust[num14].noGravity = true;
							Main.dust[num14].scale *= 1.2f;
						}
					}
				}
				if (this.type == 141)
				{
					if (this.life > 0)
					{
						int num15 = 0;
						while ((double)num15 < dmg / (double)this.lifeMax * 100.0)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)hitDirection, -1f, this.alpha, new Color(210, 230, 140), 1f);
							num15++;
						}
					}
					else
					{
						for (int l = 0; l < 50; l++)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)(2 * hitDirection), -2f, this.alpha, new Color(210, 230, 140), 1f);
						}
					}
				}
				if (this.type == 112)
				{
					for (int m = 0; m < 20; m++)
					{
						Vector2 vector3 = new Vector2(this.position.X, this.position.Y + 2f);
						int num16 = this.width;
						int num17 = this.height;
						int num18 = 18;
						float speedX3 = 0f;
						float speedY3 = 0f;
						int num19 = 100;
						Color newColor = default(Color);
						int num20 = Dust.NewDust(vector3, num16, num17, num18, speedX3, speedY3, num19, newColor, 2f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num20].scale *= 0.6f;
						}
						else
						{
							Dust dust = Main.dust[num20];
							dust.velocity *= 1.4f;
							Main.dust[num20].noGravity = true;
						}
					}
				}
				if (this.type == 81 || this.type == 121)
				{
					if (this.life > 0)
					{
						int num21 = 0;
						while ((double)num21 < dmg / (double)this.lifeMax * 100.0)
						{
							Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, this.alpha, this.color, 1f);
							num21++;
						}
					}
					else
					{
						for (int n = 0; n < 50; n++)
						{
							int num22 = Dust.NewDust(this.position, this.width, this.height, 14, (float)hitDirection, 0f, this.alpha, this.color, 1f);
							Dust dust2 = Main.dust[num22];
							dust2.velocity *= 2f;
						}
						if (Main.netMode != 1)
						{
							if (this.type == 121)
							{
								int num23 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), 81, 0);
								Main.npc[num23].SetDefaults("Slimer2");
								Main.npc[num23].velocity.X = this.velocity.X;
								Main.npc[num23].velocity.Y = this.velocity.Y;
								Gore.NewGore(this.position, this.velocity, 94, this.scale);
								if (Main.netMode == 2 && num23 < 200)
								{
									NetMessage.SendData(23, -1, -1, "", num23, 0f, 0f, 0f, 0);
								}
							}
							else if (this.scale >= 1f)
							{
								int num24 = Main.rand.Next(2) + 2;
								for (int num25 = 0; num25 < num24; num25++)
								{
									int num26 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), 1, 0);
									Main.npc[num26].SetDefaults("Slimeling");
									Main.npc[num26].velocity.X = this.velocity.X * 3f;
									Main.npc[num26].velocity.Y = this.velocity.Y;
									NPC nPC3 = Main.npc[num26];
									nPC3.velocity.X = nPC3.velocity.X + ((float)Main.rand.Next(-10, 10) * 0.1f + (float)(num25 * this.direction) * 0.3f);
									NPC nPC4 = Main.npc[num26];
									nPC4.velocity.Y = nPC4.velocity.Y - ((float)Main.rand.Next(0, 10) * 0.1f + (float)num25);
									Main.npc[num26].ai[1] = (float)num25;
									if (Main.netMode == 2 && num26 < 200)
									{
										NetMessage.SendData(23, -1, -1, "", num26, 0f, 0f, 0f, 0);
									}
								}
							}
						}
					}
				}
				if (this.type == 120 || this.type == 137 || this.type == 138)
				{
					if (this.life > 0)
					{
						int num27 = 0;
						while ((double)num27 < dmg / (double)this.lifeMax * 50.0)
						{
							Vector2 vector4 = this.position;
							int num28 = this.width;
							int num29 = this.height;
							int num30 = 71;
							float speedX4 = 0f;
							float speedY4 = 0f;
							int num31 = 200;
							int num32 = Dust.NewDust(vector4, num28, num29, num30, speedX4, speedY4, num31, default(Color), 1f);
							Dust dust3 = Main.dust[num32];
							dust3.velocity *= 1.5f;
							num27++;
						}
					}
					else
					{
						for (int num33 = 0; num33 < 50; num33++)
						{
							Vector2 vector5 = this.position;
							int num34 = this.width;
							int num35 = this.height;
							int num36 = 71;
							float speedX5 = (float)hitDirection;
							float speedY5 = 0f;
							int num37 = 200;
							int num38 = Dust.NewDust(vector5, num34, num35, num36, speedX5, speedY5, num37, default(Color), 1f);
							Dust dust4 = Main.dust[num38];
							dust4.velocity *= 1.5f;
						}
					}
				}
				if (this.type == 122)
				{
					if (this.life > 0)
					{
						int num39 = 0;
						while ((double)num39 < dmg / (double)this.lifeMax * 50.0)
						{
							Vector2 vector6 = this.position;
							int num40 = this.width;
							int num41 = this.height;
							int num42 = 72;
							float speedX6 = 0f;
							float speedY6 = 0f;
							int num43 = 200;
							int num44 = Dust.NewDust(vector6, num40, num41, num42, speedX6, speedY6, num43, default(Color), 1f);
							Dust dust5 = Main.dust[num44];
							dust5.velocity *= 1.5f;
							num39++;
						}
					}
					else
					{
						for (int num45 = 0; num45 < 50; num45++)
						{
							Vector2 vector7 = this.position;
							int num46 = this.width;
							int num47 = this.height;
							int num48 = 72;
							float speedX7 = (float)hitDirection;
							float speedY7 = 0f;
							int num49 = 200;
							int num50 = Dust.NewDust(vector7, num46, num47, num48, speedX7, speedY7, num49, default(Color), 1f);
							Dust dust6 = Main.dust[num50];
							dust6.velocity *= 1.5f;
						}
					}
				}
				if (this.type == 75)
				{
					if (this.life > 0)
					{
						int num51 = 0;
						while ((double)num51 < dmg / (double)this.lifeMax * 50.0)
						{
							Dust.NewDust(this.position, this.width, this.height, 55, 0f, 0f, 200, this.color, 1f);
							num51++;
						}
					}
					else
					{
						for (int num52 = 0; num52 < 50; num52++)
						{
							int num53 = Dust.NewDust(this.position, this.width, this.height, 55, (float)hitDirection, 0f, 200, this.color, 1f);
							Dust dust7 = Main.dust[num53];
							dust7.velocity *= 2f;
						}
					}
				}
				if (this.type == 63 || this.type == 64 || this.type == 103)
				{
					Color newColor2 = new Color(50, 120, 255, 100);
					if (this.type == 64)
					{
						newColor2 = new Color(225, 70, 140, 100);
					}
					if (this.type == 103)
					{
						newColor2 = new Color(70, 225, 140, 100);
					}
					if (this.life > 0)
					{
						int num54 = 0;
						while ((double)num54 < dmg / (double)this.lifeMax * 50.0)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)hitDirection, -1f, 0, newColor2, 1f);
							num54++;
						}
					}
					else
					{
						for (int num55 = 0; num55 < 25; num55++)
						{
							Dust.NewDust(this.position, this.width, this.height, 4, (float)(2 * hitDirection), -2f, 0, newColor2, 1f);
						}
					}
				}
				else if (this.type != 59 && this.type != 60)
				{
					if (this.type == 50)
					{
						if (this.life > 0)
						{
							int num56 = 0;
							while ((double)num56 < dmg / (double)this.lifeMax * 300.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 4, (float)hitDirection, -1f, 175, new Color(0, 80, 255, 100), 1f);
								num56++;
							}
						}
						else
						{
							for (int num57 = 0; num57 < 200; num57++)
							{
								Dust.NewDust(this.position, this.width, this.height, 4, (float)(2 * hitDirection), -2f, 175, new Color(0, 80, 255, 100), 1f);
							}
							if (Main.netMode != 1)
							{
								int num58 = Main.rand.Next(4) + 4;
								for (int num59 = 0; num59 < num58; num59++)
								{
									int x = (int)(this.position.X + (float)Main.rand.Next(this.width - 32));
									int y = (int)(this.position.Y + (float)Main.rand.Next(this.height - 32));
									int num60 = NPC.NewNPC(x, y, 1, 0);
									Main.npc[num60].SetDefaults(1, -1f);
									Main.npc[num60].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
									Main.npc[num60].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
									Main.npc[num60].ai[1] = (float)Main.rand.Next(3);
									if (Main.netMode == 2 && num60 < 200)
									{
										NetMessage.SendData(23, -1, -1, "", num60, 0f, 0f, 0f, 0);
									}
								}
							}
						}
					}
					else if (this.type == 49 || this.type == 51 || this.type == 93)
					{
						if (this.life > 0)
						{
							int num61 = 0;
							while ((double)num61 < dmg / (double)this.lifeMax * 30.0)
							{
								Vector2 vector8 = this.position;
								int num62 = this.width;
								int num63 = this.height;
								int num64 = 5;
								float speedX8 = (float)hitDirection;
								float speedY8 = -1f;
								int num65 = 0;
								Dust.NewDust(vector8, num62, num63, num64, speedX8, speedY8, num65, default(Color), 1f);
								num61++;
							}
						}
						else
						{
							for (int num66 = 0; num66 < 15; num66++)
							{
								Vector2 vector9 = this.position;
								int num67 = this.width;
								int num68 = this.height;
								int num69 = 5;
								float speedX9 = (float)(2 * hitDirection);
								float speedY9 = -2f;
								int num70 = 0;
								Dust.NewDust(vector9, num67, num68, num69, speedX9, speedY9, num70, default(Color), 1f);
							}
							if (this.type == 51)
							{
								Gore.NewGore(this.position, this.velocity, 83, 1f);
							}
							else if (this.type == 93)
							{
								Gore.NewGore(this.position, this.velocity, 107, 1f);
							}
							else
							{
								Gore.NewGore(this.position, this.velocity, 82, 1f);
							}
						}
					}
					else if (this.type == 46 || this.type == 55 || this.type == 67 || this.type == 74 || this.type == 102)
					{
						if (this.life > 0)
						{
							int num71 = 0;
							while ((double)num71 < dmg / (double)this.lifeMax * 20.0)
							{
								Vector2 vector10 = this.position;
								int num72 = this.width;
								int num73 = this.height;
								int num74 = 5;
								float speedX10 = (float)hitDirection;
								float speedY10 = -1f;
								int num75 = 0;
								Dust.NewDust(vector10, num72, num73, num74, speedX10, speedY10, num75, default(Color), 1f);
								num71++;
							}
						}
						else
						{
							for (int num76 = 0; num76 < 10; num76++)
							{
								Vector2 vector11 = this.position;
								int num77 = this.width;
								int num78 = this.height;
								int num79 = 5;
								float speedX11 = (float)(2 * hitDirection);
								float speedY11 = -2f;
								int num80 = 0;
								Dust.NewDust(vector11, num77, num78, num79, speedX11, speedY11, num80, default(Color), 1f);
							}
							if (this.type == 46)
							{
								Gore.NewGore(this.position, this.velocity, 76, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 77, 1f);
							}
							else if (this.type == 67)
							{
								Gore.NewGore(this.position, this.velocity, 95, 1f);
								Gore.NewGore(this.position, this.velocity, 95, 1f);
								Gore.NewGore(this.position, this.velocity, 96, 1f);
							}
							else if (this.type == 74)
							{
								Gore.NewGore(this.position, this.velocity, 100, 1f);
							}
							else if (this.type == 102)
							{
								Gore.NewGore(this.position, this.velocity, 116, 1f);
							}
						}
					}
					else if (this.type == 47 || this.type == 57 || this.type == 58)
					{
						if (this.life > 0)
						{
							int num81 = 0;
							while ((double)num81 < dmg / (double)this.lifeMax * 20.0)
							{
								Vector2 vector12 = this.position;
								int num82 = this.width;
								int num83 = this.height;
								int num84 = 5;
								float speedX12 = (float)hitDirection;
								float speedY12 = -1f;
								int num85 = 0;
								Dust.NewDust(vector12, num82, num83, num84, speedX12, speedY12, num85, default(Color), 1f);
								num81++;
							}
						}
						else
						{
							for (int num86 = 0; num86 < 10; num86++)
							{
								Vector2 vector13 = this.position;
								int num87 = this.width;
								int num88 = this.height;
								int num89 = 5;
								float speedX13 = (float)(2 * hitDirection);
								float speedY13 = -2f;
								int num90 = 0;
								Dust.NewDust(vector13, num87, num88, num89, speedX13, speedY13, num90, default(Color), 1f);
							}
							if (this.type == 57)
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 84, 1f);
							}
							else if (this.type == 58)
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 85, 1f);
							}
							else
							{
								Gore.NewGore(this.position, this.velocity, 78, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 79, 1f);
							}
						}
					}
					else if (this.type == 2)
					{
						if (this.life > 0)
						{
							int num91 = 0;
							while ((double)num91 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector14 = this.position;
								int num92 = this.width;
								int num93 = this.height;
								int num94 = 5;
								float speedX14 = (float)hitDirection;
								float speedY14 = -1f;
								int num95 = 0;
								Dust.NewDust(vector14, num92, num93, num94, speedX14, speedY14, num95, default(Color), 1f);
								num91++;
							}
						}
						else
						{
							for (int num96 = 0; num96 < 50; num96++)
							{
								Vector2 vector15 = this.position;
								int num97 = this.width;
								int num98 = this.height;
								int num99 = 5;
								float speedX15 = (float)(2 * hitDirection);
								float speedY15 = -2f;
								int num100 = 0;
								Dust.NewDust(vector15, num97, num98, num99, speedX15, speedY15, num100, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 1, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 2, 1f);
						}
					}
					else if (this.type == 133)
					{
						if (this.life <= 0)
						{
							for (int num101 = 0; num101 < 50; num101++)
							{
								Vector2 vector16 = this.position;
								int num102 = this.width;
								int num103 = this.height;
								int num104 = 5;
								float speedX16 = (float)(2 * hitDirection);
								float speedY16 = -2f;
								int num105 = 0;
								Dust.NewDust(vector16, num102, num103, num104, speedX16, speedY16, num105, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 155, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 14f), this.velocity, 155, 1f);
						}
						else
						{
							int num106 = 0;
							while ((double)num106 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector17 = this.position;
								int num107 = this.width;
								int num108 = this.height;
								int num109 = 5;
								float speedX17 = (float)hitDirection;
								float speedY17 = -1f;
								int num110 = 0;
								Dust.NewDust(vector17, num107, num108, num109, speedX17, speedY17, num110, default(Color), 1f);
								num106++;
							}
							if ((float)this.life < (float)this.lifeMax * 0.5f && this.localAI[0] == 0f)
							{
								this.localAI[0] = 1f;
								Gore.NewGore(this.position, this.velocity, 1, 1f);
							}
						}
					}
					else if (this.type == 69)
					{
						if (this.life > 0)
						{
							int num111 = 0;
							while ((double)num111 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector18 = this.position;
								int num112 = this.width;
								int num113 = this.height;
								int num114 = 5;
								float speedX18 = (float)hitDirection;
								float speedY18 = -1f;
								int num115 = 0;
								Dust.NewDust(vector18, num112, num113, num114, speedX18, speedY18, num115, default(Color), 1f);
								num111++;
							}
						}
						else
						{
							for (int num116 = 0; num116 < 50; num116++)
							{
								Vector2 vector19 = this.position;
								int num117 = this.width;
								int num118 = this.height;
								int num119 = 5;
								float speedX19 = (float)(2 * hitDirection);
								float speedY19 = -2f;
								int num120 = 0;
								Dust.NewDust(vector19, num117, num118, num119, speedX19, speedY19, num120, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 97, 1f);
							Gore.NewGore(this.position, this.velocity, 98, 1f);
						}
					}
					else if (this.type == 61)
					{
						if (this.life > 0)
						{
							int num121 = 0;
							while ((double)num121 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector20 = this.position;
								int num122 = this.width;
								int num123 = this.height;
								int num124 = 5;
								float speedX20 = (float)hitDirection;
								float speedY20 = -1f;
								int num125 = 0;
								Dust.NewDust(vector20, num122, num123, num124, speedX20, speedY20, num125, default(Color), 1f);
								num121++;
							}
						}
						else
						{
							for (int num126 = 0; num126 < 50; num126++)
							{
								Vector2 vector21 = this.position;
								int num127 = this.width;
								int num128 = this.height;
								int num129 = 5;
								float speedX21 = (float)(2 * hitDirection);
								float speedY21 = -2f;
								int num130 = 0;
								Dust.NewDust(vector21, num127, num128, num129, speedX21, speedY21, num130, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 86, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 87, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 88, 1f);
						}
					}
					else if (this.type == 65)
					{
						if (this.life > 0)
						{
							int num131 = 0;
							while ((double)num131 < dmg / (double)this.lifeMax * 150.0)
							{
								Vector2 vector22 = this.position;
								int num132 = this.width;
								int num133 = this.height;
								int num134 = 5;
								float speedX22 = (float)hitDirection;
								float speedY22 = -1f;
								int num135 = 0;
								Dust.NewDust(vector22, num132, num133, num134, speedX22, speedY22, num135, default(Color), 1f);
								num131++;
							}
						}
						else
						{
							for (int num136 = 0; num136 < 75; num136++)
							{
								Vector2 vector23 = this.position;
								int num137 = this.width;
								int num138 = this.height;
								int num139 = 5;
								float speedX23 = (float)(2 * hitDirection);
								float speedY23 = -2f;
								int num140 = 0;
								Dust.NewDust(vector23, num137, num138, num139, speedX23, speedY23, num140, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity * 0.8f, 89, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 90, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 91, 1f);
							Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 92, 1f);
						}
					}
					else if (this.type == 3 || this.type == 52 || this.type == 53 || this.type == 104 || this.type == 109 || this.type == 132)
					{
						if (this.life > 0)
						{
							int num141 = 0;
							while ((double)num141 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector24 = this.position;
								int num142 = this.width;
								int num143 = this.height;
								int num144 = 5;
								float speedX24 = (float)hitDirection;
								float speedY24 = -1f;
								int num145 = 0;
								Dust.NewDust(vector24, num142, num143, num144, speedX24, speedY24, num145, default(Color), 1f);
								num141++;
							}
						}
						else
						{
							for (int num146 = 0; num146 < 50; num146++)
							{
								Vector2 vector25 = this.position;
								int num147 = this.width;
								int num148 = this.height;
								int num149 = 5;
								float speedX25 = 2.5f * (float)hitDirection;
								float speedY25 = -2.5f;
								int num150 = 0;
								Dust.NewDust(vector25, num147, num148, num149, speedX25, speedY25, num150, default(Color), 1f);
							}
							if (this.type == 104)
							{
								Gore.NewGore(this.position, this.velocity, 117, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119, 1f);
							}
							else if (this.type == 109)
							{
								Gore.NewGore(this.position, this.velocity, 121, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 46f), this.velocity, 120, 1f);
							}
							else
							{
								if (this.type == 132)
								{
									Gore.NewGore(this.position, this.velocity, 154, 1f);
								}
								else
								{
									Gore.NewGore(this.position, this.velocity, 3, 1f);
								}
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5, 1f);
							}
						}
					}
					else if (this.type == 83 || this.type == 84)
					{
						if (this.life > 0)
						{
							int num151 = 0;
							while ((double)num151 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector26 = this.position;
								int num152 = this.width;
								int num153 = this.height;
								int num154 = 31;
								float speedX26 = 0f;
								float speedY26 = 0f;
								int num155 = 0;
								int num156 = Dust.NewDust(vector26, num152, num153, num154, speedX26, speedY26, num155, default(Color), 1.5f);
								Main.dust[num156].noGravity = true;
								num151++;
							}
						}
						else
						{
							for (int num157 = 0; num157 < 20; num157++)
							{
								Vector2 vector27 = this.position;
								int num158 = this.width;
								int num159 = this.height;
								int num160 = 31;
								float speedX27 = 0f;
								float speedY27 = 0f;
								int num161 = 0;
								int num162 = Dust.NewDust(vector27, num158, num159, num160, speedX27, speedY27, num161, default(Color), 1.5f);
								Dust dust8 = Main.dust[num162];
								dust8.velocity *= 2f;
								Main.dust[num162].noGravity = true;
							}
							int num163 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)Main.rand.Next(-2, 3), (float)Main.rand.Next(-2, 3)), 61, this.scale);
							Gore gore = Main.gore[num163];
							gore.velocity *= 0.5f;
							num163 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)Main.rand.Next(-2, 3), (float)Main.rand.Next(-2, 3)), 61, this.scale);
							Gore gore2 = Main.gore[num163];
							gore2.velocity *= 0.5f;
							num163 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)Main.rand.Next(-2, 3), (float)Main.rand.Next(-2, 3)), 61, this.scale);
							Gore gore3 = Main.gore[num163];
							gore3.velocity *= 0.5f;
						}
					}
					else if (this.type == 4 || this.type == 126 || this.type == 125)
					{
						if (this.life > 0)
						{
							int num164 = 0;
							while ((double)num164 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector28 = this.position;
								int num165 = this.width;
								int num166 = this.height;
								int num167 = 5;
								float speedX28 = (float)hitDirection;
								float speedY28 = -1f;
								int num168 = 0;
								Dust.NewDust(vector28, num165, num166, num167, speedX28, speedY28, num168, default(Color), 1f);
								num164++;
							}
						}
						else
						{
							for (int num169 = 0; num169 < 150; num169++)
							{
								Vector2 vector29 = this.position;
								int num170 = this.width;
								int num171 = this.height;
								int num172 = 5;
								float speedX29 = (float)(2 * hitDirection);
								float speedY29 = -2f;
								int num173 = 0;
								Dust.NewDust(vector29, num170, num171, num172, speedX29, speedY29, num173, default(Color), 1f);
							}
							for (int num174 = 0; num174 < 2; num174++)
							{
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 2, 1f);
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
								Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 9, 1f);
								if (this.type == 4)
								{
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 10, 1f);
									Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
								}
								else if (this.type == 125)
								{
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 146, 1f);
								}
								else if (this.type == 126)
								{
									Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 145, 1f);
								}
							}
							if (this.type == 125 || this.type == 126)
							{
								for (int num175 = 0; num175 < 10; num175++)
								{
									Vector2 vector30 = new Vector2(this.position.X, this.position.Y);
									int num176 = this.width;
									int num177 = this.height;
									int num178 = 31;
									float speedX30 = 0f;
									float speedY30 = 0f;
									int num179 = 100;
									Color newColor = default(Color);
									int num180 = Dust.NewDust(vector30, num176, num177, num178, speedX30, speedY30, num179, newColor, 1.5f);
									Dust dust9 = Main.dust[num180];
									dust9.velocity *= 1.4f;
								}
								for (int num181 = 0; num181 < 5; num181++)
								{
									Vector2 vector31 = new Vector2(this.position.X, this.position.Y);
									int num182 = this.width;
									int num183 = this.height;
									int num184 = 6;
									float speedX31 = 0f;
									float speedY31 = 0f;
									int num185 = 100;
									Color newColor = default(Color);
									int num186 = Dust.NewDust(vector31, num182, num183, num184, speedX31, speedY31, num185, newColor, 2.5f);
									Main.dust[num186].noGravity = true;
									Dust dust10 = Main.dust[num186];
									dust10.velocity *= 5f;
									Vector2 vector32 = new Vector2(this.position.X, this.position.Y);
									int num187 = this.width;
									int num188 = this.height;
									int num189 = 6;
									float speedX32 = 0f;
									float speedY32 = 0f;
									int num190 = 100;
									newColor = default(Color);
									num186 = Dust.NewDust(vector32, num187, num188, num189, speedX32, speedY32, num190, newColor, 1.5f);
									Dust dust11 = Main.dust[num186];
									dust11.velocity *= 3f;
								}
								Vector2 vector33 = new Vector2(this.position.X, this.position.Y);
								Vector2 vector34 = default(Vector2);
								int num191 = Gore.NewGore(vector33, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore4 = Main.gore[num191];
								gore4.velocity *= 0.4f;
								Gore gore5 = Main.gore[num191];
								gore5.velocity.X = gore5.velocity.X + 1f;
								Gore gore6 = Main.gore[num191];
								gore6.velocity.Y = gore6.velocity.Y + 1f;
								Vector2 vector35 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num191 = Gore.NewGore(vector35, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore7 = Main.gore[num191];
								gore7.velocity *= 0.4f;
								Gore gore8 = Main.gore[num191];
								gore8.velocity.X = gore8.velocity.X - 1f;
								Gore gore9 = Main.gore[num191];
								gore9.velocity.Y = gore9.velocity.Y + 1f;
								Vector2 vector36 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num191 = Gore.NewGore(vector36, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore10 = Main.gore[num191];
								gore10.velocity *= 0.4f;
								Gore gore11 = Main.gore[num191];
								gore11.velocity.X = gore11.velocity.X + 1f;
								Gore gore12 = Main.gore[num191];
								gore12.velocity.Y = gore12.velocity.Y - 1f;
								Vector2 vector37 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num191 = Gore.NewGore(vector37, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore13 = Main.gore[num191];
								gore13.velocity *= 0.4f;
								Gore gore14 = Main.gore[num191];
								gore14.velocity.X = gore14.velocity.X - 1f;
								Gore gore15 = Main.gore[num191];
								gore15.velocity.Y = gore15.velocity.Y - 1f;
							}
						}
					}
					else if (this.type == 5)
					{
						if (this.life > 0)
						{
							int num192 = 0;
							while ((double)num192 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector38 = this.position;
								int num193 = this.width;
								int num194 = this.height;
								int num195 = 5;
								float speedX33 = (float)hitDirection;
								float speedY33 = -1f;
								int num196 = 0;
								Dust.NewDust(vector38, num193, num194, num195, speedX33, speedY33, num196, default(Color), 1f);
								num192++;
							}
						}
						else
						{
							for (int num197 = 0; num197 < 20; num197++)
							{
								Vector2 vector39 = this.position;
								int num198 = this.width;
								int num199 = this.height;
								int num200 = 5;
								float speedX34 = (float)(2 * hitDirection);
								float speedY34 = -2f;
								int num201 = 0;
								Dust.NewDust(vector39, num198, num199, num200, speedX34, speedY34, num201, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 6, 1f);
							Gore.NewGore(this.position, this.velocity, 7, 1f);
						}
					}
					else if (this.type == 113 || this.type == 114)
					{
						if (this.life > 0)
						{
							for (int num202 = 0; num202 < 20; num202++)
							{
								Vector2 vector40 = this.position;
								int num203 = this.width;
								int num204 = this.height;
								int num205 = 5;
								float speedX35 = (float)hitDirection;
								float speedY35 = -1f;
								int num206 = 0;
								Dust.NewDust(vector40, num203, num204, num205, speedX35, speedY35, num206, default(Color), 1f);
							}
						}
						else
						{
							for (int num207 = 0; num207 < 50; num207++)
							{
								Vector2 vector41 = this.position;
								int num208 = this.width;
								int num209 = this.height;
								int num210 = 5;
								float speedX36 = (float)(2 * hitDirection);
								float speedY36 = -1f;
								int num211 = 0;
								Dust.NewDust(vector41, num208, num209, num210, speedX36, speedY36, num211, default(Color), 1f);
							}
							if (this.type == 114)
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 137, this.scale);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2)), this.velocity, 139, this.scale);
								Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y), this.velocity, 139, this.scale);
								Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), this.velocity, 137, this.scale);
							}
							else
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 137, this.scale);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2)), this.velocity, 138, this.scale);
								Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y), this.velocity, 138, this.scale);
								Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), this.velocity, 137, this.scale);
								if (Main.player[Main.myPlayer].position.Y / 16f > (float)(Main.maxTilesY - 250))
								{
									int num212 = (int)Main.screenPosition.Y;
									int num213 = num212 + Main.screenWidth;
									int num214 = (int)this.position.X;
									if (this.direction > 0)
									{
										num214 -= 80;
									}
									int num215 = num214 + 140;
									int num216 = num214;
									for (int num217 = num212; num217 < num213; num217 += 50)
									{
										while (num216 < num215)
										{
											for (int num218 = 0; num218 < 5; num218++)
											{
												Vector2 vector42 = new Vector2((float)num216, (float)num217);
												int num219 = 32;
												int num220 = 32;
												int num221 = 5;
												float speedX37 = (float)Main.rand.Next(-60, 61) * 0.1f;
												float speedY37 = (float)Main.rand.Next(-60, 61) * 0.1f;
												int num222 = 0;
												Color newColor = default(Color);
												Dust.NewDust(vector42, num219, num220, num221, speedX37, speedY37, num222, newColor, 1f);
											}
											Vector2 vector43 = new Vector2((float)Main.rand.Next(-80, 81) * 0.1f, (float)Main.rand.Next(-60, 21) * 0.1f);
											Gore.NewGore(new Vector2((float)num216, (float)num217), vector43, Main.rand.Next(140, 143), 1f);
											num216 += 46;
										}
										num216 = num214;
									}
								}
							}
						}
					}
					else if (this.type == 115 || this.type == 116)
					{
						if (this.life > 0)
						{
							for (int num223 = 0; num223 < 5; num223++)
							{
								Vector2 vector44 = this.position;
								int num224 = this.width;
								int num225 = this.height;
								int num226 = 5;
								float speedX38 = (float)hitDirection;
								float speedY38 = -1f;
								int num227 = 0;
								Dust.NewDust(vector44, num224, num225, num226, speedX38, speedY38, num227, default(Color), 1f);
							}
						}
						else if (this.type == 115 && Main.netMode != 1)
						{
							NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), 116, 0);
							for (int num228 = 0; num228 < 10; num228++)
							{
								Vector2 vector45 = this.position;
								int num229 = this.width;
								int num230 = this.height;
								int num231 = 5;
								float speedX39 = (float)hitDirection;
								float speedY39 = -1f;
								int num232 = 0;
								Dust.NewDust(vector45, num229, num230, num231, speedX39, speedY39, num232, default(Color), 1f);
							}
						}
						else
						{
							for (int num233 = 0; num233 < 20; num233++)
							{
								Vector2 vector46 = this.position;
								int num234 = this.width;
								int num235 = this.height;
								int num236 = 5;
								float speedX40 = (float)hitDirection;
								float speedY40 = -1f;
								int num237 = 0;
								Dust.NewDust(vector46, num234, num235, num236, speedX40, speedY40, num237, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 132, this.scale);
							Gore.NewGore(this.position, this.velocity, 133, this.scale);
						}
					}
					else if (this.type >= 117 && this.type <= 119)
					{
						if (this.life > 0)
						{
							for (int num238 = 0; num238 < 5; num238++)
							{
								Vector2 vector47 = this.position;
								int num239 = this.width;
								int num240 = this.height;
								int num241 = 5;
								float speedX41 = (float)hitDirection;
								float speedY41 = -1f;
								int num242 = 0;
								Dust.NewDust(vector47, num239, num240, num241, speedX41, speedY41, num242, default(Color), 1f);
							}
						}
						else
						{
							for (int num243 = 0; num243 < 10; num243++)
							{
								Vector2 vector48 = this.position;
								int num244 = this.width;
								int num245 = this.height;
								int num246 = 5;
								float speedX42 = (float)hitDirection;
								float speedY42 = -1f;
								int num247 = 0;
								Dust.NewDust(vector48, num244, num245, num246, speedX42, speedY42, num247, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 134 + this.type - 117, this.scale);
						}
					}
					else if (this.type == 6 || this.type == 94)
					{
						if (this.life > 0)
						{
							int num248 = 0;
							while ((double)num248 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num248++;
							}
						}
						else
						{
							for (int num249 = 0; num249 < 50; num249++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							if (this.type == 94)
							{
								int num250 = Gore.NewGore(this.position, this.velocity, 108, this.scale);
								num250 = Gore.NewGore(this.position, this.velocity, 108, this.scale);
								num250 = Gore.NewGore(this.position, this.velocity, 109, this.scale);
								num250 = Gore.NewGore(this.position, this.velocity, 110, this.scale);
							}
							else
							{
								int num250 = Gore.NewGore(this.position, this.velocity, 14, this.scale);
								Main.gore[num250].alpha = this.alpha;
								num250 = Gore.NewGore(this.position, this.velocity, 15, this.scale);
								Main.gore[num250].alpha = this.alpha;
							}
						}
					}
					else if (this.type == 101)
					{
						if (this.life > 0)
						{
							int num251 = 0;
							while ((double)num251 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num251++;
							}
						}
						else
						{
							for (int num252 = 0; num252 < 50; num252++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							Gore.NewGore(this.position, this.velocity, 110, this.scale);
							Gore.NewGore(this.position, this.velocity, 114, this.scale);
							Gore.NewGore(this.position, this.velocity, 114, this.scale);
							Gore.NewGore(this.position, this.velocity, 115, this.scale);
						}
					}
					else if (this.type == 7 || this.type == 8 || this.type == 9)
					{
						if (this.life > 0)
						{
							int num253 = 0;
							while ((double)num253 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num253++;
							}
						}
						else
						{
							for (int num254 = 0; num254 < 50; num254++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							int num255 = Gore.NewGore(this.position, this.velocity, this.type - 7 + 18, 1f);
							Main.gore[num255].alpha = this.alpha;
						}
					}
					else if (this.type == 98 || this.type == 99 || this.type == 100)
					{
						if (this.life > 0)
						{
							int num256 = 0;
							while ((double)num256 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num256++;
							}
						}
						else
						{
							for (int num257 = 0; num257 < 50; num257++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							int num258 = Gore.NewGore(this.position, this.velocity, 110, 1f);
							Main.gore[num258].alpha = this.alpha;
						}
					}
					else if (this.type == 10 || this.type == 11 || this.type == 12)
					{
						if (this.life > 0)
						{
							int num259 = 0;
							while ((double)num259 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector49 = this.position;
								int num260 = this.width;
								int num261 = this.height;
								int num262 = 5;
								float speedX43 = (float)hitDirection;
								float speedY43 = -1f;
								int num263 = 0;
								Dust.NewDust(vector49, num260, num261, num262, speedX43, speedY43, num263, default(Color), 1f);
								num259++;
							}
						}
						else
						{
							for (int num264 = 0; num264 < 10; num264++)
							{
								Vector2 vector50 = this.position;
								int num265 = this.width;
								int num266 = this.height;
								int num267 = 5;
								float speedX44 = 2.5f * (float)hitDirection;
								float speedY44 = -2.5f;
								int num268 = 0;
								Dust.NewDust(vector50, num265, num266, num267, speedX44, speedY44, num268, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, this.type - 7 + 18, 1f);
						}
					}
					else if (this.type == 95 || this.type == 96 || this.type == 97)
					{
						if (this.life > 0)
						{
							int num269 = 0;
							while ((double)num269 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector51 = this.position;
								int num270 = this.width;
								int num271 = this.height;
								int num272 = 5;
								float speedX45 = (float)hitDirection;
								float speedY45 = -1f;
								int num273 = 0;
								Dust.NewDust(vector51, num270, num271, num272, speedX45, speedY45, num273, default(Color), 1f);
								num269++;
							}
						}
						else
						{
							for (int num274 = 0; num274 < 10; num274++)
							{
								Vector2 vector52 = this.position;
								int num275 = this.width;
								int num276 = this.height;
								int num277 = 5;
								float speedX46 = 2.5f * (float)hitDirection;
								float speedY46 = -2.5f;
								int num278 = 0;
								Dust.NewDust(vector52, num275, num276, num277, speedX46, speedY46, num278, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, this.type - 95 + 111, 1f);
						}
					}
					else if (this.type == 13 || this.type == 14 || this.type == 15)
					{
						if (this.life > 0)
						{
							int num279 = 0;
							while ((double)num279 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num279++;
							}
						}
						else
						{
							for (int num280 = 0; num280 < 50; num280++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							if (this.type == 13)
							{
								Gore.NewGore(this.position, this.velocity, 24, 1f);
								Gore.NewGore(this.position, this.velocity, 25, 1f);
							}
							else if (this.type == 14)
							{
								Gore.NewGore(this.position, this.velocity, 26, 1f);
								Gore.NewGore(this.position, this.velocity, 27, 1f);
							}
							else
							{
								Gore.NewGore(this.position, this.velocity, 28, 1f);
								Gore.NewGore(this.position, this.velocity, 29, 1f);
							}
						}
					}
					else if (this.type == 17)
					{
						if (this.life > 0)
						{
							int num281 = 0;
							while ((double)num281 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector53 = this.position;
								int num282 = this.width;
								int num283 = this.height;
								int num284 = 5;
								float speedX47 = (float)hitDirection;
								float speedY47 = -1f;
								int num285 = 0;
								Dust.NewDust(vector53, num282, num283, num284, speedX47, speedY47, num285, default(Color), 1f);
								num281++;
							}
						}
						else
						{
							for (int num286 = 0; num286 < 50; num286++)
							{
								Vector2 vector54 = this.position;
								int num287 = this.width;
								int num288 = this.height;
								int num289 = 5;
								float speedX48 = 2.5f * (float)hitDirection;
								float speedY48 = -2.5f;
								int num290 = 0;
								Dust.NewDust(vector54, num287, num288, num289, speedX48, speedY48, num290, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 30, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32, 1f);
						}
					}
					else if (this.type == 86)
					{
						if (this.life > 0)
						{
							int num291 = 0;
							while ((double)num291 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector55 = this.position;
								int num292 = this.width;
								int num293 = this.height;
								int num294 = 5;
								float speedX49 = (float)hitDirection;
								float speedY49 = -1f;
								int num295 = 0;
								Dust.NewDust(vector55, num292, num293, num294, speedX49, speedY49, num295, default(Color), 1f);
								num291++;
							}
						}
						else
						{
							for (int num296 = 0; num296 < 50; num296++)
							{
								Vector2 vector56 = this.position;
								int num297 = this.width;
								int num298 = this.height;
								int num299 = 5;
								float speedX50 = 2.5f * (float)hitDirection;
								float speedY50 = -2.5f;
								int num300 = 0;
								Dust.NewDust(vector56, num297, num298, num299, speedX50, speedY50, num300, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 101, 1f);
							Gore.NewGore(this.position, this.velocity, 102, 1f);
							Gore.NewGore(this.position, this.velocity, 103, 1f);
							Gore.NewGore(this.position, this.velocity, 103, 1f);
							Gore.NewGore(this.position, this.velocity, 104, 1f);
							Gore.NewGore(this.position, this.velocity, 104, 1f);
							Gore.NewGore(this.position, this.velocity, 105, 1f);
						}
					}
					else if (this.type >= 105 && this.type <= 108)
					{
						if (this.life > 0)
						{
							int num301 = 0;
							while ((double)num301 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector57 = this.position;
								int num302 = this.width;
								int num303 = this.height;
								int num304 = 5;
								float speedX51 = (float)hitDirection;
								float speedY51 = -1f;
								int num305 = 0;
								Dust.NewDust(vector57, num302, num303, num304, speedX51, speedY51, num305, default(Color), 1f);
								num301++;
							}
						}
						else
						{
							for (int num306 = 0; num306 < 50; num306++)
							{
								Vector2 vector58 = this.position;
								int num307 = this.width;
								int num308 = this.height;
								int num309 = 5;
								float speedX52 = 2.5f * (float)hitDirection;
								float speedY52 = -2.5f;
								int num310 = 0;
								Dust.NewDust(vector58, num307, num308, num309, speedX52, speedY52, num310, default(Color), 1f);
							}
							if (this.type == 105 || this.type == 107)
							{
								Gore.NewGore(this.position, this.velocity, 124, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126, 1f);
							}
							else
							{
								Gore.NewGore(this.position, this.velocity, 127, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129, 1f);
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129, 1f);
							}
						}
					}
					else if (this.type == 123 || this.type == 124)
					{
						if (this.life > 0)
						{
							int num311 = 0;
							while ((double)num311 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector59 = this.position;
								int num312 = this.width;
								int num313 = this.height;
								int num314 = 5;
								float speedX53 = (float)hitDirection;
								float speedY53 = -1f;
								int num315 = 0;
								Dust.NewDust(vector59, num312, num313, num314, speedX53, speedY53, num315, default(Color), 1f);
								num311++;
							}
						}
						else
						{
							for (int num316 = 0; num316 < 50; num316++)
							{
								Vector2 vector60 = this.position;
								int num317 = this.width;
								int num318 = this.height;
								int num319 = 5;
								float speedX54 = 2.5f * (float)hitDirection;
								float speedY54 = -2.5f;
								int num320 = 0;
								Dust.NewDust(vector60, num317, num318, num319, speedX54, speedY54, num320, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 151, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153, 1f);
						}
					}
					else if (this.type == 22)
					{
						if (this.life > 0)
						{
							int num321 = 0;
							while ((double)num321 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector61 = this.position;
								int num322 = this.width;
								int num323 = this.height;
								int num324 = 5;
								float speedX55 = (float)hitDirection;
								float speedY55 = -1f;
								int num325 = 0;
								Dust.NewDust(vector61, num322, num323, num324, speedX55, speedY55, num325, default(Color), 1f);
								num321++;
							}
						}
						else
						{
							for (int num326 = 0; num326 < 50; num326++)
							{
								Vector2 vector62 = this.position;
								int num327 = this.width;
								int num328 = this.height;
								int num329 = 5;
								float speedX56 = 2.5f * (float)hitDirection;
								float speedY56 = -2.5f;
								int num330 = 0;
								Dust.NewDust(vector62, num327, num328, num329, speedX56, speedY56, num330, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 73, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75, 1f);
						}
					}
					else if (this.type == 142)
					{
						if (this.life > 0)
						{
							int num331 = 0;
							while ((double)num331 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector63 = this.position;
								int num332 = this.width;
								int num333 = this.height;
								int num334 = 5;
								float speedX57 = (float)hitDirection;
								float speedY57 = -1f;
								int num335 = 0;
								Dust.NewDust(vector63, num332, num333, num334, speedX57, speedY57, num335, default(Color), 1f);
								num331++;
							}
						}
						else
						{
							for (int num336 = 0; num336 < 50; num336++)
							{
								Vector2 vector64 = this.position;
								int num337 = this.width;
								int num338 = this.height;
								int num339 = 5;
								float speedX58 = 2.5f * (float)hitDirection;
								float speedY58 = -2.5f;
								int num340 = 0;
								Dust.NewDust(vector64, num337, num338, num339, speedX58, speedY58, num340, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 157, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159, 1f);
						}
					}
					else if (this.type == 37 || this.type == 54)
					{
						if (this.life > 0)
						{
							int num341 = 0;
							while ((double)num341 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector65 = this.position;
								int num342 = this.width;
								int num343 = this.height;
								int num344 = 5;
								float speedX59 = (float)hitDirection;
								float speedY59 = -1f;
								int num345 = 0;
								Dust.NewDust(vector65, num342, num343, num344, speedX59, speedY59, num345, default(Color), 1f);
								num341++;
							}
						}
						else
						{
							for (int num346 = 0; num346 < 50; num346++)
							{
								Vector2 vector66 = this.position;
								int num347 = this.width;
								int num348 = this.height;
								int num349 = 5;
								float speedX60 = 2.5f * (float)hitDirection;
								float speedY60 = -2.5f;
								int num350 = 0;
								Dust.NewDust(vector66, num347, num348, num349, speedX60, speedY60, num350, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 58, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60, 1f);
						}
					}
					else if (this.type == 18)
					{
						if (this.life > 0)
						{
							int num351 = 0;
							while ((double)num351 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector67 = this.position;
								int num352 = this.width;
								int num353 = this.height;
								int num354 = 5;
								float speedX61 = (float)hitDirection;
								float speedY61 = -1f;
								int num355 = 0;
								Dust.NewDust(vector67, num352, num353, num354, speedX61, speedY61, num355, default(Color), 1f);
								num351++;
							}
						}
						else
						{
							for (int num356 = 0; num356 < 50; num356++)
							{
								Vector2 vector68 = this.position;
								int num357 = this.width;
								int num358 = this.height;
								int num359 = 5;
								float speedX62 = 2.5f * (float)hitDirection;
								float speedY62 = -2.5f;
								int num360 = 0;
								Dust.NewDust(vector68, num357, num358, num359, speedX62, speedY62, num360, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 33, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35, 1f);
						}
					}
					else if (this.type == 19)
					{
						if (this.life > 0)
						{
							int num361 = 0;
							while ((double)num361 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector69 = this.position;
								int num362 = this.width;
								int num363 = this.height;
								int num364 = 5;
								float speedX63 = (float)hitDirection;
								float speedY63 = -1f;
								int num365 = 0;
								Dust.NewDust(vector69, num362, num363, num364, speedX63, speedY63, num365, default(Color), 1f);
								num361++;
							}
						}
						else
						{
							for (int num366 = 0; num366 < 50; num366++)
							{
								Vector2 vector70 = this.position;
								int num367 = this.width;
								int num368 = this.height;
								int num369 = 5;
								float speedX64 = 2.5f * (float)hitDirection;
								float speedY64 = -2.5f;
								int num370 = 0;
								Dust.NewDust(vector70, num367, num368, num369, speedX64, speedY64, num370, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 36, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38, 1f);
						}
					}
					else if (this.type == 38)
					{
						if (this.life > 0)
						{
							int num371 = 0;
							while ((double)num371 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector71 = this.position;
								int num372 = this.width;
								int num373 = this.height;
								int num374 = 5;
								float speedX65 = (float)hitDirection;
								float speedY65 = -1f;
								int num375 = 0;
								Dust.NewDust(vector71, num372, num373, num374, speedX65, speedY65, num375, default(Color), 1f);
								num371++;
							}
						}
						else
						{
							for (int num376 = 0; num376 < 50; num376++)
							{
								Vector2 vector72 = this.position;
								int num377 = this.width;
								int num378 = this.height;
								int num379 = 5;
								float speedX66 = 2.5f * (float)hitDirection;
								float speedY66 = -2.5f;
								int num380 = 0;
								Dust.NewDust(vector72, num377, num378, num379, speedX66, speedY66, num380, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 64, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66, 1f);
						}
					}
					else if (this.type == 20)
					{
						if (this.life > 0)
						{
							int num381 = 0;
							while ((double)num381 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector73 = this.position;
								int num382 = this.width;
								int num383 = this.height;
								int num384 = 5;
								float speedX67 = (float)hitDirection;
								float speedY67 = -1f;
								int num385 = 0;
								Dust.NewDust(vector73, num382, num383, num384, speedX67, speedY67, num385, default(Color), 1f);
								num381++;
							}
						}
						else
						{
							for (int num386 = 0; num386 < 50; num386++)
							{
								Vector2 vector74 = this.position;
								int num387 = this.width;
								int num388 = this.height;
								int num389 = 5;
								float speedX68 = 2.5f * (float)hitDirection;
								float speedY68 = -2.5f;
								int num390 = 0;
								Dust.NewDust(vector74, num387, num388, num389, speedX68, speedY68, num390, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 39, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41, 1f);
						}
					}
					else if (this.type == 21 || this.type == 31 || this.type == 32 || this.type == 44 || this.type == 45 || this.type == 77 || this.type == 110)
					{
						if (this.life > 0)
						{
							int num391 = 0;
							while ((double)num391 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector75 = this.position;
								int num392 = this.width;
								int num393 = this.height;
								int num394 = 26;
								float speedX69 = (float)hitDirection;
								float speedY69 = -1f;
								int num395 = 0;
								Dust.NewDust(vector75, num392, num393, num394, speedX69, speedY69, num395, default(Color), 1f);
								num391++;
							}
						}
						else
						{
							for (int num396 = 0; num396 < 20; num396++)
							{
								Vector2 vector76 = this.position;
								int num397 = this.width;
								int num398 = this.height;
								int num399 = 26;
								float speedX70 = 2.5f * (float)hitDirection;
								float speedY70 = -2.5f;
								int num400 = 0;
								Dust.NewDust(vector76, num397, num398, num399, speedX70, speedY70, num400, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 42, this.scale);
							if (this.type == 77)
							{
								Gore.NewGore(this.position, this.velocity, 106, this.scale);
							}
							if (this.type == 110)
							{
								Gore.NewGore(this.position, this.velocity, 130, this.scale);
							}
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 43, this.scale);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 43, this.scale);
							if (this.type == 110)
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, this.scale);
							}
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 44, this.scale);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 44, this.scale);
						}
					}
					else if (this.type == 85)
					{
						int num401 = 7;
						if (this.ai[3] == 2f)
						{
							num401 = 10;
						}
						if (this.ai[3] == 3f)
						{
							num401 = 37;
						}
						if (this.life > 0)
						{
							int num402 = 0;
							while ((double)num402 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector77 = this.position;
								int num403 = this.width;
								int num404 = this.height;
								int num405 = num401;
								float speedX71 = 0f;
								float speedY71 = 0f;
								int num406 = 0;
								Dust.NewDust(vector77, num403, num404, num405, speedX71, speedY71, num406, default(Color), 1f);
								num402++;
							}
						}
						else
						{
							for (int num407 = 0; num407 < 20; num407++)
							{
								Vector2 vector78 = this.position;
								int num408 = this.width;
								int num409 = this.height;
								int num410 = num401;
								float speedX72 = 0f;
								float speedY72 = 0f;
								int num411 = 0;
								Dust.NewDust(vector78, num408, num409, num410, speedX72, speedY72, num411, default(Color), 1f);
							}
							int num412 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float)hitDirection, 0f), 61, this.scale);
							Gore gore16 = Main.gore[num412];
							gore16.velocity *= 0.3f;
							num412 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)hitDirection, 0f), 62, this.scale);
							Gore gore17 = Main.gore[num412];
							gore17.velocity *= 0.3f;
							num412 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)this.height - 10f), new Vector2((float)hitDirection, 0f), 63, this.scale);
							Gore gore18 = Main.gore[num412];
							gore18.velocity *= 0.3f;
						}
					}
					else if (this.type >= 87 && this.type <= 92)
					{
						if (this.life > 0)
						{
							int num413 = 0;
							while ((double)num413 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector79 = this.position;
								int num414 = this.width;
								int num415 = this.height;
								int num416 = 16;
								float speedX73 = 0f;
								float speedY73 = 0f;
								int num417 = 0;
								int num418 = Dust.NewDust(vector79, num414, num415, num416, speedX73, speedY73, num417, default(Color), 1.5f);
								Dust dust12 = Main.dust[num418];
								dust12.velocity *= 1.5f;
								Main.dust[num418].noGravity = true;
								num413++;
							}
						}
						else
						{
							for (int num419 = 0; num419 < 10; num419++)
							{
								Vector2 vector80 = this.position;
								int num420 = this.width;
								int num421 = this.height;
								int num422 = 16;
								float speedX74 = 0f;
								float speedY74 = 0f;
								int num423 = 0;
								int num424 = Dust.NewDust(vector80, num420, num421, num422, speedX74, speedY74, num423, default(Color), 1.5f);
								Dust dust13 = Main.dust[num424];
								dust13.velocity *= 2f;
								Main.dust[num424].noGravity = true;
							}
							int num425 = Main.rand.Next(1, 4);
							for (int num426 = 0; num426 < num425; num426++)
							{
								int num427 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)hitDirection, 0f), Main.rand.Next(11, 14), this.scale);
								Gore gore19 = Main.gore[num427];
								gore19.velocity *= 0.8f;
							}
						}
					}
					else if (this.type == 78 || this.type == 79 || this.type == 80)
					{
						if (this.life > 0)
						{
							int num428 = 0;
							while ((double)num428 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector81 = this.position;
								int num429 = this.width;
								int num430 = this.height;
								int num431 = 31;
								float speedX75 = 0f;
								float speedY75 = 0f;
								int num432 = 0;
								int num433 = Dust.NewDust(vector81, num429, num430, num431, speedX75, speedY75, num432, default(Color), 1.5f);
								Dust dust14 = Main.dust[num433];
								dust14.velocity *= 2f;
								Main.dust[num433].noGravity = true;
								num428++;
							}
						}
						else
						{
							for (int num434 = 0; num434 < 20; num434++)
							{
								Vector2 vector82 = this.position;
								int num435 = this.width;
								int num436 = this.height;
								int num437 = 31;
								float speedX76 = 0f;
								float speedY76 = 0f;
								int num438 = 0;
								int num439 = Dust.NewDust(vector82, num435, num436, num437, speedX76, speedY76, num438, default(Color), 1.5f);
								Dust dust15 = Main.dust[num439];
								dust15.velocity *= 2f;
								Main.dust[num439].noGravity = true;
							}
							int num440 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float)hitDirection, 0f), 61, this.scale);
							Gore gore20 = Main.gore[num440];
							gore20.velocity *= 0.3f;
							num440 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 10f), new Vector2((float)hitDirection, 0f), 62, this.scale);
							Gore gore21 = Main.gore[num440];
							gore21.velocity *= 0.3f;
							num440 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)this.height - 10f), new Vector2((float)hitDirection, 0f), 63, this.scale);
							Gore gore22 = Main.gore[num440];
							gore22.velocity *= 0.3f;
						}
					}
					else if (this.type == 82)
					{
						if (this.life > 0)
						{
							int num441 = 0;
							while ((double)num441 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector83 = this.position;
								int num442 = this.width;
								int num443 = this.height;
								int num444 = 54;
								float speedX77 = 0f;
								float speedY77 = 0f;
								int num445 = 50;
								int num446 = Dust.NewDust(vector83, num442, num443, num444, speedX77, speedY77, num445, default(Color), 1.5f);
								Dust dust16 = Main.dust[num446];
								dust16.velocity *= 2f;
								Main.dust[num446].noGravity = true;
								num441++;
							}
						}
						else
						{
							for (int num447 = 0; num447 < 20; num447++)
							{
								Vector2 vector84 = this.position;
								int num448 = this.width;
								int num449 = this.height;
								int num450 = 54;
								float speedX78 = 0f;
								float speedY78 = 0f;
								int num451 = 50;
								int num452 = Dust.NewDust(vector84, num448, num449, num450, speedX78, speedY78, num451, default(Color), 1.5f);
								Dust dust17 = Main.dust[num452];
								dust17.velocity *= 2f;
								Main.dust[num452].noGravity = true;
							}
							int num453 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore23 = Main.gore[num453];
							gore23.velocity *= 0.3f;
							num453 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 15f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore24 = Main.gore[num453];
							gore24.velocity *= 0.3f;
							num453 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)this.height - 20f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore25 = Main.gore[num453];
							gore25.velocity *= 0.3f;
						}
					}
					else if (this.type == 140)
					{
						if (this.life <= 0)
						{
							for (int num454 = 0; num454 < 20; num454++)
							{
								Vector2 vector85 = this.position;
								int num455 = this.width;
								int num456 = this.height;
								int num457 = 54;
								float speedX79 = 0f;
								float speedY79 = 0f;
								int num458 = 50;
								int num459 = Dust.NewDust(vector85, num455, num456, num457, speedX79, speedY79, num458, default(Color), 1.5f);
								Dust dust18 = Main.dust[num459];
								dust18.velocity *= 2f;
								Main.dust[num459].noGravity = true;
							}
							int num460 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore26 = Main.gore[num460];
							gore26.velocity *= 0.3f;
							num460 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 15f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore27 = Main.gore[num460];
							gore27.velocity *= 0.3f;
							num460 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float)this.height - 20f), new Vector2((float)hitDirection, 0f), 99, this.scale);
							Gore gore28 = Main.gore[num460];
							gore28.velocity *= 0.3f;
						}
					}
					else if (this.type == 39 || this.type == 40 || this.type == 41)
					{
						if (this.life > 0)
						{
							int num461 = 0;
							while ((double)num461 < dmg / (double)this.lifeMax * 50.0)
							{
								Vector2 vector86 = this.position;
								int num462 = this.width;
								int num463 = this.height;
								int num464 = 26;
								float speedX80 = (float)hitDirection;
								float speedY80 = -1f;
								int num465 = 0;
								Dust.NewDust(vector86, num462, num463, num464, speedX80, speedY80, num465, default(Color), 1f);
								num461++;
							}
						}
						else
						{
							for (int num466 = 0; num466 < 20; num466++)
							{
								Vector2 vector87 = this.position;
								int num467 = this.width;
								int num468 = this.height;
								int num469 = 26;
								float speedX81 = 2.5f * (float)hitDirection;
								float speedY81 = -2.5f;
								int num470 = 0;
								Dust.NewDust(vector87, num467, num468, num469, speedX81, speedY81, num470, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, this.type - 39 + 67, 1f);
						}
					}
					else if (this.type == 34)
					{
						if (this.life > 0)
						{
							int num471 = 0;
							while ((double)num471 < dmg / (double)this.lifeMax * 30.0)
							{
								Vector2 vector88 = new Vector2(this.position.X, this.position.Y);
								int num472 = this.width;
								int num473 = this.height;
								int num474 = 15;
								float speedX82 = -this.velocity.X * 0.2f;
								float speedY82 = -this.velocity.Y * 0.2f;
								int num475 = 100;
								Color newColor = default(Color);
								int num476 = Dust.NewDust(vector88, num472, num473, num474, speedX82, speedY82, num475, newColor, 1.8f);
								Main.dust[num476].noLight = true;
								Main.dust[num476].noGravity = true;
								Dust dust19 = Main.dust[num476];
								dust19.velocity *= 1.3f;
								Vector2 vector89 = new Vector2(this.position.X, this.position.Y);
								int num477 = this.width;
								int num478 = this.height;
								int num479 = 26;
								float speedX83 = -this.velocity.X * 0.2f;
								float speedY83 = -this.velocity.Y * 0.2f;
								int num480 = 0;
								newColor = default(Color);
								num476 = Dust.NewDust(vector89, num477, num478, num479, speedX83, speedY83, num480, newColor, 0.9f);
								Main.dust[num476].noLight = true;
								Dust dust20 = Main.dust[num476];
								dust20.velocity *= 1.3f;
								num471++;
							}
						}
						else
						{
							for (int num481 = 0; num481 < 15; num481++)
							{
								Vector2 vector90 = new Vector2(this.position.X, this.position.Y);
								int num482 = this.width;
								int num483 = this.height;
								int num484 = 15;
								float speedX84 = -this.velocity.X * 0.2f;
								float speedY84 = -this.velocity.Y * 0.2f;
								int num485 = 100;
								Color newColor = default(Color);
								int num486 = Dust.NewDust(vector90, num482, num483, num484, speedX84, speedY84, num485, newColor, 1.8f);
								Main.dust[num486].noLight = true;
								Main.dust[num486].noGravity = true;
								Dust dust21 = Main.dust[num486];
								dust21.velocity *= 1.3f;
								Vector2 vector91 = new Vector2(this.position.X, this.position.Y);
								int num487 = this.width;
								int num488 = this.height;
								int num489 = 26;
								float speedX85 = -this.velocity.X * 0.2f;
								float speedY85 = -this.velocity.Y * 0.2f;
								int num490 = 0;
								newColor = default(Color);
								num486 = Dust.NewDust(vector91, num487, num488, num489, speedX85, speedY85, num490, newColor, 0.9f);
								Main.dust[num486].noLight = true;
								Dust dust22 = Main.dust[num486];
								dust22.velocity *= 1.3f;
							}
						}
					}
					else if (this.type == 35 || this.type == 36)
					{
						if (this.life > 0)
						{
							int num491 = 0;
							while ((double)num491 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector92 = this.position;
								int num492 = this.width;
								int num493 = this.height;
								int num494 = 26;
								float speedX86 = (float)hitDirection;
								float speedY86 = -1f;
								int num495 = 0;
								Dust.NewDust(vector92, num492, num493, num494, speedX86, speedY86, num495, default(Color), 1f);
								num491++;
							}
						}
						else
						{
							for (int num496 = 0; num496 < 150; num496++)
							{
								Vector2 vector93 = this.position;
								int num497 = this.width;
								int num498 = this.height;
								int num499 = 26;
								float speedX87 = 2.5f * (float)hitDirection;
								float speedY87 = -2.5f;
								int num500 = 0;
								Dust.NewDust(vector93, num497, num498, num499, speedX87, speedY87, num500, default(Color), 1f);
							}
							if (this.type == 35)
							{
								Gore.NewGore(this.position, this.velocity, 54, 1f);
								Gore.NewGore(this.position, this.velocity, 55, 1f);
							}
							else
							{
								Gore.NewGore(this.position, this.velocity, 56, 1f);
								Gore.NewGore(this.position, this.velocity, 57, 1f);
								Gore.NewGore(this.position, this.velocity, 57, 1f);
								Gore.NewGore(this.position, this.velocity, 57, 1f);
							}
						}
					}
					else if (this.type == 139)
					{
						if (this.life <= 0)
						{
							for (int num501 = 0; num501 < 10; num501++)
							{
								Vector2 vector94 = new Vector2(this.position.X, this.position.Y);
								int num502 = this.width;
								int num503 = this.height;
								int num504 = 31;
								float speedX88 = 0f;
								float speedY88 = 0f;
								int num505 = 100;
								Color newColor = default(Color);
								int num506 = Dust.NewDust(vector94, num502, num503, num504, speedX88, speedY88, num505, newColor, 1.5f);
								Dust dust23 = Main.dust[num506];
								dust23.velocity *= 1.4f;
							}
							for (int num507 = 0; num507 < 5; num507++)
							{
								Vector2 vector95 = new Vector2(this.position.X, this.position.Y);
								int num508 = this.width;
								int num509 = this.height;
								int num510 = 6;
								float speedX89 = 0f;
								float speedY89 = 0f;
								int num511 = 100;
								Color newColor = default(Color);
								int num512 = Dust.NewDust(vector95, num508, num509, num510, speedX89, speedY89, num511, newColor, 2.5f);
								Main.dust[num512].noGravity = true;
								Dust dust24 = Main.dust[num512];
								dust24.velocity *= 5f;
								Vector2 vector96 = new Vector2(this.position.X, this.position.Y);
								int num513 = this.width;
								int num514 = this.height;
								int num515 = 6;
								float speedX90 = 0f;
								float speedY90 = 0f;
								int num516 = 100;
								newColor = default(Color);
								num512 = Dust.NewDust(vector96, num513, num514, num515, speedX90, speedY90, num516, newColor, 1.5f);
								Dust dust25 = Main.dust[num512];
								dust25.velocity *= 3f;
							}
							Vector2 vector97 = new Vector2(this.position.X, this.position.Y);
							Vector2 vector34 = default(Vector2);
							int num517 = Gore.NewGore(vector97, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore29 = Main.gore[num517];
							gore29.velocity *= 0.4f;
							Gore gore30 = Main.gore[num517];
							gore30.velocity.X = gore30.velocity.X + 1f;
							Gore gore31 = Main.gore[num517];
							gore31.velocity.Y = gore31.velocity.Y + 1f;
							Vector2 vector98 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num517 = Gore.NewGore(vector98, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore32 = Main.gore[num517];
							gore32.velocity *= 0.4f;
							Gore gore33 = Main.gore[num517];
							gore33.velocity.X = gore33.velocity.X - 1f;
							Gore gore34 = Main.gore[num517];
							gore34.velocity.Y = gore34.velocity.Y + 1f;
							Vector2 vector99 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num517 = Gore.NewGore(vector99, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore35 = Main.gore[num517];
							gore35.velocity *= 0.4f;
							Gore gore36 = Main.gore[num517];
							gore36.velocity.X = gore36.velocity.X + 1f;
							Gore gore37 = Main.gore[num517];
							gore37.velocity.Y = gore37.velocity.Y - 1f;
							Vector2 vector100 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num517 = Gore.NewGore(vector100, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore38 = Main.gore[num517];
							gore38.velocity *= 0.4f;
							Gore gore39 = Main.gore[num517];
							gore39.velocity.X = gore39.velocity.X - 1f;
							Gore gore40 = Main.gore[num517];
							gore40.velocity.Y = gore40.velocity.Y - 1f;
						}
					}
					else if (this.type >= 134 && this.type <= 136)
					{
						if (this.type == 135 && this.life > 0 && Main.netMode != 1 && this.ai[2] == 0f && Main.rand.Next(25) == 0)
						{
							this.ai[2] = 1f;
							int num518 = NPC.NewNPC((int)(this.position.X + (float)(this.width / 2)), (int)(this.position.Y + (float)this.height), 139, 0);
							if (Main.netMode == 2 && num518 < 200)
							{
								NetMessage.SendData(23, -1, -1, "", num518, 0f, 0f, 0f, 0);
							}
							this.netUpdate = true;
						}
						if (this.life <= 0)
						{
							Gore.NewGore(this.position, this.velocity, 156, 1f);
							if (Main.rand.Next(2) == 0)
							{
								for (int num519 = 0; num519 < 10; num519++)
								{
									Vector2 vector101 = new Vector2(this.position.X, this.position.Y);
									int num520 = this.width;
									int num521 = this.height;
									int num522 = 31;
									float speedX91 = 0f;
									float speedY91 = 0f;
									int num523 = 100;
									Color newColor = default(Color);
									int num524 = Dust.NewDust(vector101, num520, num521, num522, speedX91, speedY91, num523, newColor, 1.5f);
									Dust dust26 = Main.dust[num524];
									dust26.velocity *= 1.4f;
								}
								for (int num525 = 0; num525 < 5; num525++)
								{
									Vector2 vector102 = new Vector2(this.position.X, this.position.Y);
									int num526 = this.width;
									int num527 = this.height;
									int num528 = 6;
									float speedX92 = 0f;
									float speedY92 = 0f;
									int num529 = 100;
									Color newColor = default(Color);
									int num530 = Dust.NewDust(vector102, num526, num527, num528, speedX92, speedY92, num529, newColor, 2.5f);
									Main.dust[num530].noGravity = true;
									Dust dust27 = Main.dust[num530];
									dust27.velocity *= 5f;
									Vector2 vector103 = new Vector2(this.position.X, this.position.Y);
									int num531 = this.width;
									int num532 = this.height;
									int num533 = 6;
									float speedX93 = 0f;
									float speedY93 = 0f;
									int num534 = 100;
									newColor = default(Color);
									num530 = Dust.NewDust(vector103, num531, num532, num533, speedX93, speedY93, num534, newColor, 1.5f);
									Dust dust28 = Main.dust[num530];
									dust28.velocity *= 3f;
								}
								Vector2 vector104 = new Vector2(this.position.X, this.position.Y);
								Vector2 vector34 = default(Vector2);
								int num535 = Gore.NewGore(vector104, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore41 = Main.gore[num535];
								gore41.velocity *= 0.4f;
								Gore gore42 = Main.gore[num535];
								gore42.velocity.X = gore42.velocity.X + 1f;
								Gore gore43 = Main.gore[num535];
								gore43.velocity.Y = gore43.velocity.Y + 1f;
								Vector2 vector105 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num535 = Gore.NewGore(vector105, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore44 = Main.gore[num535];
								gore44.velocity *= 0.4f;
								Gore gore45 = Main.gore[num535];
								gore45.velocity.X = gore45.velocity.X - 1f;
								Gore gore46 = Main.gore[num535];
								gore46.velocity.Y = gore46.velocity.Y + 1f;
								Vector2 vector106 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num535 = Gore.NewGore(vector106, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore47 = Main.gore[num535];
								gore47.velocity *= 0.4f;
								Gore gore48 = Main.gore[num535];
								gore48.velocity.X = gore48.velocity.X + 1f;
								Gore gore49 = Main.gore[num535];
								gore49.velocity.Y = gore49.velocity.Y - 1f;
								Vector2 vector107 = new Vector2(this.position.X, this.position.Y);
								vector34 = default(Vector2);
								num535 = Gore.NewGore(vector107, vector34, Main.rand.Next(61, 64), 1f);
								Gore gore50 = Main.gore[num535];
								gore50.velocity *= 0.4f;
								Gore gore51 = Main.gore[num535];
								gore51.velocity.X = gore51.velocity.X - 1f;
								Gore gore52 = Main.gore[num535];
								gore52.velocity.Y = gore52.velocity.Y - 1f;
							}
						}
					}
					else if (this.type == 127)
					{
						if (this.life <= 0)
						{
							Gore.NewGore(this.position, this.velocity, 149, 1f);
							Gore.NewGore(this.position, this.velocity, 150, 1f);
							for (int num536 = 0; num536 < 10; num536++)
							{
								Vector2 vector108 = new Vector2(this.position.X, this.position.Y);
								int num537 = this.width;
								int num538 = this.height;
								int num539 = 31;
								float speedX94 = 0f;
								float speedY94 = 0f;
								int num540 = 100;
								Color newColor = default(Color);
								int num541 = Dust.NewDust(vector108, num537, num538, num539, speedX94, speedY94, num540, newColor, 1.5f);
								Dust dust29 = Main.dust[num541];
								dust29.velocity *= 1.4f;
							}
							for (int num542 = 0; num542 < 5; num542++)
							{
								Vector2 vector109 = new Vector2(this.position.X, this.position.Y);
								int num543 = this.width;
								int num544 = this.height;
								int num545 = 6;
								float speedX95 = 0f;
								float speedY95 = 0f;
								int num546 = 100;
								Color newColor = default(Color);
								int num547 = Dust.NewDust(vector109, num543, num544, num545, speedX95, speedY95, num546, newColor, 2.5f);
								Main.dust[num547].noGravity = true;
								Dust dust30 = Main.dust[num547];
								dust30.velocity *= 5f;
								Vector2 vector110 = new Vector2(this.position.X, this.position.Y);
								int num548 = this.width;
								int num549 = this.height;
								int num550 = 6;
								float speedX96 = 0f;
								float speedY96 = 0f;
								int num551 = 100;
								newColor = default(Color);
								num547 = Dust.NewDust(vector110, num548, num549, num550, speedX96, speedY96, num551, newColor, 1.5f);
								Dust dust31 = Main.dust[num547];
								dust31.velocity *= 3f;
							}
							Vector2 vector111 = new Vector2(this.position.X, this.position.Y);
							Vector2 vector34 = default(Vector2);
							int num552 = Gore.NewGore(vector111, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore53 = Main.gore[num552];
							gore53.velocity *= 0.4f;
							Gore gore54 = Main.gore[num552];
							gore54.velocity.X = gore54.velocity.X + 1f;
							Gore gore55 = Main.gore[num552];
							gore55.velocity.Y = gore55.velocity.Y + 1f;
							Vector2 vector112 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num552 = Gore.NewGore(vector112, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore56 = Main.gore[num552];
							gore56.velocity *= 0.4f;
							Gore gore57 = Main.gore[num552];
							gore57.velocity.X = gore57.velocity.X - 1f;
							Gore gore58 = Main.gore[num552];
							gore58.velocity.Y = gore58.velocity.Y + 1f;
							Vector2 vector113 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num552 = Gore.NewGore(vector113, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore59 = Main.gore[num552];
							gore59.velocity *= 0.4f;
							Gore gore60 = Main.gore[num552];
							gore60.velocity.X = gore60.velocity.X + 1f;
							Gore gore61 = Main.gore[num552];
							gore61.velocity.Y = gore61.velocity.Y - 1f;
							Vector2 vector114 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num552 = Gore.NewGore(vector114, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore62 = Main.gore[num552];
							gore62.velocity *= 0.4f;
							Gore gore63 = Main.gore[num552];
							gore63.velocity.X = gore63.velocity.X - 1f;
							Gore gore64 = Main.gore[num552];
							gore64.velocity.Y = gore64.velocity.Y - 1f;
						}
					}
					else if (this.type >= 128 && this.type <= 131)
					{
						if (this.life <= 0)
						{
							Gore.NewGore(this.position, this.velocity, 147, 1f);
							Gore.NewGore(this.position, this.velocity, 148, 1f);
							for (int num553 = 0; num553 < 10; num553++)
							{
								Vector2 vector115 = new Vector2(this.position.X, this.position.Y);
								int num554 = this.width;
								int num555 = this.height;
								int num556 = 31;
								float speedX97 = 0f;
								float speedY97 = 0f;
								int num557 = 100;
								Color newColor = default(Color);
								int num558 = Dust.NewDust(vector115, num554, num555, num556, speedX97, speedY97, num557, newColor, 1.5f);
								Dust dust32 = Main.dust[num558];
								dust32.velocity *= 1.4f;
							}
							for (int num559 = 0; num559 < 5; num559++)
							{
								Vector2 vector116 = new Vector2(this.position.X, this.position.Y);
								int num560 = this.width;
								int num561 = this.height;
								int num562 = 6;
								float speedX98 = 0f;
								float speedY98 = 0f;
								int num563 = 100;
								Color newColor = default(Color);
								int num564 = Dust.NewDust(vector116, num560, num561, num562, speedX98, speedY98, num563, newColor, 2.5f);
								Main.dust[num564].noGravity = true;
								Dust dust33 = Main.dust[num564];
								dust33.velocity *= 5f;
								Vector2 vector117 = new Vector2(this.position.X, this.position.Y);
								int num565 = this.width;
								int num566 = this.height;
								int num567 = 6;
								float speedX99 = 0f;
								float speedY99 = 0f;
								int num568 = 100;
								newColor = default(Color);
								num564 = Dust.NewDust(vector117, num565, num566, num567, speedX99, speedY99, num568, newColor, 1.5f);
								Dust dust34 = Main.dust[num564];
								dust34.velocity *= 3f;
							}
							Vector2 vector118 = new Vector2(this.position.X, this.position.Y);
							Vector2 vector34 = default(Vector2);
							int num569 = Gore.NewGore(vector118, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore65 = Main.gore[num569];
							gore65.velocity *= 0.4f;
							Gore gore66 = Main.gore[num569];
							gore66.velocity.X = gore66.velocity.X + 1f;
							Gore gore67 = Main.gore[num569];
							gore67.velocity.Y = gore67.velocity.Y + 1f;
							Vector2 vector119 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num569 = Gore.NewGore(vector119, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore68 = Main.gore[num569];
							gore68.velocity *= 0.4f;
							Gore gore69 = Main.gore[num569];
							gore69.velocity.X = gore69.velocity.X - 1f;
							Gore gore70 = Main.gore[num569];
							gore70.velocity.Y = gore70.velocity.Y + 1f;
							Vector2 vector120 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num569 = Gore.NewGore(vector120, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore71 = Main.gore[num569];
							gore71.velocity *= 0.4f;
							Gore gore72 = Main.gore[num569];
							gore72.velocity.X = gore72.velocity.X + 1f;
							Gore gore73 = Main.gore[num569];
							gore73.velocity.Y = gore73.velocity.Y - 1f;
							Vector2 vector121 = new Vector2(this.position.X, this.position.Y);
							vector34 = default(Vector2);
							num569 = Gore.NewGore(vector121, vector34, Main.rand.Next(61, 64), 1f);
							Gore gore74 = Main.gore[num569];
							gore74.velocity *= 0.4f;
							Gore gore75 = Main.gore[num569];
							gore75.velocity.X = gore75.velocity.X - 1f;
							Gore gore76 = Main.gore[num569];
							gore76.velocity.Y = gore76.velocity.Y - 1f;
						}
					}
					else if (this.type == 23)
					{
						if (this.life > 0)
						{
							int num570 = 0;
							while ((double)num570 < dmg / (double)this.lifeMax * 100.0)
							{
								int num571 = 25;
								if (Main.rand.Next(2) == 0)
								{
									num571 = 6;
								}
								Vector2 vector122 = this.position;
								int num572 = this.width;
								int num573 = this.height;
								int num574 = num571;
								float speedX100 = (float)hitDirection;
								float speedY100 = -1f;
								int num575 = 0;
								Dust.NewDust(vector122, num572, num573, num574, speedX100, speedY100, num575, default(Color), 1f);
								Vector2 vector123 = new Vector2(this.position.X, this.position.Y);
								int num576 = this.width;
								int num577 = this.height;
								int num578 = 6;
								float speedX101 = this.velocity.X * 0.2f;
								float speedY101 = this.velocity.Y * 0.2f;
								int num579 = 100;
								Color newColor = default(Color);
								int num580 = Dust.NewDust(vector123, num576, num577, num578, speedX101, speedY101, num579, newColor, 2f);
								Main.dust[num580].noGravity = true;
								num570++;
							}
						}
						else
						{
							for (int num581 = 0; num581 < 50; num581++)
							{
								int num582 = 25;
								if (Main.rand.Next(2) == 0)
								{
									num582 = 6;
								}
								Vector2 vector124 = this.position;
								int num583 = this.width;
								int num584 = this.height;
								int num585 = num582;
								float speedX102 = (float)(2 * hitDirection);
								float speedY102 = -2f;
								int num586 = 0;
								Dust.NewDust(vector124, num583, num584, num585, speedX102, speedY102, num586, default(Color), 1f);
							}
							for (int num587 = 0; num587 < 50; num587++)
							{
								Vector2 vector125 = new Vector2(this.position.X, this.position.Y);
								int num588 = this.width;
								int num589 = this.height;
								int num590 = 6;
								float speedX103 = this.velocity.X * 0.2f;
								float speedY103 = this.velocity.Y * 0.2f;
								int num591 = 100;
								Color newColor = default(Color);
								int num592 = Dust.NewDust(vector125, num588, num589, num590, speedX103, speedY103, num591, newColor, 2.5f);
								Dust dust35 = Main.dust[num592];
								dust35.velocity *= 6f;
								Main.dust[num592].noGravity = true;
							}
						}
					}
					else if (this.type == 24)
					{
						if (this.life > 0)
						{
							int num593 = 0;
							while ((double)num593 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector126 = new Vector2(this.position.X, this.position.Y);
								int num594 = this.width;
								int num595 = this.height;
								int num596 = 6;
								float x2 = this.velocity.X;
								float y2 = this.velocity.Y;
								int num597 = 100;
								Color newColor = default(Color);
								int num598 = Dust.NewDust(vector126, num594, num595, num596, x2, y2, num597, newColor, 2.5f);
								Main.dust[num598].noGravity = true;
								num593++;
							}
						}
						else
						{
							for (int num599 = 0; num599 < 50; num599++)
							{
								Vector2 vector127 = new Vector2(this.position.X, this.position.Y);
								int num600 = this.width;
								int num601 = this.height;
								int num602 = 6;
								float x3 = this.velocity.X;
								float y3 = this.velocity.Y;
								int num603 = 100;
								Color newColor = default(Color);
								int num604 = Dust.NewDust(vector127, num600, num601, num602, x3, y3, num603, newColor, 2.5f);
								Main.dust[num604].noGravity = true;
								Dust dust36 = Main.dust[num604];
								dust36.velocity *= 2f;
							}
							Gore.NewGore(this.position, this.velocity, 45, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47, 1f);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47, 1f);
						}
					}
					else if (this.type == 25)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
						for (int num605 = 0; num605 < 20; num605++)
						{
							Vector2 vector128 = new Vector2(this.position.X, this.position.Y);
							int num606 = this.width;
							int num607 = this.height;
							int num608 = 6;
							float speedX104 = -this.velocity.X * 0.2f;
							float speedY104 = -this.velocity.Y * 0.2f;
							int num609 = 100;
							Color newColor = default(Color);
							int num610 = Dust.NewDust(vector128, num606, num607, num608, speedX104, speedY104, num609, newColor, 2f);
							Main.dust[num610].noGravity = true;
							Dust dust37 = Main.dust[num610];
							dust37.velocity *= 2f;
							Vector2 vector129 = new Vector2(this.position.X, this.position.Y);
							int num611 = this.width;
							int num612 = this.height;
							int num613 = 6;
							float speedX105 = -this.velocity.X * 0.2f;
							float speedY105 = -this.velocity.Y * 0.2f;
							int num614 = 100;
							newColor = default(Color);
							num610 = Dust.NewDust(vector129, num611, num612, num613, speedX105, speedY105, num614, newColor, 1f);
							Dust dust38 = Main.dust[num610];
							dust38.velocity *= 2f;
						}
					}
					else if (this.type == 33)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
						for (int num615 = 0; num615 < 20; num615++)
						{
							Vector2 vector130 = new Vector2(this.position.X, this.position.Y);
							int num616 = this.width;
							int num617 = this.height;
							int num618 = 29;
							float speedX106 = -this.velocity.X * 0.2f;
							float speedY106 = -this.velocity.Y * 0.2f;
							int num619 = 100;
							Color newColor = default(Color);
							int num620 = Dust.NewDust(vector130, num616, num617, num618, speedX106, speedY106, num619, newColor, 2f);
							Main.dust[num620].noGravity = true;
							Dust dust39 = Main.dust[num620];
							dust39.velocity *= 2f;
							Vector2 vector131 = new Vector2(this.position.X, this.position.Y);
							int num621 = this.width;
							int num622 = this.height;
							int num623 = 29;
							float speedX107 = -this.velocity.X * 0.2f;
							float speedY107 = -this.velocity.Y * 0.2f;
							int num624 = 100;
							newColor = default(Color);
							num620 = Dust.NewDust(vector131, num621, num622, num623, speedX107, speedY107, num624, newColor, 1f);
							Dust dust40 = Main.dust[num620];
							dust40.velocity *= 2f;
						}
					}
					else if (this.type == 26 || this.type == 27 || this.type == 28 || this.type == 29 || this.type == 73 || this.type == 111)
					{
						if (this.life > 0)
						{
							int num625 = 0;
							while ((double)num625 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector132 = this.position;
								int num626 = this.width;
								int num627 = this.height;
								int num628 = 5;
								float speedX108 = (float)hitDirection;
								float speedY108 = -1f;
								int num629 = 0;
								Dust.NewDust(vector132, num626, num627, num628, speedX108, speedY108, num629, default(Color), 1f);
								num625++;
							}
						}
						else
						{
							for (int num630 = 0; num630 < 50; num630++)
							{
								Vector2 vector133 = this.position;
								int num631 = this.width;
								int num632 = this.height;
								int num633 = 5;
								float speedX109 = 2.5f * (float)hitDirection;
								float speedY109 = -2.5f;
								int num634 = 0;
								Dust.NewDust(vector133, num631, num632, num633, speedX109, speedY109, num634, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 48, this.scale);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, this.scale);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, this.scale);
							if (this.type == 111)
							{
								Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, this.scale);
							}
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, this.scale);
							Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, this.scale);
						}
					}
					else if (this.type == 30)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
						for (int num635 = 0; num635 < 20; num635++)
						{
							Vector2 vector134 = new Vector2(this.position.X, this.position.Y);
							int num636 = this.width;
							int num637 = this.height;
							int num638 = 27;
							float speedX110 = -this.velocity.X * 0.2f;
							float speedY110 = -this.velocity.Y * 0.2f;
							int num639 = 100;
							Color newColor = default(Color);
							int num640 = Dust.NewDust(vector134, num636, num637, num638, speedX110, speedY110, num639, newColor, 2f);
							Main.dust[num640].noGravity = true;
							Dust dust41 = Main.dust[num640];
							dust41.velocity *= 2f;
							Vector2 vector135 = new Vector2(this.position.X, this.position.Y);
							int num641 = this.width;
							int num642 = this.height;
							int num643 = 27;
							float speedX111 = -this.velocity.X * 0.2f;
							float speedY111 = -this.velocity.Y * 0.2f;
							int num644 = 100;
							newColor = default(Color);
							num640 = Dust.NewDust(vector135, num641, num642, num643, speedX111, speedY111, num644, newColor, 1f);
							Dust dust42 = Main.dust[num640];
							dust42.velocity *= 2f;
						}
					}
					else if (this.type == 42)
					{
						if (this.life > 0)
						{
							int num645 = 0;
							while ((double)num645 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -1f, this.alpha, this.color, this.scale);
								num645++;
							}
						}
						else
						{
							for (int num646 = 0; num646 < 50; num646++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, (float)hitDirection, -2f, this.alpha, this.color, this.scale);
							}
							Gore.NewGore(this.position, this.velocity, 70, this.scale);
							Gore.NewGore(this.position, this.velocity, 71, this.scale);
						}
					}
					else if (this.type == 43 || this.type == 56)
					{
						if (this.life > 0)
						{
							int num647 = 0;
							while ((double)num647 < dmg / (double)this.lifeMax * 100.0)
							{
								Dust.NewDust(this.position, this.width, this.height, 40, (float)hitDirection, -1f, this.alpha, this.color, 1.2f);
								num647++;
							}
						}
						else
						{
							for (int num648 = 0; num648 < 50; num648++)
							{
								Dust.NewDust(this.position, this.width, this.height, 40, (float)hitDirection, -2f, this.alpha, this.color, 1.2f);
							}
							Gore.NewGore(this.position, this.velocity, 72, 1f);
							Gore.NewGore(this.position, this.velocity, 72, 1f);
						}
					}
					else if (this.type == 48)
					{
						if (this.life > 0)
						{
							int num649 = 0;
							while ((double)num649 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector136 = this.position;
								int num650 = this.width;
								int num651 = this.height;
								int num652 = 5;
								float speedX112 = (float)hitDirection;
								float speedY112 = -1f;
								int num653 = 0;
								Dust.NewDust(vector136, num650, num651, num652, speedX112, speedY112, num653, default(Color), 1f);
								num649++;
							}
						}
						else
						{
							for (int num654 = 0; num654 < 50; num654++)
							{
								Vector2 vector137 = this.position;
								int num655 = this.width;
								int num656 = this.height;
								int num657 = 5;
								float speedX113 = (float)(2 * hitDirection);
								float speedY113 = -2f;
								int num658 = 0;
								Dust.NewDust(vector137, num655, num656, num657, speedX113, speedY113, num658, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 80, 1f);
							Gore.NewGore(this.position, this.velocity, 81, 1f);
						}
					}
					else if (this.type == 62 || this.type == 66)
					{
						if (this.life > 0)
						{
							int num659 = 0;
							while ((double)num659 < dmg / (double)this.lifeMax * 100.0)
							{
								Vector2 vector138 = this.position;
								int num660 = this.width;
								int num661 = this.height;
								int num662 = 5;
								float speedX114 = (float)hitDirection;
								float speedY114 = -1f;
								int num663 = 0;
								Dust.NewDust(vector138, num660, num661, num662, speedX114, speedY114, num663, default(Color), 1f);
								num659++;
							}
						}
						else
						{
							for (int num664 = 0; num664 < 50; num664++)
							{
								Vector2 vector139 = this.position;
								int num665 = this.width;
								int num666 = this.height;
								int num667 = 5;
								float speedX115 = (float)(2 * hitDirection);
								float speedY115 = -2f;
								int num668 = 0;
								Dust.NewDust(vector139, num665, num666, num667, speedX115, speedY115, num668, default(Color), 1f);
							}
							Gore.NewGore(this.position, this.velocity, 93, 1f);
							Gore.NewGore(this.position, this.velocity, 94, 1f);
							Gore.NewGore(this.position, this.velocity, 94, 1f);
						}
					}
				}
				else if (this.life > 0)
				{
					int num669 = 0;
					while ((double)num669 < dmg / (double)this.lifeMax * 80.0)
					{
						Vector2 vector140 = this.position;
						int num670 = this.width;
						int num671 = this.height;
						int num672 = 6;
						float speedX116 = (float)(hitDirection * 2);
						float speedY116 = -1f;
						int num673 = this.alpha;
						Dust.NewDust(vector140, num670, num671, num672, speedX116, speedY116, num673, default(Color), 1.5f);
						num669++;
					}
				}
				else
				{
					for (int num674 = 0; num674 < 40; num674++)
					{
						Vector2 vector141 = this.position;
						int num675 = this.width;
						int num676 = this.height;
						int num677 = 6;
						float speedX117 = (float)(hitDirection * 2);
						float speedY117 = -1f;
						int num678 = this.alpha;
						Dust.NewDust(vector141, num675, num676, num677, speedX117, speedY117, num678, default(Color), 1.5f);
					}
				}
			}
		}

		public static bool AnyNPCs(int Type)
		{
			bool result;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == Type)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public static void SpawnSkeletron()
		{
			bool flag = true;
			bool flag2 = false;
			Vector2 vector = default(Vector2);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 35)
				{
					flag = false;
					break;
				}
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active && Main.npc[j].type == 37)
				{
					flag2 = true;
					Main.npc[j].ai[3] = 1f;
					vector = Main.npc[j].position;
					num = Main.npc[j].width;
					num2 = Main.npc[j].height;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(23, -1, -1, "", j, 0f, 0f, 0f, 0);
					}
				}
			}
			if (flag && flag2)
			{
				int num3 = NPC.NewNPC((int)vector.X + num / 2, (int)vector.Y + num2 / 2, 35, 0);
				Main.npc[num3].netUpdate = true;
				string str = "骷髅君王";
				if (Main.netMode == 0)
				{
					Main.NewText(str + " 苏醒了!", 175, 75, 255);
				}
				else if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, str + " 苏醒了!", 255, 175f, 75f, 255f, 0);
				}
			}
		}

		public static bool NearSpikeBall(int x, int y)
		{
			Rectangle rectangle = new Rectangle(x * 16 - 300, y * 16 - 300, 600, 600);
			bool result;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].aiStyle == 20)
				{
					Rectangle rectangle2 = new Rectangle((int)Main.npc[i].ai[1], (int)Main.npc[i].ai[2], 20, 20);
					if (rectangle.Intersects(rectangle2))
					{
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}

		public void AddBuff(int type, int time, bool quiet = false)
		{
			if (!this.buffImmune[type])
			{
				if (!quiet)
				{
					if (Main.netMode == 1)
					{
						NetMessage.SendData(53, -1, -1, "", this.whoAmI, (float)type, (float)time, 0f, 0);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(54, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
					}
				}
				int num = -1;
				for (int i = 0; i < 5; i++)
				{
					if (this.buffType[i] == type)
					{
						if (this.buffTime[i] < time)
						{
							this.buffTime[i] = time;
						}
						return;
					}
				}
				while (num == -1)
				{
					int num2 = -1;
					for (int j = 0; j < 5; j++)
					{
						if (!Main.debuff[this.buffType[j]])
						{
							num2 = j;
							break;
						}
					}
					if (num2 == -1)
					{
						return;
					}
					for (int k = num2; k < 5; k++)
					{
						if (this.buffType[k] == 0)
						{
							num = k;
							break;
						}
					}
					if (num == -1)
					{
						this.DelBuff(num2);
					}
				}
				this.buffType[num] = type;
				this.buffTime[num] = time;
			}
		}

		public void DelBuff(int b)
		{
			this.buffTime[b] = 0;
			this.buffType[b] = 0;
			for (int i = 0; i < 4; i++)
			{
				if (this.buffTime[i] == 0 || this.buffType[i] == 0)
				{
					for (int j = i + 1; j < 5; j++)
					{
						this.buffTime[j - 1] = this.buffTime[j];
						this.buffType[j - 1] = this.buffType[j];
						this.buffTime[j] = 0;
						this.buffType[j] = 0;
					}
				}
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData(54, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
			}
		}

		public void UpdateNPC(int i)
		{
			this.whoAmI = i;
			if (this.active)
			{
				if (this.displayName == "")
				{
					this.displayName = this.name;
					this.displayCName = this.CName;
				}
				if (this.townNPC && Main.chrName[this.type] != "")
				{
					this.displayName = Main.chrName[this.type];
					this.displayCName = NPC.FindCNames(Main.chrName[this.type]);
				}
				this.lifeRegen = 0;
				this.poisoned = false;
				this.onFire = false;
				this.onFire2 = false;
				this.confused = false;
				for (int j = 0; j < 5; j++)
				{
					if (this.buffType[j] > 0 && this.buffTime[j] > 0)
					{
						this.buffTime[j]--;
						if (this.buffType[j] == 20)
						{
							this.poisoned = true;
						}
						else if (this.buffType[j] == 24)
						{
							this.onFire = true;
						}
						else if (this.buffType[j] == 31)
						{
							this.confused = true;
						}
						else if (this.buffType[j] == 39)
						{
							this.onFire2 = true;
						}
					}
				}
				if (Main.netMode != 1)
				{
					for (int k = 0; k < 5; k++)
					{
						if (this.buffType[k] > 0 && this.buffTime[k] <= 0)
						{
							this.DelBuff(k);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(54, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0);
							}
						}
					}
				}
				if (!this.dontTakeDamage)
				{
					if (this.poisoned)
					{
						this.lifeRegen = -4;
					}
					if (this.onFire)
					{
						this.lifeRegen = -8;
					}
					if (this.onFire2)
					{
						this.lifeRegen = -12;
					}
					this.lifeRegenCount += this.lifeRegen;
					while (this.lifeRegenCount >= 120)
					{
						this.lifeRegenCount -= 120;
						if (this.life < this.lifeMax)
						{
							this.life++;
						}
						if (this.life > this.lifeMax)
						{
							this.life = this.lifeMax;
						}
					}
					while (this.lifeRegenCount <= -120)
					{
						this.lifeRegenCount += 120;
						int num = this.whoAmI;
						if (this.realLife >= 0)
						{
							num = this.realLife;
						}
						Main.npc[num].life--;
						if (Main.npc[num].life <= 0)
						{
							Main.npc[num].life = 1;
							if (Main.netMode != 1)
							{
								Main.npc[num].StrikeNPC(9999, 0f, 0, false, false);
								if (Main.netMode == 2)
								{
									NetMessage.SendData(28, -1, -1, "", num, 9999f, 0f, 0f, 0);
								}
							}
						}
					}
				}
				if (Main.netMode != 1 && Main.bloodMoon)
				{
					if (this.type == 46)
					{
						this.Transform(47);
					}
					else if (this.type == 55)
					{
						this.Transform(57);
					}
				}
				float num2 = 10f;
				float num3 = 0.3f;
				float num4 = (float)(Main.maxTilesX / 4200);
				num4 *= num4;
				float num5 = (float)((double)(this.position.Y / 16f - (60f + 10f * num4)) / (Main.worldSurface / 6.0));
				if ((double)num5 < 0.25)
				{
					num5 = 0.25f;
				}
				if (num5 > 1f)
				{
					num5 = 1f;
				}
				num3 *= num5;
				if (this.wet)
				{
					num3 = 0.2f;
					num2 = 7f;
				}
				if (this.soundDelay > 0)
				{
					this.soundDelay--;
				}
				if (this.life <= 0)
				{
					this.active = false;
				}
				this.oldTarget = this.target;
				this.oldDirection = this.direction;
				this.oldDirectionY = this.directionY;
				this.AI();
				if (this.type == 44)
				{
					Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + 4f) / 16, 0.9f, 0.75f, 0.5f);
				}
				for (int l = 0; l < 256; l++)
				{
					if (this.immune[l] > 0)
					{
						this.immune[l]--;
					}
				}
				if (!this.noGravity && !this.noTileCollide)
				{
					int num6 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num7 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (Main.tile[num6, num7] == null)
					{
						num3 = 0f;
						this.velocity.X = 0f;
						this.velocity.Y = 0f;
					}
				}
				if (!this.noGravity)
				{
					this.velocity.Y = this.velocity.Y + num3;
					if (this.velocity.Y > num2)
					{
						this.velocity.Y = num2;
					}
				}
				if ((double)this.velocity.X < 0.005 && (double)this.velocity.X > -0.005)
				{
					this.velocity.X = 0f;
				}
				if (Main.netMode != 1 && this.type != 37 && (this.friendly || this.type == 46 || this.type == 55 || this.type == 74))
				{
					if (this.life < this.lifeMax)
					{
						this.friendlyRegen++;
						if (this.friendlyRegen > 300)
						{
							this.friendlyRegen = 0;
							this.life++;
							this.netUpdate = true;
						}
					}
					if (this.immune[255] == 0)
					{
						Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						for (int m = 0; m < 200; m++)
						{
							if (Main.npc[m].active && !Main.npc[m].friendly && Main.npc[m].damage > 0)
							{
								Rectangle rectangle2 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
								if (rectangle.Intersects(rectangle2))
								{
									int num8 = Main.npc[m].damage;
									int num9 = 6;
									int num10 = 1;
									if (Main.npc[m].position.X + (float)(Main.npc[m].width / 2) > this.position.X + (float)(this.width / 2))
									{
										num10 = -1;
									}
									Main.npc[i].StrikeNPC(num8, (float)num9, num10, false, false);
									if (Main.netMode != 0)
									{
										NetMessage.SendData(28, -1, -1, "", i, (float)num8, (float)num9, (float)num10, 0);
									}
									this.netUpdate = true;
									this.immune[255] = 30;
								}
							}
						}
					}
				}
				if (!this.noTileCollide)
				{
					bool flag = Collision.LavaCollision(this.position, this.width, this.height);
					if (flag)
					{
						this.lavaWet = true;
						if (!this.lavaImmune && !this.dontTakeDamage && Main.netMode != 1 && this.immune[255] == 0)
						{
							this.AddBuff(24, 420, false);
							this.immune[255] = 30;
							this.StrikeNPC(50, 0f, 0, false, false);
							if (Main.netMode == 2 && Main.netMode != 0)
							{
								NetMessage.SendData(28, -1, -1, "", this.whoAmI, 50f, 0f, 0f, 0);
							}
						}
					}
					bool flag2;
					if (this.type == 72)
					{
						flag2 = false;
						this.wetCount = 0;
						flag = false;
					}
					else
					{
						flag2 = Collision.WetCollision(this.position, this.width, this.height);
					}
					if (flag2)
					{
						if (this.onFire && !this.lavaWet && Main.netMode != 1)
						{
							for (int n = 0; n < 5; n++)
							{
								if (this.buffType[n] == 24)
								{
									this.DelBuff(n);
								}
							}
						}
						if (!this.wet && this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!flag)
							{
								for (int num11 = 0; num11 < 30; num11++)
								{
									int num12 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
									Dust dust = Main.dust[num12];
									dust.velocity.Y = dust.velocity.Y - 4f;
									Dust dust2 = Main.dust[num12];
									dust2.velocity.X = dust2.velocity.X * 2.5f;
									Main.dust[num12].scale = 1.3f;
									Main.dust[num12].alpha = 100;
									Main.dust[num12].noGravity = true;
								}
								if (this.type != 1 && this.type != 59 && !this.noGravity)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
							}
							else
							{
								for (int num13 = 0; num13 < 10; num13++)
								{
									int num14 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust dust3 = Main.dust[num14];
									dust3.velocity.Y = dust3.velocity.Y - 1.5f;
									Dust dust4 = Main.dust[num14];
									dust4.velocity.X = dust4.velocity.X * 2.5f;
									Main.dust[num14].scale = 1.3f;
									Main.dust[num14].alpha = 100;
									Main.dust[num14].noGravity = true;
								}
								if (this.type != 1 && this.type != 59 && !this.noGravity)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
						}
						this.wet = true;
					}
					else if (this.wet)
					{
						this.velocity.X = this.velocity.X * 0.5f;
						this.wet = false;
						if (this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!this.lavaWet)
							{
								for (int num15 = 0; num15 < 30; num15++)
								{
									int num16 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
									Dust dust5 = Main.dust[num16];
									dust5.velocity.Y = dust5.velocity.Y - 4f;
									Dust dust6 = Main.dust[num16];
									dust6.velocity.X = dust6.velocity.X * 2.5f;
									Main.dust[num16].scale = 1.3f;
									Main.dust[num16].alpha = 100;
									Main.dust[num16].noGravity = true;
								}
								if (this.type != 1 && this.type != 59 && !this.noGravity)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
							}
							else
							{
								for (int num17 = 0; num17 < 10; num17++)
								{
									int num18 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust dust7 = Main.dust[num18];
									dust7.velocity.Y = dust7.velocity.Y - 1.5f;
									Dust dust8 = Main.dust[num18];
									dust8.velocity.X = dust8.velocity.X * 2.5f;
									Main.dust[num18].scale = 1.3f;
									Main.dust[num18].alpha = 100;
									Main.dust[num18].noGravity = true;
								}
								if (this.type != 1 && this.type != 59 && !this.noGravity)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
						}
					}
					if (!this.wet)
					{
						this.lavaWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
					bool flag3 = false;
					if (this.aiStyle == 10)
					{
						flag3 = true;
					}
					if (this.aiStyle == 14)
					{
						flag3 = true;
					}
					if (this.aiStyle == 3 && this.directionY == 1)
					{
						flag3 = true;
					}
					this.oldVelocity = this.velocity;
					this.collideX = false;
					this.collideY = false;
					if (this.wet)
					{
						Vector2 vector = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
						if (Collision.up)
						{
							this.velocity.Y = 0.01f;
						}
						Vector2 value = this.velocity * 0.5f;
						if (this.velocity.X != vector.X)
						{
							value.X = this.velocity.X;
							this.collideX = true;
						}
						if (this.velocity.Y != vector.Y)
						{
							value.Y = this.velocity.Y;
							this.collideY = true;
						}
						this.oldPosition = this.position;
						this.position += value;
					}
					else
					{
						if (this.type == 72)
						{
							Vector2 vector2 = new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
							int num19 = 12;
							int num20 = 12;
							vector2.X -= (float)(num19 / 2);
							vector2.Y -= (float)(num20 / 2);
							this.velocity = Collision.TileCollision(vector2, this.velocity, num19, num20, true, true);
						}
						else
						{
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
						}
						if (Collision.up)
						{
							this.velocity.Y = 0.01f;
						}
						if (this.oldVelocity.X != this.velocity.X)
						{
							this.collideX = true;
						}
						if (this.oldVelocity.Y != this.velocity.Y)
						{
							this.collideY = true;
						}
						this.oldPosition = this.position;
						this.position += this.velocity;
					}
				}
				else
				{
					this.oldPosition = this.position;
					this.position += this.velocity;
				}
				if (Main.netMode != 1 && !this.noTileCollide && this.lifeMax > 1 && Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition) && this.type == 46)
				{
					this.ai[0] = 1f;
					this.ai[1] = 400f;
					this.ai[2] = 0f;
				}
				if (!this.active)
				{
					this.netUpdate = true;
				}
				if (Main.netMode == 2)
				{
					if (this.townNPC)
					{
						this.netSpam = 0;
					}
					if (this.netUpdate2)
					{
						this.netUpdate = true;
					}
					if (!this.active)
					{
						this.netSpam = 0;
					}
					if (this.netUpdate)
					{
						if (this.netSpam <= 180)
						{
							this.netSpam += 60;
							NetMessage.SendData(23, -1, -1, "", i, 0f, 0f, 0f, 0);
							this.netUpdate2 = false;
						}
						else
						{
							this.netUpdate2 = true;
						}
					}
					if (this.netSpam > 0)
					{
						this.netSpam--;
					}
					if (this.active && this.townNPC && NPC.TypeToNum(this.type) != -1)
					{
						if (this.homeless != this.oldHomeless || this.homeTileX != this.oldHomeTileX || this.homeTileY != this.oldHomeTileY)
						{
							int num21 = 0;
							if (this.homeless)
							{
								num21 = 1;
							}
							NetMessage.SendData(60, -1, -1, "", i, (float)Main.npc[i].homeTileX, (float)Main.npc[i].homeTileY, (float)num21, 0);
						}
						this.oldHomeless = this.homeless;
						this.oldHomeTileX = this.homeTileX;
						this.oldHomeTileY = this.homeTileY;
					}
				}
				this.FindFrame();
				this.CheckActive();
				this.netUpdate = false;
				this.justHit = false;
				if (this.type == 120 || this.type == 137 || this.type == 138)
				{
					for (int num22 = this.oldPos.Length - 1; num22 > 0; num22--)
					{
						this.oldPos[num22] = this.oldPos[num22 - 1];
						Lighting.addLight((int)this.position.X / 16, (int)this.position.Y / 16, 0.3f, 0f, 0.2f);
					}
					this.oldPos[0] = this.position;
				}
				else if (this.type == 94)
				{
					for (int num23 = this.oldPos.Length - 1; num23 > 0; num23--)
					{
						this.oldPos[num23] = this.oldPos[num23 - 1];
					}
					this.oldPos[0] = this.position;
				}
				else if (this.type == 125 || this.type == 126 || this.type == 127 || this.type == 128 || this.type == 129 || this.type == 130 || this.type == 131 || this.type == 139 || this.type == 140)
				{
					for (int num24 = this.oldPos.Length - 1; num24 > 0; num24--)
					{
						this.oldPos[num24] = this.oldPos[num24 - 1];
					}
					this.oldPos[0] = this.position;
				}
			}
		}

		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - this.alpha) / 255f;
			int num2 = (int)((float)newColor.R * num);
			int num3 = (int)((float)newColor.G * num);
			int num4 = (int)((float)newColor.B * num);
			int num5 = (int)newColor.A - this.alpha;
			Color result;
			if (this.type == 25 || this.type == 30 || this.type == 33 || this.type == 59 || this.type == 60)
			{
				result = new Color(200, 200, 200, 0);
			}
			else
			{
				if (this.type == 72)
				{
					num2 = (int)newColor.R;
					num3 = (int)newColor.G;
					num4 = (int)newColor.B;
				}
				else if (this.type == 64 || this.type == 63 || this.type == 75 || this.type == 103)
				{
					num2 = (int)((double)newColor.R * 1.5);
					num3 = (int)((double)newColor.G * 1.5);
					num4 = (int)((double)newColor.B * 1.5);
					if (num2 > 255)
					{
						num2 = 255;
					}
					if (num3 > 255)
					{
						num3 = 255;
					}
					if (num4 > 255)
					{
						num4 = 255;
					}
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num5 > 255)
				{
					num5 = 255;
				}
				result = new Color(num2, num3, num4, num5);
			}
			return result;
		}

		public Color GetColor(Color newColor)
		{
			int num = (int)(this.color.R - (255 - newColor.R));
			int num2 = (int)(this.color.G - (255 - newColor.G));
			int num3 = (int)(this.color.B - (255 - newColor.B));
			int num4 = (int)(this.color.A - (255 - newColor.A));
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}

		public string GetChat()
		{
			string text = NPC.FindCNames(Main.chrName[18]);
			string str = NPC.FindCNames(Main.chrName[17]);
			string text2 = NPC.FindCNames(Main.chrName[19]);
			string text3 = NPC.FindCNames(Main.chrName[20]);
			string str2 = NPC.FindCNames(Main.chrName[38]);
			string text4 = NPC.FindCNames(Main.chrName[54]);
			string str3 = NPC.FindCNames(Main.chrName[22]);
			string text5 = NPC.FindCNames(Main.chrName[108]);
			string text6 = NPC.FindCNames(Main.chrName[107]);
			string text7 = NPC.FindCNames(Main.chrName[124]);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					if (Main.npc[i].type == 17)
					{
						flag = true;
					}
					else if (Main.npc[i].type == 18)
					{
						flag2 = true;
					}
					else if (Main.npc[i].type == 19)
					{
						flag3 = true;
					}
					else if (Main.npc[i].type == 20)
					{
						flag4 = true;
					}
					else if (Main.npc[i].type == 37)
					{
						flag5 = true;
					}
					else if (Main.npc[i].type == 38)
					{
						flag6 = true;
					}
					else if (Main.npc[i].type == 124)
					{
						flag7 = true;
					}
					else if (Main.npc[i].type == 107)
					{
						flag8 = true;
					}
					else if (Main.npc[i].type == 2)
					{
						flag9 = true;
					}
				}
			}
			string result = "";
			if (this.type == 17)
			{
				if (!NPC.downedBoss1 && Main.rand.Next(3) == 0)
				{
					if (Main.player[Main.myPlayer].statLifeMax < 200)
					{
						result = "真希望保护我们对付克苏鲁之眼的不是只有你这个废柴小子。";
					}
					else if (Main.player[Main.myPlayer].statDefense <= 10)
					{
						result = "你那身防具都是山寨货吧，还不多买点我的治疗药水。";
					}
					else
					{
						result = "真可怕，我感到一个邪恶的怪物正注视着我！";
					}
				}
				else if (Main.dayTime)
				{
					if (Main.time < 16200.0)
					{
						int num = Main.rand.Next(3);
						if (num == 0)
						{
							result = "我这里的刀剑削铁如泥。";
						}
						else if (num == 1)
						{
							result = "我们今天终于有100个小馒头了！…………什么？你只要2个？";
						}
						else
						{
							result = "真是个美妙的清晨啊不是么，看看有什么想要的吧。";
						}
					}
					else if (Main.time > 37800.0)
					{
						int num2 = Main.rand.Next(3);
						if (num2 == 0)
						{
							result = "黑夜马上就要来临，尽快挑些东西吧，我的朋友。";
						}
						else if (num2 == 1)
						{
							result = "我们每年都会向海外出口大量的泥巴块，有些国家要用它们做豆腐渣工程。";
						}
						else
						{
							result = "啊，他们总有一天会传颂" + Main.player[Main.myPlayer].name + "的英雄事迹，那一定会是个很精彩的故事。";
						}
					}
					else
					{
						int num3 = Main.rand.Next(3);
						if (num3 == 0)
						{
							result = "看看我这卖的泥巴块，不脏不要钱！";
						}
						else if (num3 == 1)
						{
							result = "这鬼天气真热，要不要看看这一套凉爽透气的盔甲？";
						}
						else
						{
							result = "太阳升的老高了，但我这的价格可一点都不高。";
						}
					}
				}
				else if (Main.bloodMoon)
				{
					if (flag2 && flag7 && Main.rand.Next(3) == 0)
					{
						result = string.Concat(new string[]
						{
							"天啊，我离这么老远都能听到 ",
							text7,
							" 和 ",
							text,
							" 吵架的声音。"
						});
					}
					else
					{
						int num4 = Main.rand.Next(4);
						if (num4 == 0)
						{
							result = "你看看看看见那个……大大大大眼珠子了么？";
						}
						else if (num4 == 1)
						{
							result = "我说……你盖的这间屋子很安全吧？很安全吧？很安全吧？？" + Main.player[Main.myPlayer].name + "?";
						}
						else if (num4 == 2)
						{
							result = "血月之夜也阻止不了资本的运转，坐下吧，咱俩还有生意要谈。";
						}
						else
						{
							result = "你如果不先在我店里买一副眼镜的话，又怎么看清其他货物的标价呢？";
						}
					}
				}
				else if (Main.time < 9720.0)
				{
					if (Main.rand.Next(2) == 0)
					{
						result = "Kosh, kapleck Mog.我会告诉你这句话是克林贡语‘不买就去死’么？";
					}
					else
					{
						result = Main.player[Main.myPlayer].name + " 对吧？关于你的事情总是传的特别快。";
					}
				}
				else if (Main.time > 22680.0)
				{
					if (Main.rand.Next(2) == 0)
					{
						result = "我听说，在一个不为人知的地下洞穴里埋藏着无数的宝物…………我刚才说到哪了？";
					}
					else
					{
						result = "天使雕像？不好意思，本店不收购垃圾。";
					}
				}
				else
				{
					int num5 = Main.rand.Next(3);
					if (num5 == 0)
					{
						result = "好眼光！你手里那坨垃圾就是上一个冒险者留下的……我是说你手里那件宝贝！宝贝！";
					}
					else if (num5 == 1)
					{
						result = "今晚的月亮看上去真像一大块奶酪！你需要来点么？";
					}
					else
					{
						result = "你说什么？金币？咳咳……我来帮你免费鉴定一下真伪吧！";
					}
				}
			}
			else if (this.type == 18)
			{
				if (Main.bloodMoon)
				{
					if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.66)
					{
						int num6 = Main.rand.Next(3);
						if (num6 == 0)
						{
							result = "喂喂！别把血流到我那块地毯上！";
						}
						else if (num6 == 1)
						{
							result = "我这不卖创可贴！";
						}
						else
						{
							result = "如果你要死，就死到外面好吗？";
						}
					}
					else
					{
						int num7 = Main.rand.Next(4);
						if (num7 == 0)
						{
							result = "你那无辜的眼神是什么意思？";
						}
						else if (num7 == 1)
						{
							result = "注意你和我说话的口气！";
						}
						else if (num7 == 2)
						{
							result = "不缺胳膊少腿的就别进来烦我！";
						}
						else
						{
							result = "你刚才嘴里嘟囔什么来着？";
						}
					}
				}
				else if (Main.rand.Next(3) == 0 && !NPC.downedBoss3)
				{
					result = "看到在地牢门口踱步的那个老头子了么？他看上去有大麻烦了。";
				}
				else if (flag6 && Main.rand.Next(4) == 0)
				{
					result = "真希望 " + str2 + "能不要再那么乱来了，每天都要把他的断肢缝回去真是烦死了！";
				}
				else if (flag3 && Main.rand.Next(4) == 0)
				{
					result = "喂， " + text2 + "告诉过你什么时候需要去看医生吗？我很好奇。";
				}
				else if (flag9 && Main.rand.Next(4) == 0)
				{
					result = "我真该和 " + str3 + "好好谈谈！你每周到底要带着岩浆的烧伤来烦我多少次？";
				}
				else if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.33)
				{
					int num8 = Main.rand.Next(5);
					if (num8 == 0)
					{
						result = "伤口这样子缝会让你看起来更有品位一些。";
					}
					else if (num8 == 1)
					{
						result = "你的脸怎么肿成这样？比以前耐看多了。";
					}
					else if (num8 == 2)
					{
						result = "我的诊断结果显示：你还是直接去外面那个棺材里躺着吧。";
					}
					else if (num8 == 3)
					{
						result = "各位来宾，各位亲友，我们今天怀着沉痛的心情深切悼念…………嘘~~~~我不是告诉过你，身上要像着火一样才能睁开眼睛吗？";
					}
					else
					{
						result = "就算你实在找不到，也不用拿着僵尸的胳膊来让我帮你缝回去吧？";
					}
				}
				else if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.66)
				{
					int num9 = Main.rand.Next(7);
					if (num9 == 0)
					{
						result = "别像杀猪似的叫唤！我早就不干兽医那一行了！";
					}
					else if (num9 == 1)
					{
						result = "你这是病！得治！";
					}
					else if (num9 == 2)
					{
						result = "又去打小怪兽了？";
					}
					else if (num9 == 3)
					{
						result = "再坚持一会！我去找些卡通点的绷带，这样才能配得上你那可爱的伤口。";
					}
					else if (num9 == 4)
					{
						result = "别哭丧着脸啦，" + Main.player[Main.myPlayer].name + "，我会对你负责的。";
					}
					else if (num9 == 5)
					{
						result = "你呲牙咧嘴的时候真可爱。";
					}
					else
					{
						result = "你说有人把你的布丁换成了史莱姆？好吃吗？";
					}
				}
				else
				{
					int num10 = Main.rand.Next(4);
					if (num10 == 0)
					{
						result = "咳嗽一下……不是要你对着我的脸啦白痴！";
					}
					else if (num10 == 1)
					{
						result = "你这算什么，我见过更大的呢……我是说更大的伤口！伤口！";
					}
					else if (num10 == 2)
					{
						result = "来一根棒棒糖？";
					}
					else
					{
						result = "哪里疼？让我看看。";
					}
				}
			}
			else if (this.type == 19)
			{
				if (NPC.downedBoss3 && !Main.hardMode)
				{
					result = "我在地下深处见过一个人偶，那欠揍的脸和" + str3 + "一模一样，当时真想把它丢到岩浆里去，不过我只往它的脸上开了几枪。";
				}
				else if (flag2 && Main.rand.Next(5) == 0)
				{
					result = "快一点，我还要去和" + text + "约会呢！";
				}
				else if (flag2 && Main.rand.Next(5) == 0)
				{
					result = "真想去" + text + "那里消费消费……什么？你说她什么都不卖？";
				}
				else if (flag4 && Main.rand.Next(5) == 0)
				{
					result = text3 + "其实身材不错，就是太假正经了点。";
				}
				else if (flag6 && Main.rand.Next(5) == 0)
				{
					result = "别去理" + str2 + "那个卖烟花的了，我这里就有你要的东西。";
				}
				else if (flag6 && Main.rand.Next(5) == 0)
				{
					result = "真不知道" + str2 + "是怎么想的，难道他还没意识到我的货物比他的更与众不同么？";
				}
				else if (Main.bloodMoon)
				{
					if (Main.rand.Next(2) == 0)
					{
						result = "今天是个独处的好日子啊" + Main.player[Main.myPlayer].name + "，不是吗？";
					}
					else
					{
						result = "我就喜欢这样的夜晚，想杀的东西永远也杀不完。";
					}
				}
				else
				{
					int num11 = Main.rand.Next(3);
					if (num11 == 0)
					{
						result = "别盯着那把迷你鲨看了，如果你知道它是用什么做的，估计会吓一跳！";
					}
					else if (num11 == 1)
					{
						result = "我最讨厌那些枪战片，好像每个人枪里的子弹都打不完似的！";
					}
					else
					{
						result = "别碰我这杆老枪，哥们。";
					}
				}
			}
			else if (this.type == 20)
			{
				if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
				{
					result = "试过把净化粉末洒到腐化之地里的黑檀石上么？";
				}
				else if (flag3 && Main.rand.Next(4) == 0)
				{
					result = "但愿" + text2 + "这个白痴永远别再来烦我，难道他还没意识到我已经500岁了么。";
				}
				else if (flag && Main.rand.Next(4) == 0)
				{
					result = "为什么" + str + "不停的和我推销天使雕像？地球人都知道那东西就是一摆设。";
				}
				else if (flag5 && Main.rand.Next(4) == 0)
				{
					result = "你看见地牢门口那个老头了么？他看上去气色不是很好。";
				}
				else if (Main.bloodMoon)
				{
					int num12 = Main.rand.Next(4);
					if (num12 == 0)
					{
						result = "我想卖什么就卖什么，不喜欢就走开啊～";
					}
					else if (num12 == 1)
					{
						result = "为什么每次一到这个时候你就要跑来和我较劲？";
					}
					else if (num12 == 2)
					{
						result = "我不会逼着你买我的东西，因为我会让你自愿来买的。";
					}
					else
					{
						result = "呃……难道只有我看见你背后有个鬼魂么？";
					}
				}
				else
				{
					int num13 = Main.rand.Next(5);
					if (num13 == 0)
					{
						result = "你必须尽快去净化这个世界的腐化之处。";
					}
					else if (num13 == 1)
					{
						result = "祝你平安。泰拉瑞亚需要你！";
					}
					else if (num13 == 2)
					{
						result = "为什么我这么老，皮肤还这么好？你的问题真奇怪。";
					}
					else if (num13 == 3)
					{
						result = "你刚才说树妖的皮肤就和树皮一样粗糙？如果你觉得我会因为这句话就让你随便摸我的话……";
					}
					else
					{
						result = "一个瞎子走进一家酒馆，酒保惊讶地说‘你从哪弄来的眼球给自己安上的？’‘泰拉瑞亚。’瞎子说‘那里天上飞的都是这玩意。’";
					}
				}
			}
			else if (this.type == 22)
			{
				if (Main.bloodMoon)
				{
					int num14 = Main.rand.Next(3);
					if (num14 == 0)
					{
						result = "当月亮变成血红色的时候，不知道为什么，怪物会像潮水般涌来。";
					}
					else if (num14 == 1)
					{
						result = "我说……这种死亡草你在哪里找到的？呃，没什么，只是好奇罢了。";
					}
					else
					{
						result = "看天上，月亮真的变成红色了！";
					}
				}
				else if (!Main.dayTime)
				{
					result = "外面黑漆漆的时候，你就给我呆在家里，这样会很安全…………笑什么？我一个人才不会害害害害怕呢！";
				}
				else
				{
					int num15 = Main.rand.Next(3);
					if (num15 == 0)
					{
						result = "你好啊" + Main.player[Main.myPlayer].name + "，有什么能效劳的么？如果没有的话，就去帮我倒杯水，我最近突然觉得脸很疼。";
					}
					else if (num15 == 1)
					{
						result = "如果有什么不懂的，只管来问我就对了…………基友？兄贵？那是什么？";
					}
					else
					{
						result = "我可以教你怎么在这个恶劣的环境中生存。只要你别再用岩浆烫我！";
					}
				}
			}
			else if (this.type == 37)
			{
				if (Main.dayTime)
				{
					int num16 = Main.rand.Next(3);
					if (num16 == 0)
					{
						result = "我不能让你进入，除非解除我的诅咒，让我获得自由。";
					}
					else if (num16 == 1)
					{
						result = "想进去的话，就等晚上再来吧。";
					}
					else
					{
						result = "白天是无法召唤我的主人的。";
					}
				}
				else if (Main.player[Main.myPlayer].statLifeMax < 300 || Main.player[Main.myPlayer].statDefense < 10)
				{
					int num17 = Main.rand.Next(4);
					if (num17 == 0)
					{
						result = "我身上的诅咒比你想象的更加强大，什么时候你变得更强一些再来吧！";
					}
					else if (num17 == 1)
					{
						result = "你这个可怜的蠢蛋，以你现在的程度还差得远呢！";
					}
					else if (num17 == 2)
					{
						result = "下次不要再把和你一样菜的家伙叫来送死了。";
					}
					else
					{
						result = "如果你想死的话，有更方便的方法，为什么非要来烦我？";
					}
				}
				else
				{
					int num18 = Main.rand.Next(4);
					if (num18 == 0)
					{
						result = "嗯，看起来你应该能抗的住主人的两下子……";
					}
					else if (num18 == 1)
					{
						result = "陌生人啊，你愿意用你拥有的力量击败我的主人吗？";
					}
					else if (num18 == 2)
					{
						result = "求求你！把囚禁我的那个怪物打败！救我出去！";
					}
					else
					{
						result = "只要你能打败我的主人，你就能安全进入他的地下城堡！";
					}
				}
			}
			else if (this.type == 38)
			{
				if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
				{
				}
				if (Main.bloodMoon)
				{
					int num19 = Main.rand.Next(3);
					if (num19 == 0)
					{
						result = "喂，你见到那个小丑了吗？";
					}
					else if (num19 == 1)
					{
						result = "咦？？刚才我放在那的一颗定时炸弹去哪了？？";
					}
					else
					{
						result = "这些炸弹是给那些僵尸们准备的。";
					}
				}
				else if (flag3 && Main.rand.Next(5) == 0)
				{
					result = "就连" + text2 + "那个自大的家伙也想要我这里的东西！";
				}
				else if (flag3 && Main.rand.Next(5) == 0)
				{
					result = "是来我这里，还是去军火商那，这取决于你想在怪物身上开多大的口子。";
				}
				else if (flag2 && Main.rand.Next(4) == 0)
				{
					result = "没问题，" + text + "一定会帮你把胳膊啊腿啊缝的好好的，我经常去！";
				}
				else if (flag4 && Main.rand.Next(4) == 0)
				{
					result = "当你拥有能将整个世界炸个稀巴烂的炸药时，还用得着费劲去净化它吗？";
				}
				else if (!Main.dayTime)
				{
					int num20 = Main.rand.Next(4);
					if (num20 == 0)
					{
						result = "相信我，洗澡的时候把这个丢到浴缸里然后关上窗户，就能治好你的便秘。我经常这么干！";
					}
					else if (num20 == 1)
					{
						result = "来玩一局雷管炸小鸡？";
					}
					else if (num20 == 2)
					{
						result = "我这除了卖爆炸品，其实还代理人身保险业务，来签一份么？";
					}
					else
					{
						result = "数数我的手指头，你就知道你不该在我这里吸烟。";
					}
				}
				else
				{
					int num21 = Main.rand.Next(5);
					if (num21 == 0)
					{
						result = "这年头，要的就是爆炸性的新闻！多买点吧！";
					}
					else if (num21 == 1)
					{
						result = "今天是个去死的好日子。";
					}
					else if (num21 == 2)
					{
						result = "红线还是蓝线？红线还是蓝线？？（轰！！！）";
					}
					else if (num21 == 3)
					{
						result = "只要雷管能解决的问题，就都不是问题。";
					}
					else
					{
						result = "我这里的货物可都是惊爆价！";
					}
				}
			}
			else if (this.type == 54)
			{
				if (!flag7 && Main.rand.Next(2) == 0)
				{
					result = "说起来，我依稀记得那时好像把一个女孩绑了起来关在了地窖里面……又好像是六个？";
				}
				else if (Main.bloodMoon)
				{
					result = Main.player[Main.myPlayer].name + "……我们有大麻烦了！血月之夜降临了！";
				}
				else if (flag2 && Main.rand.Next(4) == 0)
				{
					result = "如果我再年轻些，一定会约" + text + "出去，那时的我真是个少女杀手。";
				}
				else if (Main.player[Main.myPlayer].head == 24)
				{
					result = "你头上那顶红帽子……看起来很眼熟啊。";
				}
				else
				{
					int num22 = Main.rand.Next(6);
					if (num22 == 0)
					{
						result = "谢谢你解开了我的诅咒，说起来……我那时好像被什么东西咬了一口。";
					}
					else if (num22 == 1)
					{
						result = "从小我老妈就说我天生是个当裁缝的料。";
					}
					else if (num22 == 2)
					{
						result = "生活就像一柜子的衣服，你永远都不知道该穿哪一件。";
					}
					else if (num22 == 3)
					{
						result = "刺绣当然很难！如果没那么难，我才不会去做！";
					}
					else if (num22 == 4)
					{
						result = "裁缝活我样样精通！";
					}
					else
					{
						result = "被诅咒的日子真是寂寞，于是我用皮子缝了一个皮球，我给它取名威尔逊。";
					}
				}
			}
			else if (this.type == 105)
			{
				result = "啊，謝謝你救了我，人類。我被我的族人綁起萊丟到這裏等死。其實我和他們相處的不是很好。";
			}
			else if (this.type == 106)
			{
				result = "感謝你爲我松綁，這些繩索勒的我好疼。";
			}
			else if (this.type == 107)
			{
				if (this.homeless)
				{
					int num23 = Main.rand.Next(5);
					if (num23 == 0)
					{
						result = "真是離譜！這群怪胎把我丟在這裏，就因爲……就因爲我們入侵這裏的時候我對族長說左邊才是東邊！";
					}
					else if (num23 == 1)
					{
						result = "現在我成了一個流浪的地精，我能丟掉這些尖釘球嗎？一直在我屁股口袋裏放著疼死了……";
					}
					else if (num23 == 2)
					{
						result = "你在找擅長鼓搗小玩意的專家嗎？你算找對地精了！";
					}
					else if (num23 == 3)
					{
						result = "再次感謝你的幫助，我終于可以離開這個陰森的地方了。相信我們還會再見面的！";
					}
					else
					{
						result = "我還以爲救我的人一定會比我高呢……";
					}
				}
				else if (flag7 && Main.rand.Next(4) == 0)
				{
					result = "哟~你知道" + text7 + "最近在忙什麽嗎？難道你沒有……從來沒有去找她談談？";
				}
				else if (!Main.dayTime)
				{
					int num24 = Main.rand.Next(5);
					if (num24 == 0)
					{
						result = "哟~你的帽子上需要加裝一個電動機嗎？我這裏剛好有一個大小合適的。";
					}
					else if (num24 == 1)
					{
						result = "哟~我聽說你喜歡火箭和跑鞋，所以我就把火箭裝到了跑鞋裏面……";
					}
					else if (num24 == 2)
					{
						result = "沈默是金，是指不需要借助膠帶的沈默。";
					}
					else if (num24 == 3)
					{
						result = "黃金當然比鐵堅硬了！現在人類學校的老師都怎麽教的？";
					}
					else
					{
						result = "不是我想打擊你……不過你提出的這個礦工頭盔+腳蹼的設計也太蠢了吧！";
					}
				}
				else
				{
					int num25 = Main.rand.Next(5);
					if (num25 == 0)
					{
						result = "地精都是非常易怒的生物，他們甚至會爲了搶一塊破布而大打出手。";
					}
					else if (num25 == 1)
					{
						result = "說實在的，大部分地精都不是專業的火箭學家……嗯，不像我這麽專業。";
					}
					else if (num25 == 2)
					{
						result = "你知道爲什麽我們都隨身帶著這些尖釘球嗎？好吧，我也不知道！";
					}
					else if (num25 == 3)
					{
						result = "我剛剛完成了我的最新研究！這個新版的玩意絕對不會因爲你無意間朝它吹了一口氣就把整個山頭都炸掉了！";
					}
					else
					{
						result = "那些地精盜賊真是徒有虛名，這裏這麽多沒上鎖的箱子，可裏面的東西他們一個都偷不走！";
					}
				}
			}
			else if (this.type == 108)
			{
				if (this.homeless)
				{
					int num26 = Main.rand.Next(3);
					if (num26 == 0)
					{
						result = "哦！我的英雄！";
					}
					else if (num26 == 1 && !Main.player[Main.myPlayer].male)
					{
						result = "噢，多么的英勇！多谢你救了我，年轻的女士！";
					}
					else if (num26 == 1)
					{
						result = "噢，多么的英勇！多谢你救了我，年轻人！";
					}
					else if (num26 == 2)
					{
						result = "我们已经互相介绍过了，所以我可以去你那里住了吧！对吧？";
					}
				}
				else if (Main.player[Main.myPlayer].male && flag9 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + str3 + "！今天我能帮上什么忙吗？";
				}
				else if (Main.player[Main.myPlayer].male && flag6 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + str2 + "！今天我能帮上什么忙吗？";
				}
				else if (Main.player[Main.myPlayer].male && flag8 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + text6 + "！今天我能帮上什么忙吗？";
				}
				else if (!Main.player[Main.myPlayer].male && flag2 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + text + "！今天我能帮上什么忙吗？";
				}
				else if (!Main.player[Main.myPlayer].male && flag7 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + text7 + "！今天我能帮上什么忙吗？";
				}
				else if (!Main.player[Main.myPlayer].male && flag4 && Main.rand.Next(6) == 0)
				{
					result = "你好啊！" + text3 + "！今天我能帮上什么忙吗？";
				}
				else if (!Main.dayTime)
				{
					int num27 = Main.rand.Next(3);
					if (num27 == 0)
					{
						result = "想在耳垂上镶一个宝石吗？不要？好吧……";
					}
					else if (num27 == 1)
					{
						result = "想来一点魔法糖果吗？不要？好吧……";
					}
					else if (num27 == 2)
					{
						result = "我用禁忌的法术加持了一杯热巧克力如果你感兴……不要？好吧……";
					}
				}
				else
				{
					int num28 = Main.rand.Next(5);
					if (num28 == 0)
					{
						result = "你又偷看我的水晶球了？";
					}
					else if (num28 == 1)
					{
						result = "想要一个能把石头变成史莱姆的魔法戒指吗？好吧，其实我也不想要。";
					}
					else if (num28 == 2)
					{
						result = "曾经有人告诉我，友谊就是一种魔法。真是荒谬，你能用友谊把人变成一只青蛙吗？";
					}
					else if (num28 == 3)
					{
						result = "我透过水晶球看到了你的未来！那就是，你会在我这里买很多很多东西……";
					}
					else
					{
						result = "我曾经想把那个天使雕像变成活的，结果它没反应。";
					}
				}
			}
			else if (this.type == 123)
			{
				result = "多谢！要不是你，我早晚都会落得和这些骷髅一样的下场。";
			}
			else if (this.type == 124)
			{
				if (this.homeless)
				{
					int num29 = Main.rand.Next(4);
					if (num29 == 0)
					{
						result = "喂！越过那条线就会死的哦。因为我之前在那做过手脚……";
					}
					else if (num29 == 1)
					{
						result = "等等！我快能连上无线网络了。";
					}
					else if (num29 == 2)
					{
						result = "我马上就能把闪光信号灯装好了！";
					}
					else
					{
						result = "别动！我把触发器掉到地上了！";
					}
				}
				else if (Main.bloodMoon)
				{
					int num30 = Main.rand.Next(4);
					if (num30 == 0)
					{
						result = "我只是想要一个开关来做…………？";
					}
					else if (num30 == 1)
					{
						result = "哈，让我猜猜，你没买够导线对吧？白痴！";
					}
					else if (num30 == 2)
					{
						result = "那个……你能不能……就是……那个……好吗？你愿意？你真的愿意？呼~";
					}
					else
					{
						result = "你就算用那种眼神望着我我也不会……我正在工作呢！";
					}
				}
				else if (flag8 && Main.rand.Next(6) == 0)
				{
					result = string.Concat(new string[]
					{
						"喂~",
						Main.player[Main.myPlayer].name,
						"，你刚从",
						text6,
						"那里过来吗？他曾有意无意的提到过我吗？"
					});
				}
				else if (flag3 && Main.rand.Next(6) == 0)
				{
					result = text2 + "一直不停的说按那个压力盘按那个压力盘的……我告诉过他那是用来踩，用来踩！";
				}
				else
				{
					int num31 = Main.rand.Next(3);
					if (num31 == 0)
					{
						result = "对于导线来说，买的再多也不够用。";
					}
					else if (num31 == 1)
					{
						result = "你确定你把你的设备接通电源了吗？";
					}
					else
					{
						result = "你知道你的屋子还缺什么吗？更多的闪光信号灯！";
					}
				}
			}
			else if (this.type == 142)
			{
				int num32 = Main.rand.Next(3);
				if (num32 == 0)
				{
					result = "哦吼吼!一瓶...蛋酒！";
				}
				else if (num32 == 1)
				{
					result = "愿意帮我烤些小饼干吗？";
				}
				else if (num32 == 2)
				{
					result = "什么？你以为我不是真的？";
				}
			}
			return result;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}
	}
}
