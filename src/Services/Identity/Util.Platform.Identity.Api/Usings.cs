﻿global using System;
global using System.Threading.Tasks;
global using System.Linq;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Util.Microservices.Dapr;
global using Util.Applications.Trees;
global using Util.Applications.Controllers;
global using Util.Applications.Properties;
global using Util.Applications.Models;
global using Util.Ui.NgZorro.Controllers;
global using Util.Sessions;
global using Util.Tenants;
global using Util.Data.EntityFrameworkCore;
global using Util.Data;
global using Util.Microservices.HealthChecks;
global using Util.Microservices.Dapr.Events;
global using Util.Platform.Share;
global using Util.Platform.Share.Config;
global using Util.Platform.Identity.Api;
global using Util.Platform.Identity.Data;
global using Util.Platform.Identity.Applications.Authorization;
global using Util.Platform.Share.Identity.Events;
global using Util.Platform.Share.Identity.Applications;
global using Util.Platform.Share.Identity.Applications.Services.Abstractions;
global using Util.Platform.Share.Identity.Applications.Options;