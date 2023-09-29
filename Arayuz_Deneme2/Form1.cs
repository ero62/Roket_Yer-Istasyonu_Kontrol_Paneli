using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace Arayuz_Deneme2
{
    
    public partial class Form1 : Form
    {
        int paketNo=14;//default 
        float PayIrtifa,PayEnlem,PayBoylam,PayInisHizi,PaySicaklik,PayNem;
        float AviIrtifa;
        float AviSicaklik=25;
        float AviEnlem;
        float AviBoylam;
        float AviInisHizi;
        float AviBilgi;
        float AviBasinc;
        float AviNem;
        float AviITP_1;
        float AviITP_2;
        float IntubePresure_1, IntubePresure_2=10,AviyonikPilYuzdesi;
        float gaugeCakmasi=360;
        String[] portlar = SerialPort.GetPortNames();
        string[] baudRates = {"300", "600", "1200", "2400", "4800", "9600", " 14400", "19200", "28800", "38400", "57600", "115200" };
        public Form1()
        {
            InitializeComponent();
            PortlarVeYolar();
        }
        private void PortlarVeYolar()
        {
            foreach (string port in portlar)
            {
                cmpPort1.Items.Add(port);
                cmpPort2.Items.Add(port);
                cmpPort3.Items.Add(port);
            }
            cmpPort1.SelectedIndex = 0;
            cmpPort2.SelectedIndex = 0;
            cmpPort3.SelectedIndex = 0;

            foreach (string baudRate in baudRates)
            {
                cmpRate1.Items.Add(baudRate);
                cmpRate2.Items.Add(baudRate);
                cmpRate3.Items.Add(baudRate);
            }
            cmpRate1.SelectedIndex = 0;
            cmpRate2.SelectedIndex = 0;
            cmpRate3.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Text = paketNo.ToString();
            textBox3.Text = paketNo.ToString();
            
        }

        private void grpPayloadData_Enter(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //portlar = SerialPort.GetPortNames();
            timer1.Stop();
        }

        private void grpAnaAviData_Enter(object sender, EventArgs e)
        {

        }

        private void lblIntubePressSayac_2_Click(object sender, EventArgs e)
        {

        }

        private void grpAnaAviBaglanti_Enter(object sender, EventArgs e)
        {

        }

        private void grpPlayloadBaglanti_Enter(object sender, EventArgs e)
        {

        }

        private void grpHYIBaglanti_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                if (serialPort1.IsOpen)
                {
                    String sonuc = serialPort1.ReadLine();
                    float.TryParse(sonuc, out AviSicaklik);
                    serialPort1.DiscardInBuffer();
                    String[] port1Degerler = sonuc.Split('+');
                    /*
                     * nerde kulanacaksa= port1Degerler[0];
                     * nerde kulanacaksa= port1Degerler[1];
                     * gibi aynı port değerlerini böler
                     */
                    chtAviSicaklik.Series["Sicaklik"].Points.AddXY(saniye, AviSicaklik);
                    txtAviSicaklik.Text = AviSicaklik.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                timer1.Stop();
            }
            grafiklerVeDegerler();
            
        }
        public double saniye;
        private void btnBaglan1_Click(object sender, EventArgs e)
        { 
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = cmpPort1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cmpRate1.Text);
                    serialPort1.Open();
                    btnBaglan1.Text = "Bağlantıyı Kes";
                }
                catch(Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                serialPort1.Close();
                btnBaglan1.Text = "Bağlan";
            } 
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen==true)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close();
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Close();
            }
            timer1.Stop();
        }

        private void btnBaglan2_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen == false)
            {

                try
                {
                    serialPort2.PortName = cmpPort2.Text;
                    serialPort2.BaudRate = Convert.ToInt32(cmpRate2.Text);
                    serialPort2.Open();
                    btnBaglan2.Text = "Bağlantıyı Kes";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                serialPort2.Close();
                btnBaglan2.Text = "Bağlan";
            }
        }

        private void btnBaglan3_Click(object sender, EventArgs e)
        {
            if (serialPort3.IsOpen == false)
            {

                try
                {
                    serialPort3.PortName = cmpPort3.Text;
                    serialPort3.BaudRate = Convert.ToInt32(cmpRate3.Text);
                    serialPort3.Open();
                    btnBaglan3.Text = "Bağlantıyı Kes";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                serialPort3.Close();
                btnBaglan3.Text = "Bağlan";
        }
    }

        private void grafiklerVeDegerler()
        {
            lblIntubePresureSayac_1.Text = IntubePresure_1.ToString();
            lblIntubePressSayac_2.Text = IntubePresure_2.ToString();
            lblAviyonikPilSayac.Text = AviyonikPilYuzdesi.ToString();
            ////////////////////////////////////////////////////////////////////////
            chtAviSicaklik.Series["AnaSicaklik"].Points.AddY(AviSicaklik);
            chtAviSicaklik.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtAviSicaklik.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash; // Çizgi stili ayarı
            chtAviSicaklik.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White; // X ekseni ızgara rengini değiştirme
            chtAviSicaklik.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White; // Y ekseni ızgara rengini değiştirme
            chtAviSicaklik.ChartAreas[0].BackColor = Color.Black;
//////////////////////////////////////////////////////////////////////////////
            chtAviIrtifa.Series["AnaIrtifa"].Points.AddY(AviIrtifa);
            chtAviIrtifa.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtAviIrtifa.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtAviIrtifa.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chtAviIrtifa.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chtAviIrtifa.ChartAreas[0].BackColor = Color.Black;
            ///////////////////////////////////////////////////////////////////
            chtAviInisHızı.Series["AnaInisHizi"].Points.AddY(AviInisHizi);
            chtAviInisHızı.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtAviInisHızı.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtAviInisHızı.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White; 
            chtAviInisHızı.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White; 
            chtAviInisHızı.ChartAreas[0].BackColor = Color.Black;
            ///////////////////////////////////////////////////////////////
            chtAviNem.Series["AnaNem"].Points.AddY(AviNem);
            chtAviNem.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtAviNem.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtAviNem.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White; 
            chtAviNem.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chtAviNem.ChartAreas[0].BackColor = Color.Black;
            //////////////////////////////////////////////////////
            chtAviBasinc.Series["AnaBasinc"].Points.AddY(AviBasinc);
            chtAviBasinc.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtAviBasinc.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtAviBasinc.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chtAviBasinc.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chtAviBasinc.ChartAreas[0].BackColor = Color.Black;
            /////////////////////////////////////////////////////////////////////////////
            chtPayInisHizi.Series["PayInisHizi"].Points.AddY(PayInisHizi);
            chtPayInisHizi.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtPayInisHizi.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtPayInisHizi.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chtPayInisHizi.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chtPayInisHizi.ChartAreas[0].BackColor = Color.Black;
            ////////////////////////////////////////////////////////////////
            chtPayIrtifa.Series["PayIrtifa"].Points.AddY(PayIrtifa);
            chtPayIrtifa.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtPayIrtifa.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtPayIrtifa.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chtPayIrtifa.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chtPayIrtifa.ChartAreas[0].BackColor = Color.Black;
            /////////////////////////////////////////////////
            chtPayNem.Series["PayNem"].Points.AddY(PayNem);
            chtPayNem.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtPayNem.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtPayNem.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White; 
            chtPayNem.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White; 
            chtPayNem.ChartAreas[0].BackColor = Color.Black;
            ////////////////////////////////////////////////////////////
            chtPaySicaklik.Series["PaySicaklik"].Points.AddY(PaySicaklik);
            chtPaySicaklik.Series[0].Color = System.Drawing.Color.DarkGoldenrod;
            chtPaySicaklik.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chtPaySicaklik.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White; 
            chtPaySicaklik.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White; 
            chtPaySicaklik.ChartAreas[0].BackColor = Color.Black;
            //////////////////////////////////////////////////////////////////////////////
            txtAviSicaklik.Text = AviSicaklik.ToString();
            txtAviIrtifa.Text = AviIrtifa.ToString();
            txtAviEnlem.Text = AviEnlem.ToString();
            txtAviBoylam.Text = AviBoylam.ToString();
            txtAviInişHızı.Text = AviInisHizi.ToString();
            txtAviBasinc.Text = AviBasinc.ToString();
            txtAviNem.Text = AviNem.ToString();
            txtAviITP_1.Text = AviITP_1.ToString();
            txtAviITP_2.Text = AviITP_2.ToString();
        }
    }
}
