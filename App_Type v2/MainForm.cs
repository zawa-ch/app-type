using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Serialization;
using zawa_ch.UI;

namespace App_Type_v2
{
	public partial class MainForm : Form
	{
		const int WM_SYSCOMMAND = 0x112;
		const int SC_MOVE = 0xF010;

		[DllImport("User32.dll")]
		public static extern bool SetCapture(IntPtr hWnd);

		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		Settings AppSetting = new Settings();
		Lang AppLang = new Lang();
		Dictionary<string, string> KeyBind = new Dictionary<string, string>();
		Dictionary<string, string> keybuffer = new Dictionary<string, string>();
		List<string> Type_Jpn = new List<string>();
		List<string> Type_kana = new List<string>();
		bool Game_IsStarted = false;
		bool Game_IsReady = false;
		bool Game_IsResult = false;
		int ReadyCount = 4;
		int Index = -1;
		int Typed = 0;
		int CollectType = 0;
		int Cleared = 0;
		int Score = 0;
		string InputKey = "";
		string Disp_Jpn = "";
		string Disp_Kana = "";
		int RemainTime = 100;
		int RemTimeBuffer = 0;
		Easing RemainTimeBarSize = new Easing(Easing.CIRCULAR_STALL, 200, 0);
		Random rnd = new Random();
		//*/
		public MainForm()
		{
			InitializeComponent();
			LangLoad();
			LangApply();
			ResourceLoad();
			DataLoad();
			Text = ProductName + " " + ProductVersion;
			mainToolStripMenuItem.Text = ProductName;
			versionToolStripMenuItem.Text = "Version: " + ProductVersion;
			Game_Reset();
			DrawTimer.Start();
		}
		//*/
		void Game_Reset()
		{
			AppSetting.TotalType += Typed;
			AppSetting.TotalCollectType += CollectType;
			AppSetting.TotalClear += Cleared;
			AppSetting.TotalScore += Score;
			Game_IsStarted = false;
			Game_IsReady = false;
			Game_IsResult = false;
			MainTick.Stop();
			ReadyCounter.Stop();
			ReadyCounter.Interval = 1;
			ReadyCount = 4;
			Index = -1;
			Typed = 0;
			CollectType = 0;
			Cleared = 0;
			InputKey = "";
			Disp_Jpn = "";
			Disp_Kana = "";
			Score = 0;
			RemainTime = 100;
			MainLabel.Text = ProductName;
			CaptionLabel.Text = "Typing Game ver " + ProductVersion;
			InputLabel.Text = "";
			RemainTimeLabel.Text = "";
			SpeedLabel.Text = "Speed";
			ScoreLabel.Text = "SCORE";
			HighscoreLabel.Text = "HIGHSCORE: " + AppSetting.HighScore.ToString();
			DataSave();
		}
		//*/
		void ResourceLoad()
		{
			string buffer = "";
			string[] Spriter = { "\t" };
			string[] Bindingdata = new string[2];
			StreamReader DataReader = new StreamReader(@"KeyBindings.dat", Encoding.UTF8);
			while ((buffer = DataReader.ReadLine()) != null)
			{
				Bindingdata = buffer.Split(Spriter, StringSplitOptions.None);
				KeyBind.Add(Bindingdata[0], Bindingdata[1]);
			}
			DataReader.Close();
			DataReader = new StreamReader(@"Typetext.txt", Encoding.UTF8);
			while ((buffer = DataReader.ReadLine()) != null)
			{
				Type_Jpn.Add(buffer);
			}
			DataReader.Close();
			DataReader = new StreamReader(@"Typekana.txt", Encoding.UTF8);
			while ((buffer = DataReader.ReadLine()) != null)
			{
				Type_kana.Add(buffer);
			}
			DataReader.Close();
		}
		//*/
		void LangLoad()
		{
			XmlSerializer LangLoader = new XmlSerializer(typeof(Lang));
			try
			{
				StreamReader Loader = new StreamReader(Directory.GetCurrentDirectory() + @"\Lang.xml", new UTF8Encoding(false));
				AppLang = (Lang)LangLoader.Deserialize(Loader);
				Loader.Close();
			}
			catch(FileNotFoundException e)
			{
				StreamWriter Saver = new StreamWriter(Directory.GetCurrentDirectory() + @"\Lang.xml", false, new UTF8Encoding(false));
				LangLoader.Serialize(Saver, AppLang);
				Saver.Close();
			}
		}
		//*/
		void LangApply()
		{
			startToolStripMenuItem.Text = AppLang.ts_StartText + " (&S)";
			resetToolStripMenuItem.Text = AppLang.ts_ResetText + " (&R)";
			exitToolStripMenuItem.Text = AppLang.ts_ExitText + " (&Q)";
			statToolStripMenuItem.Text = AppLang.ts_SeatText;
			clearStatToolStripMenuItem.Text = AppLang.ts_ClearText;
			clearToolStripMenuItem.Text = AppLang.ts_ClearreallyText;
			helpToolStripMenuItem.Text = AppLang.ts_HelpText;
			aboutToolStripMenuItem.Text = AppLang.ts_AboutText + " (&A)";
		}
		//*/
		void DataLoad()
		{
			try
			{
				XmlSerializer DataLoader = new XmlSerializer(typeof(Settings));
				StreamReader Stream = new StreamReader(Directory.GetCurrentDirectory() + @"\Settings.xml", new UTF8Encoding(false));
				AppSetting = (Settings)DataLoader.Deserialize(Stream);
				Stream.Close();
			}
			catch (FileNotFoundException e)
			{
				DataSave();
			}
		}
		//*/
		void DataSave()
		{
			XmlSerializer DataSaver = new XmlSerializer(typeof(Settings));
			StreamWriter Stream = new StreamWriter(Directory.GetCurrentDirectory() + @"\Settings.xml", false, new UTF8Encoding(false));
			DataSaver.Serialize(Stream, AppSetting);
			Stream.Close();
		}
		//*/
		void DataClear()
		{
			AppSetting = new Settings();
		}
		//*/
		int KeyPressProc(string Input)
		{
			if (((Disp_Kana.Length > 1) ? (Disp_Kana.Remove(1).ToLower()) : Disp_Kana) == Input)
			{
				return 1;
			}
			keybuffer = FindKey(KeyBind, Input);
			if (keybuffer.Count > 0)
			{
				if(DicStartWith(Disp_Kana, keybuffer) == 1)
				{
					if (keybuffer.ContainsKey(Input))
						return keybuffer[Input].Length;
				}
				else if(DicStartWith(Disp_Kana, keybuffer) == 0)
				{
					return -1;
				}
			}
			else
			{
				return -1;
			}
			return 0;
		}
		//*/
		void TextPick()
		{
			int indexbuf = Index;
			do
			{
				Index = rnd.Next(Type_kana.Count);
			} while (Index == indexbuf);
			Disp_Jpn = Type_Jpn[Index];
			Disp_Kana = Type_kana[Index];
		}
		//*/
		void FormMove()
		{
			SetCapture(this.Handle);
			ReleaseCapture();
			SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
		}
		//*/
		void ItemReflesh()
		{
			if (RemainTime != RemTimeBuffer)
			{
				RemainTimeBarSize.Destination = RemainTime;
				RemTimeBuffer = RemainTime;
			}
			RemainTimeBar.Width = (int)RemainTimeBarSize.Each;
			ScoreLabel.Text = "SCORE: " + Score.ToString();
			HighscoreLabel.Text = "HIGHSCORE: " + AppSetting.HighScore.ToString();
			totalTypeToolStripMenuItem.Text = AppLang.ts_TotaltypeText + ": " + (AppSetting.TotalType + Typed).ToString();
			totalCollectToolStripMenuItem.Text = AppLang.ts_TotslcollectText + ": " + (AppSetting.TotalCollectType + CollectType).ToString();
			acctuaryToolStripMenuItem.Text = AppLang.ts_AcctuaryText + ": " + (100.0 * (AppSetting.TotalCollectType + CollectType) / (AppSetting.TotalType + Typed)).ToString("f2") + "%";
			totalClearToolStripMenuItem.Text = AppLang.ts_TotalclearText + ": " + (AppSetting.TotalClear + Cleared).ToString();
			totalScoreToolStripMenuItem.Text = AppLang.ts_TotalscoreText + ": " + (AppSetting.TotalScore + Score).ToString();
		}
		//*/
		Dictionary<string,string> FindKey(Dictionary<string,string> From, string Find)
		{
			Dictionary<string, string> rtb = new Dictionary<string, string>();
			foreach (var item in From)
			{
				if (item.Key.StartsWith(Find))
					rtb.Add(item.Key, item.Value);
			}
			return rtb;
		}
		//*/
		int DicStartWith(string From, Dictionary<string,string> Find)
		{
			int InFind = 0;
			foreach (var item in Find)
			{
				if (From.StartsWith(item.Value))
					InFind++;
			}
			return InFind;
		}
		//*/
		void Exit()
		{
			Game_Reset();
			Close();
		}
		//*/
		//--------------------------//
		private void MainMenu_MouseDown(object sender, MouseEventArgs e)
		{
			FormMove();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Exit();
		}

		private void DrawTimer_Tick(object sender, EventArgs e)
		{
			ItemReflesh();
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Game_Reset();
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (Game_IsStarted && (Game_IsReady == false))
			{
				string key = e.KeyCode.ToString();
				if (key == "OemMinus") key = "-";
				if (key.Length > 1) key = "";
				key = key.ToLower();
				if (key.Length > 0)
				{
					Typed++;
					int scorebuf = KeyPressProc(InputKey + key);
					if (scorebuf == 0)
					{
						InputKey = InputKey + key;
						CollectType++;
					}
					else if (scorebuf < 0)
					{
						Score--;
						if (Score < 0) Score = 0;
					}
					else if (scorebuf > 0)
					{
						CollectType++;
						RemainTime += scorebuf * 4;
						Score += scorebuf;
						Disp_Kana = Disp_Kana.Substring(scorebuf);
						InputKey = "";
					}
				}
				if (Disp_Kana.Length == 0)
				{
					Cleared++;
					RemainTime += Type_kana[Index].Length;
					TextPick();
					MainTick.Interval = (int)(200 / (1.00 + (0.05 * Cleared)));
				}
				MainLabel.Text = Disp_Jpn;
				CaptionLabel.Text = Disp_Kana;
				InputLabel.Text = InputKey;
				SpeedLabel.Text = "Speed: x" + (1.0 + 0.05 * Cleared).ToString("f2");
				RemainTimeLabel.Text = AppLang.tx_RemaintimeText + ": " + RemainTime.ToString();
			}
		}

		private void MainTick_Tick(object sender, EventArgs e)
		{
			if (Game_IsStarted && (Game_IsReady == false))
			{
				RemainTime--;
				if (RemainTime <= 0)
				{
					MainTick.Stop();
					Game_IsStarted = false;
					Game_IsResult = true;
					MainLabel.Text = AppLang.tx_GameoverText;
					if (Score > AppSetting.HighScore)
					{
						CaptionLabel.Text = AppLang.tx_LasthighscoreText + ": " + AppSetting.HighScore.ToString() + " → " + Score.ToString();
						AppSetting.HighScore = Score;
						HighscoreLabel.Text = "HIGHSCORE: " + AppSetting.HighScore.ToString();
					}
					else
					{
						CaptionLabel.Text = AppLang.tx_LastscoreText + ": " + Score.ToString();
					}
					InputLabel.Text = "";
				}
				RemainTimeLabel.Text = AppLang.tx_RemaintimeText + ": " + RemainTime.ToString();
			}
		}

		private void ReadyCounter_Tick(object sender, EventArgs e)
		{
			ReadyCount--;
			ReadyCounter.Interval = 1000;
			if (ReadyCount <= 0)
			{
				ReadyCounter.Stop();
				MainTick.Start();
				Game_IsReady = false;
				TextPick();
				MainTick.Interval = (int)(200 / (1.00 + (0.05 * Cleared)));
				MainLabel.Text = Disp_Jpn;
				CaptionLabel.Text = Disp_Kana;
				InputLabel.Text = InputKey;
				SpeedLabel.Text = "Speed: x" + (1.0 + 0.05 * Cleared).ToString("f2");
			}
			else
			{
				MainLabel.Text = "Ready... " + ReadyCount.ToString();
			}
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Game_IsResult)
				Game_Reset();
			if (Game_IsStarted == false)
			{
				Game_IsStarted = true;
				Game_IsReady = true;
				ReadyCounter.Start();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(ProductName + "\nver " + ProductVersion + "\nCopyright zawa-ch. 2016", "About - " + ProductName);
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataClear();
			ItemReflesh();
		}
	}

	public class Settings
	{
		int _high;
		long _totaltype;
		long _totalcollect;
		long _totalclear;
		long _totalscore;

		public int HighScore
		{
			get { return _high; }
			set { _high = value; }
		}
		public long TotalType
		{
			get { return _totaltype; }
			set { _totaltype = value; }
		}
		public long TotalCollectType
		{
			get { return _totalcollect; }
			set { _totalcollect = value; }
		}
		public long TotalClear
		{
			get { return _totalclear; }
			set { _totalclear = value; }
		}
		public long TotalScore
		{
			get { return _totalscore; }
			set { _totalscore = value; }
		}

		public Settings()
		{
			_high = 0;
			_totaltype = 0;
			_totalcollect = 0;
			_totalclear = 0;
			_totalscore = 0;
		}
	}

	public class Lang
	{
		string _tsstart;
		string _tsreset;
		string _tsexit;
		string _tsstat;
		string _tstotaltype;
		string _tstotalcollect;
		string _tsacctuary;
		string _tstotalclear;
		string _tstotalscore;
		string _tsclear;
		string _tsclearreally;
		string _tshelp;
		string _tsabout;
		string _txgameover;
		string _txlastscore;
		string _txlasthighscore;
		string _txremtime;

		public string ts_StartText { get { return _tsstart; } set { _tsstart = value; } }
		public string ts_ResetText { get { return _tsreset; } set { _tsreset = value; } }
		public string ts_ExitText { get { return _tsexit; } set { _tsexit = value; } }
		public string ts_SeatText { get { return _tsstat; } set { _tsstat = value; } }
		public string ts_TotaltypeText { get { return _tstotaltype; } set { _tstotaltype = value; } }
		public string ts_TotslcollectText { get { return _tstotalcollect; } set { _tstotalcollect = value; } }
		public string ts_AcctuaryText { get { return _tsacctuary; } set { _tsacctuary = value; } }
		public string ts_TotalclearText { get { return _tstotalclear; } set { _tstotalclear = value; } }
		public string ts_TotalscoreText { get { return _tstotalscore; } set { _tstotalscore = value; } }
		public string ts_ClearText { get { return _tsclear; } set { _tsclear = value; } }
		public string ts_ClearreallyText { get { return _tsclearreally; } set { _tsclearreally = value; } }
		public string ts_HelpText { get { return _tshelp; } set { _tshelp = value; } }
		public string ts_AboutText { get { return _tsabout; } set { _tsabout = value; } }
		public string tx_GameoverText { get { return _txgameover; } set { _txgameover = value; } }
		public string tx_LastscoreText { get { return _txlastscore; } set { _txlastscore = value; } }
		public string tx_LasthighscoreText { get { return _txlasthighscore; } set { _txlasthighscore = value; } }
		public string tx_RemaintimeText { get { return _txremtime; } set { _txremtime = value; } }

		public Lang()
		{
			_tsstart = "Start";
			_tsreset = "Reset";
			_tsexit = "Exit";
			_tsstat = "Stat";
			_tstotaltype = "TotalType";
			_tstotalcollect = "TotalCollectType";
			_tsacctuary = "Acctualy";
			_tstotalclear = "TotalClear";
			_tstotalscore = "TotalScore";
			_tsclear = "Clear";
			_tsclearreally = "...Really?";
			_tshelp = "Help";
			_tsabout = "About";
			_txgameover = "Gameover";
			_txlastscore = "Score";
			_txlasthighscore = "Highscore";
			_txremtime = "TIME";
		}
	}
}
