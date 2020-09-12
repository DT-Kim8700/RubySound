using App.Models.Account;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IHomeRepository
    {
        void DeleteCommunity(int communityId);
        IEnumerable<CommunityListViewModel> GetAllCommunitis(int num);
        CommunityListViewModel GetCommunity(int CommunityId);
        void UploadCommunity(CommunityCreateViewModel model);
    }
}