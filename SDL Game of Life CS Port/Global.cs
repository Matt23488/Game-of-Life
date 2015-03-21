using System.Collections.Concurrent;
using System.IO;
using System.Windows.Forms;

namespace SDL_Game_of_Life_CS_Port
{
	enum GOL_PRESET
	{
		GOL_GLIDERGUN_SYNTH,
		GOL_X,
		GOL_CROSS,
		GOL_HORIZONTAL,
		GOL_VERTICAL,
		GOL_VORTEX,
		GOL_VORTEXFAIL,
	}

	enum HL_PRESET
	{
		HL_REPLICATOR,
	}

	public enum GOL_Message
	{
		Start,
		Pause,
		Suspend,
		Resume,
		Stop,
		Advance,
		Clear,
		Save,
		Quit,
		Insert,
		Move,
		RotateLeft,
		RotateRight,
		FlipHorizontal,
		FlipVertical,
		ChangeCellSize,
		ChangeDelay,
		ChangeWrap,
	}

	public static class Global
	{
		public static BlockingCollection<GOL_Message> messages = new BlockingCollection<GOL_Message>();
		public static BlockingCollection<int> intData = new BlockingCollection<int>();
		public static BlockingCollection<Button> buttons = new BlockingCollection<Button>();
		public static BlockingCollection<StreamWriter> fStreams = new BlockingCollection<StreamWriter>();
		public static BlockingCollection<bool[,]> structures = new BlockingCollection<bool[,]>();
		public static BlockingCollection<bool> saved = new BlockingCollection<bool>();

		#region SpaceShips

		public static bool[,] Glider =
								{
									{ true, false, false },
									{ false, true, true },
									{ true, true, false }
								};

		public static bool[,] LWSS =
								{
									{ true, false, true, false },
									{ false, false, false, true },
									{ false, false, false, true },
									{ true, false, false, true },
									{ false, true, true, true }
								};

		#endregion

		#region Oscillators

		public static bool[,] Blinker = 
								{
									{ true, true, true }
								};

		public static bool[,] Toad =
								{
									{ false, true },
									{ true, true },
									{ true, true },
									{ true, false }
								};

		public static bool[,] Beacon =
								{
									{ true, true, false, false },
									{ true, true, false, false },
									{ false, false, true, true },
									{ false, false, true, true }
								};

		public static bool[,] Pulsar =
								{
									{ false, false, false, false, true, false, false, false, false, false, true, false, false, false, false },
									{ false, false, false, false, true, false, false, false, false, false, true, false, false, false, false },
									{ false, false, false, false, true, true, false, false, false, true, true, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
									{ true, true, true, false, false, true, true, false, true, true, false, false, true, true, true },
									{ false, false, true, false, true, false, true, false, true, false, true, false, true, false, false },
									{ false, false, false, false, true, true, false, false, false, true, true, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, true, true, false, false, false, true, true, false, false, false, false },
									{ false, false, true, false, true, false, true, false, true, false, true, false, true, false, false },
									{ true, true, true, false, false, true, true, false, true, true, false, false, true, true, true },
									{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, true, true, false, false, false, true, true, false, false, false, false },
									{ false, false, false, false, true, false, false, false, false, false, true, false, false, false, false },
									{ false, false, false, false, true, false, false, false, false, false, true, false, false, false, false }
								};

		public static bool[,] GliderGun =
								{
									{ false, false, false, false, true, true, false, false, false },
									{ false, false, false, false, true, true, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, true, true, true, false, false },
									{ false, false, false, true, false, false, false, true, false },
									{ false, false, true, false, false, false, false, false, true },
									{ false, false, true, false, false, false, false, false, true },
									{ false, false, false, false, false, true, false, false, false },
									{ false, false, false, true, false, false, false, true, false },
									{ false, false, false, false, true, true, true, false, false },
									{ false, false, false, false, false, true, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, true, true, true, false, false, false, false },
									{ false, false, true, true, true, false, false, false, false },
									{ false, true, false, false, false, true, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ true, true, false, false, false, true, true, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, false, false, false, false, false, false, false },
									{ false, false, true, true, false, false, false, false, false },
									{ false, false, true, true, false, false, false, false, false }
								};

		#endregion

		#region Still Lifes

		public static bool[,] Block =
								{
									{ true, true },
									{ true, true }
								};

		public static bool[,] Beehive =
								{
									{ false, true, false },
									{ true, false, true },
									{ true, false, true },
									{ false, true, false }
								};

		public static bool[,] Loaf =
								{
									{ false, true, false, false },
									{ true, false, true, false },
									{ true, false, false, true },
									{ false, true, true, false }
								};

		public static bool[,] Boat =
								{
									{ true, true, false },
									{ true, false, true },
									{ false, true, false }
								};

		#endregion
	}
}