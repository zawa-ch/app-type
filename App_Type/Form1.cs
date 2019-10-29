using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace App_Type
{
    public partial class Form1 : Form
    {
        const int WM_SYSCOMMAND = 0x112;
        const int SC_MOVE = 0xF010;

        [DllImport("User32.dll")]
        public static extern bool SetCapture(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 押下状態を記憶しておく変数

        private string disp_alp = "";
        private string disp_jpn = "";
        private string input_key = " ";
        int remain_time = 100;
        int ctdn_time = 3;
        int score = 0;
        int index = 0;
        int difficulty_sel = 0;
        int[] difficulty = new int[5];
        int latespeed = 100;
        int speed;
        bool flag_gameover = true;
        List<string> type_txt = new List<string>();
        List<string> type_dsp = new List<string>();
        StreamReader sra = new StreamReader("a.txt", Encoding.GetEncoding("Shift_JIS"));
        StreamReader srb = new StreamReader("b.txt", Encoding.GetEncoding("Shift_JIS"));
        string txtbuf="";
        int dbuf = 0;
        int strlng = 0;
        Random rnd = new Random();
        int[] timelinelng = new int[3];
        int highscore = 0;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // キー押下時イベントを登録
            this.KeyUp += new KeyEventHandler(Form1_KeyUp); // キーを離した時のイベントを登録
            label1.Text = "Initializing...";
            //↓かつてのシステムの名残www
            difficulty[0] = 200;
            difficulty[1] = 100;
            difficulty[2] = 50;
            difficulty[3] = 20;
            difficulty[4] = 5;
            timer1.Interval = difficulty[difficulty_sel];
            //タイピング文字列データ読み込み
            while ((txtbuf = sra.ReadLine()) != null)
            {
                type_txt.Add(txtbuf);
            }
            while ((txtbuf = srb.ReadLine()) != null)
            {
                type_dsp.Add(txtbuf);
            }
            //ハイスコアデータ読み込み
            FileStream fst = new FileStream("highscore.txt",FileMode.OpenOrCreate,FileAccess.Read);
            fst.Close();
            using (StreamReader ld_high = new StreamReader("highscore.txt", Encoding.GetEncoding("Shift_JIS")))
            {
                txtbuf = ld_high.ReadToEnd();
                bool b = int.TryParse(txtbuf, out highscore);
            }
            init();
        }

        private void init()
        {
            timer1.Stop();
            timer2.Stop();
            flag_gameover = true;
            score = 0;
            remain_time = 100;
            latespeed = 100;
            ctdn_time = 3;
            disp_alp = "";
            index = rnd.Next(type_txt.Count);
            label1.Text = "Typing Game ver 1.02";
            label2.Text = " ";
            label3.Text = "TIME : " + remain_time.ToString();
            label4.Text = "App_Type";
            toolStripStatusLabel1.Text = "SCORE : " + score.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // キー押下時イベントプロシジャ
        {
            input_key = e.KeyCode.ToString();
            if (e.KeyCode.ToString().Equals("OemMinus")) input_key = "-";
            if (input_key.Length > 1) input_key = "";
            input_key = input_key.ToLowerInvariant();

            if (flag_gameover == false)
            //ゲームが動作中か判定
            {
                if (input_key.Length != 0 && disp_alp.StartsWith(input_key))
                //入力キーが指定されたものと一致しているか判定
                {
                    disp_alp = disp_alp.Substring(1, disp_alp.Length - 1);
                    score++;
                    remain_time+=2;
                    if (disp_alp.Length == 0)
                    //文章の入力が完了した場合次の文章を表示
                    {
                        dbuf = index;
                        remain_time += strlng;
                        do
                        //直前に入力した文章と同じものが出ないよう調整
                        {
                            index = rnd.Next(type_txt.Count);
                        } while (dbuf == index);
                        disp_alp = type_txt[index];
                        disp_jpn = type_dsp[index];
                        strlng = disp_alp.Length;
                        latespeed+=5;
                        speed = difficulty[difficulty_sel] * 100;
                        speed /= latespeed;
                        timer1.Interval = speed;
                    }
                }
                else if (input_key!="")
                //入力キーがEnterなどのシステムキーではなく、かつ間違った入力の場合SCOREを-1する
                {
                    score--;
                    if (score < 0) score = 0;
                }
                //表示を更新
                label1.Text = disp_alp;
                label4.Text = disp_jpn;
            }
            //[デバッグ用]入力キーの履歴を更新
            label2.Text = label2.Text.Insert(0, input_key);
//            label2.Text = label2.Text.Insert(0, e.KeyCode.ToString());
//            if (label2.Text.Length > 10);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) // キーを離した時のイベントプロシジャ
        {
            //しかし、中身はミミックだった
        }

        private void exitQToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Exitボタンをクリックしたときの反応
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {   //フォームをクリックしたときにフォームを移動
            SetCapture(this.Handle);
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //一定時間ごとに作動(ゲームのタイマ)
            if (remain_time <= 0)
            //残り時間が0の場合、ゲーム終了
            {
                timer1.Stop();
                flag_gameover = true;
                if (score > highscore)
                //最終スコアがハイスコアか判定
                {
                    label1.Text = "スコア : " + score.ToString() + " → ハイスコア";
                    highscore = score;
                    using (StreamWriter sv_high = new StreamWriter("highscore.txt"))
                    {
                    //ハイスコアデータを更新,セーブする
                        txtbuf = highscore.ToString();
                        sv_high.Write(txtbuf);
                    }
                }
                else
                {
                    label1.Text = "スコア : " + score.ToString();
                }
                label4.Text = "ゲームオーバー!";
            }
            if (flag_gameover == false)
            //残り時間を-1して、表示更新
                remain_time--;
            label3.Text = "TIME : "+remain_time.ToString();
        }

        private void staetSToolStripMenuItem_Click(object sender, EventArgs e)
        //スタートボタンクリック時の反応(staetになっているのはタイポですwww)
        {
            if (flag_gameover == true)
            //すでにゲームが動作しているときは動かないようにする
            {
                remain_time = 100;
                score = 0;
                latespeed = 100;
                timer2.Start();
                label1.Text = "";
                label4.Text = "Ready... "+ctdn_time.ToString();
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (false)
            {
                timer1.Stop();
                timer2.Stop();
                flag_gameover = true;
                score = 0;
                remain_time = 100;
                latespeed = 100;
                ctdn_time = 3;
                label3.Text = "TIME : " + remain_time.ToString();
                disp_alp = "";
                index = rnd.Next(type_txt.Count);
                label1.Text = " ";
                label4.Text = "App_Type";
            }*/
            init();
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("タイピングゲーム\nApp_Type\nver.1.02\n\nzawa-ch. 2015");
        }

        private void timer2_Tick(object sender, EventArgs e)
        //一定時間ごとに作動(ゲーム開始前カウントダウン)
        {
            ctdn_time--;
            label4.Text = "Ready... "+ctdn_time.ToString();
            label1.Text = " ";
            if (ctdn_time <= 0)
            {
                flag_gameover = false;
                timer2.Stop();
                timer1.Start();
                index = rnd.Next(type_txt.Count);
                disp_alp = type_txt[index];
                disp_jpn = type_dsp[index];
                label1.Text = disp_alp;
                label4.Text = disp_jpn;
                ctdn_time = 3;
            }
        }

        private void timer_timelinetick_Tick(object sender, EventArgs e)
        //一定時間ごとに作動(ゲームのシステムタイマ)
        {
            timelinelng[0] = img_timeline.Width;
            timelinelng[1] = remain_time;
            timelinelng[2] = (timelinelng[1] - timelinelng[0])/4;
            img_timeline.Width = timelinelng[0] + timelinelng[2];
            Stat_speedrate.Text = "Rate : x" + (latespeed / 100.0).ToString();
            toolStripStatusLabel1.Text = "SCORE : " + score.ToString();
            Stat_highscore.Text = "HIGHSCORE : " + highscore.ToString();
        }

        private void openreadmeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", @"""readme.txt""");

        }
    }
}
