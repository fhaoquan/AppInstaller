using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Install
{
    public partial class mainFrm : CForm
    {
        public mainFrm()
        {
            InitializeComponent();
            this.FormClosing += (a, b) =>
            {
                if (installing) b.Cancel = true;
            };
        }
        bool installing = false;
        string path = Paths.ProgramFiles + "\\";
        Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream("Install.dyp.zip");
        private delegate void setLoad(object i);
        private void start(object sender, EventArgs e)
        {
            try
            {
                installing = true;
                process.Visible = true;
                btnstart.Visible = false;
                Directory.CreateDirectory(path + "DeYiPai");
                Directory.CreateDirectory(path + "DeYiPai\\x86");
                Directory.CreateDirectory(path + "DeYiPai\\tessdata");


                //新建ManualResetEvent对象并且初始化为无信号状态
                ManualResetEvent eventX = new ManualResetEvent(false);
                ThreadPool.SetMaxThreads(3, 3);

                ThreadPool.QueueUserWorkItem(new WaitCallback(unzip));

                //   Paths.CreateShortCut("德易拍文档管理器", path + "DeYiPai\\DocumentManager.exe", "", "", "");
                Paths.CreateShortCut("德易拍文档管理器", path + "DeYiPai\\DocumentManager.exe", "超级牛逼的文档采集管理工具");


                var _timer = new System.Windows.Forms.Timer();
                _timer.Interval = 50;

                EventHandler handler = delegate
                {
                    process.Value++;
                    if (process.Value == process.Maximum - 1)
                    {
                        installing = false;
                        System.Diagnostics.Process.Start(path + "DeYiPai\\DocumentManager.exe");
                        this.Close();
                    }
                };

                _timer.Tick += handler;
                _timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // this.Close();
            }
        }
        void unzip(object i)
        {
            Zip.DeCompressDirectory(sm, path);
        }

        void Setload(object i)
        {
            process.Value++;
        }
    }
}
