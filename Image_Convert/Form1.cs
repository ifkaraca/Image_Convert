using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Convert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ac = new OpenFileDialog();
        SaveFileDialog kaydet = new SaveFileDialog();
        string yol;
        Image grsl;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ac.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            ac.Title = "Bir resim dosyası seçin";

            if (ac.ShowDialog() == DialogResult.OK)
            {
                yol = ac.FileName;
                grsl = Image.FromFile(yol);
                pictureBox1.Image = grsl;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grsl != null)
            {
                kaydet.Filter = "PNG Dosyası|*.png";
                kaydet.Title = "PNG Olarak Kaydet";
                kaydet.FileName = "image.png";

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    grsl.Save(kaydet.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Görsel başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Önce bir görsel seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (grsl != null)
            {
                kaydet.Filter = "JPG Dosyası|*.jpg";
                kaydet.Title = "JPG Olarak Kaydet";
                kaydet.FileName = "image.jpg";

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    grsl.Save(kaydet.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Görsel başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Önce bir görsel seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (grsl != null)
            {
                kaydet.Filter = "ICO Dosyası|*.ico";
                kaydet.Title = "ICO Olarak Kaydet";
                kaydet.FileName = "image.ico";

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(grsl))
                    {
                        SaveBitmapAsIcon(bmp, kaydet.FileName);
                    }
                    MessageBox.Show("Görsel başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Önce bir görsel seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveBitmapAsIcon(Bitmap bitmap, string filePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write((short)0);           // rezerv
                        bw.Write((short)1);           // tür: 1=icon
                        bw.Write((short)1);           // resim sayısı

                        bw.Write((byte)bitmap.Width); // icon genişliği
                        bw.Write((byte)bitmap.Height);// icon yüksekliği
                        bw.Write((byte)0);            // renk paleti (0 = true color)
                        bw.Write((byte)0);            // rezerv
                        bw.Write((short)1);           // renk planı
                        bw.Write((short)32);          // bit sayısı
                        bw.Write((int)ms.Length);     // resim veri uzunluğu
                        bw.Write(22);                 // veri başlangıç noktası


                        bw.Write(ms.ToArray());

                        bw.Flush();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (grsl != null)
            {
                kaydet.Filter = "BMP Dosyası|*.bmp";
                kaydet.Title = "BMP Olarak Kaydet";
                kaydet.FileName = "image.bmp";

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    grsl.Save(kaydet.FileName, ImageFormat.Bmp);
                    MessageBox.Show("Görsel başarıyla BMP formatında kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Önce bir görsel seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (grsl != null)
            {
                kaydet.Filter = "GIF Dosyası|*.gif";
                kaydet.Title = "GIF Olarak Kaydet";
                kaydet.FileName = "image.gif";

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    grsl.Save(kaydet.FileName, ImageFormat.Gif);
                    MessageBox.Show("Görsel başarıyla GIF formatında kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Önce bir görsel seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
