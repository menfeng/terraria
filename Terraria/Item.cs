using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public class Item
	{
		public static int potionDelay = 3600;

		public static int[] headType = new int[45];

		public static int[] bodyType = new int[26];

		public static int[] legType = new int[25];

		public bool mech;

		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public Vector2 position;

		public Vector2 velocity;

		public int width;

		public int height;

		public bool active;

		public int noGrabDelay;

		public bool beingGrabbed;

		public int spawnTime;

		public bool wornArmor;

		public int ownIgnore = -1;

		public int ownTime;

		public int keepTime;

		public int type;

		public string name;

		public string CName;

		public int holdStyle;

		public int useStyle;

		public bool channel;

		public bool accessory;

		public int useAnimation;

		public int useTime;

		public int stack;

		public int maxStack;

		public int pick;

		public int axe;

		public int hammer;

		public int tileBoost;

		public int createTile = -1;

		public int createWall = -1;

		public int placeStyle;

		public int damage;

		public float knockBack;

		public int healLife;

		public int healMana;

		public bool potion;

		public bool consumable;

		public bool autoReuse;

		public bool useTurn;

		public Color color;

		public int alpha;

		public float scale = 1f;

		public int useSound;

		public int defense;

		public int headSlot = -1;

		public int bodySlot = -1;

		public int legSlot = -1;

		public string toolTip;

		public string toolTip2;

		public int owner = 255;

		public int rare;

		public int shoot;

		public float shootSpeed;

		public int ammo;

		public int useAmmo;

		public int lifeRegen;

		public int manaIncrease;

		public bool buyOnce;

		public int mana;

		public bool noUseGraphic;

		public bool noMelee;

		public int release;

		public int value;

		public bool buy;

		public bool social;

		public bool vanity;

		public bool material;

		public bool noWet;

		public int buffType;

		public int buffTime;

		public int netID;

		public int crit;

		public byte prefix;

		public bool melee;

		public bool magic;

		public bool ranged;

		public int reuseDelay;

		public bool Prefix(int pre)
		{
			bool result;
			if (pre == 0 || this.type == 0)
			{
				result = false;
			}
			else
			{
				int num = pre;
				float num2 = 1f;
				float num3 = 1f;
				float num4 = 1f;
				float num5 = 1f;
				float num6 = 1f;
				float num7 = 1f;
				int num8 = 0;
				bool flag = true;
				while (flag)
				{
					num2 = 1f;
					num3 = 1f;
					num4 = 1f;
					num5 = 1f;
					num6 = 1f;
					num7 = 1f;
					num8 = 0;
					flag = false;
					if (num == -1 && Main.rand.Next(4) == 0)
					{
						num = 0;
					}
					if (pre < -1)
					{
						num = -1;
					}
					if (num == -1 || num == -2 || num == -3)
					{
						if (this.type == 1 || this.type == 4 || this.type == 6 || this.type == 7 || this.type == 10 || this.type == 24 || this.type == 45 || this.type == 46 || this.type == 103 || this.type == 104 || this.type == 121 || this.type == 122 || this.type == 155 || this.type == 190 || this.type == 196 || this.type == 198 || this.type == 199 || this.type == 200 || this.type == 201 || this.type == 202 || this.type == 203 || this.type == 204 || this.type == 213 || this.type == 217 || this.type == 273 || this.type == 367 || this.type == 368 || this.type == 426 || this.type == 482 || this.type == 483 || this.type == 484)
						{
							int num9 = Main.rand.Next(40);
							if (num9 == 0)
							{
								num = 1;
							}
							if (num9 == 1)
							{
								num = 2;
							}
							if (num9 == 2)
							{
								num = 3;
							}
							if (num9 == 3)
							{
								num = 4;
							}
							if (num9 == 4)
							{
								num = 5;
							}
							if (num9 == 5)
							{
								num = 6;
							}
							if (num9 == 6)
							{
								num = 7;
							}
							if (num9 == 7)
							{
								num = 8;
							}
							if (num9 == 8)
							{
								num = 9;
							}
							if (num9 == 9)
							{
								num = 10;
							}
							if (num9 == 10)
							{
								num = 11;
							}
							if (num9 == 11)
							{
								num = 12;
							}
							if (num9 == 12)
							{
								num = 13;
							}
							if (num9 == 13)
							{
								num = 14;
							}
							if (num9 == 14)
							{
								num = 15;
							}
							if (num9 == 15)
							{
								num = 36;
							}
							if (num9 == 16)
							{
								num = 37;
							}
							if (num9 == 17)
							{
								num = 38;
							}
							if (num9 == 18)
							{
								num = 53;
							}
							if (num9 == 19)
							{
								num = 54;
							}
							if (num9 == 20)
							{
								num = 55;
							}
							if (num9 == 21)
							{
								num = 39;
							}
							if (num9 == 22)
							{
								num = 40;
							}
							if (num9 == 23)
							{
								num = 56;
							}
							if (num9 == 24)
							{
								num = 41;
							}
							if (num9 == 25)
							{
								num = 57;
							}
							if (num9 == 26)
							{
								num = 42;
							}
							if (num9 == 27)
							{
								num = 43;
							}
							if (num9 == 28)
							{
								num = 44;
							}
							if (num9 == 29)
							{
								num = 45;
							}
							if (num9 == 30)
							{
								num = 46;
							}
							if (num9 == 31)
							{
								num = 47;
							}
							if (num9 == 32)
							{
								num = 48;
							}
							if (num9 == 33)
							{
								num = 49;
							}
							if (num9 == 34)
							{
								num = 50;
							}
							if (num9 == 35)
							{
								num = 51;
							}
							if (num9 == 36)
							{
								num = 59;
							}
							if (num9 == 37)
							{
								num = 60;
							}
							if (num9 == 38)
							{
								num = 61;
							}
							if (num9 == 39)
							{
								num = 81;
							}
						}
						else if (this.type == 162 || this.type == 160 || this.type == 163 || this.type == 220 || this.type == 274 || this.type == 277 || this.type == 280 || this.type == 383 || this.type == 384 || this.type == 385 || this.type == 386 || this.type == 387 || this.type == 388 || this.type == 389 || this.type == 390 || this.type == 406 || this.type == 537 || this.type == 550 || this.type == 579)
						{
							int num10 = Main.rand.Next(14);
							if (num10 == 0)
							{
								num = 36;
							}
							if (num10 == 1)
							{
								num = 37;
							}
							if (num10 == 2)
							{
								num = 38;
							}
							if (num10 == 3)
							{
								num = 53;
							}
							if (num10 == 4)
							{
								num = 54;
							}
							if (num10 == 5)
							{
								num = 55;
							}
							if (num10 == 6)
							{
								num = 39;
							}
							if (num10 == 7)
							{
								num = 40;
							}
							if (num10 == 8)
							{
								num = 56;
							}
							if (num10 == 9)
							{
								num = 41;
							}
							if (num10 == 10)
							{
								num = 57;
							}
							if (num10 == 11)
							{
								num = 59;
							}
							if (num10 == 12)
							{
								num = 60;
							}
							if (num10 == 13)
							{
								num = 61;
							}
						}
						else if (this.type == 39 || this.type == 44 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || this.type == 120 || this.type == 164 || this.type == 197 || this.type == 219 || this.type == 266 || this.type == 281 || this.type == 434 || this.type == 435 || this.type == 436 || this.type == 481 || this.type == 506 || this.type == 533 || this.type == 534 || this.type == 578)
						{
							int num11 = Main.rand.Next(36);
							if (num11 == 0)
							{
								num = 16;
							}
							if (num11 == 1)
							{
								num = 17;
							}
							if (num11 == 2)
							{
								num = 18;
							}
							if (num11 == 3)
							{
								num = 19;
							}
							if (num11 == 4)
							{
								num = 20;
							}
							if (num11 == 5)
							{
								num = 21;
							}
							if (num11 == 6)
							{
								num = 22;
							}
							if (num11 == 7)
							{
								num = 23;
							}
							if (num11 == 8)
							{
								num = 24;
							}
							if (num11 == 9)
							{
								num = 25;
							}
							if (num11 == 10)
							{
								num = 58;
							}
							if (num11 == 11)
							{
								num = 36;
							}
							if (num11 == 12)
							{
								num = 37;
							}
							if (num11 == 13)
							{
								num = 38;
							}
							if (num11 == 14)
							{
								num = 53;
							}
							if (num11 == 15)
							{
								num = 54;
							}
							if (num11 == 16)
							{
								num = 55;
							}
							if (num11 == 17)
							{
								num = 39;
							}
							if (num11 == 18)
							{
								num = 40;
							}
							if (num11 == 19)
							{
								num = 56;
							}
							if (num11 == 20)
							{
								num = 41;
							}
							if (num11 == 21)
							{
								num = 57;
							}
							if (num11 == 22)
							{
								num = 42;
							}
							if (num11 == 23)
							{
								num = 43;
							}
							if (num11 == 24)
							{
								num = 44;
							}
							if (num11 == 25)
							{
								num = 45;
							}
							if (num11 == 26)
							{
								num = 46;
							}
							if (num11 == 27)
							{
								num = 47;
							}
							if (num11 == 28)
							{
								num = 48;
							}
							if (num11 == 29)
							{
								num = 49;
							}
							if (num11 == 30)
							{
								num = 50;
							}
							if (num11 == 31)
							{
								num = 51;
							}
							if (num11 == 32)
							{
								num = 59;
							}
							if (num11 == 33)
							{
								num = 60;
							}
							if (num11 == 34)
							{
								num = 61;
							}
							if (num11 == 35)
							{
								num = 82;
							}
						}
						else if (this.type == 64 || this.type == 65 || this.type == 112 || this.type == 113 || this.type == 127 || this.type == 157 || this.type == 165 || this.type == 218 || this.type == 272 || this.type == 494 || this.type == 495 || this.type == 496 || this.type == 514 || this.type == 517 || this.type == 518 || this.type == 519)
						{
							int num12 = Main.rand.Next(36);
							if (num12 == 0)
							{
								num = 26;
							}
							if (num12 == 1)
							{
								num = 27;
							}
							if (num12 == 2)
							{
								num = 28;
							}
							if (num12 == 3)
							{
								num = 29;
							}
							if (num12 == 4)
							{
								num = 30;
							}
							if (num12 == 5)
							{
								num = 31;
							}
							if (num12 == 6)
							{
								num = 32;
							}
							if (num12 == 7)
							{
								num = 33;
							}
							if (num12 == 8)
							{
								num = 34;
							}
							if (num12 == 9)
							{
								num = 35;
							}
							if (num12 == 10)
							{
								num = 52;
							}
							if (num12 == 11)
							{
								num = 36;
							}
							if (num12 == 12)
							{
								num = 37;
							}
							if (num12 == 13)
							{
								num = 38;
							}
							if (num12 == 14)
							{
								num = 53;
							}
							if (num12 == 15)
							{
								num = 54;
							}
							if (num12 == 16)
							{
								num = 55;
							}
							if (num12 == 17)
							{
								num = 39;
							}
							if (num12 == 18)
							{
								num = 40;
							}
							if (num12 == 19)
							{
								num = 56;
							}
							if (num12 == 20)
							{
								num = 41;
							}
							if (num12 == 21)
							{
								num = 57;
							}
							if (num12 == 22)
							{
								num = 42;
							}
							if (num12 == 23)
							{
								num = 43;
							}
							if (num12 == 24)
							{
								num = 44;
							}
							if (num12 == 25)
							{
								num = 45;
							}
							if (num12 == 26)
							{
								num = 46;
							}
							if (num12 == 27)
							{
								num = 47;
							}
							if (num12 == 28)
							{
								num = 48;
							}
							if (num12 == 29)
							{
								num = 49;
							}
							if (num12 == 30)
							{
								num = 50;
							}
							if (num12 == 31)
							{
								num = 51;
							}
							if (num12 == 32)
							{
								num = 59;
							}
							if (num12 == 33)
							{
								num = 60;
							}
							if (num12 == 34)
							{
								num = 61;
							}
							if (num12 == 35)
							{
								num = 83;
							}
						}
						else if (this.type == 55 || this.type == 119 || this.type == 191 || this.type == 284)
						{
							int num13 = Main.rand.Next(14);
							if (num13 == 0)
							{
								num = 36;
							}
							if (num13 == 1)
							{
								num = 37;
							}
							if (num13 == 2)
							{
								num = 38;
							}
							if (num13 == 3)
							{
								num = 53;
							}
							if (num13 == 4)
							{
								num = 54;
							}
							if (num13 == 5)
							{
								num = 55;
							}
							if (num13 == 6)
							{
								num = 39;
							}
							if (num13 == 7)
							{
								num = 40;
							}
							if (num13 == 8)
							{
								num = 56;
							}
							if (num13 == 9)
							{
								num = 41;
							}
							if (num13 == 10)
							{
								num = 57;
							}
							if (num13 == 11)
							{
								num = 59;
							}
							if (num13 == 12)
							{
								num = 60;
							}
							if (num13 == 13)
							{
								num = 61;
							}
						}
						else
						{
							if (!this.accessory || this.type == 267 || this.type == 562 || this.type == 563 || this.type == 564 || this.type == 565 || this.type == 566 || this.type == 567 || this.type == 568 || this.type == 569 || this.type == 570 || this.type == 571 || this.type == 572 || this.type == 573 || this.type == 574 || this.type == 576)
							{
								result = false;
								return result;
							}
							num = Main.rand.Next(62, 81);
						}
					}
					if (pre == -3)
					{
						result = true;
						return result;
					}
					if (pre == -1 && (num == 7 || num == 8 || num == 9 || num == 10 || num == 11 || num == 22 || num == 23 || num == 24 || num == 29 || num == 30 || num == 31 || num == 39 || num == 40 || num == 56 || num == 41 || num == 47 || num == 48 || num == 49) && Main.rand.Next(3) != 0)
					{
						num = 0;
					}
					if (num == 1)
					{
						num5 = 1.12f;
					}
					else if (num == 2)
					{
						num5 = 1.18f;
					}
					else if (num == 3)
					{
						num2 = 1.05f;
						num8 = 2;
						num5 = 1.05f;
					}
					else if (num == 4)
					{
						num2 = 1.1f;
						num5 = 1.1f;
						num3 = 1.1f;
					}
					else if (num == 5)
					{
						num2 = 1.15f;
					}
					else if (num == 6)
					{
						num2 = 1.1f;
					}
					else if (num == 81)
					{
						num3 = 1.15f;
						num2 = 1.15f;
						num8 = 5;
						num4 = 0.9f;
						num5 = 1.1f;
					}
					else if (num == 7)
					{
						num5 = 0.82f;
					}
					else if (num == 8)
					{
						num3 = 0.85f;
						num2 = 0.85f;
						num5 = 0.87f;
					}
					else if (num == 9)
					{
						num5 = 0.9f;
					}
					else if (num == 10)
					{
						num2 = 0.85f;
					}
					else if (num == 11)
					{
						num4 = 1.1f;
						num3 = 0.9f;
						num5 = 0.9f;
					}
					else if (num == 12)
					{
						num3 = 1.1f;
						num2 = 1.05f;
						num5 = 1.1f;
						num4 = 1.15f;
					}
					else if (num == 13)
					{
						num3 = 0.8f;
						num2 = 0.9f;
						num5 = 1.1f;
					}
					else if (num == 14)
					{
						num3 = 1.15f;
						num4 = 1.1f;
					}
					else if (num == 15)
					{
						num3 = 0.9f;
						num4 = 0.85f;
					}
					else if (num == 16)
					{
						num2 = 1.1f;
						num8 = 3;
					}
					else if (num == 17)
					{
						num4 = 0.85f;
						num6 = 1.1f;
					}
					else if (num == 18)
					{
						num4 = 0.9f;
						num6 = 1.15f;
					}
					else if (num == 19)
					{
						num3 = 1.15f;
						num6 = 1.05f;
					}
					else if (num == 20)
					{
						num3 = 1.05f;
						num6 = 1.05f;
						num2 = 1.1f;
						num4 = 0.95f;
						num8 = 2;
					}
					else if (num == 21)
					{
						num3 = 1.15f;
						num2 = 1.1f;
					}
					else if (num == 82)
					{
						num3 = 1.15f;
						num2 = 1.15f;
						num8 = 5;
						num4 = 0.9f;
						num6 = 1.1f;
					}
					else if (num == 22)
					{
						num3 = 0.9f;
						num6 = 0.9f;
						num2 = 0.85f;
					}
					else if (num == 23)
					{
						num4 = 1.15f;
						num6 = 0.9f;
					}
					else if (num == 24)
					{
						num4 = 1.1f;
						num3 = 0.8f;
					}
					else if (num == 25)
					{
						num4 = 1.1f;
						num2 = 1.15f;
						num8 = 1;
					}
					else if (num == 58)
					{
						num4 = 0.85f;
						num2 = 0.85f;
					}
					else if (num == 26)
					{
						num7 = 0.85f;
						num2 = 1.1f;
					}
					else if (num == 27)
					{
						num7 = 0.85f;
					}
					else if (num == 28)
					{
						num7 = 0.85f;
						num2 = 1.15f;
						num3 = 1.05f;
					}
					else if (num == 83)
					{
						num3 = 1.15f;
						num2 = 1.15f;
						num8 = 5;
						num4 = 0.9f;
						num7 = 0.9f;
					}
					else if (num == 29)
					{
						num7 = 1.1f;
					}
					else if (num == 30)
					{
						num7 = 1.2f;
						num2 = 0.9f;
					}
					else if (num == 31)
					{
						num3 = 0.9f;
						num2 = 0.9f;
					}
					else if (num == 32)
					{
						num7 = 1.15f;
						num2 = 1.1f;
					}
					else if (num == 33)
					{
						num7 = 1.1f;
						num3 = 1.1f;
						num4 = 0.9f;
					}
					else if (num == 34)
					{
						num7 = 0.9f;
						num3 = 1.1f;
						num4 = 1.1f;
						num2 = 1.1f;
					}
					else if (num == 35)
					{
						num7 = 1.2f;
						num2 = 1.15f;
						num3 = 1.15f;
					}
					else if (num == 52)
					{
						num7 = 0.9f;
						num2 = 0.9f;
						num4 = 0.9f;
					}
					else if (num == 36)
					{
						num8 = 3;
					}
					else if (num == 37)
					{
						num2 = 1.1f;
						num8 = 3;
						num3 = 1.1f;
					}
					else if (num == 38)
					{
						num3 = 1.15f;
					}
					else if (num == 53)
					{
						num2 = 1.1f;
					}
					else if (num == 54)
					{
						num3 = 1.15f;
					}
					else if (num == 55)
					{
						num3 = 1.15f;
						num2 = 1.05f;
					}
					else if (num == 59)
					{
						num3 = 1.15f;
						num2 = 1.15f;
						num8 = 5;
					}
					else if (num == 60)
					{
						num2 = 1.15f;
						num8 = 5;
					}
					else if (num == 61)
					{
						num8 = 5;
					}
					else if (num == 39)
					{
						num2 = 0.7f;
						num3 = 0.8f;
					}
					else if (num == 40)
					{
						num2 = 0.85f;
					}
					else if (num == 56)
					{
						num3 = 0.8f;
					}
					else if (num == 41)
					{
						num3 = 0.85f;
						num2 = 0.9f;
					}
					else if (num == 57)
					{
						num3 = 0.9f;
						num2 = 1.18f;
					}
					else if (num == 42)
					{
						num4 = 0.9f;
					}
					else if (num == 43)
					{
						num2 = 1.1f;
						num4 = 0.9f;
					}
					else if (num == 44)
					{
						num4 = 0.9f;
						num8 = 3;
					}
					else if (num == 45)
					{
						num4 = 0.95f;
					}
					else if (num == 46)
					{
						num8 = 3;
						num4 = 0.94f;
						num2 = 1.07f;
					}
					else if (num == 47)
					{
						num4 = 1.15f;
					}
					else if (num == 48)
					{
						num4 = 1.2f;
					}
					else if (num == 49)
					{
						num4 = 1.08f;
					}
					else if (num == 50)
					{
						num2 = 0.8f;
						num4 = 1.15f;
					}
					else if (num == 51)
					{
						num3 = 0.9f;
						num4 = 0.9f;
						num2 = 1.05f;
						num8 = 2;
					}
					if (num2 != 1f && Math.Round((double)((float)this.damage * num2)) == (double)this.damage)
					{
						flag = true;
						num = -1;
					}
					if (num4 != 1f && Math.Round((double)((float)this.useAnimation * num4)) == (double)this.useAnimation)
					{
						flag = true;
						num = -1;
					}
					if (num7 != 1f && Math.Round((double)((float)this.mana * num7)) == (double)this.mana)
					{
						flag = true;
						num = -1;
					}
					if (num3 != 1f && this.knockBack == 0f)
					{
						flag = true;
						num = -1;
					}
					if (pre == -2 && num == 0)
					{
						num = -1;
						flag = true;
					}
				}
				this.damage = (int)Math.Round((double)((float)this.damage * num2));
				this.useAnimation = (int)Math.Round((double)((float)this.useAnimation * num4));
				this.useTime = (int)Math.Round((double)((float)this.useTime * num4));
				this.reuseDelay = (int)Math.Round((double)((float)this.reuseDelay * num4));
				this.mana = (int)Math.Round((double)((float)this.mana * num7));
				this.knockBack *= num3;
				this.scale *= num5;
				this.shootSpeed *= num6;
				this.crit += num8;
				float num14 = 1f * num2 * (2f - num4) * (2f - num7) * num5 * num3 * num6 * (1f + (float)this.crit * 0.02f);
				if (num == 62 || num == 69 || num == 73 || num == 77)
				{
					num14 *= 1.05f;
				}
				if (num == 63 || num == 70 || num == 74 || num == 78 || num == 67)
				{
					num14 *= 1.1f;
				}
				if (num == 64 || num == 71 || num == 75 || num == 79 || num == 66)
				{
					num14 *= 1.15f;
				}
				if (num == 65 || num == 72 || num == 76 || num == 80 || num == 68)
				{
					num14 *= 1.2f;
				}
				if ((double)num14 >= 1.2)
				{
					this.rare += 2;
				}
				else if ((double)num14 >= 1.05)
				{
					this.rare++;
				}
				else if ((double)num14 <= 0.8)
				{
					this.rare -= 2;
				}
				else if ((double)num14 <= 0.95)
				{
					this.rare--;
				}
				if (this.rare < -1)
				{
					this.rare = -1;
				}
				if (this.rare > 6)
				{
					this.rare = 6;
				}
				num14 *= num14;
				this.value = (int)((float)this.value * num14);
				this.prefix = (byte)num;
				result = true;
			}
			return result;
		}

		public string AffixName()
		{
			string text = "";
			if (this.prefix == 1)
			{
				text = "大号的";
			}
			if (this.prefix == 2)
			{
				text = "巨大的";
			}
			if (this.prefix == 3)
			{
				text = "致命的";
			}
			if (this.prefix == 4)
			{
				text = "残暴的";
			}
			if (this.prefix == 5)
			{
				text = "锋利的";
			}
			if (this.prefix == 6)
			{
				text = "尖锐的";
			}
			if (this.prefix == 7)
			{
				text = "迷你的";
			}
			if (this.prefix == 8)
			{
				text = "糟糕的";
			}
			if (this.prefix == 9)
			{
				text = "细小的";
			}
			if (this.prefix == 10)
			{
				text = "钝锋的";
			}
			if (this.prefix == 11)
			{
				text = "倒霉的";
			}
			if (this.prefix == 12)
			{
				text = "笨重的";
			}
			if (this.prefix == 13)
			{
				text = "丢人的";
			}
			if (this.prefix == 14)
			{
				text = "沉重的";
			}
			if (this.prefix == 15)
			{
				text = "轻巧的";
			}
			if (this.prefix == 16)
			{
				text = "有瞄准器的";
			}
			if (this.prefix == 17)
			{
				text = "疾速的";
			}
			if (this.prefix == 18)
			{
				text = "迅捷的";
			}
			if (this.prefix == 19)
			{
				text = "压制的";
			}
			if (this.prefix == 20)
			{
				text = "致死的";
			}
			if (this.prefix == 21)
			{
				text = "可靠的";
			}
			if (this.prefix == 22)
			{
				text = "差劲的";
			}
			if (this.prefix == 23)
			{
				text = "疲倦的";
			}
			if (this.prefix == 24)
			{
				text = "笨拙的";
			}
			if (this.prefix == 25)
			{
				text = "强力的";
			}
			if (this.prefix == 58)
			{
				text = "狂暴的";
			}
			if (this.prefix == 26)
			{
				text = "神秘的";
			}
			if (this.prefix == 27)
			{
				text = "内行的";
			}
			if (this.prefix == 28)
			{
				text = "熟练的";
			}
			if (this.prefix == 29)
			{
				text = "无能的";
			}
			if (this.prefix == 30)
			{
				text = "无知的";
			}
			if (this.prefix == 31)
			{
				text = "不稳定的";
			}
			if (this.prefix == 32)
			{
				text = "强烈的";
			}
			if (this.prefix == 33)
			{
				text = "禁忌的";
			}
			if (this.prefix == 34)
			{
				text = "神圣的";
			}
			if (this.prefix == 35)
			{
				text = "狂怒的";
			}
			if (this.prefix == 52)
			{
				text = "疯狂的";
			}
			if (this.prefix == 36)
			{
				text = "锐利的";
			}
			if (this.prefix == 37)
			{
				text = "卓越的";
			}
			if (this.prefix == 38)
			{
				text = "力场的";
			}
			if (this.prefix == 53)
			{
				text = "痛苦的";
			}
			if (this.prefix == 54)
			{
				text = "强壮的";
			}
			if (this.prefix == 55)
			{
				text = "讨厌的";
			}
			if (this.prefix == 39)
			{
				text = "坏掉的";
			}
			if (this.prefix == 40)
			{
				text = "受损的";
			}
			if (this.prefix == 56)
			{
				text = "无力的";
			}
			if (this.prefix == 41)
			{
				text = "山寨的";
			}
			if (this.prefix == 57)
			{
				text = "无情的";
			}
			if (this.prefix == 42)
			{
				text = "快速的";
			}
			if (this.prefix == 43)
			{
				text = "致命的";
			}
			if (this.prefix == 44)
			{
				text = "敏捷的";
			}
			if (this.prefix == 45)
			{
				text = "灵巧的";
			}
			if (this.prefix == 46)
			{
				text = "残暴的";
			}
			if (this.prefix == 47)
			{
				text = "缓慢的";
			}
			if (this.prefix == 48)
			{
				text = "迟钝的";
			}
			if (this.prefix == 49)
			{
				text = "倦怠的";
			}
			if (this.prefix == 50)
			{
				text = "烦人的";
			}
			if (this.prefix == 51)
			{
				text = "猥琐的";
			}
			if (this.prefix == 59)
			{
				text = "神器的";
			}
			if (this.prefix == 60)
			{
				text = "恶魔的";
			}
			if (this.prefix == 61)
			{
				text = "狂热的";
			}
			if (this.prefix == 62)
			{
				text = "坚硬的";
			}
			if (this.prefix == 63)
			{
				text = "守护的";
			}
			if (this.prefix == 64)
			{
				text = "装甲的";
			}
			if (this.prefix == 65)
			{
				text = "护佑的";
			}
			if (this.prefix == 66)
			{
				text = "奥术的";
			}
			if (this.prefix == 67)
			{
				text = "精准的";
			}
			if (this.prefix == 68)
			{
				text = "幸运的";
			}
			if (this.prefix == 69)
			{
				text = "有锯齿的";
			}
			if (this.prefix == 70)
			{
				text = "有尖刺的";
			}
			if (this.prefix == 71)
			{
				text = "发怒的";
			}
			if (this.prefix == 72)
			{
				text = "险恶的";
			}
			if (this.prefix == 73)
			{
				text = "轻快的";
			}
			if (this.prefix == 74)
			{
				text = "敏捷的";
			}
			if (this.prefix == 75)
			{
				text = "急速的";
			}
			if (this.prefix == 76)
			{
				text = "迅捷的";
			}
			if (this.prefix == 77)
			{
				text = "狂野的";
			}
			if (this.prefix == 78)
			{
				text = "鲁莽的";
			}
			if (this.prefix == 79)
			{
				text = "勇猛的";
			}
			if (this.prefix == 80)
			{
				text = "暴力的";
			}
			if (this.prefix == 81)
			{
				text = "传说中的";
			}
			if (this.prefix == 82)
			{
				text = "浮云的";
			}
			if (this.prefix == 83)
			{
				text = "神话中的";
			}
			string result = this.CName;
			if (text != "")
			{
				result = text + " " + this.CName;
			}
			return result;
		}

		public void SetDefaults(string ItemName)
		{
			this.name = "";
			bool flag = false;
			if (ItemName == "Gold Pickaxe")
			{
				this.SetDefaults(1, false);
				this.CName = "黄金锄头";
				this.color = new Color(210, 190, 0, 100);
				this.useTime = 17;
				this.pick = 55;
				this.useAnimation = 20;
				this.scale = 1.05f;
				this.damage = 6;
				this.value = 10000;
				this.toolTip = "可以挖掘陨石";
				this.netID = -1;
			}
			else if (ItemName == "Gold Broadsword")
			{
				this.SetDefaults(4, false);
				this.CName = "黄金宽刃剑";
				this.color = new Color(210, 190, 0, 100);
				this.useAnimation = 20;
				this.damage = 13;
				this.scale = 1.05f;
				this.value = 9000;
				this.netID = -2;
			}
			else if (ItemName == "Gold Shortsword")
			{
				this.SetDefaults(6, false);
				this.CName = "黄金短剑";
				this.color = new Color(210, 190, 0, 100);
				this.damage = 11;
				this.useAnimation = 11;
				this.scale = 0.95f;
				this.value = 7000;
				this.netID = -3;
			}
			else if (ItemName == "Gold Axe")
			{
				this.SetDefaults(10, false);
				this.CName = "黄金斧头";
				this.color = new Color(210, 190, 0, 100);
				this.useTime = 18;
				this.axe = 11;
				this.useAnimation = 26;
				this.scale = 1.15f;
				this.damage = 7;
				this.value = 8000;
				this.netID = -4;
			}
			else if (ItemName == "Gold Hammer")
			{
				this.SetDefaults(7, false);
				this.CName = "黄金大锤";
				this.color = new Color(210, 190, 0, 100);
				this.useAnimation = 28;
				this.useTime = 23;
				this.scale = 1.25f;
				this.damage = 9;
				this.hammer = 55;
				this.value = 8000;
				this.netID = -5;
			}
			else if (ItemName == "Gold Bow")
			{
				this.SetDefaults(99, false);
				this.CName = "黄金短弓";
				this.useAnimation = 26;
				this.useTime = 26;
				this.color = new Color(210, 190, 0, 100);
				this.damage = 11;
				this.value = 7000;
				this.netID = -6;
			}
			else if (ItemName == "Silver Pickaxe")
			{
				this.SetDefaults(1, false);
				this.CName = "白银锄头";
				this.color = new Color(180, 180, 180, 100);
				this.useTime = 11;
				this.pick = 45;
				this.useAnimation = 19;
				this.scale = 1.05f;
				this.damage = 6;
				this.value = 5000;
				this.netID = -7;
			}
			else if (ItemName == "Silver Broadsword")
			{
				this.SetDefaults(4, false);
				this.CName = "白银宽刃剑";
				this.color = new Color(180, 180, 180, 100);
				this.useAnimation = 21;
				this.damage = 11;
				this.value = 4500;
				this.netID = -8;
			}
			else if (ItemName == "Silver Shortsword")
			{
				this.SetDefaults(6, false);
				this.CName = "白银短剑";
				this.color = new Color(180, 180, 180, 100);
				this.damage = 9;
				this.useAnimation = 12;
				this.scale = 0.95f;
				this.value = 3500;
				this.netID = -9;
			}
			else if (ItemName == "Silver Axe")
			{
				this.SetDefaults(10, false);
				this.CName = "白银斧头";
				this.color = new Color(180, 180, 180, 100);
				this.useTime = 18;
				this.axe = 10;
				this.useAnimation = 26;
				this.scale = 1.15f;
				this.damage = 6;
				this.value = 4000;
				this.netID = -10;
			}
			else if (ItemName == "Silver Hammer")
			{
				this.SetDefaults(7, false);
				this.CName = "白银大锤";
				this.color = new Color(180, 180, 180, 100);
				this.useAnimation = 29;
				this.useTime = 19;
				this.scale = 1.25f;
				this.damage = 9;
				this.hammer = 45;
				this.value = 4000;
				this.netID = -11;
			}
			else if (ItemName == "Silver Bow")
			{
				this.SetDefaults(99, false);
				this.CName = "白银短弓";
				this.useAnimation = 27;
				this.useTime = 27;
				this.color = new Color(180, 180, 180, 100);
				this.damage = 9;
				this.value = 3500;
				this.netID = -12;
			}
			else if (ItemName == "Copper Pickaxe")
			{
				this.SetDefaults(1, false);
				this.CName = "铜质锄头";
				this.color = new Color(180, 100, 45, 80);
				this.useTime = 15;
				this.pick = 35;
				this.useAnimation = 23;
				this.damage = 4;
				this.scale = 0.9f;
				this.tileBoost = -1;
				this.value = 500;
				this.netID = -13;
			}
			else if (ItemName == "Copper Broadsword")
			{
				this.SetDefaults(4, false);
				this.CName = "铜质宽刃剑";
				this.color = new Color(180, 100, 45, 80);
				this.useAnimation = 23;
				this.damage = 8;
				this.value = 450;
				this.netID = -14;
			}
			else if (ItemName == "Copper Shortsword")
			{
				this.SetDefaults(6, false);
				this.CName = "铜质短剑";
				this.color = new Color(180, 100, 45, 80);
				this.damage = 5;
				this.useAnimation = 13;
				this.scale = 0.8f;
				this.value = 350;
				this.netID = -15;
			}
			else if (ItemName == "Copper Axe")
			{
				this.SetDefaults(10, false);
				this.CName = "铜质斧头";
				this.color = new Color(180, 100, 45, 80);
				this.useTime = 21;
				this.axe = 7;
				this.useAnimation = 30;
				this.scale = 1f;
				this.damage = 3;
				this.tileBoost = -1;
				this.value = 400;
				this.netID = -16;
			}
			else if (ItemName == "Copper Hammer")
			{
				this.SetDefaults(7, false);
				this.CName = "铜质大锤";
				this.color = new Color(180, 100, 45, 80);
				this.useAnimation = 33;
				this.useTime = 23;
				this.scale = 1.1f;
				this.damage = 4;
				this.hammer = 35;
				this.tileBoost = -1;
				this.value = 400;
				this.netID = -17;
			}
			else if (ItemName == "Copper Bow")
			{
				this.SetDefaults(99, false);
				this.CName = "铜质短弓";
				this.useAnimation = 29;
				this.useTime = 29;
				this.color = new Color(180, 100, 45, 80);
				this.damage = 6;
				this.value = 350;
				this.netID = -18;
			}
			else if (ItemName == "Blue Phasesaber")
			{
				this.SetDefaults(198, false);
				this.CName = "冰蓝光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -19;
			}
			else if (ItemName == "Red Phasesaber")
			{
				this.SetDefaults(199, false);
				this.CName = "真红光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -20;
			}
			else if (ItemName == "Green Phasesaber")
			{
				this.SetDefaults(200, false);
				this.CName = "翠绿光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -21;
			}
			else if (ItemName == "Purple Phasesaber")
			{
				this.SetDefaults(201, false);
				this.CName = "紫晶光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -22;
			}
			else if (ItemName == "White Phasesaber")
			{
				this.SetDefaults(202, false);
				this.CName = "纯白光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -23;
			}
			else if (ItemName == "Yellow Phasesaber")
			{
				this.SetDefaults(203, false);
				this.CName = "黄昏光刃";
				this.damage = 41;
				this.scale = 1.15f;
				flag = true;
				this.autoReuse = true;
				this.useTurn = true;
				this.rare = 4;
				this.netID = -24;
			}
			else if (ItemName != "")
			{
				for (int i = 0; i < 603; i++)
				{
					if (Main.itemName[i] == ItemName)
					{
						this.SetDefaults(i, false);
						this.checkMat();
						return;
					}
				}
				this.name = "";
				this.stack = 0;
				this.type = 0;
			}
			if (this.type != 0)
			{
				if (flag)
				{
					this.material = false;
				}
				else
				{
					this.checkMat();
				}
				this.name = ItemName;
			}
		}

		public bool checkMat()
		{
			bool result;
			if (this.type >= 71 && this.type <= 74)
			{
				this.material = false;
				result = false;
			}
			else
			{
				for (int i = 0; i < Recipe.numRecipes; i++)
				{
					int num = 0;
					while (Main.recipe[i].requiredItem[num].type > 0)
					{
						if (this.name == Main.recipe[i].requiredItem[num].name)
						{
							this.material = true;
							result = true;
							return result;
						}
						num++;
					}
				}
				this.material = false;
				result = false;
			}
			return result;
		}

		public void netDefaults(int type)
		{
			if (type < 0)
			{
				if (type == -1)
				{
					this.SetDefaults("Gold Pickaxe");
				}
				else if (type == -2)
				{
					this.SetDefaults("Gold Broadsword");
				}
				else if (type == -3)
				{
					this.SetDefaults("Gold Shortsword");
				}
				else if (type == -4)
				{
					this.SetDefaults("Gold Axe");
				}
				else if (type == -5)
				{
					this.SetDefaults("Gold Hammer");
				}
				else if (type == -6)
				{
					this.SetDefaults("Gold Bow");
				}
				else if (type == -7)
				{
					this.SetDefaults("Silver Pickaxe");
				}
				else if (type == -8)
				{
					this.SetDefaults("Silver Broadsword");
				}
				else if (type == -9)
				{
					this.SetDefaults("Silver Shortsword");
				}
				else if (type == -10)
				{
					this.SetDefaults("Silver Axe");
				}
				else if (type == -11)
				{
					this.SetDefaults("Silver Hammer");
				}
				else if (type == -12)
				{
					this.SetDefaults("Silver Bow");
				}
				else if (type == -13)
				{
					this.SetDefaults("Copper Pickaxe");
				}
				else if (type == -14)
				{
					this.SetDefaults("Copper Broadsword");
				}
				else if (type == -15)
				{
					this.SetDefaults("Copper Shortsword");
				}
				else if (type == -16)
				{
					this.SetDefaults("Copper Axe");
				}
				else if (type == -17)
				{
					this.SetDefaults("Copper Hammer");
				}
				else if (type == -18)
				{
					this.SetDefaults("Copper Bow");
				}
				else if (type == -19)
				{
					this.SetDefaults("Blue Phasesaber");
				}
				else if (type == -20)
				{
					this.SetDefaults("Red Phasesaber");
				}
				else if (type == -21)
				{
					this.SetDefaults("Green Phasesaber");
				}
				else if (type == -22)
				{
					this.SetDefaults("Purple Phasesaber");
				}
				else if (type == -23)
				{
					this.SetDefaults("White Phasesaber");
				}
				else if (type == -24)
				{
					this.SetDefaults("Yellow Phasesaber");
				}
			}
			else
			{
				this.SetDefaults(type, false);
			}
		}

		public void SetDefaults(int Type, bool noMatCheck = false)
		{
			if (Main.netMode == 1 || Main.netMode == 2)
			{
				this.owner = 255;
			}
			else
			{
				this.owner = Main.myPlayer;
			}
			this.netID = 0;
			this.prefix = 0;
			this.crit = 0;
			this.mech = false;
			this.reuseDelay = 0;
			this.melee = false;
			this.magic = false;
			this.ranged = false;
			this.placeStyle = 0;
			this.buffTime = 0;
			this.buffType = 0;
			this.material = false;
			this.noWet = false;
			this.vanity = false;
			this.mana = 0;
			this.wet = false;
			this.wetCount = 0;
			this.lavaWet = false;
			this.channel = false;
			this.manaIncrease = 0;
			this.release = 0;
			this.noMelee = false;
			this.noUseGraphic = false;
			this.lifeRegen = 0;
			this.shootSpeed = 0f;
			this.active = true;
			this.alpha = 0;
			this.ammo = 0;
			this.useAmmo = 0;
			this.autoReuse = false;
			this.accessory = false;
			this.axe = 0;
			this.healMana = 0;
			this.bodySlot = -1;
			this.legSlot = -1;
			this.headSlot = -1;
			this.potion = false;
			this.color = default(Color);
			this.consumable = false;
			this.createTile = -1;
			this.createWall = -1;
			this.damage = -1;
			this.defense = 0;
			this.hammer = 0;
			this.healLife = 0;
			this.holdStyle = 0;
			this.knockBack = 0f;
			this.maxStack = 1;
			this.pick = 0;
			this.rare = 0;
			this.scale = 1f;
			this.shoot = 0;
			this.stack = 1;
			this.toolTip = null;
			this.toolTip2 = null;
			this.tileBoost = 0;
			this.type = Type;
			this.useStyle = 0;
			this.useSound = 0;
			this.useTime = 100;
			this.useAnimation = 100;
			this.value = 0;
			this.useTurn = false;
			this.buy = false;
			if (this.type == 0)
			{
				this.name = "";
				this.CName = "";
				this.stack = 0;
			}
			else if (this.type == 1)
			{
				this.name = "Iron Pickaxe";
				this.CName = "铁质锄头";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 20;
				this.useTime = 13;
				this.autoReuse = true;
				this.width = 24;
				this.height = 28;
				this.damage = 5;
				this.pick = 40;
				this.useSound = 1;
				this.knockBack = 2f;
				this.value = 2000;
				this.melee = true;
			}
			else if (this.type == 2)
			{
				this.name = "Dirt Block";
				this.CName = "门峰2泥土块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 0;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 3)
			{
				this.name = "Stone Block";
				this.CName = "岩石块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 1;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 4)
			{
				this.name = "Iron Broadsword";
				this.CName = "铁质宽刃剑";
				this.useStyle = 1;
				this.useTurn = false;
				this.useAnimation = 21;
				this.useTime = 21;
				this.width = 24;
				this.height = 28;
				this.damage = 10;
				this.knockBack = 5f;
				this.useSound = 1;
				this.scale = 1f;
				this.value = 1800;
				this.melee = true;
			}
			else if (this.type == 5)
			{
				this.name = "Mushroom";
				this.CName = "蘑菇";
				this.useStyle = 2;
				this.useSound = 2;
				this.useTurn = false;
				this.useAnimation = 17;
				this.useTime = 17;
				this.width = 16;
				this.height = 18;
				this.healLife = 15;
				this.maxStack = 99;
				this.consumable = true;
				this.potion = true;
				this.value = 25;
			}
			else if (this.type == 6)
			{
				this.name = "Iron Shortsword";
				this.CName = "铁质短剑";
				this.useStyle = 3;
				this.useTurn = false;
				this.useAnimation = 12;
				this.useTime = 12;
				this.width = 24;
				this.height = 28;
				this.damage = 8;
				this.knockBack = 4f;
				this.scale = 0.9f;
				this.useSound = 1;
				this.useTurn = true;
				this.value = 1400;
				this.melee = true;
			}
			else if (this.type == 7)
			{
				this.name = "Iron Hammer";
				this.CName = "铁质大锤";
				this.autoReuse = true;
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 30;
				this.useTime = 20;
				this.hammer = 45;
				this.width = 24;
				this.height = 28;
				this.damage = 7;
				this.knockBack = 5.5f;
				this.scale = 1.2f;
				this.useSound = 1;
				this.value = 1600;
				this.melee = true;
			}
			else if (this.type == 8)
			{
				this.noWet = true;
				this.name = "Torch";
				this.CName = "火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.width = 10;
				this.height = 12;
				this.toolTip = "简易的光源";
				this.value = 50;
			}
			else if (this.type == 9)
			{
				this.name = "Wood";
				this.CName = "木材";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 30;
				this.width = 8;
				this.height = 10;
			}
			else if (this.type == 10)
			{
				this.name = "Iron Axe";
				this.CName = "铁质斧头";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 27;
				this.knockBack = 4.5f;
				this.useTime = 19;
				this.autoReuse = true;
				this.width = 24;
				this.height = 28;
				this.damage = 5;
				this.axe = 9;
				this.scale = 1.1f;
				this.useSound = 1;
				this.value = 1600;
				this.melee = true;
			}
			else if (this.type == 11)
			{
				this.name = "Iron Ore";
				this.CName = "铁矿石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 6;
				this.width = 12;
				this.height = 12;
				this.value = 500;
			}
			else if (this.type == 12)
			{
				this.name = "Copper Ore";
				this.CName = "铜矿石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 7;
				this.width = 12;
				this.height = 12;
				this.value = 250;
			}
			else if (this.type == 13)
			{
				this.name = "Gold Ore";
				this.CName = "金矿石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 8;
				this.width = 12;
				this.height = 12;
				this.value = 2000;
			}
			else if (this.type == 14)
			{
				this.name = "Silver Ore";
				this.CName = "银矿石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 9;
				this.width = 12;
				this.height = 12;
				this.value = 1000;
			}
			else if (this.type == 15)
			{
				this.name = "Copper Watch";
				this.CName = "铜怀表";
				this.width = 24;
				this.height = 28;
				this.accessory = true;
				this.toolTip = "表盘上有一个时针和12个刻度";
				this.value = 1000;
			}
			else if (this.type == 16)
			{
				this.name = "Silver Watch";
				this.CName = "银怀表";
				this.width = 24;
				this.height = 28;
				this.accessory = true;
				this.toolTip = "表盘上有一个时针和24个刻度";
				this.value = 5000;
			}
			else if (this.type == 17)
			{
				this.name = "Gold Watch";
				this.CName = "金怀表";
				this.width = 24;
				this.height = 28;
				this.accessory = true;
				this.rare = 1;
				this.toolTip = "表盘上有时针、分针和60个刻度";
				this.value = 10000;
			}
			else if (this.type == 18)
			{
				this.name = "Depth Meter";
				this.CName = "深度计";
				this.width = 24;
				this.height = 18;
				this.accessory = true;
				this.rare = 1;
				this.toolTip = "显示的是海拔高度";
				this.value = 10000;
			}
			else if (this.type == 19)
			{
				this.name = "Gold Bar";
				this.CName = "金锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 6000;
			}
			else if (this.type == 20)
			{
				this.name = "Copper Bar";
				this.CName = "铜锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 750;
			}
			else if (this.type == 21)
			{
				this.name = "Silver Bar";
				this.CName = "银锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 3000;
			}
			else if (this.type == 22)
			{
				this.name = "Iron Bar";
				this.CName = "铁锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 1500;
			}
			else if (this.type == 23)
			{
				this.name = "Gel";
				this.CName = "凝胶";
				this.width = 10;
				this.height = 12;
				this.maxStack = 250;
				this.alpha = 175;
				this.ammo = 23;
				this.color = new Color(0, 80, 255, 100);
				this.toolTip = "'美味且易燃'";
				this.value = 5;
			}
			else if (this.type == 24)
			{
				this.name = "Wooden Sword";
				this.CName = "木剑";
				this.useStyle = 1;
				this.useTurn = false;
				this.useAnimation = 25;
				this.width = 24;
				this.height = 28;
				this.damage = 7;
				this.knockBack = 4f;
				this.scale = 0.95f;
				this.useSound = 1;
				this.value = 100;
				this.melee = true;
			}
			else if (this.type == 25)
			{
				this.name = "Wooden Door";
				this.CName = "木门";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 10;
				this.width = 14;
				this.height = 28;
				this.value = 200;
			}
			else if (this.type == 26)
			{
				this.name = "Stone Wall";
				this.CName = "岩石墙壁";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 1;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 27)
			{
				this.name = "Acorn";
				this.CName = "橡树果实";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 20;
				this.width = 18;
				this.height = 18;
				this.value = 10;
			}
			else if (this.type == 28)
			{
				this.name = "Lesser Healing Potion";
				this.CName = "弱效治疗药水";
				this.useSound = 3;
				this.healLife = 50;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.potion = true;
				this.value = 300;
			}
			else if (this.type == 29)
			{
				this.name = "Life Crystal";
				this.CName = "生命水晶";
				this.maxStack = 99;
				this.consumable = true;
				this.width = 18;
				this.height = 18;
				this.useStyle = 4;
				this.useTime = 30;
				this.useSound = 4;
				this.useAnimation = 30;
				this.toolTip = "永久提升20点最大生命值";
				this.rare = 2;
				this.value = 75000;
			}
			else if (this.type == 30)
			{
				this.name = "Dirt Wall";
				this.CName = "泥土墙壁";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 16;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 31)
			{
				this.name = "Bottle";
				this.CName = "空瓶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 13;
				this.width = 16;
				this.height = 24;
				this.value = 20;
			}
			else if (this.type == 32)
			{
				this.name = "Wooden Table";
				this.CName = "木桌";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 14;
				this.width = 26;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 33)
			{
				this.name = "Furnace";
				this.CName = "熔炉";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 17;
				this.width = 26;
				this.height = 24;
				this.value = 300;
				this.toolTip = "用来熔炼矿石";
			}
			else if (this.type == 34)
			{
				this.name = "Wooden Chair";
				this.CName = "木椅";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 15;
				this.width = 12;
				this.height = 30;
				this.value = 150;
			}
			else if (this.type == 35)
			{
				this.name = "Iron Anvil";
				this.CName = "铁砧";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 16;
				this.width = 28;
				this.height = 14;
				this.value = 5000;
				this.toolTip = "可用于初级金属锻造";
			}
			else if (this.type == 36)
			{
				this.name = "Work Bench";
				this.CName = "工作台";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 18;
				this.width = 28;
				this.height = 14;
				this.value = 150;
				this.toolTip = "用于初级道具制作";
			}
			else if (this.type == 37)
			{
				this.name = "Goggles";
				this.CName = "护目镜";
				this.width = 28;
				this.height = 12;
				this.defense = 1;
				this.headSlot = 10;
				this.rare = 1;
				this.value = 1000;
			}
			else if (this.type == 38)
			{
				this.name = "Lens";
				this.CName = "晶状体";
				this.width = 12;
				this.height = 20;
				this.maxStack = 99;
				this.value = 500;
			}
			else if (this.type == 39)
			{
				this.useStyle = 5;
				this.useAnimation = 30;
				this.useTime = 30;
				this.name = "Wooden Bow";
				this.CName = "木制短弓";
				this.width = 12;
				this.height = 28;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 4;
				this.shootSpeed = 6.1f;
				this.noMelee = true;
				this.value = 100;
				this.ranged = true;
			}
			else if (this.type == 40)
			{
				this.name = "Wooden Arrow";
				this.CName = "木箭";
				this.shootSpeed = 3f;
				this.shoot = 1;
				this.damage = 4;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 2f;
				this.value = 10;
				this.ranged = true;
			}
			else if (this.type == 41)
			{
				this.name = "Flaming Arrow";
				this.CName = "燃烧箭";
				this.shootSpeed = 3.5f;
				this.shoot = 2;
				this.damage = 6;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 2f;
				this.value = 15;
				this.ranged = true;
			}
			else if (this.type == 42)
			{
				this.useStyle = 1;
				this.name = "Shuriken";
				this.CName = "手里剑";
				this.shootSpeed = 9f;
				this.shoot = 3;
				this.damage = 10;
				this.width = 18;
				this.height = 20;
				this.maxStack = 250;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 20;
				this.ranged = true;
			}
			else if (this.type == 43)
			{
				this.useStyle = 4;
				this.name = "Suspicious Looking Eye";
				this.CName = "可疑的眼球";
				this.width = 22;
				this.height = 14;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.maxStack = 20;
				this.toolTip = "召唤邪神克苏鲁";
			}
			else if (this.type == 44)
			{
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 25;
				this.name = "Demon Bow";
				this.CName = "恶魔长弓";
				this.width = 12;
				this.height = 28;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 14;
				this.shootSpeed = 6.7f;
				this.knockBack = 1f;
				this.alpha = 30;
				this.rare = 1;
				this.noMelee = true;
				this.value = 18000;
				this.ranged = true;
			}
			else if (this.type == 45)
			{
				this.name = "War Axe of the Night";
				this.CName = "暗夜战斧";
				this.autoReuse = true;
				this.useStyle = 1;
				this.useAnimation = 30;
				this.knockBack = 6f;
				this.useTime = 15;
				this.width = 24;
				this.height = 28;
				this.damage = 20;
				this.axe = 15;
				this.scale = 1.2f;
				this.useSound = 1;
				this.rare = 1;
				this.value = 13500;
				this.melee = true;
			}
			else if (this.type == 46)
			{
				this.name = "Light's Bane";
				this.CName = "光之驱逐";
				this.useStyle = 1;
				this.useAnimation = 20;
				this.knockBack = 5f;
				this.width = 24;
				this.height = 28;
				this.damage = 17;
				this.scale = 1.1f;
				this.useSound = 1;
				this.rare = 1;
				this.value = 13500;
				this.melee = true;
			}
			else if (this.type == 47)
			{
				this.name = "Unholy Arrow";
				this.CName = "邪影箭";
				this.shootSpeed = 3.4f;
				this.shoot = 4;
				this.damage = 8;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 3f;
				this.alpha = 30;
				this.rare = 1;
				this.value = 40;
				this.ranged = true;
			}
			else if (this.type == 48)
			{
				this.name = "Chest";
				this.CName = "箱子";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 21;
				this.width = 26;
				this.height = 22;
				this.value = 500;
			}
			else if (this.type == 49)
			{
				this.name = "Band of Regeneration";
				this.CName = "再生饰带";
				this.width = 22;
				this.height = 22;
				this.accessory = true;
				this.lifeRegen = 1;
				this.rare = 1;
				this.toolTip = "缓慢回复生命值";
				this.value = 50000;
			}
			else if (this.type == 50)
			{
				this.mana = 20;
				this.name = "Magic Mirror";
				this.CName = "魔镜";
				this.useTurn = true;
				this.width = 20;
				this.height = 20;
				this.useStyle = 4;
				this.useTime = 90;
				this.useSound = 6;
				this.useAnimation = 90;
				this.toolTip = "'魔镜，魔镜，带我回家'";
				this.rare = 1;
				this.value = 50000;
			}
			else if (this.type == 51)
			{
				this.name = "Jester's Arrow";
				this.CName = "小丑之箭";
				this.shootSpeed = 0.5f;
				this.shoot = 5;
				this.damage = 9;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 4f;
				this.rare = 1;
				this.value = 100;
				this.ranged = true;
			}
			else if (this.type == 52)
			{
				this.name = "Angel Statue";
				this.CName = "天使雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 1;
			}
			else if (this.type == 53)
			{
				this.name = "Cloud in a Bottle";
				this.CName = "瓶中云";
				this.width = 16;
				this.height = 24;
				this.accessory = true;
				this.rare = 1;
				this.toolTip = "佩戴者可施展二段跳";
				this.value = 50000;
			}
			else if (this.type == 54)
			{
				this.name = "Hermes Boots";
				this.CName = "赫尔墨斯之靴";
				this.width = 28;
				this.height = 24;
				this.accessory = true;
				this.rare = 1;
				this.toolTip = "穿戴者可提高奔跑速度";
				this.value = 50000;
			}
			else if (this.type == 55)
			{
				this.noMelee = true;
				this.useStyle = 1;
				this.name = "Enchanted Boomerang";
				this.CName = "魔化回力镖";
				this.shootSpeed = 10f;
				this.shoot = 6;
				this.damage = 13;
				this.knockBack = 8f;
				this.width = 14;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.rare = 1;
				this.value = 50000;
				this.melee = true;
			}
			else if (this.type == 56)
			{
				this.name = "Demonite Ore";
				this.CName = "魔金矿石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 22;
				this.width = 12;
				this.height = 12;
				this.rare = 1;
				this.toolTip = "'脉动着黑暗能量'";
				this.value = 4000;
			}
			else if (this.type == 57)
			{
				this.name = "Demonite Bar";
				this.CName = "魔金锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.rare = 1;
				this.toolTip = "'脉动着黑暗能量'";
				this.value = 16000;
			}
			else if (this.type == 58)
			{
				this.name = "Heart";
				this.CName = "红心";
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 59)
			{
				this.name = "Corrupt Seeds";
				this.CName = "污染之种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 23;
				this.width = 14;
				this.height = 14;
				this.value = 500;
			}
			else if (this.type == 60)
			{
				this.name = "Vile Mushroom";
				this.CName = "邪恶菇";
				this.width = 16;
				this.height = 18;
				this.maxStack = 99;
				this.value = 50;
			}
			else if (this.type == 61)
			{
				this.name = "Ebonstone Block";
				this.CName = "黑檀石块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 25;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 62)
			{
				this.name = "Grass Seeds";
				this.CName = "草种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 2;
				this.width = 14;
				this.height = 14;
				this.value = 20;
			}
			else if (this.type == 63)
			{
				this.name = "Sunflower";
				this.CName = "向日葵";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 27;
				this.width = 26;
				this.height = 26;
				this.value = 200;
			}
			else if (this.type == 64)
			{
				this.mana = 12;
				this.damage = 8;
				this.useStyle = 1;
				this.name = "Vilethorn";
				this.CName = "邪恶荆刺";
				this.shootSpeed = 32f;
				this.shoot = 7;
				this.width = 26;
				this.height = 28;
				this.useSound = 8;
				this.useAnimation = 30;
				this.useTime = 30;
				this.rare = 1;
				this.noMelee = true;
				this.knockBack = 1f;
				this.toolTip = "召唤一条无视障碍的魔法荆棘";
				this.value = 10000;
				this.magic = true;
			}
			else if (this.type == 65)
			{
				this.autoReuse = true;
				this.mana = 16;
				this.knockBack = 5f;
				this.alpha = 100;
				this.color = new Color(150, 150, 150, 0);
				this.damage = 16;
				this.useStyle = 1;
				this.scale = 1.15f;
				this.name = "Starfury";
				this.CName = "群星之怒";
				this.shootSpeed = 12f;
				this.shoot = 9;
				this.width = 14;
				this.height = 28;
				this.useSound = 9;
				this.useAnimation = 25;
				this.useTime = 10;
				this.rare = 1;
				this.toolTip = "召唤群星从天空坠落";
				this.toolTip2 = "'伴随天神的怒火锻造而成'";
				this.value = 50000;
				this.magic = true;
			}
			else if (this.type == 66)
			{
				this.useStyle = 1;
				this.name = "Purification Powder";
				this.CName = "净化粉末";
				this.shootSpeed = 4f;
				this.shoot = 10;
				this.width = 16;
				this.height = 24;
				this.maxStack = 99;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noMelee = true;
				this.toolTip = "可用于净化腐败的气息";
				this.value = 75;
			}
			else if (this.type == 67)
			{
				this.damage = 0;
				this.useStyle = 1;
				this.name = "Vile Powder";
				this.CName = "邪恶粉末";
				this.shootSpeed = 4f;
				this.shoot = 11;
				this.width = 16;
				this.height = 24;
				this.maxStack = 99;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noMelee = true;
				this.value = 100;
				this.toolTip = "可用于中和圣洁的气息";
			}
			else if (this.type == 68)
			{
				this.name = "Rotten Chunk";
				this.CName = "腐肉";
				this.width = 18;
				this.height = 20;
				this.maxStack = 99;
				this.toolTip = "'看上去很美味……'";
				this.value = 10;
			}
			else if (this.type == 69)
			{
				this.name = "Worm Tooth";
				this.CName = "蠕虫毒牙";
				this.width = 8;
				this.height = 20;
				this.maxStack = 99;
				this.value = 100;
			}
			else if (this.type == 70)
			{
				this.useStyle = 4;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.name = "Worm Food";
				this.CName = "蠕虫诱饵";
				this.width = 28;
				this.height = 28;
				this.maxStack = 20;
				this.toolTip = "召唤吞世者";
			}
			else if (this.type == 71)
			{
				this.name = "Copper Coin";
				this.CName = "铜币";
				this.width = 10;
				this.height = 12;
				this.maxStack = 100;
				this.value = 5;
			}
			else if (this.type == 72)
			{
				this.name = "Silver Coin";
				this.CName = "银币";
				this.width = 10;
				this.height = 12;
				this.maxStack = 100;
				this.value = 500;
			}
			else if (this.type == 73)
			{
				this.name = "Gold Coin";
				this.CName = "金币";
				this.width = 10;
				this.height = 12;
				this.maxStack = 100;
				this.value = 50000;
			}
			else if (this.type == 74)
			{
				this.name = "Platinum Coin";
				this.CName = "白金币";
				this.width = 10;
				this.height = 12;
				this.maxStack = 100;
				this.value = 5000000;
			}
			else if (this.type == 75)
			{
				this.name = "Fallen Star";
				this.CName = "落星";
				this.width = 18;
				this.height = 20;
				this.maxStack = 100;
				this.alpha = 75;
				this.ammo = 15;
				this.toolTip = "太阳升起时会消失";
				this.value = 500;
				this.useStyle = 4;
				this.useSound = 4;
				this.useTurn = false;
				this.useAnimation = 17;
				this.useTime = 17;
				this.consumable = true;
				this.rare = 1;
			}
			else if (this.type == 76)
			{
				this.name = "Copper Greaves";
				this.CName = "铜质护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 1;
				this.legSlot = 1;
				this.value = 750;
			}
			else if (this.type == 77)
			{
				this.name = "Iron Greaves";
				this.CName = "铁质护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 2;
				this.legSlot = 2;
				this.value = 3000;
			}
			else if (this.type == 78)
			{
				this.name = "Silver Greaves";
				this.CName = "白银护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.legSlot = 3;
				this.value = 7500;
			}
			else if (this.type == 79)
			{
				this.name = "Gold Greaves";
				this.CName = "黄金护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.legSlot = 4;
				this.value = 15000;
			}
			else if (this.type == 80)
			{
				this.name = "Copper Chainmail";
				this.CName = "铜质链甲";
				this.width = 18;
				this.height = 18;
				this.defense = 2;
				this.bodySlot = 1;
				this.value = 1000;
			}
			else if (this.type == 81)
			{
				this.name = "Iron Chainmail";
				this.CName = "铁质链甲";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.bodySlot = 2;
				this.value = 4000;
			}
			else if (this.type == 82)
			{
				this.name = "Silver Chainmail";
				this.CName = "白银链甲";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.bodySlot = 3;
				this.value = 10000;
			}
			else if (this.type == 83)
			{
				this.name = "Gold Chainmail";
				this.CName = "黄金链甲";
				this.width = 18;
				this.height = 18;
				this.defense = 5;
				this.bodySlot = 4;
				this.value = 20000;
			}
			else if (this.type == 84)
			{
				this.noUseGraphic = true;
				this.damage = 0;
				this.knockBack = 7f;
				this.useStyle = 5;
				this.name = "Grappling Hook";
				this.CName = "钩爪";
				this.shootSpeed = 11f;
				this.shoot = 13;
				this.width = 18;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 1;
				this.noMelee = true;
				this.value = 20000;
				this.toolTip = "'忍者飞檐走壁的道具'";
			}
			else if (this.type == 85)
			{
				this.name = "Iron Chain";
				this.CName = "铁链";
				this.width = 14;
				this.height = 20;
				this.maxStack = 99;
				this.value = 1000;
			}
			else if (this.type == 86)
			{
				this.name = "Shadow Scale";
				this.CName = "暗影鳞片";
				this.width = 14;
				this.height = 18;
				this.maxStack = 99;
				this.rare = 1;
				this.value = 500;
			}
			else if (this.type == 87)
			{
				this.name = "Piggy Bank";
				this.CName = "猪猪储蓄罐";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 29;
				this.width = 20;
				this.height = 12;
				this.value = 10000;
			}
			else if (this.type == 88)
			{
				this.name = "Mining Helmet";
				this.CName = "采矿头盔";
				this.width = 22;
				this.height = 16;
				this.defense = 1;
				this.headSlot = 11;
				this.rare = 1;
				this.value = 80000;
				this.toolTip = "上面装有一盏小矿灯";
			}
			else if (this.type == 89)
			{
				this.name = "Copper Helmet";
				this.CName = "铜质头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 1;
				this.headSlot = 1;
				this.value = 1250;
			}
			else if (this.type == 90)
			{
				this.name = "Iron Helmet";
				this.CName = "铁质头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 2;
				this.headSlot = 2;
				this.value = 5000;
			}
			else if (this.type == 91)
			{
				this.name = "Silver Helmet";
				this.CName = "白银头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.headSlot = 3;
				this.value = 12500;
			}
			else if (this.type == 92)
			{
				this.name = "Gold Helmet";
				this.CName = "黄金头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.headSlot = 4;
				this.value = 25000;
			}
			else if (this.type == 93)
			{
				this.name = "Wood Wall";
				this.CName = "木墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 4;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 94)
			{
				this.name = "Wood Platform";
				this.CName = "木质平台";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 19;
				this.width = 8;
				this.height = 10;
			}
			else if (this.type == 95)
			{
				this.useStyle = 5;
				this.useAnimation = 16;
				this.useTime = 16;
				this.name = "Flintlock Pistol";
				this.CName = "燧发枪";
				this.width = 24;
				this.height = 28;
				this.shoot = 14;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 10;
				this.shootSpeed = 5f;
				this.noMelee = true;
				this.value = 50000;
				this.scale = 0.9f;
				this.rare = 1;
				this.ranged = true;
			}
			else if (this.type == 96)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 43;
				this.useTime = 43;
				this.name = "Musket";
				this.CName = "毛瑟M-1";
				this.width = 44;
				this.height = 14;
				this.shoot = 10;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 23;
				this.shootSpeed = 8f;
				this.noMelee = true;
				this.value = 100000;
				this.knockBack = 4f;
				this.rare = 1;
				this.ranged = true;
			}
			else if (this.type == 97)
			{
				this.name = "Musket Ball";
				this.CName = "枪弹";
				this.shootSpeed = 4f;
				this.shoot = 14;
				this.damage = 7;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 14;
				this.knockBack = 2f;
				this.value = 7;
				this.ranged = true;
			}
			else if (this.type == 98)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 8;
				this.useTime = 8;
				this.name = "Minishark";
				this.CName = "迷你鲨MG-I";
				this.width = 50;
				this.height = 18;
				this.shoot = 10;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 6;
				this.shootSpeed = 7f;
				this.noMelee = true;
				this.value = 350000;
				this.rare = 2;
				this.toolTip = "射击时有33%的几率不消耗弹药";
				this.toolTip2 = "'初代试做原型机'";
				this.ranged = true;
			}
			else if (this.type == 99)
			{
				this.useStyle = 5;
				this.useAnimation = 28;
				this.useTime = 28;
				this.name = "Iron Bow";
				this.CName = "铁质短弓";
				this.width = 12;
				this.height = 28;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 8;
				this.shootSpeed = 6.6f;
				this.noMelee = true;
				this.value = 1400;
				this.ranged = true;
			}
			else if (this.type == 100)
			{
				this.name = "Shadow Greaves";
				this.CName = "暗鳞护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 6;
				this.legSlot = 5;
				this.rare = 1;
				this.value = 22500;
				this.toolTip = "增加7%近战攻速";
			}
			else if (this.type == 101)
			{
				this.name = "Shadow Scalemail";
				this.CName = "暗鳞胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 7;
				this.bodySlot = 5;
				this.rare = 1;
				this.value = 30000;
				this.toolTip = "增加7%近战攻速";
			}
			else if (this.type == 102)
			{
				this.name = "Shadow Helmet";
				this.CName = "暗鳞头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 6;
				this.headSlot = 5;
				this.rare = 1;
				this.value = 37500;
				this.toolTip = "增加7%近战攻速";
			}
			else if (this.type == 103)
			{
				this.name = "Nightmare Pickaxe";
				this.CName = "噩梦锄头";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 20;
				this.useTime = 15;
				this.autoReuse = true;
				this.width = 24;
				this.height = 28;
				this.damage = 9;
				this.pick = 65;
				this.useSound = 1;
				this.knockBack = 3f;
				this.rare = 1;
				this.value = 18000;
				this.scale = 1.15f;
				this.toolTip = "可以挖掘地狱矿石";
				this.melee = true;
			}
			else if (this.type == 104)
			{
				this.name = "The Breaker";
				this.CName = "破坏者巨锤";
				this.autoReuse = true;
				this.useStyle = 1;
				this.useAnimation = 45;
				this.useTime = 19;
				this.hammer = 55;
				this.width = 24;
				this.height = 28;
				this.damage = 24;
				this.knockBack = 6f;
				this.scale = 1.3f;
				this.useSound = 1;
				this.rare = 1;
				this.value = 15000;
				this.melee = true;
			}
			else if (this.type == 105)
			{
				this.noWet = true;
				this.name = "Candle";
				this.CName = "蜡烛";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 33;
				this.width = 8;
				this.height = 18;
				this.holdStyle = 1;
			}
			else if (this.type == 106)
			{
				this.name = "Copper Chandelier";
				this.CName = "铜质吊灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 34;
				this.width = 26;
				this.height = 26;
			}
			else if (this.type == 107)
			{
				this.name = "Silver Chandelier";
				this.CName = "白银吊灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 35;
				this.width = 26;
				this.height = 26;
			}
			else if (this.type == 108)
			{
				this.name = "Gold Chandelier";
				this.CName = "黄金吊灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 36;
				this.width = 26;
				this.height = 26;
			}
			else if (this.type == 109)
			{
				this.name = "Mana Crystal";
				this.CName = "魔力水晶";
				this.maxStack = 99;
				this.consumable = true;
				this.width = 18;
				this.height = 18;
				this.useStyle = 4;
				this.useTime = 30;
				this.useSound = 29;
				this.useAnimation = 30;
				this.toolTip = "永久提升20点最大魔力值";
				this.rare = 2;
			}
			else if (this.type == 110)
			{
				this.name = "Lesser Mana Potion";
				this.CName = "弱效魔力药水";
				this.useSound = 3;
				this.healMana = 50;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 20;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.value = 100;
			}
			else if (this.type == 111)
			{
				this.name = "Band of Starpower";
				this.CName = "星光饰带";
				this.width = 22;
				this.height = 22;
				this.accessory = true;
				this.rare = 1;
				this.toolTip = "增加20点最大魔力值";
				this.value = 50000;
			}
			else if (this.type == 112)
			{
				this.mana = 17;
				this.damage = 44;
				this.useStyle = 1;
				this.name = "Flower of Fire";
				this.CName = "火花魔杖";
				this.shootSpeed = 6f;
				this.shoot = 15;
				this.width = 26;
				this.height = 28;
				this.useSound = 20;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 3;
				this.noMelee = true;
				this.knockBack = 5.5f;
				this.toolTip = "向前投出能在地面弹跳的火球";
				this.value = 10000;
				this.magic = true;
			}
			else if (this.type == 113)
			{
				this.mana = 10;
				this.channel = true;
				this.damage = 22;
				this.useStyle = 1;
				this.name = "Magic Missile";
				this.CName = "飞弹魔杖";
				this.shootSpeed = 6f;
				this.shoot = 16;
				this.width = 26;
				this.height = 28;
				this.useSound = 9;
				this.useAnimation = 17;
				this.useTime = 17;
				this.rare = 2;
				this.noMelee = true;
				this.knockBack = 5f;
				this.toolTip = "施放一枚跟随鼠标的魔法飞弹";
				this.value = 10000;
				this.magic = true;
			}
			else if (this.type == 114)
			{
				this.mana = 5;
				this.channel = true;
				this.damage = 0;
				this.useStyle = 1;
				this.name = "Dirt Rod";
				this.CName = "泥土魔杖";
				this.shoot = 17;
				this.width = 26;
				this.height = 28;
				this.useSound = 8;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 1;
				this.noMelee = true;
				this.knockBack = 5f;
				this.toolTip = "可用魔力控制附近的泥土";
				this.value = 200000;
			}
			else if (this.type == 115)
			{
				this.mana = 40;
				this.channel = true;
				this.damage = 0;
				this.useStyle = 4;
				this.name = "Orb of Light";
				this.CName = "光芒法球";
				this.shoot = 18;
				this.width = 24;
				this.height = 24;
				this.useSound = 8;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 1;
				this.noMelee = true;
				this.toolTip = "召唤一个魔法光球";
				this.value = 10000;
				this.buffType = 19;
				this.buffTime = 18000;
			}
			else if (this.type == 116)
			{
				this.name = "Meteorite";
				this.CName = "陨铁矿";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 37;
				this.width = 12;
				this.height = 12;
				this.value = 1000;
			}
			else if (this.type == 117)
			{
				this.name = "Meteorite Bar";
				this.CName = "陨铁锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.rare = 1;
				this.toolTip = "'触感坚硬而温暖'";
				this.value = 7000;
			}
			else if (this.type == 118)
			{
				this.name = "Hook";
				this.CName = "钩子";
				this.maxStack = 99;
				this.width = 18;
				this.height = 18;
				this.value = 1000;
				this.toolTip = "能在骷髅和食人鱼身上找到";
			}
			else if (this.type == 119)
			{
				this.noMelee = true;
				this.useStyle = 1;
				this.name = "Flamarang";
				this.CName = "破空之炎";
				this.shootSpeed = 11f;
				this.shoot = 19;
				this.damage = 32;
				this.knockBack = 8f;
				this.width = 14;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.rare = 3;
				this.value = 100000;
				this.melee = true;
			}
			else if (this.type == 120)
			{
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 25;
				this.name = "Molten Fury";
				this.CName = "熔火之怒";
				this.width = 14;
				this.height = 32;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 29;
				this.shootSpeed = 8f;
				this.knockBack = 2f;
				this.alpha = 30;
				this.rare = 3;
				this.noMelee = true;
				this.scale = 1.1f;
				this.value = 27000;
				this.toolTip = "能够点燃射出的木箭";
				this.ranged = true;
			}
			else if (this.type == 121)
			{
				this.name = "Fiery Greatsword";
				this.CName = "炽焰巨剑";
				this.useStyle = 1;
				this.useAnimation = 34;
				this.knockBack = 6.5f;
				this.width = 24;
				this.height = 28;
				this.damage = 36;
				this.scale = 1.3f;
				this.useSound = 1;
				this.rare = 3;
				this.value = 27000;
				this.toolTip = "'剑柄喷出的火焰汇聚成了剑刃'";
				this.melee = true;
			}
			if (this.type == 122)
			{
				this.name = "Molten Pickaxe";
				this.CName = "熔岩锄头";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 25;
				this.useTime = 25;
				this.autoReuse = true;
				this.width = 24;
				this.height = 28;
				this.damage = 12;
				this.pick = 100;
				this.scale = 1.15f;
				this.useSound = 1;
				this.knockBack = 2f;
				this.rare = 3;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 123)
			{
				this.name = "Meteor Helmet";
				this.CName = "陨星面甲";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.headSlot = 6;
				this.rare = 1;
				this.value = 45000;
				this.toolTip = "增加5%魔法伤害";
			}
			else if (this.type == 124)
			{
				this.name = "Meteor Suit";
				this.CName = "陨星胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.bodySlot = 6;
				this.rare = 1;
				this.value = 30000;
				this.toolTip = "增加5%魔法伤害";
			}
			else if (this.type == 125)
			{
				this.name = "Meteor Leggings";
				this.CName = "陨星胫甲";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.legSlot = 6;
				this.rare = 1;
				this.value = 30000;
				this.toolTip = "增加5%魔法伤害";
			}
			else if (this.type == 126)
			{
				this.name = "Bottled Water";
				this.CName = "瓶装水";
				this.useSound = 3;
				this.healLife = 20;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.potion = true;
				this.value = 20;
			}
			else if (this.type == 127)
			{
				this.autoReuse = true;
				this.useStyle = 5;
				this.useAnimation = 19;
				this.useTime = 19;
				this.name = "Space Gun";
				this.CName = "空间枪β";
				this.width = 24;
				this.height = 28;
				this.shoot = 20;
				this.mana = 8;
				this.useSound = 12;
				this.knockBack = 0.5f;
				this.damage = 17;
				this.shootSpeed = 10f;
				this.noMelee = true;
				this.scale = 0.8f;
				this.rare = 1;
				this.magic = true;
				this.value = 20000;
			}
			else if (this.type == 128)
			{
				this.name = "Rocket Boots";
				this.CName = "火箭靴";
				this.width = 28;
				this.height = 24;
				this.accessory = true;
				this.rare = 3;
				this.toolTip = "地精科技的产物";
				this.value = 50000;
			}
			else if (this.type == 129)
			{
				this.name = "Gray Brick";
				this.CName = "灰色砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 38;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 130)
			{
				this.name = "Gray Brick Wall";
				this.CName = "灰色砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 5;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 131)
			{
				this.name = "Red Brick";
				this.CName = "红色砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 39;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 132)
			{
				this.name = "Red Brick Wall";
				this.CName = "红色砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 6;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 133)
			{
				this.name = "Clay Block";
				this.CName = "粘土块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 40;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 134)
			{
				this.name = "Blue Brick";
				this.CName = "蓝色砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 41;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 135)
			{
				this.name = "Blue Brick Wall";
				this.CName = "蓝色砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 17;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 136)
			{
				this.name = "Chain Lantern";
				this.CName = "挂链吊灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 42;
				this.width = 12;
				this.height = 28;
			}
			else if (this.type == 137)
			{
				this.name = "Green Brick";
				this.CName = "绿色砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 43;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 138)
			{
				this.name = "Green Brick Wall";
				this.CName = "绿色砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 18;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 139)
			{
				this.name = "Pink Brick";
				this.CName = "粉红砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 44;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 140)
			{
				this.name = "Pink Brick Wall";
				this.CName = "粉红砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 19;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 141)
			{
				this.name = "Gold Brick";
				this.CName = "黄金砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 45;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 142)
			{
				this.name = "Gold Brick Wall";
				this.CName = "黄金砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 10;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 143)
			{
				this.name = "Silver Brick";
				this.CName = "白银砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 46;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 144)
			{
				this.name = "Silver Brick Wall";
				this.CName = "白银砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 11;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 145)
			{
				this.name = "Copper Brick";
				this.CName = "铜砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 47;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 146)
			{
				this.name = "Copper Brick Wall";
				this.CName = "铜砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 12;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 147)
			{
				this.name = "Spike";
				this.CName = "金属尖刺";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 48;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 148)
			{
				this.noWet = true;
				this.name = "Water Candle";
				this.CName = "水蜡烛";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 49;
				this.width = 8;
				this.height = 18;
				this.holdStyle = 1;
				this.toolTip = "手里拿着它的话可能会招来意想不到的麻烦";
			}
			else if (this.type == 149)
			{
				this.name = "Book";
				this.CName = "书";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 50;
				this.width = 24;
				this.height = 28;
				this.toolTip = "'上面画着奇怪的符号'";
			}
			else if (this.type == 150)
			{
				this.name = "Cobweb";
				this.CName = "蜘蛛网";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 51;
				this.width = 20;
				this.height = 24;
				this.alpha = 100;
			}
			else if (this.type == 151)
			{
				this.name = "Necro Helmet";
				this.CName = "死灵头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 5;
				this.headSlot = 7;
				this.rare = 2;
				this.value = 45000;
				this.toolTip = "增加4%远程伤害";
			}
			else if (this.type == 152)
			{
				this.name = "Necro Breastplate";
				this.CName = "死灵胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 6;
				this.bodySlot = 7;
				this.rare = 2;
				this.value = 30000;
				this.toolTip = "增加4%远程伤害";
			}
			else if (this.type == 153)
			{
				this.name = "Necro Greaves";
				this.CName = "死灵胫甲";
				this.width = 18;
				this.height = 18;
				this.defense = 5;
				this.legSlot = 7;
				this.rare = 2;
				this.value = 30000;
				this.toolTip = "增加4%远程伤害";
			}
			else if (this.type == 154)
			{
				this.name = "Bone";
				this.CName = "骨头";
				this.maxStack = 99;
				this.consumable = true;
				this.width = 12;
				this.height = 14;
				this.value = 50;
				this.useAnimation = 12;
				this.useTime = 12;
				this.useStyle = 1;
				this.useSound = 1;
				this.shootSpeed = 8f;
				this.noUseGraphic = true;
				this.damage = 22;
				this.knockBack = 4f;
				this.shoot = 21;
				this.ranged = true;
			}
			else if (this.type == 155)
			{
				this.autoReuse = true;
				this.useTurn = true;
				this.name = "Muramasa";
				this.CName = "妖刀村正";
				this.useStyle = 1;
				this.useAnimation = 20;
				this.width = 40;
				this.height = 40;
				this.damage = 18;
				this.scale = 1.1f;
				this.useSound = 1;
				this.rare = 2;
				this.value = 27000;
				this.knockBack = 1f;
				this.melee = true;
			}
			else if (this.type == 156)
			{
				this.name = "Cobalt Shield";
				this.CName = "钴蓝护盾";
				this.width = 24;
				this.height = 28;
				this.rare = 2;
				this.value = 27000;
				this.accessory = true;
				this.defense = 1;
				this.toolTip = "使佩戴者免疫击退效果";
			}
			else if (this.type == 157)
			{
				this.mana = 7;
				this.autoReuse = true;
				this.name = "Aqua Scepter";
				this.CName = "海蓝魔杖";
				this.useStyle = 5;
				this.useAnimation = 16;
				this.useTime = 8;
				this.knockBack = 5f;
				this.width = 38;
				this.height = 10;
				this.damage = 14;
				this.scale = 1f;
				this.shoot = 22;
				this.shootSpeed = 11f;
				this.useSound = 13;
				this.rare = 2;
				this.value = 27000;
				this.toolTip = "向前方喷射魔法水柱";
				this.magic = true;
			}
			else if (this.type == 158)
			{
				this.name = "Lucky Horseshoe";
				this.CName = "幸运马掌";
				this.width = 20;
				this.height = 22;
				this.rare = 1;
				this.value = 27000;
				this.accessory = true;
				this.toolTip = "使佩戴者免疫掉落伤害";
			}
			else if (this.type == 159)
			{
				this.name = "Shiny Red Balloon";
				this.CName = "闪亮的红气球";
				this.width = 14;
				this.height = 28;
				this.rare = 1;
				this.value = 27000;
				this.accessory = true;
				this.toolTip = "使佩戴者增加跳跃高度";
			}
			else if (this.type == 160)
			{
				this.autoReuse = true;
				this.name = "Harpoon";
				this.CName = "鱼叉链枪";
				this.useStyle = 5;
				this.useAnimation = 30;
				this.useTime = 30;
				this.knockBack = 6f;
				this.width = 30;
				this.height = 10;
				this.damage = 25;
				this.scale = 1.1f;
				this.shoot = 23;
				this.shootSpeed = 11f;
				this.useSound = 10;
				this.rare = 2;
				this.value = 27000;
				this.ranged = true;
			}
			else if (this.type == 161)
			{
				this.useStyle = 1;
				this.name = "Spiky Ball";
				this.CName = "尖钉球";
				this.shootSpeed = 5f;
				this.shoot = 24;
				this.knockBack = 1f;
				this.damage = 15;
				this.width = 10;
				this.height = 10;
				this.maxStack = 250;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 80;
				this.ranged = true;
			}
			else if (this.type == 162)
			{
				this.name = "Ball O' Hurt";
				this.CName = "链球";
				this.useStyle = 5;
				this.useAnimation = 45;
				this.useTime = 45;
				this.knockBack = 6.5f;
				this.width = 30;
				this.height = 10;
				this.damage = 15;
				this.scale = 1.1f;
				this.noUseGraphic = true;
				this.shoot = 25;
				this.shootSpeed = 12f;
				this.useSound = 1;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
				this.channel = true;
				this.noMelee = true;
			}
			else if (this.type == 163)
			{
				this.name = "Blue Moon";
				this.CName = "蓝月";
				this.useStyle = 5;
				this.useAnimation = 45;
				this.useTime = 45;
				this.knockBack = 7f;
				this.width = 30;
				this.height = 10;
				this.damage = 23;
				this.scale = 1.1f;
				this.noUseGraphic = true;
				this.shoot = 26;
				this.shootSpeed = 12f;
				this.useSound = 1;
				this.rare = 2;
				this.value = 27000;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 164)
			{
				this.autoReuse = false;
				this.useStyle = 5;
				this.useAnimation = 12;
				this.useTime = 12;
				this.name = "Handgun";
				this.CName = "手枪";
				this.width = 24;
				this.height = 24;
				this.shoot = 14;
				this.knockBack = 3f;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 14;
				this.shootSpeed = 10f;
				this.noMelee = true;
				this.value = 50000;
				this.scale = 0.75f;
				this.rare = 2;
				this.ranged = true;
			}
			else if (this.type == 165)
			{
				this.autoReuse = true;
				this.rare = 2;
				this.mana = 14;
				this.useSound = 21;
				this.name = "Water Bolt";
				this.CName = "水箭魔法书";
				this.useStyle = 5;
				this.damage = 17;
				this.useAnimation = 17;
				this.useTime = 17;
				this.width = 24;
				this.height = 28;
				this.shoot = 27;
				this.scale = 0.9f;
				this.shootSpeed = 4.5f;
				this.knockBack = 5f;
				this.toolTip = "施放一枚魔法水球";
				this.magic = true;
				this.value = 50000;
			}
			else if (this.type == 166)
			{
				this.useStyle = 1;
				this.name = "Bomb";
				this.CName = "MK-2炸弹";
				this.shootSpeed = 5f;
				this.shoot = 28;
				this.width = 20;
				this.height = 20;
				this.maxStack = 50;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 25;
				this.useTime = 25;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 500;
				this.damage = 0;
				this.toolTip = "只有延时引信的投掷武器，小范围破坏砖块";
			}
			else if (this.type == 167)
			{
				this.useStyle = 1;
				this.name = "Dynamite";
				this.CName = "矿用雷管";
				this.shootSpeed = 4f;
				this.shoot = 29;
				this.width = 8;
				this.height = 28;
				this.maxStack = 5;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 40;
				this.useTime = 40;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 5000;
				this.rare = 1;
				this.toolTip = "大范围破坏砖块的强力炸药，小心使用";
			}
			else if (this.type == 168)
			{
				this.useStyle = 5;
				this.name = "Grenade";
				this.CName = "M-61手雷";
				this.shootSpeed = 5.5f;
				this.shoot = 30;
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 45;
				this.useTime = 45;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 400;
				this.damage = 60;
				this.knockBack = 8f;
				this.toolTip = "装有碰触和延时引信的便携式手雷";
				this.ranged = true;
			}
			else if (this.type == 169)
			{
				this.name = "Sand Block";
				this.CName = "沙块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 53;
				this.width = 12;
				this.height = 12;
				this.ammo = 42;
			}
			else if (this.type == 170)
			{
				this.name = "Glass";
				this.CName = "玻璃";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 54;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 171)
			{
				this.name = "Sign";
				this.CName = "标牌";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 55;
				this.width = 28;
				this.height = 28;
			}
			else if (this.type == 172)
			{
				this.name = "Ash Block";
				this.CName = "灰烬块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 57;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 173)
			{
				this.name = "Obsidian";
				this.CName = "黑曜石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 56;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 174)
			{
				this.name = "Hellstone";
				this.CName = "狱岩石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 58;
				this.width = 12;
				this.height = 12;
				this.rare = 2;
			}
			else if (this.type == 175)
			{
				this.name = "Hellstone Bar";
				this.CName = "狱岩锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.rare = 2;
				this.toolTip = "好烫！";
				this.value = 20000;
			}
			else if (this.type == 176)
			{
				this.name = "Mud Block";
				this.CName = "淤泥块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 59;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 181)
			{
				this.name = "Amethyst";
				this.CName = "紫水晶";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 1875;
			}
			else if (this.type == 180)
			{
				this.name = "Topaz";
				this.CName = "黄晶玉";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 3750;
			}
			else if (this.type == 177)
			{
				this.name = "Sapphire";
				this.CName = "蓝宝石";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 5625;
			}
			else if (this.type == 179)
			{
				this.name = "Emerald";
				this.CName = "祖母绿";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 7500;
			}
			else if (this.type == 178)
			{
				this.name = "Ruby";
				this.CName = "红宝石";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 11250;
			}
			else if (this.type == 182)
			{
				this.name = "Diamond";
				this.CName = "钻石";
				this.maxStack = 99;
				this.alpha = 50;
				this.width = 10;
				this.height = 14;
				this.value = 15000;
			}
			else if (this.type == 183)
			{
				this.name = "Glowing Mushroom";
				this.CName = "夜光蘑菇";
				this.useStyle = 2;
				this.useSound = 2;
				this.useTurn = false;
				this.useAnimation = 17;
				this.useTime = 17;
				this.width = 16;
				this.height = 18;
				this.healLife = 25;
				this.maxStack = 99;
				this.consumable = true;
				this.potion = true;
				this.value = 50;
			}
			else if (this.type == 184)
			{
				this.name = "Star";
				this.CName = "魔力星";
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 185)
			{
				this.noUseGraphic = true;
				this.damage = 0;
				this.knockBack = 7f;
				this.useStyle = 5;
				this.name = "Ivy Whip";
				this.CName = "常春藤鞭";
				this.shootSpeed = 13f;
				this.shoot = 32;
				this.width = 18;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 3;
				this.noMelee = true;
				this.value = 20000;
			}
			else if (this.type == 186)
			{
				this.name = "Breathing Reed";
				this.CName = "芦苇杆";
				this.width = 44;
				this.height = 44;
				this.rare = 1;
				this.value = 10000;
				this.holdStyle = 2;
				this.toolTip = "'忍者水遁时使用的道具'";
			}
			else if (this.type == 187)
			{
				this.name = "Flipper";
				this.CName = "脚蹼";
				this.width = 28;
				this.height = 28;
				this.rare = 1;
				this.value = 10000;
				this.accessory = true;
				this.toolTip = "使佩戴者能在水中游动";
			}
			else if (this.type == 188)
			{
				this.name = "Healing Potion";
				this.CName = "治疗药水";
				this.useSound = 3;
				this.healLife = 100;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.rare = 1;
				this.potion = true;
				this.value = 1000;
			}
			else if (this.type == 189)
			{
				this.name = "Mana Potion";
				this.CName = "魔力药水";
				this.useSound = 3;
				this.healMana = 100;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 50;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.rare = 1;
				this.value = 250;
			}
			else if (this.type == 190)
			{
				this.name = "Blade of Grass";
				this.CName = "草薙";
				this.useStyle = 1;
				this.useAnimation = 30;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 28;
				this.scale = 1.4f;
				this.useSound = 1;
				this.rare = 3;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 191)
			{
				this.noMelee = true;
				this.useStyle = 1;
				this.name = "Thorn Chakram";
				this.CName = "荆棘旋刃";
				this.shootSpeed = 11f;
				this.shoot = 33;
				this.damage = 25;
				this.knockBack = 8f;
				this.width = 14;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.rare = 3;
				this.value = 50000;
				this.melee = true;
			}
			else if (this.type == 192)
			{
				this.name = "Obsidian Brick";
				this.CName = "黑曜石砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 75;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 193)
			{
				this.name = "Obsidian Skull";
				this.CName = "黑曜石头颅";
				this.width = 20;
				this.height = 22;
				this.rare = 2;
				this.value = 27000;
				this.accessory = true;
				this.defense = 1;
				this.toolTip = "使佩戴者免疫高温砖块烫伤";
			}
			else if (this.type == 194)
			{
				this.name = "Mushroom Grass Seeds";
				this.CName = "夜光蘑菇孢子";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 70;
				this.width = 14;
				this.height = 14;
				this.value = 150;
			}
			else if (this.type == 195)
			{
				this.name = "Jungle Grass Seeds";
				this.CName = "丛林草种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 60;
				this.width = 14;
				this.height = 14;
				this.value = 150;
			}
			else if (this.type == 196)
			{
				this.name = "Wooden Hammer";
				this.CName = "木槌";
				this.autoReuse = true;
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 37;
				this.useTime = 25;
				this.hammer = 25;
				this.width = 24;
				this.height = 28;
				this.damage = 2;
				this.knockBack = 5.5f;
				this.scale = 1.2f;
				this.useSound = 1;
				this.tileBoost = -1;
				this.value = 50;
				this.melee = true;
			}
			else if (this.type == 197)
			{
				this.autoReuse = true;
				this.useStyle = 5;
				this.useAnimation = 10;
				this.useTime = 10;
				this.name = "Star Cannon";
				this.CName = "星辰炮";
				this.width = 50;
				this.height = 18;
				this.shoot = 12;
				this.useAmmo = 15;
				this.useSound = 9;
				this.damage = 60;
				this.shootSpeed = 14f;
				this.noMelee = true;
				this.value = 500000;
				this.rare = 2;
				this.toolTip = "用落星当做弹药的大口径火炮";
				this.ranged = true;
			}
			else if (this.type == 198)
			{
				this.name = "Blue Phaseblade";
				this.CName = "蓝相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 199)
			{
				this.name = "Red Phaseblade";
				this.CName = "红相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 200)
			{
				this.name = "Green Phaseblade";
				this.CName = "绿相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 201)
			{
				this.name = "Purple Phaseblade";
				this.CName = "紫相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 202)
			{
				this.name = "White Phaseblade";
				this.CName = "白相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 203)
			{
				this.name = "Yellow Phaseblade";
				this.CName = "黄相位剑";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.knockBack = 3f;
				this.width = 40;
				this.height = 40;
				this.damage = 21;
				this.scale = 1f;
				this.useSound = 15;
				this.rare = 1;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 204)
			{
				this.name = "Meteor Hamaxe";
				this.CName = "陨星锤斧";
				this.useTurn = true;
				this.autoReuse = true;
				this.useStyle = 1;
				this.useAnimation = 30;
				this.useTime = 16;
				this.hammer = 60;
				this.axe = 20;
				this.width = 24;
				this.height = 28;
				this.damage = 20;
				this.knockBack = 7f;
				this.scale = 1.2f;
				this.useSound = 1;
				this.rare = 1;
				this.value = 15000;
				this.melee = true;
			}
			else if (this.type == 205)
			{
				this.name = "Empty Bucket";
				this.CName = "空桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.width = 20;
				this.height = 20;
				this.headSlot = 13;
				this.defense = 1;
			}
			else if (this.type == 206)
			{
				this.name = "Water Bucket";
				this.CName = "装满水的桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.width = 20;
				this.height = 20;
			}
			else if (this.type == 207)
			{
				this.name = "Lava Bucket";
				this.CName = "装满岩浆的桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.width = 20;
				this.height = 20;
			}
			else if (this.type == 208)
			{
				this.name = "Jungle Rose";
				this.CName = "丛林玫瑰";
				this.width = 20;
				this.height = 20;
				this.value = 100;
				this.headSlot = 23;
				this.toolTip = "'赠人玫瑰，手有余香'";
				this.vanity = true;
			}
			else if (this.type == 209)
			{
				this.name = "Stinger";
				this.CName = "毒刺";
				this.width = 16;
				this.height = 18;
				this.maxStack = 99;
				this.value = 200;
			}
			else if (this.type == 210)
			{
				this.name = "Vine";
				this.CName = "花藤";
				this.width = 14;
				this.height = 20;
				this.maxStack = 99;
				this.value = 1000;
			}
			else if (this.type == 211)
			{
				this.name = "Feral Claws";
				this.CName = "狂爪坠饰";
				this.width = 20;
				this.height = 20;
				this.accessory = true;
				this.rare = 3;
				this.toolTip = "使佩戴者增加12%近战攻速";
				this.value = 50000;
			}
			else if (this.type == 212)
			{
				this.name = "Anklet of the Wind";
				this.CName = "疾风脚镯";
				this.width = 20;
				this.height = 20;
				this.accessory = true;
				this.rare = 3;
				this.toolTip = "使佩戴者增加10%移动速度";
				this.value = 50000;
			}
			else if (this.type == 213)
			{
				this.name = "Staff of Regrowth";
				this.CName = "绿化法杖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 25;
				this.useTime = 13;
				this.autoReuse = true;
				this.width = 24;
				this.height = 28;
				this.damage = 7;
				this.createTile = 2;
				this.scale = 1.2f;
				this.useSound = 1;
				this.knockBack = 3f;
				this.rare = 3;
				this.value = 2000;
				this.toolTip = "可以在泥土上创造绿色植被";
				this.melee = true;
			}
			else if (this.type == 214)
			{
				this.name = "Hellstone Brick";
				this.CName = "狱岩石砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 76;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 215)
			{
				this.name = "Whoopie Cushion";
				this.CName = "整人坐垫";
				this.width = 18;
				this.height = 18;
				this.useTurn = true;
				this.useTime = 30;
				this.useAnimation = 30;
				this.noUseGraphic = true;
				this.useStyle = 10;
				this.useSound = 16;
				this.rare = 2;
				this.toolTip = "'别太过份'";
				this.value = 100;
			}
			else if (this.type == 216)
			{
				this.name = "Shackle";
				this.CName = "脚镣";
				this.width = 20;
				this.height = 20;
				this.rare = 1;
				this.value = 1500;
				this.accessory = true;
				this.defense = 1;
			}
			else if (this.type == 217)
			{
				this.name = "Molten Hamaxe";
				this.CName = "熔岩锤斧";
				this.useTurn = true;
				this.autoReuse = true;
				this.useStyle = 1;
				this.useAnimation = 27;
				this.useTime = 14;
				this.hammer = 70;
				this.axe = 30;
				this.width = 24;
				this.height = 28;
				this.damage = 20;
				this.knockBack = 7f;
				this.scale = 1.4f;
				this.useSound = 1;
				this.rare = 3;
				this.value = 15000;
				this.melee = true;
			}
			else if (this.type == 218)
			{
				this.mana = 16;
				this.channel = true;
				this.damage = 34;
				this.useStyle = 1;
				this.name = "Flamelash";
				this.CName = "烈焰火鞭";
				this.shootSpeed = 6f;
				this.shoot = 34;
				this.width = 26;
				this.height = 28;
				this.useSound = 20;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 3;
				this.noMelee = true;
				this.knockBack = 6.5f;
				this.toolTip = "施放一枚跟随鼠标的魔法火球";
				this.value = 10000;
				this.magic = true;
			}
			else if (this.type == 219)
			{
				this.autoReuse = false;
				this.useStyle = 5;
				this.useAnimation = 11;
				this.useTime = 11;
				this.name = "Phoenix Blaster";
				this.CName = "凤凰MAG-44";
				this.width = 24;
				this.height = 22;
				this.shoot = 14;
				this.knockBack = 2f;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 23;
				this.shootSpeed = 13f;
				this.noMelee = true;
				this.value = 50000;
				this.scale = 0.75f;
				this.rare = 3;
				this.ranged = true;
			}
			else if (this.type == 220)
			{
				this.name = "Sunfury";
				this.CName = "阳炎之怒";
				this.noMelee = true;
				this.useStyle = 5;
				this.useAnimation = 45;
				this.useTime = 45;
				this.knockBack = 7f;
				this.width = 30;
				this.height = 10;
				this.damage = 33;
				this.scale = 1.1f;
				this.noUseGraphic = true;
				this.shoot = 35;
				this.shootSpeed = 12f;
				this.useSound = 1;
				this.rare = 3;
				this.value = 27000;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 221)
			{
				this.name = "Hellforge";
				this.CName = "地狱熔炉";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 77;
				this.width = 26;
				this.height = 24;
				this.value = 3000;
			}
			else if (this.type == 222)
			{
				this.name = "Clay Pot";
				this.CName = "粘土花盆";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 78;
				this.width = 14;
				this.height = 14;
				this.value = 100;
				this.toolTip = "园艺用";
			}
			else if (this.type == 223)
			{
				this.name = "Nature's Gift";
				this.CName = "自然的恩赐";
				this.width = 20;
				this.height = 22;
				this.rare = 3;
				this.value = 27000;
				this.accessory = true;
				this.toolTip = "使佩戴者减少6%魔力消耗";
			}
			else if (this.type == 224)
			{
				this.name = "Bed";
				this.CName = "床";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 79;
				this.width = 28;
				this.height = 20;
				this.value = 2000;
			}
			else if (this.type == 225)
			{
				this.name = "Silk";
				this.CName = "丝绸";
				this.maxStack = 99;
				this.width = 22;
				this.height = 22;
				this.value = 1000;
			}
			else if (this.type == 226)
			{
				this.name = "Lesser Restoration Potion";
				this.CName = "弱效回复药水";
				this.useSound = 3;
				this.healMana = 50;
				this.healLife = 50;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 20;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.potion = true;
				this.value = 2000;
			}
			else if (this.type == 227)
			{
				this.name = "Restoration Potion";
				this.CName = "回复药水";
				this.useSound = 3;
				this.healMana = 100;
				this.healLife = 100;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 20;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.potion = true;
				this.value = 4000;
			}
			else if (this.type == 228)
			{
				this.name = "Jungle Hat";
				this.CName = "丛林帽";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.headSlot = 8;
				this.rare = 3;
				this.value = 45000;
				this.toolTip = "增加20点最大法力值";
				this.toolTip2 = "增加3%魔法暴击率";
			}
			else if (this.type == 229)
			{
				this.name = "Jungle Shirt";
				this.CName = "丛林衣";
				this.width = 18;
				this.height = 18;
				this.defense = 5;
				this.bodySlot = 8;
				this.rare = 3;
				this.value = 30000;
				this.toolTip = "增加20点最大法力值";
				this.toolTip2 = "增加3%魔法暴击率";
			}
			else if (this.type == 230)
			{
				this.name = "Jungle Pants";
				this.CName = "丛林裤";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.legSlot = 8;
				this.rare = 3;
				this.value = 30000;
				this.toolTip = "增加20点最大法力值";
				this.toolTip2 = "增加3%魔法暴击率";
			}
			else if (this.type == 231)
			{
				this.name = "Molten Helmet";
				this.CName = "熔岩头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 8;
				this.headSlot = 9;
				this.rare = 3;
				this.value = 45000;
			}
			else if (this.type == 232)
			{
				this.name = "Molten Breastplate";
				this.CName = "熔岩胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 9;
				this.bodySlot = 9;
				this.rare = 3;
				this.value = 30000;
			}
			else if (this.type == 233)
			{
				this.name = "Molten Greaves";
				this.CName = "熔岩护胫";
				this.width = 18;
				this.height = 18;
				this.defense = 8;
				this.legSlot = 9;
				this.rare = 3;
				this.value = 30000;
			}
			else if (this.type == 234)
			{
				this.name = "Meteor Shot";
				this.CName = "陨星螺旋弹";
				this.shootSpeed = 3f;
				this.shoot = 36;
				this.damage = 9;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 14;
				this.knockBack = 1f;
				this.value = 8;
				this.rare = 1;
				this.ranged = true;
			}
			else if (this.type == 235)
			{
				this.useStyle = 1;
				this.name = "Sticky Bomb";
				this.CName = "黏性炸弹";
				this.shootSpeed = 5f;
				this.shoot = 37;
				this.width = 20;
				this.height = 20;
				this.maxStack = 50;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 25;
				this.useTime = 25;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 500;
				this.damage = 0;
				this.toolTip = "'黏在手上就麻烦了'";
			}
			else if (this.type == 236)
			{
				this.name = "Black Lens";
				this.CName = "黑色晶状体";
				this.width = 12;
				this.height = 20;
				this.maxStack = 99;
				this.value = 5000;
			}
			else if (this.type == 237)
			{
				this.name = "Sunglasses";
				this.CName = "墨镜";
				this.width = 28;
				this.height = 12;
				this.headSlot = 12;
				this.rare = 2;
				this.value = 10000;
				this.toolTip = "'可以用来装酷'";
				this.vanity = true;
			}
			else if (this.type == 238)
			{
				this.name = "Wizard Hat";
				this.CName = "巫师帽";
				this.width = 28;
				this.height = 20;
				this.headSlot = 14;
				this.rare = 2;
				this.value = 10000;
				this.defense = 2;
				this.toolTip = "增加15%魔法伤害";
			}
			else if (this.type == 239)
			{
				this.name = "Top Hat";
				this.CName = "礼服帽";
				this.width = 18;
				this.height = 18;
				this.headSlot = 15;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 240)
			{
				this.name = "Tuxedo Shirt";
				this.CName = "黑礼服";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 10;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 241)
			{
				this.name = "Tuxedo Pants";
				this.CName = "礼服裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 10;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 242)
			{
				this.name = "Summer Hat";
				this.CName = "海贼的草帽";
				this.width = 18;
				this.height = 18;
				this.headSlot = 16;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 243)
			{
				this.name = "Bunny Hood";
				this.CName = "兔子兜帽";
				this.width = 18;
				this.height = 18;
				this.headSlot = 17;
				this.value = 20000;
				this.vanity = true;
			}
			else if (this.type == 244)
			{
				this.name = "Plumber's Hat";
				this.CName = "管道工帽子";
				this.width = 18;
				this.height = 12;
				this.headSlot = 18;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 245)
			{
				this.name = "Plumber's Shirt";
				this.CName = "管道工上衣";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 11;
				this.value = 250000;
				this.vanity = true;
			}
			else if (this.type == 246)
			{
				this.name = "Plumber's Pants";
				this.CName = "管道工背带裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 11;
				this.value = 250000;
				this.vanity = true;
			}
			else if (this.type == 247)
			{
				this.name = "Hero's Hat";
				this.CName = "林克的兜帽";
				this.width = 18;
				this.height = 12;
				this.headSlot = 19;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 248)
			{
				this.name = "Hero's Shirt";
				this.CName = "林克的上衣";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 12;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 249)
			{
				this.name = "Hero's Pants";
				this.CName = "林克的裤子";
				this.width = 18;
				this.height = 18;
				this.legSlot = 12;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 250)
			{
				this.name = "Fish Bowl";
				this.CName = "鱼缸";
				this.width = 18;
				this.height = 18;
				this.headSlot = 20;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 251)
			{
				this.name = "Archaeologist's Hat";
				this.CName = "琼斯的考古帽";
				this.width = 18;
				this.height = 12;
				this.headSlot = 21;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 252)
			{
				this.name = "Archaeologist's Jacket";
				this.CName = "琼斯的考古上衣";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 13;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 253)
			{
				this.name = "Archaeologist's Pants";
				this.CName = "琼斯的考古长裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 13;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 254)
			{
				this.name = "Black Dye";
				this.CName = "黑色染料";
				this.maxStack = 99;
				this.width = 12;
				this.height = 20;
				this.value = 10000;
			}
			else if (this.type == 255)
			{
				this.name = "Green Dye";
				this.CName = "绿色染料";
				this.maxStack = 99;
				this.width = 12;
				this.height = 20;
				this.value = 2000;
			}
			else if (this.type == 256)
			{
				this.name = "Ninja Hood";
				this.CName = "忍者面罩";
				this.width = 18;
				this.height = 12;
				this.headSlot = 22;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 257)
			{
				this.name = "Ninja Shirt";
				this.CName = "忍者夜行衣";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 14;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 258)
			{
				this.name = "Ninja Pants";
				this.CName = "忍者夜行裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 14;
				this.value = 5000;
				this.vanity = true;
			}
			else if (this.type == 259)
			{
				this.name = "Leather";
				this.CName = "毛皮";
				this.width = 18;
				this.height = 20;
				this.maxStack = 99;
				this.value = 50;
			}
			else if (this.type == 260)
			{
				this.name = "Red Hat";
				this.CName = "小红帽";
				this.width = 18;
				this.height = 14;
				this.headSlot = 24;
				this.value = 1000;
				this.vanity = true;
			}
			else if (this.type == 261)
			{
				this.name = "Goldfish";
				this.CName = "金鱼";
				this.useStyle = 2;
				this.useSound = 2;
				this.useTurn = false;
				this.useAnimation = 17;
				this.useTime = 17;
				this.width = 20;
				this.height = 10;
				this.maxStack = 99;
				this.healLife = 20;
				this.consumable = true;
				this.value = 1000;
				this.potion = true;
				this.toolTip = "'再看我，就把你吃掉'";
			}
			else if (this.type == 262)
			{
				this.name = "Robe";
				this.CName = "长袍";
				this.width = 18;
				this.height = 14;
				this.bodySlot = 15;
				this.value = 2000;
				this.vanity = true;
			}
			else if (this.type == 263)
			{
				this.name = "Robot Hat";
				this.CName = "库特的机械帽";
				this.width = 18;
				this.height = 18;
				this.headSlot = 25;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 264)
			{
				this.name = "Gold Crown";
				this.CName = "金冠";
				this.width = 18;
				this.height = 18;
				this.headSlot = 26;
				this.value = 10000;
				this.vanity = true;
			}
			else if (this.type == 265)
			{
				this.name = "Hellfire Arrow";
				this.CName = "狱炎箭";
				this.shootSpeed = 6.5f;
				this.shoot = 41;
				this.damage = 10;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 8f;
				this.value = 100;
				this.rare = 2;
				this.ranged = true;
			}
			else if (this.type == 266)
			{
				this.useStyle = 5;
				this.useAnimation = 16;
				this.useTime = 16;
				this.autoReuse = true;
				this.name = "Sandgun";
				this.CName = "沙枪";
				this.width = 40;
				this.height = 20;
				this.shoot = 42;
				this.useAmmo = 42;
				this.useSound = 11;
				this.damage = 30;
				this.shootSpeed = 12f;
				this.noMelee = true;
				this.knockBack = 5f;
				this.value = 10000;
				this.rare = 2;
				this.toolTip = "'并不是所有人都会用它'";
				this.ranged = true;
			}
			else if (this.type == 267)
			{
				this.accessory = true;
				this.name = "Guide Voodoo Doll";
				this.CName = "向导巫毒玩偶";
				this.width = 14;
				this.height = 26;
				this.value = 1000;
				this.toolTip = "用来完成某种黑暗仪式的道具";
				this.toolTip2 = "'玩偶的头上有三个弹孔'";
			}
			else if (this.type == 268)
			{
				this.headSlot = 27;
				this.defense = 2;
				this.name = "Diving Helmet";
				this.CName = "潜水头盔";
				this.width = 20;
				this.height = 20;
				this.value = 1000;
				this.rare = 2;
				this.toolTip = "减缓在水下时氧气消耗速度";
			}
			else if (this.type == 269)
			{
				this.name = "Familiar Shirt";
				this.CName = "眼熟的衣服";
				this.bodySlot = 0;
				this.width = 20;
				this.height = 20;
				this.value = 10000;
				this.color = Main.player[Main.myPlayer].shirtColor;
			}
			else if (this.type == 270)
			{
				this.name = "Familiar Pants";
				this.CName = "眼熟的裤子";
				this.legSlot = 0;
				this.width = 20;
				this.height = 20;
				this.value = 10000;
				this.color = Main.player[Main.myPlayer].pantsColor;
			}
			else if (this.type == 271)
			{
				this.name = "Familiar Wig";
				this.CName = "眼熟的假发";
				this.headSlot = 0;
				this.width = 20;
				this.height = 20;
				this.value = 10000;
				this.color = Main.player[Main.myPlayer].hairColor;
			}
			else if (this.type == 272)
			{
				this.mana = 14;
				this.damage = 35;
				this.useStyle = 5;
				this.name = "Demon Scythe";
				this.CName = "恶魔之镰";
				this.shootSpeed = 0.2f;
				this.shoot = 45;
				this.width = 26;
				this.height = 28;
				this.useSound = 8;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 3;
				this.noMelee = true;
				this.knockBack = 5f;
				this.scale = 0.9f;
				this.toolTip = "召唤一把不断旋转的恶魔镰刀";
				this.value = 10000;
				this.magic = true;
			}
			else if (this.type == 273)
			{
				this.name = "Night's Edge";
				this.CName = "永夜之刃";
				this.useStyle = 1;
				this.useAnimation = 27;
				this.useTime = 27;
				this.knockBack = 4.5f;
				this.width = 40;
				this.height = 40;
				this.damage = 42;
				this.scale = 1.15f;
				this.useSound = 1;
				this.rare = 3;
				this.value = 27000;
				this.melee = true;
			}
			else if (this.type == 274)
			{
				this.name = "Dark Lance";
				this.CName = "暗黑长矛";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 25;
				this.shootSpeed = 5f;
				this.knockBack = 4f;
				this.width = 40;
				this.height = 40;
				this.damage = 27;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 46;
				this.rare = 3;
				this.value = 27000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 275)
			{
				this.name = "Coral";
				this.CName = "珊瑚";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 81;
				this.width = 20;
				this.height = 22;
				this.value = 400;
			}
			else if (this.type == 276)
			{
				this.name = "Cactus";
				this.CName = "仙人掌";
				this.maxStack = 250;
				this.width = 12;
				this.height = 12;
				this.value = 10;
			}
			else if (this.type == 277)
			{
				this.name = "Trident";
				this.CName = "三叉戟";
				this.useStyle = 5;
				this.useAnimation = 31;
				this.useTime = 31;
				this.shootSpeed = 4f;
				this.knockBack = 5f;
				this.width = 40;
				this.height = 40;
				this.damage = 10;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 47;
				this.rare = 1;
				this.value = 10000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 278)
			{
				this.name = "Silver Bullet";
				this.CName = "银弹";
				this.shootSpeed = 4.5f;
				this.shoot = 14;
				this.damage = 9;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 14;
				this.knockBack = 3f;
				this.value = 15;
				this.ranged = true;
			}
			else if (this.type == 279)
			{
				this.useStyle = 1;
				this.name = "Throwing Knife";
				this.CName = "飞刀";
				this.shootSpeed = 10f;
				this.shoot = 48;
				this.damage = 12;
				this.width = 18;
				this.height = 20;
				this.maxStack = 250;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 50;
				this.knockBack = 2f;
				this.ranged = true;
			}
			else if (this.type == 280)
			{
				this.name = "Spear";
				this.CName = "长矛";
				this.useStyle = 5;
				this.useAnimation = 31;
				this.useTime = 31;
				this.shootSpeed = 3.7f;
				this.knockBack = 6.5f;
				this.width = 32;
				this.height = 32;
				this.damage = 8;
				this.scale = 1f;
				this.useSound = 1;
				this.shoot = 49;
				this.value = 1000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 281)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.name = "Blowpipe";
				this.CName = "吹管";
				this.width = 38;
				this.height = 6;
				this.shoot = 10;
				this.useAmmo = 51;
				this.useSound = 5;
				this.damage = 9;
				this.shootSpeed = 11f;
				this.noMelee = true;
				this.value = 10000;
				this.knockBack = 4f;
				this.useAmmo = 51;
				this.toolTip = "携带者能够收集用作弹药的种子";
				this.ranged = true;
			}
			else if (this.type == 282)
			{
				this.useStyle = 1;
				this.name = "Glowstick";
				this.CName = "荧光棒";
				this.shootSpeed = 6f;
				this.shoot = 50;
				this.width = 12;
				this.height = 12;
				this.maxStack = 99;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noMelee = true;
				this.value = 10;
				this.holdStyle = 1;
				this.toolTip = "水下作业用";
			}
			else if (this.type == 283)
			{
				this.name = "Seed";
				this.CName = "种子";
				this.shoot = 51;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.ammo = 51;
				this.toolTip = "吹管的弹药";
			}
			else if (this.type == 284)
			{
				this.noMelee = true;
				this.useStyle = 1;
				this.name = "Wooden Boomerang";
				this.CName = "木制回力镖";
				this.shootSpeed = 6.5f;
				this.shoot = 52;
				this.damage = 7;
				this.knockBack = 5f;
				this.width = 14;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 16;
				this.useTime = 16;
				this.noUseGraphic = true;
				this.value = 5000;
				this.melee = true;
			}
			else if (this.type == 285)
			{
				this.name = "Aglet";
				this.CName = "敏捷扣链";
				this.width = 24;
				this.height = 8;
				this.accessory = true;
				this.toolTip = "使佩戴者增加5%移动速度";
				this.value = 5000;
			}
			else if (this.type == 286)
			{
				this.useStyle = 1;
				this.name = "Sticky Glowstick";
				this.CName = "黏性荧光棒";
				this.shootSpeed = 6f;
				this.shoot = 53;
				this.width = 12;
				this.height = 12;
				this.maxStack = 99;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noMelee = true;
				this.value = 20;
				this.holdStyle = 1;
			}
			else if (this.type == 287)
			{
				this.useStyle = 1;
				this.name = "Poisoned Knife";
				this.CName = "剧毒飞刀";
				this.shootSpeed = 11f;
				this.shoot = 54;
				this.damage = 13;
				this.width = 18;
				this.height = 20;
				this.maxStack = 250;
				this.consumable = true;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 60;
				this.knockBack = 2f;
				this.ranged = true;
			}
			else if (this.type == 288)
			{
				this.name = "Obsidian Skin Potion";
				this.CName = "黑曜石皮肤药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 1;
				this.buffTime = 14400;
				this.toolTip = "免疫岩浆高温";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 289)
			{
				this.name = "Regeneration Potion";
				this.CName = "再生药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 2;
				this.buffTime = 18000;
				this.toolTip = "加速生命恢复";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 290)
			{
				this.name = "Swiftness Potion";
				this.CName = "敏捷药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 3;
				this.buffTime = 14400;
				this.toolTip = "增加25%移动速度";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 291)
			{
				this.name = "Gills Potion";
				this.CName = "鱼鳃药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 4;
				this.buffTime = 7200;
				this.toolTip = "能像鱼一样呼吸";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 292)
			{
				this.name = "Ironskin Potion";
				this.CName = "铁皮药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 5;
				this.buffTime = 18000;
				this.toolTip = "增加8点防御";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 293)
			{
				this.name = "Mana Regeneration Potion";
				this.CName = "魔力恢复药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 6;
				this.buffTime = 7200;
				this.toolTip = "加速魔力恢复";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 294)
			{
				this.name = "Magic Power Potion";
				this.CName = "魔能药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 7;
				this.buffTime = 7200;
				this.toolTip = "增加20%魔法伤害";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 295)
			{
				this.name = "Featherfall Potion";
				this.CName = "羽落药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 8;
				this.buffTime = 18000;
				this.toolTip = "减缓掉落速度";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 296)
			{
				this.name = "Spelunker Potion";
				this.CName = "勘探药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 9;
				this.buffTime = 18000;
				this.toolTip = "显示周围宝藏和矿物位置";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 297)
			{
				this.name = "Invisibility Potion";
				this.CName = "隐身药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 10;
				this.buffTime = 7200;
				this.toolTip = "使身体变得透明，对盔甲无效";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 298)
			{
				this.name = "Shine Potion";
				this.CName = "光芒药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 11;
				this.buffTime = 18000;
				this.toolTip = "身体会被明亮的光环笼罩";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 299)
			{
				this.name = "Night Owl Potion";
				this.CName = "夜神药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 12;
				this.buffTime = 14400;
				this.toolTip = "增加夜视能力";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 300)
			{
				this.name = "Battle Potion";
				this.CName = "战争药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 13;
				this.buffTime = 25200;
				this.toolTip = "增加怪物刷新速率";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 301)
			{
				this.name = "Thorns Potion";
				this.CName = "荆棘药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 14;
				this.buffTime = 7200;
				this.toolTip = "反弹所受到的伤害";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 302)
			{
				this.name = "Water Walking Potion";
				this.CName = "水上行走药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 15;
				this.buffTime = 18000;
				this.toolTip = "能在液体表面行走";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 303)
			{
				this.name = "Archery Potion";
				this.CName = "箭术药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 16;
				this.buffTime = 14400;
				this.toolTip = "增加20%箭矢伤害和飞行速度";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 304)
			{
				this.name = "Hunter Potion";
				this.CName = "狩猎药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 17;
				this.buffTime = 18000;
				this.toolTip = "显示附近敌人位置";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 305)
			{
				this.name = "Gravitation Potion";
				this.CName = "重力药剂";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.buffType = 18;
				this.buffTime = 10800;
				this.toolTip = "能控制重力方向";
				this.value = 1000;
				this.rare = 1;
			}
			else if (this.type == 306)
			{
				this.name = "Gold Chest";
				this.CName = "黄金宝箱";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 21;
				this.placeStyle = 1;
				this.width = 26;
				this.height = 22;
				this.value = 5000;
			}
			else if (this.type == 307)
			{
				this.name = "Daybloom Seeds";
				this.CName = "太阳花种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 0;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 308)
			{
				this.name = "Moonglow Seeds";
				this.CName = "月光草种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 1;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 309)
			{
				this.name = "Blinkroot Seeds";
				this.CName = "闪耀根种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 2;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 310)
			{
				this.name = "Deathweed Seeds";
				this.CName = "死亡草种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 3;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 311)
			{
				this.name = "Waterleaf Seeds";
				this.CName = "粉蝶花种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 4;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 312)
			{
				this.name = "Fireblossom Seeds";
				this.CName = "火焰花种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 82;
				this.placeStyle = 5;
				this.width = 12;
				this.height = 14;
				this.value = 80;
			}
			else if (this.type == 313)
			{
				this.name = "Daybloom";
				this.CName = "太阳花";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 314)
			{
				this.name = "Moonglow";
				this.CName = "月光草";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 315)
			{
				this.name = "Blinkroot";
				this.CName = "闪耀根";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 316)
			{
				this.name = "Deathweed";
				this.CName = "死亡草";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 317)
			{
				this.name = "Waterleaf";
				this.CName = "粉蝶花";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 318)
			{
				this.name = "Fireblossom";
				this.CName = "火焰花";
				this.maxStack = 99;
				this.width = 12;
				this.height = 14;
				this.value = 100;
			}
			else if (this.type == 319)
			{
				this.name = "Shark Fin";
				this.CName = "鲨鱼鳍";
				this.maxStack = 99;
				this.width = 16;
				this.height = 14;
				this.value = 200;
			}
			else if (this.type == 320)
			{
				this.name = "Feather";
				this.CName = "羽毛";
				this.maxStack = 99;
				this.width = 16;
				this.height = 14;
				this.value = 50;
			}
			else if (this.type == 321)
			{
				this.name = "Tombstone";
				this.CName = "墓碑";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 85;
				this.width = 20;
				this.height = 20;
			}
			else if (this.type == 322)
			{
				this.name = "Mime Mask";
				this.CName = "丑角面具";
				this.headSlot = 28;
				this.width = 20;
				this.height = 20;
				this.value = 20000;
			}
			else if (this.type == 323)
			{
				this.name = "Antlion Mandible";
				this.CName = "蚁狮上颚";
				this.width = 10;
				this.height = 20;
				this.maxStack = 99;
				this.value = 50;
			}
			else if (this.type == 324)
			{
				this.name = "Illegal Gun Parts";
				this.CName = "非法枪械部件";
				this.width = 10;
				this.height = 20;
				this.maxStack = 99;
				this.value = 750000;
				this.toolTip = "'危险的违禁品'";
			}
			else if (this.type == 325)
			{
				this.name = "The Doctor's Shirt";
				this.CName = "博士上衣";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 16;
				this.value = 200000;
				this.vanity = true;
			}
			else if (this.type == 326)
			{
				this.name = "The Doctor's Pants";
				this.CName = "博士长裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 15;
				this.value = 200000;
				this.vanity = true;
			}
			else if (this.type == 327)
			{
				this.name = "Golden Key";
				this.CName = "黄金钥匙";
				this.width = 14;
				this.height = 20;
				this.maxStack = 99;
				this.toolTip = "可开启一个黄金宝箱";
			}
			else if (this.type == 328)
			{
				this.name = "Shadow Chest";
				this.CName = "暗影宝箱";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 21;
				this.placeStyle = 3;
				this.width = 26;
				this.height = 22;
				this.value = 5000;
			}
			else if (this.type == 329)
			{
				this.name = "Shadow Key";
				this.CName = "暗影钥匙";
				this.width = 14;
				this.height = 20;
				this.maxStack = 1;
				this.toolTip = "可开启所有暗影宝箱";
				this.value = 75000;
			}
			else if (this.type == 330)
			{
				this.name = "Obsidian Brick Wall";
				this.CName = "黑曜石墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 20;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 331)
			{
				this.name = "Jungle Spores";
				this.CName = "丛林孢子";
				this.width = 18;
				this.height = 16;
				this.maxStack = 99;
				this.value = 100;
			}
			else if (this.type == 332)
			{
				this.name = "Loom";
				this.CName = "织布机";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 86;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.toolTip = "用于纺织";
			}
			else if (this.type == 333)
			{
				this.name = "Piano";
				this.CName = "钢琴";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 87;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 334)
			{
				this.name = "Dresser";
				this.CName = "梳妆台";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 88;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 335)
			{
				this.name = "Bench";
				this.CName = "长椅";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 89;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 336)
			{
				this.name = "Bathtub";
				this.CName = "浴缸";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 90;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 337)
			{
				this.name = "Red Banner";
				this.CName = "红色标识";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 91;
				this.placeStyle = 0;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 338)
			{
				this.name = "Green Banner";
				this.CName = "绿色标识";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 91;
				this.placeStyle = 1;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 339)
			{
				this.name = "Blue Banner";
				this.CName = "蓝色标识";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 91;
				this.placeStyle = 2;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 340)
			{
				this.name = "Yellow Banner";
				this.CName = "黄色标识";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 91;
				this.placeStyle = 3;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 341)
			{
				this.name = "Lamp Post";
				this.CName = "路灯柱";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 92;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 342)
			{
				this.name = "Tiki Torch";
				this.CName = "缇基火炬";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 93;
				this.width = 10;
				this.height = 24;
				this.value = 500;
			}
			else if (this.type == 343)
			{
				this.name = "Barrel";
				this.CName = "木桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 21;
				this.placeStyle = 5;
				this.width = 20;
				this.height = 20;
				this.value = 500;
			}
			else if (this.type == 344)
			{
				this.name = "Chinese Lantern";
				this.CName = "折纸灯笼";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 95;
				this.width = 20;
				this.height = 20;
				this.value = 500;
			}
			else if (this.type == 345)
			{
				this.name = "Cooking Pot";
				this.CName = "烹饪锅";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 96;
				this.width = 20;
				this.height = 20;
				this.value = 500;
			}
			else if (this.type == 346)
			{
				this.name = "Safe";
				this.CName = "保险箱";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 97;
				this.width = 20;
				this.height = 20;
				this.value = 500000;
			}
			else if (this.type == 347)
			{
				this.name = "Skull Lantern";
				this.CName = "颅骨烛台";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 98;
				this.width = 20;
				this.height = 20;
				this.value = 500;
			}
			else if (this.type == 348)
			{
				this.name = "Trash Can";
				this.CName = "垃圾桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 21;
				this.placeStyle = 6;
				this.width = 20;
				this.height = 20;
				this.value = 1000;
			}
			else if (this.type == 349)
			{
				this.name = "Candelabra";
				this.CName = "大烛台";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 100;
				this.width = 20;
				this.height = 20;
				this.value = 1500;
			}
			else if (this.type == 350)
			{
				this.name = "Pink Vase";
				this.CName = "粉色水瓶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 13;
				this.placeStyle = 3;
				this.width = 16;
				this.height = 24;
				this.value = 70;
			}
			else if (this.type == 351)
			{
				this.name = "Mug";
				this.CName = "酒杯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 13;
				this.placeStyle = 4;
				this.width = 16;
				this.height = 24;
				this.value = 20;
			}
			else if (this.type == 352)
			{
				this.name = "Keg";
				this.CName = "酒桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 94;
				this.width = 24;
				this.height = 24;
				this.value = 600;
				this.toolTip = "用来酿造麦酒";
			}
			else if (this.type == 353)
			{
				this.name = "Ale";
				this.CName = "麦酒";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 10;
				this.height = 10;
				this.buffType = 25;
				this.buffTime = 7200;
				this.value = 100;
			}
			else if (this.type == 354)
			{
				this.name = "Bookcase";
				this.CName = "书架";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 101;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 355)
			{
				this.name = "Throne";
				this.CName = "王座";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 102;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 356)
			{
				this.name = "Bowl";
				this.CName = "空碗";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 103;
				this.width = 16;
				this.height = 24;
				this.value = 20;
			}
			else if (this.type == 357)
			{
				this.name = "Bowl of Soup";
				this.CName = "蘑菇鱼汤";
				this.useSound = 3;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 10;
				this.height = 10;
				this.buffType = 26;
				this.buffTime = 36000;
				this.rare = 1;
				this.toolTip = "少量增加所有属性";
				this.value = 1000;
			}
			else if (this.type == 358)
			{
				this.name = "Toilet";
				this.CName = "马桶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 15;
				this.placeStyle = 1;
				this.width = 12;
				this.height = 30;
				this.value = 150;
			}
			else if (this.type == 359)
			{
				this.name = "Grandfather Clock";
				this.CName = "老式摆钟";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 104;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 360)
			{
				this.name = "Armor Statue";
				this.CName = "盔甲雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
			}
			else if (this.type == 361)
			{
				this.useStyle = 4;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.name = "Goblin Battle Standard";
				this.CName = "地精战旗";
				this.width = 28;
				this.height = 28;
				this.toolTip = "召唤地精大军";
			}
			else if (this.type == 362)
			{
				this.name = "Tattered Cloth";
				this.CName = "破布";
				this.maxStack = 99;
				this.width = 24;
				this.height = 24;
				this.value = 30;
			}
			else if (this.type == 363)
			{
				this.name = "Sawmill";
				this.CName = "锯木机";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 106;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.toolTip = "用于高级木工制作";
			}
			else if (this.type == 364)
			{
				this.name = "Cobalt Ore";
				this.CName = "钴蓝矿";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 107;
				this.width = 12;
				this.height = 12;
				this.value = 3500;
				this.rare = 3;
			}
			else if (this.type == 365)
			{
				this.name = "Mythril Ore";
				this.CName = "秘银矿";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 108;
				this.width = 12;
				this.height = 12;
				this.value = 5500;
				this.rare = 3;
			}
			else if (this.type == 366)
			{
				this.name = "Adamantite Ore";
				this.CName = "精金矿";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 111;
				this.width = 12;
				this.height = 12;
				this.value = 7500;
				this.rare = 3;
			}
			else if (this.type == 367)
			{
				this.name = "Pwnhammer";
				this.CName = "神槌·无坚不摧";
				this.useTurn = true;
				this.autoReuse = true;
				this.useStyle = 1;
				this.useAnimation = 27;
				this.useTime = 14;
				this.hammer = 80;
				this.width = 24;
				this.height = 28;
				this.damage = 26;
				this.knockBack = 7.5f;
				this.scale = 1.2f;
				this.useSound = 1;
				this.rare = 4;
				this.value = 39000;
				this.melee = true;
				this.toolTip = "拥有将恶魔祭坛摧毁的能力";
			}
			else if (this.type == 368)
			{
				this.autoReuse = true;
				this.name = "Excalibur";
				this.CName = "圣剑·胜利誓约";
				this.useStyle = 1;
				this.useAnimation = 25;
				this.useTime = 25;
				this.knockBack = 4.5f;
				this.width = 40;
				this.height = 40;
				this.damage = 47;
				this.scale = 1.15f;
				this.useSound = 1;
				this.rare = 5;
				this.value = 230000;
				this.melee = true;
			}
			else if (this.type == 369)
			{
				this.name = "Hallowed Seeds";
				this.CName = "神圣之种";
				this.useTurn = true;
				this.useStyle = 1;
				this.useAnimation = 15;
				this.useTime = 10;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 109;
				this.width = 14;
				this.height = 14;
				this.value = 2000;
				this.rare = 3;
			}
			else if (this.type == 370)
			{
				this.name = "Ebonsand Block";
				this.CName = "黑檀沙块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 112;
				this.width = 12;
				this.height = 12;
				this.ammo = 42;
			}
			else if (this.type == 371)
			{
				this.name = "Cobalt Hat";
				this.CName = "钴蓝罩帽";
				this.width = 18;
				this.height = 18;
				this.defense = 2;
				this.headSlot = 29;
				this.rare = 4;
				this.value = 75000;
				this.toolTip = "增加40点最大魔力值";
				this.toolTip2 = "增加9%魔法暴击率";
			}
			else if (this.type == 372)
			{
				this.name = "Cobalt Helmet";
				this.CName = "钴蓝重盔";
				this.width = 18;
				this.height = 18;
				this.defense = 11;
				this.headSlot = 30;
				this.rare = 4;
				this.value = 75000;
				this.toolTip = "增加7%移动速度";
				this.toolTip2 = "增加12%近战攻速";
			}
			else if (this.type == 373)
			{
				this.name = "Cobalt Mask";
				this.CName = "钴蓝面罩";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.headSlot = 31;
				this.rare = 4;
				this.value = 75000;
				this.toolTip = "增加10%远程伤害";
				this.toolTip2 = "增加6%远程暴击率";
			}
			else if (this.type == 374)
			{
				this.name = "Cobalt Breastplate";
				this.CName = "钴蓝胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 8;
				this.bodySlot = 17;
				this.rare = 4;
				this.value = 60000;
				this.toolTip2 = "所有攻击增加3%暴击率";
			}
			else if (this.type == 375)
			{
				this.name = "Cobalt Leggings";
				this.CName = "钴蓝腿甲";
				this.width = 18;
				this.height = 18;
				this.defense = 7;
				this.legSlot = 16;
				this.rare = 4;
				this.value = 45000;
				this.toolTip2 = "增加10%移动速度";
			}
			else if (this.type == 376)
			{
				this.name = "Mythril Hood";
				this.CName = "秘银兜帽";
				this.width = 18;
				this.height = 18;
				this.defense = 3;
				this.headSlot = 32;
				this.rare = 4;
				this.value = 112500;
				this.toolTip = "增加60点最大魔力值";
				this.toolTip2 = "增加15%魔法伤害";
			}
			else if (this.type == 377)
			{
				this.name = "Mythril Helmet";
				this.CName = "秘银重盔";
				this.width = 18;
				this.height = 18;
				this.defense = 16;
				this.headSlot = 33;
				this.rare = 4;
				this.value = 112500;
				this.toolTip = "增加5%近战暴击率";
				this.toolTip2 = "增加10%近战伤害";
			}
			else if (this.type == 378)
			{
				this.name = "Mythril Hat";
				this.CName = "秘银头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 6;
				this.headSlot = 34;
				this.rare = 4;
				this.value = 112500;
				this.toolTip = "增加12%远程伤害";
				this.toolTip2 = "增加7%远程暴击率";
			}
			else if (this.type == 379)
			{
				this.name = "Mythril Chainmail";
				this.CName = "秘银链甲";
				this.width = 18;
				this.height = 18;
				this.defense = 12;
				this.bodySlot = 18;
				this.rare = 4;
				this.value = 90000;
				this.toolTip2 = "所有攻击增加5%伤害";
			}
			else if (this.type == 380)
			{
				this.name = "Mythril Greaves";
				this.CName = "秘银胫甲";
				this.width = 18;
				this.height = 18;
				this.defense = 9;
				this.legSlot = 17;
				this.rare = 4;
				this.value = 67500;
				this.toolTip2 = "所有攻击增加3%暴击率";
			}
			else if (this.type == 381)
			{
				this.name = "Cobalt Bar";
				this.CName = "钴蓝锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 10500;
				this.rare = 3;
			}
			else if (this.type == 382)
			{
				this.name = "Mythril Bar";
				this.CName = "秘银锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 22000;
				this.rare = 3;
			}
			else if (this.type == 383)
			{
				this.name = "Cobalt Chainsaw";
				this.CName = "钴蓝链锯";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 8;
				this.shootSpeed = 40f;
				this.knockBack = 2.75f;
				this.width = 20;
				this.height = 12;
				this.damage = 23;
				this.axe = 14;
				this.useSound = 23;
				this.shoot = 57;
				this.rare = 4;
				this.value = 54000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 384)
			{
				this.name = "Mythril Chainsaw";
				this.CName = "秘银链锯";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 8;
				this.shootSpeed = 40f;
				this.knockBack = 3f;
				this.width = 20;
				this.height = 12;
				this.damage = 29;
				this.axe = 17;
				this.useSound = 23;
				this.shoot = 58;
				this.rare = 4;
				this.value = 81000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 385)
			{
				this.name = "Cobalt Drill";
				this.CName = "钴蓝钻头";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 13;
				this.shootSpeed = 32f;
				this.knockBack = 0f;
				this.width = 20;
				this.height = 12;
				this.damage = 10;
				this.pick = 110;
				this.useSound = 23;
				this.shoot = 59;
				this.rare = 4;
				this.value = 54000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
				this.toolTip = "能采掘秘银";
			}
			else if (this.type == 386)
			{
				this.name = "Mythril Drill";
				this.CName = "秘银钻头";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 10;
				this.shootSpeed = 32f;
				this.knockBack = 0f;
				this.width = 20;
				this.height = 12;
				this.damage = 15;
				this.pick = 150;
				this.useSound = 23;
				this.shoot = 60;
				this.rare = 4;
				this.value = 81000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
				this.toolTip = "能采掘精金";
			}
			else if (this.type == 387)
			{
				this.name = "Adamantite Chainsaw";
				this.CName = "精金链锯";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 6;
				this.shootSpeed = 40f;
				this.knockBack = 4.5f;
				this.width = 20;
				this.height = 12;
				this.damage = 33;
				this.axe = 20;
				this.useSound = 23;
				this.shoot = 61;
				this.rare = 4;
				this.value = 108000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 388)
			{
				this.name = "Adamantite Drill";
				this.CName = "精金钻头";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 7;
				this.shootSpeed = 32f;
				this.knockBack = 0f;
				this.width = 20;
				this.height = 12;
				this.damage = 20;
				this.pick = 180;
				this.useSound = 23;
				this.shoot = 62;
				this.rare = 4;
				this.value = 108000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
			}
			else if (this.type == 389)
			{
				this.name = "Dao of Pow";
				this.CName = "无极";
				this.noMelee = true;
				this.useStyle = 5;
				this.useAnimation = 45;
				this.useTime = 45;
				this.knockBack = 7f;
				this.width = 30;
				this.height = 10;
				this.damage = 49;
				this.scale = 1.1f;
				this.noUseGraphic = true;
				this.shoot = 63;
				this.shootSpeed = 15f;
				this.useSound = 1;
				this.rare = 5;
				this.value = 144000;
				this.melee = true;
				this.channel = true;
				this.toolTip = "有几率对目标造成混乱效果";
				this.toolTip2 = "'心如止水'";
			}
			else if (this.type == 390)
			{
				this.name = "Mythril Halberd";
				this.CName = "秘银长戟";
				this.useStyle = 5;
				this.useAnimation = 26;
				this.useTime = 26;
				this.shootSpeed = 4.5f;
				this.knockBack = 5f;
				this.width = 40;
				this.height = 40;
				this.damage = 35;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 64;
				this.rare = 4;
				this.value = 67500;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 391)
			{
				this.name = "Adamantite Bar";
				this.CName = "精金锭";
				this.width = 20;
				this.height = 20;
				this.maxStack = 99;
				this.value = 37500;
				this.rare = 3;
			}
			else if (this.type == 392)
			{
				this.name = "Glass Wall";
				this.CName = "玻璃幕墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 21;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 393)
			{
				this.name = "Compass";
				this.CName = "罗盘";
				this.width = 24;
				this.height = 28;
				this.rare = 3;
				this.value = 100000;
				this.accessory = true;
				this.toolTip = "显示水平方位";
			}
			else if (this.type == 394)
			{
				this.name = "Diving Gear";
				this.CName = "潜水用具";
				this.width = 24;
				this.height = 28;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
				this.toolTip = "能够在水下游动";
				this.toolTip2 = "能够长时间在水下呼吸";
			}
			else if (this.type == 395)
			{
				this.name = "GPS";
				this.CName = "GPS全球定位系统";
				this.width = 24;
				this.height = 28;
				this.rare = 4;
				this.value = 150000;
				this.accessory = true;
				this.toolTip = "显示自身方位";
				this.toolTip2 = "显示时间";
			}
			else if (this.type == 396)
			{
				this.name = "Obsidian Horseshoe";
				this.CName = "黑曜石马掌";
				this.width = 24;
				this.height = 28;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
				this.toolTip = "免疫掉落伤害";
				this.toolTip2 = "免受高温砖块烫伤";
			}
			else if (this.type == 397)
			{
				this.name = "Obsidian Shield";
				this.CName = "黑曜石盾";
				this.width = 24;
				this.height = 28;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
				this.defense = 2;
				this.toolTip = "免疫击退效果";
				this.toolTip2 = "免受高温砖块烫伤";
			}
			else if (this.type == 398)
			{
				this.name = "Tinkerer's Workshop";
				this.CName = "工匠作坊";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 114;
				this.width = 26;
				this.height = 20;
				this.value = 100000;
				this.toolTip = "允许进行饰品组合";
			}
			else if (this.type == 399)
			{
				this.name = "Cloud in a Balloon";
				this.CName = "云气球";
				this.width = 14;
				this.height = 28;
				this.rare = 4;
				this.value = 150000;
				this.accessory = true;
				this.toolTip = "允许二段跳";
				this.toolTip2 = "增加跳跃高度";
			}
			else if (this.type == 400)
			{
				this.name = "Adamantite Headgear";
				this.CName = "精金头饰";
				this.width = 18;
				this.height = 18;
				this.defense = 4;
				this.headSlot = 35;
				this.rare = 4;
				this.value = 150000;
				this.toolTip = "增加80点最大魔力值";
				this.toolTip2 = "增加11%魔法伤害和魔法暴击率";
			}
			else if (this.type == 401)
			{
				this.name = "Adamantite Helmet";
				this.CName = "精金重盔";
				this.width = 18;
				this.height = 18;
				this.defense = 22;
				this.headSlot = 36;
				this.rare = 4;
				this.value = 150000;
				this.toolTip = "增加7%近战暴击率";
				this.toolTip2 = "增加14%近战伤害";
			}
			else if (this.type == 402)
			{
				this.name = "Adamantite Mask";
				this.CName = "精金面甲";
				this.width = 18;
				this.height = 18;
				this.defense = 8;
				this.headSlot = 37;
				this.rare = 4;
				this.value = 150000;
				this.toolTip = "增加14%远程伤害";
				this.toolTip2 = "增加8%远程暴击率";
			}
			else if (this.type == 403)
			{
				this.name = "Adamantite Breastplate";
				this.CName = "精金胸甲";
				this.width = 18;
				this.height = 18;
				this.defense = 14;
				this.bodySlot = 19;
				this.rare = 4;
				this.value = 120000;
				this.toolTip = "所有攻击增加6%伤害";
			}
			else if (this.type == 404)
			{
				this.name = "Adamantite Leggings";
				this.CName = "精金腿甲";
				this.width = 18;
				this.height = 18;
				this.defense = 10;
				this.legSlot = 18;
				this.rare = 4;
				this.value = 90000;
				this.toolTip = "所有攻击增加4%暴击率";
				this.toolTip2 = "增加5%移动速度";
			}
			else if (this.type == 405)
			{
				this.name = "Spectre Boots";
				this.CName = "风火靴";
				this.width = 28;
				this.height = 24;
				this.accessory = true;
				this.rare = 4;
				this.toolTip = "地精科技与神话的结晶";
				this.toolTip2 = "助跑，起飞！";
				this.value = 100000;
			}
			else if (this.type == 406)
			{
				this.name = "Adamantite Glaive";
				this.CName = "精金关刀";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 25;
				this.shootSpeed = 5f;
				this.knockBack = 6f;
				this.width = 40;
				this.height = 40;
				this.damage = 38;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 66;
				this.rare = 4;
				this.value = 90000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 407)
			{
				this.name = "Toolbelt";
				this.CName = "工具包";
				this.width = 28;
				this.height = 24;
				this.accessory = true;
				this.rare = 3;
				this.toolTip = "使佩戴者增加一格砖块摆放距离";
				this.value = 100000;
			}
			else if (this.type == 408)
			{
				this.name = "Pearlsand Block";
				this.CName = "珍珠沙块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 116;
				this.width = 12;
				this.height = 12;
				this.ammo = 42;
			}
			else if (this.type == 409)
			{
				this.name = "Pearlstone Block";
				this.CName = "珍珠岩块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 117;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 410)
			{
				this.name = "Mining Shirt";
				this.CName = "矿工衬衫";
				this.width = 18;
				this.height = 18;
				this.defense = 1;
				this.bodySlot = 20;
				this.value = 5000;
				this.rare = 1;
			}
			else if (this.type == 411)
			{
				this.name = "Mining Pants";
				this.CName = "矿工长裤";
				this.width = 18;
				this.height = 18;
				this.defense = 1;
				this.legSlot = 19;
				this.value = 5000;
				this.rare = 1;
			}
			else if (this.type == 412)
			{
				this.name = "Pearlstone Brick";
				this.CName = "珍珠岩砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 118;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 413)
			{
				this.name = "Iridescent Brick";
				this.CName = "荧光砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 119;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 414)
			{
				this.name = "Mudstone Block";
				this.CName = "淤泥石块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 120;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 415)
			{
				this.name = "Cobalt Brick";
				this.CName = "钴蓝砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 121;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 416)
			{
				this.name = "Mythril Brick";
				this.CName = "秘银砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 122;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 417)
			{
				this.name = "Pearlstone Brick Wall";
				this.CName = "珍珠岩墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 22;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 418)
			{
				this.name = "Iridescent Brick Wall";
				this.CName = "荧光砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 23;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 419)
			{
				this.name = "Mudstone Brick Wall";
				this.CName = "淤泥石墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 24;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 420)
			{
				this.name = "Cobalt Brick Wall";
				this.CName = "钴蓝砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 25;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 421)
			{
				this.name = "Mythril Brick Wall";
				this.CName = "秘银砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 26;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 422)
			{
				this.useStyle = 1;
				this.name = "Holy Water";
				this.CName = "圣洁水瓶";
				this.shootSpeed = 9f;
				this.rare = 3;
				this.damage = 20;
				this.shoot = 69;
				this.width = 18;
				this.height = 20;
				this.maxStack = 250;
				this.consumable = true;
				this.knockBack = 3f;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 200;
				this.toolTip = "装有净化大地的神圣之水";
			}
			else if (this.type == 423)
			{
				this.useStyle = 1;
				this.name = "Unholy Water";
				this.CName = "邪恶水瓶";
				this.shootSpeed = 9f;
				this.rare = 3;
				this.damage = 20;
				this.shoot = 70;
				this.width = 18;
				this.height = 20;
				this.maxStack = 250;
				this.consumable = true;
				this.knockBack = 3f;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 200;
				this.toolTip = "装有污染大地的腐化之水";
			}
			else if (this.type == 424)
			{
				this.name = "Silt Block";
				this.CName = "泥沙块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 123;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 425)
			{
				this.mana = 40;
				this.channel = true;
				this.damage = 0;
				this.useStyle = 1;
				this.name = "Fairy Bell";
				this.CName = "妖精铃铛";
				this.shoot = 72;
				this.width = 24;
				this.height = 24;
				this.useSound = 25;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 5;
				this.noMelee = true;
				this.toolTip = "召唤一只魔法妖精";
				this.value = (this.value = 250000);
				this.buffType = 27;
				this.buffTime = 18000;
			}
			else if (this.type == 426)
			{
				this.name = "Breaker Blade";
				this.CName = "破坏者巨剑";
				this.useStyle = 1;
				this.useAnimation = 30;
				this.knockBack = 8f;
				this.width = 60;
				this.height = 70;
				this.damage = 39;
				this.scale = 1.05f;
				this.useSound = 1;
				this.rare = 4;
				this.value = 150000;
				this.melee = true;
			}
			else if (this.type == 427)
			{
				this.noWet = true;
				this.name = "Blue Torch";
				this.CName = "蓝火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 1;
				this.width = 10;
				this.height = 12;
				this.value = 200;
			}
			else if (this.type == 428)
			{
				this.noWet = true;
				this.name = "Red Torch";
				this.CName = "红火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 2;
				this.width = 10;
				this.height = 12;
				this.value = 200;
			}
			else if (this.type == 429)
			{
				this.noWet = true;
				this.name = "Green Torch";
				this.CName = "绿火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 3;
				this.width = 10;
				this.height = 12;
				this.value = 200;
			}
			else if (this.type == 430)
			{
				this.noWet = true;
				this.name = "Purple Torch";
				this.CName = "紫火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 4;
				this.width = 10;
				this.height = 12;
				this.value = 200;
			}
			else if (this.type == 431)
			{
				this.noWet = true;
				this.name = "White Torch";
				this.CName = "白火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 5;
				this.width = 10;
				this.height = 12;
				this.value = 500;
			}
			else if (this.type == 432)
			{
				this.noWet = true;
				this.name = "Yellow Torch";
				this.CName = "黄火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 6;
				this.width = 10;
				this.height = 12;
				this.value = 200;
			}
			else if (this.type == 433)
			{
				this.noWet = true;
				this.name = "Demon Torch";
				this.CName = "恶魔火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 7;
				this.width = 10;
				this.height = 12;
				this.value = 300;
			}
			else if (this.type == 434)
			{
				this.autoReuse = true;
				this.useStyle = 5;
				this.useAnimation = 12;
				this.useTime = 4;
				this.reuseDelay = 14;
				this.name = "Clockwork Assault Rifle";
				this.CName = "发条式突击步枪AR47";
				this.width = 50;
				this.height = 18;
				this.shoot = 10;
				this.useAmmo = 14;
				this.useSound = 31;
				this.damage = 19;
				this.shootSpeed = 7.75f;
				this.noMelee = true;
				this.value = 150000;
				this.rare = 4;
				this.ranged = true;
				this.toolTip = "三连发";
				this.toolTip2 = "只有第一发消耗弹药";
			}
			else if (this.type == 435)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 25;
				this.useTime = 25;
				this.name = "Cobalt Repeater";
				this.CName = "钴蓝连发弩";
				this.width = 50;
				this.height = 18;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 30;
				this.shootSpeed = 9f;
				this.noMelee = true;
				this.value = 60000;
				this.ranged = true;
				this.rare = 4;
				this.knockBack = 1.5f;
			}
			else if (this.type == 436)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 23;
				this.useTime = 23;
				this.name = "Mythril Repeater";
				this.CName = "秘银连发弩";
				this.width = 50;
				this.height = 18;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 34;
				this.shootSpeed = 9.5f;
				this.noMelee = true;
				this.value = 90000;
				this.ranged = true;
				this.rare = 4;
				this.knockBack = 2f;
			}
			else if (this.type == 437)
			{
				this.noUseGraphic = true;
				this.damage = 0;
				this.knockBack = 7f;
				this.useStyle = 5;
				this.name = "Dual Hook";
				this.CName = "双龙爪";
				this.shootSpeed = 14f;
				this.shoot = 73;
				this.width = 18;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 4;
				this.noMelee = true;
				this.value = 200000;
			}
			else if (this.type == 438)
			{
				this.name = "Star Statue";
				this.CName = "星辰雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 2;
			}
			else if (this.type == 439)
			{
				this.name = "Sword Statue";
				this.CName = "宝剑雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 3;
			}
			else if (this.type == 440)
			{
				this.name = "Slime Statue";
				this.CName = "史莱姆雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 4;
			}
			else if (this.type == 441)
			{
				this.name = "Goblin Statue";
				this.CName = "地精雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 5;
			}
			else if (this.type == 442)
			{
				this.name = "Shield Statue";
				this.CName = "盾牌雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 6;
			}
			else if (this.type == 443)
			{
				this.name = "Bat Statue";
				this.CName = "蝙蝠雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 7;
			}
			else if (this.type == 444)
			{
				this.name = "Fish Statue";
				this.CName = "金鱼雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 8;
			}
			else if (this.type == 445)
			{
				this.name = "Bunny Statue";
				this.CName = "兔子雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 9;
			}
			else if (this.type == 446)
			{
				this.name = "Skeleton Statue";
				this.CName = "骷髅雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 10;
			}
			else if (this.type == 447)
			{
				this.name = "Reaper Statue";
				this.CName = "巫术雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 11;
			}
			else if (this.type == 448)
			{
				this.name = "Woman Statue";
				this.CName = "女性雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 12;
			}
			else if (this.type == 449)
			{
				this.name = "Imp Statue";
				this.CName = "魔精雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 13;
			}
			else if (this.type == 450)
			{
				this.name = "Gargoyle Statue";
				this.CName = "石像鬼雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 14;
			}
			else if (this.type == 451)
			{
				this.name = "Gloom Statue";
				this.CName = "阴森雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 15;
			}
			else if (this.type == 452)
			{
				this.name = "Hornet Statue";
				this.CName = "黄蜂雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 16;
			}
			else if (this.type == 453)
			{
				this.name = "Bomb Statue";
				this.CName = "炸弹雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 17;
			}
			else if (this.type == 454)
			{
				this.name = "Crab Statue";
				this.CName = "螃蟹雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 18;
			}
			else if (this.type == 455)
			{
				this.name = "Hammer Statue";
				this.CName = "战锤雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 19;
			}
			else if (this.type == 456)
			{
				this.name = "Potion Statue";
				this.CName = "药瓶雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 20;
			}
			else if (this.type == 457)
			{
				this.name = "Spear Statue";
				this.CName = "矛尖雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 21;
			}
			else if (this.type == 458)
			{
				this.name = "Cross Statue";
				this.CName = "十字架雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 22;
			}
			else if (this.type == 459)
			{
				this.name = "Jellyfish Statue";
				this.CName = "水母雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 23;
			}
			else if (this.type == 460)
			{
				this.name = "Bow Statue";
				this.CName = "短弓雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 24;
			}
			else if (this.type == 461)
			{
				this.name = "Boomerang Statue";
				this.CName = "回力镖雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 25;
			}
			else if (this.type == 462)
			{
				this.name = "Boot Statue";
				this.CName = "靴子雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 26;
			}
			else if (this.type == 463)
			{
				this.name = "Chest Statue";
				this.CName = "宝箱雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 27;
			}
			else if (this.type == 464)
			{
				this.name = "Bird Statue";
				this.CName = "小鸟雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 28;
			}
			else if (this.type == 465)
			{
				this.name = "Axe Statue";
				this.CName = "战斧雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 29;
			}
			else if (this.type == 466)
			{
				this.name = "Corrupt Statue";
				this.CName = "腐化雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 30;
			}
			else if (this.type == 467)
			{
				this.name = "Tree Statue";
				this.CName = "树木雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 31;
			}
			else if (this.type == 468)
			{
				this.name = "Anvil Statue";
				this.CName = "铁砧雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 32;
			}
			else if (this.type == 469)
			{
				this.name = "Pickaxe Statue";
				this.CName = "锄头雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 33;
			}
			else if (this.type == 470)
			{
				this.name = "Mushroom Statue";
				this.CName = "蘑菇雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 34;
			}
			else if (this.type == 471)
			{
				this.name = "Eyeball Statue";
				this.CName = "魔眼雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 35;
			}
			else if (this.type == 472)
			{
				this.name = "Pillar Statue";
				this.CName = "石柱雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 36;
			}
			else if (this.type == 473)
			{
				this.name = "Heart Statue";
				this.CName = "红心雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 37;
			}
			else if (this.type == 474)
			{
				this.name = "Pot Statue";
				this.CName = "陶罐雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 38;
			}
			else if (this.type == 475)
			{
				this.name = "Sunflower Statue";
				this.CName = "向日葵雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 39;
			}
			else if (this.type == 476)
			{
				this.name = "King Statue";
				this.CName = "国王雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 40;
			}
			else if (this.type == 477)
			{
				this.name = "Queen Statue";
				this.CName = "皇后雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 41;
			}
			else if (this.type == 478)
			{
				this.name = "Pirahna Statue";
				this.CName = "食人鱼雕像";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 105;
				this.width = 20;
				this.height = 20;
				this.value = 300;
				this.placeStyle = 42;
			}
			else if (this.type == 479)
			{
				this.name = "Planked Wall";
				this.CName = "板条墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 7;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 27;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 480)
			{
				this.name = "Wooden Beam";
				this.CName = "木梁";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 124;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 481)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 20;
				this.useTime = 20;
				this.name = "Adamantite Repeater";
				this.CName = "精金连发弩";
				this.width = 50;
				this.height = 18;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 37;
				this.shootSpeed = 10f;
				this.noMelee = true;
				this.value = 120000;
				this.ranged = true;
				this.rare = 4;
				this.knockBack = 2.5f;
			}
			else if (this.type == 482)
			{
				this.name = "Adamantite Sword";
				this.CName = "精金斩杀剑";
				this.useStyle = 1;
				this.useAnimation = 27;
				this.useTime = 27;
				this.knockBack = 6f;
				this.width = 40;
				this.height = 40;
				this.damage = 44;
				this.scale = 1.2f;
				this.useSound = 1;
				this.rare = 4;
				this.value = 138000;
				this.melee = true;
			}
			else if (this.type == 483)
			{
				this.useTurn = true;
				this.autoReuse = true;
				this.name = "Cobalt Sword";
				this.CName = "钴蓝轻剑";
				this.useStyle = 1;
				this.useAnimation = 23;
				this.useTime = 23;
				this.knockBack = 3.85f;
				this.width = 40;
				this.height = 40;
				this.damage = 34;
				this.scale = 1.1f;
				this.useSound = 1;
				this.rare = 4;
				this.value = 69000;
				this.melee = true;
			}
			else if (this.type == 484)
			{
				this.name = "Mythril Sword";
				this.CName = "秘银重剑";
				this.useStyle = 1;
				this.useAnimation = 26;
				this.useTime = 26;
				this.knockBack = 6f;
				this.width = 40;
				this.height = 40;
				this.damage = 39;
				this.scale = 1.15f;
				this.useSound = 1;
				this.rare = 4;
				this.value = 103500;
				this.melee = true;
			}
			else if (this.type == 485)
			{
				this.rare = 4;
				this.name = "Moon Charm";
				this.CName = "月光咒符";
				this.width = 24;
				this.height = 28;
				this.accessory = true;
				this.toolTip = "满月时会有奇怪的事情发生";
				this.value = 150000;
			}
			else if (this.type == 486)
			{
				this.name = "Ruler";
				this.CName = "标尺";
				this.width = 10;
				this.height = 26;
				this.accessory = true;
				this.toolTip = "显示网格可供建筑参照";
				this.value = 10000;
				this.rare = 1;
			}
			else if (this.type == 487)
			{
				this.name = "Crystal Ball";
				this.CName = "水晶球";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 125;
				this.width = 22;
				this.height = 22;
				this.value = 100000;
				this.rare = 3;
			}
			else if (this.type == 488)
			{
				this.name = "Disco Ball";
				this.CName = "镭射球灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 126;
				this.width = 22;
				this.height = 26;
				this.value = 10000;
			}
			else if (this.type == 489)
			{
				this.name = "Sorcerer Emblem";
				this.CName = "咒术纹章";
				this.width = 24;
				this.height = 24;
				this.accessory = true;
				this.toolTip = "增加15%魔法伤害";
				this.value = 100000;
				this.rare = 4;
			}
			else if (this.type == 491)
			{
				this.name = "Ranger Emblem";
				this.CName = "游侠纹章";
				this.width = 24;
				this.height = 24;
				this.accessory = true;
				this.toolTip = "增加15%远程伤害";
				this.value = 100000;
			}
			else if (this.type == 490)
			{
				this.name = "Warrior Emblem";
				this.CName = "勇士纹章";
				this.width = 24;
				this.height = 24;
				this.accessory = true;
				this.toolTip = "增加15%近战伤害";
				this.value = 100000;
				this.rare = 4;
			}
			else if (this.type == 492)
			{
				this.name = "Demon Wings";
				this.CName = "恶魔翅膀";
				this.width = 24;
				this.height = 8;
				this.accessory = true;
				this.toolTip = "获得飞翔和缓落能力";
				this.value = 400000;
				this.rare = 5;
			}
			else if (this.type == 493)
			{
				this.name = "Angel Wings";
				this.CName = "天使翅膀";
				this.width = 24;
				this.height = 8;
				this.accessory = true;
				this.toolTip = "获得飞翔和缓落能力";
				this.value = 400000;
				this.rare = 5;
			}
			else if (this.type == 494)
			{
				this.rare = 5;
				this.useStyle = 5;
				this.useAnimation = 12;
				this.useTime = 12;
				this.name = "Magical Harp";
				this.CName = "魔法竖琴";
				this.width = 12;
				this.height = 28;
				this.shoot = 76;
				this.holdStyle = 3;
				this.autoReuse = true;
				this.damage = 30;
				this.shootSpeed = 4.5f;
				this.noMelee = true;
				this.value = 200000;
				this.mana = 4;
				this.magic = true;
			}
			else if (this.type == 495)
			{
				this.rare = 5;
				this.mana = 10;
				this.channel = true;
				this.damage = 53;
				this.useStyle = 1;
				this.name = "Rainbow Rod";
				this.CName = "彩虹魔杖";
				this.shootSpeed = 6f;
				this.shoot = 79;
				this.width = 26;
				this.height = 28;
				this.useSound = 28;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noMelee = true;
				this.knockBack = 5f;
				this.toolTip = "能用鼠标控制一道强烈的魔法虹光，如果在圣域使用会造成更大伤害";
				this.value = 200000;
				this.magic = true;
			}
			else if (this.type == 496)
			{
				this.rare = 4;
				this.mana = 7;
				this.damage = 26;
				this.useStyle = 1;
				this.name = "Ice Rod";
				this.CName = "寒冰魔杖";
				this.shootSpeed = 12f;
				this.shoot = 80;
				this.width = 26;
				this.height = 28;
				this.useSound = 28;
				this.useAnimation = 17;
				this.useTime = 17;
				this.rare = 4;
				this.autoReuse = true;
				this.noMelee = true;
				this.knockBack = 0f;
				this.toolTip = "魔法冻结周围空气制造出一个持续5秒的寒冰块";
				this.value = 1000000;
				this.magic = true;
				this.knockBack = 2f;
			}
			else if (this.type == 497)
			{
				this.name = "Neptune's Shell";
				this.CName = "海神贝壳";
				this.width = 24;
				this.height = 28;
				this.accessory = true;
				this.toolTip = "进入水中会变成鱼人";
				this.value = 150000;
				this.rare = 5;
			}
			else if (this.type == 498)
			{
				this.name = "Mannequin";
				this.CName = "木质模型";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 128;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 499)
			{
				this.name = "Greater Healing Potion";
				this.CName = "强效治疗药水";
				this.useSound = 3;
				this.healLife = 150;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 30;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.rare = 3;
				this.potion = true;
				this.value = 5000;
			}
			else if (this.type == 500)
			{
				this.name = "Greater Mana Potion";
				this.CName = "强效魔力药水";
				this.useSound = 3;
				this.healMana = 200;
				this.useStyle = 2;
				this.useTurn = true;
				this.useAnimation = 17;
				this.useTime = 17;
				this.maxStack = 99;
				this.consumable = true;
				this.width = 14;
				this.height = 24;
				this.rare = 3;
				this.value = 500;
			}
			else if (this.type == 501)
			{
				this.name = "Pixie Dust";
				this.CName = "精灵尘";
				this.width = 16;
				this.height = 14;
				this.maxStack = 99;
				this.value = 500;
				this.rare = 1;
			}
			else if (this.type == 502)
			{
				this.name = "Crystal Shard";
				this.CName = "碎魔晶";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 129;
				this.width = 24;
				this.height = 24;
				this.value = 8000;
				this.rare = 1;
			}
			else if (this.type == 503)
			{
				this.name = "Clown Hat";
				this.CName = "小丑帽";
				this.width = 18;
				this.height = 18;
				this.headSlot = 40;
				this.value = 20000;
				this.vanity = true;
				this.rare = 2;
			}
			else if (this.type == 504)
			{
				this.name = "Clown Shirt";
				this.CName = "小丑服";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 23;
				this.value = 10000;
				this.vanity = true;
				this.rare = 2;
			}
			else if (this.type == 505)
			{
				this.name = "Clown Pants";
				this.CName = "小丑裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 22;
				this.value = 10000;
				this.vanity = true;
				this.rare = 2;
			}
			else if (this.type == 506)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 30;
				this.useTime = 6;
				this.name = "Flamethrower";
				this.CName = "聚焦喷火器";
				this.width = 50;
				this.height = 18;
				this.shoot = 85;
				this.useAmmo = 23;
				this.useSound = 34;
				this.damage = 27;
				this.knockBack = 0.3f;
				this.shootSpeed = 7f;
				this.noMelee = true;
				this.value = 500000;
				this.rare = 5;
				this.ranged = true;
				this.toolTip = "枪身上有一行小字:'凝胶由此处注入'";
			}
			else if (this.type == 507)
			{
				this.rare = 3;
				this.useStyle = 1;
				this.useAnimation = 12;
				this.useTime = 12;
				this.name = "Bell";
				this.CName = "铃铛";
				this.width = 12;
				this.height = 28;
				this.autoReuse = true;
				this.noMelee = true;
				this.value = 10000;
			}
			else if (this.type == 508)
			{
				this.rare = 3;
				this.useStyle = 5;
				this.useAnimation = 12;
				this.useTime = 12;
				this.name = "Harp";
				this.CName = "竖琴";
				this.width = 12;
				this.height = 28;
				this.autoReuse = true;
				this.noMelee = true;
				this.value = 10000;
			}
			else if (this.type == 509)
			{
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.name = "Wrench";
				this.CName = "扳手";
				this.width = 24;
				this.height = 28;
				this.rare = 1;
				this.toolTip = "布置导线用";
				this.value = 20000;
				this.mech = true;
			}
			else if (this.type == 510)
			{
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.name = "Wire Cutter";
				this.CName = "电工钳";
				this.width = 24;
				this.height = 28;
				this.rare = 1;
				this.toolTip = "移除导线用";
				this.value = 20000;
				this.mech = true;
			}
			else if (this.type == 511)
			{
				this.name = "Active Stone Block";
				this.CName = "机关石块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 130;
				this.width = 12;
				this.height = 12;
				this.value = 1000;
				this.mech = true;
			}
			else if (this.type == 512)
			{
				this.name = "Inactive Stone Block";
				this.CName = "机关石壁";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 131;
				this.width = 12;
				this.height = 12;
				this.value = 1000;
				this.mech = true;
			}
			else if (this.type == 513)
			{
				this.name = "Lever";
				this.CName = "控制杆";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 132;
				this.width = 24;
				this.height = 24;
				this.value = 3000;
				this.mech = true;
			}
			else if (this.type == 514)
			{
				this.autoReuse = true;
				this.useStyle = 5;
				this.useAnimation = 12;
				this.useTime = 12;
				this.name = "Laser Rifle";
				this.CName = "光束枪PG-γ";
				this.width = 36;
				this.height = 22;
				this.shoot = 88;
				this.mana = 8;
				this.useSound = 12;
				this.knockBack = 2.5f;
				this.damage = 29;
				this.shootSpeed = 17f;
				this.noMelee = true;
				this.rare = 4;
				this.magic = true;
				this.value = 500000;
			}
			else if (this.type == 515)
			{
				this.name = "Crystal Bullet";
				this.CName = "魔晶爆裂弹";
				this.shootSpeed = 5f;
				this.shoot = 89;
				this.damage = 9;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 14;
				this.knockBack = 1f;
				this.value = 30;
				this.ranged = true;
				this.rare = 3;
				this.toolTip = "受到撞击时会碎裂成许多魔晶碎片";
			}
			else if (this.type == 516)
			{
				this.name = "Holy Arrow";
				this.CName = "神怒之箭";
				this.shootSpeed = 3.5f;
				this.shoot = 91;
				this.damage = 6;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 2f;
				this.value = 80;
				this.ranged = true;
				this.rare = 3;
				this.toolTip = "箭的落点会吸引星辰坠落";
			}
			else if (this.type == 517)
			{
				this.useStyle = 1;
				this.name = "Magic Dagger";
				this.CName = "魔法飞刀";
				this.shootSpeed = 10f;
				this.shoot = 93;
				this.damage = 28;
				this.width = 18;
				this.height = 20;
				this.mana = 7;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.noMelee = true;
				this.value = 1000000;
				this.knockBack = 2f;
				this.magic = true;
				this.rare = 4;
				this.toolTip = "刀柄刻着能使它回到你手中的魔法铭文";
			}
			else if (this.type == 518)
			{
				this.autoReuse = true;
				this.rare = 4;
				this.mana = 5;
				this.useSound = 9;
				this.name = "Crystal Storm";
				this.CName = "魔晶风暴";
				this.useStyle = 5;
				this.damage = 26;
				this.useAnimation = 7;
				this.useTime = 7;
				this.width = 24;
				this.height = 28;
				this.shoot = 94;
				this.scale = 0.9f;
				this.shootSpeed = 16f;
				this.knockBack = 5f;
				this.toolTip = "召唤可持续反弹的魔晶碎片";
				this.magic = true;
				this.value = 500000;
			}
			else if (this.type == 519)
			{
				this.autoReuse = true;
				this.rare = 4;
				this.mana = 14;
				this.useSound = 20;
				this.name = "Cursed Flames";
				this.CName = "诅咒魔焰";
				this.useStyle = 5;
				this.damage = 35;
				this.useAnimation = 20;
				this.useTime = 20;
				this.width = 24;
				this.height = 28;
				this.shoot = 95;
				this.scale = 0.9f;
				this.shootSpeed = 10f;
				this.knockBack = 6.5f;
				this.toolTip = "召唤一枚诅咒火球";
				this.magic = true;
				this.value = 500000;
			}
			else if (this.type == 520)
			{
				this.name = "Soul of Light";
				this.CName = "光明之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 1000;
				this.rare = 3;
				this.toolTip = "'光明生物的精华'";
			}
			else if (this.type == 521)
			{
				this.name = "Soul of Night";
				this.CName = "暗影之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 1000;
				this.rare = 3;
				this.toolTip = "'黑暗生物的精华'";
			}
			else if (this.type == 522)
			{
				this.name = "Cursed Flame";
				this.CName = "诅咒火焰";
				this.width = 12;
				this.height = 14;
				this.maxStack = 99;
				this.value = 4000;
				this.rare = 3;
				this.toolTip = "'恶魔虫类的腺体中存在的物质，在水中也不会熄灭'";
			}
			else if (this.type == 523)
			{
				this.name = "Cursed Torch";
				this.CName = "诅咒火把";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.holdStyle = 1;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 4;
				this.placeStyle = 8;
				this.width = 10;
				this.height = 12;
				this.value = 300;
				this.rare = 1;
				this.toolTip = "可在水下放置";
			}
			else if (this.type == 524)
			{
				this.name = "Adamantite Forge";
				this.CName = "精金熔炉";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 133;
				this.width = 44;
				this.height = 30;
				this.value = 50000;
				this.toolTip = "可熔炼精金矿石";
				this.rare = 3;
			}
			else if (this.type == 525)
			{
				this.name = "Mythril Anvil";
				this.CName = "秘银砧";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 134;
				this.width = 28;
				this.height = 14;
				this.value = 25000;
				this.toolTip = "可用于高级金属锻造";
				this.rare = 3;
			}
			else if (this.type == 526)
			{
				this.name = "Unicorn Horn";
				this.CName = "独角兽的角";
				this.width = 14;
				this.height = 14;
				this.maxStack = 99;
				this.value = 15000;
				this.rare = 1;
				this.toolTip = "'有着不寻常魔力的尖角'";
			}
			else if (this.type == 527)
			{
				this.name = "Dark Shard";
				this.CName = "黑暗碎片";
				this.width = 14;
				this.height = 14;
				this.maxStack = 99;
				this.value = 4500;
				this.rare = 2;
				this.toolTip = "'沉重而冰冷的黑色碎片'";
			}
			else if (this.type == 528)
			{
				this.name = "Light Shard";
				this.CName = "光明碎片";
				this.width = 14;
				this.height = 14;
				this.maxStack = 99;
				this.value = 4500;
				this.rare = 2;
				this.toolTip = "'轻盈且温热的白色碎片'";
			}
			else if (this.type == 529)
			{
				this.name = "Red Pressure Plate";
				this.CName = "红色压力盘";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 135;
				this.width = 12;
				this.height = 12;
				this.placeStyle = 0;
				this.mech = true;
				this.value = 5000;
				this.mech = true;
				this.toolTip = "被踩下时会触发内置的机关";
			}
			else if (this.type == 530)
			{
				this.name = "Wire";
				this.CName = "导线";
				this.width = 12;
				this.height = 18;
				this.maxStack = 250;
				this.value = 500;
				this.mech = true;
			}
			else if (this.type == 531)
			{
				this.name = "Spell Tome";
				this.CName = "空白魔法书";
				this.width = 12;
				this.height = 18;
				this.maxStack = 99;
				this.value = 50000;
				this.rare = 1;
				this.toolTip = "可用魔法铭文进行加持";
			}
			else if (this.type == 532)
			{
				this.name = "Star Cloak";
				this.CName = "星辰披风";
				this.width = 20;
				this.height = 24;
				this.value = 100000;
				this.toolTip = "受到伤害时会有星星落下";
				this.accessory = true;
				this.rare = 4;
			}
			else if (this.type == 533)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 7;
				this.useTime = 7;
				this.name = "Megashark";
				this.CName = "巨兽鲨MG-II";
				this.width = 50;
				this.height = 18;
				this.shoot = 10;
				this.useAmmo = 14;
				this.useSound = 11;
				this.damage = 23;
				this.shootSpeed = 10f;
				this.noMelee = true;
				this.value = 300000;
				this.rare = 5;
				this.toolTip = "射击时有50%几率不消耗弹药";
				this.toolTip2 = "'鲨鱼机炮强化形态'";
				this.knockBack = 1f;
				this.ranged = true;
			}
			else if (this.type == 534)
			{
				this.knockBack = 6.5f;
				this.useStyle = 5;
				this.useAnimation = 45;
				this.useTime = 45;
				this.name = "Shotgun";
				this.CName = "散弹枪M12";
				this.width = 50;
				this.height = 14;
				this.shoot = 10;
				this.useAmmo = 14;
				this.useSound = 36;
				this.damage = 18;
				this.shootSpeed = 6f;
				this.noMelee = true;
				this.value = 700000;
				this.rare = 4;
				this.ranged = true;
				this.toolTip = "适合近距离作战";
			}
			else if (this.type == 535)
			{
				this.name = "Philosopher's Stone";
				this.CName = "炼金石";
				this.width = 12;
				this.height = 18;
				this.value = 100000;
				this.toolTip = "减少治疗药水的冷却时间";
				this.accessory = true;
				this.rare = 4;
			}
			else if (this.type == 536)
			{
				this.name = "Titan Glove";
				this.CName = "泰坦手套";
				this.width = 12;
				this.height = 18;
				this.value = 100000;
				this.toolTip = "增加击退能力";
				this.rare = 4;
				this.accessory = true;
			}
			else if (this.type == 537)
			{
				this.name = "Cobalt Naginata";
				this.CName = "钴蓝薙刀";
				this.useStyle = 5;
				this.useAnimation = 28;
				this.useTime = 28;
				this.shootSpeed = 4.3f;
				this.knockBack = 4f;
				this.width = 40;
				this.height = 40;
				this.damage = 29;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 97;
				this.rare = 4;
				this.value = 45000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 538)
			{
				this.name = "Switch";
				this.CName = "开关";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 136;
				this.width = 12;
				this.height = 12;
				this.value = 2000;
				this.mech = true;
			}
			else if (this.type == 539)
			{
				this.name = "Dart Trap";
				this.CName = "毒箭机关";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 137;
				this.width = 12;
				this.height = 12;
				this.value = 10000;
				this.mech = true;
			}
			else if (this.type == 540)
			{
				this.name = "Boulder";
				this.CName = "巨石";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 138;
				this.width = 12;
				this.height = 12;
				this.mech = true;
			}
			else if (this.type == 541)
			{
				this.name = "Green Pressure Plate";
				this.CName = "绿色压力盘";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 135;
				this.width = 12;
				this.height = 12;
				this.placeStyle = 1;
				this.mech = true;
				this.value = 5000;
				this.toolTip = "被踩下时会触发内置的机关";
			}
			else if (this.type == 542)
			{
				this.name = "Gray Pressure Plate";
				this.CName = "灰色压力盘";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 135;
				this.width = 12;
				this.height = 12;
				this.placeStyle = 2;
				this.mech = true;
				this.value = 5000;
				this.toolTip = "被踩下时会触发内置的机关";
			}
			else if (this.type == 543)
			{
				this.name = "Brown Pressure Plate";
				this.CName = "棕色压力盘";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 135;
				this.width = 12;
				this.height = 12;
				this.placeStyle = 3;
				this.mech = true;
				this.value = 5000;
				this.toolTip = "被踩下时会触发内置的机关";
			}
			else if (this.type == 544)
			{
				this.useStyle = 4;
				this.name = "Mechanical Eye";
				this.CName = "机械魔眼";
				this.width = 22;
				this.height = 14;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.maxStack = 20;
				this.toolTip = "召唤魔眼双子";
				this.rare = 3;
			}
			else if (this.type == 545)
			{
				this.name = "Cursed Arrow";
				this.CName = "咒火箭";
				this.shootSpeed = 4f;
				this.shoot = 103;
				this.damage = 14;
				this.width = 10;
				this.height = 28;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 1;
				this.knockBack = 3f;
				this.value = 80;
				this.ranged = true;
				this.rare = 3;
			}
			else if (this.type == 546)
			{
				this.name = "Cursed Bullet";
				this.CName = "咒火燃烧弹";
				this.shootSpeed = 5f;
				this.shoot = 104;
				this.damage = 12;
				this.width = 8;
				this.height = 8;
				this.maxStack = 250;
				this.consumable = true;
				this.ammo = 14;
				this.knockBack = 4f;
				this.value = 30;
				this.rare = 1;
				this.ranged = true;
				this.rare = 3;
			}
			else if (this.type == 547)
			{
				this.name = "Soul of Fright";
				this.CName = "恐惧之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 100000;
				this.rare = 5;
				this.toolTip = "'某个恐惧统治者的精华'";
			}
			else if (this.type == 548)
			{
				this.name = "Soul of Might";
				this.CName = "力量之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 100000;
				this.rare = 5;
				this.toolTip = "'某个世界毁灭者的精华'";
			}
			else if (this.type == 549)
			{
				this.name = "Soul of Sight";
				this.CName = "视域之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 100000;
				this.rare = 5;
				this.toolTip = "'某个全能窥视者的精华'";
			}
			else if (this.type == 550)
			{
				this.name = "Gungnir";
				this.CName = "神枪·奥丁之力";
				this.useStyle = 5;
				this.useAnimation = 22;
				this.useTime = 22;
				this.shootSpeed = 5.6f;
				this.knockBack = 6.4f;
				this.width = 40;
				this.height = 40;
				this.damage = 42;
				this.scale = 1.1f;
				this.useSound = 1;
				this.shoot = 105;
				this.rare = 5;
				this.value = 1500000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
			}
			else if (this.type == 551)
			{
				this.name = "Hallowed Plate Mail";
				this.CName = "神圣板甲";
				this.width = 18;
				this.height = 18;
				this.defense = 15;
				this.bodySlot = 24;
				this.rare = 5;
				this.value = 200000;
				this.toolTip = "所有攻击增加7%暴击率";
			}
			else if (this.type == 552)
			{
				this.name = "Hallowed Greaves";
				this.CName = "神圣腿甲";
				this.width = 18;
				this.height = 18;
				this.defense = 11;
				this.legSlot = 23;
				this.rare = 5;
				this.value = 150000;
				this.toolTip = "所有攻击增加7%伤害";
				this.toolTip2 = "增加8%移动速度";
			}
			else if (this.type == 553)
			{
				this.name = "Hallowed Helmet";
				this.CName = "神圣头盔";
				this.width = 18;
				this.height = 18;
				this.defense = 9;
				this.headSlot = 41;
				this.rare = 5;
				this.value = 250000;
				this.toolTip = "增加15%远程伤害";
				this.toolTip2 = "增加8%远程暴击率";
			}
			else if (this.type == 558)
			{
				this.name = "Hallowed Headgear";
				this.CName = "神圣头饰";
				this.width = 18;
				this.height = 18;
				this.defense = 5;
				this.headSlot = 42;
				this.rare = 5;
				this.value = 250000;
				this.toolTip = "增加100点最大法力值";
				this.toolTip2 = "增加12%魔法伤害和暴击率";
			}
			else if (this.type == 559)
			{
				this.name = "Hallowed Mask";
				this.CName = "神圣重盔";
				this.width = 18;
				this.height = 18;
				this.defense = 24;
				this.headSlot = 43;
				this.rare = 5;
				this.value = 250000;
				this.toolTip = "增加10%近战伤害和暴击率";
				this.toolTip2 = "增加10%近战攻速";
			}
			else if (this.type == 554)
			{
				this.name = "Cross Necklace";
				this.CName = "神圣十字项链";
				this.width = 20;
				this.height = 24;
				this.value = 1500;
				this.toolTip = "延长受到伤害后的无敌时间";
				this.accessory = true;
				this.rare = 4;
			}
			else if (this.type == 555)
			{
				this.name = "Mana Flower";
				this.CName = "魔法的礼物";
				this.width = 20;
				this.height = 24;
				this.value = 50000;
				this.toolTip = "使佩戴者减少8%魔力消耗";
				this.toolTip2 = "魔力耗尽时自动使用魔力药水";
				this.accessory = true;
				this.rare = 4;
			}
			else if (this.type == 556)
			{
				this.useStyle = 4;
				this.name = "Mechanical Worm";
				this.CName = "机械蠕虫";
				this.width = 22;
				this.height = 14;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.maxStack = 20;
				this.toolTip = "召唤机甲毁灭者";
				this.rare = 3;
			}
			else if (this.type == 557)
			{
				this.useStyle = 4;
				this.name = "Mechanical Skull";
				this.CName = "机械颅骨";
				this.width = 22;
				this.height = 14;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.maxStack = 20;
				this.toolTip = "召唤机甲终结者";
				this.rare = 3;
			}
			else if (this.type == 560)
			{
				this.useStyle = 4;
				this.name = "Slime Crown";
				this.CName = "史莱姆王冠";
				this.width = 22;
				this.height = 14;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.maxStack = 20;
				this.toolTip = "召唤史莱姆王";
				this.rare = 1;
			}
			else if (this.type == 561)
			{
				this.melee = true;
				this.autoReuse = true;
				this.noMelee = true;
				this.useStyle = 1;
				this.name = "Light Disc";
				this.CName = "光辉飞盘";
				this.shootSpeed = 13f;
				this.shoot = 106;
				this.damage = 35;
				this.knockBack = 8f;
				this.width = 24;
				this.height = 24;
				this.useSound = 1;
				this.useAnimation = 15;
				this.useTime = 15;
				this.noUseGraphic = true;
				this.rare = 5;
				this.maxStack = 5;
				this.value = 500000;
				this.toolTip = "只能叠放5个";
			}
			else if (this.type == 562)
			{
				this.name = "Music Box (Overworld Day)";
				this.CName = "八音盒（地表的清晨）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 0;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 563)
			{
				this.name = "Music Box (Eerie)";
				this.CName = "八音盒（恐惧）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 1;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 564)
			{
				this.name = "Music Box (Night)";
				this.CName = "八音盒（黑夜）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 2;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 565)
			{
				this.name = "Music Box (Title)";
				this.CName = "八音盒（世界初始）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 3;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 566)
			{
				this.name = "Music Box (Underground)";
				this.CName = "八音盒（地下居民）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 4;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 567)
			{
				this.name = "Music Box (Boss 1)";
				this.CName = "八音盒（全能窥探者）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 5;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 568)
			{
				this.name = "Music Box (Jungle)";
				this.CName = "八音盒（消失的丛林）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 6;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 569)
			{
				this.name = "Music Box (Corruption)";
				this.CName = "八音盒（腐化蔓延）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 7;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 570)
			{
				this.name = "Music Box (Underground Corruption)";
				this.CName = "八音盒（地底的黑暗）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 8;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 571)
			{
				this.name = "Music Box (The Hallow)";
				this.CName = "八音盒（圣域之歌）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 9;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 572)
			{
				this.name = "Music Box (Boss 2)";
				this.CName = "八音盒（世界毁灭者）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 10;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 573)
			{
				this.name = "Music Box (Underground Hallow)";
				this.CName = "八音盒（光明的信念）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 11;
				this.width = 24;
				this.height = 24;
				this.rare = 4;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 574)
			{
				this.name = "Music Box (Boss 3)";
				this.CName = "八音盒（深渊之主）";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.consumable = true;
				this.createTile = 139;
				this.placeStyle = 12;
				this.width = 24;
				this.height = 24;
				this.rare = 3;
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 575)
			{
				this.name = "Soul of Flight";
				this.CName = "飞翔之魂";
				this.width = 18;
				this.height = 18;
				this.maxStack = 250;
				this.value = 1000;
				this.rare = 3;
				this.toolTip = "'强大的飞行生物的精华'";
			}
			else if (this.type == 576)
			{
				this.name = "Music Box";
				this.CName = "八音盒";
				this.width = 24;
				this.height = 24;
				this.rare = 3;
				this.toolTip = "偶尔会录下音乐";
				this.value = 100000;
				this.accessory = true;
			}
			else if (this.type == 577)
			{
				this.name = "Demonite Brick";
				this.CName = "魔金砖";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 140;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 578)
			{
				this.useStyle = 5;
				this.autoReuse = true;
				this.useAnimation = 19;
				this.useTime = 19;
				this.name = "Hallowed Repeater";
				this.CName = "神圣连发弩";
				this.width = 50;
				this.height = 18;
				this.shoot = 1;
				this.useAmmo = 1;
				this.useSound = 5;
				this.damage = 39;
				this.shootSpeed = 11f;
				this.noMelee = true;
				this.value = 200000;
				this.ranged = true;
				this.rare = 4;
				this.knockBack = 2.5f;
			}
			else if (this.type == 579)
			{
				this.name = "Hamdrax";
				this.CName = "神金钻头";
				this.useStyle = 5;
				this.useAnimation = 25;
				this.useTime = 7;
				this.shootSpeed = 36f;
				this.knockBack = 4.75f;
				this.width = 20;
				this.height = 12;
				this.damage = 35;
				this.pick = 200;
				this.axe = 22;
				this.hammer = 85;
				this.useSound = 23;
				this.shoot = 107;
				this.rare = 4;
				this.value = 220000;
				this.noMelee = true;
				this.noUseGraphic = true;
				this.melee = true;
				this.channel = true;
				this.toolTip = "'传说中拆迁大队的标准装备'";
			}
			else if (this.type == 580)
			{
				this.mech = true;
				this.name = "Explosives";
				this.CName = "炸药";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 141;
				this.width = 12;
				this.height = 12;
				this.toolTip = "激活后会爆炸";
			}
			else if (this.type == 581)
			{
				this.mech = true;
				this.name = "Inlet Pump";
				this.CName = "入水泵";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 142;
				this.width = 12;
				this.height = 12;
				this.toolTip = "将液体送往出水泵";
			}
			else if (this.type == 582)
			{
				this.mech = true;
				this.name = "Outlet Pump";
				this.CName = "出水泵";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 143;
				this.width = 12;
				this.height = 12;
				this.toolTip = "放出从入水泵口进入的液体";
			}
			else if (this.type == 583)
			{
				this.mech = true;
				this.noWet = true;
				this.name = "1 Second Timer";
				this.CName = "1秒定时器";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 144;
				this.placeStyle = 0;
				this.width = 10;
				this.height = 12;
				this.value = 50;
				this.toolTip = "每秒触发一次";
			}
			else if (this.type == 584)
			{
				this.mech = true;
				this.noWet = true;
				this.name = "3 Second Timer";
				this.CName = "3秒定时器";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 144;
				this.placeStyle = 1;
				this.width = 10;
				this.height = 12;
				this.value = 50;
				this.toolTip = "每3秒触发一次";
			}
			else if (this.type == 585)
			{
				this.mech = true;
				this.noWet = true;
				this.name = "5 Second Timer";
				this.CName = "5秒定时器";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 99;
				this.consumable = true;
				this.createTile = 144;
				this.placeStyle = 2;
				this.width = 10;
				this.height = 12;
				this.value = 50;
				this.toolTip = "每5秒触发一次";
			}
			else if (this.type == 586)
			{
				this.name = "Candy Cane Block";
				this.CName = "拐杖糖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 145;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 587)
			{
				this.name = "Candy Cane Wall";
				this.CName = "拐杖糖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 29;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 588)
			{
				this.name = "Santa Hat";
				this.CName = "圣诞帽";
				this.width = 18;
				this.height = 12;
				this.headSlot = 44;
				this.value = 150000;
				this.vanity = true;
			}
			else if (this.type == 589)
			{
				this.name = "Santa Shirt";
				this.CName = "圣诞衬衫";
				this.width = 18;
				this.height = 18;
				this.bodySlot = 25;
				this.value = 150000;
				this.vanity = true;
			}
			else if (this.type == 590)
			{
				this.name = "Santa Pants";
				this.CName = "圣诞裤";
				this.width = 18;
				this.height = 18;
				this.legSlot = 24;
				this.value = 150000;
				this.vanity = true;
			}
			else if (this.type == 591)
			{
				this.name = "Green Candy Cane Block";
				this.CName = "绿色拐杖糖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 146;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 592)
			{
				this.name = "Green Candy Cane Wall";
				this.CName = "绿色拐杖糖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 30;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 593)
			{
				this.name = "Snow Block";
				this.CName = "雪块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 147;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 594)
			{
				this.name = "Snow Brick";
				this.CName = "雪砖块";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 148;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 595)
			{
				this.name = "Snow Brick Wall";
				this.CName = "雪砖墙";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createWall = 31;
				this.width = 12;
				this.height = 12;
			}
			else if (this.type == 596)
			{
				this.name = "Blue Light";
				this.CName = "蓝灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 149;
				this.placeStyle = 0;
				this.width = 12;
				this.height = 12;
				this.value = 500;
			}
			else if (this.type == 597)
			{
				this.name = "Red Light";
				this.CName = "红灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 149;
				this.placeStyle = 1;
				this.width = 12;
				this.height = 12;
				this.value = 500;
			}
			else if (this.type == 598)
			{
				this.name = "Green Light";
				this.CName = "绿灯";
				this.useStyle = 1;
				this.useTurn = true;
				this.useAnimation = 15;
				this.useTime = 10;
				this.autoReuse = true;
				this.maxStack = 250;
				this.consumable = true;
				this.createTile = 149;
				this.placeStyle = 2;
				this.width = 12;
				this.height = 12;
				this.value = 500;
			}
			else if (this.type == 599)
			{
				this.name = "Blue Present";
				this.CName = "蓝色礼物";
				this.width = 12;
				this.height = 12;
				this.rare = 1;
				this.toolTip = "右击打开";
			}
			else if (this.type == 600)
			{
				this.name = "Green Present";
				this.CName = "绿色礼物";
				this.width = 12;
				this.height = 12;
				this.rare = 1;
				this.toolTip = "右击打开";
			}
			else if (this.type == 601)
			{
				this.name = "Yellow Present";
				this.CName = "黄色礼物";
				this.width = 12;
				this.height = 12;
				this.rare = 1;
				this.toolTip = "右击打开";
			}
			else if (this.type == 602)
			{
				this.name = "Snow Globe";
				this.CName = "雪景球";
				this.useStyle = 4;
				this.consumable = true;
				this.useAnimation = 45;
				this.useTime = 45;
				this.width = 28;
				this.height = 28;
				this.toolTip = "召唤霜之军团";
				this.rare = 2;
			}
			if (!noMatCheck)
			{
				this.checkMat();
			}
			this.netID = this.type;
		}

		public static string VersionName(string oldName, int release)
		{
			string result = oldName;
			if (release <= 4)
			{
				if (oldName == "Cobalt Helmet")
				{
					result = "Jungle Hat";
				}
				else if (oldName == "Cobalt Breastplate")
				{
					result = "Jungle Shirt";
				}
				else if (oldName == "Cobalt Greaves")
				{
					result = "Jungle Pants";
				}
			}
			if (release <= 13 && oldName == "Jungle Rose")
			{
				result = "Jungle Spores";
			}
			if (release <= 20)
			{
				if (oldName == "Gills potion")
				{
					result = "Gills Potion";
				}
				else if (oldName == "Thorn Chakrum")
				{
					result = "Thorn Chakram";
				}
				else if (oldName == "Ball 'O Hurt")
				{
					result = "Ball O' Hurt";
				}
			}
			return result;
		}

		public Color GetAlpha(Color newColor)
		{
			Color result;
			if (this.type == 75)
			{
				result = new Color(255, 255, 255, (int)newColor.A - this.alpha);
			}
			else if (this.type == 121 || this.type == 122 || this.type == 217 || this.type == 218 || this.type == 219 || this.type == 220 || this.type == 120 || this.type == 119)
			{
				result = new Color(255, 255, 255, 255);
			}
			else if (this.type == 501)
			{
				result = new Color(200, 200, 200, 50);
			}
			else if (this.type == 520 || this.type == 521 || this.type == 522 || this.type == 547 || this.type == 548 || this.type == 549 || this.type == 575)
			{
				result = new Color(255, 255, 255, 50);
			}
			else if (this.type == 58 || this.type == 184)
			{
				result = new Color(200, 200, 200, 2000);
			}
			else
			{
				float num = (float)(255 - this.alpha) / 255f;
				int r = (int)((float)newColor.R * num);
				int g = (int)((float)newColor.G * num);
				int b = (int)((float)newColor.B * num);
				int num2 = (int)newColor.A - this.alpha;
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (this.type >= 198 && this.type <= 203)
				{
					result = Color.White;
				}
				else
				{
					result = new Color(r, g, b, num2);
				}
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

		public static bool MechSpawn(float x, float y, int type)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.item[i].active && Main.item[i].type == type)
				{
					num++;
					Vector2 vector = new Vector2(x, y);
					float num4 = Main.item[i].position.X - vector.X;
					float num5 = Main.item[i].position.Y - vector.Y;
					float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
					if (num6 < 300f)
					{
						num2++;
					}
					if (num6 < 800f)
					{
						num3++;
					}
				}
			}
			return num2 < 3 && num3 < 6 && num < 10;
		}

		public void UpdateItem(int i)
		{
			if (this.active)
			{
				if (Main.netMode == 0)
				{
					this.owner = Main.myPlayer;
				}
				float num = 0.1f;
				float num2 = 7f;
				int num3 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int num4 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
				if (Main.tile[num3, num4] == null)
				{
					num = 0f;
					this.velocity.X = 0f;
					this.velocity.Y = 0f;
				}
				if (this.wet)
				{
					num2 = 5f;
					num = 0.08f;
				}
				Vector2 value = this.velocity * 0.5f;
				if (this.ownTime > 0)
				{
					this.ownTime--;
				}
				else
				{
					this.ownIgnore = -1;
				}
				if (this.keepTime > 0)
				{
					this.keepTime--;
				}
				if (!this.beingGrabbed)
				{
					if (this.type == 520 || this.type == 521 || this.type == 547 || this.type == 548 || this.type == 549 || this.type == 575)
					{
						this.velocity.X = this.velocity.X * 0.95f;
						if ((double)this.velocity.X < 0.1 && (double)this.velocity.X > -0.1)
						{
							this.velocity.X = 0f;
						}
						this.velocity.Y = this.velocity.Y * 0.95f;
						if ((double)this.velocity.Y < 0.1 && (double)this.velocity.Y > -0.1)
						{
							this.velocity.Y = 0f;
						}
					}
					else
					{
						this.velocity.Y = this.velocity.Y + num;
						if (this.velocity.Y > num2)
						{
							this.velocity.Y = num2;
						}
						this.velocity.X = this.velocity.X * 0.95f;
						if ((double)this.velocity.X < 0.1 && (double)this.velocity.X > -0.1)
						{
							this.velocity.X = 0f;
						}
					}
					bool flag = Collision.LavaCollision(this.position, this.width, this.height);
					if (flag)
					{
						this.lavaWet = true;
					}
					bool flag2 = Collision.WetCollision(this.position, this.width, this.height);
					if (flag2)
					{
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 20;
								if (!flag)
								{
									for (int j = 0; j < 10; j++)
									{
										int num5 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
										Dust dust = Main.dust[num5];
										dust.velocity.Y = dust.velocity.Y - 4f;
										Dust dust2 = Main.dust[num5];
										dust2.velocity.X = dust2.velocity.X * 2.5f;
										Main.dust[num5].scale = 1.3f;
										Main.dust[num5].alpha = 100;
										Main.dust[num5].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int k = 0; k < 5; k++)
									{
										int num6 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust dust3 = Main.dust[num6];
										dust3.velocity.Y = dust3.velocity.Y - 1.5f;
										Dust dust4 = Main.dust[num6];
										dust4.velocity.X = dust4.velocity.X * 2.5f;
										Main.dust[num6].scale = 1.3f;
										Main.dust[num6].alpha = 100;
										Main.dust[num6].noGravity = true;
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
					}
					if (!this.wet)
					{
						this.lavaWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
					if (this.wet)
					{
						if (this.wet)
						{
							Vector2 vector = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
							if (this.velocity.X != vector.X)
							{
								value.X = this.velocity.X;
							}
							if (this.velocity.Y != vector.Y)
							{
								value.Y = this.velocity.Y;
							}
						}
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
					}
					if (this.lavaWet)
					{
						if (this.type == 267)
						{
							if (Main.netMode != 1)
							{
								this.active = false;
								this.type = 0;
								this.name = "";
								this.stack = 0;
								for (int l = 0; l < 200; l++)
								{
									if (Main.npc[l].active && Main.npc[l].type == 22)
									{
										if (Main.netMode == 2)
										{
											NetMessage.SendData(28, -1, -1, "", l, 9999f, 10f, -(float)Main.npc[l].direction, 0);
										}
										Main.npc[l].StrikeNPC(9999, 10f, -Main.npc[l].direction, false, false);
										NPC.SpawnWOF(this.position);
									}
								}
								NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0);
							}
						}
						else if (this.owner == Main.myPlayer && this.type != 312 && this.type != 318 && this.type != 173 && this.type != 174 && this.type != 175 && this.rare == 0)
						{
							this.active = false;
							this.type = 0;
							this.name = "";
							this.stack = 0;
							if (Main.netMode != 0)
							{
								NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0);
							}
						}
					}
					if (this.type == 520)
					{
						float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
						num7 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.5f * num7, 0.1f * num7, 0.25f * num7);
					}
					else if (this.type == 521)
					{
						float num8 = (float)Main.rand.Next(90, 111) * 0.01f;
						num8 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.25f * num8, 0.1f * num8, 0.5f * num8);
					}
					else if (this.type == 547)
					{
						float num9 = (float)Main.rand.Next(90, 111) * 0.01f;
						num9 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.5f * num9, 0.3f * num9, 0.05f * num9);
					}
					else if (this.type == 548)
					{
						float num10 = (float)Main.rand.Next(90, 111) * 0.01f;
						num10 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.1f * num10, 0.1f * num10, 0.6f * num10);
					}
					else if (this.type == 575)
					{
						float num11 = (float)Main.rand.Next(90, 111) * 0.01f;
						num11 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.1f * num11, 0.3f * num11, 0.5f * num11);
					}
					else if (this.type == 549)
					{
						float num12 = (float)Main.rand.Next(90, 111) * 0.01f;
						num12 *= Main.essScale;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.1f * num12, 0.5f * num12, 0.2f * num12);
					}
					else if (this.type == 58)
					{
						float num13 = (float)Main.rand.Next(90, 111) * 0.01f;
						num13 *= Main.essScale * 0.5f;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.5f * num13, 0.1f * num13, 0.1f * num13);
					}
					else if (this.type == 184)
					{
						float num14 = (float)Main.rand.Next(90, 111) * 0.01f;
						num14 *= Main.essScale * 0.5f;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.1f * num14, 0.1f * num14, 0.5f * num14);
					}
					else if (this.type == 522)
					{
						float num15 = (float)Main.rand.Next(90, 111) * 0.01f;
						num15 *= Main.essScale * 0.2f;
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.5f * num15, 1f * num15, 0.1f * num15);
					}
					if (this.type == 75 && Main.dayTime)
					{
						for (int m = 0; m < 10; m++)
						{
							Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X, this.velocity.Y, 150, default(Color), 1.2f);
						}
						for (int n = 0; n < 3; n++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X, this.velocity.Y), Main.rand.Next(16, 18), 1f);
						}
						this.active = false;
						this.type = 0;
						this.stack = 0;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0);
						}
					}
				}
				else
				{
					this.beingGrabbed = false;
				}
				if (this.type == 501)
				{
					if (Main.rand.Next(6) == 0)
					{
						int num16 = Dust.NewDust(this.position, this.width, this.height, 55, 0f, 0f, 200, this.color, 1f);
						Dust dust5 = Main.dust[num16];
						dust5.velocity *= 0.3f;
						Main.dust[num16].scale *= 0.5f;
					}
				}
				else if (this.type == 8 || this.type == 105)
				{
					if (!this.wet)
					{
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 1f, 0.95f, 0.8f);
					}
				}
				else if (this.type == 523)
				{
					Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.85f, 1f, 0.7f);
				}
				else if (this.type >= 427 && this.type <= 432)
				{
					if (!this.wet)
					{
						float r = 0f;
						float g = 0f;
						float b = 0f;
						int num17 = this.type - 426;
						if (num17 == 1)
						{
							r = 0.1f;
							g = 0.2f;
							b = 1.1f;
						}
						if (num17 == 2)
						{
							r = 1f;
							g = 0.1f;
							b = 0.1f;
						}
						if (num17 == 3)
						{
							r = 0f;
							g = 1f;
							b = 0.1f;
						}
						if (num17 == 4)
						{
							r = 0.9f;
							g = 0f;
							b = 0.9f;
						}
						if (num17 == 5)
						{
							r = 1.3f;
							g = 1.3f;
							b = 1.3f;
						}
						if (num17 == 6)
						{
							r = 0.9f;
							g = 0.9f;
							b = 0f;
						}
						Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), r, g, b);
					}
				}
				else if (this.type == 41)
				{
					if (!this.wet)
					{
						Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 1f, 0.75f, 0.55f);
					}
				}
				else if (this.type == 282)
				{
					Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.7f, 1f, 0.8f);
				}
				else if (this.type == 286)
				{
					Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.7f, 0.8f, 1f);
				}
				else if (this.type == 331)
				{
					Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.55f, 0.75f, 0.6f);
				}
				else if (this.type == 183)
				{
					Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.15f, 0.45f, 0.9f);
				}
				else if (this.type == 75)
				{
					Lighting.addLight((int)((this.position.X + (float)this.width) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), 0.8f, 0.7f, 0.1f);
				}
				if (this.type == 75)
				{
					if (Main.rand.Next(25) == 0)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.2f);
					}
					if (Main.rand.Next(50) == 0)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
					}
				}
				if (this.spawnTime < 2147483646)
				{
					this.spawnTime++;
				}
				if (Main.netMode == 2 && this.owner != Main.myPlayer)
				{
					this.release++;
					if (this.release >= 300)
					{
						this.release = 0;
						NetMessage.SendData(39, this.owner, -1, "", i, 0f, 0f, 0f, 0);
					}
				}
				if (this.wet)
				{
					this.position += value;
				}
				else
				{
					this.position += this.velocity;
				}
				if (this.noGrabDelay > 0)
				{
					this.noGrabDelay--;
				}
			}
		}

		public static int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int pfix = 0)
		{
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			int result;
			if (WorldGen.gen)
			{
				result = 0;
			}
			else
			{
				int num = 200;
				Main.item[200] = new Item();
				if (Main.netMode != 1)
				{
					for (int i = 0; i < 200; i++)
					{
						if (!Main.item[i].active)
						{
							num = i;
							break;
						}
					}
				}
				if (num == 200 && Main.netMode != 1)
				{
					int num2 = 0;
					for (int j = 0; j < 200; j++)
					{
						if (Main.item[j].spawnTime > num2)
						{
							num2 = Main.item[j].spawnTime;
							num = j;
						}
					}
				}
				Main.item[num] = new Item();
				Main.item[num].SetDefaults(Type, false);
				Main.item[num].Prefix(pfix);
				Main.item[num].position.X = (float)(X + Width / 2 - Main.item[num].width / 2);
				Main.item[num].position.Y = (float)(Y + Height / 2 - Main.item[num].height / 2);
				Main.item[num].wet = Collision.WetCollision(Main.item[num].position, Main.item[num].width, Main.item[num].height);
				Main.item[num].velocity.X = (float)Main.rand.Next(-30, 31) * 0.1f;
				Main.item[num].velocity.Y = (float)Main.rand.Next(-40, -15) * 0.1f;
				if (Type == 520 || Type == 521)
				{
					Main.item[num].velocity.X = (float)Main.rand.Next(-30, 31) * 0.1f;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-30, 31) * 0.1f;
				}
				Main.item[num].active = true;
				Main.item[num].spawnTime = 0;
				Main.item[num].stack = Stack;
				if (Main.netMode == 2 && !noBroadcast)
				{
					NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					Main.item[num].FindOwner(num);
				}
				else if (Main.netMode == 0)
				{
					Main.item[num].owner = Main.myPlayer;
				}
				result = num;
			}
			return result;
		}

		public void FindOwner(int whoAmI)
		{
			if (this.keepTime <= 0)
			{
				int num = this.owner;
				this.owner = 255;
				float num2 = -1f;
				for (int i = 0; i < 255; i++)
				{
					if (this.ownIgnore != i && Main.player[i].active && Main.player[i].ItemSpace(Main.item[whoAmI]))
					{
						float num3 = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - this.position.X - (float)(this.width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - this.position.Y - (float)this.height);
						if (num3 < (float)NPC.sWidth && (num2 == -1f || num3 < num2))
						{
							num2 = num3;
							this.owner = i;
						}
					}
				}
				if (this.owner != num && ((num == Main.myPlayer && Main.netMode == 1) || (num == 255 && Main.netMode == 2) || !Main.player[num].active))
				{
					NetMessage.SendData(21, -1, -1, "", whoAmI, 0f, 0f, 0f, 0);
					if (this.active)
					{
						NetMessage.SendData(22, -1, -1, "", whoAmI, 0f, 0f, 0f, 0);
					}
				}
			}
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		public bool IsTheSameAs(Item compareItem)
		{
			return this.name == compareItem.name;
		}

		public bool IsNotTheSameAs(Item compareItem)
		{
			return this.name != compareItem.name || this.stack != compareItem.stack || this.prefix != compareItem.prefix;
		}
	}
}
