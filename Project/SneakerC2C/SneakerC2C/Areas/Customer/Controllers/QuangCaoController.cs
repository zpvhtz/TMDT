using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;
using Newtonsoft.Json;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class QuangCaoController : Controller
    {
       public ActionResult LoadQuangCao(string mavitri)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            QuangCao qc = new QuangCao();
            qc = quangcao.LoadQuangCao(mavitri);
            var json = JsonConvert.SerializeObject(qc, Formatting.Indented,
new JsonSerializerSettings
{
    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
});
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }
    }
}