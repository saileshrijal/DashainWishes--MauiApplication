using CommunityToolkit.Maui.Alerts;
using DashainWishes.Data;
using DashainWishes.Model;
using Plugin.MauiMTAdmob;

namespace DashainWishes.View;

public partial class StatusPage : ContentPage
{
    private readonly int _categoryId;
    public StatusPage(int categoryId)
    {
        InitializeComponent();
        _categoryId = categoryId;
        InitializeOnLoad();
        LoadStatusAsync();
        AddEvenntListener();
        statusBannerAds.AdsId = Ads.BannerAdsId;
        
    }

    private void AddEvenntListener()
    {
        NavigationTitle.Text = _categoryId == 1 ? "Nepali Dashain Wishes" : "English Dashain Wishes";
    }

    private async void LoadStatusAsync()
    {
        try
        {
            ListRefreshing.IsEnabled = true;
            ListRefreshing.IsRefreshing = true;
            await Task.Delay(1000);
            StatusList.ItemsSource = AppData.Statuses.Where(x => x.CategoryId == _categoryId).ToList();
            CrossMauiMTAdmob.Current.ShowInterstitial();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            ListRefreshing.IsRefreshing = false;
            ListRefreshing.IsEnabled = false;
        }
    }

    private void InitializeOnLoad()
    {
        BackBtn.Clicked += async (sender, e) =>
        {
            await Navigation.PopAsync();
        };
    }

    private async void CopyBtn_Clicked(object sender, EventArgs e)
    {
        var listItem = (sender as BindableObject)?.BindingContext as Status;
        if (listItem != null)
        {
            await Clipboard.SetTextAsync(listItem.Title);
            var toast = Toast.Make("Status copied to clipboard!!");
            await toast.Show();
        }

    }

    private void ShareBtn_Clicked(object sender, EventArgs e)
    {
        var listItem = (sender as BindableObject)?.BindingContext as Status;
        if (listItem != null)
        {
            Share.RequestAsync(new ShareTextRequest
            {
                Text = listItem.Title,
                Title = "Share Status"
            });
        }
    }
}