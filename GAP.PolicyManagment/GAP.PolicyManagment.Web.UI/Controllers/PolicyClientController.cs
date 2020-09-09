using GAP.PolicyManagment.Web.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GAP.PolicyManagment.Web.UI.Controllers
{
    public class PolicyClientController : Controller
    {
        // GET: PolicyClient
        public ActionResult Index()
        {
            return View();
        }

        // GET: PolicyClient/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                TempData["ClientId"] = id;
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Clients/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policyClient = JsonConvert.DeserializeObject<ICollection<Client>>(json).FirstOrDefault();
                    ViewBag.Records = true;
                    return View(policyClient.PolicyClients);
                }
                else
                {
                    ViewBag.Records = false;
                    return View();
                }
            }

        }

        // GET: PolicyClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyClient/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var newPolicyClient = new PolicyClient
                {
                    ClientId = Convert.ToInt32(TempData["ClientId"]),
                    PolicyId = Convert.ToInt32(collection["PolicyId"])
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var policyClient = JsonConvert.SerializeObject(newPolicyClient);
                    var data = new StringContent(policyClient, Encoding.UTF8, "application/json");

                    var url = $"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyClients";

                    var response = await httpClient.PostAsync(url, data);
                }

                return RedirectToAction("Details", new { id = TempData["ClientId"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PolicyClient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyClient/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyClients/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policyClient = JsonConvert.DeserializeObject<ICollection<PolicyClient>>(json);
                    return View(policyClient.FirstOrDefault());
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: PolicyClient/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}PolicyClients/{id}");
                }

                return RedirectToAction("Details", new { id = TempData["ClientId"] });
            }
            catch
            {
                return View();
            }
        }
    }
}
