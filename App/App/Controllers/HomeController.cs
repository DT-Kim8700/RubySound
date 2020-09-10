﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using App.Models.ViewModels;
using App.Models.Account;
using Microsoft.AspNetCore.Identity;
using App.Repository;

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


        public IActionResult Index()
        {
            return View();
        }

        

        // 학원 소개
        public IActionResult Introduce()
        {
            return View();
        }

        // 로그인
        public IActionResult Login()
        {
            return View();
        }

        // 계정 가입 페이지
        public IActionResult Join()
        {
            return View();
        }

        // 커뮤니티
        public IActionResult Community()
        {
            return View();
        }


        // 계정 가입
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
    }
}
