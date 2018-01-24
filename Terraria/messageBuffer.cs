using System;
using System.Text;

namespace Terraria
{
	public class messageBuffer
	{
		public const int readBufferMax = 65535;

		public const int writeBufferMax = 65535;

		public bool broadcast;

		public byte[] readBuffer = new byte[65535];

		public byte[] writeBuffer = new byte[65535];

		public bool writeLocked;

		public int messageLength;

		public int totalData;

		public int whoAmI;

		public int spamCount;

		public int maxSpam;

		public bool checkBytes;

		public void Reset()
		{
			this.writeBuffer = new byte[65535];
			this.writeLocked = false;
			this.messageLength = 0;
			this.totalData = 0;
			this.spamCount = 0;
			this.broadcast = false;
			this.checkBytes = false;
		}

		public void GetData(int start, int length)
		{
			if (this.whoAmI < 256)
			{
				Netplay.serverSock[this.whoAmI].timeOut = 0;
			}
			else
			{
				Netplay.clientSock.timeOut = 0;
			}
			int num = start + 1;
			byte b = this.readBuffer[start];
			Main.rxMsg++;
			Main.rxData += length;
			Main.rxMsgType[(int)b]++;
			Main.rxDataType[(int)b] += length;
			if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
			{
				Netplay.clientSock.statusCount++;
			}
			if (Main.verboseNetplay)
			{
				for (int i = start; i < start + length; i++)
				{
				}
				for (int j = start; j < start + length; j++)
				{
					byte b2 = this.readBuffer[j];
				}
			}
			if (Main.netMode == 2 && b != 38 && Netplay.serverSock[this.whoAmI].state == -1)
			{
				NetMessage.SendData(2, this.whoAmI, -1, "密码不正确", 0, 0f, 0f, 0f, 0);
			}
			else
			{
				if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state < 10 && b > 12 && b != 16 && b != 42 && b != 50 && b != 38)
				{
					NetMessage.BootPlayer(this.whoAmI, "无效操作");
				}
				if (b == 1 && Main.netMode == 2)
				{
					if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
					{
						NetMessage.SendData(2, this.whoAmI, -1, "你在服务器的黑名单中", 0, 0f, 0f, 0f, 0);
					}
					else if (Netplay.serverSock[this.whoAmI].state == 0)
					{
						string @string = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
						if (!(@string == "Terraria" + Main.curRelease))
						{
							NetMessage.SendData(2, this.whoAmI, -1, "客户端版本号不符", 0, 0f, 0f, 0f, 0);
						}
						else if (Netplay.password == null || Netplay.password == "")
						{
							Netplay.serverSock[this.whoAmI].state = 1;
							NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
						}
						else
						{
							Netplay.serverSock[this.whoAmI].state = -1;
							NetMessage.SendData(37, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
						}
					}
				}
				else if (b == 2 && Main.netMode == 1)
				{
					Netplay.disconnect = true;
					Main.statusText = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
				}
				else if (b == 3 && Main.netMode == 1)
				{
					if (Netplay.clientSock.state == 1)
					{
						Netplay.clientSock.state = 2;
					}
					int num2 = (int)this.readBuffer[start + 1];
					if (num2 != Main.myPlayer)
					{
						Main.player[num2] = (Player)Main.player[Main.myPlayer].Clone();
						Main.player[Main.myPlayer] = new Player();
						Main.player[num2].whoAmi = num2;
						Main.myPlayer = num2;
					}
					NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					for (int k = 0; k < 49; k++)
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
					}
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
					NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0);
					if (Netplay.clientSock.state == 2)
					{
						Netplay.clientSock.state = 3;
					}
				}
				else if (b == 4)
				{
					bool flag = false;
					int num3 = (int)this.readBuffer[start + 1];
					if (Main.netMode == 2)
					{
						num3 = this.whoAmI;
					}
					if (num3 != Main.myPlayer)
					{
						int num4 = (int)this.readBuffer[start + 2];
						if (num4 >= 36)
						{
							num4 = 0;
						}
						Main.player[num3].hair = num4;
						Main.player[num3].whoAmi = num3;
						num += 2;
						byte b3 = this.readBuffer[num];
						num++;
						if (b3 == 1)
						{
							Main.player[num3].male = true;
						}
						else
						{
							Main.player[num3].male = false;
						}
						Main.player[num3].hairColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].hairColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].hairColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].skinColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].skinColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].skinColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].eyeColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].eyeColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].eyeColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].shirtColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].shirtColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].shirtColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].underShirtColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].underShirtColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].underShirtColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].pantsColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].pantsColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].pantsColor.B = this.readBuffer[num];
						num++;
						Main.player[num3].shoeColor.R = this.readBuffer[num];
						num++;
						Main.player[num3].shoeColor.G = this.readBuffer[num];
						num++;
						Main.player[num3].shoeColor.B = this.readBuffer[num];
						num++;
						byte difficulty = this.readBuffer[num];
						Main.player[num3].difficulty = difficulty;
						num++;
						string text = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
						text = text.Trim();
						Main.player[num3].name = text.Trim();
						if (Main.netMode == 2)
						{
							if (Netplay.serverSock[this.whoAmI].state < 10)
							{
								for (int l = 0; l < 255; l++)
								{
									if (l != num3 && text == Main.player[l].name && Netplay.serverSock[l].active)
									{
										flag = true;
									}
								}
							}
							if (flag)
							{
								NetMessage.SendData(2, this.whoAmI, -1, text + "已经登录该服务器", 0, 0f, 0f, 0f, 0);
							}
							else if (text.Length > Player.nameLen)
							{
								NetMessage.SendData(2, this.whoAmI, -1, "名字太长了", 0, 0f, 0f, 0f, 0);
							}
							else if (text == "")
							{
								NetMessage.SendData(2, this.whoAmI, -1, "名字不能为空", 0, 0f, 0f, 0f, 0);
							}
							else
							{
								Netplay.serverSock[this.whoAmI].oldName = text;
								Netplay.serverSock[this.whoAmI].name = text;
								NetMessage.SendData(4, -1, this.whoAmI, text, num3, 0f, 0f, 0f, 0);
							}
						}
					}
				}
				else
				{
					if (b == 5)
					{
						int num5 = (int)this.readBuffer[start + 1];
						if (Main.netMode == 2)
						{
							num5 = this.whoAmI;
						}
						if (num5 == Main.myPlayer)
						{
							return;
						}
						lock (Main.player[num5])
						{
							int num6 = (int)this.readBuffer[start + 2];
							int stack = (int)this.readBuffer[start + 3];
							byte b4 = this.readBuffer[start + 4];
							int type = (int)BitConverter.ToInt16(this.readBuffer, start + 5);
							if (num6 < 49)
							{
								Main.player[num5].inventory[num6] = new Item();
								Main.player[num5].inventory[num6].netDefaults(type);
								Main.player[num5].inventory[num6].stack = stack;
								Main.player[num5].inventory[num6].Prefix((int)b4);
							}
							else
							{
								Main.player[num5].armor[num6 - 48 - 1] = new Item();
								Main.player[num5].armor[num6 - 48 - 1].netDefaults(type);
								Main.player[num5].armor[num6 - 48 - 1].stack = stack;
								Main.player[num5].armor[num6 - 48 - 1].Prefix((int)b4);
							}
							if (Main.netMode == 2 && num5 == this.whoAmI)
							{
								NetMessage.SendData(5, -1, this.whoAmI, "", num5, (float)num6, (float)b4, 0f, 0);
							}
							return;
						}
					}
					if (b == 6)
					{
						if (Main.netMode == 2)
						{
							if (Netplay.serverSock[this.whoAmI].state == 1)
							{
								Netplay.serverSock[this.whoAmI].state = 2;
							}
							NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 7)
					{
						if (Main.netMode == 1)
						{
							Main.time = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.dayTime = false;
							if (this.readBuffer[num] == 1)
							{
								Main.dayTime = true;
							}
							num++;
							Main.moonPhase = (int)this.readBuffer[num];
							num++;
							int num7 = (int)this.readBuffer[num];
							num++;
							if (num7 == 1)
							{
								Main.bloodMoon = true;
							}
							else
							{
								Main.bloodMoon = false;
							}
							Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.worldSurface = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.rockLayer = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.worldID = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							byte b5 = this.readBuffer[num];
							if ((b5 & 1) == 1)
							{
								WorldGen.shadowOrbSmashed = true;
							}
							if ((b5 & 2) == 2)
							{
								NPC.downedBoss1 = true;
							}
							if ((b5 & 4) == 4)
							{
								NPC.downedBoss2 = true;
							}
							if ((b5 & 8) == 8)
							{
								NPC.downedBoss3 = true;
							}
							if ((b5 & 16) == 16)
							{
								Main.hardMode = true;
							}
							if ((b5 & 32) == 32)
							{
								NPC.downedClown = true;
							}
							num++;
							Main.worldName = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							if (Netplay.clientSock.state == 3)
							{
								Netplay.clientSock.state = 4;
							}
						}
					}
					else if (b == 8)
					{
						if (Main.netMode == 2)
						{
							int num8 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num9 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							bool flag3 = true;
							if (num8 == -1 || num9 == -1)
							{
								flag3 = false;
							}
							else if (num8 < 10 || num8 > Main.maxTilesX - 10)
							{
								flag3 = false;
							}
							else if (num9 < 10 || num9 > Main.maxTilesY - 10)
							{
								flag3 = false;
							}
							int num10 = 1350;
							if (flag3)
							{
								num10 *= 2;
							}
							if (Netplay.serverSock[this.whoAmI].state == 2)
							{
								Netplay.serverSock[this.whoAmI].state = 3;
							}
							NetMessage.SendData(9, this.whoAmI, -1, "接收物块数据", num10, 0f, 0f, 0f, 0);
							Netplay.serverSock[this.whoAmI].statusText2 = "正在接收物块数据";
							Netplay.serverSock[this.whoAmI].statusMax += num10;
							int sectionX = Netplay.GetSectionX(Main.spawnTileX);
							int sectionY = Netplay.GetSectionY(Main.spawnTileY);
							for (int m = sectionX - 2; m < sectionX + 3; m++)
							{
								for (int n = sectionY - 1; n < sectionY + 2; n++)
								{
									NetMessage.SendSection(this.whoAmI, m, n);
								}
							}
							if (flag3)
							{
								num8 = Netplay.GetSectionX(num8);
								num9 = Netplay.GetSectionY(num9);
								for (int num11 = num8 - 2; num11 < num8 + 3; num11++)
								{
									for (int num12 = num9 - 1; num12 < num9 + 2; num12++)
									{
										NetMessage.SendSection(this.whoAmI, num11, num12);
									}
								}
								NetMessage.SendData(11, this.whoAmI, -1, "", num8 - 2, (float)(num9 - 1), (float)(num8 + 2), (float)(num9 + 1), 0);
							}
							NetMessage.SendData(11, this.whoAmI, -1, "", sectionX - 2, (float)(sectionY - 1), (float)(sectionX + 2), (float)(sectionY + 1), 0);
							for (int num13 = 0; num13 < 200; num13++)
							{
								if (Main.item[num13].active)
								{
									NetMessage.SendData(21, this.whoAmI, -1, "", num13, 0f, 0f, 0f, 0);
									NetMessage.SendData(22, this.whoAmI, -1, "", num13, 0f, 0f, 0f, 0);
								}
							}
							for (int num14 = 0; num14 < 200; num14++)
							{
								if (Main.npc[num14].active)
								{
									NetMessage.SendData(23, this.whoAmI, -1, "", num14, 0f, 0f, 0f, 0);
								}
							}
							NetMessage.SendData(49, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							NetMessage.SendData(57, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 17, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 18, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 19, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 20, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 22, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 38, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 54, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 107, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 108, 0f, 0f, 0f, 0);
							NetMessage.SendData(56, this.whoAmI, -1, "", 124, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 9)
					{
						if (Main.netMode == 1)
						{
							int num15 = BitConverter.ToInt32(this.readBuffer, start + 1);
							string string2 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
							Netplay.clientSock.statusMax += num15;
							Netplay.clientSock.statusText = string2;
						}
					}
					else if (b == 10 && Main.netMode == 1)
					{
						short num16 = BitConverter.ToInt16(this.readBuffer, start + 1);
						int num17 = BitConverter.ToInt32(this.readBuffer, start + 3);
						int num18 = BitConverter.ToInt32(this.readBuffer, start + 7);
						num = start + 11;
						for (int num19 = num17; num19 < num17 + (int)num16; num19++)
						{
							if (Main.tile[num19, num18] == null)
							{
								Main.tile[num19, num18] = new Tile();
							}
							byte b6 = this.readBuffer[num];
							num++;
							bool active = Main.tile[num19, num18].active;
							if ((b6 & 1) == 1)
							{
								Main.tile[num19, num18].active = true;
							}
							else
							{
								Main.tile[num19, num18].active = false;
							}
							byte b7 = (byte)(b6 & 2);
							if ((b6 & 4) == 4)
							{
								Main.tile[num19, num18].wall = 1;
							}
							else
							{
								Main.tile[num19, num18].wall = 0;
							}
							if ((b6 & 8) == 8)
							{
								Main.tile[num19, num18].liquid = 1;
							}
							else
							{
								Main.tile[num19, num18].liquid = 0;
							}
							if ((b6 & 16) == 16)
							{
								Main.tile[num19, num18].wire = true;
							}
							else
							{
								Main.tile[num19, num18].wire = false;
							}
							if (Main.tile[num19, num18].active)
							{
								int type2 = (int)Main.tile[num19, num18].type;
								Main.tile[num19, num18].type = this.readBuffer[num];
								num++;
								if (Main.tileFrameImportant[(int)Main.tile[num19, num18].type])
								{
									Main.tile[num19, num18].frameX = BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									Main.tile[num19, num18].frameY = BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
								}
								else if (!active || (int)Main.tile[num19, num18].type != type2)
								{
									Main.tile[num19, num18].frameX = -1;
									Main.tile[num19, num18].frameY = -1;
								}
							}
							if (Main.tile[num19, num18].wall > 0)
							{
								Main.tile[num19, num18].wall = this.readBuffer[num];
								num++;
							}
							if (Main.tile[num19, num18].liquid > 0)
							{
								Main.tile[num19, num18].liquid = this.readBuffer[num];
								num++;
								byte b8 = this.readBuffer[num];
								num++;
								if (b8 == 1)
								{
									Main.tile[num19, num18].lava = true;
								}
								else
								{
									Main.tile[num19, num18].lava = false;
								}
							}
							short num20 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							int num21 = num19;
							while (num20 > 0)
							{
								num21++;
								num20 -= 1;
								if (Main.tile[num21, num18] == null)
								{
									Main.tile[num21, num18] = new Tile();
								}
								Main.tile[num21, num18].active = Main.tile[num19, num18].active;
								Main.tile[num21, num18].type = Main.tile[num19, num18].type;
								Main.tile[num21, num18].wall = Main.tile[num19, num18].wall;
								Main.tile[num21, num18].wire = Main.tile[num19, num18].wire;
								if (Main.tileFrameImportant[(int)Main.tile[num21, num18].type])
								{
									Main.tile[num21, num18].frameX = Main.tile[num19, num18].frameX;
									Main.tile[num21, num18].frameY = Main.tile[num19, num18].frameY;
								}
								else
								{
									Main.tile[num21, num18].frameX = -1;
									Main.tile[num21, num18].frameY = -1;
								}
								Main.tile[num21, num18].liquid = Main.tile[num19, num18].liquid;
								Main.tile[num21, num18].lava = Main.tile[num19, num18].lava;
							}
							num19 = num21;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)b, -1, this.whoAmI, "", (int)num16, (float)num17, (float)num18, 0f, 0);
						}
					}
					else if (b == 11)
					{
						if (Main.netMode == 1)
						{
							int startX = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 4;
							int startY = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 4;
							int endX = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 4;
							int endY = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 4;
							WorldGen.SectionTileFrame(startX, startY, endX, endY);
						}
					}
					else if (b == 12)
					{
						int num22 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num22 = this.whoAmI;
						}
						num++;
						Main.player[num22].SpawnX = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						Main.player[num22].SpawnY = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						Main.player[num22].Spawn();
						if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state >= 3)
						{
							if (Netplay.serverSock[this.whoAmI].state == 3)
							{
								Netplay.serverSock[this.whoAmI].state = 10;
								NetMessage.greetPlayer(this.whoAmI);
								NetMessage.buffer[this.whoAmI].broadcast = true;
								NetMessage.syncPlayers();
								NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
							}
							else
							{
								NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 13)
					{
						int num23 = (int)this.readBuffer[num];
						if (num23 != Main.myPlayer)
						{
							if (Main.netMode == 1)
							{
								bool active2 = Main.player[num23].active;
							}
							if (Main.netMode == 2)
							{
								num23 = this.whoAmI;
							}
							num++;
							int num24 = (int)this.readBuffer[num];
							num++;
							int selectedItem = (int)this.readBuffer[num];
							num++;
							float x = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float num25 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float x2 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							Main.player[num23].selectedItem = selectedItem;
							Main.player[num23].position.X = x;
							Main.player[num23].position.Y = num25;
							Main.player[num23].velocity.X = x2;
							Main.player[num23].velocity.Y = y;
							Main.player[num23].oldVelocity = Main.player[num23].velocity;
							Main.player[num23].fallStart = (int)(num25 / 16f);
							Main.player[num23].controlUp = false;
							Main.player[num23].controlDown = false;
							Main.player[num23].controlLeft = false;
							Main.player[num23].controlRight = false;
							Main.player[num23].controlJump = false;
							Main.player[num23].controlUseItem = false;
							Main.player[num23].direction = -1;
							if ((num24 & 1) == 1)
							{
								Main.player[num23].controlUp = true;
							}
							if ((num24 & 2) == 2)
							{
								Main.player[num23].controlDown = true;
							}
							if ((num24 & 4) == 4)
							{
								Main.player[num23].controlLeft = true;
							}
							if ((num24 & 8) == 8)
							{
								Main.player[num23].controlRight = true;
							}
							if ((num24 & 16) == 16)
							{
								Main.player[num23].controlJump = true;
							}
							if ((num24 & 32) == 32)
							{
								Main.player[num23].controlUseItem = true;
							}
							if ((num24 & 64) == 64)
							{
								Main.player[num23].direction = 1;
							}
							if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state == 10)
							{
								NetMessage.SendData(13, -1, this.whoAmI, "", num23, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 14)
					{
						if (Main.netMode == 1)
						{
							int num26 = (int)this.readBuffer[num];
							num++;
							int num27 = (int)this.readBuffer[num];
							if (num27 == 1)
							{
								if (!Main.player[num26].active)
								{
									Main.player[num26] = new Player();
								}
								Main.player[num26].active = true;
							}
							else
							{
								Main.player[num26].active = false;
							}
						}
					}
					else if (b == 15)
					{
						if (Main.netMode == 2)
						{
						}
					}
					else if (b == 16)
					{
						int num28 = (int)this.readBuffer[num];
						num++;
						if (num28 != Main.myPlayer)
						{
							int statLife = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							int statLifeMax = (int)BitConverter.ToInt16(this.readBuffer, num);
							if (Main.netMode == 2)
							{
								num28 = this.whoAmI;
							}
							Main.player[num28].statLife = statLife;
							Main.player[num28].statLifeMax = statLifeMax;
							if (Main.player[num28].statLife <= 0)
							{
								Main.player[num28].dead = true;
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(16, -1, this.whoAmI, "", num28, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 17)
					{
						byte b9 = this.readBuffer[num];
						num++;
						int num29 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						int num30 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						byte b10 = this.readBuffer[num];
						num++;
						int num31 = (int)this.readBuffer[num];
						bool flag4 = false;
						if (b10 == 1)
						{
							flag4 = true;
						}
						if (Main.tile[num29, num30] == null)
						{
							Main.tile[num29, num30] = new Tile();
						}
						if (Main.netMode == 2)
						{
							if (!flag4)
							{
								if (b9 == 0 || b9 == 2 || b9 == 4)
								{
									Netplay.serverSock[this.whoAmI].spamDelBlock += 1f;
								}
								else if (b9 == 1 || b9 == 3)
								{
									Netplay.serverSock[this.whoAmI].spamAddBlock += 1f;
								}
							}
							if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(num29), Netplay.GetSectionY(num30)])
							{
								flag4 = true;
							}
						}
						if (b9 == 0)
						{
							WorldGen.KillTile(num29, num30, flag4, false, false);
						}
						else if (b9 == 1)
						{
							WorldGen.PlaceTile(num29, num30, (int)b10, false, true, -1, num31);
						}
						else if (b9 == 2)
						{
							WorldGen.KillWall(num29, num30, flag4);
						}
						else if (b9 == 3)
						{
							WorldGen.PlaceWall(num29, num30, (int)b10, false);
						}
						else if (b9 == 4)
						{
							WorldGen.KillTile(num29, num30, flag4, false, true);
						}
						else if (b9 == 5)
						{
							WorldGen.PlaceWire(num29, num30);
						}
						else if (b9 == 6)
						{
							WorldGen.KillWire(num29, num30);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(17, -1, this.whoAmI, "", (int)b9, (float)num29, (float)num30, (float)b10, num31);
							if (b9 == 1 && b10 == 53)
							{
								NetMessage.SendTileSquare(-1, num29, num30, 1);
							}
						}
					}
					else if (b == 18)
					{
						if (Main.netMode == 1)
						{
							byte b11 = this.readBuffer[num];
							num++;
							int num32 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							short sunModY = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							short moonModY = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							if (b11 == 1)
							{
								Main.dayTime = true;
							}
							else
							{
								Main.dayTime = false;
							}
							Main.time = (double)num32;
							Main.sunModY = sunModY;
							Main.moonModY = moonModY;
							if (Main.netMode == 2)
							{
								NetMessage.SendData(18, -1, this.whoAmI, "", 0, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 19)
					{
						byte b12 = this.readBuffer[num];
						num++;
						int num33 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						int num34 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						int num35 = (int)this.readBuffer[num];
						int direction = 0;
						if (num35 == 0)
						{
							direction = -1;
						}
						if (b12 == 0)
						{
							WorldGen.OpenDoor(num33, num34, direction);
						}
						else if (b12 == 1)
						{
							WorldGen.CloseDoor(num33, num34, true);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(19, -1, this.whoAmI, "", (int)b12, (float)num33, (float)num34, (float)num35, 0);
						}
					}
					else if (b == 20)
					{
						short num36 = BitConverter.ToInt16(this.readBuffer, start + 1);
						int num37 = BitConverter.ToInt32(this.readBuffer, start + 3);
						int num38 = BitConverter.ToInt32(this.readBuffer, start + 7);
						num = start + 11;
						for (int num39 = num37; num39 < num37 + (int)num36; num39++)
						{
							for (int num40 = num38; num40 < num38 + (int)num36; num40++)
							{
								if (Main.tile[num39, num40] == null)
								{
									Main.tile[num39, num40] = new Tile();
								}
								byte b13 = this.readBuffer[num];
								num++;
								bool active3 = Main.tile[num39, num40].active;
								if ((b13 & 1) == 1)
								{
									Main.tile[num39, num40].active = true;
								}
								else
								{
									Main.tile[num39, num40].active = false;
								}
								byte b14 = (byte)(b13 & 2);
								if ((b13 & 4) == 4)
								{
									Main.tile[num39, num40].wall = 1;
								}
								else
								{
									Main.tile[num39, num40].wall = 0;
								}
								if ((b13 & 8) == 8)
								{
									Main.tile[num39, num40].liquid = 1;
								}
								else
								{
									Main.tile[num39, num40].liquid = 0;
								}
								if ((b13 & 16) == 16)
								{
									Main.tile[num39, num40].wire = true;
								}
								else
								{
									Main.tile[num39, num40].wire = false;
								}
								if (Main.tile[num39, num40].active)
								{
									int type3 = (int)Main.tile[num39, num40].type;
									Main.tile[num39, num40].type = this.readBuffer[num];
									num++;
									if (Main.tileFrameImportant[(int)Main.tile[num39, num40].type])
									{
										Main.tile[num39, num40].frameX = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										Main.tile[num39, num40].frameY = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
									}
									else if (!active3 || (int)Main.tile[num39, num40].type != type3)
									{
										Main.tile[num39, num40].frameX = -1;
										Main.tile[num39, num40].frameY = -1;
									}
								}
								if (Main.tile[num39, num40].wall > 0)
								{
									Main.tile[num39, num40].wall = this.readBuffer[num];
									num++;
								}
								if (Main.tile[num39, num40].liquid > 0)
								{
									Main.tile[num39, num40].liquid = this.readBuffer[num];
									num++;
									byte b15 = this.readBuffer[num];
									num++;
									if (b15 == 1)
									{
										Main.tile[num39, num40].lava = true;
									}
									else
									{
										Main.tile[num39, num40].lava = false;
									}
								}
							}
						}
						WorldGen.RangeFrame(num37, num38, num37 + (int)num36, num38 + (int)num36);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)b, -1, this.whoAmI, "", (int)num36, (float)num37, (float)num38, 0f, 0);
						}
					}
					else if (b == 21)
					{
						short num41 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						float num42 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float num43 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float x3 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float y2 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						byte stack2 = this.readBuffer[num];
						num++;
						byte pre = this.readBuffer[num];
						num++;
						short num44 = BitConverter.ToInt16(this.readBuffer, num);
						if (Main.netMode == 1)
						{
							if (num44 == 0)
							{
								Main.item[(int)num41].active = false;
							}
							else
							{
								Main.item[(int)num41].netDefaults((int)num44);
								Main.item[(int)num41].Prefix((int)pre);
								Main.item[(int)num41].stack = (int)stack2;
								Main.item[(int)num41].position.X = num42;
								Main.item[(int)num41].position.Y = num43;
								Main.item[(int)num41].velocity.X = x3;
								Main.item[(int)num41].velocity.Y = y2;
								Main.item[(int)num41].active = true;
								Main.item[(int)num41].wet = Collision.WetCollision(Main.item[(int)num41].position, Main.item[(int)num41].width, Main.item[(int)num41].height);
							}
						}
						else if (num44 == 0)
						{
							if (num41 < 200)
							{
								Main.item[(int)num41].active = false;
								NetMessage.SendData(21, -1, -1, "", (int)num41, 0f, 0f, 0f, 0);
							}
						}
						else
						{
							bool flag5 = false;
							if (num41 == 200)
							{
								flag5 = true;
							}
							if (flag5)
							{
								Item item = new Item();
								item.netDefaults((int)num44);
								num41 = (short)Item.NewItem((int)num42, (int)num43, item.width, item.height, item.type, (int)stack2, true, 0);
							}
							Main.item[(int)num41].netDefaults((int)num44);
							Main.item[(int)num41].Prefix((int)pre);
							Main.item[(int)num41].stack = (int)stack2;
							Main.item[(int)num41].position.X = num42;
							Main.item[(int)num41].position.Y = num43;
							Main.item[(int)num41].velocity.X = x3;
							Main.item[(int)num41].velocity.Y = y2;
							Main.item[(int)num41].active = true;
							Main.item[(int)num41].owner = Main.myPlayer;
							if (flag5)
							{
								NetMessage.SendData(21, -1, -1, "", (int)num41, 0f, 0f, 0f, 0);
								Main.item[(int)num41].ownIgnore = this.whoAmI;
								Main.item[(int)num41].ownTime = 100;
								Main.item[(int)num41].FindOwner((int)num41);
							}
							else
							{
								NetMessage.SendData(21, -1, this.whoAmI, "", (int)num41, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 22)
					{
						short num45 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						byte b16 = this.readBuffer[num];
						if (Main.netMode != 2 || Main.item[(int)num45].owner == this.whoAmI)
						{
							Main.item[(int)num45].owner = (int)b16;
							if ((int)b16 == Main.myPlayer)
							{
								Main.item[(int)num45].keepTime = 15;
							}
							else
							{
								Main.item[(int)num45].keepTime = 0;
							}
							if (Main.netMode == 2)
							{
								Main.item[(int)num45].owner = 255;
								Main.item[(int)num45].keepTime = 15;
								NetMessage.SendData(22, -1, -1, "", (int)num45, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 23 && Main.netMode == 1)
					{
						short num46 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						float x4 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float y3 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float x5 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float y4 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						int target = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						int direction2 = (int)(this.readBuffer[num] - 1);
						num++;
						int directionY = (int)(this.readBuffer[num] - 1);
						num++;
						int num47 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						float[] array = new float[NPC.maxAI];
						for (int num48 = 0; num48 < NPC.maxAI; num48++)
						{
							array[num48] = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
						}
						int num49 = (int)BitConverter.ToInt16(this.readBuffer, num);
						if (!Main.npc[(int)num46].active || Main.npc[(int)num46].netID != num49)
						{
							Main.npc[(int)num46].active = true;
							Main.npc[(int)num46].netDefaults(num49);
						}
						Main.npc[(int)num46].position.X = x4;
						Main.npc[(int)num46].position.Y = y3;
						Main.npc[(int)num46].velocity.X = x5;
						Main.npc[(int)num46].velocity.Y = y4;
						Main.npc[(int)num46].target = target;
						Main.npc[(int)num46].direction = direction2;
						Main.npc[(int)num46].directionY = directionY;
						Main.npc[(int)num46].life = num47;
						if (num47 <= 0)
						{
							Main.npc[(int)num46].active = false;
						}
						for (int num50 = 0; num50 < NPC.maxAI; num50++)
						{
							Main.npc[(int)num46].ai[num50] = array[num50];
						}
					}
					else if (b == 24)
					{
						short num51 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						byte b17 = this.readBuffer[num];
						if (Main.netMode == 2)
						{
							b17 = (byte)this.whoAmI;
						}
						Main.npc[(int)num51].StrikeNPC(Main.player[(int)b17].inventory[Main.player[(int)b17].selectedItem].damage, Main.player[(int)b17].inventory[Main.player[(int)b17].selectedItem].knockBack, Main.player[(int)b17].direction, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(24, -1, this.whoAmI, "", (int)num51, (float)b17, 0f, 0f, 0);
							NetMessage.SendData(23, -1, -1, "", (int)num51, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 25)
					{
						int num52 = (int)this.readBuffer[start + 1];
						if (Main.netMode == 2)
						{
							num52 = this.whoAmI;
						}
						byte b18 = this.readBuffer[start + 2];
						byte b19 = this.readBuffer[start + 3];
						byte b20 = this.readBuffer[start + 4];
						if (Main.netMode == 2)
						{
							b18 = 255;
							b19 = 255;
							b20 = 255;
						}
						string text2 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
						int num53 = text2.IndexOf("[\"CHS\"]");
						string text3;
						if (num53 > 0)
						{
							text2 = text2.Remove(num53);
							int i = text2.LastIndexOf(" ");
							string str = text2.Remove(i + 1);
							string s = text2.Substring(i + 1);
							byte[] bytes = Convert.FromBase64String(s);
							text3 = str + Encoding.UTF8.GetString(bytes);
						}
						else
						{
							text3 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
						}
						if (Main.netMode == 1)
						{
							string newText = text3;
							if (num52 < 255)
							{
								newText = "<" + Main.player[num52].name + "> " + text3;
								Main.player[num52].chatText = text3;
								Main.player[num52].chatShowTime = Main.chatLength / 2;
							}
							Main.NewText(newText, b18, b19, b20);
						}
						else if (Main.netMode == 2)
						{
							string text4 = text3.ToLower();
							if (text4 == "/playing")
							{
								string text5 = "";
								for (int num54 = 0; num54 < 255; num54++)
								{
									if (Main.player[num54].active)
									{
										if (text5 == "")
										{
											text5 += Main.player[num54].name;
										}
										else
										{
											text5 = text5 + ", " + Main.player[num54].name;
										}
									}
								}
								NetMessage.SendData(25, this.whoAmI, -1, "当前玩家: " + text5 + ".", 255, 255f, 240f, 20f, 0);
							}
							else if (text4.Length >= 4 && text4.Substring(0, 4) == "/me ")
							{
								NetMessage.SendData(25, -1, -1, "*" + Main.player[this.whoAmI].name + " " + text3.Substring(4), 255, 200f, 100f, 0f, 0);
							}
							else if (text4 == "/roll")
							{
								NetMessage.SendData(25, -1, -1, string.Concat(new object[]
								{
									"*",
									Main.player[this.whoAmI].name,
									" rolls a ",
									Main.rand.Next(1, 101)
								}), 255, 255f, 240f, 20f, 0);
							}
							else if (text4.Length >= 3 && text4.Substring(0, 3) == "/p ")
							{
								if (Main.player[this.whoAmI].team != 0)
								{
									for (int num55 = 0; num55 < 255; num55++)
									{
										if (Main.player[num55].team == Main.player[this.whoAmI].team)
										{
											NetMessage.SendData(25, num55, -1, text3.Substring(3), num52, (float)Main.teamColor[Main.player[this.whoAmI].team].R, (float)Main.teamColor[Main.player[this.whoAmI].team].G, (float)Main.teamColor[Main.player[this.whoAmI].team].B, 0);
										}
									}
								}
								else
								{
									NetMessage.SendData(25, this.whoAmI, -1, "你当前不在队伍中!", 255, 255f, 240f, 20f, 0);
								}
							}
							else
							{
								if (Main.player[this.whoAmI].difficulty == 2)
								{
									b18 = Main.hcColor.R;
									b19 = Main.hcColor.G;
									b20 = Main.hcColor.B;
								}
								else if (Main.player[this.whoAmI].difficulty == 1)
								{
									b18 = Main.mcColor.R;
									b19 = Main.mcColor.G;
									b20 = Main.mcColor.B;
								}
								NetMessage.SendData(25, -1, -1, text3, num52, (float)b18, (float)b19, (float)b20, 0);
								if (Main.dedServ)
								{
									Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + text3);
								}
							}
						}
					}
					else if (b == 26)
					{
						byte b21 = this.readBuffer[num];
						if (Main.netMode != 2 || this.whoAmI == (int)b21 || (Main.player[(int)b21].hostile && Main.player[this.whoAmI].hostile))
						{
							num++;
							int num56 = (int)(this.readBuffer[num] - 1);
							num++;
							short num57 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b22 = this.readBuffer[num];
							num++;
							bool pvp = false;
							byte b23 = this.readBuffer[num];
							num++;
							bool crit = false;
							string text3 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							if (b22 != 0)
							{
								pvp = true;
							}
							if (b23 != 0)
							{
								crit = true;
							}
							Main.player[(int)b21].Hurt((int)num57, num56, pvp, true, text3, crit);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(26, -1, this.whoAmI, text3, (int)b21, (float)num56, (float)num57, (float)b22, 0);
							}
						}
					}
					else if (b == 27)
					{
						short num58 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						float x6 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float y5 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float x7 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float y6 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						float knockBack = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						short damage = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						byte b24 = this.readBuffer[num];
						num++;
						byte b25 = this.readBuffer[num];
						num++;
						float[] array2 = new float[Projectile.maxAI];
						for (int num59 = 0; num59 < Projectile.maxAI; num59++)
						{
							array2[num59] = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
						}
						int num60 = 1000;
						for (int num61 = 0; num61 < 1000; num61++)
						{
							if (Main.projectile[num61].owner == (int)b24 && Main.projectile[num61].identity == (int)num58 && Main.projectile[num61].active)
							{
								num60 = num61;
								break;
							}
						}
						if (num60 == 1000)
						{
							for (int num62 = 0; num62 < 1000; num62++)
							{
								if (!Main.projectile[num62].active)
								{
									num60 = num62;
									break;
								}
							}
						}
						if (!Main.projectile[num60].active || Main.projectile[num60].type != (int)b25)
						{
							Main.projectile[num60].SetDefaults((int)b25);
							if (Main.netMode == 2)
							{
								Netplay.serverSock[this.whoAmI].spamProjectile += 1f;
							}
						}
						Main.projectile[num60].identity = (int)num58;
						Main.projectile[num60].position.X = x6;
						Main.projectile[num60].position.Y = y5;
						Main.projectile[num60].velocity.X = x7;
						Main.projectile[num60].velocity.Y = y6;
						Main.projectile[num60].damage = (int)damage;
						Main.projectile[num60].type = (int)b25;
						Main.projectile[num60].owner = (int)b24;
						Main.projectile[num60].knockBack = knockBack;
						for (int num63 = 0; num63 < Projectile.maxAI; num63++)
						{
							Main.projectile[num60].ai[num63] = array2[num63];
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(27, -1, this.whoAmI, "", num60, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 28)
					{
						short num64 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						short num65 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						float num66 = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						int num67 = (int)(this.readBuffer[num] - 1);
						num++;
						int num68 = (int)this.readBuffer[num];
						if (num65 >= 0)
						{
							if (num68 == 1)
							{
								Main.npc[(int)num64].StrikeNPC((int)num65, num66, num67, true, false);
							}
							else
							{
								Main.npc[(int)num64].StrikeNPC((int)num65, num66, num67, false, false);
							}
						}
						else
						{
							Main.npc[(int)num64].life = 0;
							Main.npc[(int)num64].HitEffect(0, 10.0);
							Main.npc[(int)num64].active = false;
						}
						if (Main.netMode == 2)
						{
							if (Main.npc[(int)num64].life <= 0)
							{
								NetMessage.SendData(28, -1, this.whoAmI, "", (int)num64, (float)num65, num66, (float)num67, num68);
								NetMessage.SendData(23, -1, -1, "", (int)num64, 0f, 0f, 0f, 0);
							}
							else
							{
								NetMessage.SendData(28, -1, this.whoAmI, "", (int)num64, (float)num65, num66, (float)num67, num68);
								Main.npc[(int)num64].netUpdate = true;
							}
						}
					}
					else if (b == 29)
					{
						short num69 = BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						byte b26 = this.readBuffer[num];
						if (Main.netMode == 2)
						{
							b26 = (byte)this.whoAmI;
						}
						for (int num70 = 0; num70 < 1000; num70++)
						{
							if (Main.projectile[num70].owner == (int)b26 && Main.projectile[num70].identity == (int)num69 && Main.projectile[num70].active)
							{
								Main.projectile[num70].Kill();
								break;
							}
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(29, -1, this.whoAmI, "", (int)num69, (float)b26, 0f, 0f, 0);
						}
					}
					else if (b == 30)
					{
						byte b27 = this.readBuffer[num];
						if (Main.netMode == 2)
						{
							b27 = (byte)this.whoAmI;
						}
						num++;
						byte b28 = this.readBuffer[num];
						if (b28 == 1)
						{
							Main.player[(int)b27].hostile = true;
						}
						else
						{
							Main.player[(int)b27].hostile = false;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(30, -1, this.whoAmI, "", (int)b27, 0f, 0f, 0f, 0);
							string str2 = " 已经开启PvP模式!";
							if (b28 == 0)
							{
								str2 = " 已经关闭PvP模式!";
							}
							NetMessage.SendData(25, -1, -1, Main.player[(int)b27].name + str2, 255, (float)Main.teamColor[Main.player[(int)b27].team].R, (float)Main.teamColor[Main.player[(int)b27].team].G, (float)Main.teamColor[Main.player[(int)b27].team].B, 0);
						}
					}
					else if (b == 31)
					{
						if (Main.netMode == 2)
						{
							int x8 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int y7 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num71 = Chest.FindChest(x8, y7);
							if (num71 > -1 && Chest.UsingChest(num71) == -1)
							{
								for (int num72 = 0; num72 < Chest.maxItems; num72++)
								{
									NetMessage.SendData(32, this.whoAmI, -1, "", num71, (float)num72, 0f, 0f, 0);
								}
								NetMessage.SendData(33, this.whoAmI, -1, "", num71, 0f, 0f, 0f, 0);
								Main.player[this.whoAmI].chest = num71;
							}
						}
					}
					else if (b == 32)
					{
						int num73 = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						int num74 = (int)this.readBuffer[num];
						num++;
						int stack3 = (int)this.readBuffer[num];
						num++;
						int pre2 = (int)this.readBuffer[num];
						num++;
						int type4 = (int)BitConverter.ToInt16(this.readBuffer, num);
						if (Main.chest[num73] == null)
						{
							Main.chest[num73] = new Chest();
						}
						if (Main.chest[num73].item[num74] == null)
						{
							Main.chest[num73].item[num74] = new Item();
						}
						Main.chest[num73].item[num74].netDefaults(type4);
						Main.chest[num73].item[num74].Prefix(pre2);
						Main.chest[num73].item[num74].stack = stack3;
					}
					else if (b == 33)
					{
						int num75 = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						int chestX = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						int chestY = BitConverter.ToInt32(this.readBuffer, num);
						if (Main.netMode == 1)
						{
							if (Main.player[Main.myPlayer].chest == -1)
							{
								Main.playerInventory = true;
								Main.PlaySound(10, -1, -1, 1);
							}
							else if (Main.player[Main.myPlayer].chest != num75 && num75 != -1)
							{
								Main.playerInventory = true;
								Main.PlaySound(12, -1, -1, 1);
							}
							else if (Main.player[Main.myPlayer].chest != -1 && num75 == -1)
							{
								Main.PlaySound(11, -1, -1, 1);
							}
							Main.player[Main.myPlayer].chest = num75;
							Main.player[Main.myPlayer].chestX = chestX;
							Main.player[Main.myPlayer].chestY = chestY;
						}
						else
						{
							Main.player[this.whoAmI].chest = num75;
						}
					}
					else if (b == 34)
					{
						if (Main.netMode == 2)
						{
							int num76 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num77 = BitConverter.ToInt32(this.readBuffer, num);
							if (Main.tile[num76, num77].type == 21)
							{
								WorldGen.KillTile(num76, num77, false, false, false);
								if (!Main.tile[num76, num77].active)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num76, (float)num77, 0f, 0);
								}
							}
						}
					}
					else if (b == 35)
					{
						int num78 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num78 = this.whoAmI;
						}
						num++;
						int num79 = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						if (num78 != Main.myPlayer)
						{
							Main.player[num78].HealEffect(num79);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(35, -1, this.whoAmI, "", num78, (float)num79, 0f, 0f, 0);
						}
					}
					else if (b == 36)
					{
						int num80 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num80 = this.whoAmI;
						}
						num++;
						int num81 = (int)this.readBuffer[num];
						num++;
						int num82 = (int)this.readBuffer[num];
						num++;
						int num83 = (int)this.readBuffer[num];
						num++;
						int num84 = (int)this.readBuffer[num];
						num++;
						int num85 = (int)this.readBuffer[num];
						num++;
						if (num81 == 0)
						{
							Main.player[num80].zoneEvil = false;
						}
						else
						{
							Main.player[num80].zoneEvil = true;
						}
						if (num82 == 0)
						{
							Main.player[num80].zoneMeteor = false;
						}
						else
						{
							Main.player[num80].zoneMeteor = true;
						}
						if (num83 == 0)
						{
							Main.player[num80].zoneDungeon = false;
						}
						else
						{
							Main.player[num80].zoneDungeon = true;
						}
						if (num84 == 0)
						{
							Main.player[num80].zoneJungle = false;
						}
						else
						{
							Main.player[num80].zoneJungle = true;
						}
						if (num85 == 0)
						{
							Main.player[num80].zoneHoly = false;
						}
						else
						{
							Main.player[num80].zoneHoly = true;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(36, -1, this.whoAmI, "", num80, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 37)
					{
						if (Main.netMode == 1)
						{
							if (Main.autoPass)
							{
								NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
								Main.autoPass = false;
							}
							else
							{
								Netplay.password = "";
								Main.menuMode = 31;
							}
						}
					}
					else if (b == 38)
					{
						if (Main.netMode == 2)
						{
							string string3 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							if (string3 == Netplay.password)
							{
								Netplay.serverSock[this.whoAmI].state = 1;
								NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							}
							else
							{
								NetMessage.SendData(2, this.whoAmI, -1, "密码不正确", 0, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 39 && Main.netMode == 1)
					{
						short num86 = BitConverter.ToInt16(this.readBuffer, num);
						Main.item[(int)num86].owner = 255;
						NetMessage.SendData(22, -1, -1, "", (int)num86, 0f, 0f, 0f, 0);
					}
					else if (b == 40)
					{
						byte b29 = this.readBuffer[num];
						if (Main.netMode == 2)
						{
							b29 = (byte)this.whoAmI;
						}
						num++;
						int talkNPC = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						Main.player[(int)b29].talkNPC = talkNPC;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(40, -1, this.whoAmI, "", (int)b29, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 41)
					{
						byte b30 = this.readBuffer[num];
						if (Main.netMode == 2)
						{
							b30 = (byte)this.whoAmI;
						}
						num++;
						float itemRotation = BitConverter.ToSingle(this.readBuffer, num);
						num += 4;
						int itemAnimation = (int)BitConverter.ToInt16(this.readBuffer, num);
						Main.player[(int)b30].itemRotation = itemRotation;
						Main.player[(int)b30].itemAnimation = itemAnimation;
						Main.player[(int)b30].channel = Main.player[(int)b30].inventory[Main.player[(int)b30].selectedItem].channel;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(41, -1, this.whoAmI, "", (int)b30, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 42)
					{
						int num87 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num87 = this.whoAmI;
						}
						num++;
						int statMana = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						int statManaMax = (int)BitConverter.ToInt16(this.readBuffer, num);
						if (Main.netMode == 2)
						{
							num87 = this.whoAmI;
						}
						Main.player[num87].statMana = statMana;
						Main.player[num87].statManaMax = statManaMax;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(42, -1, this.whoAmI, "", num87, 0f, 0f, 0f, 0);
						}
					}
					else if (b == 43)
					{
						int num88 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num88 = this.whoAmI;
						}
						num++;
						int num89 = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						if (num88 != Main.myPlayer)
						{
							Main.player[num88].ManaEffect(num89);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(43, -1, this.whoAmI, "", num88, (float)num89, 0f, 0f, 0);
						}
					}
					else if (b == 44)
					{
						byte b31 = this.readBuffer[num];
						if ((int)b31 != Main.myPlayer)
						{
							if (Main.netMode == 2)
							{
								b31 = (byte)this.whoAmI;
							}
							num++;
							int num90 = (int)(this.readBuffer[num] - 1);
							num++;
							short num91 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b32 = this.readBuffer[num];
							num++;
							string string4 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							bool pvp2 = false;
							if (b32 != 0)
							{
								pvp2 = true;
							}
							Main.player[(int)b31].KillMe((double)num91, num90, pvp2, string4);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(44, -1, this.whoAmI, string4, (int)b31, (float)num90, (float)num91, (float)b32, 0);
							}
						}
					}
					else if (b == 45)
					{
						int num92 = (int)this.readBuffer[num];
						if (Main.netMode == 2)
						{
							num92 = this.whoAmI;
						}
						num++;
						int num93 = (int)this.readBuffer[num];
						num++;
						int team = Main.player[num92].team;
						Main.player[num92].team = num93;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(45, -1, this.whoAmI, "", num92, 0f, 0f, 0f, 0);
							string str3 = "";
							if (num93 == 0)
							{
								str3 = " 已经退出了队伍";
							}
							else if (num93 == 1)
							{
								str3 = " 已经加入了红队";
							}
							else if (num93 == 2)
							{
								str3 = " 已经加入了绿队";
							}
							else if (num93 == 3)
							{
								str3 = " 已经加入了蓝队";
							}
							else if (num93 == 4)
							{
								str3 = " 已经加入了黄队";
							}
							for (int num94 = 0; num94 < 255; num94++)
							{
								if (num94 == this.whoAmI || (team > 0 && Main.player[num94].team == team) || (num93 > 0 && Main.player[num94].team == num93))
								{
									NetMessage.SendData(25, num94, -1, Main.player[num92].name + str3, 255, (float)Main.teamColor[num93].R, (float)Main.teamColor[num93].G, (float)Main.teamColor[num93].B, 0);
								}
							}
						}
					}
					else if (b == 46)
					{
						if (Main.netMode == 2)
						{
							int i2 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int j2 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num95 = Sign.ReadSign(i2, j2);
							if (num95 >= 0)
							{
								NetMessage.SendData(47, this.whoAmI, -1, "", num95, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (b == 47)
					{
						int num96 = (int)BitConverter.ToInt16(this.readBuffer, num);
						num += 2;
						int x9 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						int y8 = BitConverter.ToInt32(this.readBuffer, num);
						num += 4;
						string string5 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
						Main.sign[num96] = new Sign();
						Main.sign[num96].x = x9;
						Main.sign[num96].y = y8;
						Sign.TextSign(num96, string5);
						if (Main.netMode == 1 && Main.sign[num96] != null && num96 != Main.player[Main.myPlayer].sign)
						{
							Main.playerInventory = false;
							Main.player[Main.myPlayer].talkNPC = -1;
							Main.editSign = false;
							Main.PlaySound(10, -1, -1, 1);
							Main.player[Main.myPlayer].sign = num96;
							Main.npcChatText = Main.sign[num96].text;
						}
					}
					else
					{
						if (b == 48)
						{
							int num97 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num98 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							byte liquid = this.readBuffer[num];
							num++;
							byte b33 = this.readBuffer[num];
							num++;
							if (Main.netMode == 2 && Netplay.spamCheck)
							{
								int num99 = this.whoAmI;
								int num100 = (int)(Main.player[num99].position.X + (float)(Main.player[num99].width / 2));
								int num101 = (int)(Main.player[num99].position.Y + (float)(Main.player[num99].height / 2));
								int num102 = 10;
								int num103 = num100 - num102;
								int num104 = num100 + num102;
								int num105 = num101 - num102;
								int num106 = num101 + num102;
								if (num100 < num103 || num100 > num104 || num101 < num105 || num101 > num106)
								{
									NetMessage.BootPlayer(this.whoAmI, "检测到作弊: Liquid spam");
									return;
								}
							}
							if (Main.tile[num97, num98] == null)
							{
								Main.tile[num97, num98] = new Tile();
							}
							lock (Main.tile[num97, num98])
							{
								Main.tile[num97, num98].liquid = liquid;
								if (b33 == 1)
								{
									Main.tile[num97, num98].lava = true;
								}
								else
								{
									Main.tile[num97, num98].lava = false;
								}
								if (Main.netMode == 2)
								{
									WorldGen.SquareTileFrame(num97, num98, true);
								}
								return;
							}
						}
						if (b == 49)
						{
							if (Netplay.clientSock.state == 6)
							{
								Netplay.clientSock.state = 10;
								Main.player[Main.myPlayer].Spawn();
							}
						}
						else if (b == 50)
						{
							int num107 = (int)this.readBuffer[num];
							num++;
							if (Main.netMode == 2)
							{
								num107 = this.whoAmI;
							}
							else if (num107 == Main.myPlayer)
							{
								return;
							}
							for (int num108 = 0; num108 < 10; num108++)
							{
								Main.player[num107].buffType[num108] = (int)this.readBuffer[num];
								if (Main.player[num107].buffType[num108] > 0)
								{
									Main.player[num107].buffTime[num108] = 60;
								}
								else
								{
									Main.player[num107].buffTime[num108] = 0;
								}
								num++;
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(50, -1, this.whoAmI, "", num107, 0f, 0f, 0f, 0);
							}
						}
						else if (b == 51)
						{
							byte b34 = this.readBuffer[num];
							num++;
							byte b35 = this.readBuffer[num];
							if (b35 == 1)
							{
								NPC.SpawnSkeletron();
							}
							else if (b35 == 2)
							{
								if (Main.netMode != 2)
								{
									Main.PlaySound(2, (int)Main.player[(int)b34].position.X, (int)Main.player[(int)b34].position.Y, 1);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData(51, -1, this.whoAmI, "", (int)b34, (float)b35, 0f, 0f, 0);
								}
							}
						}
						else if (b == 52)
						{
							byte number = this.readBuffer[num];
							num++;
							byte b36 = this.readBuffer[num];
							num++;
							int num109 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num110 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							if (b36 == 1)
							{
								Chest.Unlock(num109, num110);
								if (Main.netMode == 2)
								{
									NetMessage.SendData(52, -1, this.whoAmI, "", (int)number, (float)b36, (float)num109, (float)num110, 0);
									NetMessage.SendTileSquare(-1, num109, num110, 2);
								}
							}
						}
						else if (b == 53)
						{
							short num111 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte type5 = this.readBuffer[num];
							num++;
							short time = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							Main.npc[(int)num111].AddBuff((int)type5, (int)time, true);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(54, -1, -1, "", (int)num111, 0f, 0f, 0f, 0);
							}
						}
						else if (b == 54)
						{
							if (Main.netMode == 1)
							{
								short num112 = BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								for (int num113 = 0; num113 < 5; num113++)
								{
									Main.npc[(int)num112].buffType[num113] = (int)this.readBuffer[num];
									num++;
									Main.npc[(int)num112].buffTime[num113] = (int)BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
								}
							}
						}
						else if (b == 55)
						{
							byte b37 = this.readBuffer[num];
							num++;
							byte b38 = this.readBuffer[num];
							num++;
							short num114 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							if (Main.netMode == 1 && (int)b37 == Main.myPlayer)
							{
								Main.player[(int)b37].AddBuff((int)b38, (int)num114, true);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(55, (int)b37, -1, "", (int)b37, (float)b38, (float)num114, 0f, 0);
							}
						}
						else if (b == 56)
						{
							if (Main.netMode == 1)
							{
								short num115 = BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								string string6 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
								Main.chrName[(int)num115] = string6;
							}
						}
						else if (b == 57)
						{
							if (Main.netMode == 1)
							{
								WorldGen.tGood = this.readBuffer[num];
								num++;
								WorldGen.tEvil = this.readBuffer[num];
							}
						}
						else if (b == 58)
						{
							byte b39 = this.readBuffer[num];
							if (Main.netMode == 2)
							{
								b39 = (byte)this.whoAmI;
							}
							num++;
							float num116 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							if (Main.netMode == 2)
							{
								NetMessage.SendData(58, -1, this.whoAmI, "", this.whoAmI, num116, 0f, 0f, 0);
							}
							else
							{
								Main.harpNote = num116;
								int style = 26;
								if (Main.player[(int)b39].inventory[Main.player[(int)b39].selectedItem].type == 507)
								{
									style = 35;
								}
								Main.PlaySound(2, (int)Main.player[(int)b39].position.X, (int)Main.player[(int)b39].position.Y, style);
							}
						}
						else if (b == 59)
						{
							int num117 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num118 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							WorldGen.hitSwitch(num117, num118);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(59, -1, this.whoAmI, "", num117, (float)num118, 0f, 0f, 0);
							}
						}
						else if (b == 60)
						{
							short num119 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							short num120 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							short num121 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b40 = this.readBuffer[num];
							num++;
							bool homeless = false;
							if (b40 == 1)
							{
								homeless = true;
							}
							if (Main.netMode == 1)
							{
								Main.npc[(int)num119].homeless = homeless;
								Main.npc[(int)num119].homeTileX = (int)num120;
								Main.npc[(int)num119].homeTileY = (int)num121;
							}
							else if (b40 == 0)
							{
								WorldGen.kickOut((int)num119);
							}
							else
							{
								WorldGen.moveRoom((int)num120, (int)num121, (int)num119);
							}
						}
					}
				}
			}
		}
	}
}
