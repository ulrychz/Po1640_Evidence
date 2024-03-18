using Microsoft.JSInterop;
using System.Globalization;

namespace Po1640_Evidence.Models
{
    public class Evidence
    {
        public Evidence(IJSRuntime js) 
        { 
            JS = js;
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs-CZ");
        }
        private IJSRuntime JS { get; set; }
        public List<Polozka> Polozky { get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();
        public string Vystup { get; set; } = "";
        public bool IsEditace { get; set; } = false;
        public void PridatZaznam()
        {
            //Polozky.Add(Polozka);
            //Polozka = new Polozka();
            Polozky.Add(new Polozka(datum: Polozka.Datum, Polozka.Naklady, Polozka.Vynosy));
        }
        public void ZobrazPocetZaznamu()
        {
            Vystup = $"Počet záznamů je {Polozky.Count}";
        }
        public void ZobrazZaznamy()
        {
            Vystup = $"Jednotlivé záznamy jsou:<br> {string.Join("<br>", Polozky)}";

        }
        public void Statistiky()
        {
            Vystup = "";
            Vystup += $"Minimum: {Minimum()} <br>";
            Vystup += $"Maximum: {Maximum()} <br>";
            Vystup += $"Průměr: {Prumer()}";
        }

        private double Minimum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Min(pol=>pol.Zisk);
        }

        private double Maximum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Max(pol => pol.Zisk);
        }
        private double Prumer()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Average(pol => pol.Zisk);
        }

        public async Task SmazatZaznam(Models.Polozka item)
        {
            var zprava = $"Chcete smazat {item.Datum} - Zisk: {item.Zisk} z vašeho seznamu?";
            //JS.InvokeVoidAsync("alert", zprava);
            if (await JS.InvokeAsync<bool>("confirm", zprava))
            {
                Polozky.Remove(item);
            }
        }
        public void Editace(Polozka item)
        {
            Polozka = item;
            IsEditace = true;
        }
        public void UkonciEditaci()
        {
            IsEditace = false;
            Polozka = new Polozka();
        }
    }

   
}
