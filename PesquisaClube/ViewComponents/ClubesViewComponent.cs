using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaClube.Models;

namespace PesquisaClube.ViewComponents
{
    public class ClubesViewComponent : ViewComponent
    {
        private readonly ClubeContexto _clubeContexto;

        public ClubesViewComponent (ClubeContexto clubeContexto)
        {
            _clubeContexto = clubeContexto;
        }

       public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _clubeContexto.Clube.ToListAsync());
        }
    }
}
