using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class App : Application
    {

        public static Game CurrentGame { get; private set; }
        public static IFileHelper FileHelper { get; private set; }
        static Uri JsonQuestionsUri {
            get {
                return new Uri("https://www.dropbox.com/s/racrgjrsq2xcwdu/questions.json?raw=1");
            }
        }
         
        public App()
        { 
            MainPage = new NavigationPage(new HomePage()); 
            FileHelper = DependencyService.Get<IFileHelper>();
        }

        protected override async void OnStart()
        {
            List<QuizQuestion> questions = null;
            string result = null;
            if (CrossConnectivity.Current.IsConnected)
            {
                HttpClient httpClient = new HttpClient();
                result = await httpClient.GetStringAsync(JsonQuestionsUri);
                if (result != null)
                {
                    await FileHelper.SaveLocalFileAsync("cachedquestions.json", result);
                }
            }
            else
            {
                result = await FileHelper.LoadLocalFileAsync("cachedquestions.json");
                if (result == null)
                {
                    StreamReader stream = new StreamReader(
                        typeof(App)
                        .GetTypeInfo()
                        .Assembly
                        .GetManifestResourceStream("eXam.Data.questions.json"));
                    result = await stream.ReadToEndAsync();
                }
            }
            questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(result);
            CurrentGame = new Game(questions);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        { 
        }
    }
}
