namespace Po1640_Evidence.Models
{
    public class Polozka
    {
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
                    if (value < 0)
                        vynosy = 0;
                    else
                        vynosy = value;
                }
            }
		}


	}
}
