using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v0827
{
    public partial class Form1 : Form
    {
        int vx = -10;
        int vy = -10;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;

            if(label1.Left < 0)
            {
                vx = Math.Abs(vx);
            }
            if(label1.Top < 0)
            {
                vy = Math.Abs(vy);
            }
            if(label1.Right > ClientSize.Width)
            {
                vx = -Math.Abs(vx);
            }
            if(label1.Bottom > ClientSize.Height)
            {
                vy = -Math.Abs(vy);
            }
            // 2次元クラスPoint型の変数mpを宣言
            Point mp = MousePosition;

            // mpに、マウスのフォーム座標を取り出す。
            //// MousePositionにマウス座標のスクリーン左上からのX、Yが入っている。
            //// PointToClient()を使うと、スクリーン座標を、フォーム座標に変換できる。
            mp = PointToClient(mp);

            // ラベルに座標を表示
            //// 変換したフォーム座標は、mp.X、mp.Yで取り出せる。
            label2.Text = "" + mp.X + "," + mp.Y;

            // aが0で、かつ、bが0
            if ((mp.X >= label1.Left) && (mp.X < label1.Right) && (mp.Y >= label1.Top) && (mp.Y < label1.Bottom))
            {
                timer1.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
