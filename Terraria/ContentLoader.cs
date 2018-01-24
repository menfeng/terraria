using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Terraria
{
	internal static class ContentLoader
	{
		private static Texture2D BitmapToTexture(GraphicsDevice gd, Bitmap img)
		{
			Texture2D texture2D = new Texture2D(gd, img.Width, img.Height);
			BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			int[] array = new int[img.Width * img.Height];
			byte[] array2 = new byte[bitmapData.Stride * img.Height];
			Marshal.Copy(bitmapData.Scan0, array2, 0, array2.Length);
			for (int i = 0; i < img.Height; i++)
			{
				for (int j = 0; j < img.Width; j++)
				{
					int num = i * bitmapData.Stride + j * 4;
					int num2 = (int)array2[num];
					int num3 = (int)array2[num + 1];
					int num4 = (int)array2[num + 2];
					int num5 = (int)array2[num + 3];
					array[i * img.Width + j] = (num5 << 24 | num2 << 16 | num3 << 8 | num4);
				}
			}
			texture2D.SetData<int>(array);
			img.UnlockBits(bitmapData);
			return texture2D;
		}

		private static Texture2D GetOrNull(Dictionary<string, Texture2D> textures, string name)
		{
			Texture2D texture2D;
			Texture2D result;
			if (!textures.TryGetValue(name, out texture2D))
			{
				result = null;
			}
			else
			{
				result = texture2D;
			}
			return result;
		}

		internal static Dictionary<string, Texture2D> GetTextures(GraphicsDevice gd, IFileProvider provider)
		{
			Dictionary<string, Texture2D> dictionary = new Dictionary<string, Texture2D>();
			string[] files = provider.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				string text = files[i];
				Bitmap img = new Bitmap(new MemoryStream(provider.GetData(text)));
				dictionary.Add(text, ContentLoader.BitmapToTexture(gd, img));
			}
			return dictionary;
		}

		internal static void Load(Dictionary<string, Texture2D> textures)
		{
			ContentLoader.LoadTiles(textures);
			ContentLoader.LoadWalls(textures);
			ContentLoader.LoadBuff(textures);
			ContentLoader.LoadBackgrounds(textures);
			ContentLoader.LoadItems(textures);
			ContentLoader.LoadNpcs(textures);
			ContentLoader.LoadProjectiles(textures);
			ContentLoader.LoadGores(textures);
			ContentLoader.LoadClouds(textures);
			ContentLoader.LoadStars(textures);
			ContentLoader.LoadLiquids(textures);
			ContentLoader.LoadArmors(textures);
			ContentLoader.LoadTrees(textures);
			ContentLoader.LoadMisc(textures);
		}

		private static void LoadArmors(Dictionary<string, Texture2D> textures)
		{
			for (int i = 1; i < 25; i++)
			{
				Main.femaleBodyTexture[i] = (ContentLoader.GetOrNull(textures, "Female_Body_" + i) ?? Main.femaleBodyTexture[i]);
				Main.armorBodyTexture[i] = (ContentLoader.GetOrNull(textures, "Armor_Body_" + i) ?? Main.armorBodyTexture[i]);
				Main.armorArmTexture[i] = (ContentLoader.GetOrNull(textures, "Armor_Arm_" + i) ?? Main.armorArmTexture[i]);
			}
			for (int i = 1; i < 44; i++)
			{
				Main.armorHeadTexture[i] = (ContentLoader.GetOrNull(textures, "Armor_Head_" + i) ?? Main.armorHeadTexture[i]);
			}
			for (int i = 1; i < 24; i++)
			{
				Main.armorLegTexture[i] = (ContentLoader.GetOrNull(textures, "Armor_Legs_" + i) ?? Main.armorLegTexture[i]);
			}
			for (int i = 0; i < 36; i++)
			{
				Main.playerHairTexture[i] = (ContentLoader.GetOrNull(textures, "Player_Hair_" + i + 1) ?? Main.playerHairTexture[i]);
			}
		}

		private static void LoadBackgrounds(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 32; i++)
			{
				if (textures.ContainsKey("Background_" + i))
				{
					Main.backgroundTexture[i] = textures["Background_" + i];
					Main.backgroundWidth[i] = Main.backgroundTexture[i].Width;
					Main.backgroundHeight[i] = Main.backgroundTexture[i].Height;
				}
			}
		}

		private static void LoadClouds(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 4; i++)
			{
				if (textures.ContainsKey("Cloud_" + i))
				{
					Main.cloudTexture[i] = textures["Cloud_" + i];
				}
			}
		}

		private static void LoadBuff(Dictionary<string, Texture2D> textures)
		{
			for (int i = 1; i < 40; i++)
			{
				if (textures.ContainsKey("Buff_" + i))
				{
					Main.buffTexture[i] = textures["Buff_" + i];
				}
			}
		}

		private static void LoadGores(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 157; i++)
			{
				if (textures.ContainsKey("Gore_" + i))
				{
					Main.goreTexture[i] = textures["Gore_" + i];
				}
			}
		}

		private static void LoadItems(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 586; i++)
			{
				if (textures.ContainsKey("Item_" + i))
				{
					Main.itemTexture[i] = textures["Item_" + i];
				}
			}
		}

		private static void LoadLiquids(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 2; i++)
			{
				if (textures.ContainsKey("Liquid_" + i))
				{
					Main.liquidTexture[i] = textures["Liquid_" + i];
				}
			}
		}

		private static void LoadTrees(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 4; i++)
			{
				if (textures.ContainsKey("Tree_Tops_" + i))
				{
					Main.treeTopTexture[i] = textures["Tree_Tops_" + i];
				}
				if (textures.ContainsKey("Tree_Branches_" + i))
				{
					Main.treeBranchTexture[i] = textures["Tree_Branches_" + i];
				}
			}
		}

		private static void LoadMisc(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 6; i++)
			{
				if (textures.ContainsKey("logo_" + (i + 1)))
				{
					Main.loTexture[i] = textures["logo_" + (i + 1)];
				}
			}
			Main.bannerTexture[1] = (ContentLoader.GetOrNull(textures, "House_Banner_1") ?? Main.bannerTexture[1]);
			for (int j = 0; j < 11; j++)
			{
				if (textures.ContainsKey("NPC_Head_" + j))
				{
					Main.npcHeadTexture[j] = textures["NPC_Head_" + j];
				}
			}
			Main.reforgeTexture = (ContentLoader.GetOrNull(textures, "Reforge") ?? Main.reforgeTexture);
			Main.timerTexture = (ContentLoader.GetOrNull(textures, "Timer") ?? Main.timerTexture);
			Main.wofTexture = (ContentLoader.GetOrNull(textures, "WallOfFlesh") ?? Main.wofTexture);
			Main.wallOutlineTexture = (ContentLoader.GetOrNull(textures, "Wall_Outline") ?? Main.wallOutlineTexture);
			Main.raTexture = (ContentLoader.GetOrNull(textures, "ra-logo") ?? Main.raTexture);
			Main.reTexture = (ContentLoader.GetOrNull(textures, "re-logo") ?? Main.reTexture);
			Main.splashTexture = (ContentLoader.GetOrNull(textures, "splash") ?? Main.splashTexture);
			Main.fadeTexture = (ContentLoader.GetOrNull(textures, "fade-out") ?? Main.fadeTexture);
			Main.ghostTexture = (ContentLoader.GetOrNull(textures, "Ghost") ?? Main.ghostTexture);
			Main.evilCactusTexture = (ContentLoader.GetOrNull(textures, "Evil_Cactus") ?? Main.evilCactusTexture);
			Main.goodCactusTexture = (ContentLoader.GetOrNull(textures, "Good_Cactus") ?? Main.goodCactusTexture);
			Main.wraithEyeTexture = (ContentLoader.GetOrNull(textures, "Wraith_Eyes") ?? Main.wraithEyeTexture);
			Main.MusicBoxTexture = (ContentLoader.GetOrNull(textures, "Music_Box") ?? Main.MusicBoxTexture);
			Main.wingsTexture[1] = (ContentLoader.GetOrNull(textures, "Wings_1") ?? Main.wingsTexture[1]);
			Main.wingsTexture[2] = (ContentLoader.GetOrNull(textures, "Wings_2") ?? Main.wingsTexture[2]);
			Main.destTexture[0] = (ContentLoader.GetOrNull(textures, "Dest1") ?? Main.destTexture[0]);
			Main.destTexture[1] = (ContentLoader.GetOrNull(textures, "Dest2") ?? Main.destTexture[1]);
			Main.destTexture[2] = (ContentLoader.GetOrNull(textures, "Dest3") ?? Main.destTexture[2]);
			Main.wireTexture = (ContentLoader.GetOrNull(textures, "Wires") ?? Main.wireTexture);
			Main.npcToggleTexture[0] = (ContentLoader.GetOrNull(textures, "House_1") ?? Main.npcToggleTexture[0]);
			Main.npcToggleTexture[1] = (ContentLoader.GetOrNull(textures, "House_2") ?? Main.npcToggleTexture[1]);
			Main.HBLockTexture[0] = (ContentLoader.GetOrNull(textures, "Lock_0") ?? Main.HBLockTexture[0]);
			Main.HBLockTexture[1] = (ContentLoader.GetOrNull(textures, "Lock_1") ?? Main.HBLockTexture[1]);
			Main.gridTexture = (ContentLoader.GetOrNull(textures, "Grid") ?? Main.gridTexture);
			Main.trashTexture = (ContentLoader.GetOrNull(textures, "Trash") ?? Main.trashTexture);
			Main.cdTexture = (ContentLoader.GetOrNull(textures, "CoolDown") ?? Main.cdTexture);
			Main.logoTexture = (ContentLoader.GetOrNull(textures, "Logo") ?? Main.logoTexture);
			Main.logo2Texture = (ContentLoader.GetOrNull(textures, "Logo2") ?? Main.logo2Texture);
			Main.logo3Texture = (ContentLoader.GetOrNull(textures, "Logo3") ?? Main.logo3Texture);
			Main.dustTexture = (ContentLoader.GetOrNull(textures, "Dust") ?? Main.dustTexture);
			Main.sunTexture = (ContentLoader.GetOrNull(textures, "Sun") ?? Main.sunTexture);
			Main.sun2Texture = (ContentLoader.GetOrNull(textures, "Sun2") ?? Main.sun2Texture);
			Main.moonTexture = (ContentLoader.GetOrNull(textures, "Moon") ?? Main.moonTexture);
			Main.blackTileTexture = (ContentLoader.GetOrNull(textures, "Black_Tile") ?? Main.blackTileTexture);
			Main.heartTexture = (ContentLoader.GetOrNull(textures, "Heart") ?? Main.heartTexture);
			Main.bubbleTexture = (ContentLoader.GetOrNull(textures, "Bubble") ?? Main.bubbleTexture);
			Main.manaTexture = (ContentLoader.GetOrNull(textures, "Mana") ?? Main.manaTexture);
			Main.cursorTexture = (ContentLoader.GetOrNull(textures, "Cursor") ?? Main.cursorTexture);
			Main.ninjaTexture = (ContentLoader.GetOrNull(textures, "Ninja") ?? Main.ninjaTexture);
			Main.antLionTexture = (ContentLoader.GetOrNull(textures, "AntlionBody") ?? Main.antLionTexture);
			Main.spikeBaseTexture = (ContentLoader.GetOrNull(textures, "Spike_Base") ?? Main.spikeBaseTexture);
			Main.shroomCapTexture = (ContentLoader.GetOrNull(textures, "Shroom_Tops") ?? Main.shroomCapTexture);
			Main.inventoryBackTexture = (ContentLoader.GetOrNull(textures, "Inventory_Back") ?? Main.inventoryBackTexture);
			Main.inventoryBack2Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back2") ?? Main.inventoryBack2Texture);
			Main.inventoryBack3Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back3") ?? Main.inventoryBack3Texture);
			Main.inventoryBack4Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back4") ?? Main.inventoryBack4Texture);
			Main.inventoryBack5Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back5") ?? Main.inventoryBack5Texture);
			Main.inventoryBack6Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back6") ?? Main.inventoryBack6Texture);
			Main.inventoryBack7Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back7") ?? Main.inventoryBack7Texture);
			Main.inventoryBack8Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back8") ?? Main.inventoryBack8Texture);
			Main.inventoryBack9Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back9") ?? Main.inventoryBack9Texture);
			Main.inventoryBack10Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back10") ?? Main.inventoryBack10Texture);
			Main.inventoryBack11Texture = (ContentLoader.GetOrNull(textures, "Inventory_Back11") ?? Main.inventoryBack11Texture);
			Main.textBackTexture = (ContentLoader.GetOrNull(textures, "Text_Back") ?? Main.textBackTexture);
			Main.chatTexture = (ContentLoader.GetOrNull(textures, "Chat") ?? Main.chatTexture);
			Main.chat2Texture = (ContentLoader.GetOrNull(textures, "Chat2") ?? Main.chat2Texture);
			Main.chatBackTexture = (ContentLoader.GetOrNull(textures, "Chat_Back") ?? Main.chatBackTexture);
			Main.teamTexture = (ContentLoader.GetOrNull(textures, "Team") ?? Main.teamTexture);
			Main.skinBodyTexture = (ContentLoader.GetOrNull(textures, "Skin_Body") ?? Main.skinBodyTexture);
			Main.skinLegsTexture = (ContentLoader.GetOrNull(textures, "Skin_Legs") ?? Main.skinLegsTexture);
			Main.playerEyeWhitesTexture = (ContentLoader.GetOrNull(textures, "Player_Eye_Whites") ?? Main.playerEyeWhitesTexture);
			Main.playerEyesTexture = (ContentLoader.GetOrNull(textures, "Player_Eyes") ?? Main.playerEyesTexture);
			Main.playerHandsTexture = (ContentLoader.GetOrNull(textures, "Player_Hands") ?? Main.playerHandsTexture);
			Main.playerHands2Texture = (ContentLoader.GetOrNull(textures, "Player_Hands2") ?? Main.playerHands2Texture);
			Main.playerHeadTexture = (ContentLoader.GetOrNull(textures, "Player_Head") ?? Main.playerHeadTexture);
			Main.playerPantsTexture = (ContentLoader.GetOrNull(textures, "Player_Pants") ?? Main.playerPantsTexture);
			Main.playerShirtTexture = (ContentLoader.GetOrNull(textures, "Player_Shirt") ?? Main.playerShirtTexture);
			Main.playerShoesTexture = (ContentLoader.GetOrNull(textures, "Player_Shoes") ?? Main.playerShoesTexture);
			Main.playerUnderShirtTexture = (ContentLoader.GetOrNull(textures, "Player_Undershirt") ?? Main.playerUnderShirtTexture);
			Main.playerUnderShirt2Texture = (ContentLoader.GetOrNull(textures, "Player_Undershirt2") ?? Main.playerUnderShirt2Texture);
			Main.femalePantsTexture = (ContentLoader.GetOrNull(textures, "Female_Pants") ?? Main.femalePantsTexture);
			Main.femaleShirtTexture = (ContentLoader.GetOrNull(textures, "Female_Shirt") ?? Main.femaleShirtTexture);
			Main.femaleShoesTexture = (ContentLoader.GetOrNull(textures, "Female_Shoes") ?? Main.femaleShoesTexture);
			Main.femaleUnderShirtTexture = (ContentLoader.GetOrNull(textures, "Female_Undershirt") ?? Main.femaleUnderShirtTexture);
			Main.femaleUnderShirt2Texture = (ContentLoader.GetOrNull(textures, "Female_Undershirt2") ?? Main.femaleUnderShirt2Texture);
			Main.femaleShirt2Texture = (ContentLoader.GetOrNull(textures, "Female_Shirt2") ?? Main.femaleShirt2Texture);
			Main.chaosTexture = (ContentLoader.GetOrNull(textures, "Chaos") ?? Main.chaosTexture);
			Main.EyeLaserTexture = (ContentLoader.GetOrNull(textures, "Eye_Laser") ?? Main.EyeLaserTexture);
			Main.BoneEyesTexture = (ContentLoader.GetOrNull(textures, "Bone_eyes") ?? Main.BoneEyesTexture);
			Main.BoneLaserTexture = (ContentLoader.GetOrNull(textures, "Bone_Laser") ?? Main.BoneLaserTexture);
			Main.lightDiscTexture = (ContentLoader.GetOrNull(textures, "Light_Disc") ?? Main.lightDiscTexture);
			Main.confuseTexture = (ContentLoader.GetOrNull(textures, "Confuse") ?? Main.confuseTexture);
			Main.probeTexture = (ContentLoader.GetOrNull(textures, "Probe") ?? Main.probeTexture);
			Main.chainTexture = (ContentLoader.GetOrNull(textures, "Chain") ?? Main.chainTexture);
			Main.chain2Texture = (ContentLoader.GetOrNull(textures, "Chain2") ?? Main.chain2Texture);
			Main.chain3Texture = (ContentLoader.GetOrNull(textures, "Chain3") ?? Main.chain3Texture);
			Main.chain4Texture = (ContentLoader.GetOrNull(textures, "Chain4") ?? Main.chain4Texture);
			Main.chain5Texture = (ContentLoader.GetOrNull(textures, "Chain5") ?? Main.chain5Texture);
			Main.chain6Texture = (ContentLoader.GetOrNull(textures, "Chain6") ?? Main.chain6Texture);
			Main.chain7Texture = (ContentLoader.GetOrNull(textures, "Chain7") ?? Main.chain7Texture);
			Main.chain8Texture = (ContentLoader.GetOrNull(textures, "Chain8") ?? Main.chain8Texture);
			Main.chain9Texture = (ContentLoader.GetOrNull(textures, "Chain9") ?? Main.chain9Texture);
			Main.chain10Texture = (ContentLoader.GetOrNull(textures, "Chain10") ?? Main.chain10Texture);
			Main.chain11Texture = (ContentLoader.GetOrNull(textures, "Chain11") ?? Main.chain11Texture);
			Main.chain12Texture = (ContentLoader.GetOrNull(textures, "Chain12") ?? Main.chain12Texture);
			Main.boneArmTexture = (ContentLoader.GetOrNull(textures, "Arm_Bone") ?? Main.boneArmTexture);
			Main.boneArm2Texture = (ContentLoader.GetOrNull(textures, "Arm_Bone_2") ?? Main.boneArm2Texture);
		}

		private static void LoadNpcs(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 142; i++)
			{
				if (textures.ContainsKey("NPC_" + i))
				{
					Main.npcTexture[i] = textures["NPC_" + i];
				}
			}
		}

		private static void LoadProjectiles(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 109; i++)
			{
				if (textures.ContainsKey("Projectile_" + i))
				{
					Main.projectileTexture[i] = textures["Projectile_" + i];
				}
			}
		}

		private static void LoadStars(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 5; i++)
			{
				if (textures.ContainsKey("Star_" + i))
				{
					Main.starTexture[i] = textures["Star_" + i];
				}
			}
		}

		private static void LoadTiles(Dictionary<string, Texture2D> textures)
		{
			for (int i = 0; i < 145; i++)
			{
				if (textures.ContainsKey("Tiles_" + i))
				{
					Main.tileTexture[i] = textures["Tiles_" + i];
				}
			}
		}

		private static void LoadWalls(Dictionary<string, Texture2D> textures)
		{
			for (int i = 1; i < 29; i++)
			{
				if (textures.ContainsKey("Wall_" + i))
				{
					Main.wallTexture[i] = textures["Wall_" + i];
				}
			}
		}
	}
}
