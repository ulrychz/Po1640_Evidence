namespace Po1640_Evidence.Models
{
    public class Polozka
    {
		public Polozka() 
		{ 
			Datum = DateOnly.FromDateTime(DateTime.Now);
        }
		public Polozka(DateOnly datum, double naklady, double vynosy)
		{
			Datum = datum;
			Naklady = naklady;
			Vynosy = vynosy;
		}
		public DateOnly Datum { get; set; } //= DateOnly.FromDateTime(DateTime.Now);

        private double naklady;

		public double Naklady
		{
			get { return naklady; }
			set 
			{	
				if (naklady != value)
				{
					if(value < 0)
						naklady = 0;
					else
						naklady = value; 
				}
			}
		}
		private double vynosy;

		public double Vynosy
		{
			get { return vynosy; }
			set 
			{
                if (vynosy != value)
                {
                    vynosy = Math.Abs(value);
                }
            }
		}

		public double Zisk => Vynosy - Naklady;

        public override string ToString()
        {
            return $"Datum: {Datum} - Náklady {Naklady} - Výnosy {Vynosy} - Zisk {Zisk}";
        }
    }
}
