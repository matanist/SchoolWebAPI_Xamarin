using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTutorial1WebApi
{
	public partial class MainPage : ContentPage
	{
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			//Application.Current.MainPage = new StudentList();
			Navigation.PushModalAsync(new StudentList());
		}
		void Handle_AddStudent(object sender, EventArgs eventArgs)
		{
			Navigation.PushModalAsync(new AddStudent(null));
		}
		public MainPage()
		{
			InitializeComponent();
		}
	}
}
