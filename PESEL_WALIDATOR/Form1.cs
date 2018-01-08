using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PESEL_WALIDATOR
{
    public partial class Form1 : Form
    {
        int suma_kontrolna = 0;

        public Boolean SprawdzPESEL(string pesel)
        {
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            if (pesel.Length != 11) return false;
            int checksum = pesel[10] - 48;
            int sum = 0;

            for (int i = 0; i < wagi.Length; i++)
            {
                sum += wagi[i] * (Convert.ToInt16(pesel[i]) - 48);
            }
             suma_kontrolna = (10 - (sum % 10));

            if (10 - (sum % 10) == checksum) return true;
            else return false;
        }

        public String DataUrodzenia(string pesel)
        {
            string odp = String.Concat("ROK: ",pesel[0],  pesel[1]," MIESIĄC: ",pesel[2],pesel[3]," DZIEŃ: ",
                                        pesel[4],pesel[5]);
            return odp;
        }

        public String Plec(string pesel)
        {
            if (Convert.ToInt16(pesel[9]) % 2 == 0)
                return "KOBIETA";
            else return "MĘŻCZYZNA";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pesel = "93050303339";
            //SprawdzPESEL(textBox1.Text);
            SprawdzPESEL(pesel);
            //label3.Text= DataUrodzenia(pesel);
            label3.Text = Plec(pesel);
            //label3.Text = Convert.ToString(suma_kontrolna);
           
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
