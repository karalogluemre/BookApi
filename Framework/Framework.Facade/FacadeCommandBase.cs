using Framework.Core.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Framework.Facade
{
    public class FacadeCommandBase : Controller
    {
        public FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        public ICommandBus CommandBus { get; private set; }
    }
}
