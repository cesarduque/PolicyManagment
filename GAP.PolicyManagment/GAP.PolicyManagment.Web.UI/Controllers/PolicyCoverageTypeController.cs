using GAP.PolicyManagment.Web.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GAP.PolicyManagment.Web.UI.Controllers
{
    public class PolicyCoverageTypeController : Controller
    {
        // GET: PolicyCoverageType
        public ActionResult Index()      
        {
            return View();
        }

        // GET: PolicyCoverageType/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                TempData["PolicyId"] = id;
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policyCoverageType = JsonConvert.DeserializeObject<ICollection<Policy>>(json).FirstOrDefault();
                    ViewBag.Records = true;
                    return View(policyCoverageType.PolicyCoverageTypes);
                }
                else
                {
                    ViewBag.Records = false;
                    return View();
                }
            }
        }

        // GET: PolicyCoverageType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyCoverageType/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var newPolicyCoverageType = new PolicyCoverageType
                {   
                    PolicyId = Convert.ToInt32(TempData["PolicyId"]),
                    CoverageTypeId = Convert.ToInt32(collection["CoverageTypeId"]),
                    CoveragePercentage = Convert.ToInt32(collection["CoveragePercentage"])                   
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var client = JsonConvert.SerializeObject(newPolicyCoverageType);
                    var data = new StringContent(client, Encoding.UTF8, "application/json");

                    var url = $"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyCoverageTypes";

                    var response = await httpClient.PostAsync(url, data);
                }

                return RedirectToAction("Details", new { id = TempData["PolicyId"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyCoverageType/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}policyCoverageTypes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policyCoverageType = JsonConvert.DeserializeObject<ICollection<PolicyCoverageType>>(json);
                    return View(policyCoverageType.FirstOrDefault());
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: PolicyCoverageType/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                var newPolicyCoverageType = new PolicyCoverageType
                {
                    PolicyCoverageTypeId = id,
                    PolicyId = Convert.ToInt32(TempData["PolicyId"]),
                    CoverageTypeId = Convert.ToInt32(collection["CoverageTypeId"]),
                    CoveragePercentage = Convert.ToInt32(collection["CoveragePercentage"])
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var client = JsonConvert.SerializeObject(newPolicyCoverageType);
                    var data = new StringContent(client, Encoding.UTF8, "application/json");

                    var url = $"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyCoverageTypes";

                    var response = await httpClient.PutAsync(url, data);
                }

                return RedirectToAction("Details", new { id = TempData["PolicyId"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyCoverageType/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyCoverageTypes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policyCoverageType = JsonConvert.DeserializeObject<ICollection<PolicyCoverageType>>(json);
                    return View(policyCoverageType.FirstOrDefault());
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: PolicyCoverageType/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyCoverageTypes/{id}");
                }

                return RedirectToAction("Details", new { id = TempData["PolicyId"] });
            }
            catch
            {
                return View();
            }
        }
    }
}
