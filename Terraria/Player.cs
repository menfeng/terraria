using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 10;

		public bool flapSound;

		public int wingTime;

		public int wings;

		public int wingFrame;

		public int wingFrameCounter;

		public bool male = true;

		public bool ghost;

		public int ghostFrame;

		public int ghostFrameCounter;

		public bool pvpDeath;

		public bool zoneDungeon;

		public bool zoneEvil;

		public bool zoneHoly;

		public bool zoneMeteor;

		public bool zoneJungle;

		public bool boneArmor;

		public float townNPCs;

		public Vector2 position;

		public Vector2 oldPosition;

		public Vector2 velocity;

		public Vector2 oldVelocity;

		public double headFrameCounter;

		public double bodyFrameCounter;

		public double legFrameCounter;

		public int netSkip;

		public int oldSelectItem;

		public bool immune;

		public int immuneTime;

		public int immuneAlphaDirection;

		public int immuneAlpha;

		public int team;

		public bool hbLocked;

		public static int nameLen = 20;

		private float maxRegenDelay;

		public string chatText = "";

		public int sign = -1;

		public int chatShowTime;

		public int reuseDelay;

		public float activeNPCs;

		public bool mouseInterface;

		public int noThrow;

		public int changeItem = -1;

		public int selectedItem;

		public Item[] armor = new Item[11];

		public int itemAnimation;

		public int itemAnimationMax;

		public int itemTime;

		public int toolTime;

		public float itemRotation;

		public int itemWidth;

		public int itemHeight;

		public Vector2 itemLocation;

		public float ghostFade;

		public float ghostDir = 1f;

		public int[] buffType = new int[10];

		public int[] buffTime = new int[10];

		public int heldProj = -1;

		public int breathCD;

		public int breathMax = 200;

		public int breath = 200;

		public bool socialShadow;

		public string setBonus = "";

		public Item[] inventory = new Item[49];

		public Item[] bank = new Item[Chest.maxItems];

		public Item[] bank2 = new Item[Chest.maxItems];

		public float headRotation;

		public float bodyRotation;

		public float legRotation;

		public Vector2 headPosition;

		public Vector2 bodyPosition;

		public Vector2 legPosition;

		public Vector2 headVelocity;

		public Vector2 bodyVelocity;

		public Vector2 legVelocity;

		public int nonTorch = -1;

		public static bool deadForGood = false;

		public bool dead;

		public int respawnTimer;

		public string name = "";

		public int attackCD;

		public int potionDelay;

		public byte difficulty;

		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public int hitTile;

		public int hitTileX;

		public int hitTileY;

		public int jump;

		public int head = -1;

		public int body = -1;

		public int legs = -1;

		public Rectangle headFrame;

		public Rectangle bodyFrame;

		public Rectangle legFrame;

		public Rectangle hairFrame;

		public bool controlLeft;

		public bool controlRight;

		public bool controlUp;

		public bool controlDown;

		public bool controlJump;

		public bool controlUseItem;

		public bool controlUseTile;

		public bool controlThrow;

		public bool controlInv;

		public bool controlHook;

		public bool controlTorch;

		public bool releaseJump;

		public bool releaseUseItem;

		public bool releaseUseTile;

		public bool releaseInventory;

		public bool releaseHook;

		public bool releaseThrow;

		public bool releaseQuickMana;

		public bool releaseQuickHeal;

		public bool delayUseItem;

		public bool active;

		public int width = 20;

		public int height = 42;

		public int direction = 1;

		public bool showItemIcon;

		public int showItemIcon2;

		public int whoAmi;

		public int runSoundDelay;

		public float shadow;

		public float manaCost = 1f;

		public bool fireWalk;

		public Vector2[] shadowPos = new Vector2[3];

		public int shadowCount;

		public bool channel;

		public int step = -1;

		public int statDefense;

		public int statAttack;

		public int statLifeMax = 100;

		public int statLife = 100;

		public int statMana;

		public int statManaMax;

		public int statManaMax2;

		public int lifeRegen;

		public int lifeRegenCount;

		public int lifeRegenTime;

		public int manaRegen;

		public int manaRegenCount;

		public int manaRegenDelay;

		public bool manaRegenBuff;

		public bool noKnockback;

		public bool spaceGun;

		public float gravDir = 1f;

		public bool ammoCost80;

		public bool ammoCost75;

		public int stickyBreak;

		public bool lightOrb;

		public bool fairy;

		public bool archery;

		public bool poisoned;

		public bool blind;

		public bool onFire;

		public bool onFire2;

		public bool noItems;

		public bool wereWolf;

		public bool wolfAcc;

		public bool rulerAcc;

		public bool bleed;

		public bool confused;

		public bool accMerman;

		public bool merman;

		public bool brokenArmor;

		public bool silence;

		public bool slow;

		public bool gross;

		public bool tongued;

		public bool kbGlove;

		public bool starCloak;

		public bool longInvince;

		public bool pStone;

		public bool manaFlower;

		public int meleeCrit = 4;

		public int rangedCrit = 4;

		public int magicCrit = 4;

		public float meleeDamage = 1f;

		public float rangedDamage = 1f;

		public float magicDamage = 1f;

		public float meleeSpeed = 1f;

		public float moveSpeed = 1f;

		public float pickSpeed = 1f;

		public int SpawnX = -1;

		public int SpawnY = -1;

		public int[] spX = new int[200];

		public int[] spY = new int[200];

		public string[] spN = new string[200];

		public int[] spI = new int[200];

		public static int tileRangeX = 5;

		public static int tileRangeY = 4;

		private static int tileTargetX;

		private static int tileTargetY;

		private static int jumpHeight = 15;

		private static float jumpSpeed = 5.01f;

		public bool adjWater;

		public bool oldAdjWater;

		public bool[] adjTile = new bool[150];

		public bool[] oldAdjTile = new bool[150];

		private static int itemGrabRange = 38;

		private static float itemGrabSpeed = 0.45f;

		private static float itemGrabSpeedMax = 4f;

		public Color hairColor = new Color(215, 90, 55);

		public Color skinColor = new Color(255, 125, 90);

		public Color eyeColor = new Color(105, 90, 75);

		public Color shirtColor = new Color(175, 165, 140);

		public Color underShirtColor = new Color(160, 180, 215);

		public Color pantsColor = new Color(255, 230, 175);

		public Color shoeColor = new Color(160, 105, 60);

		public int hair;

		public bool hostile;

		public int accCompass;

		public int accWatch;

		public int accDepthMeter;

		public bool accDivingHelm;

		public bool accFlipper;

		public bool doubleJump;

		public bool jumpAgain;

		public bool spawnMax;

		public int blockRange;

		public int[] grappling = new int[20];

		public int grapCount;

		public int rocketTime;

		public int rocketTimeMax = 7;

		public int rocketDelay;

		public int rocketDelay2;

		public bool rocketRelease;

		public bool rocketFrame;

		public int rocketBoots;

		public bool canRocket;

		public bool jumpBoost;

		public bool noFallDmg;

		public int swimTime;

		public bool killGuide;

		public bool lavaImmune;

		public bool gills;

		public bool slowFall;

		public bool findTreasure;

		public bool invis;

		public bool detectCreature;

		public bool nightVision;

		public bool enemySpawns;

		public bool thorns;

		public bool waterWalk;

		public bool gravControl;

		public int chest = -1;

		public int chestX;

		public int chestY;

		public int talkNPC = -1;

		public int fallStart;

		public int slowCount;

		public int potionDelayTime = Item.potionDelay;

		public void HealEffect(int healAmount)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 255, 100, 255), string.Concat(healAmount), false);
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(35, -1, -1, "", this.whoAmi, (float)healAmount, 0f, 0f, 0);
			}
		}

		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 100, 255, 255), string.Concat(manaAmount), false);
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(43, -1, -1, "", this.whoAmi, (float)manaAmount, 0f, 0f, 0);
			}
		}

		public static byte FindClosest(Vector2 Position, int Width, int Height)
		{
			byte result = 0;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					result = (byte)i;
					break;
				}
			}
			float num = -1f;
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].active && !Main.player[j].dead && (num == -1f || Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2)) < num))
				{
					num = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2));
					result = (byte)j;
				}
			}
			return result;
		}

		public void checkArmor()
		{
		}

		public void toggleInv()
		{
			if (this.talkNPC >= 0)
			{
				this.talkNPC = -1;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
			}
			else if (this.sign >= 0)
			{
				this.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
			}
			else if (!Main.playerInventory)
			{
				Recipe.FindRecipes();
				Main.playerInventory = true;
				Main.PlaySound(10, -1, -1, 1);
			}
			else
			{
				Main.playerInventory = false;
				Main.PlaySound(11, -1, -1, 1);
			}
		}

		public void dropItemCheck()
		{
			if (!Main.playerInventory)
			{
				this.noThrow = 0;
			}
			if (this.noThrow > 0)
			{
				this.noThrow--;
			}
			if (!Main.craftGuide && Main.guideItem.type > 0)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.guideItem.type, 1, false, 0);
				Main.guideItem.position = Main.item[num].position;
				Main.item[num] = Main.guideItem;
				Main.guideItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num].noGrabDelay = 100;
				}
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
				}
			}
			if (!Main.reforge && Main.reforgeItem.type > 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.reforgeItem.type, 1, false, 0);
				Main.reforgeItem.position = Main.item[num2].position;
				Main.item[num2] = Main.reforgeItem;
				Main.reforgeItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num2].noGrabDelay = 100;
				}
				Main.item[num2].velocity.Y = -2f;
				Main.item[num2].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
				}
			}
			if (Main.myPlayer == this.whoAmi)
			{
				this.inventory[48] = (Item)Main.mouseItem.Clone();
			}
			bool flag = true;
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
			{
				Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
				Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
				if (this.selectedItem != 48)
				{
					this.oldSelectItem = this.selectedItem;
				}
				this.selectedItem = 48;
				flag = false;
			}
			if (flag && this.selectedItem == 48)
			{
				this.selectedItem = this.oldSelectItem;
			}
			if (((this.controlThrow && this.releaseThrow && this.inventory[this.selectedItem].type > 0 && !Main.chatMode) || (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)) && this.noThrow <= 0)
			{
				Item item = new Item();
				bool flag2 = false;
				if (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					item = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = Main.mouseItem;
					this.delayUseItem = true;
					this.controlUseItem = false;
					flag2 = true;
				}
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0);
				if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
				{
					this.inventory[this.selectedItem].stack--;
				}
				else
				{
					this.inventory[this.selectedItem].position = Main.item[num3].position;
					Main.item[num3] = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = new Item();
				}
				if (Main.netMode == 0)
				{
					Main.item[num3].noGrabDelay = 100;
				}
				Main.item[num3].velocity.Y = -2f;
				Main.item[num3].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (((Main.mouseRight && !this.mouseInterface) || !Main.playerInventory) && Main.mouseItem.type > 0)
				{
					this.inventory[this.selectedItem] = item;
					Main.mouseItem = new Item();
				}
				else
				{
					this.itemAnimation = 10;
					this.itemAnimationMax = 10;
				}
				Recipe.FindRecipes();
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
				}
			}
		}

		public void AddBuff(int type, int time, bool quiet = true)
		{
			if (!quiet && Main.netMode == 1)
			{
				NetMessage.SendData(55, -1, -1, "", this.whoAmi, (float)type, (float)time, 0f, 0);
			}
			int num = -1;
			for (int i = 0; i < 10; i++)
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
				for (int j = 0; j < 10; j++)
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
				for (int k = num2; k < 10; k++)
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

		public void DelBuff(int b)
		{
			this.buffTime[b] = 0;
			this.buffType[b] = 0;
			for (int i = 0; i < 9; i++)
			{
				if (this.buffTime[i] == 0 || this.buffType[i] == 0)
				{
					for (int j = i + 1; j < 10; j++)
					{
						this.buffTime[j - 1] = this.buffTime[j];
						this.buffType[j - 1] = this.buffType[j];
						this.buffTime[j] = 0;
						this.buffType[j] = 0;
					}
				}
			}
		}

		public void QuickHeal()
		{
			if (!this.noItems)
			{
				if (this.statLife != this.statLifeMax && this.potionDelay <= 0)
				{
					for (int i = 0; i < 48; i++)
					{
						if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].potion && this.inventory[i].healLife > 0)
						{
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
							if (this.inventory[i].potion)
							{
								this.potionDelay = this.potionDelayTime;
								this.AddBuff(21, this.potionDelay, true);
							}
							this.statLife += this.inventory[i].healLife;
							this.statMana += this.inventory[i].healMana;
							if (this.statLife > this.statLifeMax)
							{
								this.statLife = this.statLifeMax;
							}
							if (this.statMana > this.statManaMax2)
							{
								this.statMana = this.statManaMax2;
							}
							if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
							{
								this.HealEffect(this.inventory[i].healLife);
							}
							if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
							{
								this.ManaEffect(this.inventory[i].healMana);
							}
							this.inventory[i].stack--;
							if (this.inventory[i].stack <= 0)
							{
								this.inventory[i].type = 0;
								this.inventory[i].name = "";
							}
							Recipe.FindRecipes();
							break;
						}
					}
				}
			}
		}

		public void QuickMana()
		{
			if (!this.noItems)
			{
				if (this.statMana != this.statManaMax2)
				{
					for (int i = 0; i < 48; i++)
					{
						if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].healMana > 0 && (this.potionDelay == 0 || !this.inventory[i].potion))
						{
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
							if (this.inventory[i].potion)
							{
								this.potionDelay = this.potionDelayTime;
								this.AddBuff(21, this.potionDelay, true);
							}
							this.statLife += this.inventory[i].healLife;
							this.statMana += this.inventory[i].healMana;
							if (this.statLife > this.statLifeMax)
							{
								this.statLife = this.statLifeMax;
							}
							if (this.statMana > this.statManaMax2)
							{
								this.statMana = this.statManaMax2;
							}
							if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
							{
								this.HealEffect(this.inventory[i].healLife);
							}
							if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
							{
								this.ManaEffect(this.inventory[i].healMana);
							}
							this.inventory[i].stack--;
							if (this.inventory[i].stack <= 0)
							{
								this.inventory[i].type = 0;
								this.inventory[i].name = "";
							}
							Recipe.FindRecipes();
							break;
						}
					}
				}
			}
		}

		public int countBuffs()
		{
			int num = 0;
			for (int i = 0; i < 10; i++)
			{
				if (this.buffType[num] > 0)
				{
					num++;
				}
			}
			return num;
		}

		public void QuickBuff()
		{
			if (!this.noItems)
			{
				int num = 0;
				for (int i = 0; i < 48; i++)
				{
					if (this.countBuffs() == 10)
					{
						return;
					}
					if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0)
					{
						bool flag = true;
						for (int j = 0; j < 10; j++)
						{
							if (this.buffType[j] == this.inventory[i].buffType)
							{
								flag = false;
								break;
							}
						}
						if (this.inventory[i].mana > 0 && flag)
						{
							if (this.statMana >= (int)((float)this.inventory[i].mana * this.manaCost))
							{
								this.manaRegenDelay = (int)this.maxRegenDelay;
								this.statMana -= (int)((float)this.inventory[i].mana * this.manaCost);
							}
							else
							{
								flag = false;
							}
						}
						if (flag)
						{
							num = this.inventory[i].useSound;
							this.AddBuff(this.inventory[i].buffType, this.inventory[i].buffTime, true);
							if (this.inventory[i].consumable)
							{
								this.inventory[i].stack--;
								if (this.inventory[i].stack <= 0)
								{
									this.inventory[i].type = 0;
									this.inventory[i].name = "";
								}
							}
						}
					}
				}
				if (num > 0)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, num);
					Recipe.FindRecipes();
				}
			}
		}

		public void StatusNPC(int type, int i)
		{
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(20, 420, false);
				}
			}
			else if (type == 217 && Main.rand.Next(5) == 0)
			{
				Main.npc[i].AddBuff(24, 180, false);
			}
		}

		public void StatusPvP(int type, int i)
		{
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
				}
			}
			else if (type == 217 && Main.rand.Next(5) == 0)
			{
				Main.player[i].AddBuff(24, 180, false);
			}
		}

		public void Ghost()
		{
			this.immune = false;
			this.immuneAlpha = 0;
			this.controlUp = false;
			this.controlLeft = false;
			this.controlDown = false;
			this.controlRight = false;
			this.controlJump = false;
			if (Main.hasFocus && !Main.chatMode && !Main.editSign)
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				for (int i = 0; i < pressedKeys.Length; i++)
				{
					string a = string.Concat(pressedKeys[i]);
					if (a == Main.cUp)
					{
						this.controlUp = true;
					}
					if (a == Main.cLeft)
					{
						this.controlLeft = true;
					}
					if (a == Main.cDown)
					{
						this.controlDown = true;
					}
					if (a == Main.cRight)
					{
						this.controlRight = true;
					}
					if (a == Main.cJump)
					{
						this.controlJump = true;
					}
				}
			}
			if (this.controlUp || this.controlJump)
			{
				if (this.velocity.Y > 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.9f;
				}
				this.velocity.Y = this.velocity.Y - 0.1f;
				if (this.velocity.Y < -3f)
				{
					this.velocity.Y = -3f;
				}
			}
			else if (this.controlDown)
			{
				if (this.velocity.Y < 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.9f;
				}
				this.velocity.Y = this.velocity.Y + 0.1f;
				if (this.velocity.Y > 3f)
				{
					this.velocity.Y = 3f;
				}
			}
			else if ((double)this.velocity.Y < -0.1 || (double)this.velocity.Y > 0.1)
			{
				this.velocity.Y = this.velocity.Y * 0.9f;
			}
			else
			{
				this.velocity.Y = 0f;
			}
			if (this.controlLeft && !this.controlRight)
			{
				if (this.velocity.X > 0f)
				{
					this.velocity.X = this.velocity.X * 0.9f;
				}
				this.velocity.X = this.velocity.X - 0.1f;
				if (this.velocity.X < -3f)
				{
					this.velocity.X = -3f;
				}
			}
			else if (this.controlRight && !this.controlLeft)
			{
				if (this.velocity.X < 0f)
				{
					this.velocity.X = this.velocity.X * 0.9f;
				}
				this.velocity.X = this.velocity.X + 0.1f;
				if (this.velocity.X > 3f)
				{
					this.velocity.X = 3f;
				}
			}
			else if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
			{
				this.velocity.X = this.velocity.X * 0.9f;
			}
			else
			{
				this.velocity.X = 0f;
			}
			this.position += this.velocity;
			this.ghostFrameCounter++;
			if (this.velocity.X < 0f)
			{
				this.direction = -1;
			}
			else if (this.velocity.X > 0f)
			{
				this.direction = 1;
			}
			if (this.ghostFrameCounter >= 8)
			{
				this.ghostFrameCounter = 0;
				this.ghostFrame++;
				if (this.ghostFrame >= 4)
				{
					this.ghostFrame = 0;
				}
			}
			if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				this.velocity.X = 0f;
			}
			if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
			{
				this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
				this.velocity.X = 0f;
			}
			if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				if ((double)this.velocity.Y < -0.1)
				{
					this.velocity.Y = -0.1f;
				}
			}
			if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
			{
				this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
				this.velocity.Y = 0f;
			}
		}

		public void UpdatePlayer(int i)
		{
			float num = 10f;
			float num2 = 0.4f;
			Player.jumpHeight = 15;
			Player.jumpSpeed = 5.01f;
			if (this.wet)
			{
				if (this.merman)
				{
					num2 = 0.3f;
					num = 7f;
				}
				else
				{
					num2 = 0.2f;
					num = 5f;
					Player.jumpHeight = 30;
					Player.jumpSpeed = 6.01f;
				}
			}
			float num3 = 3f;
			float num4 = 0.08f;
			float num5 = 0.2f;
			float num6 = num3;
			this.heldProj = -1;
			if (this.active)
			{
				float num7 = (float)(Main.maxTilesX / 4200);
				num7 *= num7;
				float num8 = (float)((double)(this.position.Y / 16f - (60f + 10f * num7)) / (Main.worldSurface / 6.0));
				if ((double)num8 < 0.25)
				{
					num8 = 0.25f;
				}
				if (num8 > 1f)
				{
					num8 = 1f;
				}
				num2 *= num8;
				this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
				this.shadowCount++;
				if (this.shadowCount == 1)
				{
					this.shadowPos[2] = this.shadowPos[1];
				}
				else if (this.shadowCount == 2)
				{
					this.shadowPos[1] = this.shadowPos[0];
				}
				else if (this.shadowCount >= 3)
				{
					this.shadowCount = 0;
					this.shadowPos[0] = this.position;
				}
				this.whoAmi = i;
				if (this.runSoundDelay > 0)
				{
					this.runSoundDelay--;
				}
				if (this.attackCD > 0)
				{
					this.attackCD--;
				}
				if (this.itemAnimation == 0)
				{
					this.attackCD = 0;
				}
				if (this.chatShowTime > 0)
				{
					this.chatShowTime--;
				}
				if (this.potionDelay > 0)
				{
					this.potionDelay--;
				}
				if (i == Main.myPlayer)
				{
					this.zoneEvil = false;
					if (Main.evilTiles >= 200)
					{
						this.zoneEvil = true;
					}
					this.zoneHoly = false;
					if (Main.holyTiles >= 100)
					{
						this.zoneHoly = true;
					}
					this.zoneMeteor = false;
					if (Main.meteorTiles >= 50)
					{
						this.zoneMeteor = true;
					}
					this.zoneDungeon = false;
					if (Main.dungeonTiles >= 250 && (double)this.position.Y > Main.worldSurface * 16.0)
					{
						int num9 = (int)this.position.X / 16;
						int num10 = (int)this.position.Y / 16;
						if (Main.tile[num9, num10].wall > 0 && !Main.wallHouse[(int)Main.tile[num9, num10].wall])
						{
							this.zoneDungeon = true;
						}
					}
					this.zoneJungle = false;
					if (Main.jungleTiles >= 80)
					{
						this.zoneJungle = true;
					}
				}
				if (this.ghost)
				{
					this.Ghost();
				}
				else if (!this.dead)
				{
					if (i == Main.myPlayer)
					{
						this.controlUp = false;
						this.controlLeft = false;
						this.controlDown = false;
						this.controlRight = false;
						this.controlJump = false;
						this.controlUseItem = false;
						this.controlUseTile = false;
						this.controlThrow = false;
						this.controlInv = false;
						this.controlHook = false;
						this.controlTorch = false;
						if (Main.hasFocus)
						{
							if (!Main.chatMode && !Main.editSign)
							{
								Keys[] pressedKeys = Main.keyState.GetPressedKeys();
								bool flag = false;
								bool flag2 = false;
								for (int j = 0; j < pressedKeys.Length; j++)
								{
									string a = string.Concat(pressedKeys[j]);
									if (a == Main.cUp)
									{
										this.controlUp = true;
									}
									if (a == Main.cLeft)
									{
										this.controlLeft = true;
									}
									if (a == Main.cDown)
									{
										this.controlDown = true;
									}
									if (a == Main.cRight)
									{
										this.controlRight = true;
									}
									if (a == Main.cJump)
									{
										this.controlJump = true;
									}
									if (a == Main.cThrowItem)
									{
										this.controlThrow = true;
									}
									if (a == Main.cInv)
									{
										this.controlInv = true;
									}
									if (a == Main.cBuff)
									{
										this.QuickBuff();
									}
									if (a == Main.cHeal)
									{
										flag2 = true;
									}
									if (a == Main.cMana)
									{
										flag = true;
									}
									if (a == Main.cHook)
									{
										this.controlHook = true;
									}
									if (a == Main.cTorch)
									{
										this.controlTorch = true;
									}
								}
								if (Main.gamePad)
								{
									GamePadState state = GamePad.GetState(PlayerIndex.One);
									if (state.DPad.Up == ButtonState.Pressed)
									{
										this.controlUp = true;
									}
									if (state.DPad.Down == ButtonState.Pressed)
									{
										this.controlDown = true;
									}
									if (state.DPad.Left == ButtonState.Pressed)
									{
										this.controlLeft = true;
									}
									if (state.DPad.Right == ButtonState.Pressed)
									{
										this.controlRight = true;
									}
									if (state.Triggers.Left > 0f)
									{
										this.controlJump = true;
									}
									if (state.Triggers.Right > 0f)
									{
										this.controlUseItem = true;
									}
									float num11 = (float)(Main.screenWidth / 2);
									Main.mouseX = (int)(num11 + state.ThumbSticks.Right.X * (float)Player.tileRangeX * 16f);
									float num12 = (float)(Main.screenHeight / 2);
									Main.mouseY = (int)(num12 - state.ThumbSticks.Right.Y * (float)Player.tileRangeX * 16f);
									if (state.ThumbSticks.Right.X == 0f)
									{
										Main.mouseX = Main.screenWidth / 2 + this.direction * 2;
									}
								}
								if (flag2)
								{
									if (this.releaseQuickHeal)
									{
										this.QuickHeal();
									}
									this.releaseQuickHeal = false;
								}
								else
								{
									this.releaseQuickHeal = true;
								}
								if (flag)
								{
									if (this.releaseQuickMana)
									{
										this.QuickMana();
									}
									this.releaseQuickMana = false;
								}
								else
								{
									this.releaseQuickMana = true;
								}
								if (this.controlLeft && this.controlRight)
								{
									this.controlLeft = false;
									this.controlRight = false;
								}
							}
							if (this.confused)
							{
								bool flag3 = this.controlLeft;
								bool flag4 = this.controlUp;
								this.controlLeft = this.controlRight;
								this.controlRight = flag3;
								this.controlUp = this.controlRight;
								this.controlDown = flag4;
							}
							if (Main.mouseLeft && !this.mouseInterface)
							{
								this.controlUseItem = true;
							}
							if (Main.mouseRight && !this.mouseInterface)
							{
								this.controlUseTile = true;
							}
							if (this.controlInv)
							{
								if (this.releaseInventory)
								{
									this.toggleInv();
								}
								this.releaseInventory = false;
							}
							else
							{
								this.releaseInventory = true;
							}
							if (this.delayUseItem)
							{
								if (!this.controlUseItem)
								{
									this.delayUseItem = false;
								}
								this.controlUseItem = false;
							}
							if (this.itemAnimation == 0 && this.itemTime == 0)
							{
								this.dropItemCheck();
								int num13 = this.selectedItem;
								if (!Main.chatMode && this.selectedItem != 48)
								{
									if (Main.keyState.IsKeyDown(Keys.D1))
									{
										this.selectedItem = 0;
									}
									if (Main.keyState.IsKeyDown(Keys.D2))
									{
										this.selectedItem = 1;
									}
									if (Main.keyState.IsKeyDown(Keys.D3))
									{
										this.selectedItem = 2;
									}
									if (Main.keyState.IsKeyDown(Keys.D4))
									{
										this.selectedItem = 3;
									}
									if (Main.keyState.IsKeyDown(Keys.D5))
									{
										this.selectedItem = 4;
									}
									if (Main.keyState.IsKeyDown(Keys.D6))
									{
										this.selectedItem = 5;
									}
									if (Main.keyState.IsKeyDown(Keys.D7))
									{
										this.selectedItem = 6;
									}
									if (Main.keyState.IsKeyDown(Keys.D8))
									{
										this.selectedItem = 7;
									}
									if (Main.keyState.IsKeyDown(Keys.D9))
									{
										this.selectedItem = 8;
									}
									if (Main.keyState.IsKeyDown(Keys.D0))
									{
										this.selectedItem = 9;
									}
								}
								if (num13 != this.selectedItem)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (!Main.playerInventory)
								{
									int k;
									for (k = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120; k > 9; k -= 10)
									{
									}
									while (k < 0)
									{
										k += 10;
									}
									this.selectedItem -= k;
									if (k != 0)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									if (this.changeItem >= 0)
									{
										if (this.selectedItem != this.changeItem)
										{
											Main.PlaySound(12, -1, -1, 1);
										}
										this.selectedItem = this.changeItem;
										this.changeItem = -1;
									}
									while (this.selectedItem > 9)
									{
										this.selectedItem -= 10;
									}
									while (this.selectedItem < 0)
									{
										this.selectedItem += 10;
									}
								}
								else
								{
									int num14 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
									Main.focusRecipe += num14;
									if (Main.focusRecipe > Main.numAvailableRecipes - 1)
									{
										Main.focusRecipe = Main.numAvailableRecipes - 1;
									}
									if (Main.focusRecipe < 0)
									{
										Main.focusRecipe = 0;
									}
								}
							}
						}
						if (this.selectedItem == 48)
						{
							this.nonTorch = -1;
						}
						else if (this.controlTorch && this.itemAnimation == 0)
						{
							int num15 = 0;
							int num16 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
							int num17 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
							if (this.position.X / 16f - (float)Player.tileRangeX <= (float)num16 && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)num16 && this.position.Y / 16f - (float)Player.tileRangeY <= (float)num17 && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)num17)
							{
								try
								{
									if (Main.tile[num16, num17].active)
									{
										int type = (int)Main.tile[num16, num17].type;
										if (Main.tileHammer[type])
										{
											num15 = 1;
										}
										else if (Main.tileAxe[type])
										{
											num15 = 2;
										}
										else
										{
											num15 = 3;
										}
									}
									else if (Main.tile[num16, num17].liquid > 0 && this.wet)
									{
										num15 = 4;
									}
									goto IL_FAD;
								}
								catch
								{
									goto IL_FAD;
								}
							}
							if (this.wet)
							{
								num15 = 4;
							}
							IL_FAD:
							if (num15 == 0)
							{
								float num18 = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (this.position.X + (float)(this.width / 2)));
								float num19 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (this.position.Y + (float)(this.height / 2))) * 1.3f;
								float num20 = (float)Math.Sqrt((double)(num18 * num18 + num19 * num19));
								if (num20 > 200f)
								{
									num15 = 5;
								}
							}
							for (int l = 0; l < 40; l++)
							{
								int type2 = this.inventory[l].type;
								if (num15 == 0)
								{
									if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
									if (type2 == 282 || type2 == 286)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
									}
								}
								else if (num15 == 1)
								{
									if (this.inventory[l].hammer > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
								}
								else if (num15 == 2)
								{
									if (this.inventory[l].axe > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
								}
								else if (num15 == 3)
								{
									if (this.inventory[l].pick > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
								}
								else if (num15 == 4)
								{
									if (type2 == 282 || type2 == 286 || type2 == 523)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
								}
								else if (num15 == 5)
								{
									if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
									}
									else if (type2 == 282 || type2 == 286)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = l;
										break;
									}
								}
							}
						}
						else if (this.nonTorch > -1 && this.itemAnimation == 0)
						{
							this.selectedItem = this.nonTorch;
							this.nonTorch = -1;
						}
						if (!this.controlThrow)
						{
							this.releaseThrow = true;
						}
						else
						{
							this.releaseThrow = false;
						}
						if (Main.netMode == 1)
						{
							bool flag5 = false;
							if (this.statLife != Main.clientPlayer.statLife || this.statLifeMax != Main.clientPlayer.statLifeMax)
							{
								NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								flag5 = true;
							}
							if (this.statMana != Main.clientPlayer.statMana || this.statManaMax != Main.clientPlayer.statManaMax)
							{
								NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								flag5 = true;
							}
							if (this.controlUp != Main.clientPlayer.controlUp)
							{
								flag5 = true;
							}
							if (this.controlDown != Main.clientPlayer.controlDown)
							{
								flag5 = true;
							}
							if (this.controlLeft != Main.clientPlayer.controlLeft)
							{
								flag5 = true;
							}
							if (this.controlRight != Main.clientPlayer.controlRight)
							{
								flag5 = true;
							}
							if (this.controlJump != Main.clientPlayer.controlJump)
							{
								flag5 = true;
							}
							if (this.controlUseItem != Main.clientPlayer.controlUseItem)
							{
								flag5 = true;
							}
							if (this.selectedItem != Main.clientPlayer.selectedItem)
							{
								flag5 = true;
							}
							if (flag5)
							{
								NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
							}
						}
						if (Main.playerInventory)
						{
							this.AdjTiles();
						}
						if (this.chest != -1)
						{
							int num21 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
							int num22 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
							if (num21 < this.chestX - 5 || num21 > this.chestX + 6 || num22 < this.chestY - 4 || num22 > this.chestY + 5)
							{
								if (this.chest != -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.chest = -1;
							}
							if (!Main.tile[this.chestX, this.chestY].active)
							{
								Main.PlaySound(11, -1, -1, 1);
								this.chest = -1;
							}
						}
						if (this.velocity.Y == 0f)
						{
							int num23 = (int)(this.position.Y / 16f) - this.fallStart;
							if (((this.gravDir == 1f && num23 > 25) || (this.gravDir == -1f && num23 < -25)) && !this.noFallDmg && this.wings == 0)
							{
								int damage = (int)((float)num23 * this.gravDir - 25f) * 10;
								this.immune = false;
								this.Hurt(damage, 0, false, false, Player.getDeathMessage(-1, -1, -1, 0), false);
							}
							this.fallStart = (int)(this.position.Y / 16f);
						}
						if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)num8 < 0.8 || this.tongued)
						{
							this.fallStart = (int)(this.position.Y / 16f);
						}
					}
					if (this.mouseInterface)
					{
						this.delayUseItem = true;
					}
					Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
					Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
					if (this.immune)
					{
						this.immuneTime--;
						if (this.immuneTime <= 0)
						{
							this.immune = false;
						}
						this.immuneAlpha += this.immuneAlphaDirection * 50;
						if (this.immuneAlpha <= 50)
						{
							this.immuneAlphaDirection = 1;
						}
						else if (this.immuneAlpha >= 205)
						{
							this.immuneAlphaDirection = -1;
						}
					}
					else
					{
						this.immuneAlpha = 0;
					}
					this.potionDelayTime = Item.potionDelay;
					if (this.pStone)
					{
						this.potionDelayTime -= 900;
					}
					this.statDefense = 0;
					this.accWatch = 0;
					this.accCompass = 0;
					this.accDepthMeter = 0;
					this.accDivingHelm = false;
					this.lifeRegen = 0;
					this.manaCost = 1f;
					this.meleeSpeed = 1f;
					this.meleeDamage = 1f;
					this.rangedDamage = 1f;
					this.magicDamage = 1f;
					this.moveSpeed = 1f;
					this.boneArmor = false;
					this.rocketBoots = 0;
					this.fireWalk = false;
					this.noKnockback = false;
					this.jumpBoost = false;
					this.noFallDmg = false;
					this.accFlipper = false;
					this.spawnMax = false;
					this.spaceGun = false;
					this.killGuide = false;
					this.lavaImmune = false;
					this.gills = false;
					this.slowFall = false;
					this.findTreasure = false;
					this.invis = false;
					this.nightVision = false;
					this.enemySpawns = false;
					this.thorns = false;
					this.waterWalk = false;
					this.detectCreature = false;
					this.gravControl = false;
					this.statManaMax2 = this.statManaMax;
					this.ammoCost80 = false;
					this.ammoCost75 = false;
					this.manaRegenBuff = false;
					this.meleeCrit = 4;
					this.rangedCrit = 4;
					this.magicCrit = 4;
					this.lightOrb = false;
					this.fairy = false;
					this.archery = false;
					this.poisoned = false;
					this.blind = false;
					this.onFire = false;
					this.onFire2 = false;
					this.noItems = false;
					this.blockRange = 0;
					this.pickSpeed = 1f;
					this.wereWolf = false;
					this.rulerAcc = false;
					this.bleed = false;
					this.confused = false;
					this.wings = 0;
					this.brokenArmor = false;
					this.silence = false;
					this.slow = false;
					this.gross = false;
					this.tongued = false;
					this.kbGlove = false;
					this.starCloak = false;
					this.longInvince = false;
					this.pStone = false;
					this.manaFlower = false;
					this.meleeCrit += this.inventory[this.selectedItem].crit;
					this.magicCrit += this.inventory[this.selectedItem].crit;
					this.rangedCrit += this.inventory[this.selectedItem].crit;
					if (this.whoAmi == Main.myPlayer)
					{
						Main.musicBox2 = -1;
					}
					for (int m = 0; m < 10; m++)
					{
						if (this.buffType[m] > 0 && this.buffTime[m] > 0)
						{
							if (this.whoAmi == Main.myPlayer && this.buffType[m] != 28)
							{
								this.buffTime[m]--;
							}
							if (this.buffType[m] == 1)
							{
								this.lavaImmune = true;
								this.fireWalk = true;
							}
							else if (this.buffType[m] == 2)
							{
								this.lifeRegen += 2;
							}
							else if (this.buffType[m] == 3)
							{
								this.moveSpeed += 0.25f;
							}
							else if (this.buffType[m] == 4)
							{
								this.gills = true;
							}
							else if (this.buffType[m] == 5)
							{
								this.statDefense += 8;
							}
							else if (this.buffType[m] == 6)
							{
								this.manaRegenBuff = true;
							}
							else if (this.buffType[m] == 7)
							{
								this.magicDamage += 0.2f;
							}
							else if (this.buffType[m] == 8)
							{
								this.slowFall = true;
							}
							else if (this.buffType[m] == 9)
							{
								this.findTreasure = true;
							}
							else if (this.buffType[m] == 10)
							{
								this.invis = true;
							}
							else if (this.buffType[m] == 11)
							{
								Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.8f, 0.95f, 1f);
							}
							else if (this.buffType[m] == 12)
							{
								this.nightVision = true;
							}
							else if (this.buffType[m] == 13)
							{
								this.enemySpawns = true;
							}
							else if (this.buffType[m] == 14)
							{
								this.thorns = true;
							}
							else if (this.buffType[m] == 15)
							{
								this.waterWalk = true;
							}
							else if (this.buffType[m] == 16)
							{
								this.archery = true;
							}
							else if (this.buffType[m] == 17)
							{
								this.detectCreature = true;
							}
							else if (this.buffType[m] == 18)
							{
								this.gravControl = true;
							}
							else if (this.buffType[m] == 30)
							{
								this.bleed = true;
							}
							else if (this.buffType[m] == 31)
							{
								this.confused = true;
							}
							else if (this.buffType[m] == 32)
							{
								this.slow = true;
							}
							else if (this.buffType[m] == 35)
							{
								this.silence = true;
							}
							else if (this.buffType[m] == 36)
							{
								this.brokenArmor = true;
							}
							else if (this.buffType[m] == 37)
							{
								if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
								{
									this.gross = true;
									this.buffTime[m] = 10;
								}
								else
								{
									this.DelBuff(m);
								}
							}
							else if (this.buffType[m] == 38)
							{
								this.buffTime[m] = 10;
								this.tongued = true;
							}
							else if (this.buffType[m] == 19)
							{
								this.lightOrb = true;
								bool flag6 = true;
								for (int n = 0; n < 1000; n++)
								{
									if (Main.projectile[n].active && Main.projectile[n].owner == this.whoAmi && Main.projectile[n].type == 18)
									{
										flag6 = false;
										break;
									}
								}
								if (flag6)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi);
								}
							}
							else if (this.buffType[m] == 27)
							{
								this.fairy = true;
								bool flag7 = true;
								for (int num24 = 0; num24 < 1000; num24++)
								{
									if (Main.projectile[num24].active && Main.projectile[num24].owner == this.whoAmi && (Main.projectile[num24].type == 72 || Main.projectile[num24].type == 86 || Main.projectile[num24].type == 87))
									{
										flag7 = false;
										break;
									}
								}
								if (flag7)
								{
									int num25 = Main.rand.Next(3);
									if (num25 == 0)
									{
										num25 = 72;
									}
									else if (num25 == 1)
									{
										num25 = 86;
									}
									else if (num25 == 2)
									{
										num25 = 87;
									}
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num25, 0, 0f, this.whoAmi);
								}
							}
							else if (this.buffType[m] == 20)
							{
								this.poisoned = true;
							}
							else if (this.buffType[m] == 21)
							{
								this.potionDelay = this.buffTime[m];
							}
							else if (this.buffType[m] == 22)
							{
								this.blind = true;
							}
							else if (this.buffType[m] == 23)
							{
								this.noItems = true;
							}
							else if (this.buffType[m] == 24)
							{
								this.onFire = true;
							}
							else if (this.buffType[m] == 39)
							{
								this.onFire2 = true;
							}
							else if (this.buffType[m] == 29)
							{
								this.magicCrit += 2;
								this.magicDamage += 0.05f;
								this.statManaMax2 += 20;
								this.manaCost -= 0.02f;
							}
							else if (this.buffType[m] == 28)
							{
								if (!Main.dayTime && Main.moonPhase == 0 && this.wolfAcc && !this.merman)
								{
									this.wereWolf = true;
									this.meleeCrit++;
									this.meleeDamage += 0.051f;
									this.meleeSpeed += 0.051f;
									this.statDefense++;
									this.moveSpeed += 0.05f;
								}
								else
								{
									this.DelBuff(m);
								}
							}
							else if (this.buffType[m] == 33)
							{
								this.meleeDamage -= 0.051f;
								this.meleeSpeed -= 0.051f;
								this.statDefense -= 4;
								this.moveSpeed -= 0.1f;
							}
							else if (this.buffType[m] == 25)
							{
								this.statDefense -= 4;
								this.meleeCrit += 2;
								this.meleeDamage += 0.1f;
								this.meleeSpeed += 0.1f;
							}
							else if (this.buffType[m] == 26)
							{
								this.statDefense++;
								this.meleeCrit++;
								this.meleeDamage += 0.05f;
								this.meleeSpeed += 0.05f;
								this.magicCrit++;
								this.magicDamage += 0.05f;
								this.rangedCrit++;
								this.magicDamage += 0.05f;
								this.moveSpeed += 0.1f;
							}
						}
					}
					if (this.accMerman && this.wet && !this.lavaWet)
					{
						this.releaseJump = true;
						this.wings = 0;
						this.merman = true;
						this.accFlipper = true;
						this.AddBuff(34, 2, true);
					}
					else
					{
						this.merman = false;
					}
					this.accMerman = false;
					if (this.wolfAcc && !this.merman && !Main.dayTime && Main.moonPhase == 0 && !this.wereWolf)
					{
						this.AddBuff(28, 60, true);
					}
					this.wolfAcc = false;
					if (this.whoAmi == Main.myPlayer)
					{
						for (int num26 = 0; num26 < 10; num26++)
						{
							if (this.buffType[num26] > 0 && this.buffTime[num26] <= 0)
							{
								this.DelBuff(num26);
							}
						}
					}
					this.doubleJump = false;
					for (int num27 = 0; num27 < 8; num27++)
					{
						this.statDefense += this.armor[num27].defense;
						this.lifeRegen += this.armor[num27].lifeRegen;
						if (this.armor[num27].type == 238)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num27].type == 123 || this.armor[num27].type == 124 || this.armor[num27].type == 125)
						{
							this.magicDamage += 0.05f;
						}
						if (this.armor[num27].type == 151 || this.armor[num27].type == 152 || this.armor[num27].type == 153)
						{
							this.rangedDamage += 0.05f;
						}
						if (this.armor[num27].type == 111 || this.armor[num27].type == 228 || this.armor[num27].type == 229 || this.armor[num27].type == 230)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num27].type == 228 || this.armor[num27].type == 229 || this.armor[num27].type == 230)
						{
							this.magicCrit += 3;
						}
						if (this.armor[num27].type == 100 || this.armor[num27].type == 101 || this.armor[num27].type == 102)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num27].type == 371)
						{
							this.magicCrit += 9;
							this.statManaMax2 += 40;
						}
						if (this.armor[num27].type == 372)
						{
							this.moveSpeed += 0.07f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num27].type == 373)
						{
							this.rangedDamage += 0.1f;
							this.rangedCrit += 6;
						}
						if (this.armor[num27].type == 374)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num27].type == 375)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num27].type == 376)
						{
							this.magicDamage += 0.15f;
							this.statManaMax2 += 60;
						}
						if (this.armor[num27].type == 377)
						{
							this.meleeCrit += 5;
							this.meleeDamage += 0.1f;
						}
						if (this.armor[num27].type == 378)
						{
							this.rangedDamage += 0.12f;
							this.rangedCrit += 7;
						}
						if (this.armor[num27].type == 379)
						{
							this.rangedDamage += 0.05f;
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
						}
						if (this.armor[num27].type == 380)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num27].type == 268)
						{
							this.accDivingHelm = true;
						}
						if (this.armor[num27].type == 400)
						{
							this.magicDamage += 0.11f;
							this.magicCrit += 11;
							this.statManaMax2 += 80;
						}
						if (this.armor[num27].type == 401)
						{
							this.meleeCrit += 7;
							this.meleeDamage += 0.14f;
						}
						if (this.armor[num27].type == 402)
						{
							this.rangedDamage += 0.14f;
							this.rangedCrit += 8;
						}
						if (this.armor[num27].type == 403)
						{
							this.rangedDamage += 0.06f;
							this.meleeDamage += 0.06f;
							this.magicDamage += 0.06f;
						}
						if (this.armor[num27].type == 404)
						{
							this.magicCrit += 4;
							this.meleeCrit += 4;
							this.rangedCrit += 4;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num27].type == 558)
						{
							this.magicDamage += 0.12f;
							this.magicCrit += 12;
							this.statManaMax2 += 100;
						}
						if (this.armor[num27].type == 559)
						{
							this.meleeCrit += 10;
							this.meleeDamage += 0.1f;
							this.meleeSpeed += 0.1f;
						}
						if (this.armor[num27].type == 553)
						{
							this.rangedDamage += 0.15f;
							this.rangedCrit += 8;
						}
						if (this.armor[num27].type == 551)
						{
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num27].type == 552)
						{
							this.rangedDamage += 0.07f;
							this.meleeDamage += 0.07f;
							this.magicDamage += 0.07f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num27].prefix == 62)
						{
							this.statDefense++;
						}
						if (this.armor[num27].prefix == 63)
						{
							this.statDefense += 2;
						}
						if (this.armor[num27].prefix == 64)
						{
							this.statDefense += 3;
						}
						if (this.armor[num27].prefix == 65)
						{
							this.statDefense += 4;
						}
						if (this.armor[num27].prefix == 66)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num27].prefix == 67)
						{
							this.meleeCrit++;
							this.rangedCrit++;
							this.magicCrit++;
						}
						if (this.armor[num27].prefix == 68)
						{
							this.meleeCrit += 2;
							this.rangedCrit += 2;
							this.magicCrit += 2;
						}
						if (this.armor[num27].prefix == 69)
						{
							this.meleeDamage += 0.01f;
							this.rangedDamage += 0.01f;
							this.magicDamage += 0.01f;
						}
						if (this.armor[num27].prefix == 70)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
						}
						if (this.armor[num27].prefix == 71)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
						}
						if (this.armor[num27].prefix == 72)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
						}
						if (this.armor[num27].prefix == 73)
						{
							this.moveSpeed += 0.01f;
						}
						if (this.armor[num27].prefix == 74)
						{
							this.moveSpeed += 0.02f;
						}
						if (this.armor[num27].prefix == 75)
						{
							this.moveSpeed += 0.03f;
						}
						if (this.armor[num27].prefix == 76)
						{
							this.moveSpeed += 0.04f;
						}
						if (this.armor[num27].prefix == 77)
						{
							this.meleeSpeed += 0.01f;
						}
						if (this.armor[num27].prefix == 78)
						{
							this.meleeSpeed += 0.02f;
						}
						if (this.armor[num27].prefix == 79)
						{
							this.meleeSpeed += 0.03f;
						}
						if (this.armor[num27].prefix == 80)
						{
							this.meleeSpeed += 0.04f;
						}
					}
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					for (int num28 = 3; num28 < 8; num28++)
					{
						if (this.armor[num28].type == 15 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num28].type == 16 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num28].type == 17 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num28].type == 18 && this.accDepthMeter < 1)
						{
							this.accDepthMeter = 1;
						}
						if (this.armor[num28].type == 53)
						{
							this.doubleJump = true;
						}
						if (this.armor[num28].type == 54)
						{
							num6 = 6f;
						}
						if (this.armor[num28].type == 128)
						{
							this.rocketBoots = 1;
						}
						if (this.armor[num28].type == 156)
						{
							this.noKnockback = true;
						}
						if (this.armor[num28].type == 158)
						{
							this.noFallDmg = true;
						}
						if (this.armor[num28].type == 159)
						{
							this.jumpBoost = true;
						}
						if (this.armor[num28].type == 187)
						{
							this.accFlipper = true;
						}
						if (this.armor[num28].type == 211)
						{
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num28].type == 223)
						{
							this.manaCost -= 0.06f;
						}
						if (this.armor[num28].type == 285)
						{
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num28].type == 212)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num28].type == 267)
						{
							this.killGuide = true;
						}
						if (this.armor[num28].type == 193)
						{
							this.fireWalk = true;
						}
						if (this.armor[num28].type == 485)
						{
							this.wolfAcc = true;
						}
						if (this.armor[num28].type == 486)
						{
							this.rulerAcc = true;
						}
						if (this.armor[num28].type == 393)
						{
							this.accCompass = 1;
						}
						if (this.armor[num28].type == 394)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
						}
						if (this.armor[num28].type == 395)
						{
							this.accWatch = 3;
							this.accDepthMeter = 1;
							this.accCompass = 1;
						}
						if (this.armor[num28].type == 396)
						{
							this.noFallDmg = true;
							this.fireWalk = true;
						}
						if (this.armor[num28].type == 397)
						{
							this.noKnockback = true;
							this.fireWalk = true;
						}
						if (this.armor[num28].type == 399)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
						}
						if (this.armor[num28].type == 405)
						{
							num6 = 6f;
							this.rocketBoots = 2;
						}
						if (this.armor[num28].type == 407)
						{
							this.blockRange = 1;
						}
						if (this.armor[num28].type == 489)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num28].type == 490)
						{
							this.meleeDamage += 0.15f;
						}
						if (this.armor[num28].type == 491)
						{
							this.rangedDamage += 0.15f;
						}
						if (this.armor[num28].type == 492)
						{
							this.wings = 1;
						}
						if (this.armor[num28].type == 493)
						{
							this.wings = 2;
						}
						if (this.armor[num28].type == 497)
						{
							this.accMerman = true;
						}
						if (this.armor[num28].type == 535)
						{
							this.pStone = true;
						}
						if (this.armor[num28].type == 536)
						{
							this.kbGlove = true;
						}
						if (this.armor[num28].type == 532)
						{
							this.starCloak = true;
						}
						if (this.armor[num28].type == 554)
						{
							this.longInvince = true;
						}
						if (this.armor[num28].type == 555)
						{
							this.manaFlower = true;
							this.manaCost -= 0.08f;
						}
						if (Main.myPlayer == this.whoAmi)
						{
							if (this.armor[num28].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0)
							{
								int num29 = 0;
								if (Main.curMusic == 1)
								{
									num29 = 0;
								}
								if (Main.curMusic == 2)
								{
									num29 = 1;
								}
								if (Main.curMusic == 3)
								{
									num29 = 2;
								}
								if (Main.curMusic == 4)
								{
									num29 = 4;
								}
								if (Main.curMusic == 5)
								{
									num29 = 5;
								}
								if (Main.curMusic == 7)
								{
									num29 = 6;
								}
								if (Main.curMusic == 8)
								{
									num29 = 7;
								}
								if (Main.curMusic == 9)
								{
									num29 = 9;
								}
								if (Main.curMusic == 10)
								{
									num29 = 8;
								}
								if (Main.curMusic == 11)
								{
									num29 = 11;
								}
								if (Main.curMusic == 12)
								{
									num29 = 10;
								}
								if (Main.curMusic == 13)
								{
									num29 = 12;
								}
								this.armor[num28].SetDefaults(num29 + 562, false);
							}
							if (this.armor[num28].type >= 562 && this.armor[num28].type <= 574)
							{
								Main.musicBox2 = this.armor[num28].type - 562;
							}
						}
					}
					if (this.head == 11)
					{
						int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
						int j2 = (int)(this.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
					}
					this.setBonus = "";
					if ((this.head == 1 && this.body == 1 && this.legs == 1) || (this.head == 2 && this.body == 2 && this.legs == 2))
					{
						this.setBonus = "2点防御加成";
						this.statDefense += 2;
					}
					if ((this.head == 3 && this.body == 3 && this.legs == 3) || (this.head == 4 && this.body == 4 && this.legs == 4))
					{
						this.setBonus = "3点防御加成";
						this.statDefense += 3;
					}
					if (this.head == 5 && this.body == 5 && this.legs == 5)
					{
						this.setBonus = "提高15%移动速度";
						this.moveSpeed += 0.15f;
					}
					if (this.head == 6 && this.body == 6 && this.legs == 6)
					{
						this.setBonus = "使用空间枪免魔耗";
						this.spaceGun = true;
					}
					if (this.head == 7 && this.body == 7 && this.legs == 7)
					{
						this.setBonus = "20%几率不消耗弹药";
						this.ammoCost80 = true;
					}
					if (this.head == 8 && this.body == 8 && this.legs == 8)
					{
						this.setBonus = "减少16%魔力消耗";
						this.manaCost -= 0.16f;
					}
					if (this.head == 9 && this.body == 9 && this.legs == 9)
					{
						this.setBonus = "增加17%近战伤害";
						this.meleeDamage += 0.17f;
					}
					if (this.head == 11 && this.body == 20 && this.legs == 19)
					{
						this.setBonus = "增加20%挖掘速度 ";
						this.pickSpeed = 0.8f;
					}
					if (this.body == 17 && this.legs == 16)
					{
						if (this.head == 29)
						{
							this.setBonus = "减少14%魔力消耗";
							this.manaCost -= 0.14f;
						}
						else if (this.head == 30)
						{
							this.setBonus = "增加15%近战攻速";
							this.meleeSpeed += 0.15f;
						}
						else if (this.head == 31)
						{
							this.setBonus = "20%几率不消耗弹药";
							this.ammoCost80 = true;
						}
					}
					if (this.body == 18 && this.legs == 17)
					{
						if (this.head == 32)
						{
							this.setBonus = "减少17%魔力消耗";
							this.manaCost -= 0.17f;
						}
						else if (this.head == 33)
						{
							this.setBonus = "增加5%近战暴击率";
							this.meleeCrit += 5;
						}
						else if (this.head == 34)
						{
							this.setBonus = "20%几率不消耗弹药";
							this.ammoCost80 = true;
						}
					}
					if (this.body == 19 && this.legs == 18)
					{
						if (this.head == 35)
						{
							this.setBonus = "减少19%魔力消耗";
							this.manaCost -= 0.19f;
						}
						else if (this.head == 36)
						{
							this.setBonus = "增加18%近战攻速和移动速度";
							this.meleeSpeed += 0.18f;
							this.moveSpeed += 0.18f;
						}
						else if (this.head == 37)
						{
							this.setBonus = "25%几率不消耗弹药";
							this.ammoCost75 = true;
						}
					}
					if (this.body == 24 && this.legs == 23)
					{
						if (this.head == 42)
						{
							this.setBonus = "减少20%魔力消耗";
							this.manaCost -= 0.2f;
						}
						else if (this.head == 43)
						{
							this.setBonus = "增加19%近战攻速和移动速度";
							this.meleeSpeed += 0.19f;
							this.moveSpeed += 0.19f;
						}
						else if (this.head == 41)
						{
							this.setBonus = "25%几率不消耗弹药";
							this.ammoCost75 = true;
						}
					}
					if (this.merman)
					{
						this.wings = 0;
					}
					if (this.meleeSpeed > 4f)
					{
						this.meleeSpeed = 4f;
					}
					if ((double)this.moveSpeed > 1.4)
					{
						this.moveSpeed = 1.4f;
					}
					if (this.slow)
					{
						this.moveSpeed *= 0.5f;
					}
					if (this.statManaMax2 > 400)
					{
						this.statManaMax2 = 400;
					}
					if (this.statDefense < 0)
					{
						this.statDefense = 0;
					}
					this.meleeSpeed = 1f / this.meleeSpeed;
					if (this.poisoned)
					{
						this.lifeRegenTime = 0;
						this.lifeRegen = -4;
					}
					if (this.onFire)
					{
						this.lifeRegenTime = 0;
						this.lifeRegen = -8;
					}
					if (this.onFire2)
					{
						this.lifeRegenTime = 0;
						this.lifeRegen = -8;
					}
					this.lifeRegenTime++;
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num30 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num30 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num30 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num30 *= 1.25f;
					}
					else
					{
						num30 *= 0.5f;
					}
					float num31 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num30 *= num31;
					this.lifeRegen += (int)Math.Round((double)num30);
					this.lifeRegenCount += this.lifeRegen;
					while (this.lifeRegenCount >= 120)
					{
						this.lifeRegenCount -= 120;
						if (this.statLife < this.statLifeMax)
						{
							this.statLife++;
						}
						if (this.statLife > this.statLifeMax)
						{
							this.statLife = this.statLifeMax;
						}
					}
					while (this.lifeRegenCount <= -120)
					{
						this.lifeRegenCount += 120;
						this.statLife--;
						if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
						{
							if (this.poisoned)
							{
								this.KillMe(10.0, 0, false, " 没能找到解毒药剂...");
							}
							else if (this.onFire)
							{
								this.KillMe(10.0, 0, false, " 没能扑灭身上的火焰...");
							}
							else if (this.onFire2)
							{
								this.KillMe(10.0, 0, false, " 没能扑灭身上的火焰...");
							}
						}
					}
					if (this.manaRegenDelay > 0 && !this.channel)
					{
						this.manaRegenDelay--;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegenDelay--;
						}
					}
					if (this.manaRegenBuff && this.manaRegenDelay > 20)
					{
						this.manaRegenDelay = 20;
					}
					if (this.manaRegenDelay <= 0)
					{
						this.manaRegenDelay = 0;
						this.manaRegen = this.statManaMax2 / 7 + 1;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegen += this.statManaMax2 / 2;
						}
						float num32 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num32 = 1f;
						}
						this.manaRegen = (int)((float)this.manaRegen * num32);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag8 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag8 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag8)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num33 = 0; num33 < 5; num33++)
								{
									Vector2 vector = this.position;
									int num34 = this.width;
									int num35 = this.height;
									int type3 = 45;
									float speedX = 0f;
									float speedY = 0f;
									int alpha = 255;
									int num36 = Dust.NewDust(vector, num34, num35, type3, speedX, speedY, alpha, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num36].noLight = true;
									Main.dust[num36].noGravity = true;
									Dust dust = Main.dust[num36];
									dust.velocity *= 0.5f;
								}
							}
							this.statMana = this.statManaMax2;
						}
					}
					if (this.manaRegenCount < 0)
					{
						this.manaRegenCount = 0;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					num4 *= this.moveSpeed;
					num3 *= this.moveSpeed;
					if (this.jumpBoost)
					{
						Player.jumpHeight = 20;
						Player.jumpSpeed = 6.51f;
					}
					if (this.wereWolf)
					{
						Player.jumpHeight += 2;
						Player.jumpSpeed += 0.2f;
					}
					if (this.brokenArmor)
					{
						this.statDefense /= 2;
					}
					if (!this.doubleJump)
					{
						this.jumpAgain = false;
					}
					else if (this.velocity.Y == 0f)
					{
						this.jumpAgain = true;
					}
					if (this.grappling[0] == -1 && !this.tongued)
					{
						if (this.controlLeft && this.velocity.X > -num3)
						{
							if (this.velocity.X > num5)
							{
								this.velocity.X = this.velocity.X - num5;
							}
							this.velocity.X = this.velocity.X - num4;
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = -1;
							}
						}
						else if (this.controlRight && this.velocity.X < num3)
						{
							if (this.velocity.X < -num5)
							{
								this.velocity.X = this.velocity.X + num5;
							}
							this.velocity.X = this.velocity.X + num4;
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = 1;
							}
						}
						else if (this.controlLeft && this.velocity.X > -num6)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = -1;
							}
							if (this.velocity.Y == 0f || this.wings > 0)
							{
								if (this.velocity.X > num5)
								{
									this.velocity.X = this.velocity.X - num5;
								}
								this.velocity.X = this.velocity.X - num4 * 0.2f;
							}
							if (this.velocity.X < -(num6 + num3) / 2f && this.velocity.Y == 0f)
							{
								int num37 = 0;
								if (this.gravDir == -1f)
								{
									num37 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								Vector2 vector2 = new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num37);
								int num38 = this.width + 8;
								int num39 = 4;
								int type4 = 16;
								float speedX2 = -this.velocity.X * 0.5f;
								float speedY2 = this.velocity.Y * 0.5f;
								int alpha2 = 50;
								Color newColor = default(Color);
								int num40 = Dust.NewDust(vector2, num38, num39, type4, speedX2, speedY2, alpha2, newColor, 1.5f);
								Main.dust[num40].velocity.X = Main.dust[num40].velocity.X * 0.2f;
								Main.dust[num40].velocity.Y = Main.dust[num40].velocity.Y * 0.2f;
							}
						}
						else if (this.controlRight && this.velocity.X < num6)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = 1;
							}
							if (this.velocity.Y == 0f || this.wings > 0)
							{
								if (this.velocity.X < -num5)
								{
									this.velocity.X = this.velocity.X + num5;
								}
								this.velocity.X = this.velocity.X + num4 * 0.2f;
							}
							if (this.velocity.X > (num6 + num3) / 2f && this.velocity.Y == 0f)
							{
								int num41 = 0;
								if (this.gravDir == -1f)
								{
									num41 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								Vector2 vector3 = new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num41);
								int num42 = this.width + 8;
								int num43 = 4;
								int type5 = 16;
								float speedX3 = -this.velocity.X * 0.5f;
								float speedY3 = this.velocity.Y * 0.5f;
								int alpha3 = 50;
								Color newColor = default(Color);
								int num44 = Dust.NewDust(vector3, num42, num43, type5, speedX3, speedY3, alpha3, newColor, 1.5f);
								Main.dust[num44].velocity.X = Main.dust[num44].velocity.X * 0.2f;
								Main.dust[num44].velocity.Y = Main.dust[num44].velocity.Y * 0.2f;
							}
						}
						else if (this.velocity.Y == 0f)
						{
							if (this.velocity.X > num5)
							{
								this.velocity.X = this.velocity.X - num5;
							}
							else if (this.velocity.X < -num5)
							{
								this.velocity.X = this.velocity.X + num5;
							}
							else
							{
								this.velocity.X = 0f;
							}
						}
						else if ((double)this.velocity.X > (double)num5 * 0.5)
						{
							this.velocity.X = this.velocity.X - num5 * 0.5f;
						}
						else if ((double)this.velocity.X < -(double)num5 * 0.5)
						{
							this.velocity.X = this.velocity.X + num5 * 0.5f;
						}
						else
						{
							this.velocity.X = 0f;
						}
						if (this.gravControl)
						{
							if (this.controlUp && this.gravDir == 1f)
							{
								this.gravDir = -1f;
								this.fallStart = (int)(this.position.Y / 16f);
								this.jump = 0;
								Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
							}
							if (this.controlDown && this.gravDir == -1f)
							{
								this.gravDir = 1f;
								this.fallStart = (int)(this.position.Y / 16f);
								this.jump = 0;
								Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
							}
						}
						else
						{
							this.gravDir = 1f;
						}
						if (this.controlJump)
						{
							if (this.jump > 0)
							{
								if (this.velocity.Y == 0f)
								{
									if (this.merman)
									{
										this.jump = 10;
									}
									this.jump = 0;
								}
								else
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									if (this.merman)
									{
										if (this.swimTime <= 10)
										{
											this.swimTime = 30;
										}
									}
									else
									{
										this.jump--;
									}
								}
							}
							else if ((this.velocity.Y == 0f || this.jumpAgain || (this.wet && this.accFlipper)) && this.releaseJump)
							{
								bool flag9 = false;
								if (this.wet && this.accFlipper)
								{
									if (this.swimTime == 0)
									{
										this.swimTime = 30;
									}
									flag9 = true;
								}
								this.jumpAgain = false;
								this.canRocket = false;
								this.rocketRelease = false;
								if (this.velocity.Y == 0f && this.doubleJump)
								{
									this.jumpAgain = true;
								}
								if (this.velocity.Y == 0f || flag9)
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight;
								}
								else
								{
									int num45 = this.height;
									if (this.gravDir == -1f)
									{
										num45 = 0;
									}
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight / 2;
									for (int num46 = 0; num46 < 10; num46++)
									{
										Vector2 vector4 = new Vector2(this.position.X - 34f, this.position.Y + (float)num45 - 16f);
										int num47 = 102;
										int num48 = 32;
										int type6 = 16;
										float speedX4 = -this.velocity.X * 0.5f;
										float speedY4 = this.velocity.Y * 0.5f;
										int alpha4 = 100;
										Color newColor = default(Color);
										int num49 = Dust.NewDust(vector4, num47, num48, type6, speedX4, speedY4, alpha4, newColor, 1.5f);
										Main.dust[num49].velocity.X = Main.dust[num49].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num49].velocity.Y = Main.dust[num49].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num50 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num45 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num50].velocity.X = Main.gore[num50].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num50].velocity.Y = Main.gore[num50].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num50 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num45 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num50].velocity.X = Main.gore[num50].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num50].velocity.Y = Main.gore[num50].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num50 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num45 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num50].velocity.X = Main.gore[num50].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num50].velocity.Y = Main.gore[num50].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
								}
							}
							this.releaseJump = false;
						}
						else
						{
							this.jump = 0;
							this.releaseJump = true;
							this.rocketRelease = true;
						}
						if (this.doubleJump && !this.jumpAgain && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)) && this.rocketBoots == 0 && !this.accFlipper)
						{
							int num51 = this.height;
							if (this.gravDir == -1f)
							{
								num51 = -6;
							}
							Vector2 vector5 = new Vector2(this.position.X - 4f, this.position.Y + (float)num51);
							int num52 = this.width + 8;
							int num53 = 4;
							int type7 = 16;
							float speedX5 = -this.velocity.X * 0.5f;
							float speedY5 = this.velocity.Y * 0.5f;
							int alpha5 = 100;
							Color newColor = default(Color);
							int num54 = Dust.NewDust(vector5, num52, num53, type7, speedX5, speedY5, alpha5, newColor, 1.5f);
							Main.dust[num54].velocity.X = Main.dust[num54].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num54].velocity.Y = Main.dust[num54].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
						}
						if (((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed) || (this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed)) && this.velocity.Y != 0f)
						{
							this.canRocket = true;
						}
						bool flag10 = false;
						if (this.velocity.Y == 0f)
						{
							this.wingTime = 90;
						}
						if (this.wings > 0 && this.controlJump && this.wingTime > 0 && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
						{
							flag10 = true;
						}
						if (flag10)
						{
							this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
							if (this.gravDir == 1f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - 0.5f;
								}
								else if ((double)this.velocity.Y > -(double)Player.jumpSpeed * 0.5)
								{
									this.velocity.Y = this.velocity.Y - 0.1f;
								}
								if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
								{
									this.velocity.Y = -Player.jumpSpeed * 1.5f;
								}
							}
							else
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + 0.5f;
								}
								else if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
								{
									this.velocity.Y = this.velocity.Y + 0.1f;
								}
								if (this.velocity.Y > Player.jumpSpeed * 1.5f)
								{
									this.velocity.Y = Player.jumpSpeed * 1.5f;
								}
							}
							this.wingTime--;
						}
						if (flag10 || this.jump > 0)
						{
							this.wingFrameCounter++;
							if (this.wingFrameCounter > 4)
							{
								this.wingFrame++;
								this.wingFrameCounter = 0;
								if (this.wingFrame >= 4)
								{
									this.wingFrame = 0;
								}
							}
						}
						else if (this.velocity.Y != 0f)
						{
							this.wingFrame = 1;
						}
						else
						{
							this.wingFrame = 0;
						}
						if (this.wings > 0 && this.rocketBoots > 0)
						{
							this.wingTime += this.rocketTime * 10;
							this.rocketTime = 0;
						}
						if (flag10)
						{
							if (this.wingFrame == 3)
							{
								if (!this.flapSound)
								{
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 32);
								}
								this.flapSound = true;
							}
							else
							{
								this.flapSound = false;
							}
						}
						if (this.velocity.Y == 0f)
						{
							this.rocketTime = this.rocketTimeMax;
						}
						if ((this.wingTime == 0 || this.wings == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
						{
							if (this.rocketTime > 0)
							{
								this.rocketTime--;
								this.rocketDelay = 10;
								if (this.rocketDelay2 <= 0)
								{
									if (this.rocketBoots == 1)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
										this.rocketDelay2 = 30;
									}
									else if (this.rocketBoots == 2)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 24);
										this.rocketDelay2 = 15;
									}
								}
							}
							else
							{
								this.canRocket = false;
							}
						}
						if (this.rocketDelay2 > 0)
						{
							this.rocketDelay2--;
						}
						if (this.rocketDelay == 0)
						{
							this.rocketFrame = false;
						}
						if (this.rocketDelay > 0)
						{
							int num55 = this.height;
							if (this.gravDir == -1f)
							{
								num55 = 4;
							}
							this.rocketFrame = true;
							for (int num56 = 0; num56 < 2; num56++)
							{
								int num57 = 6;
								float scale = 2.5f;
								int num58 = 100;
								if (this.rocketBoots == 2)
								{
									num57 = 16;
									scale = 1.5f;
									num58 = 20;
								}
								else if (this.socialShadow)
								{
									num57 = 27;
									scale = 1.5f;
								}
								if (num56 == 0)
								{
									Vector2 vector6 = new Vector2(this.position.X - 4f, this.position.Y + (float)num55 - 10f);
									int num59 = 8;
									int num60 = 8;
									int type8 = num57;
									float speedX6 = 0f;
									float speedY6 = 0f;
									int alpha6 = num58;
									Color newColor = default(Color);
									int num61 = Dust.NewDust(vector6, num59, num60, type8, speedX6, speedY6, alpha6, newColor, scale);
									if (this.rocketBoots == 1)
									{
										Main.dust[num61].noGravity = true;
									}
									Main.dust[num61].velocity.X = Main.dust[num61].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
									Main.dust[num61].velocity.Y = Main.dust[num61].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
									if (this.rocketBoots == 2)
									{
										Dust dust2 = Main.dust[num61];
										dust2.velocity *= 0.1f;
									}
								}
								else
								{
									Vector2 vector7 = new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num55 - 10f);
									int num62 = 8;
									int num63 = 8;
									int type9 = num57;
									float speedX7 = 0f;
									float speedY7 = 0f;
									int alpha7 = num58;
									Color newColor = default(Color);
									int num64 = Dust.NewDust(vector7, num62, num63, type9, speedX7, speedY7, alpha7, newColor, scale);
									if (this.rocketBoots == 1)
									{
										Main.dust[num64].noGravity = true;
									}
									Main.dust[num64].velocity.X = Main.dust[num64].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
									Main.dust[num64].velocity.Y = Main.dust[num64].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
									if (this.rocketBoots == 2)
									{
										Dust dust3 = Main.dust[num64];
										dust3.velocity *= 0.1f;
									}
								}
							}
							if (this.rocketDelay == 0)
							{
								this.releaseJump = true;
							}
							this.rocketDelay--;
							this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
							if (this.gravDir == 1f)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - 0.5f;
								}
								else if ((double)this.velocity.Y > -(double)Player.jumpSpeed * 0.5)
								{
									this.velocity.Y = this.velocity.Y - 0.1f;
								}
								if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
								{
									this.velocity.Y = -Player.jumpSpeed * 1.5f;
								}
							}
							else
							{
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + 0.5f;
								}
								else if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
								{
									this.velocity.Y = this.velocity.Y + 0.1f;
								}
								if (this.velocity.Y > Player.jumpSpeed * 1.5f)
								{
									this.velocity.Y = Player.jumpSpeed * 1.5f;
								}
							}
						}
						else if (!flag10)
						{
							if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlUp && this.gravDir == -1f)))
							{
								if ((this.controlUp && this.gravDir == 1f) || (this.controlDown && this.gravDir == -1f))
								{
									this.velocity.Y = this.velocity.Y + num2 / 10f * this.gravDir;
								}
								else
								{
									this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
								}
							}
							else if (this.wings > 0 && this.controlJump && this.velocity.Y > 0f)
							{
								this.fallStart = (int)(this.position.Y / 16f);
								if (this.velocity.Y > 0f)
								{
									this.wingFrame = 2;
								}
								this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
								if (this.gravDir == 1f)
								{
									if (this.velocity.Y > num / 3f && !this.controlDown)
									{
										this.velocity.Y = num / 3f;
									}
								}
								else if (this.velocity.Y < -num / 3f && !this.controlUp)
								{
									this.velocity.Y = -num / 3f;
								}
							}
							else
							{
								this.velocity.Y = this.velocity.Y + num2 * this.gravDir;
							}
						}
						if (this.gravDir == 1f)
						{
							if (this.velocity.Y > num)
							{
								this.velocity.Y = num;
							}
							if (this.slowFall && this.velocity.Y > num / 3f && !this.controlDown)
							{
								this.velocity.Y = num / 3f;
							}
							if (this.slowFall && this.velocity.Y > num / 5f && this.controlUp)
							{
								this.velocity.Y = num / 10f;
							}
						}
						else
						{
							if (this.velocity.Y < -num)
							{
								this.velocity.Y = -num;
							}
							if (this.slowFall && this.velocity.Y < -num / 3f && !this.controlUp)
							{
								this.velocity.Y = -num / 3f;
							}
							if (this.slowFall && this.velocity.Y < -num / 5f && this.controlDown)
							{
								this.velocity.Y = -num / 10f;
							}
						}
					}
					for (int num65 = 0; num65 < 200; num65++)
					{
						if (Main.item[num65].active && Main.item[num65].noGrabDelay == 0 && Main.item[num65].owner == i)
						{
							Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							if (rectangle.Intersects(new Rectangle((int)Main.item[num65].position.X, (int)Main.item[num65].position.Y, Main.item[num65].width, Main.item[num65].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num65].type == 58)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statLife += 20;
										if (Main.myPlayer == this.whoAmi)
										{
											this.HealEffect(20);
										}
										if (this.statLife > this.statLifeMax)
										{
											this.statLife = this.statLifeMax;
										}
										Main.item[num65] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num65, 0f, 0f, 0f, 0);
										}
									}
									else if (Main.item[num65].type == 184)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statMana += 100;
										if (Main.myPlayer == this.whoAmi)
										{
											this.ManaEffect(100);
										}
										if (this.statMana > this.statManaMax2)
										{
											this.statMana = this.statManaMax2;
										}
										Main.item[num65] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num65, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										Main.item[num65] = this.GetItem(i, Main.item[num65]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num65, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else
							{
								rectangle = new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2);
								if (rectangle.Intersects(new Rectangle((int)Main.item[num65].position.X, (int)Main.item[num65].position.Y, Main.item[num65].width, Main.item[num65].height)) && this.ItemSpace(Main.item[num65]))
								{
									Main.item[num65].beingGrabbed = true;
									if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num65].position.X + (double)Main.item[num65].width * 0.5)
									{
										if (Main.item[num65].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item item = Main.item[num65];
											item.velocity.X = item.velocity.X + Player.itemGrabSpeed;
										}
										if (Main.item[num65].velocity.X < 0f)
										{
											Item item2 = Main.item[num65];
											item2.velocity.X = item2.velocity.X + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num65].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item item3 = Main.item[num65];
											item3.velocity.X = item3.velocity.X - Player.itemGrabSpeed;
										}
										if (Main.item[num65].velocity.X > 0f)
										{
											Item item4 = Main.item[num65];
											item4.velocity.X = item4.velocity.X - Player.itemGrabSpeed * 0.75f;
										}
									}
									if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num65].position.Y + (double)Main.item[num65].height * 0.5)
									{
										if (Main.item[num65].velocity.Y < Player.itemGrabSpeedMax)
										{
											Item item5 = Main.item[num65];
											item5.velocity.Y = item5.velocity.Y + Player.itemGrabSpeed;
										}
										if (Main.item[num65].velocity.Y < 0f)
										{
											Item item6 = Main.item[num65];
											item6.velocity.Y = item6.velocity.Y + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num65].velocity.Y > -Player.itemGrabSpeedMax)
										{
											Item item7 = Main.item[num65];
											item7.velocity.Y = item7.velocity.Y - Player.itemGrabSpeed;
										}
										if (Main.item[num65].velocity.Y > 0f)
										{
											Item item8 = Main.item[num65];
											item8.velocity.Y = item8.velocity.Y - Player.itemGrabSpeed * 0.75f;
										}
									}
								}
							}
						}
					}
					if (this.position.X / 16f - (float)Player.tileRangeX <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)Player.tileTargetY)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
						{
							Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 359;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 224;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
								{
									this.showItemIcon2 = 348;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
								{
									this.showItemIcon2 = 343;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 144)
								{
									this.showItemIcon2 = 329;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 108)
								{
									this.showItemIcon2 = 328;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
								{
									this.showItemIcon2 = 327;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 36)
								{
									this.showItemIcon2 = 306;
								}
								else
								{
									this.showItemIcon2 = 48;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								int num66 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num66 == 0)
								{
									this.showItemIcon2 = 8;
								}
								else if (num66 == 8)
								{
									this.showItemIcon2 = 523;
								}
								else
								{
									this.showItemIcon2 = 426 + num66;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 72)
								{
									this.showItemIcon2 = 351;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
								{
									this.showItemIcon2 = 350;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18)
								{
									this.showItemIcon2 = 28;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 36)
								{
									this.showItemIcon2 = 110;
								}
								else
								{
									this.showItemIcon2 = 31;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 87;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 346;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 105;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 148;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50)
							{
								this.noThrow = 2;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90)
								{
									this.showItemIcon = true;
									this.showItemIcon2 = 165;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
							{
								this.noThrow = 2;
								int num67 = Player.tileTargetX;
								int num68 = Player.tileTargetY;
								int num69 = 0;
								for (int num70 = (int)(Main.tile[num67, num68].frameY / 18); num70 >= 2; num70 -= 2)
								{
									num69++;
								}
								this.showItemIcon = true;
								this.showItemIcon2 = 562 + num69;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
							{
								this.noThrow = 2;
								int num71 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
								int num72 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
								while (num71 > 1)
								{
									num71 -= 2;
								}
								int num73 = Player.tileTargetX - num71;
								int num74 = Player.tileTargetY - num72;
								Main.signBubble = true;
								Main.signX = num73 * 16 + 16;
								Main.signY = num74 * 16;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 25;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 487;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 513;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 538;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = (int)(583 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128)
							{
								this.noThrow = 2;
								int num75 = Player.tileTargetX;
								int num76 = Player.tileTargetY;
								int num77;
								for (num77 = (int)Main.tile[num75, num76].frameX; num77 >= 100; num77 -= 100)
								{
								}
								while (num77 >= 36)
								{
									num77 -= 36;
								}
								if (num77 == 18)
								{
									num75--;
								}
								int num78 = (int)Main.tile[num75, num76].frameX;
								if (num78 >= 100)
								{
									int num79 = 0;
									while (num78 >= 100)
									{
										num78 -= 100;
										num79++;
									}
									this.showItemIcon = true;
									int num80 = (int)(Main.tile[num75, num76].frameY / 18);
									if (num80 == 0)
									{
										this.showItemIcon2 = Item.headType[num79];
									}
									if (num80 == 1)
									{
										this.showItemIcon2 = Item.bodyType[num79];
									}
									if (num80 == 2)
									{
										this.showItemIcon2 = Item.legType[num79];
									}
								}
							}
							if (this.controlUseTile)
							{
								if (this.releaseUseTile)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
									{
										WorldGen.hitSwitch(Player.tileTargetX, Player.tileTargetY);
										NetMessage.SendData(59, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
									{
										Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
										WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128)
									{
										int num81 = Player.tileTargetX;
										int num82 = Player.tileTargetY;
										int num83;
										for (num83 = (int)Main.tile[num81, num82].frameX; num83 >= 100; num83 -= 100)
										{
										}
										while (num83 >= 36)
										{
											num83 -= 36;
										}
										if (num83 == 18)
										{
											num81--;
										}
										int frameX = (int)Main.tile[num81, num82].frameX;
										if (frameX >= 100)
										{
											WorldGen.KillTile(num81, num82, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num81, (float)num82, 1f, 0);
											}
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
									{
										this.AddBuff(29, 36000, true);
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
									{
										int num84 = Player.tileTargetX;
										int num85 = Player.tileTargetY;
										num84 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
										{
											num84 += 4;
											num84++;
										}
										else
										{
											num84 += 2;
										}
										num85 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18 * -1);
										num85 += 2;
										if (Player.CheckSpawn(num84, num85))
										{
											this.ChangeSpawn(num84, num85);
											Main.NewText("重生点已安置在这里!", 255, 240, 20);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
									{
										bool flag11 = true;
										if (this.sign >= 0)
										{
											int num86 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
											if (num86 == this.sign)
											{
												this.sign = -1;
												Main.npcChatText = "";
												Main.editSign = false;
												Main.PlaySound(11, -1, -1, 1);
												flag11 = false;
											}
										}
										if (flag11)
										{
											if (Main.netMode == 0)
											{
												this.talkNPC = -1;
												Main.playerInventory = false;
												Main.editSign = false;
												Main.PlaySound(10, -1, -1, 1);
												int num87 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
												this.sign = num87;
												Main.npcChatText = Main.sign[num87].text;
											}
											else
											{
												int num88 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
												int num89 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
												while (num88 > 1)
												{
													num88 -= 2;
												}
												int num90 = Player.tileTargetX - num88;
												int num91 = Player.tileTargetY - num89;
												if (Main.tile[num90, num91].type == 55 || Main.tile[num90, num91].type == 85)
												{
													NetMessage.SendData(46, -1, -1, "", num90, (float)num91, 0f, 0f, 0);
												}
											}
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
									{
										string text = "AM";
										double num92 = Main.time;
										if (!Main.dayTime)
										{
											num92 += 54000.0;
										}
										num92 = num92 / 86400.0 * 24.0;
										double num93 = 7.5;
										num92 = num92 - num93 - 12.0;
										if (num92 < 0.0)
										{
											num92 += 24.0;
										}
										if (num92 >= 12.0)
										{
											text = "PM";
										}
										int num94 = (int)num92;
										double num95 = num92 - (double)num94;
										num95 = (double)((int)(num95 * 60.0));
										string text2 = string.Concat(num95);
										if (num95 < 10.0)
										{
											text2 = "0" + text2;
										}
										if (num94 > 12)
										{
											num94 -= 12;
										}
										if (num94 == 0)
										{
											num94 = 12;
										}
										string newText = string.Concat(new object[]
										{
											"时间: ",
											num94,
											":",
											text2,
											" ",
											text
										});
										Main.NewText(newText, 255, 240, 20);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
									{
										WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
										NetMessage.SendData(19, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
									{
										if (WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
										{
											NetMessage.SendData(19, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
										}
									}
									else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
									{
										int num96 = 0;
										int num97;
										for (num97 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num97 > 1; num97 -= 2)
										{
										}
										num97 = Player.tileTargetX - num97;
										int num98 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
										{
											num96 = 1;
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
										{
											num96 = 2;
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
										{
											Main.chestText = "垃圾桶";
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
										{
											Main.chestText = "木桶";
										}
										else
										{
											Main.chestText = "箱子";
										}
										if (Main.netMode == 1 && num96 == 0 && (Main.tile[num97, num98].frameX < 72 || Main.tile[num97, num98].frameX > 106) && (Main.tile[num97, num98].frameX < 144 || Main.tile[num97, num98].frameX > 178))
										{
											if (num97 == this.chestX && num98 == this.chestY && this.chest != -1)
											{
												this.chest = -1;
												Main.PlaySound(11, -1, -1, 1);
											}
											else
											{
												NetMessage.SendData(31, -1, -1, "", num97, (float)num98, 0f, 0f, 0);
											}
										}
										else
										{
											int num99 = -1;
											if (num96 == 1)
											{
												num99 = -2;
											}
											else if (num96 == 2)
											{
												num99 = -3;
											}
											else
											{
												bool flag12 = false;
												if ((Main.tile[num97, num98].frameX >= 72 && Main.tile[num97, num98].frameX <= 106) || (Main.tile[num97, num98].frameX >= 144 && Main.tile[num97, num98].frameX <= 178))
												{
													int num100 = 327;
													if (Main.tile[num97, num98].frameX >= 144 && Main.tile[num97, num98].frameX <= 178)
													{
														num100 = 329;
													}
													flag12 = true;
													for (int num101 = 0; num101 < 48; num101++)
													{
														if (this.inventory[num101].type == num100 && this.inventory[num101].stack > 0)
														{
															if (num100 != 329)
															{
																this.inventory[num101].stack--;
																if (this.inventory[num101].stack <= 0)
																{
																	this.inventory[num101] = new Item();
																}
															}
															Chest.Unlock(num97, num98);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num97, (float)num98, 0);
															}
														}
													}
												}
												if (!flag12)
												{
													num99 = Chest.FindChest(num97, num98);
												}
											}
											if (num99 != -1)
											{
												if (num99 == this.chest)
												{
													this.chest = -1;
													Main.PlaySound(11, -1, -1, 1);
												}
												else if (num99 != this.chest && this.chest == -1)
												{
													this.chest = num99;
													Main.playerInventory = true;
													Main.PlaySound(10, -1, -1, 1);
													this.chestX = num97;
													this.chestY = num98;
												}
												else
												{
													this.chest = num99;
													Main.playerInventory = true;
													Main.PlaySound(12, -1, -1, 1);
													this.chestX = num97;
													this.chestY = num98;
												}
											}
										}
									}
								}
								this.releaseUseTile = false;
							}
							else
							{
								this.releaseUseTile = true;
							}
						}
					}
					if (this.tongued)
					{
						bool flag13 = false;
						if (Main.wof >= 0)
						{
							float num102 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num102 += (float)(Main.npc[Main.wof].direction * 200);
							float num103 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num104 = num102 - vector8.X;
							float num105 = num103 - vector8.Y;
							float num106 = (float)Math.Sqrt((double)(num104 * num104 + num105 * num105));
							float num107 = 11f;
							float num108;
							if (num106 > num107)
							{
								num108 = num107 / num106;
							}
							else
							{
								num108 = 1f;
								flag13 = true;
							}
							num104 *= num108;
							num105 *= num108;
							this.velocity.X = num104;
							this.velocity.Y = num105;
						}
						else
						{
							flag13 = true;
						}
						if (flag13 && Main.myPlayer == this.whoAmi)
						{
							for (int num109 = 0; num109 < 10; num109++)
							{
								if (this.buffType[num109] == 38)
								{
									this.DelBuff(num109);
								}
							}
						}
					}
					if (Main.myPlayer == this.whoAmi)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].active)
						{
							float num110 = Main.npc[Main.wof].position.X + 40f;
							if (Main.npc[Main.wof].direction > 0)
							{
								num110 -= 96f;
							}
							if (this.position.X + (float)this.width > num110 && this.position.X < num110 + 140f && this.gross)
							{
								this.noKnockback = false;
								this.Hurt(50, Main.npc[Main.wof].direction, false, false, " 被杀死了...", false);
							}
							if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num110 - 1920f && this.position.X < num110 + 1920f)
							{
								this.AddBuff(37, 10, true);
								Main.PlaySound(4, (int)Main.npc[Main.wof].position.X, (int)Main.npc[Main.wof].position.Y, 10);
							}
							if (this.gross)
							{
								if (this.position.Y < (float)((Main.maxTilesY - 200) * 16))
								{
									this.AddBuff(38, 10, true);
								}
								if (Main.npc[Main.wof].direction < 0)
								{
									if (this.position.X + (float)(this.width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
									{
										this.AddBuff(38, 10, true);
									}
								}
								else if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
								{
									this.AddBuff(38, 10, true);
								}
							}
							if (this.tongued)
							{
								this.controlHook = false;
								this.controlUseItem = false;
								for (int num111 = 0; num111 < 1000; num111++)
								{
									if (Main.projectile[num111].active && Main.projectile[num111].owner == Main.myPlayer && Main.projectile[num111].aiStyle == 7)
									{
										Main.projectile[num111].Kill();
									}
								}
								Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num112 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector9.X;
								float num113 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector9.Y;
								float num114 = (float)Math.Sqrt((double)(num112 * num112 + num113 * num113));
								if (num114 > 3000f)
								{
									this.KillMe(1000.0, 0, false, " 尝试着逃跑...");
								}
								else if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
								{
									this.KillMe(1000.0, 0, false, " 被舔了一下...");
								}
							}
						}
						if (this.controlHook)
						{
							if (this.releaseHook)
							{
								this.QuickGrapple();
							}
							this.releaseHook = false;
						}
						else
						{
							this.releaseHook = true;
						}
						if (this.talkNPC >= 0)
						{
							Rectangle rectangle2 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							Rectangle value = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
							if (!rectangle2.Intersects(value) || this.chest != -1 || !Main.npc[this.talkNPC].active)
							{
								if (this.chest == -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.talkNPC = -1;
								Main.npcChatText = "";
							}
						}
						if (this.sign >= 0)
						{
							Rectangle rectangle3 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							try
							{
								Rectangle value2 = new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32);
								if (!rectangle3.Intersects(value2))
								{
									Main.PlaySound(11, -1, -1, 1);
									this.sign = -1;
									Main.editSign = false;
									Main.npcChatText = "";
								}
							}
							catch
							{
								Main.PlaySound(11, -1, -1, 1);
								this.sign = -1;
								Main.editSign = false;
								Main.npcChatText = "";
							}
						}
						if (Main.editSign)
						{
							if (this.sign == -1)
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
						if (!this.immune)
						{
							Rectangle rectangle4 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							for (int num115 = 0; num115 < 200; num115++)
							{
								if (Main.npc[num115].active && !Main.npc[num115].friendly && Main.npc[num115].damage > 0 && rectangle4.Intersects(new Rectangle((int)Main.npc[num115].position.X, (int)Main.npc[num115].position.Y, Main.npc[num115].width, Main.npc[num115].height)))
								{
									int num116 = -1;
									if (Main.npc[num115].position.X + (float)(Main.npc[num115].width / 2) < this.position.X + (float)(this.width / 2))
									{
										num116 = 1;
									}
									int num117 = Main.DamageVar((float)Main.npc[num115].damage);
									if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num115].dontTakeDamage)
									{
										int num118 = num117 / 3;
										int num119 = 10;
										Main.npc[num115].StrikeNPC(num118, (float)num119, -num116, false, false);
										if (Main.netMode != 0)
										{
											NetMessage.SendData(28, -1, -1, "", num115, (float)num118, (float)num119, -(float)num116, 0);
										}
									}
									if (!this.immune)
									{
										if (((Main.npc[num115].type == 1 && Main.npc[num115].name == "Black Slime") || Main.npc[num115].type == 81 || Main.npc[num115].type == 79) && Main.rand.Next(4) == 0)
										{
											this.AddBuff(22, 900, true);
										}
										if ((Main.npc[num115].type == 23 || Main.npc[num115].type == 25) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(24, 420, true);
										}
										if ((Main.npc[num115].type == 34 || Main.npc[num115].type == 83 || Main.npc[num115].type == 84) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(23, 240, true);
										}
										if ((Main.npc[num115].type == 104 || Main.npc[num115].type == 102) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(30, 2700, true);
										}
										if (Main.npc[num115].type == 75 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num115].type == 79 || Main.npc[num115].type == 103) && Main.rand.Next(5) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num115].type == 75 || Main.npc[num115].type == 78 || Main.npc[num115].type == 82) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(32, 900, true);
										}
										if ((Main.npc[num115].type == 93 || Main.npc[num115].type == 109 || Main.npc[num115].type == 80) && Main.rand.Next(12) == 0)
										{
											this.AddBuff(31, 420, true);
										}
										if (Main.npc[num115].type == 77 && Main.rand.Next(6) == 0)
										{
											this.AddBuff(36, 18000, true);
										}
										if (Main.npc[num115].type == 112 && Main.rand.Next(20) == 0)
										{
											this.AddBuff(33, 18000, true);
										}
										if (Main.npc[num115].type == 141 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(20, 600, true);
										}
									}
									this.Hurt(num117, num116, false, false, Player.getDeathMessage(-1, num115, -1, -1), false);
								}
							}
						}
						Vector2 vector10 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
						if (vector10.Y != 0f)
						{
							int damage2 = Main.DamageVar(vector10.Y);
							this.Hurt(damage2, 0, false, false, Player.getDeathMessage(-1, -1, -1, 3), false);
						}
					}
					if (this.grappling[0] >= 0)
					{
						this.wingFrame = 1;
						if (this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02))
						{
							this.wingFrame = 0;
						}
						this.wingTime = 90;
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
						this.fallStart = (int)(this.position.Y / 16f);
						float num120 = 0f;
						float num121 = 0f;
						for (int num122 = 0; num122 < this.grapCount; num122++)
						{
							num120 += Main.projectile[this.grappling[num122]].position.X + (float)(Main.projectile[this.grappling[num122]].width / 2);
							num121 += Main.projectile[this.grappling[num122]].position.Y + (float)(Main.projectile[this.grappling[num122]].height / 2);
						}
						num120 /= (float)this.grapCount;
						num121 /= (float)this.grapCount;
						Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num123 = num120 - vector11.X;
						float num124 = num121 - vector11.Y;
						float num125 = (float)Math.Sqrt((double)(num123 * num123 + num124 * num124));
						float num126 = 11f;
						float num127;
						if (num125 > num126)
						{
							num127 = num126 / num125;
						}
						else
						{
							num127 = 1f;
						}
						num123 *= num127;
						num124 *= num127;
						this.velocity.X = num123;
						this.velocity.Y = num124;
						if (this.itemAnimation == 0)
						{
							if (this.velocity.X > 0f)
							{
								this.direction = 1;
							}
							if (this.velocity.X < 0f)
							{
								this.direction = -1;
							}
						}
						if (this.controlJump)
						{
							if (this.releaseJump)
							{
								if ((this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02)) && !this.controlDown)
								{
									this.velocity.Y = -Player.jumpSpeed;
									this.jump = Player.jumpHeight / 2;
									this.releaseJump = false;
								}
								else
								{
									this.velocity.Y = this.velocity.Y + 0.01f;
									this.releaseJump = false;
								}
								if (this.doubleJump)
								{
									this.jumpAgain = true;
								}
								this.grappling[0] = 0;
								this.grapCount = 0;
								for (int num128 = 0; num128 < 1000; num128++)
								{
									if (Main.projectile[num128].active && Main.projectile[num128].owner == i && Main.projectile[num128].aiStyle == 7)
									{
										Main.projectile[num128].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num129 = this.width / 2;
					int num130 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num129 / 2), this.position.Y + (float)(this.height / 2) - (float)(num130 / 2));
					Vector2 vector12 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector12.Y != -1f && vector12.X != -1f)
					{
						if (this.whoAmi == Main.myPlayer && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								int num131 = (int)vector12.X;
								int num132 = (int)vector12.Y;
								WorldGen.KillTile(num131, num132, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num131, num132].active && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num131, (float)num132, 0f, 0);
								}
							}
						}
						this.fallStart = (int)(this.position.Y / 16f);
						this.jump = 0;
						if (this.velocity.X > 1f)
						{
							this.velocity.X = 1f;
						}
						if (this.velocity.X < -1f)
						{
							this.velocity.X = -1f;
						}
						if (this.velocity.Y > 1f)
						{
							this.velocity.Y = 1f;
						}
						if (this.velocity.Y < -5f)
						{
							this.velocity.Y = -5f;
						}
						if ((double)this.velocity.X > 0.75 || (double)this.velocity.X < -0.75)
						{
							this.velocity.X = this.velocity.X * 0.85f;
						}
						else
						{
							this.velocity.X = this.velocity.X * 0.6f;
						}
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.96f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y * 0.3f;
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag14 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag14 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num133 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num134 = 0;
							if (this.gravDir == -1f)
							{
								num134 = this.height;
							}
							int num135 = (int)((this.position.Y + (float)num134 - 44f * this.gravDir) / 16f);
							if (Main.tile[num133, num135].liquid < 128)
							{
								if (Main.tile[num133, num135] == null)
								{
									Main.tile[num133, num135] = new Tile();
								}
								if (!Main.tile[num133, num135].active || !Main.tileSolid[(int)Main.tile[num133, num135].type] || Main.tileSolidTop[(int)Main.tile[num133, num135].type])
								{
									flag14 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag14 = !flag14;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag14 = false;
						}
						if (flag14)
						{
							this.breathCD++;
							int num136 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num136 *= 2;
							}
							if (this.accDivingHelm)
							{
								num136 *= 4;
							}
							if (this.breathCD >= num136)
							{
								this.breathCD = 0;
								this.breath--;
								if (this.breath == 0)
								{
									Main.PlaySound(23, -1, -1, 1);
								}
								if (this.breath <= 0)
								{
									this.lifeRegenTime = 0;
									this.breath = 0;
									this.statLife -= 2;
									if (this.statLife <= 0)
									{
										this.statLife = 0;
										this.KillMe(10.0, 0, false, Player.getDeathMessage(-1, -1, -1, 1));
									}
								}
							}
						}
						else
						{
							this.breath += 3;
							if (this.breath > this.breathMax)
							{
								this.breath = this.breathMax;
							}
							this.breathCD = 0;
						}
					}
					if (flag14 && Main.rand.Next(20) == 0 && !this.lavaWet)
					{
						int num137 = 0;
						if (this.gravDir == -1f)
						{
							num137 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Vector2 vector13 = new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num137 - 54f * this.gravDir);
							int num138 = this.width - 8;
							int num139 = 8;
							int type10 = 34;
							float speedX8 = 0f;
							float speedY8 = 0f;
							int alpha8 = 0;
							Color newColor = default(Color);
							Dust.NewDust(vector13, num138, num139, type10, speedX8, speedY8, alpha8, newColor, 1.2f);
						}
						else
						{
							Vector2 vector14 = new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num137 + 4f * this.gravDir);
							int num140 = this.width - 8;
							int num141 = 8;
							int type11 = 34;
							float speedX9 = 0f;
							float speedY9 = 0f;
							int alpha9 = 0;
							Color newColor = default(Color);
							Dust.NewDust(vector14, num140, num141, type11, speedX9, speedY9, alpha9, newColor, 1.2f);
						}
					}
					int num142 = this.height;
					if (this.waterWalk)
					{
						num142 -= 6;
					}
					bool flag15 = Collision.LavaCollision(this.position, this.width, num142);
					if (flag15)
					{
						if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
						{
							this.AddBuff(24, 420, true);
							this.Hurt(80, 0, false, false, Player.getDeathMessage(-1, -1, -1, 2), false);
						}
						this.lavaWet = true;
					}
					bool flag16 = Collision.WetCollision(this.position, this.width, this.height);
					if (flag16)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num143 = 0; num143 < 10; num143++)
							{
								if (this.buffType[num143] == 24)
								{
									this.DelBuff(num143);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag15)
								{
									for (int num144 = 0; num144 < 50; num144++)
									{
										Vector2 vector15 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
										int num145 = this.width + 12;
										int num146 = 24;
										int type12 = 33;
										float speedX10 = 0f;
										float speedY10 = 0f;
										int alpha10 = 0;
										Color newColor = default(Color);
										int num147 = Dust.NewDust(vector15, num145, num146, type12, speedX10, speedY10, alpha10, newColor, 1f);
										Dust dust4 = Main.dust[num147];
										dust4.velocity.Y = dust4.velocity.Y - 4f;
										Dust dust5 = Main.dust[num147];
										dust5.velocity.X = dust5.velocity.X * 2.5f;
										Main.dust[num147].scale = 1.3f;
										Main.dust[num147].alpha = 100;
										Main.dust[num147].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
								else
								{
									for (int num148 = 0; num148 < 20; num148++)
									{
										Vector2 vector16 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
										int num149 = this.width + 12;
										int num150 = 24;
										int type13 = 35;
										float speedX11 = 0f;
										float speedY11 = 0f;
										int alpha11 = 0;
										Color newColor = default(Color);
										int num151 = Dust.NewDust(vector16, num149, num150, type13, speedX11, speedY11, alpha11, newColor, 1f);
										Dust dust6 = Main.dust[num151];
										dust6.velocity.Y = dust6.velocity.Y - 1.5f;
										Dust dust7 = Main.dust[num151];
										dust7.velocity.X = dust7.velocity.X * 2.5f;
										Main.dust[num151].scale = 1.3f;
										Main.dust[num151].alpha = 100;
										Main.dust[num151].noGravity = true;
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
						if (this.jump > Player.jumpHeight / 5)
						{
							this.jump = Player.jumpHeight / 5;
						}
						if (this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!this.lavaWet)
							{
								for (int num152 = 0; num152 < 50; num152++)
								{
									Vector2 vector17 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2));
									int num153 = this.width + 12;
									int num154 = 24;
									int type14 = 33;
									float speedX12 = 0f;
									float speedY12 = 0f;
									int alpha12 = 0;
									Color newColor = default(Color);
									int num155 = Dust.NewDust(vector17, num153, num154, type14, speedX12, speedY12, alpha12, newColor, 1f);
									Dust dust8 = Main.dust[num155];
									dust8.velocity.Y = dust8.velocity.Y - 4f;
									Dust dust9 = Main.dust[num155];
									dust9.velocity.X = dust9.velocity.X * 2.5f;
									Main.dust[num155].scale = 1.3f;
									Main.dust[num155].alpha = 100;
									Main.dust[num155].noGravity = true;
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
							}
							else
							{
								for (int num156 = 0; num156 < 20; num156++)
								{
									Vector2 vector18 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
									int num157 = this.width + 12;
									int num158 = 24;
									int type15 = 35;
									float speedX13 = 0f;
									float speedY13 = 0f;
									int alpha13 = 0;
									Color newColor = default(Color);
									int num159 = Dust.NewDust(vector18, num157, num158, type15, speedX13, speedY13, alpha13, newColor, 1f);
									Dust dust10 = Main.dust[num159];
									dust10.velocity.Y = dust10.velocity.Y - 1.5f;
									Dust dust11 = Main.dust[num159];
									dust11.velocity.X = dust11.velocity.X * 2.5f;
									Main.dust[num159].scale = 1.3f;
									Main.dust[num159].alpha = 100;
									Main.dust[num159].noGravity = true;
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
					this.oldPosition = this.position;
					if (this.tongued)
					{
						this.position += this.velocity;
					}
					else if (this.wet && !this.merman)
					{
						Vector2 vector19 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
						Vector2 value3 = this.velocity * 0.5f;
						if (this.velocity.X != vector19.X)
						{
							value3.X = this.velocity.X;
						}
						if (this.velocity.Y != vector19.Y)
						{
							value3.Y = this.velocity.Y;
						}
						this.position += value3;
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
						if (this.waterWalk)
						{
							this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
						}
						this.position += this.velocity;
					}
					if (this.velocity.Y == 0f)
					{
						if (this.gravDir == 1f && Collision.up)
						{
							this.velocity.Y = 0.01f;
							if (!this.merman)
							{
								this.jump = 0;
							}
						}
						else if (this.gravDir == -1f && Collision.down)
						{
							this.velocity.Y = -0.01f;
							if (!this.merman)
							{
								this.jump = 0;
							}
						}
					}
					if (this.whoAmi == Main.myPlayer)
					{
						Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition);
					}
					if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
					{
						this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
						this.velocity.X = 0f;
					}
					if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
					{
						this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
						this.velocity.X = 0f;
					}
					if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
					{
						this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
						if ((double)this.velocity.Y < 0.11)
						{
							this.velocity.Y = 0.11f;
						}
					}
					if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
					{
						this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
						this.velocity.Y = 0f;
					}
					if (Main.ignoreErrors)
					{
						try
						{
							this.ItemCheck(i);
							goto IL_B9D0;
						}
						catch
						{
							goto IL_B9D0;
						}
					}
					this.ItemCheck(i);
					IL_B9D0:
					this.PlayerFrame();
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
				}
				else
				{
					this.wings = 0;
					this.poisoned = false;
					this.onFire = false;
					this.onFire2 = false;
					this.blind = false;
					this.gravDir = 1f;
					for (int num160 = 0; num160 < 10; num160++)
					{
						this.buffTime[num160] = 0;
						this.buffType[num160] = 0;
					}
					if (i == Main.myPlayer)
					{
						Main.npcChatText = "";
						Main.editSign = false;
					}
					this.grappling[0] = -1;
					this.grappling[1] = -1;
					this.grappling[2] = -1;
					this.sign = -1;
					this.talkNPC = -1;
					this.statLife = 0;
					this.channel = false;
					this.potionDelay = 0;
					this.chest = -1;
					this.changeItem = -1;
					this.itemAnimation = 0;
					this.immuneAlpha += 2;
					if (this.immuneAlpha > 255)
					{
						this.immuneAlpha = 255;
					}
					this.headPosition += this.headVelocity;
					this.bodyPosition += this.bodyVelocity;
					this.legPosition += this.legVelocity;
					this.headRotation += this.headVelocity.X * 0.1f;
					this.bodyRotation += this.bodyVelocity.X * 0.1f;
					this.legRotation += this.legVelocity.X * 0.1f;
					this.headVelocity.Y = this.headVelocity.Y + 0.1f;
					this.bodyVelocity.Y = this.bodyVelocity.Y + 0.1f;
					this.legVelocity.Y = this.legVelocity.Y + 0.1f;
					this.headVelocity.X = this.headVelocity.X * 0.99f;
					this.bodyVelocity.X = this.bodyVelocity.X * 0.99f;
					this.legVelocity.X = this.legVelocity.X * 0.99f;
					if (this.difficulty == 2)
					{
						if (this.respawnTimer > 0)
						{
							this.respawnTimer--;
						}
						else if (this.whoAmi == Main.myPlayer || Main.netMode == 2)
						{
							this.ghost = true;
						}
					}
					else
					{
						this.respawnTimer--;
						if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmi)
						{
							if (Main.mouseItem.type > 0)
							{
								Main.playerInventory = true;
							}
							this.Spawn();
						}
					}
				}
			}
		}

		public bool SellItem(int price, int stack)
		{
			bool result;
			if (price <= 0)
			{
				result = false;
			}
			else
			{
				Item[] array = new Item[48];
				for (int i = 0; i < 48; i++)
				{
					array[i] = new Item();
					array[i] = (Item)this.inventory[i].Clone();
				}
				int j = price / 5;
				j *= stack;
				if (j < 1)
				{
					j = 1;
				}
				bool flag = false;
				while (j >= 1000000)
				{
					if (flag)
					{
						break;
					}
					int num = -1;
					for (int k = 43; k >= 0; k--)
					{
						if (num == -1 && (this.inventory[k].type == 0 || this.inventory[k].stack == 0))
						{
							num = k;
						}
						while (this.inventory[k].type == 74 && this.inventory[k].stack < this.inventory[k].maxStack && j >= 1000000)
						{
							this.inventory[k].stack++;
							j -= 1000000;
							this.DoCoins(k);
							if (this.inventory[k].stack == 0 && num == -1)
							{
								num = k;
							}
						}
					}
					if (j >= 1000000)
					{
						if (num == -1)
						{
							flag = true;
						}
						else
						{
							this.inventory[num].SetDefaults(74, false);
							j -= 1000000;
						}
					}
				}
				while (j >= 10000)
				{
					if (flag)
					{
						break;
					}
					int num2 = -1;
					for (int l = 43; l >= 0; l--)
					{
						if (num2 == -1 && (this.inventory[l].type == 0 || this.inventory[l].stack == 0))
						{
							num2 = l;
						}
						while (this.inventory[l].type == 73 && this.inventory[l].stack < this.inventory[l].maxStack && j >= 10000)
						{
							this.inventory[l].stack++;
							j -= 10000;
							this.DoCoins(l);
							if (this.inventory[l].stack == 0 && num2 == -1)
							{
								num2 = l;
							}
						}
					}
					if (j >= 10000)
					{
						if (num2 == -1)
						{
							flag = true;
						}
						else
						{
							this.inventory[num2].SetDefaults(73, false);
							j -= 10000;
						}
					}
				}
				while (j >= 100)
				{
					if (flag)
					{
						break;
					}
					int num3 = -1;
					for (int m = 43; m >= 0; m--)
					{
						if (num3 == -1 && (this.inventory[m].type == 0 || this.inventory[m].stack == 0))
						{
							num3 = m;
						}
						while (this.inventory[m].type == 72 && this.inventory[m].stack < this.inventory[m].maxStack && j >= 100)
						{
							this.inventory[m].stack++;
							j -= 100;
							this.DoCoins(m);
							if (this.inventory[m].stack == 0 && num3 == -1)
							{
								num3 = m;
							}
						}
					}
					if (j >= 100)
					{
						if (num3 == -1)
						{
							flag = true;
						}
						else
						{
							this.inventory[num3].SetDefaults(72, false);
							j -= 100;
						}
					}
				}
				while (j >= 1 && !flag)
				{
					int num4 = -1;
					for (int n = 43; n >= 0; n--)
					{
						if (num4 == -1 && (this.inventory[n].type == 0 || this.inventory[n].stack == 0))
						{
							num4 = n;
						}
						while (this.inventory[n].type == 71 && this.inventory[n].stack < this.inventory[n].maxStack && j >= 1)
						{
							this.inventory[n].stack++;
							j--;
							this.DoCoins(n);
							if (this.inventory[n].stack == 0 && num4 == -1)
							{
								num4 = n;
							}
						}
					}
					if (j >= 1)
					{
						if (num4 == -1)
						{
							flag = true;
						}
						else
						{
							this.inventory[num4].SetDefaults(71, false);
							j--;
						}
					}
				}
				if (flag)
				{
					for (int num5 = 0; num5 < 48; num5++)
					{
						this.inventory[num5] = (Item)array[num5].Clone();
					}
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		public bool BuyItem(int price)
		{
			bool result;
			if (price == 0)
			{
				result = true;
			}
			else
			{
				int num = 0;
				Item[] array = new Item[44];
				for (int i = 0; i < 44; i++)
				{
					array[i] = new Item();
					array[i] = (Item)this.inventory[i].Clone();
					if (this.inventory[i].type == 71)
					{
						num += this.inventory[i].stack;
					}
					if (this.inventory[i].type == 72)
					{
						num += this.inventory[i].stack * 100;
					}
					if (this.inventory[i].type == 73)
					{
						num += this.inventory[i].stack * 10000;
					}
					if (this.inventory[i].type == 74)
					{
						num += this.inventory[i].stack * 1000000;
					}
				}
				if (num >= price)
				{
					int j = price;
					while (j > 0)
					{
						if (j >= 1000000)
						{
							for (int k = 0; k < 44; k++)
							{
								if (this.inventory[k].type == 74)
								{
									while (this.inventory[k].stack > 0 && j >= 1000000)
									{
										j -= 1000000;
										this.inventory[k].stack--;
										if (this.inventory[k].stack == 0)
										{
											this.inventory[k].type = 0;
										}
									}
								}
							}
						}
						if (j >= 10000)
						{
							for (int l = 0; l < 44; l++)
							{
								if (this.inventory[l].type == 73)
								{
									while (this.inventory[l].stack > 0 && j >= 10000)
									{
										j -= 10000;
										this.inventory[l].stack--;
										if (this.inventory[l].stack == 0)
										{
											this.inventory[l].type = 0;
										}
									}
								}
							}
						}
						if (j >= 100)
						{
							for (int m = 0; m < 44; m++)
							{
								if (this.inventory[m].type == 72)
								{
									while (this.inventory[m].stack > 0 && j >= 100)
									{
										j -= 100;
										this.inventory[m].stack--;
										if (this.inventory[m].stack == 0)
										{
											this.inventory[m].type = 0;
										}
									}
								}
							}
						}
						if (j >= 1)
						{
							for (int n = 0; n < 44; n++)
							{
								if (this.inventory[n].type == 71)
								{
									while (this.inventory[n].stack > 0 && j >= 1)
									{
										j--;
										this.inventory[n].stack--;
										if (this.inventory[n].stack == 0)
										{
											this.inventory[n].type = 0;
										}
									}
								}
							}
						}
						if (j > 0)
						{
							int num2 = -1;
							for (int num3 = 43; num3 >= 0; num3--)
							{
								if (this.inventory[num3].type == 0 || this.inventory[num3].stack == 0)
								{
									num2 = num3;
									break;
								}
							}
							if (num2 < 0)
							{
								for (int num4 = 0; num4 < 44; num4++)
								{
									this.inventory[num4] = (Item)array[num4].Clone();
								}
								result = false;
								return result;
							}
							bool flag = true;
							if (j >= 10000)
							{
								for (int num5 = 0; num5 < 48; num5++)
								{
									if (this.inventory[num5].type == 74 && this.inventory[num5].stack >= 1)
									{
										this.inventory[num5].stack--;
										if (this.inventory[num5].stack == 0)
										{
											this.inventory[num5].type = 0;
										}
										this.inventory[num2].SetDefaults(73, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							else if (j >= 100)
							{
								for (int num6 = 0; num6 < 44; num6++)
								{
									if (this.inventory[num6].type == 73 && this.inventory[num6].stack >= 1)
									{
										this.inventory[num6].stack--;
										if (this.inventory[num6].stack == 0)
										{
											this.inventory[num6].type = 0;
										}
										this.inventory[num2].SetDefaults(72, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							else if (j >= 1)
							{
								for (int num7 = 0; num7 < 44; num7++)
								{
									if (this.inventory[num7].type == 72 && this.inventory[num7].stack >= 1)
									{
										this.inventory[num7].stack--;
										if (this.inventory[num7].stack == 0)
										{
											this.inventory[num7].type = 0;
										}
										this.inventory[num2].SetDefaults(71, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							if (flag)
							{
								if (j < 10000)
								{
									for (int num8 = 0; num8 < 44; num8++)
									{
										if (this.inventory[num8].type == 73 && this.inventory[num8].stack >= 1)
										{
											this.inventory[num8].stack--;
											if (this.inventory[num8].stack == 0)
											{
												this.inventory[num8].type = 0;
											}
											this.inventory[num2].SetDefaults(72, false);
											this.inventory[num2].stack = 100;
											flag = false;
											break;
										}
									}
								}
								if (flag && j < 1000000)
								{
									for (int num9 = 0; num9 < 44; num9++)
									{
										if (this.inventory[num9].type == 74 && this.inventory[num9].stack >= 1)
										{
											this.inventory[num9].stack--;
											if (this.inventory[num9].stack == 0)
											{
												this.inventory[num9].type = 0;
											}
											this.inventory[num2].SetDefaults(73, false);
											this.inventory[num2].stack = 100;
											break;
										}
									}
								}
							}
						}
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public void AdjTiles()
		{
			int num = 4;
			int num2 = 3;
			for (int i = 0; i < 150; i++)
			{
				this.oldAdjTile[i] = this.adjTile[i];
				this.adjTile[i] = false;
			}
			this.oldAdjWater = this.adjWater;
			this.adjWater = false;
			int num3 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int num4 = (int)((this.position.Y + (float)this.height) / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].active)
					{
						this.adjTile[(int)Main.tile[j, k].type] = true;
						if (Main.tile[j, k].type == 77)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 133)
						{
							this.adjTile[17] = true;
							this.adjTile[77] = true;
						}
						if (Main.tile[j, k].type == 134)
						{
							this.adjTile[16] = true;
						}
					}
					if (Main.tile[j, k].liquid > 200 && !Main.tile[j, k].lava)
					{
						this.adjWater = true;
					}
				}
			}
			if (Main.playerInventory)
			{
				bool flag = false;
				for (int l = 0; l < 150; l++)
				{
					if (this.oldAdjTile[l] != this.adjTile[l])
					{
						flag = true;
						break;
					}
				}
				if (this.adjWater != this.oldAdjWater)
				{
					flag = true;
				}
				if (flag)
				{
					Recipe.FindRecipes();
				}
			}
		}

		public void PlayerFrame()
		{
			if (this.swimTime > 0)
			{
				this.swimTime--;
				if (!this.wet)
				{
					this.swimTime = 0;
				}
			}
			this.head = this.armor[0].headSlot;
			this.body = this.armor[1].bodySlot;
			this.legs = this.armor[2].legSlot;
			if (this.armor[8].headSlot >= 0)
			{
				this.head = this.armor[8].headSlot;
			}
			if (this.armor[9].bodySlot >= 0)
			{
				this.body = this.armor[9].bodySlot;
			}
			if (this.armor[10].legSlot >= 0)
			{
				this.legs = this.armor[10].legSlot;
			}
			if (this.wereWolf)
			{
				this.legs = 20;
				this.body = 21;
				this.head = 38;
			}
			if (this.merman)
			{
				this.head = 39;
				this.legs = 21;
				this.body = 22;
			}
			this.socialShadow = false;
			if (this.head == 5 && this.body == 5 && this.legs == 5)
			{
				this.socialShadow = true;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int i = 0; i < 2; i++)
				{
					int num = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].noLight = true;
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X - this.velocity.X * 0.5f;
					Dust dust2 = Main.dust[num];
					dust2.velocity.Y = dust2.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.head == 7 && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
			}
			if (this.head == 8 && this.body == 8 && this.legs == 8 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
			{
				int num2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 40, 0f, 0f, 50, default(Color), 1.4f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity.X = this.velocity.X * 0.25f;
				Main.dust[num2].velocity.Y = this.velocity.Y * 0.25f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int j = 0; j < 2; j++)
				{
					int num3 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].noLight = true;
					Dust dust3 = Main.dust[num3];
					dust3.velocity.X = dust3.velocity.X - this.velocity.X * 0.5f;
					Dust dust4 = Main.dust[num3];
					dust4.velocity.Y = dust4.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
			{
				int num4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num4].fadeIn = 0.8f;
				Dust dust5 = Main.dust[num4];
				dust5.velocity *= 0f;
			}
			if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && this.velocity.X != 0f && this.velocity.Y != 0f && Main.rand.Next(10) == 0)
			{
				int num5 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num5].fadeIn = 0.8f;
				Dust dust6 = Main.dust[num5];
				dust6.velocity *= 0f;
			}
			this.bodyFrame.Width = 40;
			this.bodyFrame.Height = 56;
			this.legFrame.Width = 40;
			this.legFrame.Height = 56;
			this.bodyFrame.X = 0;
			this.legFrame.X = 0;
			if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
			{
				if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 2)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 4)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
				}
				else if (this.inventory[this.selectedItem].useStyle == 5)
				{
					if (this.inventory[this.selectedItem].type == 281)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
					else
					{
						float num6 = this.itemRotation * (float)this.direction;
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						if ((double)num6 < -0.75)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 4;
							}
						}
						if ((double)num6 > 0.6)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 4;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 2;
							}
						}
					}
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 3;
			}
			else if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 2;
			}
			else if (this.inventory[this.selectedItem].holdStyle == 3)
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 3;
			}
			else if (this.grappling[0] >= 0)
			{
				Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num7 = 0f;
				float num8 = 0f;
				for (int k = 0; k < this.grapCount; k++)
				{
					num7 += Main.projectile[this.grappling[k]].position.X + (float)(Main.projectile[this.grappling[k]].width / 2);
					num8 += Main.projectile[this.grappling[k]].position.Y + (float)(Main.projectile[this.grappling[k]].height / 2);
				}
				num7 /= (float)this.grapCount;
				num8 /= (float)this.grapCount;
				num7 -= vector.X;
				num8 -= vector.Y;
				if (num8 < 0f && Math.Abs(num8) > Math.Abs(num7))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					if (this.gravDir == -1f)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 4;
					}
				}
				else if (num8 > 0f && Math.Abs(num8) > Math.Abs(num7))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 4;
					if (this.gravDir == -1f)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
				}
				else
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
				}
			}
			else if (this.swimTime > 0)
			{
				if (this.swimTime > 20)
				{
					this.bodyFrame.Y = 0;
				}
				else if (this.swimTime > 10)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 5;
				}
				else
				{
					this.bodyFrame.Y = 0;
				}
			}
			else if (this.velocity.Y != 0f)
			{
				if (this.wings > 0)
				{
					if (this.velocity.Y > 0f)
					{
						if (this.controlJump)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 5;
						}
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 6;
					}
				}
				else
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 5;
				}
				this.bodyFrameCounter = 0.0;
			}
			else if (this.velocity.X != 0f)
			{
				this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
				this.bodyFrame.Y = this.legFrame.Y;
			}
			else
			{
				this.bodyFrameCounter = 0.0;
				this.bodyFrame.Y = 0;
			}
			if (this.swimTime > 0)
			{
				this.legFrameCounter += 2.0;
				while (this.legFrameCounter > 8.0)
				{
					this.legFrameCounter -= 8.0;
					this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
				}
				if (this.legFrame.Y < this.legFrame.Height * 7)
				{
					this.legFrame.Y = this.legFrame.Height * 19;
				}
				else if (this.legFrame.Y > this.legFrame.Height * 19)
				{
					this.legFrame.Y = this.legFrame.Height * 7;
				}
			}
			else if (this.velocity.Y != 0f || this.grappling[0] > -1)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * 5;
			}
			else if (this.velocity.X != 0f)
			{
				this.legFrameCounter += (double)Math.Abs(this.velocity.X) * 1.3;
				while (this.legFrameCounter > 8.0)
				{
					this.legFrameCounter -= 8.0;
					this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
				}
				if (this.legFrame.Y < this.legFrame.Height * 7)
				{
					this.legFrame.Y = this.legFrame.Height * 19;
				}
				else if (this.legFrame.Y > this.legFrame.Height * 19)
				{
					this.legFrame.Y = this.legFrame.Height * 7;
				}
			}
			else
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
		}

		public void Spawn()
		{
			if (this.whoAmi == Main.myPlayer)
			{
				Main.quickBG = 10;
				this.FindSpawn();
				if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
				}
				Main.maxQ = true;
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				Main.gameMenu = false;
			}
			this.headPosition = default(Vector2);
			this.bodyPosition = default(Vector2);
			this.legPosition = default(Vector2);
			this.headRotation = 0f;
			this.bodyRotation = 0f;
			this.legRotation = 0f;
			if (this.statLife <= 0)
			{
				this.statLife = 100;
				this.breath = this.breathMax;
				if (this.spawnMax)
				{
					this.statLife = this.statLifeMax;
					this.statMana = this.statManaMax2;
				}
			}
			this.immune = true;
			this.dead = false;
			this.immuneTime = 0;
			this.active = true;
			if (this.SpawnX >= 0 && this.SpawnY >= 0)
			{
				this.position.X = (float)(this.SpawnX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(this.SpawnY * 16 - this.height);
			}
			else
			{
				this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
						if (Main.tile[i, j].liquid > 0)
						{
							Main.tile[i, j].lava = false;
							Main.tile[i, j].liquid = 0;
							WorldGen.SquareTileFrame(i, j, true);
						}
					}
				}
			}
			this.wet = false;
			this.wetCount = 0;
			this.lavaWet = false;
			this.fallStart = (int)(this.position.Y / 16f);
			this.velocity.X = 0f;
			this.velocity.Y = 0f;
			this.talkNPC = -1;
			if (this.pvpDeath)
			{
				this.pvpDeath = false;
				this.immuneTime = 300;
				this.statLife = this.statLifeMax;
			}
			else
			{
				this.immuneTime = 60;
			}
			if (this.whoAmi == Main.myPlayer)
			{
				Main.renderNow = true;
				if (Main.netMode == 1)
				{
					Netplay.newRecent();
				}
				Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
			}
		}

		public static string getDeathMessage(int plr = -1, int npc = -1, int proj = -1, int other = -1)
		{
			string str = "他们";
			if (plr >= 0)
			{
				if (Main.player[plr].male)
				{
					str = "他";
				}
				else
				{
					str = "她";
				}
			}
			string result = "";
			int num = Main.rand.Next(26);
			string text = "";
			if (num == 0)
			{
				text = "杀死了！";
			}
			else if (num == 1)
			{
				text = "掏出了内脏！";
			}
			else if (num == 2)
			{
				text = "残忍的杀死！";
			}
			else if (num == 3)
			{
				text = "撕下了脸皮！";
			}
			else if (num == 4)
			{
				text = "掏出了内脏！";
			}
			else if (num == 5)
			{
				text = "消灭了！";
			}
			else if (num == 6)
			{
				text = "敲碎了头骨！";
			}
			else if (num == 7)
			{
				text = "屠杀了！";
			}
			else if (num == 8)
			{
				text = "刺穿了！";
			}
			else if (num == 9)
			{
				text = "扯成了两半！";
			}
			else if (num == 10)
			{
				text = "斩下了首级！";
			}
			else if (num == 11)
			{
				text = "弄断了" + str + "的胳膊！";
			}
			else if (num == 12)
			{
				text = "挤出了" + str + "的内脏！";
			}
			else if (num == 13)
			{
				text = "残忍的肢解！";
			}
			else if (num == 14)
			{
				text = "分尸了！";
			}
			else if (num == 15)
			{
				text = "撕裂了身体！";
			}
			else if (num == 16)
			{
				text = "震碎了内脏！";
			}
			else if (num == 17)
			{
				text = "变成了一堆肉酱！";
			}
			else if (num == 18)
			{
				text = "打飞出了 " + Main.worldName;
			}
			else if (num == 19)
			{
				text = "啪的一声断成了两截！";
			}
			else if (num == 20)
			{
				text = "从中间劈成了两半！";
			}
			else if (num == 21)
			{
				text = "剁碎了！";
			}
			else if (num == 22)
			{
				text = "实现了" + str + "想死的愿望。";
			}
			else if (num == 23)
			{
				text = "凌迟了……";
			}
			else if (num == 24)
			{
				text = "击中了要害！";
			}
			else if (num == 25)
			{
				text = "打掉了脑袋！";
			}
			if (plr >= 0 && plr < 255)
			{
				if (proj >= 0 && Main.projectile[proj].name != "")
				{
					result = string.Concat(new string[]
					{
						" 被<",
						Main.player[plr].name,
						">的",
						Main.projectile[proj].CName,
						text
					});
				}
				else
				{
					result = string.Concat(new string[]
					{
						" 被<",
						Main.player[plr].name,
						">的 ",
						Main.player[plr].inventory[Main.player[plr].selectedItem].CName,
						text
					});
				}
			}
			else if (npc >= 0 && Main.npc[npc].displayName != "")
			{
				result = " 被<" + Main.npc[npc].displayCName + ">" + text;
			}
			else if (proj >= 0 && Main.projectile[proj].name != "")
			{
				result = " 被<" + Main.projectile[proj].CName + ">" + text;
			}
			else if (other >= 0)
			{
				if (other == 0)
				{
					if (Main.rand.Next(2) == 0)
					{
						result = " 摔死了...";
					}
					else
					{
						result = " 没有弹起来...";
					}
				}
				else if (other == 1)
				{
					int num2 = Main.rand.Next(4);
					if (num2 == 0)
					{
						result = " 忘记了呼吸...";
					}
					else if (num2 == 1)
					{
						result = " 和鱼儿们一起安眠...";
					}
					else if (num2 == 2)
					{
						result = " 溺死了...";
					}
					else if (num2 == 3)
					{
						result = " 成为了鲨鱼的美餐...";
					}
				}
				else if (other == 2)
				{
					int num3 = Main.rand.Next(4);
					if (num3 == 0)
					{
						result = " 融化了...";
					}
					else if (num3 == 1)
					{
						result = " 烧成了灰烬...";
					}
					else if (num3 == 2)
					{
						result = " 试着在岩浆里游泳...";
					}
					else if (num3 == 3)
					{
						result = " 喜欢在熔岩里玩耍...";
					}
				}
				else if (other == 3)
				{
					result = "被" + text;
				}
			}
			return result;
		}

		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " 被杀死了...", bool Crit = false)
		{
			double result;
			if (!this.immune)
			{
				int num = Damage;
				if (pvp)
				{
					num *= 2;
				}
				double num2 = Main.CalculateDamage(num, this.statDefense);
				if (Crit)
				{
					num *= 2;
				}
				if (num2 >= 1.0)
				{
					if (Main.netMode == 1 && this.whoAmi == Main.myPlayer && !quiet)
					{
						int num3 = 0;
						if (pvp)
						{
							num3 = 1;
						}
						NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						NetMessage.SendData(16, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						NetMessage.SendData(26, -1, -1, "", this.whoAmi, (float)hitDirection, (float)Damage, (float)num3, 0);
					}
					CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 80, 90, 255), string.Concat((int)num2), Crit);
					this.statLife -= (int)num2;
					this.immune = true;
					this.immuneTime = 40;
					if (this.longInvince)
					{
						this.immuneTime += 40;
					}
					this.lifeRegenTime = 0;
					if (pvp)
					{
						this.immuneTime = 8;
					}
					if (this.whoAmi == Main.myPlayer && this.starCloak)
					{
						for (int i = 0; i < 3; i++)
						{
							float x = this.position.X + (float)Main.rand.Next(-400, 400);
							float y = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector = new Vector2(x, y);
							float num4 = this.position.X + (float)(this.width / 2) - vector.X;
							float num5 = this.position.Y + (float)(this.height / 2) - vector.Y;
							num4 += (float)Main.rand.Next(-100, 101);
							int num6 = 23;
							float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
							num7 = (float)num6 / num7;
							num4 *= num7;
							num5 *= num7;
							int num8 = Projectile.NewProjectile(x, y, num4, num5, 92, 30, 5f, this.whoAmi);
							Main.projectile[num8].ai[1] = this.position.Y;
						}
					}
					if (!this.noKnockback && hitDirection != 0)
					{
						this.velocity.X = 4.5f * (float)hitDirection;
						this.velocity.Y = -3.5f;
					}
					if (this.wereWolf)
					{
						Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 6);
					}
					else if (this.boneArmor)
					{
						Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 2);
					}
					else if (!this.male)
					{
						Main.PlaySound(20, (int)this.position.X, (int)this.position.Y, 1);
					}
					else
					{
						Main.PlaySound(1, (int)this.position.X, (int)this.position.Y, 1);
					}
					if (this.statLife > 0)
					{
						int num9 = 0;
						while ((double)num9 < num2 / (double)this.statLifeMax * 100.0)
						{
							if (this.boneArmor)
							{
								Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
							}
							else
							{
								Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
							}
							num9++;
						}
					}
					else
					{
						this.statLife = 0;
						if (this.whoAmi == Main.myPlayer)
						{
							this.KillMe(num2, hitDirection, pvp, deathText);
						}
					}
				}
				if (pvp)
				{
					num2 = Main.CalculateDamage(num, this.statDefense);
				}
				result = num2;
			}
			else
			{
				result = 0.0;
			}
			return result;
		}

		public void KillMeForGood()
		{
			if (File.Exists(Main.playerPathName))
			{
				File.Delete(Main.playerPathName);
			}
			if (File.Exists(Main.playerPathName + ".bak"))
			{
				File.Delete(Main.playerPathName + ".bak");
			}
			if (File.Exists(Main.playerPathName + ".dat"))
			{
				File.Delete(Main.playerPathName + ".dat");
			}
			Main.playerPathName = "";
		}

		public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " 被杀死了...")
		{
			if (!this.dead)
			{
				if (pvp)
				{
					this.pvpDeath = true;
				}
				if (this.difficulty == 0)
				{
					if (Main.netMode != 1)
					{
						float num = (float)Main.rand.Next(-35, 36) * 0.1f;
						while (num < 2f && num > -2f)
						{
							num += (float)Main.rand.Next(-30, 31) * 0.1f;
						}
						int num2 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0f, Main.myPlayer);
						Main.projectile[num2].miscText = this.name + deathText;
					}
				}
				else
				{
					if (Main.netMode != 1)
					{
						float num3 = (float)Main.rand.Next(-35, 36) * 0.1f;
						while (num3 < 2f && num3 > -2f)
						{
							num3 += (float)Main.rand.Next(-30, 31) * 0.1f;
						}
						int num4 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num3, (float)Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0f, Main.myPlayer);
						Main.projectile[num4].miscText = this.name + deathText;
					}
					if (Main.myPlayer == this.whoAmi)
					{
						Main.trashItem.SetDefaults(0, false);
						if (this.difficulty == 1)
						{
							this.DropItems();
						}
						else if (this.difficulty == 2)
						{
							this.DropItems();
							this.KillMeForGood();
						}
					}
				}
				Main.PlaySound(5, (int)this.position.X, (int)this.position.Y, 1);
				this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
				this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
				this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
				this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
				this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
				this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
				int num5 = 0;
				while ((double)num5 < 20.0 + dmg / (double)this.statLifeMax * 100.0)
				{
					if (this.boneArmor)
					{
						Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
					}
					else
					{
						Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
					}
					num5++;
				}
				this.dead = true;
				this.respawnTimer = 600;
				this.immuneAlpha = 0;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, this.name + deathText, 255, 225f, 25f, 25f, 0);
				}
				else if (Main.netMode == 0)
				{
					Main.NewText(this.name + deathText, 225, 25, 25);
				}
				if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
				{
					int num6 = 0;
					if (pvp)
					{
						num6 = 1;
					}
					NetMessage.SendData(44, -1, -1, deathText, this.whoAmi, (float)hitDirection, (float)((int)dmg), (float)num6, 0);
				}
				if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == 0)
				{
					this.DropCoins();
				}
				if (this.whoAmi == Main.myPlayer)
				{
					try
					{
						WorldGen.saveToonWhilePlaying();
					}
					catch
					{
					}
				}
			}
		}

		public bool ItemSpace(Item newItem)
		{
			bool result;
			if (newItem.type == 58)
			{
				result = true;
			}
			else if (newItem.type == 184)
			{
				result = true;
			}
			else
			{
				int num = 40;
				if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
				{
					num = 44;
				}
				for (int i = 0; i < num; i++)
				{
					if (this.inventory[i].type == 0)
					{
						result = true;
						return result;
					}
				}
				for (int j = 0; j < num; j++)
				{
					if (this.inventory[j].type > 0 && this.inventory[j].stack < this.inventory[j].maxStack && newItem.IsTheSameAs(this.inventory[j]))
					{
						result = true;
						return result;
					}
				}
				if (newItem.ammo > 0)
				{
					if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
					{
						for (int k = 44; k < 48; k++)
						{
							if (this.inventory[k].type == 0)
							{
								result = true;
								return result;
							}
						}
					}
					for (int l = 44; l < 48; l++)
					{
						if (this.inventory[l].type > 0 && this.inventory[l].stack < this.inventory[l].maxStack && newItem.IsTheSameAs(this.inventory[l]))
						{
							result = true;
							return result;
						}
					}
				}
				result = false;
			}
			return result;
		}

		public void DoCoins(int i)
		{
			if (this.inventory[i].stack == 100 && (this.inventory[i].type == 71 || this.inventory[i].type == 72 || this.inventory[i].type == 73))
			{
				this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
				for (int j = 0; j < 44; j++)
				{
					if (this.inventory[j].IsTheSameAs(this.inventory[i]) && j != i && this.inventory[j].stack < this.inventory[j].maxStack)
					{
						this.inventory[j].stack++;
						this.inventory[i].SetDefaults(0, false);
						this.inventory[i].active = false;
						this.inventory[i].name = "";
						this.inventory[i].type = 0;
						this.inventory[i].stack = 0;
						this.DoCoins(j);
					}
				}
			}
		}

		public Item FillAmmo(int plr, Item newItem)
		{
			Item result;
			for (int i = 44; i < 48; i++)
			{
				if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem.IsTheSameAs(this.inventory[i]))
				{
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (newItem.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
					{
						this.inventory[i].stack += newItem.stack;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						result = new Item();
						return result;
					}
					newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
					ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
					this.inventory[i].stack = this.inventory[i].maxStack;
					this.DoCoins(i);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
			{
				for (int j = 44; j < 48; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = newItem;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(j);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						result = new Item();
						return result;
					}
				}
			}
			result = newItem;
			return result;
		}

		public Item GetItem(int plr, Item newItem)
		{
			Item item = newItem;
			int num = 40;
			Item result;
			if (newItem.noGrabDelay > 0)
			{
				result = item;
			}
			else
			{
				int num2 = 0;
				if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
				{
					num2 = -4;
					num = 44;
				}
				if (item.ammo > 0)
				{
					item = this.FillAmmo(plr, item);
					if (item.type == 0 || item.stack == 0)
					{
						result = new Item();
						return result;
					}
				}
				for (int i = num2; i < 40; i++)
				{
					int num3 = i;
					if (num3 < 0)
					{
						num3 = 44 + i;
					}
					if (this.inventory[num3].type > 0 && this.inventory[num3].stack < this.inventory[num3].maxStack && item.IsTheSameAs(this.inventory[num3]))
					{
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (item.stack + this.inventory[num3].stack <= this.inventory[num3].maxStack)
						{
							this.inventory[num3].stack += item.stack;
							ItemText.NewText(newItem, item.stack);
							this.DoCoins(num3);
							if (plr == Main.myPlayer)
							{
								Recipe.FindRecipes();
							}
							result = new Item();
							return result;
						}
						item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
						ItemText.NewText(newItem, this.inventory[num3].maxStack - this.inventory[num3].stack);
						this.inventory[num3].stack = this.inventory[num3].maxStack;
						this.DoCoins(num3);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
					}
				}
				if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
				{
					for (int j = 0; j < 10; j++)
					{
						if (this.inventory[j].type == 0)
						{
							this.inventory[j] = item;
							ItemText.NewText(newItem, newItem.stack);
							this.DoCoins(j);
							Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
							if (plr == Main.myPlayer)
							{
								Recipe.FindRecipes();
							}
							result = new Item();
							return result;
						}
					}
				}
				for (int k = num - 1; k >= 0; k--)
				{
					if (this.inventory[k].type == 0)
					{
						this.inventory[k] = item;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(k);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						result = new Item();
						return result;
					}
				}
				result = item;
			}
			return result;
		}

		public void PlaceThing()
		{
			if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				bool flag = false;
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
				{
					if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
					{
						flag = true;
					}
					else if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
					{
						flag = true;
					}
				}
				if (((!Main.tile[Player.tileTargetX, Player.tileTargetY].active && !flag) || Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					bool flag2 = false;
					if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0)
						{
							flag2 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59)
						{
							flag2 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
					{
						int num = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
						int num2 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
						int num3 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
						int num4 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
						int num5 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
						int num6 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
						int num7 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
						if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active)
						{
							num = -1;
						}
						if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active)
						{
							num2 = -1;
						}
						if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active)
						{
							num3 = -1;
						}
						if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].active)
						{
							num4 = -1;
						}
						if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].active)
						{
							num5 = -1;
						}
						if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].active)
						{
							num6 = -1;
						}
						if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].active)
						{
							num7 = -1;
						}
						if (num >= 0 && Main.tileSolid[num] && !Main.tileNoAttach[num])
						{
							flag2 = true;
						}
						else if ((num2 >= 0 && Main.tileSolid[num2] && !Main.tileNoAttach[num2]) || (num2 == 5 && num4 == 5 && num6 == 5) || num2 == 124)
						{
							flag2 = true;
						}
						else if ((num3 >= 0 && Main.tileSolid[num3] && !Main.tileNoAttach[num3]) || (num3 == 5 && num5 == 5 && num7 == 5) || num3 == 124)
						{
							flag2 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
						{
							flag2 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
						{
							flag2 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 51)
					{
						if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
						{
							flag2 = true;
						}
					}
					else if ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active && Main.tileSolid[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type]) || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active && Main.tileSolid[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type]) || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 124)) || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 124)) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
					{
						flag2 = true;
					}
					if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
					{
						flag2 = true;
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 78)
						{
							WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
							if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						int num8 = this.inventory[this.selectedItem].placeStyle;
						if (this.inventory[this.selectedItem].createTile == 141)
						{
							num8 = Main.rand.Next(2);
						}
						if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 137)
						{
							if (this.direction < 0)
							{
								num8 = -1;
							}
							else
							{
								num8 = 1;
							}
						}
						if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num8))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num8);
							}
							if (this.inventory[this.selectedItem].createTile == 15)
							{
								if (this.direction == 1)
								{
									Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
									Tile expr_DEA = tile;
									expr_DEA.frameX += 18;
									Tile tile2 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
									Tile expr_E13 = tile2;
									expr_E13.frameX += 18;
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
								}
							}
							else if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
							}
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].createWall >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0) && (int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
				{
					WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
					if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int createWall = this.inventory[this.selectedItem].createWall;
							for (int i = 0; i < 4; i++)
							{
								int num9 = Player.tileTargetX;
								int num10 = Player.tileTargetY;
								if (i == 0)
								{
									num9--;
								}
								if (i == 1)
								{
									num9++;
								}
								if (i == 2)
								{
									num10--;
								}
								if (i == 3)
								{
									num10++;
								}
								if (Main.tile[num9, num10].wall == 0)
								{
									int num11 = 0;
									for (int j = 0; j < 4; j++)
									{
										int num12 = num9;
										int num13 = num10;
										if (j == 0)
										{
											num12--;
										}
										if (j == 1)
										{
											num12++;
										}
										if (j == 2)
										{
											num13--;
										}
										if (j == 3)
										{
											num13++;
										}
										if ((int)Main.tile[num12, num13].wall == createWall)
										{
											num11++;
										}
									}
									if (num11 == 4)
									{
										WorldGen.PlaceWall(num9, num10, createWall, false);
										if ((int)Main.tile[num9, num10].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num9, (float)num10, (float)createWall, 0);
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

		public void ItemCheck(int i)
		{
			int num = this.inventory[this.selectedItem].damage;
			if (num > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					num = (int)((float)num * this.meleeDamage);
				}
				else if (this.inventory[this.selectedItem].ranged)
				{
					num = (int)((float)num * this.rangedDamage);
				}
				else if (this.inventory[this.selectedItem].magic)
				{
					num = (int)((float)num * this.magicDamage);
				}
			}
			if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
			{
				this.releaseUseItem = true;
				if (this.itemAnimation == 1 && this.inventory[this.selectedItem].stack > 0)
				{
					if (this.inventory[this.selectedItem].shoot > 0 && this.whoAmi != Main.myPlayer && this.controlUseItem)
					{
						this.itemAnimation = 2;
					}
					else
					{
						this.itemAnimation = 0;
					}
				}
			}
			if (this.itemAnimation == 0 && this.reuseDelay > 0)
			{
				this.itemAnimation = this.reuseDelay;
				this.itemTime = this.reuseDelay;
				this.reuseDelay = 0;
			}
			if (this.controlUseItem && this.releaseUseItem && (this.inventory[this.selectedItem].headSlot > 0 || this.inventory[this.selectedItem].bodySlot > 0 || this.inventory[this.selectedItem].legSlot > 0))
			{
				if (this.inventory[this.selectedItem].useStyle == 0)
				{
					this.releaseUseItem = false;
				}
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num2 = Player.tileTargetX;
					int num3 = Player.tileTargetY;
					if (Main.tile[num2, num3].active && Main.tile[num2, num3].type == 128)
					{
						int num4 = (int)Main.tile[num2, num3].frameY;
						int j = 0;
						if (this.inventory[this.selectedItem].bodySlot >= 0)
						{
							j = 1;
						}
						if (this.inventory[this.selectedItem].legSlot >= 0)
						{
							j = 2;
						}
						num4 /= 18;
						while (j > num4)
						{
							num3++;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						while (j < num4)
						{
							num3--;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						int k;
						for (k = (int)Main.tile[num2, num3].frameX; k >= 100; k -= 100)
						{
						}
						if (k >= 36)
						{
							k -= 36;
						}
						num2 -= k / 18;
						int l = (int)Main.tile[num2, num3].frameX;
						WorldGen.KillTile(num2, num3, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num2, (float)num3, 1f, 0);
						}
						while (l >= 100)
						{
							l -= 100;
						}
						if (num4 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (num4 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (num4 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
					}
				}
			}
			if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
			{
				bool flag = true;
				if (this.inventory[this.selectedItem].shoot == 0)
				{
					this.itemRotation = 0f;
				}
				if (this.wet && (this.inventory[this.selectedItem].shoot == 85 || this.inventory[this.selectedItem].shoot == 15 || this.inventory[this.selectedItem].shoot == 34))
				{
					flag = false;
				}
				if (this.noItems)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52)
				{
					for (int m = 0; m < 1000; m++)
					{
						if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.inventory[this.selectedItem].shoot)
						{
							flag = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 106)
				{
					int num5 = 0;
					for (int n = 0; n < 1000; n++)
					{
						if (Main.projectile[n].active && Main.projectile[n].owner == Main.myPlayer && Main.projectile[n].type == this.inventory[this.selectedItem].shoot)
						{
							num5++;
						}
					}
					if (num5 >= this.inventory[this.selectedItem].stack)
					{
						flag = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32)
				{
					for (int num6 = 0; num6 < 1000; num6++)
					{
						if (Main.projectile[num6].active && Main.projectile[num6].owner == Main.myPlayer && Main.projectile[num6].type == this.inventory[this.selectedItem].shoot && Main.projectile[num6].ai[0] != 2f)
						{
							flag = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 73)
				{
					for (int num7 = 0; num7 < 1000; num7++)
					{
						if (Main.projectile[num7].active && Main.projectile[num7].owner == Main.myPlayer && Main.projectile[num7].type == 74)
						{
							flag = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].potion && flag)
				{
					if (this.potionDelay <= 0)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					else
					{
						flag = false;
					}
				}
				if (this.inventory[this.selectedItem].mana > 0 && this.silence)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].mana > 0 && flag)
				{
					if (this.inventory[this.selectedItem].type != 127 || !this.spaceGun)
					{
						if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
						{
							this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
						}
						else if (this.manaFlower)
						{
							this.QuickMana();
							if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
							{
								this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 0)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
				}
				if (this.inventory[this.selectedItem].type == 43 && Main.dayTime)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].type == 544 && Main.dayTime)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].type == 556 && Main.dayTime)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].type == 557 && Main.dayTime)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].type == 70 && !this.zoneEvil)
				{
					flag = false;
				}
				if (this.inventory[this.selectedItem].shoot == 17 && flag && i == Main.myPlayer)
				{
					int num8 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num9 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					if (Main.tile[num8, num9].active && (Main.tile[num8, num9].type == 0 || Main.tile[num8, num9].type == 2 || Main.tile[num8, num9].type == 23))
					{
						WorldGen.KillTile(num8, num9, false, false, true);
						if (!Main.tile[num8, num9].active)
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)num8, (float)num9, 0f, 0);
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				if (flag && this.inventory[this.selectedItem].useAmmo > 0)
				{
					flag = false;
					for (int num10 = 0; num10 < 48; num10++)
					{
						if (this.inventory[num10].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num10].stack > 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					if (this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0)
					{
						this.toolTime = 1;
					}
					if (this.grappling[0] > -1)
					{
						if (this.controlRight)
						{
							this.direction = 1;
						}
						else if (this.controlLeft)
						{
							this.direction = -1;
						}
					}
					this.channel = this.inventory[this.selectedItem].channel;
					this.attackCD = 0;
					if (this.inventory[this.selectedItem].melee)
					{
						this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
						this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
					}
					else
					{
						this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
						this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
						this.reuseDelay = this.inventory[this.selectedItem].reuseDelay;
					}
					if (this.inventory[this.selectedItem].useSound > 0)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[this.selectedItem].useSound);
					}
				}
				if (flag && (this.inventory[this.selectedItem].shoot == 18 || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 86))
				{
					for (int num11 = 0; num11 < 1000; num11++)
					{
						if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == this.inventory[this.selectedItem].shoot)
						{
							Main.projectile[num11].Kill();
						}
						if (this.inventory[this.selectedItem].shoot == 72)
						{
							if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == 86)
							{
								Main.projectile[num11].Kill();
							}
							if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == 87)
							{
								Main.projectile[num11].Kill();
							}
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool flag2 = this.channel;
				this.channel = false;
			}
			if (this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
				}
				else
				{
					this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
				}
				if (this.inventory[this.selectedItem].mana > 0)
				{
					this.manaRegenDelay = (int)this.maxRegenDelay;
				}
				if (Main.dedServ)
				{
					this.itemHeight = this.inventory[this.selectedItem].height;
					this.itemWidth = this.inventory[this.selectedItem].width;
				}
				else
				{
					this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
					this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
				}
				this.itemAnimation--;
				if (!Main.dedServ)
				{
					if (this.inventory[this.selectedItem].useStyle == 1)
					{
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
						{
							float num12 = 10f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
							{
								num12 = 14f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
							{
								num12 = 28f;
							}
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num12) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 24f;
						}
						else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
						{
							float num13 = 10f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
							{
								num13 = 18f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
							{
								num13 = 28f;
							}
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num13) * (float)this.direction;
							num13 = 10f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
							{
								num13 = 8f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
							{
								num13 = 14f;
							}
							this.itemLocation.Y = this.position.Y + num13;
						}
						else
						{
							float num14 = 6f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
							{
								num14 = 14f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
							{
								num14 = 28f;
							}
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num14) * (float)this.direction;
							num14 = 10f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
							{
								num14 = 10f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
							{
								num14 = 14f;
							}
							this.itemLocation.Y = this.position.Y + num14;
						}
						this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * -(float)this.direction * 3.5f - (float)this.direction * 0.3f;
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 2)
					{
						this.itemRotation = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)this.direction * 2f + -1.4f * (float)this.direction;
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.5)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 12f * (float)this.direction) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction * 4f;
						}
						else
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 16f * (float)this.direction) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 3)
					{
						if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
						{
							this.itemLocation.X = -1000f;
							this.itemLocation.Y = -1000f;
							this.itemRotation = -1.3f * (float)this.direction;
						}
						else
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 4f) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 24f;
							float num15 = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (float)this.direction * this.inventory[this.selectedItem].scale * 1.2f - (float)(10 * this.direction);
							if (num15 > -4f && this.direction == -1)
							{
								num15 = -8f;
							}
							if (num15 < 4f && this.direction == 1)
							{
								num15 = 8f;
							}
							this.itemLocation.X = this.itemLocation.X - num15;
							this.itemRotation = 0.8f * (float)this.direction;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 4)
					{
						this.itemRotation = 0f;
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 14f * (float)this.direction - 4f) * (float)this.direction;
						this.itemLocation.Y = this.position.Y + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f + 4f;
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 5)
					{
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
						this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
					}
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 1)
			{
				if (Main.dedServ)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
				}
				else
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f + 2f) * (float)this.direction;
					if (this.inventory[this.selectedItem].type == 282 || this.inventory[this.selectedItem].type == 286)
					{
						this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 2);
						this.itemLocation.Y = this.itemLocation.Y + 4f;
					}
				}
				this.itemLocation.Y = this.position.Y + 24f;
				this.itemRotation = 0f;
				if (this.gravDir == -1f)
				{
					this.itemRotation = -this.itemRotation;
					this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 2)
			{
				this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
				this.itemLocation.Y = this.position.Y + 16f;
				this.itemRotation = 0.79f * -(float)this.direction;
				if (this.gravDir == -1f)
				{
					this.itemRotation = -this.itemRotation;
					this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 3 && !Main.dedServ)
			{
				this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
				this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
				this.itemRotation = 0f;
			}
			if (((this.inventory[this.selectedItem].type == 8 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523)
			{
				float r = 1f;
				float g = 0.95f;
				float b = 0.8f;
				int num16 = 0;
				if (this.inventory[this.selectedItem].type == 523)
				{
					num16 = 8;
				}
				else if (this.inventory[this.selectedItem].type >= 427)
				{
					num16 = this.inventory[this.selectedItem].type - 426;
				}
				if (num16 == 1)
				{
					r = 0f;
					g = 0.1f;
					b = 1.3f;
				}
				else if (num16 == 2)
				{
					r = 1f;
					g = 0.1f;
					b = 0.1f;
				}
				else if (num16 == 3)
				{
					r = 0f;
					g = 1f;
					b = 0.1f;
				}
				else if (num16 == 4)
				{
					r = 0.9f;
					g = 0f;
					b = 0.9f;
				}
				else if (num16 == 5)
				{
					r = 1.3f;
					g = 1.3f;
					b = 1.3f;
				}
				else if (num16 == 6)
				{
					r = 0.9f;
					g = 0.9f;
					b = 0f;
				}
				else if (num16 == 7)
				{
					r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					g = 0.3f;
					b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
				}
				else if (num16 == 8)
				{
					b = 0.7f;
					r = 0.85f;
					g = 1f;
				}
				int num17 = num16;
				if (num17 == 0)
				{
					num17 = 6;
				}
				else if (num17 == 8)
				{
					num17 = 75;
				}
				else
				{
					num17 = 58 + num17;
				}
				int maxValue = 20;
				if (this.itemAnimation > 0)
				{
					maxValue = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						Vector2 vector = new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir);
						int num18 = 4;
						int num19 = 4;
						int type = num17;
						float speedX = 0f;
						float speedY = 0f;
						int alpha = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector, num18, num19, type, speedX, speedY, alpha, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X - 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
				}
				else
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						Vector2 vector2 = new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir);
						int num20 = 4;
						int num21 = 4;
						int type2 = num17;
						float speedX2 = 0f;
						float speedY2 = 0f;
						int alpha2 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector2, num20, num21, type2, speedX2, speedY2, alpha2, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X + 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
				}
			}
			if (this.inventory[this.selectedItem].type == 105 && !this.wet)
			{
				int maxValue2 = 20;
				if (this.itemAnimation > 0)
				{
					maxValue2 = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						Vector2 vector3 = new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir);
						int num22 = 4;
						int num23 = 4;
						int type3 = 6;
						float speedX3 = 0f;
						float speedY3 = 0f;
						int alpha3 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector3, num22, num23, type3, speedX3, speedY3, alpha3, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
				else
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						Vector2 vector4 = new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir);
						int num24 = 4;
						int num25 = 4;
						int type4 = 6;
						float speedX4 = 0f;
						float speedY4 = 0f;
						int alpha4 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector4, num24, num25, type4, speedX4, speedY4, alpha4, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
			}
			else if (this.inventory[this.selectedItem].type == 148 && !this.wet)
			{
				int maxValue3 = 10;
				if (this.itemAnimation > 0)
				{
					maxValue3 = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						Vector2 vector5 = new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir);
						int num26 = 4;
						int num27 = 4;
						int type5 = 29;
						float speedX5 = 0f;
						float speedY5 = 0f;
						int alpha5 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector5, num26, num27, type5, speedX5, speedY5, alpha5, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.3f, 0.3f, 0.75f);
				}
				else
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						Vector2 vector6 = new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir);
						int num28 = 4;
						int num29 = 4;
						int type6 = 29;
						float speedX6 = 0f;
						float speedY6 = 0f;
						int alpha6 = 100;
						Color newColor = default(Color);
						Dust.NewDust(vector6, num28, num29, type6, speedX6, speedY6, alpha6, newColor, 1f);
					}
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.3f, 0.3f, 0.75f);
				}
			}
			if (this.inventory[this.selectedItem].type == 282)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
			}
			if (this.inventory[this.selectedItem].type == 286)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
			}
			if (this.controlUseItem)
			{
				this.releaseUseItem = false;
			}
			else
			{
				this.releaseUseItem = true;
			}
			if (this.itemTime > 0)
			{
				this.itemTime--;
			}
			if (i == Main.myPlayer)
			{
				if (this.inventory[this.selectedItem].shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0)
				{
					int num30 = this.inventory[this.selectedItem].shoot;
					float num31 = this.inventory[this.selectedItem].shootSpeed;
					if (this.inventory[this.selectedItem].melee && num30 != 25 && num30 != 26 && num30 != 35)
					{
						num31 /= this.meleeSpeed;
					}
					bool flag3 = false;
					int num32 = num;
					float num33 = this.inventory[this.selectedItem].knockBack;
					if (num30 == 13 || num30 == 32)
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num34 = 0; num34 < 1000; num34++)
						{
							if (Main.projectile[num34].active && Main.projectile[num34].owner == i && Main.projectile[num34].type == 13)
							{
								Main.projectile[num34].Kill();
							}
						}
					}
					if (this.inventory[this.selectedItem].useAmmo > 0)
					{
						Item item = new Item();
						bool flag4 = false;
						for (int num35 = 44; num35 < 48; num35++)
						{
							if (this.inventory[num35].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num35].stack > 0)
							{
								item = this.inventory[num35];
								flag3 = true;
								flag4 = true;
								break;
							}
						}
						if (!flag4)
						{
							for (int num36 = 0; num36 < 44; num36++)
							{
								if (this.inventory[num36].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num36].stack > 0)
								{
									item = this.inventory[num36];
									flag3 = true;
									break;
								}
							}
						}
						if (flag3)
						{
							if (item.shoot > 0)
							{
								num30 = item.shoot;
							}
							if (num30 == 42)
							{
								if (item.type == 370)
								{
									num30 = 65;
									num32 += 5;
								}
								else if (item.type == 408)
								{
									num30 = 68;
									num32 += 5;
								}
							}
							num31 += item.shootSpeed;
							if (item.ranged)
							{
								if (item.damage > 0)
								{
									num32 += (int)((float)item.damage * this.rangedDamage);
								}
							}
							else
							{
								num32 += item.damage;
							}
							if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
							{
								if (num31 < 20f)
								{
									num31 *= 1.2f;
									if (num31 > 20f)
									{
										num31 = 20f;
									}
								}
								num32 = (int)((double)((float)num32) * 1.2);
							}
							num33 += item.knockBack;
							bool flag5 = false;
							if (this.inventory[this.selectedItem].type == 98 && Main.rand.Next(3) == 0)
							{
								flag5 = true;
							}
							if (this.inventory[this.selectedItem].type == 533 && Main.rand.Next(2) == 0)
							{
								flag5 = true;
							}
							if (this.inventory[this.selectedItem].type == 434 && this.itemAnimation < this.inventory[this.selectedItem].useAnimation - 2)
							{
								flag5 = true;
							}
							if (this.ammoCost80 && Main.rand.Next(5) == 0)
							{
								flag5 = true;
							}
							if (this.ammoCost75 && Main.rand.Next(4) == 0)
							{
								flag5 = true;
							}
							if (num30 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
							{
								flag5 = true;
							}
							if (!flag5)
							{
								item.stack--;
								if (item.stack <= 0)
								{
									item.active = false;
									item.name = "";
									item.type = 0;
								}
							}
						}
					}
					else
					{
						flag3 = true;
					}
					if (num30 == 72)
					{
						int num37 = Main.rand.Next(3);
						if (num37 == 0)
						{
							num30 = 72;
						}
						else if (num37 == 1)
						{
							num30 = 86;
						}
						else if (num37 == 2)
						{
							num30 = 87;
						}
					}
					if (num30 == 73)
					{
						for (int num38 = 0; num38 < 1000; num38++)
						{
							if (Main.projectile[num38].active && Main.projectile[num38].owner == i)
							{
								if (Main.projectile[num38].type == 73)
								{
									num30 = 74;
								}
								if (Main.projectile[num38].type == 74)
								{
									flag3 = false;
								}
							}
						}
					}
					if (flag3)
					{
						if (this.inventory[this.selectedItem].mech && this.kbGlove)
						{
							num33 *= 1.7f;
						}
						if (num30 == 1 && this.inventory[this.selectedItem].type == 120)
						{
							num30 = 2;
						}
						this.itemTime = this.inventory[this.selectedItem].useTime;
						if ((float)Main.mouseX + Main.screenPosition.X > this.position.X + (float)this.width * 0.5f)
						{
							this.direction = 1;
						}
						else
						{
							this.direction = -1;
						}
						Vector2 vector7 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						if (num30 == 9)
						{
							vector7 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)Main.rand.Next(601) * -(float)this.direction, this.position.Y + (float)this.height * 0.5f - 300f - (float)Main.rand.Next(100));
							num33 = 0f;
						}
						else if (num30 == 51)
						{
							vector7.Y -= 6f * this.gravDir;
						}
						float num39 = (float)Main.mouseX + Main.screenPosition.X - vector7.X;
						float num40 = (float)Main.mouseY + Main.screenPosition.Y - vector7.Y;
						float num41 = (float)Math.Sqrt((double)(num39 * num39 + num40 * num40));
						float num42 = num41;
						num41 = num31 / num41;
						num39 *= num41;
						num40 *= num41;
						if (num30 == 12)
						{
							vector7.X += num39 * 3f;
							vector7.Y += num40 * 3f;
						}
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = (float)Math.Atan2((double)(num40 * (float)this.direction), (double)(num39 * (float)this.direction));
							NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
						if (num30 == 17)
						{
							vector7.X = (float)Main.mouseX + Main.screenPosition.X;
							vector7.Y = (float)Main.mouseY + Main.screenPosition.Y;
						}
						if (num30 == 76)
						{
							num30 += Main.rand.Next(3);
							num42 /= (float)(Main.screenHeight / 2);
							if (num42 > 1f)
							{
								num42 = 1f;
							}
							float num43 = num39 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num44 = num40 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num43 *= num42 + 0.25f;
							num44 *= num42 + 0.25f;
							int num45 = Projectile.NewProjectile(vector7.X, vector7.Y, num43, num44, num30, num32, num33, i);
							Main.projectile[num45].ai[1] = 1f;
							num42 = num42 * 2f - 1f;
							if (num42 < -1f)
							{
								num42 = -1f;
							}
							if (num42 > 1f)
							{
								num42 = 1f;
							}
							Main.projectile[num45].ai[0] = num42;
							NetMessage.SendData(27, -1, -1, "", num45, 0f, 0f, 0f, 0);
						}
						else if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
						{
							float speedX7 = num39 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float speedY7 = num40 + (float)Main.rand.Next(-40, 41) * 0.01f;
							Projectile.NewProjectile(vector7.X, vector7.Y, speedX7, speedY7, num30, num32, num33, i);
						}
						else if (this.inventory[this.selectedItem].type == 518)
						{
							float num46 = num39;
							float num47 = num40;
							num46 += (float)Main.rand.Next(-40, 41) * 0.04f;
							num47 += (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(vector7.X, vector7.Y, num46, num47, num30, num32, num33, i);
						}
						else if (this.inventory[this.selectedItem].type == 534)
						{
							for (int num48 = 0; num48 < 4; num48++)
							{
								float num49 = num39;
								float num50 = num40;
								num49 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num50 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector7.X, vector7.Y, num49, num50, num30, num32, num33, i);
							}
						}
						else if (this.inventory[this.selectedItem].type == 434)
						{
							float num51 = num39;
							float num52 = num40;
							if (this.itemAnimation < 5)
							{
								num51 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num52 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num51 *= 1.1f;
								num52 *= 1.1f;
							}
							else if (this.itemAnimation < 10)
							{
								num51 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num52 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num51 *= 1.05f;
								num52 *= 1.05f;
							}
							Projectile.NewProjectile(vector7.X, vector7.Y, num51, num52, num30, num32, num33, i);
						}
						else
						{
							int num53 = Projectile.NewProjectile(vector7.X, vector7.Y, num39, num40, num30, num32, num33, i);
							if (num30 == 80)
							{
								Main.projectile[num53].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num53].ai[1] = (float)Player.tileTargetY;
							}
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 5)
					{
						this.itemRotation = 0f;
						NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					}
				}
				if (this.whoAmi == Main.myPlayer && (this.inventory[this.selectedItem].type == 509 || this.inventory[this.selectedItem].type == 510) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
					{
						int i2 = Player.tileTargetX;
						int j2 = Player.tileTargetY;
						if (this.inventory[this.selectedItem].type == 509)
						{
							int num54 = -1;
							for (int num55 = 0; num55 < 48; num55++)
							{
								if (this.inventory[num55].stack > 0 && this.inventory[num55].type == 530)
								{
									num54 = num55;
									break;
								}
							}
							if (num54 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								this.inventory[num54].stack--;
								if (this.inventory[num54].stack <= 0)
								{
									this.inventory[num54].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else if (WorldGen.KillWire(i2, j2))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
						}
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num56 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
					float num57 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
					float num58 = (float)Math.Sqrt((double)(num56 * num56 + num57 * num57));
					num58 /= (float)(Main.screenHeight / 2);
					if (num58 > 1f)
					{
						num58 = 1f;
					}
					num58 = num58 * 2f - 1f;
					if (num58 < -1f)
					{
						num58 = -1f;
					}
					if (num58 > 1f)
					{
						num58 = 1f;
					}
					Main.harpNote = num58;
					int style = 26;
					if (this.inventory[this.selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
					NetMessage.SendData(58, -1, -1, "", this.whoAmi, num58, 0f, 0f, 0);
				}
				if (this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (this.inventory[this.selectedItem].type == 205)
						{
							bool lava = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
							int num59 = 0;
							for (int num60 = Player.tileTargetX - 1; num60 <= Player.tileTargetX + 1; num60++)
							{
								for (int num61 = Player.tileTargetY - 1; num61 <= Player.tileTargetY + 1; num61++)
								{
									if (Main.tile[num60, num61].lava == lava)
									{
										num59 += (int)Main.tile[num60, num61].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num59 > 100)
							{
								bool lava2 = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
								{
									this.inventory[this.selectedItem].SetDefaults(206, false);
								}
								else
								{
									this.inventory[this.selectedItem].SetDefaults(207, false);
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								this.itemTime = this.inventory[this.selectedItem].useTime;
								int num62 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
								Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
								else
								{
									Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
								}
								for (int num63 = Player.tileTargetX - 1; num63 <= Player.tileTargetX + 1; num63++)
								{
									for (int num64 = Player.tileTargetY - 1; num64 <= Player.tileTargetY + 1; num64++)
									{
										if (num62 < 256 && Main.tile[num63, num64].lava == lava)
										{
											int num65 = (int)Main.tile[num63, num64].liquid;
											if (num65 + num62 > 255)
											{
												num65 = 255 - num62;
											}
											num62 += num65;
											Tile tile = Main.tile[num63, num64];
											Tile expr_47F8 = tile;
											expr_47F8.liquid -= (byte)num65;
											Main.tile[num63, num64].lava = lava2;
											if (Main.tile[num63, num64].liquid == 0)
											{
												Main.tile[num63, num64].lava = false;
											}
											WorldGen.SquareTileFrame(num63, num64, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num63, num64);
											}
											else
											{
												Liquid.AddWater(num63, num64);
											}
										}
									}
								}
							}
						}
						else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							if (this.inventory[this.selectedItem].type == 207)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].lava = true;
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									this.inventory[this.selectedItem].SetDefaults(205, false);
									this.itemTime = this.inventory[this.selectedItem].useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || !Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
							{
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								this.inventory[this.selectedItem].SetDefaults(205, false);
								this.itemTime = this.inventory[this.selectedItem].useTime;
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
							}
						}
					}
				}
				if (!this.channel)
				{
					this.toolTime = this.itemTime;
				}
				else
				{
					this.toolTime--;
					if (this.toolTime < 0)
					{
						if (this.inventory[this.selectedItem].pick > 0)
						{
							this.toolTime = this.inventory[this.selectedItem].useTime;
						}
						else
						{
							this.toolTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
						}
					}
				}
				if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					bool flag6 = true;
					this.showItemIcon = true;
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
					{
						if ((this.inventory[this.selectedItem].pick > 0 && !Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].axe > 0 && Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].hammer > 0 && Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							flag6 = false;
						}
						if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
							{
								this.hitTile = 0;
								this.hitTileX = Player.tileTargetX;
								this.hitTileY = Player.tileTargetY;
							}
							if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								this.hitTile = 100;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type != 27)
							{
								if (Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									flag6 = false;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 48)
									{
										this.hitTile += this.inventory[this.selectedItem].hammer / 2;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 129)
									{
										this.hitTile += this.inventory[this.selectedItem].hammer * 2;
									}
									else
									{
										this.hitTile += this.inventory[this.selectedItem].hammer;
									}
									if ((double)Player.tileTargetY > Main.rockLayer && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 77 && this.inventory[this.selectedItem].hammer < 60)
									{
										this.hitTile = 0;
									}
									if (this.inventory[this.selectedItem].hammer > 0)
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (this.inventory[this.selectedItem].hammer < 80 || !Main.hardMode))
										{
											this.hitTile = 0;
											this.Hurt(this.statLife / 2, -this.direction, false, false, Player.getDeathMessage(-1, -1, -1, 4), false);
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										if (this.hitTile >= 100)
										{
											if (Main.netMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
											{
												WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
												NetMessage.SendData(34, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
											}
											else
											{
												this.hitTile = 0;
												WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
												}
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										this.itemTime = this.inventory[this.selectedItem].useTime;
									}
								}
								else if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 30 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 124)
									{
										this.hitTile += this.inventory[this.selectedItem].axe * 5;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
									{
										this.hitTile += this.inventory[this.selectedItem].axe * 3;
									}
									else
									{
										this.hitTile += this.inventory[this.selectedItem].axe;
									}
									if (this.inventory[this.selectedItem].axe > 0)
									{
										if (this.hitTile >= 100)
										{
											this.hitTile = 0;
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										this.itemTime = this.inventory[this.selectedItem].useTime;
									}
								}
								else if (this.inventory[this.selectedItem].pick > 0)
								{
									if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117)
									{
										this.hitTile += this.inventory[this.selectedItem].pick / 2;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107)
									{
										this.hitTile += this.inventory[this.selectedItem].pick / 2;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108)
									{
										this.hitTile += this.inventory[this.selectedItem].pick / 3;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111)
									{
										this.hitTile += this.inventory[this.selectedItem].pick / 4;
									}
									else
									{
										this.hitTile += this.inventory[this.selectedItem].pick;
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 && this.inventory[this.selectedItem].pick < 65)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 && this.inventory[this.selectedItem].pick < 65)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 && this.inventory[this.selectedItem].pick < 55)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 22 && (double)Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 56 && this.inventory[this.selectedItem].pick < 65)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 && this.inventory[this.selectedItem].pick < 65)
									{
										this.hitTile = 0;
									}
									else if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
									{
										if ((double)Player.tileTargetX < (double)Main.maxTilesX * 0.25 || (double)Player.tileTargetX > (double)Main.maxTilesX * 0.75)
										{
											this.hitTile = 0;
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 && this.inventory[this.selectedItem].pick < 100)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 && this.inventory[this.selectedItem].pick < 110)
									{
										this.hitTile = 0;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 && this.inventory[this.selectedItem].pick < 120)
									{
										this.hitTile = 0;
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 40 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 53 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 57 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 123)
									{
										this.hitTile += this.inventory[this.selectedItem].pick;
									}
									if (this.hitTile >= 100 && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 2 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 23 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 60 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 70 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 109))
									{
										this.hitTile = 0;
									}
									if (this.hitTile >= 100)
									{
										this.hitTile = 0;
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
										}
									}
									this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
								}
							}
						}
					}
					int num66 = Player.tileTargetX;
					int num67 = Player.tileTargetY;
					bool flag7 = true;
					if (Main.tile[num66, num67].wall > 0)
					{
						if (!Main.wallHouse[(int)Main.tile[num66, num67].wall])
						{
							for (int num68 = num66 - 1; num68 < num66 + 2; num68++)
							{
								for (int num69 = num67 - 1; num69 < num67 + 2; num69++)
								{
									if (Main.tile[num68, num69].wall != Main.tile[num66, num67].wall)
									{
										flag7 = false;
										break;
									}
								}
							}
						}
						else
						{
							flag7 = false;
						}
					}
					if (flag7 && !Main.tile[num66, num67].active)
					{
						int num70 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num70 = 0;
						}
						int num71 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num71 = 0;
						}
						for (int num72 = Player.tileTargetX + num70; num72 <= Player.tileTargetX + num70 + 1; num72++)
						{
							for (int num73 = Player.tileTargetY + num71; num73 <= Player.tileTargetY + num71 + 1; num73++)
							{
								if (flag7)
								{
									num66 = num72;
									num67 = num73;
									if (Main.tile[num66, num67].wall > 0)
									{
										if (!Main.wallHouse[(int)Main.tile[num66, num67].wall])
										{
											for (int num74 = num66 - 1; num74 < num66 + 2; num74++)
											{
												for (int num75 = num67 - 1; num75 < num67 + 2; num75++)
												{
													if (Main.tile[num74, num75].wall != Main.tile[num66, num67].wall)
													{
														flag7 = false;
														break;
													}
												}
											}
										}
										else
										{
											flag7 = false;
										}
									}
								}
							}
						}
					}
					if (flag6 && Main.tile[num66, num67].wall > 0 && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
					{
						bool flag8 = true;
						if (!Main.wallHouse[(int)Main.tile[num66, num67].wall])
						{
							flag8 = false;
							for (int num76 = num66 - 1; num76 < num66 + 2; num76++)
							{
								for (int num77 = num67 - 1; num77 < num67 + 2; num77++)
								{
									if (Main.tile[num76, num77].wall != Main.tile[num66, num67].wall)
									{
										flag8 = true;
										break;
									}
								}
							}
						}
						if (flag8)
						{
							if (this.hitTileX != num66 || this.hitTileY != num67)
							{
								this.hitTile = 0;
								this.hitTileX = num66;
								this.hitTileY = num67;
							}
							this.hitTile += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
							if (this.hitTile >= 100)
							{
								this.hitTile = 0;
								WorldGen.KillWall(num66, num67, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num66, (float)num67, 0f, 0);
								}
							}
							else
							{
								WorldGen.KillWall(num66, num67, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num66, (float)num67, 1f, 0);
								}
							}
							this.itemTime = this.inventory[this.selectedItem].useTime / 2;
						}
					}
				}
				if (this.inventory[this.selectedItem].type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statLifeMax += 20;
					this.statLife += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(20);
					}
				}
				if (this.inventory[this.selectedItem].type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statManaMax += 20;
					this.statMana += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(20);
					}
				}
				this.PlaceThing();
			}
			if (this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee && this.itemAnimation > 0)
			{
				bool flag9 = false;
				Rectangle rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
				if (!Main.dedServ)
				{
					rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
				}
				rectangle.Width = (int)((float)rectangle.Width * this.inventory[this.selectedItem].scale);
				rectangle.Height = (int)((float)rectangle.Height * this.inventory[this.selectedItem].scale);
				if (this.direction == -1)
				{
					rectangle.X -= rectangle.Width;
				}
				if (this.gravDir == 1f)
				{
					rectangle.Y -= rectangle.Height;
				}
				if (this.inventory[this.selectedItem].useStyle == 1)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						if (this.direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)this.gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.1);
					}
					else if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
					{
						if (this.direction == 1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.2);
						}
						rectangle.Width *= 2;
						rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)this.gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.4);
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						flag9 = true;
					}
					else
					{
						if (this.direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.6);
						rectangle.Height = (int)((double)rectangle.Height * 0.6);
					}
				}
				float num78 = this.gravDir;
				if (!flag9)
				{
					if ((this.inventory[this.selectedItem].type == 44 || this.inventory[this.selectedItem].type == 45 || this.inventory[this.selectedItem].type == 46 || this.inventory[this.selectedItem].type == 103 || this.inventory[this.selectedItem].type == 104) && Main.rand.Next(15) == 0)
					{
						Vector2 vector9 = new Vector2((float)rectangle.X, (float)rectangle.Y);
						int num79 = rectangle.Width;
						int num80 = rectangle.Height;
						int type7 = 14;
						float speedX8 = (float)(this.direction * 2);
						float speedY8 = 0f;
						int alpha7 = 150;
						Color newColor = default(Color);
						Dust.NewDust(vector9, num79, num80, type7, speedX8, speedY8, alpha7, newColor, 1.3f);
					}
					if (this.inventory[this.selectedItem].type == 273)
					{
						Color newColor;
						if (Main.rand.Next(5) == 0)
						{
							Vector2 vector10 = new Vector2((float)rectangle.X, (float)rectangle.Y);
							int num81 = rectangle.Width;
							int num82 = rectangle.Height;
							int type8 = 14;
							float speedX9 = (float)(this.direction * 2);
							float speedY9 = 0f;
							int alpha8 = 150;
							newColor = default(Color);
							Dust.NewDust(vector10, num81, num82, type8, speedX9, speedY9, alpha8, newColor, 1.4f);
						}
						Vector2 vector11 = new Vector2((float)rectangle.X, (float)rectangle.Y);
						int num83 = rectangle.Width;
						int num84 = rectangle.Height;
						int type9 = 27;
						float speedX10 = this.velocity.X * 0.2f + (float)(this.direction * 3);
						float speedY10 = this.velocity.Y * 0.2f;
						int alpha9 = 100;
						newColor = default(Color);
						int num85 = Dust.NewDust(vector11, num83, num84, type9, speedX10, speedY10, alpha9, newColor, 1.2f);
						Main.dust[num85].noGravity = true;
						Dust dust = Main.dust[num85];
						dust.velocity.X = dust.velocity.X / 2f;
						Dust dust2 = Main.dust[num85];
						dust2.velocity.Y = dust2.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 65)
					{
						if (Main.rand.Next(5) == 0)
						{
							Vector2 vector12 = new Vector2((float)rectangle.X, (float)rectangle.Y);
							int num86 = rectangle.Width;
							int num87 = rectangle.Height;
							int type10 = 58;
							float speedX11 = 0f;
							float speedY11 = 0f;
							int alpha10 = 150;
							Color newColor = default(Color);
							Dust.NewDust(vector12, num86, num87, type10, speedX11, speedY11, alpha10, newColor, 1.2f);
						}
						if (Main.rand.Next(10) == 0)
						{
							Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), default(Vector2), Main.rand.Next(16, 18), 1f);
						}
					}
					if (this.inventory[this.selectedItem].type == 190 || this.inventory[this.selectedItem].type == 213)
					{
						Vector2 vector13 = new Vector2((float)rectangle.X, (float)rectangle.Y);
						int num88 = rectangle.Width;
						int num89 = rectangle.Height;
						int type11 = 40;
						float speedX12 = this.velocity.X * 0.2f + (float)(this.direction * 3);
						float speedY12 = this.velocity.Y * 0.2f;
						int alpha11 = 0;
						Color newColor = default(Color);
						int num90 = Dust.NewDust(vector13, num88, num89, type11, speedX12, speedY12, alpha11, newColor, 1.2f);
						Main.dust[num90].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 121)
					{
						for (int num91 = 0; num91 < 2; num91++)
						{
							Vector2 vector14 = new Vector2((float)rectangle.X, (float)rectangle.Y);
							int num92 = rectangle.Width;
							int num93 = rectangle.Height;
							int type12 = 6;
							float speedX13 = this.velocity.X * 0.2f + (float)(this.direction * 3);
							float speedY13 = this.velocity.Y * 0.2f;
							int alpha12 = 100;
							Color newColor = default(Color);
							int num94 = Dust.NewDust(vector14, num92, num93, type12, speedX13, speedY13, alpha12, newColor, 2.5f);
							Main.dust[num94].noGravity = true;
							Dust dust3 = Main.dust[num94];
							dust3.velocity.X = dust3.velocity.X * 2f;
							Dust dust4 = Main.dust[num94];
							dust4.velocity.Y = dust4.velocity.Y * 2f;
						}
					}
					if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
					{
						Vector2 vector15 = new Vector2((float)rectangle.X, (float)rectangle.Y);
						int num95 = rectangle.Width;
						int num96 = rectangle.Height;
						int type13 = 6;
						float speedX14 = this.velocity.X * 0.2f + (float)(this.direction * 3);
						float speedY14 = this.velocity.Y * 0.2f;
						int alpha13 = 100;
						Color newColor = default(Color);
						int num97 = Dust.NewDust(vector15, num95, num96, type13, speedX14, speedY14, alpha13, newColor, 1.9f);
						Main.dust[num97].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 155)
					{
						Vector2 vector16 = new Vector2((float)rectangle.X, (float)rectangle.Y);
						int num98 = rectangle.Width;
						int num99 = rectangle.Height;
						int type14 = 29;
						float speedX15 = this.velocity.X * 0.2f + (float)(this.direction * 3);
						float speedY15 = this.velocity.Y * 0.2f;
						int alpha14 = 100;
						Color newColor = default(Color);
						int num100 = Dust.NewDust(vector16, num98, num99, type14, speedX15, speedY15, alpha14, newColor, 2f);
						Main.dust[num100].noGravity = true;
						Dust dust5 = Main.dust[num100];
						dust5.velocity.X = dust5.velocity.X / 2f;
						Dust dust6 = Main.dust[num100];
						dust6.velocity.Y = dust6.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368)
					{
						if (Main.rand.Next(3) == 0)
						{
							Vector2 vector17 = new Vector2((float)rectangle.X, (float)rectangle.Y);
							int num101 = rectangle.Width;
							int num102 = rectangle.Height;
							int type15 = 57;
							float speedX16 = this.velocity.X * 0.2f + (float)(this.direction * 3);
							float speedY16 = this.velocity.Y * 0.2f;
							int alpha15 = 100;
							Color newColor = default(Color);
							int num103 = Dust.NewDust(vector17, num101, num102, type15, speedX16, speedY16, alpha15, newColor, 1.1f);
							Main.dust[num103].noGravity = true;
							Dust dust7 = Main.dust[num103];
							dust7.velocity.X = dust7.velocity.X / 2f;
							Dust dust8 = Main.dust[num103];
							dust8.velocity.Y = dust8.velocity.Y / 2f;
							Dust dust9 = Main.dust[num103];
							dust9.velocity.X = dust9.velocity.X + (float)(this.direction * 2);
						}
						if (Main.rand.Next(4) == 0)
						{
							Vector2 vector18 = new Vector2((float)rectangle.X, (float)rectangle.Y);
							int num104 = rectangle.Width;
							int num105 = rectangle.Height;
							int type16 = 43;
							float speedX17 = 0f;
							float speedY17 = 0f;
							int alpha16 = 254;
							Color newColor = default(Color);
							int num103 = Dust.NewDust(vector18, num104, num105, type16, speedX17, speedY17, alpha16, newColor, 0.3f);
							Dust dust10 = Main.dust[num103];
							dust10.velocity *= 0f;
						}
					}
					if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
					{
						float num106 = 0.5f;
						float num107 = 0.5f;
						float num108 = 0.5f;
						if (this.inventory[this.selectedItem].type == 198)
						{
							num106 *= 0.1f;
							num107 *= 0.5f;
							num108 *= 1.2f;
						}
						else if (this.inventory[this.selectedItem].type == 199)
						{
							num106 *= 1f;
							num107 *= 0.2f;
							num108 *= 0.1f;
						}
						else if (this.inventory[this.selectedItem].type == 200)
						{
							num106 *= 0.1f;
							num107 *= 1f;
							num108 *= 0.2f;
						}
						else if (this.inventory[this.selectedItem].type == 201)
						{
							num106 *= 0.8f;
							num107 *= 0.1f;
							num108 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 202)
						{
							num106 *= 0.8f;
							num107 *= 0.9f;
							num108 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 203)
						{
							num106 *= 0.9f;
							num107 *= 0.9f;
							num108 *= 0.1f;
						}
						Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), num106, num107, num108);
					}
					if (Main.myPlayer == i)
					{
						int num109 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
						float num110 = this.inventory[this.selectedItem].knockBack;
						if (this.kbGlove)
						{
							num110 *= 2f;
						}
						int num111 = rectangle.X / 16;
						int num112 = (rectangle.X + rectangle.Width) / 16 + 1;
						int num113 = rectangle.Y / 16;
						int num114 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int num115 = num111; num115 < num112; num115++)
						{
							for (int num116 = num113; num116 < num114; num116++)
							{
								if (Main.tile[num115, num116] != null && Main.tileCut[(int)Main.tile[num115, num116].type] && Main.tile[num115, num116 + 1] != null && Main.tile[num115, num116 + 1].type != 78)
								{
									WorldGen.KillTile(num115, num116, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num115, (float)num116, 0f, 0);
									}
								}
							}
						}
						for (int num117 = 0; num117 < 200; num117++)
						{
							if (Main.npc[num117].active && Main.npc[num117].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num117].dontTakeDamage && (!Main.npc[num117].friendly || (Main.npc[num117].type == 22 && this.killGuide)))
							{
								Rectangle value = new Rectangle((int)Main.npc[num117].position.X, (int)Main.npc[num117].position.Y, Main.npc[num117].width, Main.npc[num117].height);
								if (rectangle.Intersects(value) && (Main.npc[num117].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num117].position, Main.npc[num117].width, Main.npc[num117].height)))
								{
									bool flag10 = false;
									if (Main.rand.Next(1, 101) <= this.meleeCrit)
									{
										flag10 = true;
									}
									int num118 = Main.DamageVar((float)num109);
									this.StatusNPC(this.inventory[this.selectedItem].type, num117);
									Main.npc[num117].StrikeNPC(num118, num110, this.direction, flag10, false);
									if (Main.netMode != 0)
									{
										if (flag10)
										{
											NetMessage.SendData(28, -1, -1, "", num117, (float)num118, num110, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", num117, (float)num118, num110, (float)this.direction, 0);
										}
									}
									Main.npc[num117].immune[i] = this.itemAnimation;
									this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
								}
							}
						}
						if (this.hostile)
						{
							for (int num119 = 0; num119 < 255; num119++)
							{
								if (num119 != i && Main.player[num119].active && Main.player[num119].hostile && !Main.player[num119].immune && !Main.player[num119].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num119].team))
								{
									Rectangle value2 = new Rectangle((int)Main.player[num119].position.X, (int)Main.player[num119].position.Y, Main.player[num119].width, Main.player[num119].height);
									if (rectangle.Intersects(value2) && Collision.CanHit(this.position, this.width, this.height, Main.player[num119].position, Main.player[num119].width, Main.player[num119].height))
									{
										bool flag11 = false;
										if (Main.rand.Next(1, 101) <= 10)
										{
											flag11 = true;
										}
										int num120 = Main.DamageVar((float)num109);
										this.StatusPvP(this.inventory[this.selectedItem].type, num119);
										Main.player[num119].Hurt(num120, this.direction, true, false, "", flag11);
										if (Main.netMode != 0)
										{
											if (flag11)
											{
												NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.whoAmi, -1, -1, -1), num119, (float)this.direction, (float)num120, 1f, 1);
											}
											else
											{
												NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.whoAmi, -1, -1, -1), num119, (float)this.direction, (float)num120, 1f, 0);
											}
										}
										this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
									}
								}
							}
						}
					}
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].healLife > 0)
				{
					this.statLife += this.inventory[this.selectedItem].healLife;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[this.selectedItem].healLife);
					}
				}
				if (this.inventory[this.selectedItem].healMana > 0)
				{
					this.statMana += this.inventory[this.selectedItem].healMana;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(this.inventory[this.selectedItem].healMana);
					}
				}
				if (this.inventory[this.selectedItem].buffType > 0)
				{
					if (this.whoAmi == Main.myPlayer)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 361)
			{
				this.itemTime = this.inventory[this.selectedItem].useTime;
				Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
				if (Main.netMode != 1 && Main.invasionType == 0)
				{
					Main.invasionDelay = 0;
					Main.StartInvasion(1);
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 602)
			{
				this.itemTime = this.inventory[this.selectedItem].useTime;
				Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
				if (Main.netMode != 1 && Main.invasionType == 0)
				{
					Main.invasionDelay = 0;
					Main.StartInvasion(2);
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560))
			{
				bool flag12 = false;
				for (int num121 = 0; num121 < 200; num121++)
				{
					if (Main.npc[num121].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[num121].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[num121].type == 13) || (this.inventory[this.selectedItem].type == 560 & Main.npc[num121].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num121].type == 125) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num121].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[num121].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[num121].type == 128)))
					{
						flag12 = true;
						break;
					}
				}
				if (flag12)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.Hurt(this.statLife * (this.statDefense + 1), -this.direction, false, false, Player.getDeathMessage(-1, -1, -1, 3), false);
					}
				}
				else if (this.inventory[this.selectedItem].type == 560)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						NPC.SpawnOnPlayer(i, 50);
					}
				}
				else if (this.inventory[this.selectedItem].type == 43)
				{
					if (!Main.dayTime)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 4);
						}
					}
				}
				else if (this.inventory[this.selectedItem].type == 70)
				{
					if (this.zoneEvil)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 13);
						}
					}
				}
				else if (this.inventory[this.selectedItem].type == 544)
				{
					if (!Main.dayTime)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 125);
							NPC.SpawnOnPlayer(i, 126);
						}
					}
				}
				else if (this.inventory[this.selectedItem].type == 556)
				{
					if (!Main.dayTime)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 134);
						}
					}
				}
				else if (this.inventory[this.selectedItem].type == 557 && !Main.dayTime)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						NPC.SpawnOnPlayer(i, 127);
					}
				}
			}
			if (this.inventory[this.selectedItem].type == 50 && this.itemAnimation > 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					Vector2 vector19 = this.position;
					int num122 = this.width;
					int num123 = this.height;
					int type17 = 15;
					float speedX18 = 0f;
					float speedY18 = 0f;
					int alpha17 = 150;
					Dust.NewDust(vector19, num122, num123, type17, speedX18, speedY18, alpha17, default(Color), 1.1f);
				}
				if (this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				else if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
				{
					for (int num124 = 0; num124 < 70; num124++)
					{
						Vector2 vector20 = this.position;
						int num125 = this.width;
						int num126 = this.height;
						int type18 = 15;
						float speedX19 = this.velocity.X * 0.5f;
						float speedY19 = this.velocity.Y * 0.5f;
						int alpha18 = 150;
						Dust.NewDust(vector20, num125, num126, type18, speedX19, speedY19, alpha18, default(Color), 1.5f);
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num127 = 0; num127 < 1000; num127++)
					{
						if (Main.projectile[num127].active && Main.projectile[num127].owner == i && Main.projectile[num127].aiStyle == 7)
						{
							Main.projectile[num127].Kill();
						}
					}
					this.Spawn();
					for (int num128 = 0; num128 < 70; num128++)
					{
						Vector2 vector21 = this.position;
						int num129 = this.width;
						int num130 = this.height;
						int type19 = 15;
						float speedX20 = 0f;
						float speedY20 = 0f;
						int alpha19 = 150;
						Dust.NewDust(vector21, num129, num130, type19, speedX20, speedY20, alpha19, default(Color), 1.5f);
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
				{
					bool flag13 = true;
					if (this.inventory[this.selectedItem].ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag13 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag13 = false;
						}
					}
					if (flag13)
					{
						if (this.inventory[this.selectedItem].stack > 0)
						{
							this.inventory[this.selectedItem].stack--;
						}
						if (this.inventory[this.selectedItem].stack <= 0)
						{
							this.itemTime = this.itemAnimation;
						}
					}
				}
				if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
				{
					this.inventory[this.selectedItem] = new Item();
				}
				if (this.selectedItem == 48)
				{
					if (this.itemAnimation != 0)
					{
						Main.mouseItem = (Item)this.inventory[this.selectedItem].Clone();
					}
				}
			}
		}

		public Color GetImmuneAlpha(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			Color result;
			if (this.immuneAlpha > 125)
			{
				result = new Color(0, 0, 0, 0);
			}
			else
			{
				int r = (int)((float)newColor.R * num);
				int g = (int)((float)newColor.G * num);
				int b = (int)((float)newColor.B * num);
				int num2 = (int)((float)newColor.A * num);
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num2 > 255)
				{
					num2 = 255;
				}
				result = new Color(r, g, b, num2);
			}
			return result;
		}

		public Color GetImmuneAlpha2(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			int r = (int)((float)newColor.R * num);
			int g = (int)((float)newColor.G * num);
			int b = (int)((float)newColor.B * num);
			int num2 = (int)((float)newColor.A * num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}

		public Color GetDeathAlpha(Color newColor)
		{
			int r = (int)newColor.R + (int)((double)this.immuneAlpha * 0.9);
			int g = (int)newColor.G + (int)((double)this.immuneAlpha * 0.5);
			int b = (int)newColor.B + (int)((double)this.immuneAlpha * 0.5);
			int num = (int)newColor.A + (int)((double)this.immuneAlpha * 0.4);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}

		public void DropCoins()
		{
			for (int i = 0; i < 49; i++)
			{
				if (this.inventory[i].type >= 71 && this.inventory[i].type <= 74)
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0);
					int num2 = this.inventory[i].stack / 2;
					num2 = this.inventory[i].stack - num2;
					this.inventory[i].stack -= num2;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i] = new Item();
					}
					Main.item[num].stack = num2;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (i == 48)
					{
						Main.mouseItem = (Item)this.inventory[i].Clone();
					}
				}
			}
		}

		public void DropItems()
		{
			for (int i = 0; i < 49; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].name != "Copper Pickaxe" && this.inventory[i].name != "Copper Axe" && this.inventory[i].name != "Copper Shortsword")
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0);
					Main.item[num].SetDefaults(this.inventory[i].name);
					Main.item[num].Prefix((int)this.inventory[i].prefix);
					Main.item[num].stack = this.inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
				}
				this.inventory[i] = new Item();
				if (i < 11)
				{
					if (this.armor[i].stack > 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0);
						Main.item[num2].SetDefaults(this.armor[i].name);
						Main.item[num2].Prefix((int)this.armor[i].prefix);
						Main.item[num2].stack = this.armor[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
						}
					}
					this.armor[i] = new Item();
				}
			}
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[0].Prefix(-1);
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[1].Prefix(-1);
			this.inventory[2].SetDefaults("Copper Axe");
			this.inventory[2].Prefix(-1);
			Main.mouseItem = new Item();
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		public object clientClone()
		{
			Player player = new Player();
			player.zoneEvil = this.zoneEvil;
			player.zoneMeteor = this.zoneMeteor;
			player.zoneDungeon = this.zoneDungeon;
			player.zoneJungle = this.zoneJungle;
			player.zoneHoly = this.zoneHoly;
			player.direction = this.direction;
			player.selectedItem = this.selectedItem;
			player.controlUp = this.controlUp;
			player.controlDown = this.controlDown;
			player.controlLeft = this.controlLeft;
			player.controlRight = this.controlRight;
			player.controlJump = this.controlJump;
			player.controlUseItem = this.controlUseItem;
			player.statLife = this.statLife;
			player.statLifeMax = this.statLifeMax;
			player.statMana = this.statMana;
			player.statManaMax = this.statManaMax;
			player.position.X = this.position.X;
			player.chest = this.chest;
			player.talkNPC = this.talkNPC;
			for (int i = 0; i < 49; i++)
			{
				player.inventory[i] = (Item)this.inventory[i].Clone();
				if (i < 11)
				{
					player.armor[i] = (Item)this.armor[i].Clone();
				}
			}
			for (int j = 0; j < 10; j++)
			{
				player.buffType[j] = this.buffType[j];
				player.buffTime[j] = this.buffTime[j];
			}
			return player;
		}

		private static void EncryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(outputFile, FileMode.Create);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
			FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
			int num;
			while ((num = fileStream2.ReadByte()) != -1)
			{
				cryptoStream.WriteByte((byte)num);
			}
			fileStream2.Close();
			cryptoStream.Close();
			fileStream.Close();
		}

		private static bool DecryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(inputFile, FileMode.Open);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
			FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
			bool result;
			try
			{
				int num;
				while ((num = cryptoStream.ReadByte()) != -1)
				{
					fileStream2.WriteByte((byte)num);
				}
				fileStream2.Close();
				cryptoStream.Close();
				fileStream.Close();
			}
			catch
			{
				fileStream2.Close();
				fileStream.Close();
				File.Delete(outputFile);
				result = true;
				return result;
			}
			result = false;
			return result;
		}

		public static bool CheckSpawn(int x, int y)
		{
			bool result;
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
			{
				result = false;
			}
			else if (Main.tile[x, y - 1] == null)
			{
				result = false;
			}
			else if (!Main.tile[x, y - 1].active || Main.tile[x, y - 1].type != 79)
			{
				result = false;
			}
			else
			{
				for (int i = x - 1; i <= x + 1; i++)
				{
					for (int j = y - 3; j < y; j++)
					{
						if (Main.tile[i, j] == null)
						{
							result = false;
							return result;
						}
						if (Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
						{
							result = false;
							return result;
						}
					}
				}
				result = WorldGen.StartRoomCheck(x, y - 1);
			}
			return result;
		}

		public void FindSpawn()
		{
			for (int i = 0; i < 200; i++)
			{
				if (this.spN[i] == null)
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
					break;
				}
				if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
				{
					this.SpawnX = this.spX[i];
					this.SpawnY = this.spY[i];
					break;
				}
			}
		}

		public void ChangeSpawn(int x, int y)
		{
			int num = 0;
			while (num < 200 && this.spN[num] != null)
			{
				if (this.spN[num] == Main.worldName && this.spI[num] == Main.worldID)
				{
					for (int i = num; i > 0; i--)
					{
						this.spN[i] = this.spN[i - 1];
						this.spI[i] = this.spI[i - 1];
						this.spX[i] = this.spX[i - 1];
						this.spY[i] = this.spY[i - 1];
					}
					this.spN[0] = Main.worldName;
					this.spI[0] = Main.worldID;
					this.spX[0] = x;
					this.spY[0] = y;
					return;
				}
				num++;
			}
			for (int j = 199; j > 0; j--)
			{
				if (this.spN[j - 1] != null)
				{
					this.spN[j] = this.spN[j - 1];
					this.spI[j] = this.spI[j - 1];
					this.spX[j] = this.spX[j - 1];
					this.spY[j] = this.spY[j - 1];
				}
			}
			this.spN[0] = Main.worldName;
			this.spI[0] = Main.worldID;
			this.spX[0] = x;
			this.spY[0] = y;
		}

		public static void SavePlayer(Player newPlayer, string playerPath)
		{
			try
			{
				Directory.CreateDirectory(Main.PlayerPath);
			}
			catch
			{
			}
			if (playerPath != null && !(playerPath == ""))
			{
				string destFileName = playerPath + ".bak";
				if (File.Exists(playerPath))
				{
					File.Copy(playerPath, destFileName, true);
				}
				string text = playerPath + ".dat";
				using (FileStream fileStream = new FileStream(text, FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						binaryWriter.Write(newPlayer.name);
						binaryWriter.Write(newPlayer.difficulty);
						binaryWriter.Write(newPlayer.hair);
						binaryWriter.Write(newPlayer.male);
						binaryWriter.Write(newPlayer.statLife);
						binaryWriter.Write(newPlayer.statLifeMax);
						binaryWriter.Write(newPlayer.statMana);
						binaryWriter.Write(newPlayer.statManaMax);
						binaryWriter.Write(newPlayer.hairColor.R);
						binaryWriter.Write(newPlayer.hairColor.G);
						binaryWriter.Write(newPlayer.hairColor.B);
						binaryWriter.Write(newPlayer.skinColor.R);
						binaryWriter.Write(newPlayer.skinColor.G);
						binaryWriter.Write(newPlayer.skinColor.B);
						binaryWriter.Write(newPlayer.eyeColor.R);
						binaryWriter.Write(newPlayer.eyeColor.G);
						binaryWriter.Write(newPlayer.eyeColor.B);
						binaryWriter.Write(newPlayer.shirtColor.R);
						binaryWriter.Write(newPlayer.shirtColor.G);
						binaryWriter.Write(newPlayer.shirtColor.B);
						binaryWriter.Write(newPlayer.underShirtColor.R);
						binaryWriter.Write(newPlayer.underShirtColor.G);
						binaryWriter.Write(newPlayer.underShirtColor.B);
						binaryWriter.Write(newPlayer.pantsColor.R);
						binaryWriter.Write(newPlayer.pantsColor.G);
						binaryWriter.Write(newPlayer.pantsColor.B);
						binaryWriter.Write(newPlayer.shoeColor.R);
						binaryWriter.Write(newPlayer.shoeColor.G);
						binaryWriter.Write(newPlayer.shoeColor.B);
						for (int i = 0; i < 11; i++)
						{
							if (newPlayer.armor[i].name == null)
							{
								newPlayer.armor[i].name = "";
							}
							binaryWriter.Write(newPlayer.armor[i].name);
							binaryWriter.Write(newPlayer.armor[i].prefix);
						}
						for (int j = 0; j < 48; j++)
						{
							if (newPlayer.inventory[j].name == null)
							{
								newPlayer.inventory[j].name = "";
							}
							binaryWriter.Write(newPlayer.inventory[j].name);
							binaryWriter.Write(newPlayer.inventory[j].stack);
							binaryWriter.Write(newPlayer.inventory[j].prefix);
						}
						for (int k = 0; k < Chest.maxItems; k++)
						{
							if (newPlayer.bank[k].name == null)
							{
								newPlayer.bank[k].name = "";
							}
							binaryWriter.Write(newPlayer.bank[k].name);
							binaryWriter.Write(newPlayer.bank[k].stack);
							binaryWriter.Write(newPlayer.bank[k].prefix);
						}
						for (int l = 0; l < Chest.maxItems; l++)
						{
							if (newPlayer.bank2[l].name == null)
							{
								newPlayer.bank2[l].name = "";
							}
							binaryWriter.Write(newPlayer.bank2[l].name);
							binaryWriter.Write(newPlayer.bank2[l].stack);
							binaryWriter.Write(newPlayer.bank2[l].prefix);
						}
						for (int m = 0; m < 10; m++)
						{
							binaryWriter.Write(newPlayer.buffType[m]);
							binaryWriter.Write(newPlayer.buffTime[m]);
						}
						for (int n = 0; n < 200; n++)
						{
							if (newPlayer.spN[n] == null)
							{
								binaryWriter.Write(-1);
								break;
							}
							binaryWriter.Write(newPlayer.spX[n]);
							binaryWriter.Write(newPlayer.spY[n]);
							binaryWriter.Write(newPlayer.spI[n]);
							binaryWriter.Write(newPlayer.spN[n]);
						}
						binaryWriter.Write(newPlayer.hbLocked);
						binaryWriter.Close();
					}
				}
				Player.EncryptFile(text, playerPath);
				File.Delete(text);
			}
		}

		public static Player LoadPlayer(string playerPath)
		{
			bool flag = false;
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			Player player = new Player();
			Player result;
			try
			{
				string text = playerPath + ".dat";
				flag = Player.DecryptFile(playerPath, text);
				if (!flag)
				{
					using (FileStream fileStream = new FileStream(text, FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							player.name = binaryReader.ReadString();
							if (num >= 10)
							{
								if (num >= 17)
								{
									player.difficulty = binaryReader.ReadByte();
								}
								else
								{
									bool flag2 = binaryReader.ReadBoolean();
									if (flag2)
									{
										player.difficulty = 2;
									}
								}
							}
							player.hair = binaryReader.ReadInt32();
							if (num <= 17)
							{
								if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
								{
									player.male = false;
								}
								else
								{
									player.male = true;
								}
							}
							else
							{
								player.male = binaryReader.ReadBoolean();
							}
							player.statLife = binaryReader.ReadInt32();
							player.statLifeMax = binaryReader.ReadInt32();
							if (player.statLife > player.statLifeMax)
							{
								player.statLife = player.statLifeMax;
							}
							player.statMana = binaryReader.ReadInt32();
							player.statManaMax = binaryReader.ReadInt32();
							if (player.statMana > 400)
							{
								player.statMana = 400;
							}
							player.hairColor.R = binaryReader.ReadByte();
							player.hairColor.G = binaryReader.ReadByte();
							player.hairColor.B = binaryReader.ReadByte();
							player.skinColor.R = binaryReader.ReadByte();
							player.skinColor.G = binaryReader.ReadByte();
							player.skinColor.B = binaryReader.ReadByte();
							player.eyeColor.R = binaryReader.ReadByte();
							player.eyeColor.G = binaryReader.ReadByte();
							player.eyeColor.B = binaryReader.ReadByte();
							player.shirtColor.R = binaryReader.ReadByte();
							player.shirtColor.G = binaryReader.ReadByte();
							player.shirtColor.B = binaryReader.ReadByte();
							player.underShirtColor.R = binaryReader.ReadByte();
							player.underShirtColor.G = binaryReader.ReadByte();
							player.underShirtColor.B = binaryReader.ReadByte();
							player.pantsColor.R = binaryReader.ReadByte();
							player.pantsColor.G = binaryReader.ReadByte();
							player.pantsColor.B = binaryReader.ReadByte();
							player.shoeColor.R = binaryReader.ReadByte();
							player.shoeColor.G = binaryReader.ReadByte();
							player.shoeColor.B = binaryReader.ReadByte();
							Main.player[Main.myPlayer].shirtColor = player.shirtColor;
							Main.player[Main.myPlayer].pantsColor = player.pantsColor;
							Main.player[Main.myPlayer].hairColor = player.hairColor;
							for (int i = 0; i < 8; i++)
							{
								player.armor[i].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								if (num >= 36)
								{
									player.armor[i].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 6)
							{
								for (int j = 8; j < 11; j++)
								{
									player.armor[j].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									if (num >= 36)
									{
										player.armor[j].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							for (int k = 0; k < 44; k++)
							{
								player.inventory[k].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.inventory[k].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.inventory[k].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 15)
							{
								for (int l = 44; l < 48; l++)
								{
									player.inventory[l].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.inventory[l].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.inventory[l].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							for (int m = 0; m < Chest.maxItems; m++)
							{
								player.bank[m].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.bank[m].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.bank[m].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 20)
							{
								for (int n = 0; n < Chest.maxItems; n++)
								{
									player.bank2[n].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.bank2[n].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.bank2[n].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							if (num >= 11)
							{
								for (int num2 = 0; num2 < 10; num2++)
								{
									player.buffType[num2] = binaryReader.ReadInt32();
									player.buffTime[num2] = binaryReader.ReadInt32();
								}
							}
							for (int num3 = 0; num3 < 200; num3++)
							{
								int num4 = binaryReader.ReadInt32();
								if (num4 == -1)
								{
									break;
								}
								player.spX[num3] = num4;
								player.spY[num3] = binaryReader.ReadInt32();
								player.spI[num3] = binaryReader.ReadInt32();
								player.spN[num3] = binaryReader.ReadString();
							}
							if (num >= 16)
							{
								player.hbLocked = binaryReader.ReadBoolean();
							}
							binaryReader.Close();
						}
					}
					player.PlayerFrame();
					File.Delete(text);
					Player player2 = player;
					result = player2;
					return result;
				}
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				try
				{
					string text2 = playerPath + ".bak";
					Player player2;
					if (File.Exists(text2))
					{
						File.Delete(playerPath);
						File.Move(text2, playerPath);
						player2 = Player.LoadPlayer(playerPath);
						result = player2;
						return result;
					}
					player2 = new Player();
					result = player2;
					return result;
				}
				catch
				{
					Player player2 = new Player();
					result = player2;
					return result;
				}
			}
			result = new Player();
			return result;
		}

		public bool HasItem(int type)
		{
			bool result;
			for (int i = 0; i < 48; i++)
			{
				if (type == this.inventory[i].type)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public void QuickGrapple()
		{
			if (!this.noItems)
			{
				int num = -1;
				for (int i = 0; i < 48; i++)
				{
					if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73)
					{
						num = i;
						break;
					}
				}
				if (num >= 0)
				{
					if (this.inventory[num].shoot == 73)
					{
						int num2 = 0;
						if (num >= 0)
						{
							for (int j = 0; j < 1000; j++)
							{
								if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
								{
									num2++;
								}
							}
						}
						if (num2 > 1)
						{
							num = -1;
						}
					}
					else if (num >= 0)
					{
						for (int k = 0; k < 1000; k++)
						{
							if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == this.inventory[num].shoot && Main.projectile[k].ai[0] != 2f)
							{
								num = -1;
								break;
							}
						}
					}
					if (num >= 0)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[num].useSound);
						if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
						{
							NetMessage.SendData(51, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
						}
						int num3 = this.inventory[num].shoot;
						float shootSpeed = this.inventory[num].shootSpeed;
						int damage = this.inventory[num].damage;
						float knockBack = this.inventory[num].knockBack;
						if (num3 == 13 || num3 == 32)
						{
							this.grappling[0] = -1;
							this.grapCount = 0;
							for (int l = 0; l < 1000; l++)
							{
								if (Main.projectile[l].active && Main.projectile[l].owner == this.whoAmi && Main.projectile[l].type == 13)
								{
									Main.projectile[l].Kill();
								}
							}
						}
						if (num3 == 73)
						{
							for (int m = 0; m < 1000; m++)
							{
								if (Main.projectile[m].active && Main.projectile[m].owner == this.whoAmi && Main.projectile[m].type == 73)
								{
									num3 = 74;
								}
							}
						}
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num4 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
						float num5 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
						float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
						num6 = shootSpeed / num6;
						num4 *= num6;
						num5 *= num6;
						Projectile.NewProjectile(vector.X, vector.Y, num4, num5, num3, damage, knockBack, this.whoAmi);
					}
				}
			}
		}

		public Player()
		{
			for (int i = 0; i < 49; i++)
			{
				if (i < 11)
				{
					this.armor[i] = new Item();
					this.armor[i].name = "";
				}
				this.inventory[i] = new Item();
				this.inventory[i].name = "";
			}
			for (int j = 0; j < Chest.maxItems; j++)
			{
				this.bank[j] = new Item();
				this.bank[j].name = "";
				this.bank2[j] = new Item();
				this.bank2[j].name = "";
			}
			this.grappling[0] = -1;
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[2].SetDefaults("Copper Axe");
			for (int k = 0; k < 150; k++)
			{
				this.adjTile[k] = false;
				this.oldAdjTile[k] = false;
			}
		}
	}
}
