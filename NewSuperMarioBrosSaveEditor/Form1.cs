using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NewSuperMarioBrosSaveEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dlg.Filter = "NSMB Savefile (*.sav)|*.sav";

            comboBox1.Items.Add("Small");
            comboBox1.Items.Add("Super");
            comboBox1.Items.Add("Fire");
            comboBox1.Items.Add("Mini");
            comboBox1.Items.Add("Blue Shell");

            comboBox2.Items.Add("Nothing");
            comboBox2.Items.Add("Super Mushroom");
            comboBox2.Items.Add("Fire Flower");
            comboBox2.Items.Add("Mini Mushroom");
            comboBox2.Items.Add("Mega Mushroom");
            comboBox2.Items.Add("Blue Shell");

            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            label9.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label16.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            pictureBox1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

            button2.Click += new System.EventHandler(SaveButtonClicked);
        }

        OpenFileDialog dlg = new OpenFileDialog();

        public UInt16 nsmbChecksum(byte[] data, int dataSize, int pos)
        {
            UInt16 checksum = 654;

            for (int i = 0; i < dataSize; ++i)
            {
                byte readByte = data[pos + i];
                checksum = Convert.ToUInt16(readByte ^ ((2 * checksum & 0xFFFE) | (checksum >> 15) & 1));
            }

            return checksum;
        }

        public byte[] recalculateSaveFileChecksums(byte[] savefile)
        {
            for (int baseData = 0; baseData <= 0x1000; baseData += 0x1000)
            {
                doChecksum(savefile, baseData + 0x00, 0xF4); //Header

                doChecksum(savefile, baseData + 0x100, 0x248); //Save 1
                doChecksum(savefile, baseData + 0x380, 0x248); //Save 2
                doChecksum(savefile, baseData + 0x600, 0x248); //Save 3

                doChecksum(savefile, baseData + 0x880, 0x14); //Footer
            }

            return savefile;
        }

        public void doChecksum(byte[] savefile, int checksumPos, int dataLen)
        {
            UInt16 checksum = nsmbChecksum(savefile, dataLen, checksumPos + 10);
            savefile[checksumPos] = Convert.ToByte(checksum & 0xFF);
            savefile[checksumPos + 1] = Convert.ToByte(checksum >> 8);
        }

        public void UncheckFileButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        public void ReadPowerups()
        {
            BinaryReader bnr = new BinaryReader(File.OpenRead(dlg.FileName));

            if (radioButton1.Checked == true)
            {
                bnr.BaseStream.Position = 0x13A;

                if (bnr.ReadByte() == (0))
                {
                    comboBox1.SelectedItem = "Small";
                }

                bnr.BaseStream.Position = 0x13A;

                if (bnr.ReadByte() == (1))
                {
                    comboBox1.SelectedItem = "Super";
                }

                bnr.BaseStream.Position = 0x13A;

                if (bnr.ReadByte() == (2))
                {
                    comboBox1.SelectedItem = "Fire";
                }

                bnr.BaseStream.Position = 0x13A;

                if (bnr.ReadByte() == (4))
                {
                    comboBox1.SelectedItem = "Mini";
                }

                bnr.BaseStream.Position = 0x13A;

                if (bnr.ReadByte() == (5))
                {
                    comboBox1.SelectedItem = "Blue Shell";
                }
            }

            if (radioButton2.Checked == true)
            {
                bnr.BaseStream.Position = 0x3BA;

                if (bnr.ReadByte() == (0))
                {
                    comboBox1.SelectedItem = "Small";
                }

                bnr.BaseStream.Position = 0x3BA;

                if (bnr.ReadByte() == (1))
                {
                    comboBox1.SelectedItem = "Super";
                }

                bnr.BaseStream.Position = 0x3BA;

                if (bnr.ReadByte() == (2))
                {
                    comboBox1.SelectedItem = "Fire";
                }

                bnr.BaseStream.Position = 0x3BA;

                if (bnr.ReadByte() == (4))
                {
                    comboBox1.SelectedItem = "Mini";
                }

                bnr.BaseStream.Position = 0x3BA;

                if (bnr.ReadByte() == (5))
                {
                    comboBox1.SelectedItem = "Blue Shell";
                }
            }

            if (radioButton3.Checked == true)
            {
                bnr.BaseStream.Position = 0x63A;

                if (bnr.ReadByte() == (0))
                {
                    comboBox1.SelectedItem = "Small";
                }

                bnr.BaseStream.Position = 0x63A;

                if (bnr.ReadByte() == (1))
                {
                    comboBox1.SelectedItem = "Super";
                }

                bnr.BaseStream.Position = 0x63A;

                if (bnr.ReadByte() == (2))
                {
                    comboBox1.SelectedItem = "Fire";
                }

                bnr.BaseStream.Position = 0x63A;

                if (bnr.ReadByte() == (4))
                {
                    comboBox1.SelectedItem = "Mini";
                }

                bnr.BaseStream.Position = 0x63A;

                if (bnr.ReadByte() == (5))
                {
                    comboBox1.SelectedItem = "Blue Shell";
                }
            }

            bnr.Close();
        }

        public void ReadInventory()
        {
            BinaryReader bnr = new BinaryReader(File.OpenRead(dlg.FileName));

            if (radioButton1.Checked == true)
            {
                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (0))
                {
                    comboBox2.SelectedItem = "Nothing";
                }

                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (1))
                {
                    comboBox2.SelectedItem = "Super Mushroom";
                }

                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (2))
                {
                    comboBox2.SelectedItem = "Fire Flower";
                }

                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (3))
                {
                    comboBox2.SelectedItem = "Blue Shell";
                }

                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (4))
                {
                    comboBox2.SelectedItem = "Mini Mushroom";
                }

                bnr.BaseStream.Position = 0x166;

                if (bnr.ReadByte() == (5))
                {
                    comboBox2.SelectedItem = "Mega Mushroom";
                }
            }

            if (radioButton2.Checked == true)
            {
                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (0))
                {
                    comboBox2.SelectedItem = "Nothing";
                }

                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (1))
                {
                    comboBox2.SelectedItem = "Super Mushroom";
                }

                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (2))
                {
                    comboBox2.SelectedItem = "Fire Flower";
                }

                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (3))
                {
                    comboBox2.SelectedItem = "Blue Shell";
                }

                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (4))
                {
                    comboBox2.SelectedItem = "Mini Mushroom";
                }

                bnr.BaseStream.Position = 0x3E6;

                if (bnr.ReadByte() == (5))
                {
                    comboBox2.SelectedItem = "Mega Mushroom";
                }
            }

            if (radioButton3.Checked == true)
            {
                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (0))
                {
                    comboBox2.SelectedItem = "Nothing";
                }

                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (1))
                {
                    comboBox2.SelectedItem = "Super Mushroom";
                }

                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (2))
                {
                    comboBox2.SelectedItem = "Fire Flower";
                }

                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (3))
                {
                    comboBox2.SelectedItem = "Blue Shell";
                }

                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (4))
                {
                    comboBox2.SelectedItem = "Mini Mushroom";
                }

                bnr.BaseStream.Position = 0x666;

                if (bnr.ReadByte() == (5))
                {
                    comboBox2.SelectedItem = "Mega Mushroom";
                }
            }

            bnr.Close();
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            byte[] fileByteRead;

            using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
            {
                fileByteRead = File.ReadAllBytes(dlg.FileName);
            }

            BinaryWriter bnw = new BinaryWriter(new MemoryStream(fileByteRead));

            if (radioButton1.Checked == true)
            {
                if (checkBox1.Checked)
                {
                    int pos = 0x241;
                    for (int i = 0; i <= 0x114; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xC0);
                    }
                }

                if (checkBox2.Checked)
                {
                    int pos = 0x16A;
                    for (int i = 0; i <= 0x10; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xFF);
                    }
                }

                bnw.BaseStream.Position = 0x116;
                int livesValue = Convert.ToInt32(numericUpDown1.Value);
                bnw.Write(livesValue);
            
                bnw.BaseStream.Position = 0x11A;
                int coinsValue = Convert.ToInt32(numericUpDown2.Value);
                bnw.Write(coinsValue);
            
                bnw.BaseStream.Position = 0x122;
                int starCoinValue = Convert.ToInt32(numericUpDown3.Value);
                bnw.Write(starCoinValue);

                bnw.BaseStream.Position = 0x11E;
                int scoreValue = Convert.ToInt32(numericUpDown5.Value);
                bnw.Write(scoreValue);

                bnw.BaseStream.Position = 0x13A;
                if (comboBox1.Text == "Small")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x13A;
                if (comboBox1.Text == "Super")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x13A;
                if (comboBox1.Text == "Fire")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x13A;
                if (comboBox1.Text == "Mini")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x13A;
                if (comboBox1.Text == "Blue Shell")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Nothing")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Super Mushroom")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Fire Flower")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Blue Shell")
                {
                    bnw.Write(3);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Mini Mushroom")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x166;
                if (comboBox2.Text == "Mega Mushroom")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x142;
                if (numericUpDown6.Value == 1)
                {
                    bnw.Write(0);
                    pictureBox1.Image = Properties.Resources.NSMB_BG1;
                }

                bnw.BaseStream.Position = 0x142;
                if (numericUpDown6.Value == 2)
                {
                    bnw.Write(1);
                    pictureBox1.Image = Properties.Resources.NSMB_BG2;
                }

                bnw.BaseStream.Position = 0x142;
                if (numericUpDown6.Value == 3)
                {
                    bnw.Write(2);
                    pictureBox1.Image = Properties.Resources.NSMB_BG3;
                }

                bnw.BaseStream.Position = 0x142;
                if (numericUpDown6.Value == 4)
                {
                    bnw.Write(3);
                    pictureBox1.Image = Properties.Resources.NSMB_BG4;
                }

                bnw.BaseStream.Position = 0x142;
                if (numericUpDown6.Value == 5)
                {
                    bnw.Write(4);
                    pictureBox1.Image = Properties.Resources.NSMB_BG5;
                }
            }

            if (radioButton2.Checked == true)
            {
                if (checkBox1.Checked)
                {
                    int pos = 0x4C1;
                    for (int i = 0; i <= 0x114; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xC0);
                    }
                }

                if (checkBox2.Checked)
                {
                    int pos = 0x3EA;
                    for (int i = 0; i <= 0x10; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xFF);
                    }
                }

                bnw.BaseStream.Position = 0x396;
                int livesValue = Convert.ToInt32(numericUpDown1.Value);
                bnw.Write(livesValue);

                bnw.BaseStream.Position = 0x39A;
                int coinsValue = Convert.ToInt32(numericUpDown2.Value);
                bnw.Write(coinsValue);

                bnw.BaseStream.Position = 0x3A2;
                int starCoinValue = Convert.ToInt32(numericUpDown3.Value);
                bnw.Write(starCoinValue);

                bnw.BaseStream.Position = 0x39E;
                int scoreValue = Convert.ToInt32(numericUpDown5.Value);
                bnw.Write(scoreValue);

                bnw.BaseStream.Position = 0x3BA;
                if (comboBox1.Text == "Small")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x3BA;
                if (comboBox1.Text == "Super")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x3BA;
                if (comboBox1.Text == "Fire")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x3BA;
                if (comboBox1.Text == "Mini")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x3BA;
                if (comboBox1.Text == "Blue Shell")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Nothing")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Super Mushroom")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Fire Flower")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Blue Shell")
                {
                    bnw.Write(3);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Mini Mushroom")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x3E6;
                if (comboBox2.Text == "Mega Mushroom")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x3C2;
                if (numericUpDown6.Value == 1)
                {
                    bnw.Write(0);
                    pictureBox1.Image = Properties.Resources.NSMB_BG1;
                }

                bnw.BaseStream.Position = 0x3C2;
                if (numericUpDown6.Value == 2)
                {
                    bnw.Write(1);
                    pictureBox1.Image = Properties.Resources.NSMB_BG2;
                }

                bnw.BaseStream.Position = 0x3C2;
                if (numericUpDown6.Value == 3)
                {
                    bnw.Write(2);
                    pictureBox1.Image = Properties.Resources.NSMB_BG3;
                }

                bnw.BaseStream.Position = 0x3C2;
                if (numericUpDown6.Value == 4)
                {
                    bnw.Write(3);
                    pictureBox1.Image = Properties.Resources.NSMB_BG4;
                }

                bnw.BaseStream.Position = 0x3C2;
                if (numericUpDown6.Value == 5)
                {
                    bnw.Write(4);
                    pictureBox1.Image = Properties.Resources.NSMB_BG5;
                }
            }

            if (radioButton3.Checked == true)
            {
                if (checkBox1.Checked)
                {
                    int pos = 0x741;
                    for (int i = 0; i <= 0x114; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xC0);
                    }
                }

                if (checkBox2.Checked)
                {
                    int pos = 0x66A;
                    for (int i = 0; i <= 0x10; i++)
                    {
                        bnw.BaseStream.Position = pos + i;
                        bnw.Write(0xFF);
                    }
                }

                bnw.BaseStream.Position = 0x616;
                int livesValue = Convert.ToInt32(numericUpDown1.Value);
                bnw.Write(livesValue);

                bnw.BaseStream.Position = 0x61A;
                int coinsValue = Convert.ToInt32(numericUpDown2.Value);
                bnw.Write(coinsValue);

                bnw.BaseStream.Position = 0x622;
                int starCoinValue = Convert.ToInt32(numericUpDown3.Value);
                bnw.Write(starCoinValue);

                bnw.BaseStream.Position = 0x61E;
                int scoreValue = Convert.ToInt32(numericUpDown5.Value);
                bnw.Write(scoreValue);

                bnw.BaseStream.Position = 0x63A;
                if (comboBox1.Text == "Small")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x63A;
                if (comboBox1.Text == "Super")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x63A;
                if (comboBox1.Text == "Fire")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x63A;
                if (comboBox1.Text == "Mini")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x63A;
                if (comboBox1.Text == "Blue Shell")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Nothing")
                {
                    bnw.Write(0);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Super Mushroom")
                {
                    bnw.Write(1);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Fire Flower")
                {
                    bnw.Write(2);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Blue Shell")
                {
                    bnw.Write(3);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Mini Mushroom")
                {
                    bnw.Write(4);
                }

                bnw.BaseStream.Position = 0x666;
                if (comboBox2.Text == "Mega Mushroom")
                {
                    bnw.Write(5);
                }

                bnw.BaseStream.Position = 0x642;
                if (numericUpDown6.Value == 1)
                {
                    bnw.Write(0);
                    pictureBox1.Image = Properties.Resources.NSMB_BG1;
                }

                bnw.BaseStream.Position = 0x642;
                if (numericUpDown6.Value == 2)
                {
                    bnw.Write(1);
                    pictureBox1.Image = Properties.Resources.NSMB_BG2;
                }

                bnw.BaseStream.Position = 0x642;
                if (numericUpDown6.Value == 3)
                {
                    bnw.Write(2);
                    pictureBox1.Image = Properties.Resources.NSMB_BG3;
                }

                bnw.BaseStream.Position = 0x642;
                if (numericUpDown6.Value == 4)
                {
                    bnw.Write(3);
                    pictureBox1.Image = Properties.Resources.NSMB_BG4;
                }

                bnw.BaseStream.Position = 0x642;
                if (numericUpDown6.Value == 5)
                {
                    bnw.Write(4);
                    pictureBox1.Image = Properties.Resources.NSMB_BG5;
                }
            }

            bnw.Close();

            recalculateSaveFileChecksums(fileByteRead);

            using (FileStream fsWrite = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Write))
            {
                fsWrite.Write(fileByteRead, 0, fileByteRead.Length);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dlg.ShowDialog();

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;

            label1.Text = Path.GetFileName(dlg.FileName).ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label16.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            pictureBox1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;

            BinaryReader bnr = new BinaryReader(File.OpenRead(dlg.FileName));

            bnr.BaseStream.Position = 0x142;

            if (bnr.ReadByte() == (0))
            {
                numericUpDown6.Value = 1;
                pictureBox1.Image = Properties.Resources.NSMB_BG1;
            }

            bnr.BaseStream.Position = 0x142;

            if (bnr.ReadByte() == (1))
            {
                numericUpDown6.Value = 2;
                pictureBox1.Image = Properties.Resources.NSMB_BG2;
            }

            bnr.BaseStream.Position = 0x142;

            if (bnr.ReadByte() == (2))
            {
                numericUpDown6.Value = 3;
                pictureBox1.Image = Properties.Resources.NSMB_BG3;
            }

            bnr.BaseStream.Position = 0x142;

            if (bnr.ReadByte() == (3))
            {
                numericUpDown6.Value = 4;
                pictureBox1.Image = Properties.Resources.NSMB_BG4;
            }

            bnr.BaseStream.Position = 0x142;

            if (bnr.ReadByte() == (4))
            {
                numericUpDown6.Value = 5;
                pictureBox1.Image = Properties.Resources.NSMB_BG5;
            }

            bnr.BaseStream.Position = 0x116;

            numericUpDown1.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x11A;

            numericUpDown2.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x122;

            numericUpDown3.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x11E;

            numericUpDown5.Value = bnr.ReadInt32();

            ReadPowerups();

            ReadInventory();

            bnr.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label16.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            pictureBox1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;

            BinaryReader bnr = new BinaryReader(File.OpenRead(dlg.FileName));

            bnr.BaseStream.Position = 0x3C2;

            if (bnr.ReadByte() == (0))
            {
                numericUpDown6.Value = 1;
                pictureBox1.Image = Properties.Resources.NSMB_BG1;
            }

            bnr.BaseStream.Position = 0x3C2;

            if (bnr.ReadByte() == (1))
            {
                numericUpDown6.Value = 2;
                pictureBox1.Image = Properties.Resources.NSMB_BG2;
            }

            bnr.BaseStream.Position = 0x3C2;

            if (bnr.ReadByte() == (2))
            {
                numericUpDown6.Value = 3;
                pictureBox1.Image = Properties.Resources.NSMB_BG3;
            }

            bnr.BaseStream.Position = 0x3C2;

            if (bnr.ReadByte() == (3))
            {
                numericUpDown6.Value = 4;
                pictureBox1.Image = Properties.Resources.NSMB_BG4;
            }

            bnr.BaseStream.Position = 0x3C2;

            if (bnr.ReadByte() == (4))
            {
                numericUpDown6.Value = 5;
                pictureBox1.Image = Properties.Resources.NSMB_BG5;
            }

            bnr.BaseStream.Position = 0x396;

            numericUpDown1.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x39A;

            numericUpDown2.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x3A2;

            numericUpDown3.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x39E;

            numericUpDown5.Value = bnr.ReadInt32();

            ReadPowerups();

            ReadInventory();

            bnr.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label16.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            pictureBox1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;

            BinaryReader bnr = new BinaryReader(File.OpenRead(dlg.FileName));

            bnr.BaseStream.Position = 0x642;

            if (bnr.ReadByte() == (0))
            {
                numericUpDown6.Value = 1;
                pictureBox1.Image = Properties.Resources.NSMB_BG1;
            }

            bnr.BaseStream.Position = 0x642;

            if (bnr.ReadByte() == (1))
            {
                numericUpDown6.Value = 2;
                pictureBox1.Image = Properties.Resources.NSMB_BG2;
            }

            bnr.BaseStream.Position = 0x642;

            if (bnr.ReadByte() == (2))
            {
                numericUpDown6.Value = 3;
                pictureBox1.Image = Properties.Resources.NSMB_BG3;
            }

            bnr.BaseStream.Position = 0x642;

            if (bnr.ReadByte() == (3))
            {
                numericUpDown6.Value = 4;
                pictureBox1.Image = Properties.Resources.NSMB_BG4;
            }

            bnr.BaseStream.Position = 0x642;

            if (bnr.ReadByte() == (4))
            {
                numericUpDown6.Value = 5;
                pictureBox1.Image = Properties.Resources.NSMB_BG5;
            }

            bnr.BaseStream.Position = 0x616;

            numericUpDown1.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x61A;

            numericUpDown2.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x622;

            numericUpDown3.Value = bnr.ReadInt32();

            bnr.BaseStream.Position = 0x61E;

            numericUpDown5.Value = bnr.ReadInt32();

            ReadPowerups();

            ReadInventory();

            bnr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
