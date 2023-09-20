using CommunityToolkit.Maui.Alerts;
using DashainWishes.Data;
using Plugin.MauiMTAdmob;

namespace DashainWishes.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        AddEvenetListener();
        homeBannerAds.AdsId = Ads.BannerAdsId;
    }

    private void AddEvenetListener()
    {
        copyright.Text = $"Copyright © {DateTime.Now.Year} AliveCoder";
        stausOfDay.Text = RandomStatus(AppData.StatusOfDayCollections);

        nepaliBtn.Clicked += async (s, e) =>
        {
            CrossMauiMTAdmob.Current.LoadInterstitial(Ads.InterstitialAdsId);
            await Navigation.PushAsync(new StatusPage(1));
        };

        englishBtn.Clicked += async (s, e) =>
        {
            CrossMauiMTAdmob.Current.LoadInterstitial(Ads.InterstitialAdsId);
            await Navigation.PushAsync(new StatusPage(2));
        };

        copyBtn.Clicked += async (sender, e) =>
        {
            await Clipboard.SetTextAsync(stausOfDay.Text);
            var toast = Toast.Make("Status copied to clipboard!!");
            await toast.Show();
        };

        shareBtn.Clicked += async (sender, e) =>
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = stausOfDay.Text,
                Title = "Share Status"
            });
        };
    }

    private static string RandomStatus(List<string> statusList)
    {
        Random random = new();
        int index = random.Next(statusList.Count);
        return statusList[index];
    }

}