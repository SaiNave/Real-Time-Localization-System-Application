using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace zone_tracking_6tags
{
    public partial class Form1 : Form
    {
        Pen pen1;
        Rectangle r1, roff1, r2, roff2;
        Image i1, i2, i3;
        Boolean draw1 = false;
        Graphics g, gc, path, gc1;

        Double t1x, t1y, t2x, t2y, t3x, t3y, t4x, t4y, t5x, t5y, t6x, t6y;

        Boolean check;

        Double An1x = 0, An1y = 0, An2x = 0, An2y = 6.1, An3x = 9.6, An3y = 6.1, An4x = 9.6, An4y = 0; // anchor position coordinates
        Double scx = 0.01513986014, scy = 0.01527593598; // scaling
        Int32 offx = 659, offy = 437;// image offsets

        double dt = 0, dt1z1 = 0, dt1z2 = 0, dt2z1 = 0, dt2z2 = 0, dt3z1 = 0, dt3z2 = 0, dt4z1 = 0, dt4z2 = 0, dt5z1 = 0, dt5z2 = 0, dt6z1 = 0, dt6z2 = 0;

        int count1z1 = 0, count1z2 = 0;
        int count2z1 = 0, count2z2 = 0;
        int count3z1 = 0, count3z2 = 0;
        int count4z1 = 0, count4z2 = 0;
        int count5z1 = 0, count5z2 = 0;
        int count6z1 = 0, count6z2 = 0;

        Stopwatch time = new Stopwatch();
        TimeSpan tstart1, tstop1;

        Stopwatch watch1z1 = new Stopwatch();
        Stopwatch watch1z2 = new Stopwatch();
        Stopwatch watch2z1 = new Stopwatch();
        Stopwatch watch2z2 = new Stopwatch();
        Stopwatch watch3z1 = new Stopwatch();
        Stopwatch watch3z2 = new Stopwatch();
        Stopwatch watch4z1 = new Stopwatch();
        Stopwatch watch4z2 = new Stopwatch();
        Stopwatch watch5z1 = new Stopwatch();
        Stopwatch watch5z2 = new Stopwatch();
        Stopwatch watch6z1 = new Stopwatch();
        Stopwatch watch6z2 = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            pen1 = new Pen(Color.BlanchedAlmond, 2);
            r1 = new Rectangle(0, 28, 200, 170);
            roff1 = new Rectangle(0, 20, 210, 190);
            r2 = new Rectangle(0, 282, 200, 170);
            roff2 = new Rectangle(0, 266, 210, 190);

            i1 = new Bitmap("Childr.png");
            i2 = new Bitmap("Childg.png");
            i3 = new Bitmap("Childb.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread Data_Read1 = new Thread(new ThreadStart(data_read1));
            Data_Read1.Start();

            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, panel1, new object[] { true });
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

                    if (roff1.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x)))
                    {
                        zone1_for_tag1();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x)))
                    {
                        zone2_for_tag1();
                    }
                }
                else if (Double.Parse(part[0]) == 2)
                {
                    t2x = offy - (Double.Parse(part[1]) / scx);
                    t2y = offx - (Double.Parse(part[2]) / scy);

                    if (roff1.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x)))
                    {
                        zone1_for_tag2();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x)))
                    {
                        zone2_for_tag2();
                    }
                }
                else if (Double.Parse(part[0]) == 3)
                {
                    t3x = offy - (Double.Parse(part[1]) / scx);
                    t3y = offx - (Double.Parse(part[2]) / scy);

                    if (roff1.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x)))
                    {
                        zone1_for_tag3();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x)))
                    {
                        zone2_for_tag3();
                    }
                }
                else if (Double.Parse(part[0]) == 4)
                {
                    t4x = offy - (Double.Parse(part[1]) / scx);
                    t4y = offx - (Double.Parse(part[2]) / scy);

                    if (roff1.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x)))
                    {
                        zone1_for_tag4();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x)))
                    {
                        zone2_for_tag4();
                    }
                }
                else if (Double.Parse(part[0]) == 5)
                {
                    t5x = offy - (Double.Parse(part[1]) / scx);
                    t5y = offx - (Double.Parse(part[2]) / scy);

                    if (roff1.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x)))
                    {
                        zone1_for_tag5();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x)))
                    {
                        zone2_for_tag5();
                    }
                }
                else if (Double.Parse(part[0]) == 6)
                {
                    t6x = offy - (Double.Parse(part[1]) / scx);
                    t6y = offx - (Double.Parse(part[2]) / scy);

                    if (roff1.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x)))
                    {
                        zone1_for_tag6();
                    }
                    else if (roff2.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x)))
                    {
                        zone2_for_tag6();
                    }
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
                    computationtime.WriteLine(System.DateTime.Now.ToString() + "\t" + Double.Parse(part[0]) + "\t" + Double.Parse(part[1]) + "\t" + Double.Parse(part[2]) + "\t" + Math.Round(dt, 3));
                }
            }
        } // receiver thread end

        int temp1 = 0, pretemp1 = 0, temp11 = 0, pretemp11 = 0;
        private void zone1_for_tag1()
        {
            if (!r1.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x))) // r1 is the rectangle1
            {
                pretemp1 = temp1;
                temp1 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x)))
            {
                pretemp1 = temp1;
                if (temp1 == 1)
                {
                    temp1 = 2;
                }
            }
            if ((temp1 == 2) && (pretemp1 != temp1))
            {
                count1z1 += 1;
                watch1z1 = Stopwatch.StartNew();
                entrytime1z1.Invoke(new Action(() => { entrytime1z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag1_countz1.Invoke(new Action(() => { tag1_countz1.Text = count1z1.ToString(); }));
                time1z1.Invoke(new Action(() => { time1z1.Text = "  ".ToString(); }));
                tag1idz1.Invoke(new Action(() => { tag1idz1.Text = "1".ToString(); }));
            }
            if ((temp1 == 1) && (pretemp1 != temp1))
            {
                watch1z1.Stop();
                dt1z1 = (watch1z1.ElapsedTicks) / Stopwatch.Frequency;
                time1z1.Invoke(new Action(() => { time1z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + "\t" + 1 + "\t" + count1z1 + "\t" + dt1z1.ToString() + "\t" + (dt1z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag1()
        {
            if (!r2.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x))) // r1 is the rectangle1
            {
                pretemp11 = temp11;
                temp11 = 1;

            }
            if (r2.Contains(Convert.ToInt32(t1y), Convert.ToInt32(t1x)))
            {
                pretemp11 = temp11;
                if (temp11 == 1)
                {
                    temp11 = 2;
                }
            }
            if ((temp11 == 2) && (pretemp11 != temp11))
            {
                count1z2 += 1;
                watch1z2 = Stopwatch.StartNew();

                entrytime1z2.Invoke(new Action(() => { entrytime1z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag1_countz2.Invoke(new Action(() => { tag1_countz2.Text = count1z2.ToString(); }));
                time1z2.Invoke(new Action(() => { time1z2.Text = "  ".ToString(); }));
                tag1idz2.Invoke(new Action(() => { tag1idz2.Text = "1".ToString(); }));
            }
            if ((temp11 == 1) && (pretemp11 != temp11))
            {
                watch1z2.Stop();
                dt1z2 = (watch1z2.ElapsedTicks) / Stopwatch.Frequency;
                time1z2.Invoke(new Action(() => { time1z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + "\t" + 1 + "\t" + count1z2 + "\t" + dt1z2.ToString() + "\t" + (dt1z2 / 60).ToString());
                }
            }
        }

        int temp2 = 0, pretemp2 = 0, temp22 = 0, pretemp22 = 0;
        private void zone1_for_tag2() //number of entries
        {
            if (!r1.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x))) // r1 is the rectangle1
            {
                pretemp2 = temp2;
                temp2 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x)))
            {
                pretemp2 = temp2;
                if (temp2 == 1)
                {
                    temp2 = 2;
                }
            }
            if ((temp2 == 2) && (pretemp2 != temp2))
            {
                count2z1 += 1;
                watch2z1 = Stopwatch.StartNew();

                entrytime2z1.Invoke(new Action(() => { entrytime2z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag2_countz1.Invoke(new Action(() => { tag2_countz1.Text = count2z1.ToString(); }));
                time2z1.Invoke(new Action(() => { time2z1.Text = "  ".ToString(); }));
                tag2idz1.Invoke(new Action(() => { tag2idz1.Text = "2".ToString(); }));
            }
            if ((temp2 == 1) && (pretemp2 != temp2))
            {
                watch2z1.Stop();
                dt2z1 = (watch2z1.ElapsedTicks) / Stopwatch.Frequency;
                time2z1.Invoke(new Action(() => { time2z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + "\t" + 2 + "\t" + count2z1 + "\t" + dt2z1.ToString() + "\t" + (dt2z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag2() //number of entries
        {
            if (!r2.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x))) // r1 is the rectangle1
            {
                pretemp22 = temp22;
                temp22 = 1;
            }
            if (r2.Contains(Convert.ToInt32(t2y), Convert.ToInt32(t2x)))
            {
                pretemp22 = temp22;
                if (temp22 == 1)
                {
                    temp22 = 2;
                }
            }
            if ((temp22 == 2) && (pretemp22 != temp22))
            {
                count2z2 += 1;
                watch2z2 = Stopwatch.StartNew();

                entrytime2z2.Invoke(new Action(() => { entrytime2z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag2_countz2.Invoke(new Action(() => { tag2_countz2.Text = count2z2.ToString(); }));
                time2z2.Invoke(new Action(() => { time2z2.Text = "  ".ToString(); }));
                tag2idz2.Invoke(new Action(() => { tag2idz2.Text = "2".ToString(); }));
            }
            if ((temp22 == 1) && (pretemp22 != temp22))
            {
                watch2z2.Stop();
                dt2z2 = (watch2z2.ElapsedTicks) / Stopwatch.Frequency;
                time2z2.Invoke(new Action(() => { time2z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + " \t " + 2 + " \t " + count2z2 + " \t " + dt2z2.ToString() + " \t " + (dt2z2 / 60).ToString());
                }
            }
        }

        int temp3 = 0, pretemp3 = 0, temp33 = 0, pretemp33 = 0;
        private void zone1_for_tag3() //number of entries
        {
            if (!r1.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x))) // r1 is the rectangle1
            {
                pretemp3 = temp3;
                temp3 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x)))
            {
                pretemp3 = temp3;
                if (temp3 == 1)
                {
                    temp3 = 2;
                }
            }
            if ((temp3 == 2) && (pretemp3 != temp3))
            {
                count3z1 += 1;
                watch3z1 = Stopwatch.StartNew();

                entrytime3z1.Invoke(new Action(() => { entrytime3z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag3_countz1.Invoke(new Action(() => { tag3_countz1.Text = count3z1.ToString(); }));
                time3z1.Invoke(new Action(() => { time3z1.Text = "  ".ToString(); }));
                tag3idz1.Invoke(new Action(() => { tag3idz1.Text = "3".ToString(); }));
            }
            if ((temp3 == 1) && (pretemp3 != temp3))
            {
                watch3z1.Stop();
                dt3z1 = (watch3z1.ElapsedTicks) / Stopwatch.Frequency;
                time3z1.Invoke(new Action(() => { time3z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + " \t " + 3 + " \t " + count3z1 + " \t " + dt3z1.ToString() + " \t " + (dt3z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag3()
        {
            if (!r2.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x))) // r1 is the rectangle1
            {
                pretemp33 = temp33;
                temp33 = 1;
            }
            if (r2.Contains(Convert.ToInt32(t3y), Convert.ToInt32(t3x)))
            {
                pretemp33 = temp33;
                if (temp33 == 1)
                {
                    temp33 = 2;
                }
            }
            if ((temp33 == 2) && (pretemp33 != temp33))
            {
                count3z2 += 1;
                watch3z2 = Stopwatch.StartNew();

                entrytime3z2.Invoke(new Action(() => { entrytime3z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag3_countz2.Invoke(new Action(() => { tag3_countz2.Text = count3z2.ToString(); }));
                time3z2.Invoke(new Action(() => { time3z2.Text = "  ".ToString(); }));
                tag3idz2.Invoke(new Action(() => { tag3idz2.Text = "3".ToString(); }));
            }
            if ((temp33 == 1) && (pretemp33 != temp33))
            {
                watch3z2.Stop();
                dt3z2 = (watch3z2.ElapsedTicks) / Stopwatch.Frequency;
                time3z2.Invoke(new Action(() => { time3z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + " \t " + 3 + " \t " + count3z2 + " \t " + dt3z2.ToString() + " \t " + (dt3z2 / 60).ToString());
                }
            }
        }

        int temp4 = 0, pretemp4 = 0, temp44 = 0, pretemp44 = 0;
        private void zone1_for_tag4()
        {
            if (!r1.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x))) // r1 is the rectangle1
            {
                pretemp4 = temp4;
                temp4 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x)))
            {
                pretemp4 = temp4;
                if (temp4 == 1)
                {
                    temp4 = 2;
                }
            }
            if ((temp4 == 2) && (pretemp4 != temp4))
            {
                count4z1 += 1;
                watch4z1 = Stopwatch.StartNew();
                entrytime4z1.Invoke(new Action(() => { entrytime4z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag4_countz1.Invoke(new Action(() => { tag4_countz1.Text = count4z1.ToString(); }));
                time4z1.Invoke(new Action(() => { time4z1.Text = "  ".ToString(); }));
                tag4idz1.Invoke(new Action(() => { tag4idz1.Text = "4".ToString(); }));
            }
            if ((temp4 == 1) && (pretemp4 != temp4))
            {
                watch4z1.Stop();
                dt4z1 = (watch4z1.ElapsedTicks) / Stopwatch.Frequency;
                time4z1.Invoke(new Action(() => { time4z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + "\t" + 4 + " \t " + count4z1 + " \t " + dt4z1.ToString() + " \t " + (dt4z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag4()
        {
            if (!r2.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x))) // r1 is the rectangle1
            {
                pretemp44 = temp44;
                temp44 = 1;

            }
            if (r2.Contains(Convert.ToInt32(t4y), Convert.ToInt32(t4x)))
            {
                pretemp44 = temp44;
                if (temp44 == 1)
                {
                    temp44 = 2;
                }
            }
            if ((temp44 == 2) && (pretemp44 != temp44))
            {
                count4z2 += 1;
                watch4z2 = Stopwatch.StartNew();

                entrytime4z2.Invoke(new Action(() => { entrytime4z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag4_countz2.Invoke(new Action(() => { tag4_countz2.Text = count4z2.ToString(); }));
                time4z2.Invoke(new Action(() => { time4z2.Text = "  ".ToString(); }));
                tag4idz2.Invoke(new Action(() => { tag4idz2.Text = "4".ToString(); }));
            }
            if ((temp44 == 1) && (pretemp44 != temp44))
            {
                watch4z2.Stop();
                dt4z2 = (watch4z2.ElapsedTicks) / Stopwatch.Frequency;
                time4z2.Invoke(new Action(() => { time4z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + " \t " + 4 + "\t " + count4z2 + "\t " + dt4z2.ToString() + " \t " + (dt4z2 / 60).ToString());
                }
            }
        }

        int temp5, pretemp5 = 0, temp55 = 0, pretemp55 = 0;
        private void zone1_for_tag5()
        {
            if (!r1.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x))) // r1 is the rectangle1
            {
                pretemp5 = temp5;
                temp5 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x)))
            {
                pretemp5 = temp5;
                if (temp5 == 1)
                {
                    temp5 = 2;
                }
            }
            if ((temp5 == 2) && (pretemp5 != temp5))
            {
                count5z1 += 1;
                watch5z1 = Stopwatch.StartNew();
                entrytime5z1.Invoke(new Action(() => { entrytime5z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag5_countz1.Invoke(new Action(() => { tag5_countz1.Text = count5z1.ToString(); }));
                time5z1.Invoke(new Action(() => { time5z1.Text = "  ".ToString(); }));
                tag5idz1.Invoke(new Action(() => { tag5idz1.Text = "5".ToString(); }));
            }
            if ((temp5 == 1) && (pretemp5 != temp5))
            {
                watch5z1.Stop();
                dt5z1 = (watch5z1.ElapsedTicks) / Stopwatch.Frequency;
                time5z1.Invoke(new Action(() => { time5z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + " \t " + 5 + " \t " + count5z1 + " \t " + dt5z1.ToString() + " \t " + (dt5z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag5()
        {
            if (!r2.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x))) // r1 is the rectangle1
            {
                pretemp55 = temp55;
                temp55 = 1;

            }
            if (r2.Contains(Convert.ToInt32(t5y), Convert.ToInt32(t5x)))
            {
                pretemp55 = temp55;
                if (temp55 == 1)
                {
                    temp55 = 2;
                }
            }
            if ((temp55 == 2) && (pretemp55 != temp55))
            {
                count5z2 += 1;
                watch5z2 = Stopwatch.StartNew();

                entrytime5z2.Invoke(new Action(() => { entrytime5z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag5_countz2.Invoke(new Action(() => { tag5_countz2.Text = count5z2.ToString(); }));
                time5z2.Invoke(new Action(() => { time5z2.Text = "  ".ToString(); }));
                tag5idz2.Invoke(new Action(() => { tag5idz2.Text = "5".ToString(); }));
            }
            if ((temp55 == 1) && (pretemp55 != temp55))
            {
                watch5z2.Stop();
                dt5z2 = (watch5z2.ElapsedTicks) / Stopwatch.Frequency;
                time5z2.Invoke(new Action(() => { time5z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + " \t " + 5 + " \t " + count5z2 + " \t " + dt5z2.ToString() + " \t " + (dt5z2 / 60).ToString());
                }
            }
        }

        int temp6 = 0, pretemp6 = 0, temp66 = 0, pretemp66 = 0;
        private void zone1_for_tag6()
        {
            if (!r1.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x))) // r1 is the rectangle1
            {
                pretemp6 = temp6;
                temp6 = 1;
            }
            if (r1.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x)))
            {
                pretemp6 = temp6;
                if (temp6 == 1)
                {
                    temp6 = 2;
                }
            }
            if ((temp6 == 2) && (pretemp6 != temp6))
            {
                count6z1 += 1;
                watch6z1 = Stopwatch.StartNew();
                entrytime6z1.Invoke(new Action(() => { entrytime6z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag6_countz1.Invoke(new Action(() => { tag6_countz1.Text = count6z1.ToString(); }));
                time6z1.Invoke(new Action(() => { time6z1.Text = "  ".ToString(); }));
                tag6idz1.Invoke(new Action(() => { tag6idz1.Text = "6".ToString(); }));
            }
            if ((temp6 == 1) && (pretemp6 != temp6))
            {
                watch6z1.Stop();
                dt6z1 = (watch6z1.ElapsedTicks) / Stopwatch.Frequency;
                time6z1.Invoke(new Action(() => { time6z1.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                using (StreamWriter file1 = new StreamWriter("zone1.txt", true))
                {
                    file1.WriteLine(System.DateTime.Now.ToString() + " \t " + 6 + " \t " + count6z1 + " \t " + dt6z1.ToString() + " \t " + (dt6z1 / 60).ToString());
                }
            }
        }
        private void zone2_for_tag6()
        {
            if (!r2.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x))) // r1 is the rectangle1
            {
                pretemp66 = temp66;
                temp66 = 1;
            }
            if (r2.Contains(Convert.ToInt32(t6y), Convert.ToInt32(t6x)))
            {
                pretemp66 = temp66;
                if (temp66 == 1)
                {
                    temp66 = 2;
                }
            }
            if ((temp66 == 2) && (pretemp66 != temp66))
            {
                count6z2 += 1;
                watch6z2 = Stopwatch.StartNew();

                entrytime6z2.Invoke(new Action(() => { entrytime6z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));
                tag6_countz2.Invoke(new Action(() => { tag6_countz2.Text = count6z2.ToString(); }));
                time6z2.Invoke(new Action(() => { time6z2.Text = "  ".ToString(); }));
                tag6idz2.Invoke(new Action(() => { tag6idz2.Text = "6".ToString(); }));
            }
            if ((temp66 == 1) && (pretemp66 != temp66))
            {
                watch6z2.Stop();
                dt6z2 = (watch6z2.ElapsedTicks) / Stopwatch.Frequency;
                time6z2.Invoke(new Action(() => { time6z2.Text = System.DateTime.Now.ToString("h:mm:ss tt"); }));

                using (StreamWriter file2 = new StreamWriter("zone2.txt", true))
                {
                    file2.WriteLine(System.DateTime.Now.ToString() + " \t " + 6 + " \t " + count6z2 + "\t  " + dt6z2.ToString() + " \t " + (dt6z2 / 60).ToString());
                }
            }
        }

        private void panel1_mousemove(object sender, MouseEventArgs e)
        {
            xy_values.Text = "X: " + Math.Round((e.X * scx), 3) + "\n" + "Y: " + Math.Round((e.Y * scy), 3);
        }

        private void panel1_mousedown(object sender, MouseEventArgs e)
        {
            Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
                path.FillEllipse(Brushes.OrangeRed, Convert.ToInt32(t1y + 5), Convert.ToInt32(t1x + 5), 3, 3);
                path.FillEllipse(Brushes.Green, Convert.ToInt32(t2y + 5), Convert.ToInt32(t2x + 4), 3, 3);
                path.FillEllipse(Brushes.RoyalBlue, Convert.ToInt32(t3y + 5), Convert.ToInt32(t3x + 5), 3, 3);
                path.FillEllipse(Brushes.OrangeRed, Convert.ToInt32(t4y + 5), Convert.ToInt32(t4x + 5), 3, 3);
                path.FillEllipse(Brushes.Green, Convert.ToInt32(t5y + 5), Convert.ToInt32(t5x + 5), 3, 3);
                path.FillEllipse(Brushes.RoyalBlue, Convert.ToInt32(t6y + 5), Convert.ToInt32(t6x + 5), 3, 3);
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
                panel1.BackgroundImage = new Bitmap("room_208_4F.jpg");
            }
        }

        private void show_anchors(object sender, EventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;
            using (gc1 = Graphics.FromImage(panel1.BackgroundImage))
            {
                if (show_anchors_check.Checked)
                {
                    gc1.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An1x / scx)), Convert.ToInt32(offy - (An1y / scy)), 10, 10);
                    gc1.DrawString("1", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An1x / scx)) + 10 / 2, Convert.ToInt32(offy - (An1y / scy)), sf);

                    gc1.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An2x / scx)), Convert.ToInt32(offy - (An2y / scy)), 10, 10);
                    gc1.DrawString("2", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An2x / scx)) + 8 / 2, Convert.ToInt32(offy - (An2y / scy)), sf);

                    gc1.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An3x / scx)), Convert.ToInt32(offy - (An3y / scy)), 10, 10);
                    gc1.DrawString("3", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An3x / scx)) + 8 / 2, Convert.ToInt32(offy - (An3y / scy)), sf);

                    gc1.FillEllipse(Brushes.Red, Convert.ToInt32(offx - (An4x / scx)), Convert.ToInt32(offy - (An4y / scy)), 10, 10);
                    gc1.DrawString("4", SystemFonts.DialogFont, Brushes.Black, Convert.ToInt32(offx - (An4x / scx)) + 10 / 2, Convert.ToInt32(offy - (An4y / scy)), sf);
                }
                else
                {
                    gc1.Clear(SystemColors.Control);
                    panel1.BackgroundImage = new Bitmap("room_208_4F.jpg ");
                }
            }
        }
        private void ZoneArea_CheckedChanged(object sender, EventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;
            using (gc = Graphics.FromImage(panel1.BackgroundImage))
            {
                if (ZoneArea.Checked)
                {
                    gc.DrawRectangle(pen1, r1);
                    gc.DrawString("zone1", SystemFonts.DialogFont, Brushes.Black, 10 + 40 / 2, 45, sf);
                    gc.DrawRectangle(pen1, r2);
                    gc.DrawString("zone2", SystemFonts.DialogFont, Brushes.Black, 10 + 40 / 2, 305, sf);
                }
                else
                {
                    gc.Clear(SystemColors.Control);
                    panel1.BackgroundImage = new Bitmap("room_208_4F.jpg ");

                }
            }
        }
    }
}
