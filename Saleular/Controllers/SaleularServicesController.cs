using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;

namespace Saleular.Controllers
{
    /// <summary>
    /// Saleluar APIs
    /// </summary>
    [Authorize]
    [RoutePrefix("gadgets")]
    public class SaleularServicesController : ApiController
    {
        protected IGadgetRepository Gadget;
        /// <summary>
        /// Saleular APIs
        /// </summary>
        public SaleularServicesController()
        {
            Gadget = new GadgetRepository();
        }

        /// <summary>
        /// Returns all available gadgets
        /// </summary>
        /// <returns>List of gadgets</returns>        
        [Route]
        [HttpGet]
        public IEnumerable<Gadget> Get()
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return gadgetsRepository.GetGadgets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gadget"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        // UPDATE
        public Gadget Post(Gadget gadget)
        {
            Gadget.UpdateGadget(gadget);
            return gadget;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gadget"></param>
        [Route]
        [HttpPut]
        // CREATE
        public void Put(Gadget gadget)
        {
            Gadget.InsertGadget(gadget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Route]
        [HttpDelete]
        // DELETE 
        public void Delete(int id)
        {
            Gadget.DeleteGadget(id);
        }

        /// <summary>
        /// Returns a single gadget by id
        /// </summary>
        /// <param name="id">Gadget id</param>
        /// <returns>Gadget object</returns>
        [Route("{id:int:min(1)}")]
        [HttpGet]
        public Gadget GetGadget(int id)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgetById(id);
        }

        /// <summary>
        /// Returns a list of gadget models for a given type
        /// </summary>
        /// <param name="type">Gadget type</param>
        /// <returns>List of models</returns>
        [Route("{type}/models")]
        [HttpGet]
        public IEnumerable<string> GetGadget(string type)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetDistinctModels(type);
        }

        /// <summary>
        /// Returns a list of gadgets with a specific type and model
        /// </summary>
        /// <param name="type">Gadget type</param>
        /// <param name="model">Gadget model</param>
        /// <returns></returns>
        [Route("{type}/{model}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model);
        }

        /// <summary>
        /// Returns a list of gadgets with a specific type model and carrier
        /// </summary>
        /// <param name="type">Gadget type</param>
        /// <param name="model">Gadget model</param>
        /// <param name="carrier">Gadget carrier</param>
        /// <returns></returns>
        [Route("{type}/{model}/{carrier}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model, string carrier)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="model"></param>
        /// <param name="carrier"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        [Route("{type}/{model}/{carrier}/{capacity}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model, string carrier, string capacity)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier
                && g.Capacity == capacity);
        }       
    }
}
