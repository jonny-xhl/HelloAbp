﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Xhznl.HelloAbp.Volo.Abp.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("User")]
    [Route("api/identity/users")]
    public class HelloIdentityUserController : AbpController, IHelloIIdentityUserAppService
    {
        protected IHelloIIdentityUserAppService UserAppService { get; }
        public HelloIdentityUserController(IHelloIIdentityUserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        /// <summary>
        /// Add members to the organizational unit
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="ouId">ouId</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}/add-to-organization/{ouId}")]
        public virtual Task AddToOrganizationUnitAsync(Guid userId, Guid ouId)
        {
            return UserAppService.AddToOrganizationUnitAsync(userId, ouId);
        }
    }
}