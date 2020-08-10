using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using LinXi_IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinXi_IdentityServer.ServerModel
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public ResourceOwnerPasswordValidator()
        {
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            LinXi_Model.db_erpContext db = new LinXi_Model.db_erpContext();

            var user = db.AcUserinfo.FirstOrDefault(u => u.Account == context.UserName && context.Password == u.Pwd);
            if (user != null)
            {
                context.Result = new GrantValidationResult(
                subject: context.UserName,
                authenticationMethod: "custom",
                claims: new Claim[]
                {
                          //账号id
                          new Claim("account_id",user.Id.ToString()),
                          //操作人id
                         new Claim("operator_id",user.StaffId.ToString()),
                          //操作人名字
                          new Claim("operator_name",user.Staff.Name.ToString())
                });
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
            //context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
        }

        //可以根据需要设置相应的Claim
        private Claim[] GetUserClaims()
        {
            return new Claim[]
            {
            new Claim("UserId", 1.ToString()),
            new Claim(JwtClaimTypes.Name,"wjk"),
            new Claim(JwtClaimTypes.GivenName, "jaycewu"),
            new Claim(JwtClaimTypes.FamilyName, "yyy"),
            new Claim(JwtClaimTypes.Email, "977865769@qq.com"),
            new Claim(JwtClaimTypes.Role,"admin")
            };
        }
    }
}