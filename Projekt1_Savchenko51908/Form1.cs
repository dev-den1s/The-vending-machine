using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_Savchenko51908
{
    public partial class Form1 : Form
    {
        Random ds_random;
        dsBankomat dsb;
        List<dsProduktyStruct> dsDostepneProdukty;
        Label dsetykietadolnej = new Label();
        TextBox dstxtdolnagranica = new TextBox();
        Label dsetykirtagornej = new Label();
        TextBox dstxtgornagranica = new TextBox();
        Button dsbtnprzyciskakceptacji = new Button();
        dsNominaly[] dsPojemnikiNominalow;
        decimal[] dsWartosciNominalow = { 5.00M, 2.00M, 1.00M, 0.50M };
        public Form1()
        {
            InitializeComponent();
            ds_random = new Random();
            dsPojemnikiNominalow = new dsNominaly[dsWartosciNominalow.Length];
            dsb = new dsBankomat();
            dsDostepneProdukty = new List<dsProduktyStruct>() { 
                new dsProduktyStruct() { produkt = dsProdukty.Cola, ilosc=5, cenapln = 2.50M, cenaeur = 0.50M,cenahrn = 18.50M },
                new dsProduktyStruct() { produkt = dsProdukty.Fanta, ilosc=5, cenapln = 4.00M, cenaeur = 1.00M,cenahrn = 30.00M },
                new dsProduktyStruct() { produkt = dsProdukty.Sprite, ilosc=5, cenapln = 2.50M, cenaeur = 0.50M,cenahrn = 18.50M },
                new dsProduktyStruct() { produkt = dsProdukty.Mars, ilosc=5, cenapln = 5.00M, cenaeur = 1.50M,cenahrn = 45.50M },
                new dsProduktyStruct() { produkt = dsProdukty.Twix, ilosc=5, cenapln = 6.50M, cenaeur = 2.00M,cenahrn = 60.00M },
                new dsProduktyStruct() { produkt = dsProdukty.Snickers, ilosc=5, cenapln = 2.50M, cenaeur = 0.50M,cenahrn = 18.50M }
            };
        }
        public void dsDisableProdukty()
        {
            dspbcola.Enabled = false;
            dspbfanta.Enabled = false;
            dspbsprite.Enabled = false;
            dspbmars.Enabled = false;
            dspbtwix.Enabled = false;
            dspbsnickers.Enabled = false;
        }
        
        public void dsEnableProdukty()
        {
            dspbcola.Enabled = true;
            dspbfanta.Enabled = true;
            dspbsprite.Enabled = true;
            dspbmars.Enabled = true;
            dspbtwix.Enabled = true;
            dspbsnickers.Enabled = true;
        }
        private void dscmbWaluta_SelectedIndexChanged(object sender, EventArgs e)
        {           
            dsb.dsWaluta = (dsWaluta)dscmbWaluta.SelectedIndex;
            dscmbRodzajPlatnosci.Enabled = true;
            dscmbWaluta.Enabled = false;
            dsb.dsEdytujText(dstb, "Select the type of payment ...");        
        }

        private void dscmbRodzajPlatnosci_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsb.dsSetRodzajPlatnosci((dsRodzajPlatnosci)dscmbRodzajPlatnosci.SelectedIndex);
            dscmbRodzajPlatnosci.Enabled = false;
            dsEnableProdukty();
            dsb.dsEdytujText(dstb, "Select a product...");
        }

        private void dspbcola_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 0))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");

            if (dsb.dsNapiszPlatnosc(dstb)==1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dspbfanta_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 1))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");
            if (dsb.dsNapiszPlatnosc(dstb) == 1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dspbsprite_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 2))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");
            if (dsb.dsNapiszPlatnosc(dstb) == 1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dspbmars_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 3))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");
            if (dsb.dsNapiszPlatnosc(dstb) == 1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dspbtwix_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 4))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");
            if (dsb.dsNapiszPlatnosc(dstb) == 1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dspbsnickers_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetWybranyProdukt(dsDostepneProdukty, 5))
                errorProvider1.SetError(dstb, "Unfortunately, we dont have this product now :(");
            if (dsb.dsNapiszPlatnosc(dstb) == 1)
            {
                dslblplatnosc.Visible = true;
                dspbpinpad.Enabled = true;
            }
            else
            {
                dsgbmonety.Enabled = true;
            }
            dsDisableProdukty();
        }

        private void dsbtn50_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetZaplacono(dstbWrzuconeMonety, 0.50M))
            {
                dsgbmonety.Enabled = false;
                dsb.dsEdytujText(dstb, "Okej, now click on the button <Pay by coins>");
                dsbtnplace.Enabled = true;
            }             
        }

        private void dsbtn1_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetZaplacono(dstbWrzuconeMonety, 1.00M))
            {
                dsgbmonety.Enabled = false;
                dsbtnplace.Enabled = true;

                dsb.dsEdytujText(dstb, "Okej, now click on the button <Pay by coins>");
            }
        }

        private void dsbtn2_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetZaplacono(dstbWrzuconeMonety, 2.00M))
            {
                dsgbmonety.Enabled = false;
                dsbtnplace.Enabled = true;

                dsb.dsEdytujText(dstb, "Okej, now click on the button <Pay by coins>");
            }
        }

        private void dsbtn5_Click(object sender, EventArgs e)
        {
            if (!dsb.dsSetZaplacono(dstbWrzuconeMonety, 5.00M))
            {
                dsgbmonety.Enabled = false;
                dsbtnplace.Enabled = true;

                dsb.dsEdytujText(dstb, "Okej, now click on the button <Pay by coins>");
            }
        }

        private void dsbtnreset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The transaction will be aborted now!");
            dsReset();
        }

       

        private void dsbtnnie_Click(object sender, EventArgs e)
        {
            const int dslicznoscnominalow = 25;
            for (ushort i = 0; i < dsPojemnikiNominalow.Length; i++)
            {
                dsPojemnikiNominalow[i].dslicznosc = dslicznoscnominalow;
                dsPojemnikiNominalow[i].dswartosc = dsWartosciNominalow[i];
            }
            dsbtntak.Visible = false;
            dsbtnnie.Visible = false;
            dscmbWaluta.Enabled = true;
            dsb.dsEdytujText(dstb, "Select a currency...");
        }

        private void dsbtntak_Click(object sender, EventArgs e)
        {
            dsbtntak.Visible = false;
            dsbtnnie.Visible = false;
             dsetykietadolnej = new Label();
             dstxtdolnagranica = new TextBox();
             dsetykirtagornej = new Label();
             dstxtgornagranica = new TextBox();
             dsbtnprzyciskakceptacji = new Button();

            //dolna
            dsetykietadolnej.Text = "Od:";
            dsetykietadolnej.Font = new Font(FontFamily.GenericSansSerif, 10.25f, FontStyle.Italic);
            dsetykietadolnej.TextAlign = ContentAlignment.MiddleCenter;
            dsetykietadolnej.Location = new Point(6, 439);////////////
            dsetykietadolnej.BackColor = this.BackColor;
            dsetykietadolnej.ForeColor = Color.White;
            dsetykietadolnej.AutoSize = false;
            dsetykietadolnej.Size = new Size(31, 17);
            dsgbplatnosc.Controls.Add(dsetykietadolnej);
            //gorna
            dsetykirtagornej.Text = "Do:";
            dsetykirtagornej.Font = new Font(FontFamily.GenericSansSerif, 10.25f, FontStyle.Italic);
            dsetykirtagornej.TextAlign = ContentAlignment.MiddleCenter;
            dsetykirtagornej.Location = new Point(102, 439);////////////
            dsetykirtagornej.BackColor = this.BackColor;
            dsetykirtagornej.ForeColor = Color.White;
            dsetykirtagornej.AutoSize = false;
            dsetykirtagornej.Size = new Size(31, 17);
            dsgbplatnosc.Controls.Add(dsetykirtagornej);

            //tb 
            dstxtdolnagranica.BackColor = Color.White;
            dstxtdolnagranica.ForeColor = Color.Black;
            dstxtdolnagranica.Text = "";
            dstxtdolnagranica.Font = new Font(FontFamily.GenericSansSerif, 9.25F, FontStyle.Regular);
            dstxtdolnagranica.TextAlign = HorizontalAlignment.Center;
            dstxtdolnagranica.Location = new Point(37, 459);////////////
            dstxtdolnagranica.Size = new Size(57, 21);
            dstxtdolnagranica.BorderStyle = BorderStyle.FixedSingle;
            dsgbplatnosc.Controls.Add(dstxtdolnagranica);
            //tb 
            dstxtgornagranica.BackColor = Color.White;
            dstxtgornagranica.ForeColor = Color.Black;
            dstxtgornagranica.Text = "";
            dstxtgornagranica.Font = new Font(FontFamily.GenericSansSerif, 9.25F, FontStyle.Regular);
            dstxtgornagranica.TextAlign = HorizontalAlignment.Center;
            dstxtgornagranica.Location = new Point(133, 459);////////////
            dstxtgornagranica.Size = new Size(57, 21);
            dstxtgornagranica.BorderStyle = BorderStyle.FixedSingle;
            dsgbplatnosc.Controls.Add(dstxtgornagranica);
            //btn
            dsbtnprzyciskakceptacji.Text = "OK";
            dsbtnprzyciskakceptacji.Font = new Font(FontFamily.GenericSansSerif, 9.25F, FontStyle.Italic);
            dsbtnprzyciskakceptacji.TextAlign = ContentAlignment.MiddleCenter;
            dsbtnprzyciskakceptacji.Location = new Point(213, 451);////////////
            dsbtnprzyciskakceptacji.Width = 35;
            dsbtnprzyciskakceptacji.Height = 25; 
            dsgbplatnosc.Controls.Add(dsbtnprzyciskakceptacji);
            dsbtnprzyciskakceptacji.Click += new EventHandler(dsbtnprzyciskakceptacji_Click);
        }
        private bool dsPobranieGranicyLosowania(ref int dsod, ref int dsdo)
        {
            dsod = 0;
            dsdo = 0;
            if(!int.TryParse(dstxtdolnagranica.Text, out dsod) || dsod < 0 )
            {
                if (dsod < 0)
                {
                    errorProvider1.SetError(dstxtdolnagranica, "ERROR: Wczytywana liczba musi być wieksza od zera");
                    return false;
                }
                errorProvider1.SetError(dstxtdolnagranica, "ERROR: Wczytywana liczba musi być całkowita");
                return false;
            }
            if(!int.TryParse(dstxtgornagranica.Text, out dsdo) || dsdo < dsod)
            {
                if (dsdo < dsod)
                {
                    errorProvider1.SetError(dstxtgornagranica, "ERROR: Górny przedział musi być >= dolnemu");
                    return false;
                }
                errorProvider1.SetError(dstxtgornagranica, "ERROR: Wczytywana liczba musi być całkowita");
                return false;
            }
            return true;
        }
        private void dsbtnprzyciskakceptacji_Click(object sender, EventArgs e)
        {
            string dsstr = "\n\t-------------------------------------------\n\tThe container of denominations:\n\t-------------------------------------------";
            int dsdolna_granica=0, dsgorna_granica=0;
            if (!dsPobranieGranicyLosowania(ref dsdolna_granica, ref dsgorna_granica)) return;
            for (ushort i = 0; i < dsPojemnikiNominalow.Length; i++)
            {
                dsPojemnikiNominalow[i].dslicznosc = ds_random.Next(dsdolna_granica, dsgorna_granica+1);
                dsPojemnikiNominalow[i].dswartosc = dsWartosciNominalow[i];
                dsstr += $"\n\t{dsPojemnikiNominalow[i].dswartosc} - {dsPojemnikiNominalow[i].dslicznosc};" +
                    $"\n\t-------------------------------------------";
            }
            MessageBox.Show(dsstr);
            dsbtntak.Visible = false;
            dsbtnnie.Visible = false;
            this.Controls.Remove(dsbtnprzyciskakceptacji);
            dsbtnprzyciskakceptacji.Dispose();
            this.Controls.Remove(dstxtgornagranica);
            dstxtgornagranica.Dispose();
            this.Controls.Remove(dstxtdolnagranica);
            dstxtdolnagranica.Dispose();
            this.Controls.Remove(dsetykirtagornej);
            dsetykirtagornej.Dispose();
            this.Controls.Remove(dsetykietadolnej);
            dsetykietadolnej.Dispose();
            dscmbWaluta.Enabled = true;
            dsb.dsEdytujText(dstb, "Select a currency...");
        }
        private void dsReset()
        {
            dsb.dsEdytujText(dstb, "Set the number of denominations randomly ?");
            dsb.dsEdytujText(dstbWrzuconeMonety, "");
            dscmbWaluta.Text = "";
            dsbtntak.Visible = true;
            dsbtnnie.Visible = true;
            dscmbRodzajPlatnosci.Text = "";
            dsbtnplace.Enabled = false;
            dslblplatnosc.Visible = false;
            dscmbRodzajPlatnosci.Enabled = false;
            dsb = new dsBankomat();
        } 

        private void dspbpinpad_Click(object sender, EventArgs e)
        {
            dsPlatnosc.dsZaplacKartą(dsb, dsDostepneProdukty, ds_random.Next(1, 20));
            dsReset();
        }

        private void dsbtnplace_Click(object sender, EventArgs e)
        {
            dsPlatnosc.dsZaplacGotówką(dsb, dsDostepneProdukty, dsPojemnikiNominalow);
            dsReset();
        }

      
    }
}
