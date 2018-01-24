using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public class Projectile
	{
		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public int whoAmI;

		public static int maxAI = 2;

		public Vector2 position;

		public Vector2 lastPosition;

		public Vector2 velocity;

		public int width;

		public int height;

		public float scale = 1f;

		public float rotation;

		public int type;

		public int alpha;

		public int owner = 255;

		public bool active;

		public string name = "";

		public string CName = "";

		public float[] ai = new float[Projectile.maxAI];

		public float[] localAI = new float[Projectile.maxAI];

		public int aiStyle;

		public int timeLeft;

		public int soundDelay;

		public int damage;

		public int direction;

		public int spriteDirection = 1;

		public bool hostile;

		public float knockBack;

		public bool friendly;

		public int penetrate = 1;

		public int identity;

		public float light;

		public bool netUpdate;

		public bool netUpdate2;

		public int netSpam;

		public Vector2[] oldPos = new Vector2[10];

		public int restrikeDelay;

		public bool tileCollide;

		public int maxUpdates;

		public int numUpdates;

		public bool ignoreWater;

		public bool hide;

		public bool ownerHitCheck;

		public int[] playerImmune = new int[255];

		public string miscText = "";

		public bool melee;

		public bool ranged;

		public bool magic;

		public int frameCounter;

		public int frame;

		public void SetDefaults(int Type)
		{
			for (int i = 0; i < this.oldPos.Length; i++)
			{
				this.oldPos[i].X = 0f;
				this.oldPos[i].Y = 0f;
			}
			for (int j = 0; j < Projectile.maxAI; j++)
			{
				this.ai[j] = 0f;
				this.localAI[j] = 0f;
			}
			for (int k = 0; k < 255; k++)
			{
				this.playerImmune[k] = 0;
			}
			this.soundDelay = 0;
			this.spriteDirection = 1;
			this.melee = false;
			this.ranged = false;
			this.magic = false;
			this.ownerHitCheck = false;
			this.hide = false;
			this.lavaWet = false;
			this.wetCount = 0;
			this.wet = false;
			this.ignoreWater = false;
			this.hostile = false;
			this.netUpdate = false;
			this.netUpdate2 = false;
			this.netSpam = 0;
			this.numUpdates = 0;
			this.maxUpdates = 0;
			this.identity = 0;
			this.restrikeDelay = 0;
			this.light = 0f;
			this.penetrate = 1;
			this.tileCollide = true;
			this.position = default(Vector2);
			this.velocity = default(Vector2);
			this.aiStyle = 0;
			this.alpha = 0;
			this.type = Type;
			this.active = true;
			this.rotation = 0f;
			this.scale = 1f;
			this.owner = 255;
			this.timeLeft = 3600;
			this.name = "";
			this.CName = "";
			this.friendly = false;
			this.damage = 0;
			this.knockBack = 0f;
			this.miscText = "";
			if (this.type == 1)
			{
				this.name = "Wooden Arrow";
				this.CName = "木箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 2)
			{
				this.name = "Fire Arrow";
				this.CName = "燃烧箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
			}
			else if (this.type == 3)
			{
				this.name = "Shuriken";
				this.CName = "手里剑";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 4;
				this.ranged = true;
			}
			else if (this.type == 4)
			{
				this.name = "Unholy Arrow";
				this.CName = "邪影箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 0.35f;
				this.penetrate = 5;
				this.ranged = true;
			}
			else if (this.type == 5)
			{
				this.name = "Jester's Arrow";
				this.CName = "小丑之箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 0.4f;
				this.penetrate = -1;
				this.timeLeft = 40;
				this.alpha = 100;
				this.ignoreWater = true;
				this.ranged = true;
			}
			else if (this.type == 6)
			{
				this.name = "Enchanted Boomerang";
				this.CName = "魔化回力镖";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.light = 0.4f;
			}
			else if (this.type == 7 || this.type == 8)
			{
				this.name = "Vilethorn";
				this.CName = "邪恶荆刺";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 4;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = 255;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 9)
			{
				this.name = "Starfury";
				this.CName = "群星之怒";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = 2;
				this.alpha = 50;
				this.scale = 0.8f;
				this.tileCollide = false;
				this.magic = true;
			}
			else if (this.type == 10)
			{
				this.name = "Purification Powder";
				this.CName = "净化粉末";
				this.width = 64;
				this.height = 64;
				this.aiStyle = 6;
				this.friendly = true;
				this.tileCollide = false;
				this.penetrate = -1;
				this.alpha = 255;
				this.ignoreWater = true;
			}
			else if (this.type == 11)
			{
				this.name = "Vile Powder";
				this.CName = "邪恶粉末";
				this.width = 48;
				this.height = 48;
				this.aiStyle = 6;
				this.friendly = true;
				this.tileCollide = false;
				this.penetrate = -1;
				this.alpha = 255;
				this.ignoreWater = true;
			}
			else if (this.type == 12)
			{
				this.name = "Falling Star";
				this.CName = "落星";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = 50;
				this.light = 1f;
			}
			else if (this.type == 13)
			{
				this.name = "Hook";
				this.CName = "钩子";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 14)
			{
				this.name = "Bullet";
				this.CName = "枪弹";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = 255;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 15)
			{
				this.name = "Ball of Fire";
				this.CName = "火魔球";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
			}
			else if (this.type == 16)
			{
				this.name = "Magic Missile";
				this.CName = "魔法飞弹";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
			}
			else if (this.type == 17)
			{
				this.name = "Dirt Ball";
				this.CName = "泥土球";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
			}
			else if (this.type == 18)
			{
				this.name = "Orb of Light";
				this.CName = "魔法光球";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.45f;
				this.alpha = 150;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 19)
			{
				this.name = "Flamarang";
				this.CName = "破空之炎";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.light = 1f;
				this.melee = true;
			}
			else if (this.type == 20)
			{
				this.name = "Green Laser";
				this.CName = "β射线";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 21)
			{
				this.name = "Bone";
				this.CName = "骨头";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 2;
				this.scale = 1.2f;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 22)
			{
				this.name = "Water Stream";
				this.CName = "魔法水流";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 12;
				this.friendly = true;
				this.alpha = 255;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 23)
			{
				this.name = "Harpoon";
				this.CName = "鱼叉";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 13;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = 255;
				this.ranged = true;
			}
			else if (this.type == 24)
			{
				this.name = "Spiky Ball";
				this.CName = "尖钉球";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 14;
				this.friendly = true;
				this.penetrate = 6;
				this.ranged = true;
			}
			else if (this.type == 25)
			{
				this.name = "Ball 'O Hurt";
				this.CName = "链球";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 26)
			{
				this.name = "Blue Moon";
				this.CName = "蓝月";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 27)
			{
				this.name = "Water Bolt";
				this.CName = "水魔球";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 200;
				this.timeLeft /= 2;
				this.penetrate = 10;
				this.magic = true;
			}
			else if (this.type == 28)
			{
				this.name = "Bomb";
				this.CName = "MK-2炸弹";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
			}
			else if (this.type == 29)
			{
				this.name = "Dynamite";
				this.CName = "矿用雷管";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
			}
			else if (this.type == 30)
			{
				this.name = "Grenade";
				this.CName = "M-61手雷";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 31)
			{
				this.name = "Sand Ball";
				this.CName = "沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 32)
			{
				this.name = "Ivy Whip";
				this.CName = "常春藤鞭";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 33)
			{
				this.name = "Thorn Chakrum";
				this.CName = "荆棘旋刃";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 3;
				this.friendly = true;
				this.scale = 0.9f;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 34)
			{
				this.name = "Flamelash";
				this.CName = "烈焰火鞭";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.penetrate = 1;
				this.magic = true;
			}
			else if (this.type == 35)
			{
				this.name = "Sunfury";
				this.CName = "阳炎之怒";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 36)
			{
				this.name = "Meteor Shot";
				this.CName = "陨星螺旋弹";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 2;
				this.light = 0.6f;
				this.alpha = 255;
				this.maxUpdates = 1;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 37)
			{
				this.name = "Sticky Bomb";
				this.CName = "黏性炸弹";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
			}
			else if (this.type == 38)
			{
				this.name = "Harpy Feather";
				this.CName = "女妖羽毛";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 0;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 1;
				this.tileCollide = true;
			}
			else if (this.type == 39)
			{
				this.name = "Mud Ball";
				this.CName = "淤泥球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 40)
			{
				this.name = "Ash Ball";
				this.CName = "灰烬球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 41)
			{
				this.name = "Hellfire Arrow";
				this.CName = "狱炎箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
				this.light = 0.3f;
			}
			else if (this.type == 42)
			{
				this.name = "Sand Ball";
				this.CName = "沙球";
				this.knockBack = 8f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 43)
			{
				this.name = "Tombstone";
				this.CName = "墓碑";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 44)
			{
				this.name = "Demon Sickle";
				this.CName = "恶魔镰刀";
				this.width = 48;
				this.height = 48;
				this.alpha = 100;
				this.light = 0.2f;
				this.aiStyle = 18;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = true;
				this.scale = 0.9f;
			}
			else if (this.type == 45)
			{
				this.name = "Demon Scythe";
				this.CName = "恶魔之镰";
				this.width = 48;
				this.height = 48;
				this.alpha = 100;
				this.light = 0.2f;
				this.aiStyle = 18;
				this.friendly = true;
				this.penetrate = 5;
				this.tileCollide = true;
				this.scale = 0.9f;
				this.magic = true;
			}
			else if (this.type == 46)
			{
				this.name = "Dark Lance";
				this.CName = "暗黑长矛";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 47)
			{
				this.name = "Trident";
				this.CName = "三叉戟";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 48)
			{
				this.name = "Throwing Knife";
				this.CName = "飞刀";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.ranged = true;
			}
			else if (this.type == 49)
			{
				this.name = "Spear";
				this.CName = "长矛";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.2f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 50)
			{
				this.name = "Glowstick";
				this.CName = "荧光棒";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 14;
				this.penetrate = -1;
				this.alpha = 75;
				this.light = 1f;
				this.timeLeft *= 5;
			}
			else if (this.type == 51)
			{
				this.name = "Seed";
				this.CName = "种子";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 1;
				this.friendly = true;
			}
			else if (this.type == 52)
			{
				this.name = "Wooden Boomerang";
				this.CName = "木制回力镖";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 53)
			{
				this.name = "Sticky Glowstick";
				this.CName = "黏性荧光棒";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 14;
				this.penetrate = -1;
				this.alpha = 75;
				this.light = 1f;
				this.timeLeft *= 5;
				this.tileCollide = false;
			}
			else if (this.type == 54)
			{
				this.name = "Poisoned Knife";
				this.CName = "剧毒飞刀";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.ranged = true;
			}
			else if (this.type == 55)
			{
				this.name = "Stinger";
				this.CName = "毒刺";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 0;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 1;
				this.tileCollide = true;
			}
			else if (this.type == 56)
			{
				this.name = "Ebonsand Ball";
				this.CName = "黑檀沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 57)
			{
				this.name = "Cobalt Chainsaw";
				this.CName = "钴蓝链锯";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 58)
			{
				this.name = "Mythril Chainsaw";
				this.CName = "秘银链锯";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.08f;
			}
			else if (this.type == 59)
			{
				this.name = "Cobalt Drill";
				this.CName = "钴蓝钻头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 60)
			{
				this.name = "Mythril Drill";
				this.CName = "秘银钻头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 61)
			{
				this.name = "Adamantite Chainsaw";
				this.CName = "精金链锯";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.16f;
			}
			else if (this.type == 62)
			{
				this.name = "Adamantite Drill";
				this.CName = "精金钻头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 63)
			{
				this.name = "The Dao of Pow";
				this.CName = "无极";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 64)
			{
				this.name = "Mythril Halberd";
				this.CName = "秘银长戟";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.25f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 65)
			{
				this.name = "Ebonsand Ball";
				this.CName = "黑檀沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
			}
			else if (this.type == 66)
			{
				this.name = "Adamantite Glaive";
				this.CName = "精金关刀";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.27f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 67)
			{
				this.name = "Pearl Sand Ball";
				this.CName = "珍珠沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 68)
			{
				this.name = "Pearl Sand Ball";
				this.CName = "珍珠沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
			}
			else if (this.type == 69)
			{
				this.name = "Holy Water";
				this.CName = "圣洁水瓶";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 70)
			{
				this.name = "Unholy Water";
				this.CName = "邪恶水瓶";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 71)
			{
				this.name = "Gravel Ball";
				this.CName = "泥沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 72)
			{
				this.name = "Blue Fairy";
				this.CName = "蓝色妖精";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 73 || this.type == 74)
			{
				this.name = "Hook";
				this.CName = "钩子";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
				this.light = 0.4f;
			}
			else if (this.type == 75)
			{
				this.name = "Happy Bomb";
				this.CName = "笑脸炸弹";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 76 || this.type == 77 || this.type == 78)
			{
				if (this.type == 76)
				{
					this.width = 10;
					this.height = 22;
				}
				else if (this.type == 77)
				{
					this.width = 18;
					this.height = 24;
				}
				else
				{
					this.width = 22;
					this.height = 24;
				}
				this.name = "Note";
				this.CName = "魔法音符";
				this.aiStyle = 21;
				this.friendly = true;
				this.ranged = true;
				this.alpha = 100;
				this.light = 0.3f;
				this.penetrate = -1;
				this.timeLeft = 180;
			}
			else if (this.type == 79)
			{
				this.name = "Rainbow";
				this.CName = "魔法虹光";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 255;
				this.magic = true;
			}
			else if (this.type == 80)
			{
				this.name = "Ice Block";
				this.CName = "寒冰块";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 22;
				this.friendly = true;
				this.magic = true;
				this.tileCollide = false;
				this.light = 0.5f;
			}
			else if (this.type == 81)
			{
				this.name = "Wooden Arrow";
				this.CName = "木箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.hostile = true;
				this.ranged = true;
			}
			else if (this.type == 82)
			{
				this.name = "Flaming Arrow";
				this.CName = "燃烧箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.hostile = true;
				this.ranged = true;
			}
			else if (this.type == 83)
			{
				this.name = "Eye Laser";
				this.CName = "魔眼镭射";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.7f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 84)
			{
				this.name = "Pink Laser";
				this.CName = "迟缓镭射";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 85)
			{
				this.name = "Flames";
				this.CName = "火焰";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 23;
				this.friendly = true;
				this.alpha = 255;
				this.penetrate = 3;
				this.maxUpdates = 2;
				this.magic = true;
			}
			else if (this.type == 86)
			{
				this.name = "Pink Fairy";
				this.CName = "粉色妖精";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 87)
			{
				this.name = "Pink Fairy";
				this.CName = "粉色妖精";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 88)
			{
				this.name = "Purple Laser";
				this.CName = "γ射线";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 4;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 89)
			{
				this.name = "Crystal Bullet";
				this.CName = "魔晶爆裂弹";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = 255;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 90)
			{
				this.name = "Crystal Shard";
				this.CName = "魔晶碎片";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 24;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = 50;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
				this.tileCollide = false;
			}
			else if (this.type == 91)
			{
				this.name = "Holy Arrow";
				this.CName = "神怒之箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 92)
			{
				this.name = "Hallow Star";
				this.CName = "神圣星辰";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = 2;
				this.alpha = 50;
				this.scale = 0.8f;
				this.tileCollide = false;
				this.magic = true;
			}
			else if (this.type == 93)
			{
				this.light = 0.15f;
				this.name = "Magic Dagger";
				this.CName = "魔法飞刀";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.magic = true;
			}
			else if (this.type == 94)
			{
				this.ignoreWater = true;
				this.name = "Crystal Storm";
				this.CName = "魔晶风暴";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 24;
				this.friendly = true;
				this.light = 0.5f;
				this.alpha = 50;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.magic = true;
				this.tileCollide = true;
				this.penetrate = 1;
			}
			else if (this.type == 95)
			{
				this.name = "Cursed Flame";
				this.CName = "诅咒魔焰";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
				this.penetrate = 2;
			}
			else if (this.type == 96)
			{
				this.name = "Cursed Flame";
				this.CName = "诅咒魔焰";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.hostile = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
				this.penetrate = -1;
				this.scale = 0.9f;
				this.scale = 1.3f;
			}
			else if (this.type == 97)
			{
				this.name = "Cobalt Naginata";
				this.CName = "钴蓝薙刀";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 98)
			{
				this.name = "Poison Dart";
				this.CName = "毒箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.hostile = true;
				this.ranged = true;
				this.penetrate = -1;
			}
			else if (this.type == 99)
			{
				this.name = "Boulder";
				this.CName = "巨石";
				this.width = 31;
				this.height = 31;
				this.aiStyle = 25;
				this.friendly = true;
				this.hostile = true;
				this.ranged = true;
				this.penetrate = -1;
			}
			else if (this.type == 100)
			{
				this.name = "Death Laser";
				this.CName = "死光";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.8f;
				this.timeLeft = 1200;
				this.magic = true;
			}
			else if (this.type == 101)
			{
				this.name = "Eye Fire";
				this.CName = "魔眼之火";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 23;
				this.hostile = true;
				this.alpha = 255;
				this.penetrate = -1;
				this.maxUpdates = 3;
				this.magic = true;
			}
			else if (this.type == 102)
			{
				this.name = "Bomb";
				this.CName = "炸弹";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.hostile = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 103)
			{
				this.name = "Cursed Arrow";
				this.CName = "咒火箭";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
			}
			else if (this.type == 104)
			{
				this.name = "Cursed Bullet";
				this.CName = "咒火燃烧弹";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = 255;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 105)
			{
				this.name = "Gungnir";
				this.CName = "奥丁神枪";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.3f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 106)
			{
				this.name = "Light Disc";
				this.CName = "光辉飞盘";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.light = 0.4f;
			}
			else if (this.type == 107)
			{
				this.name = "Hamdrax";
				this.CName = "神金钻头";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.1f;
			}
			else if (this.type == 108)
			{
				this.name = "Explosives";
				this.CName = "炸药";
				this.width = 260;
				this.height = 260;
				this.aiStyle = 16;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = 255;
				this.timeLeft = 2;
			}
			else if (this.type == 109)
			{
				this.name = "Sand Ball";
				this.CName = "沙球";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.hostile = true;
				this.scale = 0.9f;
				this.penetrate = -1;
			}
			else if (this.type == 110)
			{
				this.name = "Bullet";
				this.CName = "子弹";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.5f;
				this.alpha = 255;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else
			{
				this.active = false;
			}
			this.width = (int)((float)this.width * this.scale);
			this.height = (int)((float)this.height * this.scale);
		}

		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255)
		{
			int num = 1000;
			for (int i = 0; i < 1000; i++)
			{
				if (!Main.projectile[i].active)
				{
					num = i;
					break;
				}
			}
			int result;
			if (num == 1000)
			{
				result = num;
			}
			else
			{
				Main.projectile[num].SetDefaults(Type);
				Main.projectile[num].position.X = X - (float)Main.projectile[num].width * 0.5f;
				Main.projectile[num].position.Y = Y - (float)Main.projectile[num].height * 0.5f;
				Main.projectile[num].owner = Owner;
				Main.projectile[num].velocity.X = SpeedX;
				Main.projectile[num].velocity.Y = SpeedY;
				Main.projectile[num].damage = Damage;
				Main.projectile[num].knockBack = KnockBack;
				Main.projectile[num].identity = num;
				Main.projectile[num].wet = Collision.WetCollision(Main.projectile[num].position, Main.projectile[num].width, Main.projectile[num].height);
				if (Main.netMode != 0 && Owner == Main.myPlayer)
				{
					NetMessage.SendData(27, -1, -1, "", num, 0f, 0f, 0f, 0);
				}
				if (Owner == Main.myPlayer)
				{
					if (Type == 28)
					{
						Main.projectile[num].timeLeft = 180;
					}
					if (Type == 29)
					{
						Main.projectile[num].timeLeft = 300;
					}
					if (Type == 30)
					{
						Main.projectile[num].timeLeft = 180;
					}
					if (Type == 37)
					{
						Main.projectile[num].timeLeft = 180;
					}
					if (Type == 75)
					{
						Main.projectile[num].timeLeft = 180;
					}
				}
				result = num;
			}
			return result;
		}

		public void StatusNPC(int i)
		{
			if (this.type == 2)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 300, false);
				}
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(20, 420, false);
				}
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 240, false);
				}
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(20, 600, false);
				}
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.npc[i].AddBuff(31, 120, false);
				}
			}
			else if (this.type == 85)
			{
				Main.npc[i].AddBuff(24, 1200, false);
			}
			else if (this.type == 95 || this.type == 103 || this.type == 104)
			{
				Main.npc[i].AddBuff(39, 420, false);
			}
			else if (this.type == 98)
			{
				Main.npc[i].AddBuff(20, 600, false);
			}
		}

		public void StatusPvP(int i)
		{
			if (this.type == 2)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 300, false);
				}
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
				}
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 240, false);
				}
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(20, 600, false);
				}
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.player[i].AddBuff(31, 120, true);
				}
			}
			else if (this.type == 85)
			{
				Main.player[i].AddBuff(24, 1200, false);
			}
			else if (this.type == 95 || this.type == 103 || this.type == 104)
			{
				Main.player[i].AddBuff(39, 420, true);
			}
		}

		public void StatusPlayer(int i)
		{
			if (this.type == 55 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
			if (this.type == 44 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(22, 900, true);
			}
			if (this.type == 82 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 420, true);
			}
			if ((this.type == 96 || this.type == 101) && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(39, 480, true);
			}
			if (this.type == 98)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
		}

		public void Damage()
		{
			if (this.type != 18 && this.type != 72 && this.type != 86 && this.type != 87)
			{
				Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
				if (this.type == 85 || this.type == 101)
				{
					int num = 30;
					rectangle.X -= num;
					rectangle.Y -= num;
					rectangle.Width += num * 2;
					rectangle.Height += num * 2;
				}
				if (this.friendly && this.owner == Main.myPlayer)
				{
					if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108))
					{
						int myPlayer = Main.myPlayer;
						if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
						{
							Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
							if (rectangle.Intersects(value))
							{
								if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < this.position.X + (float)(this.width / 2))
								{
									this.direction = -1;
								}
								else
								{
									this.direction = 1;
								}
								int num2 = Main.DamageVar((float)this.damage);
								this.StatusPlayer(myPlayer);
								Main.player[myPlayer].Hurt(num2, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), false);
								if (Main.netMode != 0)
								{
									NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), myPlayer, (float)this.direction, (float)num2, 1f, 0);
								}
							}
						}
					}
					if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11)
					{
						int num3 = (int)(this.position.X / 16f);
						int num4 = (int)((this.position.X + (float)this.width) / 16f) + 1;
						int num5 = (int)(this.position.Y / 16f);
						int num6 = (int)((this.position.Y + (float)this.height) / 16f) + 1;
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
						for (int i = num3; i < num4; i++)
						{
							for (int j = num5; j < num6; j++)
							{
								if (Main.tile[i, j] != null && Main.tileCut[(int)Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != 78)
								{
									WorldGen.KillTile(i, j, false, false, false);
									if (Main.netMode != 0)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0);
									}
								}
							}
						}
					}
				}
				if (this.owner == Main.myPlayer)
				{
					if (this.damage > 0)
					{
						for (int k = 0; k < 200; k++)
						{
							if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || (Main.npc[k].type == 22 && this.owner < 255 && Main.player[this.owner].killGuide)) && this.friendly) || (Main.npc[k].friendly && this.hostile)) && (this.owner < 0 || Main.npc[k].immune[this.owner] == 0))
							{
								bool flag = false;
								if (this.type == 11 && (Main.npc[k].type == 47 || Main.npc[k].type == 57))
								{
									flag = true;
								}
								else if (this.type == 31 && Main.npc[k].type == 69)
								{
									flag = true;
								}
								if (!flag && (Main.npc[k].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
								{
									Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
									if (rectangle.Intersects(value2))
									{
										if (this.aiStyle == 3)
										{
											if (this.ai[0] == 0f)
											{
												this.velocity.X = -this.velocity.X;
												this.velocity.Y = -this.velocity.Y;
												this.netUpdate = true;
											}
											this.ai[0] = 1f;
										}
										else if (this.aiStyle == 16)
										{
											if (this.timeLeft > 3)
											{
												this.timeLeft = 3;
											}
											if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < this.position.X + (float)(this.width / 2))
											{
												this.direction = -1;
											}
											else
											{
												this.direction = 1;
											}
										}
										if (this.type == 41 && this.timeLeft > 1)
										{
											this.timeLeft = 1;
										}
										bool flag2 = false;
										if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
										{
											flag2 = true;
										}
										if (this.ranged && Main.rand.Next(1, 101) <= Main.player[this.owner].rangedCrit)
										{
											flag2 = true;
										}
										if (this.magic && Main.rand.Next(1, 101) <= Main.player[this.owner].magicCrit)
										{
											flag2 = true;
										}
										int num7 = Main.DamageVar((float)this.damage);
										this.StatusNPC(k);
										Main.npc[k].StrikeNPC(num7, this.knockBack, this.direction, flag2, false);
										if (Main.netMode != 0)
										{
											if (flag2)
											{
												NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 1);
											}
											else
											{
												NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 0);
											}
										}
										if (this.penetrate != 1)
										{
											Main.npc[k].immune[this.owner] = 10;
										}
										if (this.penetrate > 0)
										{
											this.penetrate--;
											if (this.penetrate == 0)
											{
												break;
											}
										}
										if (this.aiStyle == 7)
										{
											this.ai[0] = 1f;
											this.damage = 0;
											this.netUpdate = true;
										}
										else if (this.aiStyle == 13)
										{
											this.ai[0] = 1f;
											this.netUpdate = true;
										}
									}
								}
							}
						}
					}
					if (this.damage > 0 && Main.player[Main.myPlayer].hostile)
					{
						for (int l = 0; l < 255; l++)
						{
							if (l != this.owner && Main.player[l].active && !Main.player[l].dead && !Main.player[l].immune && Main.player[l].hostile && this.playerImmune[l] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[l].team) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[l].position, Main.player[l].width, Main.player[l].height)))
							{
								Rectangle value3 = new Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
								if (rectangle.Intersects(value3))
								{
									if (this.aiStyle == 3)
									{
										if (this.ai[0] == 0f)
										{
											this.velocity.X = -this.velocity.X;
											this.velocity.Y = -this.velocity.Y;
											this.netUpdate = true;
										}
										this.ai[0] = 1f;
									}
									else if (this.aiStyle == 16)
									{
										if (this.timeLeft > 3)
										{
											this.timeLeft = 3;
										}
										if (Main.player[l].position.X + (float)(Main.player[l].width / 2) < this.position.X + (float)(this.width / 2))
										{
											this.direction = -1;
										}
										else
										{
											this.direction = 1;
										}
									}
									if (this.type == 41 && this.timeLeft > 1)
									{
										this.timeLeft = 1;
									}
									bool flag3 = false;
									if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
									{
										flag3 = true;
									}
									int num8 = Main.DamageVar((float)this.damage);
									if (!Main.player[l].immune)
									{
										this.StatusPvP(l);
									}
									Main.player[l].Hurt(num8, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), flag3);
									if (Main.netMode != 0)
									{
										if (flag3)
										{
											NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 1);
										}
										else
										{
											NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 0);
										}
									}
									this.playerImmune[l] = 40;
									if (this.penetrate > 0)
									{
										this.penetrate--;
										if (this.penetrate == 0)
										{
											break;
										}
									}
									if (this.aiStyle == 7)
									{
										this.ai[0] = 1f;
										this.damage = 0;
										this.netUpdate = true;
									}
									else if (this.aiStyle == 13)
									{
										this.ai[0] = 1f;
										this.netUpdate = true;
									}
								}
							}
						}
					}
				}
				if (this.type == 11 && Main.netMode != 1)
				{
					for (int m = 0; m < 200; m++)
					{
						if (Main.npc[m].active)
						{
							if (Main.npc[m].type == 46)
							{
								Rectangle value4 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
								if (rectangle.Intersects(value4))
								{
									Main.npc[m].Transform(47);
								}
							}
							else if (Main.npc[m].type == 55)
							{
								Rectangle value5 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
								if (rectangle.Intersects(value5))
								{
									Main.npc[m].Transform(57);
								}
							}
						}
					}
				}
				if (Main.netMode != 2 && this.hostile && Main.myPlayer < 255 && this.damage > 0)
				{
					int myPlayer2 = Main.myPlayer;
					if (Main.player[myPlayer2].active && !Main.player[myPlayer2].dead && !Main.player[myPlayer2].immune)
					{
						Rectangle value6 = new Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
						if (rectangle.Intersects(value6))
						{
							int hitDirection = this.direction;
							if (Main.player[myPlayer2].position.X + (float)(Main.player[myPlayer2].width / 2) < this.position.X + (float)(this.width / 2))
							{
								hitDirection = -1;
							}
							else
							{
								hitDirection = 1;
							}
							int num9 = Main.DamageVar((float)this.damage);
							if (!Main.player[myPlayer2].immune)
							{
								this.StatusPlayer(myPlayer2);
							}
							Main.player[myPlayer2].Hurt(num9 * 2, hitDirection, false, false, Player.getDeathMessage(-1, -1, this.whoAmI, -1), false);
						}
					}
				}
			}
		}

		public void Update(int i)
		{
			if (this.active)
			{
				Vector2 value = this.velocity;
				if (this.position.X <= Main.leftWorld || this.position.X + (float)this.width >= Main.rightWorld || this.position.Y <= Main.topWorld || this.position.Y + (float)this.height >= Main.bottomWorld)
				{
					this.active = false;
				}
				else
				{
					this.whoAmI = i;
					if (this.soundDelay > 0)
					{
						this.soundDelay--;
					}
					this.netUpdate = false;
					for (int j = 0; j < 255; j++)
					{
						if (this.playerImmune[j] > 0)
						{
							this.playerImmune[j]--;
						}
					}
					this.AI();
					if (this.owner < 255 && !Main.player[this.owner].active)
					{
						this.Kill();
					}
					if (!this.ignoreWater)
					{
						bool flag;
						bool flag2;
						try
						{
							flag = Collision.LavaCollision(this.position, this.width, this.height);
							flag2 = Collision.WetCollision(this.position, this.width, this.height);
							if (flag)
							{
								this.lavaWet = true;
							}
						}
						catch
						{
							this.active = false;
							return;
						}
						if (this.wet && !this.lavaWet)
						{
							if (this.type == 85 || this.type == 15 || this.type == 34)
							{
								this.Kill();
							}
							if (this.type == 2)
							{
								this.type = 1;
								this.light = 0f;
							}
						}
						if (this.type == 80)
						{
							flag2 = false;
							this.wet = false;
							if (flag && this.ai[0] >= 0f)
							{
								this.Kill();
							}
						}
						if (flag2)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!this.wet)
								{
									if (!flag)
									{
										for (int k = 0; k < 10; k++)
										{
											int num = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
											Dust dust = Main.dust[num];
											dust.velocity.Y = dust.velocity.Y - 4f;
											Dust dust2 = Main.dust[num];
											dust2.velocity.X = dust2.velocity.X * 2.5f;
											Main.dust[num].scale = 1.3f;
											Main.dust[num].alpha = 100;
											Main.dust[num].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int l = 0; l < 10; l++)
										{
											int num2 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
											Dust dust3 = Main.dust[num2];
											dust3.velocity.Y = dust3.velocity.Y - 1.5f;
											Dust dust4 = Main.dust[num2];
											dust4.velocity.X = dust4.velocity.X * 2.5f;
											Main.dust[num2].scale = 1.3f;
											Main.dust[num2].alpha = 100;
											Main.dust[num2].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
								}
								this.wet = true;
							}
						}
						else if (this.wet)
						{
							this.wet = false;
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!this.lavaWet)
								{
									for (int m = 0; m < 10; m++)
									{
										int num3 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
										Dust dust5 = Main.dust[num3];
										dust5.velocity.Y = dust5.velocity.Y - 4f;
										Dust dust6 = Main.dust[num3];
										dust6.velocity.X = dust6.velocity.X * 2.5f;
										Main.dust[num3].scale = 1.3f;
										Main.dust[num3].alpha = 100;
										Main.dust[num3].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int n = 0; n < 10; n++)
									{
										int num4 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust dust7 = Main.dust[num4];
										dust7.velocity.Y = dust7.velocity.Y - 1.5f;
										Dust dust8 = Main.dust[num4];
										dust8.velocity.X = dust8.velocity.X * 2.5f;
										Main.dust[num4].scale = 1.3f;
										Main.dust[num4].alpha = 100;
										Main.dust[num4].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
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
					}
					this.lastPosition = this.position;
					if (this.tileCollide)
					{
						Vector2 value2 = this.velocity;
						bool flag3 = true;
						if (this.type == 9 || this.type == 12 || this.type == 15 || this.type == 13 || this.type == 31 || this.type == 39 || this.type == 40)
						{
							flag3 = false;
						}
						if (this.aiStyle == 10)
						{
							if (this.type == 42 || this.type == 65 || this.type == 68 || (this.type == 31 && this.ai[0] == 2f))
							{
								this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
							}
							else
							{
								this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
							}
						}
						else if (this.aiStyle == 18)
						{
							int num5 = this.width - 36;
							int num6 = this.height - 36;
							Vector2 vector = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num5 / 2), this.position.Y + (float)(this.height / 2) - (float)(num6 / 2));
							this.velocity = Collision.TileCollision(vector, this.velocity, num5, num6, flag3, flag3);
						}
						else if (this.wet)
						{
							Vector2 vector2 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
							value = this.velocity * 0.5f;
							if (this.velocity.X != vector2.X)
							{
								value.X = this.velocity.X;
							}
							if (this.velocity.Y != vector2.Y)
							{
								value.Y = this.velocity.Y;
							}
						}
						else
						{
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
						}
						if (value2 != this.velocity)
						{
							if (this.type == 94)
							{
								if (this.velocity.X != value2.X)
								{
									this.velocity.X = -value2.X;
								}
								if (this.velocity.Y != value2.Y)
								{
									this.velocity.Y = -value2.Y;
								}
							}
							else if (this.type == 99)
							{
								if (this.velocity.Y != value2.Y && value2.Y > 5f)
								{
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -value2.Y * 0.2f;
								}
								if (this.velocity.X != value2.X)
								{
									this.Kill();
								}
							}
							else if (this.type == 36)
							{
								if (this.penetrate > 1)
								{
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
									this.penetrate--;
									if (this.velocity.X != value2.X)
									{
										this.velocity.X = -value2.X;
									}
									if (this.velocity.Y != value2.Y)
									{
										this.velocity.Y = -value2.Y;
									}
								}
								else
								{
									this.Kill();
								}
							}
							else if (this.aiStyle == 21)
							{
								if (this.velocity.X != value2.X)
								{
									this.velocity.X = -value2.X;
								}
								if (this.velocity.Y != value2.Y)
								{
									this.velocity.Y = -value2.Y;
								}
							}
							else if (this.aiStyle == 17)
							{
								if (this.velocity.X != value2.X)
								{
									this.velocity.X = value2.X * -0.75f;
								}
								if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
								{
									this.velocity.Y = value2.Y * -0.7f;
								}
							}
							else if (this.aiStyle == 15)
							{
								bool flag4 = false;
								if (value2.X != this.velocity.X)
								{
									if (Math.Abs(value2.X) > 4f)
									{
										flag4 = true;
									}
									this.position.X = this.position.X + this.velocity.X;
									this.velocity.X = -value2.X * 0.2f;
								}
								if (value2.Y != this.velocity.Y)
								{
									if (Math.Abs(value2.Y) > 4f)
									{
										flag4 = true;
									}
									this.position.Y = this.position.Y + this.velocity.Y;
									this.velocity.Y = -value2.Y * 0.2f;
								}
								this.ai[0] = 1f;
								if (flag4)
								{
									this.netUpdate = true;
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							else if (this.aiStyle == 3 || this.aiStyle == 13)
							{
								Collision.HitTiles(this.position, this.velocity, this.width, this.height);
								if (this.type == 33 || this.type == 106)
								{
									if (this.velocity.X != value2.X)
									{
										this.velocity.X = -value2.X;
									}
									if (this.velocity.Y != value2.Y)
									{
										this.velocity.Y = -value2.Y;
									}
								}
								else
								{
									this.ai[0] = 1f;
									if (this.aiStyle == 3)
									{
										this.velocity.X = -value2.X;
										this.velocity.Y = -value2.Y;
									}
								}
								this.netUpdate = true;
								Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
							}
							else if (this.aiStyle == 8 && this.type != 96)
							{
								Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
								this.ai[0] += 1f;
								if (this.ai[0] >= 5f)
								{
									this.position += this.velocity;
									this.Kill();
								}
								else
								{
									if (this.type == 15 && this.velocity.Y > 4f)
									{
										if (this.velocity.Y != value2.Y)
										{
											this.velocity.Y = -value2.Y * 0.8f;
										}
									}
									else if (this.velocity.Y != value2.Y)
									{
										this.velocity.Y = -value2.Y;
									}
									if (this.velocity.X != value2.X)
									{
										this.velocity.X = -value2.X;
									}
								}
							}
							else if (this.aiStyle == 14)
							{
								if (this.type == 50)
								{
									if (this.velocity.X != value2.X)
									{
										this.velocity.X = value2.X * -0.2f;
									}
									if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
									{
										this.velocity.Y = value2.Y * -0.2f;
									}
								}
								else
								{
									if (this.velocity.X != value2.X)
									{
										this.velocity.X = value2.X * -0.5f;
									}
									if (this.velocity.Y != value2.Y && value2.Y > 1f)
									{
										this.velocity.Y = value2.Y * -0.5f;
									}
								}
							}
							else if (this.aiStyle == 16)
							{
								if (this.velocity.X != value2.X)
								{
									this.velocity.X = value2.X * -0.4f;
									if (this.type == 29)
									{
										this.velocity.X = this.velocity.X * 0.8f;
									}
								}
								if (this.velocity.Y != value2.Y && (double)value2.Y > 0.7 && this.type != 102)
								{
									this.velocity.Y = value2.Y * -0.4f;
									if (this.type == 29)
									{
										this.velocity.Y = this.velocity.Y * 0.8f;
									}
								}
							}
							else if (this.aiStyle != 9 || this.owner == Main.myPlayer)
							{
								this.position += this.velocity;
								this.Kill();
							}
						}
					}
					if (this.type != 7 && this.type != 8)
					{
						if (this.wet)
						{
							this.position += value;
						}
						else
						{
							this.position += this.velocity;
						}
					}
					if ((this.aiStyle != 3 || this.ai[0] != 1f) && (this.aiStyle != 7 || this.ai[0] != 1f) && (this.aiStyle != 13 || this.ai[0] != 1f) && (this.aiStyle != 15 || this.ai[0] != 1f) && this.aiStyle != 15)
					{
						if (this.velocity.X < 0f)
						{
							this.direction = -1;
						}
						else
						{
							this.direction = 1;
						}
					}
					if (this.active)
					{
						if (this.light > 0f)
						{
							float num7 = this.light;
							float num8 = this.light;
							float num9 = this.light;
							if (this.type == 2 || this.type == 82)
							{
								num8 *= 0.75f;
								num9 *= 0.55f;
							}
							else if (this.type == 94)
							{
								num7 *= 0.5f;
								num8 *= 0f;
							}
							else if (this.type == 95 || this.type == 96 || this.type == 103 || this.type == 104)
							{
								num7 *= 0.35f;
								num8 *= 1f;
								num9 *= 0f;
							}
							else if (this.type == 4)
							{
								num8 *= 0.1f;
								num7 *= 0.5f;
							}
							else if (this.type == 9)
							{
								num8 *= 0.1f;
								num9 *= 0.6f;
							}
							else if (this.type == 92)
							{
								num8 *= 0.6f;
								num7 *= 0.8f;
							}
							else if (this.type == 93)
							{
								num8 *= 1f;
								num7 *= 1f;
								num9 *= 0.01f;
							}
							else if (this.type == 12)
							{
								num7 *= 0.9f;
								num8 *= 0.8f;
								num9 *= 0.1f;
							}
							else if (this.type == 14 || this.type == 110)
							{
								num8 *= 0.7f;
								num9 *= 0.1f;
							}
							else if (this.type == 15)
							{
								num8 *= 0.4f;
								num9 *= 0.1f;
								num7 = 1f;
							}
							else if (this.type == 16)
							{
								num7 *= 0.1f;
								num8 *= 0.4f;
								num9 = 1f;
							}
							else if (this.type == 18)
							{
								num8 *= 0.7f;
								num9 *= 0.3f;
							}
							else if (this.type == 19)
							{
								num8 *= 0.5f;
								num9 *= 0.1f;
							}
							else if (this.type == 20)
							{
								num7 *= 0.1f;
								num9 *= 0.3f;
							}
							else if (this.type == 22)
							{
								num7 = 0f;
								num8 = 0f;
							}
							else if (this.type == 27)
							{
								num7 *= 0f;
								num8 *= 0.3f;
								num9 = 1f;
							}
							else if (this.type == 34)
							{
								num8 *= 0.1f;
								num9 *= 0.1f;
							}
							else if (this.type == 36)
							{
								num7 = 0.8f;
								num8 *= 0.2f;
								num9 *= 0.6f;
							}
							else if (this.type == 41)
							{
								num8 *= 0.8f;
								num9 *= 0.6f;
							}
							else if (this.type == 44 || this.type == 45)
							{
								num9 = 1f;
								num7 *= 0.6f;
								num8 *= 0.1f;
							}
							else if (this.type == 50)
							{
								num7 *= 0.7f;
								num9 *= 0.8f;
							}
							else if (this.type == 53)
							{
								num7 *= 0.7f;
								num8 *= 0.8f;
							}
							else if (this.type == 72)
							{
								num7 *= 0.45f;
								num8 *= 0.75f;
								num9 = 1f;
							}
							else if (this.type == 86)
							{
								num7 *= 1f;
								num8 *= 0.45f;
								num9 = 0.75f;
							}
							else if (this.type == 87)
							{
								num7 *= 0.45f;
								num8 = 1f;
								num9 *= 0.75f;
							}
							else if (this.type == 73)
							{
								num7 *= 0.4f;
								num8 *= 0.6f;
								num9 *= 1f;
							}
							else if (this.type == 74)
							{
								num7 *= 1f;
								num8 *= 0.4f;
								num9 *= 0.6f;
							}
							else if (this.type == 76 || this.type == 77 || this.type == 78)
							{
								num7 *= 1f;
								num8 *= 0.3f;
								num9 *= 0.6f;
							}
							else if (this.type == 79)
							{
								num7 = (float)Main.DiscoR / 255f;
								num8 = (float)Main.DiscoG / 255f;
								num9 = (float)Main.DiscoB / 255f;
							}
							else if (this.type == 80)
							{
								num7 *= 0f;
								num8 *= 0.8f;
								num9 *= 1f;
							}
							else if (this.type == 83 || this.type == 88)
							{
								num7 *= 0.7f;
								num8 *= 0f;
								num9 *= 1f;
							}
							else if (this.type == 100)
							{
								num7 *= 1f;
								num8 *= 0.5f;
								num9 *= 0f;
							}
							else if (this.type == 84)
							{
								num7 *= 0.8f;
								num8 *= 0f;
								num9 *= 0.5f;
							}
							else if (this.type == 89 || this.type == 90)
							{
								num8 *= 0.2f;
								num9 *= 1f;
								num7 *= 0.05f;
							}
							else if (this.type == 106)
							{
								num7 *= 0f;
								num8 *= 0.5f;
								num9 *= 1f;
							}
							Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), num7, num8, num9);
						}
						if (this.type == 2 || this.type == 82)
						{
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						}
						else if (this.type == 103)
						{
							int num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num10].noGravity = true;
								Main.dust[num10].scale *= 2f;
							}
						}
						else if (this.type == 4)
						{
							if (Main.rand.Next(5) == 0)
							{
								Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
							}
						}
						else if (this.type == 5)
						{
							int num11 = Main.rand.Next(3);
							if (num11 == 0)
							{
								num11 = 15;
							}
							else if (num11 == 1)
							{
								num11 = 57;
							}
							else
							{
								num11 = 58;
							}
							Dust.NewDust(this.position, this.width, this.height, num11, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.2f);
						}
						this.Damage();
						if (Main.netMode != 1 && this.type == 99)
						{
							Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
						}
						if (this.type == 94)
						{
							for (int num12 = this.oldPos.Length - 1; num12 > 0; num12--)
							{
								this.oldPos[num12] = this.oldPos[num12 - 1];
							}
							this.oldPos[0] = this.position;
						}
						this.timeLeft--;
						if (this.timeLeft <= 0)
						{
							this.Kill();
						}
						if (this.penetrate == 0)
						{
							this.Kill();
						}
						if (this.active && this.owner == Main.myPlayer)
						{
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
								if (this.netSpam < 60)
								{
									this.netSpam += 5;
									NetMessage.SendData(27, -1, -1, "", i, 0f, 0f, 0f, 0);
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
						}
						if (this.active && this.maxUpdates > 0)
						{
							this.numUpdates--;
							if (this.numUpdates >= 0)
							{
								this.Update(i);
							}
							else
							{
								this.numUpdates = this.maxUpdates;
							}
						}
						this.netUpdate = false;
					}
				}
			}
		}

		public void AI()
		{
			if (this.aiStyle == 1)
			{
				if (this.type == 83 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 110 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
				}
				if (this.type == 84 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 12);
				}
				if (this.type == 100 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 98 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if ((this.type == 81 || this.type == 82) && this.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
					this.ai[1] = 1f;
				}
				if (this.type == 41)
				{
					Vector2 vector = new Vector2(this.position.X, this.position.Y);
					int num = this.width;
					int num2 = this.height;
					int num3 = 31;
					float speedX = 0f;
					float speedY = 0f;
					int num4 = 100;
					Color newColor = default(Color);
					int num5 = Dust.NewDust(vector, num, num2, num3, speedX, speedY, num4, newColor, 1.6f);
					Main.dust[num5].noGravity = true;
					Vector2 vector2 = new Vector2(this.position.X, this.position.Y);
					int num6 = this.width;
					int num7 = this.height;
					int num8 = 6;
					float speedX2 = 0f;
					float speedY2 = 0f;
					int num9 = 100;
					newColor = default(Color);
					num5 = Dust.NewDust(vector2, num6, num7, num8, speedX2, speedY2, num9, newColor, 2f);
					Main.dust[num5].noGravity = true;
				}
				else if (this.type == 55)
				{
					Vector2 vector3 = new Vector2(this.position.X, this.position.Y);
					int num10 = this.width;
					int num11 = this.height;
					int num12 = 18;
					float speedX3 = 0f;
					float speedY3 = 0f;
					int num13 = 0;
					Color newColor = default(Color);
					int num14 = Dust.NewDust(vector3, num10, num11, num12, speedX3, speedY3, num13, newColor, 0.9f);
					Main.dust[num14].noGravity = true;
				}
				else if (this.type == 91 && Main.rand.Next(2) == 0)
				{
					int num15 = Main.rand.Next(2);
					if (num15 == 0)
					{
						num15 = 15;
					}
					else
					{
						num15 = 58;
					}
					Vector2 vector4 = this.position;
					int num16 = this.width;
					int num17 = this.height;
					int num18 = num15;
					float speedX4 = this.velocity.X * 0.25f;
					float speedY4 = this.velocity.Y * 0.25f;
					int num19 = 150;
					int num20 = Dust.NewDust(vector4, num16, num17, num18, speedX4, speedY4, num19, default(Color), 0.9f);
					Dust dust = Main.dust[num20];
					dust.velocity *= 0.25f;
				}
				if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 89 || this.type == 100 || this.type == 104 || this.type == 110)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 15;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 88)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 10;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type != 5 && this.type != 14 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 104 && this.type != 110)
				{
					this.ai[0] += 1f;
				}
				if (this.type == 81 || this.type == 91)
				{
					if (this.ai[0] >= 20f)
					{
						this.ai[0] = 20f;
						this.velocity.Y = this.velocity.Y + 0.07f;
					}
				}
				else if (this.ai[0] >= 15f)
				{
					this.ai[0] = 15f;
					this.velocity.Y = this.velocity.Y + 0.1f;
				}
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 2)
			{
				if (this.type == 93 && Main.rand.Next(5) == 0)
				{
					Vector2 vector5 = this.position;
					int num21 = this.width;
					int num22 = this.height;
					int num23 = 57;
					float speedX5 = this.velocity.X * 0.2f + (float)(this.direction * 3);
					float speedY5 = this.velocity.Y * 0.2f;
					int num24 = 100;
					int num25 = Dust.NewDust(vector5, num21, num22, num23, speedX5, speedY5, num24, default(Color), 0.3f);
					Dust dust2 = Main.dust[num25];
					dust2.velocity.X = dust2.velocity.X * 0.3f;
					Dust dust3 = Main.dust[num25];
					dust3.velocity.Y = dust3.velocity.Y * 0.3f;
				}
				this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f * (float)this.direction;
				if (this.type == 69 || this.type == 70)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 10f)
					{
						this.velocity.Y = this.velocity.Y + 0.25f;
						this.velocity.X = this.velocity.X * 0.99f;
					}
				}
				else
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 20f)
					{
						this.velocity.Y = this.velocity.Y + 0.4f;
						this.velocity.X = this.velocity.X * 0.97f;
					}
					else if (this.type == 48 || this.type == 54 || this.type == 93)
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					}
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
				if (this.type == 54 && Main.rand.Next(20) == 0)
				{
					Vector2 vector6 = new Vector2(this.position.X, this.position.Y);
					int num26 = this.width;
					int num27 = this.height;
					int num28 = 40;
					float speedX6 = this.velocity.X * 0.1f;
					float speedY6 = this.velocity.Y * 0.1f;
					int num29 = 0;
					Color newColor = default(Color);
					Dust.NewDust(vector6, num26, num27, num28, speedX6, speedY6, num29, newColor, 0.75f);
				}
			}
			else if (this.aiStyle == 3)
			{
				if (this.soundDelay == 0)
				{
					this.soundDelay = 8;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 7);
				}
				if (this.type == 19)
				{
					for (int i = 0; i < 2; i++)
					{
						Vector2 vector7 = new Vector2(this.position.X, this.position.Y);
						int num30 = this.width;
						int num31 = this.height;
						int num32 = 6;
						float speedX7 = this.velocity.X * 0.2f;
						float speedY7 = this.velocity.Y * 0.2f;
						int num33 = 100;
						Color newColor = default(Color);
						int num34 = Dust.NewDust(vector7, num30, num31, num32, speedX7, speedY7, num33, newColor, 2f);
						Main.dust[num34].noGravity = true;
						Dust dust4 = Main.dust[num34];
						dust4.velocity.X = dust4.velocity.X * 0.3f;
						Dust dust5 = Main.dust[num34];
						dust5.velocity.Y = dust5.velocity.Y * 0.3f;
					}
				}
				else if (this.type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						Vector2 vector8 = this.position;
						int num35 = this.width;
						int num36 = this.height;
						int num37 = 40;
						float speedX8 = this.velocity.X * 0.25f;
						float speedY8 = this.velocity.Y * 0.25f;
						int num38 = 0;
						int num39 = Dust.NewDust(vector8, num35, num36, num37, speedX8, speedY8, num38, default(Color), 1.4f);
						Main.dust[num39].noGravity = true;
					}
				}
				else if (this.type == 6 && Main.rand.Next(5) == 0)
				{
					int num40 = Main.rand.Next(3);
					if (num40 == 0)
					{
						num40 = 15;
					}
					else if (num40 == 1)
					{
						num40 = 57;
					}
					else
					{
						num40 = 58;
					}
					Vector2 vector9 = this.position;
					int num41 = this.width;
					int num42 = this.height;
					int num43 = num40;
					float speedX9 = this.velocity.X * 0.25f;
					float speedY9 = this.velocity.Y * 0.25f;
					int num44 = 150;
					Dust.NewDust(vector9, num41, num42, num43, speedX9, speedY9, num44, default(Color), 0.7f);
				}
				if (this.ai[0] == 0f)
				{
					this.ai[1] += 1f;
					if (this.type == 106)
					{
						if (this.ai[1] >= 45f)
						{
							this.ai[0] = 1f;
							this.ai[1] = 0f;
							this.netUpdate = true;
						}
					}
					else if (this.ai[1] >= 30f)
					{
						this.ai[0] = 1f;
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
				}
				else
				{
					this.tileCollide = false;
					float num45 = 9f;
					float num46 = 0.4f;
					if (this.type == 19)
					{
						num45 = 13f;
						num46 = 0.6f;
					}
					else if (this.type == 33)
					{
						num45 = 15f;
						num46 = 0.8f;
					}
					else if (this.type == 106)
					{
						num45 = 16f;
						num46 = 1.2f;
					}
					Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num47 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector10.X;
					float num48 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector10.Y;
					float num49 = (float)Math.Sqrt((double)(num47 * num47 + num48 * num48));
					if (num49 > 3000f)
					{
						this.Kill();
					}
					num49 = num45 / num49;
					num47 *= num49;
					num48 *= num49;
					if (this.velocity.X < num47)
					{
						this.velocity.X = this.velocity.X + num46;
						if (this.velocity.X < 0f && num47 > 0f)
						{
							this.velocity.X = this.velocity.X + num46;
						}
					}
					else if (this.velocity.X > num47)
					{
						this.velocity.X = this.velocity.X - num46;
						if (this.velocity.X > 0f && num47 < 0f)
						{
							this.velocity.X = this.velocity.X - num46;
						}
					}
					if (this.velocity.Y < num48)
					{
						this.velocity.Y = this.velocity.Y + num46;
						if (this.velocity.Y < 0f && num48 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num46;
						}
					}
					else if (this.velocity.Y > num48)
					{
						this.velocity.Y = this.velocity.Y - num46;
						if (this.velocity.Y > 0f && num48 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num46;
						}
					}
					if (Main.myPlayer == this.owner)
					{
						Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						Rectangle value = new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
						if (rectangle.Intersects(value))
						{
							this.Kill();
						}
					}
				}
				if (this.type == 106)
				{
					this.rotation += 0.3f * (float)this.direction;
				}
				else
				{
					this.rotation += 0.4f * (float)this.direction;
				}
			}
			else if (this.aiStyle == 4)
			{
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				if (this.ai[0] == 0f)
				{
					this.alpha -= 50;
					if (this.alpha <= 0)
					{
						this.alpha = 0;
						this.ai[0] = 1f;
						if (this.ai[1] == 0f)
						{
							this.ai[1] += 1f;
							this.position += this.velocity * 1f;
						}
						if (this.type == 7 && Main.myPlayer == this.owner)
						{
							int num50 = this.type;
							if (this.ai[1] >= 6f)
							{
								num50++;
							}
							int num51 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num50, this.damage, this.knockBack, this.owner);
							Main.projectile[num51].damage = this.damage;
							Main.projectile[num51].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num51, 0f, 0f, 0f, 0);
						}
					}
				}
				else
				{
					if (this.alpha < 170 && this.alpha + 5 >= 170)
					{
						for (int j = 0; j < 3; j++)
						{
							Vector2 vector11 = this.position;
							int num52 = this.width;
							int num53 = this.height;
							int num54 = 18;
							float speedX10 = this.velocity.X * 0.025f;
							float speedY10 = this.velocity.Y * 0.025f;
							int num55 = 170;
							Dust.NewDust(vector11, num52, num53, num54, speedX10, speedY10, num55, default(Color), 1.2f);
						}
						Vector2 vector12 = this.position;
						int num56 = this.width;
						int num57 = this.height;
						int num58 = 14;
						float speedX11 = 0f;
						float speedY11 = 0f;
						int num59 = 170;
						Dust.NewDust(vector12, num56, num57, num58, speedX11, speedY11, num59, default(Color), 1.1f);
					}
					this.alpha += 5;
					if (this.alpha >= 255)
					{
						this.Kill();
					}
				}
			}
			else if (this.aiStyle == 5)
			{
				if (this.type == 92)
				{
					if (this.position.Y > this.ai[1])
					{
						this.tileCollide = true;
					}
				}
				else
				{
					if (this.ai[1] == 0f && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[1] = 1f;
						this.netUpdate = true;
					}
					if (this.ai[1] != 0f)
					{
						this.tileCollide = true;
					}
				}
				if (this.soundDelay == 0)
				{
					this.soundDelay = 20 + Main.rand.Next(40);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
				}
				if (this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
				}
				this.alpha += (int)(25f * this.localAI[0]);
				if (this.alpha > 200)
				{
					this.alpha = 200;
					this.localAI[0] = -1f;
				}
				if (this.alpha < 0)
				{
					this.alpha = 0;
					this.localAI[0] = 1f;
				}
				this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f * (float)this.direction;
				if (this.ai[1] == 1f || this.type == 92)
				{
					this.light = 0.9f;
					if (Main.rand.Next(10) == 0)
					{
						Vector2 vector13 = this.position;
						int num60 = this.width;
						int num61 = this.height;
						int num62 = 58;
						float speedX12 = this.velocity.X * 0.5f;
						float speedY12 = this.velocity.Y * 0.5f;
						int num63 = 150;
						Dust.NewDust(vector13, num60, num61, num62, speedX12, speedY12, num63, default(Color), 1.2f);
					}
					if (Main.rand.Next(20) == 0)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
					}
				}
			}
			else if (this.aiStyle == 6)
			{
				this.velocity *= 0.95f;
				this.ai[0] += 1f;
				if (this.ai[0] == 180f)
				{
					this.Kill();
				}
				if (this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					for (int k = 0; k < 30; k++)
					{
						Vector2 vector14 = this.position;
						int num64 = this.width;
						int num65 = this.height;
						int num66 = 10 + this.type;
						float x = this.velocity.X;
						float y = this.velocity.Y;
						int num67 = 50;
						Dust.NewDust(vector14, num64, num65, num66, x, y, num67, default(Color), 1f);
					}
				}
				if (this.type == 10 || this.type == 11)
				{
					int num68 = (int)(this.position.X / 16f) - 1;
					int num69 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num70 = (int)(this.position.Y / 16f) - 1;
					int num71 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num68 < 0)
					{
						num68 = 0;
					}
					if (num69 > Main.maxTilesX)
					{
						num69 = Main.maxTilesX;
					}
					if (num70 < 0)
					{
						num70 = 0;
					}
					if (num71 > Main.maxTilesY)
					{
						num71 = Main.maxTilesY;
					}
					for (int l = num68; l < num69; l++)
					{
						for (int m = num70; m < num71; m++)
						{
							Vector2 vector15;
							vector15.X = (float)(l * 16);
							vector15.Y = (float)(m * 16);
							if (this.position.X + (float)this.width > vector15.X && this.position.X < vector15.X + 16f && this.position.Y + (float)this.height > vector15.Y && this.position.Y < vector15.Y + 16f && Main.myPlayer == this.owner && Main.tile[l, m].active)
							{
								if (this.type == 10)
								{
									if (Main.tile[l, m].type == 23)
									{
										Main.tile[l, m].type = 2;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
									if (Main.tile[l, m].type == 25)
									{
										Main.tile[l, m].type = 1;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
									if (Main.tile[l, m].type == 112)
									{
										Main.tile[l, m].type = 53;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
								}
								else if (this.type == 11)
								{
									if (Main.tile[l, m].type == 109)
									{
										Main.tile[l, m].type = 2;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
									if (Main.tile[l, m].type == 116)
									{
										Main.tile[l, m].type = 53;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
									if (Main.tile[l, m].type == 117)
									{
										Main.tile[l, m].type = 1;
										WorldGen.SquareTileFrame(l, m, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, l, m, 1);
										}
									}
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 7)
			{
				if (Main.player[this.owner].dead)
				{
					this.Kill();
				}
				else
				{
					Vector2 vector16 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num72 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector16.X;
					float num73 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector16.Y;
					float num74 = (float)Math.Sqrt((double)(num72 * num72 + num73 * num73));
					this.rotation = (float)Math.Atan2((double)num73, (double)num72) - 1.57f;
					if (this.ai[0] == 0f)
					{
						if ((num74 > 300f && this.type == 13) || (num74 > 400f && this.type == 32) || (num74 > 440f && this.type == 73) || (num74 > 440f && this.type == 74))
						{
							this.ai[0] = 1f;
						}
						int num75 = (int)(this.position.X / 16f) - 1;
						int num76 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num77 = (int)(this.position.Y / 16f) - 1;
						int num78 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num75 < 0)
						{
							num75 = 0;
						}
						if (num76 > Main.maxTilesX)
						{
							num76 = Main.maxTilesX;
						}
						if (num77 < 0)
						{
							num77 = 0;
						}
						if (num78 > Main.maxTilesY)
						{
							num78 = Main.maxTilesY;
						}
						for (int n = num75; n < num76; n++)
						{
							int num79 = num77;
							while (num79 < num78)
							{
								if (Main.tile[n, num79] == null)
								{
									Main.tile[n, num79] = new Tile();
								}
								Vector2 vector17;
								vector17.X = (float)(n * 16);
								vector17.Y = (float)(num79 * 16);
								if (this.position.X + (float)this.width > vector17.X && this.position.X < vector17.X + 16f && this.position.Y + (float)this.height > vector17.Y && this.position.Y < vector17.Y + 16f && Main.tile[n, num79].active && Main.tileSolid[(int)Main.tile[n, num79].type])
								{
									if (Main.player[this.owner].grapCount < 10)
									{
										Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
										Main.player[this.owner].grapCount++;
									}
									if (Main.myPlayer == this.owner)
									{
										int num80 = 0;
										int num81 = -1;
										int num82 = 100000;
										if (this.type == 73 || this.type == 74)
										{
											for (int num83 = 0; num83 < 1000; num83++)
											{
												if (num83 != this.whoAmI && Main.projectile[num83].active && Main.projectile[num83].owner == this.owner && Main.projectile[num83].aiStyle == 7 && Main.projectile[num83].ai[0] == 2f)
												{
													Main.projectile[num83].Kill();
												}
											}
										}
										else
										{
											for (int num84 = 0; num84 < 1000; num84++)
											{
												if (Main.projectile[num84].active && Main.projectile[num84].owner == this.owner && Main.projectile[num84].aiStyle == 7)
												{
													if (Main.projectile[num84].timeLeft < num82)
													{
														num81 = num84;
														num82 = Main.projectile[num84].timeLeft;
													}
													num80++;
												}
											}
											if (num80 > 3)
											{
												Main.projectile[num81].Kill();
											}
										}
									}
									WorldGen.KillTile(n, num79, true, true, false);
									Main.PlaySound(0, n * 16, num79 * 16, 1);
									this.velocity.X = 0f;
									this.velocity.Y = 0f;
									this.ai[0] = 2f;
									this.position.X = (float)(n * 16 + 8 - this.width / 2);
									this.position.Y = (float)(num79 * 16 + 8 - this.height / 2);
									this.damage = 0;
									this.netUpdate = true;
									if (Main.myPlayer == this.owner)
									{
										NetMessage.SendData(13, -1, -1, "", this.owner, 0f, 0f, 0f, 0);
										break;
									}
									break;
								}
								else
								{
									num79++;
								}
							}
							if (this.ai[0] == 2f)
							{
								break;
							}
						}
					}
					else if (this.ai[0] == 1f)
					{
						float num85 = 11f;
						if (this.type == 32)
						{
							num85 = 15f;
						}
						if (this.type == 73 || this.type == 74)
						{
							num85 = 17f;
						}
						if (num74 < 24f)
						{
							this.Kill();
						}
						num74 = num85 / num74;
						num72 *= num74;
						num73 *= num74;
						this.velocity.X = num72;
						this.velocity.Y = num73;
					}
					else if (this.ai[0] == 2f)
					{
						int num86 = (int)(this.position.X / 16f) - 1;
						int num87 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num88 = (int)(this.position.Y / 16f) - 1;
						int num89 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num86 < 0)
						{
							num86 = 0;
						}
						if (num87 > Main.maxTilesX)
						{
							num87 = Main.maxTilesX;
						}
						if (num88 < 0)
						{
							num88 = 0;
						}
						if (num89 > Main.maxTilesY)
						{
							num89 = Main.maxTilesY;
						}
						bool flag = true;
						for (int num90 = num86; num90 < num87; num90++)
						{
							for (int num91 = num88; num91 < num89; num91++)
							{
								if (Main.tile[num90, num91] == null)
								{
									Main.tile[num90, num91] = new Tile();
								}
								Vector2 vector18;
								vector18.X = (float)(num90 * 16);
								vector18.Y = (float)(num91 * 16);
								if (this.position.X + (float)(this.width / 2) > vector18.X && this.position.X + (float)(this.width / 2) < vector18.X + 16f && this.position.Y + (float)(this.height / 2) > vector18.Y && this.position.Y + (float)(this.height / 2) < vector18.Y + 16f && Main.tile[num90, num91].active && Main.tileSolid[(int)Main.tile[num90, num91].type])
								{
									flag = false;
								}
							}
						}
						if (flag)
						{
							this.ai[0] = 1f;
						}
						else if (Main.player[this.owner].grapCount < 10)
						{
							Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
							Main.player[this.owner].grapCount++;
						}
					}
				}
			}
			else if (this.aiStyle == 8)
			{
				if (this.type == 96 && this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
				}
				if (this.type == 27)
				{
					Vector2 vector19 = new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
					int num92 = this.width;
					int num93 = this.height;
					int num94 = 29;
					float x2 = this.velocity.X;
					float y2 = this.velocity.Y;
					int num95 = 100;
					Color newColor = default(Color);
					int num96 = Dust.NewDust(vector19, num92, num93, num94, x2, y2, num95, newColor, 3f);
					Main.dust[num96].noGravity = true;
					if (Main.rand.Next(10) == 0)
					{
						Vector2 vector20 = new Vector2(this.position.X, this.position.Y);
						int num97 = this.width;
						int num98 = this.height;
						int num99 = 29;
						float x3 = this.velocity.X;
						float y3 = this.velocity.Y;
						int num100 = 100;
						newColor = default(Color);
						num96 = Dust.NewDust(vector20, num97, num98, num99, x3, y3, num100, newColor, 1.4f);
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Vector2 vector21 = new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
					int num101 = this.width;
					int num102 = this.height;
					int num103 = 75;
					float x4 = this.velocity.X;
					float y4 = this.velocity.Y;
					int num104 = 100;
					Color newColor = default(Color);
					int num105 = Dust.NewDust(vector21, num101, num102, num103, x4, y4, num104, newColor, 3f * this.scale);
					Main.dust[num105].noGravity = true;
				}
				else
				{
					for (int num106 = 0; num106 < 2; num106++)
					{
						Vector2 vector22 = new Vector2(this.position.X, this.position.Y);
						int num107 = this.width;
						int num108 = this.height;
						int num109 = 6;
						float speedX13 = this.velocity.X * 0.2f;
						float speedY13 = this.velocity.Y * 0.2f;
						int num110 = 100;
						Color newColor = default(Color);
						int num111 = Dust.NewDust(vector22, num107, num108, num109, speedX13, speedY13, num110, newColor, 2f);
						Main.dust[num111].noGravity = true;
						Dust dust6 = Main.dust[num111];
						dust6.velocity.X = dust6.velocity.X * 0.3f;
						Dust dust7 = Main.dust[num111];
						dust7.velocity.Y = dust7.velocity.Y * 0.3f;
					}
				}
				if (this.type != 27 && this.type != 96)
				{
					this.ai[1] += 1f;
				}
				if (this.ai[1] >= 20f)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				this.rotation += 0.3f * (float)this.direction;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 9)
			{
				if (this.type == 34)
				{
					Vector2 vector23 = new Vector2(this.position.X, this.position.Y);
					int num112 = this.width;
					int num113 = this.height;
					int num114 = 6;
					float speedX14 = this.velocity.X * 0.2f;
					float speedY14 = this.velocity.Y * 0.2f;
					int num115 = 100;
					Color newColor = default(Color);
					int num116 = Dust.NewDust(vector23, num112, num113, num114, speedX14, speedY14, num115, newColor, 3.5f);
					Main.dust[num116].noGravity = true;
					Dust dust8 = Main.dust[num116];
					dust8.velocity *= 1.4f;
					Vector2 vector24 = new Vector2(this.position.X, this.position.Y);
					int num117 = this.width;
					int num118 = this.height;
					int num119 = 6;
					float speedX15 = this.velocity.X * 0.2f;
					float speedY15 = this.velocity.Y * 0.2f;
					int num120 = 100;
					newColor = default(Color);
					num116 = Dust.NewDust(vector24, num117, num118, num119, speedX15, speedY15, num120, newColor, 1.5f);
				}
				else if (this.type == 79)
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					for (int num121 = 0; num121 < 1; num121++)
					{
						int num122 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Dust dust9 = Main.dust[num122];
						dust9.velocity *= 0.1f;
						Dust dust10 = Main.dust[num122];
						dust10.velocity += this.velocity * 0.2f;
						Main.dust[num122].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num122].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num122].noGravity = true;
					}
				}
				else
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					Vector2 vector25 = new Vector2(this.position.X, this.position.Y);
					int num123 = this.width;
					int num124 = this.height;
					int num125 = 15;
					float speedX16 = 0f;
					float speedY16 = 0f;
					int num126 = 100;
					Color newColor = default(Color);
					int num127 = Dust.NewDust(vector25, num123, num124, num125, speedX16, speedY16, num126, newColor, 2f);
					Dust dust11 = Main.dust[num127];
					dust11.velocity *= 0.3f;
					Main.dust[num127].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num127].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num127].noGravity = true;
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num128 = 12f;
						if (this.type == 16)
						{
							num128 = 15f;
						}
						Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num129 = (float)Main.mouseX + Main.screenPosition.X - vector26.X;
						float num130 = (float)Main.mouseY + Main.screenPosition.Y - vector26.Y;
						float num131 = (float)Math.Sqrt((double)(num129 * num129 + num130 * num130));
						num131 = (float)Math.Sqrt((double)(num129 * num129 + num130 * num130));
						if (num131 > num128)
						{
							num131 = num128 / num131;
							num129 *= num131;
							num130 *= num131;
							int num132 = (int)(num129 * 1000f);
							int num133 = (int)(this.velocity.X * 1000f);
							int num134 = (int)(num130 * 1000f);
							int num135 = (int)(this.velocity.Y * 1000f);
							if (num132 != num133 || num134 != num135)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num129;
							this.velocity.Y = num130;
						}
						else
						{
							int num136 = (int)(num129 * 1000f);
							int num137 = (int)(this.velocity.X * 1000f);
							int num138 = (int)(num130 * 1000f);
							int num139 = (int)(this.velocity.Y * 1000f);
							if (num136 != num137 || num138 != num139)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num129;
							this.velocity.Y = num130;
						}
					}
					else if (this.ai[0] == 0f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						float num140 = 12f;
						Vector2 vector27 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num141 = (float)Main.mouseX + Main.screenPosition.X - vector27.X;
						float num142 = (float)Main.mouseY + Main.screenPosition.Y - vector27.Y;
						float num143 = (float)Math.Sqrt((double)(num141 * num141 + num142 * num142));
						if (num143 == 0f)
						{
							vector27 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
							num141 = this.position.X + (float)this.width * 0.5f - vector27.X;
							num142 = this.position.Y + (float)this.height * 0.5f - vector27.Y;
							num143 = (float)Math.Sqrt((double)(num141 * num141 + num142 * num142));
						}
						num143 = num140 / num143;
						num141 *= num143;
						num142 *= num143;
						this.velocity.X = num141;
						this.velocity.Y = num142;
						if (this.velocity.X == 0f && this.velocity.Y == 0f)
						{
							this.Kill();
						}
					}
				}
				if (this.type == 34)
				{
					this.rotation += 0.3f * (float)this.direction;
				}
				else if (this.velocity.X != 0f || this.velocity.Y != 0f)
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 2.355f;
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 10)
			{
				if (this.type == 31 && this.ai[0] != 2f)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector28 = new Vector2(this.position.X, this.position.Y);
						int num144 = this.width;
						int num145 = this.height;
						int num146 = 32;
						float speedX17 = 0f;
						float speedY17 = this.velocity.Y / 2f;
						int num147 = 0;
						Color newColor = default(Color);
						int num148 = Dust.NewDust(vector28, num144, num145, num146, speedX17, speedY17, num147, newColor, 1f);
						Dust dust12 = Main.dust[num148];
						dust12.velocity.X = dust12.velocity.X * 0.4f;
					}
				}
				else if (this.type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector29 = new Vector2(this.position.X, this.position.Y);
						int num149 = this.width;
						int num150 = this.height;
						int num151 = 38;
						float speedX18 = 0f;
						float speedY18 = this.velocity.Y / 2f;
						int num152 = 0;
						Color newColor = default(Color);
						int num153 = Dust.NewDust(vector29, num149, num150, num151, speedX18, speedY18, num152, newColor, 1f);
						Dust dust13 = Main.dust[num153];
						dust13.velocity.X = dust13.velocity.X * 0.4f;
					}
				}
				else if (this.type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector30 = new Vector2(this.position.X, this.position.Y);
						int num154 = this.width;
						int num155 = this.height;
						int num156 = 36;
						float speedX19 = 0f;
						float speedY19 = this.velocity.Y / 2f;
						int num157 = 0;
						Color newColor = default(Color);
						int num158 = Dust.NewDust(vector30, num154, num155, num156, speedX19, speedY19, num157, newColor, 1f);
						Dust dust14 = Main.dust[num158];
						dust14.velocity *= 0.4f;
					}
				}
				else if (this.type == 42 || this.type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector31 = new Vector2(this.position.X, this.position.Y);
						int num159 = this.width;
						int num160 = this.height;
						int num161 = 32;
						float speedX20 = 0f;
						float speedY20 = 0f;
						int num162 = 0;
						Color newColor = default(Color);
						int num163 = Dust.NewDust(vector31, num159, num160, num161, speedX20, speedY20, num162, newColor, 1f);
						Dust dust15 = Main.dust[num163];
						dust15.velocity.X = dust15.velocity.X * 0.4f;
					}
				}
				else if (this.type == 56 || this.type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector32 = new Vector2(this.position.X, this.position.Y);
						int num164 = this.width;
						int num165 = this.height;
						int num166 = 14;
						float speedX21 = 0f;
						float speedY21 = 0f;
						int num167 = 0;
						Color newColor = default(Color);
						int num168 = Dust.NewDust(vector32, num164, num165, num166, speedX21, speedY21, num167, newColor, 1f);
						Dust dust16 = Main.dust[num168];
						dust16.velocity.X = dust16.velocity.X * 0.4f;
					}
				}
				else if (this.type == 67 || this.type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector33 = new Vector2(this.position.X, this.position.Y);
						int num169 = this.width;
						int num170 = this.height;
						int num171 = 51;
						float speedX22 = 0f;
						float speedY22 = 0f;
						int num172 = 0;
						Color newColor = default(Color);
						int num173 = Dust.NewDust(vector33, num169, num170, num171, speedX22, speedY22, num172, newColor, 1f);
						Dust dust17 = Main.dust[num173];
						dust17.velocity.X = dust17.velocity.X * 0.4f;
					}
				}
				else if (this.type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						Vector2 vector34 = new Vector2(this.position.X, this.position.Y);
						int num174 = this.width;
						int num175 = this.height;
						int num176 = 53;
						float speedX23 = 0f;
						float speedY23 = 0f;
						int num177 = 0;
						Color newColor = default(Color);
						int num178 = Dust.NewDust(vector34, num174, num175, num176, speedX23, speedY23, num177, newColor, 1f);
						Dust dust18 = Main.dust[num178];
						dust18.velocity.X = dust18.velocity.X * 0.4f;
					}
				}
				else if (this.type != 109 && Main.rand.Next(20) == 0)
				{
					Vector2 vector35 = new Vector2(this.position.X, this.position.Y);
					int num179 = this.width;
					int num180 = this.height;
					int num181 = 0;
					float speedX24 = 0f;
					float speedY24 = 0f;
					int num182 = 0;
					Color newColor = default(Color);
					Dust.NewDust(vector35, num179, num180, num181, speedX24, speedY24, num182, newColor, 1f);
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num183 = 12f;
						Vector2 vector36 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num184 = (float)Main.mouseX + Main.screenPosition.X - vector36.X;
						float num185 = (float)Main.mouseY + Main.screenPosition.Y - vector36.Y;
						float num186 = (float)Math.Sqrt((double)(num184 * num184 + num185 * num185));
						num186 = (float)Math.Sqrt((double)(num184 * num184 + num185 * num185));
						if (num186 > num183)
						{
							num186 = num183 / num186;
							num184 *= num186;
							num185 *= num186;
							if (num184 != this.velocity.X || num185 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num184;
							this.velocity.Y = num185;
						}
						else
						{
							if (num184 != this.velocity.X || num185 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num184;
							this.velocity.Y = num185;
						}
					}
					else
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
					}
				}
				if (this.ai[0] == 1f && this.type != 109)
				{
					if (this.type == 42 || this.type == 65 || this.type == 68)
					{
						this.ai[1] += 1f;
						if (this.ai[1] >= 60f)
						{
							this.ai[1] = 60f;
							this.velocity.Y = this.velocity.Y + 0.2f;
						}
					}
					else
					{
						this.velocity.Y = this.velocity.Y + 0.41f;
					}
				}
				else if (this.ai[0] == 2f && this.type != 109)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
					if ((double)this.velocity.X < -0.04)
					{
						this.velocity.X = this.velocity.X + 0.04f;
					}
					else if ((double)this.velocity.X > 0.04)
					{
						this.velocity.X = this.velocity.X - 0.04f;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				this.rotation += 0.1f;
				if (this.velocity.Y > 10f)
				{
					this.velocity.Y = 10f;
				}
			}
			else if (this.aiStyle == 11)
			{
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					if (this.velocity.X > 0f)
					{
						this.spriteDirection = -1;
					}
					else if (this.velocity.X < 0f)
					{
						this.spriteDirection = 1;
					}
					this.rotation = this.velocity.X * 0.1f;
					this.frameCounter++;
					if (this.frameCounter >= 4)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame >= 4)
					{
						this.frame = 0;
					}
					if (Main.rand.Next(6) == 0)
					{
						int num187 = 56;
						if (this.type == 86)
						{
							num187 = 73;
						}
						else if (this.type == 87)
						{
							num187 = 74;
						}
						Vector2 vector37 = this.position;
						int num188 = this.width;
						int num189 = this.height;
						int num190 = num187;
						float speedX25 = 0f;
						float speedY25 = 0f;
						int num191 = 200;
						int num192 = Dust.NewDust(vector37, num188, num189, num190, speedX25, speedY25, num191, default(Color), 0.8f);
						Dust dust19 = Main.dust[num192];
						dust19.velocity *= 0.3f;
					}
				}
				else
				{
					this.rotation += 0.02f;
				}
				if (Main.myPlayer == this.owner)
				{
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						if (Main.player[Main.myPlayer].fairy)
						{
							this.timeLeft = 2;
						}
					}
					else if (Main.player[Main.myPlayer].lightOrb)
					{
						this.timeLeft = 2;
					}
				}
				if (Main.player[this.owner].dead)
				{
					this.Kill();
				}
				else
				{
					float num193 = 2.5f;
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						num193 = 3.5f;
					}
					Vector2 vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num194 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector38.X;
					float num195 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector38.Y;
					float num196 = (float)Math.Sqrt((double)(num194 * num194 + num195 * num195));
					num196 = (float)Math.Sqrt((double)(num194 * num194 + num195 * num195));
					int num197 = 70;
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						num197 = 40;
					}
					if (num196 > 800f)
					{
						this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
						this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
					}
					else if (num196 > (float)num197)
					{
						num196 = num193 / num196;
						num194 *= num196;
						num195 *= num196;
						this.velocity.X = num194;
						this.velocity.Y = num195;
					}
					else
					{
						this.velocity.X = 0f;
						this.velocity.Y = 0f;
					}
				}
			}
			else if (this.aiStyle == 12)
			{
				this.scale -= 0.04f;
				if (this.scale <= 0f)
				{
					this.Kill();
				}
				if (this.ai[0] > 4f)
				{
					this.alpha = 150;
					this.light = 0.8f;
					Vector2 vector39 = new Vector2(this.position.X, this.position.Y);
					int num198 = this.width;
					int num199 = this.height;
					int num200 = 29;
					float x5 = this.velocity.X;
					float y5 = this.velocity.Y;
					int num201 = 100;
					Color newColor = default(Color);
					int num202 = Dust.NewDust(vector39, num198, num199, num200, x5, y5, num201, newColor, 2.5f);
					Main.dust[num202].noGravity = true;
					Vector2 vector40 = new Vector2(this.position.X, this.position.Y);
					int num203 = this.width;
					int num204 = this.height;
					int num205 = 29;
					float x6 = this.velocity.X;
					float y6 = this.velocity.Y;
					int num206 = 100;
					newColor = default(Color);
					Dust.NewDust(vector40, num203, num204, num205, x6, y6, num206, newColor, 1.5f);
				}
				else
				{
					this.ai[0] += 1f;
				}
				this.rotation += 0.3f * (float)this.direction;
			}
			else if (this.aiStyle == 13)
			{
				if (Main.player[this.owner].dead)
				{
					this.Kill();
				}
				else
				{
					Main.player[this.owner].itemAnimation = 5;
					Main.player[this.owner].itemTime = 5;
					if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
					{
						Main.player[this.owner].direction = 1;
					}
					else
					{
						Main.player[this.owner].direction = -1;
					}
					Vector2 vector41 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num207 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector41.X;
					float num208 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector41.Y;
					float num209 = (float)Math.Sqrt((double)(num207 * num207 + num208 * num208));
					if (this.ai[0] == 0f)
					{
						if (num209 > 700f)
						{
							this.ai[0] = 1f;
						}
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
						this.ai[1] += 1f;
						if (this.ai[1] > 2f)
						{
							this.alpha = 0;
						}
						if (this.ai[1] >= 10f)
						{
							this.ai[1] = 15f;
							this.velocity.Y = this.velocity.Y + 0.3f;
						}
					}
					else if (this.ai[0] == 1f)
					{
						this.tileCollide = false;
						this.rotation = (float)Math.Atan2((double)num208, (double)num207) - 1.57f;
						float num210 = 20f;
						if (num209 < 50f)
						{
							this.Kill();
						}
						num209 = num210 / num209;
						num207 *= num209;
						num208 *= num209;
						this.velocity.X = num207;
						this.velocity.Y = num208;
					}
				}
			}
			else if (this.aiStyle == 14)
			{
				if (this.type == 53)
				{
					try
					{
						Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
						bool flag2 = this.velocity != value2;
						int num211 = (int)(this.position.X / 16f) - 1;
						int num212 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num213 = (int)(this.position.Y / 16f) - 1;
						int num214 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num211 < 0)
						{
							num211 = 0;
						}
						if (num212 > Main.maxTilesX)
						{
							num212 = Main.maxTilesX;
						}
						if (num213 < 0)
						{
							num213 = 0;
						}
						if (num214 > Main.maxTilesY)
						{
							num214 = Main.maxTilesY;
						}
						for (int num215 = num211; num215 < num212; num215++)
						{
							for (int num216 = num213; num216 < num214; num216++)
							{
								if (Main.tile[num215, num216] != null && Main.tile[num215, num216].active && (Main.tileSolid[(int)Main.tile[num215, num216].type] || (Main.tileSolidTop[(int)Main.tile[num215, num216].type] && Main.tile[num215, num216].frameY == 0)))
								{
									Vector2 vector42;
									vector42.X = (float)(num215 * 16);
									vector42.Y = (float)(num216 * 16);
									if (this.position.X + (float)this.width > vector42.X && this.position.X < vector42.X + 16f && this.position.Y + (float)this.height > vector42.Y && this.position.Y < vector42.Y + 16f)
									{
										this.velocity.X = 0f;
										this.velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				this.ai[0] += 1f;
				if (this.ai[0] > 5f)
				{
					this.ai[0] = 5f;
					if (this.velocity.Y == 0f && this.velocity.X != 0f)
					{
						this.velocity.X = this.velocity.X * 0.97f;
						if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
						{
							this.velocity.X = 0f;
							this.netUpdate = true;
						}
					}
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				this.rotation += this.velocity.X * 0.1f;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 15)
			{
				if (this.type == 25)
				{
					if (Main.rand.Next(15) == 0)
					{
						Vector2 vector43 = this.position;
						int num217 = this.width;
						int num218 = this.height;
						int num219 = 14;
						float speedX26 = 0f;
						float speedY26 = 0f;
						int num220 = 150;
						Dust.NewDust(vector43, num217, num218, num219, speedX26, speedY26, num220, default(Color), 1.3f);
					}
				}
				else if (this.type == 26)
				{
					Vector2 vector44 = this.position;
					int num221 = this.width;
					int num222 = this.height;
					int num223 = 29;
					float speedX27 = this.velocity.X * 0.4f;
					float speedY27 = this.velocity.Y * 0.4f;
					int num224 = 100;
					int num225 = Dust.NewDust(vector44, num221, num222, num223, speedX27, speedY27, num224, default(Color), 2.5f);
					Main.dust[num225].noGravity = true;
					Dust dust20 = Main.dust[num225];
					dust20.velocity.X = dust20.velocity.X / 2f;
					Dust dust21 = Main.dust[num225];
					dust21.velocity.Y = dust21.velocity.Y / 2f;
				}
				else if (this.type == 35)
				{
					Vector2 vector45 = this.position;
					int num226 = this.width;
					int num227 = this.height;
					int num228 = 6;
					float speedX28 = this.velocity.X * 0.4f;
					float speedY28 = this.velocity.Y * 0.4f;
					int num229 = 100;
					int num230 = Dust.NewDust(vector45, num226, num227, num228, speedX28, speedY28, num229, default(Color), 3f);
					Main.dust[num230].noGravity = true;
					Dust dust22 = Main.dust[num230];
					dust22.velocity.X = dust22.velocity.X * 2f;
					Dust dust23 = Main.dust[num230];
					dust23.velocity.Y = dust23.velocity.Y * 2f;
				}
				if (Main.player[this.owner].dead)
				{
					this.Kill();
				}
				else
				{
					Main.player[this.owner].itemAnimation = 10;
					Main.player[this.owner].itemTime = 10;
					if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
					{
						Main.player[this.owner].direction = 1;
						this.direction = 1;
					}
					else
					{
						Main.player[this.owner].direction = -1;
						this.direction = -1;
					}
					Vector2 vector46 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num231 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector46.X;
					float num232 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector46.Y;
					float num233 = (float)Math.Sqrt((double)(num231 * num231 + num232 * num232));
					if (this.ai[0] == 0f)
					{
						float num234 = 160f;
						if (this.type == 63)
						{
							num234 *= 1.5f;
						}
						this.tileCollide = true;
						if (num233 > num234)
						{
							this.ai[0] = 1f;
							this.netUpdate = true;
						}
						else if (!Main.player[this.owner].channel)
						{
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
							}
							this.velocity.Y = this.velocity.Y + 1f;
							this.velocity.X = this.velocity.X * 0.9f;
						}
					}
					else if (this.ai[0] == 1f)
					{
						float num235 = 14f / Main.player[this.owner].meleeSpeed;
						float num236 = 0.9f / Main.player[this.owner].meleeSpeed;
						float num237 = 300f;
						if (this.type == 63)
						{
							num237 *= 1.5f;
							num235 *= 1.5f;
							num236 *= 1.5f;
						}
						Math.Abs(num231);
						Math.Abs(num232);
						if (this.ai[1] == 1f)
						{
							this.tileCollide = false;
						}
						if (!Main.player[this.owner].channel || num233 > num237 || !this.tileCollide)
						{
							this.ai[1] = 1f;
							if (this.tileCollide)
							{
								this.netUpdate = true;
							}
							this.tileCollide = false;
							if (num233 < 20f)
							{
								this.Kill();
							}
						}
						if (!this.tileCollide)
						{
							num236 *= 2f;
						}
						if (num233 > 60f || !this.tileCollide)
						{
							num233 = num235 / num233;
							num231 *= num233;
							num232 *= num233;
							new Vector2(this.velocity.X, this.velocity.Y);
							float num238 = num231 - this.velocity.X;
							float num239 = num232 - this.velocity.Y;
							float num240 = (float)Math.Sqrt((double)(num238 * num238 + num239 * num239));
							num240 = num236 / num240;
							num238 *= num240;
							num239 *= num240;
							this.velocity.X = this.velocity.X * 0.98f;
							this.velocity.Y = this.velocity.Y * 0.98f;
							this.velocity.X = this.velocity.X + num238;
							this.velocity.Y = this.velocity.Y + num239;
						}
						else
						{
							if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 6f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
								this.velocity.Y = this.velocity.Y + 0.2f;
							}
							if (Main.player[this.owner].velocity.X == 0f)
							{
								this.velocity.X = this.velocity.X * 0.96f;
							}
						}
					}
					this.rotation = (float)Math.Atan2((double)num232, (double)num231) - this.velocity.X * 0.1f;
				}
			}
			else if (this.aiStyle == 16)
			{
				if (this.type == 108)
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 3f)
					{
						this.Kill();
					}
				}
				if (this.type == 37)
				{
					try
					{
						int num241 = (int)(this.position.X / 16f) - 1;
						int num242 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num243 = (int)(this.position.Y / 16f) - 1;
						int num244 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num241 < 0)
						{
							num241 = 0;
						}
						if (num242 > Main.maxTilesX)
						{
							num242 = Main.maxTilesX;
						}
						if (num243 < 0)
						{
							num243 = 0;
						}
						if (num244 > Main.maxTilesY)
						{
							num244 = Main.maxTilesY;
						}
						for (int num245 = num241; num245 < num242; num245++)
						{
							for (int num246 = num243; num246 < num244; num246++)
							{
								if (Main.tile[num245, num246] != null && Main.tile[num245, num246].active && (Main.tileSolid[(int)Main.tile[num245, num246].type] || (Main.tileSolidTop[(int)Main.tile[num245, num246].type] && Main.tile[num245, num246].frameY == 0)))
								{
									Vector2 vector47;
									vector47.X = (float)(num245 * 16);
									vector47.Y = (float)(num246 * 16);
									if (this.position.X + (float)this.width - 4f > vector47.X && this.position.X + 4f < vector47.X + 16f && this.position.Y + (float)this.height - 4f > vector47.Y && this.position.Y + 4f < vector47.Y + 16f)
									{
										this.velocity.X = 0f;
										this.velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (this.type == 102)
				{
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
					if (this.localAI[0] == 0f)
					{
						this.localAI[0] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					}
					this.frameCounter++;
					if (this.frameCounter > 3)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame > 1)
					{
						this.frame = 0;
					}
					if (this.velocity.Y == 0f)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 40;
						this.knockBack = 8f;
						this.timeLeft = 3;
						this.netUpdate = true;
					}
				}
				if (this.owner == Main.myPlayer && this.timeLeft <= 3)
				{
					this.ai[1] = 0f;
					this.alpha = 255;
					if (this.type == 28 || this.type == 37 || this.type == 75)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 100;
						this.knockBack = 8f;
					}
					else if (this.type == 29)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 250;
						this.height = 250;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 250;
						this.knockBack = 10f;
					}
					else if (this.type == 30)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.knockBack = 8f;
					}
				}
				else
				{
					if (this.type != 30 && this.type != 108)
					{
						this.damage = 0;
					}
					if (this.type != 30 && Main.rand.Next(4) == 0)
					{
						Vector2 vector48 = new Vector2(this.position.X, this.position.Y);
						int num247 = this.width;
						int num248 = this.height;
						int num249 = 6;
						float speedX29 = 0f;
						float speedY29 = 0f;
						int num250 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector48, num247, num248, num249, speedX29, speedY29, num250, newColor, 1f);
					}
				}
				this.ai[0] += 1f;
				if ((this.type == 30 && this.ai[0] > 10f) || (this.type != 30 && this.ai[0] > 5f))
				{
					this.ai[0] = 10f;
					if (this.velocity.Y == 0f && this.velocity.X != 0f)
					{
						this.velocity.X = this.velocity.X * 0.97f;
						if (this.type == 29)
						{
							this.velocity.X = this.velocity.X * 0.99f;
						}
						if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
						{
							this.velocity.X = 0f;
							this.netUpdate = true;
						}
					}
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				this.rotation += this.velocity.X * 0.1f;
			}
			else if (this.aiStyle == 17)
			{
				if (this.velocity.Y == 0f)
				{
					this.velocity.X = this.velocity.X * 0.98f;
				}
				this.rotation += this.velocity.X * 0.1f;
				this.velocity.Y = this.velocity.Y + 0.2f;
				if (this.owner == Main.myPlayer)
				{
					int num251 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
					int num252 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
					if (Main.tile[num251, num252] != null && !Main.tile[num251, num252].active)
					{
						WorldGen.PlaceTile(num251, num252, 85, false, false, -1, 0);
						if (Main.tile[num251, num252].active)
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num251, (float)num252, 85f, 0);
							}
							int num253 = Sign.ReadSign(num251, num252);
							if (num253 >= 0)
							{
								Sign.TextSign(num253, this.miscText);
							}
							this.Kill();
						}
					}
				}
			}
			else if (this.aiStyle == 18)
			{
				if (this.ai[1] == 0f && this.type == 44)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
				}
				this.rotation += (float)this.direction * 0.8f;
				this.ai[0] += 1f;
				if (this.ai[0] >= 30f)
				{
					if (this.ai[0] < 100f)
					{
						this.velocity *= 1.06f;
					}
					else
					{
						this.ai[0] = 200f;
					}
				}
				for (int num254 = 0; num254 < 2; num254++)
				{
					Vector2 vector49 = new Vector2(this.position.X, this.position.Y);
					int num255 = this.width;
					int num256 = this.height;
					int num257 = 27;
					float speedX30 = 0f;
					float speedY30 = 0f;
					int num258 = 100;
					Color newColor = default(Color);
					int num259 = Dust.NewDust(vector49, num255, num256, num257, speedX30, speedY30, num258, newColor, 1f);
					Main.dust[num259].noGravity = true;
				}
			}
			else if (this.aiStyle == 19)
			{
				this.direction = Main.player[this.owner].direction;
				Main.player[this.owner].heldProj = this.whoAmI;
				Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
				this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
				this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
				if (this.type == 46)
				{
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 3f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 1.6f;
					}
					else
					{
						this.ai[0] += 1.4f;
					}
				}
				else if (this.type == 105)
				{
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 3f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 2.4f;
					}
					else
					{
						this.ai[0] += 2.1f;
					}
				}
				else if (this.type == 47)
				{
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 4f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 1.2f;
					}
					else
					{
						this.ai[0] += 0.9f;
					}
				}
				else if (this.type == 49)
				{
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 4f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 1.1f;
					}
					else
					{
						this.ai[0] += 0.85f;
					}
				}
				else if (this.type == 64)
				{
					this.spriteDirection = -this.direction;
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 3f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 1.9f;
					}
					else
					{
						this.ai[0] += 1.7f;
					}
				}
				else if (this.type == 66 || this.type == 97)
				{
					this.spriteDirection = -this.direction;
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 3f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 2.1f;
					}
					else
					{
						this.ai[0] += 1.9f;
					}
				}
				else if (this.type == 97)
				{
					this.spriteDirection = -this.direction;
					if (this.ai[0] == 0f)
					{
						this.ai[0] = 3f;
						this.netUpdate = true;
					}
					if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
					{
						this.ai[0] -= 1.6f;
					}
					else
					{
						this.ai[0] += 1.4f;
					}
				}
				this.position += this.velocity * this.ai[0];
				if (Main.player[this.owner].itemAnimation == 0)
				{
					this.Kill();
				}
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 2.355f;
				if (this.spriteDirection == -1)
				{
					this.rotation -= 1.57f;
				}
				if (this.type == 46)
				{
					if (Main.rand.Next(5) == 0)
					{
						Vector2 vector50 = this.position;
						int num260 = this.width;
						int num261 = this.height;
						int num262 = 14;
						float speedX31 = 0f;
						float speedY31 = 0f;
						int num263 = 150;
						Dust.NewDust(vector50, num260, num261, num262, speedX31, speedY31, num263, default(Color), 1.4f);
					}
					Vector2 vector51 = this.position;
					int num264 = this.width;
					int num265 = this.height;
					int num266 = 27;
					float speedX32 = this.velocity.X * 0.2f + (float)(this.direction * 3);
					float speedY32 = this.velocity.Y * 0.2f;
					int num267 = 100;
					int num268 = Dust.NewDust(vector51, num264, num265, num266, speedX32, speedY32, num267, default(Color), 1.2f);
					Main.dust[num268].noGravity = true;
					Dust dust24 = Main.dust[num268];
					dust24.velocity.X = dust24.velocity.X / 2f;
					Dust dust25 = Main.dust[num268];
					dust25.velocity.Y = dust25.velocity.Y / 2f;
					Vector2 vector52 = this.position - this.velocity * 2f;
					int num269 = this.width;
					int num270 = this.height;
					int num271 = 27;
					float speedX33 = 0f;
					float speedY33 = 0f;
					int num272 = 150;
					num268 = Dust.NewDust(vector52, num269, num270, num271, speedX33, speedY33, num272, default(Color), 1.4f);
					Dust dust26 = Main.dust[num268];
					dust26.velocity.X = dust26.velocity.X / 5f;
					Dust dust27 = Main.dust[num268];
					dust27.velocity.Y = dust27.velocity.Y / 5f;
				}
				else if (this.type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						Vector2 vector53 = new Vector2(this.position.X, this.position.Y);
						int num273 = this.width;
						int num274 = this.height;
						int num275 = 57;
						float speedX34 = this.velocity.X * 0.2f;
						float speedY34 = this.velocity.Y * 0.2f;
						int num276 = 200;
						Color newColor = default(Color);
						int num277 = Dust.NewDust(vector53, num273, num274, num275, speedX34, speedY34, num276, newColor, 1.2f);
						Dust dust28 = Main.dust[num277];
						dust28.velocity += this.velocity * 0.3f;
						Dust dust29 = Main.dust[num277];
						dust29.velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						Vector2 vector54 = new Vector2(this.position.X, this.position.Y);
						int num278 = this.width;
						int num279 = this.height;
						int num280 = 43;
						float speedX35 = 0f;
						float speedY35 = 0f;
						int num281 = 254;
						Color newColor = default(Color);
						int num282 = Dust.NewDust(vector54, num278, num279, num280, speedX35, speedY35, num281, newColor, 0.3f);
						Dust dust30 = Main.dust[num282];
						dust30.velocity += this.velocity * 0.5f;
						Dust dust31 = Main.dust[num282];
						dust31.velocity *= 0.5f;
					}
				}
			}
			else if (this.aiStyle == 20)
			{
				if (this.soundDelay <= 0)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 22);
					this.soundDelay = 30;
				}
				if (Main.myPlayer == this.owner)
				{
					if (Main.player[this.owner].channel)
					{
						float num283 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
						Vector2 vector55 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
						float num284 = (float)Main.mouseX + Main.screenPosition.X - vector55.X;
						float num285 = (float)Main.mouseY + Main.screenPosition.Y - vector55.Y;
						float num286 = (float)Math.Sqrt((double)(num284 * num284 + num285 * num285));
						num286 = (float)Math.Sqrt((double)(num284 * num284 + num285 * num285));
						num286 = num283 / num286;
						num284 *= num286;
						num285 *= num286;
						if (num284 != this.velocity.X || num285 != this.velocity.Y)
						{
							this.netUpdate = true;
						}
						this.velocity.X = num284;
						this.velocity.Y = num285;
					}
					else
					{
						this.Kill();
					}
				}
				if (this.velocity.X > 0f)
				{
					Main.player[this.owner].direction = 1;
				}
				else if (this.velocity.X < 0f)
				{
					Main.player[this.owner].direction = -1;
				}
				this.spriteDirection = this.direction;
				Main.player[this.owner].direction = this.direction;
				Main.player[this.owner].heldProj = this.whoAmI;
				Main.player[this.owner].itemTime = 2;
				Main.player[this.owner].itemAnimation = 2;
				this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
				this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
				this.rotation = (float)(Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.5700000524520874);
				if (Main.player[this.owner].direction == 1)
				{
					Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
				}
				else
				{
					Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
				}
				this.velocity.X = this.velocity.X * (1f + (float)Main.rand.Next(-3, 4) * 0.01f);
				if (Main.rand.Next(6) == 0)
				{
					Vector2 vector56 = this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f;
					int num287 = this.width;
					int num288 = this.height;
					int num289 = 31;
					float speedX36 = 0f;
					float speedY36 = 0f;
					int num290 = 80;
					int num291 = Dust.NewDust(vector56, num287, num288, num289, speedX36, speedY36, num290, default(Color), 1.4f);
					Dust dust32 = Main.dust[num291];
					dust32.position.X = dust32.position.X - 4f;
					Main.dust[num291].noGravity = true;
					Dust dust33 = Main.dust[num291];
					dust33.velocity *= 0.2f;
					Main.dust[num291].velocity.Y = -(float)Main.rand.Next(7, 13) * 0.15f;
				}
			}
			else if (this.aiStyle == 21)
			{
				this.rotation = this.velocity.X * 0.1f;
				this.spriteDirection = -this.direction;
				if (Main.rand.Next(3) == 0)
				{
					Vector2 vector57 = this.position;
					int num292 = this.width;
					int num293 = this.height;
					int num294 = 27;
					float speedX37 = 0f;
					float speedY37 = 0f;
					int num295 = 80;
					int num296 = Dust.NewDust(vector57, num292, num293, num294, speedX37, speedY37, num295, default(Color), 1f);
					Main.dust[num296].noGravity = true;
					Dust dust34 = Main.dust[num296];
					dust34.velocity *= 0.2f;
				}
				if (this.ai[1] == 1f)
				{
					this.ai[1] = 0f;
					Main.harpNote = this.ai[0];
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
				}
			}
			else if (this.aiStyle == 22)
			{
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					this.alpha = 255;
				}
				if (this.ai[1] < 0f)
				{
					if (this.velocity.X > 0f)
					{
						this.rotation += 0.3f;
					}
					else
					{
						this.rotation -= 0.3f;
					}
					int num297 = (int)(this.position.X / 16f) - 1;
					int num298 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num299 = (int)(this.position.Y / 16f) - 1;
					int num300 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num297 < 0)
					{
						num297 = 0;
					}
					if (num298 > Main.maxTilesX)
					{
						num298 = Main.maxTilesX;
					}
					if (num299 < 0)
					{
						num299 = 0;
					}
					if (num300 > Main.maxTilesY)
					{
						num300 = Main.maxTilesY;
					}
					int num301 = (int)this.position.X + 4;
					int num302 = (int)this.position.Y + 4;
					for (int num303 = num297; num303 < num298; num303++)
					{
						for (int num304 = num299; num304 < num300; num304++)
						{
							if (Main.tile[num303, num304] != null && Main.tile[num303, num304].active && Main.tile[num303, num304].type != 127 && Main.tileSolid[(int)Main.tile[num303, num304].type] && !Main.tileSolidTop[(int)Main.tile[num303, num304].type])
							{
								Vector2 vector58;
								vector58.X = (float)(num303 * 16);
								vector58.Y = (float)(num304 * 16);
								if ((float)(num301 + 8) > vector58.X && (float)num301 < vector58.X + 16f && (float)(num302 + 8) > vector58.Y && (float)num302 < vector58.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					Vector2 vector59 = new Vector2(this.position.X, this.position.Y);
					int num305 = this.width;
					int num306 = this.height;
					int num307 = 67;
					float speedX38 = 0f;
					float speedY38 = 0f;
					int num308 = 0;
					Color newColor = default(Color);
					int num309 = Dust.NewDust(vector59, num305, num306, num307, speedX38, speedY38, num308, newColor, 1f);
					Main.dust[num309].noGravity = true;
					Dust dust35 = Main.dust[num309];
					dust35.velocity *= 0.3f;
				}
				else if (this.ai[0] < 0f)
				{
					if (this.ai[0] == -1f)
					{
						for (int num310 = 0; num310 < 10; num310++)
						{
							Vector2 vector60 = new Vector2(this.position.X, this.position.Y);
							int num311 = this.width;
							int num312 = this.height;
							int num313 = 67;
							float speedX39 = 0f;
							float speedY39 = 0f;
							int num314 = 0;
							Color newColor = default(Color);
							int num315 = Dust.NewDust(vector60, num311, num312, num313, speedX39, speedY39, num314, newColor, 1.1f);
							Main.dust[num315].noGravity = true;
							Dust dust36 = Main.dust[num315];
							dust36.velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						Vector2 vector61 = new Vector2(this.position.X, this.position.Y);
						int num316 = this.width;
						int num317 = this.height;
						int num318 = 67;
						float speedX40 = 0f;
						float speedY40 = 0f;
						int num319 = 100;
						Color newColor = default(Color);
						int num320 = Dust.NewDust(vector61, num316, num317, num318, speedX40, speedY40, num319, newColor, 1f);
						Dust dust37 = Main.dust[num320];
						dust37.velocity *= 0.2f;
					}
					int num321 = (int)this.position.X / 16;
					int num322 = (int)this.position.Y / 16;
					if (Main.tile[num321, num322] == null || !Main.tile[num321, num322].active)
					{
						this.Kill();
					}
					this.ai[0] -= 1f;
					if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num321, num322].active && Main.tile[num321, num322].type == 127)
					{
						WorldGen.KillTile(num321, num322, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num321, (float)num322, 0f, 0);
						}
						this.Kill();
					}
				}
				else
				{
					int num323 = (int)(this.position.X / 16f) - 1;
					int num324 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num325 = (int)(this.position.Y / 16f) - 1;
					int num326 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num323 < 0)
					{
						num323 = 0;
					}
					if (num324 > Main.maxTilesX)
					{
						num324 = Main.maxTilesX;
					}
					if (num325 < 0)
					{
						num325 = 0;
					}
					if (num326 > Main.maxTilesY)
					{
						num326 = Main.maxTilesY;
					}
					int num327 = (int)this.position.X + 4;
					int num328 = (int)this.position.Y + 4;
					for (int num329 = num323; num329 < num324; num329++)
					{
						for (int num330 = num325; num330 < num326; num330++)
						{
							if (Main.tile[num329, num330] != null && Main.tile[num329, num330].active && Main.tile[num329, num330].type != 127 && Main.tileSolid[(int)Main.tile[num329, num330].type] && !Main.tileSolidTop[(int)Main.tile[num329, num330].type])
							{
								Vector2 vector62;
								vector62.X = (float)(num329 * 16);
								vector62.Y = (float)(num330 * 16);
								if ((float)(num327 + 8) > vector62.X && (float)num327 < vector62.X + 16f && (float)(num328 + 8) > vector62.Y && (float)num328 < vector62.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					if (this.lavaWet)
					{
						this.Kill();
					}
					if (this.active)
					{
						Vector2 vector63 = new Vector2(this.position.X, this.position.Y);
						int num331 = this.width;
						int num332 = this.height;
						int num333 = 67;
						float speedX41 = 0f;
						float speedY41 = 0f;
						int num334 = 0;
						Color newColor = default(Color);
						int num335 = Dust.NewDust(vector63, num331, num332, num333, speedX41, speedY41, num334, newColor, 1f);
						Main.dust[num335].noGravity = true;
						Dust dust38 = Main.dust[num335];
						dust38.velocity *= 0.3f;
						int num336 = (int)this.ai[0];
						int num337 = (int)this.ai[1];
						if (this.velocity.X > 0f)
						{
							this.rotation += 0.3f;
						}
						else
						{
							this.rotation -= 0.3f;
						}
						if (Main.myPlayer == this.owner)
						{
							int num338 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
							int num339 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
							bool flag2 = false;
							if (num338 == num336 && num339 == num337)
							{
								flag2 = true;
							}
							if (((this.velocity.X <= 0f && num338 <= num336) || (this.velocity.X >= 0f && num338 >= num336)) && ((this.velocity.Y <= 0f && num339 <= num337) || (this.velocity.Y >= 0f && num339 >= num337)))
							{
								flag2 = true;
							}
							if (flag2)
							{
								if (WorldGen.PlaceTile(num336, num337, 127, false, false, this.owner, 0))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
									}
									this.damage = 0;
									this.ai[0] = -1f;
									this.velocity *= 0f;
									this.alpha = 255;
									this.position.X = (float)(num336 * 16);
									this.position.Y = (float)(num337 * 16);
									this.netUpdate = true;
								}
								else
								{
									this.ai[1] = -1f;
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 23)
			{
				if (this.timeLeft > 60)
				{
					this.timeLeft = 60;
				}
				if (this.ai[0] > 7f)
				{
					float num340 = 1f;
					if (this.ai[0] == 8f)
					{
						num340 = 0.25f;
					}
					else if (this.ai[0] == 9f)
					{
						num340 = 0.5f;
					}
					else if (this.ai[0] == 10f)
					{
						num340 = 0.75f;
					}
					this.ai[0] += 1f;
					int num341 = 6;
					if (this.type == 101)
					{
						num341 = 75;
					}
					if (num341 == 6 || Main.rand.Next(2) == 0)
					{
						for (int num342 = 0; num342 < 1; num342++)
						{
							Vector2 vector64 = new Vector2(this.position.X, this.position.Y);
							int num343 = this.width;
							int num344 = this.height;
							int num345 = num341;
							float speedX42 = this.velocity.X * 0.2f;
							float speedY42 = this.velocity.Y * 0.2f;
							int num346 = 100;
							Color newColor = default(Color);
							int num347 = Dust.NewDust(vector64, num343, num344, num345, speedX42, speedY42, num346, newColor, 1f);
							if (Main.rand.Next(3) != 0 || (num341 == 75 && Main.rand.Next(3) == 0))
							{
								Main.dust[num347].noGravity = true;
								Main.dust[num347].scale *= 3f;
								Dust dust39 = Main.dust[num347];
								dust39.velocity.X = dust39.velocity.X * 2f;
								Dust dust40 = Main.dust[num347];
								dust40.velocity.Y = dust40.velocity.Y * 2f;
							}
							Main.dust[num347].scale *= 1.5f;
							Dust dust41 = Main.dust[num347];
							dust41.velocity.X = dust41.velocity.X * 1.2f;
							Dust dust42 = Main.dust[num347];
							dust42.velocity.Y = dust42.velocity.Y * 1.2f;
							Main.dust[num347].scale *= num340;
							if (num341 == 75)
							{
								Dust dust43 = Main.dust[num347];
								dust43.velocity += this.velocity;
								if (!Main.dust[num347].noGravity)
								{
									Dust dust44 = Main.dust[num347];
									dust44.velocity *= 0.5f;
								}
							}
						}
					}
				}
				else
				{
					this.ai[0] += 1f;
				}
				this.rotation += 0.3f * (float)this.direction;
			}
			else if (this.aiStyle == 24)
			{
				this.light = this.scale * 0.5f;
				this.rotation += this.velocity.X * 0.2f;
				this.ai[1] += 1f;
				if (this.type == 94)
				{
					if (Main.rand.Next(4) == 0)
					{
						Vector2 vector65 = new Vector2(this.position.X, this.position.Y);
						int num348 = this.width;
						int num349 = this.height;
						int num350 = 70;
						float speedX43 = 0f;
						float speedY43 = 0f;
						int num351 = 0;
						Color newColor = default(Color);
						int num352 = Dust.NewDust(vector65, num348, num349, num350, speedX43, speedY43, num351, newColor, 1f);
						Main.dust[num352].noGravity = true;
						Dust dust45 = Main.dust[num352];
						dust45.velocity *= 0.5f;
						Main.dust[num352].scale *= 0.9f;
					}
					this.velocity *= 0.985f;
					if (this.ai[1] > 130f)
					{
						this.scale -= 0.05f;
						if ((double)this.scale <= 0.2)
						{
							this.scale = 0.2f;
							this.Kill();
						}
					}
				}
				else
				{
					this.velocity *= 0.96f;
					if (this.ai[1] > 15f)
					{
						this.scale -= 0.05f;
						if ((double)this.scale <= 0.2)
						{
							this.scale = 0.2f;
							this.Kill();
						}
					}
				}
			}
			else if (this.aiStyle == 25)
			{
				if (this.ai[0] != 0f && this.velocity.Y <= 0f && this.velocity.X == 0f)
				{
					float num353 = 0.5f;
					int i2 = (int)((this.position.X - 8f) / 16f);
					int num354 = (int)(this.position.Y / 16f);
					bool flag3 = false;
					bool flag4 = false;
					if (WorldGen.SolidTile(i2, num354) || WorldGen.SolidTile(i2, num354 + 1))
					{
						flag3 = true;
					}
					i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
					if (WorldGen.SolidTile(i2, num354) || WorldGen.SolidTile(i2, num354 + 1))
					{
						flag4 = true;
					}
					if (flag3)
					{
						this.velocity.X = num353;
					}
					else if (flag4)
					{
						this.velocity.X = -num353;
					}
					else
					{
						i2 = (int)((this.position.X - 8f - 16f) / 16f);
						num354 = (int)(this.position.Y / 16f);
						flag3 = false;
						flag4 = false;
						if (WorldGen.SolidTile(i2, num354) || WorldGen.SolidTile(i2, num354 + 1))
						{
							flag3 = true;
						}
						i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
						if (WorldGen.SolidTile(i2, num354) || WorldGen.SolidTile(i2, num354 + 1))
						{
							flag4 = true;
						}
						if (flag3)
						{
							this.velocity.X = num353;
						}
						else if (flag4)
						{
							this.velocity.X = -num353;
						}
						else
						{
							i2 = (int)((this.position.X + 4f) / 16f);
							num354 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num354) || WorldGen.SolidTile(i2, num354 + 1))
							{
								flag3 = true;
							}
							if (!flag3)
							{
								this.velocity.X = num353;
							}
							else
							{
								this.velocity.X = -num353;
							}
						}
					}
				}
				this.rotation += this.velocity.X * 0.06f;
				this.ai[0] = 1f;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
				if (this.velocity.Y <= 6f)
				{
					if (this.velocity.X > 0f && this.velocity.X < 7f)
					{
						this.velocity.X = this.velocity.X + 0.05f;
					}
					if (this.velocity.X < 0f && this.velocity.X > -7f)
					{
						this.velocity.X = this.velocity.X - 0.05f;
					}
				}
				this.velocity.Y = this.velocity.Y + 0.3f;
			}
		}

		public void Kill()
		{
			if (this.active)
			{
				this.timeLeft = 0;
				if (this.type == 1 || this.type == 81 || this.type == 98)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int i = 0; i < 10; i++)
					{
						Vector2 vector = new Vector2(this.position.X, this.position.Y);
						int num = this.width;
						int num2 = this.height;
						int num3 = 7;
						float speedX = 0f;
						float speedY = 0f;
						int num4 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector, num, num2, num3, speedX, speedY, num4, newColor, 1f);
					}
				}
				else if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int j = 0; j < 10; j++)
					{
						Vector2 vector2 = this.position;
						int num5 = this.width;
						int num6 = this.height;
						int num7 = 57;
						float speedX2 = 0f;
						float speedY2 = 0f;
						int num8 = 100;
						int num9 = Dust.NewDust(vector2, num5, num6, num7, speedX2, speedY2, num8, default(Color), 0.5f);
						Dust dust = Main.dust[num9];
						dust.velocity.X = dust.velocity.X * 2f;
						Dust dust2 = Main.dust[num9];
						dust2.velocity.Y = dust2.velocity.Y * 2f;
					}
				}
				else if (this.type == 99)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int k = 0; k < 30; k++)
					{
						Vector2 vector3 = this.position;
						int num10 = this.width;
						int num11 = this.height;
						int num12 = 1;
						float speedX3 = 0f;
						float speedY3 = 0f;
						int num13 = 0;
						int num14 = Dust.NewDust(vector3, num10, num11, num12, speedX3, speedY3, num13, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num14].scale *= 1.4f;
						}
						this.velocity *= 1.9f;
					}
				}
				else if (this.type == 91 || this.type == 92)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int l = 0; l < 10; l++)
					{
						Vector2 vector4 = this.position;
						int num15 = this.width;
						int num16 = this.height;
						int num17 = 58;
						float speedX4 = this.velocity.X * 0.1f;
						float speedY4 = this.velocity.Y * 0.1f;
						int num18 = 150;
						Dust.NewDust(vector4, num15, num16, num17, speedX4, speedY4, num18, default(Color), 1.2f);
					}
					for (int m = 0; m < 3; m++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 500)
					{
						for (int n = 0; n < 10; n++)
						{
							Vector2 vector5 = this.position;
							int num19 = this.width;
							int num20 = this.height;
							int num21 = 57;
							float speedX5 = this.velocity.X * 0.1f;
							float speedY5 = this.velocity.Y * 0.1f;
							int num22 = 150;
							Dust.NewDust(vector5, num19, num20, num21, speedX5, speedY5, num22, default(Color), 1.2f);
						}
						for (int num23 = 0; num23 < 3; num23++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
					if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
					{
						float x = this.position.X + (float)Main.rand.Next(-400, 400);
						float y = this.position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector6 = new Vector2(x, y);
						float num24 = this.position.X + (float)(this.width / 2) - vector6.X;
						float num25 = this.position.Y + (float)(this.height / 2) - vector6.Y;
						int num26 = 22;
						float num27 = (float)Math.Sqrt((double)(num24 * num24 + num25 * num25));
						num27 = (float)num26 / num27;
						num24 *= num27;
						num25 *= num27;
						int num28 = this.damage;
						if (this.type == 91)
						{
							num28 = (int)((float)num28 * 0.5f);
						}
						int num29 = Projectile.NewProjectile(x, y, num24, num25, 92, num28, this.knockBack, this.owner);
						if (this.type == 91)
						{
							Main.projectile[num29].ai[1] = this.position.Y;
							Main.projectile[num29].ai[0] = 1f;
						}
						else
						{
							Main.projectile[num29].ai[1] = this.position.Y;
						}
					}
				}
				else if (this.type == 89)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num30 = 0; num30 < 5; num30++)
					{
						Vector2 vector7 = new Vector2(this.position.X, this.position.Y);
						int num31 = this.width;
						int num32 = this.height;
						int num33 = 68;
						float speedX6 = 0f;
						float speedY6 = 0f;
						int num34 = 0;
						Color newColor = default(Color);
						int num35 = Dust.NewDust(vector7, num31, num32, num33, speedX6, speedY6, num34, newColor, 1f);
						Main.dust[num35].noGravity = true;
						Dust dust3 = Main.dust[num35];
						dust3.velocity *= 1.5f;
						Main.dust[num35].scale *= 0.9f;
					}
					if (this.type == 89 && this.owner == Main.myPlayer)
					{
						for (int num36 = 0; num36 < 3; num36++)
						{
							float num37 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							float num38 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							Projectile.NewProjectile(this.position.X + num37, this.position.Y + num38, num37, num38, 90, (int)((double)this.damage * 0.6), 0f, this.owner);
						}
					}
				}
				else if (this.type == 80)
				{
					if (this.ai[0] >= 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
						for (int num39 = 0; num39 < 10; num39++)
						{
							Vector2 vector8 = new Vector2(this.position.X, this.position.Y);
							int num40 = this.width;
							int num41 = this.height;
							int num42 = 67;
							float speedX7 = 0f;
							float speedY7 = 0f;
							int num43 = 0;
							Color newColor = default(Color);
							Dust.NewDust(vector8, num40, num41, num42, speedX7, speedY7, num43, newColor, 1f);
						}
					}
					int num44 = (int)this.position.X / 16;
					int num45 = (int)this.position.Y / 16;
					if (Main.tile[num44, num45] == null)
					{
						Main.tile[num44, num45] = new Tile();
					}
					if (Main.tile[num44, num45].type == 127 && Main.tile[num44, num45].active)
					{
						WorldGen.KillTile(num44, num45, false, false, false);
					}
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					for (int num46 = 0; num46 < 5; num46++)
					{
						Vector2 vector9 = this.position;
						int num47 = this.width;
						int num48 = this.height;
						int num49 = 27;
						float speedX8 = 0f;
						float speedY8 = 0f;
						int num50 = 80;
						int num51 = Dust.NewDust(vector9, num47, num48, num49, speedX8, speedY8, num50, default(Color), 1.5f);
						Main.dust[num51].noGravity = true;
					}
				}
				else if (this.type == 55)
				{
					for (int num52 = 0; num52 < 5; num52++)
					{
						Vector2 vector10 = new Vector2(this.position.X, this.position.Y);
						int num53 = this.width;
						int num54 = this.height;
						int num55 = 18;
						float speedX9 = 0f;
						float speedY9 = 0f;
						int num56 = 0;
						Color newColor = default(Color);
						int num57 = Dust.NewDust(vector10, num53, num54, num55, speedX9, speedY9, num56, newColor, 1.5f);
						Main.dust[num57].noGravity = true;
					}
				}
				else if (this.type == 51)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num58 = 0; num58 < 5; num58++)
					{
						Vector2 vector11 = new Vector2(this.position.X, this.position.Y);
						int num59 = this.width;
						int num60 = this.height;
						int num61 = 0;
						float speedX10 = 0f;
						float speedY10 = 0f;
						int num62 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector11, num59, num60, num61, speedX10, speedY10, num62, newColor, 0.7f);
					}
				}
				else if (this.type == 2 || this.type == 82)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num63 = 0; num63 < 20; num63++)
					{
						Vector2 vector12 = new Vector2(this.position.X, this.position.Y);
						int num64 = this.width;
						int num65 = this.height;
						int num66 = 6;
						float speedX11 = 0f;
						float speedY11 = 0f;
						int num67 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector12, num64, num65, num66, speedX11, speedY11, num67, newColor, 1f);
					}
				}
				else if (this.type == 103)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num68 = 0; num68 < 20; num68++)
					{
						Vector2 vector13 = new Vector2(this.position.X, this.position.Y);
						int num69 = this.width;
						int num70 = this.height;
						int num71 = 75;
						float speedX12 = 0f;
						float speedY12 = 0f;
						int num72 = 100;
						Color newColor = default(Color);
						int num73 = Dust.NewDust(vector13, num69, num70, num71, speedX12, speedY12, num72, newColor, 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num73].scale *= 2.5f;
							Main.dust[num73].noGravity = true;
							Dust dust4 = Main.dust[num73];
							dust4.velocity *= 5f;
						}
					}
				}
				else if (this.type == 3 || this.type == 48 || this.type == 54)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num74 = 0; num74 < 10; num74++)
					{
						Vector2 vector14 = new Vector2(this.position.X, this.position.Y);
						int num75 = this.width;
						int num76 = this.height;
						int num77 = 1;
						float speedX13 = this.velocity.X * 0.1f;
						float speedY13 = this.velocity.Y * 0.1f;
						int num78 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector14, num75, num76, num77, speedX13, speedY13, num78, newColor, 0.75f);
					}
				}
				else if (this.type == 4)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num79 = 0; num79 < 10; num79++)
					{
						Vector2 vector15 = new Vector2(this.position.X, this.position.Y);
						int num80 = this.width;
						int num81 = this.height;
						int num82 = 14;
						float speedX14 = 0f;
						float speedY14 = 0f;
						int num83 = 150;
						Color newColor = default(Color);
						Dust.NewDust(vector15, num80, num81, num82, speedX14, speedY14, num83, newColor, 1.1f);
					}
				}
				else if (this.type == 5)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num84 = 0; num84 < 60; num84++)
					{
						int num85 = Main.rand.Next(3);
						if (num85 == 0)
						{
							num85 = 15;
						}
						else if (num85 == 1)
						{
							num85 = 57;
						}
						else
						{
							num85 = 58;
						}
						Vector2 vector16 = this.position;
						int num86 = this.width;
						int num87 = this.height;
						int num88 = num85;
						float speedX15 = this.velocity.X * 0.5f;
						float speedY15 = this.velocity.Y * 0.5f;
						int num89 = 150;
						Dust.NewDust(vector16, num86, num87, num88, speedX15, speedY15, num89, default(Color), 1.5f);
					}
				}
				else if (this.type == 9 || this.type == 12)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num90 = 0; num90 < 10; num90++)
					{
						Vector2 vector17 = this.position;
						int num91 = this.width;
						int num92 = this.height;
						int num93 = 58;
						float speedX16 = this.velocity.X * 0.1f;
						float speedY16 = this.velocity.Y * 0.1f;
						int num94 = 150;
						Dust.NewDust(vector17, num91, num92, num93, speedX16, speedY16, num94, default(Color), 1.2f);
					}
					for (int num95 = 0; num95 < 3; num95++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 100)
					{
						for (int num96 = 0; num96 < 10; num96++)
						{
							Vector2 vector18 = this.position;
							int num97 = this.width;
							int num98 = this.height;
							int num99 = 57;
							float speedX17 = this.velocity.X * 0.1f;
							float speedY17 = this.velocity.Y * 0.1f;
							int num100 = 150;
							Dust.NewDust(vector18, num97, num98, num99, speedX17, speedY17, num100, default(Color), 1.2f);
						}
						for (int num101 = 0; num101 < 3; num101++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
				}
				else if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 100 || this.type == 110)
				{
					Collision.HitTiles(this.position, this.velocity, this.width, this.height);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
				}
				else if (this.type == 15 || this.type == 34)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num102 = 0; num102 < 20; num102++)
					{
						Vector2 vector19 = new Vector2(this.position.X, this.position.Y);
						int num103 = this.width;
						int num104 = this.height;
						int num105 = 6;
						float speedX18 = -this.velocity.X * 0.2f;
						float speedY18 = -this.velocity.Y * 0.2f;
						int num106 = 100;
						Color newColor = default(Color);
						int num107 = Dust.NewDust(vector19, num103, num104, num105, speedX18, speedY18, num106, newColor, 2f);
						Main.dust[num107].noGravity = true;
						Dust dust5 = Main.dust[num107];
						dust5.velocity *= 2f;
						Vector2 vector20 = new Vector2(this.position.X, this.position.Y);
						int num108 = this.width;
						int num109 = this.height;
						int num110 = 6;
						float speedX19 = -this.velocity.X * 0.2f;
						float speedY19 = -this.velocity.Y * 0.2f;
						int num111 = 100;
						newColor = default(Color);
						num107 = Dust.NewDust(vector20, num108, num109, num110, speedX19, speedY19, num111, newColor, 1f);
						Dust dust6 = Main.dust[num107];
						dust6.velocity *= 2f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num112 = 0; num112 < 20; num112++)
					{
						Vector2 vector21 = new Vector2(this.position.X, this.position.Y);
						int num113 = this.width;
						int num114 = this.height;
						int num115 = 75;
						float speedX20 = -this.velocity.X * 0.2f;
						float speedY20 = -this.velocity.Y * 0.2f;
						int num116 = 100;
						Color newColor = default(Color);
						int num117 = Dust.NewDust(vector21, num113, num114, num115, speedX20, speedY20, num116, newColor, 2f * this.scale);
						Main.dust[num117].noGravity = true;
						Dust dust7 = Main.dust[num117];
						dust7.velocity *= 2f;
						Vector2 vector22 = new Vector2(this.position.X, this.position.Y);
						int num118 = this.width;
						int num119 = this.height;
						int num120 = 75;
						float speedX21 = -this.velocity.X * 0.2f;
						float speedY21 = -this.velocity.Y * 0.2f;
						int num121 = 100;
						newColor = default(Color);
						num117 = Dust.NewDust(vector22, num118, num119, num120, speedX21, speedY21, num121, newColor, 1f * this.scale);
						Dust dust8 = Main.dust[num117];
						dust8.velocity *= 2f;
					}
				}
				else if (this.type == 79)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num122 = 0; num122 < 20; num122++)
					{
						int num123 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[num123].noGravity = true;
						Dust dust9 = Main.dust[num123];
						dust9.velocity *= 4f;
					}
				}
				else if (this.type == 16)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num124 = 0; num124 < 20; num124++)
					{
						Vector2 vector23 = new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
						int num125 = this.width;
						int num126 = this.height;
						int num127 = 15;
						float speedX22 = 0f;
						float speedY22 = 0f;
						int num128 = 100;
						Color newColor = default(Color);
						int num129 = Dust.NewDust(vector23, num125, num126, num127, speedX22, speedY22, num128, newColor, 2f);
						Main.dust[num129].noGravity = true;
						Dust dust10 = Main.dust[num129];
						dust10.velocity *= 2f;
						Vector2 vector24 = new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
						int num130 = this.width;
						int num131 = this.height;
						int num132 = 15;
						float speedX23 = 0f;
						float speedY23 = 0f;
						int num133 = 100;
						newColor = default(Color);
						num129 = Dust.NewDust(vector24, num130, num131, num132, speedX23, speedY23, num133, newColor, 1f);
					}
				}
				else if (this.type == 17)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num134 = 0; num134 < 5; num134++)
					{
						Vector2 vector25 = new Vector2(this.position.X, this.position.Y);
						int num135 = this.width;
						int num136 = this.height;
						int num137 = 0;
						float speedX24 = 0f;
						float speedY24 = 0f;
						int num138 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector25, num135, num136, num137, speedX24, speedY24, num138, newColor, 1f);
					}
				}
				else if (this.type == 31 || this.type == 42)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num139 = 0; num139 < 5; num139++)
					{
						Vector2 vector26 = new Vector2(this.position.X, this.position.Y);
						int num140 = this.width;
						int num141 = this.height;
						int num142 = 32;
						float speedX25 = 0f;
						float speedY25 = 0f;
						int num143 = 0;
						Color newColor = default(Color);
						int num144 = Dust.NewDust(vector26, num140, num141, num142, speedX25, speedY25, num143, newColor, 1f);
						Dust dust11 = Main.dust[num144];
						dust11.velocity *= 0.6f;
					}
				}
				else if (this.type == 109)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num145 = 0; num145 < 5; num145++)
					{
						Vector2 vector27 = new Vector2(this.position.X, this.position.Y);
						int num146 = this.width;
						int num147 = this.height;
						int num148 = 51;
						float speedX26 = 0f;
						float speedY26 = 0f;
						int num149 = 0;
						Color newColor = default(Color);
						int num150 = Dust.NewDust(vector27, num146, num147, num148, speedX26, speedY26, num149, newColor, 0.6f);
						Dust dust12 = Main.dust[num150];
						dust12.velocity *= 0.6f;
					}
				}
				else if (this.type == 39)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num151 = 0; num151 < 5; num151++)
					{
						Vector2 vector28 = new Vector2(this.position.X, this.position.Y);
						int num152 = this.width;
						int num153 = this.height;
						int num154 = 38;
						float speedX27 = 0f;
						float speedY27 = 0f;
						int num155 = 0;
						Color newColor = default(Color);
						int num156 = Dust.NewDust(vector28, num152, num153, num154, speedX27, speedY27, num155, newColor, 1f);
						Dust dust13 = Main.dust[num156];
						dust13.velocity *= 0.6f;
					}
				}
				else if (this.type == 71)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num157 = 0; num157 < 5; num157++)
					{
						Vector2 vector29 = new Vector2(this.position.X, this.position.Y);
						int num158 = this.width;
						int num159 = this.height;
						int num160 = 53;
						float speedX28 = 0f;
						float speedY28 = 0f;
						int num161 = 0;
						Color newColor = default(Color);
						int num162 = Dust.NewDust(vector29, num158, num159, num160, speedX28, speedY28, num161, newColor, 1f);
						Dust dust14 = Main.dust[num162];
						dust14.velocity *= 0.6f;
					}
				}
				else if (this.type == 40)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num163 = 0; num163 < 5; num163++)
					{
						Vector2 vector30 = new Vector2(this.position.X, this.position.Y);
						int num164 = this.width;
						int num165 = this.height;
						int num166 = 36;
						float speedX29 = 0f;
						float speedY29 = 0f;
						int num167 = 0;
						Color newColor = default(Color);
						int num168 = Dust.NewDust(vector30, num164, num165, num166, speedX29, speedY29, num167, newColor, 1f);
						Dust dust15 = Main.dust[num168];
						dust15.velocity *= 0.6f;
					}
				}
				else if (this.type == 21)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num169 = 0; num169 < 10; num169++)
					{
						Vector2 vector31 = new Vector2(this.position.X, this.position.Y);
						int num170 = this.width;
						int num171 = this.height;
						int num172 = 26;
						float speedX30 = 0f;
						float speedY30 = 0f;
						int num173 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector31, num170, num171, num172, speedX30, speedY30, num173, newColor, 0.8f);
					}
				}
				else if (this.type == 24)
				{
					for (int num174 = 0; num174 < 10; num174++)
					{
						Vector2 vector32 = new Vector2(this.position.X, this.position.Y);
						int num175 = this.width;
						int num176 = this.height;
						int num177 = 1;
						float speedX31 = this.velocity.X * 0.1f;
						float speedY31 = this.velocity.Y * 0.1f;
						int num178 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector32, num175, num176, num177, speedX31, speedY31, num178, newColor, 0.75f);
					}
				}
				else if (this.type == 27)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num179 = 0; num179 < 30; num179++)
					{
						Vector2 vector33 = new Vector2(this.position.X, this.position.Y);
						int num180 = this.width;
						int num181 = this.height;
						int num182 = 29;
						float speedX32 = this.velocity.X * 0.1f;
						float speedY32 = this.velocity.Y * 0.1f;
						int num183 = 100;
						Color newColor = default(Color);
						int num184 = Dust.NewDust(vector33, num180, num181, num182, speedX32, speedY32, num183, newColor, 3f);
						Main.dust[num184].noGravity = true;
						Vector2 vector34 = new Vector2(this.position.X, this.position.Y);
						int num185 = this.width;
						int num186 = this.height;
						int num187 = 29;
						float speedX33 = this.velocity.X * 0.1f;
						float speedY33 = this.velocity.Y * 0.1f;
						int num188 = 100;
						newColor = default(Color);
						Dust.NewDust(vector34, num185, num186, num187, speedX33, speedY33, num188, newColor, 2f);
					}
				}
				else if (this.type == 38)
				{
					for (int num189 = 0; num189 < 10; num189++)
					{
						Vector2 vector35 = new Vector2(this.position.X, this.position.Y);
						int num190 = this.width;
						int num191 = this.height;
						int num192 = 42;
						float speedX34 = this.velocity.X * 0.1f;
						float speedY34 = this.velocity.Y * 0.1f;
						int num193 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector35, num190, num191, num192, speedX34, speedY34, num193, newColor, 1f);
					}
				}
				else if (this.type == 44 || this.type == 45)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num194 = 0; num194 < 30; num194++)
					{
						Vector2 vector36 = new Vector2(this.position.X, this.position.Y);
						int num195 = this.width;
						int num196 = this.height;
						int num197 = 27;
						float x2 = this.velocity.X;
						float y2 = this.velocity.Y;
						int num198 = 100;
						Color newColor = default(Color);
						int num199 = Dust.NewDust(vector36, num195, num196, num197, x2, y2, num198, newColor, 1.7f);
						Main.dust[num199].noGravity = true;
						Vector2 vector37 = new Vector2(this.position.X, this.position.Y);
						int num200 = this.width;
						int num201 = this.height;
						int num202 = 27;
						float x3 = this.velocity.X;
						float y3 = this.velocity.Y;
						int num203 = 100;
						newColor = default(Color);
						Dust.NewDust(vector37, num200, num201, num202, x3, y3, num203, newColor, 1f);
					}
				}
				else if (this.type == 41)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num204 = 0; num204 < 10; num204++)
					{
						Vector2 vector38 = new Vector2(this.position.X, this.position.Y);
						int num205 = this.width;
						int num206 = this.height;
						int num207 = 31;
						float speedX35 = 0f;
						float speedY35 = 0f;
						int num208 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector38, num205, num206, num207, speedX35, speedY35, num208, newColor, 1.5f);
					}
					for (int num209 = 0; num209 < 5; num209++)
					{
						Vector2 vector39 = new Vector2(this.position.X, this.position.Y);
						int num210 = this.width;
						int num211 = this.height;
						int num212 = 6;
						float speedX36 = 0f;
						float speedY36 = 0f;
						int num213 = 100;
						Color newColor = default(Color);
						int num214 = Dust.NewDust(vector39, num210, num211, num212, speedX36, speedY36, num213, newColor, 2.5f);
						Main.dust[num214].noGravity = true;
						Dust dust16 = Main.dust[num214];
						dust16.velocity *= 3f;
						Vector2 vector40 = new Vector2(this.position.X, this.position.Y);
						int num215 = this.width;
						int num216 = this.height;
						int num217 = 6;
						float speedX37 = 0f;
						float speedY37 = 0f;
						int num218 = 100;
						newColor = default(Color);
						num214 = Dust.NewDust(vector40, num215, num216, num217, speedX37, speedY37, num218, newColor, 1.5f);
						Dust dust17 = Main.dust[num214];
						dust17.velocity *= 2f;
					}
					Vector2 vector41 = new Vector2(this.position.X, this.position.Y);
					Vector2 vector42 = default(Vector2);
					int num219 = Gore.NewGore(vector41, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore = Main.gore[num219];
					gore.velocity *= 0.4f;
					Gore gore2 = Main.gore[num219];
					gore2.velocity.X = gore2.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore gore3 = Main.gore[num219];
					gore3.velocity.Y = gore3.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					Vector2 vector43 = new Vector2(this.position.X, this.position.Y);
					vector42 = default(Vector2);
					num219 = Gore.NewGore(vector43, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore4 = Main.gore[num219];
					gore4.velocity *= 0.4f;
					Gore gore5 = Main.gore[num219];
					gore5.velocity.X = gore5.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore gore6 = Main.gore[num219];
					gore6.velocity.Y = gore6.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					if (this.owner == Main.myPlayer)
					{
						this.penetrate = -1;
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 64;
						this.height = 64;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num220 = 0; num220 < 20; num220++)
					{
						Vector2 vector44 = new Vector2(this.position.X, this.position.Y);
						int num221 = this.width;
						int num222 = this.height;
						int num223 = 31;
						float speedX38 = 0f;
						float speedY38 = 0f;
						int num224 = 100;
						Color newColor = default(Color);
						int num225 = Dust.NewDust(vector44, num221, num222, num223, speedX38, speedY38, num224, newColor, 1.5f);
						Dust dust18 = Main.dust[num225];
						dust18.velocity *= 1.4f;
					}
					for (int num226 = 0; num226 < 10; num226++)
					{
						Vector2 vector45 = new Vector2(this.position.X, this.position.Y);
						int num227 = this.width;
						int num228 = this.height;
						int num229 = 6;
						float speedX39 = 0f;
						float speedY39 = 0f;
						int num230 = 100;
						Color newColor = default(Color);
						int num231 = Dust.NewDust(vector45, num227, num228, num229, speedX39, speedY39, num230, newColor, 2.5f);
						Main.dust[num231].noGravity = true;
						Dust dust19 = Main.dust[num231];
						dust19.velocity *= 5f;
						Vector2 vector46 = new Vector2(this.position.X, this.position.Y);
						int num232 = this.width;
						int num233 = this.height;
						int num234 = 6;
						float speedX40 = 0f;
						float speedY40 = 0f;
						int num235 = 100;
						newColor = default(Color);
						num231 = Dust.NewDust(vector46, num232, num233, num234, speedX40, speedY40, num235, newColor, 1.5f);
						Dust dust20 = Main.dust[num231];
						dust20.velocity *= 3f;
					}
					Vector2 vector47 = new Vector2(this.position.X, this.position.Y);
					Vector2 vector42 = default(Vector2);
					int num236 = Gore.NewGore(vector47, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore7 = Main.gore[num236];
					gore7.velocity *= 0.4f;
					Gore gore8 = Main.gore[num236];
					gore8.velocity.X = gore8.velocity.X + 1f;
					Gore gore9 = Main.gore[num236];
					gore9.velocity.Y = gore9.velocity.Y + 1f;
					Vector2 vector48 = new Vector2(this.position.X, this.position.Y);
					vector42 = default(Vector2);
					num236 = Gore.NewGore(vector48, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore10 = Main.gore[num236];
					gore10.velocity *= 0.4f;
					Gore gore11 = Main.gore[num236];
					gore11.velocity.X = gore11.velocity.X - 1f;
					Gore gore12 = Main.gore[num236];
					gore12.velocity.Y = gore12.velocity.Y + 1f;
					Vector2 vector49 = new Vector2(this.position.X, this.position.Y);
					vector42 = default(Vector2);
					num236 = Gore.NewGore(vector49, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore13 = Main.gore[num236];
					gore13.velocity *= 0.4f;
					Gore gore14 = Main.gore[num236];
					gore14.velocity.X = gore14.velocity.X + 1f;
					Gore gore15 = Main.gore[num236];
					gore15.velocity.Y = gore15.velocity.Y - 1f;
					Vector2 vector50 = new Vector2(this.position.X, this.position.Y);
					vector42 = default(Vector2);
					num236 = Gore.NewGore(vector50, vector42, Main.rand.Next(61, 64), 1f);
					Gore gore16 = Main.gore[num236];
					gore16.velocity *= 0.4f;
					Gore gore17 = Main.gore[num236];
					gore17.velocity.X = gore17.velocity.X - 1f;
					Gore gore18 = Main.gore[num236];
					gore18.velocity.Y = gore18.velocity.Y - 1f;
				}
				else if (this.type == 29 || this.type == 108)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					if (this.type == 29)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 200;
						this.height = 200;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
					}
					for (int num237 = 0; num237 < 50; num237++)
					{
						Vector2 vector51 = new Vector2(this.position.X, this.position.Y);
						int num238 = this.width;
						int num239 = this.height;
						int num240 = 31;
						float speedX41 = 0f;
						float speedY41 = 0f;
						int num241 = 100;
						Color newColor = default(Color);
						int num242 = Dust.NewDust(vector51, num238, num239, num240, speedX41, speedY41, num241, newColor, 2f);
						Dust dust21 = Main.dust[num242];
						dust21.velocity *= 1.4f;
					}
					for (int num243 = 0; num243 < 80; num243++)
					{
						Vector2 vector52 = new Vector2(this.position.X, this.position.Y);
						int num244 = this.width;
						int num245 = this.height;
						int num246 = 6;
						float speedX42 = 0f;
						float speedY42 = 0f;
						int num247 = 100;
						Color newColor = default(Color);
						int num248 = Dust.NewDust(vector52, num244, num245, num246, speedX42, speedY42, num247, newColor, 3f);
						Main.dust[num248].noGravity = true;
						Dust dust22 = Main.dust[num248];
						dust22.velocity *= 5f;
						Vector2 vector53 = new Vector2(this.position.X, this.position.Y);
						int num249 = this.width;
						int num250 = this.height;
						int num251 = 6;
						float speedX43 = 0f;
						float speedY43 = 0f;
						int num252 = 100;
						newColor = default(Color);
						num248 = Dust.NewDust(vector53, num249, num250, num251, speedX43, speedY43, num252, newColor, 2f);
						Dust dust23 = Main.dust[num248];
						dust23.velocity *= 3f;
					}
					for (int num253 = 0; num253 < 2; num253++)
					{
						Vector2 vector54 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
						Vector2 vector42 = default(Vector2);
						int num254 = Gore.NewGore(vector54, vector42, Main.rand.Next(61, 64), 1f);
						Main.gore[num254].scale = 1.5f;
						Gore gore19 = Main.gore[num254];
						gore19.velocity.X = gore19.velocity.X + 1.5f;
						Gore gore20 = Main.gore[num254];
						gore20.velocity.Y = gore20.velocity.Y + 1.5f;
						Vector2 vector55 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
						vector42 = default(Vector2);
						num254 = Gore.NewGore(vector55, vector42, Main.rand.Next(61, 64), 1f);
						Main.gore[num254].scale = 1.5f;
						Gore gore21 = Main.gore[num254];
						gore21.velocity.X = gore21.velocity.X - 1.5f;
						Gore gore22 = Main.gore[num254];
						gore22.velocity.Y = gore22.velocity.Y + 1.5f;
						Vector2 vector56 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
						vector42 = default(Vector2);
						num254 = Gore.NewGore(vector56, vector42, Main.rand.Next(61, 64), 1f);
						Main.gore[num254].scale = 1.5f;
						Gore gore23 = Main.gore[num254];
						gore23.velocity.X = gore23.velocity.X + 1.5f;
						Gore gore24 = Main.gore[num254];
						gore24.velocity.Y = gore24.velocity.Y - 1.5f;
						Vector2 vector57 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
						vector42 = default(Vector2);
						num254 = Gore.NewGore(vector57, vector42, Main.rand.Next(61, 64), 1f);
						Main.gore[num254].scale = 1.5f;
						Gore gore25 = Main.gore[num254];
						gore25.velocity.X = gore25.velocity.X - 1.5f;
						Gore gore26 = Main.gore[num254];
						gore26.velocity.Y = gore26.velocity.Y - 1.5f;
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 10;
					this.height = 10;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
				}
				else if (this.type == 69)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num255 = 0; num255 < 5; num255++)
					{
						Vector2 vector58 = new Vector2(this.position.X, this.position.Y);
						int num256 = this.width;
						int num257 = this.height;
						int num258 = 13;
						float speedX44 = 0f;
						float speedY44 = 0f;
						int num259 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector58, num256, num257, num258, speedX44, speedY44, num259, newColor, 1f);
					}
					for (int num260 = 0; num260 < 30; num260++)
					{
						Vector2 vector59 = new Vector2(this.position.X, this.position.Y);
						int num261 = this.width;
						int num262 = this.height;
						int num263 = 33;
						float speedX45 = 0f;
						float speedY45 = -2f;
						int num264 = 0;
						Color newColor = default(Color);
						int num265 = Dust.NewDust(vector59, num261, num262, num263, speedX45, speedY45, num264, newColor, 1.1f);
						Main.dust[num265].alpha = 100;
						Dust dust24 = Main.dust[num265];
						dust24.velocity.X = dust24.velocity.X * 1.5f;
						Dust dust25 = Main.dust[num265];
						dust25.velocity *= 3f;
					}
				}
				else if (this.type == 70)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num266 = 0; num266 < 5; num266++)
					{
						Vector2 vector60 = new Vector2(this.position.X, this.position.Y);
						int num267 = this.width;
						int num268 = this.height;
						int num269 = 13;
						float speedX46 = 0f;
						float speedY46 = 0f;
						int num270 = 0;
						Color newColor = default(Color);
						Dust.NewDust(vector60, num267, num268, num269, speedX46, speedY46, num270, newColor, 1f);
					}
					for (int num271 = 0; num271 < 30; num271++)
					{
						Vector2 vector61 = new Vector2(this.position.X, this.position.Y);
						int num272 = this.width;
						int num273 = this.height;
						int num274 = 52;
						float speedX47 = 0f;
						float speedY47 = -2f;
						int num275 = 0;
						Color newColor = default(Color);
						int num276 = Dust.NewDust(vector61, num272, num273, num274, speedX47, speedY47, num275, newColor, 1.1f);
						Main.dust[num276].alpha = 100;
						Dust dust26 = Main.dust[num276];
						dust26.velocity.X = dust26.velocity.X * 1.5f;
						Dust dust27 = Main.dust[num276];
						dust27.velocity *= 3f;
					}
				}
				if (this.owner == Main.myPlayer)
				{
					if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 75 || this.type == 108)
					{
						int num277 = 3;
						if (this.type == 29)
						{
							num277 = 7;
						}
						if (this.type == 108)
						{
							num277 = 10;
						}
						int num278 = (int)(this.position.X / 16f - (float)num277);
						int num279 = (int)(this.position.X / 16f + (float)num277);
						int num280 = (int)(this.position.Y / 16f - (float)num277);
						int num281 = (int)(this.position.Y / 16f + (float)num277);
						if (num278 < 0)
						{
							num278 = 0;
						}
						if (num279 > Main.maxTilesX)
						{
							num279 = Main.maxTilesX;
						}
						if (num280 < 0)
						{
							num280 = 0;
						}
						if (num281 > Main.maxTilesY)
						{
							num281 = Main.maxTilesY;
						}
						bool flag = false;
						for (int num282 = num278; num282 <= num279; num282++)
						{
							for (int num283 = num280; num283 <= num281; num283++)
							{
								float num284 = Math.Abs((float)num282 - this.position.X / 16f);
								float num285 = Math.Abs((float)num283 - this.position.Y / 16f);
								double num286 = Math.Sqrt((double)(num284 * num284 + num285 * num285));
								if (num286 < (double)num277 && Main.tile[num282, num283] != null && Main.tile[num282, num283].wall == 0)
								{
									flag = true;
									break;
								}
							}
						}
						for (int num287 = num278; num287 <= num279; num287++)
						{
							for (int num288 = num280; num288 <= num281; num288++)
							{
								float num289 = Math.Abs((float)num287 - this.position.X / 16f);
								float num290 = Math.Abs((float)num288 - this.position.Y / 16f);
								double num291 = Math.Sqrt((double)(num289 * num289 + num290 * num290));
								if (num291 < (double)num277)
								{
									bool flag2 = true;
									if (Main.tile[num287, num288] != null && Main.tile[num287, num288].active)
									{
										flag2 = true;
										if (Main.tileDungeon[(int)Main.tile[num287, num288].type] || Main.tile[num287, num288].type == 21 || Main.tile[num287, num288].type == 26 || Main.tile[num287, num288].type == 107 || Main.tile[num287, num288].type == 108 || Main.tile[num287, num288].type == 111)
										{
											flag2 = false;
										}
										if (!Main.hardMode && Main.tile[num287, num288].type == 58)
										{
											flag2 = false;
										}
										if (flag2)
										{
											WorldGen.KillTile(num287, num288, false, false, false);
											if (!Main.tile[num287, num288].active && Main.netMode != 0)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num287, (float)num288, 0f, 0);
											}
										}
									}
									if (flag2)
									{
										for (int num292 = num287 - 1; num292 <= num287 + 1; num292++)
										{
											for (int num293 = num288 - 1; num293 <= num288 + 1; num293++)
											{
												if (Main.tile[num292, num293] != null && Main.tile[num292, num293].wall > 0 && flag)
												{
													WorldGen.KillWall(num292, num293, false);
													if (Main.tile[num292, num293].wall == 0 && Main.netMode != 0)
													{
														NetMessage.SendData(17, -1, -1, "", 2, (float)num292, (float)num293, 0f, 0);
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (Main.netMode != 0)
					{
						NetMessage.SendData(29, -1, -1, "", this.identity, (float)this.owner, 0f, 0f, 0);
					}
					int num294 = -1;
					if (this.aiStyle == 10)
					{
						int num295 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num296 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
						int num297 = 0;
						int num298 = 2;
						if (this.type == 109)
						{
							num297 = 147;
							num298 = 0;
						}
						if (this.type == 31)
						{
							num297 = 53;
							num298 = 0;
						}
						if (this.type == 42)
						{
							num297 = 53;
							num298 = 0;
						}
						if (this.type == 56)
						{
							num297 = 112;
							num298 = 0;
						}
						if (this.type == 65)
						{
							num297 = 112;
							num298 = 0;
						}
						if (this.type == 67)
						{
							num297 = 116;
							num298 = 0;
						}
						if (this.type == 68)
						{
							num297 = 116;
							num298 = 0;
						}
						if (this.type == 71)
						{
							num297 = 123;
							num298 = 0;
						}
						if (this.type == 39)
						{
							num297 = 59;
							num298 = 176;
						}
						if (this.type == 40)
						{
							num297 = 57;
							num298 = 172;
						}
						if (!Main.tile[num295, num296].active)
						{
							WorldGen.PlaceTile(num295, num296, num297, false, true, -1, 0);
							if (Main.tile[num295, num296].active && (int)Main.tile[num295, num296].type == num297)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num295, (float)num296, (float)num297, 0);
							}
							else if (num298 > 0)
							{
								num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num298, 1, false, 0);
							}
						}
						else if (num298 > 0)
						{
							num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num298, 1, false, 0);
						}
					}
					if (this.type == 1 && Main.rand.Next(3) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
					}
					if (this.type == 103 && Main.rand.Next(6) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0);
						}
						else
						{
							num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
						}
					}
					if (this.type == 2 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0);
						}
						else
						{
							num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
						}
					}
					if (this.type == 91 && Main.rand.Next(6) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0);
					}
					if (this.type == 50 && Main.rand.Next(3) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0);
					}
					if (this.type == 53 && Main.rand.Next(3) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0);
					}
					if (this.type == 48 && Main.rand.Next(2) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0);
					}
					if (this.type == 54 && Main.rand.Next(2) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0);
					}
					if (this.type == 3 && Main.rand.Next(2) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0);
					}
					if (this.type == 4 && Main.rand.Next(4) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0);
					}
					if (this.type == 12 && this.damage > 100)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0);
					}
					if (this.type == 69 || this.type == 70)
					{
						int num299 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num300 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
						for (int num301 = num299 - 4; num301 <= num299 + 4; num301++)
						{
							for (int num302 = num300 - 4; num302 <= num300 + 4; num302++)
							{
								if (Math.Abs(num301 - num299) + Math.Abs(num302 - num300) < 6)
								{
									if (this.type == 69)
									{
										if (Main.tile[num301, num302].type == 2)
										{
											Main.tile[num301, num302].type = 109;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
										else if (Main.tile[num301, num302].type == 1)
										{
											Main.tile[num301, num302].type = 117;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
										else if (Main.tile[num301, num302].type == 53)
										{
											Main.tile[num301, num302].type = 116;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
										else if (Main.tile[num301, num302].type == 23)
										{
											Main.tile[num301, num302].type = 109;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
										else if (Main.tile[num301, num302].type == 25)
										{
											Main.tile[num301, num302].type = 117;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
										else if (Main.tile[num301, num302].type == 112)
										{
											Main.tile[num301, num302].type = 116;
											WorldGen.SquareTileFrame(num301, num302, true);
											NetMessage.SendTileSquare(-1, num301, num302, 1);
										}
									}
									else if (Main.tile[num301, num302].type == 2)
									{
										Main.tile[num301, num302].type = 23;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
									else if (Main.tile[num301, num302].type == 1)
									{
										Main.tile[num301, num302].type = 25;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
									else if (Main.tile[num301, num302].type == 53)
									{
										Main.tile[num301, num302].type = 112;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
									else if (Main.tile[num301, num302].type == 109)
									{
										Main.tile[num301, num302].type = 23;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
									else if (Main.tile[num301, num302].type == 117)
									{
										Main.tile[num301, num302].type = 25;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
									else if (Main.tile[num301, num302].type == 116)
									{
										Main.tile[num301, num302].type = 112;
										WorldGen.SquareTileFrame(num301, num302, true);
										NetMessage.SendTileSquare(-1, num301, num302, 1);
									}
								}
							}
						}
					}
					if (this.type == 21 && Main.rand.Next(2) == 0)
					{
						num294 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0);
					}
					if (Main.netMode == 1 && num294 >= 0)
					{
						NetMessage.SendData(21, -1, -1, "", num294, 0f, 0f, 0f, 0);
					}
				}
				this.active = false;
			}
		}

		public Color GetAlpha(Color newColor)
		{
			Color result;
			if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || (this.type == 102 && this.alpha < 255))
			{
				result = new Color(200, 200, 200, 25);
			}
			else if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104)
			{
				if (this.alpha < 200)
				{
					result = new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
				}
				else
				{
					result = new Color(0, 0, 0, 0);
				}
			}
			else if (this.type == 34 || this.type == 35 || this.type == 15 || this.type == 19 || this.type == 44 || this.type == 45)
			{
				result = Color.White;
			}
			else if (this.type == 79)
			{
				int r = Main.DiscoR;
				int g = Main.DiscoG;
				int b = Main.DiscoB;
				result = default(Color);
			}
			else
			{
				int r;
				int g;
				int b;
				if (this.type == 9 || this.type == 15 || this.type == 34 || this.type == 50 || this.type == 53 || this.type == 76 || this.type == 77 || this.type == 78 || this.type == 92 || this.type == 91)
				{
					r = (int)newColor.R - this.alpha / 3;
					g = (int)newColor.G - this.alpha / 3;
					b = (int)newColor.B - this.alpha / 3;
				}
				else if (this.type == 16 || this.type == 18 || this.type == 44 || this.type == 45)
				{
					r = (int)newColor.R;
					g = (int)newColor.G;
					b = (int)newColor.B;
				}
				else
				{
					if (this.type == 12 || this.type == 72 || this.type == 86 || this.type == 87)
					{
						result = new Color(255, 255, 255, (int)newColor.A - this.alpha);
						return result;
					}
					r = (int)newColor.R - this.alpha;
					g = (int)newColor.G - this.alpha;
					b = (int)newColor.B - this.alpha;
				}
				int num = (int)newColor.A - this.alpha;
				if (num < 0)
				{
					num = 0;
				}
				if (num > 255)
				{
					num = 255;
				}
				result = new Color(r, g, b, num);
			}
			return result;
		}
	}
}
