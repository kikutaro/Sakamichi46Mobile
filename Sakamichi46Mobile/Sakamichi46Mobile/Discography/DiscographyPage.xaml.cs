using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Model;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Discography
{
    public partial class DiscographyPage : TabbedPage
    {
        private ObservableCollection<MusicCategory> nogiMusicCollection;
        private ObservableCollection<MusicCategory> keyaMusicCollection;

        private List<Music> nogiMusicList = new List<Music>();
        private List<Music> keyaMusicList = new List<Music>();

        public DiscographyPage(NogiController nogiCtrl, KeyakiController keyaCtrl)
        {
            InitializeComponent();

            nogiMusicCollection = new ObservableCollection<MusicCategory>();
            NogizakaMusics.ItemsSource = nogiMusicCollection;
            keyaMusicCollection = new ObservableCollection<MusicCategory>();
            KeyakiMusics.ItemsSource = keyaMusicCollection;

            Task<List<Music>> nogiMusics = GetAsyncDiscography(nogiCtrl);
            Task<List<Music>> keyaMusics = GetAsyncDiscography(keyaCtrl);

            InitEvent(nogiCtrl, nogiMusicCollection, searchNogiMusic, NogizakaMusics, nogiMusics);
            InitEvent(keyaCtrl, keyaMusicCollection, searchKeyaMusic, KeyakiMusics, keyaMusics);

            if (nogiMusics.IsCompleted)
            {
                nogiMusicList = nogiMusics.Result;
                ViewDiscography(nogiCtrl, nogiMusicCollection, nogiMusicList);
            }

            if(keyaMusics.IsCompleted)
            {
                keyaMusicList = keyaMusics.Result;
                ViewDiscography(keyaCtrl, keyaMusicCollection, keyaMusicList);
            }
        }

        private void UpdateMusicList(SakamichiController sakaCtrl, ObservableCollection<MusicCategory> musicCollection, Task<List<Music>> sakaMusics)
        {
            if (sakaMusics.IsCompleted)
            {
                if(Children.IndexOf(CurrentPage) == 0)
                {
                    nogiMusicList = sakaMusics.Result;
                }
                else if(Children.IndexOf(CurrentPage) == 1)
                {
                    keyaMusicList = sakaMusics.Result;
                }
                ViewDiscography(sakaCtrl, musicCollection, sakaMusics.Result);
            }
        }

        private void InitEvent(SakamichiController sakaCtrl, ObservableCollection<MusicCategory> musicCollection, SearchBar sakaSearch, ListView sakaListView, Task<List<Music>> sakaMusics)
        {
            sakaListView.Refreshing += async (sender, e) =>
            {
                ViewDiscography(sakaCtrl, musicCollection, await GetAsyncDiscography(sakaCtrl));
                sakaListView.IsRefreshing = false;

                UpdateMusicList(sakaCtrl, musicCollection, sakaMusics);
            };

            sakaSearch.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(sakaSearch.Text))
                {
                    ViewDiscography(sakaCtrl, musicCollection,
                        Children.IndexOf(CurrentPage) == 0 ?
                        nogiMusicList.Where(nm => nm.title.Contains(sakaSearch.Text)).ToList() :
                        keyaMusicList.Where(km => km.title.Contains(sakaSearch.Text)).ToList());
                }
                else
                {
                    ViewDiscography(sakaCtrl, musicCollection,
                        Children.IndexOf(CurrentPage) == 0 ? nogiMusicList : keyaMusicList);
                }
            };
        }

        public async Task<List<Music>> GetAsyncDiscography(SakamichiController sakaCtrl)
        {
            return await sakaCtrl.GetMusic();
        }

        public void ViewDiscography(SakamichiController sakaCtrl, ObservableCollection<MusicCategory> musicCollection, List<Music> musics)
        {
            if (musics != null)
            {
                if(musicCollection.Count > 0) musicCollection.Clear();
                Dictionary<string, List<Music>> dicMusic = musics
                    .ToLookup(s => s.releaseVersion)
                    .ToDictionary(
                        saka => saka.Key,
                        saka => saka.ToList()
                    );

                foreach (string sakaMusicCategory in dicMusic.Keys)
                {
                    MusicCategory s = new MusicCategory(sakaMusicCategory);
                    foreach (Music sm in dicMusic[sakaMusicCategory])
                    {
                        s.Add(sm);
                    };
                    musicCollection.Add(s);
                }
            }
        }

        public void SelectMusic(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                Music selectedMusic = (Music)e.SelectedItem;
                Debug.WriteLine(selectedMusic.lyricsUri);
                Navigation.PushModalAsync(new LyricPage(selectedMusic.lyricsUri.ToString()));
            }
        }
    }
}
