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
    public class PolicyController : Controller
    {
        // GET: Policy
        public async Task<ActionResult> Index()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies/0");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policy = JsonConvert.DeserializeObject<ICollection<Policy>>(json);
                    return View(policy);
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Policy/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: Policy/Create
        public async Task<ActionResult> Create()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}RiskTypes/0");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<ICollection<RiskType>>(json);

                    var model = new Policy
                    {
                        RiskTypeCollection = list.Select(c => new SelectListItem
                        {
                            Value = c.RiskTypeId.ToString(),
                            Text = c.Name
                        }
                            )
                    };
                    return View(model);
                }
                else
                {
                    return View();
                }

            }   
            
        }

        // POST: Policy/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var newPolicy = new Policy
                {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    StartDate = Convert.ToDateTime(collection["StartDate"]),
                    CoverageTime = Convert.ToInt32(collection["CoverageTime"]),
                    Price = Convert.ToDouble(collection["Price"]),
                    RiskTypeId = Convert.ToInt32(collection["RiskTypeId"]),
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var policy = JsonConvert.SerializeObject(newPolicy);
                    var data = new StringContent(policy, Encoding.UTF8, "application/json");

                    var url = $"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies";

                    var response = await httpClient.PostAsync(url, data);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policy = JsonConvert.DeserializeObject<ICollection<Policy>>(json);
                    return View(policy.FirstOrDefault());
                }
                else
                {                    
                    return View();
                }
            }
        }

        // POST: Policy/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                var updatePolicy = new Policy
                {
                    PolicyId = id,
                    Name = collection["Name"],
                    Description = collection["Description"],
                    StartDate = Convert.ToDateTime(collection["StartDate"]),
                    CoverageTime = Convert.ToInt32(collection["CoverageTime"]),
                    Price = Convert.ToDouble(collection["Price"]),
                    RiskTypeId = Convert.ToInt32(collection["RiskTypeId"]),
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var policy = JsonConvert.SerializeObject(updatePolicy);
                    var data = new StringContent(policy, Encoding.UTF8, "application/json");

                    var url = $"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies";

                    var response = await httpClient.PutAsync(url, data);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var policy = JsonConvert.DeserializeObject<ICollection<Policy>>(json);
                    return View(policy.FirstOrDefault());
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: Policy/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ConfigurationManager.AppSettings["BaseUrlApi"]}Policies/{id}");                                   
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
