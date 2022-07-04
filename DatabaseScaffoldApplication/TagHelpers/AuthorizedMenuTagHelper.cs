using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.TagHelpers
{
    // this format all attributes is required 
    //[HtmlTargetElement("authorized-menu", Attributes = "register-text,login-text,logout-text")]

    // format below code attributes is optional
    [HtmlTargetElement("authorized-menu")]
    [HtmlTargetElement("authorized-menu", Attributes = "register-text")]
    [HtmlTargetElement("authorized-menu", Attributes = "login-text")]
    [HtmlTargetElement("authorized-menu", Attributes = "logout-text")]


    public class AuthorizedMenuTagHelper: TagHelper
    {
        public string RegisterText { get; set; } = "Register";
        public string LoginText { get; set; } = "Login";
        public string LogOutText { get; set; } = "Sign Out";

        private IHttpContextAccessor _httpContextAccessor;

        public AuthorizedMenuTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "AuthorizedMenu";
            output.TagMode = TagMode.StartTagAndEndTag;


            if(!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var sb = new StringBuilder();
                sb.AppendFormat($"<ul class='navbar-nav flex-grow-1'><li class='nav-item float-right'><a class='nav-link text-dark' href='/Account/Login' >{LoginText}</a></li><li class='nav-item float-right'><a class='nav-link text-dark' href='/Account/Register'>{RegisterText}</a></li></ul>");

                output.PostContent.SetHtmlContent(sb.ToString());
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendFormat($"<ul class='navbar-nav flex-grow-1'><li class='nav-item dropdown'><a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'> Profile</a><div class='dropdown-menu' aria-labelledby='navbarDropdown'><a class='dropdown-item' href='/Account/LogOut'>{LogOutText}</a></div></li></ul>");

                output.PostContent.SetHtmlContent(sb.ToString());
            }


       

            return base.ProcessAsync(context, output);
        }
    }
}
