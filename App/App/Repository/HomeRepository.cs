using App.Data;
using App.Models.Account;
using App.Models.Entity;
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
                    Page = (num + query.Count() + 9) / 10      // 소속된 페이지
                });
            }

            return viewModel;
        }


        // 글 본문
        public CommunityListViewModel GetCommunity(int CommunityId)
        {
            var query = (from accountUser in context.AccountUsers
                         join community in context.Communitys
                         on accountUser.Id equals community.Id
                         where community.CommunityId == CommunityId
                         select new { accountUser, community }).FirstOrDefault();

            CommunityListViewModel viewModel = new CommunityListViewModel
            {
                Community = query.community,
                AccountUser = query.accountUser
            };

            return viewModel;
        }

        // 커뮤니티 글 등록
        public void UploadCommunity(CommunityCreateViewModel model)
        {
            AccountUser accountUser = context.AccountUsers.Where(a => a.Email == model.AccountUser.Email).FirstOrDefault();

            var community = new Community
            {
                Title = model.Community.Title,
                Description = model.Community.Description,
                EnrollTime = DateTime.Now,
                Id = accountUser.Id
            };

            context.Communitys.Add(community);

            context.SaveChanges();
        }

        // 커뮤니티 글 삭제
        public void DeleteCommunity(int communityId)
        {
            Community community = context.Communitys.Where(c => c.CommunityId == communityId).FirstOrDefault();

            context.Communitys.Remove(community);

            context.SaveChanges();
        }
    }
}
