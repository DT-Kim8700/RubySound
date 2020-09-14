using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models.ViewModels;
using App.Models.Account;
using App.Repository;
using Microsoft.AspNetCore.Identity;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository homeRepository;
        private readonly UserManager<AccountUser> userManager;
        private readonly SignInManager<AccountUser> signInManager;

        public HomeController(IHomeRepository homeRepository ,UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager)
        {
            this.homeRepository = homeRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // 홈페이지 첫 화면
        public IActionResult Index()
        {
            return View();
        }


        // 학원 소개 페이지
        public IActionResult Introduce()
        {
            return View();
        }


        // 로그인 페이지
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                // 세번째 인자 : 브라우저가 닫혀도 로그인 된 쿠키가 지속되어야 하는가에 대한 설정값
                // 네번째 인자 : 유저가 로그인 실패 했을 시 계정을 잠궈야하는지에 대한 설정값

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");   // 로그인 성공 시
                }

                ModelState.AddModelError("", "로그인 실패");
            }

            return View(model);     // 로그인 실패시
        }


        // 로그아웃
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();     // 로그인 관련 쿠기 정보를 삭제한다.

            return RedirectToAction("Index", "Home");
        }


        // 계정 가입 페이지
        public IActionResult Join()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(JoinViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountUser
                {
                    Email = model.Email,
                    UserName = model.Email,     // Email로 로그인시키기 위해 UserName에 Email값을 넣고 Name 컬럼으로 이름값을 따로 저장
                    Name = model.Name,
                    Gender = model.Gender,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");       // 회원 가입 성공시 로그인 페이지로 이동
                }

                ModelState.AddModelError("", "회원가입 실패");
            }

            return View(model);     // 회원 가입 실패시
        }


        // 커뮤니티 페이지
        public IActionResult Community(int id = 1)
        {
            var viewModel = homeRepository.GetAllCommunitis(id);

            return View(viewModel);
        }

        // 커뮤니티 페이지 - 본문 읽기
        public IActionResult Description(int id)
        {
            var viewModel = homeRepository.GetCommunity(id);

            return View(viewModel);
        }


        // 커뮤니티 글 작성
        public IActionResult CreateCommunity()     // id에 email 값이 들어온다.
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCommunity(CommunityCreateViewModel model)     // id에 email 값이 들어온다.
        {
            homeRepository.UploadCommunity(model);
            homeRepository.Save();

            return RedirectToAction("Community");

        }

        // 커뮤니티 글 삭제
        public IActionResult DeleteCommunity(int id)
        {
            homeRepository.DeleteCommunity(id);
            homeRepository.Save();

            return RedirectToAction("Community");
        }

        // 유저 정보 변경 -  update
        public IActionResult UpdateUser(string id)
        {
            AccountUserViewModel viewModel = new AccountUserViewModel()
            {
                Email = id
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(AccountUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                AccountUser accountUser = homeRepository.UpdateUser(model);

                if (accountUser != null)
                {
                    var result = await userManager.ChangePasswordAsync(accountUser, model.BeforePassword, model.Password);

                    if (result.Succeeded)       // 비밀번호 변경 성공시 DB변경까지 save한다.
                    {
                        homeRepository.Save();
                        return RedirectToAction("Index", "Home");   // 변경 성공 시
                    }

                    // 비밀번호 변경에 실패할 경우 DB변경 내용을 commit 하지 않는다.
                    ModelState.AddModelError("", "비밀번호는 8자이상, 영문 대소문자, 숫자,\n특수문자를 모두 포함해야 합니다.");

                }

            }

            return View(model);
        }

    }
}



