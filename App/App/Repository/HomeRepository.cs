using App.Data;
using App.Models.Account;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationContext context;

        public HomeRepository(ApplicationContext context)
        {
            this.context = context;
        }


        // 게시판 글 리스트 페이징 처리
        public IEnumerable<CommunityListViewModel> GetAllCommunitis(int num)
        {
            num = num == 0 ? 1 : num;
            
            num = (num - 1) * 10;       // skip 개수

            if (CommunityListViewModel.Count == 0)      // 처음 한 번만 작동
            {
                var countQuery = (from accountUser in context.AccountUsers
                                 join community in context.Communitys
                                 on accountUser.Id equals community.Id
                                 orderby community.CommunityId descending
                                 select new { accountUser, community });

                CommunityListViewModel.Count = (countQuery.Count() + 9) / 10;
            }

            var query = (from accountUser in context.AccountUsers
                         join community in context.Communitys
                         on accountUser.Id equals community.Id
                         orderby community.CommunityId descending
                         select new { accountUser, community })
                         .Skip(num).Take(10);

            List<CommunityListViewModel> viewModel = new List<CommunityListViewModel>();

            foreach (var i in query)
            {
                viewModel.Add(new CommunityListViewModel
                {
                    AccountUser = i.accountUser,
                    Community = i.community,
                    Page = (num + query.Count() + 99) / 100      // 소속된 페이지
                });
            }

            return viewModel;
        }
    }
}
