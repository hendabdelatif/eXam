using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eXam
{
    public class HomePage : ContentPage
    {
         

      

        public HomePage()
        {
            var layout = new AbsoluteLayout();
            
           
            var btn = new Button();
            btn.Text = "Start eXam!";
            btn.TextColor = Color.White;
            btn.BackgroundColor = Color.Black;

            btn.Clicked += async (o, e) =>
            {
                await this.Navigation.PushAsync(new QuestionPage(new QuestionPageViewModel(App.CurrentGame)));
            };

            var image = new Image();
            image.Source = ImageSource.FromResource("eXam.Images.background.jpg");
            image.Aspect = Aspect.AspectFill;

            layout.Children.Add(image, new Rectangle(0f, 0f, 1f, 1f), AbsoluteLayoutFlags.All);
            layout.Children.Add(btn, new Rectangle(0.5, 0.5, 150, 60), AbsoluteLayoutFlags.PositionProportional);
            this.Content = new StackLayout()
            {
                BackgroundColor = Color.FromHex("#333"),
                Children = {
                    layout
                }
            };
            this.Content.VerticalOptions = LayoutOptions.CenterAndExpand;
            this.Content.HorizontalOptions = LayoutOptions.CenterAndExpand;

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
