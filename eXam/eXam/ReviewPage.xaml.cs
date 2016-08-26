using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace eXam
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(ReviewPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm; 
            
        }

        protected async void itemTapped(object sender, ItemTappedEventArgs args)
        {
            QuizQuestionViewModel qqvm = args.Item as QuizQuestionViewModel;
            await DisplayAlert("Explanation", qqvm.Explanation.ToString(), "OK");
        }


    }
}
