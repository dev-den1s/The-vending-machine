using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Savchenko51908
{
    static class dsPlatnosc
    {
        public static bool dsZaplacKartą(dsBankomat bankomat, List<dsProduktyStruct> prod, decimal sum)
        {
            if (bankomat.dsCena > sum)
            {
                System.Windows.Forms.MessageBox.Show("\tRefusal\n\t-------------------------------------------" +
                    "\n\t You dont have enough money on you bill...");
                return false;
            }
             bankomat.dsOdebranieProduktu(prod);
             dsParagon(bankomat);
             return true;           
        }
        public static bool dsZaplacGotówką(dsBankomat bankomat, List<dsProduktyStruct> prod, dsNominaly [] nominaly)
        {
            decimal ds_reszta = 0.00M;
            if (bankomat.dsCena > bankomat.dsZaplacono)
            {
                System.Windows.Forms.MessageBox.Show("\tRefusal\n\t-------------------------------------------" +
                    $"\n\t You dont have enough money on you bill...\n\tTo pay: {bankomat.dsCena-bankomat.dsZaplacono}...");
                return false;
            }
            else
            {
                ds_reszta = bankomat.dsZaplacono - bankomat.dsCena;
                if (ds_reszta > 0)
                {
                    if (dsUdaSieWydacReszte(ds_reszta, nominaly))
                    {
                        dsParagon(bankomat, dsOddajReszte(ds_reszta, nominaly));
                        bankomat.dsOdebranieProduktu(prod);
                        return true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("\tRefusal\n\t-------------------------------------------" +
                    $"\n\t The veding machine doesnt have enough coins to give change: {bankomat.dsCena - bankomat.dsZaplacono}" +
                    $"\n\tPlease, pay by card or find another coins...");
                        return false;
                    }
                }
                else
                {
                    dsParagon(bankomat);
                    bankomat.dsOdebranieProduktu(prod);
                    return true;
                }
            }            
        }
        public static void dsParagon(dsBankomat bankomat)
        {
            string str = "";
            str = $"\tThank you for shopping <EATPlus>\n\t-------------------------------------------" +
                $" \n\tYour choice:\n\tProduct:{bankomat.dsWybranyProdukt.ToString()};" +
             $"\n\tPrice:{bankomat.dsCena};\n\tCurrency:{bankomat.dsWaluta.ToString()}" +
           $"\n\t-------------------------------------------\n\tPlease, dont forget, to take your purchase...";
            
            System.Windows.Forms.MessageBox.Show(str);
        }
        public static void dsParagon(dsBankomat bankomat, string str)
        {
            string dsstr = "";
            dsstr = $"\tThank you for shopping <EATPlus>\n\t-------------------------------------------" +
                    $" \n\tYour choice:\n\tProduct:{bankomat.dsWybranyProdukt.ToString()};" +
             $"\n\tPrice:{bankomat.dsCena};\n\tCurrency:{bankomat.dsWaluta.ToString()}" +
           $"\n\t-------------------------------------------\n\tPlease, dont forget, to take your purchase...";
            dsstr += str;
            System.Windows.Forms.MessageBox.Show(dsstr);
        }
        public static bool dsUdaSieWydacReszte(decimal reszta, dsNominaly[] nominaly)
        {
            decimal dskapitalbankomatu = 0;
            foreach(dsNominaly i in nominaly)
            {
                if (i.dslicznosc > 0 && i.dswartosc <= reszta)
                    dskapitalbankomatu += i.dslicznosc * i.dswartosc; 
            }
            if (dskapitalbankomatu >= reszta)
                return true;
            else return false;
        }
        public static string dsOddajReszte(decimal reszta, dsNominaly[] nominaly)
        {
            int dsindexpojemnikanominalow = 0, dsliczbanominalow;
            string str = $"\n\t--------------------------------------------\n\t--------------------------------------------" +
                $"\n\tYour change {reszta}:" +
                $"\n\t--------------------------------------------";
            while ((reszta > 0.0M) && (dsindexpojemnikanominalow < nominaly.Length))
            {
                dsliczbanominalow = (ushort)(reszta / nominaly[dsindexpojemnikanominalow].dswartosc);
                if (dsliczbanominalow > nominaly[dsindexpojemnikanominalow].dslicznosc)
                {
                    dsliczbanominalow = nominaly[dsindexpojemnikanominalow].dslicznosc;
                    nominaly[dsindexpojemnikanominalow].dslicznosc = 0;
                }
                else
                {
                    nominaly[dsindexpojemnikanominalow].dslicznosc = (nominaly[dsindexpojemnikanominalow].dslicznosc -
                       dsliczbanominalow);
                }
                if (dsliczbanominalow > 0)
                {
                    str += $"\n\tThe number of denominations - {dsliczbanominalow};\n\tThe cost of denominations - {nominaly[dsindexpojemnikanominalow].dswartosc}" +
                        $"\n\t--------------------------------------------";
                }
                reszta -= dsliczbanominalow * nominaly[dsindexpojemnikanominalow].dswartosc;
                dsindexpojemnikanominalow++;
            }
            return str;
        }
    }
}
