using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace UWB_RTLS_6Tags_Visualization
{
    public partial class UWB_RTLS_6tags : Form
    {
        Image i1, i2, i3;
        Boolean draw1 = false;
        Graphics g, gc, path;

        Double t1x, t1y, t2x, t2y, t3x, t3y, t4x, t4y, t5x, t5y, t6x, t6y;
        Boolean check;

        Double An1x = 0, An1y = 0, An2x = 0, An2y = 6.1, An3x = 9.6, An3y = 6.1, An4x = 9.6, An4y = 0; // anchor position coordinates
        Double scx = 0.01513986014, scy = 0.01527593598; // scaling
        Int32 offx = 659, offy = 437;// image offset

        Stopwatch time = new Stopwatch();
        TimeSpan tstart1, tstop1;

        double dt;

        public UWB_RTLS_6tags()
        {
            InitializeComponent();

            i1 = new Bitmap("Childr.png");
            i2 = new Bitmap("Childg.png");
            i3 = new Bitmap("Childb.png");
        }

        private void UWB_RTLS_6tags_Load(object sender, EventArgs e)
        {
            Thread Data_Read1 = new Thread(new ThreadStart(data_read1));
            Data_Read1.Start();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
        }

        public void data_read1() // receiver thread
        {
            UdpClient UdpServer = new UdpClient(1200);
            IPEndPoint Sender = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                Datetime.Invoke(new Action(() => { Datetime.Text = System.DateTime.Now.ToString("d") + "\n" + System.DateTime.Now.ToString("h:mm:ss tt"); }));

                tstart1 = time.Elapsed;
                time.Start();

                Byte[] data1 = UdpServer.Receive(ref Sender);
                String line1 = Encoding.ASCII.GetString(data1);
                var part = line1.Split(',');

                if (Double.Parse(part[0]) == 1)
                {
                    t1x = offy - (Double.Parse(part[1]) / scx);
                    t1y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (Double.Parse(part[0]) == 2)
                {
                    t2x = offy - (Double.Parse(part[1]) / scx);
                    t2y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (Double.Parse(part[0]) == 3)
                {
                    t3x = offy - (Double.Parse(part[1]) / scx);
                    t3y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (Double.Parse(part[0]) == 4)
                {
                    t4x = offy - (Double.Parse(part[1]) / scx);
                    t4y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (Double.Parse(part[0]) == 5)
                {
                    t5x = offy - (Double.Parse(part[1]) / scx);
                    t5y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (Double.Parse(part[0]) == 6)
                {
                    t6x = offy - (Double.Parse(part[1]) / scx);
                    t6y = offx - (Double.Parse(part[2]) / scy);
                }
                else if (data1 == null)
                {
                    panel1.Invoke(new Action(() => { panel1.Refresh(); })); // panel refresh
                }
                draw1 = true;
                panel1.Invoke(new Action(() => { panel1.Invalidate(); })); // panel refresh

                time.Stop();
                tstop1 = time.Elapsed;
                dt = (Math.Round(tstop1.TotalMilliseconds, 5) - Math.Round(tstart1.TotalMilliseconds, 5));

                using (StreamWriter computationtime = new StreamWriter("computation data.txt", true))
                {
                    computationtime.WriteLine(System.DateTime.Now.ToString() + "   " + Double.Parse(part[0]) + "   " + Double.Parse(part[1]) + "   " + Double.Parse(part[2]) + "    " + Math.Round(dt, 3));
                }
            }
        } // receiver thread end

        private void panel1_mousemove(object sender, MouseEventArgs e)
        {
            xy_values.Text = "X: " + Math.Round((e.X * scx), 3) + "\n" + "Y: " + Math.Round((e.Y * scy), 3);
        }

        private void panel1_mousedown(object sender, MouseEventArgs e)
        {
            Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        }

        private void panel1_paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            path = Graphics.FromImage(panel1.BackgroundImage);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;

            if (draw1 == true)
            {
                g.DrawImage(i1, Convert.ToInt32(t1y), Convert.ToInt32(t1x), 18, 21);
                g.DrawString("1", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t1y) + 30 / 2, Convert.ToInt32(t1x), sf);
                g.DrawImage(i2, Convert.ToInt32(t2y), Convert.ToInt32(t2x), 18, 21);
                g.DrawString("2", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t2y) + 30 / 2, Convert.ToInt32(t2x), sf);
                g.DrawImage(i3, Convert.ToInt32(t3y), Convert.ToInt32(t3x), 18, 21);
                g.DrawString("3", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t3y) + 30 / 2, Convert.ToInt32(t3x), sf);
                g.DrawImage(i1, Convert.ToInt32(t4y), Convert.ToInt32(t4x), 18, 21);
                g.DrawString("4", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t4y) + 30 / 2, Convert.ToInt32(t4x), sf);
                g.DrawImage(i2, Convert.ToInt32(t5y), Convert.ToInt32(t5x), 18, 21);
                g.DrawString("5", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t5y) + 30 / 2, Convert.ToInt32(t5x), sf);
                g.DrawImage(i3, Convert.ToInt32(t6y), Convert.ToInt32(t6x), 18, 21);
                g.DrawString("6", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(t6y) + 30 / 2, Convert.ToInt32(t6x), sf);
            }
            if (check == true)
            {
                path.FillEllipse(Brushes.OrangeRed, Convert.ToInt32(t1y), Convert.ToInt32(t1x), 5, 5);
                path.FillEllipse(Brushes.Green, Convert.ToInt32(t2y), Convert.ToInt32(t2x), 5, 5);
                path.FillEllipse(Brushes.RoyalBlue, Convert.ToInt32(t3y), Convert.ToInt32(t3x), 5, 5);
                path.FillEllipse(Brushes.OrangeRed, Convert.ToInt32(t4y), Convert.ToInt32(t4x), 5, 5);
                path.FillEllipse(Brushes.Green, Convert.ToInt32(t5y), Convert.ToInt32(t5x), 5, 5);
                path.FillEllipse(Brushes.RoyalBlue, Convert.ToInt32(t6y), Convert.ToInt32(t6x), 5, 5);
            }
        }

        private void tags_tracking_CheckedChanged(object sender, EventArgs e)
        {
            if (tags_tracking.Checked)
            {
                check = true;
            }
            else
            {
                check = false;
                path.Clear(panel1.BackColor);
                panel1.BackgroundImage = new Bitmap("room_208.jpg");
            }
        }

        private void show_anchors_check(object sender, EventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;
            using (gc = Graphics.FromImage(panel1.BackgroundImage))
            {
                if (show_anchors.Checked)
                {
                    gc.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An1x / scx)), Convert.ToInt32(offy - (An1y / scy)), 10, 10);
                    gc.DrawString("1", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An1x / scx)) + 10 / 2, Convert.ToInt32(offy - (An1y / scy)), sf);

                    gc.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An2x / scx)), Convert.ToInt32(offy - (An2y / scy)), 10, 10);
                    gc.DrawString("2", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An2x / scx)) + 8 / 2, Convert.ToInt32(offy - (An2y / scy)), sf);

                    gc.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An3x / scx)), Convert.ToInt32(offy - (An3y / scy)), 10, 10);
                    gc.DrawString("3", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An3x / scx)) + 8 / 2, Convert.ToInt32(offy - (An3y / scy)), sf);

                    gc.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An4x / scx)), Convert.ToInt32(offy - (An4y / scy)), 10, 10);
                    gc.DrawString("4", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An4x / scx)) + 10 / 2, Convert.ToInt32(offy - (An4y / scy)), sf);
                }
                else
                {
                    gc.Clear(SystemColors.Control);
                    panel1.BackgroundImage = new Bitmap("room_208.jpg ");
                }
            }

        }
    }
}
    
