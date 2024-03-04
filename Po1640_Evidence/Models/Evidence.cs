namespace Po1640_Evidence.Models
{
    public class Evidence
    {
        public List<Polozka> Polozky { get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();
        public string Vystup { get; set; } = "";
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
    }
}
