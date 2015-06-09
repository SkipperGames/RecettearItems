using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Recettear_All_Items
{
    public partial class Form1 : Form
    {
        private static int ITEMS = 48;

        readonly int[] categories =
        {
            64,
            6464,
            12864,
            19264,
            25664,
            32064,
            38464,
            44864,
            64064,
            70464,
            76864,
            83264,
            89664,
            96064,
            102464,
            108864,
            128064,
            134464,
            140864,
            147264,
            153664,
            160064,
            192064,
            198464,
            204864,
            217664,
            256064,
            262464,
            320064,
            326464,
            332864,
            339264,
            345664
        };

        OpenFileDialog dialog;

        string path;
        byte[] data1;
        byte[] data2;

        public Form1()
        {
            InitializeComponent();

            dialog = new OpenFileDialog();
            dialog.DefaultExt = "CEM";
            dialog.Filter = "CE Memory File (*.CEM)|*.CEM|All files (*.*)|*.*";
            dialog.Title = "Cheat Engine Memory File";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream file;

                try
                {
                    file = File.Create(Application.StartupPath + "recettear all items.CEM");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK);
                    return;
                }

                path = dialog.FileName;

                data1 = File.ReadAllBytes(path);
                data2 = new byte[data1.Length * 3];

                Array.Copy(data1, 0, data2, 0, data1.Length);
                Array.Copy(data1, 0, data2, data1.Length - 1, data1.Length);
                Array.Copy(data1, 0, data2, data1.Length + data1.Length - 2, data1.Length);

                file.Write(data2, 0, data2.Length);
                file.Close();

                Close();
            }
        }
    }
}
