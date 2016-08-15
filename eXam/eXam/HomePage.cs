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
            this.Content = layout;
            this.Content.VerticalOptions = LayoutOptions.Center;
            this.Content.HorizontalOptions = LayoutOptions.Center;

            var btn = new Button();
            btn.Text = "Start eXam!";
            btn.TextColor = Color.White;
            btn.BackgroundColor = Color.Blue;

            btn.Clicked += async (o, e) =>
            {
                await this.Navigation.PushAsync(new QuestionPage());
            };

            var image = new Image();
            image.Source = ImageSource.FromResource("eXam.Images.background.jpg");
            image.Aspect = Aspect.AspectFill;
            
            layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(btn, new Rectangle(0.5, 0.5, 150, 60));
            NavigationPage.SetHasNavigationBar(this, false);



        }
    }
}
