using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Saleular.Classes.Repositories;
using Saleular.Interfaces;
using Saleular.Models;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace Saleular.Controllers
{
    /// <summary>
    /// Saleluar APIs
    /// </summary>
    //[Authorize]
    [RoutePrefix("gadgets")]
    public class SaleularServicesController : ApiController
    {
        protected IGadgetRepository GadgetRepository;
        /// <summary>
        /// saleular api
        /// </summary>
        public SaleularServicesController()
        {
            GadgetRepository = new GadgetRepository();
        }

        /// <summary>
        /// returns all available gadgets
        /// </summary>
        /// <returns>list of gadgets</returns>        
        [Route]
        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<Gadget> gadgets = GadgetRepository.GetGadgets();

            if (gadgets == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gadgets);
            }
        }

        /// <summary>
        /// returns a single gadget by id
        /// </summary>
        /// <param name="id">gadget id</param>
        /// <returns>gadget object</returns>
        [Route("{id}")]
        [ResponseType(typeof(Gadget))]
        [HttpGet]
        public IHttpActionResult GetGadget(int id)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            Gadget gadget = GadgetRepository.GetGadgetById(id);

            if (gadget == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gadget);
            }
        }

        /// <summary>
        /// returns a list of gadget models for a given type
        /// </summary>
        /// <param name="type">gadget type</param>
        /// <returns>list of models</returns>
        [Route("{type}/models")]
        [ResponseType(typeof(IEnumerable<string>))]
        [HttpGet]
        public IHttpActionResult GetGadget(string type)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            IEnumerable<string> models = GadgetRepository.GetDistinctModels(type).ToList();

            if (!models.Any())
            {
                return NotFound();
            }

            return Ok(models);
        }

        /// <summary>
        /// returns a list of gadgets with a specific type and model
        /// </summary>
        /// <param name="type">gadget type</param>
        /// <param name="model">gadget model</param>
        /// <returns>list of gadgets</returns>
        [Route("{type}/{model}")]
        [ResponseType(typeof(IEnumerable<Gadget>))]
        [HttpGet]
        public IHttpActionResult GetGadget(string type, string model)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            IEnumerable<Gadget> gadgets = GadgetRepository.GetGadgets().Where(g => g.Type == type
                && g.Model == model).ToList();

            if (!gadgets.Any())
            {
                return NotFound();
            }

            return Ok(gadgets);
        }

        /// <summary>
        /// returns a list of gadgets with a specific type model and carrier
        /// </summary>
        /// <param name="type">gadget type</param>
        /// <param name="model">gadget model</param>
        /// <param name="carrier">gadget carrier</param>
        /// <returns>list of gadgets</returns>
        [Route("{type}/{model}/{carrier}")]
        [ResponseType(typeof(IEnumerable<Gadget>))]
        [HttpGet]
        public IHttpActionResult GetGadget(string type, string model, string carrier)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            IEnumerable<Gadget> gadgets = GadgetRepository.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier).ToList();

            if (!gadgets.Any())
            {
                return NotFound();
            }

            return Ok(gadgets);
        }

        /// <summary>
        /// returns a list of gadgets with a specific type model carrier and capacity
        /// </summary>
        /// <param name="type">gadget type</param>
        /// <param name="model">gadget model</param>
        /// <param name="carrier">gadget carrier</param>
        /// <param name="capacity">gadget capacity</param>
        /// <returns>list of gadgets</returns>
        [Route("{type}/{model}/{carrier}/{capacity}")]
        [ResponseType(typeof(IEnumerable<Gadget>))]
        [HttpGet]
        public IHttpActionResult GetGadget(string type, string model, string carrier, string capacity)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            IEnumerable<Gadget> gadgets = GadgetRepository.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier
                && g.Capacity == capacity).ToList();

            if (!gadgets.Any())
            {
                return NotFound();
            }

            return Ok(gadgets);
        }

        /// <summary>
        /// create a new gadget
        /// </summary>
        /// <param name="gadget">gadget</param>
        /// <returns>new gadget uri</returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Post(Gadget gadget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GadgetRepository.InsertGadget(gadget);
            GadgetRepository.Save();

            return CreatedAtRoute("SaleularServices", new { id = gadget.GadgetId }, gadget);
        }

        /// <summary>
        /// update an existing gadget
        /// </summary>
        /// <param name="id">existing gadget id</param>
        /// <param name="gadget">gadget</param>
        /// <returns>NoContent</returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(int id, Gadget gadget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gadget.GadgetId)
            {
                return BadRequest();
            }

            try
            {
                GadgetRepository.UpdateGadget(gadget);
                GadgetRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GadgetRepository.GetGadgetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// delete a gadget
        /// </summary>
        /// <param name="id">existing gadget id</param>
        /// <returns>Ok</returns>
        [Route]
        [HttpDelete]        
        public IHttpActionResult Delete(int id)
        {
            Gadget gadget = GadgetRepository.GetGadgetById(id);
            if (gadget == null)
            {
                return NotFound();
            }

            GadgetRepository.DeleteGadget(id);
            GadgetRepository.Save();

            return Ok(gadget);
        }
    }
}
