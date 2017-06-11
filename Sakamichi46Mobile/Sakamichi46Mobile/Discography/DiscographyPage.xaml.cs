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

        public DiscographyPage(NogiController nogiCtrl, KeyakiController keyaCtrl, List<Music> nogiMusicList, List<Music> keyaMusicList)
        {
            InitializeComponent();

            nogiMusicCollection = new ObservableCollection<MusicCategory>();
            NogizakaMusics.ItemsSource = nogiMusicCollection;
            keyaMusicCollection = new ObservableCollection<MusicCategory>();
            KeyakiMusics.ItemsSource = keyaMusicCollection;

            this.nogiMusicList = nogiMusicList;
            this.keyaMusicList = keyaMusicList;

            InitEvent(nogiCtrl, nogiMusicCollection, searchNogiMusic);
            InitEvent(keyaCtrl, keyaMusicCollection, searchKeyaMusic);

            ViewDiscography(nogiCtrl, nogiMusicCollection, this.nogiMusicList);
            ViewDiscography(keyaCtrl, keyaMusicCollection, this.keyaMusicList);
        }

        private void InitEvent(SakamichiController sakaCtrl, ObservableCollection<MusicCategory> musicCollection, SearchBar sakaSearch)
        {
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
