using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GovernmentData.Models;

namespace GovernmentData.Controllers
{
    public class AwardRecipientsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AwardRecipients
        public IQueryable<AwardRecipient> GetAwardRecipients()
        {
            return db.AwardRecipients;
        }

        // GET: api/AwardRecipients/5
        [ResponseType(typeof(AwardRecipient))]
        public async Task<IHttpActionResult> GetAwardRecipient(int id)
        {
            AwardRecipient awardRecipient = await db.AwardRecipients.FindAsync(id);
            if (awardRecipient == null)
            {
                return NotFound();
            }

            return Ok(awardRecipient);
        }

        // PUT: api/AwardRecipients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAwardRecipient(int id, AwardRecipient awardRecipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != awardRecipient.Id)
            {
                return BadRequest();
            }

            db.Entry(awardRecipient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardRecipientExists(id))
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

        // POST: api/AwardRecipients
        [ResponseType(typeof(AwardRecipient))]
        public async Task<IHttpActionResult> PostAwardRecipient(AwardRecipient awardRecipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AwardRecipients.Add(awardRecipient);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = awardRecipient.Id }, awardRecipient);
        }

        // DELETE: api/AwardRecipients/5
        [ResponseType(typeof(AwardRecipient))]
        public async Task<IHttpActionResult> DeleteAwardRecipient(int id)
        {
            AwardRecipient awardRecipient = await db.AwardRecipients.FindAsync(id);
            if (awardRecipient == null)
            {
                return NotFound();
            }

            db.AwardRecipients.Remove(awardRecipient);
            await db.SaveChangesAsync();

            return Ok(awardRecipient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AwardRecipientExists(int id)
        {
            return db.AwardRecipients.Count(e => e.Id == id) > 0;
        }
    }
}