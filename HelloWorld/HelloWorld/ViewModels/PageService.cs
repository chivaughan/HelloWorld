using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class PageService : IPageService
    {
        private Page _pageContext;
        private Page PageContext
        {
            get
            {
                return _pageContext = Application.Current.MainPage as Page;
            }
            set
            {
                PageContext = value;
            }
        }
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await PageContext.DisplayAlert(title, message, accept, cancel);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await PageContext.DisplayAlert(title, message, cancel);
        }

        public Task PopAsync()
        {
            return PageContext.Navigation.PopAsync();
        }

        public Task PushAsync(Page page)
        {
            return PageContext.Navigation.PushAsync(page);
        }
    }
}
