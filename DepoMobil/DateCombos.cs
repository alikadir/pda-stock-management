#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace DepoMobil
{
    public class DateCombos
    {
       ComboBox Gun,  Ay,  yil;

		public DateCombos(ComboBox Gun, ComboBox Ay, ComboBox yil)
		{
			this.Gun = Gun;
			this.Ay = Ay;
			this.yil=yil;			
			FillDropDown();
		}

		void FillDropDown()
		{	
			
			DateTime ToDay = new DateTime(2007,1,1);
			
			int Day =1;
			int Month = 0;
			int Year = ToDay.Year;
			int LastDay = 31;
			for(int i = Day; i <= LastDay ; i++)
				Gun.Items.Add(i.ToString());
			int x = 0;
			for(int i = Month ; i < 12; i++)
			{
				
				Ay.Items.Add(ToDay.AddMonths(x).ToString("MMMM"));
				x++;

			}

			for(int i = 0;i < 5; i ++)
				yil.Items.Add(ToDay.AddYears(i).Year.ToString());	
		
			DateTime tmp = DateTime.Now;
			Gun.SelectedIndex= tmp.Day-1;
			Ay.SelectedIndex=tmp.Month-1;
			yil.SelectedIndex = 0;
		}

		public DateTime Getdate
		{
			get
			{
				int yilInt = Convert.ToInt16(yil.SelectedItem.ToString());
				int GunInt = Convert.ToInt16(Gun.SelectedItem.ToString());
				int AyInt = Convert.ToInt16(Ay.SelectedIndex+1);
				try
				{
					DateTime dt = new DateTime(yilInt,AyInt,GunInt);
					return dt;
				}
				catch
				{
					return DateTime.MinValue;					
				}

			}
		}

		public void SetDate(DateTime dt)
		{
			Gun.SelectedIndex=dt.Day-1;
			Ay.SelectedIndex = dt.Month-1;
			for(int i = 0 ; i < yil.Items.Count; i++)
				if(yil.Items[i].ToString() == dt.Year.ToString())
					yil.SelectedIndex= i;
		}
    }
}
