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
    class dsBankomat
    {
        public dsWaluta dsWaluta;
        dsRodzajPlatnosci dsRodzajPlatnosci;
        public dsProdukty dsWybranyProdukt { get; private set; }
        public decimal dsCena { get; private set; } = 0.00M;
        public decimal dsZaplacono { get; private set; } = 0.00M;
       
        public void dsSetRodzajPlatnosci(dsRodzajPlatnosci r)
        {
            dsRodzajPlatnosci = r;
        }
        public bool dsSetWybranyProdukt(List<dsProduktyStruct> prod, int index)
        {
            foreach(dsProduktyStruct i in prod)
            {
                if (i.produkt == (dsProdukty)index && i.ilosc > 0)
                {
                    dsWybranyProdukt = i.produkt;
                    if (dsWaluta == dsWaluta.PLN)
                        dsCena = i.cenapln;
                    else if (dsWaluta == dsWaluta.EUR)
                        dsCena = i.cenaeur;
                    else if (dsWaluta == dsWaluta.HRN)
                        dsCena = i.cenahrn;
                    return true;
                }
            }
            return false;
        }
        public bool dsSetZaplacono(TextBox tb, decimal c)
        {
            dsZaplacono+=c;
            tb.Text = dsZaplacono.ToString();
            if (dsZaplacono >= dsCena)
                return false;
            else return true;
        }
        public void dsEdytujText(TextBox tb, string str)
        {
            tb.Clear();
            tb.Text = str;
        }
        public int dsNapiszPlatnosc(TextBox tb)
        {
            tb.Clear();
            string str = $"Selected product - {dsWybranyProdukt.ToString()}.\n" +
               $"To pay - {dsCena}{dsWaluta.ToString()}.";
            if (this.dsRodzajPlatnosci == dsRodzajPlatnosci.Card)
            {
                str += "\nUse your card in the pin-pad...";
                tb.Text = str;
                return 1;
            }
            else str += " \n Throw in (the coins)...";
            tb.Text = str;
            return 0;
        }
        public void dsOdebranieProduktu(List<dsProduktyStruct> prod)
        {
            for (int i = 0; i < prod.Count; i++)
            {
                if (prod[i].produkt == dsWybranyProdukt) {
                     prod[i].ilosc--;
                }
            }          
        }
    }
}
