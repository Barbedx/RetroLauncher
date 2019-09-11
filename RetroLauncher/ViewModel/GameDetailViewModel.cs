﻿using GalaSoft.MvvmLight;
using RetroLauncher.Data.Model;
using RetroLauncher.Data.Service;
using RetroLauncher.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroLauncher.ViewModel
{
    public class GameDetailViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService _navigationService;
        private readonly IRepository _repository;

        private Game selectedGame;
        public Game SelectedGame { get { return selectedGame; } set { selectedGame = value; } }

        public GameDetailViewModel(IFrameNavigationService navigationService, IRepository repository)
        {
            _repository = repository;
            _navigationService = navigationService;            
            MessengerInstance.Register<Game>(this, RefreshGame);
            RefreshGame((Game)_navigationService.Parameter);
        }

        private async void RefreshGame(Game recGame)
        {
            SelectedGame = await _repository.GetGameById(recGame.GameId);
            RaisePropertyChanged(nameof(SelectedGame));
        }
    }
}
